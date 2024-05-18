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

Public MustInherit Class Generic_Editor
    Sub New()
        MyBase.New
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Flickering.EnableDoubleBuffering(BG3Selector_Template1.TreeView1)
    End Sub

    Public HandledStats As New List(Of String)
    Public HandledAttributes As New List(Of String)

    Public Property ActiveModSource As BG3_Pak_SourceOfResource_Class
    Protected Overridable Property SelectedTmp As BG3_Obj_Template_Class
    Protected Overridable Property SelectedStat As BG3_Obj_Stats_Class

    Protected Overridable ReadOnly Property Prefix As String = "UTAM_XXXX_"
    Protected Overridable ReadOnly Property UtamType As BG3_Enum_UTAM_Type = BG3_Enum_UTAM_Type.Container
    Protected Overridable ReadOnly Property DefaulStatUsing As String = ""
    Protected Overridable ReadOnly Property DefaulParent As String = ""
    Protected Overridable ReadOnly Property DefaulStat_Type As BG3_Enum_StatType = BG3_Enum_StatType.Object
    Protected Overridable Property Template_guid As String = Funciones.NewGUID(False)
    Public Sub New(ByRef MdiParent As Main, Source As BG3_Pak_SourceOfResource_Class)
        MyBase.New(MdiParent)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Initialize(MdiParent, Source)
        Me.DoubleBuffered = True

    End Sub
    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.WaitCursor
        BG3Selector_Template1.Selection = UtamType
        BG3Selector_Template1.Load_Templates(FuncionesHelpers.GameEngine.UtamTemplates)
        Cursor.Current = Cursors.Default
    End Sub
    Private Sub Explore_Node_DoubleClicked(nod As Object)
        If BG3Selector_Template1.IsEditing OrElse BG3Selector_Template1.Isclonning_or_transfering Then Exit Sub
        Select Case nod.GetType
            Case GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class))
                If Not IsNothing(CType(nod, BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class)).Objeto) Then
                    Dim obj = CType(CType(nod, BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class)).Objeto, BG3_Obj_Template_Class)
                    Dim find = BG3Selector_Template1.TreeView1.Nodes.Find(obj.MapKey, True)
                    If find.Length > 0 Then
                        BG3Selector_Template1.TreeView1.SelectedNode = find.First
                    End If
                End If
            Case GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Stats_Class))
                If Not IsNothing(CType(nod, BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Stats_Class)).Objeto) Then
                    Dim obj = CType(CType(nod, BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Stats_Class)).Objeto, BG3_Obj_Stats_Class)
                    If Not IsNothing(obj.AssociatedTemplate) Then
                        Dim find = BG3Selector_Template1.TreeView1.Nodes.Find(obj.AssociatedTemplate.MapKey, True)
                        If find.Length > 0 Then
                            BG3Selector_Template1.TreeView1.SelectedNode = find.First
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
        ActiveModSource = New BG3_Pak_SourceOfResource_Class(Source.Pak_Or_Folder, MdiParent.ActiveMod.CurrentMod.RootTemplateFilePath, BG3_Enum_Package_Type.UTAM_Mod)
        Create_Stat_Transfers()
        Habilita_Edicion_Botones(False)
        PictureBox3.AllowDrop = True
        BG3Editor_Complex_Localization1.Link_Controls({BG3Editor_Template_DisplayName1, BG3Editor_Template_Description1, BG3Editor_Template_TechnicalDescription1})
        HandledStats.Add("Type")
        HandledStats.Add("Using")
        HandledStats.Add("Weight")
        HandledStats.Add("Unique")
        HandledStats.Add("ValueOverride")
        HandledStats.Add("ValueScale")
        HandledStats.Add("ValueUUID")
        HandledStats.Add("ValueRounding")
        HandledStats.Add("ValueLevel")
        HandledStats.Add("Rarity")
        HandledStats.Add("RootTemplate")
        HandledStats.Add("MinLevel")
        HandledStats.Add("MinAmount")
        HandledStats.Add("MaxAmount")
        HandledStats.Add("InventoryTab")
        HandledStats.Add("ObjectCategory")
        HandledStats.Add("GameSize")



        HandledAttributes.Add("MapKey")
        HandledAttributes.Add("ParentTemplateId")
        HandledAttributes.Add("VisualTemplate")
        HandledAttributes.Add("Icon")
        HandledAttributes.Add("UTAM_h1")
        HandledAttributes.Add("UTAM_h2")
        HandledAttributes.Add("UTAM_h3")
        HandledAttributes.Add("UTAM_Type")
        HandledAttributes.Add("UTAM_Group")
        HandledAttributes.Add("DisplayName")
        HandledAttributes.Add("Name")
        HandledAttributes.Add("Stats")
        HandledAttributes.Add("StoryItem")
        HandledAttributes.Add("Description")
        HandledAttributes.Add("TechnicalDescription")
        HandledAttributes.Add("Type")
        HandledAttributes.Add("_OriginalFileVersion_")
        HandledAttributes.Add("maxStackAmount")

        Initialize_Specifics()
    End Sub

    Protected Overridable Sub Initialize_Specifics()
        Debugger.Break()
    End Sub

    ' Procesos Comunes Editores
    Private ReadOnly Property Stat_Default_Name
        Get
            Return Prefix + "OBJ_" + Template_guid
        End Get
    End Property

    Private Sub Habilita_Edicion_Botones(Edicion As Boolean)
        GroupBoxBasicTemplates.Enabled = Edicion
        GroupBoxVisuals.Enabled = Edicion
        GroupBoxBasicStats.Enabled = Edicion
        GroupBoxTrade.Enabled = Edicion
        GroupBox10.Enabled = Edicion
        GroupBoxInventory.Enabled = Edicion
        BG3Editor_Complex_Advanced_Stats1.ReadOnly = Edicion
        BG3Editor_Complex_Advanced_Attributes1.ReadOnly = Not Edicion
        BG3Selector_Template1.BG3Cloner1.Enabled = Not Edicion
        BG3Editor_Complex_Localization1.DataGridView1.Enabled = Edicion
        BG3Editor_Complex_WorldInjection1.Enabled = Edicion
        Habilita_Edicion_Botones_Specific(Edicion)
        Process_Selection_Change()
        If DefaulStat_Type <> BG3_Enum_StatType.Object Then BG3Editor_Stats_GameSize1.Enabled = False : BG3Editor_Stats_GameSize1.AllowEdit = False
    End Sub
    Protected Overridable Sub Habilita_Edicion_Botones_Specific(Edicion As Boolean)
        Debugger.Break()
    End Sub

    Private Sub PictureBox3_DragEnter(sender As Object, e As DragEventArgs) Handles PictureBox3.DragEnter
        If GroupBoxVisuals.Enabled = True Then BG3Editor_Template_Icon1.Control_DragEnter(sender, e)
    End Sub
    Private Sub PictureBox3_DragDrop(sender As Object, e As DragEventArgs) Handles PictureBox3.DragDrop
        If GroupBoxVisuals.Enabled = True Then BG3Editor_Template_Icon1.Control_DragDrop(sender, e)
    End Sub
    Private Sub Capture_Icon_Changed(sender As Object) Handles BG3Editor_Template_Icon1.Inside_Text_Changed
        If Not IsNothing(SelectedTmp) Then
            Dim ic As BG3_Obj_IconUV_Class = Nothing
            PictureBox3.Image = Nothing
            If FuncionesHelpers.GameEngine.ProcessedIcons.TryGetValue(BG3Editor_Template_Icon1.TextBox1.Text, ic) Then
                PictureBox3.Image = ic.Get_Icon_FromAtlass_or_File
            End If
        Else
            PictureBox3.Image = Nothing
        End If
    End Sub
    Private Sub Capture_Names_Changed(sender As Object) Handles BG3Selector_Template1.Change_Selected, BG3Editor_Complex_Localization1.LocaTextChanged
        If Not IsNothing(SelectedTmp) Then
            LabelInfoName.Text = "Name: " + BG3Editor_Complex_Localization1.Get_Localization(BG3Editor_Template_DisplayName1, SelectedTmp, FuncionesHelpers.GameEngine.Settings.SelectedLocalization)
            LabelInfoDescription.Text = "Description: " + BG3Editor_Complex_Localization1.Get_Localization(BG3Editor_Template_Description1, SelectedTmp, FuncionesHelpers.GameEngine.Settings.SelectedLocalization)
            LabelTechnical.Text = "Technical: " + BG3Editor_Complex_Localization1.Get_Localization(BG3Editor_Template_TechnicalDescription1, SelectedTmp, FuncionesHelpers.GameEngine.Settings.SelectedLocalization)
        Else
            If Not IsNothing(BG3Selector_Template1.Current_Nod) Then
                LabelInfoName.Text = "Group name: " + BG3Selector_Template1.Current_Group
                LabelInfoDescription.Text = "Number of templates: " + BG3Selector_Template1.Current_Nod.Nodes.Count.ToString
                LabelTechnical.Text = ""
            Else
                LabelInfoName.Text = "Group name: "
                LabelInfoDescription.Text = "Number of templates: "
                LabelTechnical.Text = ""
            End If
        End If
    End Sub
    Private Sub Capturle_Localization_Changed(Makpek As String, sender As Object) Handles BG3Editor_Complex_Localization1.Cell_EndEdit
        Capture_Names_Changed(sender)
    End Sub

    Private processing_Parent_change As Boolean = False
    Private Sub Capture_Parent_Changed(sender As Object) Handles BG3Editor_Template_Parent1.Inside_Text_Changed
        If processing_Parent_change = False AndAlso BG3Selector_Template1.IsEditing = True AndAlso BG3Editor_Template_Parent1.AllowEdit = True Then
            If BG3Editor_Template_Parent1.Text <> SelectedTmp.MapKey Then
                If Not IsNothing(SelectedTmp) AndAlso SelectedTmp.ReadAttribute_Or_Empty("ParentTemplateId") <> BG3Editor_Template_Parent1.Text Then
                    processing_Parent_change = True
                    SelectedTmp.Process_Parent_Change(BG3Editor_Template_Parent1.Text)
                    BG3Editor_Template_Parent1.Write(SelectedTmp)
                    Process_Selection_Change()
                    processing_Parent_change = False
                End If
            Else
                BG3Editor_Template_Parent1.Text = DefaulParent
            End If
        End If
    End Sub

    Private processing_Using_change As Boolean = False
    Private Sub Capture_Using_Changed(sender As Object) Handles BG3Editor_Stat_Using1.Inside_Text_Changed
        If processing_Using_change = False AndAlso BG3Selector_Template1.IsEditing = True AndAlso BG3Editor_Stat_Using1.AllowEdit = True Then
            If BG3Editor_Stat_Using1.Text <> SelectedStat.MapKey Then
                If Not IsNothing(SelectedStat) AndAlso SelectedStat.Using <> BG3Editor_Stat_Using1.Text Then
                    processing_Using_change = True
                    SelectedStat.Process_Parent_Change(BG3Editor_Stat_Using1.Text)
                    BG3Editor_Stat_Using1.Write(SelectedStat)
                    Process_Selection_Change()
                    processing_Using_change = False
                End If
            Else
                BG3Editor_Stat_Using1.Text = DefaulStatUsing
            End If
        End If
    End Sub

    Protected Overridable Sub Capture_Clone_specific(obj As BG3_Obj_Template_Class, tipo As BG3Cloner.Clonetype)

    End Sub


    Protected Clone_Stat_Name As String
    Protected Clone_Stat_Using As String
    Protected Clone_Nuevonod As LSLib.LS.Node
    Private Sub Capture_Clone(obj As BG3_Obj_Template_Class, tipo As BG3Cloner.Clonetype, stat As BG3_Obj_Stats_Class) Handles BG3Selector_Template1.Clone_Template
        Clone_Nuevonod = New LSLib.LS.Node
        Template_guid = Funciones.NewGUID(False)
        Clone_Stat_Name = Stat_Default_Name
        Clone_Stat_Using = DefaulStatUsing
        BG3Selector_Template1.Habilita_Edicion_Botones(True)
        Dim tempstat As BG3_Obj_Stats_Class = stat
        ' template Clone
        Select Case tipo
            Case BG3Cloner.Clonetype.None
                Create_Initial(Clone_Nuevonod)
                Capture_Clone_specific(obj, tipo)
            Case BG3Cloner.Clonetype.Inherit
                Create_Initial(Clone_Nuevonod)
                BG3Editor_Template_Parent1.Replace_Attribute(Clone_Nuevonod, obj.MapKey)
                BG3Editor_Template_Name1.Replace_Attribute(Clone_Nuevonod, obj.Name + "_Inherited")
                If Not IsNothing(tempstat) Then Clone_Stat_Using = tempstat.Name
                Capture_Clone_specific(obj, tipo)
            Case BG3Cloner.Clonetype.Clone
                Clone_Nuevonod = obj.NodeLSLIB.CloneNode
                Clone_Nuevonod.Attributes.Remove("UTAM_h1")
                Clone_Nuevonod.Attributes.Remove("UTAM_h2")
                Clone_Nuevonod.Attributes.Remove("UTAM_h3")
                Create_Initial(Clone_Nuevonod)
                Editor_Generic_GenericAttribute.Replace_Attribute_Generic(Clone_Nuevonod, "UTAM_Group", BG3Selector_Template1.Current_Group, AttributeType.FixedString)
                BG3Editor_Template_Mapkey1.Replace_Attribute(Clone_Nuevonod, Template_guid)
                BG3Editor_Template_Name1.Replace_Attribute(Clone_Nuevonod, obj.Name + "_Cloned")
                If Not IsNothing(tempstat) Then Clone_Stat_Using = tempstat.Using
                BG3Editor_Template_Stats1.Replace_Attribute(Clone_Nuevonod, Clone_Stat_Name)
                Capture_Clone_specific(obj, tipo)
            Case BG3Cloner.Clonetype.Override
                Template_guid = obj.MapKey
                Clone_Nuevonod = obj.NodeLSLIB.CloneNode
                Clone_Nuevonod.Attributes.Remove("UTAM_h1")
                Clone_Nuevonod.Attributes.Remove("UTAM_h2")
                Clone_Nuevonod.Attributes.Remove("UTAM_h3")
                Create_Initial(Clone_Nuevonod)
                Editor_Generic_GenericAttribute.Replace_Attribute_Generic(Clone_Nuevonod, "UTAM_Group", BG3Selector_Template1.Current_Group, AttributeType.FixedString)
                BG3Editor_Template_Mapkey1.Replace_Attribute(Clone_Nuevonod, obj.MapKey)
                BG3Editor_Template_Name1.Replace_Attribute(Clone_Nuevonod, obj.Name + "_Overrided")
                If obj.NodeLSLIB.TryGetOrEmpty("DisplayName") <> "" Then Editor_Generic_GenericAttribute.Replace_Attribute_Generic(Clone_Nuevonod, "UTAM_h1", obj.NodeLSLIB.TryGetOrEmpty("DisplayName"), AttributeType.TranslatedString)
                If obj.NodeLSLIB.TryGetOrEmpty("Description") <> "" Then Editor_Generic_GenericAttribute.Replace_Attribute_Generic(Clone_Nuevonod, "UTAM_h2", obj.NodeLSLIB.TryGetOrEmpty("Description"), AttributeType.TranslatedString)
                If obj.NodeLSLIB.TryGetOrEmpty("TechnicalDescription") <> "" Then Editor_Generic_GenericAttribute.Replace_Attribute_Generic(Clone_Nuevonod, "UTAM_h3", obj.NodeLSLIB.TryGetOrEmpty("TechnicalDescription"), AttributeType.TranslatedString)
                If IsNothing(tempstat) Then BG3Editor_Template_Stats1.Replace_Attribute(Clone_Nuevonod, Clone_Stat_Name)
                If Not IsNothing(tempstat) Then Clone_Stat_Name = tempstat.Name
                If Not IsNothing(tempstat) Then Clone_Stat_Using = tempstat.Using
                BG3Editor_Template_Stats1.Replace_Attribute(Clone_Nuevonod, Clone_Stat_Name)
                Capture_Clone_specific(obj, tipo)
            Case Else
                Debugger.Break()
        End Select

        SelectedTmp = FuncionesHelpers.GameEngine.ProcessedGameObjectList.Manage_Overrides(New BG3_Obj_Template_Class(Clone_Nuevonod, ActiveModSource))
        SelectedStat = FuncionesHelpers.GameEngine.ProcessedStatList.Manage_Overrides(New BG3_Obj_Stats_Class(ActiveModSource, Clone_Stat_Name) With {.Using = Clone_Stat_Using, .Type = DefaulStat_Type})

        ' Stat Clone
        Select Case tipo
            Case BG3Cloner.Clonetype.None, BG3Cloner.Clonetype.Inherit
                Editor_Stats_Generic.Create_Generic("RootTemplate", Template_guid, SelectedStat)
            Case BG3Cloner.Clonetype.Clone, BG3Cloner.Clonetype.Override
                Editor_Stats_Generic.Create_Generic("RootTemplate", Template_guid, SelectedStat)
                If Not IsNothing(tempstat) Then
                    For Each dat In tempstat.Data
                        SelectedStat.Data.TryAdd(dat.Key, dat.Value)
                    Next
                End If
            Case Else
                Debugger.Break()
        End Select

        ' Localization Clone
        Select Case tipo
            Case BG3Cloner.Clonetype.None
            Case BG3Cloner.Clonetype.Clone, BG3Cloner.Clonetype.Inherit, BG3Cloner.Clonetype.Override
                CLone_Loca(obj.NodeLSLIB.TryGetOrEmpty("DisplayName"), SelectedTmp.NodeLSLIB.TryGetOrEmpty("UTAM_h1"))
                CLone_Loca(obj.NodeLSLIB.TryGetOrEmpty("Description"), SelectedTmp.NodeLSLIB.TryGetOrEmpty("UTAM_h2"))
                CLone_Loca(obj.NodeLSLIB.TryGetOrEmpty("TechnicalDescription"), SelectedTmp.NodeLSLIB.TryGetOrEmpty("UTAM_h3"))
            Case Else
                Debugger.Break()
        End Select

        Process_Save_Objetos()
        Process_Save_Final()
    End Sub

    Private Sub CLone_Loca(OldMapkey As String, UtamHandle As String)
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
    Private Sub Capture_AddNew(Group As String) Handles BG3Selector_Template1.Add_New_Click
        Capture_Clone(Nothing, BG3Cloner.Clonetype.None, Nothing)
        BG3Selector_Template1.Habilita_Edicion_Botones(True)
        Habilita_Edicion_Botones(True)
    End Sub
    Private Sub Capture_Edit(template As BG3_Obj_Template_Class) Handles BG3Selector_Template1.Edit_Click
        If IsNothing(template) Then Exit Sub
        Process_Edit()
    End Sub
    Private Sub Capture_Cancel() Handles BG3Selector_Template1.Cancel_Click
        Process_Cancel()
    End Sub
    Private Sub Capture_Save() Handles BG3Selector_Template1.Save_Click
        Process_Save_Edits()
    End Sub
    Private Sub Capture_Delete() Handles BG3Selector_Template1.Delete_Click
        Process_delete()
    End Sub
    Protected Overridable Sub Process_Delete_Specifics()
        Debug.Print(Me.Text)
        Debugger.Break()
    End Sub

    Private Sub Process_delete()
        If MsgBox("Deleting records is a known recipe for bricking savegames!. Do you want to continue?", MsgBoxStyle.Exclamation + vbOKCancel, "Warning") = MsgBoxResult.Cancel Then Exit Sub
        BG3Editor_Complex_WorldInjection1.Borra_All()
        BG3Editor_Complex_WorldInjection1.Write_Data(SelectedStat)
        If FuncionesHelpers.GameEngine.ProcessedLocalizationList.ContainsKey(BG3Editor_Template_DisplayName1.Get_Utam_Handle(SelectedTmp)) = True Then
            FuncionesHelpers.GameEngine.ProcessedLocalizationList.Remove(BG3Editor_Template_DisplayName1.Get_Utam_Handle(SelectedTmp))
        End If
        If FuncionesHelpers.GameEngine.ProcessedLocalizationList.ContainsKey(BG3Editor_Template_Description1.Get_Utam_Handle(SelectedTmp)) = True Then
            FuncionesHelpers.GameEngine.ProcessedLocalizationList.Remove(BG3Editor_Template_Description1.Get_Utam_Handle(SelectedTmp))
        End If
        If FuncionesHelpers.GameEngine.ProcessedLocalizationList.ContainsKey(BG3Editor_Template_TechnicalDescription1.Get_Utam_Handle(SelectedTmp)) = True Then
            FuncionesHelpers.GameEngine.ProcessedLocalizationList.Remove(BG3Editor_Template_TechnicalDescription1.Get_Utam_Handle(SelectedTmp))
        End If
        FuncionesHelpers.GameEngine.UtamTemplates.Remove(SelectedTmp)
        FuncionesHelpers.GameEngine.Utamstats.Remove(SelectedStat)
        FuncionesHelpers.GameEngine.ProcessedGameObjectList.Remove(SelectedTmp)
        FuncionesHelpers.GameEngine.ProcessedStatList.Remove(SelectedStat)
        Process_Delete_Specifics()
        BG3Selector_Template1.Delete_Ended()
    End Sub
    Private Sub Capture_Selection_Change(Template As BG3_Obj_Template_Class) Handles BG3Selector_Template1.Change_Selected
        Select_Objects(Template)
        Process_Selection_Change()
    End Sub

    Protected Overridable Sub Select_Objects_Specifics()
        Debug.Print(Me.Text)
        Debugger.Break()
    End Sub
    Private Sub Select_Objects(Template As BG3_Obj_Template_Class)
        If Not IsNothing(Template) AndAlso Not IsNothing(Template.AssociatedStats) Then
            SelectedTmp = Template
            SelectedStat = Template.AssociatedStats
            Select_Objects_Specifics()
        Else
            SelectedTmp = Nothing
            SelectedStat = Nothing
            Select_Objects_Specifics()
        End If
    End Sub

    Private Sub Create_Initial(ByRef nuevonod As LSLib.LS.Node)
        BG3Editor_Template_Mapkey1.Create_Attribute(nuevonod, Template_guid)
        BG3Editor_Template_Name1.Create_Attribute(nuevonod, Prefix + Template_guid)
        BG3Editor_Template_Type1.Create_Attribute(nuevonod, "item")
        BG3Editor_Template_Parent1.Create_Attribute(nuevonod, DefaulParent)
        BG3Editor_Template_Stats1.Create_Attribute(nuevonod, Stat_Default_Name)
        BG3Editor_Template_StoryItem1.Create_Attribute(nuevonod, "False")
        BG3Editor_Template_DisplayName1.Create_Attribute(nuevonod, Funciones.NewGUID(True) + ";1")
        BG3Editor_Template_Description1.Create_Attribute(nuevonod, Funciones.NewGUID(True) + ";1")
        BG3Editor_Template_TechnicalDescription1.Create_Attribute(nuevonod, Funciones.NewGUID(True) + ";1")
        Create_Initial_Specific(nuevonod)
        Add_UTAM_Attribute(nuevonod)
    End Sub
    Private Sub Add_UTAM_Attribute(ByRef nuevonod As LSLib.LS.Node)
        Editor_Generic_GenericAttribute.Create_Attribute_Generic(nuevonod, "UTAM_Type", UtamType, AttributeType.FixedString)
        Editor_Generic_GenericAttribute.Create_Attribute_Generic(nuevonod, "UTAM_Group", BG3Selector_Template1.Current_Group, AttributeType.FixedString)
        Add_UTAM_Attribute_Specific(nuevonod)
    End Sub

    Protected Overridable Sub Add_UTAM_Attribute_Specific(ByRef nuevonod As LSLib.LS.Node)
        Debug.Print(Me.Text)
        Debugger.Break()
    End Sub

    Protected Overridable Sub Create_Initial_Specific(ByRef nuevonod As LSLib.LS.Node)
        Debug.Print(Me.Text)
        Debugger.Break()
    End Sub

    Protected Overridable Sub Process_Selection_Change_specific()
        Debug.Print(Me.Text)
        Debugger.Break()
    End Sub

    Private Sub Process_Selection_Change()
        If Not IsNothing(SelectedTmp) Then
            Add_UTAM_Attribute(SelectedTmp.NodeLSLIB)
            BG3Editor_Complex_Localization1.Read_Data(SelectedTmp)
            BG3Editor_Template_Mapkey1.Read(SelectedTmp)
            BG3Editor_Template_Name1.Read(SelectedTmp)
            BG3Selector_Template1.BG3Editor_Template_UtamGroup1.Read(SelectedTmp)
            BG3Editor_Template_Parent1.Read(SelectedTmp)
            BG3Editor_Template_Type1.Read(SelectedTmp)
            BG3Editor_Template_StoryItem1.Read(SelectedTmp)
            BG3Editor_Template_VisualTemplate1.Read(SelectedTmp)
            BG3Editor_Template_Icon1.Read(SelectedTmp)
            BG3Editor_Template_DisplayName1.Read(SelectedTmp)
            BG3Editor_Template_Description1.Read(SelectedTmp)
            BG3Editor_Template_TechnicalDescription1.Read(SelectedTmp)
            BG3Editor_Template_Stats1.Read(SelectedTmp)
            BG3Editor_Template_maxStackAmount1.Read(SelectedTmp)
            BG3Editor_Stat_Type1.Read(SelectedStat)
            BG3Editor_Stat_Rarity1.Read(SelectedStat)
            BG3Editor_Stat_Weight1.Read(SelectedStat)
            BG3Editor_Stat_Using1.Read(SelectedStat)
            BG3Editor_Stat_Unique1.Read(SelectedStat)
            BG3Editor_Stats_Valueuuid1.Read(SelectedStat)
            BG3Editor_Stats_ValueScale1.Read(SelectedStat)
            BG3Editor_Stats_ValueLevel1.Read(SelectedStat)
            BG3Editor_Stat_ValueOverride1.Read(SelectedStat)
            BG3Editor_Stats_ValueRounding1.Read(SelectedStat)
            BG3Editor_Stats_MinLevel1.Read(SelectedStat)
            BG3Editor_Stats_MinAmount1.Read(SelectedStat)
            BG3Editor_Stats_MaxAmount1.Read(SelectedStat)
            BG3Editor_Stats_InventoryTab1.Read(SelectedStat)
            BG3Editor_Stats_ObjectCategory1.Read(SelectedStat)
            BG3Editor_Stats_GameSize1.Read(SelectedStat)
            Process_Selection_Change_specific()
            BG3Editor_Complex_Advanced_Attributes1.Read(SelectedTmp)
            BG3Editor_Complex_Advanced_Stats1.Read(SelectedStat)
            BG3Editor_Complex_WorldInjection1.Read_Data(SelectedStat)
            BG3Editor_Complex_Tags1.Read(SelectedTmp)
        Else
            BG3Editor_Complex_Localization1.Clear()
            BG3Editor_Template_Mapkey1.Clear()
            BG3Editor_Template_Name1.Clear()
            BG3Selector_Template1.BG3Editor_Template_UtamGroup1.Clear()
            BG3Editor_Template_Parent1.Clear()
            BG3Editor_Template_Type1.Clear()
            BG3Editor_Template_StoryItem1.Clear()
            BG3Editor_Template_VisualTemplate1.Clear()
            BG3Editor_Template_Icon1.Clear()
            BG3Editor_Template_DisplayName1.Clear()
            BG3Editor_Template_Description1.Clear()
            BG3Editor_Template_TechnicalDescription1.Clear()
            BG3Editor_Template_maxStackAmount1.Clear()
            BG3Editor_Template_Stats1.Clear()
            BG3Editor_Stat_Type1.Clear()
            BG3Editor_Stat_Rarity1.Clear()
            BG3Editor_Stat_Weight1.Clear()
            BG3Editor_Stat_Using1.Clear()
            BG3Editor_Stats_Valueuuid1.Clear()
            BG3Editor_Stats_ValueScale1.Clear()
            BG3Editor_Stats_ValueLevel1.Clear()
            BG3Editor_Stat_ValueOverride1.Clear()
            BG3Editor_Stats_ValueRounding1.Clear()
            BG3Editor_Stats_MinLevel1.Clear()
            BG3Editor_Stat_Unique1.Clear()
            BG3Editor_Stats_MinAmount1.Clear()
            BG3Editor_Stats_MaxAmount1.Clear()
            BG3Editor_Stats_InventoryTab1.Clear()
            BG3Editor_Stats_ObjectCategory1.Clear()
            BG3Editor_Stats_GameSize1.Clear()
            Process_Selection_Change_specific()
            BG3Editor_Complex_Advanced_Attributes1.Clear()
            BG3Editor_Complex_Advanced_Stats1.Clear()
            BG3Editor_Complex_WorldInjection1.Clear()
            BG3Editor_Complex_Tags1.Clear()
        End If
    End Sub
    Protected Overridable Sub Process_Save_Edits_Specifics()
        Debug.Print(Me.Text)
        Debugger.Break()
    End Sub

    Private Sub Process_Save_Edits()
        BG3Editor_Template_Mapkey1.Write(SelectedTmp)
        If BG3Editor_Template_Name1.Text <> "" Then BG3Editor_Template_Name1.Write(SelectedTmp)
        BG3Selector_Template1.BG3Editor_Template_UtamGroup1.Write(SelectedTmp)
        BG3Editor_Template_Parent1.Write(SelectedTmp)
        BG3Editor_Template_Type1.Write(SelectedTmp)
        BG3Editor_Template_StoryItem1.Write(SelectedTmp)
        BG3Editor_Template_VisualTemplate1.Write(SelectedTmp)
        BG3Editor_Template_Icon1.Write(SelectedTmp)
        BG3Editor_Template_DisplayName1.Write(SelectedTmp)
        BG3Editor_Template_Description1.Write(SelectedTmp)
        BG3Editor_Template_TechnicalDescription1.Write(SelectedTmp)
        BG3Editor_Template_Stats1.Write(SelectedTmp)
        BG3Editor_Template_maxStackAmount1.Write(SelectedTmp)
        BG3Editor_Stat_Type1.Write(SelectedStat)
        BG3Editor_Stat_Rarity1.Write(SelectedStat)
        BG3Editor_Stat_Unique1.Write(SelectedStat)
        BG3Editor_Stat_Weight1.Write(SelectedStat)
        BG3Editor_Stat_ValueOverride1.Write(SelectedStat)
        BG3Editor_Stat_Using1.Write(SelectedStat)
        BG3Editor_Stats_Valueuuid1.Write(SelectedStat)
        BG3Editor_Stats_ValueScale1.Write(SelectedStat)
        BG3Editor_Stats_ValueLevel1.Write(SelectedStat)
        BG3Editor_Stat_ValueOverride1.Write(SelectedStat)
        BG3Editor_Stats_ValueRounding1.Write(SelectedStat)
        BG3Editor_Stats_MinLevel1.Write(SelectedStat)
        BG3Editor_Stats_MinAmount1.Write(SelectedStat)
        BG3Editor_Stats_MaxAmount1.Write(SelectedStat)
        BG3Editor_Stats_InventoryTab1.Write(SelectedStat)
        BG3Editor_Stats_ObjectCategory1.Write(SelectedStat)
        BG3Editor_Stats_GameSize1.Write(SelectedStat)
        BG3Editor_Complex_Tags1.Write(SelectedTmp)
        Process_Save_Edits_Specifics()
        Process_Save_Objetos()
        Process_Save_Final()
        Habilita_Edicion_Botones(False)
    End Sub

    Protected Overridable Sub Process_Save_Objetos_Specifics()
        Debug.Print(Me.Text)
        Debugger.Break()
    End Sub
    Private Sub Process_Save_Objetos()
        SelectedTmp.Write_Data()
        SelectedStat.Write_Data()
        Process_Save_Objetos_Specifics()
        BG3Editor_Complex_Localization1.Write_Data()
        BG3Editor_Complex_WorldInjection1.Write_Data(SelectedStat)
    End Sub
    Private Sub Process_Save_Final()
        BG3Selector_Template1.Edit_Ended(SelectedTmp)
    End Sub

    Protected Overridable Sub Process_Edit_Specifics()
        Debug.Print(Me.Text)
        Debugger.Break()

    End Sub

    Private Sub Process_Edit()
        SelectedTmp.Edit_start()
        SelectedStat.Edit_start()
        Process_Edit_Specifics()
        Habilita_Edicion_Botones(True)
    End Sub
    Protected Overridable Sub Process_Cancel_Specifics()
        Debug.Print(Me.Text)
        Debugger.Break()
    End Sub

    Private Sub Process_Cancel()
        SelectedTmp.Cancel_Edit()
        SelectedStat.Cancel_Edit()
        Process_Cancel_Specifics()
        Habilita_Edicion_Botones(False)
        BG3Selector_Template1.Edit_Ended(SelectedTmp)
    End Sub

    Private Sub Create_Stat_Transfers()
