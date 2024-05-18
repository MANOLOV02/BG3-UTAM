Imports System.Runtime.InteropServices.JavaScript.JSType

Public Class BG3Editor_Complex_Advanced_Stats
    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.DoubleBuffered = True
        Flickering.EnableDoubleBuffering(ListView1)
    End Sub
    Public Property [ReadOnly] As Boolean
        Get
            Return BG3Editor_Stats_Undefined1.Enabled
        End Get
        Set(value As Boolean)
            BG3Editor_Stats_Undefined1.Enabled = value
            ButtonOk.Enabled = Not value
        End Set
    End Property

    Private ReadOnly Property ParentHandledList As List(Of String)
        Get
            Try
                Return CType(ParentForm, Generic_Editor).HandledStats
            Catch ex As Exception
                Debugger.Break()
                Return New List(Of String)
            End Try
        End Get
    End Property

    Private _Last_read As BG3_Obj_Stats_Class = Nothing
    Public Sub Clear()
        _Last_read = Nothing
        ListView1.Items.Clear()
        BG3Editor_Stats_Undefined1.Label = "Select"
        BG3Editor_Stats_Undefined1.Key = "Undefined"
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
        For Each stat In FuncionesHelpers.GameEngine.ProcessedStatList.Attributes_Stats_List.Where(Function(pf) ParentHandledList.Contains(pf.Value) = False AndAlso pf.Key.EndsWith(";" + CInt(Obj.Type).ToString) = True).Select(Function(pf) pf).Distinct
            idx = New ListViewItem With {.Text = stat.Value}
            idx.SubItems.Add("data")
            idx.SubItems.Add(Obj.Get_Data_Or_Inherited(stat.Value))
            idx = ListView1.Items.Add(idx)
            If Not IsNothing(top) AndAlso idx.Name = top.Name Then top = idx
            If idx.Text = last_pos Then idx.Selected = True
            If IsNothing(Obj.Get_Data_Or_Inherited(stat.Value)) Then
                idx.ForeColor = Color.FromKnownColor(KnownColor.GrayText)
            Else
                If _Last_read.Data.ContainsKey(stat.Value) = False Then
                    idx.ForeColor = Color.FromKnownColor(KnownColor.ControlText)
                Else
                    idx.ForeColor = Color.FromKnownColor(KnownColor.Highlight)
                End If
            End If
        Next
        ListView1.Columns(0).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
        ListView1.Columns(1).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
        If ListView1.Columns(1).Width < 100 Then ListView1.Columns(1).Width = 100
        ListView1.Columns(2).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
        ListView1.TopItem = top
        ListView1.EndUpdate()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.ItemSelectionChanged
        If ListView1.SelectedItems.Count <> 0 Then
            Dim Stat As String = ListView1.SelectedItems(0).Text
            BG3Editor_Stats_Undefined1.Label = Stat
            BG3Editor_Stats_Undefined1.Key = Stat
            BG3Editor_Stats_Undefined1.Read(_Last_read)
        Else
            BG3Editor_Stats_Undefined1.Label = "Select"
            BG3Editor_Stats_Undefined1.Key = "Undefined"
            BG3Editor_Stats_Undefined1.Clear()
        End If

    End Sub
    Private Sub BG3Editor_Stats_Undefined1_TextChanged(sender As Object) Handles BG3Editor_Stats_Undefined1.Inside_Text_Changed, BG3Editor_Stats_Undefined1.Inside_Checkbox_Changed
        ButtonOk.Enabled = BG3Editor_Stats_Undefined1.Enabled
    End Sub
    Private Sub ButtonOk_Click(sender As Object, e As EventArgs) Handles ButtonOk.Click
        If ListView1.SelectedItems.Count = 0 Then Exit Sub
        If BG3Editor_Stats_Undefined1.Key = "Undefined" Then Exit Sub
        Dim oldv As String = ""
        Try
            oldv = ListView1.SelectedItems(0).SubItems(2).Text
            ListView1.SelectedItems(0).SubItems(2).Text = BG3Editor_Stats_Undefined1.TextBox1.Text
            BG3Editor_Stats_Undefined1.Write(_Last_read)
            If IsNothing(_Last_read.Get_Data_Or_Inherited(BG3Editor_Stats_Undefined1.Key)) Then
                ListView1.SelectedItems(0).ForeColor = Color.FromKnownColor(KnownColor.GrayText)
            Else
                If _Last_read.Data.ContainsKey(BG3Editor_Stats_Undefined1.Key) = False Then
                    ListView1.SelectedItems(0).ForeColor = Color.FromKnownColor(KnownColor.ControlText)
                Else
                    ListView1.SelectedItems(0).ForeColor = Color.FromKnownColor(KnownColor.Highlight)
                End If
            End If
            BG3Editor_Stats_Undefined1.Write(_Last_read)
        Catch ex As Exception
            BG3Editor_Stats_Undefined1.TextBox1.Text = oldv
            MsgBox("Error parsing the text to value. Try again", vbExclamation + vbOKOnly, "Error")
        End Try
        ButtonOk.Enabled = False
    End Sub
End Class
