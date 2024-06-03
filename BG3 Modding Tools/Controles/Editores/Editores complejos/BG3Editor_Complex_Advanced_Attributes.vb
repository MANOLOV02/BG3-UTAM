Imports System.ComponentModel
Imports System.Runtime.InteropServices.JavaScript.JSType
Imports LSLib.Granny
Imports LSLib.LS

Public Class BG3Editor_Complex_Advanced_Attributes
    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.DoubleBuffered = True
        Flickering.EnableDoubleBuffering(ListView1)
    End Sub


    Private _Readonly As Boolean = True
    <DefaultValue(True)>
    Public Property [ReadOnly] As Boolean
        Get
            Return _readonly
        End Get
        Set(value As Boolean)
            _readonly = value
            BG3Editor_Template_Undefined1.Enabled = Not value
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

    Public Sub Clear()
        _Last_read = Nothing
        _Last_OBJ = Nothing
        BG3Editor_Template_Undefined1.Label = "Select"
        BG3Editor_Template_Undefined1.Key = "Undefined"
        BG3Editor_Template_Undefined1.AttributeType = AttributeType.FixedString
        BG3Editor_Template_Undefined1.Clear()
        TreeView1.Nodes.Clear()
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
                    ReadNodes(treenod2, child)
                End If
            Next
        Next
    End Sub
    Public Sub Read(Obj As BG3_Obj_Generic_Class)
        Clear()
        _Last_read = Obj.NodeLSLIB
        _Last_OBJ = Obj
        Dim treenod As New System.Windows.Forms.TreeNode With {.Text = Obj.NodeLSLIB.Name, .Tag = Obj.NodeLSLIB}
        TreeView1.Nodes.Add(treenod)
        ReadNodes(treenod, Obj.NodeLSLIB)
        treenod.ExpandAll()
        TreeView1.SelectedNode = treenod

    End Sub

    Private Sub Read(Node As LSLib.LS.Node)
        ListView1.BeginUpdate()
        Dim idx As ListViewItem
        Dim top = ListView1.TopItem
        Dim last_pos As String = ""
        If ListView1.SelectedItems.Count > 0 Then last_pos = ListView1.SelectedItems(0).Text
        ListView1.Items.Clear()
        If TreeView1.SelectedNode Is TreeView1.Nodes(0) Then
            Dim filtro As IEnumerable(Of KeyValuePair(Of String, String))
            Select Case _Last_OBJ.GetType
                Case GetType(BG3_Obj_Template_Class)
                    filtro = FuncionesHelpers.GameEngine.ProcessedGameObjectList.Attributes_Stats_List.Where(Function(pf) ParentHandledList.Contains(pf.Value) = False AndAlso pf.Key.EndsWith(";" + CInt(CType(_Last_OBJ, BG3_Obj_Template_Class).Type).ToString) = True).Select(Function(pf) pf).Distinct
                Case GetType(BG3_Obj_FlagsAndTags_Class)
                    filtro = FuncionesHelpers.GameEngine.ProcessedFlagsAndTags.Attributes_Stats_List.Where(Function(pf) ParentHandledList.Contains(pf.Value) = False AndAlso pf.Key.EndsWith(";" + CInt(CType(_Last_OBJ, BG3_Obj_FlagsAndTags_Class).Type).ToString) = True).Select(Function(pf) pf).Distinct
                Case GetType(BG3_Obj_VisualBank_Class)
                    filtro = FuncionesHelpers.GameEngine.ProcessedVisualBanksList.Attributes_Stats_List.Where(Function(pf) ParentHandledList.Contains(pf.Value) = False AndAlso pf.Key.EndsWith(";" + CInt(CType(_Last_OBJ, BG3_Obj_VisualBank_Class).Type).ToString) = True).Select(Function(pf) pf).Distinct
                Case Else
                    filtro = Nothing
                    Debugger.Break()
            End Select
            For Each stat In filtro
                idx = New ListViewItem With {.Text = stat.Value, .Name = stat.Key}
                Dim tipos() = stat.Key.Split(";")
                idx.SubItems.Add(tipos(1))
                idx.SubItems.Add(_Last_OBJ.ReadAttribute_Or_Inhterithed(stat.Value))
                idx = ListView1.Items.Add(idx)
                If Not IsNothing(top) AndAlso idx.Name = top.Name Then top = idx
                If idx.Text = last_pos Then idx.Selected = True
                If IsNothing(_Last_OBJ.ReadAttribute_Or_Inhterithed(stat.Value)) Then
                    idx.ForeColor = Color.FromKnownColor(KnownColor.GrayText)
                Else
                    If _Last_read.Attributes.ContainsKey(stat.Value) = False Then
                        idx.ForeColor = Color.FromKnownColor(KnownColor.ControlText)
                    Else
                        idx.ForeColor = Color.FromKnownColor(KnownColor.Highlight)
                    End If
                End If
            Next
        Else
            For Each attr In Node.Attributes
                Try
                    idx = New ListViewItem With {.Text = attr.Key, .Name = attr.Key}
                    idx.SubItems.Add(attr.Value.Type.ToString)
                    idx.SubItems.Add(attr.Value.AsString(Funciones.Guid_to_string))
                    idx = ListView1.Items.Add(idx)
                Catch ex As Exception

                End Try

            Next
        End If
        _Last_read = Node
        ListView1.Columns(0).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
        ListView1.Columns(1).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
        If ListView1.Columns(1).Width < 100 Then ListView1.Columns(1).Width = 100
        ListView1.Columns(2).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
        If ListView1.Columns(2).Width < 100 Then ListView1.Columns(2).Width = 100
        ListView1.EndUpdate()
        ListView1.TopItem = top
    End Sub

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
            If TreeView1.SelectedNode Is TreeView1.Nodes(0) Then
                BG3Editor_Template_Undefined1.CheckBox1.Enabled = True
                BG3Editor_Template_Undefined1.Read(_Last_OBJ.NodeLSLIB)
            Else
                BG3Editor_Template_Undefined1.CheckBox1.Enabled = False
                BG3Editor_Template_Undefined1.Read(_Last_read)
            End If
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
            If TreeView1.SelectedNode Is TreeView1.Nodes(0) Then
                BG3Editor_Template_Undefined1.Write(_Last_OBJ.NodeLSLIB)
                If IsNothing(_Last_OBJ.ReadAttribute_Or_Inhterithed(BG3Editor_Template_Undefined1.Key)) Then
                    ListView1.SelectedItems(0).ForeColor = Color.FromKnownColor(KnownColor.GrayText)
                Else
                    If _Last_read.Attributes.ContainsKey(BG3Editor_Template_Undefined1.Key) = False Then
                        ListView1.SelectedItems(0).ForeColor = Color.FromKnownColor(KnownColor.ControlText)
                    Else
                        ListView1.SelectedItems(0).ForeColor = Color.FromKnownColor(KnownColor.Highlight)
                    End If
                End If
            Else
                BG3Editor_Template_Undefined1.Write(_Last_read)
            End If
        Catch ex As Exception
            BG3Editor_Template_Undefined1.TextBox1.Text = oldv
            MsgBox("Error parsing the text to value. Try again", vbExclamation + vbOKOnly, "Error")
        End Try
        ButtonOk.Enabled = False
    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        Read(CType(e.Node.Tag, LSLib.LS.Node))
        ListBox1_SelectedIndexChanged(Me, New EventArgs)
    End Sub


End Class