#Disable Warning CA1861 ' Evitar matrices constantes como argumentos
        Dim lista As New List(Of ToolStripMenuItem) From {
           New ToolStripMenuItem("Stats|Rarity|True|Data", Nothing, AddressOf BG3Selector_Template1.TransferSibligsClick) With {.Tag = {"Rarity"}},
           New ToolStripMenuItem("Stats|Unique|True|Data", Nothing, AddressOf BG3Selector_Template1.TransferSibligsClick) With {.Tag = {"Unique"}},
           New ToolStripMenuItem("Template|Story item|True|Attribute", Nothing, AddressOf BG3Selector_Template1.TransferSibligsClick) With {.Tag = {"StoryItem"}},
           New ToolStripMenuItem("Template|Icon|False|Attribute", Nothing, AddressOf BG3Selector_Template1.TransferSibligsClick) With {.Tag = {"Icon"}},
           New ToolStripMenuItem("Stats|Trade settings|False|Data", Nothing, AddressOf BG3Selector_Template1.TransferSibligsClick) With {.Tag = {"Trade"}},
           New ToolStripMenuItem("Stats|Object category|True|Data", Nothing, AddressOf BG3Selector_Template1.TransferSibligsClick) With {.Tag = {"ObjectCategory"}},
           New ToolStripMenuItem("Stats|Minimum level|True|Data", Nothing, AddressOf BG3Selector_Template1.TransferSibligsClick) With {.Tag = {"MinLevel"}},
           New ToolStripMenuItem("Stats|Inventory settings|False|Data", Nothing, AddressOf BG3Selector_Template1.TransferSibligsClick) With {.Tag = {"Inventory"}},
            New ToolStripMenuItem("Stats|Game size|True|Data", Nothing, AddressOf BG3Selector_Template1.TransferSibligsClick) With {.Tag = {"GameSize"}},
           New ToolStripMenuItem("Stats|Using|True|Data", Nothing, AddressOf BG3Selector_Template1.TransferSibligsClick) With {.Tag = {"Using"}},
           New ToolStripMenuItem("Stats|Value override|False|Data", Nothing, AddressOf BG3Selector_Template1.TransferSibligsClick) With {.Tag = {"Valueoverride"}},
           New ToolStripMenuItem("Template|Visual template|False|Attribute", Nothing, AddressOf BG3Selector_Template1.TransferSibligsClick) With {.Tag = {"VisualTemplate"}}
        }
