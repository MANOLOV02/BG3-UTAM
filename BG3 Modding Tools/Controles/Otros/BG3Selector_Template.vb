Imports System.ComponentModel
Imports System.Reflection.Metadata
Imports System.Text.RegularExpressions
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button
Imports LSLib.Granny

Public Class BG3Selector_Template
    Public Property Selection As BG3_Enum_UTAM_Type = BG3_Enum_UTAM_Type.Dyes
    Private WithEvents SelectorWorker As New BackgroundWorker With {.WorkerReportsProgress = True, .WorkerSupportsCancellation = True}
    Private ReadOnly filter As New BG3_CustomFilter_Class(Of BG3_Obj_Template_Class)(SelectorWorker, Nothing)
    Private Groups As New List(Of String)
    Public Property IsEditing As Boolean = False
    Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Habilita_Edicion_Botones(False)
    End Sub
    Public Sub Load_Templates()
        For Each obj In FuncionesHelpers.GameEngine.UtamTemplates.Where(Function(pf) pf.Utam_Type = Selection)
            Agrega_item(obj)
        Next
    End Sub

    Private Function Agrega_item(obj As BG3_Obj_Template_Class) As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class)
        Dim nod As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class)
        Agrega_grupo(obj.Utam_Group)

        Dim tn = TreeView1.TopNode
        TreeView1.SuspendLayout()
        TreeView1.BeginUpdate()

        If TreeView1.Nodes.Find(obj.MapKey, True).Length > 0 Then
            nod = TreeView1.Nodes.Find(obj.MapKey, True).First
            If nod.Parent.Text <> obj.Utam_Group Then
                Dim par = nod.Parent
                nod.Remove()
                'If par.Nodes.Count = 0 Then par.Remove()
                TreeView1.Nodes.Find(Safe_node_key(obj.Utam_Group), False).First.Nodes.Add(nod)
                nod.Parent.Expand()
            End If
        Else
            nod = New BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class)(filter, obj) With {.Name = obj.MapKey, .Text = obj.Name}
            TreeView1.Nodes.Find(Safe_node_key(obj.Utam_Group), False).First.Nodes.Add(nod)
        End If

        ' Corrige Nombre
        TreeView1.LabelEdit = True
        nod.Change_to_DisplayFormat()
        TreeView1.LabelEdit = False
        nod.EnsureVisible()
        TreeView1.Sort()
        TreeView1.TopNode = tn
        TreeView1.EndUpdate()
        TreeView1.ResumeLayout()
        Return nod
    End Function

    Private Sub Agrega_grupo(grupo As String)
        If TreeView1.Nodes.ContainsKey(Safe_node_key(grupo)) = False Then
            Dim nod = New BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class)(filter, Nothing) With {.Name = Safe_node_key(grupo), .Text = grupo}
            TreeView1.Nodes.Add(nod)
        End If
        If Groups.Where(Function(pf) pf.Equals(grupo, StringComparison.OrdinalIgnoreCase)).Any = False Then
            Groups.Add(grupo)
            BG3Editor_Template_UtamGroup1.Update_Groups(Groups)
        End If
    End Sub
    Public Shared Function Safe_node_key(grupo As String) As String
        Return Regex.Replace(grupo, "[^\w\.@-]", "")
    End Function

    Public Sub Edit_Ended(Template As BG3_Obj_Template_Class)
        Agrega_item(Template)
        Dim nod As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class)
        nod = TreeView1.Nodes.Find(Template.MapKey, True).First
        IsEditing = False
        TreeView1.SelectedNode = nod
        Habilita_Edicion_Botones(False)
    End Sub
    <Browsable(False)>
    Public ReadOnly Property Current_Group As String
        Get
            If IsNothing(TreeView1.SelectedNode) Then Return "(Default)"
            If Current_Nod_IsTemplate = False Then Return Current_Nod.Text
            Dim obj As BG3_Obj_Template_Class = Current_Nod.Objeto
            Dim Group As String = obj.ReadAttribute_Or_Nothing("UTAM_Group")
            If IsNothing(Group) Then Return "(Default)"
            Return Group
        End Get
    End Property
    <Browsable(False)>
    Public ReadOnly Property Current_Nod As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class)
        Get
            If IsNothing(TreeView1.SelectedNode) Then Return Nothing
            Return TreeView1.SelectedNode
        End Get
    End Property
    <Browsable(False)>
    Public ReadOnly Property Current_Nod_Template As BG3_Obj_Template_Class
        Get
            If IsNothing(TreeView1.SelectedNode) Then Return Nothing
            If Current_Nod_IsTemplate = False Then Return Nothing
            If IsNothing(Current_Nod) Then Return Nothing
            Dim obj As BG3_Obj_Template_Class = Current_Nod.Objeto
            Return obj
        End Get
    End Property
    <Browsable(False)>
    Public ReadOnly Property Current_Nod_IsTemplate As Boolean
        Get
            If IsNothing(TreeView1.SelectedNode) Then Return False
            If IsNothing(Current_Nod) Then Return False
            If IsNothing(Current_Nod.Objeto) Then Return False
            Return True
        End Get
    End Property
    Public Sub Habilita_Edicion_Botones(Edicion As Boolean)
        IsEditing = Edicion
        ButtonSave.Enabled = Edicion
        ButtonCancel.Enabled = Edicion
        ButtonNew.Enabled = Not Edicion
        ButtonEdit.Enabled = Not (Edicion Or Current_Nod_IsTemplate = False)
        BG3Editor_Template_UtamGroup1.AllowEdit = Edicion
        SplitContainer1.Panel2.Enabled = True
    End Sub
    Private Sub TreeView1_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick
        Try
            If Not IsNothing(e.Node) Then TreeView1.SelectedNode = e.Node
        Catch ex As Exception
            Debugger.Break()
        End Try
    End Sub
    Private Sub TreeView1_ItemDrag(sender As Object, e As ItemDragEventArgs) Handles TreeView1.ItemDrag
        Try
            If Not IsNothing(e.Item) Then
                TreeView1.SelectedNode = e.Item
                DoDragDrop(e.Item, DragDropEffects.Copy)
            End If
        Catch ex As Exception
            Debugger.Break()
        End Try
    End Sub
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

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As CancelEventArgs) Handles ContextMenuStrip1.Opening
        If IsNothing(TreeView1.SelectedNode) OrElse IsEditing Then e.Cancel = True : Exit Sub
        Dim obj = CType(TreeView1.SelectedNode, BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class)).Objeto
        If IsNothing(obj) Then
            ToolStripGroupMenu.Enabled = True
            MoveToToolStripMoveTo.Enabled = False
            MoveToToolStripTransfer.Enabled = False
            If TreeView1.SelectedNode.Nodes.Count > 0 Then
                ToolStripGroupRemove.Enabled = False
            Else
                ToolStripGroupRemove.Enabled = True
            End If
        Else
            ToolStripGroupMenu.Enabled = False
            MoveToToolStripTransfer.Enabled = True
            If Groups.Count <= 1 Then
                MoveToToolStripMoveTo.Enabled = False
            Else
                If MoveToToolStripMoveTo.DropDown.Items.Count = 0 Then MoveToToolStripMoveTo.DropDown.Items.Add("(Default)")
                MoveToToolStripMoveTo.Enabled = True
            End If
        End If
    End Sub


    Private Sub ToolStripGroupMenuChangeName_Click(sender As Object, e As EventArgs) Handles ToolStripGroupMenuChangeName.Click
        IsEditing = True
        TreeView1.LabelEdit = True
        TreeView1.SelectedNode.BeginEdit()
    End Sub


    Private Sub Name_edited(node As TreeNode, label As String)
        If node.Nodes.Count > 0 Then
            Dim nods(node.Nodes.Count - 1) As Object
            node.Nodes.CopyTo(nods, 0)
            For Each nod In nods
                Dim selectedtmp = CType(nod.objeto, BG3_Obj_Template_Class)
                selectedtmp.Edit_start()
                Editor_Generic_GenericAttribute.Replace_Attribute_Generic(selectedtmp.NodeLSLIB, "UTAM_Group", label, LSLib.LS.AttributeType.FixedString)
                selectedtmp.Write_Data()
            Next
        End If
    End Sub
    Private Sub TreeView1_AfterLabelEdit(sender As Object, e As NodeLabelEditEventArgs) Handles TreeView1.AfterLabelEdit
        TreeView1.LabelEdit = False
        If Not IsNothing(Current_Nod) AndAlso e.Node Is Current_Nod Then
            If Not IsNothing(e.Label) AndAlso e.Node.Text <> e.Label Then
                If Groups.Contains(Safe_node_key(e.Label)) Then e.CancelEdit = True : IsEditing = False : Exit Sub
                Groups.Remove(Safe_node_key(e.Node.Text))
                e.Node.Text = e.Label
                e.Node.Name = Safe_node_key(e.Label)
                Groups.Add(Safe_node_key(e.Label))
                Name_edited(e.Node, e.Label)
                BG3Editor_Template_UtamGroup1.Update_Groups(Groups)
            End If
            IsEditing = False
        End If
    End Sub

    Private Sub ToolStripGroupMenuAdd_Click(sender As Object, e As EventArgs) Handles ToolStripGroupMenuAdd.Click
        IsEditing = True
        Dim str As String = "New group"
        Dim x As Integer = 1
        While Groups.Contains(str)
            str = "New group(" + x.ToString + ")"
            x += 1
        End While
        Agrega_grupo(str)
        IsEditing = False
    End Sub

    Private Sub ToolStripGroupRemove_Click(sender As Object, e As EventArgs) Handles ToolStripGroupRemove.Click
        IsEditing = True
        If TreeView1.SelectedNode.Nodes.Count = 0 Then
            Groups.Remove(Safe_node_key(Current_Nod.Text))
            TreeView1.SelectedNode.Remove()
            BG3Editor_Template_UtamGroup1.Update_Groups(Groups)
        End If
        IsEditing = False
    End Sub

    Private Sub MoveToToolStripMoveTo_DropDownOpening(sender As Object, e As EventArgs) Handles MoveToToolStripMoveTo.DropDownOpening
        For Each it In MoveToToolStripMoveTo.DropDown.Items
            RemoveHandler CType(it, ToolStripItem).Click, AddressOf Transferclick
        Next
        MoveToToolStripMoveTo.DropDown.Items.Clear()
        For Each gr In TreeView1.Nodes
            If CType(gr, TreeNode).Text <> Current_Group Then
                Dim it = MoveToToolStripMoveTo.DropDown.Items.Add(CType(gr, TreeNode).Text)
                AddHandler it.Click, AddressOf Transferclick
            End If
        Next
    End Sub

    Private Sub Transferclick(sender As Object, e As EventArgs)
        If sender.text <> Current_Group Then
            IsEditing = True
            ContextMenuStrip1.Close()
            Dim selectedtmp = Current_Nod_Template
            selectedtmp.Edit_start()
            Editor_Generic_GenericAttribute.Replace_Attribute_Generic(selectedtmp.NodeLSLIB, "UTAM_Group", sender.text, LSLib.LS.AttributeType.FixedString)
            selectedtmp.Write_Data()
            IsEditing = False
            TreeView1.SelectedNode = Agrega_item(selectedtmp)
        End If
    End Sub

    Public Sub StatsToolStripMenuItem_Click(sender As Object, e As EventArgs)
        SplitContainer1.Panel2.Enabled = False
        IsEditing = True
        RaiseEvent Transfer_Stats(Current_Nod_Template, CType(sender, ToolStripMenuItem).Tag)
    End Sub
    Private Sub TagsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TagsToolStripMenuItem.Click
        SplitContainer1.Panel2.Enabled = False
        IsEditing = True
        RaiseEvent Transfer_Tags(Current_Nod_Template)
    End Sub

    Private Sub TreasureTablesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TreasureTablesToolStripMenuItem.Click
        SplitContainer1.Panel2.Enabled = False
        IsEditing = True
        RaiseEvent Transfer_WorldInject(Current_Nod_Template)
    End Sub
    Private Sub LocalizationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LocalizationToolStripMenuItem.Click
        SplitContainer1.Panel2.Enabled = False
        IsEditing = True
        RaiseEvent Transfer_Localization(Current_Nod_Template)
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

    Public Event Add_New_Click(Current_Group As String)
    Public Event Edit_Click(Template As BG3_Obj_Template_Class)
    Public Event Save_Click()
    Public Event Cancel_Click()
    Public Event Change_Selected(Template As BG3_Obj_Template_Class)
    Public Event Transfer_Stats(Template As BG3_Obj_Template_Class, strings() As String)
    Public Event Transfer_WorldInject(Template As BG3_Obj_Template_Class)
    Public Event Transfer_Tags(Template As BG3_Obj_Template_Class)
    Public Event Transfer_Localization(Template As BG3_Obj_Template_Class)

End Class
