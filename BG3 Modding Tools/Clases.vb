Imports System.ComponentModel
Imports System.IO
Imports System.Net.Mail
Imports System.Net.WebRequestMethods
Imports System.Text.Json
Imports System.Text.Json.Serialization
Imports BG3_Modding_Tools.FuncionesHelpers
Imports BG3_Modding_Tools.Funciones
Imports LSLib.Granny
Imports LSLib.LS
Imports LSLib.LS.Enums
Imports Pfim
Imports System.Drawing.Imaging
Imports System.IO.Compression
Imports System.Text
Imports System.Resources
Imports LSLib.LS.Story
Imports System.Reflection.Emit
Imports System.Net.Http.Headers
Imports System.ComponentModel.Design.Serialization
Imports LSLib.Granny.Model
Imports System.Globalization
Imports System.Runtime.CompilerServices
Imports System.Configuration
Imports System.Runtime
Imports System.Net.Quic
Imports System.Net
Imports System.Net.NetworkInformation
Imports System.DirectoryServices.ActiveDirectory
Imports System.ComponentModel.DataAnnotations
Imports System.Diagnostics.Metrics
Imports System.Threading.Channels
Imports System.CodeDom







#Region "AplicationClasses"

Public Enum BG3_Enum_DisplayFormat
    OnlyName
    OnlyDisplayName
    Name_and_DisplayName
    DisplayName_and_Name
End Enum

Public Enum Bg3_Enum_Languages
    English
    BrazilianPortuguese
    Chinese
    ChineseTraditional
    French
    German
    Italian
    Korean
    LatinSpanish
    Polish
    Russian
    Spanish
    Turkish
    Ukrainian
End Enum
Public Enum Bg3_Enum_Genders
    Male
    Female
    Neutral
End Enum
Public Enum Bg3_Enum_GendersTo
    M_to_M
    M_to_F
    M_to_X
    F_to_M
    F_to_F
    F_to_X
    X_to_M
    X_to_F
    X_to_X
End Enum
Public Enum Bg3_Enum_Default
    All
End Enum
Class BG3_Pak_InfoJson_Class
    Public Property Mods As New List(Of BG3_Pak_InfoJson_Details_Class)
    Public Property MD5 As String
End Class
Public Class BG3_Pak_InfoJson_Details_Class
    Public Property Author As String
    Public Property Name As String
    Public Property Folder As String
    Public Property Version As String
    Public Property Description As String
    Public Property UUID As String
    Public Property Created As DateTime?
    Public Property Dependencies As New List(Of BG3_Pak_InfoKson_Dependencies_Class)
    Public Property Group As String
End Class
Public Class BG3_Pak_InfoKson_Dependencies_Class
    Public Property Name As String
    Public Property Folder As String
    Public Property Version As String
    Public Property UUID As String
    Public Property MD5 As String
End Class
Public Class BG3_CustomFilter_Class(Of T As BG3_Obj_Generic_Class)
    Public Property Roots As BG3_Custom_TreeNode_Linked_Class(Of T)() = Array.Empty(Of BG3_Custom_TreeNode_Linked_Class(Of T))
    Public Property TreeSource As BG3_Obj_SortedList_Class(Of T)
    Public SourceFilter As BG3_Pak_SourceOfResource_Class
    Public Property ToReload As Boolean = True
    Public Property ToRefilter As Boolean = True
    Public Property ToRePaint As Boolean = True

    Public Property Worker As BackgroundWorker = Nothing

    Public Event Filter_Changed(Sender As BG3_CustomFilter_Class(Of T))
    Public Event Filter_Reloaded(Sender As BG3_CustomFilter_Class(Of T))
    Public Event DisplayFormat_Changed(Sender As BG3_CustomFilter_Class(Of T))
    Public Event SortRequested(Sender As BG3_CustomFilter_Class(Of T))

    Public Sub SortNodes()
        RaiseEvent SortRequested(Me)
    End Sub


    Public Property DisplayFormat As BG3_Enum_DisplayFormat = BG3_Enum_DisplayFormat.Name_and_DisplayName
    Public Property Textfilter As String = ""
    Public Property Deepfilter As Boolean = False
    Public Property Filter_Level1 As Integer = 0
    Public Property Filter_Level2 As String = ""


    Public Sub Refilter()
        RaiseEvent Filter_Changed(Me)
    End Sub
    Public Sub Repaint()
        RaiseEvent DisplayFormat_Changed(Me)
    End Sub
    Public Sub RefilterAndRepaint()
        RaiseEvent Filter_Changed(Me)
        RaiseEvent DisplayFormat_Changed(Me)
    End Sub

    Public Property Elementos_Procesados As Long = 0
    Public Property Elementos_Totales As Long = 100


    Private Bach_elementos_Reporte As Long = 0
    Sub New(ByRef Worker As BackgroundWorker, ByRef ObjList As Object)
        Me.TreeSource = ObjList
        Me.Worker = Worker
    End Sub
    Public Sub Clear_Cuentas()
        Elementos_Totales = 0
        Elementos_Procesados = 0
    End Sub
    Public Sub IncrementTotal(cantidad As Long)
        SyncLock (Me)
            Elementos_Totales += cantidad
            If Toca_report() Then Reporta()
        End SyncLock
    End Sub
    Public Sub IncrementProcessed(cantidad As Long)
        SyncLock (Me)
            Bach_elementos_Reporte += cantidad
            Elementos_Procesados += cantidad
            If Toca_report() Then Reporta()
        End SyncLock
    End Sub
    Private Function Toca_report() As Boolean
        If Elementos_Totales = 0 Then Return True
        If Bach_elementos_Reporte / Elementos_Totales > 0.01 Then Return True
        Return False
    End Function
    Private Sub Reporta()
        Bach_elementos_Reporte = 0
        If Worker.IsBusy Then Worker.ReportProgress(100, {Elementos_Procesados, Elementos_Totales})
    End Sub
    Public ReadOnly Property Orphan(obj As T) As Boolean
        Get
            If obj.ParentKey_Or_Empty <> "" Then
                If TreeSource.Containskey(obj.ParentKey_Or_Empty) = False Then Return True
            End If
            Return False
        End Get
    End Property
    Public ReadOnly Property GetTreeNode(obj As T) As BG3_Custom_TreeNode_Linked_Class(Of T)
        Get
            Dim CachedNode = New BG3_Custom_TreeNode_Linked_Class(Of T)(Me, obj) With {.Name = obj.MapKey, .Text = "ToOverrite"}
            Try

                CachedNode.Change_to_DisplayFormat()

                If Orphan(obj) Then
                    Me.IncrementTotal(1)
                End If

                If obj.IsModObject = True Then
                    CachedNode.ForeColor = Color.FromKnownColor(KnownColor.Highlight)
                Else
                    CachedNode.ForeColor = Color.FromKnownColor(KnownColor.ControlText)
                End If

                If obj.IsOverrided = True Then
                    'If obj.GetType IsNot GetType(BG3_Obj_TreasureTable_Class) OrElse (CType(CType(obj, Object), BG3_Obj_TreasureTable_Class).Merged = False AndAlso (Not IsNothing(CType(CType(obj, Object), BG3_Obj_TreasureTable_Class).Parent) AndAlso CType(CType(obj, Object), BG3_Obj_TreasureTable_Class).Parent.IsOverrided = False)) Then
                    If obj.IsModObject = True Then
                        CachedNode.ForeColor = Color.FromKnownColor(KnownColor.LightBlue)
                    Else
                        CachedNode.ForeColor = Color.FromKnownColor(KnownColor.GrayText)
                    End If
                    'End If
                    If obj.ParentKey_Or_Empty = "" Then IncrementTotal(1)
                    Me.IncrementProcessed(1)
                    Return CachedNode
                End If

                If obj.Deleted = True Then
                    CachedNode.ForeColor = Color.FromKnownColor(KnownColor.Red)
                End If

                If Me.Worker.CancellationPending = True Then
                    Me.IncrementProcessed(1)
                    Return CachedNode
                End If

                CachedNode.Nodes.AddRange(GetChildren(obj).Select(Function(go) Me.GetTreeNode(TreeSource(go))).OrderBy(Function(pq) Replace_Override_Text(pq.Text)).ToArray)
                'CachedNode.Text = CachedNode.Text + " [# " + CachedNode.Nodes.Count.ToString + "]"
                Me.IncrementProcessed(1)

                Return CachedNode
            Catch ex As Exception
                Debugger.Break()
            End Try
            Return CachedNode
        End Get

    End Property
    Public Shared Function Replace_Override_Text(que As String) As String
        If que.StartsWith("(Overrided ", StringComparison.OrdinalIgnoreCase) Then
            Return que.Substring(17)
        End If
        If que.StartsWith("(Honour ", StringComparison.OrdinalIgnoreCase) Then
            Return que.Substring(14)
        End If
        If que.StartsWith("(Merged ", StringComparison.OrdinalIgnoreCase) Then
            Return que.Substring(14)
        End If
        If que.StartsWith("(Deleted) ", StringComparison.OrdinalIgnoreCase) Then
            Return que.Substring(10)
        End If
        Return que
    End Function

    Private ReadOnly _emptylist As New List(Of String)
    Public ReadOnly Property GetChildren(obj As T) As List(Of String)
        Get
            If obj.ParentKey_Or_Empty = "" Then IncrementTotal(1)
            Dim value As List(Of String) = Nothing
            If TreeSource.Hierarchy_Helper.TryGetValue(obj.MapKey, value) = True Then
                IncrementTotal(value.Count)
                Return value
            Else
                Return _emptylist
            End If
        End Get
    End Property

    Public Shared Function Getenum() As Type
        Select Case GetType(T)
            Case GetType(BG3_Obj_Template_Class)
                Return GetType(BG3_Enum_Templates_Type)
            Case GetType(BG3_Obj_FlagsAndTags_Class)
                Return GetType(BG3_Enum_FlagsandTagsType)
            Case GetType(BG3_Obj_Stats_Class)
                Return GetType(BG3_Enum_StatType)
            Case GetType(BG3_Obj_VisualBank_Class)
                Return GetType(BG3_Enum_VisualBank_Type)
            Case GetType(BG3_Obj_Assets_Class)
                Return GetType(Bg3_Enum_Default)
            Case GetType(BG3_Obj_Generic_Class)
                Return GetType(Bg3_Enum_Default)
            Case GetType(BG3_Obj_IconAtlass_Class)
                Return GetType(Bg3_Enum_Default)
            Case GetType(BG3_Obj_IconUV_Class)
                Return GetType(BG3_Enum_Icon_Type)
            Case GetType(BG3_Obj_TreasureTable_Class)
                Return GetType(BG3_Enum_TreasureTables)
            Case Else
                Debugger.Break()
                Return Nothing
        End Select
    End Function
    Public Function Reload() As Boolean
        Dim toresort As Boolean = False
        If ToReload = True Then
            Clear_Cuentas()
            Roots = Array.Empty(Of BG3_Custom_TreeNode_Linked_Class(Of T))
            Try
                Dim ite As Integer()
                Dim nods As New List(Of BG3_Custom_TreeNode_Linked_Class(Of T))

                If Filter_Level1 = -1 AndAlso Not IsNothing(Getenum) Then ite = [Enum].GetValues(Getenum) Else ite = {Filter_Level1}

                'Parallel.ForEach(ite, Sub(Typ)
                For Each typ In ite.OrderBy(Function(pf) [Enum].GetNames(Getenum).ToArray(pf))
                    Dim newnod As New BG3_Custom_TreeNode_Linked_Class(Of T)(Me, Nothing) With {.Name = [Enum].GetValues(Getenum)(typ).ToString, .Text = [Enum].GetValues(Getenum)(typ).ToString}
                    newnod.BeginEdit()
                    Dim filt = TreeSource.ElementValues.AsParallel.Where(Function(pf) pf.Filter_Check_Level1(typ) AndAlso ((Filter_Level2 = "" AndAlso pf.ParentKey_Or_Empty = "") OrElse (Filter_Level2 <> "" AndAlso pf.MapKey = Filter_Level2)))
                    newnod.Nodes.AddRange(filt.Select(Function(pq) GetTreeNode(pq)).OrderBy(Function(pq) Replace_Override_Text(pq.Text)).ToArray)
                    If GetType(T) = GetType(BG3_Obj_Template_Class) AndAlso typ = BG3_Enum_Templates_Type.invalid_template Then
                        filt = TreeSource.ElementValues.AsParallel.Where(Function(pf) pf.ParentKey_Or_Empty <> "" AndAlso TreeSource.Containskey(pf.ParentKey_Or_Empty) = False)
                        newnod.Nodes.AddRange(filt.Select(Function(pq) GetTreeNode(pq)).OrderBy(Function(pq) Replace_Override_Text(pq.Text)).ToArray)
                    End If
                    If ite.Length = 1 Then newnod.Expand()
                    newnod.EndEdit(False)
                    SyncLock nods
                        nods.Add(newnod)
                    End SyncLock
                Next

                Roots = nods.ToArray

                'End Sub)
                'Roots = nods.OrderBy(Function(pq) pq.Text).ToArray

            Catch ex As Exception
                Debugger.Break()
                Roots = Array.Empty(Of BG3_Custom_TreeNode_Linked_Class(Of T))
                Return False
            End Try
            ToReload = False
        End If

        RaiseEvent Filter_Reloaded(Me)

        If ToRefilter = True Then Elementos_Procesados = 0 : Refilter() : ToRefilter = False : toresort = True
        If ToRePaint = True Then Elementos_Procesados = 0 : Repaint() : ToRePaint = False : toresort = True
        If toresort = True Then SortNodes()
        Return True

    End Function

End Class

Public Class BG3_Custom_ComboboxItem
    Public Property Text As String
    Public Property Value As Object
    Public Overrides Function ToString() As String
        Return Text
    End Function
    Sub New(texto As String, value As String)
        Me.Text = texto
        Me.Value = value
    End Sub
    Sub New()

    End Sub
End Class

Public Class BG3_Custom_Progreso_Class
    Public Property MaxP1 As Integer
    Public Property MaxP2 As Integer
    Public Property ValueP1 As Integer
    Public Property ValueP2 As Integer
    Sub New()
        MaxP1 = 100
        MaxP2 = 100
        ValueP1 = 0
        ValueP2 = 0
    End Sub
End Class

#End Region

Public Class BG3_Custom_TreeNode_Linked_Class(Of T As BG3_Obj_Generic_Class)
    Inherits System.Windows.Forms.TreeNode
    Public ReadOnly Objeto As BG3_Obj_Generic_Class
    Private PerpetualParent As BG3_Custom_TreeNode_Linked_Class(Of T)
    Private ReadOnly Sender As BG3_CustomFilter_Class(Of T)

    Private Sub Filter_Changed()
        If IsNothing(Me.Objeto) Then Exit Sub
        Sender.IncrementProcessed(1)
        Dim Muestra As Boolean = False
        If IsNothing(PerpetualParent) OrElse IsNothing(PerpetualParent.PerpetualParent) Then
            If Muestra = False Then Muestra = (Objeto.MapKey = Sender.Filter_Level2) Or (Objeto.Is_Filtered(Sender.Filter_Level1, Sender.Filter_Level2, Sender.Textfilter, Sender.SourceFilter, Sender.Deepfilter))
        Else
            If Muestra = False Then Muestra = Objeto.Is_Filtered(Sender.Filter_Level1, PerpetualParent.Objeto.MapKey, Sender.Textfilter, Sender.SourceFilter, Sender.Deepfilter)
            If Muestra = False Then Muestra = Children_filter()
        End If
        If Not Muestra AndAlso Not IsNothing(PerpetualParent) Then Me.PerpetualParent.Nodes.Remove(Me)
        If Muestra Then Reconnect()
    End Sub

    Public Sub ResortNod()
        If Me.Nodes.Count = 0 Then Exit Sub
        Dim child(Me.Nodes.Count - 1) As BG3_Custom_TreeNode_Linked_Class(Of T)
        Me.Nodes.CopyTo(child, 0)
        Me.Nodes.Clear()
        Me.Nodes.AddRange(child.OrderBy(Function(pf) BG3_CustomFilter_Class(Of T).Replace_Override_Text(pf.Text)).ToArray)
    End Sub

    Protected Sub Reconnect()
        If Not IsNothing(PerpetualParent) Then
            If PerpetualParent.Nodes.Contains(Me) = False Then
                If IsNothing(PerpetualParent.PerpetualParent) Then
                    If (Objeto.MapKey = Sender.Filter_Level2) Or (Objeto.Is_Filtered(Sender.Filter_Level1, Sender.Filter_Level2, "", Nothing, False)) Then PerpetualParent.Nodes.Add(Me)
                Else
                    PerpetualParent.Nodes.Add(Me)
                End If
            End If
            PerpetualParent.Reconnect()
        End If
    End Sub
    Public Function Children_filter() As Boolean
        If Me.Nodes.Count = 0 Then Return Objeto.Is_Filtered(Sender.Filter_Level1, "", Sender.Textfilter, Sender.SourceFilter, Sender.Deepfilter)
        If Me.Nodes.Cast(Of BG3_Custom_TreeNode_Linked_Class(Of T)).Where(Function(pf) pf.Children_filter() = True).Any Then
            Return True
        End If
        Return False
    End Function
    Private Sub Filter_Reloaded()
        If IsNothing(Me.Parent) Then Exit Sub
        Me.PerpetualParent = Me.Parent
    End Sub
    Private Sub DisplayFormat_Changed()
        If IsNothing(Me.Objeto) Then Exit Sub
        Sender.IncrementProcessed(1)
        Change_to_DisplayFormat()
    End Sub
    Public Sub Change_to_DisplayFormat()
        Me.BeginEdit()
        Select Case Sender.DisplayFormat
            Case BG3_Enum_DisplayFormat.DisplayName_and_Name
                If Objeto.DisplayName = "" Then Me.Text = Objeto.Name : Exit Select
                Me.Text = Objeto.DisplayName + " (" + Objeto.Name + ")"
            Case BG3_Enum_DisplayFormat.Name_and_DisplayName
                If Objeto.DisplayName = "" Then Me.Text = Objeto.Name : Exit Select
                Me.Text = Objeto.Name + " (" + Objeto.DisplayName + ")"
            Case BG3_Enum_DisplayFormat.OnlyDisplayName
                If Objeto.DisplayName = "" Then Me.Text = Objeto.Name : Exit Select
                Me.Text = Objeto.DisplayName
            Case BG3_Enum_DisplayFormat.OnlyName
                Me.Text = Objeto.Name
            Case Else
                Debugger.Break()
        End Select
        Me.ToolTipText = ""
        Me.EndEdit(False)
        If Not IsNothing(Me.Parent) Then
            PerpetualParent = Me.Parent
        End If
    End Sub
    Sub New(Filter As BG3_CustomFilter_Class(Of T), Obj As BG3_Obj_Generic_Class)
        AddHandler Filter.Filter_Changed, AddressOf Filter_Changed
        AddHandler Filter.Filter_Reloaded, AddressOf Filter_Reloaded
        AddHandler Filter.DisplayFormat_Changed, AddressOf DisplayFormat_Changed
        AddHandler Filter.SortRequested, AddressOf ResortNod
        Me.Objeto = Obj
        Me.Sender = Filter
    End Sub

    Sub New()

    End Sub
End Class
<Serializable>
Public Class Main_GameEngine_Settings_Class
    Public ReadOnly Property BG3_UTAM_Folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BG3 UTAM")
    Public Property GameExeFolder As String = "Search for the game bin folder"
    Public Property GameModFolder As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Larian Studios\Baldur's Gate 3\Mods")
    Public Property UTAMModFolder As String = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BG3 UTAM"), "Mods")

    Private _cacheFolder As String = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BG3 UTAM"), "Cache")
    Public Property UTAMCacheFolder As String
        Get
            Return _cacheFolder
        End Get
        Set(value As String)
            _cacheFolder = value
        End Set
    End Property

    Public ReadOnly Property GameDataFolder As String
        Get
            Return IO.Path.Combine(Path.GetDirectoryName(Me.GameExeFolder), "data")
        End Get
    End Property
    Public ReadOnly Property GameModProfile As String
        Get
            Return IO.Path.Combine(Path.GetDirectoryName(Me.GameModFolder), "PlayerProfiles")
        End Get
    End Property

    Public Property SelectedLocalization As Bg3_Enum_Languages = Bg3_Enum_Languages.English
    Sub New()

    End Sub
    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.Never)>
    <DefaultValue(True)>
    Public Property Showdetails As Boolean = True

End Class