#Enable Warning CA1861 ' Evitar matrices constantes como argumentos

        Create_Stat_Transfers_Specific(lista)

        Dim Cats = lista.OrderBy(Function(pf) pf.Text).Select(Function(pf) pf.Text.Split("|")(0)).Distinct.ToArray

        For Each cat In Cats
            Dim indx = BG3Selector_Template1.PropertiesToolStripMenuItem.DropDown.Items.Add(New ToolStripMenuItem(cat))
            Dim indx2 = BG3Selector_Template1.SplitGroupButton.DropDown.Items.Add(New ToolStripMenuItem(cat))
            Dim indx3 = BG3Selector_Template1.PropertiesToolStripMenuItem1.DropDown.Items.Add(New ToolStripMenuItem(cat))
            For Each it In lista.Where(Function(pf) pf.Text.Split("|")(0) = cat).OrderBy(Function(pq) pq.Text.Split("|")(1)).Select(Function(pf) pf)
                Dim splitstr = it.Text.Split("|")
                If splitstr(2) = "True" Then
                    Dim splitx = New ToolStripMenuItem(splitstr(1), Nothing, AddressOf BG3Selector_Template1.SplitGroup) With {.Tag = CType(it.Tag, String()).Select(Function(pf) splitstr(3) + "|" + pf).ToArray}
                    CType(BG3Selector_Template1.SplitGroupButton.DropDown.Items(indx2), ToolStripMenuItem).DropDown.Items.Add(splitx)
                End If

                it.Text = splitstr(1)
                CType(BG3Selector_Template1.PropertiesToolStripMenuItem.DropDown.Items(indx), ToolStripMenuItem).DropDown.Items.Add(it)
                Dim Toall = New ToolStripMenuItem(it.Text, Nothing, AddressOf BG3Selector_Template1.TransferAllClick) With {.Tag = it.Tag}
                CType(BG3Selector_Template1.PropertiesToolStripMenuItem1.DropDown.Items(indx3), ToolStripMenuItem).DropDown.Items.Add(Toall)
            Next
        Next
    End Sub
    Protected Overridable Sub Create_Stat_Transfers_Specific(ByRef Lista As List(Of ToolStripMenuItem))
        Debug.Print(Me.Text)
        Debugger.Break()
