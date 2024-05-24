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

Public Class Generic_Editor
    Sub New()
        MyBase.New
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Flickering.EnableDoubleBuffering(BG3Selector_Template1.TreeView1)
    End Sub

    Public HandledStats As New List(Of String)
    Public HandledAttributes As New List(Of String)
    Public HandledNodes As New List(Of String)

    Public Property ActiveModSource As BG3_Pak_SourceOfResource_Class
    Protected Overridable Property SelectedTmp As BG3_Obj_Template_Class
    Protected Overridable ReadOnly Property Prefix As String = "UTAM_XXXX_"
    Protected Overridable ReadOnly Property UtamType As BG3_Enum_UTAM_Type = BG3_Enum_UTAM_Type.Container
    Protected Overridable ReadOnly Property DefaulParent As String = ""
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
        'BG3Editor_Complex_Localization1.Link_Controls({BG3Editor_Template_DisplayName1, BG3Editor_Template_Description1, BG3Editor_Template_TechnicalDescription1})
        Initialize_Specifics()
    End Sub

    Protected Overridable Sub Initialize_Specifics()
        Debugger.Break()
    End Sub

    ' Procesos Comunes Editores
    Private Sub Habilita_Edicion_Botones(Edicion As Boolean)
        Habilita_Edicion_Botones_Specific(Edicion)
        Process_Selection_Change()
    End Sub
    Protected Overridable Sub Habilita_Edicion_Botones_Specific(Edicion As Boolean)
        Debugger.Break()
    End Sub

    Protected Overridable Sub Capture_Clone_specific(obj As BG3_Obj_Template_Class, tipo As BG3Cloner.Clonetype)

    End Sub

    Protected Clone_Stat_Name As String
    Protected Clone_Stat_Using As String
    Protected Clone_Nuevonod As LSLib.LS.Node
    Private Sub Capture_Clone(obj As BG3_Obj_Template_Class, tipo As BG3Cloner.Clonetype, stat As BG3_Obj_Stats_Class) Handles BG3Selector_Template1.Clone_Template

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
            Select_Objects_Specifics()
        Else
            SelectedTmp = Nothing
            Select_Objects_Specifics()
        End If
    End Sub

    Private Sub Create_Initial(ByRef nuevonod As LSLib.LS.Node)
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
            BG3Selector_Template1.BG3Editor_Template_UtamGroup1.Read(SelectedTmp)
            Process_Selection_Change_specific()
        Else
            BG3Selector_Template1.BG3Editor_Template_UtamGroup1.Clear()
            Process_Selection_Change_specific()
        End If
    End Sub
    Protected Overridable Sub Process_Save_Edits_Specifics()
        Debug.Print(Me.Text)
        Debugger.Break()
    End Sub

    Private Sub Process_Save_Edits()
        BG3Selector_Template1.BG3Editor_Template_UtamGroup1.Write(SelectedTmp)

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
        Process_Save_Objetos_Specifics()
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
        Process_Edit_Specifics()
        Habilita_Edicion_Botones(True)
    End Sub
    Protected Overridable Sub Process_Cancel_Specifics()
        Debug.Print(Me.Text)
        Debugger.Break()
    End Sub

    Private Sub Process_Cancel()
        SelectedTmp.Cancel_Edit()
        Process_Cancel_Specifics()
        Habilita_Edicion_Botones(False)
        BG3Selector_Template1.Edit_Ended(SelectedTmp)
    End Sub

    Private Sub Create_Stat_Transfers()
        Dim lista As New List(Of ToolStripMenuItem) From {
            } 'New ToolStripMenuItem("Stats|Rarity|True|Data", Nothing, AddressOf BG3Selector_Template1.TransferSibligsClick) With {.Tag = {"Rarity"}},}

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
                        Case "xxxx"

                        Case Else
                            Transfer_stats_specifics(Template, statsList)
                    End Select
                Next
                SelectedTmp.Write_Data()
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
                obj.Edit_start()
                obj.Write_Data()
            End If
        Next
        BG3Selector_Template1.Edit_Ended(Template)
    End Sub
    Private Sub Transfer_WorldInjection(Template As BG3_Obj_Template_Class, nods As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class)) Handles BG3Selector_Template1.Transfer_WorldInject
        For Each nod As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class) In nods.Nodes
            Dim obj As BG3_Obj_Template_Class = nod.Objeto
            If obj IsNot Template Then
                ' Borra nuevo
                ' Copia viejo
                ' Escribe nuevo
            End If
        Next
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

    Private Sub TabPageAttributes_Click(sender As Object, e As EventArgs)

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