<Serializable>
Public Class Main_GameEngine_Class
    Public Property Settings As New Main_GameEngine_Settings_Class
    Public ReadOnly Property CacheVersion As Double = 5.7
    Public Function Save_Settings() As Boolean
        Return SerializeObjetc(IO.Path.Combine(Settings.BG3_UTAM_Folder, "BG3_Utam.cfg"), Settings)
    End Function
    Public Function Load_Settings() As Boolean
        Dim Nuevo As New Main_GameEngine_Settings_Class
        If IO.File.Exists(IO.Path.Combine(Nuevo.BG3_UTAM_Folder, "BG3_Utam.cfg")) AndAlso DeserializeObject(IO.Path.Combine(Nuevo.BG3_UTAM_Folder, "BG3_Utam.cfg"), Nuevo) = True Then
            Settings = Nuevo
            Return True
        End If
        Return False
    End Function

    Public ReadOnly Property CheckFolders As Boolean
        Get
            If Not Check_folders_GameExe Then Return False
            If Not Check_folders_GameMods Then Return False
            If Not Check_folders_UtamMods Then Return False
            If Not Check_folders_UtamCache Then Return False
            Return True
        End Get
    End Property

    Public ReadOnly Property Check_folders_GameExe As Boolean
        Get
            If IO.Directory.Exists(Settings.GameExeFolder) = False OrElse Settings.GameExeFolder.EndsWith("bin", StringComparison.OrdinalIgnoreCase) = False Then Return False
            If IO.Directory.Exists(Settings.GameModFolder) = False OrElse Settings.GameModFolder.EndsWith("Mods", StringComparison.OrdinalIgnoreCase) = False Then Return False
            If IO.Directory.Exists(Settings.GameDataFolder) = False Then Return False
            Return True
        End Get
    End Property

    Public ReadOnly Property Check_folders_GameMods As Boolean
        Get
            If IO.Directory.Exists(Settings.GameModFolder) = False OrElse Settings.GameModFolder.EndsWith("Mods", StringComparison.OrdinalIgnoreCase) = False Then Return False
            If IO.Directory.Exists(Settings.GameModProfile) = False Then Return False
            Return True
        End Get
    End Property
    Public ReadOnly Property Check_folders_UtamMods As Boolean
        Get
            If IO.Directory.Exists(Settings.UTAMModFolder) = False Then
                Try
                    IO.Directory.CreateDirectory(Settings.UTAMModFolder)
                Catch ex As Exception
                    Return False
                End Try
            End If
            Return True
        End Get
    End Property
    Public ReadOnly Property Check_folders_UtamCache As Boolean
        Get
            If IO.Directory.Exists(Settings.UTAMCacheFolder) = False Then
                Try
                    IO.Directory.CreateDirectory(Settings.UTAMCacheFolder)
                Catch ex As Exception
                    Return False
                End Try
            End If
            Return True
        End Get
    End Property


    Public Property ProcessedPackList As New BG3_Pak_Packages_List_Class
    Public Property ProcessedModuleList As New Bg3_Mod_Module_List
    Public Property ProcessedLocalizationList As New BG3_Loca_Localization_List_Class
    Public Property ProcessedStatList As New BG3_Obj_SortedList_Class(Of BG3_Obj_Stats_Class)
    Public Property ProcessedGameObjectList As New BG3_Obj_SortedList_Class(Of BG3_Obj_Template_Class)
    Public Property ProcessedVisualBanksList As New BG3_Obj_SortedList_Class(Of BG3_Obj_VisualBank_Class)
    Public Property ProcessedIconAtlassList As New BG3_Obj_SortedList_Class(Of BG3_Obj_IconAtlass_Class)
    Public Property ProcessedAssets As New BG3_Obj_SortedList_Class(Of BG3_Obj_Assets_Class)
    Public Property ProcessedIcons As New BG3_Obj_SortedList_Class(Of BG3_Obj_IconUV_Class)
    Public Property ProcessedFlagsAndTags As New BG3_Obj_SortedList_Class(Of BG3_Obj_FlagsAndTags_Class)
    Public Property ProcessedTTables As New BG3_Obj_SortedList_Class(Of BG3_Obj_TreasureTable_Class)
    Public Property UtamTemplates As New List(Of BG3_Obj_Template_Class)
    Public Property UtamVisuals As New List(Of BG3_Obj_VisualBank_Class)
    Public Property Utamstats As New List(Of BG3_Obj_Stats_Class)
    Public Property UtamTreasures As New List(Of BG3_Obj_TreasureTable_Class)
    Public Property Utamflagsandtags As New List(Of BG3_Obj_FlagsAndTags_Class)
    Public Property Processed As Boolean = False

    Public ReadOnly Property Cache_String_List As New List(Of String) From {
        "GameObjects_Cache.json",
        "Localization_Cache.json",
        "Packs_Cache.json",
        "Stats_Cache.json",
        "VisualBanks_Cache.json",
        "IconAtlas_Cache.json",
        "Icons_Cache.json",
        "Assets_Cache.json",
        "FlagandTags_Cache.json",
        "Modules_Cache.json",
        "Ttables_Cache.json"
        }
    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.Always)>
    Public ReadOnly Property Cache_Object_List As New List(Of Object) From {
        ProcessedGameObjectList,
        ProcessedLocalizationList,
        ProcessedPackList,
        ProcessedStatList,
        ProcessedVisualBanksList,
        ProcessedIconAtlassList,
        ProcessedIcons,
        ProcessedAssets,
        ProcessedFlagsAndTags,
        ProcessedModuleList,
        ProcessedTTables
            }

    Public Sub Relink_Caches()
        Me.ProcessedGameObjectList = Cache_Object_List(0)
        Me.ProcessedLocalizationList = Cache_Object_List(1)
        Me.ProcessedPackList = Cache_Object_List(2)
        Me.ProcessedStatList = Cache_Object_List(3)
        Me.ProcessedVisualBanksList = Cache_Object_List(4)
        Me.ProcessedIconAtlassList = Cache_Object_List(5)
        Me.ProcessedIcons = Cache_Object_List(6)
        Me.ProcessedAssets = Cache_Object_List(7)
        Me.ProcessedFlagsAndTags = Cache_Object_List(8)
        Me.ProcessedModuleList = Cache_Object_List(9)
        Me.ProcessedTTables = Cache_Object_List(10)
        For Each pak In ProcessedPackList
            Dim path As String
            Select Case pak.PackageType
                Case BG3_Enum_Package_Type.BaseGame
                    path = IO.Path.Combine(Settings.GameDataFolder, pak.PackFileName)
                    pak.ReloadPackage(path)
                Case BG3_Enum_Package_Type.BaseMod
                    path = IO.Path.Combine(Settings.GameModFolder, pak.PackFileName)
                    pak.ReloadPackage(path)
                Case BG3_Enum_Package_Type.Loose_Files
                Case BG3_Enum_Package_Type.UTAM_Mod
                Case Else
                    Debugger.Break()
            End Select
        Next
    End Sub

    Private Shared _LoadedModOrder As List(Of String) = Nothing
    Public Shared ReadOnly Property ModLoadOrder As List(Of String)
        Get
            Try
                If IsNothing(_LoadedModOrder) Then
                    Dim modcfg As String = Path.Combine(GameEngine.Settings.GameModFolder, "..\PlayerProfiles\Public\modsettings.lsx")
                    If IO.File.Exists(modcfg) Then
                        Dim recurso = ResourceUtils.LoadResource(modcfg, ResourceFormat.LSX, ResourceLoadParameters.FromGameVersion(Game.BaldursGate3))
                        _LoadedModOrder = recurso.Regions("ModuleSettings").Children("ModOrder").First.Children.Where(Function(pf) pf.Key = "Module").First.Value.Select(Function(pq) pq.Attributes("UUID").Value.ToString).ToList
                    Else
                        _LoadedModOrder = New List(Of String)
                    End If
                End If
            Catch ex As Exception
                Debugger.Break()
                MsgBox("Error Loading ModOrderList")
                _LoadedModOrder = New List(Of String)
            End Try
            Return _LoadedModOrder
        End Get
    End Property
    Public Shared Function IncludeModInGame(ByRef utammod As BG3_Mod_Module_Class) As Boolean
        Try
            Dim modcfg As String = Path.Combine(GameEngine.Settings.GameModFolder, "..\PlayerProfiles\Public\modsettings.lsx")
            Dim uuid = utammod.UUID
            Dim debograbar As Boolean = False
            If IO.File.Exists(modcfg) Then
                Dim recurso = ResourceUtils.LoadResource(modcfg, ResourceFormat.LSX, ResourceLoadParameters.FromGameVersion(Game.BaldursGate3))
                Dim modules = recurso.Regions("ModuleSettings").Children("ModOrder").First.Children.Where(Function(pf) pf.Key = "Module").First.Value
                Dim mods = recurso.Regions("ModuleSettings").Children("Mods").First.Children.Where(Function(pf) pf.Key = "ModuleShortDesc").First.Value

                If mods.Where(Function(pq) pq.Attributes("UUID").Value.ToString = uuid).Any = False Then
                    Dim cre As New LSLib.LS.Node With {.Name = "ModuleShortDesc"}
                    cre.Attributes.Add("Folder", New NodeAttribute(AttributeType.LSString) With {.Value = utammod.Folder})
                    cre.Attributes.Add("MD5", New NodeAttribute(AttributeType.LSString) With {.Value = ""})
                    cre.Attributes.Add("Name", New NodeAttribute(AttributeType.LSString) With {.Value = utammod.Name})
                    cre.Attributes.Add("UUID", New NodeAttribute(AttributeType.FixedString) With {.Value = utammod.UUID})
                    cre.Attributes.Add("Version64", New NodeAttribute(AttributeType.Int64) With {.Value = utammod.Version})
                    cre.Parent = recurso.Regions("ModuleSettings").Children("Mods").First
                    recurso.Regions("ModuleSettings").Children("Mods").First.AppendChild(cre)
                    debograbar = True
                End If

                If modules.Where(Function(pq) pq.Attributes("UUID").Value.ToString = uuid).Any = False Then
                    Dim cre As New LSLib.LS.Node With {.Name = "Module"}
                    cre.Attributes.Add("UUID", New NodeAttribute(AttributeType.FixedString) With {.Value = utammod.UUID})
                    cre.Parent = recurso.Regions("ModuleSettings").Children("ModOrder").First
                    recurso.Regions("ModuleSettings").Children("ModOrder").First.AppendChild(cre)
                    debograbar = True
                End If
                If debograbar Then ResourceUtils.SaveResource(recurso, modcfg, ResourceFormat.LSX, ResourceConversionParameters.FromGameVersion(Game.BaldursGate3))
            End If
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

End Class

#Region "PackageClasses"

<Serializable>
Public Enum BG3_Enum_Package_Type
    BaseGame
    BaseMod
    UTAM_Mod
    Loose_Files
End Enum

