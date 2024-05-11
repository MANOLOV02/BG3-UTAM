Imports LSLib
Imports LSLib.LS

Public Class BG3Editor_Template_Container_TT
    Inherits Editor_Template_GenericAttribute
    Sub New()
        MyBase.New("Object")
        Label = "Treasure table"
    End Sub
    Public Overrides Function Create_Attribute(ByRef Que As LSLib.LS.Node, value As String) As Boolean
        Dim lisi As List(Of LSLib.LS.Node) = Nothing
        Dim invlist As LSLib.LS.Node
        Dim invit As LSLib.LS.Node
        If Que.Children.TryGetValue("InventoryList", lisi) = True Then
            invlist = lisi.First
        Else
            invlist = New LSLib.LS.Node With {.Name = "InventoryList"}
            Que.Children.Add("InventoryList", New List(Of Node) From {invlist})
        End If
        If invlist.Children.TryGetValue("InventoryItem", lisi) = False Then
            invit = New LSLib.LS.Node With {.Name = "InventoryItem"}
            invit.Attributes.Add("Object", (New LSLib.LS.NodeAttribute(AttributeType.FixedString) With {.Value = value}))
            invlist.Children.Add("InventoryItem", New List(Of Node) From {invit})
        End If

        'Dim invit As New LSLib.LS.Node With {.Name = "InventoryItem"}
        'invit.Attributes.Add("Object", (New LSLib.LS.NodeAttribute(AttributeType.FixedString) With {.Value = value}))
        'Dim invlist As New LSLib.LS.Node With {.Name = "InventoryList"}
        'invlist.Children.Add("children", New List(Of Node) From {invit})
        'Que.Children.Add("children", New List(Of Node) From {invlist})
        Return True
    End Function
    Public Overrides Function Replace_Attribute(ByRef Que As LSLib.LS.Node, value As String) As Boolean
        Dim lisi As List(Of LSLib.LS.Node) = Nothing
        Dim invlist As LSLib.LS.Node
        Dim invit As LSLib.LS.Node
        If Que.Children.TryGetValue("InventoryList", lisi) = True Then
            invlist = lisi.First
        Else
            invlist = New LSLib.LS.Node With {.Name = "InventoryList"}
            Que.AppendChild(invlist)
        End If
        If invlist.Children.TryGetValue("InventoryItem", lisi) = True Then
            invit = lisi.First
            If invit.Attributes.TryAdd("Object", (New LSLib.LS.NodeAttribute(AttributeType.FixedString) With {.Value = value})) = False Then
                invit.Attributes("Object").Value = value
            End If
        Else
            invit = New LSLib.LS.Node With {.Name = "InventoryItem"}
            invit.Attributes.Add("Object", (New LSLib.LS.NodeAttribute(AttributeType.FixedString) With {.Value = value}))
            invlist.AppendChild(invit)
        End If

        'Dim invit As New LSLib.LS.Node With {.Name = "InventoryItem"}
        'invit.Attributes.Add("Object", (New LSLib.LS.NodeAttribute(AttributeType.FixedString) With {.Value = value}))
        'Dim invlist As New LSLib.LS.Node With {.Name = "InventoryList"}
        'invlist.Children.Add("children", New List(Of Node) From {invit})
        'Que.Children.Add("children", New List(Of Node) From {invlist})
        Return True
    End Function

    Public Overrides Function Read(Que As BG3_Obj_Template_Class) As Boolean
        Last_read = Que
        Dim value As LSLib.LS.NodeAttribute = Nothing
        Que.NodeLSLIB.Children("InventoryList").First.Children("InventoryItem").First.Attributes.TryGetValue(Key, value)
        Return Get_ValueString(value)
    End Function
    Public Overrides Function Write(Que As BG3_Obj_Template_Class) As Boolean
        If Me.AllowEdit = False Then Return False
        If Me.AllowEdit = True Then
            Dim valueString As String = Set_ValueString(Que)
            Dim value As LSLib.LS.NodeAttribute = Conver_String_to_Node(valueString)
            If Que.NodeLSLIB.Children("InventoryList").First.Children("InventoryItem").First.Attributes.TryAdd(Key, value) = False Then
                Que.NodeLSLIB.Children("InventoryList").First.Children("InventoryItem").First.Attributes(Key) = value
                Return True
            End If
            Return True
        End If

        Return False
    End Function
    Public Overrides Function Conditional_Changed(Que As BG3_Obj_Template_Class) As Boolean
        If Me.EditIsConditional = True AndAlso CheckBox1.Checked = False Then
            If Not IsNothing(Que.Parent) Then
                TextBox1.Text = Conditional_GetParent_Value(Que.Parent)
                Return True
            Else
                TextBox1.Text = ""
                Return False
            End If
        End If
        Dim value As LSLib.LS.NodeAttribute = Nothing
        Que.NodeLSLIB.Attributes.TryGetValue(Key, value)
        Return Get_ValueString(value)
    End Function
End Class
