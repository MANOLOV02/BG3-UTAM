Imports LSLib
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports LSLib.Granny
Imports LSLib.LS.Story

Public Class BG3Editor_Complex_WorldInjection
    Private Last_Objeto As BG3_Obj_Stats_Class
    Private ReadOnly Property ModSource As BG3_Pak_SourceOfResource_Class
        Get
            Return CType(Me.ParentForm, Generic_Item_Editor).ActiveModSource
        End Get
    End Property
    Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Public Sub Read_Data(ByRef Objeto As BG3_Obj_Stats_Class)
        Last_Objeto = Objeto
        Dim nam As String = "I_" + Objeto.Name
        ListBox1.Items.Clear()
        Dim tabesta As Boolean
        For Each tabl In FuncionesHelpers.GameEngine.UtamTreasures.Where(Function(pf) pf.HasItem(nam, ModSource) = True)
            tabesta = False
            For Each Subt In tabl.Subtables
                If Subt.Source.Pak_Or_Folder = ModSource.Pak_Or_Folder Then
                    For Each lis In Subt.Lista
                        If lis.Item.Contains(nam, StringComparison.OrdinalIgnoreCase) Then
                            Dim lis2 As New BG3_Obj_TreasureTable_TableItem_Class(lis.Item, lis.Conditions)
                            Dim Ite As New BG3_Custom_ComboboxItem With {.Value = lis2, .Text = tabl.Mapkey_WithoutOverride}
                            ListBox1.Items.Add(Ite)
                            tabesta = True
                            Exit For
                        End If
                    Next
                    If tabesta Then Exit For
                End If
            Next
        Next
        'If ListBox1.Items.Count > 0 And ListBox1.SelectedIndex = -1 Then ListBox1.SelectedIndex = 0
    End Sub
    Public Sub Clear()
        ListBox1.Items.Clear()
    End Sub
    Public Sub Write_Data(ByRef Objeto As BG3_Obj_Stats_Class)
        If IsNothing(Objeto) Then Exit Sub
        Dim nam As String = "I_" + Objeto.Name
        Dim tabesta As Boolean
        For Each it In ListBox1.Items
            Dim tabl As BG3_Obj_TreasureTable_Class = Nothing
            If FuncionesHelpers.GameEngine.UtamTreasures.Where(Function(pf) pf.Mapkey_WithoutOverride = it.text).Any = False Then
                tabl = FuncionesHelpers.GameEngine.ProcessedTTables.Manage_Overrides(New BG3_Obj_TreasureTable_Class(ModSource, it.text) With {.CanMerge = True})
            End If
            tabl = FuncionesHelpers.GameEngine.UtamTreasures.Where(Function(pf) pf.Mapkey_WithoutOverride = it.text).First
            If tabl.Subtables.Where(Function(pf) pf.HasItem(nam, ModSource)).Any = False Then
                Dim subt As New BG3_Obj_TreasureTable_Subtable_Class(ModSource, "1,1")
                Dim lis2 As BG3_Obj_TreasureTable_TableItem_Class = it.value
                subt.Lista.Add(New BG3_Obj_TreasureTable_TableItem_Class(nam, lis2.Conditions))
                tabl.Subtables.Add(subt)
            End If
            For Each Subt In tabl.Subtables.Where(Function(pf) pf.HasItem(nam, ModSource))
                Dim lis2 As BG3_Obj_TreasureTable_TableItem_Class = it.value
                For Each lis In Subt.Lista
                    If lis.Item.Contains(nam, StringComparison.OrdinalIgnoreCase) Then
                        lis.Conditions = lis2.Conditions
                        tabesta = True
                        Exit For
                    End If
                Next
                If tabesta Then Exit For
            Next
            tabl.Edit_start()

        Next

    End Sub
    Private Sub ListBox1_DragDrop(sender As Object, e As DragEventArgs) Handles ListBox1.DragDrop
        If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_TreasureTable_Class))) Then
            Dim obj As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_TreasureTable_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_TreasureTable_Class)))
            DropTT(obj.Objeto)
        End If
        If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class))) Then
            Dim obj As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class)))
            If Not IsNothing(obj.Objeto) Then
                If CType(obj.Objeto, BG3_Obj_Template_Class).Type = BG3_Enum_Templates_Type.character Then
                    Drop_Character(obj.Objeto)
                End If
                If CType(obj.Objeto, BG3_Obj_Template_Class).Type = BG3_Enum_Templates_Type.item Then
                    Drop_Item(obj.Objeto)
                End If
            End If
        End If
    End Sub
    Private Sub Drop_Character(Obj As BG3_Obj_Template_Class)
        Dim value0 As List(Of LSLib.LS.Node) = Nothing
        If Obj.NodeLSLIB.ChildCount > 0 AndAlso Obj.NodeLSLIB.Children.TryGetValue("TradeTreasures", value0) Then
            Dim curnodes = value0
            For Each nod In curnodes
                Dim value As List(Of LSLib.LS.Node) = Nothing
                ' Primero de visuals
                If nod.ChildCount > 0 AndAlso nod.Children.TryGetValue("TreasureItem", value) Then
                    Dim curnodes2 = value
                    For Each nod2 In curnodes2
                        Dim value4 As LSLib.LS.NodeAttribute = Nothing
                        If nod2.Attributes.TryGetValue("Object", value4) Then
                            Dim tts As String = value4.Value.ToString
                            Dim ttObj As BG3_Obj_TreasureTable_Class = Nothing
                            If tts <> "Empty" AndAlso FuncionesHelpers.GameEngine.ProcessedTTables.TryGetValue(tts, ttObj) = True Then
                                DropTT(ttObj)
                            End If
                        End If
                    Next
                End If
            Next
        End If
        If Obj.NodeLSLIB.ChildCount > 0 AndAlso Obj.NodeLSLIB.Children.TryGetValue("Treasures", value0) Then
            Dim curnodes = value0
            For Each nod In curnodes
                Dim value As List(Of LSLib.LS.Node) = Nothing
                ' Primero de visuals
                If nod.ChildCount > 0 AndAlso nod.Children.TryGetValue("TreasureItem", value) Then
                    Dim curnodes2 = value
                    For Each nod2 In curnodes2
                        Dim value4 As LSLib.LS.NodeAttribute = Nothing
                        If nod2.Attributes.TryGetValue("Object", value4) Then
                            Dim tts As String = value4.Value.ToString
                            Dim ttObj As BG3_Obj_TreasureTable_Class = Nothing
                            If tts <> "Empty" AndAlso FuncionesHelpers.GameEngine.ProcessedTTables.TryGetValue(tts, ttObj) = True Then
                                DropTT(ttObj)
                            End If
                        End If
                    Next
                End If
            Next
        End If
    End Sub
    Private Sub Drop_Item(Obj As BG3_Obj_Template_Class)
        Dim value0 As List(Of LSLib.LS.Node) = Nothing
        If Obj.NodeLSLIB.ChildCount > 0 AndAlso Obj.NodeLSLIB.Children.TryGetValue("InventoryList", value0) Then
            Dim curnodes = value0
            For Each nod In curnodes
                Dim value As List(Of LSLib.LS.Node) = Nothing
                ' Primero de visuals
                If nod.ChildCount > 0 AndAlso nod.Children.TryGetValue("InventoryItem", value) Then
                    Dim curnodes2 = value
                    For Each nod2 In curnodes2
                        Dim value4 As LSLib.LS.NodeAttribute = Nothing
                        If nod2.Attributes.TryGetValue("Object", value4) Then
                            Dim tts As String = value4.Value.ToString
                            Dim ttObj As BG3_Obj_TreasureTable_Class = Nothing
                            If tts <> "Empty" AndAlso FuncionesHelpers.GameEngine.ProcessedTTables.TryGetValue(tts, ttObj) = True Then
                                DropTT(ttObj)
                            End If
                        End If
                    Next
                End If
            Next
        End If
    End Sub
    Private Sub DropTT(obj As BG3_Obj_TreasureTable_Class)
        Dim idx As Integer = -1
        For x = 0 To ListBox1.Items.Count - 1
            If ListBox1.Items(x).text = obj.Mapkey_WithoutOverride Then idx = x : Exit For
        Next
        If idx = -1 Then
            Dim lis As New BG3_Obj_TreasureTable_TableItem_Class("I_" + Last_Objeto.Name, "," + NumericUpDown1.Value.ToString + ",0,0,0,0,0,0,0")
            Dim Ite As New BG3_Custom_ComboboxItem With {.Value = lis, .Text = obj.Mapkey_WithoutOverride}
            idx = ListBox1.Items.Add(Ite)
        End If

        ListBox1.SelectedIndex = idx
    End Sub
    Private Sub ListBox1_DragEnter(sender As Object, e As DragEventArgs) Handles ListBox1.DragEnter
        If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_TreasureTable_Class))) Then
            Dim obj As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_TreasureTable_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_TreasureTable_Class)))
            If Not IsNothing(obj.Objeto) Then
                e.Effect = DragDropEffects.Copy
            End If
            Exit Sub
        End If
        If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class))) Then
            Dim obj As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class)))
            If Not IsNothing(obj.Objeto) Then
                Dim escorrecto As Boolean = False
                If CType(obj.Objeto, BG3_Obj_Template_Class).Type = BG3_Enum_Templates_Type.character Then escorrecto = True
                If CType(obj.Objeto, BG3_Obj_Template_Class).Type = BG3_Enum_Templates_Type.item Then escorrecto = True
                If escorrecto Then
                    e.Effect = DragDropEffects.Copy
                    Exit Sub
                End If
            End If
        End If
        e.Effect = DragDropEffects.None
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedIndex <> -1 Then
            Button1.Enabled = True
            NumericUpDown1.Enabled = True
            Dim lis As BG3_Obj_TreasureTable_TableItem_Class = ListBox1.Items(ListBox1.SelectedIndex).value
            NumericUpDown1.Value = lis.Conditions.Split(",")(1)
        Else
            Button1.Enabled = False
            NumericUpDown1.Value = 1
            NumericUpDown1.Enabled = False
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Borra_Selected()
    End Sub
    Public Sub Borra_All()
        For x = ListBox1.Items.Count - 1 To 0 Step -1
            ListBox1.SelectedIndex = x
            Borra_Selected()
        Next
    End Sub
    Public Sub Borra_Selected()
        If ListBox1.SelectedIndex <> -1 Then
            Dim it = ListBox1.Items(ListBox1.SelectedIndex)
            Dim nam As String = "I_" + Last_Objeto.Name
            Dim tabl As BG3_Obj_TreasureTable_Class = Nothing
            If FuncionesHelpers.GameEngine.UtamTreasures.Where(Function(pf) pf.Mapkey_WithoutOverride = it.text).Any = True Then
                tabl = FuncionesHelpers.GameEngine.UtamTreasures.Where(Function(pf) pf.Mapkey_WithoutOverride = it.text).First
            Else
                Debugger.Break()
                Exit Sub
            End If
            If tabl.Subtables.Where(Function(pf) pf.HasItem(nam, ModSource)).Any = True Then
                For Each Subt In tabl.Subtables.Where(Function(pf) pf.HasItem(nam, ModSource)).ToList
                    Dim lis2 As BG3_Obj_TreasureTable_TableItem_Class = it.value
                    For x = Subt.Lista.Count - 1 To 0 Step -1
                        If Subt.Lista(x).Item.Contains(nam, StringComparison.OrdinalIgnoreCase) Then
                            Subt.Lista.RemoveAt(x)
                        End If
                        If Subt.Lista.Count = 0 Then tabl.Subtables.Remove(Subt)
                    Next
                Next
            End If
            ListBox1.Items.RemoveAt(ListBox1.SelectedIndex)
        End If
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        If ListBox1.SelectedIndex <> -1 Then
            Dim lis As BG3_Obj_TreasureTable_TableItem_Class = ListBox1.Items(ListBox1.SelectedIndex).value
            lis.Conditions = "," + NumericUpDown1.Value.ToString + ",0,0,0,0,0,0,0"
        End If
    End Sub
End Class