<Serializable>
Public Class BG3_Pak_SourceOfResource_Class
    <JsonPropertyName("P")>
    Public Property Pak_Or_Folder As String
    Private _filrel As String
    <JsonPropertyName("F")>
    Public Property Filename_Relative As String
        Get
            Return _filrel
        End Get
        Set(value As String)
            _filrel = value
            If _filrel.StartsWith("..") Then Debugger.Break()
        End Set
    End Property
    Public ReadOnly Property ModFolder As String
        Get
            Return GetModFolder(Filename_Relative, Pak_Or_Folder)
        End Get
    End Property

    <JsonIgnore(Condition:=JsonIgnoreCondition.WhenWritingDefault)>
    <JsonPropertyName("T")>
    <DefaultValue(BG3_Enum_Package_Type.BaseGame)>
    Public Property PackageType As BG3_Enum_Package_Type = BG3_Enum_Package_Type.BaseGame

    Public ReadOnly Property Package As BG3_Pak_PackageContainer_Class
        Get
            Dim pack = Nothing
            If GameEngine.ProcessedPackList.Where(Function(pf) pf.PackFileName = Pak_Or_Folder And pf.PackageType = PackageType).Any Then
                pack = GameEngine.ProcessedPackList.Where(Function(pf) pf.PackFileName = Pak_Or_Folder And pf.PackageType = PackageType).Last
            End If
            Return pack
        End Get
    End Property
    Sub New(ByRef Pack As BG3_Pak_PackageContainer_Class, ByRef fil As PackagedFileInfo)
        Me.PackageType = Pack.PackageType
        Me.Pak_Or_Folder = Pack.PackFileName
        Me.Filename_Relative = fil.Name.Replace("\", "/")
    End Sub
    Sub New(ByRef Path As String, ByRef fil As String)
        Me.PackageType = BG3_Enum_Package_Type.Loose_Files
        Me.Pak_Or_Folder = Path
        Me.Filename_Relative = IO.Path.GetRelativePath(Path, fil).Replace("\", "/")
    End Sub
    Sub New(ByRef Path As String, ByRef fil As String, type As BG3_Enum_Package_Type)
        Me.PackageType = type
        Me.Pak_Or_Folder = Path
        Me.Filename_Relative = IO.Path.GetRelativePath(Path, fil).Replace("\", "/")
    End Sub
    Sub New(ByRef Path As String, type As BG3_Enum_Package_Type)
        Me.PackageType = type
        Me.Pak_Or_Folder = Path
        Me.Filename_Relative = ""
    End Sub
    Public Shared Function GetModFolder(Filename_Relative_param As String, Pack_Or_Path As String) As String
        Try
            Filename_Relative_param = Filename_Relative_param.Replace("\", "/")
            If Filename_Relative_param.Contains("/"c) = False Then
                Debugger.Break()
                Return "Unknown"
            End If
            Dim roots As String() = Filename_Relative_param.Split("/")
            If roots(0).Equals("Public", StringComparison.OrdinalIgnoreCase) Then Return roots(1)
            If roots(0).Equals("Mods", StringComparison.OrdinalIgnoreCase) Then Return roots(1)
            If roots(0).Equals("Generated", StringComparison.OrdinalIgnoreCase) Then
                If roots.Length = 1 Then
                    Debugger.Break()
                    Return "Unknown"
                End If
                If roots(1).Equals("Public", StringComparison.OrdinalIgnoreCase) Then Return roots(2)
            End If
            If roots(0).Equals("Localization", StringComparison.OrdinalIgnoreCase) Then Return IO.Path.GetFileNameWithoutExtension(Pack_Or_Path)
            Debugger.Break()
        Catch ex As Exception
            Debugger.Break()
        End Try
        Return "Unknown"
    End Function

    Public Function CreateContentReader() As Stream
        If Not IsNothing(Strm) Then ReleaseMem()
        If Me.PackageType = BG3_Enum_Package_Type.Loose_Files Or Me.PackageType = BG3_Enum_Package_Type.UTAM_Mod Then
            Strm = New FileStream(IO.Path.Combine(Pak_Or_Folder, Filename_Relative), FileMode.Open, FileAccess.Read)
        Else
            Strm = Me.Package.Package.Files.Where(Function(pf) pf.Name.Equals(Filename_Relative)).First.CreateContentReader
        End If
        Return Strm
    End Function

    Sub New()

    End Sub
    Public Sub ReleaseMem()
        If Not IsNothing(Strm) Then
            Strm.Close()
            Strm.Dispose()
            Strm = Nothing
        End If
        If Not IsNothing(Reso) Then Reso = Nothing
        If Not IsNothing(LocaReso) Then LocaReso = Nothing
    End Sub

    Private Strm As Stream = Nothing
    Private Reso As Resource = Nothing
    Private LocaReso As LocaResource = Nothing
    Public Function ReadLocaResource() As LSLib.LS.LocaResource
        Dim LocaFormat
        Select Case Path.GetExtension(Me.Filename_Relative).ToLower
            Case ".loca"
                LocaFormat = LSLib.LS.LocaFormat.Loca
            Case ".xml"
                LocaFormat = LSLib.LS.LocaFormat.Xml
            Case Else
                Debugger.Break()
                Throw New Exception
        End Select
        Try
            LocaReso = LocaUtils.Load(Me.CreateContentReader, LocaFormat)
        Catch ex As Exception
            LocaReso = TryFromMemory(LocaFormat)
            Debugger.Break()
        End Try
        Return LocaReso
    End Function

    Private Function TryFromMemory(LocaFormat As LSLib.LS.LocaFormat) As LSLib.LS.LocaResource
        Try
            Dim fil As String = System.IO.Path.GetTempFileName
            Dim filst As New FileStream(fil, FileMode.Create)
            Me.CreateContentReader.CopyTo(filst)
            filst.Flush()
            filst.Close()
            Dim Reso As LocaResource = LocaUtils.Load(fil, LocaFormat)
            IO.File.Delete(fil)
            ReleaseMem()
            Return Reso
        Catch ex As Exception
            Debugger.Break()
        End Try
        Return New LSLib.LS.LocaResource
    End Function


    Public Function ReadResource() As Resource
        Dim ResourceFormat
        Select Case Path.GetExtension(Me.Filename_Relative).ToLower
            Case ".lsf"
                ResourceFormat = Enums.ResourceFormat.LSF
            Case ".lsx"
                ResourceFormat = Enums.ResourceFormat.LSX
            Case ".lsfx" '????
                ResourceFormat = Enums.ResourceFormat.LSX
            Case ".lsb"
                ResourceFormat = Enums.ResourceFormat.LSB
            Case ".lsj"
                ResourceFormat = Enums.ResourceFormat.LSJ
            Case Else
                Debugger.Break()
                Throw New Exception
        End Select
        Try
            Reso = ResourceUtils.LoadResource(Me.CreateContentReader, ResourceFormat, Funciones.LoadParams_LSLIB)
        Catch ex As Exception

            If Filename_Relative.EndsWith("meta.lsx", StringComparison.OrdinalIgnoreCase) Then
                Reso = FixVersion(ResourceFormat)
            Else
                Debugger.Break()
                Reso = New LSLib.LS.Resource
            End If
        End Try
        Return Reso
    End Function

    Private Function FixVersion(ResourceFormat As Enums.ResourceFormat) As LSLib.LS.Resource
        Try
            Dim byt(Me.CreateContentReader.Length - 1) As Byte
            Me.CreateContentReader.Read(byt, 0, byt.Length)
            Dim str = System.Text.Encoding.UTF8.GetString(byt)
            str = str.Replace("<attribute id=" + Chr(34) + "Version" + Chr(34) + " type=" + Chr(34) + "int32" + Chr(34), "<attribute id=" + Chr(34) + "Version64" + Chr(34) + " type=" + Chr(34) + "int64" + Chr(34))
            ReleaseMem()
            Return ResourceUtils.LoadResource(New MemoryStream(Encoding.UTF8.GetBytes(str)), ResourceFormat, Funciones.LoadParams_LSLIB)
        Catch ex As Exception
            Debugger.Break()
        End Try
        Return New LSLib.LS.Resource
    End Function


End Class


<Serializable>
Public Class BG3_Pak_Packages_List_Class
    Inherits List(Of BG3_Pak_PackageContainer_Class)
    Public Function AddPackageContainer(Path As String, Packagetype As BG3_Enum_Package_Type) As Boolean
        Try
            Dim obj As New BG3_Pak_PackageContainer_Class(Path, Packagetype)
            SyncLock Me
                Me.Add(obj)

            End SyncLock
            GameEngine.ProcessedModuleList.ProcessMetas(obj.PackFileName, Packagetype)

            Return True
        Catch ex As Exception
            Debugger.Break()
            MsgBox("Error Loading Pack")
            Return False
        End Try
    End Function

    Public Shared Function Find_Asset(Prefix As String, Asset As String) As BG3_Obj_Assets_Class
        Dim Fillpath As String = IO.Path.Combine(Prefix, Asset).Replace("\", "/")
        Dim ass As BG3_Obj_Assets_Class = Nothing
        If GameEngine.ProcessedAssets.TryGetValue(Fillpath, ass) Then
            Return ass
        End If
        Return Nothing
    End Function
    Public Shared Function Find_AssetRelative(Prefix As String, Asset As String) As BG3_Obj_Assets_Class
        Dim Fillpath As String = IO.Path.Combine(Prefix, Asset).Replace("\", "/")
        Dim ass As BG3_Obj_Assets_Class = Nothing
        Dim filtro = GameEngine.ProcessedAssets.ElementValues.Where(Function(pf) pf.SourceOfResorce.Filename_Relative = Fillpath)
        If filtro.Count = 1 Then Return filtro.First
        Return Nothing
    End Function
    Public Shared Function Find_Assets(Prefix As String, AssetStarting As String, Extension As String) As BG3_Obj_Assets_Class()
        Dim Fillpath As String = IO.Path.Combine(Prefix, AssetStarting).Replace("\", "/")
        Return GameEngine.ProcessedAssets.Elements.Where(Function(pf) pf.Key.EndsWith(Extension, StringComparison.Ordinal) AndAlso pf.Key.StartsWith(AssetStarting, StringComparison.OrdinalIgnoreCase)).Select(Function(pf) pf.Value).ToArray
    End Function


    Sub New()
    End Sub

    Public ReadOnly Property ReprocessNodes As System.Windows.Forms.TreeNode()
        Get
            Dim GamePacksNode As New System.Windows.Forms.TreeNode("Game")
            Dim It11 As New System.Windows.Forms.TreeNode("Loaded")
            Dim It12 As New System.Windows.Forms.TreeNode("Not Loaded")
            Dim ModsPacksNode As New System.Windows.Forms.TreeNode("Mods")
            Dim It21 As New System.Windows.Forms.TreeNode("Loaded")
            Dim It22 As New System.Windows.Forms.TreeNode("Not Loaded")
            Dim it11n As Integer = 0
            Dim it12n As Integer = 0
            Dim it21n As Integer = 0
            Dim it22n As Integer = 0

            For Each pak In Me.OrderBy(Function(pf) pf.SortIndex)
                Dim it = New System.Windows.Forms.TreeNode(pak.PackFileName) With {.Checked = Not IsNothing(pak.Package)}
                Dim itdest As System.Windows.Forms.TreeNode = It11
                If it.Checked = False Then
                    If pak.PackageType = BG3_Enum_Package_Type.BaseGame Then
                        it.ForeColor = Color.Gray
                        itdest = It12
                        it12n += 1
                    Else
                        it.ForeColor = Color.LightBlue
                        itdest = It22
                        it22n += 1
                    End If
                Else
                    If pak.PackageType = BG3_Enum_Package_Type.BaseGame Then
                        it.ForeColor = Color.Black
                        itdest = It11
                        it11n += 1
                    Else
                        it.ForeColor = Color.Blue
                        itdest = It21
                        it21n += 1
                    End If
                End If
                For Each modu In GameEngine.ProcessedModuleList.Where(Function(pf) pf.SourceOfResource.Pak_Or_Folder = pak.PackFileName AndAlso pak.PackageType = pf.SourceOfResource.PackageType)
                    it.Nodes.Add(New System.Windows.Forms.TreeNode With {.Text = modu.Name, .ForeColor = it.ForeColor})
                Next
                itdest.Nodes.Add(it)
            Next
            GamePacksNode.Text = "Game (" + (it11n + it12n).ToString + ")"
            ModsPacksNode.Text = "Mods (" + (it21n + it22n).ToString + ")"
            It11.Text = "Loaded (" + (it11n).ToString + ")"
            It12.Text = "Not Loaded (" + (it12n).ToString + ")"
            GamePacksNode.Nodes.AddRange({It11, It12})
            It21.Text = "Loaded (" + (it21n).ToString + ")"
            It22.Text = "Not Loaded (" + (it22n).ToString + ")"
            ModsPacksNode.Nodes.AddRange({It21, It22})
            Return {GamePacksNode, ModsPacksNode}
        End Get
    End Property

    Private Shared Function Sort_Base(Pak As String) As Integer
        Select Case True
            Case Pak.StartsWith("DiceSet")
                Return 1
            Case Pak.StartsWith("Localization\")
                Return 2
            Case Pak = "Effects.pak"
                Return 1
            Case Pak = "LowTex.pak"
                Return 1
            Case Pak = "Icons.pak"
                Return 1
            Case Pak = "Models.pak"
                Return 1
            Case Pak = "PsoCache.pak"
                Return 1
            Case Pak = "Materials.pak"
                Return 1
            Case Pak = "GamePlatform.pak"
                Return 1
            Case Pak = "SharedSoundBanks.pak"
                Return 1
            Case Pak = "EngineShaders.pak"
                Return 1
            Case Pak = "Assets.pak"
                Return 1
            Case Pak = "Textures.pak"
                Return 1
            Case Pak = "VirtualTextures.pak"
                Return 1
            Case Pak = "Game.pak"
                Return 2
            Case Pak = "Engine.pak"
                Return 3

            Case Pak = "SharedSounds.pak"
                Return 10
            Case Pak = "Shared.pak"
                Return 10

            Case Pak = "Gustav_NavCloud.pak"
                Return 20
            Case Pak = "Gustav_Textures.pak"
                Return 21
            Case Pak = "Gustav_Video.pak"
                Return 22
            Case Pak = "Gustav.pak"
                Return 23

            Case Pak.StartsWith("Patch1")
                Return 31
            Case Pak.StartsWith("Patch2")
                Return 32
            Case Pak.StartsWith("Patch3")
                Return 33
            Case Pak.StartsWith("Patch4")
                Return 34
            Case Pak.StartsWith("Patch5")
                Return 35
            Case Pak.StartsWith("Patch6")
                Return 36
            Case Pak.StartsWith("Patch")
                Return 100
            Case Else
                Return 1
        End Select
    End Function
    Public Sub Re_Sort()
        ' Ordena primero por tipo
        Try
            SyncLock (Me)
                Dim SortedbyType = Me.OrderBy(Function(pq) pq.PackageType).ThenBy(Function(pf) pf.PackFileName).ToList
                SortedbyType.ForEach(Function(e)
                                         Dim ret = e
                                         e.SortIndex = e.PackageType * 1000 + SortedbyType.IndexOf(e) + 1
                                         Return e
                                     End Function)

                SortedbyType.Where(Function(pf) pf.PackageType = BG3_Enum_Package_Type.BaseGame).ToList.ForEach(Function(e)
                                                                                                                    e.SortIndex = e.PackageType * 1000 + Sort_Base(e.PackFileName)
                                                                                                                    Return e
                                                                                                                End Function)
                For x = 0 To 1
                    Dim filtro As IEnumerable(Of BG3_Pak_PackageContainer_Class) = Nothing
                    If x = 0 Then filtro = Me.Where(Function(pf) pf.PackageType = BG3_Enum_Package_Type.BaseGame)
                    If x = 1 Then filtro = Me.Where(Function(pf) pf.PackageType <> BG3_Enum_Package_Type.BaseGame)
                    Dim finished As Boolean = False
                    While finished = False
                        finished = True
                        For Each pak In filtro
                            For Each pak2 In filtro.Where(Function(pf) pf.SortIndex <> pak.SortIndex)
                                For Each modu In pak.AssociatedModules
                                    For Each modu2 In pak2.AssociatedModules
                                        If modu.Dependencies.Contains(modu2.UUID) Then
                                            If pak2.SortIndex > pak.SortIndex Then
                                                If (pak.AssociatedModules.Select(Function(pq) pq.UUID).Contains(modu2.UUID) = False AndAlso pak2.AssociatedModules.Select(Function(pq) pq.UUID).Contains(modu.UUID) = False) OrElse pak2.AssociatedModules.Count < pak.AssociatedModules.Count Then
                                                    Dim tmp = pak2.SortIndex
                                                    pak2.SortIndex = pak.SortIndex
                                                    pak.SortIndex = tmp
                                                    finished = False
                                                End If

                                            End If
                                        End If

                                    Next
                                Next
                            Next
                        Next
                    End While

                Next

                'Debugger.Break()
            End SyncLock
        Catch ex As Exception
            Debugger.Break()
        End Try

    End Sub

End Class

<Serializable>
Public Class BG3_Pak_PackageContainer_Class
    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.Never)>
    <JsonPropertyName("P")>
    Public Property PackFileName As String = ""

    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.Never)>
    <JsonPropertyName("I")>
    Public Property SortIndex As Integer = 0

    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.Always)>
    Public Property Package As LSLib.LS.Package = Nothing

    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.WhenWritingDefault)>
    <JsonPropertyName("T")>
    <DefaultValue(BG3_Enum_Package_Type.BaseGame)>
    Public Property PackageType As BG3_Enum_Package_Type = BG3_Enum_Package_Type.BaseGame
    Sub New()

    End Sub
    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.Always)>
    Public ReadOnly Property AssociatedModules As IEnumerable(Of BG3_Mod_Module_Class)
        Get
            Return GameEngine.ProcessedModuleList.Where(Function(pf) pf.SourceOfResource.PackageType = Me.PackageType AndAlso pf.SourceOfResource.Pak_Or_Folder = Me.PackFileName)
        End Get
    End Property
    Sub New(Path As String, Packagetype As BG3_Enum_Package_Type)
        Try
            Me.PackageType = Packagetype
            Select Case Packagetype
                Case BG3_Enum_Package_Type.BaseGame
                    PackFileName = IO.Path.GetRelativePath(GameEngine.Settings.GameDataFolder, Path)
                Case BG3_Enum_Package_Type.BaseMod
                    PackFileName = IO.Path.GetRelativePath(GameEngine.Settings.GameModFolder, Path)
                Case BG3_Enum_Package_Type.Loose_Files
                    PackFileName = ""
                Case Else
                    Debugger.Break()
                    PackFileName = Path
            End Select
            ReloadPackage(Path)
        Catch ex As Exception
            Debugger.Break()
        End Try
    End Sub
    Public Sub ReloadPackage(Path As String)
        Try
            Package = New PackageReader().Read(Path)
        Catch ex As Exception
            If IO.Path.GetFileNameWithoutExtension(Path).StartsWith("Textures_") Or IO.Path.GetFileNameWithoutExtension(Path).StartsWith("VirtualTextures_") Then
                ' do nothing
            Else
                If IO.Path.GetFileNameWithoutExtension(Path).StartsWith("LowTex") = False Then
                    Debugger.Break()
                End If
            End If
        End Try
    End Sub

End Class
<Serializable>
Public Class Bg3_Mod_Module_List
    Inherits List(Of BG3_Mod_Module_Class)
    Public Sub ProcessMetas(pak_or_path As String, type As BG3_Enum_Package_Type)
        Dim source As BG3_Pak_SourceOfResource_Class
        Select Case type
            Case BG3_Enum_Package_Type.BaseGame, BG3_Enum_Package_Type.BaseMod
                Dim package As BG3_Pak_PackageContainer_Class = GameEngine.ProcessedPackList.Where(Function(pf) pf.PackFileName = pak_or_path).First()
                If Not IsNothing(package.Package) Then
                    For Each meta In package.Package.Files.Where(Function(pf) Path.GetFileName(pf.Name).EndsWith("meta.lsx", StringComparison.OrdinalIgnoreCase))
                        source = New BG3_Pak_SourceOfResource_Class(package, meta)
                        Procesa_Recurso_meta(source)
                    Next
                End If
            Case BG3_Enum_Package_Type.Loose_Files, BG3_Enum_Package_Type.UTAM_Mod
                For Each meta In IO.Directory.GetFiles(pak_or_path, "*.*", SearchOption.AllDirectories).Where(Function(pf) pf.EndsWith("meta.lsx", StringComparison.OrdinalIgnoreCase))
                    source = New BG3_Pak_SourceOfResource_Class(pak_or_path, meta)
                    Procesa_Recurso_meta(source)
                Next
            Case Else
                Debugger.Break()
        End Select

    End Sub
    Public Sub Procesa_Recurso_meta(ByRef Source As BG3_Pak_SourceOfResource_Class)
        Dim recurso = (Source).ReadResource
        If Not IsNothing(recurso) Then
            Dim modu As New BG3_Mod_Module_Class With {.SourceOfResource = Source}
            modu.Update(recurso)
            SyncLock Me
                Me.Add(modu)
            End SyncLock
        End If
        Source.ReleaseMem()
    End Sub


End Class

<Serializable>
Public Class Utam_CurrentModClass

    <JsonIgnore(Condition:=JsonIgnoreCondition.Always)>
    Public Property ModLsx As New BG3_Mod_Module_Class
    <JsonIgnore(Condition:=JsonIgnoreCondition.Never)>
    Public Property SaveFolder As String = ""
    <JsonIgnore(Condition:=JsonIgnoreCondition.Never)>
    Public Property BuildPak As Boolean = True
    <JsonIgnore(Condition:=JsonIgnoreCondition.Never)>
    Public Property BuildZip As Boolean = True
    <JsonIgnore(Condition:=JsonIgnoreCondition.Never)>
    Public Property BuildModFixer As Boolean = False
    <JsonIgnore(Condition:=JsonIgnoreCondition.Never)>
    Public Property AddToGame As Boolean = True
    <JsonIgnore(Condition:=JsonIgnoreCondition.Never)>
    Public Property ShinyhoboCompatible As Boolean = True

    <JsonIgnore(Condition:=JsonIgnoreCondition.Never)>
    Public Property PackPriority As Byte = 30

    <JsonIgnore(Condition:=JsonIgnoreCondition.Never)>
    Public Property SaveUUID As String = ""

    Public ReadOnly Property Paths_Save As String
        Get
            Return IO.Path.Combine(GameEngine.Settings.UTAMModFolder, IO.Path.Combine(ModLsx.Folder))
        End Get
    End Property

    Public ReadOnly Property Paths_Mod As String
        Get
            Return IO.Path.Combine(GameEngine.Settings.UTAMModFolder, ModLsx.Folder)
        End Get
    End Property

    Public ReadOnly Property MetaFilePath As String
        Get
            Return IO.Path.Combine(IO.Path.Combine(IO.Path.Combine(GameEngine.Settings.UTAMModFolder, IO.Path.Combine(ModLsx.Folder, "Mods")), ModLsx.Folder), "meta.lsx")
        End Get
    End Property
    Public ReadOnly Property LevelsFolderPath As String
        Get
            Return IO.Path.Combine(IO.Path.Combine(IO.Path.Combine(GameEngine.Settings.UTAMModFolder, IO.Path.Combine(ModLsx.Folder, "Mods")), ModLsx.Folder), "Levels")
        End Get
    End Property
    Public ReadOnly Property LocalizationLanguagePath(language As Bg3_Enum_Languages) As String
        Get
            Return IO.Path.Combine(IO.Path.Combine(GameEngine.Settings.UTAMModFolder, IO.Path.Combine(ModLsx.Folder, "Localization")), language.ToString)
        End Get
    End Property
    Public ReadOnly Property LocalizationFilePath(language As Bg3_Enum_Languages) As String
        Get
            Return IO.Path.Combine(LocalizationLanguagePath(language), ModLsx.Folder + ".loca")
        End Get
    End Property
    Public ReadOnly Property LocalizationFolderPath As String
        Get
            Return IO.Path.Combine(GameEngine.Settings.UTAMModFolder, IO.Path.Combine(ModLsx.Folder, "Localization"))
        End Get
    End Property
    Public ReadOnly Property PublicFolderPath As String
        Get
            Return IO.Path.Combine(GameEngine.Settings.UTAMModFolder, IO.Path.Combine(ModLsx.Folder, "Public"))
        End Get
    End Property
    Public ReadOnly Property PublicFolderandModePath As String
        Get
            Return IO.Path.Combine(PublicFolderPath, ModLsx.Folder)
        End Get
    End Property
    Public ReadOnly Property RootTemplatePath As String
        Get
            Return IO.Path.Combine(PublicFolderandModePath, "RootTemplates")
        End Get
    End Property
    Public ReadOnly Property AssetsPath As String
        Get
            Return IO.Path.Combine(GameEngine.Settings.UTAMModFolder, IO.Path.Combine(ModLsx.Folder, "Generated\Public\" + ModLsx.Folder + "\Assets"))
        End Get
    End Property
    Public ReadOnly Property MaterialsPath As String
        Get
            Return IO.Path.Combine(PublicFolderandModePath, "Assets\Materials")
        End Get
    End Property

    Public ReadOnly Property RootTemplateFilePath As String
        Get
            Return IO.Path.Combine(RootTemplatePath, ModLsx.Folder + ".lsf")
        End Get
    End Property
    Public ReadOnly Property LevelsFolderPathWithLevel(level As String, type As BG3_Enum_Templates_Type) As String
        Get
            Dim fol As String = IO.Path.Combine(LevelsFolderPath, level)
            Select Case type
                Case BG3_Enum_Templates_Type.character
                    fol = IO.Path.Combine(fol, "Characters")
                Case BG3_Enum_Templates_Type.item
                    fol = IO.Path.Combine(fol, "Items")
                Case Else
                    Debugger.Break()
            End Select
            If IO.Directory.Exists(fol) = False Then IO.Directory.CreateDirectory(fol)
            Return fol
        End Get
    End Property

    Public ReadOnly Property LevelTemplateFilePath(Level As String, type As BG3_Enum_Templates_Type) As String
        Get
            Return IO.Path.Combine(LevelsFolderPathWithLevel(Level, type), ModLsx.Folder + ".lsf")
        End Get
    End Property
    Public ReadOnly Property ActionResourcPath As String
        Get
            Return IO.Path.Combine(PublicFolderandModePath, "ActionResourceDefinitions")
        End Get
    End Property

    Public ReadOnly Property ActionResourceFilePath As String
        Get
            Return IO.Path.Combine(ActionResourcPath, "ActionResourceDefinitions.lsx")
        End Get
    End Property
    Public ReadOnly Property TagsPath As String
        Get
            Return IO.Path.Combine(PublicFolderandModePath, "Tags")
        End Get
    End Property
    Public ReadOnly Property VisualBanksPath As String
        Get
            Return IO.Path.Combine(PublicFolderandModePath, "Content\Assets\Characters\[PAK]_Shared_Materials")
        End Get
    End Property

    Public ReadOnly Property VisualBanksFilePath As String
        Get
            Return IO.Path.Combine(VisualBanksPath, ModLsx.Folder + ".lsf")
        End Get
    End Property
    Public ReadOnly Property MaterialFilePath(que As BG3_Obj_VisualBank_Class) As String
        Get
            Dim file As String = IO.Path.Combine(Paths_Mod, que.MapKey)
            Dim dire As String = IO.Path.GetDirectoryName(file)
            If IO.Directory.Exists(dire) = False Then IO.Directory.CreateDirectory(dire)
            Return file
        End Get
    End Property

    Public ReadOnly Property StatsPath As String
        Get
            Return IO.Path.Combine(PublicFolderandModePath, "Stats")
        End Get
    End Property
    Public ReadOnly Property StatsGeneratedPath As String
        Get
            Return IO.Path.Combine(StatsPath, "Generated")
        End Get
    End Property

    Public ReadOnly Property StatsGeneratedDataPath As String
        Get
            Return IO.Path.Combine(StatsGeneratedPath, "Data")
        End Get
    End Property
    Public ReadOnly Property TreasureTableFilePath As String
        Get
            Return IO.Path.Combine(StatsGeneratedPath, "TreasureTable.txt")
        End Get
    End Property
    Public ReadOnly Property StatsObjectsFilePath As String
        Get
            Return IO.Path.Combine(StatsGeneratedDataPath, "Object.txt")
        End Get
    End Property
    Public ReadOnly Property StatsCharacterFilePath As String
        Get
            Return IO.Path.Combine(StatsGeneratedDataPath, "Character.txt")
        End Get
    End Property
    Public ReadOnly Property StatsStatusFilePath As String
        Get
            Return IO.Path.Combine(StatsGeneratedDataPath, "Status.txt")
        End Get
    End Property
    Public ReadOnly Property StatsDataFilePath As String
        Get
            Return IO.Path.Combine(StatsGeneratedDataPath, "Data.txt")
        End Get
    End Property
    Public ReadOnly Property StatsCombinationsFilePath As String
        Get
            Return IO.Path.Combine(StatsGeneratedPath, "ItemCombos.txt")
        End Get
    End Property

    Public Sub Create_folders()
        Dim fol As String
        fol = LocalizationFolderPath
        If IO.Directory.Exists(fol) = False Then IO.Directory.CreateDirectory(fol)
        For Each lan In [Enum].GetValues(Of Bg3_Enum_Languages)
            fol = LocalizationLanguagePath(lan)
            If IO.Directory.Exists(fol) = False Then IO.Directory.CreateDirectory(fol)
        Next
        fol = PublicFolderPath
        If IO.Directory.Exists(fol) = False Then IO.Directory.CreateDirectory(fol)
        fol = PublicFolderandModePath
        If IO.Directory.Exists(fol) = False Then IO.Directory.CreateDirectory(fol)
        fol = RootTemplatePath
        If IO.Directory.Exists(fol) = False Then IO.Directory.CreateDirectory(fol)
        fol = StatsPath
        If IO.Directory.Exists(fol) = False Then IO.Directory.CreateDirectory(fol)
        fol = StatsGeneratedPath
        If IO.Directory.Exists(fol) = False Then IO.Directory.CreateDirectory(fol)
        fol = StatsGeneratedDataPath
        If IO.Directory.Exists(fol) = False Then IO.Directory.CreateDirectory(fol)
        fol = VisualBanksPath
        If IO.Directory.Exists(fol) = False Then IO.Directory.CreateDirectory(fol)
        fol = TagsPath
        If IO.Directory.Exists(fol) = False Then IO.Directory.CreateDirectory(fol)
        fol = AssetsPath
        If IO.Directory.Exists(fol) = False Then IO.Directory.CreateDirectory(fol)
        fol = MaterialsPath
        If IO.Directory.Exists(fol) = False Then IO.Directory.CreateDirectory(fol)
        fol = ActionResourcPath
        If IO.Directory.Exists(fol) = False Then IO.Directory.CreateDirectory(fol)
        fol = LevelsFolderPath
        If IO.Directory.Exists(fol) = False Then IO.Directory.CreateDirectory(fol)
    End Sub

    <JsonIgnore(Condition:=JsonIgnoreCondition.Always)>
    Public Property Isnew As Boolean = False

    <JsonIgnore(Condition:=JsonIgnoreCondition.Always)>
    Public Versionconverter As New LSLib.LS.PackedVersion
End Class
<Serializable>
Public Class BG3_Mod_Module_Class

    <JsonPropertyName("S")>
    Public Property SourceOfResource As BG3_Pak_SourceOfResource_Class

    Public Property UUID As String
        Get
            Return NodeLSLIB.TryGetOrEmpty("UUID")
        End Get
        Set(value As String)
            If NodeLSLIB.Attributes.TryAdd("UUID", New NodeAttribute(AttributeType.FixedString) With {.Value = value}) = False Then
                NodeLSLIB.Attributes("UUID").Value = value
            End If
        End Set
    End Property

    Public Sub SaveChanges()
        MetaXMLZip = MetaLSLIB.To_XML.ZippedString
    End Sub
    Public Sub RejectChanges()
        Clear_Cached_Data()
    End Sub

    Public Property Name As String
        Get
            Return NodeLSLIB.TryGetOrEmpty("Name")
        End Get
        Set(value As String)
            If NodeLSLIB.Attributes.TryAdd("Name", New NodeAttribute(AttributeType.LSString) With {.Value = value}) = False Then
                NodeLSLIB.Attributes("Name").Value = value
            End If
        End Set
    End Property
    Public Property Description As String
        Get
            Return NodeLSLIB.TryGetOrEmpty("Description")
        End Get
        Set(value As String)
            If NodeLSLIB.Attributes.TryAdd("Description", New NodeAttribute(AttributeType.LSString) With {.Value = value}) = False Then
                NodeLSLIB.Attributes("Description").Value = value
            End If
        End Set
    End Property

    Public Property Folder As String
        Get
            Return NodeLSLIB.TryGetOrEmpty("Folder")
        End Get
        Set(value As String)
            If NodeLSLIB.Attributes.TryAdd("Folder", New NodeAttribute(AttributeType.LSString) With {.Value = value}) = False Then
                NodeLSLIB.Attributes("Folder").Value = value
            End If
        End Set
    End Property
    Public Property Author As String
        Get
            Return NodeLSLIB.TryGetOrEmpty("Author")
        End Get
        Set(value As String)
            If NodeLSLIB.Attributes.TryAdd("Author", New NodeAttribute(AttributeType.LSString) With {.Value = value}) = False Then
                NodeLSLIB.Attributes("Author").Value = value
            End If
        End Set
    End Property

    Private _CacheDependencies As List(Of String)

    <JsonIgnore(Condition:=JsonIgnoreCondition.Always)>
    Public ReadOnly Property Dependencies As List(Of String)
        Get
            If IsNothing(_CacheDependencies) Then
                _CacheDependencies = Nothing
                Dim dep = MetaLSLIB.Regions("Config").Children("Dependencies").First
                If dep.Children.Count > 0 Then
                    _CacheDependencies = dep.Children.Select(Function(pf) pf.Value).First.Select(Function(pq) pq.Attributes("UUID").Value.ToString).ToList
                Else
                    _CacheDependencies = New List(Of String)
                End If
            End If
            Return _CacheDependencies
        End Get
    End Property

    Public Property LoadOrderd As Integer = 0
    Public Property Version As Long
        Get
            Return NodeLSLIB.TryGetOrEmpty("Version64")
        End Get
        Set(value As Long)
            If NodeLSLIB.Attributes.TryAdd("Version64", New NodeAttribute(AttributeType.Int64) With {.Value = value}) = False Then
                NodeLSLIB.Attributes("Version64").Value = value
            End If
        End Set
    End Property
    Public Property PublishVersion As Long
        Get
            Return NodeLSLIB.Children("PublishVersion").First.TryGetOrEmpty("Version64")
        End Get
        Set(value As Long)
            If NodeLSLIB.Children.TryAdd("PublishVersion", {New LSLib.LS.Node With {.Name = "PublishVersion"}}.ToList) = False Then
                If NodeLSLIB.Children("PublishVersion").First.Attributes.TryAdd("Version64", New NodeAttribute(AttributeType.Int64) With {.Value = value}) = False Then
                    NodeLSLIB.Children("PublishVersion").First.Attributes("Version64").Value = value
                End If
            End If
        End Set
    End Property



    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.Never)>
    Public Property MetaXMLZip As Byte() = Generate_new_Mod.To_XML.ZippedString

    Private _CacheXML As String = Nothing
    Private _CacheMeta As LSLib.LS.Resource = Nothing

    Public Sub New()

    End Sub

    Public Overridable Sub Clear_Cached_Data()
        _CacheMeta = Nothing
        _CacheXML = Nothing
    End Sub

    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.Always)>
    Public ReadOnly Property NodeLSLIB As LSLib.LS.Node
        Get
            Return MetaLSLIB.Regions("Config").Children("ModuleInfo").First
        End Get
    End Property
    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.Always)>
    Public ReadOnly Property MetaLSLIB As LSLib.LS.Resource
        Get
            If IsNothing(_CacheMeta) Then
                _CacheMeta = ResourceUtils.LoadResource(New MemoryStream(Encoding.UTF8.GetBytes(MetaXMLZip.UnZippedString)), Enums.ResourceFormat.LSX, Funciones.LoadParams_LSLIB)
            End If
            Return _CacheMeta
        End Get
    End Property
    Public ReadOnly Property MetaXML As String
        Get
            If IsNothing(_CacheXML) Then
                _CacheXML = MetaXMLZip.UnZippedString
            End If
            Return _CacheXML
        End Get
    End Property

    Public Shared Function Generate_new_Mod() As LSLib.LS.Resource
        Dim MetaResource As New LSLib.LS.Resource
        MetaResource.Metadata.MajorVersion = Default_LS_Version_Major
        MetaResource.Metadata.MinorVersion = Default_LS_Version_Minor
        MetaResource.Metadata.Revision = Default_LS_Version_Revision
        MetaResource.Metadata.BuildNumber = Default_LS_Version_Build
        Dim ConfigR As New LSLib.LS.Region With {.Name = "root", .RegionName = "Config"}
        MetaResource.Regions.Add("Config", ConfigR)
        Dim LSDependencies As LSLib.LS.Node
        Dim LSModuleInfo As LSLib.LS.Node
        Dim LSModulePV As LSLib.LS.Node
        Dim LSModuleTM As LSLib.LS.Node
        Dim LSModuleTM2 As LSLib.LS.Node
        LSDependencies = New LSLib.LS.Node With {.Name = "Dependencies"}
        LSModuleInfo = New LSLib.LS.Node With {.Name = "ModuleInfo"}
        ConfigR.AppendChild(LSDependencies)
        ConfigR.AppendChild(LSModuleInfo)
        LSModuleInfo.Attributes.Add("Author", (New LSLib.LS.NodeAttribute(AttributeType.LSString) With {.Value = ""}))
        LSModuleInfo.Attributes.Add("CharacterCreationLevelName", (New LSLib.LS.NodeAttribute(AttributeType.FixedString) With {.Value = ""}))
        LSModuleInfo.Attributes.Add("Description", (New LSLib.LS.NodeAttribute(AttributeType.LSString) With {.Value = ""}))
        LSModuleInfo.Attributes.Add("Folder", (New LSLib.LS.NodeAttribute(AttributeType.LSString) With {.Value = ""}))
        LSModuleInfo.Attributes.Add("LobbyLevelName", (New LSLib.LS.NodeAttribute(AttributeType.FixedString) With {.Value = ""}))
        LSModuleInfo.Attributes.Add("MD5", (New LSLib.LS.NodeAttribute(AttributeType.LSString) With {.Value = ""}))
        LSModuleInfo.Attributes.Add("MainMenuBackgroundVideo", (New LSLib.LS.NodeAttribute(AttributeType.FixedString) With {.Value = ""}))
        LSModuleInfo.Attributes.Add("MenuLevelName", (New LSLib.LS.NodeAttribute(AttributeType.FixedString) With {.Value = ""}))
        LSModuleInfo.Attributes.Add("Name", (New LSLib.LS.NodeAttribute(AttributeType.LSString) With {.Value = ""}))
        LSModuleInfo.Attributes.Add("NumPlayers", (New LSLib.LS.NodeAttribute(AttributeType.UInt) With {.Value = "4"}))
        LSModuleInfo.Attributes.Add("PhotoBooth", (New LSLib.LS.NodeAttribute(AttributeType.FixedString) With {.Value = ""}))
        LSModuleInfo.Attributes.Add("StartupLevelName", (New LSLib.LS.NodeAttribute(AttributeType.FixedString) With {.Value = ""}))
        LSModuleInfo.Attributes.Add("Tags", (New LSLib.LS.NodeAttribute(AttributeType.LSString) With {.Value = ""}))
        LSModuleInfo.Attributes.Add("Type", (New LSLib.LS.NodeAttribute(AttributeType.FixedString) With {.Value = "Add-On"}))
        LSModuleInfo.Attributes.Add("UUID", (New LSLib.LS.NodeAttribute(AttributeType.FixedString) With {.Value = NewGUID(False)}))
        LSModuleInfo.Attributes.Add("Utam_Mod", (New LSLib.LS.NodeAttribute(AttributeType.Bool) With {.Value = "True"}))
        LSModuleInfo.Attributes.Add("Version64", (New LSLib.LS.NodeAttribute(AttributeType.Int64) With {.Value = "36028797018963968"}))
        LSModulePV = New LSLib.LS.Node With {.Name = "PublishVersion"}
        LSModulePV.Attributes.Add("Version64", (New LSLib.LS.NodeAttribute(AttributeType.Int64) With {.Value = "36028797018963968"}))
        LSModuleTM = New LSLib.LS.Node With {.Name = "TargetModes"}
        LSModuleInfo.AppendChild(LSModulePV)
        LSModuleInfo.AppendChild(LSModuleTM)
        LSModuleTM2 = New LSLib.LS.Node With {.Name = "Target"}
        LSModuleTM2.Attributes.Add("Object", (New LSLib.LS.NodeAttribute(AttributeType.FixedString) With {.Value = "Story"}))
        LSModuleTM.AppendChild(LSModuleTM2)
        Return MetaResource
    End Function

    Public Sub Update(ByRef MetaResource As LSLib.LS.Resource)
        Try
            Dim rec = MetaResource.Regions("Config").Children("ModuleInfo").First
            UUID = rec.Attributes("UUID").Value
            Name = rec.Attributes("Name").Value
            Folder = rec.Attributes("Folder").Value
            Author = rec.Attributes("Author").Value
            Version = rec.TryGetOrzero("Version64")
            Description = rec.Attributes("Description").Value
            MetaXMLZip = MetaResource.To_XML.ZippedString
            LoadOrderd = Main_GameEngine_Class.ModLoadOrder.IndexOf(UUID)
        Catch ex As Exception
            Debugger.Break()
        End Try

    End Sub

End Class


#End Region

#Region "LocalizationClasses"
<Serializable>
Public Class BG3_Loca_Localization_List_Class
    Inherits SortedList(Of String, BG3_Loca_Localization_Class)
    Public Function Localize(Mapkey As String, Language As Bg3_Enum_Languages, Gender As Bg3_Enum_Genders, Genderto As Bg3_Enum_GendersTo) As String
        Dim obj As BG3_Loca_Localization_Class = Nothing
        If Mapkey = "" Then Return ""
        If IsNothing(Mapkey) Then Return Mapkey
        If Mapkey.StartsWith("h"c) = False OrElse Mapkey.Contains(";"c) = False Then Return Nothing
        If Mapkey.Split(";")(0).Length <> 37 Then Return Nothing
        Dim version As Integer = Mapkey.Split(";")(1)
        Dim key As String = Mapkey.Split(";")(0)
        If TryGetValue(key, obj) = False Then Return Nothing
        If obj.Count = 0 Then Return Nothing
        If obj.ContainsKey(version) = False Then version = obj.OrderBy(Function(pf) Math.Abs(pf.Key - version)).Select(Function(pq) pq.Key).First

        If obj(version).ContainsKey(Language) Then
            If obj(version)(Language).ContainsKey(Gender) Then
                If obj(version)(Language)(Gender).ContainsKey(Genderto) Then
                    Return obj(version)(Language)(Gender)(Genderto)
                Else
                    If obj(version)(Language)(Gender).ContainsKey(Bg3_Enum_GendersTo.M_to_M) Then Return obj(version)(Language)(Gender)(Bg3_Enum_GendersTo.M_to_M)
                End If
            Else
                If obj(version)(Language)(Bg3_Enum_Genders.Male).ContainsKey(Genderto) Then Return obj(version)(Language)(Bg3_Enum_Genders.Male)(Genderto)
                If obj(version)(Language)(Bg3_Enum_Genders.Male).ContainsKey(Bg3_Enum_GendersTo.M_to_M) Then Return obj(version)(Language)(Bg3_Enum_Genders.Male)(Bg3_Enum_GendersTo.M_to_M)
            End If
        Else
            If obj(version).ContainsKey(0) Then
                If obj(version)(Bg3_Enum_Languages.English).ContainsKey(Gender) Then
                    If obj(version)(Bg3_Enum_Languages.English)(Gender).ContainsKey(Genderto) Then
                        Return obj(version)(Bg3_Enum_Languages.English)(Gender)(Genderto)
                    Else
                        If obj(version)(Bg3_Enum_Languages.English)(Gender).ContainsKey(Bg3_Enum_GendersTo.M_to_M) Then Return obj(version)(Bg3_Enum_Languages.English)(Gender)(Bg3_Enum_GendersTo.M_to_M)
                    End If
                Else
                    If obj(version)(Bg3_Enum_Languages.English)(Bg3_Enum_Genders.Male).ContainsKey(Genderto) Then Return obj(version)(Bg3_Enum_Languages.English)(Bg3_Enum_Genders.Male)(Genderto)
                    If obj(version)(Bg3_Enum_Languages.English)(Bg3_Enum_Genders.Male).ContainsKey(Bg3_Enum_GendersTo.M_to_M) Then Return obj(version)(Bg3_Enum_Languages.English)(Bg3_Enum_Genders.Male)(Bg3_Enum_GendersTo.M_to_M)
                End If
            End If
        End If

        Debugger.Break()
        Return Nothing
    End Function
    Public Function Key_Has_Language(Mapkey As String, Language As Bg3_Enum_Languages) As Boolean
        Dim obj As BG3_Loca_Localization_Class = Nothing
        If Mapkey = "" Then Return False
        If IsNothing(Mapkey) Then Return False
        If Mapkey.StartsWith("h"c) = False OrElse Mapkey.Contains(";"c) = False Then Return False
        If Mapkey.Split(";")(0).Length <> 37 Then Return False
        Dim version As Integer = Mapkey.Split(";")(1)
        Dim key As String = Mapkey.Split(";")(0)
        If TryGetValue(key, obj) = False Then Return False
        If obj.Count = 0 Then Return Nothing
        If obj.ContainsKey(version) = False Then version = obj.OrderBy(Function(pf) Math.Abs(pf.Key - version)).Select(Function(pq) pq.Key).First
        Return obj(version).ContainsKey(Language)
    End Function
    Public Function Localize(Mapkey As String, Gender As Bg3_Enum_Genders, Genderto As Bg3_Enum_GendersTo) As String
        Return Localize(Mapkey, GameEngine.Settings.SelectedLocalization, Gender, Genderto)
    End Function
    Public Function Localize(Mapkey As String, Language As Bg3_Enum_Languages, Gender As Bg3_Enum_Genders) As String
        Return Localize(Mapkey, Language, Gender, Bg3_Enum_GendersTo.M_to_M)
    End Function
    Public Function Localize(Mapkey As String, Gender As Bg3_Enum_Genders) As String
        Return Localize(Mapkey, GameEngine.Settings.SelectedLocalization, Gender, Bg3_Enum_GendersTo.M_to_M)
    End Function
    Public Function Localize(Mapkey As String, Language As Bg3_Enum_Languages) As String
        Return Localize(Mapkey, Language, Bg3_Enum_Genders.Male, Bg3_Enum_GendersTo.M_to_M)
    End Function
    Public Function Localize(Mapkey As String) As String
        Return Localize(Mapkey, GameEngine.Settings.SelectedLocalization, Bg3_Enum_Genders.Male, Bg3_Enum_GendersTo.M_to_M)
    End Function
    Public Function Localize(Handle As String, Version As UShort, Gender As Bg3_Enum_Genders, Genderto As Bg3_Enum_GendersTo) As String
        Return Localize(Handle + ";" + Version.ToString, Gender, Genderto)
    End Function
    Public Function Localize(Handle As String, Version As UShort, Language As Bg3_Enum_Languages, Gender As Bg3_Enum_Genders, Genderto As Bg3_Enum_GendersTo) As String
        Return Localize(Handle + ";" + Version.ToString, Language, Gender, Genderto)
    End Function
    Public Function Localize(Handle As String, Version As UShort, Language As Bg3_Enum_Languages, Gender As Bg3_Enum_Genders) As String
        Return Localize(Handle + ";" + Version.ToString, Language, Gender)
    End Function
    Public Function Localize(Handle As String, Version As UShort, Gender As Bg3_Enum_Genders) As String
        Return Localize(Handle + ";" + Version.ToString, Gender)
    End Function
    Public Function Localize(Handle As String, Version As UShort, Language As Bg3_Enum_Languages) As String
        Return Localize(Handle + ";" + Version.ToString, Language)
    End Function
    Public Function Localize(Handle As String, Version As UShort) As String
        Return Localize(Handle + ";" + Version.ToString)
    End Function


End Class

<Serializable>
Public Class BG3_Loca_Localization_Class
    Inherits SortedList(Of Integer, SortedList(Of String, SortedList(Of String, SortedList(Of String, String))))
    Public Property Handle As String = ""
    Public Property Version As UShort = 0


    Sub New()
    End Sub
    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.WhenWritingDefault)>
    Public Property SourceOfResorce As BG3_Pak_SourceOfResource_Class

    Public Sub New(Language As Bg3_Enum_Languages, Gender As Bg3_Enum_Genders, GendersTo As Bg3_Enum_GendersTo, ByRef Node As LSLib.LS.LocalizedText, ByRef Source As BG3_Pak_SourceOfResource_Class)
        SyncLock Me
            Me.Handle = Node.Key
            Me.Version = Node.Version
            Me.SourceOfResorce = Source
            AddSpecific(Node.Version, Language, Gender, GendersTo, Node.Text, Source)
        End SyncLock
    End Sub
    Public Sub New(Language As Bg3_Enum_Languages, Gender As Bg3_Enum_Genders, GendersTo As Bg3_Enum_GendersTo, ByRef Handle As String, Version As Integer, Text As String, ByRef Source As BG3_Pak_SourceOfResource_Class)
        SyncLock Me
            Me.Handle = Handle
            Me.Version = Version
            Me.SourceOfResorce = Source
            AddSpecific(Version, Language, Gender, GendersTo, Text, Source)
        End SyncLock
    End Sub


    Public Sub New(Language As Bg3_Enum_Languages, Gender As Bg3_Enum_Genders, ByRef Node As LSLib.LS.LocalizedText, ByRef Source As BG3_Pak_SourceOfResource_Class)
        Me.New(Language, Gender, Bg3_Enum_GendersTo.M_to_M, Node, Source)
    End Sub
    Public Sub New(Language As Bg3_Enum_Languages, ByRef Node As LSLib.LS.LocalizedText, ByRef Source As BG3_Pak_SourceOfResource_Class)
        Me.New(Language, Bg3_Enum_Genders.Male, Bg3_Enum_GendersTo.M_to_M, Node, Source)
    End Sub
    Public Sub New(ByRef Node As LSLib.LS.LocalizedText, ByRef Source As BG3_Pak_SourceOfResource_Class)
        Me.New(Bg3_Enum_Languages.English, Bg3_Enum_Genders.Male, Bg3_Enum_GendersTo.M_to_M, Node, Source)
    End Sub
    Public Sub AddSpecific(Version As Integer, Language As Bg3_Enum_Languages, Gender As Bg3_Enum_Genders, GendersTo As Bg3_Enum_GendersTo, ByRef Text As String, source As BG3_Pak_SourceOfResource_Class)
        SyncLock Me
            Me.SourceOfResorce = source
            If Me.ContainsKey(Version) = False Then
                Me.Add(Version, New SortedList(Of String, SortedList(Of String, SortedList(Of String, String))))
            End If
            If Me(Version).ContainsKey(Language) = False Then
                Me(Version).Add(Language, New SortedList(Of String, SortedList(Of String, String)))
            End If
            If Me(Version)(Language).ContainsKey(Gender) = False Then
                Me(Version)(Language).Add(Gender, New SortedList(Of String, String))
            End If
            If Me(Version)(Language)(Gender).ContainsKey(GendersTo) = False Then
                Me(Version)(Language)(Gender).Add(GendersTo, Text)
            End If
            Me(Version)(Language)(Gender)(GendersTo) = Text

        End SyncLock
    End Sub
End Class

#End Region


#Region "GameObjectClasses"

<Serializable>
Public Enum BG3_Enum_Templates_Type
    character
    decal
    item
    LevelTemplate
    light
    lightProbe
    prefab
    projectile
    scenery
    Spline
    SplineConstruction
    surface
    terrain
    TileConstruction
    trigger
    invalid_template
    fogVolume
    CombinedLight
    constellation
    constellationHelper
    Schematic
End Enum

<Serializable>
Public Class BG3_Obj_Template_Class
    Inherits BG3_Obj_Generic_Class
    Public Overloads ReadOnly Property Type As BG3_Enum_Templates_Type
        Get
            Return GameObjectsType_EnumNames.IndexOf(ReadAttribute_Or_Nothing("Type"))
        End Get
    End Property

    Public Overrides ReadOnly Property Name As String
        Get
            If IsOverrided = True Then
                If Me.SourceOfResorce.ModFolder = "Honour" Then
                    Return "(Honour " + OverrideNumber.ToString.PadLeft(4, "0") + ") " + ReadAttribute_Or_Nothing("Name")
                Else
                    Return "(Overrided " + OverrideNumber.ToString.PadLeft(4, "0") + ") " + ReadAttribute_Or_Nothing("Name")
                End If
            End If
            If Deleted Then
                Return "(Deleted) " + ReadAttribute_Or_Nothing("Name")
            End If
            Return ReadAttribute_Or_Nothing("Name")
        End Get
    End Property

    Public Overrides Sub Process_Parent_Change(NewParent As String)
        If NewParent = Me.MapKey Then Exit Sub
        FuncionesHelpers.GameEngine.ProcessedGameObjectList.RemoveHyerarchy(Me)
        Cached_Attributes.Remove("ParentTemplateId")
        Cached_Attributes.TryAdd("ParentTemplateId", NewParent)
        FuncionesHelpers.GameEngine.ProcessedGameObjectList.AddHyerarchy(Me)
    End Sub
    Public Overrides Sub Cancel_Edit()
        If Me.GetType = GetType(BG3_Obj_Template_Class) Then GameEngine.ProcessedGameObjectList.RemoveHyerarchy(Me)
        MyBase.Cancel_Edit()
        If Me.GetType = GetType(BG3_Obj_Template_Class) Then GameEngine.ProcessedGameObjectList.AddHyerarchy(Me)
    End Sub

    Public ReadOnly Property AssociatedStats As BG3_Obj_Stats_Class
        Get
            Dim st As String = ReadAttribute_Or_Empty("Stats")
            If st = "" Then Return ClonableStats
            Dim obj As BG3_Obj_Stats_Class = Nothing
            GameEngine.ProcessedStatList.TryGetValue(st, obj)
            Return obj
        End Get
    End Property
    Public ReadOnly Property ClonableStats As BG3_Obj_Stats_Class
        Get
            If CheckedStat(ReadAttribute_Or_Inhterithed_Or_Empty("Stats")) = "" Then Return Nothing
            Dim obj As BG3_Obj_Stats_Class = Nothing
            GameEngine.ProcessedStatList.TryGetValue(CheckedStat(""), obj)
            Return obj
        End Get
    End Property
    Private Function CheckedStat(recursive As String) As String
        Dim str = ReadAttribute_Or_Inhterithed_Or_Empty("Stats")
        If recursive = "" Then recursive = str
        Dim obj As BG3_Obj_Stats_Class = Nothing
        GameEngine.ProcessedStatList.TryGetValue(str, obj)
        If Not IsNothing(obj) AndAlso obj.Get_Data_Or_Inherited_or_Empty("RootTemplate") = Me.Mapkey_WithoutOverride Then Return str
        Dim count = GameEngine.ProcessedStatList.ElementValues.Where(Function(pf) pf.IsOverrided = False AndAlso pf.Get_Data_or_Empty("RootTemplate") = Me.Mapkey_WithoutOverride).Count
        If count > 0 Then Return GameEngine.ProcessedStatList.ElementValues.Where(Function(pf) pf.Get_Data_or_Empty("RootTemplate") = Me.Mapkey_WithoutOverride).Last.Mapkey_WithoutOverride
        If Not IsNothing(Parent) Then Return Parent.CheckedStat(recursive)
        Return recursive
    End Function



    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.Always)>
    Public Overrides ReadOnly Property ParentKey_Or_Empty As String
        Get
            If Me.IsOverrided Then
                If Me.MapKey = Mapkey_WithoutOverride Then Debugger.Break()
                Return Me.Mapkey_WithoutOverride
            End If
            Dim valor As String = ReadAttribute_Or_Nothing("ParentTemplateId")
            If Not IsNothing(valor) AndAlso valor <> Me.MapKey Then Return valor
            valor = ReadAttribute_Or_Nothing("TemplateName")
            If Not IsNothing(valor) AndAlso valor <> Me.MapKey Then Return valor
            Return ""
        End Get
    End Property

    Public Overloads ReadOnly Property Parent As BG3_Obj_Template_Class
        Get
            If Me.ParentKey_Or_Empty = "" Then Return Nothing
            Dim Value As BG3_Obj_Template_Class = Nothing
            If GameEngine.ProcessedGameObjectList.TryGetValue(Me.ParentKey_Or_Empty, Value) Then Return Value
            Return Nothing
        End Get
    End Property
    Public Overrides Function ReadAttribute_Or_Inhterithed(Attribuute As String) As String
        Dim value As String = ReadAttribute_Or_Nothing(Attribuute)
        Try
            If IsNothing(value) AndAlso Not IsNothing(Me.Parent) Then Return Me.Parent.ReadAttribute_Or_Inhterithed(Attribuute)
        Catch ex As Exception
            Return Nothing
        End Try
        Return value
    End Function
    Public Overrides Function ReadAttribute_Or_Inhterithed_Or_Empty(Attribuute As String) As String
        Dim str = ReadAttribute_Or_Inhterithed(Attribuute)
        If IsNothing(str) Then Return ""
        Return str
    End Function

    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.Always)>
    Public ReadOnly Property Icon As String
        Get
            Return ReadAttribute_Or_Inhterithed("Icon")
        End Get
    End Property


    Protected Overrides Sub Clear_Cached_Data()
        _CacheTagsIds = Nothing
        _CacheStatus = Nothing
        _cache_tags_txt = Nothing
        MyBase.Clear_Cached_Data()
    End Sub
    Public Overrides ReadOnly Property MapKey_Attribute As String = "MapKey"

    Private _cache_tags_txt As String = Nothing
    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.Always)>
    Public ReadOnly Property Get_Tags_TXT As String
        Get
            If Not IsNothing(_cache_tags_txt) Then Return _cache_tags_txt
            Dim Builder As New StringBuilder
            Dim tabs = 0
            Dim current = Me
            While Not IsNothing(current)
                For Each tag In current.GetTags_Ids
                    Dim taga As BG3_Obj_FlagsAndTags_Class = Nothing
                    If GameEngine.ProcessedFlagsAndTags.TryGetValue(tag, taga) = False Then
                        Builder.Append("".PadLeft(tabs, vbTab) + "Tagged" + ManoloSep + " " + "<Unknown>" + ManoloSep + ManoloSep + " (" + tag + ")" + vbCrLf)
                    Else
                        Builder.Append("".PadLeft(tabs, vbTab) + "Tagged" + ManoloSep + " '" + taga.Name + "'" + ManoloSep + ManoloSep + " (" + taga.DisplayName + ")" + vbCrLf)
                    End If
                Next
                current = current.Parent
                If Not IsNothing(current) Then
                    tabs += 1
                    Builder.Append("".PadLeft(tabs, vbTab) + "(inheriteds from " + ManoloSep + ManoloSep + " " + Chr(34) + current.Name + Chr(34) + ManoloSep + ")" + vbCrLf)
                End If
            End While
            _cache_tags_txt = Builder.ToString
            Return _cache_tags_txt
        End Get
    End Property



    Public Overrides Function Filter_Check_Level1(Level1 As Integer) As Boolean
        If Level1 = -1 Then Return True
        Return Level1 = Type
    End Function


    Sub New(ByRef Nod As LSLib.LS.Node, ByRef Source As BG3_Pak_SourceOfResource_Class)
        Create(Nod, Source)
    End Sub

    Public Overrides Sub Init_Necessary_Attributes()
        ReadAttribute_Or_Nothing("Icon")
        ReadAttribute_Or_Nothing("ParentTemplateId")
        ReadAttribute_Or_Nothing("TemplateName")
        ReadAttribute_Or_Nothing("DisplayName")
        ReadAttribute_Or_Nothing("Name")
        ReadAttribute_Or_Nothing("Stats")
        ReadAttribute_Or_Nothing("Type")
    End Sub

    Private _CacheTagsIds As List(Of String) = Nothing

    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.Always)>
    Public ReadOnly Property GetTags_Ids As List(Of String)
        Get
            If IsNothing(_CacheTagsIds) Then

                Dim value As List(Of LSLib.LS.Node) = Nothing
                If NodeLSLIB.Children.TryGetValue("Tags", value) Then
                    If value.Count = 0 Then
                        _CacheTagsIds = New List(Of String)
                    Else
                        Dim value2 As List(Of LSLib.LS.Node) = Nothing
                        If value.First.Children.TryGetValue("Tag", value2) Then
                            _CacheTagsIds = value2.Select(Function(Pf) Pf.TryGetOrEmpty("Object").ToString).ToList
                        Else
                            _CacheTagsIds = New List(Of String)
                        End If
                    End If
                Else
                    _CacheTagsIds = New List(Of String)
                End If
            End If

            Return _CacheTagsIds
        End Get
    End Property

    Private _CacheStatus As List(Of String) = Nothing

    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.Always)>
    Public ReadOnly Property GetStatus_Ids As List(Of String)
        Get
            If IsNothing(_CacheStatus) Then

                Dim value As List(Of LSLib.LS.Node) = Nothing
                If NodeLSLIB.Children.TryGetValue("StatusList", value) Then
                    If value.Count = 0 Then
                        _CacheStatus = New List(Of String)
                    Else
                        Dim value2 As List(Of LSLib.LS.Node) = Nothing
                        If value.First.Children.TryGetValue("Status", value2) Then
                            _CacheStatus = value2.Select(Function(Pf) Pf.TryGetOrEmpty("Object").ToString).ToList
                        Else
                            _CacheStatus = New List(Of String)
                        End If
                    End If
                Else
                    _CacheStatus = New List(Of String)
                End If
            End If

            Return _CacheStatus
        End Get
    End Property


    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.Always)>
    Public ReadOnly Property Is_Descendant(key As String)
        Get
            If IsNothing(key) OrElse key = "" Then Return False
            If Me.MapKey = key Then Return True
            If Not IsNothing(Me.Parent) Then Return Me.Parent.Is_Descendant(key)
            Return False
        End Get
    End Property

    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.Always)>
    Public Overrides ReadOnly Property DisplayName As String
        Get
            If IsNothing(ReadAttribute_Or_Inhterithed("DisplayName")) Then Return ""
            Return GameEngine.ProcessedLocalizationList.Localize(ReadAttribute_Or_Inhterithed("DisplayName"))
        End Get
    End Property
    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.Always)>
    Public Overrides ReadOnly Property DisplayName(Language As Bg3_Enum_Languages) As String
        Get
            If IsNothing(Me.ReadAttribute_Or_Inhterithed("DisplayName")) Then Return ""
            Return GameEngine.ProcessedLocalizationList.Localize(Me.ReadAttribute_Or_Inhterithed("DisplayName"), Language)
        End Get
    End Property



    '<Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.Always)>
    'Public ReadOnly Property GetDescriptionHandle_Or_Inherited As String
    '    Get
    '        If IsNothing(Me.DescriptionHandle) Then
    '            If Me.GetParentId_Or_TemplateName_Empty = "" Then Return Nothing
    '            If GameEngine.ProcessedGameObjectList.Containskey(Me.GetParentId_Or_TemplateName_Empty) = False Then Return Nothing
    '            Return GameEngine.ProcessedGameObjectList(Me.GetParentId_Or_TemplateName_Empty).GetDescriptionHandle_Or_Inherited
    '        End If
    '        Return Me.DescriptionHandle
    '    End Get
    'End Property



    Sub New()
        ' shouldnt

    End Sub
