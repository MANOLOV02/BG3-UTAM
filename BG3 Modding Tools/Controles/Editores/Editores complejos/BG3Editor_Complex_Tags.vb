Public Class BG3Editor_Complex_Tags

    Private ReadOnly Inheriteds As New SortedList(Of String, String)
    Private ReadOnly Owned As New SortedList(Of String, String)

    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Function Read(obj As BG3_Obj_Template_Class) As Boolean
        Clear()
        Dim objtag As BG3_Obj_FlagsAndTags_Class = Nothing
        For Each Tags In obj.GetTags_Ids
            If FuncionesHelpers.GameEngine.ProcessedFlagsAndTags.TryGetValue(Tags, objtag) = True Then
                Owned.TryAdd(objtag.MapKey, objtag.Name)
                ListBox2.Items.Add(New BG3_Custom_ComboboxItem(objtag.Name, objtag.MapKey))
            End If
        Next

        Dim current As BG3_Obj_Template_Class = obj.Parent
        While Not IsNothing(current)
            For Each Tags In current.GetTags_Ids
                If FuncionesHelpers.GameEngine.ProcessedFlagsAndTags.TryGetValue(Tags, objtag) = True Then
                    Inheriteds.TryAdd(objtag.MapKey, objtag.Name)
                    ListBox1.Items.Add(New BG3_Custom_ComboboxItem(objtag.Name, objtag.MapKey))
                End If
            Next
            current = current.Parent
        End While
        Return True
    End Function
    Public Function Write(obj As BG3_Obj_Template_Class) As Boolean
        Dim copyowned = New List(Of String)
        Dim value As List(Of LSLib.LS.Node) = Nothing
        If obj.NodeLSLIB.Children.TryGetValue("Tags", value) Then
            Dim value2 As List(Of LSLib.LS.Node) = Nothing
            If value.First.Children.TryGetValue("Tag", value2) Then
                For Each child In value2.ToList
                    Dim key As String = child.TryGetOrEmpty("Object").ToString
                    If Owned.ContainsKey(key) = False Then
                        obj.NodeLSLIB.Children("Tags").First.Children("Tag").Remove(child)
                    Else
                        copyowned.Add(key)
                    End If
                Next
            End If
        Else
            obj.NodeLSLIB.AppendChild(New LSLib.LS.Node With {.Name = "Tags"})
        End If

        Dim par = obj.NodeLSLIB.Children("Tags").First
        For Each key In Owned.Keys
            If copyowned.Contains(key) = False Then
                Dim nod As New LSLib.LS.Node With {.Name = "Tag", .Parent = par}
                Editor_Template_GenericAttribute.Create_Attribute_Generic(nod, "Object", key, LSLib.LS.AttributeType.UUID)
                par.AppendChild(nod)
            End If
        Next
        If par.ChildCount = 0 Then obj.NodeLSLIB.Children.Remove("Tags")

        Return True
    End Function

    Public Sub Clear()
        Owned.Clear()
        Inheriteds.Clear()
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
    End Sub

    Private Sub ListBox2_DragEnter(sender As Object, e As DragEventArgs) Handles ListBox2.DragEnter
        If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_FlagsAndTags_Class))) Then
            Dim obj As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_FlagsAndTags_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_FlagsAndTags_Class)))
            If Not IsNothing(obj.Objeto) Then
                If CType(obj.Objeto, BG3_Obj_FlagsAndTags_Class).Type = BG3_Enum_FlagsandTagsType.Tags Then
                    e.Effect = DragDropEffects.Copy
                    Exit Sub
                End If
            End If
        End If
        e.Effect = DragDropEffects.None
    End Sub
    Private Sub ListBox2_DragDrop(sender As Object, e As DragEventArgs) Handles ListBox2.DragDrop
        If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_FlagsAndTags_Class))) Then
            Dim obj As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_FlagsAndTags_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_FlagsAndTags_Class)))
            Dim tag = CType(obj.Objeto, BG3_Obj_FlagsAndTags_Class)
            If tag.Type = BG3_Enum_FlagsandTagsType.Tags Then
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
