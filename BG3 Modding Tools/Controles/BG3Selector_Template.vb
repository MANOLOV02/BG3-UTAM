Imports System.ComponentModel
Imports System.Text.RegularExpressions
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button

Public Class BG3Selector_Template
    Public Property Selection As BG3_Enum_UTAM_Type = BG3_Enum_UTAM_Type.Dyes
    Private WithEvents SelectorWorker As New BackgroundWorker With {.WorkerReportsProgress = True, .WorkerSupportsCancellation = True}
    Private ReadOnly filter As New BG3_CustomFilter_Class(Of BG3_Obj_Template_Class)(SelectorWorker, Nothing)
    Public Property IsEditing As Boolean = False

    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Agrega_grupos_Base()
        Habilita_Edicion_Botones(False)
    End Sub


    Public Sub Load_Templates()
        For Each obj In FuncionesHelpers.GameEngine.UtamTemplates.Where(Function(pf) pf.Utam_Type = Selection)
            Agrega_item(obj)
        Next
        TreeView1.Sort()
        TreeView1.ExpandAll()
    End Sub
    Private Sub TreeView1_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick
        Try
            TreeView1.SelectedNode = e.Node
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TreeView1_ItemDrag(sender As Object, e As ItemDragEventArgs) Handles TreeView1.ItemDrag
        Try
            TreeView1.SelectedNode = e.Item
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Agrega_item(obj As BG3_Obj_Template_Class)
        Dim nod As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class)
        Agrega_grupo(obj.Utam_Group)

        If TreeView1.Nodes.Find(obj.MapKey, True).Length > 0 Then
            nod = TreeView1.Nodes.Find(obj.MapKey, True).First
            If nod.Parent.Text <> obj.Utam_Group Then
                Dim par = nod.Parent
                nod.Remove()
                If par.Nodes.Count = 0 Then par.Remove()
                TreeView1.Nodes.Find(Safe_node_key(obj.Utam_Group), False).First.Nodes.Add(nod)
                nod.Parent.Expand()
            End If
        Else
            nod = New BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class)(filter, obj) With {.Name = obj.MapKey, .Text = obj.Name}
            TreeView1.Nodes.Find(Safe_node_key(obj.Utam_Group), False).First.Nodes.Add(nod)
        End If
        ' Corrige Nombre
        TreeView1.SuspendLayout()
        TreeView1.BeginUpdate()
        TreeView1.LabelEdit = True
        nod.Change_to_DisplayFormat()
        TreeView1.LabelEdit = False
        TreeView1.EndUpdate()
        TreeView1.Sort()
        TreeView1.ResumeLayout()
    End Sub

    Private Sub Agrega_grupos_Base()
        For Each gr In FuncionesHelpers.UTAM_Groups.ToList
            Agrega_grupo(gr)
        Next
    End Sub
    Private Sub Agrega_grupo(grupo As String)
        If TreeView1.Nodes.ContainsKey(Safe_node_key(grupo)) = False Then
            Dim nod = New BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class)(filter, Nothing) With {.Name = Safe_node_key(grupo), .Text = grupo}
            TreeView1.Nodes.Add(nod)
        End If
        If FuncionesHelpers.UTAM_Groups.Where(Function(pf) pf.Equals(grupo, StringComparison.OrdinalIgnoreCase)).Any = False Then
            FuncionesHelpers.UTAM_Groups.Add(grupo)
            BG3Editor_Template_UtamGroup1.Update_Groups()
        End If
    End Sub
    Public Shared Function Safe_node_key(grupo As String) As String
        Return Regex.Replace(grupo, "[^\w\.@-]", "")
    End Function
    Private Sub TreeView1_BeforeSelect(sender As Object, e As TreeViewCancelEventArgs) Handles TreeView1.BeforeSelect
        e.Cancel = IsEditing
    End Sub
    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        Dim obj = CType(e.Node, BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class)).Objeto
        If Not IsNothing(obj) Then
            ButtonEdit.Enabled = Not IsEditing
        Else
            ButtonEdit.Enabled = False
        End If
        RaiseEvent Change_Selected(obj)
    End Sub

    Private Sub ButtonNew_Click(sender As Object, e As EventArgs) Handles ButtonNew.Click
        Habilita_Edicion_Botones(True)
        RaiseEvent Add_New_Click(Current_Group)
    End Sub
    Private Sub ButtonEdit_Click(sender As Object, e As EventArgs) Handles ButtonEdit.Click
        Habilita_Edicion_Botones(True)
        RaiseEvent Edit_Click(Current_Nod_Template)
    End Sub
    Private Sub ButtonSave_Click(sender As Object, e As EventArgs) Handles ButtonSave.Click
        RaiseEvent Save_Click()
    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        RaiseEvent Cancel_Click()
    End Sub
    Public Sub Add_Item(Template As BG3_Obj_Template_Class)
        Agrega_item(Template)
    End Sub
    Public Sub Edit_Ended(Template As BG3_Obj_Template_Class)
        Agrega_item(Template)
        Dim nod As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class)
        nod = TreeView1.Nodes.Find(Template.MapKey, True).First
        IsEditing = False
        TreeView1.SelectedNode = nod
        Habilita_Edicion_Botones(False)
    End Sub
    Public ReadOnly Property Current_Group As String
        Get
            If IsNothing(TreeView1.SelectedNode) Then Return FuncionesHelpers.UTAM_Groups(0)
            If Current_Nod_IsTemplate = False Then Return Current_Nod.Text
            Dim obj As BG3_Obj_Template_Class = Current_Nod.Objeto
            Dim Group As String = obj.ReadAttribute_Or_Nothing("UTAM_Group")
            If IsNothing(Group) Then Return FuncionesHelpers.UTAM_Groups(0)
            Return Group
        End Get
    End Property
    Public ReadOnly Property Current_Nod As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class)
        Get
            If IsNothing(TreeView1.SelectedNode) Then Return Nothing
            Return TreeView1.SelectedNode
        End Get
    End Property
    Public ReadOnly Property Current_Nod_Template As BG3_Obj_Template_Class
        Get
            If IsNothing(TreeView1.SelectedNode) Then Return Nothing
            If Current_Nod_IsTemplate = False Then Return Nothing
            Dim obj As BG3_Obj_Template_Class = Current_Nod.Objeto
            Return obj
        End Get
    End Property
    Public ReadOnly Property Current_Nod_IsTemplate As Boolean
        Get
            If IsNothing(TreeView1.SelectedNode) Then Return False
            If IsNothing(Current_Nod.Objeto) Then Return False
            Return True
        End Get
    End Property
    Private Sub Habilita_Edicion_Botones(Edicion As Boolean)
        IsEditing = Edicion
        ButtonSave.Enabled = Edicion
        ButtonCancel.Enabled = Edicion
        ButtonNew.Enabled = Not Edicion
        ButtonEdit.Enabled = Not (Edicion Or Current_Nod_IsTemplate = False)
        BG3Editor_Template_UtamGroup1.AllowEdit = Edicion
    End Sub



    Public Event Add_New_Click(Current_Group As String)
    Public Event Edit_Click(Template As BG3_Obj_Template_Class)
    Public Event Save_Click()
    Public Event Cancel_Click()
    Public Event Change_Selected(Template As BG3_Obj_Template_Class)

End Class