End Class

#End Region
#Region "TreasureTables"
<Serializable>
Public Class BG3_Obj_TreasureTable_TableItem_Class
    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.Never)>
    <JsonPropertyName("SI")>
    Public Property Item As String

    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.Never)>
    Public Property ConditionArray() As New List(Of Integer)
    Sub New()

    End Sub
    Sub New(linea As String)
        Dim it1 As String = linea.Substring(0, linea.IndexOf(","c) - 1).Replace(Chr(34), "")
        Dim it2 As String = linea.Substring(linea.IndexOf(","c) + 1)
        Me.Item = it1
        ConditionArray = ParseConditions(it2)
    End Sub
    Sub New(Item As String, Conditions As String)
        Me.Item = Item
        If Conditions.StartsWith(","c) Then Conditions = Conditions.Substring(1)
        ConditionArray = ParseConditions(Conditions)
    End Sub
    Public Function WriteDefinition() As String
        Dim st As New StringBuilder
        For x = 0 To ConditionArray.Count - 1
            st.Append(","c)
            st.Append(ConditionArray(x))
        Next
        Return st.ToString
    End Function
    Public Shared Function ParseConditions(conditiononly As String) As List(Of Integer)
        Dim arr As New List(Of Integer)
        For Each sp In conditiononly.Split(","c)
            arr.Add(CInt(sp))
        Next
        Return arr
    End Function
    Private _cachedef As String = Nothing
    Private _cacheIt As String = Nothing

    Protected Sub Clear_Cached_Data()
        _cachedef = Nothing
        _cacheIt = Nothing
    End Sub
    Public Sub Cancel_Edit()
        Me.Item = _cacheIt
        ConditionArray = ParseConditions(_cachedef)
    End Sub
    Public Sub Edit_start()
        _cacheIt = Item
        _cachedef = Me.WriteDefinition.Substring(1)
    End Sub

    Public Sub Write_Data()
        Clear_Cached_Data()
    End Sub

