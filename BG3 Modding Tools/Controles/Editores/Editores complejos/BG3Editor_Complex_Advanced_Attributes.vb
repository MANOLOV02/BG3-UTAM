Imports System.Runtime.InteropServices.JavaScript.JSType
Imports LSLib.LS

Public Class BG3Editor_Complex_Advanced_Attributes
    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.DoubleBuffered = True
        Flickering.EnableDoubleBuffering(ListView1)
    End Sub
    Public Property [ReadOnly] As Boolean
        Get
            Return BG3Editor_Template_Undefined1.Enabled
        End Get
        Set(value As Boolean)
            BG3Editor_Template_Undefined1.Enabled = value
        End Set
    End Property

    Private ReadOnly Property ParentHandledList As List(Of String)
        Get
            Try
                Return CType(ParentForm, Generic_Editor).HandledAttributes
            Catch ex As Exception
                Debugger.Break()
                Return New List(Of String)
            End Try
        End Get
    End Property

    Private _Last_read As BG3_Obj_Template_Class = Nothing
    Public Sub Clear()
        _Last_read = Nothing
        ListView1.Items.Clear()
        BG3Editor_Template_Undefined1.Label = "Select"
        BG3Editor_Template_Undefined1.Key = "Undefined"
        BG3Editor_Template_Undefined1.AttributeType = AttributeType.FixedString
        BG3Editor_Template_Undefined1.Clear()
    End Sub
    Public Sub Read(Obj As BG3_Obj_Template_Class)
        Dim last_pos As String = ""
        If ListView1.SelectedItems.Count > 0 Then last_pos = ListView1.SelectedItems(0).Text
        ListView1.BeginUpdate()
        Clear()
        _Last_read = Obj
        Dim idx As ListViewItem
        For Each stat In FuncionesHelpers.GameEngine.ProcessedGameObjectList.Attributes_Stats_List.Where(Function(pf) ParentHandledList.Contains(pf.Value) = False AndAlso pf.Key.EndsWith(";" + CInt(Obj.Type).ToString) = True).Select(Function(pf) pf).Distinct
            idx = New ListViewItem With {.Text = stat.Value}
            Dim tipos() = stat.Key.Split(";")
            idx.SubItems.Add(tipos(1))
            idx.SubItems.Add(Obj.ReadAttribute_Or_Inhterithed(stat.Value))
            idx = ListView1.Items.Add(idx)
            If idx.Text = last_pos Then idx.Selected = True
            If IsNothing(Obj.ReadAttribute_Or_Inhterithed(stat.Value)) Then
                idx.ForeColor = Color.FromKnownColor(KnownColor.GrayText)
            Else
                If _Last_read.NodeLSLIB.Attributes.ContainsKey(stat.Value) = False Then
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
        ListView1.EndUpdate()
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
            BG3Editor_Template_Undefined1.Read(_Last_read)
            Else
                BG3Editor_Template_Undefined1.Label = "Select"
            BG3Editor_Template_Undefined1.Key = "Undefined"
            BG3Editor_Template_Undefined1.AttributeType = AttributeType.FixedString
            BG3Editor_Template_Undefined1.Clear()
        End If

    End Sub

    Private Sub BG3Editor_Stats_Undefined1_TextChanged(sender As Object) Handles BG3Editor_Template_Undefined1.Inside_Text_Changed, BG3Editor_Template_Undefined1.Inside_Checkbox_Changed
        If ListView1.SelectedItems.Count = 0 Then Exit Sub
        If BG3Editor_Template_Undefined1.Key = "Undefined" Then Exit Sub
        ListView1.SelectedItems(0).SubItems(2).Text = BG3Editor_Template_Undefined1.TextBox1.Text
        BG3Editor_Template_Undefined1.Write(_Last_read)
        If IsNothing(_Last_read.ReadAttribute_Or_Inhterithed(BG3Editor_Template_Undefined1.Key)) Then
            ListView1.SelectedItems(0).ForeColor = Color.FromKnownColor(KnownColor.GrayText)
        Else
            If _Last_read.NodeLSLIB.Attributes.ContainsKey(BG3Editor_Template_Undefined1.Key) = False Then
                ListView1.SelectedItems(0).ForeColor = Color.FromKnownColor(KnownColor.ControlText)
            Else
                ListView1.SelectedItems(0).ForeColor = Color.FromKnownColor(KnownColor.Highlight)
            End If
        End If
        BG3Editor_Template_Undefined1.Write(_Last_read)

    End Sub
End Class
