Imports System.ComponentModel
Imports System.Net.NetworkInformation
Imports System.Runtime.InteropServices.JavaScript.JSType
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Tab
Imports LSLib.Granny
Imports LSLib.LS
Imports LSLib.LS.Story
Public Class BG3Editor_Complex_Advanced_Stats
    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.DoubleBuffered = True
        Flickering.EnableDoubleBuffering(ListView1)
    End Sub

    Private _readonly As Boolean = False
    Public Property [ReadOnly] As Boolean
        Get
            Return _readonly
        End Get
        Set(value As Boolean)
            BG3Editor_Stats_Undefined1.Enabled = Not value
            _readonly = value
        End Set
    End Property

    Private ReadOnly Property ParentHandledList As List(Of String)
        Get
            Try
                Return CType(ParentForm, Object).HandledStats
            Catch ex As Exception
                Debugger.Break()
                Return New List(Of String)
            End Try
        End Get
    End Property

    Private _Last_read As BG3_Obj_Stats_Class = Nothing
    Private _selected As System.Windows.Forms.TreeNode
    Private _LastSelectedNode As LSLib.LS.Node
    Private DefaultList As List(Of String)
    Private CustomList As List(Of String)
    Public Sub Clear()
        _Last_read = Nothing
        ListView1.Items.Clear()
        BG3Editor_Stats_Undefined1.Label = "Select"
        BG3Editor_Stats_Undefined1.Key = "Undefined"
        DefaultList = Nothing
        CustomList = Nothing
        BG3Editor_Stats_Undefined1.Clear()
    End Sub
    Public Sub Read(Obj As BG3_Obj_Stats_Class)
        Dim last_pos As String = ""
        If ListView1.SelectedItems.Count > 0 Then last_pos = ListView1.SelectedItems(0).Text
        ListView1.BeginUpdate()
        Dim top = ListView1.TopItem
        Clear()
        _Last_read = Obj
        Dim idx As ListViewItem
        Dim filtro = FuncionesHelpers.GameEngine.ProcessedStatList.Attributes_Stats_List.Where(Function(pf) ParentHandledList.Contains(pf.Value) = False AndAlso pf.Key.EndsWith(";" + CInt(Obj.Type).ToString) = True).Select(Function(pf) pf).Distinct
        DefaultList = filtro.Select(Function(pf) pf.Value).ToList

        For Each stat In filtro
            idx = Agrega_Item(stat.Value, "data")
            If Not IsNothing(top) AndAlso idx.Name = top.Name Then top = idx
            If idx.Text = last_pos Then idx.Selected = True
        Next

        CustomList = _Last_read.Data.Where(Function(pf) DefaultList.Contains(pf.Key) = False AndAlso ParentHandledList.Contains(pf.Key) = False).Select(Function(pf) pf.Key).ToList
        ' Las que no estan
        For Each stat2 In _Last_read.Data.Where(Function(pf) DefaultList.Contains(pf.Key) = False AndAlso ParentHandledList.Contains(pf.Key) = False)
            idx = Agrega_Item(stat2.Key, "data")
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
        Dim val As String = Nothing
        _Last_read.Data.TryGetValue(Key, val)
        If Not IsNothing(val) Then
            If DefaultList.Contains(Key) Then
                Subitem.ForeColor = Color.FromKnownColor(KnownColor.Highlight)
            Else
                Subitem.ForeColor = Color.FromKnownColor(KnownColor.Red)
            End If
        Else
            Subitem.ForeColor = Color.FromKnownColor(KnownColor.ControlText)
        End If
    End Sub
    Private Function GetValueString(Key As String) As String
        Return _Last_read.Get_Data_Or_Inherited_or_Empty(Key)
    End Function
    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.ItemSelectionChanged
        If ListView1.SelectedItems.Count <> 0 Then
            Dim Stat As String = ListView1.SelectedItems(0).Text
            BG3Editor_Stats_Undefined1.Label = Stat
            BG3Editor_Stats_Undefined1.Key = Stat
            BG3Editor_Stats_Undefined1.TextBox1.Text = GetValueString(BG3Editor_Stats_Undefined1.Key)
        Else
            BG3Editor_Stats_Undefined1.Label = "Select"
            BG3Editor_Stats_Undefined1.Key = "Undefined"
            BG3Editor_Stats_Undefined1.Clear()
        End If

    End Sub
    Private Sub BG3Editor_Stats_Undefined1_TextChanged(sender As Object) Handles BG3Editor_Stats_Undefined1.Inside_Text_Changed, BG3Editor_Stats_Undefined1.Inside_Checkbox_Changed
        ButtonOk.Enabled = BG3Editor_Stats_Undefined1.Enabled
    End Sub
    Private Sub ContextMenuStrip2_Opening(sender As Object, e As CancelEventArgs) Handles ContextMenuStripKeys.Opening
        CopyValueToolStripMenuItem.Enabled = Not IsNothing(ListView1.SelectedItems) AndAlso ListView1.SelectedItems.Count <> 0 AndAlso ListView1.SelectedItems(0).SubItems(2).Text <> ""
        AddAttributeToolStripMenuItem.Enabled = BG3Editor_Stats_Undefined1.Enabled
    End Sub

    Private Sub CopySelectedValueToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyValueToolStripMenuItem.Click
        If ListView1.SelectedItems.Count <> 0 Then
            Dim str = ListView1.SelectedItems(0).SubItems(2).Text
            If str <> "" Then Clipboard.SetText(str)
        End If
    End Sub
    Private Sub AddAttributeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddAttributeToolStripMenuItem.Click
        Dim keys = OpenGetAttNameForm("Key name")
        Dim key As String = keys.Item1
        If key <> "" Then
            If DefaultList.Contains(key) OrElse CustomList.Contains(key) OrElse ParentHandledList.Contains(key) Then
                MsgBox("Key already exits", vbInformation + vbOKOnly, "Not added")
            Else
                CustomList.Add(keys.Item1)
                Dim sel = Agrega_Item(keys.Item1, "data")
                _Last_read.Data.TryAdd(keys.Item1, keys.Item2)
                sel.SubItems(2).Text = keys.Item2
                ColorSubitem(keys.Item1, sel)
            End If

        End If

    End Sub
    Private Function OpenGetAttNameForm(Propuesto As String) As Tuple(Of String, String)
        Dim Form As New AddAkey With {.StartPosition = FormStartPosition.Manual}
        Form.Text = "Key name"
        Form.Location = Me.ListView1.PointToScreen(New Point(-7, 0))
        Form.TextBox1.Text = Propuesto
        Form.ShowDialog()
        If Form.DialogResult <> DialogResult.OK Then Return New Tuple(Of String, String)("", "")
        Return New Tuple(Of String, String)(Form.TextBox1.Text, Form.TextBox2.Text)
    End Function

    Private Sub ButtonOk_Click(sender As Object, e As EventArgs) Handles ButtonOk.Click
        If ListView1.SelectedItems.Count = 0 Then Exit Sub
        If BG3Editor_Stats_Undefined1.Key = "Undefined" Then Exit Sub
        Dim oldv As String = ""
        Try
            oldv = ListView1.SelectedItems(0).SubItems(2).Text
            ListView1.SelectedItems(0).SubItems(2).Text = BG3Editor_Stats_Undefined1.TextBox1.Text
            If BG3Editor_Stats_Undefined1.CheckBox1.Checked = False Then
                _Last_read.Data.Remove(BG3Editor_Stats_Undefined1.Key)
            Else
                BG3Editor_Stats_Undefined1.Write(_Last_read)
            End If
            Dim valor As String = _Last_read.Get_Data_or_Empty(BG3Editor_Stats_Undefined1.Key)
            ListView1.SelectedItems(0).SubItems.Item(2).Text = valor
            ColorSubitem(BG3Editor_Stats_Undefined1.Key, ListView1.SelectedItems(0))
            BG3Editor_Stats_Undefined1.TextBox1.Text = valor
        Catch ex As Exception
            BG3Editor_Stats_Undefined1.TextBox1.Text = oldv
            MsgBox("Error parsing the text to value. Try again", vbExclamation + vbOKOnly, "Error")
        End Try
        ButtonOk.Enabled = False
    End Sub
End Class
