﻿Imports System.ComponentModel
Imports System.Diagnostics.Eventing.Reader
Imports LSLib.Granny

Public Class BG3Cloner
    Private ReadOnly Property ModSource As BG3_Pak_SourceOfResource_Class
        Get
            Return CType(Me.ParentForm, Generic_Editor).ActiveModSource
        End Get
    End Property
    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.DoubleBuffered = True

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

    Public Event Clone_Started()
    Public Event Clone_Finished()
    Public Event Clone_Template(Objeto As BG3_Obj_Template_Class, Tipo As Clonetype, Stat As BG3_Obj_Stats_Class)
    Public Event Clone_Stat(Objeto As BG3_Obj_Stats_Class, Tipo As Clonetype)
    Public Enum Clonetype
        Inherit
        Clone
        Override
        None
    End Enum
    Public Function Drop_Verify_OBJ(obj As BG3_Obj_Stats_Class) As Boolean
        If IsNothing(Stat_MustDescend_From) Then Return True
        If Not IsNothing(obj) Then Return CheckDescendant_Generic(obj, Stat_MustDescend_From)
        Return False
    End Function
    Public Function Drop_Verify_OBJ(obj As BG3_Obj_Template_Class) As Boolean
        If obj.ReadAttribute_Or_Empty("ParentTemplateId") = "" AndAlso obj.ReadAttribute_Or_Empty("TemplateName") <> "" Then Return False
        If IsNothing(Template_MustDescend_From) Then Return True
        If Not IsNothing(obj) Then Return CheckDescendant_Generic(obj, Template_MustDescend_From)
        Return False
    End Function

    Public Shared Function CheckDescendant_Generic(obj As Object, lista As String())
        If lista.Length = 0 Then Return True
        If lista.Where(Function(pf) (pf.StartsWith("Not") = True AndAlso obj.Is_Descendant(pf.Substring(4)) = True)).Any Then Return False
        If lista.Where(Function(pf) (pf.StartsWith("Not") = False AndAlso obj.Is_Descendant(pf) = True)).Any Then Return True
        Return False
    End Function
    Public Overridable Sub Drop_OBJ(Obj As BG3_Obj_Stats_Class)
        Dim Tipo As Clonetype = Clonetype.Inherit
        If RadioButtonClone.Checked = True Then Tipo = Clonetype.Clone
        If RadioButtonOverride.Checked = True Then Tipo = Clonetype.Override
        Do_Clone_OBJ(Obj, Tipo, Not RadioButtonOnlyChilds.Checked, Not RadioButtonItemOnly.Checked)
    End Sub
    Public Sub Do_Clone_OBJ(obj As BG3_Obj_Stats_Class, tipo As Clonetype, Copyself As Boolean, Copychilds As Boolean)
        Child_Stat.Clear()
        RaiseEvent Clone_Started()
        If Copyself = True Then
            If obj.IsOverrided = False Then
                Child_Stat.Add(obj)
            End If
        End If
        If Copychilds = True Then Recursive_Drop_OBJ(obj, tipo)
        For Each obj2 In Child_Stat
            RaiseEvent Clone_Stat(obj2, tipo)
            If Not IsNothing(obj2.AssociatedTemplate) Then RaiseEvent Clone_Template(obj2.AssociatedTemplate, tipo, obj2)
        Next
        RaiseEvent Clone_Finished()
    End Sub

    Public Overridable Sub Drop_OBJ(Obj As BG3_Obj_Template_Class)
        Dim Tipo As Clonetype = Clonetype.Inherit
        If RadioButtonClone.Checked = True Then Tipo = Clonetype.Clone
        If RadioButtonOverride.Checked = True Then Tipo = Clonetype.Override
        Do_Clone_OBJ(Obj, Tipo, Not RadioButtonOnlyChilds.Checked, Not RadioButtonItemOnly.Checked)
    End Sub

    Public Sub Do_Clone_OBJ(obj As BG3_Obj_Template_Class, tipo As Clonetype, Copyself As Boolean, Copychilds As Boolean)
        Child_Temp.Clear()
        RaiseEvent Clone_Started()
        If Copyself = True Then
            If obj.IsOverrided = False Then
                Child_Temp.Add(obj)
            End If
        End If
        If Copychilds = True Then Recursive_Drop_OBJ(obj, tipo)
        For Each obj2 In Child_Temp
            RaiseEvent Clone_Template(obj2, tipo, obj2.ClonableStats)
            If Not IsNothing(obj2.ClonableStats) Then RaiseEvent Clone_Stat(obj2.ClonableStats, tipo)
        Next
        RaiseEvent Clone_Finished()
    End Sub

    Private ReadOnly Child_Stat As New List(Of BG3_Obj_Stats_Class)
    Private ReadOnly Child_Temp As New List(Of BG3_Obj_Template_Class)
    Private Sub Recursive_Drop_OBJ(Obj As BG3_Obj_Stats_Class, tipo As Clonetype)
        Dim hyh As List(Of String) = Nothing
        If FuncionesHelpers.GameEngine.ProcessedStatList.Hierarchy_Helper.TryGetValue(Obj.MapKey, hyh) Then
            For Each x In hyh
                Dim obj2 As BG3_Obj_Stats_Class = Nothing
                If FuncionesHelpers.GameEngine.ProcessedStatList.TryGetValue(x, obj2) Then
                    If obj2.SourceOfResorce.PackageType <> BG3_Enum_Package_Type.UTAM_Mod OrElse obj2.SourceOfResorce.Pak_Or_Folder <> ModSource.Pak_Or_Folder Then
                        If obj2.IsOverrided = False Then
                            If CheckDescendant_Generic(obj2, Stat_MustDescend_From) Then
                                Child_Stat.Add(obj2)
                            End If
                        End If
                    End If
                    Recursive_Drop_OBJ(obj2, tipo)
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
                    If obj2.SourceOfResorce.PackageType <> BG3_Enum_Package_Type.UTAM_Mod OrElse obj2.SourceOfResorce.Pak_Or_Folder <> ModSource.Pak_Or_Folder Then
                        If obj2.IsOverrided = False Then
                            If CheckDescendant_Generic(obj2, Template_MustDescend_From) Then
                                If (obj2.Name.StartsWith("BASE_") = False AndAlso obj2.Name.StartsWith("CINE_") = False AndAlso obj2.Name.StartsWith("TimelineTemplate_") = False) OrElse obj2.SourceOfResorce.PackageType <> BG3_Enum_Package_Type.BaseGame Then
                                    If obj2.ReadAttribute_Or_Empty("ParentTemplateId") <> "" Then
                                        Child_Temp.Add(obj2)
                                    End If
                                End If
                            End If
                        End If
                    End If
                    Recursive_Drop_OBJ(obj2, tipo)
                End If
            Next
        End If
    End Sub

    'Private Function has_equipment(obj As BG3_Obj_Template_Class) As Boolean
    '    If obj.NodeLSLIB.Children.ContainsKey("Equipment") Then Return True
    '    If obj.ReadAttribute_Or_Empty("Stats") <> obj.ReadAttribute_Or_Inhterithed_Or_Empty("Stats") Then Return True
    '    Return False
    'End Function



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

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class