End Class

<Serializable>
Public Class BG3_Obj_TreasureTable_Subtable_Class
    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.Never)>
    Public Property Source As BG3_Pak_SourceOfResource_Class
    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.WhenWritingDefault)>
    <DefaultValue(0)>
    Public Property MaxLevel As String = ""
    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.WhenWritingDefault)>
    <DefaultValue(0)>
    Public Property MinLevel As String = ""
    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.Never)>
    <JsonPropertyName("SL")>
    Public Property Lista As New List(Of BG3_Obj_TreasureTable_TableItem_Class)
    Sub New()

    End Sub
    Sub New(source As BG3_Pak_SourceOfResource_Class, Definition As String)
        Me.Source = source
        Dim ret As Tuple(Of List(Of Integer), List(Of Integer))
        ret = Parsedefinitions(Definition)
        Counts = ret.Item1
        Chances = ret.Item2
        If Definition.Replace("; ", ";") <> WriteDefinition() Then
            Debugger.Break()
        End If
    End Sub
    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.Never)>
    Public Property Counts() As New List(Of Integer)
    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.Never)>
    Public Property Chances() As New List(Of Integer)

    Public Function WriteDefinition() As String
        Dim st As New StringBuilder
        For x = 0 To Counts.Count - 1
            If st.Length <> 0 Then st.Append(";"c)
            If Counts(x) < 0 Then
                st.Append(Counts(x))
            Else
                st.Append(Counts(x).ToString + "," + Chances(x).ToString)
            End If
        Next
        Return st.ToString
    End Function

    Public Shared Function Parsedefinitions(Definitions As String) As Tuple(Of List(Of Integer), List(Of Integer))
        Dim l1 As New List(Of Integer)
        Dim l2 As New List(Of Integer)
        Dim ret As Tuple(Of Integer, Integer)
        If Definitions.Contains(";"c) = False Then
            ret = Addcount(Definitions)
            l1.Add(ret.Item1)
            l2.Add(ret.Item2)
        Else
            Dim spl = Definitions.Split(";")
            For Each sp In spl
                ret = Addcount(sp)
                l1.Add(ret.Item1)
                l2.Add(ret.Item2)
            Next
        End If
        Return New Tuple(Of List(Of Integer), List(Of Integer))(l1, l2)
    End Function
    Private Shared Function Addcount(CountDefinition As String) As Tuple(Of Integer, Integer)
        Dim count As Integer
        Dim chance As Integer
        If CountDefinition.Contains(","c) = True Then
            count = CInt(CountDefinition.Split(",")(0))
            chance = CInt(CountDefinition.Split(",")(1))
        Else
            count = CInt(CountDefinition)
            chance = 1
        End If
        Return New Tuple(Of Integer, Integer)(count, chance)

    End Function
    Public ReadOnly Property HasItem(que As String, modsource As BG3_Pak_SourceOfResource_Class) As Boolean
        Get
            If IsNothing(modsource) Then Return Me.Lista.Where(Function(pq) pq.Item.Contains(que, StringComparison.OrdinalIgnoreCase)).Any
            If Me.Source.Pak_Or_Folder = modsource.Pak_Or_Folder Then Return Me.Lista.Where(Function(pq) pq.Item.Contains(que, StringComparison.OrdinalIgnoreCase)).Any
            Return False
        End Get
    End Property

    Private _CacheSubitems As New List(Of BG3_Obj_TreasureTable_TableItem_Class)
    Private _cachedef As String = Nothing
    Protected Sub Clear_Cached_Data()
        _CacheSubitems.Clear()
        _cachedef = Nothing
    End Sub
    Public Sub Cancel_Edit()
        Lista.Clear()
        _CacheSubitems.ToList.ForEach(Sub(pf) Lista.Add(pf))
        _CacheSubitems.ToList.ForEach(Sub(pf) pf.Cancel_Edit)
        Dim ret = Parsedefinitions(_cachedef)
        Counts = ret.Item1
        Chances = ret.Item2
    End Sub
    Public Sub Edit_start()
        _CacheSubitems.Clear()
        Lista.ToList.ForEach(Sub(pf) _CacheSubitems.Add(pf))
        Lista.ToList.ForEach(Sub(pf) pf.edit_Start)
        _cachedef = Me.WriteDefinition
    End Sub

    Public Sub Write_Data()
        Lista.ToList.ForEach(Sub(pf) pf.Write_Data())
        Clear_Cached_Data()
    End Sub

End Class
<Serializable>
Public Class BG3_Obj_TreasureTable_Class
    Inherits BG3_Obj_Generic_Class
    Public Property Name_Write As String = ""

    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.WhenWritingDefault)>
    <DefaultValue(False)>
    Public Property Merged As Boolean = False

    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.WhenWritingDefault)>
    Public Property MergedChilds As New List(Of Integer)

    Public Overrides ReadOnly Property Name As String
        Get
            If IsOverrided Then
                If Me.SourceOfResorce.ModFolder = "Honour" Then
                    Return "(Honour " + OverrideNumber.ToString.PadLeft(4, "0") + ") " + Name_Write
                Else
                    If Merged Then
                        Return "(Merged " + OverrideNumber.ToString.PadLeft(4, "0") + ") " + Name_Write
                    Else
                        Return "(Overrided " + OverrideNumber.ToString.PadLeft(4, "0") + ") " + Name_Write
                    End If
                End If
            End If
            If Deleted Then
                Return "(Deleted) " + Name_Write
            End If
            Return Name_Write
        End Get
    End Property

    Private Function Name_Write_ToMapkey() As String
        Dim valor As String = Name_Write
        If Type = BG3_Enum_StatType.ItemCombination Then valor = "IC:" + Name_Write
        If IsOverrided Then valor += "ov_" + OverrideNumber.ToString.PadLeft(4, "0")
        Return valor
    End Function
    Public Overloads ReadOnly Property Parent As BG3_Obj_TreasureTable_Class
        Get
            If Me.ParentKey_Or_Empty = "" Then Return Nothing
            If GameEngine.ProcessedTTables.Containskey(Me.ParentKey_Or_Empty) = False Then Return Nothing
            Return GameEngine.ProcessedTTables(Me.ParentKey_Or_Empty)
        End Get
    End Property
    Public Overrides ReadOnly Property MapKey As String
        Get
            Return Name_Write_ToMapkey()
        End Get
    End Property

    Private _CacheSubtables As New List(Of BG3_Obj_TreasureTable_Subtable_Class)
    Private _cache_TT_Name As String = ""
    Private _cache_CanMerge As Boolean = False
    Private _cache_Type As BG3_Enum_TreasureTables = BG3_Enum_TreasureTables.Alchemy

    Protected Overrides Sub Clear_Cached_Data()
        _CacheSubtables.Clear()
        _cache_TT_Name = Nothing
        _cache_Type = Nothing
        _cache_CanMerge = True
        MyBase.Clear_Cached_Data()
    End Sub
    Public Overrides Sub Cancel_Edit()
        GameEngine.ProcessedTTables.RemoveHyerarchy(Me)
        Subtables.Clear()
        _CacheSubtables.ToList.ForEach(Sub(pf) Subtables.Add(pf))
        _CacheSubtables.ToList.ForEach(Sub(pf) pf.Cancel_Edit())
        If _cache_TT_Name <> "" Then
            Me.CanMerge = _cache_CanMerge
            Me.Name_Write = _cache_TT_Name
            Me.Type = _cache_Type
        End If
        GameEngine.ProcessedTTables.AddHyerarchy(Me)
        MyBase.Cancel_Edit()
    End Sub
    Public Overrides Sub Edit_start()
        _CacheSubtables.Clear()
        Subtables.ToList.ForEach(Sub(pf) _CacheSubtables.Add(pf))
        Subtables.ToList.ForEach(Sub(pf) pf.Edit_start())
        _cache_CanMerge = Me.CanMerge
        _cache_TT_Name = Me.Name_Write
        _cache_Type = Me.Type
        MyBase.Edit_start()
    End Sub

    Public Overrides Sub Write_Data()
        _CacheSubtables.ToList.ForEach(Sub(pf) pf.Write_Data())
        Clear_Cached_Data()
    End Sub
    Public Sub Process_Name_Change(oldname As String, newname As String)
        If oldname = "" And newname = "" Then
            oldname = Me.Name_Write
            newname = Me.Name_Write
        End If
        Me.Name_Write = oldname
        FuncionesHelpers.GameEngine.UtamTreasures.Remove(Me)
        FuncionesHelpers.GameEngine.ProcessedTTables.RemoveHyerarchy(Me)
        FuncionesHelpers.GameEngine.ProcessedTTables.Elements.Remove(Me.MapKey)
        Dim lista As List(Of String) = Nothing
        Dim reprocesesar As New List(Of BG3_Obj_TreasureTable_Class)
        If Me.IsOverrided = False AndAlso FuncionesHelpers.GameEngine.ProcessedTTables.Hierarchy_Helper.TryGetValue(oldname, lista) Then
            Dim Orden As Integer = -1
            Dim sucesor As BG3_Obj_TreasureTable_Class = Nothing
            For Each child In lista
                If child.StartsWith(oldname + "ov_") Then
                    Dim candidato As BG3_Obj_TreasureTable_Class = Nothing
                    If FuncionesHelpers.GameEngine.ProcessedTTables.TryGetValue(child, candidato) Then
                        reprocesesar.Add(candidato)
                    End If
                End If
            Next
            If reprocesesar.Count > 0 Then
                For Each rep In reprocesesar.OrderBy(Function(pf) pf.OverrideNumber).ToList
                    FuncionesHelpers.GameEngine.ProcessedTTables.RemoveHyerarchy(rep)
                    FuncionesHelpers.GameEngine.ProcessedTTables.Elements.Remove(rep.MapKey)
                    rep.OverrideNumber = 0
                    rep.Type = Clasifica()
                    FuncionesHelpers.GameEngine.ProcessedTTables.Manage_Overrides(rep)
                Next
            End If
            reprocesesar = Nothing
        End If
        Me.Name_Write = newname
        Me.OverrideNumber = 0
        Me.Type = Clasifica()
        FuncionesHelpers.GameEngine.ProcessedTTables.Manage_Overrides(Me)
    End Sub

    Public Overrides ReadOnly Property ParentKey_Or_Empty As String
        Get
            If Me.IsOverrided Then
                If Me.Name_Write_ToMapkey = Mapkey_WithoutOverride Then Debugger.Break()
                Return Me.Mapkey_WithoutOverride
            End If
            Return ""
        End Get
    End Property
    Public Overrides ReadOnly Property Mapkey_WithoutOverride
        Get
            If Me.IsOverrided = False Then Return MapKey
            Return Name_Write_ToMapkey.Remove(Name_Write_ToMapkey.IndexOf("ov_"), 7)
        End Get
    End Property

    Public ReadOnly Property HasItem(que As String, ModSource As BG3_Pak_SourceOfResource_Class) As Boolean
        Get
            If IsNothing(ModSource) Then Return Me.Subtables.Where(Function(pq) pq.HasItem(que, Nothing)).Any
            Return Me.Subtables.Where(Function(pq) pq.HasItem(que, ModSource)).Any
        End Get
    End Property

    Private Function Clasifica() As BG3_Enum_TreasureTables
        Dim prf As String = ""
        If Name.Length > 0 AndAlso Name.IndexOf("_"c, 1) <> -1 Then
            prf = Name.Substring(0, Name.IndexOf("_"c, 1))
            If prf.StartsWith("_"c) Then prf = prf.Substring(1)
        Else
            If Name.StartsWith("_"c) Then prf = Name.Substring(1)
        End If

        Select Case prf
            Case "Alchemy", "AlchemistTrader"
                Return BG3_Enum_TreasureTables.Alchemy
            Case "BGO"
                Return BG3_Enum_TreasureTables.BGO
            Case "BG"
                Return BG3_Enum_TreasureTables.BG
            Case "CHA"
                Return BG3_Enum_TreasureTables.CHA
            Case "Clothes"
                Return BG3_Enum_TreasureTables.Clothes
            Case "COL"
                Return BG3_Enum_TreasureTables.COL
            Case "CRA"
                Return BG3_Enum_TreasureTables.CRA
            Case "CRE"
                Return BG3_Enum_TreasureTables.CRE
            Case "DEN"
                Return BG3_Enum_TreasureTables.DEN
            Case "DLC"
                Return BG3_Enum_TreasureTables.DLC
            Case "END"
                Return BG3_Enum_TreasureTables.END
            Case "Equipment", "EquipmentTrader"
                Return BG3_Enum_TreasureTables.Equipment
            Case "Exploration"
                Return BG3_Enum_TreasureTables.Exploration
            Case "FOR"
                Return BG3_Enum_TreasureTables.FOR
            Case "GEN"
                Return BG3_Enum_TreasureTables.GEN
            Case "GOB"
                Return BG3_Enum_TreasureTables.GOB
            Case "Gold"
                Return BG3_Enum_TreasureTables.Gold
            Case "HAG"
                Return BG3_Enum_TreasureTables.HAG
            Case "HAV"
                Return BG3_Enum_TreasureTables.HAV
            Case "INT"
                Return BG3_Enum_TreasureTables.INT
            Case "Kitchen"
                Return BG3_Enum_TreasureTables.Kitchen
            Case "LOW"
                Return BG3_Enum_TreasureTables.LOW
            Case "MetalBars"
                Return BG3_Enum_TreasureTables.MetalBars
            Case "Monster"
                Return BG3_Enum_TreasureTables.Monster
            Case "MOO"
                Return BG3_Enum_TreasureTables.MOO
            Case "ORI"
                Return BG3_Enum_TreasureTables.ORI
            Case "PLA"
                Return BG3_Enum_TreasureTables.PLA
            Case "SCL", "SCl"
                Return BG3_Enum_TreasureTables.SCL
            Case "SHA"
                Return BG3_Enum_TreasureTables.SHA
            Case "ST"
                Return BG3_Enum_TreasureTables.ST
            Case "Supplies", "Supply", "SUPPLY"
                Return BG3_Enum_TreasureTables.Supplies
            Case "TEST"
                Return BG3_Enum_TreasureTables.TEST
            Case "TUT"
                Return BG3_Enum_TreasureTables.TUT
            Case "TWN"
                Return BG3_Enum_TreasureTables.TWN
            Case "UND"
                Return BG3_Enum_TreasureTables.UND
            Case "Valuables", "Valuablues", "Valubles"
                Return BG3_Enum_TreasureTables.Valuables
            Case "WLD"
                Return BG3_Enum_TreasureTables.WLD
            Case "WYR"
                Return BG3_Enum_TreasureTables.WYR
            Case "UTAM"
                Return BG3_Enum_TreasureTables.UTAM
            Case Else
                Return BG3_Enum_TreasureTables.Others
        End Select
    End Function
    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.Always)>
    Public Overrides ReadOnly Property DisplayName As String
        Get
            Return Name_Write
        End Get
    End Property
    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.WhenWritingDefault)>
    <DefaultValue(BG3_Enum_TreasureTables.Others)>
    Public Overloads Property [Type] As BG3_Enum_TreasureTables = BG3_Enum_TreasureTables.Others

    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.Never)>
    <JsonPropertyName("ST")>
    Public Property Subtables As New List(Of BG3_Obj_TreasureTable_Subtable_Class)

    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.WhenWritingDefault)>
    <DefaultValue(False)>
    Public Property CanMerge As Boolean = False

    Public Overrides ReadOnly Property MapKey_Attribute As String = "Name"

    Public Overrides Function Filter_Check_Level1(Level1 As Integer) As Boolean
        If Level1 = -1 Then Return True
        Return Level1 = Type
    End Function
    Public Overrides Function Filter_Check_Text(Texto As String, deep As Boolean) As Boolean
        If Texto = "" Then Return True
        If deep Then
            If Get_txt.Contains(Texto, StringComparison.OrdinalIgnoreCase) Then Return True
        End If
        Return MyBase.Filter_Check_Text(Texto, deep)
    End Function

    Sub New(ByRef Source As BG3_Pak_SourceOfResource_Class, name As String)
        Me.SourceOfResorce = Source
        Name_Write = name
        Me.Type = Clasifica()
    End Sub
    Sub New()
    End Sub


    Public Function Get_txt() As String
        Dim Builder As New StringBuilder
        Dim tabs = 0
        Dim current = Me
        Builder.Append("".PadLeft(tabs, vbTab) + "new treasuretable" + ManoloSep + " " + Chr(34) + current.Name + Chr(34) + ManoloSep + vbCrLf)
        If CanMerge Then
            Builder.Append("".PadLeft(tabs, vbTab) + "CanMerge" + ManoloSep + " 1" + ManoloSep + vbCrLf)
        End If
        tabs += 1
        For Each st In Me.Subtables
            Builder.Append("".PadLeft(tabs, vbTab) + "new subtable" + ManoloSep + " " + ManoloSep + Chr(34) + st.WriteDefinition + Chr(34) + vbCrLf)
            If st.MinLevel <> "" Then Builder.Append("".PadLeft(tabs, vbTab) + "StartLevel" + ManoloSep + " " + Chr(34) + st.MinLevel + Chr(34) + ManoloSep + vbCrLf)
            If st.MaxLevel <> "" Then Builder.Append("".PadLeft(tabs, vbTab) + "EndLevel" + ManoloSep + " " + Chr(34) + st.MaxLevel + Chr(34) + ManoloSep + vbCrLf)
            tabs += 1
            For Each it In st.Lista

                Builder.Append("".PadLeft(tabs, vbTab) + "object category" + ManoloSep + " " + Chr(34) + it.Item + Chr(34) + ManoloSep + it.WriteDefinition + vbCrLf)
            Next
            tabs += -1
        Next
        Return Builder.ToString
    End Function
    Public Overrides Sub Init_Necessary_Attributes()
        Throw New NotImplementedException()
    End Sub
End Class
#End Region

#Region "StatClasses"