#Disable Warning IDE0079 ' Quitar supresión innecesaria
#Disable Warning CA1861 ' Evitar matrices constantes como argumentos
        Lista.AddRange(Array.Empty(Of ToolStripMenuItem))
#Enable Warning CA1861 ' Evitar matrices constantes como argumentos
#Enable Warning IDE0079 ' Quitar supresión innecesaria
    End Sub
    Protected Overridable Sub Transfer_stats_specifics(Template As BG3_Obj_Template_Class, statsList() As String)
        Debug.Print(Me.Text)
        Debugger.Break()
    End Sub

    Private Sub Transfer_SaveOriginal()
        Transfer_Stat = SelectedStat
        Transfer_SaveOriginal_Specific()
    End Sub
    Protected Overridable Sub Transfer_SaveOriginal_Specific()
    End Sub

    Protected Transfer_Stat As BG3_Obj_Stats_Class

    Private Sub Transfer_stats(Template As BG3_Obj_Template_Class, statsList() As String, nods As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class)) Handles BG3Selector_Template1.Transfer_Stats
        Transfer_SaveOriginal()
        For Each nod As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class) In nods.Nodes
            Dim obj As BG3_Obj_Template_Class = nod.Objeto
            If obj IsNot Template Then
                obj.Edit_start()
                Select_Objects(obj)
                For Each stat In statsList
                    Select Case stat
                        Case "VisualTemplate"
                            BG3Editor_Template_VisualTemplate1.Read(Template)
                            BG3Editor_Template_VisualTemplate1.Write(obj)
                        Case "Icon"
                            BG3Editor_Template_Icon1.Read(Template)
                            BG3Editor_Template_Icon1.Write(obj)
                        Case "Storyitem"
                            BG3Editor_Template_StoryItem1.Read(Template)
                            BG3Editor_Template_StoryItem1.Write(obj)
                        Case "Unique"
                            BG3Editor_Stat_Unique1.Read(Transfer_Stat)
                            BG3Editor_Stat_Unique1.Write(SelectedStat)
                        Case "Rarity"
                            BG3Editor_Stat_Rarity1.Read(Transfer_Stat)
                            BG3Editor_Stat_Rarity1.Write(SelectedStat)
                        Case "Trade"
                            BG3Editor_Stat_ValueOverride1.Read(Transfer_Stat)
                            BG3Editor_Stat_ValueOverride1.Write(SelectedStat)
                            BG3Editor_Stats_Valueuuid1.Read(Transfer_Stat)
                            BG3Editor_Stats_Valueuuid1.Write(SelectedStat)
                            BG3Editor_Stats_ValueScale1.Read(Transfer_Stat)
                            BG3Editor_Stats_ValueScale1.Write(SelectedStat)
                            BG3Editor_Stats_ValueRounding1.Read(Transfer_Stat)
                            BG3Editor_Stats_ValueRounding1.Write(SelectedStat)
                            BG3Editor_Stats_ValueLevel1.Read(Transfer_Stat)
                            BG3Editor_Stats_ValueLevel1.Write(SelectedStat)
                        Case "Using"
                            BG3Editor_Stat_Using1.Read(Transfer_Stat)
                            BG3Editor_Stat_Using1.Write(SelectedStat)
                        Case "ObjectCategory"
                            BG3Editor_Stats_ObjectCategory1.Read(Transfer_Stat)
                            BG3Editor_Stats_ObjectCategory1.Write(SelectedStat)
                        Case "MinLevel"
                            BG3Editor_Stats_MinLevel1.Read(Transfer_Stat)
                            BG3Editor_Stats_MinLevel1.Write(SelectedStat)
                        Case "GameSize"
                            BG3Editor_Stats_GameSize1.Read(Transfer_Stat)
                            BG3Editor_Stats_GameSize1.Write(SelectedStat)
                        Case "Inventory"
                            BG3Editor_Stat_Weight1.Read(Transfer_Stat)
                            BG3Editor_Stat_Weight1.Write(SelectedStat)
                            BG3Editor_Stats_InventoryTab1.Read(Transfer_Stat)
                            BG3Editor_Stats_InventoryTab1.Write(SelectedStat)
                            BG3Editor_Stats_MaxAmount1.Read(Transfer_Stat)
                            BG3Editor_Stats_MaxAmount1.Write(SelectedStat)
                            BG3Editor_Stats_MinAmount1.Read(Transfer_Stat)
                            BG3Editor_Stats_MinAmount1.Write(SelectedStat)
                            BG3Editor_Template_maxStackAmount1.Read(Template)
                            BG3Editor_Template_maxStackAmount1.Write(obj)
                        Case Else
                            Transfer_stats_specifics(Template, statsList)
                    End Select
                Next
                SelectedTmp.Write_Data()
                SelectedStat.Write_Data()
            End If
        Next
        BG3Selector_Template1.Edit_Ended(Template)
    End Sub
    Private Sub Transfer_Handles(Template As BG3_Obj_Template_Class, cual As Integer, nods As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class)) Handles BG3Selector_Template1.Transfer_Localization
        For Each nod As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class) In nods.Nodes
            Dim obj As BG3_Obj_Template_Class = nod.Objeto
            If obj IsNot Template Then
                obj.Edit_start()
                Select Case cual
                    Case 0, 1
                        If Template.NodeLSLIB.TryGetOrEmpty("UTAM_h1") <> "" Then
                            Editor_Generic_GenericAttribute.Replace_Attribute_Generic(obj.NodeLSLIB, "UTAM_h1", Template.NodeLSLIB.TryGetOrEmpty("UTAM_h1"), AttributeType.TranslatedString)
                        End If
                    Case 0, 2
                        If Template.NodeLSLIB.TryGetOrEmpty("UTAM_h2") <> "" Then
                            Editor_Generic_GenericAttribute.Replace_Attribute_Generic(obj.NodeLSLIB, "UTAM_h2", Template.NodeLSLIB.TryGetOrEmpty("UTAM_h2"), AttributeType.TranslatedString)
                        End If
                    Case 0, 3
                        If Template.NodeLSLIB.TryGetOrEmpty("UTAM_h3") <> "" Then
                            Editor_Generic_GenericAttribute.Replace_Attribute_Generic(obj.NodeLSLIB, "UTAM_h3", Template.NodeLSLIB.TryGetOrEmpty("UTAM_h3"), AttributeType.TranslatedString)
                        End If
                End Select

                obj.Write_Data()
            End If
        Next

        BG3Selector_Template1.Edit_Ended(Template)
    End Sub

    Private Sub Transfer_Tags(Template As BG3_Obj_Template_Class, nods As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class)) Handles BG3Selector_Template1.Transfer_Tags
        For Each nod As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class) In nods.Nodes
            Dim obj As BG3_Obj_Template_Class = nod.Objeto
            If obj IsNot Template Then
                BG3Editor_Complex_Tags1.Read(Template)
                obj.Edit_start()
                BG3Editor_Complex_Tags1.Write(obj)
                obj.Write_Data()
            End If
        Next

        BG3Editor_Complex_Tags1.Read(Template)
        BG3Selector_Template1.Edit_Ended(Template)
    End Sub
    Private Sub Transfer_WorldInjection(Template As BG3_Obj_Template_Class, nods As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class)) Handles BG3Selector_Template1.Transfer_WorldInject
        For Each nod As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class) In nods.Nodes
            Dim obj As BG3_Obj_Template_Class = nod.Objeto
            If obj IsNot Template Then
                ' Borra nuevo
                BG3Editor_Complex_WorldInjection1.Read_Data(obj.AssociatedStats)
                BG3Editor_Complex_WorldInjection1.Borra_All()
                ' Copia viejo
                BG3Editor_Complex_WorldInjection1.Read_Data(Template.AssociatedStats)
                ' Escribe nuevo
                BG3Editor_Complex_WorldInjection1.Write_Data(obj.AssociatedStats)
            End If
        Next
        BG3Editor_Complex_WorldInjection1.Read_Data(Template.AssociatedStats)
        BG3Selector_Template1.Edit_Ended(Template)
    End Sub

    Private Sub Generic_Editor_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If BG3Selector_Template1.IsEditing = True Then
            MsgBox("Save or cancel changes before closing", vbOKOnly, "Changes not saved")
            e.Cancel = True
        End If
    End Sub

    Private Sub FillSplit(ByVal Attr_or_data As String, ByRef selectedtmp As BG3_Obj_Template_Class, ByRef selectedstat As BG3_Obj_Stats_Class, ByRef suffix As String) Handles BG3Selector_Template1.FillSplit
        Select Case Attr_or_data
            Case Else
                FillSplit_specific(Attr_or_data, selectedtmp, selectedstat, suffix)
        End Select

    End Sub
    Protected Overridable Sub FillSplit_specific(ByVal Attr_or_data As String, ByRef selectedtmp As BG3_Obj_Template_Class, ByRef selectedstat As BG3_Obj_Stats_Class, ByRef suffix As String)

    End Sub
    Private Sub BG3Cloner1_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub TabPageAttributes_Click(sender As Object, e As EventArgs) Handles TabPageAttributes.Click

    End Sub

    'Private Sub ButtonUsingClone_Click(sender As Object, e As EventArgs)
    '    If MsgBox("This will change stats inheritance and can not be undone once saved. Do you want to continue?", MsgBoxStyle.Exclamation + vbOKCancel, "Warning") = MsgBoxResult.Cancel Then Exit Sub
    '    If Not IsNothing(SelectedStat) AndAlso Not IsNothing(SelectedTmp) Then
    '        If Not IsNothing(SelectedTmp.Parent) AndAlso Not IsNothing(SelectedTmp.Parent.AssociatedStats) Then
    '            SelectedStat.Data.Clear()

    '            For Each dat In SelectedTmp.Parent.AssociatedStats.Data
    '                SelectedStat.Data.TryAdd(dat.Key, dat.Value)
    '            Next
    '            SelectedStat.Using = SelectedTmp.Parent.AssociatedStats.Using
    '        End If
    '    End If
    '    ButtonUsingClone.Enabled = False
    '    Process_Selection_Change()
    'End Sub
End Class