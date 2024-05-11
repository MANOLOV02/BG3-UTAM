Imports System.ComponentModel
Imports System.Reflection.Emit
Imports System.Reflection.Metadata
Imports System.Runtime.Intrinsics
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
        TreeView1.BeginUpdate()
        Dim nod As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class)
        For Each obj In FuncionesHelpers.GameEngine.UtamTemplates.Where(Function(pf) pf.Utam_Type = Selection)
            nod = Agrega_item(obj)
        Next
        TreeResortNod()
        For Each nod In TreeView1.Nodes
            nod.ResortNod()
        Next
        TreeView1.EndUpdate()
    End Sub
    <DefaultValue("Drop an object to clone")>
    Public Property CloneLabel As String
        Get
            Return BG3Cloner1.Label
        End Get
        Set(value As String)
            BG3Cloner1.Label = value
        End Set
    End Property

    Public Property Template_MustDescend_From As String()
        Get
            Return BG3Cloner1.Template_MustDescend_From
        End Get
        Set
            BG3Cloner1.Template_MustDescend_From = Value
        End Set
    End Property

    Public Property Stat_MustDescend_From As String()
        Get
            Return BG3Cloner1.Stat_MustDescend_From
        End Get
        Set
            BG3Cloner1.Stat_MustDescend_From = Value
        End Set
    End Property

    Private Function Agrega_item(obj As BG3_Obj_Template_Class) As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class)
        If IsNothing(obj) Then Return Nothing
        Dim nod As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class)
        Dim gnod As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class) = Agrega_grupo(obj.Utam_Group)

        Dim find = TreeView1.Nodes.Find(obj.MapKey, True)
        If find.Length > 0 Then
            nod = find(0)
            If nod.Parent.Text <> obj.Utam_Group Then
                Dim par = nod.Parent
                nod.Remove()
                gnod.Nodes.Add(nod)
            End If
        Else
            nod = New BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class)(filter, obj) With {.Name = obj.MapKey, .Text = obj.Name}
            gnod.Nodes.Add(nod)
        End If
        TreeView1.LabelEdit = True
        nod.Change_to_DisplayFormat()
        TreeView1.LabelEdit = False
        Return nod
    End Function
    Public Sub TreeResortNod()
        If TreeView1.Nodes.Count = 0 Then Exit Sub
        Dim child(TreeView1.Nodes.Count - 1) As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class)
        TreeView1.Nodes.CopyTo(child, 0)
        TreeView1.Nodes.Clear()
        TreeView1.Nodes.AddRange(child.OrderBy(Function(pf) BG3_CustomFilter_Class(Of BG3_Obj_Template_Class).Replace_Override_Text(pf.Text)).ToArray)
    End Sub
    Private Function Agrega_grupo(grupo As String) As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class)
        Dim nod As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class)
        If TreeView1.Nodes.ContainsKey(Safe_node_key(grupo)) = False Then
            nod = New BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class)(filter, Nothing) With {.Name = Safe_node_key(grupo), .Text = grupo}
            TreeView1.Nodes.Add(nod)
            TreeResortNod()
        Else
            nod = TreeView1.Nodes.Find(Safe_node_key(grupo), False).First
        End If
        If Groups.Where(Function(pf) pf.Equals(grupo, StringComparison.OrdinalIgnoreCase)).Any = False Then
            Groups.Add(grupo)
        End If
        BG3Editor_Template_UtamGroup1.Update_Groups(Groups)
        Return nod
    End Function
    Public Shared Function Safe_node_key(grupo As String) As String
        Return Regex.Replace(grupo, "[^\w\.@-]", "")
    End Function

    Private Isclonning As Boolean = False
    Private Sub BG3Cloner1_Clone_Started() Handles BG3Cloner1.Clone_Started
        Isclonning = True
    End Sub
    Private Sub BG3Cloner1_Clone_Finished() Handles BG3Cloner1.Clone_Finished
        Isclonning = False
        Dim gnod = Agrega_grupo(Current_Group)
        gnod.ResortNod()
        Habilita_Edicion_Botones(False)
    End Sub
    Public Sub Edit_Ended(Template As BG3_Obj_Template_Class)
        Dim nod = Agrega_item(Template)
        Dim gnod = Agrega_grupo(Template.Utam_Group)
        gnod.Expand()
        If Isclonning = False Then gnod.ResortNod()
        IsEditing = False
        If Isclonning = False Then TreeView1.SelectedNode = nod
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
        If Isclonning = False Then
            IsEditing = Edicion
            ButtonSave.Enabled = Edicion
            ButtonCancel.Enabled = Edicion
            ButtonNew.Enabled = Not Edicion
            ButtonEdit.Enabled = Not (Edicion Or Current_Nod_IsTemplate = False)
            BG3Editor_Template_UtamGroup1.AllowEdit = Edicion
            SplitContainer1.Panel2.Enabled = True
        Else
            ButtonSave.Enabled = False
            ButtonCancel.Enabled = False
            ButtonNew.Enabled = False
            ButtonEdit.Enabled = False
            BG3Editor_Template_UtamGroup1.AllowEdit = False
            SplitContainer1.Panel2.Enabled = False
        End If
    End Sub
    Private Sub TreeView1_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick
        Try
            If Not IsNothing(e.Node) Then If IsEditing = False Then TreeView1.SelectedNode = e.Node
        Catch ex As Exception
            Debugger.Break()
        End Try
    End Sub
    Private Sub TreeView1_ItemDrag(sender As Object, e As ItemDragEventArgs) Handles TreeView1.ItemDrag
        Try
            If Not IsNothing(e.Item) Then
                If IsEditing = False Then TreeView1.SelectedNode = e.Item
                DoDragDrop(e.Item, DragDropEffects.Copy + DragDropEffects.Move)
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
            MoveToToolStripMoveTo.Enabled = False
            MoveToToolStripTransfer.Enabled = False
            ToolStripMenuItemSplitBy.Enabled = True
            CloneToolStripMenuItem.Enabled = True
            ToolStripGroupRemove.Enabled = True
            ToolStripGroupMenuChangeName.Enabled = True
            ToolStripGroupMenuAdd.Enabled = True

            If TreeView1.SelectedNode.Nodes.Count > 0 Then
                ToolStripGroupRemove.Enabled = False
                If TreeView1.SelectedNode.Nodes.Count > 1 Then
                    MergeWithToolStripMenuItem.Enabled = True
                Else
                    MergeWithToolStripMenuItem.Enabled = False
                End If
            Else
                MergeWithToolStripMenuItem.Enabled = False
                ToolStripGroupRemove.Enabled = True
            End If
        Else
            MoveToToolStripTransfer.Enabled = True
            MergeWithToolStripMenuItem.Enabled = False
            ToolStripMenuItemSplitBy.Enabled = False
            ToolStripGroupRemove.Enabled = False
            ToolStripGroupMenuChangeName.Enabled = False
            ToolStripGroupMenuAdd.Enabled = False

            CloneToolStripMenuItem.Enabled = False
            If Groups.Count <= 1 Then
                MoveToToolStripMoveTo.Enabled = False
            Else
                If MoveToToolStripMoveTo.DropDown.Items.Count = 0 Then MoveToToolStripMoveTo.DropDown.Items.Add("(Default)")
                If MergeWithToolStripMenuItem.DropDown.Items.Count = 0 Then MergeWithToolStripMenuItem.DropDown.Items.Add("(Default)")
                MoveToToolStripMoveTo.Enabled = True
            End If
        End If
    End Sub
    Private Function GetName(Propuesto As String) As String
        Dim xx As New GroupName With {.StartPosition = FormStartPosition.Manual}
        Dim referencex As Integer = CType(Me.ParentForm, Generic_Editor).SplitContainer1.Location.X + CType(Me.ParentForm, Generic_Editor).SplitContainer1.SplitterDistance - 7
        Dim referencey As Integer = CType(Me.ParentForm, Generic_Editor).SplitContainer1.Location.Y
        xx.Location = Me.ParentForm.PointToScreen(New Point(referencex, referencey))
        xx.TextBox1.Text = Propuesto
        xx.ShowDialog()
        If xx.DialogResult = DialogResult.OK Then
            Return xx.TextBox1.Text
        End If
        Return ""
    End Function
    Private Sub ToolStripGroupMenuChangeName_Click(sender As Object, e As EventArgs) Handles ToolStripGroupMenuChangeName.Click
        ContextMenuStrip1.Close()
        Dim label = GetName(TreeView1.SelectedNode.Text)
        If label <> "" Then
            IsEditing = True
            If Groups.Contains(Safe_node_key(label)) Then IsEditing = False : Exit Sub
            Groups.Remove(Safe_node_key(TreeView1.SelectedNode.Text))
            TreeView1.SelectedNode.Text = label
            TreeView1.SelectedNode.Name = Safe_node_key(label)
            Groups.Add(Safe_node_key(label))
            Name_edited(TreeView1.SelectedNode, label)
            TreeResortNod()
            Dim gnod As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class) = Agrega_grupo(label)
            IsEditing = False
            TreeView1.SelectedNode = gnod
        End If
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

    Private Sub ToolStripGroupMenuAdd_Click(sender As Object, e As EventArgs) Handles ToolStripGroupMenuAdd.Click
        Dim nombre As String = GetName(Crea_Uniqe_Name("New group"))
        If nombre <> "" Then
            Dim nod = Agrega_grupo(nombre)
            TreeResortNod()
            TreeView1.SelectedNode = nod
        End If
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
    Private Sub MergeWithToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles MergeWithToolStripMenuItem.DropDownOpening
        For Each it In MergeWithToolStripMenuItem.DropDown.Items
            RemoveHandler CType(it, ToolStripItem).Click, AddressOf Mergeclick
        Next
        MergeWithToolStripMenuItem.DropDown.Items.Clear()

        For Each gr In TreeView1.Nodes
            If CType(gr, TreeNode).Text <> Current_Group Then
                Dim it = MergeWithToolStripMenuItem.DropDown.Items.Add(CType(gr, TreeNode).Text)
                AddHandler it.Click, AddressOf Mergeclick
            End If
        Next
    End Sub
    Private Sub Mergeclick(sender As Object, e As EventArgs)
        If sender.text <> Current_Group Then
            IsEditing = True
            ContextMenuStrip1.Close()
            Dim oldnod = Current_Nod
            Dim nuenod = Agrega_grupo(sender.text)
            For x = Current_Nod.Nodes.Count - 1 To 0 Step -1
                Dim nod = Current_Nod.Nodes(x)
                Dim selectedtmp = CType(CType(nod, Object).objeto, BG3_Obj_Template_Class)
                selectedtmp.Edit_start()
                Editor_Generic_GenericAttribute.Replace_Attribute_Generic(selectedtmp.NodeLSLIB, "UTAM_Group", sender.text, LSLib.LS.AttributeType.FixedString)
                selectedtmp.Write_Data()
                nod.Remove()
                nuenod.Nodes.Add(nod)
            Next
            nuenod.ResortNod()
            IsEditing = False
            If oldnod.Nodes.Count = 0 Then
                Groups.Remove(Safe_node_key(oldnod.Text))
                oldnod.Remove()
                BG3Editor_Template_UtamGroup1.Update_Groups(Groups)
            End If
            TreeView1.SelectedNode = nuenod
        End If
    End Sub
    Private Sub Transferclick(sender As Object, e As EventArgs)
        If sender.text <> Current_Group Then
            Muevea(sender.text)
        End If
    End Sub
    Private Sub Muevea(donde As String)
        IsEditing = True
        ContextMenuStrip1.Close()
        Dim selectedtmp = Current_Nod_Template
        selectedtmp.Edit_start()
        Editor_Generic_GenericAttribute.Replace_Attribute_Generic(selectedtmp.NodeLSLIB, "UTAM_Group", donde, LSLib.LS.AttributeType.FixedString)
        selectedtmp.Write_Data()
        IsEditing = False
        Dim nod = Agrega_item(selectedtmp)
        Dim gnod = Agrega_grupo(donde)
        gnod.ResortNod()
        TreeView1.SelectedNode = nod
    End Sub

    Public Sub SplitStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim spl() As String = sender.tag
        IsEditing = True
        TreeView1.BeginUpdate()
        If spl.Length > 1 Then Debugger.Break()
        Dim prefix As String = Current_Group
        Dim queleo As String = spl(0).Split("|")(0)
        Dim Attr_or_data As String = spl(0).Split("|")(1)
        Dim actualnod = Current_Nod
        Dim ngrup = Current_Nod
        Dim nuevos_grupoas As New SortedList(Of String, BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class))
        For x = actualnod.Nodes.Count - 1 To 0 Step -1
            Dim nod = actualnod.Nodes(x)
            Dim selectedtmp As BG3_Obj_Template_Class = CType(CType(nod, Object).objeto, BG3_Obj_Template_Class)
            Dim selectedstat As BG3_Obj_Stats_Class = selectedtmp.AssociatedStats
            Dim suffix As String = "_" + Attr_or_data + "_"
            Select Case queleo
                Case "Data"
                    suffix += selectedstat.Get_Data_Or_Inherited_or_Empty(Attr_or_data)
                Case "Attribute"
                    suffix += selectedtmp.ReadAttribute_Or_Inhterithed_Or_Empty(Attr_or_data)
                Case "Custom"
                Case Else
                    Debugger.Break()
            End Select
            ngrup = Agrega_grupo(prefix + suffix)
            selectedtmp.Edit_start()
            Editor_Generic_GenericAttribute.Replace_Attribute_Generic(selectedtmp.NodeLSLIB, "UTAM_Group", prefix + suffix, LSLib.LS.AttributeType.FixedString)
            selectedtmp.Write_Data()
            nod.Remove()
            ngrup.Nodes.Add(nod)
            nuevos_grupoas.TryAdd(ngrup.Text, ngrup)
        Next
        For Each grp In nuevos_grupoas
            grp.Value.ResortNod()
        Next
        IsEditing = False
        TreeView1.EndUpdate()
        If actualnod.Nodes.Count = 0 Then
            Groups.Remove(Safe_node_key(actualnod.Text))
            actualnod.Remove()
            BG3Editor_Template_UtamGroup1.Update_Groups(Groups)
        End If
        TreeView1.SelectedNode = ngrup
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

    Private Sub AllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllToolStripMenuItem.Click
        SplitContainer1.Panel2.Enabled = False
        IsEditing = True
        RaiseEvent Transfer_Localization(Current_Nod_Template, 0)
    End Sub
    Private Sub OnlyDisplayNameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OnlyDisplayNameToolStripMenuItem.Click
        SplitContainer1.Panel2.Enabled = False
        IsEditing = True
        RaiseEvent Transfer_Localization(Current_Nod_Template, 1)
    End Sub
    Private Sub OnlyDescriptionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OnlyDescriptionToolStripMenuItem.Click
        SplitContainer1.Panel2.Enabled = False
        IsEditing = True
        RaiseEvent Transfer_Localization(Current_Nod_Template, 2)
    End Sub
    Private Sub OnlyTechnicalDescriptionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OnlyTechnicalDescriptionToolStripMenuItem.Click
        SplitContainer1.Panel2.Enabled = False
        IsEditing = True
        RaiseEvent Transfer_Localization(Current_Nod_Template, 3)
    End Sub
    Private Sub CLone_Loca(objeto As BG3_Obj_Stats_Class, tipo As BG3Cloner.Clonetype) Handles BG3Cloner1.Clone_Stat
        RaiseEvent Clone_Stat(objeto, tipo)
    End Sub
    Private Sub CLone_Loca(objeto As BG3_Obj_Template_Class, tipo As BG3Cloner.Clonetype) Handles BG3Cloner1.Clone_Template
        RaiseEvent Clone_Template(objeto, tipo)
    End Sub

    Private Sub GenerateNewHandlesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerateNewHandlesToolStripMenuItem.Click
        Current_Nod_Template.Edit_start()
        Editor_Generic_GenericAttribute.Replace_Attribute_Generic(Current_Nod_Template.NodeLSLIB, "UTAM_h1", Funciones.NewGUID(True) + ";1", LSLib.LS.AttributeType.FixedString)
        Editor_Generic_GenericAttribute.Replace_Attribute_Generic(Current_Nod_Template.NodeLSLIB, "UTAM_h2", Funciones.NewGUID(True) + ";1", LSLib.LS.AttributeType.FixedString)
        Editor_Generic_GenericAttribute.Replace_Attribute_Generic(Current_Nod_Template.NodeLSLIB, "UTAM_h3", Funciones.NewGUID(True) + ";1", LSLib.LS.AttributeType.FixedString)
        Current_Nod_Template.Write_Data()
    End Sub

    Private Sub ByInheritingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ByInheritingToolStripMenuItem.Click
        Dim oldnod = Current_Nod
        TreeView1.SelectedNode = Agrega_grupo(Crea_Uniqe_Name(Current_Group + "(Inherited)"))
        Dim nods(oldnod.Nodes.Count - 1) As Object
        oldnod.Nodes.CopyTo(nods, 0)
        For Each nod In nods
            BG3Cloner1.Do_Clone_OBJ(nod.objeto, BG3Cloner.Clonetype.Inherit, True, False)
        Next

    End Sub

    Private Sub ByCloningToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ByCloningToolStripMenuItem.Click
        Dim oldnod = Current_Nod
        TreeView1.SelectedNode = Agrega_grupo(Crea_Uniqe_Name(Current_Group + "(Cloned)"))
        Dim nods(oldnod.Nodes.Count - 1) As Object
        oldnod.Nodes.CopyTo(nods, 0)
        For Each nod In nods
            BG3Cloner1.Do_Clone_OBJ(nod.objeto, BG3Cloner.Clonetype.Clone, True, False)
        Next
    End Sub

    Private Function Crea_Uniqe_Name(Prefix As String) As String
        Dim str = Prefix
        Dim x As Integer = 1
        While Groups.Contains(Str)
            str = Prefix + "(" + x.ToString + ")"
            x += 1
        End While
        Return str
    End Function

    Private Sub MoveToToolStripTransfer_Click(sender As Object, e As EventArgs) Handles MoveToToolStripTransfer.Click

    End Sub

    Private Sub TreeView1_DragEnter(sender As Object, e As DragEventArgs) Handles TreeView1.DragEnter
        If IsEditing = True Then
            e.Effect = DragDropEffects.None
        Else
            If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class))) Then
                Dim obj As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class)))
                If obj.TreeView Is Me.TreeView1 Then
                    e.Effect = DragDropEffects.None
                    Exit Sub
                End If
            End If

            BG3Cloner1.Control_DragEnter(sender, e)
        End If
    End Sub

    Private Sub TreeView1_DragDrop(sender As Object, e As DragEventArgs) Handles TreeView1.DragDrop
        If IsEditing = True Then Exit Sub
        If e.Effect = DragDropEffects.Copy Then BG3Cloner1.Control_DragDrop(sender, e)
    End Sub



    Public Event Clone_Stat(objeto As BG3_Obj_Stats_Class, tipo As BG3Cloner.Clonetype)
    Public Event Clone_Template(objeto As BG3_Obj_Template_Class, tipo As BG3Cloner.Clonetype)
    Public Event Add_New_Click(Current_Group As String)
    Public Event Edit_Click(Template As BG3_Obj_Template_Class)
    Public Event Save_Click()
    Public Event Cancel_Click()
    Public Event Change_Selected(Template As BG3_Obj_Template_Class)
    Public Event Transfer_Stats(Template As BG3_Obj_Template_Class, strings() As String)
    Public Event Transfer_WorldInject(Template As BG3_Obj_Template_Class)
    Public Event Transfer_Tags(Template As BG3_Obj_Template_Class)
    Public Event Transfer_Localization(Template As BG3_Obj_Template_Class, cual As Integer)
End Class
