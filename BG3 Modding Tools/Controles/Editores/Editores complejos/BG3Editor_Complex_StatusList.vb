Imports LSLib.LS.Story

Public Class BG3Editor_Complex_StatusList

    Private ReadOnly Inheriteds As New SortedList(Of String, String)
    Private ReadOnly Owned As New SortedList(Of String, String)

    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Function Read(obj As BG3_Obj_Template_Class) As Boolean
        Clear()
        Dim objtag As BG3_Obj_Stats_Class = Nothing
        For Each Status In obj.GetStatus_Ids
            If FuncionesHelpers.GameEngine.ProcessedStatList.TryGetValue(Status, objtag) = True Then
                Owned.TryAdd(objtag.MapKey, objtag.Name)
                ListBox2.Items.Add(New BG3_Custom_ComboboxItem(objtag.Name, objtag.MapKey))
            End If
        Next
        If obj.NodeLSLIB.Children.ContainsKey("StatusList") = False Then
            Dim current As BG3_Obj_Template_Class = obj.Parent
            While Not IsNothing(current)
                For Each Status In current.GetStatus_Ids
                    If FuncionesHelpers.GameEngine.ProcessedStatList.TryGetValue(Status, objtag) = True Then
                        Inheriteds.TryAdd(objtag.MapKey, objtag.Name)
                        ListBox1.Items.Add(New BG3_Custom_ComboboxItem(objtag.Name, objtag.MapKey))
                    End If
                Next
                If obj.NodeLSLIB.Children.ContainsKey("StatusList") = True Then Exit While
                current = current.Parent
            End While
        End If

        Return True
    End Function
    Public Function Write(obj As BG3_Obj_Template_Class) As Boolean
        Dim copyowned = New List(Of String)
        Dim value As List(Of LSLib.LS.Node) = Nothing
        If obj.NodeLSLIB.Children.TryGetValue("StatusList", value) Then
            Dim value2 As List(Of LSLib.LS.Node) = Nothing
            If value.First.Children.TryGetValue("Status", value2) Then
                For Each child In value2.ToList
                    Dim key As String = child.TryGetOrEmpty("Object").ToString
                    If Owned.ContainsKey(key) = False Then
                        obj.NodeLSLIB.Children("StatusList").First.Children("Status").Remove(child)
                    Else
                        copyowned.Add(key)
                    End If
                Next
            End If
        Else
            obj.NodeLSLIB.AppendChild(New LSLib.LS.Node With {.Name = "StatusList"})
        End If

        Dim par = obj.NodeLSLIB.Children("StatusList").First
        For Each key In Owned.Keys
            If copyowned.Contains(key) = False Then
                Dim nod As New LSLib.LS.Node With {.Name = "Status", .Parent = par}
                Editor_Template_GenericAttribute.Create_Attribute_Generic(nod, "Object", key, LSLib.LS.AttributeType.FixedString)
                par.AppendChild(nod)
            End If
        Next
        If par.ChildCount = 0 Then obj.NodeLSLIB.Children.Remove("StatusList")

        Return True
    End Function

    Public Sub Clear()
        Owned.Clear()
        Inheriteds.Clear()
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
    End Sub

    Private Sub ListBox2_DragEnter(sender As Object, e As DragEventArgs) Handles ListBox2.DragEnter
        If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Stats_Class))) Then
            Dim obj As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Stats_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Stats_Class)))
            If Not IsNothing(obj.Objeto) Then
                If CType(obj.Objeto, BG3_Obj_Stats_Class).Type = BG3_Enum_StatType.StatusData Then
                    e.Effect = DragDropEffects.Copy
                    Exit Sub
                End If
            End If
        End If
        e.Effect = DragDropEffects.None
    End Sub
    Private Sub ListBox2_DragDrop(sender As Object, e As DragEventArgs) Handles ListBox2.DragDrop
        If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Stats_Class))) Then
            Dim obj As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Stats_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Stats_Class)))
            Dim tag = CType(obj.Objeto, BG3_Obj_Stats_Class)
            If tag.Type = BG3_Enum_StatType.StatusData Then
                If Owned.TryAdd(tag.MapKey, tag.Name) Then
                    ListBox2.Items.Add(New BG3_Custom_ComboboxItem(tag.Name, tag.MapKey))
                End If

            End If
        End If
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        If ListBox2.SelectedIndex = -1 Then Button1.Enabled = False
        Button1.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ListBox2.SelectedIndex = -1 Then Exit Sub
        Dim key = CType(ListBox2.Items(ListBox2.SelectedIndex), BG3_Custom_ComboboxItem).Value
        Owned.Remove(key)
        ListBox2.Items.RemoveAt(ListBox2.SelectedIndex)
    End Sub
End Class
