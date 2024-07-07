Imports System.Collections.Concurrent
Imports System.DirectoryServices
Imports System.Runtime.InteropServices.Marshalling
Imports System.Windows.Forms.VisualStyles
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Xml
Imports Accessibility
Imports LSLib.Granny
Imports LSLib.Granny.Model
Imports LSLib.LS
Imports LSLib.LS.Story

Public Class Treasure_table_editor
    Sub New()
        MyBase.New
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Flickering.EnableDoubleBuffering(BG3Selector_Treasure1.TreeView1)
    End Sub

    Public HandledStats As New List(Of String)
    Public HandledAttributes As New List(Of String)
    Public HandledNodes As New List(Of String)

    Public Property ActiveModSource As BG3_Pak_SourceOfResource_Class
    Protected Overridable Property SelectedTT As BG3_Obj_TreasureTable_Class
    Protected Overridable Property NameNod As String = "Treasure_"
    Protected Overridable ReadOnly Property Prefix As String = "UTAM_Treasure_"
    Protected Overridable ReadOnly Property UtamType As BG3_Enum_UTAM_Type = BG3_Enum_UTAM_Type.Treasure
    Public Sub New(ByRef MdiParent As Main, Source As BG3_Pak_SourceOfResource_Class)
        MyBase.New(MdiParent)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Initialize(MdiParent, Source)
        Me.DoubleBuffered = True
        Flickering.EnableDoubleBuffering(BG3Selector_Treasure1.TreeView1)
        'BG3Selector_Stat1.BG3Cloner1.RadioButtonInherit.Enabled = False
        'BG3Selector_Stat1.BG3Cloner1.RadioButtonClone.Checked = True
        'BG3Selector_Stat1.ByInheritingToolStripMenuItem.Enabled = False
        BG3Selector_Treasure1.WorldInjectionToolStripMenuItem.Visible = False
        BG3Selector_Treasure1.TreasureTablesToolStripMenuItem.Visible = False
        BG3Selector_Treasure1.TagsToolStripMenuItem.Visible = False
        BG3Selector_Treasure1.TagsToolStripMenuItem1.Visible = False
        BG3Selector_Treasure1.LocalizationToolStripMenuItem.Visible = False
        BG3Selector_Treasure1.RenameToolStripMenuItem.Visible = False
        BG3Selector_Treasure1.BG3Cloner1.RadioButtonClone.Enabled = False
        BG3Selector_Treasure1.BG3Cloner1.RadioButtonItemAndChilds.Enabled = False
        BG3Selector_Treasure1.BG3Cloner1.RadioButtonOnlyChilds.Enabled = False
        BG3Selector_Treasure1.BG3Cloner1.CheckBoxCopyLeveled.Enabled = False
        BG3Selector_Treasure1.BG3Cloner1.CheckBoxSkipGarbage.Enabled = False
        BG3Selector_Treasure1.ContextMenuStrip = Nothing
    End Sub
    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.WaitCursor
        BG3Selector_Treasure1.Selection = UtamType
        BG3Selector_Treasure1.Load_Templates(FuncionesHelpers.GameEngine.UtamTreasures)
        Cursor.Current = Cursors.Default
    End Sub
    Public ReadOnly Property LocationtoNameForm As Point
        Get
            Return Me.SplitContainer1.Location
        End Get
    End Property
    Public ReadOnly Property LocationtoNameFormDistance As Integer
        Get
            Return Me.SplitContainer1.SplitterDistance
        End Get
    End Property
    Private Sub Explore_Node_DoubleClicked(nod As Object)
        If BG3Selector_Treasure1.IsEditing OrElse BG3Selector_Treasure1.Isclonning_or_transfering Then Exit Sub
        Select Case nod.GetType
            Case GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Stats_Class))
                If Not IsNothing(CType(nod, BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Stats_Class)).Objeto) Then
                    Dim obj = CType(CType(nod, BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Stats_Class)).Objeto, BG3_Obj_Stats_Class)
                    If Not IsNothing(obj) Then
                        Dim find = BG3Selector_Treasure1.TreeView1.Nodes.Find(obj.MapKey, True)
                        If find.Length > 0 Then
                            BG3Selector_Treasure1.TreeView1.SelectedNode = find.First
                        End If
                    End If
                End If
            Case Else

        End Select
    End Sub
    Protected Sub Initialize(ByRef MdiParent As Main, Source As BG3_Pak_SourceOfResource_Class)
        Me.DoubleBuffered = True
        Me.MinimumSize = New Size(Me.Width, Me.Height)
        Me.MaximumSize = New Size(2000, Me.Height)
        Me.MdiParent = MdiParent
        AddHandler MdiParent.BackGroundWorkstarted, AddressOf BackgroundWork_WorkStarted_Sub
        AddHandler MdiParent.BackGroundWorkFinished, AddressOf BackgroundWork_Finished_Sub
        AddHandler MdiParent.BackGroundReport, AddressOf BackgroundWork_Report_SuB
        AddHandler MdiParent.BackGround_SingleTaskEnd, AddressOf BackGround_SingleTaskEnd_sub
        AddHandler MdiParent.BackGround_SingleTaskStart, AddressOf BackGround_SingleTaskStart_sub
        AddHandler MdiParent.Explorer_Form_node_Double_Clicked, AddressOf Explore_Node_DoubleClicked
        ActiveModSource = New BG3_Pak_SourceOfResource_Class(Source.Pak_Or_Folder, MdiParent.ActiveMod.CurrentMod.TreasureTableFilePath, BG3_Enum_Package_Type.UTAM_Mod)
        Create_Stat_Transfers()
        Habilita_Edicion_Botones(False)
        'BG3Editor_Complex_Localization1.Link_Controls({BG3Editor_Template_DisplayName1, BG3Editor_Template_Description1, BG3Editor_Template_TechnicalDescription1})
        Initialize_Specifics()
    End Sub

    Protected Overridable Sub Initialize_Specifics()
    End Sub

    ' Procesos Comunes Editores
    Private Sub Habilita_Edicion_Botones(Edicion As Boolean)
        GroupBoxBasicStats.Enabled = Edicion
        GroupBoxContent.Enabled = Edicion
        Habilita_Edicion_Botones_Specific(Edicion)
        Process_Selection_Change()
    End Sub
    Protected Overridable Sub Habilita_Edicion_Botones_Specific(Edicion As Boolean)
    End Sub
    Private Sub Capture_Name_Changed(quien As BG3_Obj_TreasureTable_Class, OldName As String, NewName As String) Handles BG3Editor_Treasure_Name1.WritedNewName
        Dim nod = CType(BG3Selector_Treasure1.TreeView1.SelectedNode, BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_TreasureTable_Class))
        nod.Name = NewName
        SelectedTT.Process_Name_Change(OldName, NewName)

    End Sub
    Private Sub Capture_Canmerge_Changed(quien As BG3_Obj_TreasureTable_Class, Oldvalue As Boolean, Newvalue As Boolean) Handles BG3Editor_Treasure_CanMerge1.CanmergeChanged
        Dim nod = CType(BG3Selector_Treasure1.TreeView1.SelectedNode, BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_TreasureTable_Class))
        SelectedTT.Process_Name_Change("", "")

    End Sub
    Protected Overridable Sub Capture_Clone_specific(obj As BG3_Obj_TreasureTable_Class, tipo As BG3Cloner.Clonetype)

    End Sub

    Protected Clone_Stat_Name As String
    Protected Clone_Stat_Using As String
    Protected Clone_NuevoStat As BG3_Obj_TreasureTable_Class
    Private Sub Capture_Clone(obj As BG3_Obj_TreasureTable_Class, tipo As BG3Cloner.Clonetype) Handles BG3Selector_Treasure1.Clone_Treasure
        Clone_NuevoStat = New BG3_Obj_TreasureTable_Class(ActiveModSource, NameNod) With {.CanMerge = True}
        BG3Selector_Treasure1.Habilita_Edicion_Botones(True)
        'template Clone
        Select Case tipo
            Case BG3Cloner.Clonetype.None
                Create_Initial(Clone_NuevoStat)
                Capture_Clone_specific(obj, tipo)
            Case BG3Cloner.Clonetype.Inherit
                Create_Initial(Clone_NuevoStat)
                Capture_Clone_specific(obj, tipo)
                Clone_NuevoStat.Name_Write = obj.Name
            Case BG3Cloner.Clonetype.Clone
                Create_Initial(Clone_NuevoStat)
                Clone_NuevoStat.Name_Write = obj.Name + "_Cloned"
                Capture_Clone_specific(obj, tipo)
            Case BG3Cloner.Clonetype.Override
                Create_Initial(Clone_NuevoStat)
                Clone_NuevoStat.Name_Write = obj.Name
                Clone_NuevoStat.CanMerge = False
                Capture_Clone_specific(obj, tipo)
            Case Else
                Debugger.Break()
        End Select

        SelectedTT = Clone_NuevoStat ' THIS Is ONLY FOR TT
        Clone_NuevoStat = FuncionesHelpers.GameEngine.ProcessedTTables.Manage_Overrides(Clone_NuevoStat)

        ' Localization Clone
        Select Case tipo
            Case BG3Cloner.Clonetype.None
            Case BG3Cloner.Clonetype.Clone, BG3Cloner.Clonetype.Inherit, BG3Cloner.Clonetype.Override
            Case Else
                Debugger.Break()
        End Select

        Process_Save_Objetos()
        Process_Save_Final()
    End Sub
    Protected Sub CLone_Loca(OldMapkey As String, UtamHandle As String)
        If OldMapkey = "" Then Exit Sub
        If OldMapkey.Contains(";"c) = False OrElse UtamHandle.Contains(";"c) = False Then
            Debugger.Break()
            Exit Sub
        End If
        Dim oldloca As BG3_Loca_Localization_Class = Nothing
        If FuncionesHelpers.GameEngine.ProcessedLocalizationList.TryGetValue(OldMapkey.Split(";")(0), oldloca) = False Then Exit Sub
        Dim Newloca As New BG3_Loca_Localization_Class(Bg3_Enum_Languages.English, Bg3_Enum_Genders.Male, Bg3_Enum_GendersTo.M_to_M, UtamHandle.Split(";")(0), UtamHandle.Split(";")(1), "Not defined", ActiveModSource)
        If FuncionesHelpers.GameEngine.ProcessedLocalizationList.TryAdd(UtamHandle.Split(";")(0), Newloca) = False Then
            FuncionesHelpers.GameEngine.ProcessedLocalizationList(UtamHandle.Split(";")(0)) = Newloca
        End If
        Dim versiontoread As Integer = OldMapkey.Split(";")(1)
        If oldloca.ContainsKey(versiontoread) = False Then versiontoread = oldloca.OrderBy(Function(pf) Math.Abs(pf.Key - versiontoread)).Select(Function(pq) pq.Key).First
        Dim newversion As Integer = UtamHandle.Split(";")(1)
        For Each lan In oldloca(versiontoread).Keys.ToList
            For Each gen In oldloca(versiontoread)(lan).Keys.ToList
                For Each gento In oldloca(versiontoread)(lan)(gen).Keys.ToList
                    Newloca.AddSpecific(newversion, lan, gen, gento, oldloca(versiontoread)(lan)(gen)(gento), ActiveModSource)
                Next
            Next
        Next
    End Sub
    Private Sub Capture_AddNew(Group As String) Handles BG3Selector_Treasure1.Add_New_Click
        Capture_Clone(Nothing, BG3Cloner.Clonetype.None)
        BG3Selector_Treasure1.Habilita_Edicion_Botones(True)
        Habilita_Edicion_Botones(True)
    End Sub
    Private Sub Capture_Edit(template As BG3_Obj_TreasureTable_Class) Handles BG3Selector_Treasure1.Edit_Click
        If IsNothing(template) Then Exit Sub
        Process_Edit()
    End Sub
    Private Sub Capture_Cancel() Handles BG3Selector_Treasure1.Cancel_Click
        Process_Cancel()
    End Sub
    Private Sub Capture_Save() Handles BG3Selector_Treasure1.Save_Click
        Process_Save_Edits()
    End Sub
    Private Sub Capture_Delete() Handles BG3Selector_Treasure1.Delete_Click
        Process_delete()
    End Sub
    Protected Overridable Sub Process_Delete_Specifics()

    End Sub

    Private Sub Process_delete()
        If MsgBox("Deleting records is a known recipe for bricking savegames!. Do you want to continue?", MsgBoxStyle.Exclamation + vbOKCancel, "Warning") = MsgBoxResult.Cancel Then Exit Sub
        FuncionesHelpers.GameEngine.UtamTreasures.Remove(SelectedTT)
        FuncionesHelpers.GameEngine.ProcessedTTables.Remove(SelectedTT)
        Process_Delete_Specifics()
        BG3Selector_Treasure1.Delete_Ended()
    End Sub
    Private Sub Capture_Selection_Change(Template As BG3_Obj_TreasureTable_Class) Handles BG3Selector_Treasure1.Change_Selected
        Select_Objects(Template)
        Process_Selection_Change()
    End Sub

    Protected Overridable Sub Select_Objects_Specifics()

    End Sub
    Private Sub Select_Objects(Template As BG3_Obj_TreasureTable_Class)
        If Not IsNothing(Template) Then
            SelectedTT = Template
            Select_Objects_Specifics()
        Else
            SelectedTT = Nothing
            Select_Objects_Specifics()
        End If
    End Sub

    Private Sub Create_Initial(ByRef nuevonod As BG3_Obj_TreasureTable_Class)
        Create_Initial_Specific(nuevonod)
        Add_UTAM_Attribute(nuevonod)
    End Sub
    Private Sub Add_UTAM_Attribute(ByRef nuevonod As BG3_Obj_TreasureTable_Class)
        'Editor_Stats_Generic.Create_Generic("UTAM_Type", UtamType, nuevonod)
        'Editor_Stats_Generic.Create_Generic("UTAM_Group", BG3Selector_Treasure1.Current_Group, nuevonod)
        Add_UTAM_Attribute_Specific(nuevonod)
    End Sub

    Protected Overridable Sub Add_UTAM_Attribute_Specific(ByRef nuevonod As BG3_Obj_TreasureTable_Class)

    End Sub

    Protected Overridable Sub Create_Initial_Specific(ByRef nuevonod As BG3_Obj_TreasureTable_Class)

    End Sub

    Protected Overridable Sub Process_Selection_Change_specific()
        ListBox1.Items.Clear()
        If Not IsNothing(SelectedTT) Then
            For Each st In SelectedTT.Subtables
                Dim cust As New BG3_Custom_ComboboxItem With {.Text = "Subtable " + st.WriteDefinition, .Value = st}
                ListBox1.Items.Add(cust)
            Next
        End If
        BG3Editor_Treasure_SubItemDefinition1.Enabled = False
        BG3Editor_Treasure_SubtableDefinition1.Enabled = False
        If ListBox1.Items.Count > 0 Then ListBox1.SelectedIndex = 0
    End Sub

    Private Sub Process_Selection_Change()
        If Not IsNothing(SelectedTT) Then
            'Add_UTAM_Attribute(SelectedTT)
            'BG3Selector_Treasure1.BG3Editor_Template_UtamGroup1.Read(SelectedTT)
            BG3Editor_Treasure_Name1.Read(SelectedTT)
            BG3Editor_Treasure_CanMerge1.Read(SelectedTT)
            Process_Selection_Change_specific()
        Else
            BG3Selector_Treasure1.BG3Editor_Template_UtamGroup1.Clear()
            BG3Editor_Treasure_Name1.Clear()
            BG3Editor_Treasure_CanMerge1.Clear()
            Process_Selection_Change_specific()
        End If
    End Sub
    Protected Overridable Sub Process_Save_Edits_Specifics()

    End Sub

    Private Sub Process_Save_Edits()
        'BG3Selector_Treasure1.BG3Editor_Template_UtamGroup1.Write(SelectedTT)
        BG3Editor_Treasure_Name1.Write(SelectedTT)
        BG3Editor_Treasure_CanMerge1.Write(SelectedTT)
        Process_Save_Edits_Specifics()
        Process_Save_Objetos()
        Process_Save_Final()
        Habilita_Edicion_Botones(False)
    End Sub

    Protected Overridable Sub Process_Save_Objetos_Specifics()
    End Sub
    Private Sub Process_Save_Objetos()
        SelectedTT.Write_Data()
        Process_Save_Objetos_Specifics()
    End Sub
    Private Sub Process_Save_Final()
        BG3Selector_Treasure1.Edit_Ended(SelectedTT)
    End Sub

    Protected Overridable Sub Process_Edit_Specifics()
    End Sub

    Private Sub Process_Edit()
        SelectedTT.Edit_start()
        Process_Edit_Specifics()
        Habilita_Edicion_Botones(True)
    End Sub
    Protected Overridable Sub Process_Cancel_Specifics()
    End Sub

    Private Sub Process_Cancel()
        SelectedTT.Cancel_Edit()
        Process_Cancel_Specifics()
        Habilita_Edicion_Botones(False)
        BG3Selector_Treasure1.Edit_Ended(SelectedTT)
    End Sub

    Private Sub Create_Stat_Transfers()
        Dim lista As New List(Of ToolStripMenuItem) From {
            } 'New ToolStripMenuItem("Stats|Rarity|True|Data", Nothing, AddressOf BG3Selector_Template1.TransferSibligsClick) With {.Tag = {"Rarity"}},}

        Create_Stat_Transfers_Specific(lista)

        Dim Cats = lista.OrderBy(Function(pf) pf.Text).Select(Function(pf) pf.Text.Split("|")(0)).Distinct.ToArray

        For Each cat In Cats
            Dim indx = BG3Selector_Treasure1.PropertiesToolStripMenuItem.DropDown.Items.Add(New ToolStripMenuItem(cat))
            Dim indx2 = BG3Selector_Treasure1.SplitGroupButton.DropDown.Items.Add(New ToolStripMenuItem(cat))
            Dim indx3 = BG3Selector_Treasure1.PropertiesToolStripMenuItem1.DropDown.Items.Add(New ToolStripMenuItem(cat))
            For Each it In lista.Where(Function(pf) pf.Text.Split("|")(0) = cat).OrderBy(Function(pq) pq.Text.Split("|")(1)).Select(Function(pf) pf)
                Dim splitstr = it.Text.Split("|")
                If splitstr(2) = "True" Then
                    Dim splitx = New ToolStripMenuItem(splitstr(1), Nothing, AddressOf BG3Selector_Treasure1.SplitGroup) With {.Tag = CType(it.Tag, String()).Select(Function(pf) splitstr(3) + "|" + pf).ToArray}
                    CType(BG3Selector_Treasure1.SplitGroupButton.DropDown.Items(indx2), ToolStripMenuItem).DropDown.Items.Add(splitx)
                End If

                it.Text = splitstr(1)
                CType(BG3Selector_Treasure1.PropertiesToolStripMenuItem.DropDown.Items(indx), ToolStripMenuItem).DropDown.Items.Add(it)
                Dim Toall = New ToolStripMenuItem(it.Text, Nothing, AddressOf BG3Selector_Treasure1.TransferAllClick) With {.Tag = it.Tag}
                CType(BG3Selector_Treasure1.PropertiesToolStripMenuItem1.DropDown.Items(indx3), ToolStripMenuItem).DropDown.Items.Add(Toall)
            Next
        Next
    End Sub
    Protected Overridable Sub Create_Stat_Transfers_Specific(ByRef Lista As List(Of ToolStripMenuItem))

