Imports System.ComponentModel
Imports System.Reflection.Emit
Imports System.Reflection.Metadata
Imports System.Runtime.Intrinsics
Imports System.Text.RegularExpressions
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button
Imports LSLib.Granny

Public MustInherit Class BG3Selector_Generic_Code(Of T As BG3_Obj_Generic_Class)
    Inherits BG3Selector_Generic_Designer
    Public IsEditing As Boolean = False
    Public Isclonning_or_transfering As Boolean = False
    Public Property Selection As BG3_Enum_UTAM_Type = BG3_Enum_UTAM_Type.Dyes
    Private WithEvents SelectorWorker As New BackgroundWorker With {.WorkerReportsProgress = True, .WorkerSupportsCancellation = True}
    Private ReadOnly filter As New BG3_CustomFilter_Class(Of T)(SelectorWorker, Nothing)
    Protected Groups As New List(Of String)
    Public SelectedDisplayformat As BG3_Enum_DisplayFormat = BG3_Enum_DisplayFormat.Name_and_DisplayName

    Sub New()
        Isclonning_or_transfering = True
        Habilita_Edicion_Botones(False)
    End Sub
    Private Sub DisplaySelectionButton(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.DropDownOpening
        DisplayNAmeOption_1.Checked = SelectedDisplayformat = BG3_Enum_DisplayFormat.OnlyName
        DisplayNAmeOption_2.Checked = SelectedDisplayformat = BG3_Enum_DisplayFormat.Name_and_DisplayName
        DisplayNAmeOption_3.Checked = SelectedDisplayformat = BG3_Enum_DisplayFormat.OnlyDisplayName
        DisplayNAmeOption_4.Checked = SelectedDisplayformat = BG3_Enum_DisplayFormat.DisplayName_and_Name
    End Sub

    Private Sub DisplayNAmeOption1(sender As Object, e As EventArgs) Handles DisplayNAmeOption_1.Click
        SelectedDisplayformat = BG3_Enum_DisplayFormat.OnlyName
        Do_DisplayChange()
    End Sub

    Private Sub DisplayNAmeOption2(sender As Object, e As EventArgs) Handles DisplayNAmeOption_2.Click
        SelectedDisplayformat = BG3_Enum_DisplayFormat.Name_and_DisplayName
        Do_DisplayChange()
    End Sub
    Private Sub DisplayNAmeOption3(sender As Object, e As EventArgs) Handles DisplayNAmeOption_3.Click
        SelectedDisplayformat = BG3_Enum_DisplayFormat.OnlyDisplayName
        Do_DisplayChange()
    End Sub

    Private Sub DisplayNAmeOption4(sender As Object, e As EventArgs) Handles DisplayNAmeOption_4.Click
        SelectedDisplayformat = BG3_Enum_DisplayFormat.DisplayName_and_Name
        Do_DisplayChange()
    End Sub
    Private Sub Do_DisplayChange()
        Cursor.Current = Cursors.WaitCursor
        TreeView1.BeginUpdate()
        Isclonning_or_transfering = True
        Dim curnod = Current_Nod
        Dim child(TreeView1.Nodes.Count - 1) As BG3_Custom_TreeNode_Linked_Class(Of T)
        TreeView1.Nodes.CopyTo(child, 0)
        TreeView1.Nodes.Clear()

        TreeView1.LabelEdit = True
        filter.DisplayFormat = SelectedDisplayformat
        filter.Repaint()
        TreeView1.LabelEdit = False

        For Each gr As BG3_Custom_TreeNode_Linked_Class(Of T) In child
            gr.ResortNod()
        Next

        TreeView1.Nodes.AddRange(child.OrderBy(Function(pf) BG3_CustomFilter_Class(Of T).Replace_Override_Text(pf.Text)).ToArray)
        Cursor.Current = Cursors.Default
        Isclonning_or_transfering = False
        TreeView1.SelectedNode = curnod
        TreeView1.EndUpdate()
    End Sub
    Private Sub CollapseAll_Click(sender As Object, e As EventArgs) Handles CollapseAll.Click
        For Each gr As TreeNode In TreeView1.Nodes
            gr.Collapse()
        Next
    End Sub

    Private Sub ExpandAll_Click(sender As Object, e As EventArgs) Handles ExpandAll.Click
        For Each gr As TreeNode In TreeView1.Nodes
            gr.ExpandAll()
        Next
    End Sub
    Public Sub Habilita_Edicion_Botones(Edicion As Boolean)
        If Isclonning_or_transfering = False Then
            IsEditing = Edicion
            ButtonSave.Enabled = Edicion
            ButtonCancel.Enabled = Edicion
            ButtonNew.Enabled = Not Edicion
            ButtonEdit.Enabled = Not (Edicion Or Current_Nod_IsObject = False)
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
        If ButtonEdit.Enabled = True Then
            ButtonCancel.Text = "Delete" : ButtonCancel.Enabled = True
        Else
            ButtonCancel.Text = "Cancel" : ButtonCancel.Enabled = ButtonSave.Enabled
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
            If IsNothing(e.Item) Then Exit Sub
            If IsEditing = False Then TreeView1.SelectedNode = e.Item
            DoDragDrop(e.Item, DragDropEffects.Copy + DragDropEffects.Move)
        Catch ex As Exception
            Debugger.Break()
        End Try
    End Sub
    Private Sub TreeView1_BeforeSelect(sender As Object, e As TreeViewCancelEventArgs) Handles TreeView1.BeforeSelect
        e.Cancel = IsEditing
    End Sub
    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        Dim obj = CType(e.Node, BG3_Custom_TreeNode_Linked_Class(Of T)).Objeto
        If Not IsNothing(obj) Then ButtonEdit.Enabled = Not IsEditing Else ButtonEdit.Enabled = False
        RaiseEvent Change_Selected(obj)
    End Sub
    Private Sub TreeView1_DragEnter(sender As Object, e As DragEventArgs) Handles TreeView1.DragEnter
        If IsEditing = True Then
            e.Effect = DragDropEffects.None
        Else
            If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of T))) Then
                Dim obj As BG3_Custom_TreeNode_Linked_Class(Of T) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of T)))
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


    Public Sub Load_Templates(ByRef Lista As IEnumerable(Of Object))
        TreeView1.BeginUpdate()
        Dim nod As BG3_Custom_TreeNode_Linked_Class(Of T)
        For Each obj In Lista.Where(Function(pf) pf.Utam_Type = Selection)
            nod = Agrega_item(CType(obj, Object))
        Next
        TreeResortNod()
        For Each nod In TreeView1.Nodes
            nod.ResortNod()
        Next
        If TreeView1.Nodes.Count = 0 Then Agrega_grupo("(Default)")
        TreeView1.EndUpdate()
        Isclonning_or_transfering = False
        Habilita_Edicion_Botones(False)

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
    Protected Function Agrega_grupo(grupo As String) As BG3_Custom_TreeNode_Linked_Class(Of T)
        Dim nod As BG3_Custom_TreeNode_Linked_Class(Of T)
        If TreeView1.Nodes.ContainsKey(Safe_node_key(grupo)) = False Then
            nod = New BG3_Custom_TreeNode_Linked_Class(Of T)(filter, Nothing) With {.Name = Safe_node_key(grupo), .Text = grupo}
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
    Private Function Agrega_item(obj As T) As BG3_Custom_TreeNode_Linked_Class(Of T)
        If IsNothing(obj) Then Return Nothing
        Dim nod As BG3_Custom_TreeNode_Linked_Class(Of T)
        Dim gnod As BG3_Custom_TreeNode_Linked_Class(Of T) = Agrega_grupo(obj.Utam_Group)

        Dim find() As TreeNode = TreeView1.Nodes.Find(obj.MapKey, True)
        If find.Length > 0 Then
            nod = find(0)
            If nod.Parent.Text <> obj.Utam_Group Then
                nod.Remove()
                gnod.Nodes.Add(nod)
            End If
        Else
            nod = New BG3_Custom_TreeNode_Linked_Class(Of T)(filter, obj) With {.Name = obj.MapKey, .Text = obj.Name}
            gnod.Nodes.Add(nod)
        End If
        TreeView1.LabelEdit = True
        nod.Change_to_DisplayFormat()
        TreeView1.LabelEdit = False
        Return nod
    End Function

    Public Sub TreeResortNod()
        If TreeView1.Nodes.Count < 1 Then Exit Sub
        Dim child(TreeView1.Nodes.Count - 1) As BG3_Custom_TreeNode_Linked_Class(Of T)
        TreeView1.Nodes.CopyTo(child, 0)
        TreeView1.Nodes.Clear()
        TreeView1.Nodes.AddRange(child.OrderBy(Function(pf) BG3_CustomFilter_Class(Of T).Replace_Override_Text(pf.Text)).ToArray)
    End Sub

    Public Shared Function Safe_node_key(grupo As String) As String
        Return Regex.Replace(grupo, "[^\w\.@-]", "")
    End Function

    Private Sub BG3Cloner1_Clone_Started() Handles BG3Cloner1.Clone_Started
        Isclonning_or_transfering = True
    End Sub
    Private Sub Capture_Clone_Finished() Handles BG3Cloner1.Clone_Finished
        Isclonning_or_transfering = False
        Current_Group_nod.ResortNod()
        Habilita_Edicion_Botones(False)
        CType(Me.ParentForm.MdiParent, Main).ChangedMod()
    End Sub
    Public Sub Edit_Ended(Template As T)
        Dim nod = Agrega_item(Template)
        Current_Group_nod.Expand()
        If Isclonning_or_transfering = False Then Current_Group_nod.ResortNod()
        IsEditing = False
        If Isclonning_or_transfering = False Then TreeView1.SelectedNode = nod
        Habilita_Edicion_Botones(False)
        CType(Me.ParentForm.MdiParent, Main).ChangedMod()
    End Sub
    Public Sub Delete_Ended()
        Dim gnod = Current_Group_nod
        Dim idx = Current_Nod.Index
        Current_Nod.Remove()
        IsEditing = False
        If gnod.Nodes.Count - 1 >= idx Then TreeView1.SelectedNode = gnod.Nodes(idx) Else TreeView1.SelectedNode = gnod
        Habilita_Edicion_Botones(False)
        CType(Me.ParentForm.MdiParent, Main).ChangedMod()
    End Sub

    <Browsable(False)>
    Public ReadOnly Property Current_Group As String
        Get
            Return Current_Group_nod.Text
        End Get
    End Property
    <Browsable(False)>
    Public ReadOnly Property Current_Group_nod As BG3_Custom_TreeNode_Linked_Class(Of T)
        Get
            If IsNothing(Current_Nod) Then Return TreeView1.Nodes(0)
            If Current_Nod_IsObject = False Then Return Current_Nod
            Return Current_Nod.Parent
        End Get
    End Property
    <Browsable(False)>
    Public ReadOnly Property Current_Nod As BG3_Custom_TreeNode_Linked_Class(Of T)
        Get
            If IsNothing(TreeView1.SelectedNode) Then Return Nothing
            Return TreeView1.SelectedNode
        End Get
    End Property
    <Browsable(False)>
    Public ReadOnly Property Current_Nod_Bg3Object As T
        Get
            If IsNothing(Current_Nod) Then Return Nothing
            If Current_Nod_IsObject = False Then Return Nothing
            Return Current_Nod.Objeto
        End Get
    End Property

    <Browsable(False)>
    Public ReadOnly Property Current_Nod_IsObject As Boolean
        Get
            If IsNothing(Current_Nod) Then Return False
            If IsNothing(Current_Nod.Objeto) Then Return False
            Return True
        End Get
    End Property

    Private Sub ContextMenuOpening(sender As Object, e As CancelEventArgs) Handles ContextMenuStrip1.Opening
        If IsNothing(TreeView1.SelectedNode) OrElse IsEditing Then e.Cancel = True : Exit Sub
        Dim obj = CType(TreeView1.SelectedNode, BG3_Custom_TreeNode_Linked_Class(Of T)).Objeto
        If IsNothing(obj) Then
            MoveObjectButton.Enabled = False
            TransferToSiblingsButton.Enabled = False
            TransferToAllButton.Enabled = False
            SplitGroupButton.Enabled = True
            CloneGroupButton.Enabled = True
            RemoveGroupButton.Enabled = True
            RenameGroupButton.Enabled = True
            AddGroupButton.Enabled = True
            If MergeGroupButton.DropDown.Items.Count = 0 Then MergeGroupButton.DropDown.Items.Add("(Default)")
            MergeGroupButton.Enabled = TreeView1.Nodes.Count > 1
            RemoveGroupButton.Enabled = Current_Nod.Nodes.Count = 0
        Else
            TransferToSiblingsButton.Enabled = Current_Group_nod.Nodes.Count > 1
            MergeGroupButton.Enabled = False
            SplitGroupButton.Enabled = False
            RemoveGroupButton.Enabled = False
            RenameGroupButton.Enabled = False
            AddGroupButton.Enabled = False
            CloneGroupButton.Enabled = False
            If MoveObjectButton.DropDown.Items.Count = 0 Then MoveObjectButton.DropDown.Items.Add("(Default)")
            MoveObjectButton.Enabled = TreeView1.Nodes.Count > 1
            TransferToAllButton.Enabled = TreeView1.Nodes.Count > 1
        End If
    End Sub

    Private Function OpenGetNameForm(Propuesto As String) As String
        Dim Form As New GroupName With {.StartPosition = FormStartPosition.Manual}
        Dim referencex As Integer = CType(Me.ParentForm, Generic_Item_Editor).SplitContainer1.Location.X + CType(Me.ParentForm, Generic_Item_Editor).SplitContainer1.SplitterDistance - 7
        Dim referencey As Integer = CType(Me.ParentForm, Generic_Item_Editor).SplitContainer1.Location.Y
        Form.Location = Me.ParentForm.PointToScreen(New Point(referencex, referencey))
        Form.TextBox1.Text = Propuesto
        Form.ShowDialog()
        If Form.DialogResult <> DialogResult.OK Then Return ""
        Return Form.TextBox1.Text
    End Function
    Private Sub Rename_Group(sender As Object, e As EventArgs) Handles RenameGroupButton.Click
        ContextMenuStrip1.Close()
        Dim label = OpenGetNameForm(TreeView1.SelectedNode.Text)
        If label = "" Then Exit Sub
        TreeView1.BeginUpdate()
        IsEditing = True
        If Groups.Contains(Safe_node_key(label)) Then IsEditing = False : Exit Sub
        Groups.Remove(Safe_node_key(Current_Group))
        Current_Group_nod.Text = label
        Current_Group_nod.Name = Safe_node_key(label)
        Groups.Add(Safe_node_key(label))
        Name_edited(Current_Group_nod, label)
        Dim gnod = Agrega_grupo(label)
        TreeResortNod()
        IsEditing = False
        TreeView1.EndUpdate()
        TreeView1.SelectedNode = gnod
    End Sub

    Private Shared Sub Name_edited(node As TreeNode, label As String)
        For Each nod In node.Nodes
            Dim selectedtmp = CType(nod.objeto, T)
            selectedtmp.Edit_start()
            Editor_Generic_GenericAttribute.Replace_Attribute_Generic(selectedtmp.NodeLSLIB, "UTAM_Group", label, LSLib.LS.AttributeType.FixedString)
            selectedtmp.Write_Data()
        Next
    End Sub

    Private Sub Agega_Grupo(sender As Object, e As EventArgs) Handles AddGroupButton.Click
        Dim nombre As String = OpenGetNameForm(Crea_Uniqe_Name("New group"))
        If nombre = "" Then Exit Sub
        Dim nod = Agrega_grupo(nombre)
        TreeResortNod()
        TreeView1.SelectedNode = nod
    End Sub

    Private Sub ToolStripGroupRemove_Click(sender As Object, e As EventArgs) Handles RemoveGroupButton.Click
        IsEditing = True
        If TreeView1.SelectedNode.Nodes.Count = 0 Then
            Groups.Remove(Safe_node_key(Current_Nod.Text))
            TreeView1.SelectedNode.Remove()
            BG3Editor_Template_UtamGroup1.Update_Groups(Groups)
        End If
        IsEditing = False
    End Sub

    Private Sub MoveGruoupOpening(sender As Object, e As EventArgs) Handles MoveObjectButton.DropDownOpening
        For Each it In MoveObjectButton.DropDown.Items
            RemoveHandler CType(it, ToolStripItem).Click, AddressOf MoveItem_click
        Next
        MoveObjectButton.DropDown.Items.Clear()
        For Each gr In TreeView1.Nodes
            If CType(gr, TreeNode).Text <> Current_Group Then
                Dim it = MoveObjectButton.DropDown.Items.Add(CType(gr, TreeNode).Text)
                AddHandler it.Click, AddressOf MoveItem_click
            End If
        Next
    End Sub
    Private Sub MergeOpening(sender As Object, e As EventArgs) Handles MergeGroupButton.DropDownOpening
        For Each it In MergeGroupButton.DropDown.Items
            RemoveHandler CType(it, ToolStripItem).Click, AddressOf Merge_Group
        Next
        MergeGroupButton.DropDown.Items.Clear()
        For Each gr In TreeView1.Nodes
            If CType(gr, TreeNode).Text <> Current_Group Then
                Dim it = MergeGroupButton.DropDown.Items.Add(CType(gr, TreeNode).Text)
                AddHandler it.Click, AddressOf Merge_Group
            End If
        Next
    End Sub
    Private Sub Merge_Group(sender As Object, e As EventArgs)
        ContextMenuStrip1.Close()
        If sender.text = Current_Group Then Exit Sub
        TreeView1.BeginUpdate()
        IsEditing = True
        Dim oldnod = Current_Nod
        Dim nuenod = Agrega_grupo(sender.text)
        Name_edited(Current_Nod, sender.text)
        Dim nods(oldnod.Nodes.Count - 1) As TreeNode
        oldnod.Nodes.CopyTo(nods, 0)
        oldnod.Nodes.Clear()
        nuenod.Nodes.AddRange(nods)
        nuenod.ResortNod()
        IsEditing = False
        If oldnod.Nodes.Count = 0 Then Groups.Remove(Safe_node_key(oldnod.Text)) : oldnod.Remove() : BG3Editor_Template_UtamGroup1.Update_Groups(Groups)
        TreeView1.EndUpdate()
        TreeView1.SelectedNode = nuenod
        CType(Me.ParentForm.MdiParent, Main).ChangedMod()
    End Sub
    Private Sub MoveItem_click(sender As Object, e As EventArgs)
        ContextMenuStrip1.Close()
        If sender.text = Current_Group Then Exit Sub
        Muevea(sender.text)
        CType(Me.ParentForm.MdiParent, Main).ChangedMod()
    End Sub
    Private Sub Muevea(donde As String)
        IsEditing = True
        TreeView1.BeginUpdate()
        Dim selectedtmp = Current_Nod_Bg3Object
        Dim idx = Current_Nod.Index
        Dim nod = Current_Nod
        Dim next_nod As TreeNode
        If Current_Group_nod.Nodes.Count - 2 >= idx Then next_nod = Current_Group_nod.Nodes(idx + 1) Else next_nod = Current_Group_nod
        selectedtmp.Edit_start()
        Editor_Generic_GenericAttribute.Replace_Attribute_Generic(selectedtmp.NodeLSLIB, "UTAM_Group", donde, LSLib.LS.AttributeType.FixedString)
        selectedtmp.Write_Data()
        Dim gnod = Agrega_grupo(donde)
        nod.Remove()
        gnod.Nodes.Add(nod)
        gnod.ResortNod()
        IsEditing = False
        TreeView1.EndUpdate()
        TreeView1.SelectedNode = next_nod
    End Sub
    Public MustOverride Sub SplitGroup(sender As Object, e As EventArgs)


    Public Sub TransferSibligsClick(sender As Object, e As EventArgs) Handles TagsToolStripMenuItem.Click, TreasureTablesToolStripMenuItem.Click, AllToolStripMenuItem.Click, OnlyDisplayNameToolStripMenuItem.Click, OnlyDescriptionToolStripMenuItem.Click, OnlyTechnicalDescriptionToolStripMenuItem.Click
        If Warning_accept(Current_Nod.Parent.Nodes.Count) = False Then Exit Sub
        Isclonning_or_transfering = True
        SplitContainer1.Panel2.Enabled = False
        IsEditing = True
        DoTransferStat(sender, Current_Nod.Parent)
        Isclonning_or_transfering = False
        Edit_Ended(Current_Nod_Bg3Object)
    End Sub
    Public Sub TransferAllClick(sender As Object, e As EventArgs) Handles WorldInjectionToolStripMenuItem.Click, TagsToolStripMenuItem1.Click
        Dim count As Integer = 0
        For Each nod In TreeView1.Nodes
            count += nod.nodes.count
        Next
        If Warning_accept(count) = False Then Exit Sub
        Isclonning_or_transfering = True
        SplitContainer1.Panel2.Enabled = False
        IsEditing = True
        For Each nod In TreeView1.Nodes
            Dim xx = Current_Nod
            DoTransferStat(sender, nod)
        Next
        Isclonning_or_transfering = False
        Edit_Ended(Current_Nod_Bg3Object)
    End Sub

    Private Sub DoTransferStat(sender As Object, nod As BG3_Custom_TreeNode_Linked_Class(Of T))
        Select Case True
            Case sender Is TreasureTablesToolStripMenuItem Or sender Is WorldInjectionToolStripMenuItem
                RaiseEvent Transfer_WorldInject(Current_Nod_Bg3Object, nod)
            Case sender Is AllToolStripMenuItem
                RaiseEvent Transfer_Localization(Current_Nod_Bg3Object, 0, nod)
            Case sender Is OnlyDisplayNameToolStripMenuItem
                RaiseEvent Transfer_Localization(Current_Nod_Bg3Object, 1, nod)
            Case sender Is OnlyDescriptionToolStripMenuItem
                RaiseEvent Transfer_Localization(Current_Nod_Bg3Object, 2, nod)
            Case sender Is OnlyTechnicalDescriptionToolStripMenuItem
                RaiseEvent Transfer_Localization(Current_Nod_Bg3Object, 3, nod)
            Case sender Is TagsToolStripMenuItem Or sender Is TagsToolStripMenuItem1
                RaiseEvent Transfer_Tags(Current_Nod_Bg3Object, nod)
            Case Else
                RaiseEvent Transfer_Stats(Current_Nod_Bg3Object, CType(sender, ToolStripMenuItem).Tag, nod)
        End Select
    End Sub
    Private Sub GenerateNewHandlesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerateNewHandlesToolStripMenuItem.Click
        Current_Nod_Bg3Object.Edit_start()
        Editor_Generic_GenericAttribute.Replace_Attribute_Generic(Current_Nod_Bg3Object.NodeLSLIB, "UTAM_h1", Funciones.NewGUID(True) + ";1", LSLib.LS.AttributeType.FixedString)
        Editor_Generic_GenericAttribute.Replace_Attribute_Generic(Current_Nod_Bg3Object.NodeLSLIB, "UTAM_h2", Funciones.NewGUID(True) + ";1", LSLib.LS.AttributeType.FixedString)
        Editor_Generic_GenericAttribute.Replace_Attribute_Generic(Current_Nod_Bg3Object.NodeLSLIB, "UTAM_h3", Funciones.NewGUID(True) + ";1", LSLib.LS.AttributeType.FixedString)
        Current_Nod_Bg3Object.Write_Data()
    End Sub

    Private Sub ButtonNew_Click(sender As Object, e As EventArgs) Handles ButtonNew.Click
        Habilita_Edicion_Botones(True)
        RaiseEvent Add_New_Click(Current_Group)
    End Sub
    Private Sub ButtonEdit_Click(sender As Object, e As EventArgs) Handles ButtonEdit.Click
        Habilita_Edicion_Botones(True)
        RaiseEvent Edit_Click(Current_Nod_Bg3Object)
    End Sub
    Private Sub ButtonSave_Click(sender As Object, e As EventArgs) Handles ButtonSave.Click
        RaiseEvent Save_Click()
    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        If ButtonCancel.Text = "Delete" Then
            RaiseEvent Delete_Click()
        Else
            RaiseEvent Cancel_Click()
        End If
    End Sub

    Private Sub CLone_Stat_Capture(objeto As BG3_Obj_Stats_Class, tipo As BG3Cloner.Clonetype) Handles BG3Cloner1.Clone_Stat
        RaiseEvent Clone_Stat(objeto, tipo)
    End Sub
    Private Sub CLone_Template_Capture(objeto As BG3_Obj_Template_Class, tipo As BG3Cloner.Clonetype, Stat As BG3_Obj_Stats_Class) Handles BG3Cloner1.Clone_Template
        RaiseEvent Clone_Template(objeto, tipo, Stat)
    End Sub

    Private Shared Function Warning_accept(Count As Integer)
        Dim recs As String = Count.ToString
        If MsgBox("This will change " + recs + " records and can not be undone. Do you want to continue?", MsgBoxStyle.Exclamation + vbOKCancel, "Warning") = MsgBoxResult.Cancel Then Return False
        Return True
    End Function

    Private Sub CloneByInheriting_click(sender As Object, e As EventArgs) Handles ByInheritingToolStripMenuItem.Click
        Dim oldnod = Current_Nod
        TreeView1.SelectedNode = Agrega_grupo(Crea_Uniqe_Name(Current_Group + "(Inherited)"))
        Dim nods(oldnod.Nodes.Count - 1) As Object
        oldnod.Nodes.CopyTo(nods, 0)
        For Each nod In nods
            BG3Cloner1.Do_Clone_OBJ(nod.objeto, BG3Cloner.Clonetype.Inherit, True, False)
        Next
    End Sub
    Private Sub CloneByCloning_click(sender As Object, e As EventArgs) Handles ByCloningToolStripMenuItem.Click
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
        While Groups.Contains(str)
            str = Prefix + "(" + x.ToString + ")"
            x += 1
        End While
        Return str
    End Function
    Private Sub ButtonEdit_EnabledChanged(sender As Object, e As EventArgs) Handles ButtonEdit.EnabledChanged
        If ButtonEdit.Enabled = True Then
            ButtonCancel.Text = "Delete" : ButtonCancel.Enabled = True
        Else
            ButtonCancel.Text = "Cancel" : ButtonCancel.Enabled = ButtonSave.Enabled
        End If
    End Sub


    Public Event Clone_Stat(objeto As BG3_Obj_Stats_Class, tipo As BG3Cloner.Clonetype)
    Public Event Clone_Template(objeto As BG3_Obj_Template_Class, tipo As BG3Cloner.Clonetype, Stat As BG3_Obj_Stats_Class)
    Public Event Add_New_Click(Current_Group As String)
    Public Event Edit_Click(Template As T)
    Public Event Save_Click()
    Public Event Cancel_Click()
    Public Event Delete_Click()
    Public Event Change_Selected(Template As T)
    Public Event Transfer_Stats(Template As T, strings() As String, nod As BG3_Custom_TreeNode_Linked_Class(Of T))
    Public Event Transfer_WorldInject(Template As T, nod As BG3_Custom_TreeNode_Linked_Class(Of T))
    Public Event Transfer_Tags(Template As T, nod As BG3_Custom_TreeNode_Linked_Class(Of T))
    Public Event Transfer_Localization(Template As T, cual As Integer, nod As BG3_Custom_TreeNode_Linked_Class(Of T))
End Class
