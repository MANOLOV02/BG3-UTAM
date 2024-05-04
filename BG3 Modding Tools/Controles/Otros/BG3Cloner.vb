Imports System.ComponentModel
Imports System.Diagnostics.Eventing.Reader

Public Class BG3Cloner
    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    <DefaultValue("Drop an object to clone")>
    Public Property Label As String
        Get
            Return Label1.Text
        End Get
        Set(value As String)
            Label1.Text = value
        End Set
    End Property
    Public Property Template_MustDescend_From As String()
    Public Property Stat_MustDescend_From As String()





    Public Sub Control_DragEnter(sender As Object, e As DragEventArgs) Handles Label1.DragEnter

        If e.Data.GetDataPresent(GetType(BG3_Obj_IconUV_Class)) Then
            Dim obj As BG3_Obj_IconUV_Class = e.Data.GetData(GetType(BG3_Obj_IconUV_Class))
            If Not IsNothing(obj) Then
                If Drop_Verify_OBJ(obj) Then
                    e.Effect = DragDropEffects.Copy
                    Exit Sub
                End If
            End If
        End If

        If e.Data.GetDataPresent(GetType(BG3_Obj_Assets_Class)) Then
            Dim obj As BG3_Obj_Assets_Class = e.Data.GetData(GetType(BG3_Obj_Assets_Class))
            If Not IsNothing(obj) Then
                If Drop_Verify_OBJ(obj) Then
                    e.Effect = DragDropEffects.Copy
                    Exit Sub
                End If
            End If
        End If

        If e.Data.GetDataPresent(GetType(BG3_Obj_FlagsAndTags_Class)) Then
            Dim obj As BG3_Obj_FlagsAndTags_Class = e.Data.GetData(GetType(BG3_Obj_FlagsAndTags_Class))
            If Not IsNothing(obj) Then
                If Drop_Verify_OBJ(obj) Then
                    e.Effect = DragDropEffects.Copy
                    Exit Sub
                End If
            End If
        End If

        If e.Data.GetDataPresent(GetType(BG3_Obj_Generic_Class)) Then
            Dim obj As BG3_Obj_Generic_Class = e.Data.GetData(GetType(BG3_Obj_Generic_Class))
            If Not IsNothing(obj) Then
                If Drop_Verify_OBJ(obj) Then
                    e.Effect = DragDropEffects.Copy
                    Exit Sub
                End If
            End If
        End If

        If e.Data.GetDataPresent(GetType(BG3_Obj_IconAtlass_Class)) Then
            Dim obj As BG3_Obj_IconAtlass_Class = e.Data.GetData(GetType(BG3_Obj_IconAtlass_Class))
            If Not IsNothing(obj) Then
                If Drop_Verify_OBJ(obj) Then
                    e.Effect = DragDropEffects.Copy
                    Exit Sub
                End If
            End If
        End If

        If e.Data.GetDataPresent(GetType(BG3_Obj_Stats_Class)) Then
            Dim obj As BG3_Obj_Stats_Class = e.Data.GetData(GetType(BG3_Obj_Stats_Class))
            If Not IsNothing(obj) Then
                If Drop_Verify_OBJ(obj) Then
                    e.Effect = DragDropEffects.Copy
                    Exit Sub
                End If
            End If
        End If

        If e.Data.GetDataPresent(GetType(BG3_Obj_Template_Class)) Then
            Dim obj As BG3_Obj_Template_Class = e.Data.GetData(GetType(BG3_Obj_Template_Class))
            If Not IsNothing(obj) Then
                If Drop_Verify_OBJ(obj) Then
                    e.Effect = DragDropEffects.Copy
                    Exit Sub
                End If
            End If
        End If


        If e.Data.GetDataPresent(GetType(BG3_Obj_TreasureTable_Class)) Then
            Dim obj As BG3_Obj_TreasureTable_Class = e.Data.GetData(GetType(BG3_Obj_TreasureTable_Class))
            If Not IsNothing(obj) Then
                If Drop_Verify_OBJ(obj) Then
                    e.Effect = DragDropEffects.Copy
                    Exit Sub
                End If
            End If
        End If

        If e.Data.GetDataPresent(GetType(BG3_Obj_TreasureTable_Subtable_Class)) Then
            Dim obj As BG3_Obj_TreasureTable_Subtable_Class = e.Data.GetData(GetType(BG3_Obj_TreasureTable_Subtable_Class))
            If Not IsNothing(obj) Then
                If Drop_Verify_OBJ(obj) Then
                    e.Effect = DragDropEffects.Copy
                    Exit Sub
                End If
            End If
        End If

        If e.Data.GetDataPresent(GetType(BG3_Obj_TreasureTable_TableItem_Class)) Then
            Dim obj As BG3_Obj_TreasureTable_TableItem_Class = e.Data.GetData(GetType(BG3_Obj_TreasureTable_TableItem_Class))
            If Not IsNothing(obj) Then
                If Drop_Verify_OBJ(obj) Then
                    e.Effect = DragDropEffects.Copy
                    Exit Sub
                End If
            End If
        End If

        If e.Data.GetDataPresent(GetType(BG3_Obj_VisualBank_Class)) Then
            Dim obj As BG3_Obj_VisualBank_Class = e.Data.GetData(GetType(BG3_Obj_VisualBank_Class))
            If Not IsNothing(obj) Then
                If Drop_Verify_OBJ(obj) Then
                    e.Effect = DragDropEffects.Copy
                    Exit Sub
                End If
            End If
        End If


        If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_IconUV_Class))) Then
            Dim obj As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_IconUV_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_IconUV_Class)))
            If Not IsNothing(obj.Objeto) Then
                If Drop_Verify_OBJ(CType(obj.Objeto, BG3_Obj_IconUV_Class)) Then
                    e.Effect = DragDropEffects.Copy
                    Exit Sub
                End If
            End If
        End If
        If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Assets_Class))) Then
            Dim obj As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Assets_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Assets_Class)))
            If Not IsNothing(obj.Objeto) Then
                If Drop_Verify_OBJ(CType(obj.Objeto, BG3_Obj_Assets_Class)) Then
                    e.Effect = DragDropEffects.Copy
                    Exit Sub
                End If
            End If
        End If
        If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_FlagsAndTags_Class))) Then
            Dim obj As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_FlagsAndTags_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_FlagsAndTags_Class)))
            If Not IsNothing(obj.Objeto) Then
                If Drop_Verify_OBJ(CType(obj.Objeto, BG3_Obj_FlagsAndTags_Class)) Then
                    e.Effect = DragDropEffects.Copy
                    Exit Sub
                End If
            End If
        End If
        If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Generic_Class))) Then
            Dim obj As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Generic_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Generic_Class)))
            If Not IsNothing(obj.Objeto) Then
                If Drop_Verify_OBJ(CType(obj.Objeto, BG3_Obj_Generic_Class)) Then
                    e.Effect = DragDropEffects.Copy
                    Exit Sub
                End If
            End If
        End If
        If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_IconAtlass_Class))) Then
            Dim obj As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_IconAtlass_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_IconAtlass_Class)))
            If Not IsNothing(obj.Objeto) Then
                If Drop_Verify_OBJ(CType(obj.Objeto, BG3_Obj_IconAtlass_Class)) Then
                    e.Effect = DragDropEffects.Copy
                    Exit Sub
                End If
            End If
        End If
        If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Stats_Class))) Then
            Dim obj As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Stats_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Stats_Class)))
            If Not IsNothing(obj.Objeto) Then
                If Drop_Verify_OBJ(CType(obj.Objeto, BG3_Obj_Stats_Class)) Then
                    e.Effect = DragDropEffects.Copy
                    Exit Sub
                End If
            End If
        End If
        If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class))) Then
            Dim obj As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class)))
            If Not IsNothing(obj.Objeto) Then
                If Drop_Verify_OBJ(CType(obj.Objeto, BG3_Obj_Template_Class)) Then
                    e.Effect = DragDropEffects.Copy
                    Exit Sub
                End If
            End If
        End If
        If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_TreasureTable_Class))) Then
            Dim obj As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_TreasureTable_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_TreasureTable_Class)))
            If Not IsNothing(obj.Objeto) Then
                If Drop_Verify_OBJ(CType(obj.Objeto, BG3_Obj_TreasureTable_Class)) Then
                    e.Effect = DragDropEffects.Copy
                    Exit Sub
                End If
            End If
        End If

        If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_VisualBank_Class))) Then
            Dim obj As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_VisualBank_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_VisualBank_Class)))
            If Not IsNothing(obj.Objeto) Then
                If Drop_Verify_OBJ(CType(obj.Objeto, BG3_Obj_VisualBank_Class)) Then
                    e.Effect = DragDropEffects.Copy
                    Exit Sub
                End If
            End If
        End If

        e.Effect = DragDropEffects.None
    End Sub

    Public Sub Control_DragDrop(sender As Object, e As DragEventArgs) Handles Label1.DragDrop

        If e.Data.GetDataPresent(GetType(BG3_Obj_IconUV_Class)) Then
            Dim obj As BG3_Obj_IconUV_Class = e.Data.GetData(GetType(BG3_Obj_IconUV_Class))
            If Not IsNothing(obj) Then
                Drop_OBJ(obj)
                Exit Sub
            End If
        End If

        If e.Data.GetDataPresent(GetType(BG3_Obj_Assets_Class)) Then
            Dim obj As BG3_Obj_Assets_Class = e.Data.GetData(GetType(BG3_Obj_Assets_Class))
            If Not IsNothing(obj) Then
                Drop_OBJ(obj)
                Exit Sub
            End If
        End If

        If e.Data.GetDataPresent(GetType(BG3_Obj_FlagsAndTags_Class)) Then
            Dim obj As BG3_Obj_FlagsAndTags_Class = e.Data.GetData(GetType(BG3_Obj_FlagsAndTags_Class))
            If Not IsNothing(obj) Then
                Drop_OBJ(obj)
                Exit Sub
            End If
        End If

        If e.Data.GetDataPresent(GetType(BG3_Obj_Generic_Class)) Then
            Dim obj As BG3_Obj_Generic_Class = e.Data.GetData(GetType(BG3_Obj_Generic_Class))
            If Not IsNothing(obj) Then
                Drop_OBJ(obj)
                Exit Sub
            End If
        End If

        If e.Data.GetDataPresent(GetType(BG3_Obj_IconAtlass_Class)) Then
            Dim obj As BG3_Obj_IconAtlass_Class = e.Data.GetData(GetType(BG3_Obj_IconAtlass_Class))
            If Not IsNothing(obj) Then
                Drop_OBJ(obj)
                Exit Sub
            End If
        End If

        If e.Data.GetDataPresent(GetType(BG3_Obj_Stats_Class)) Then
            Dim obj As BG3_Obj_Stats_Class = e.Data.GetData(GetType(BG3_Obj_Stats_Class))
            If Not IsNothing(obj) Then
                Drop_OBJ(obj)
                Exit Sub
            End If
        End If

        If e.Data.GetDataPresent(GetType(BG3_Obj_Template_Class)) Then
            Dim obj As BG3_Obj_Template_Class = e.Data.GetData(GetType(BG3_Obj_Template_Class))
            If Not IsNothing(obj) Then
                Drop_OBJ(obj)
                Exit Sub
            End If
        End If


        If e.Data.GetDataPresent(GetType(BG3_Obj_TreasureTable_Class)) Then
            Dim obj As BG3_Obj_TreasureTable_Class = e.Data.GetData(GetType(BG3_Obj_TreasureTable_Class))
            If Not IsNothing(obj) Then
                Drop_OBJ(obj)
                Exit Sub
            End If
        End If

        If e.Data.GetDataPresent(GetType(BG3_Obj_TreasureTable_Subtable_Class)) Then
            Dim obj As BG3_Obj_TreasureTable_Subtable_Class = e.Data.GetData(GetType(BG3_Obj_TreasureTable_Subtable_Class))
            If Not IsNothing(obj) Then
                Drop_OBJ(obj)
                Exit Sub
            End If
        End If

        If e.Data.GetDataPresent(GetType(BG3_Obj_TreasureTable_TableItem_Class)) Then
            Dim obj As BG3_Obj_TreasureTable_TableItem_Class = e.Data.GetData(GetType(BG3_Obj_TreasureTable_TableItem_Class))
            If Not IsNothing(obj) Then
                Drop_OBJ(obj)
                Exit Sub
            End If
        End If

        If e.Data.GetDataPresent(GetType(BG3_Obj_VisualBank_Class)) Then
            Dim obj As BG3_Obj_VisualBank_Class = e.Data.GetData(GetType(BG3_Obj_VisualBank_Class))
            If Not IsNothing(obj) Then
                Drop_OBJ(obj)
                Exit Sub
            End If
        End If


        If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_IconUV_Class))) Then
            Dim obj As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_IconUV_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_IconUV_Class)))
            If Not IsNothing(obj.Objeto) Then
                Drop_OBJ(CType(obj.Objeto, BG3_Obj_IconUV_Class))
                Exit Sub
            End If
        End If
        If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Assets_Class))) Then
            Dim obj As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Assets_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Assets_Class)))
            If Not IsNothing(obj.Objeto) Then
                Drop_OBJ(CType(obj.Objeto, BG3_Obj_Assets_Class))
                Exit Sub
            End If
        End If
        If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_FlagsAndTags_Class))) Then
            Dim obj As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_FlagsAndTags_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_FlagsAndTags_Class)))
            If Not IsNothing(obj.Objeto) Then
                Drop_OBJ(CType(obj.Objeto, BG3_Obj_FlagsAndTags_Class))
                Exit Sub
            End If
        End If
        If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Generic_Class))) Then
            Dim obj As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Generic_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Generic_Class)))
            If Not IsNothing(obj.Objeto) Then
                Drop_OBJ(CType(obj.Objeto, BG3_Obj_Generic_Class))
                Exit Sub
            End If
        End If
        If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_IconAtlass_Class))) Then
            Dim obj As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_IconAtlass_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_IconAtlass_Class)))
            If Not IsNothing(obj.Objeto) Then
                Drop_OBJ(CType(obj.Objeto, BG3_Obj_IconAtlass_Class))
                Exit Sub
            End If
        End If
        If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Stats_Class))) Then
            Dim obj As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Stats_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Stats_Class)))
            If Not IsNothing(obj.Objeto) Then
                Drop_OBJ(CType(obj.Objeto, BG3_Obj_Stats_Class))
                Exit Sub
            End If
        End If
        If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class))) Then
            Dim obj As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class)))
            If Not IsNothing(obj.Objeto) Then
                Drop_OBJ(CType(obj.Objeto, BG3_Obj_Template_Class))
                Exit Sub
            End If
        End If
        If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_TreasureTable_Class))) Then
            Dim obj As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_TreasureTable_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_TreasureTable_Class)))
            If Not IsNothing(obj.Objeto) Then
                Drop_OBJ(CType(obj.Objeto, BG3_Obj_TreasureTable_Class))
                Exit Sub
            End If
        End If

        If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_VisualBank_Class))) Then
            Dim obj As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_VisualBank_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_VisualBank_Class)))
            If Not IsNothing(obj.Objeto) Then
                Drop_OBJ(CType(obj.Objeto, BG3_Obj_VisualBank_Class))
                Exit Sub
            End If
        End If

        Debugger.Break()
    End Sub

    Public Event Clone_Template(Objeto As BG3_Obj_Template_Class, Tipo As Clonetype)
    Public Event Clone_Stat(Objeto As BG3_Obj_Stats_Class, Tipo As Clonetype)
    Public Enum Clonetype
        Inherit
        Clone
        Override
        None
    End Enum
    Public Function Drop_Verify_OBJ(obj As BG3_Obj_Stats_Class) As Boolean
        If Not IsNothing(obj) Then
            If Stat_MustDescend_From.Length = 0 OrElse Stat_MustDescend_From.Where(Function(pf) obj.Is_Descendant(pf) = True).Any Then Return True
        End If
        Return False
    End Function
    Public Function Drop_Verify_OBJ(obj As BG3_Obj_Template_Class) As Boolean
        If Not IsNothing(obj) Then
            If Template_MustDescend_From.Length = 0 OrElse Template_MustDescend_From.Where(Function(pf) obj.Is_Descendant(pf) = True).Any Then Return True
        End If
        Return False
    End Function
    Public Overridable Sub Drop_OBJ(Obj As BG3_Obj_Stats_Class)
        Dim Tipo As Clonetype = Clonetype.Inherit
        If RadioButtonClone.Checked = True Then Tipo = Clonetype.Clone
        If RadioButtonOverride.Checked = True Then Tipo = Clonetype.Override
        Child_Stat.Clear()
        If RadioButtonOnlyChilds.Checked = False Then
            If Obj.IsOverrided = False Then
                Child_Stat.Add(Obj)
            End If
        End If
        If RadioButtonItemOnly.Checked = False Then Recursive_Drop_OBJ(Obj, Tipo)

        For Each obj2 In Child_Stat
            RaiseEvent Clone_Stat(obj2, Tipo)
            If Not IsNothing(obj2.AssociatedTemplate_Obj) Then RaiseEvent Clone_Template(obj2.AssociatedTemplate_Obj, Tipo)
        Next
    End Sub
    Public Overridable Sub Drop_OBJ(Obj As BG3_Obj_Template_Class)
        Dim Tipo As Clonetype = Clonetype.Inherit
        If RadioButtonClone.Checked = True Then Tipo = Clonetype.Clone
        If RadioButtonOverride.Checked = True Then Tipo = Clonetype.Override
        Child_Temp.Clear()
        If RadioButtonOnlyChilds.Checked = False Then
            If Obj.IsOverrided = False Then
                Child_Temp.Add(Obj)
            End If
        End If
        If RadioButtonItemOnly.Checked = False Then Recursive_Drop_OBJ(Obj, Tipo)

        For Each obj2 In Child_Temp
            RaiseEvent Clone_Template(obj2, Tipo)
            If Not IsNothing(obj2.AssociatedStats_Obj) Then RaiseEvent Clone_Stat(obj2.AssociatedStats_Obj, Tipo)
        Next
    End Sub
    Private ReadOnly Child_Stat As New List(Of BG3_Obj_Stats_Class)
    Private ReadOnly Child_Temp As New List(Of BG3_Obj_Template_Class)
    Private Sub Recursive_Drop_OBJ(Obj As BG3_Obj_Stats_Class, tipo As Clonetype)
        Dim hyh As List(Of String) = Nothing
        If FuncionesHelpers.GameEngine.ProcessedStatList.Hierarchy_Helper.TryGetValue(Obj.MapKey, hyh) Then
            For Each x In hyh
                Dim obj2 As BG3_Obj_Stats_Class = Nothing
                If FuncionesHelpers.GameEngine.ProcessedStatList.TryGetValue(x, obj2) Then
                    If obj2.IsOverrided = False Then
                        Child_Stat.Add(obj2)
                        Recursive_Drop_OBJ(obj2, tipo)
                    End If
                End If
            Next
        End If
    End Sub
    Private Sub Recursive_Drop_OBJ(Obj As BG3_Obj_Template_Class, tipo As Clonetype)
        Dim hyh As List(Of String) = Nothing
        If FuncionesHelpers.GameEngine.ProcessedGameObjectList.Hierarchy_Helper.TryGetValue(Obj.MapKey, hyh) Then
            For Each x In hyh
                Dim obj2 As BG3_Obj_Template_Class = Nothing
                If FuncionesHelpers.GameEngine.ProcessedGameObjectList.TryGetValue(x, obj2) Then
                    If obj2.IsOverrided = False Then
                        Child_Temp.Add(obj2)
                        Recursive_Drop_OBJ(obj2, tipo)
                    End If
                End If
            Next
        End If
    End Sub




    Public Overridable Sub Drop_OBJ(Obj As BG3_Obj_IconUV_Class)
        Debugger.Break()
    End Sub
    Public Overridable Sub Drop_OBJ(Obj As BG3_Obj_Assets_Class)
        Debugger.Break()
    End Sub
    Public Overridable Sub Drop_OBJ(Obj As BG3_Obj_FlagsAndTags_Class)
        Debugger.Break()
    End Sub
    Public Overridable Sub Drop_OBJ(Obj As BG3_Obj_Generic_Class)
        Debugger.Break()
    End Sub
    Public Overridable Sub Drop_OBJ(Obj As BG3_Obj_IconAtlass_Class)
        Debugger.Break()
    End Sub

    Public Overridable Sub Drop_OBJ(Obj As BG3_Obj_TreasureTable_Class)
        Debugger.Break()
    End Sub
    Public Overridable Sub Drop_OBJ(Obj As BG3_Obj_TreasureTable_Subtable_Class)
        Debugger.Break()
    End Sub
    Public Overridable Sub Drop_OBJ(Obj As BG3_Obj_TreasureTable_TableItem_Class)
        Debugger.Break()
    End Sub
    Public Overridable Sub Drop_OBJ(Obj As BG3_Obj_VisualBank_Class)
        Debugger.Break()
    End Sub
    Public Overridable Function Drop_Verify_OBJ(Obj As BG3_Obj_IconUV_Class) As Boolean
        Return False
    End Function
    Public Overridable Function Drop_Verify_OBJ(Obj As BG3_Obj_Assets_Class) As Boolean
        Return False
    End Function
    Public Overridable Function Drop_Verify_OBJ(Obj As BG3_Obj_FlagsAndTags_Class) As Boolean
        Return False
    End Function
    Public Overridable Function Drop_Verify_OBJ(Obj As BG3_Obj_Generic_Class) As Boolean
        Return False
    End Function
    Public Overridable Function Drop_Verify_OBJ(Obj As BG3_Obj_IconAtlass_Class) As Boolean
        Return False
    End Function
    Public Overridable Function Drop_Verify_OBJ(Obj As BG3_Obj_TreasureTable_Class) As Boolean
        Return False
    End Function
    Public Overridable Function Drop_Verify_OBJ(Obj As BG3_Obj_TreasureTable_Subtable_Class) As Boolean
        Return False
    End Function
    Public Overridable Function Drop_Verify_OBJ(Obj As BG3_Obj_TreasureTable_TableItem_Class) As Boolean
        Return False
    End Function
    Public Overridable Function Drop_Verify_OBJ(Obj As BG3_Obj_VisualBank_Class) As Boolean
        Return False
    End Function
End Class
