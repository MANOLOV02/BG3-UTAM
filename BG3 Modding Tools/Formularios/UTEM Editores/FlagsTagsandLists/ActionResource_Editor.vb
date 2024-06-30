Imports System.Collections.Concurrent
Imports System.ComponentModel
Imports System.DirectoryServices
Imports System.Drawing.Design
Imports System.Runtime.InteropServices.Marshalling
Imports System.Windows.Forms.VisualStyles
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Xml
Imports Accessibility
Imports LSLib.Granny
Imports LSLib.Granny.Model
Imports LSLib.LS
Imports LSLib.LS.Story

Public Class ActionResource_Editor
    Sub New()
        MyBase.New
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Flickering.EnableDoubleBuffering(BG3Selector_FlagsandTags1.TreeView1)
    End Sub

    Public HandledAttributes As New List(Of String)
    Public HandledNodes As New List(Of String)

    Protected Overridable Property NameNod As String = "ActionResourceDefinition"
    Public Property ActiveModSource As BG3_Pak_SourceOfResource_Class
    Protected Overridable Property SelectedTmp As BG3_Obj_FlagsAndTags_Class
    Protected Overridable ReadOnly Property Prefix As String = "UTAM_XXXX_"
    Protected Overridable ReadOnly Property UtamType As BG3_Enum_UTAM_Type = BG3_Enum_UTAM_Type.ActionResource
    Protected Overridable ReadOnly Property DefaulParent As String = ""
    Protected Overridable Property Template_guid As String = Funciones.NewGUID(False)
    Public Sub New(ByRef MdiParent As Main, Source As BG3_Pak_SourceOfResource_Class)
        MyBase.New(MdiParent)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Initialize(MdiParent, Source)
        Me.DoubleBuffered = True
        Flickering.EnableDoubleBuffering(BG3Selector_FlagsandTags1.TreeView1)
        BG3Selector_FlagsandTags1.BG3Cloner1.RadioButtonInherit.Enabled = False
        BG3Selector_FlagsandTags1.BG3Cloner1.RadioButtonClone.Checked = True
        BG3Selector_FlagsandTags1.ByInheritingToolStripMenuItem.Enabled = False
        BG3Selector_FlagsandTags1.WorldInjectionToolStripMenuItem.Visible = False
        BG3Selector_FlagsandTags1.TreasureTablesToolStripMenuItem.Visible = False
        BG3Selector_FlagsandTags1.TagsToolStripMenuItem.Visible = False
        BG3Selector_FlagsandTags1.TagsToolStripMenuItem1.Visible = False
        BG3Selector_FlagsandTags1.LocalizationToolStripMenuItem.Visible = False
        BG3Selector_FlagsandTags1.BG3Cloner1.CheckBoxCopyLeveled.Enabled = False
        BG3Selector_FlagsandTags1.BG3Cloner1.CheckBoxSkipGarbage.Enabled = False
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
    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.WaitCursor
        BG3Selector_FlagsandTags1.Selection = UtamType
        BG3Selector_FlagsandTags1.Load_Templates(FuncionesHelpers.GameEngine.Utamflagsandtags)
        Cursor.Current = Cursors.Default
    End Sub
    Private Sub Explore_Node_DoubleClicked(nod As Object)
        If BG3Selector_FlagsandTags1.IsEditing OrElse BG3Selector_FlagsandTags1.Isclonning_or_transfering Then Exit Sub
        Select Case nod.GetType
            Case GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class))
                If Not IsNothing(CType(nod, BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class)).Objeto) Then
                    Dim obj = CType(CType(nod, BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class)).Objeto, BG3_Obj_Template_Class)
                    Dim find = BG3Selector_FlagsandTags1.TreeView1.Nodes.Find(obj.MapKey, True)
                    If find.Length > 0 Then
                        BG3Selector_FlagsandTags1.TreeView1.SelectedNode = find.First
                    End If
                End If
            Case GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Stats_Class))
                If Not IsNothing(CType(nod, BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Stats_Class)).Objeto) Then
                    Dim obj = CType(CType(nod, BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Stats_Class)).Objeto, BG3_Obj_Stats_Class)
                    If Not IsNothing(obj.AssociatedTemplate) Then
                        Dim find = BG3Selector_FlagsandTags1.TreeView1.Nodes.Find(obj.AssociatedTemplate.MapKey, True)
                        If find.Length > 0 Then
                            BG3Selector_FlagsandTags1.TreeView1.SelectedNode = find.First
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
        ActiveModSource = New BG3_Pak_SourceOfResource_Class(Source.Pak_Or_Folder, MdiParent.ActiveMod.CurrentMod.TagsPath, BG3_Enum_Package_Type.UTAM_Mod)
        Create_Stat_Transfers()
        Habilita_Edicion_Botones(False)
        BG3Editor_Complex_Localization1.Link_Controls({BG3Editor_FlagsandTag_DisplayName1, BG3Editor_FlagsandTag_TranslatedDescription1, BG3Editor_FlagsandTag_TranslatedError1})

        HandledAttributes.Add("UUID")
        HandledAttributes.Add("Name")
        HandledAttributes.Add("Description")
        HandledAttributes.Add("Error")
        HandledAttributes.Add("DiceType")
        HandledAttributes.Add("UTAM_h1")
        HandledAttributes.Add("UTAM_h2")
        HandledAttributes.Add("UTAM_h3")
        HandledAttributes.Add("UTAM_Type")
        HandledAttributes.Add("UTAM_Group")
        HandledAttributes.Add("DisplayName")
        HandledAttributes.Add("MaxLevel")
        HandledAttributes.Add("MaxValue")
        HandledAttributes.Add("ReplenishType")
        HandledAttributes.Add("UpdatesSpellPowerLevel")
        HandledAttributes.Add("ShowOnActionResourcePanel")
        HandledAttributes.Add("PartyActionResource")
        HandledAttributes.Add("IsSpellResource")
        HandledAttributes.Add("IsHidden")
        HandledAttributes.Add("_OriginalFileVersion_")


        Initialize_Specifics()
    End Sub

    Protected Overridable Sub Initialize_Specifics()
    End Sub

    ' Procesos Comunes Editores
    Private Sub Habilita_Edicion_Botones(Edicion As Boolean)
        GroupBoxBasicTemplates.Enabled = Edicion
        BG3Editor_Complex_Advanced_Attributes1.ReadOnly = Not Edicion
        BG3Selector_FlagsandTags1.BG3Cloner1.Enabled = Not Edicion
        BG3Editor_Complex_Localization1.DataGridView1.Enabled = Edicion
        Habilita_Edicion_Botones_Specific(Edicion)
        Process_Selection_Change()
    End Sub
    Protected Overridable Sub Habilita_Edicion_Botones_Specific(Edicion As Boolean)
    End Sub

    Private Sub Capture_Names_Changed(sender As Object) Handles BG3Selector_FlagsandTags1.Change_Selected, BG3Editor_Complex_Localization1.LocaTextChanged
        If Not IsNothing(SelectedTmp) Then
            LabelInfoName.Text = "Display name: " + BG3Editor_Complex_Localization1.Get_Localization(BG3Editor_FlagsandTag_DisplayName1, SelectedTmp, FuncionesHelpers.GameEngine.Settings.SelectedLocalization)
            LabelInfoDescription.Text = "Display description: " + BG3Editor_Complex_Localization1.Get_Localization(BG3Editor_FlagsandTag_TranslatedDescription1, SelectedTmp, FuncionesHelpers.GameEngine.Settings.SelectedLocalization)
            LabelTechnical.Text = "Display error: " + BG3Editor_Complex_Localization1.Get_Localization(BG3Editor_FlagsandTag_TranslatedError1, SelectedTmp, FuncionesHelpers.GameEngine.Settings.SelectedLocalization)
        Else
            If Not IsNothing(BG3Selector_FlagsandTags1.Current_Nod) Then
                LabelInfoName.Text = "Group name: " + BG3Selector_FlagsandTags1.Current_Group
                LabelInfoDescription.Text = "Number of templates: " + BG3Selector_FlagsandTags1.Current_Nod.Nodes.Count.ToString
                LabelTechnical.Text = ""
            Else
                LabelInfoName.Text = "Group name: "
                LabelInfoDescription.Text = "Number of templates: "
                LabelTechnical.Text = ""
            End If
        End If
    End Sub

    Protected Overridable Sub Capture_Clone_specific(obj As BG3_Obj_FlagsAndTags_Class, tipo As BG3Cloner.Clonetype)

    End Sub


    Protected Clone_Stat_Name As String
    Protected Clone_Stat_Using As String
    Protected Clone_Nuevonod As LSLib.LS.Node
    Private Sub Capture_Clone(obj As BG3_Obj_FlagsAndTags_Class, tipo As BG3Cloner.Clonetype) Handles BG3Selector_FlagsandTags1.Clone_tag
        Clone_Nuevonod = New LSLib.LS.Node With {.Name = NameNod}
        Template_guid = Funciones.NewGUID(False)
        BG3Selector_FlagsandTags1.Habilita_Edicion_Botones(True)
        ' template Clone
        Select Case tipo
            Case BG3Cloner.Clonetype.None
                Create_Initial(Clone_Nuevonod)
                Capture_Clone_specific(obj, tipo)
            Case BG3Cloner.Clonetype.Inherit
                Debugger.Break()
            Case BG3Cloner.Clonetype.Clone
                Clone_Nuevonod = obj.NodeLSLIB.CloneNode
                Clone_Nuevonod.Attributes.Remove("UTAM_h1")
                Clone_Nuevonod.Attributes.Remove("UTAM_h2")
                Clone_Nuevonod.Attributes.Remove("UTAM_h3")
                Create_Initial(Clone_Nuevonod)
                Editor_Generic_GenericAttribute.Replace_Attribute_Generic(Clone_Nuevonod, "UTAM_Group", BG3Selector_FlagsandTags1.Current_Group, AttributeType.FixedString)
                BG3Editor_FlagsAndTags_uuid1.Replace_Attribute(Clone_Nuevonod, Template_guid)
                BG3Editor_FlagsAndTag_Name1.Replace_Attribute(Clone_Nuevonod, obj.Name + "_Cloned")
                Capture_Clone_specific(obj, tipo)
            Case BG3Cloner.Clonetype.Override
                Template_guid = obj.MapKey
                Clone_Nuevonod = obj.NodeLSLIB.CloneNode
                Clone_Nuevonod.Attributes.Remove("UTAM_h1")
                Clone_Nuevonod.Attributes.Remove("UTAM_h2")
                Clone_Nuevonod.Attributes.Remove("UTAM_h3")
                Create_Initial(Clone_Nuevonod)
                Editor_Generic_GenericAttribute.Replace_Attribute_Generic(Clone_Nuevonod, "UTAM_Group", BG3Selector_FlagsandTags1.Current_Group, AttributeType.FixedString)
                BG3Editor_FlagsAndTags_uuid1.Replace_Attribute(Clone_Nuevonod, obj.MapKey)
                BG3Editor_FlagsAndTag_Name1.Replace_Attribute(Clone_Nuevonod, obj.Name + "_Overrided")
                If obj.NodeLSLIB.TryGetOrEmpty("DisplayName") <> "" Then
                    Editor_Generic_GenericAttribute.Replace_Attribute_Generic(Clone_Nuevonod, "UTAM_h1", obj.NodeLSLIB.TryGetOrEmpty("DisplayName"), AttributeType.TranslatedString)
                End If
                If obj.NodeLSLIB.TryGetOrEmpty("Description") <> "" AndAlso obj.NodeLSLIB.TryGetOrEmpty("DisplayName") <> obj.NodeLSLIB.TryGetOrEmpty("Description") Then
                    Editor_Generic_GenericAttribute.Replace_Attribute_Generic(Clone_Nuevonod, "UTAM_h2", obj.NodeLSLIB.TryGetOrEmpty("Description"), AttributeType.TranslatedString)
                End If
                If obj.NodeLSLIB.TryGetOrEmpty("Error") <> "" AndAlso obj.NodeLSLIB.TryGetOrEmpty("DisplayName") <> obj.NodeLSLIB.TryGetOrEmpty("Error") Then
                    Editor_Generic_GenericAttribute.Replace_Attribute_Generic(Clone_Nuevonod, "UTAM_h3", obj.NodeLSLIB.TryGetOrEmpty("Error"), AttributeType.TranslatedString)
                End If
                Capture_Clone_specific(obj, tipo)
            Case Else
                Debugger.Break()
        End Select

        SelectedTmp = FuncionesHelpers.GameEngine.ProcessedFlagsAndTags.Manage_Overrides(New BG3_Obj_FlagsAndTags_Class(Clone_Nuevonod, ActiveModSource, BG3_Enum_FlagsandTagsType.ActionResource))

        ' Localization Clone
        Select Case tipo
            Case BG3Cloner.Clonetype.None
            Case BG3Cloner.Clonetype.Clone, BG3Cloner.Clonetype.Inherit, BG3Cloner.Clonetype.Override
                CLone_Loca(obj.NodeLSLIB.TryGetOrEmpty("DisplayName"), SelectedTmp.NodeLSLIB.TryGetOrEmpty("UTAM_h1"))
                CLone_Loca(obj.NodeLSLIB.TryGetOrEmpty("Description"), SelectedTmp.NodeLSLIB.TryGetOrEmpty("UTAM_h2"))
                CLone_Loca(obj.NodeLSLIB.TryGetOrEmpty("Error"), SelectedTmp.NodeLSLIB.TryGetOrEmpty("UTAM_h3"))
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
    Private Sub Capture_AddNew(Group As String) Handles BG3Selector_FlagsandTags1.Add_New_Click
        Capture_Clone(Nothing, BG3Cloner.Clonetype.None)
        BG3Selector_FlagsandTags1.Habilita_Edicion_Botones(True)
        Habilita_Edicion_Botones(True)
    End Sub
    Private Sub Capture_Edit(template As BG3_Obj_FlagsAndTags_Class) Handles BG3Selector_FlagsandTags1.Edit_Click
        If IsNothing(template) Then Exit Sub
        Process_Edit()
    End Sub
    Private Sub Capture_Cancel() Handles BG3Selector_FlagsandTags1.Cancel_Click
        Process_Cancel()
    End Sub
    Private Sub Capture_Save() Handles BG3Selector_FlagsandTags1.Save_Click
        Process_Save_Edits()
    End Sub
    Private Sub Capture_Delete() Handles BG3Selector_FlagsandTags1.Delete_Click
        Process_delete()
    End Sub
    Protected Overridable Sub Process_Delete_Specifics()

    End Sub

    Private Sub Process_delete()
        If MsgBox("Deleting records is a known recipe for bricking savegames!. Do you want to continue?", MsgBoxStyle.Exclamation + vbOKCancel, "Warning") = MsgBoxResult.Cancel Then Exit Sub
        If FuncionesHelpers.GameEngine.ProcessedLocalizationList.ContainsKey(BG3Editor_FlagsandTag_DisplayName1.Get_Utam_Handle(SelectedTmp)) = True Then
            FuncionesHelpers.GameEngine.ProcessedLocalizationList.Remove(BG3Editor_FlagsandTag_DisplayName1.Get_Utam_Handle(SelectedTmp))
        End If
        If FuncionesHelpers.GameEngine.ProcessedLocalizationList.ContainsKey(BG3Editor_FlagsandTag_TranslatedDescription1.Get_Utam_Handle(SelectedTmp)) = True Then
            FuncionesHelpers.GameEngine.ProcessedLocalizationList.Remove(BG3Editor_FlagsandTag_TranslatedDescription1.Get_Utam_Handle(SelectedTmp))
        End If
        FuncionesHelpers.GameEngine.Utamflagsandtags.Remove(SelectedTmp)
        FuncionesHelpers.GameEngine.ProcessedFlagsAndTags.Remove(SelectedTmp)
        Process_Delete_Specifics()
        BG3Selector_FlagsandTags1.Delete_Ended()
    End Sub
    Private Sub Capture_Selection_Change(Template As BG3_Obj_FlagsAndTags_Class) Handles BG3Selector_FlagsandTags1.Change_Selected
        Select_Objects(Template)
        Process_Selection_Change()
    End Sub

    Protected Overridable Sub Select_Objects_Specifics()

    End Sub
    Private Sub Select_Objects(Template As BG3_Obj_FlagsAndTags_Class)
        If Not IsNothing(Template) Then
            SelectedTmp = Template
            Select_Objects_Specifics()
        Else
            SelectedTmp = Nothing
            Select_Objects_Specifics()
        End If
    End Sub

    Private Sub Create_Initial(ByRef nuevonod As LSLib.LS.Node)
        BG3Editor_FlagsAndTags_uuid1.Create_Attribute(nuevonod, Template_guid)
        BG3Editor_FlagsAndTag_Name1.Create_Attribute(nuevonod, "NEW_RESOURCEACTION")
        BG3Editor_FlagsandTag_DisplayName1.Create_Attribute(nuevonod, Funciones.NewGUID(True) + ";1")
        BG3Editor_FlagsandTag_TranslatedDescription1.Create_Attribute(nuevonod, Funciones.NewGUID(True) + ";1")
        BG3Editor_FlagsandTag_TranslatedError1.Create_Attribute(nuevonod, Funciones.NewGUID(True) + ";1")
        Create_Initial_Specific(nuevonod)
        Add_UTAM_Attribute(nuevonod)
    End Sub
    Private Sub Add_UTAM_Attribute(ByRef nuevonod As LSLib.LS.Node)
        Editor_Generic_GenericAttribute.Create_Attribute_Generic(nuevonod, "UTAM_Type", UtamType, AttributeType.FixedString)
        Editor_Generic_GenericAttribute.Create_Attribute_Generic(nuevonod, "UTAM_Group", BG3Selector_FlagsandTags1.Current_Group, AttributeType.FixedString)
        Add_UTAM_Attribute_Specific(nuevonod)
    End Sub

    Protected Overridable Sub Add_UTAM_Attribute_Specific(ByRef nuevonod As LSLib.LS.Node)
    End Sub

    Protected Overridable Sub Create_Initial_Specific(ByRef nuevonod As LSLib.LS.Node)
    End Sub

    Protected Overridable Sub Process_Selection_Change_specific()

    End Sub

    Private Sub Process_Selection_Change()
        If Not IsNothing(SelectedTmp) Then
            BG3Editor_Complex_Localization1.Read_Data(SelectedTmp)
            Add_UTAM_Attribute(SelectedTmp.NodeLSLIB)
            BG3Editor_FlagsAndTags_uuid1.Read(SelectedTmp)
            BG3Editor_FlagsAndTag_Name1.Read(SelectedTmp)
            BG3Editor_FlagsandTag_DisplayName1.Read(SelectedTmp)
            BG3Editor_FlagsandTag_TranslatedDescription1.Read(SelectedTmp)
            BG3Editor_FlagsandTag_TranslatedError1.Read(SelectedTmp)
            BG3Editor_ActionResources_Dicetype1.Read(SelectedTmp)
            BG3Editor_ActionResources_MaxLevel1.Read(SelectedTmp)
            BG3Editor_ActionResources_MaxValue1.Read(SelectedTmp)
            BG3Editor_ActionResource_IsHidden1.Read(SelectedTmp)
            BG3Editor_ActionResource_IsSpellResource1.Read(SelectedTmp)
            BG3Editor_ActionResource_ReplenishType1.Read(SelectedTmp)
            BG3Editor_ActionResource_ShowOnActionResourcePanel1.Read(SelectedTmp)
            BG3Editor_ActionResource_PartyActionResource1.Read(SelectedTmp)
            BG3Editor_ActionResource_UpdateSpellPowerLevel1.Read(SelectedTmp)
            BG3Selector_FlagsandTags1.BG3Editor_Template_UtamGroup1.Read(SelectedTmp)
            Process_Selection_Change_specific()
            BG3Editor_Complex_Advanced_Attributes1.Read(SelectedTmp)
        Else
            BG3Editor_Complex_Localization1.Clear()
            BG3Editor_FlagsAndTags_uuid1.Clear()
            BG3Editor_FlagsAndTag_Name1.Clear()
            BG3Editor_FlagsandTag_DisplayName1.Clear()
            BG3Editor_FlagsandTag_TranslatedDescription1.Clear()
            BG3Editor_FlagsandTag_TranslatedError1.Clear()
            BG3Editor_ActionResources_Dicetype1.Clear()
            BG3Editor_ActionResources_MaxLevel1.Clear()
            BG3Editor_ActionResources_MaxValue1.Clear()
            BG3Editor_ActionResource_IsHidden1.Clear()
            BG3Editor_ActionResource_IsSpellResource1.Clear()
            BG3Editor_ActionResource_ReplenishType1.Clear()
            BG3Editor_ActionResource_ShowOnActionResourcePanel1.Clear()
            BG3Editor_ActionResource_PartyActionResource1.Clear()
            BG3Editor_ActionResource_UpdateSpellPowerLevel1.Clear()
            BG3Selector_FlagsandTags1.BG3Editor_Template_UtamGroup1.Clear()
            Process_Selection_Change_specific()
            BG3Editor_Complex_Advanced_Attributes1.Clear()
        End If
    End Sub
    Protected Overridable Sub Process_Save_Edits_Specifics()
    End Sub

    Private Sub Process_Save_Edits()
        BG3Editor_FlagsAndTags_uuid1.Write(SelectedTmp)
        BG3Editor_FlagsAndTag_Name1.Write(SelectedTmp)
        BG3Editor_FlagsandTag_DisplayName1.Write(SelectedTmp)
        BG3Editor_FlagsandTag_TranslatedDescription1.Write(SelectedTmp)
        BG3Editor_FlagsandTag_TranslatedError1.Write(SelectedTmp)
        BG3Editor_ActionResources_Dicetype1.Write(SelectedTmp)
        BG3Editor_ActionResources_MaxLevel1.Write(SelectedTmp)
        BG3Editor_ActionResources_MaxValue1.Write(SelectedTmp)
        BG3Editor_ActionResource_IsHidden1.Write(SelectedTmp)
        BG3Editor_ActionResource_IsSpellResource1.Write(SelectedTmp)
        BG3Editor_ActionResource_ReplenishType1.Write(SelectedTmp)
        BG3Editor_ActionResource_ShowOnActionResourcePanel1.Write(SelectedTmp)
        BG3Editor_ActionResource_PartyActionResource1.Write(SelectedTmp)
        BG3Editor_ActionResource_UpdateSpellPowerLevel1.Write(SelectedTmp)
        BG3Selector_FlagsandTags1.BG3Editor_Template_UtamGroup1.Write(SelectedTmp)
        Process_Save_Edits_Specifics()
        Process_Save_Objetos()
        Process_Save_Final()
        Habilita_Edicion_Botones(False)
    End Sub

    Protected Overridable Sub Process_Save_Objetos_Specifics()
    End Sub
    Private Sub Process_Save_Objetos()
        SelectedTmp.Write_Data()
        Process_Save_Objetos_Specifics()
        BG3Editor_Complex_Localization1.Write_Data()
    End Sub
    Private Sub Process_Save_Final()
        BG3Selector_FlagsandTags1.Edit_Ended(SelectedTmp)
    End Sub

    Protected Overridable Sub Process_Edit_Specifics()

    End Sub

    Private Sub Process_Edit()
        SelectedTmp.Edit_start()
        Process_Edit_Specifics()
        Habilita_Edicion_Botones(True)
    End Sub
    Protected Overridable Sub Process_Cancel_Specifics()

    End Sub

    Private Sub Process_Cancel()
        SelectedTmp.Cancel_Edit()
        Process_Cancel_Specifics()
        Habilita_Edicion_Botones(False)
        BG3Selector_FlagsandTags1.Edit_Ended(SelectedTmp)
    End Sub

    Private Sub Create_Stat_Transfers()
