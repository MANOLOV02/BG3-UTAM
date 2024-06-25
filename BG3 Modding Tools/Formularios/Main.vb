Imports System.ComponentModel
Imports System.Configuration
Imports System.Drawing.Imaging
Imports System.Net.NetworkInformation
Imports System.Reflection.Emit
Imports BG3_Modding_Tools.Funciones
Imports BG3_Modding_Tools.FuncionesHelpers
Imports LSLib.Granny
Imports Microsoft.VisualBasic.Devices
Public Class Main

    Private ProcessForm As ProcesarPaks
    Private ObjectExplorerForms As New List(Of Explorer_Form_Templates)
    Private IconExplorerForms As New List(Of Explorer_Form_Icons)
    Private StatsExplorerForms As New List(Of Explorer_Form_Stats)
    Private FlagsAndTagsExplorerForms As New List(Of Explorer_Form_Flags_and_Tags)
    Private VisualExplorerForms As New List(Of Explorer_Form_VisualTemplates)
    Private TtablesExplorerForms As New List(Of Explorer_Form_TreasureTables)
    Private ToolsOpened As New List(Of System.Windows.Forms.Form)
    Private LoaderOpened As ModLoader

    Public ActiveMod As UtamMod

    Public WithEvents CacheWorker As New BackgroundWorker With {.WorkerReportsProgress = True, .WorkerSupportsCancellation = True}
    Public WithEvents ProcessWorker As New BackgroundWorker With {.WorkerReportsProgress = True, .WorkerSupportsCancellation = True}
    Public Property BackgroundTasks As Integer = 0
    Public Property CanLoadCache As Boolean = False
    Public ReadOnly Property BackgroundActive
        Get
            If BackgroundTasks = 0 Then Return True
            Return False
        End Get
    End Property

    Public Event BackGroundWorkstarted()
    Public Event BackGroundWorkFinished()
    Public Event BackGroundReport(sender As Object, e As ProgressChangedEventArgs)
    Public Event BackGround_SingleTaskEnd(sender As Object, e As RunWorkerCompletedEventArgs)
    Public Event BackGround_SingleTaskStart(sender As Object, e As DoWorkEventArgs)

    Private Sub ProcesserAndNavigatorMenuItem_click(sender As Object, e As EventArgs) Handles ProcesserToolStripMenu.Click
        If IsNothing(ProcessForm) Then
            ProcessForm = New ProcesarPaks(Me)
            ProcessForm.Show()
            AddHandler ProcessForm.FormClosed, AddressOf ClosedChildForm
        Else
            ProcessForm.Activate()
        End If
        Pinta_status()
    End Sub

    Private Sub StartedTask()
        BackgroundTasks += 1
        RaiseEvent BackGroundWorkstarted()
    End Sub
    Private Sub FinishedTask()
        BackgroundTasks += -1
        If BackgroundTasks = 0 Then RaiseEvent BackGroundWorkFinished()
    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler CacheWorker.ProgressChanged, AddressOf Reporte_progreso
        AddHandler CacheWorker.RunWorkerCompleted, AddressOf Tarea_completada
        AddHandler CacheWorker.DoWork, AddressOf ProcesaCacheBackground
        ObjectsStatusLabel.Image = My.Resources.Warning.ToBitmap
        ObjectsStatusLabel.Text = "Objects not loaded"

        If GameEngine.CheckFolders Then
            CheckCache(True)
        Else
            CheckCache(False)
            ObjectsStatusLabel.Image = My.Resources.Warning.ToBitmap
            ObjectsStatusLabel.Text = "Check paths in processer"
            BackgroundWorkToolStripMenuItem.Enabled = False
        End If

        AddHandler ProcessWorker.ProgressChanged, AddressOf Reporte_progreso
        AddHandler ProcessWorker.RunWorkerCompleted, AddressOf Tarea_completada
        AddHandler ProcessWorker.DoWork, AddressOf ProcesaPacksBackground

        InfoIcon.Image = My.Resources.Info.ToBitmap
        CancellButton.Image = My.Resources.No_Ok.ToBitmap
        InfoIcon.Text = ""

        For Each nam In [Enum].GetNames(GetType(Bg3_Enum_Languages))
            Dim obj = New ToolStripMenuItem() With {.Checked = [Enum].GetNames(GetType(Bg3_Enum_Languages)).ToList().IndexOf(nam) = GameEngine.Settings.SelectedLocalization, .Text = nam, .Tag = [Enum].GetNames(GetType(Bg3_Enum_Languages)).ToList().IndexOf(nam)}
            If obj.Checked Then LocalizationButton.Text = nam
            AddHandler obj.Click, AddressOf LocaChange
            LocalizationButton.DropDownItems.Add(obj)
        Next
        'Dim st As New StikyNote
        'st.MdiParent = Me
        'st.Location = New Point(30, 245)
        'st.Show()
    End Sub

    Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        System.Threading.Thread.CurrentThread.CurrentCulture = New Globalization.CultureInfo("en-US")
        Application.CurrentCulture = New Globalization.CultureInfo("en-US")
        GameEngine.Load_Settings()
        OpenDetailsWindowsAlsoToolStripMenuItem.Checked = FuncionesHelpers.GameEngine.Settings.Showdetails
        Me.DoubleBuffered = True
    End Sub

    Private Sub Reporte_progreso(sender As Object, e As ProgressChangedEventArgs)
        Select Case True
            Case sender Is CacheWorker
                If e.ProgressPercentage < 0 Then
                    ToolStripProgressBar.Maximum = -e.ProgressPercentage
                Else
                    ToolStripProgressBar.Value += e.ProgressPercentage
                End If
                Pinta_contadores_cache()
            Case sender Is ProcessWorker
                Dim progr As BG3_Custom_Progreso_Class = CType(e.UserState, BG3_Custom_Progreso_Class)
                If progr.MaxP1 <> 0 Then ToolStripProgressBar.Value = CDbl(progr.ValueP1 / progr.MaxP1) * 100
                Pinta_contadores()
        End Select
        RaiseEvent BackGroundReport(sender, e)
    End Sub
    Public Sub Tarea_completada(sender As Object, e As RunWorkerCompletedEventArgs)
        Select Case True
            Case sender Is CacheWorker
                ToolStripProgressBar.Value = 0
                ToolStripProgressBar.Maximum = 100
                If e.Cancelled = True Then
                    ObjectsStatusLabel.Image = My.Resources.No_Ok.ToBitmap
                    ObjectsStatusLabel.Text = "Cancelled"
                Else
                    Dim result = CType(e.Result, Tuple(Of Boolean, String))
                    Select Case result.Item2.ToString
                        Case "check"
                            Select Case result.Item1
                                Case True
                                    ObjectsStatusLabel.Image = My.Resources.Ok.ToBitmap
                                    LoadCacheToolStripMenuItem1.Enabled = True
                                    ObjectsStatusLabel.Text = "Cache checked"
                                    CanLoadCache = True
                                Case False
                                    ObjectsStatusLabel.Image = My.Resources.No_Ok.ToBitmap
                                    LoadCacheToolStripMenuItem1.Enabled = False
                                    ObjectsStatusLabel.Text = "Cache corrupted"
                                    CanLoadCache = False
                            End Select
                        Case "checkandload"
                            Select Case result.Item1
                                Case True
                                    ObjectsStatusLabel.Image = My.Resources.Info.ToBitmap
                                    LoadCacheToolStripMenuItem1.Enabled = True
                                    ObjectsStatusLabel.Text = "Cache checked"
                                    CanLoadCache = True
                                    LoadCache()
                                Case False
                                    ObjectsStatusLabel.Image = My.Resources.No_Ok.ToBitmap
                                    LoadCacheToolStripMenuItem1.Enabled = False
                                    ObjectsStatusLabel.Text = "Cache corrupted"
                                    CanLoadCache = False
                            End Select
                        Case "load"
                            Select Case result.Item1
                                Case True
                                    GameEngine.Processed = True
                                    ObjectsStatusLabel.Text = "Cache loaded"
                                    ObjectsStatusLabel.Image = My.Resources.Ok.ToBitmap
                                    CanLoadCache = True
                                Case False
                                    ObjectsStatusLabel.Image = My.Resources.No_Ok.ToBitmap
                                    GameEngine.Processed = False
                                    ObjectsStatusLabel.Text = "Cache not loaded"
                                    Clear_Cache(New BackgroundWorker With {.WorkerReportsProgress = True, .WorkerSupportsCancellation = True})
                            End Select
                        Case "save"
                            Select Case result.Item1
                                Case True
                                    ObjectsStatusLabel.Image = My.Resources.Ok.ToBitmap
                                    GameEngine.Processed = True
                                    ObjectsStatusLabel.Text = "Cache saved"
                                    CanLoadCache = True
                                Case False
                                    ObjectsStatusLabel.Image = My.Resources.No_Ok.ToBitmap
                                    GameEngine.Processed = False
                                    ObjectsStatusLabel.Text = "Cache not saved"
                                    CanLoadCache = False
                            End Select
                        Case "clear"
                            Select Case result.Item1
                                Case True
                                    CanLoadCache = False
                                Case False

                            End Select
                        Case Else
                            Debugger.Break()
                    End Select
                End If
            Case sender Is ProcessWorker
                ToolStripProgressBar.Value = 0
                ToolStripProgressBar.Maximum = 100
                Select Case e.Cancelled
                    Case True
                        ObjectsStatusLabel.Image = My.Resources.No_Ok.ToBitmap
                        ObjectsStatusLabel.Text = "Cancelled"
                        If GameEngine.Processed = False Then Clear_Loaded()
                    Case False
                        Select Case e.Result
                            Case True
                                ToolStripProgressBar.Value = 0
                                ToolStripProgressBar.Maximum = GameEngine.ProcessedGameObjectList.Count
                                SaveCache()
                            Case False
                                ObjectsStatusLabel.Image = My.Resources.No_Ok.ToBitmap
                                ObjectsStatusLabel.Text = "Process error"
                                GameEngine.Processed = False
                                Clear_Loaded()
                        End Select
                End Select
        End Select

        Pinta_status()
        FinishedTask()
        RaiseEvent BackGround_SingleTaskEnd(sender, e)
    End Sub

    Private Sub Pinta_status()
        If CacheWorker.IsBusy Or ProcessWorker.IsBusy Then
            BackgroundWorkToolStripMenuItem.Enabled = False
            ProcesserToolStripMenu.Enabled = False
            CancellButton.Visible = True
            ModdsToolStripMenuItem.Enabled = False
            LaunchGameToolStripMenuItem.Enabled = False
            ProcessSinglePakToolStripMenuItem.Enabled = False
        Else
            BackgroundWorkToolStripMenuItem.Enabled = GameEngine.CheckFolders
            LoadCacheToolStripMenuItem1.Enabled = CanLoadCache
            ProcessSinglePakToolStripMenuItem.Enabled = GameEngine.Processed
            ProcesserToolStripMenu.Enabled = True
            ModdsToolStripMenuItem.Enabled = True
            LaunchGameToolStripMenuItem.Enabled = GameEngine.Check_folders_GameExe
            If IsNothing(ActiveMod) Then
                ToolsToolStripMenuItem1.Enabled = False
                LoadToolStripMenuItem.Enabled = True
                NewToolStripMenuItem.Enabled = True
                ProcessAndNavigateObjectsToolStripMenuItem.Enabled = True
            Else
                ToolsToolStripMenuItem1.Enabled = Not ActiveMod.CurrentMod.Isnew
                LoadToolStripMenuItem.Enabled = False
                NewToolStripMenuItem.Enabled = False
                ProcessAndNavigateObjectsToolStripMenuItem.Enabled = False
            End If

            CancellButton.Visible = False
        End If


        Pinta_contadores()
    End Sub

    Private Sub Pinta_contadores()
        LabeLNumObjects.Text = "Templates (" + GameEngine.ProcessedGameObjectList.Count.ToString("#,##0") + ")"
        LabelNumpacks.Text = "Packs (" + GameEngine.ProcessedPackList.Count.ToString("#,##0") + ")"
        LabelNumTraslations.Text = "Localizations (" + GameEngine.ProcessedLocalizationList.Count.ToString("#,##0") + ")"
        LabelNumStats.Text = "Stats (" + GameEngine.ProcessedStatList.Count.ToString("#,##0") + ")"
        VisualsCount.Text = "Visual Banks (" + GameEngine.ProcessedVisualBanksList.Count.ToString("#,##0") + ")"
        IconsCount.Text = "Icons (" + GameEngine.ProcessedIcons.Count.ToString("#,##0") + ")"
        AssetsCount.Text = "Assets (" + GameEngine.ProcessedAssets.Count.ToString("#,##0") + ")"
        LabelTreasureCount.Text = "Treasure tables (" + GameEngine.ProcessedTTables.Count.ToString("#,##0") + ")"
        FlagsandTagsCount.Text = "Flags and Tags (" + GameEngine.ProcessedFlagsAndTags.Count.ToString("#,##0") + ")"
    End Sub
    Private Sub Pinta_contadores_cache()
        Dim int0 As Integer = GameEngine.Cache_Object_List(0).Count
        Dim int1 As Integer = GameEngine.Cache_Object_List(2).Count
        Dim int2 As Integer = GameEngine.Cache_Object_List(1).Count
        Dim int3 As Integer = GameEngine.Cache_Object_List(3).Count
        Dim int4 As Integer = GameEngine.Cache_Object_List(4).Count
        Dim int5 As Integer = GameEngine.Cache_Object_List(6).Count
        Dim int6 As Integer = GameEngine.Cache_Object_List(7).Count
        Dim int7 As Integer = GameEngine.Cache_Object_List(8).Count
        Dim int8 As Integer = GameEngine.Cache_Object_List(10).Count
        LabeLNumObjects.Text = "Templates (" + int0.ToString("#,##0") + ")"
        LabelNumpacks.Text = "Packs (" + int1.ToString("#,##0") + ")"
        LabelNumTraslations.Text = "Localizations (" + int2.ToString("#,##0") + ")"
        LabelNumStats.Text = "Stats (" + int3.ToString("#,##0") + ")"
        VisualsCount.Text = "Visual Banks (" + int4.ToString("#,##0") + ")"
        IconsCount.Text = "Icons (" + int5.ToString("#,##0") + ")"
        AssetsCount.Text = "Assets (" + int6.ToString("#,##0") + ")"
        FlagsandTagsCount.Text = "Flags and Tags (" + int7.ToString("#,##0") + ")"
        LabelTreasureCount.Text = "Treasure tables (" + int8.ToString("#,##0") + ")"
    End Sub


    Public Sub LoadCache()
        StartedTask()
        CancellButton.Visible = True
        BackgroundWorkToolStripMenuItem.Enabled = False
        ProcesserToolStripMenu.Enabled = False
        ToolStripProgressBar.Value = 0
        ToolStripProgressBar.Maximum = 100
        ObjectsStatusLabel.Image = My.Resources.Info.ToBitmap
        ObjectsStatusLabel.Text = "Loading cache"
        CacheWorker.RunWorkerAsync("load")
        RaiseEvent BackGround_SingleTaskStart(ProcessWorker, New DoWorkEventArgs("load"))
    End Sub
    Public Sub ClearCache()
        StartedTask()
        CancellButton.Visible = True
        BackgroundWorkToolStripMenuItem.Enabled = False
        ProcesserToolStripMenu.Enabled = False
        ToolStripProgressBar.Value = 0
        ToolStripProgressBar.Maximum = 100
        ObjectsStatusLabel.Image = My.Resources.Info.ToBitmap
        ObjectsStatusLabel.Text = "Clearing cache"
        CacheWorker.RunWorkerAsync("clear")
        RaiseEvent BackGround_SingleTaskStart(ProcessWorker, New DoWorkEventArgs("clear"))
    End Sub
    Public Sub SaveCache()
        StartedTask()
        CancellButton.Visible = True
        BackgroundWorkToolStripMenuItem.Enabled = False
        ProcesserToolStripMenu.Enabled = False
        ToolStripProgressBar.Value = 0
        ToolStripProgressBar.Maximum = 100
        ObjectsStatusLabel.Image = My.Resources.Info.ToBitmap
        ObjectsStatusLabel.Text = "Saving cache"
        CacheWorker.RunWorkerAsync("save")
        RaiseEvent BackGround_SingleTaskStart(ProcessWorker, New DoWorkEventArgs("save"))
    End Sub

    Public Sub CheckCache(LoadAfter As Boolean)
        StartedTask()
        CancellButton.Visible = True
        BackgroundWorkToolStripMenuItem.Enabled = False
        ProcesserToolStripMenu.Enabled = False
        ToolStripProgressBar.Value = 0
        ToolStripProgressBar.Maximum = 100

        If LoadAfter Then
            CacheWorker.RunWorkerAsync("checkandload")
            RaiseEvent BackGround_SingleTaskStart(ProcessWorker, New DoWorkEventArgs("checkandload"))
        Else
            CacheWorker.RunWorkerAsync("check")
            RaiseEvent BackGround_SingleTaskStart(ProcessWorker, New DoWorkEventArgs("check"))
        End If

    End Sub
    Public Sub Processpacks(includemods As Boolean)
        StartedTask()
        CancellButton.Visible = True
        GameEngine.Processed = False
        BackgroundWorkToolStripMenuItem.Enabled = False
        ProcesserToolStripMenu.Enabled = False
        ModdsToolStripMenuItem.Enabled = False
        ToolStripProgressBar.Value = 0
        ToolStripProgressBar.Maximum = 100
        Clear_Loaded()
        ObjectsStatusLabel.Image = My.Resources.Info.ToBitmap
        ObjectsStatusLabel.Text = "Processing files"
        ProcessWorker.RunWorkerAsync(includemods)
        RaiseEvent BackGround_SingleTaskStart(ProcessWorker, New DoWorkEventArgs(includemods))
    End Sub

    Private Sub CancellBackground_ButtonClick(sender As Object, e As EventArgs) Handles CancellButton.Click
        Cancell_Background()
    End Sub

    Public Sub Cancell_Background()
        If CacheWorker.IsBusy Then CacheWorker.CancelAsync()
        If ProcessWorker.IsBusy Then ProcessWorker.CancelAsync()
        Pinta_status()
    End Sub

    Private Sub LoadCacheToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadCacheToolStripMenuItem1.Click
        LoadCache()
    End Sub
    Private Sub MenuClearCacheBackground_Click(sender As Object, e As EventArgs) Handles MenuClearCacheBackground.Click
        ClearCache()
    End Sub

    Private Sub VanillaGameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VanillaGameToolStripMenuItem.Click
        Processpacks(False)
    End Sub

    Private Sub GamePlusModsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GamePlusModsToolStripMenuItem.Click
        Processpacks(True)
    End Sub
    Private Sub LocaChange(sender As Object, e As EventArgs)
        LocalizationButton.Text = sender.text
        sender.checked = True
        GameEngine.Settings.SelectedLocalization = sender.tag
        For Each el In LocalizationButton.DropDownItems
            If el.tag <> sender.tag Then
                el.checked = False
            End If
        Next
    End Sub
    Private Sub ClosedChildForm(sender As Object, e As FormClosedEventArgs)
        Select Case sender.GetType
            Case GetType(ProcesarPaks)
                ProcessForm.Dispose()
                ProcessForm = Nothing
            Case GetType(UtamMod)
                For x = ToolsOpened.Count - 1 To 0 Step -1
                    If Not IsNothing(ToolsOpened(x)) Then ToolsOpened(x).Close()
                Next
                RemoveHandler ActiveMod.Changed_status, AddressOf ActiveMode_Changed
                ActiveMod.Dispose()
                ActiveMod = Nothing
            Case GetType(Explorer_Form_Templates)
                Dim ind As Integer = ObjectExplorerForms.IndexOf(sender)
                ObjectExplorerForms(ind).Dispose()
                ObjectExplorerForms(ind) = Nothing
                ObjectExplorerForms.Remove(ObjectExplorerForms(ind))
            Case GetType(Explorer_Form_Icons)
                Dim ind As Integer = IconExplorerForms.IndexOf(sender)
                IconExplorerForms(ind).Dispose()
                IconExplorerForms(ind) = Nothing
                IconExplorerForms.Remove(IconExplorerForms(ind))
            Case GetType(Explorer_Form_Stats)
                Dim ind As Integer = StatsExplorerForms.IndexOf(sender)
                StatsExplorerForms(ind).Dispose()
                StatsExplorerForms(ind) = Nothing
                StatsExplorerForms.Remove(StatsExplorerForms(ind))
            Case GetType(Explorer_Form_Flags_and_Tags)
                Dim ind As Integer = FlagsAndTagsExplorerForms.IndexOf(sender)
                FlagsAndTagsExplorerForms(ind).Dispose()
                FlagsAndTagsExplorerForms(ind) = Nothing
                FlagsAndTagsExplorerForms.Remove(FlagsAndTagsExplorerForms(ind))
            Case GetType(Explorer_Form_VisualTemplates)
                Dim ind As Integer = VisualExplorerForms.IndexOf(sender)
                VisualExplorerForms(ind).Dispose()
                VisualExplorerForms(ind) = Nothing
                VisualExplorerForms.Remove(VisualExplorerForms(ind))
            Case GetType(Explorer_Form_TreasureTables)
                Dim ind As Integer = TtablesExplorerForms.IndexOf(sender)
                TtablesExplorerForms(ind).Dispose()
                TtablesExplorerForms(ind) = Nothing
                TtablesExplorerForms.Remove(TtablesExplorerForms(ind))
            Case GetType(Containers_Editor), GetType(Dyes_Editor), GetType(Armors_Editor), GetType(Weapons_Editor), GetType(Consumables_Editor), GetType(Tags_Editor), GetType(Textures_Editor), GetType(MaterialBank_Editor), GetType(VisualBank_Editor), GetType(Config_Editor), GetType(ActionResource_Editor), GetType(Status_Editor), GetType(Spell_Editor), GetType(Pasives_Editor),
                 GetType(Interrupt_Editor), GetType(Books_Editor), GetType(Scrolls_Editor), GetType(Arrows_Editor), GetType(CharacterBank_Editor)
                Dim ind As Integer = ToolsOpened.IndexOf(sender)
                ToolsOpened(ind).Dispose()
                ToolsOpened(ind) = Nothing
                ToolsOpened.Remove(ToolsOpened(ind))
            Case Else
                Debugger.Break()
        End Select
        Pinta_status()
    End Sub

    Private Sub Explorer_node_Selected(sender As Object, e As TreeViewEventArgs)
        RaiseEvent Explorer_Form_node_Selected(sender, e)
    End Sub
    Private Sub Explorer_node_Double_Clicked(nod As TreeNode)
        RaiseEvent Explorer_Form_node_Double_Clicked(nod)
    End Sub
    Public Event Explorer_Form_node_Selected(sender As Object, e As TreeViewEventArgs)
    Public Event Explorer_Form_node_Double_Clicked(nod As TreeNode)

    Private Function GenerateChildForm(T As Type, Title As String, Optional L1 As Integer = -1) As Object
        Select Case T
            Case GetType(Explorer_Form_Templates)
                Dim form = New Explorer_Form_Templates(Me) With {.Text = Title + " (# " + (ObjectExplorerForms.Count + 1).ToString.PadLeft(4, "0") + ")"}
                ObjectExplorerForms.Add(form)
                If L1 <> -1 Then
                    Dim idx As Integer = 0
                    For x = 0 To form.ObjectsTree.ComboBoxItems.Items.Count - 1
                        If form.ObjectsTree.ComboBoxItems.Items.Item(x).value = L1 Then
                            idx = x : Exit For
                        End If
                    Next
                    form.ObjectsTree.ComboBoxItems.SelectedIndex = idx
                    form.ObjectsTree.ComboBoxItems.Enabled = False
                End If
                AddHandler form.FormClosed, AddressOf ClosedChildForm
                AddHandler form.TreeNodeSelected, AddressOf Explorer_node_Selected
                AddHandler form.TreeNodeDoubleClicked, AddressOf Explorer_node_Double_Clicked
                form.ObjectsTree.SelectedDisplayformat = BG3_Enum_DisplayFormat.Name_and_DisplayName
                form.Show()
                form.ObjectsTree.ObjectList = GameEngine.ProcessedGameObjectList
                If form.ObjectsTree.ComboBoxItems.Enabled = False Then form.ObjectsTree.Rellena_Comboparent()
                form.ObjectsTree.Reload_Arbol(False)
                Return form
            Case GetType(Explorer_Form_Icons)
                Dim form = New Explorer_Form_Icons(Me) With {.Text = Title + " (# " + (IconExplorerForms.Count + 1).ToString.PadLeft(4, "0") + ")"}
                IconExplorerForms.Add(form)
                AddHandler form.FormClosed, AddressOf ClosedChildForm
                AddHandler form.TreeNodeSelected, AddressOf Explorer_node_Selected
                AddHandler form.TreeNodeDoubleClicked, AddressOf Explorer_node_Double_Clicked
                form.ObjectsTree.SelectedDisplayformat = BG3_Enum_DisplayFormat.OnlyName
                form.Show()
                form.ObjectsTree.ObjectList = GameEngine.ProcessedIcons
                form.ObjectsTree.Reload_Arbol(False)
            Case GetType(Explorer_Form_Stats)
                Dim form = New Explorer_Form_Stats(Me) With {.Text = Title + " (# " + (StatsExplorerForms.Count + 1).ToString.PadLeft(4, "0") + ")"}
                StatsExplorerForms.Add(form)
                If L1 <> -1 Then
                    Dim idx As Integer = 0
                    For x = 0 To form.ObjectsTree.ComboBoxItems.Items.Count - 1
                        If form.ObjectsTree.ComboBoxItems.Items.Item(x).value = L1 Then
                            idx = x : Exit For
                        End If
                    Next
                    form.ObjectsTree.ComboBoxItems.SelectedIndex = idx
                    form.ObjectsTree.ComboBoxItems.Enabled = False
                End If
                AddHandler form.FormClosed, AddressOf ClosedChildForm
                AddHandler form.TreeNodeSelected, AddressOf Explorer_node_Selected
                AddHandler form.TreeNodeDoubleClicked, AddressOf Explorer_node_Double_Clicked
                form.ObjectsTree.SelectedDisplayformat = BG3_Enum_DisplayFormat.Name_and_DisplayName
                form.Show()
                form.ObjectsTree.ObjectList = GameEngine.ProcessedStatList
                If form.ObjectsTree.ComboBoxItems.Enabled = False Then form.ObjectsTree.Rellena_Comboparent()
                form.ObjectsTree.Reload_Arbol(False)
                Return form
            Case GetType(Explorer_Form_Flags_and_Tags)
                Dim form = New Explorer_Form_Flags_and_Tags(Me) With {.Text = Title + " (# " + (FlagsAndTagsExplorerForms.Count + 1).ToString.PadLeft(4, "0") + ")"}
                FlagsAndTagsExplorerForms.Add(form)
                If L1 <> -1 Then
                    Dim idx As Integer = 0
                    For x = 0 To form.ObjectsTree.ComboBoxItems.Items.Count - 1
                        If form.ObjectsTree.ComboBoxItems.Items.Item(x).value = L1 Then
                            idx = x : Exit For
                        End If
                    Next
                    form.ObjectsTree.ComboBoxItems.SelectedIndex = idx
                    form.ObjectsTree.ComboBoxItems.Enabled = False
                End If
                AddHandler form.FormClosed, AddressOf ClosedChildForm
                AddHandler form.TreeNodeSelected, AddressOf Explorer_node_Selected
                AddHandler form.TreeNodeDoubleClicked, AddressOf Explorer_node_Double_Clicked
                form.ObjectsTree.SelectedDisplayformat = BG3_Enum_DisplayFormat.Name_and_DisplayName
                form.Show()
                form.ObjectsTree.ObjectList = GameEngine.ProcessedFlagsAndTags
                If form.ObjectsTree.ComboBoxItems.Enabled = False Then form.ObjectsTree.Rellena_Comboparent()
                form.ObjectsTree.Reload_Arbol(False)
                Return form
            Case GetType(Explorer_Form_VisualTemplates)
                Dim form = New Explorer_Form_VisualTemplates(Me) With {.Text = Title + " (# " + (VisualExplorerForms.Count + 1).ToString.PadLeft(4, "0") + ")"}
                VisualExplorerForms.Add(form)
                If L1 <> -1 Then
                    Dim idx As Integer = 0
                    For x = 0 To form.ObjectsTree.ComboBoxItems.Items.Count - 1
                        If form.ObjectsTree.ComboBoxItems.Items.Item(x).value = L1 Then
                            idx = x : Exit For
                        End If
                    Next
                    form.ObjectsTree.ComboBoxItems.SelectedIndex = idx
                    form.ObjectsTree.ComboBoxItems.Enabled = False
                End If

                AddHandler form.FormClosed, AddressOf ClosedChildForm
                AddHandler form.TreeNodeSelected, AddressOf Explorer_node_Selected
                AddHandler form.TreeNodeDoubleClicked, AddressOf Explorer_node_Double_Clicked
                form.ObjectsTree.SelectedDisplayformat = BG3_Enum_DisplayFormat.OnlyName
                form.Show()
                form.ObjectsTree.ObjectList = GameEngine.ProcessedVisualBanksList
                If form.ObjectsTree.ComboBoxItems.Enabled = False Then form.ObjectsTree.Rellena_Comboparent()
                form.ObjectsTree.Reload_Arbol(False)
                Return form
            Case GetType(Explorer_Form_TreasureTables)
                Dim form = New Explorer_Form_TreasureTables(Me) With {.Text = Title + " (# " + (VisualExplorerForms.Count + 1).ToString.PadLeft(4, "0") + ")"}
                TtablesExplorerForms.Add(form)
                AddHandler form.TreeNodeSelected, AddressOf Explorer_node_Selected
                AddHandler form.TreeNodeDoubleClicked, AddressOf Explorer_node_Double_Clicked
                AddHandler form.FormClosed, AddressOf ClosedChildForm
                form.ObjectsTree.SelectedDisplayformat = BG3_Enum_DisplayFormat.OnlyName
                form.Show()
                form.ObjectsTree.ObjectList = GameEngine.ProcessedTTables
                form.ObjectsTree.Reload_Arbol(False)
                Return form
            Case GetType(Dyes_Editor), GetType(Containers_Editor), GetType(Armors_Editor), GetType(Weapons_Editor), GetType(Consumables_Editor), GetType(Tags_Editor), GetType(Textures_Editor), GetType(MaterialBank_Editor), GetType(VisualBank_Editor), GetType(Config_Editor), GetType(ActionResource_Editor), GetType(Status_Editor), GetType(Spell_Editor), GetType(Pasives_Editor),
                GetType(Interrupt_Editor), GetType(Books_Editor), GetType(Scrolls_Editor), GetType(Arrows_Editor), GetType(CharacterBank_Editor)
                Dim form As System.Windows.Forms.Form = Nothing
                If ToolsOpened.Where(Function(pf) Not IsNothing(pf) AndAlso pf.GetType = T).Any Then
                    form = ToolsOpened.Where(Function(pf) pf.GetType = T).First
                    form.Activate()
                Else
                    form = Activator.CreateInstance(T, {Me, ActiveMod.CurrentMod.ModLsx.SourceOfResource})
                    ToolsOpened.Add(form)
                    AddHandler form.FormClosed, AddressOf ClosedChildForm
                    form.Show()
                End If
                Return form
            Case Else
                Debugger.Break()
                Return Nothing
        End Select
        Return Nothing
    End Function
    Private Sub ObjectsExplorerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ObjectsExplorerToolStripMenuItem.Click

    End Sub
    Private Sub ObjectInformationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ObjectInformationToolStripMenuItem.Click
        GenerateChildForm(GetType(Explorer_Form_Icons), "Icons explorer")
    End Sub

    Private Sub AllTemplatesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllTemplatesToolStripMenuItem.Click
        GenerateChildForm(GetType(Explorer_Form_Templates), "Templates explorer")
    End Sub

    Private Sub ItemTemplatesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ItemTemplatesToolStripMenuItem.Click
        GenerateChildForm(GetType(Explorer_Form_Templates), "Items templates explorer", BG3_Enum_Templates_Type.item)
    End Sub

    Private Sub CharacterTemplatesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CharacterTemplatesToolStripMenuItem.Click
        GenerateChildForm(GetType(Explorer_Form_Templates), "Characters templates explorer", BG3_Enum_Templates_Type.character)
    End Sub

    Private Sub StatsExplorerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StatsExplorerToolStripMenuItem.Click
        GenerateChildForm(GetType(Explorer_Form_Stats), "Stats explorer")
    End Sub

    Private Sub FlagsExplorerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FlagsExplorerToolStripMenuItem.Click
        GenerateChildForm(GetType(Explorer_Form_Flags_and_Tags), "Flags, tags and lists explorer")
    End Sub
    Private Sub VisualBankExplorerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        GenerateChildForm(GetType(Explorer_Form_VisualTemplates), "Visuals banks explorer")
    End Sub
    Private Sub TrasureTablesExplorerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TrasureTablesExplorerToolStripMenuItem.Click
        GenerateChildForm(GetType(Explorer_Form_TreasureTables), "Treasure tables explorer")

    End Sub
    Private Sub ObjectsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ObjectsToolStripMenuItem.Click
        GenerateChildForm(GetType(Explorer_Form_Stats), "Objects stats explorer", BG3_Enum_StatType.Object)
    End Sub

    Private Sub ArmorsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ArmorsToolStripMenuItem1.Click
        GenerateChildForm(GetType(Explorer_Form_Stats), "Armors stats explorer", BG3_Enum_StatType.Armor)
    End Sub

    Private Sub WeaponsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles WeaponsToolStripMenuItem1.Click
        GenerateChildForm(GetType(Explorer_Form_Stats), "Weapons stats explorer", BG3_Enum_StatType.Weapon)
    End Sub

    Private Sub CharactersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CharactersToolStripMenuItem.Click
        GenerateChildForm(GetType(Explorer_Form_Stats), "Characters stats explorer", BG3_Enum_StatType.Character)
    End Sub

    Private Sub SpellsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SpellsToolStripMenuItem.Click
        GenerateChildForm(GetType(Explorer_Form_Stats), "Spell stats explorer", BG3_Enum_StatType.SpellData)
    End Sub

    Private Sub PasivesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasivesToolStripMenuItem.Click
        GenerateChildForm(GetType(Explorer_Form_Stats), "Pasives stats explorer", BG3_Enum_StatType.PassiveData)
    End Sub

    Private Sub StatusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StatusToolStripMenuItem.Click
        GenerateChildForm(GetType(Explorer_Form_Stats), "Status stats explorer", BG3_Enum_StatType.StatusData)
    End Sub

    Private Sub TexturesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TexturesToolStripMenuItem.Click
        GenerateChildForm(GetType(Explorer_Form_VisualTemplates), "Textures explorer", BG3_Enum_VisualBank_Type.TextureBank)
    End Sub

    Private Sub MaterialsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MaterialsToolStripMenuItem.Click
        GenerateChildForm(GetType(Explorer_Form_VisualTemplates), "Materials bank explorer", BG3_Enum_VisualBank_Type.MaterialBank)
    End Sub

    Private Sub MaterialToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MaterialToolStripMenuItem.Click
        GenerateChildForm(GetType(Explorer_Form_VisualTemplates), "Material shaders explorer", BG3_Enum_VisualBank_Type.MaterialShader)
    End Sub

    Private Sub MaterialPresetsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MaterialPresetsToolStripMenuItem.Click
        GenerateChildForm(GetType(Explorer_Form_VisualTemplates), "Materials presets explorer", BG3_Enum_VisualBank_Type.MaterialPresetBank)
    End Sub

    Private Sub CharacterVisualBankToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CharacterVisualBankToolStripMenuItem.Click
        GenerateChildForm(GetType(Explorer_Form_VisualTemplates), "Characters visual bank explorer", BG3_Enum_VisualBank_Type.CharacterVisualBank)
    End Sub

    Private Sub VisualBankToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VisualBankToolStripMenuItem.Click
        GenerateChildForm(GetType(Explorer_Form_VisualTemplates), "Visual bank explorer", BG3_Enum_VisualBank_Type.VisualBank)
    End Sub

    Private Sub VirtualTexturesBankToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VirtualTexturesBankToolStripMenuItem.Click
        GenerateChildForm(GetType(Explorer_Form_VisualTemplates), "Virtual textures explorer", BG3_Enum_VisualBank_Type.VirtualTextureBank)
    End Sub

    Private Sub OtherToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FlagstoolstripMenuItem.Click
        GenerateChildForm(GetType(Explorer_Form_Flags_and_Tags), "Flags explorer", BG3_Enum_FlagsandTagsType.Flags)
    End Sub

    Private Sub TagsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TagsToolStripMenuItem.Click
        GenerateChildForm(GetType(Explorer_Form_Flags_and_Tags), "Tags explorer", BG3_Enum_FlagsandTagsType.Tags)
    End Sub

    Private Sub RacesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RacesToolStripMenuItem.Click
        GenerateChildForm(GetType(Explorer_Form_Flags_and_Tags), "Races explorer", BG3_Enum_FlagsandTagsType.EquipmentRaces)
    End Sub

    Private Sub GoldValuesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GoldValuesToolStripMenuItem.Click
        GenerateChildForm(GetType(Explorer_Form_Flags_and_Tags), "gold values explorer", BG3_Enum_FlagsandTagsType.GoldValues)
    End Sub

    Private Sub EquipmentTypesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EquipmentTypesToolStripMenuItem.Click
        GenerateChildForm(GetType(Explorer_Form_Flags_and_Tags), "Equipment types explorer", BG3_Enum_FlagsandTagsType.EquipmentTypes)
    End Sub

    Private Sub EquipmentSlotsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EquipmentSlotsToolStripMenuItem.Click
        GenerateChildForm(GetType(Explorer_Form_Flags_and_Tags), "Equipment slots explorer", BG3_Enum_FlagsandTagsType.EquipmentSlots)
    End Sub
    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        If IsNothing(ActiveMod) = False Then Throw New Exception
        Clear_Current_Mod_Loaded()
        ActiveMod = New UtamMod(Me, True)
        ActiveMod.Show()
        AddHandler ActiveMod.FormClosed, AddressOf ClosedChildForm
        AddHandler ActiveMod.Changed_status, AddressOf ActiveMode_Changed
        Pinta_status()
    End Sub
    Private Sub LoadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadToolStripMenuItem.Click
        If IsNothing(LoaderOpened) OrElse LoaderOpened.IsDisposed Then
            LoaderOpened = New ModLoader(Me)
            AddHandler LoaderOpened.Mod_load, AddressOf ActiveMode_Load
        End If
        LoaderOpened.Show()
    End Sub
    Private Sub ActiveMode_Load(ByRef ModLoaded As UtamMod)
        If IsNothing(ActiveMod) = False Then Throw New Exception
        ActiveMod = ModLoaded
        AddHandler ActiveMod.FormClosed, AddressOf ClosedChildForm
        AddHandler ActiveMod.Changed_status, AddressOf ActiveMode_Changed
        Pinta_status()
    End Sub

    Private Sub ActiveMode_Changed()
        Pinta_status()
    End Sub

    Public Sub ChangedMod()
        If IsNothing(ActiveMod) Then Exit Sub
        ActiveMod.Habilita_Deshabilita_edicion(True, False)
    End Sub
    Private Sub ContainersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ContainersToolStripMenuItem.Click
        GenerateChildForm(GetType(Containers_Editor), "")
    End Sub

    Private Sub DyesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DyesToolStripMenuItem.Click
        GenerateChildForm(GetType(Dyes_Editor), "")
    End Sub

    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        CacheWorker.CancelAsync()
        ProcessWorker.CancelAsync()
        GameEngine.Save_Settings()
    End Sub

    Private Sub AboutAndAcknoulegementsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutAndAcknoulegementsToolStripMenuItem.Click
        Dim xx As New AboutBox1
        xx.ShowDialog()
    End Sub

    Private CaptureN As Integer = 0
    Private Sub ObjectsStatusLabel_Click(sender As Object, e As EventArgs) Handles ObjectsStatusLabel.Click
        If Control.ModifierKeys = Keys.Control Then
            Try
                Dim bmp As New Bitmap(Me.Width, Me.Height)
                Me.DrawToBitmap(bmp, New Rectangle(0, 0, Me.Width, Me.Height))
                bmp.Save("C:\Temp\BG3 Captures\Capture" + CaptureN.ToString("0000") + ".png", ImageFormat.Png)
                CaptureN += 1
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub ArmorsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArmorsToolStripMenuItem.Click
        GenerateChildForm(GetType(Armors_Editor), "")
    End Sub

    Private Sub LaunchGameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaunchGameToolStripMenuItem.Click
        Try
            Process.Start(IO.Path.Combine(GameEngine.Settings.GameExeFolder, "bg3.exe"))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub UTAMModsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UTAMModsToolStripMenuItem.Click
        If IO.Directory.Exists(GameEngine.Settings.UTAMModFolder) Then
            Try
                System.Diagnostics.Process.Start("explorer.exe", GameEngine.Settings.UTAMModFolder)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub UTAMCacheToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UTAMCacheToolStripMenuItem.Click
        If IO.Directory.Exists(GameEngine.Settings.UTAMCacheFolder) Then
            Try
                System.Diagnostics.Process.Start("explorer.exe", GameEngine.Settings.UTAMCacheFolder)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub BG3GameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BG3GameToolStripMenuItem.Click
        If IO.Directory.Exists(GameEngine.Settings.GameExeFolder) Then
            Try
                System.Diagnostics.Process.Start("explorer.exe", GameEngine.Settings.GameExeFolder)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub BG3ModsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BG3ModsToolStripMenuItem.Click
        If IO.Directory.Exists(GameEngine.Settings.GameModFolder) Then
            Try
                System.Diagnostics.Process.Start("explorer.exe", GameEngine.Settings.GameModFolder)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub OpenDetailsWindowsAlsoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenDetailsWindowsAlsoToolStripMenuItem.Click
        OpenDetailsWindowsAlsoToolStripMenuItem.Checked = Not OpenDetailsWindowsAlsoToolStripMenuItem.Checked
        FuncionesHelpers.GameEngine.Settings.Showdetails = OpenDetailsWindowsAlsoToolStripMenuItem.Checked
    End Sub

    Private Sub WeaponsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WeaponsToolStripMenuItem.Click
        GenerateChildForm(GetType(Weapons_Editor), "")
    End Sub

    Private Sub ConsumablesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsumablesToolStripMenuItem.Click
        GenerateChildForm(GetType(Consumables_Editor), "")
    End Sub

    Private Sub ProcessSinglePakToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProcessSinglePakToolStripMenuItem.Click
        Try
            Dim xx As New OpenFileDialog With {
                .Filter = "pak files (*.pak)|*.pak"
            }
            If xx.ShowDialog() = DialogResult.OK Then
                GameEngine.ProcessedPackList.AddPackageContainer(xx.FileName, BG3_Enum_Package_Type.BaseMod)
                Dim pack = GameEngine.ProcessedPackList.Last
                Parallel.ForEach(pack.Package.Files, Sub(fil)
                                                         Lee_Resource_From_Source(New BG3_Pak_SourceOfResource_Class(pack, fil), False)
                                                     End Sub)
            End If
        Catch ex As Exception
            MsgBox("Error processing the pak", MsgBoxStyle.Information + vbOKOnly, "Error")
        End Try

    End Sub

    Private Sub TagsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles TagsToolStripMenuItem1.Click
        GenerateChildForm(GetType(Tags_Editor), "")
    End Sub

    Private Sub TexturesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles TexturesToolStripMenuItem1.Click
        GenerateChildForm(GetType(Textures_Editor), "")
    End Sub

    Private Sub MaterialBankToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MaterialBankToolStripMenuItem.Click
        GenerateChildForm(GetType(MaterialBank_Editor), "")
    End Sub

    Private Sub VisualBankToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles VisualBankToolStripMenuItem1.Click
        GenerateChildForm(GetType(VisualBank_Editor), "")
    End Sub

    Private Sub ConfigKeysToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConfigKeysToolStripMenuItem.Click
        GenerateChildForm(GetType(Config_Editor), "")
    End Sub

    Private Sub ActionResourcesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActionResourcesToolStripMenuItem.Click
        GenerateChildForm(GetType(ActionResource_Editor), "")

    End Sub

    Private Sub ActionResourcesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ActionResourcesToolStripMenuItem1.Click
        GenerateChildForm(GetType(Explorer_Form_Flags_and_Tags), "Action resources", BG3_Enum_FlagsandTagsType.ActionResource)
    End Sub

    Private Sub ConfigKeysToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ConfigKeysToolStripMenuItem1.Click
        GenerateChildForm(GetType(Explorer_Form_Stats), "Config keys", BG3_Enum_StatType.ConfigKeys)
    End Sub

    Private Sub StatusToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles StatusToolStripMenuItem1.Click
        GenerateChildForm(GetType(Status_editor), "")

    End Sub

    Private Sub PassivesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PassivesToolStripMenuItem.Click
        GenerateChildForm(GetType(Pasives_Editor), "")

    End Sub

    Private Sub SpellsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SpellsToolStripMenuItem1.Click
        GenerateChildForm(GetType(Spell_Editor), "")
    End Sub

    Private Sub InterruptsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InterruptsToolStripMenuItem.Click
        GenerateChildForm(GetType(Interrupt_Editor), "")

    End Sub

    Private Sub InterruptsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles InterruptsToolStripMenuItem1.Click
        GenerateChildForm(GetType(Explorer_Form_Stats), "Interrupt stats explorer", BG3_Enum_StatType.InterruptData)
    End Sub

    Private Sub MultiEffectInfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MultiEffectInfoToolStripMenuItem.Click
        GenerateChildForm(GetType(Explorer_Form_Flags_and_Tags), "MultiEffectInfo explorer ", BG3_Enum_FlagsandTagsType.MultieffectInfo)

    End Sub

    Private Sub EffectsBankToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EffectsBankToolStripMenuItem.Click
        GenerateChildForm(GetType(Explorer_Form_VisualTemplates), "Effects bank explorer", BG3_Enum_VisualBank_Type.EffectsBank)

    End Sub

    Private Sub BooksToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BooksToolStripMenuItem.Click
        GenerateChildForm(GetType(Books_Editor), "")
    End Sub

    Private Sub ScrollsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ScrollsToolStripMenuItem.Click
        GenerateChildForm(GetType(Scrolls_Editor), "")

    End Sub

    Private Sub ArrowsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArrowsToolStripMenuItem.Click
        GenerateChildForm(GetType(Arrows_Editor), "")
    End Sub

    Private Sub CharacterBankToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CharacterBankToolStripMenuItem.Click
        GenerateChildForm(GetType(CharacterBank_Editor), "")
    End Sub

    Private Sub SupportbuyMeACoffeeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupportbuyMeACoffeeToolStripMenuItem.Click
        Try
            Process.Start(New ProcessStartInfo("https://ko-fi.com/Manolov02") With {.UseShellExecute = True})
        Catch ex As Exception

        End Try
    End Sub
End Class