#Disable Warning IDE0079 ' Quitar supresión innecesaria
#Disable Warning CA1861 ' Evitar matrices constantes como argumentos
        Lista.AddRange(Array.Empty(Of ToolStripMenuItem))
#Enable Warning CA1861 ' Evitar matrices constantes como argumentos
#Enable Warning IDE0079 ' Quitar supresión innecesaria
    End Sub
    Protected Overridable Sub Transfer_stats_specifics(Template As BG3_Obj_TreasureTable_Class, statsList() As String)
        Debug.Print(Me.Text)
        Debugger.Break()
    End Sub

    Private Sub Transfer_SaveOriginal()
        Transfer_SaveOriginal_Specific()
    End Sub
    Protected Overridable Sub Transfer_SaveOriginal_Specific()
    End Sub

    Protected Transfer_Stat As BG3_Obj_TreasureTable_Class

    Private Sub Transfer_stats(Template As BG3_Obj_TreasureTable_Class, statsList() As String, nods As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_TreasureTable_Class)) Handles BG3Selector_Treasure1.Transfer_Stats
        Transfer_SaveOriginal()
        For Each nod As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_TreasureTable_Class) In nods.Nodes
            Dim obj As BG3_Obj_TreasureTable_Class = nod.Objeto
            If obj IsNot Template Then
                obj.Edit_start()
                Select_Objects(obj)
                For Each stat In statsList
                    Select Case stat
                        Case "xxxx"

                        Case Else
                            Transfer_stats_specifics(Template, statsList)
                    End Select
                Next
                SelectedTT.Write_Data()
            End If
        Next
        BG3Selector_Treasure1.Edit_Ended(Template)
    End Sub


    Private Sub Generic_Editor_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If BG3Selector_Treasure1.IsEditing = True Then
            MsgBox("Save or cancel changes before closing", vbOKOnly, "Changes not saved")
            e.Cancel = True
        End If
    End Sub

    Private Sub FillSplit(ByVal Attr_or_data As String, ByRef selectedtmp As BG3_Obj_TreasureTable_Class, ByRef suffix As String) Handles BG3Selector_Treasure1.FillSplit
        Select Case Attr_or_data
            Case Else
                FillSplit_specific(Attr_or_data, selectedtmp, suffix)
        End Select

    End Sub
    Protected Overridable Sub FillSplit_specific(ByVal Attr_or_data As String, ByRef selectedtmp As BG3_Obj_TreasureTable_Class, ByRef suffix As String)

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedIndex = -1 Then
            Button2.Enabled = False
            BG3Editor_Treasure_SubtableDefinition1.Clear()
            BG3Editor_Treasure_SubtableDefinition1.AllowEdit = False
            BG3Editor_Treasure_SubtableDefinition1.Enabled = False
        Else
            Button2.Enabled = True
            Dim st = CType(ListBox1.Items(ListBox1.SelectedIndex).value, BG3_Obj_TreasureTable_Subtable_Class)
            BG3Editor_Treasure_SubtableDefinition1.AllowEdit = True
            BG3Editor_Treasure_SubtableDefinition1.Enabled = GroupBoxContent.Enabled
            BG3Editor_Treasure_SubtableDefinition1.Read(st)
        End If
        read_Items
    End Sub
    Private Sub Read_Items()
        ListBox2.Items.Clear()
        If ListBox1.SelectedIndex = -1 Then
        Else
            Dim st = CType(ListBox1.Items(ListBox1.SelectedIndex).value, BG3_Obj_TreasureTable_Subtable_Class)
            For Each it In st.Lista
                Dim xx As New BG3_Custom_ComboboxItem With {.Text = it.Item + it.WriteDefinition, .Value = it}
                ListBox2.Items.Add(xx)
            Next
        End If
        If ListBox2.Items.Count > 0 Then ListBox2.SelectedIndex = 0
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ListBox1.SelectedIndex <> -1 Then
            Dim st = CType(ListBox1.Items(ListBox1.SelectedIndex).value, BG3_Obj_TreasureTable_Subtable_Class)
            SelectedTT.Subtables.Remove(st)
            ListBox1.Items.RemoveAt(ListBox1.SelectedIndex)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim st As New BG3_Obj_TreasureTable_Subtable_Class(ActiveModSource, "1,1")
        SelectedTT.Subtables.Add(st)
        Dim cust As New BG3_Custom_ComboboxItem With {.Text = "Subtable " + st.WriteDefinition, .Value = st}
        ListBox1.SelectedIndex = ListBox1.Items.Add(cust)
    End Sub

    Private Sub BG3Editor_Treasure_SubtableDefinition1_Leave(sender As Object, e As EventArgs) Handles BG3Editor_Treasure_SubtableDefinition1.Leave
        If ListBox1.SelectedIndex <> -1 Then
            Dim st = CType(ListBox1.Items(ListBox1.SelectedIndex).value, BG3_Obj_TreasureTable_Subtable_Class)
            BG3Editor_Treasure_SubtableDefinition1.Write(st)
            ListBox1.Items(ListBox1.SelectedIndex).text = "Subtable " + st.WriteDefinition
            ListBox1.Items(ListBox1.SelectedIndex) = ListBox1.Items(ListBox1.SelectedIndex)
        End If
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        If ListBox2.SelectedIndex = -1 Then
            Button3.Enabled = False
            BG3Editor_Treasure_SubItemDefinition1.Clear()
            BG3Editor_Treasure_SubItemDefinition1.AllowEdit = False
            BG3Editor_Treasure_SubItemDefinition1.Enabled = False
        Else
            Button3.Enabled = True
            Dim st = CType(ListBox1.Items(ListBox1.SelectedIndex).value, BG3_Obj_TreasureTable_Subtable_Class)
            Dim it = CType(ListBox2.Items(ListBox2.SelectedIndex).value, BG3_Obj_TreasureTable_TableItem_Class)
            BG3Editor_Treasure_SubItemDefinition1.AllowEdit = True
            BG3Editor_Treasure_SubItemDefinition1.Enabled = GroupBoxContent.Enabled
            BG3Editor_Treasure_SubItemDefinition1.Read(it)
            procesa_numeros
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ListBox2.SelectedIndex <> -1 Then
            Dim st = CType(ListBox1.Items(ListBox1.SelectedIndex).value, BG3_Obj_TreasureTable_Subtable_Class)
            Dim it = CType(ListBox2.Items(ListBox2.SelectedIndex).value, BG3_Obj_TreasureTable_TableItem_Class)
            st.Lista.Remove(it)
            ListBox2.Items.RemoveAt(ListBox2.SelectedIndex)
        End If
    End Sub





    Private Sub Label1_DragEnter(sender As Object, e As DragEventArgs) Handles Label1.DragEnter, ListBox2.DragEnter
        If e.Data.GetDataPresent(GetType(BG3_Obj_Stats_Class)) Then
            Dim obj As BG3_Obj_Stats_Class = e.Data.GetData(GetType(BG3_Obj_Stats_Class))
            If Not IsNothing(obj) Then
                If obj.Type = BG3_Enum_StatType.Object Or obj.Type = BG3_Enum_StatType.Weapon Or obj.Type = BG3_Enum_StatType.Armor Then
                    e.Effect = DragDropEffects.Copy
                    Exit Sub
                End If
            End If
        End If
        If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Stats_Class))) Then
            Dim obj As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Stats_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Stats_Class)))
            If Not IsNothing(obj.Objeto) Then
                If CType(obj.Objeto, BG3_Obj_Stats_Class).Type = BG3_Enum_StatType.Object Or CType(obj.Objeto, BG3_Obj_Stats_Class).Type = BG3_Enum_StatType.Weapon Or CType(obj.Objeto, BG3_Obj_Stats_Class).Type = BG3_Enum_StatType.Armor Then
                    e.Effect = DragDropEffects.Copy
                    Exit Sub
                End If
            End If
        End If

        If e.Data.GetDataPresent(GetType(BG3_Obj_Template_Class)) Then
            Dim obj As BG3_Obj_Template_Class = e.Data.GetData(GetType(BG3_Obj_Template_Class))
            If Not IsNothing(obj) Then
                If Not IsNothing(obj.AssociatedStats) Then
                    If obj.AssociatedStats.Type = BG3_Enum_StatType.Object Or obj.AssociatedStats.Type = BG3_Enum_StatType.Weapon Or obj.AssociatedStats.Type = BG3_Enum_StatType.Armor Then
                        e.Effect = DragDropEffects.Copy
                        Exit Sub
                    End If
                End If
            End If
        End If

        If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class))) Then
            Dim obj As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class)))
            If Not IsNothing(obj.Objeto) Then
                If Not IsNothing(CType(obj.Objeto, BG3_Obj_Template_Class).AssociatedStats) Then
                    If CType(obj.Objeto, BG3_Obj_Template_Class).AssociatedStats.Type = BG3_Enum_StatType.Object Or CType(obj.Objeto, BG3_Obj_Template_Class).AssociatedStats.Type = BG3_Enum_StatType.Weapon Or CType(obj.Objeto, BG3_Obj_Template_Class).AssociatedStats.Type = BG3_Enum_StatType.Armor Then
                        e.Effect = DragDropEffects.Copy
                        Exit Sub
                    End If
                End If
            End If
        End If

        If e.Data.GetDataPresent(GetType(BG3_Obj_TreasureTable_Class)) Then
            Dim obj As BG3_Obj_TreasureTable_Class = e.Data.GetData(GetType(BG3_Obj_TreasureTable_Class))
            If Not IsNothing(obj) Then
                e.Effect = DragDropEffects.Copy
                Exit Sub
            End If
        End If
        If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_TreasureTable_Class))) Then
            Dim obj As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_TreasureTable_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_TreasureTable_Class)))
            If Not IsNothing(obj.Objeto) Then
                e.Effect = DragDropEffects.Copy
                Exit Sub
            End If
        End If
    End Sub

    Private Sub Label1_DragDrop(sender As Object, e As DragEventArgs) Handles Label1.DragDrop, ListBox2.DragDrop
        If e.Data.GetDataPresent(GetType(BG3_Obj_Stats_Class)) Then
            Dim obj As BG3_Obj_Stats_Class = e.Data.GetData(GetType(BG3_Obj_Stats_Class))
            If Not IsNothing(obj) Then
                Drop_OBJ(obj)
                Exit Sub
            End If
        End If


        If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Stats_Class))) Then
            Dim obj As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Stats_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Stats_Class)))
            If Not IsNothing(obj.Objeto) Then
                Drop_OBJ(CType(obj.Objeto, BG3_Obj_Stats_Class))
                Exit Sub
            End If
        End If

        If e.Data.GetDataPresent(GetType(BG3_Obj_Template_Class)) Then
            Dim obj As BG3_Obj_Template_Class = e.Data.GetData(GetType(BG3_Obj_Template_Class))
            If Not IsNothing(obj) Then
                If Not IsNothing(obj.AssociatedStats) Then
                    Drop_OBJ(obj.AssociatedStats)
                    Exit Sub
                End If
            End If
        End If

        If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class))) Then
            Dim obj As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class)))
            If Not IsNothing(obj.Objeto) Then
                If Not IsNothing(CType(obj.Objeto, BG3_Obj_Template_Class).AssociatedStats) Then
                    Drop_OBJ(CType(obj.Objeto, BG3_Obj_Template_Class).AssociatedStats)
                    Exit Sub
                End If
            End If
        End If

        If e.Data.GetDataPresent(GetType(BG3_Obj_TreasureTable_Class)) Then
            Dim obj As BG3_Obj_TreasureTable_Class = e.Data.GetData(GetType(BG3_Obj_TreasureTable_Class))
            If Not IsNothing(obj) Then
                Drop_OBJ(obj)
                Exit Sub
            End If
        End If


        If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_TreasureTable_Class))) Then
            Dim obj As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_TreasureTable_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_TreasureTable_Class)))
            If Not IsNothing(obj.Objeto) Then
                Drop_OBJ(CType(obj.Objeto, BG3_Obj_TreasureTable_Class))
                Exit Sub
            End If
        End If
    End Sub
    Private Sub Drop_OBJ(que As BG3_Obj_TreasureTable_Class)
        Drop_Cualquiera("T_" + que.Mapkey_WithoutOverride)
    End Sub
    Private Sub Drop_OBJ(que As BG3_Obj_Stats_Class)
        Drop_Cualquiera("I_" + que.Mapkey_WithoutOverride)
    End Sub
    Private Sub Drop_Cualquiera(It_Name As String)
        Dim st = CType(ListBox1.Items(ListBox1.SelectedIndex).value, BG3_Obj_TreasureTable_Subtable_Class)
        Dim it As New BG3_Obj_TreasureTable_TableItem_Class(It_Name, "1,0,0,0,0,0,0,0")
        st.Lista.Add(it)
        Dim cust As New BG3_Custom_ComboboxItem With {.Text = it.Item + it.WriteDefinition, .Value = it}
        ListBox2.SelectedIndex = ListBox2.Items.Add(cust)
    End Sub
    Private Sub Procesa_numeros()
        NumericUpDown1.Value = 0
        NumericUpDown2.Value = 0
        NumericUpDown3.Value = 0
        NumericUpDown4.Value = 0
        NumericUpDown5.Value = 0
        NumericUpDown6.Value = 0
        NumericUpDown7.Value = 0
        NumericUpDown8.Value = 0
        Try
            Dim it = CType(ListBox2.Items(ListBox2.SelectedIndex).value, BG3_Obj_TreasureTable_TableItem_Class)
            NumericUpDown1.Value = it.ConditionArray(0)
            NumericUpDown2.Value = it.ConditionArray(1)
            NumericUpDown3.Value = it.ConditionArray(2)
            NumericUpDown4.Value = it.ConditionArray(3)
            NumericUpDown5.Value = it.ConditionArray(4)
            NumericUpDown6.Value = it.ConditionArray(5)
            NumericUpDown7.Value = it.ConditionArray(6)
            NumericUpDown8.Value = it.ConditionArray(7)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.Leave, NumericUpDown2.Leave, NumericUpDown3.Leave, NumericUpDown4.Leave, NumericUpDown5.Leave, NumericUpDown6.Leave, NumericUpDown7.Leave, NumericUpDown8.Leave
        If ListBox1.SelectedIndex <> -1 And ListBox2.SelectedIndex <> -1 Then
            If GroupBoxContent.Enabled = True Then
                Dim it = CType(ListBox2.Items(ListBox2.SelectedIndex).value, BG3_Obj_TreasureTable_TableItem_Class)
                it.ConditionArray(0) = NumericUpDown1.Value
                it.ConditionArray(1) = NumericUpDown2.Value
                it.ConditionArray(2) = NumericUpDown3.Value
                it.ConditionArray(3) = NumericUpDown4.Value
                it.ConditionArray(4) = NumericUpDown5.Value
                it.ConditionArray(5) = NumericUpDown6.Value
                it.ConditionArray(6) = NumericUpDown7.Value
                it.ConditionArray(7) = NumericUpDown8.Value
                BG3Editor_Treasure_SubItemDefinition1.Read(it)
                BG3Editor_Treasure_SubItemDefinition1_Write()
            End If
        End If

    End Sub
    Private Sub BG3Editor_Treasure_SubItemDefinition1_Write()
        If ListBox1.SelectedIndex <> -1 And ListBox2.SelectedIndex <> -1 Then
            Dim st = CType(ListBox1.Items(ListBox1.SelectedIndex).value, BG3_Obj_TreasureTable_Subtable_Class)
            Dim it = CType(ListBox2.Items(ListBox2.SelectedIndex).value, BG3_Obj_TreasureTable_TableItem_Class)
            BG3Editor_Treasure_SubItemDefinition1.Write(it)
            ListBox2.Items(ListBox2.SelectedIndex).text = it.Item + it.WriteDefinition
            ListBox2.Items(ListBox2.SelectedIndex) = ListBox2.Items(ListBox2.SelectedIndex)
        End If
    End Sub

End Class