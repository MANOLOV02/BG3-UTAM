Imports System.ComponentModel
Imports LSLib.Granny
Imports LSLib.LS.Story

Public Enum BG3_Editor_Type
    Textbox
    Combobox
    NumericUpDown
End Enum

Partial Public MustInherit Class BG3_Value_Editor_Generic
    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Private _EditIsConditional As Boolean = True
    Private _EditorType As BG3_Editor_Type

    <DefaultValue(False)>
    Public Property [ReadOnly] As Boolean = False

    <DefaultValue(BG3_Editor_Type.Textbox)>
    Public Property EditorType As BG3_Editor_Type
        Get
            Return _EditorType
        End Get
        Set(value As BG3_Editor_Type)
            _EditorType = value
            Select Case _EditorType
                Case BG3_Editor_Type.Combobox
                    ComboBox1.Visible = True
                    TextBox1.Visible = False
                    NumericUpDown1.Visible = False
                Case BG3_Editor_Type.Textbox
                    ComboBox1.Visible = False
                    TextBox1.Visible = True
                    NumericUpDown1.Visible = False
                Case BG3_Editor_Type.NumericUpDown
                    ComboBox1.Visible = False
                    TextBox1.Visible = False
                    NumericUpDown1.Visible = True
            End Select
            Habilita_deshabilita()
        End Set
    End Property
    <DefaultValue(True)>
    Public Property EditIsConditional As Boolean
        Get
            Return _EditIsConditional
        End Get
        Set(value As Boolean)
            _EditIsConditional = value
            Habilita_deshabilita()
        End Set
    End Property
    <DefaultValue(True)>
    Public Property ShowLabel As Boolean
        Get
            Return Not SplitContainer1.Panel1Collapsed
        End Get
        Set(value As Boolean)
            SplitContainer1.Panel1Collapsed = Not value
        End Set
    End Property
    <DefaultValue(True)>
    Public Property ShowConditional As Boolean
        Get
            Return Not SplitContainer2.Panel1Collapsed
        End Get
        Set(value As Boolean)
            SplitContainer2.Panel1Collapsed = Not value
        End Set
    End Property
    <DefaultValue(120)>
    Public Property SplitterDistance As Integer
        Get
            Return SplitContainer1.SplitterDistance
        End Get
        Set(value As Integer)
            SplitContainer1.SplitterDistance = value
        End Set
    End Property

    Private _AllowEdit As Boolean = True
    <DefaultValue(True)>
    Public Property AllowEdit As Boolean
        Get
            Return _AllowEdit
        End Get
        Set(value As Boolean)
            _AllowEdit = value
            Habilita_deshabilita()
        End Set
    End Property
    Public Overrides Property Text As String
        Get
            Return TextBox1.Text
        End Get
        Set(value As String)
            TextBox1.Text = value
        End Set
    End Property

    <DefaultValue("Select a label to show")>
    Public Overridable Property Label As String
        Get
            Return Label1.Text
        End Get
        Set(value As String)
            Label1.Text = value
        End Set
    End Property

    <Browsable(False)>
    Public ReadOnly Property Checked As Boolean
        Get
            Return CheckBox1.Checked
        End Get
    End Property

    Protected Overridable Sub Habilita_deshabilita()
        CheckBox1.Visible = EditIsConditional
        CheckBox1.Enabled = Not Me.ReadOnly
        If Me.AllowEdit = False Then TextBox1.ReadOnly = True
        If Me.EditIsConditional = False And Me.AllowEdit = True Then TextBox1.ReadOnly = Me.ReadOnly
        If Me.EditIsConditional = True And Me.AllowEdit = True AndAlso CheckBox1.Checked = False Then TextBox1.ReadOnly = True
        If Me.EditIsConditional = True And Me.AllowEdit = True AndAlso CheckBox1.Checked = True Then TextBox1.ReadOnly = Me.ReadOnly
        ComboBox1.Enabled = Not TextBox1.ReadOnly
        If ComboBox1.Enabled = False Then ComboBox1.SelectionLength = 0
        NumericUpDown1.ReadOnly = TextBox1.ReadOnly
    End Sub
    Overridable Sub Clear()
        TextBox1.Text = ""
    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Habilita_deshabilita()
        If Me.EditIsConditional = True And Me.AllowEdit = True AndAlso Not IsNothing(Last_read) Then
            Select Case Last_read.GetType
                Case GetType(BG3_Obj_IconUV_Class)
                    Conditional_changed(CType(Last_read, BG3_Obj_IconUV_Class))
                Case GetType(BG3_Obj_Assets_Class)
                    Conditional_changed(CType(Last_read, BG3_Obj_Assets_Class))
                Case GetType(BG3_Obj_FlagsAndTags_Class)
                    Conditional_changed(CType(Last_read, BG3_Obj_FlagsAndTags_Class))
                Case GetType(BG3_Obj_Generic_Class)
                    Conditional_changed(CType(Last_read, BG3_Obj_Generic_Class))
                Case GetType(BG3_Obj_IconAtlass_Class)
                    Conditional_changed(CType(Last_read, BG3_Obj_IconAtlass_Class))
                Case GetType(BG3_Obj_Stats_Class)
                    Conditional_changed(CType(Last_read, BG3_Obj_Stats_Class))
                Case GetType(BG3_Obj_Template_Class)
                    Conditional_changed(CType(Last_read, BG3_Obj_Template_Class))
                Case GetType(BG3_Obj_TreasureTable_Class)
                    Conditional_changed(CType(Last_read, BG3_Obj_TreasureTable_Class))
                Case GetType(BG3_Obj_TreasureTable_Subtable_Class)
                    Conditional_changed(CType(Last_read, BG3_Obj_TreasureTable_Subtable_Class))
                Case GetType(BG3_Obj_TreasureTable_TableItem_Class)
                    Conditional_changed(CType(Last_read, BG3_Obj_TreasureTable_TableItem_Class))
                Case GetType(BG3_Obj_VisualBank_Class)
                    Conditional_changed(CType(Last_read, BG3_Obj_VisualBank_Class))
                Case Else
                    Debugger.Break()
            End Select
        End If
        RaiseEvent Inside_Checkbox_Changed(Me)
    End Sub

    '  BG3_Obj_IconUV_Class
    '  BG3_Obj_Assets_Class
    '  BG3_Obj_FlagsAndTags_Class
    '  BG3_Obj_Generic_Class
    '  BG3_Obj_IconAtlass_Class
    '  BG3_Obj_Stats_Class
    '  BG3_Obj_Template_Class
    '  BG3_Obj_TreasureTable_Class
    '  BG3_Obj_TreasureTable_Subtable_Class
    '  BG3_Obj_TreasureTable_TableItem_Class
    '  BG3_Obj_VisualBank_Class

    Public Sub Control_DragEnter(sender As Object, e As DragEventArgs) Handles TextBox1.DragEnter

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

    Public Sub Control_DragDrop(sender As Object, e As DragEventArgs) Handles TextBox1.DragDrop

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
    Public Overridable Sub Drop_OBJ(Obj As BG3_Obj_Stats_Class)
        Debugger.Break()
    End Sub
    Public Overridable Sub Drop_OBJ(Obj As BG3_Obj_Template_Class)
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
    Public Overridable Function Drop_Verify_OBJ(Obj As BG3_Obj_Stats_Class) As Boolean
        Return False
    End Function
    Public Overridable Function Drop_Verify_OBJ(Obj As BG3_Obj_Template_Class) As Boolean
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

    Public Last_read As Object

    Public Overridable Function Read(Que As BG3_Obj_IconUV_Class) As Boolean
        Debugger.Break()
        Return False
    End Function
    Public Overridable Function Read(Que As BG3_Obj_Assets_Class) As Boolean
        Debugger.Break()
        Return False
    End Function
    Public Overridable Function Read(Que As BG3_Obj_FlagsAndTags_Class) As Boolean
        Debugger.Break()
        Return False
    End Function
    Public Overridable Function Read(Que As BG3_Obj_Generic_Class) As Boolean
        Debugger.Break()
        Return False
    End Function
    Public Overridable Function Read(Que As BG3_Obj_IconAtlass_Class) As Boolean
        Debugger.Break()
        Return False
    End Function
    Public Overridable Function Read(Que As BG3_Obj_Stats_Class) As Boolean
        Debugger.Break()
        Return False
    End Function
    Public Overridable Function Read(Que As BG3_Obj_Template_Class) As Boolean
        Debugger.Break()
        Return False
    End Function
    Public Overridable Function Read(Que As BG3_Obj_TreasureTable_Class) As Boolean
        Debugger.Break()
        Return False
    End Function
    Public Overridable Function Read(Que As BG3_Obj_TreasureTable_Subtable_Class) As Boolean
        Debugger.Break()
        Return False
    End Function
    Public Overridable Function Read(Que As BG3_Obj_TreasureTable_TableItem_Class) As Boolean
        Debugger.Break()
        Return False
    End Function
    Public Overridable Function Read(Que As BG3_Obj_VisualBank_Class) As Boolean
        Debugger.Break()
        Return False
    End Function

    Public Overridable Function Write(Que As BG3_Obj_IconUV_Class) As Boolean
        Debugger.Break()
        Return False
    End Function
    Public Overridable Function Write(Que As BG3_Obj_Assets_Class) As Boolean
        Debugger.Break()
        Return False
    End Function
    Public Overridable Function Write(Que As BG3_Obj_FlagsAndTags_Class) As Boolean
        Debugger.Break()
        Return False
    End Function
    Public Overridable Function Write(Que As BG3_Obj_Generic_Class) As Boolean
        Debugger.Break()
        Return False
    End Function
    Public Overridable Function Write(Que As BG3_Obj_IconAtlass_Class) As Boolean
        Debugger.Break()
        Return False
    End Function
    Public Overridable Function Write(Que As BG3_Obj_Stats_Class) As Boolean
        Debugger.Break()
        Return False
    End Function
    Public Overridable Function Write(Que As BG3_Obj_Template_Class) As Boolean
        Debugger.Break()
        Return False
    End Function
    Public Overridable Function Write(Que As BG3_Obj_TreasureTable_Class) As Boolean
        Debugger.Break()
        Return False
    End Function
    Public Overridable Function Write(Que As BG3_Obj_TreasureTable_Subtable_Class) As Boolean
        Debugger.Break()
        Return False
    End Function
    Public Overridable Function Write(Que As BG3_Obj_TreasureTable_TableItem_Class) As Boolean
        Debugger.Break()
        Return False
    End Function
    Public Overridable Function Write(Que As BG3_Obj_VisualBank_Class) As Boolean
        Debugger.Break()
        Return False
    End Function
    Public Overridable Function Create(Value As String, Que As BG3_Obj_IconUV_Class) As Boolean
        Debugger.Break()
        Return False
    End Function
    Public Overridable Function Create(Value As String, Que As BG3_Obj_Assets_Class) As Boolean
        Debugger.Break()
        Return False
    End Function
    Public Overridable Function Create(Value As String, Que As BG3_Obj_FlagsAndTags_Class) As Boolean
        Debugger.Break()
        Return False
    End Function
    Public Overridable Function Create(Value As String, Que As BG3_Obj_Generic_Class) As Boolean
        Debugger.Break()
        Return False
    End Function
    Public Overridable Function Create(Value As String, Que As BG3_Obj_IconAtlass_Class) As Boolean
        Debugger.Break()
        Return False
    End Function
    Public Overridable Function Create(Value As String, Que As BG3_Obj_Stats_Class) As Boolean
        Debugger.Break()
        Return False
    End Function
    Public Overridable Function Create(Value As String, Que As BG3_Obj_Template_Class) As Boolean
        Debugger.Break()
        Return False
    End Function
    Public Overridable Function Create(Value As String, Que As BG3_Obj_TreasureTable_Class) As Boolean
        Debugger.Break()
        Return False
    End Function
    Public Overridable Function Create(Value As String, Que As BG3_Obj_TreasureTable_Subtable_Class) As Boolean
        Debugger.Break()
        Return False
    End Function
    Public Overridable Function Create(Value As String, Que As BG3_Obj_TreasureTable_TableItem_Class) As Boolean
        Debugger.Break()
        Return False
    End Function
    Public Overridable Function Create(Value As String, Que As BG3_Obj_VisualBank_Class) As Boolean
        Debugger.Break()
        Return False
    End Function
    Public Overridable Function Conditional_changed(Que As BG3_Obj_IconUV_Class) As Boolean
        Debugger.Break()
        Return False
    End Function
    Public Overridable Function Conditional_changed(Que As BG3_Obj_Assets_Class) As Boolean
        Debugger.Break()
        Return False
    End Function
    Public Overridable Function Conditional_changed(Que As BG3_Obj_FlagsAndTags_Class) As Boolean
        Debugger.Break()
        Return False
    End Function
    Public Overridable Function Conditional_changed(Que As BG3_Obj_Generic_Class) As Boolean
        Debugger.Break()
        Return False
    End Function
    Public Overridable Function Conditional_changed(Que As BG3_Obj_IconAtlass_Class) As Boolean
        Debugger.Break()
        Return False
    End Function
    Public Overridable Function Conditional_changed(Que As BG3_Obj_Stats_Class) As Boolean
        Debugger.Break()
        Return False
    End Function
    Public Overridable Function Conditional_changed(Que As BG3_Obj_Template_Class) As Boolean
        Debugger.Break()
        Return False
    End Function
    Public Overridable Function Conditional_changed(Que As BG3_Obj_TreasureTable_Class) As Boolean
        Debugger.Break()
        Return False
    End Function
    Public Overridable Function Conditional_changed(Que As BG3_Obj_TreasureTable_Subtable_Class) As Boolean
        Debugger.Break()
        Return False
    End Function
    Public Overridable Function Conditional_changed(Que As BG3_Obj_TreasureTable_TableItem_Class) As Boolean
        Debugger.Break()
        Return False
    End Function
    Public Overridable Function Conditional_changed(Que As BG3_Obj_VisualBank_Class) As Boolean
        Debugger.Break()
        Return False
    End Function

    Public Overridable Function Conditional_GetParent_Value(Que As BG3_Obj_IconUV_Class) As String
        Debugger.Break()
        Return ""
    End Function
    Public Overridable Function Conditional_GetParent_Value(Que As BG3_Obj_Assets_Class) As String
        Debugger.Break()
        Return ""
    End Function
    Public Overridable Function Conditional_GetParent_Value(Que As BG3_Obj_FlagsAndTags_Class) As String
        Debugger.Break()
        Return ""
    End Function
    Public Overridable Function Conditional_GetParent_Value(Que As BG3_Obj_Generic_Class) As String
        Debugger.Break()
        Return ""
    End Function
    Public Overridable Function Conditional_GetParent_Value(Que As BG3_Obj_IconAtlass_Class) As String
        Debugger.Break()
        Return ""
    End Function
    Public Overridable Function Conditional_GetParent_Value(Que As BG3_Obj_Stats_Class) As String
        Debugger.Break()
        Return ""
    End Function
    Public Overridable Function Conditional_GetParent_Value(Que As BG3_Obj_Template_Class) As String
        Debugger.Break()
        Return ""
    End Function
    Public Overridable Function Conditional_GetParent_Value(Que As BG3_Obj_TreasureTable_Class) As String
        Debugger.Break()
        Return ""
    End Function
    Public Overridable Function Conditional_GetParent_Value(Que As BG3_Obj_TreasureTable_Subtable_Class) As String
        Debugger.Break()
        Return ""
    End Function
    Public Overridable Function Conditional_GetParent_Value(Que As BG3_Obj_TreasureTable_TableItem_Class) As String
        Debugger.Break()
        Return ""
    End Function
    Public Overridable Function Conditional_GetParent_Value(Que As BG3_Obj_VisualBank_Class) As String
        Debugger.Break()
        Return ""
    End Function

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        Update_ComboIndex()
        Update_NumericUpDown()
        RaiseEvent Inside_Text_Leave(Me)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Update_ComboIndex()
        Update_NumericUpDown()
        RaiseEvent Inside_Text_Changed(Me)
    End Sub
    Protected Sub Reload_Combo()
        ComboBox1.Items.Clear()
        ComboBox1.Items.AddRange(ComboItems.ToArray)
        If ComboBox1.SelectedIndex = -1 AndAlso ComboBox1.Items.Count > 0 Then ComboBox1.SelectedIndex = 0
    End Sub

    Protected ComboItems As New List(Of String)
    Private Sub Update_ComboIndex()
        If Me.EditorType <> BG3_Editor_Type.Combobox Then Exit Sub
        If Me.ComboBox1.DropDownStyle <> ComboBoxStyle.DropDownList Then
            Dim valor As String = TextBox1.Text
            If ComboBox1.Text <> valor Then ComboBox1.Text = TextBox1.Text
        Else
            Dim idx = ComboItems.IndexOf(Text_to_Combo(TextBox1.Text))
            If ComboBox1.SelectedIndex <> idx Then ComboBox1.SelectedIndex = idx
        End If
    End Sub

    Protected Overridable Function Text_to_Combo(Value As String) As String
        Return Value
    End Function
    Protected Overridable Function Combo_To_Text(Value As String) As String
        Return Value
    End Function

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If Me.EditorType <> BG3_Editor_Type.Combobox Then Exit Sub
        If Me.ComboBox1.DropDownStyle <> ComboBoxStyle.DropDownList Then Exit Sub
        Dim valor As String
        If ComboBox1.SelectedIndex <> -1 AndAlso ComboBox1.SelectedIndex < ComboItems.Count Then
            valor = ComboItems(ComboBox1.SelectedIndex)
        Else
            valor = ComboItems(0)
        End If
        If TextBox1.Text <> valor Then TextBox1.Text = Combo_To_Text(valor)
        RaiseEvent Inside_Combobox_Changed(Me)
    End Sub

    Private Sub ComboBox1_TextChanged(sender As Object, e As EventArgs) Handles ComboBox1.TextChanged
        If Me.EditorType <> BG3_Editor_Type.Combobox Then Exit Sub
        If Me.ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList Then Exit Sub
        Dim valor As String = ComboBox1.Text
        If TextBox1.Text <> valor Then TextBox1.Text = ComboBox1.Text
    End Sub


    Private Sub ComboBox1_DragDrop(sender As Object, e As DragEventArgs) Handles ComboBox1.DragDrop
        Control_DragDrop(sender, e)
    End Sub

    Private Sub ComboBox1_DragEnter(sender As Object, e As DragEventArgs) Handles ComboBox1.DragEnter
        Control_DragEnter(sender, e)
    End Sub
    <Browsable(False)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property NumericDecimalPlaces As Integer
        Get
            Return NumericUpDown1.DecimalPlaces
        End Get
        Set(value As Integer)
            NumericUpDown1.DecimalPlaces = value
        End Set
    End Property
    <Browsable(False)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property NumericValue As Decimal
        Get
            Return NumericUpDown1.Value
        End Get
        Set(value As Decimal)
            NumericUpDown1.Value = value
        End Set
    End Property
    <Browsable(False)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property NumericMaximum As Decimal
        Get
            Return NumericUpDown1.Maximum
        End Get
        Set(value As Decimal)
            NumericUpDown1.Maximum = value
        End Set
    End Property
    <Browsable(False)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property NumericMinimum As Decimal
        Get
            Return NumericUpDown1.Minimum
        End Get
        Set(value As Decimal)
            NumericUpDown1.Minimum = value
        End Set
    End Property

    Private Sub Update_NumericUpDown()
        If Me.EditorType <> BG3_Editor_Type.NumericUpDown Then Exit Sub
        Dim valor = Cdec_sinerror(TextBox1.Text)
        If valor > NumericMaximum Then valor = NumericMaximum
        If valor < NumericMinimum Then valor = NumericMinimum
        If NumericUpDown1.Value <> valor Then NumericUpDown1.Value = valor
    End Sub

    Private Shared Function Cdec_sinerror(text As String) As Decimal
        Dim valor As Decimal = 0
        If Decimal.TryParse(text, valor) = False Then Return 0
        Return valor
    End Function

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        If Me.EditorType <> BG3_Editor_Type.NumericUpDown Then Exit Sub
        Dim valor As Decimal = NumericUpDown1.Value
        Dim str = valor.ToString("0." + "".PadLeft(NumericDecimalPlaces, "0"))
        If TextBox1.Text <> str Then TextBox1.Text = str
        RaiseEvent Inside_NumericUpDown_Changed(Me)
    End Sub

    Private Sub NumericUpDown1_DragDrop(sender As Object, e As DragEventArgs) Handles NumericUpDown1.DragDrop
        If Me.EditorType <> BG3_Editor_Type.NumericUpDown Then Exit Sub
        Control_DragDrop(sender, e)
    End Sub

    Private Sub NumericUpDown1_DragEnter(sender As Object, e As DragEventArgs) Handles NumericUpDown1.DragEnter
        If Me.EditorType <> BG3_Editor_Type.NumericUpDown Then Exit Sub
        Control_DragEnter(sender, e)
    End Sub



    Public Event Inside_NumericUpDown_Changed(sender As Object)
    Public Event Inside_Combobox_Changed(sender As Object)
    Public Event Inside_Checkbox_Changed(sender As Object)
    Public Event Inside_Text_Changed(sender As Object)
    Public Event Inside_Text_Leave(sender As Object)
End Class
