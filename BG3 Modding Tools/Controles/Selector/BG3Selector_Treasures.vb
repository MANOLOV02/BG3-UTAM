Imports System.ComponentModel
Imports System.Reflection.Emit
Imports System.Reflection.Metadata
Imports System.Runtime.Intrinsics
Imports System.Text.RegularExpressions
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ListView
Imports LSLib.Granny

Public Class BG3Selector_Treasures
    Inherits BG3Selector_Generic_Code(Of BG3_Obj_TreasureTable_Class)

    Public Overrides Sub SplitGroup(sender As Object, e As EventArgs)
        Dim spl() As String = sender.tag
        IsEditing = True
        TreeView1.BeginUpdate()
        If spl.Length > 1 Then Debugger.Break()
        Cursor.Current = Cursors.WaitCursor
        Dim prefix As String = Current_Group
        Dim queleo As String = spl(0).Split("|")(0)
        Dim Attr_or_data As String = spl(0).Split("|")(1)
        Dim actualnod = Current_Group_nod
        Dim ngrup = Current_Group_nod
        Dim nuevos_grupoas As New SortedList(Of String, BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_TreasureTable_Class))
        For x = actualnod.Nodes.Count - 1 To 0 Step -1
            Dim nod = actualnod.Nodes(x)
            Dim selectedtmp As BG3_Obj_TreasureTable_Class = CType(CType(nod, Object).objeto, BG3_Obj_TreasureTable_Class)
            Dim suffix As String = "_" + Attr_or_data + "_"
            Select Case queleo
                Case "Data"
                    'suffix += selectedtmp.Get_Data_Or_Inherited_or_Empty(Attr_or_data)
                Case "Attribute"
                    suffix += selectedtmp.ReadAttribute_Or_Inhterithed_Or_Empty(Attr_or_data)
                Case "Custom"
                    RaiseEvent FillSplit(Attr_or_data, CType(CType(selectedtmp, Object), BG3_Obj_TreasureTable_Class), suffix)
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
        If actualnod.Nodes.Count = 0 Then
            Groups.Remove(Safe_node_key(actualnod.Text))
            actualnod.Remove()
            BG3Editor_Template_UtamGroup1.Update_Groups(Groups)
        End If
        Cursor.Current = Cursors.Default
        TreeView1.EndUpdate()
        TreeView1.SelectedNode = ngrup
        CType(Me.ParentForm.MdiParent, Main).ChangedMod()
    End Sub

    Public Event FillSplit(ByVal Attr_or_data As String, ByRef selectedtmp As BG3_Obj_TreasureTable_Class, ByRef suffix As String)

End Class