<Serializable>
Public Class BG3_Obj_Stats_Class
    Inherits BG3_Obj_Generic_Class
    Public Property Name_Write As String = ""


    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.Never)>
    Public Property Itemresult As BG3_Obj_Stats_Class = Nothing


    Public Overrides ReadOnly Property Name As String
        Get
            If IsOverrided Then
                If Me.SourceOfResorce.ModFolder = "Honour" Then
                    Return "(Honour " + OverrideNumber.ToString.PadLeft(4, "0") + ") " + Name_Write
                Else
                    Return "(Overrided " + OverrideNumber.ToString.PadLeft(4, "0") + ") " + Name_Write
                End If
            End If
            If Deleted Then
                Return "(Deleted) " + Name_Write
            End If
            Return Name_Write
        End Get
    End Property

    Private Function Name_Write_ToMapkey() As String
        Dim valor As String = Name_Write
        If Type = BG3_Enum_StatType.ItemCombination Then valor = "IC:" + Name_Write
        If IsOverrided Then valor += "ov_" + OverrideNumber.ToString.PadLeft(4, "0")
        Return valor
    End Function

    Public Overrides ReadOnly Property MapKey As String
        Get
            Return Name_Write_ToMapkey()
        End Get
    End Property
    Public Overrides ReadOnly Property ParentKey_Or_Empty As String
        Get
            If Me.IsOverrided Then
                If Me.Name_Write_ToMapkey = Mapkey_WithoutOverride Then Debugger.Break()
                Return Me.Mapkey_WithoutOverride
            End If
            If Me.Using <> Me.MapKey Then Return [Using]
            Return ""
        End Get
    End Property
    Public Overrides ReadOnly Property Mapkey_WithoutOverride
        Get
            If Me.IsOverrided = False Then Return MapKey
            Return Name_Write_ToMapkey.Remove(Name_Write_ToMapkey.IndexOf("ov_"), 7)
        End Get
    End Property

    Public Overloads ReadOnly Property Parent As BG3_Obj_Stats_Class
        Get
            If Me.ParentKey_Or_Empty = "" Then Return Nothing
            If GameEngine.ProcessedStatList.Containskey(Me.ParentKey_Or_Empty) = False Then Return Nothing
            Return GameEngine.ProcessedStatList(Me.ParentKey_Or_Empty)
        End Get
    End Property
    Public ReadOnly Property AssociatedTemplate As BG3_Obj_Template_Class
        Get
            Dim objs As String = Get_Data_Or_Inherited("RootTemplate")
            If IsNothing(objs) OrElse objs = "" Then Return Nothing
            Dim obj As BG3_Obj_Template_Class = Nothing
            GameEngine.ProcessedGameObjectList.TryGetValue(objs, obj)
            Return obj
        End Get
    End Property
    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.Always)>
    Public ReadOnly Property Is_Descendant(key As String)
        Get
            If IsNothing(key) OrElse key = "" Then Return False
            If Me.Name = key Then Return True
            If Not IsNothing(Me.Parent) Then Return Me.Parent.Is_Descendant(key)
            Return False
        End Get
    End Property
    Public Overrides Sub Process_Parent_Change(NewParent As String)
        If NewParent = Me.MapKey Then Exit Sub
        FuncionesHelpers.GameEngine.ProcessedStatList.RemoveHyerarchy(Me)
        [Using] = NewParent
        FuncionesHelpers.GameEngine.ProcessedStatList.AddHyerarchy(Me)
    End Sub

    Public Sub Process_Name_Change(oldname As String, newname As String)
        Me.Name_Write = oldname
        FuncionesHelpers.GameEngine.Utamstats.Remove(Me)
        FuncionesHelpers.GameEngine.ProcessedStatList.RemoveHyerarchy(Me)
        FuncionesHelpers.GameEngine.ProcessedStatList.Elements.Remove(Me.MapKey)
        Dim lista As List(Of String) = Nothing
        Dim reprocesesar As New List(Of BG3_Obj_Stats_Class)
        If Me.IsOverrided = False AndAlso FuncionesHelpers.GameEngine.ProcessedStatList.Hierarchy_Helper.TryGetValue(oldname, lista) Then
            Dim Orden As Integer = -1
            Dim sucesor As BG3_Obj_Stats_Class = Nothing
            For Each child In lista
                If child.StartsWith(oldname + "ov_") Then
                    Dim candidato As BG3_Obj_Stats_Class = Nothing
                    If FuncionesHelpers.GameEngine.ProcessedStatList.TryGetValue(child, candidato) Then
                        reprocesesar.Add(candidato)
                    End If
                End If
            Next
            If reprocesesar.Count > 0 Then
                For Each rep In reprocesesar.OrderBy(Function(pf) pf.OverrideNumber).ToList
                    FuncionesHelpers.GameEngine.ProcessedStatList.RemoveHyerarchy(rep)
                    FuncionesHelpers.GameEngine.ProcessedStatList.Elements.Remove(rep.MapKey)
                    rep.OverrideNumber = 0
                    FuncionesHelpers.GameEngine.ProcessedStatList.Manage_Overrides(rep)
                Next
            End If
            reprocesesar = Nothing
        End If

        'For Each child In lista
        '    If child.StartsWith(oldname + "ov_") Then
        '        Dim candidato As BG3_Obj_Stats_Class = Nothing
        '        If FuncionesHelpers.GameEngine.ProcessedStatList.TryGetValue(child, candidato) Then
        '            If candidato.OverrideNumber > Orden Then sucesor = candidato
        '            Orden = candidato.OverrideNumber
        '        End If
        '    End If
        'Next
        'If Not IsNothing(sucesor) Then
        '    FuncionesHelpers.GameEngine.ProcessedStatList.RemoveHyerarchy(sucesor)
        '    FuncionesHelpers.GameEngine.ProcessedStatList.Elements.Remove(sucesor.MapKey)
        '    sucesor.OverrideNumber = 0
        '    FuncionesHelpers.GameEngine.ProcessedStatList.Elements.Remove(sucesor.MapKey)
        '    FuncionesHelpers.GameEngine.ProcessedStatList.Manage_Overrides(sucesor)

        'End If
        Me.Name_Write = newname
        Me.OverrideNumber = 0
        FuncionesHelpers.GameEngine.ProcessedStatList.Manage_Overrides(Me)
    End Sub

    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.Always)>
    Public Overrides ReadOnly Property DisplayName As String
        Get
            If Get_Data_Or_Inherited_or_Empty("DisplayName") = "" Then
                If IsNothing(Me.AssociatedTemplate) Then Return ""
                Return Me.AssociatedTemplate.DisplayName
            End If
            Return GameEngine.ProcessedLocalizationList.Localize(Get_Data_Or_Inherited_or_Empty("DisplayName"))
        End Get
    End Property

    Public Property [Using] As String = ""
    Public Overloads Property [Type] As BG3_Enum_StatType
    Public Property Data As New SortedList(Of String, String)

    Private ReadOnly _Cache_Data As New SortedList(Of String, String)
    Private _Cache_Using As String
    Private _Cache_Stat_Name As String
    Private _Cache_Type As BG3_Enum_StatType

    Public Overrides ReadOnly Property MapKey_Attribute As String = "Name"
    Public Overrides Function Filter_Check_Level1(Level1 As Integer) As Boolean
        If Level1 = -1 Then Return True
        Return Level1 = Type
    End Function
    Public Overrides Function Filter_Check_Text(Texto As String, deep As Boolean) As Boolean
        If Texto = "" Then Return True
        If Not IsNothing([Using]) AndAlso [Using].Contains(Texto, StringComparison.OrdinalIgnoreCase) Then Return True
        If deep Then
            If Me.SourceOfResorce.Pak_Or_Folder.Contains(Texto, StringComparison.OrdinalIgnoreCase) Or Me.SourceOfResorce.Filename_Relative.Contains(Texto, StringComparison.OrdinalIgnoreCase) Then Return True
            Dim Builder As New StringBuilder
            Dim tabs = 0
            Get_txt_Single(Me, Builder, tabs, False)
            If Builder.ToString.Replace(ManoloSep, "").Contains(Texto, StringComparison.OrdinalIgnoreCase) Then Return True
        End If
        Return MyBase.Filter_Check_Text(Texto, deep)
    End Function

    Sub New(ByRef Source As BG3_Pak_SourceOfResource_Class, name As String)
        Me.SourceOfResorce = Source
        Me.Name_Write = name
    End Sub
    Sub New()

    End Sub

    Public ReadOnly Property Get_Data_Or_Inherited(key As String) As String
        Get
            Dim value As String = Nothing
            If Data.TryGetValue(key, value) Then Return value
            If Me.Type <> BG3_Enum_StatType.ConfigKeys Then
                If IsNothing(Parent) Then Return Nothing
                Return Parent.Get_Data_Or_Inherited(key)
            Else
                For Each x In OverridedKeys
                    If x.Data.TryGetValue(key, value) Then Return value
                Next
            End If
            Return Nothing
        End Get
    End Property


    Private ReadOnly Property OverridedKeys As List(Of BG3_Obj_Stats_Class)
        Get
            Dim lista As List(Of String) = Nothing
            Dim overridedlist As New List(Of BG3_Obj_Stats_Class)
            If FuncionesHelpers.GameEngine.ProcessedStatList.Hierarchy_Helper.TryGetValue(Me.MapKey, lista) Then
                Dim obj As BG3_Obj_Stats_Class = Nothing
                For Each li In lista
                    If FuncionesHelpers.GameEngine.ProcessedStatList.TryGetValue(li, obj) Then
                        overridedlist.Add(obj)
                    End If
                Next
                Return overridedlist.OrderByDescending(Function(pf) pf.OverrideNumber).ToList
            End If
            Return overridedlist
        End Get
    End Property



    Public ReadOnly Property Get_Data_Or_Inherited_or_Empty(key As String) As String
        Get
            Dim value As String = Get_Data_Or_Inherited(key)
            If IsNothing(value) Then Return ""
            Return value
        End Get
    End Property
    Public ReadOnly Property Get_Data_or_Empty(key As String) As String
        Get
            Dim value As String = Nothing
            If Data.TryGetValue(key, value) Then Return value
            Return ""
        End Get
    End Property

    Private ReadOnly OverridesData = New List(Of String)
    Private cache_TXT As String = Nothing

    Protected Overrides Sub Clear_Cached_Data()
        cache_TXT = Nothing
        _Cache_Data.Clear()
        _Cache_Using = Nothing
        _Cache_Stat_Name = Nothing
        _Cache_Type = Nothing
        MyBase.Clear_Cached_Data()
    End Sub
    Public Overrides Sub Cancel_Edit()
        GameEngine.ProcessedStatList.RemoveHyerarchy(Me)
        Data.Clear()
        _Cache_Data.ToList.ForEach(Function(pf) Data.TryAdd(pf.Key, pf.Value))
        If _Cache_Stat_Name <> "" Then
            Me.Using = _Cache_Using
            Me.Name_Write = _Cache_Stat_Name
            Me.Type = _Cache_Type
        End If
        GameEngine.ProcessedStatList.AddHyerarchy(Me)
        MyBase.Cancel_Edit()
    End Sub
    Public Overrides Sub Edit_start()
        _Cache_Data.Clear()
        Data.ToList.ForEach(Function(pf) _Cache_Data.TryAdd(pf.Key, pf.Value))
        _Cache_Using = Me.Using
        _Cache_Stat_Name = Me.Name_Write
        _Cache_Type = Me.Type
        MyBase.Edit_start()
    End Sub

    Public Overrides Sub Write_Data()
        Clear_Cached_Data()
    End Sub

    Public Function Get_TXT(source As BG3_Obj_SortedList_Class(Of BG3_Obj_Stats_Class)) As String
        If Not IsNothing(cache_TXT) Then Return cache_TXT
        OverridesData.clear
        If Me.Type = BG3_Enum_StatType.ItemCombination Then Return Get_TXT_ItemCombination(source)
        Dim Builder As New StringBuilder
        Dim tabs = 0
        Dim current = Me
        Builder.Append("".PadLeft(tabs, vbTab) + "new entry" + ManoloSep + " " + ManoloSep + Chr(34) + current.Name + Chr(34) + vbCrLf)
        Builder.Append("".PadLeft(tabs, vbTab) + "using" + ManoloSep + " " + ManoloSep + Chr(34) + current.[Using] + Chr(34) + vbCrLf)
        Builder.Append("".PadLeft(tabs, vbTab) + "type" + ManoloSep + " " + ManoloSep + Chr(34) + [Enum].GetName(GetType(BG3_Enum_StatType), [Type]) + Chr(34) + vbCrLf)
        Get_txt_Single(current, Builder, tabs, True)
        Dim lastusing
        While current.Using <> ""
            lastusing = current.Using
            If source.TryGetValue(current.[Using], current) = False OrElse lastusing = current.Using Then
                Debugger.Break()
                Exit While
            End If
            tabs += 1
            Builder.Append("".PadLeft(tabs, vbTab) + "(inheriteds from" + ManoloSep + " ")
            If current.Type <> -1 Then Builder.Append(Chr(34) + [Enum].GetName(GetType(BG3_Enum_StatType), current.[Type]) + Chr(34) + " ")
            Builder.Append(ManoloSep + Chr(34) + current.Name + Chr(34))
            Builder.Append(ManoloSep + ")" + vbCrLf)
            Get_txt_Single(current, Builder, tabs, True)
        End While
        cache_TXT = Builder.ToString
        Return cache_TXT
    End Function
    Public Function Get_TXT_ItemCombination(source As BG3_Obj_SortedList_Class(Of BG3_Obj_Stats_Class)) As String
        Dim Builder As New StringBuilder
        Dim tabs = 0
        Dim current = Me
        Dim lastusing
        lastusing = current.Using
        If current.Using <> "" Then
            If source.TryGetValue(current.[Using], current) = False OrElse lastusing = current.Using Then
                Debugger.Break()
            End If
        End If

        Builder.Append("".PadLeft(tabs, vbTab) + "new ItemCombination" + ManoloSep + " " + ManoloSep + Chr(34) + current.Name + Chr(34) + vbCrLf)
        Dim x As Integer = 1
        While current.Data.ContainsKey("Object " + x.ToString) = True
            If current.Data.ContainsKey("Type " + x.ToString) Then
                Builder.Append("data " + ManoloSep + Chr(34) + "Type " + x.ToString + Chr(34) + " " + ManoloSep + Chr(34) + current.Data("Type " + x.ToString) + Chr(34) + vbCrLf)
            End If
            If current.Data.ContainsKey("Object " + x.ToString) Then
                Builder.Append("data " + ManoloSep + Chr(34) + "Object " + x.ToString + Chr(34) + " " + ManoloSep + Chr(34) + current.Data("Object " + x.ToString) + Chr(34) + vbCrLf)
            End If
            If current.Data.ContainsKey("Combine " + x.ToString) Then
                Builder.Append("data " + ManoloSep + Chr(34) + "Combine " + x.ToString + Chr(34) + " " + ManoloSep + Chr(34) + current.Data("Combine " + x.ToString) + Chr(34) + vbCrLf)
            End If
            If current.Data.ContainsKey("Transform " + x.ToString) Then
                Builder.Append("data " + ManoloSep + Chr(34) + "Transform " + x.ToString + Chr(34) + " " + ManoloSep + Chr(34) + current.Data("Transform " + x.ToString) + Chr(34) + vbCrLf)
            End If
            For Each dat In current.Data.Keys.Where(Function(pf) pf.EndsWith(" " + x.ToString))
                If dat.StartsWith("Type ") = False And dat.StartsWith("Object ") = False And dat.StartsWith("Combine ") = False And dat.StartsWith("Transform ") = False Then
                    Debugger.Break()
                End If
            Next
            x += 1
        End While

        For Each dat In current.Data.Keys.Where(Function(pf) pf.StartsWith("Type ") = False And pf.StartsWith("Object ") = False And pf.StartsWith("Combine ") = False And pf.StartsWith("Transform ") = False)
            Builder.Append("data " + ManoloSep + Chr(34) + dat + Chr(34) + " " + ManoloSep + Chr(34) + current.Data(dat) + Chr(34) + vbCrLf)
        Next

        current = Me.Itemresult

        If Not IsNothing(current) Then
            x = 1
            Builder.Append("".PadLeft(tabs, vbTab) + vbCrLf)
            Builder.Append("".PadLeft(tabs, vbTab) + "new ItemCombinationResult" + ManoloSep + " " + ManoloSep + Chr(34) + current.Name + Chr(34) + vbCrLf)

            While current.Data.ContainsKey("Result " + x.ToString) = True Or current.Data.ContainsKey("ResultAmount " + x.ToString) = True
                If current.Data.ContainsKey("ResultAmount " + x.ToString) Then
                    Builder.Append("".PadLeft(tabs, vbTab) + "data " + ManoloSep + Chr(34) + "ResultAmount " + x.ToString + Chr(34) + " " + ManoloSep + Chr(34) + current.Data("ResultAmount " + x.ToString) + Chr(34) + vbCrLf)
                End If
                If current.Data.ContainsKey("Result " + x.ToString) Then
                    Builder.Append("".PadLeft(tabs, vbTab) + "data " + ManoloSep + Chr(34) + "Result " + x.ToString + Chr(34) + " " + ManoloSep + Chr(34) + current.Data("Result " + x.ToString) + Chr(34) + vbCrLf)
                End If
                x += 1
            End While
            For Each dat In current.Data.Keys.Where(Function(pf) pf.StartsWith("ResultAmount ") = False And pf.StartsWith("Result ") = False)
                Builder.Append("".PadLeft(tabs, vbTab) + "data " + ManoloSep + Chr(34) + dat + Chr(34) + " " + ManoloSep + Chr(34) + current.Data(dat) + Chr(34) + vbCrLf)
            Next
        End If
        cache_TXT = Builder.ToString
        Return cache_TXT
    End Function
    Private Sub Get_txt_Single(ByRef current As BG3_Obj_Stats_Class, ByRef builder As StringBuilder, ByRef tabs As Integer, UseOverride As Boolean)
        Dim override As Boolean = False
        For Each d In current.Data
            If UseOverride = True AndAlso OverridesData.Contains(d.Key) Then override = True
            If override Then builder.Append("".PadLeft(tabs, vbTab) + "(Overrided) ") Else builder.Append("".PadLeft(tabs, vbTab))
            builder.Append("data " + ManoloSep + Chr(34) + d.Key + Chr(34) + " " + ManoloSep + Chr(34) + d.Value + Chr(34) + vbCrLf)
            If UseOverride = True AndAlso override = False Then OverridesData.Add(d.Key)
            override = False
        Next
    End Sub

    Public Overrides Sub Init_Necessary_Attributes()
        Throw New NotImplementedException()
    End Sub
End Class


<Serializable>
Public Enum BG3_Enum_StatType
    Armor
    Character
    [Object]
    PassiveData
    SpellData
    StatusData
    Weapon
    Unused
    CriticalHitTypeData
    CriticalHitTypes
    InterruptData
    ItemCombination
    ConfigKeys
End Enum
Public Enum BG3_Enum_TreasureTables
    Alchemy
    BG
    BGO
    CHA
    Clothes
    COL
    CRA
    CRE
    DEN
    DLC
    [END]
    Equipment
    Exploration
    [FOR]
    GEN
    GOB
    Gold
    HAG
    HAV
    INT
    Kitchen
    LOW
    MetalBars
    Monster
    MOO
    ORI
    PLA
    SCL
    SHA
    ST
    Supplies
    TEST
    TUT
    TWN
    UND
    Valuables
    WLD
    WYR
    Others
    UTAM
End Enum

#End Region

#Region "VisualBanks"
Public Enum BG3_Enum_VisualBank_Type
    CharacterVisualBank
    VisualBank
    MaterialBank
    TextureBank
    MaterialPresetBank
    MaterialShader
    VirtualTextureBank
    EffectsBank
End Enum
Public Enum BG3_Enum_Icon_Type
    Items
    Portraits
    Others_Files
    CharacterCreation
    Others_Atlas
End Enum
Public Enum BG3_Enum_UTAM_Type
    Container
    Dyes
    Armor
    Weapon
    Consumable
    Tag
    Texture
    MaterialBank
    VisualBank
    ActionResource
    Status
    Passives
    Spells
    Interrupt
    Book
    GenericItem
    Scrolls
    Arrows
    CharacterBank
    Character
    Treasure
    ItemCombo
End Enum