#Disable Warning CA1861 ' Evitar matrices constantes como argumentos
        Dim lista As New List(Of ToolStripMenuItem) From {}
        'New ToolStripMenuItem("Template|Icon|False|Attribute", Nothing, AddressOf BG3Selector_FlagsandTags1.TransferSibligsClick) With {.Tag = {"Icon"}}
        '}
#Enable Warning CA1861 ' Evitar matrices constantes como argumentos

        Create_Stat_Transfers_Specific(lista)

        Dim Cats = lista.OrderBy(Function(pf) pf.Text).Select(Function(pf) pf.Text.Split("|")(0)).Distinct.ToArray

        For Each cat In Cats
            Dim indx = BG3Selector_FlagsandTags1.PropertiesToolStripMenuItem.DropDown.Items.Add(New ToolStripMenuItem(cat))
            Dim indx2 = BG3Selector_FlagsandTags1.SplitGroupButton.DropDown.Items.Add(New ToolStripMenuItem(cat))
            Dim indx3 = BG3Selector_FlagsandTags1.PropertiesToolStripMenuItem1.DropDown.Items.Add(New ToolStripMenuItem(cat))
            For Each it In lista.Where(Function(pf) pf.Text.Split("|")(0) = cat).OrderBy(Function(pq) pq.Text.Split("|")(1)).Select(Function(pf) pf)
                Dim splitstr = it.Text.Split("|")
                If splitstr(2) = "True" Then
                    Dim splitx = New ToolStripMenuItem(splitstr(1), Nothing, AddressOf BG3Selector_FlagsandTags1.SplitGroup) With {.Tag = CType(it.Tag, String()).Select(Function(pf) splitstr(3) + "|" + pf).ToArray}
                    CType(BG3Selector_FlagsandTags1.SplitGroupButton.DropDown.Items(indx2), ToolStripMenuItem).DropDown.Items.Add(splitx)
                End If

                it.Text = splitstr(1)
                CType(BG3Selector_FlagsandTags1.PropertiesToolStripMenuItem.DropDown.Items(indx), ToolStripMenuItem).DropDown.Items.Add(it)
                Dim Toall = New ToolStripMenuItem(it.Text, Nothing, AddressOf BG3Selector_FlagsandTags1.TransferAllClick) With {.Tag = it.Tag}
                CType(BG3Selector_FlagsandTags1.PropertiesToolStripMenuItem1.DropDown.Items(indx3), ToolStripMenuItem).DropDown.Items.Add(Toall)
            Next
        Next
    End Sub
    Protected Overridable Sub Create_Stat_Transfers_Specific(ByRef Lista As List(Of ToolStripMenuItem))

    End Sub
    Protected Overridable Sub Transfer_stats_specifics(Template As BG3_Obj_FlagsAndTags_Class, statsList() As String)

    End Sub

    Private Sub Transfer_SaveOriginal()
        Transfer_SaveOriginal_Specific()
    End Sub
    Protected Overridable Sub Transfer_SaveOriginal_Specific()
    End Sub

    Protected Transfer_Stat As BG3_Obj_Stats_Class

    Private Sub Transfer_stats(Template As BG3_Obj_FlagsAndTags_Class, statsList() As String, nods As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_FlagsAndTags_Class)) Handles BG3Selector_FlagsandTags1.Transfer_Stats
        Transfer_SaveOriginal()
        For Each nod As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_FlagsAndTags_Class) In nods.Nodes
            Dim obj As BG3_Obj_FlagsAndTags_Class = nod.Objeto
            If obj IsNot Template Then
                obj.Edit_start()
                Select_Objects(obj)
                For Each stat In statsList
                    Select Case stat
                        Case Else
                            Transfer_stats_specifics(Template, statsList)
                    End Select
                Next
                SelectedTmp.Write_Data()
            End If
        Next
        BG3Selector_FlagsandTags1.Edit_Ended(Template)
    End Sub
    Private Sub Transfer_Handles(Template As BG3_Obj_FlagsAndTags_Class, cual As Integer, nods As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_FlagsAndTags_Class)) Handles BG3Selector_FlagsandTags1.Transfer_Localization
        For Each nod As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_FlagsAndTags_Class) In nods.Nodes
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

        BG3Selector_FlagsandTags1.Edit_Ended(Template)
    End Sub


    Private Sub Generic_Editor_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If BG3Selector_FlagsandTags1.IsEditing = True Then
            MsgBox("Save or cancel changes before closing", vbOKOnly, "Changes not saved")
            e.Cancel = True
        End If
    End Sub

    Private Sub FillSplit(ByVal Attr_or_data As String, ByRef selectedtmp As BG3_Obj_FlagsAndTags_Class, ByRef suffix As String) Handles BG3Selector_FlagsandTags1.FillSplit
        Select Case Attr_or_data
            Case Else
                FillSplit_specific(Attr_or_data, selectedtmp, suffix)
        End Select

    End Sub
    Protected Overridable Sub FillSplit_specific(ByVal Attr_or_data As String, ByRef selectedtmp As BG3_Obj_FlagsAndTags_Class, ByRef suffix As String)

    End Sub
    Private Sub BG3Cloner1_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub TabPageAttributes_Click(sender As Object, e As EventArgs) Handles TabPageAttributes.Click

    End Sub



End Class