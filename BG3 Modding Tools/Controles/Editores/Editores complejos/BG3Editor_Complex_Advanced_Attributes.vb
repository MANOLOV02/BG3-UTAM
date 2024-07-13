Imports System.ComponentModel
Imports System.Net.NetworkInformation
Imports System.Runtime.InteropServices.JavaScript.JSType
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Tab
Imports LSLib.Granny
Imports LSLib.LS
Imports LSLib.LS.Story

Public Class BG3Editor_Complex_Advanced_Attributes
    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.DoubleBuffered = True
        Flickering.EnableDoubleBuffering(ListView1)
        TreeView1.HideSelection = False
    End Sub


    Private _Readonly As Boolean = True
    <DefaultValue(True)>
    Public Property [ReadOnly] As Boolean
        Get
            Return _Readonly
        End Get
        Set(value As Boolean)
            _Readonly = value
            BG3Editor_Template_Undefined1.Enabled = Not value
            GroupBoxNodesEdit.Enabled = Not value
            ButtonOk.Enabled = Not value
        End Set
    End Property

    Private ReadOnly Property ParentHandledList As List(Of String)
        Get
            Try
                Return CType(ParentForm, Object).HandledAttributes
            Catch ex As Exception
                Debugger.Break()
                Return New List(Of String)
            End Try
        End Get
    End Property
    Private ReadOnly Property ParentHandledNodesList As List(Of String)
        Get
            Try
                Return CType(ParentForm, Object).HandledNodes
            Catch ex As Exception
                Debugger.Break()
                Return New List(Of String)
            End Try
        End Get
    End Property

    Private _Last_read As LSLib.LS.Node = Nothing
    Private _Last_OBJ As BG3_Obj_Generic_Class = Nothing
    Private _selected As System.Windows.Forms.TreeNode
    Private _LastSelectedNode As LSLib.LS.Node
    Private DefaultList As List(Of String)
    Private CustomList As List(Of String)
    Public Sub Clear()
        _Last_read = Nothing
        _Last_OBJ = Nothing
        DefaultList = Nothing
        CustomList = Nothing
        BG3Editor_Template_Undefined1.Label = "Select"
        BG3Editor_Template_Undefined1.Key = "Undefined"
        BG3Editor_Template_Undefined1.AttributeType = AttributeType.FixedString
        BG3Editor_Template_Undefined1.Clear()
        TreeView1.Nodes.Clear()
        ListView1.Items.Clear()

    End Sub

    Private Sub ReadNodes(nod As System.Windows.Forms.TreeNode, que As LSLib.LS.Node)
        For Each childs In que.Children
            For Each child In childs.Value
                Dim agrega As Boolean = True
                For Each handled In ParentHandledNodesList
                    Dim handlednode As String = handled
                    Dim handledParam As String = ""
                    Dim handledParamValue As String = ""
                    If handled.Contains(";"c) Then
                        handlednode = handled.Split(";")(0)
                        handledParam = handled.Split(";")(1).Split("=")(0)
                        handledParamValue = handled.Split(";")(1).Split("=")(1)
                    End If
                    If handlednode.Equals(nod.FullPath + "\" + child.Name) Then
                        If handledParam = "" Then agrega = False : Exit For
                        Dim val As LSLib.LS.NodeAttribute = Nothing
                        If child.Attributes.TryGetValue(handledParam, val) Then
                            If val.AsString(Funciones.Guid_to_string).Equals(handledParamValue) Then agrega = False : Exit For
                        End If
                    End If
                Next
                If agrega Then
                    Dim treenod2 As New System.Windows.Forms.TreeNode With {.Text = child.Name, .Tag = child}
                    nod.Nodes.Add(treenod2)
                    If Not IsNothing(_LastSelectedNode) AndAlso _LastSelectedNode Is child Then _selected = treenod2
                    ReadNodes(treenod2, child)
                End If
            Next
        Next
    End Sub


    Public Sub Read(Obj As BG3_Obj_Generic_Class)
        _LastSelectedNode = _Last_read
        Clear()
        _Last_read = Obj.NodeLSLIB
        _Last_OBJ = Obj
        Dim treenod As New System.Windows.Forms.TreeNode With {.Text = Obj.NodeLSLIB.Name, .Tag = Obj.NodeLSLIB}
        _selected = treenod
        TreeView1.Nodes.Add(treenod)
        ReadNodes(treenod, Obj.NodeLSLIB)
        treenod.ExpandAll()
        TreeView1.SelectedNode = _selected
        _LastSelectedNode = Nothing
        _selected = Nothing
    End Sub


    Private Sub Read(Node As LSLib.LS.Node)
        ListView1.BeginUpdate()
        _Last_read = Node
        Dim idx As ListViewItem
        Dim top = ListView1.TopItem
        Dim last_pos As String = ""
        If ListView1.SelectedItems.Count > 0 Then last_pos = ListView1.SelectedItems(0).Text
        ListView1.Items.Clear()
        Dim filtro As IEnumerable(Of KeyValuePair(Of String, String))
        Dim prefix = TreeView1.SelectedNode.FullPath + ";"
        Dim esparentnode = TreeView1.SelectedNode Is TreeView1.Nodes(0)

        Select Case _Last_OBJ.GetType
            Case GetType(BG3_Obj_Template_Class)
                filtro = FuncionesHelpers.GameEngine.ProcessedGameObjectList.Attributes_Stats_List.Where(Function(pf) (ParentHandledList.Contains(pf.Value) = False OrElse esparentnode = False) AndAlso pf.Key.StartsWith(prefix, StringComparison.OrdinalIgnoreCase) AndAlso pf.Key.EndsWith(";" + CType(_Last_OBJ, BG3_Obj_Template_Class).Type.ToString, StringComparison.OrdinalIgnoreCase) = True).Select(Function(pf) pf).Distinct
            Case GetType(BG3_Obj_FlagsAndTags_Class)
                filtro = FuncionesHelpers.GameEngine.ProcessedFlagsAndTags.Attributes_Stats_List.Where(Function(pf) (ParentHandledList.Contains(pf.Value) = False OrElse esparentnode = False) AndAlso pf.Key.StartsWith(prefix, StringComparison.OrdinalIgnoreCase) AndAlso pf.Key.EndsWith(";" + CType(_Last_OBJ, BG3_Obj_FlagsAndTags_Class).Type.ToString, StringComparison.OrdinalIgnoreCase) = True).Select(Function(pf) pf).Distinct
            Case GetType(BG3_Obj_VisualBank_Class)
                filtro = FuncionesHelpers.GameEngine.ProcessedVisualBanksList.Attributes_Stats_List.Where(Function(pf) (ParentHandledList.Contains(pf.Value) = False OrElse esparentnode = False) AndAlso pf.Key.StartsWith(prefix, StringComparison.OrdinalIgnoreCase) AndAlso pf.Key.EndsWith(";" + CType(_Last_OBJ, BG3_Obj_VisualBank_Class).Type.ToString, StringComparison.OrdinalIgnoreCase) = True).Select(Function(pf) pf).Distinct
            Case Else
                filtro = Nothing
                Debugger.Break()
        End Select
        DefaultList = filtro.Select(Function(pf) pf.Value).ToList

        For Each stat In filtro
            Dim tipos() = stat.Key.Split(";")
            idx = Agrega_Item(stat.Value, tipos(2))
            If Not IsNothing(top) AndAlso idx.Name = top.Name Then top = idx
            If idx.Text = last_pos Then idx.Selected = True
        Next

        CustomList = _Last_read.Attributes.Where(Function(pf) DefaultList.Contains(pf.Key) = False AndAlso (ParentHandledList.Contains(pf.Key) = False OrElse esparentnode = False)).Select(Function(pf) pf.Key).ToList
        ' Las que no estan
        For Each stat2 In _Last_read.Attributes.Where(Function(pf) DefaultList.Contains(pf.Key) = False AndAlso (ParentHandledList.Contains(pf.Key) = False OrElse esparentnode = False))
            Dim att As LSLib.LS.NodeAttribute = Nothing
            _Last_read.Attributes.TryGetValue(stat2.Key, att)
            idx = Agrega_Item(stat2.Key, att.Type.ToString)
            If Not IsNothing(top) AndAlso idx.Name = top.Name Then top = idx
            If idx.Text = last_pos Then idx.Selected = True
        Next

        ListView1.Columns(0).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
        ListView1.Columns(1).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
        If ListView1.Columns(1).Width < 100 Then ListView1.Columns(1).Width = 100
        ListView1.Columns(2).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
        If ListView1.Columns(2).Width < 100 Then ListView1.Columns(2).Width = 100
        ListView1.EndUpdate()
        ListView1.TopItem = top
    End Sub

    Private Function Agrega_Item(Key As String, type As String) As ListViewItem
        Dim it As ListViewItem
        it = New ListViewItem With {.Text = Key, .Name = Key}
        it = ListView1.Items.Add(it)
        it.SubItems.Add(type)
        Dim valor As String = GetValueString(Key)
        it.SubItems.Add(valor)
        ColorSubitem(Key, it)
        Return it
    End Function
    Private Sub ColorSubitem(Key As String, ByRef Subitem As ListViewItem)
        Dim val As LSLib.LS.NodeAttribute = Nothing
        Dim esparentnode = TreeView1.SelectedNode Is TreeView1.Nodes(0)
        _Last_read.Attributes.TryGetValue(Key, val)
        If Not IsNothing(val) Then
            If DefaultList.Contains(Key) Then
                Subitem.ForeColor = Color.FromKnownColor(KnownColor.Highlight)
            Else
                Subitem.ForeColor = Color.FromKnownColor(KnownColor.Red)
            End If
        Else
            If esparentnode Then
                Subitem.ForeColor = Color.FromKnownColor(KnownColor.ControlText)
            Else
                Subitem.ForeColor = Color.FromKnownColor(KnownColor.GrayText)
            End If
        End If
    End Sub
    Private Function GetValueString(Key As String) As String
        Dim val As LSLib.LS.NodeAttribute = Nothing
        Dim str As String
        Dim esparentnode = TreeView1.SelectedNode Is TreeView1.Nodes(0)
        _Last_read.Attributes.TryGetValue(Key, val)
        If Not IsNothing(val) Then
            str = val.AsString(Funciones.Guid_to_string)
        Else
            If esparentnode Then
                str = _Last_OBJ.ReadAttribute_Or_Inhterithed(Key)
            Else
                str = ""
            End If
        End If
        Return str
    End Function

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.ItemSelectionChanged
        If ListView1.SelectedItems.Count <> 0 Then
            Dim Stat As String = ListView1.SelectedItems(0).Text
            BG3Editor_Template_Undefined1.Label = Stat
            BG3Editor_Template_Undefined1.Key = Stat
            Dim att As LSLib.LS.AttributeType
            If LSLib.LS.AttributeType.TryParse(Of LSLib.LS.AttributeType)(ListView1.SelectedItems(0).SubItems(1).Text, att) Then
                BG3Editor_Template_Undefined1.AttributeType = att
            Else
                BG3Editor_Template_Undefined1.AttributeType = AttributeType.FixedString
                Debugger.Break()
            End If
            Select Case att
                Case AttributeType.Bool
                    BG3Editor_Template_Undefined1.EditorType = BG3_Editor_Type.Combobox
                    BG3Editor_Template_Undefined1.ComboItems = New List(Of String) From {"False", "True"}
                    BG3Editor_Template_Undefined1.Reload_Combo()
                Case Else
                    BG3Editor_Template_Undefined1.EditorType = BG3_Editor_Type.Textbox
            End Select
            BG3Editor_Template_Undefined1.CheckBox1.Enabled = True
            BG3Editor_Template_Undefined1.TextBox1.Text = GetValueString(BG3Editor_Template_Undefined1.Key)
            BG3Editor_Template_Undefined1.Enabled = Not [ReadOnly]
        Else
            BG3Editor_Template_Undefined1.Enabled = False
            ButtonOk.Enabled = False
            BG3Editor_Template_Undefined1.Label = "Select"
            BG3Editor_Template_Undefined1.Key = "Undefined"
            BG3Editor_Template_Undefined1.AttributeType = AttributeType.FixedString
            BG3Editor_Template_Undefined1.Clear()
        End If

    End Sub

    Private Sub BG3Editor_Stats_Undefined1_TextChanged(sender As Object) Handles BG3Editor_Template_Undefined1.Inside_Text_Changed, BG3Editor_Template_Undefined1.Inside_Checkbox_Changed
        ButtonOk.Enabled = BG3Editor_Template_Undefined1.Enabled
    End Sub

    Private Sub ButtonOk_Click(sender As Object, e As EventArgs) Handles ButtonOk.Click
        If ListView1.SelectedItems.Count = 0 Then Exit Sub
        If BG3Editor_Template_Undefined1.Key = "Undefined" Then Exit Sub
        Dim oldv As String = ""
        Try
            oldv = ListView1.SelectedItems(0).SubItems(2).Text
            ListView1.SelectedItems(0).SubItems(2).Text = BG3Editor_Template_Undefined1.TextBox1.Text
            Dim esparentnode = TreeView1.SelectedNode Is TreeView1.Nodes(0)
            If BG3Editor_Template_Undefined1.CheckBox1.Checked = False Then
                _Last_read.Attributes.Remove(BG3Editor_Template_Undefined1.Key)
            Else
                BG3Editor_Template_Undefined1.Write(_Last_read)
            End If
            Dim valor As String = GetValueString(BG3Editor_Template_Undefined1.Key)
            ListView1.SelectedItems(0).SubItems.Item(2).Text = valor
            ColorSubitem(BG3Editor_Template_Undefined1.Key, ListView1.SelectedItems(0))
            BG3Editor_Template_Undefined1.TextBox1.Text = valor
        Catch ex As Exception
            BG3Editor_Template_Undefined1.TextBox1.Text = oldv
            MsgBox("Error parsing the text to value. Try again", vbExclamation + vbOKOnly, "Error")
        End Try
        ButtonOk.Enabled = False
    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        Read(CType(e.Node.Tag, LSLib.LS.Node))
        ListBox1_SelectedIndexChanged(Me, New EventArgs)
        procesaButtons()
    End Sub
    Private Sub procesaButtons()
        If IsNothing(TreeView1.SelectedNode) Then
            ButtonDeleteNode.Enabled = False
            ButtonAddNode.Enabled = False
            ComboBox1.Enabled = False
        Else
            ButtonDeleteNode.Enabled = TreeView1.SelectedNode IsNot TreeView1.Nodes(0)

            Dim prefix = TreeView1.SelectedNode.FullPath + "\"
            Dim esparentnode = TreeView1.SelectedNode Is TreeView1.Nodes(0)
            Dim filtro As IEnumerable(Of String)
            Select Case _Last_OBJ.GetType
                Case GetType(BG3_Obj_Template_Class)
                    filtro = FuncionesHelpers.GameEngine.ProcessedGameObjectList.Attributes_Stats_List.Where(Function(pf) pf.Key.StartsWith(prefix, StringComparison.OrdinalIgnoreCase) AndAlso pf.Key.EndsWith(";" + CType(_Last_OBJ, BG3_Obj_Template_Class).Type.ToString, StringComparison.OrdinalIgnoreCase) = True).Select(Function(pf) pf.Key.Split(";")(0).Replace(prefix, "")).Select(Function(pf) CType(IIf(pf.Contains("\"c), pf.Split("\")(0), pf), String)).Distinct
                Case GetType(BG3_Obj_FlagsAndTags_Class)
                    filtro = FuncionesHelpers.GameEngine.ProcessedFlagsAndTags.Attributes_Stats_List.Where(Function(pf) pf.Key.StartsWith(prefix, StringComparison.OrdinalIgnoreCase) AndAlso pf.Key.EndsWith(";" + CType(_Last_OBJ, BG3_Obj_FlagsAndTags_Class).Type.ToString, StringComparison.OrdinalIgnoreCase) = True).Select(Function(pf) pf.Key.Split(";")(0).Replace(prefix, "")).Select(Function(pf) CType(IIf(pf.Contains("\"c), pf.Split("\")(0), pf), String)).Distinct
                Case GetType(BG3_Obj_VisualBank_Class)
                    filtro = FuncionesHelpers.GameEngine.ProcessedVisualBanksList.Attributes_Stats_List.Where(Function(pf) pf.Key.StartsWith(prefix, StringComparison.OrdinalIgnoreCase) AndAlso pf.Key.EndsWith(";" + CType(_Last_OBJ, BG3_Obj_VisualBank_Class).Type.ToString, StringComparison.OrdinalIgnoreCase) = True).Select(Function(pf) pf.Key.Split(";")(0).Replace(prefix, "")).Select(Function(pf) CType(IIf(pf.Contains("\"c), pf.Split("\")(0), pf), String)).Distinct
                Case Else
                    filtro = Nothing
                    Debugger.Break()
            End Select
            ComboBox1.Items.Clear()
            If Not IsNothing(filtro) Then ComboBox1.Items.AddRange(filtro.ToArray) 'filtro.Where(Function(pf) ParentHandledNodesList.Contains(prefix + pf) = False).ToArray) ' OJO QUE SI NO MANEJO TODO
            If ComboBox1.Items.Count > 0 Then ComboBox1.SelectedIndex = 0
            ComboBox1.Enabled = ComboBox1.Items.Count > 0
            ButtonAddNode.Enabled = ComboBox1.Items.Count > 0
        End If
    End Sub

    Private Sub ButtonAddNode_Click(sender As Object, e As EventArgs) Handles ButtonAddNode.Click
        Dim nombre As String = ComboBox1.Items(ComboBox1.SelectedIndex)
        Dim Completo = TreeView1.SelectedNode.FullPath + "\" + nombre
        If ParentHandledNodesList.Contains(Completo) Then
            If MsgBox("Seems you are adding an already managed node. ¿Are you sure, it could cause problems?", vbInformation + vbYesNo, "Warning") = MsgBoxResult.No Then Exit Sub
        End If
        Dim child As New LSLib.LS.Node With {.Name = nombre}
        _Last_read.AppendChild(child)
        Dim treenod2 As New System.Windows.Forms.TreeNode With {.Text = child.Name, .Tag = child}
        TreeView1.SelectedNode.Nodes.Add(treenod2)
        TreeView1.SelectedNode = treenod2
    End Sub

    Private Sub ButtonDeleteNode_Click(sender As Object, e As EventArgs) Handles ButtonDeleteNode.Click
        Dim nodtodelete As LSLib.LS.Node = TreeView1.SelectedNode.Tag
        Dim parent = TreeView1.SelectedNode.Parent
        Dim Parentnod As LSLib.LS.Node = TreeView1.SelectedNode.Parent.Tag
        Dim coleccion As List(Of LSLib.LS.Node) = Nothing
        Parentnod.Children.Remove(nodtodelete.Name, coleccion)
        For Each child In coleccion
            If child IsNot nodtodelete Then
                Parentnod.AppendChild(child)
            End If
        Next
        TreeView1.SelectedNode.Remove()
        TreeView1.SelectedNode = parent

    End Sub
    Private _CopiedNode As LSLib.LS.Node
    Private Sub ContextMenuStrip2_Opening(sender As Object, e As CancelEventArgs) Handles ContextMenuStripAttributes.Opening
        If TreeView1.Nodes.Count > 0 Then
            CopyValueToolStripMenuItem.Enabled = Not IsNothing(ListView1.SelectedItems) AndAlso ListView1.SelectedItems.Count <> 0 AndAlso ListView1.SelectedItems(0).SubItems(2).Text <> ""
            AddAttributeToolStripMenuItem.Enabled = Not IsNothing(TreeView1.SelectedNode) AndAlso GroupBoxNodesEdit.Enabled
        Else
            e.Cancel = True
        End If
    End Sub
    Private Sub ContextMenuStrip1_Opening(sender As Object, e As CancelEventArgs) Handles ContextMenuStripNodes.Opening
        If TreeView1.Nodes.Count > 0 Then
            DeleteNodeToolStripMenuItem.Enabled = TreeView1.SelectedNode IsNot TreeView1.Nodes(0) AndAlso GroupBoxNodesEdit.Enabled = True
            CopyNodeToolStripMenuItem.Enabled = TreeView1.SelectedNode IsNot TreeView1.Nodes(0)
            PasteNodeToolStripMenuItem.Enabled = Not IsNothing(_CopiedNode) AndAlso ComboBox1.Items.IndexOf(_CopiedNode.Name) <> -1 AndAlso GroupBoxNodesEdit.Enabled = True
        Else
            e.Cancel = True
        End If
    End Sub
    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyNodeToolStripMenuItem.Click
        _CopiedNode = TreeView1.SelectedNode.Tag
    End Sub
    Private Sub DeleteNodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteNodeToolStripMenuItem.Click
        ButtonDeleteNode.PerformClick()
    End Sub
    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteNodeToolStripMenuItem.Click
        If ComboBox1.Items.IndexOf(_CopiedNode.Name) <> -1 Then
            ComboBox1.SelectedIndex = ComboBox1.Items.IndexOf(_CopiedNode.Name)
            Dim child = _CopiedNode.CloneNode
            _Last_read.AppendChild(child)
            Dim treenod2 As New System.Windows.Forms.TreeNode With {.Text = child.Name, .Tag = child}
            TreeView1.SelectedNode.Nodes.Add(treenod2)
            ReadNodes(treenod2, child)
            treenod2.ExpandAll()
            TreeView1.SelectedNode = treenod2
            'ButtonAddNode.PerformClick()
        End If
    End Sub

    Private Sub CopySelectedValueToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyValueToolStripMenuItem.Click
        If ListView1.SelectedItems.Count <> 0 Then
            Dim str = ListView1.SelectedItems(0).SubItems(2).Text
            If str <> "" Then Clipboard.SetText(str)
        End If
    End Sub

    Private Sub AddAttributeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddAttributeToolStripMenuItem.Click
        Dim keys = OpenGetAttNameForm("Attribute name")
        Dim key As String = keys.Item1
        If key <> "" Then
            If DefaultList.Contains(key) OrElse CustomList.Contains(key) OrElse ParentHandledList.Contains(key) Then
                MsgBox("Attribute already exits", vbInformation + vbOKOnly, "Not added")
            Else
                CustomList.Add(keys.Item1)
                ColorSubitem(keys.Item1, Agrega_Item(keys.Item1, keys.Item2))
            End If

        End If

    End Sub
    Private Function OpenGetAttNameForm(Propuesto As String) As Tuple(Of String, String)
        Dim Form As New AddAttribute With {.StartPosition = FormStartPosition.Manual}
        Form.Location = Me.ListView1.PointToScreen(New Point(-7, 0))
        Form.TextBox1.Text = Propuesto
        Form.ShowDialog()
        If Form.DialogResult <> DialogResult.OK Then Return New Tuple(Of String, String)("", "")
        Return New Tuple(Of String, String)(Form.TextBox1.Text, Form.ComboBox1.Items(Form.ComboBox1.SelectedIndex))
    End Function
End Class