<Serializable>
Public Class BG3_Obj_VisualBank_Class
    Inherits BG3_Obj_Generic_Class
    Public Overrides ReadOnly Property MapKey_Attribute As String = "ID"
    Public Overrides ReadOnly Property Name As String
        Get
            If IsOverrided = True Then
                If Me.SourceOfResorce.ModFolder = "Honour" Then
                    Return "(Honour " + OverrideNumber.ToString.PadLeft(4, "0") + ") " + ReadAttribute_Or_Nothing("Name")
                Else
                    Return "(Overrided " + OverrideNumber.ToString.PadLeft(4, "0") + ") " + ReadAttribute_Or_Nothing("Name")
                End If
            End If
            If Deleted Then
                Return "(Deleted) " + ReadAttribute_Or_Nothing("Name")
            End If
            Return ReadAttribute_Or_Nothing("Name")
        End Get
    End Property
    Public Overrides ReadOnly Property DisplayName As String
        Get
            Return MapKey
        End Get
    End Property
    Public Overrides ReadOnly Property ParentKey_Or_Empty As String
        Get
            If Me.IsOverrided Then Return Me.Mapkey_WithoutOverride
            Return MyBase.ParentKey_Or_Empty
        End Get
    End Property

    Public ReadOnly Property VisualAsset As BG3_Obj_Assets_Class
        Get
            If AssetName = "" Then Return Nothing
            Return BG3_Pak_Packages_List_Class.Find_Asset("", AssetName)
        End Get
    End Property


    Public ReadOnly Property AssetName As String
        Get
            Select Case Type
                Case BG3_Enum_VisualBank_Type.TextureBank
                    Return ReadAttribute_Or_Empty("SourceFile")
                Case BG3_Enum_VisualBank_Type.VisualBank
                    Return ReadAttribute_Or_Empty("SourceFile")
                Case BG3_Enum_VisualBank_Type.MaterialShader
                    Return MapKey
                Case BG3_Enum_VisualBank_Type.VirtualTextureBank
                    Dim gtex As String = ReadAttribute_Or_Empty("GTexFileName")
                    If gtex = "" Then Return gtex
                    Return "Generated/Public/VirtualTextures/Albedo_Normal_Physical_" + gtex.Substring(0, 1) + "_" + gtex + ".gtp"
                Case Else
                    Return ""
            End Select
        End Get
    End Property

    Public Overloads ReadOnly Property Parent As BG3_Obj_VisualBank_Class
        Get
            If ParentKey_Or_Empty = "" Then Return Nothing
            Dim value As BG3_Obj_VisualBank_Class = Nothing
            GameEngine.ProcessedVisualBanksList.TryGetValue(ParentKey_Or_Empty, value)
            Return value
        End Get
    End Property
    Public Overloads Property Type As BG3_Enum_VisualBank_Type = BG3_Enum_VisualBank_Type.CharacterVisualBank
    Sub New(ByRef Nod As LSLib.LS.Node, ByRef Source As BG3_Pak_SourceOfResource_Class, type As BG3_Enum_VisualBank_Type)
        Me.Type = type
        If Me.Type = BG3_Enum_VisualBank_Type.MaterialShader Then
            Me.Cached_Attributes.TryAdd("ID", Source.Filename_Relative.Replace("\", "/").Replace(".lsf.lsx", ".lsf", StringComparison.OrdinalIgnoreCase))
            Me.Cached_Attributes.TryAdd("Name", IO.Path.GetFileNameWithoutExtension(Source.Filename_Relative.Replace(".lsf.lsx", ".lsf", StringComparison.OrdinalIgnoreCase)))
        End If
        Create(Nod, Source)
    End Sub
    Public Overrides Sub Init_Necessary_Attributes()
        ' To complete
        ReadAttribute_Or_Nothing("ID")
        ReadAttribute_Or_Nothing("Name")
    End Sub

    Public Overrides Function Filter_Check_Level1(Level1 As Integer) As Boolean
        If Level1 = -1 Then Return True
        Return Level1 = Type
    End Function
    Public Overrides Function Filter_Check_Level2(Level2 As String) As Boolean
        Return True
    End Function

    Sub New()
    End Sub
End Class

#End Region

#Region "Icons"

<Serializable>
Public Class BG3_Obj_IconAtlass_Class
    Inherits BG3_Obj_Generic_Class
    Public Overrides ReadOnly Property MapKey_Attribute As String = "Not Implemented"
    Public Property Internal_mapkey As String = ""
    Public Property Internal_Path As String = ""
    Public Overrides Function Filter_Check_Level1(Level1 As Integer) As Boolean
        Return True
    End Function
    Public Overrides Function Filter_Check_Level2(Level2 As String) As Boolean
        Return True
    End Function

    Public Overrides ReadOnly Property MapKey As String
        Get
            If IsOverrided Then Return Internal_mapkey + "ov_" + OverrideNumber.ToString.PadLeft(4, "0")
            Return Internal_mapkey
        End Get
    End Property
    Public Overrides Sub Init_Necessary_Attributes()

    End Sub
    Sub New(ByRef Nod As LSLib.LS.Node, ByRef Source As BG3_Pak_SourceOfResource_Class)
        Create(Nod, Source)
        Try
            Internal_mapkey = Nod.Children("TextureAtlasPath").First.Attributes("UUID").Value
            Internal_Path = Nod.Children("TextureAtlasPath").First.Attributes("Path").Value
        Catch ex As Exception
            Debugger.Break()
        End Try
    End Sub

    Private _CacheAtlas As Bitmap = Nothing
    Public Function Get_Atlas() As Bitmap
        If IsNothing(_CacheAtlas) Then
            Dim fil = BG3_Pak_Packages_List_Class.Find_Asset(IO.Path.Combine("Public", Me.SourceOfResorce.ModFolder), Internal_Path)
            If IsNothing(fil) Then Return Nothing
            _CacheAtlas = PfmiToBitmap(fil.SourceOfResorce.CreateContentReader).Clone
            fil.SourceOfResorce.ReleaseMem()
        End If
        Return _CacheAtlas
    End Function
    Public Sub New()

    End Sub
End Class


<Serializable>
Public Class BG3_Obj_IconUV_Class
    Inherits BG3_Obj_Generic_Class

    Public Sub New()

    End Sub
    Public Overloads ReadOnly Property [Type] As BG3_Enum_Icon_Type
        Get
            If Me.SourceOfResorce.Filename_Relative.Contains("CharacterCreation") Then Return BG3_Enum_Icon_Type.CharacterCreation
            If Not IsNothing(FilePath) AndAlso FilePath.Contains("Portraits", StringComparison.OrdinalIgnoreCase) Then Return BG3_Enum_Icon_Type.Portraits
            If IsNothing(AtlasMapKey) OrElse AtlasMapKey = "" Then Return BG3_Enum_Icon_Type.Others_Files
            If IsNothing(FilePath) Then Return BG3_Enum_Icon_Type.Others_Atlas
            Return BG3_Enum_Icon_Type.Items
        End Get
    End Property
    Public Overrides ReadOnly Property MapKey_Attribute As String = "MapKey"
    Public Property AtlasMapKey As String = Nothing
    Public Property FilePath As String = Nothing
    Public Overrides Function Filter_Check_Level1(Level1 As Integer) As Boolean
        If Level1 = -1 Or Level1 = Type Then Return True
        Return False
    End Function
    Public Overrides Sub Init_Necessary_Attributes()
        If Not IsNothing(AtlasMapKey) Then
            ReadAttribute_Or_Nothing("U1")
            ReadAttribute_Or_Nothing("U2")
            ReadAttribute_Or_Nothing("V1")
            ReadAttribute_Or_Nothing("V2")
        End If
    End Sub

    Sub New(ByRef Nod As LSLib.LS.Node, ByRef Source As BG3_Pak_SourceOfResource_Class, ByRef Atlas As BG3_Obj_IconAtlass_Class)
        AtlasMapKey = Atlas.MapKey
        Create(Nod, Source)
    End Sub
    Sub New(source As BG3_Pak_SourceOfResource_Class)
        FilePath = source.Filename_Relative
        Create(IO.Path.GetFileNameWithoutExtension(source.Filename_Relative), source)
    End Sub

    Private _CacheIconF As Bitmap = Nothing
    Private _CacheIconA As Bitmap = Nothing
    Public Function Get_Icon_FromAtlass_or_File() As Bitmap
        If Not IsNothing(Me.AtlasMapKey) Then
            Return Get_Icon_FromAtlass()
        Else
            Return Get_Icon_FromFile()
        End If
    End Function

    Public Function Get_Icon_FromAtlass() As Drawing.Image
        If IsNothing(_CacheIconA) Then
            Dim atlas As BG3_Obj_IconAtlass_Class = Nothing
            If IsNothing(AtlasMapKey) Then Return Nothing
            If GameEngine.ProcessedIconAtlassList.TryGetValue(AtlasMapKey, atlas) Then
                Dim u1 As Integer = ReadAttribute_Or_Nothing("U1") * atlas.Get_Atlas.Width
                Dim u2 As Integer = ReadAttribute_Or_Nothing("U2") * atlas.Get_Atlas.Width
                Dim v1 As Integer = ReadAttribute_Or_Nothing("V1") * atlas.Get_Atlas.Height
                Dim v2 As Integer = ReadAttribute_Or_Nothing("V2") * atlas.Get_Atlas.Height
                Dim format = PixelFormat.Format32bppArgb
                Dim cloneRect As New RectangleF(u1, v1, u2 - u1, v2 - v1)
                _CacheIconA = atlas.Get_Atlas.Clone(cloneRect, format)
            End If
        End If
        Return _CacheIconA
    End Function

    Public Function Get_Icon_FromFile() As Drawing.Image
        If IsNothing(_CacheIconF) Then
            Dim Asset As BG3_Obj_Assets_Class = Nothing
            If IsNothing(FilePath) Then Return Nothing
            If GameEngine.ProcessedAssets.TryGetValue(FilePath, Asset) Then
                Dim u1 As Integer = 0
                Dim u2 As Integer = Asset.Get_DDS.Width
                Dim v1 As Integer = 0
                Dim v2 As Integer = Asset.Get_DDS.Height
                Dim format = PixelFormat.Format32bppArgb
                Dim cloneRect As New RectangleF(u1, v1, u2 - u1, v2 - v1)
                _CacheIconF = Asset.Get_DDS.Clone(cloneRect, format)
            End If
        End If
        Return _CacheIconF
    End Function


End Class
#End Region


#Region "UsefulLists"
<Serializable>
Public Enum BG3_Enum_FlagsandTagsType
    Flags
    Tags
    GoldValues
    LevelMapValues
    ExperienceRewards
    EquipmentTypes
    EquipmentRaces
    EquipmentSlots
    PasivesList
    AbilityList
    SpellList
    SkillList
    ActionResource
    MultieffectInfo
    Races
End Enum


<Serializable>
Public Class BG3_Obj_FlagsAndTags_Class
    Inherits BG3_Obj_Generic_Class
    Public Overrides ReadOnly Property MapKey_Attribute As String = "UUID"

    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.WhenWritingDefault)>
    <DefaultValue(BG3_Enum_FlagsandTagsType.Flags)>
    Public Overloads Property Type As BG3_Enum_FlagsandTagsType = BG3_Enum_FlagsandTagsType.Flags
    Public Overrides ReadOnly Property MapKey As String
        Get
            Dim mk As String
            Select Case Type
                Case BG3_Enum_FlagsandTagsType.EquipmentSlots
                    mk = ReadAttribute_Or_Nothing("MapKey")
                Case BG3_Enum_FlagsandTagsType.EquipmentRaces
                    mk = ReadAttribute_Or_Nothing("Guid")
                Case Else
                    mk = ReadAttribute_Or_Nothing("UUID")
            End Select
            If IsOverrided Then Return mk + "ov_" + OverrideNumber.ToString.PadLeft(4, "0")
            Return mk
        End Get
    End Property
    Public Overrides ReadOnly Property Name As String
        Get
            Dim nam As String
            Select Case Type
                Case BG3_Enum_FlagsandTagsType.EquipmentSlots
                    nam = ReadAttribute_Or_Nothing("MapKey")
                Case BG3_Enum_FlagsandTagsType.AbilityList, BG3_Enum_FlagsandTagsType.PasivesList, BG3_Enum_FlagsandTagsType.SpellList, BG3_Enum_FlagsandTagsType.SkillList
                    nam = ReadAttribute_Or_Nothing("UUID")
                Case Else
                    nam = ReadAttribute_Or_Nothing("Name")
            End Select
            If IsOverrided Then
                If Me.SourceOfResorce.ModFolder = "Honour" Then
                    Return "(Honour " + OverrideNumber.ToString.PadLeft(4, "0") + ") " + nam
                Else
                    Return "(Overrided " + OverrideNumber.ToString.PadLeft(4, "0") + ") " + nam
                End If
            End If
            If Deleted Then
                Return "(Deleted) " + nam
            End If
            Return nam
        End Get
    End Property

    Public Overrides ReadOnly Property ParentKey_Or_Empty As String
        Get
            If Me.IsOverrided Then Return Me.Mapkey_WithoutOverride
            If Me.Type = BG3_Enum_FlagsandTagsType.GoldValues Then Return ReadAttribute_Or_Empty("ParentUUID")
            If Me.Type = BG3_Enum_FlagsandTagsType.EquipmentRaces Then Return ReadAttribute_Or_Empty("DefaultParent")
            If Me.Type = BG3_Enum_FlagsandTagsType.Races Then Return ReadAttribute_Or_Empty("ParentGuid")

            Return MyBase.ParentKey_Or_Empty
        End Get
    End Property

    Public Overloads ReadOnly Property Parent As BG3_Obj_FlagsAndTags_Class
        Get
            If ParentKey_Or_Empty = "" Then Return Nothing
            Dim value As BG3_Obj_FlagsAndTags_Class = Nothing
            GameEngine.ProcessedFlagsAndTags.TryGetValue(ParentKey_Or_Empty, value)
            Return value
        End Get
    End Property



    Public ReadOnly Property Description As String
        Get
            Select Case Type
                Case BG3_Enum_FlagsandTagsType.Flags
                    Return ReadAttribute_Or_Nothing("Description")
                Case BG3_Enum_FlagsandTagsType.Tags
                    Return ReadAttribute_Or_Nothing("Description")
                Case BG3_Enum_FlagsandTagsType.GoldValues
                    Return ReadAttribute_Or_Nothing("Name")
                Case BG3_Enum_FlagsandTagsType.LevelMapValues
                    Return ReadAttribute_Or_Nothing("Name")
                Case BG3_Enum_FlagsandTagsType.ExperienceRewards
                    Return ReadAttribute_Or_Nothing("Name")
                Case BG3_Enum_FlagsandTagsType.EquipmentTypes
                    Return ReadAttribute_Or_Nothing("Name")
                Case BG3_Enum_FlagsandTagsType.ActionResource
                    Return ReadAttribute_Or_Nothing("Name")
                Case BG3_Enum_FlagsandTagsType.EquipmentRaces
                    Return ReadAttribute_Or_Nothing("Name")
                Case BG3_Enum_FlagsandTagsType.EquipmentSlots
                    Return ReadAttribute_Or_Nothing("MapValue")
                Case BG3_Enum_FlagsandTagsType.SpellList
                    Return ReadAttribute_Or_Nothing("Comment")
                Case BG3_Enum_FlagsandTagsType.MultieffectInfo
                    Return ReadAttribute_Or_Nothing("Name")
                Case BG3_Enum_FlagsandTagsType.Races
                    Return ReadAttribute_Or_Nothing("Name")
                Case Else
                    Debugger.Break()
                    Return ""
            End Select
        End Get
    End Property
    Public ReadOnly Property DisplayDescription As String
        Get
            Select Case Type
                Case BG3_Enum_FlagsandTagsType.Flags
                    Return ReadAttribute_Or_Nothing("Description")
                Case BG3_Enum_FlagsandTagsType.Tags
                    If IsNothing(ReadAttribute_Or_Nothing("DisplayDescription")) Then Return Description
                    Dim str = GameEngine.ProcessedLocalizationList.Localize(ReadAttribute_Or_Nothing("DisplayDescription"))
                    If IsNothing(str) Or str = "" Then Return Description
                    Return str
                Case BG3_Enum_FlagsandTagsType.ActionResource
                    If IsNothing(ReadAttribute_Or_Nothing("Description")) Then Return Description
                    Dim str = GameEngine.ProcessedLocalizationList.Localize(ReadAttribute_Or_Nothing("Description"))
                    If IsNothing(str) Or str = "" Then Return Description
                    Return str
                Case BG3_Enum_FlagsandTagsType.EquipmentSlots
                    Return ReadAttribute_Or_Nothing("MapValue")
                Case BG3_Enum_FlagsandTagsType.Races
                    If IsNothing(ReadAttribute_Or_Nothing("Description")) Then Return Description
                    Dim str = GameEngine.ProcessedLocalizationList.Localize(ReadAttribute_Or_Nothing("Description"))
                    If IsNothing(str) Or str = "" Then Return Description
                    Return str
                Case Else
                    Return ReadAttribute_Or_Nothing("Description")
            End Select
        End Get
    End Property

    Public Overrides ReadOnly Property DisplayName As String
        Get
            Select Case Type
                Case BG3_Enum_FlagsandTagsType.Flags
                    Return ReadAttribute_Or_Nothing("Description")
                Case BG3_Enum_FlagsandTagsType.SpellList
                    Return ReadAttribute_Or_Nothing("Comment")
                Case BG3_Enum_FlagsandTagsType.Tags
                    If IsNothing(ReadAttribute_Or_Nothing("DisplayName")) Then Return Description
                    Dim str = GameEngine.ProcessedLocalizationList.Localize(ReadAttribute_Or_Nothing("DisplayName"))
                    If IsNothing(str) Or str = "" Then Return Description
                    Return str
                Case BG3_Enum_FlagsandTagsType.ActionResource
                    If IsNothing(ReadAttribute_Or_Nothing("DisplayName")) Then Return Description
                    Dim str = GameEngine.ProcessedLocalizationList.Localize(ReadAttribute_Or_Nothing("DisplayName"))
                    If IsNothing(str) Or str = "" Then Return Description
                    Return str
                Case BG3_Enum_FlagsandTagsType.EquipmentSlots
                    Return ReadAttribute_Or_Nothing("MapValue")
                Case Else
                    Return ReadAttribute_Or_Nothing("Name")
            End Select
        End Get
    End Property
    Public Overrides Function Filter_Check_Level1(Level1 As Integer) As Boolean
        If Level1 = -1 Then Return True
        Return Level1 = Type
    End Function
    Public Overrides Sub Init_Necessary_Attributes()
        ReadAttribute_Or_Nothing(MapKey_Attribute)
        If Me.Type = BG3_Enum_FlagsandTagsType.GoldValues Then ReadAttribute_Or_Nothing("ParentUUID")
        If Me.Type = BG3_Enum_FlagsandTagsType.EquipmentRaces Then ReadAttribute_Or_Nothing("DefaultParent")
        ReadAttribute_Or_Nothing("Name")
        ReadAttribute_Or_Nothing("Description")
        If Me.Type = BG3_Enum_FlagsandTagsType.SpellList Then ReadAttribute_Or_Nothing("Comment")
        If Me.Type = BG3_Enum_FlagsandTagsType.Races Then ReadAttribute_Or_Nothing("ParentGuid")

        ReadAttribute_Or_Nothing("DisplayName")
        ReadAttribute_Or_Nothing("DisplayDescription")
    End Sub

    Sub New(ByRef nod As LSLib.LS.Node, Source As BG3_Pak_SourceOfResource_Class, tipo As BG3_Enum_FlagsandTagsType)
        Select Case tipo
            Case BG3_Enum_FlagsandTagsType.EquipmentSlots
                MapKey_Attribute = "MapKey"
            Case BG3_Enum_FlagsandTagsType.EquipmentRaces
                MapKey_Attribute = "Guid"
            Case Else
                MapKey_Attribute = "UUID"
        End Select
        Me.Type = tipo
        Create(nod, Source)
        If IsNothing(MapKey) Then Debugger.Break()
    End Sub
    Sub New()

    End Sub

End Class
#End Region
#Region "Assets"

<Serializable>
Public Class BG3_Obj_Assets_Class
    Inherits BG3_Obj_Generic_Class

    Public Overrides ReadOnly Property MapKey_Attribute As String = "Not Definied"
    Public ReadOnly Property [Path] As String
        Get
            Return Me.ReadAttribute_Or_Nothing("MapKey")
        End Get
    End Property
    Public Overrides ReadOnly Property MapKey As String
        Get
            If IsOverrided Then Return Me.Path + "ov_" + OverrideNumber.ToString.PadLeft(4, "0")
            Return Me.Path
        End Get
    End Property

    Public Overrides Sub Init_Necessary_Attributes()
    End Sub

    Sub New(Source As BG3_Pak_SourceOfResource_Class)
        Me.Cached_Attributes.TryAdd("MapKey", Source.Filename_Relative.Replace("\", "/").Replace(".lsf.lsx", ".lsf", StringComparison.OrdinalIgnoreCase))
        Create(Source)
    End Sub
    Sub New()

    End Sub

    Private _CacheDDS As Bitmap = Nothing
    Public Function Get_DDS() As Bitmap
        If IsNothing(_CacheDDS) Then
            Dim fil = BG3_Pak_Packages_List_Class.Find_Asset("", Path)
            If IsNothing(fil) Then Return Nothing
            _CacheDDS = PfmiToBitmap(fil.SourceOfResorce.CreateContentReader).Clone
            fil.SourceOfResorce.ReleaseMem()
        End If
        Return _CacheDDS
    End Function


End Class


#End Region

#Region "BaseClass"
<Serializable>
Public Class Hierarchy_Helper_Class
    Inherits SortedList(Of String, List(Of String))
    Sub New()
        MyBase.New
    End Sub
End Class
<Serializable>
Public Class Elements_Class(Of T)
    Inherits SortedList(Of String, T)
    Sub New()
        MyBase.New
    End Sub
End Class
<Serializable>
Public Class BG3_Obj_SortedList_Class(Of T As BG3_Obj_Generic_Class)

    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.Never)>
    <JsonPropertyName("H")>
    Public Property Hierarchy_Helper As New Hierarchy_Helper_Class

    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.Never)>
    <JsonPropertyName("E")>
    Public Property Elements As New Elements_Class(Of T)

    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.Never)>
    <JsonPropertyName("A")>
    Public Property Attributes_Stats_List As New SortedList(Of String, String)


    Sub New()
    End Sub

    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.Always)>
    Default Public Property [Get](key As String) As T
        Get
            Return Elements(key)
        End Get
        Set(value As T)
            Elements(key) = value
        End Set
    End Property

    Public ReadOnly Property Count As Integer
        Get
            Return Elements.Count
        End Get
    End Property

    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.Always)>
    Public ReadOnly Property ElementValues As IList(Of T)
        Get
            Return Elements.Values
        End Get
    End Property

    Public Overridable Sub Clear_Cached_Data()
        Hierarchy_Helper.Clear()
        Elements.Clear()
        Attributes_Stats_List.Clear()
    End Sub
    Public Overloads Sub Clear()
        Clear_Cached_Data()
    End Sub

    Public Function Remove(ByRef obj As T) As Boolean
        obj.Deleted = True
        Return True
    End Function
    Public Function TryAdd(Key As String, ByRef obj As T) As Boolean
        Return Elements.TryAdd(Key, obj)
    End Function
    Public Overloads Function TryGetValue(Key As String, ByRef obj As T) As Boolean
        Return Elements.TryGetValue(Key, obj)
    End Function
    Public Overloads Function Containskey(key As String) As Boolean
        Return Elements.ContainsKey(key)
    End Function

    'Public _Attr As New SortedList(Of String, String)
    Private Sub Save_Attributes_List(ByRef obj As T)
        If obj.SourceOfResorce.PackageType = BG3_Enum_Package_Type.BaseGame Then
            Select Case True
                Case obj.GetType Is GetType(BG3_Obj_IconUV_Class)
                Case obj.GetType Is GetType(BG3_Obj_Assets_Class)
                Case obj.GetType Is GetType(BG3_Obj_Generic_Class)
                Case obj.GetType Is GetType(BG3_Obj_IconAtlass_Class)
                Case obj.GetType Is GetType(BG3_Obj_Stats_Class)
                    For Each da In CType(CType(obj, Object), BG3_Obj_Stats_Class).Data
                        Dim attId As Integer = CInt(CType(CType(obj, Object), BG3_Obj_Stats_Class).Type)
                        SyncLock Attributes_Stats_List
                            Attributes_Stats_List.TryAdd(da.Key + ";" + attId.ToString, da.Key)
                        End SyncLock
                    Next

                Case obj.GetType Is GetType(BG3_Obj_Template_Class)
                    SaveAttributesListNode(obj.NodeLSLIB, CType(CType(obj, Object), BG3_Obj_Template_Class).Type.ToString, "")
                Case obj.GetType Is GetType(BG3_Obj_FlagsAndTags_Class)
                    SaveAttributesListNode(obj.NodeLSLIB, CType(CType(obj, Object), BG3_Obj_FlagsAndTags_Class).Type.ToString, "")
                Case obj.GetType Is GetType(BG3_Obj_VisualBank_Class)
                    If obj.Mapkey_WithoutOverride <> "936318c6-8e61-d821-baea-dbd0c6cfd66d" Then ' Este esta mal!
                        SaveAttributesListNode(obj.NodeLSLIB, CType(CType(obj, Object), BG3_Obj_VisualBank_Class).Type.ToString, "")
                        'ScalarsAndOthers(CType(CType(obj, Object), BG3_Obj_VisualBank_Class))
                    End If

                Case obj.GetType Is GetType(BG3_Obj_TreasureTable_Class)
                Case obj.GetType Is GetType(BG3_Obj_TreasureTable_Subtable_Class)
                Case obj.GetType Is GetType(BG3_Obj_TreasureTable_TableItem_Class)

            End Select
        End If

    End Sub


    'Public ScalarParametersMaterialBank As New SortedList(Of String, Integer)
    'Public ScalarParametersCharacterBank As New SortedList(Of String, Integer)

    'Public Vector3ParametersMaterialBank As New SortedList(Of String, Integer)
    'Public Vector3ParametersCharacterBank As New SortedList(Of String, Integer)

    'Public VectorParametersMaterialBank As New SortedList(Of String, Integer)
    'Public VectorParametersCharacterBank As New SortedList(Of String, Integer)
    'Private Sub ScalarsAndOthers(obj As BG3_Obj_VisualBank_Class)
    '    Dim nod As LSLib.LS.Node = Nothing
    '    Dim Name As String = "Parameter"
    '    Dim dondeScalar As SortedList(Of String, Integer) = Nothing
    '    Dim dondevectr3 As SortedList(Of String, Integer) = Nothing
    '    Dim dondevectr As SortedList(Of String, Integer) = Nothing
    '    Select Case obj.Type
    '        Case BG3_Enum_VisualBank_Type.CharacterVisualBank
    '            If obj.NodeLSLIB.Children.ContainsKey("MaterialOverrides") Then
    '                nod = obj.NodeLSLIB.Children("MaterialOverrides").First
    '                dondeScalar = ScalarParametersCharacterBank
    '                dondevectr3 = Vector3ParametersCharacterBank
    '                dondevectr = VectorParametersCharacterBank
    '                Name = "Parameter"
    '            End If
    '        Case BG3_Enum_VisualBank_Type.MaterialBank
    '            dondeScalar = ScalarParametersMaterialBank
    '            dondevectr3 = Vector3ParametersMaterialBank
    '            dondevectr = VectorParametersMaterialBank
    '            nod = obj.NodeLSLIB
    '            Name = "ParameterName"
    '    End Select
    '    If Not IsNothing(nod) Then
    '        SyncLock dondeScalar
    '            SyncLock dondevectr
    '                SyncLock dondevectr3
    '                    If nod.Children.ContainsKey("ScalarParameters") Then
    '                        For Each child In nod.Children("ScalarParameters")
    '                            Dim att As LSLib.LS.NodeAttribute = Nothing
    '                            If child.Attributes.TryGetValue(Name, att) Then
    '                                Dim valor As String = att.AsString(Funciones.Guid_to_string)
    '                                If dondeScalar.TryAdd(valor, 1) = False Then
    '                                    dondeScalar(valor) = dondeScalar(valor) + 1
    '                                End If
    '                            End If
    '                        Next
    '                    End If
    '                    If nod.Children.ContainsKey("Vector3Parameters") Then
    '                        For Each child In nod.Children("Vector3Parameters")
    '                            Dim att As LSLib.LS.NodeAttribute = Nothing
    '                            If child.Attributes.TryGetValue(Name, att) Then
    '                                Dim valor As String = att.AsString(Funciones.Guid_to_string)
    '                                If dondevectr3.TryAdd(valor, 1) = False Then
    '                                    dondevectr3(valor) = dondevectr3(valor) + 1
    '                                End If
    '                            End If
    '                        Next
    '                    End If
    '                    If nod.Children.ContainsKey("VectorParameters") Then
    '                        For Each child In nod.Children("VectorParameters")
    '                            Dim att As LSLib.LS.NodeAttribute = Nothing
    '                            If child.Attributes.TryGetValue(Name, att) Then
    '                                Dim valor As String = att.AsString(Funciones.Guid_to_string)
    '                                If dondevectr.TryAdd(valor, 1) = False Then
    '                                    dondevectr(valor) = dondevectr(valor) + 1
    '                                End If
    '                            End If
    '                        Next
    '                    End If

    '                End SyncLock
    '            End SyncLock
    '        End SyncLock
    '    End If
    'End Sub


    Private Sub SaveAttributesListNode(Node As LSLib.LS.Node, type As String, prefix As String)
        If prefix = "" Then prefix = Node.Name
        For Each at In Node.Attributes
            Dim attId As LSLib.LS.AttributeType = CInt(at.Value.Type)
            SyncLock Attributes_Stats_List
                Attributes_Stats_List.TryAdd(prefix + ";" + at.Key + ";" + attId.ToString + ";" + type, at.Key)
            End SyncLock
        Next
        For Each nod In Node.Children
            For Each Subnod In nod.Value
                SaveAttributesListNode(Subnod, type, prefix + "\" + Subnod.Name)
            Next
        Next
    End Sub

    Private Sub SaveUtamAndOthers(ByRef obj As T)
        If obj.GetType = GetType(BG3_Obj_Template_Class) AndAlso obj.SourceOfResorce.PackageType = BG3_Enum_Package_Type.UTAM_Mod Then
            GameEngine.UtamTemplates.Add(TryCast(obj, BG3_Obj_Template_Class))
        End If
        If obj.GetType = GetType(BG3_Obj_VisualBank_Class) AndAlso obj.SourceOfResorce.PackageType = BG3_Enum_Package_Type.UTAM_Mod Then
            GameEngine.UtamVisuals.Add(TryCast(obj, BG3_Obj_VisualBank_Class))
        End If
        If obj.GetType = GetType(BG3_Obj_FlagsAndTags_Class) AndAlso obj.SourceOfResorce.PackageType = BG3_Enum_Package_Type.UTAM_Mod Then
            GameEngine.Utamflagsandtags.Add(TryCast(obj, BG3_Obj_FlagsAndTags_Class))
        End If
        If obj.GetType = GetType(BG3_Obj_Stats_Class) AndAlso obj.SourceOfResorce.PackageType = BG3_Enum_Package_Type.UTAM_Mod Then
            GameEngine.Utamstats.Add(TryCast(obj, BG3_Obj_Stats_Class))
        End If
        If obj.GetType = GetType(BG3_Obj_TreasureTable_Class) AndAlso obj.SourceOfResorce.PackageType = BG3_Enum_Package_Type.UTAM_Mod Then
            GameEngine.UtamTreasures.Add(TryCast(obj, BG3_Obj_TreasureTable_Class))
        End If

        Save_Attributes_List(obj)
        obj.Clear_CacheNode_Only()
    End Sub
    Public Function Manage_Overrides(ByRef obj As T) As T
        Dim ov As T = Nothing
        Try
            SaveUtamAndOthers(obj)

            SyncLock Elements
                ' Add
                If Elements.TryAdd(obj.MapKey, obj) = True Then AddHyerarchy(obj) : Return obj
                ' If cant add try to read same key
                If Elements.TryGetValue(obj.MapKey, ov) = True Then
                    If obj Is ov Then
                        ' En el caso que sea el mismo....
                        AddHyerarchy(obj)
                        Return obj
                    End If
                    RemoveHyerarchy(ov)
                    Dim swap As Object = Nothing
                    If Check_order(obj, ov) = False Then
                        swap = obj
                        obj = ov
                        ov = swap
                    End If
                    If DoOverride(obj, ov, swap) = True Then
                        Dim ovn As Integer = 1
                        Dim ovst As String = obj.MapKey + "ov_" + ovn.ToString.PadLeft(4, "0")
                        If obj.IsOverrided Then
                            ovn = obj.OverrideNumber
                            obj.OverrideNumber = 0
                        End If
                        Elements(obj.Mapkey_WithoutOverride) = obj
                        While Elements.ContainsKey(ovst)
                            ovn += 1
                            ovst = obj.MapKey + "ov_" + ovn.ToString.PadLeft(4, "0")
                        End While
                        ov.OverrideNumber = ovn
                        If ov.GetType Is GetType(BG3_Obj_TreasureTable_Class) AndAlso CType(CType(ov, Object), BG3_Obj_TreasureTable_Class).Merged = True Then
                            SyncLock obj
                                CType(CType(obj, Object), BG3_Obj_TreasureTable_Class).MergedChilds.Add(ovn)
                            End SyncLock
                        End If
                        Elements.TryAdd(ov.MapKey, ov)
                        AddHyerarchy(ov)
                        AddHyerarchy(obj)
                        Return obj
                    Else
                        Elements(obj.MapKey) = swap
                        AddHyerarchy(swap)
                        Return swap
                    End If
                Else
                    Debugger.Break()
                End If
                Debugger.Break()
            End SyncLock
            Return obj
        Catch ex As Exception
            Debugger.Break()
            Return Nothing
        End Try
    End Function

    Private Shared Function Check_order(obj As T, ov As T) As Boolean

        If ov.SourceOfResorce.PackageType = BG3_Enum_Package_Type.BaseGame Then
            If obj.SourceOfResorce.PackageType = BG3_Enum_Package_Type.BaseGame Then
                If obj.SourceOfResorce.Pak_Or_Folder.StartsWith("Patch") And ov.SourceOfResorce.Pak_Or_Folder.StartsWith("Patch") Then
                    If obj.SourceOfResorce.Pak_Or_Folder.ToUpper > ov.SourceOfResorce.Pak_Or_Folder.ToUpper Then Return True
                    If obj.SourceOfResorce.Pak_Or_Folder.ToUpper < ov.SourceOfResorce.Pak_Or_Folder.ToUpper Then Return False
                End If
                If obj.SourceOfResorce.Pak_Or_Folder.StartsWith("Patch") And ov.SourceOfResorce.Pak_Or_Folder.StartsWith("Patch") = False Then Return True
                If obj.SourceOfResorce.Pak_Or_Folder.StartsWith("Patch") = False And ov.SourceOfResorce.Pak_Or_Folder.StartsWith("Patch") Then Return False
                If obj.SourceOfResorce.ModFolder = "SharedDev" And ov.SourceOfResorce.ModFolder = "Shared" Then Return True
                If obj.SourceOfResorce.ModFolder = "Shared" And ov.SourceOfResorce.ModFolder = "SharedDev" Then Return False
                If obj.SourceOfResorce.ModFolder = "GustavDev" And ov.SourceOfResorce.ModFolder = "Gustav" Then Return True
                If obj.SourceOfResorce.ModFolder = "Gustav" And ov.SourceOfResorce.ModFolder = "GustavDev" Then Return False
                If obj.SourceOfResorce.ModFolder.StartsWith("Gustav") And ov.SourceOfResorce.ModFolder.StartsWith("Shared") Then Return True
                If obj.SourceOfResorce.ModFolder.StartsWith("Shared") And ov.SourceOfResorce.ModFolder.StartsWith("Gustav") Then Return False
                If ov.SourceOfResorce.Filename_Relative.EndsWith(".lsf") And obj.SourceOfResorce.Filename_Relative.EndsWith(".lsx") Then
                    If obj.SourceOfResorce.Filename_Relative.Replace(".lsx", ".lsf") = ov.SourceOfResorce.Filename_Relative Then Return False
                End If
                If obj.SourceOfResorce.Filename_Relative.EndsWith(".lsf") And ov.SourceOfResorce.Filename_Relative.EndsWith(".lsx") Then
                    If obj.SourceOfResorce.Filename_Relative = ov.SourceOfResorce.Filename_Relative.Replace(".lsx", ".lsf") Then Return True
                End If
                If obj.SourceOfResorce.ModFolder = "Shared" And ov.SourceOfResorce.ModFolder = "Engine" Then Return True
                If obj.SourceOfResorce.ModFolder = "Engine" And ov.SourceOfResorce.ModFolder = "Shared" Then Return False
                If obj.SourceOfResorce.ModFolder = "SharedDev" And ov.SourceOfResorce.ModFolder = "Engine" Then Return True
                If obj.SourceOfResorce.ModFolder = "Engine" And ov.SourceOfResorce.ModFolder = "SharedDev" Then Return False
                If obj.SourceOfResorce.ModFolder = "Honour" And ov.SourceOfResorce.ModFolder <> "Honour" Then Return False
                If obj.SourceOfResorce.ModFolder <> "Honour" And ov.SourceOfResorce.ModFolder = "Honour" Then Return True
                If obj.SourceOfResorce.ModFolder.StartsWith("Shared") And ov.SourceOfResorce.ModFolder.StartsWith("Game") Then Return True
                If obj.SourceOfResorce.ModFolder.StartsWith("Gustav") And ov.SourceOfResorce.ModFolder.StartsWith("Game") Then Return True
                If obj.SourceOfResorce.ModFolder.StartsWith("Game") And ov.SourceOfResorce.ModFolder.StartsWith("Shared") Then Return False
                If obj.SourceOfResorce.ModFolder.StartsWith("Game") And ov.SourceOfResorce.ModFolder.StartsWith("Gustav") Then Return False
                If obj.SourceOfResorce.Pak_Or_Folder = ov.SourceOfResorce.Pak_Or_Folder AndAlso obj.SourceOfResorce.ModFolder = ov.SourceOfResorce.ModFolder AndAlso obj.SourceOfResorce.Filename_Relative = ov.SourceOfResorce.Filename_Relative AndAlso obj.SourceOfResorce.PackageType = ov.SourceOfResorce.PackageType Then Return True
                If obj.SourceOfResorce.Filename_Relative.EndsWith("XPData.txt") And ov.SourceOfResorce.Filename_Relative.EndsWith("Data.txt") And ov.SourceOfResorce.Filename_Relative.EndsWith("XPData.txt") = False Then Return False
                If ov.SourceOfResorce.Filename_Relative.EndsWith("XPData.txt") And obj.SourceOfResorce.Filename_Relative.EndsWith("Data.txt") And obj.SourceOfResorce.Filename_Relative.EndsWith("XPData.txt") = False Then Return True
                Debugger.Break()
            Else
                        Return True
            End If
        End If
        Return True
        Dim lobj = FuncionesHelpers.GameEngine.ProcessedModuleList.Where(Function(pf) pf.SourceOfResource.ModFolder = obj.SourceOfResorce.ModFolder).First.LoadOrderd
        Dim lov = FuncionesHelpers.GameEngine.ProcessedModuleList.Where(Function(pf) pf.SourceOfResource.ModFolder = ov.SourceOfResorce.ModFolder).First.LoadOrderd
        If lobj < lov Then Return False
        Debugger.Break()
        Return True
    End Function
    Public Sub AddHyerarchy(ByRef quien As T)
        If quien.IsOverrided = False Then
            If quien.ParentKey_Or_Empty <> "" AndAlso quien.ParentKey_Or_Empty <> quien.MapKey Then
                SyncLock Hierarchy_Helper
                    Dim nuevo As Boolean = Hierarchy_Helper.TryAdd(quien.ParentKey_Or_Empty, New List(Of String) From {quien.MapKey})
                    If nuevo = False AndAlso Hierarchy_Helper(quien.ParentKey_Or_Empty).Contains(quien.MapKey) = False Then Hierarchy_Helper(quien.ParentKey_Or_Empty).Add(quien.MapKey)
                End SyncLock
            End If
        Else
            If quien.Mapkey_WithoutOverride <> "" AndAlso quien.Mapkey_WithoutOverride <> quien.MapKey Then
                SyncLock Hierarchy_Helper
                    Dim nuevo As Boolean = Hierarchy_Helper.TryAdd(quien.Mapkey_WithoutOverride, New List(Of String) From {quien.MapKey})
                    If nuevo = False AndAlso Hierarchy_Helper(quien.Mapkey_WithoutOverride).Contains(quien.MapKey) = False Then Hierarchy_Helper(quien.Mapkey_WithoutOverride).Add(quien.MapKey)
                End SyncLock
            End If
        End If

    End Sub
    Public Sub RemoveHyerarchy(ByRef quien As T)
        If quien.ParentKey_Or_Empty <> "" AndAlso quien.ParentKey_Or_Empty <> quien.MapKey Then
            SyncLock Hierarchy_Helper
                Dim Esta As Boolean = Hierarchy_Helper.ContainsKey(quien.ParentKey_Or_Empty)
                If Esta Then Hierarchy_Helper(quien.ParentKey_Or_Empty).Remove(quien.MapKey)
            End SyncLock
        End If
    End Sub

    Public Overloads Function DoOverride(ByRef Nuevo As Object, ByRef Original As Object, ByRef swap As Object)
        Select Case Original.GetType
            Case GetType(BG3_Obj_IconUV_Class)
                swap = Original
                swap.SourceOfResorce = Nuevo.SourceOfResorce
                If Not IsNothing(Nuevo.AtlasMapKey) Then
                    swap = Nuevo
                    swap.FilePath = Original.FilePath
                Else
                    swap.FilePath = Nuevo.FilePath
                End If
                Return False
            Case GetType(BG3_Obj_TreasureTable_Class)
                If Nuevo.SourceOfResorce.PackageType = BG3_Enum_Package_Type.UTAM_Mod AndAlso Original.SourceOfResorce.PackageType = BG3_Enum_Package_Type.UTAM_Mod Then
                    If Nuevo.SourceOfResorce.Pak_Or_Folder = Original.SourceOfResorce.Pak_Or_Folder Then
                        swap = Nuevo
                        Return False
                    End If
                End If
                If CType(Nuevo, BG3_Obj_TreasureTable_Class).CanMerge = True Then
                    swap = Original
                    SyncLock Nuevo
                        CType(Nuevo, BG3_Obj_TreasureTable_Class).Merged = True
                    End SyncLock
                    Original = Nuevo
                    Nuevo = swap
                End If
                Return True
            Case Else
                If Nuevo.SourceOfResorce.PackageType = BG3_Enum_Package_Type.UTAM_Mod AndAlso Original.SourceOfResorce.PackageType = BG3_Enum_Package_Type.UTAM_Mod Then
                    If Nuevo.SourceOfResorce.Pak_Or_Folder = Original.SourceOfResorce.Pak_Or_Folder Then
                        swap = Nuevo
                        Return False
                    End If
                End If
                Return True
        End Select
    End Function

End Class


<Serializable>
Public MustInherit Class BG3_Obj_Generic_Class
    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.Never)>
    <JsonPropertyName("S")>
    Public Property SourceOfResorce As BG3_Pak_SourceOfResource_Class

    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.Never)>
    <JsonPropertyName("MK")>
    Public Overridable ReadOnly Property MapKey As String
        Get
            If IsOverrided Then Return ReadAttribute_Or_Nothing(MapKey_Attribute) + "ov_" + OverrideNumber.ToString.PadLeft(4, "0")
            Return ReadAttribute_Or_Nothing(MapKey_Attribute)
        End Get

    End Property
    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.Always)>
    Public Overridable ReadOnly Property Mapkey_WithoutOverride
        Get
            If Me.IsOverrided = False Then Return MapKey
            Return MapKey.Remove(MapKey.IndexOf("ov_"), 7)
        End Get
    End Property

    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.Never)>
    <JsonPropertyName("C")>
    Public Property Cached_Attributes As New SortedList(Of String, String)

    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.WhenWritingNull)>
    <JsonPropertyName("N")>
    Public Property NodeXMLZip As Byte() = Nothing

    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.WhenWritingDefault)>
    <DefaultValue(0)>
    <JsonPropertyName("O")>
    Public Property OverrideNumber As Integer = 0

    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.Always)>
    Public Property Deleted As Boolean = False

    Public ReadOnly Property IsOverrided As Boolean
        Get
            If OverrideNumber > 0 Then Return True
            Return False
        End Get
    End Property
    Public Overridable ReadOnly Property ParentKey_Or_Empty As String
        Get
            Return ""
        End Get
    End Property
    Public Overridable ReadOnly Property Name As String
        Get
            Return MapKey
        End Get
    End Property

    Public Overridable ReadOnly Property DisplayName As String
        Get
            Return MapKey
        End Get
    End Property
    Public Overridable ReadOnly Property DisplayName(language As Bg3_Enum_Languages) As String
        Get
            Return MapKey
        End Get
    End Property
    Public ReadOnly Property Utam_Group As String
        Get
            Select Case Me.GetType
                Case GetType(BG3_Obj_Stats_Class)
                    Dim valor = CType(Me, BG3_Obj_Stats_Class).Get_Data_or_Empty("UTAM_Group")
                    If IsNothing(valor) OrElse valor = "" Then Return "(Default)"
                    Return valor
                Case GetType(BG3_Obj_TreasureTable_Class)
                    Dim valor = "Treasure Tables"
                    Return valor
                Case Else
                    Dim valor = ReadAttribute_Or_Nothing("UTAM_Group")
                    If IsNothing(valor) OrElse valor = "" Then Return "(Default)"
                    Return valor
            End Select
        End Get
    End Property
    Public ReadOnly Property Utam_Type As BG3_Enum_UTAM_Type
        Get

            Select Case Me.GetType
                Case GetType(BG3_Obj_Stats_Class)
                    Dim valor = CType(Me, BG3_Obj_Stats_Class).Get_Data_or_Empty("UTAM_Type")
                    If IsNothing(valor) Then Return -1
                    Dim resultado As BG3_Enum_UTAM_Type
                    If [Enum].TryParse(Of BG3_Enum_UTAM_Type)(valor, resultado) = True Then Return resultado
                    Return -1
                Case GetType(BG3_Obj_TreasureTable_Class)
                    Return BG3_Enum_UTAM_Type.Treasure
                Case Else
                    Dim valor = ReadAttribute_Or_Nothing("UTAM_Type")
                    If IsNothing(valor) Then Return -1
                    Dim resultado As BG3_Enum_UTAM_Type
                    If [Enum].TryParse(Of BG3_Enum_UTAM_Type)(valor, resultado) = True Then Return resultado
                    Return -1
            End Select
        End Get
    End Property

    Public Overridable Function Filter_Check_Level1(Level1 As Integer) As Boolean
        If Level1 = -1 Then Return True
        Return False
    End Function
    Public Overridable Function Filter_Check_Level2(Level2 As String) As Boolean
        Return ParentKey_Or_Empty = Level2
    End Function
    Public Overridable Function Filter_Check_Text(Texto As String, deep As Boolean) As Boolean
        If Texto = "" Then Return True
        If Not IsNothing(Name) AndAlso Name.Contains(Texto, StringComparison.OrdinalIgnoreCase) Then Return True
        If Not IsNothing(DisplayName) AndAlso DisplayName.Contains(Texto, StringComparison.OrdinalIgnoreCase) Then Return True
        If MapKey.Contains(Texto, StringComparison.OrdinalIgnoreCase) Then Return True
        If deep Then
            If Me.SourceOfResorce.Pak_Or_Folder.Contains(Texto, StringComparison.OrdinalIgnoreCase) Or Me.SourceOfResorce.Filename_Relative.Contains(Texto, StringComparison.OrdinalIgnoreCase) Then Return True
            If NodeXML.Contains(Texto, StringComparison.OrdinalIgnoreCase) Then Return True

        End If
        Return False
    End Function
    Public Overridable Function Filter_Check_Source(Sourcefilter As BG3_Pak_SourceOfResource_Class) As Boolean
        If IsNothing(Sourcefilter) Then Return True
        If (Me.SourceOfResorce.Pak_Or_Folder <> Sourcefilter.Pak_Or_Folder OrElse Me.SourceOfResorce.PackageType <> Sourcefilter.PackageType) Then Return False
        Return True
    End Function

    Public Function Is_Filtered(Level1 As Integer, Level2 As String, Texto As String, Sourcefilter As BG3_Pak_SourceOfResource_Class, Deep As Boolean) As Boolean
        If Filter_Check_Source(Sourcefilter) = False Then Return False
        If Filter_Check_Level1(Level1) = False Then Return False
        If Filter_Check_Level2(Level2) = False Then Return False
        If Filter_Check_Text(Texto, Deep) = False Then Return False
        Return True
    End Function

    Public Function ReadAttribute_Or_Nothing(Attribuute As String) As String
        Dim Str As String = Nothing
        SyncLock Cached_Attributes
            If Cached_Attributes.TryGetValue(Attribuute, Str) = False Then
                Cached_Attributes.Add(Attribuute, NodeLSLIB.TryGetOrNothing(Attribuute))
            End If
            Return Cached_Attributes(Attribuute)
        End SyncLock
    End Function
    Public Function ReadAttribute_Or_Empty(Attribuute As String) As String
        Dim Str As String = ReadAttribute_Or_Nothing(Attribuute)
        If IsNothing(Str) Then Return ""
        Return Str
    End Function

    Private _CachedTXT As String = Nothing
    Private OverridesData As New List(Of String)
    Public Function Get_Attributes_TXT() As String
        Dim source = GameEngine.ProcessedFlagsAndTags
        If Not IsNothing(_CachedTXT) Then Return _CachedTXT
        OverridesData.Clear()
        Dim Builder As New StringBuilder
        Dim tabs = 0
        Dim current = Me
        Get_txt_Single(current, Builder, tabs, True)
        current = current.Parent_by_Type
        While Not IsNothing(current)
            tabs += 1
            Builder.Append("".PadLeft(tabs, vbTab) + "(inheriteds from" + ManoloSep + " ")
            Builder.Append(Chr(34) + current.MapKey + Chr(34) + " ")
            Builder.Append(ManoloSep + Chr(34) + current.Name + Chr(34))
            Builder.Append(ManoloSep + ")" + vbCrLf)
            Get_txt_Single(current, Builder, tabs, True)
            current = current.Parent_by_Type
        End While
        _CachedTXT = Builder.ToString
        Return _CachedTXT
    End Function
    Private Sub Get_txt_Single(ByRef current As BG3_Obj_Template_Class, ByRef builder As StringBuilder, ByRef tabs As Integer, UseOverride As Boolean)
        Dim override As Boolean = False
        For Each d In current.NodeLSLIB.Attributes
            If UseOverride = True AndAlso OverridesData.Contains(d.Key) Then override = True
            If override Then builder.Append("".PadLeft(tabs, vbTab) + "(Overrided) ") Else builder.Append("".PadLeft(tabs, vbTab))
            builder.Append("Attribute " + ManoloSep + Chr(34) + d.Key + Chr(34) + " " + ManoloSep + Chr(34) + current.ReadAttribute_Or_Empty(d.Key) + Chr(34) + vbCrLf)
            If UseOverride = True AndAlso override = False Then OverridesData.Add(d.Key)
            override = False
        Next
    End Sub

    Private Overloads Function Parent_by_Type() As Object
        Select Case Me.GetType
            Case GetType(BG3_Obj_Template_Class)
                Return CType(Me, BG3_Obj_Template_Class).Parent
            Case GetType(BG3_Obj_Stats_Class)
                Return CType(Me, BG3_Obj_Stats_Class).Parent
            Case GetType(BG3_Obj_TreasureTable_Class)
                Return CType(Me, BG3_Obj_TreasureTable_Class).Parent
            Case GetType(BG3_Obj_FlagsAndTags_Class)
                Return CType(Me, BG3_Obj_FlagsAndTags_Class).Parent
            Case GetType(BG3_Obj_VisualBank_Class)
                Return CType(Me, BG3_Obj_VisualBank_Class).Parent
            Case Else
                Return Parent
        End Select
    End Function

    Public Overridable Overloads ReadOnly Property Parent As BG3_Obj_Generic_Class
        Get
            ' Must be overloaded
            Return Parent_by_Type()
        End Get
    End Property

    Public Overridable Function ReadAttribute_Or_Inhterithed(Attribuute As String) As String
        Dim value As String = ReadAttribute_Or_Nothing(Attribuute)
        If IsNothing(value) AndAlso Not IsNothing(Me.Parent) Then Return Me.Parent.ReadAttribute_Or_Inhterithed(Attribuute)
        Return value
    End Function
    Public Overridable Function ReadAttribute_Or_Inhterithed_Or_Empty(Attribuute As String) As String
        Dim str = ReadAttribute_Or_Inhterithed(Attribuute)
        If IsNothing(str) Then Return ""
        Return str
    End Function

    Public MustOverride Sub Init_Necessary_Attributes()

    Private _CacheXML As String = Nothing
    Private _CacheNode As LSLib.LS.Node = Nothing
    Private _Isediting As Boolean = False

    Public ReadOnly Property IsEditing
        Get
            Return _Isediting
        End Get
    End Property
    Public Overridable Sub Edit_start()
        _Isediting = True
    End Sub
    Public Overridable Sub Write_Data()
        Me.NodeXMLZip = Me.NodeLSLIB.To_XML.To_UTAMXML.ZippedString
        Me.Clear_Cached_Data()
        _Isediting = False
    End Sub

    Public Overridable Sub Cancel_Edit()
        Me.Clear_Cached_Data()
        _Isediting = False
    End Sub


    Protected Overridable Sub Clear_Cached_Data()
        _CacheXML = Nothing
        _CacheNode = Nothing
        _CachedTXT = Nothing
        OverridesData.Clear()
        Cached_Attributes.Clear()
    End Sub
    Public Sub Clear_CacheNode_Only()
        _CacheNode = Nothing
    End Sub
    Public Overridable Sub Process_Parent_Change(NewParent As String)
        Debugger.Break()
        FuncionesHelpers.GameEngine.ProcessedGameObjectList.RemoveHyerarchy(Me)
        Cached_Attributes.Remove("ParentTemplateId")
        Cached_Attributes.TryAdd("ParentTemplateId", NewParent)
        FuncionesHelpers.GameEngine.ProcessedGameObjectList.AddHyerarchy(Me)
    End Sub
    Public ReadOnly Property NodeXML As String
        Get
            If IsNothing(_CacheXML) Then
                _CacheXML = NodeXMLZip.UnZippedString
            End If
            Return _CacheXML
        End Get
    End Property
    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.Always)>
    Public ReadOnly Property NodeLSLIB As LSLib.LS.Node
        Get
            If IsNothing(_CacheNode) Then
                If Me.SourceOfResorce.PackageType <> BG3_Enum_Package_Type.UTAM_Mod Then
                    If GameEngine.Processed = False Then
                        Debugger.Break()
                    End If
                End If
                ' Really Expensive check if cache is needed for the caller property
                _CacheNode = ResourceUtils.LoadResource(New MemoryStream(Encoding.UTF8.GetBytes(NodeXMLZip.UnZippedString)), Enums.ResourceFormat.LSX, Funciones.LoadParams_LSLIB).Regions(Funciones.ManoloRegion).Children.First.Value.First
            End If
            Return _CacheNode
        End Get
    End Property

    <Serialization.JsonIgnore(Condition:=JsonIgnoreCondition.Always)>
    Public MustOverride ReadOnly Property MapKey_Attribute As String


    Public ReadOnly Property IsModObject
        Get
            Return Not SourceOfResorce.PackageType = BG3_Enum_Package_Type.BaseGame
        End Get
    End Property

    Public Sub Create(ByRef Nod As LSLib.LS.Node, Source As BG3_Pak_SourceOfResource_Class)
        SyncLock Me
            SourceOfResorce = Source
            _CacheNode = Nod
            NodeXMLZip = _CacheNode.To_XML.To_UTAMXML.ZippedString
            ReadAttribute_Or_Nothing(MapKey_Attribute)
            Init_Necessary_Attributes()
        End SyncLock
    End Sub
    Public Sub Create(ByRef Source As BG3_Pak_SourceOfResource_Class)
        Create(Source.Filename_Relative, Source)
    End Sub
    Public Sub Create(Mapkey As String, ByRef Source As BG3_Pak_SourceOfResource_Class)
        SyncLock Me
            SourceOfResorce = Source
            NodeXMLZip = Nothing
            Cached_Attributes.TryAdd("MapKey", Mapkey)
            Init_Necessary_Attributes()
        End SyncLock
    End Sub

    Sub New()

    End Sub


End Class

#End Region








