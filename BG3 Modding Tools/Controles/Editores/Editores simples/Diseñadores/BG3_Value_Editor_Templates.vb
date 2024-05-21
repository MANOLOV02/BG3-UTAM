Imports System.Net
Imports LSLib.LS
Imports LSLib.LS.Story

<ToolboxBitmap(GetType(System.Windows.Forms.TextBox))>
Public MustInherit Class Editor_Generic_GenericAttribute
    Inherits BG3_Value_Editor_Generic

    Protected AttributeType As LSLib.LS.AttributeType = LSLib.LS.AttributeType.FixedString
    Protected Key As String = "ToDefine"

    Public Overridable Function Create_Attribute(ByRef Que As LSLib.LS.Node, ValueString As String) As Boolean
        Return Que.Attributes.TryAdd(Key, Conver_String_to_Node(ValueString))
    End Function

    Public Shared Function Create_Attribute_Generic(ByRef Que As LSLib.LS.Node, Key As String, ValueString As String, attributeType As LSLib.LS.AttributeType) As Boolean
        Return Que.Attributes.TryAdd(Key, Conver_String_to_Node_Generic(ValueString, attributeType))
    End Function
    Public Overridable Function Replace_Attribute(ByRef Que As LSLib.LS.Node, ValueString As String) As Boolean
        If Que.Attributes.TryAdd(Key, Conver_String_to_Node(ValueString)) = False Then
            Que.Attributes(Key) = Conver_String_to_Node(ValueString)
        End If
        Return True
    End Function
    Public Shared Function Replace_Attribute_Generic(ByRef Que As LSLib.LS.Node, Key As String, ValueString As String, attributeType As LSLib.LS.AttributeType) As Boolean
        If Que.Attributes.TryAdd(Key, Conver_String_to_Node_Generic(ValueString, attributeType)) = False Then
            Que.Attributes(Key) = Conver_String_to_Node_Generic(ValueString, attributeType)
        End If
        Return True
    End Function
    Public Overridable Function Conver_String_to_Node(valueString As String) As LSLib.LS.NodeAttribute
        Return Conver_String_to_Node_Generic(valueString, Me.AttributeType)
    End Function
    Public Shared Function Conver_Attribute_to_String(Attr As LSLib.LS.NodeAttribute) As String
        Return Attr.AsString(Funciones.Guid_to_string)
    End Function

    Public Shared Function Conver_String_to_Node_Generic(valueString As String, attributeType As LSLib.LS.AttributeType) As LSLib.LS.NodeAttribute
        Select Case attributeType
            Case AttributeType.TranslatedString, AttributeType.TranslatedFSString
                Return New LSLib.LS.NodeAttribute(attributeType) With {.Value = New LSLib.LS.TranslatedString With {.Version = valueString.Split(";")(1), .Handle = valueString.Split(";")(0)}}
            Case Else
                Dim value = New LSLib.LS.NodeAttribute(attributeType)
                value.FromString(valueString, Funciones.Guid_to_string)
                Return value
        End Select

    End Function

    'Private Shared ReadOnly Guid_to_String_Unreversed = New NodeSerializationSettings With {.DefaultByteSwapGuids = True, .ByteSwapGuids = True}

End Class




Public MustInherit Class Editor_Template_GenericAttribute
    Inherits Editor_Generic_GenericAttribute
    Sub New(Key As String)
        Me.Key = Key
    End Sub
    Sub New(Key As String, AttributeType As LSLib.LS.AttributeType)
        Me.Key = Key
        Me.AttributeType = AttributeType
    End Sub
    Sub New()
    End Sub

    Public Overrides Function Read(Que As BG3_Obj_Template_Class) As Boolean
        Last_read = Que
        Dim value As LSLib.LS.NodeAttribute = Nothing
        If Me.EditIsConditional Then
            If Que.NodeLSLIB.Attributes.TryGetValue(Key, value) = False Then Me.CheckBox1.Checked = False Else Me.CheckBox1.Checked = True
            Return Conditional_Changed(Que)
        End If
        Que.NodeLSLIB.Attributes.TryGetValue(Key, value)
        Return Get_ValueString(value)
    End Function
    Public Overrides Function Create(value As String, Que As BG3_Obj_Template_Class) As Boolean
        If Que.NodeLSLIB.Attributes.TryAdd(Key, Conver_String_to_Node(value)) = False Then
            Que.NodeLSLIB.Attributes(Key) = Conver_String_to_Node(value)
            Return True
        End If
        Return False
    End Function

    Public Overrides Function Conditional_GetParent_Value(Parent As BG3_Obj_Template_Class) As String
        Dim str = Parent.ReadAttribute_Or_Inhterithed(Key)
        If IsNothing(str) Then Return ""
        Return str
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
        If IsNothing(value) AndAlso Not IsNothing(Que.Parent) Then value = Conditional_changed_Empty(Que)
        Return Get_ValueString(value)
    End Function
    Public Overrides Function Conditional_changed_Empty(Que As BG3_Obj_Template_Class) As LSLib.LS.NodeAttribute
        Dim value As LSLib.LS.NodeAttribute = Nothing
        Dim current = Que
        While Not IsNothing(current.Parent)
            current.Parent.NodeLSLIB.Attributes.TryGetValue(Key, value)
            If Not IsNothing(value) Then Exit While
            current = current.Parent
        End While
        Return value
    End Function

    Public Overridable Function Get_ValueString(ByRef value As LSLib.LS.NodeAttribute) As Boolean
        If IsNothing(value) Then TextBox1.Text = "" : Return False
        TextBox1.Text = value.AsString(Funciones.Guid_to_string)
        Return True
    End Function
    Public Overridable Function Set_ValueString(Que As BG3_Obj_Template_Class) As String
        Return TextBox1.Text
    End Function

    Public Overrides Function Write(Que As BG3_Obj_Template_Class) As Boolean
        If Me.AllowEdit = False Then Return False
        If Me.AllowEdit = True Then
            If Me.EditIsConditional AndAlso Me.CheckBox1.Checked = False Then
                Que.NodeLSLIB.Attributes.Remove(Key)
                Return True
            Else
                Dim valueString As String = Set_ValueString(Que)
                Dim value As LSLib.LS.NodeAttribute = Conver_String_to_Node(valueString)
                If Que.NodeLSLIB.Attributes.TryAdd(Key, value) = False Then
                    Que.NodeLSLIB.Attributes(Key) = value
                    Return True
                End If
                Return True
            End If
        End If
        Return False
    End Function
End Class

<ToolboxBitmap(GetType(System.Windows.Forms.TextBox))>
Public MustInherit Class Editor_Template_GenericTranslate
    Inherits Editor_Template_GenericAttribute
    Protected UTAM_Handle As String = "ToDefine"
    Public Overrides Function Create_Attribute(ByRef Que As LSLib.LS.Node, Value As String) As Boolean
        Que.Attributes.TryAdd(UTAM_Handle, Conver_String_to_Node(Value))
        Return True
    End Function

    Sub New()
        MyBase.New("ToDefine", AttributeType.TranslatedString)
    End Sub
    Sub New(Key As String, Utam_Handle As String)
        MyBase.New(Key, AttributeType.TranslatedString)
        Me.UTAM_Handle = Utam_Handle
    End Sub
    Public Overrides Function Get_ValueString(ByRef value As NodeAttribute) As Boolean
        Dim handle As String
        If IsNothing(value) Then
            TextBox1.Text = "Not defined"
            Return False
        End If
        handle = value.Value.ToString()
        Dim Loca As String = FuncionesHelpers.GameEngine.ProcessedLocalizationList.Localize(handle, Bg3_Enum_Languages.English)
        If Not IsNothing(Loca) Then
            TextBox1.Text = Loca
            Return True
        End If
        TextBox1.Text = "Not defined"
        Return False
    End Function
    Public Overrides Function Conditional_changed_Empty(Que As BG3_Obj_Template_Class) As LSLib.LS.NodeAttribute
        Dim value As LSLib.LS.NodeAttribute = Nothing
        Que.NodeLSLIB.Attributes.TryGetValue(UTAM_Handle, value)
        Dim Loca As String = FuncionesHelpers.GameEngine.ProcessedLocalizationList.Localize(value.Value.ToString, Bg3_Enum_Languages.English)
        If IsNothing(Loca) Then
            Dim handle As String = Que.Parent.ReadAttribute_Or_Inhterithed(Key)
            If Not IsNothing(handle) Then value = New LSLib.LS.NodeAttribute(AttributeType.TranslatedString) With {.Value = handle}
        End If
        Return value
    End Function

    Public Function GetPropertyName() As String
        Return Key
    End Function
    Public Function Get_Utam_Handle(Que As BG3_Obj_Template_Class) As String
        Dim value As LSLib.LS.NodeAttribute = Nothing
        If Que.NodeLSLIB.Attributes.TryGetValue(UTAM_Handle, value) = False OrElse IsNothing(value) Then _LastHandle = "" Else _LastHandle = value.Value.ToString
        Return _LastHandle
    End Function
    Public Function Get_inherited_Handle(Que As BG3_Obj_Template_Class) As String
        If IsNothing(Que.Parent) Then Return Nothing
        Return Que.Parent.ReadAttribute_Or_Inhterithed(Key)
    End Function
    Public Function Get_Current_Handle(Que As BG3_Obj_Template_Class) As String
        If Me.EditIsConditional = True AndAlso Me.CheckBox1.Checked Then
            Return Get_inherited_Handle(Que)
        Else
            Return Get_Utam_Handle(Que)
        End If
    End Function


    Private _LastHandle As String = ""
    Public Function Get_Last_Utam_Handle() As String
        Return _LastHandle
    End Function
    Public Overrides Function Conditional_GetParent_Value(Parent As BG3_Obj_Template_Class) As String
        Dim handle As String
        handle = Parent.ReadAttribute_Or_Inhterithed(Key)
        Dim Loca As String = FuncionesHelpers.GameEngine.ProcessedLocalizationList.Localize(handle, Bg3_Enum_Languages.English)
        If Not IsNothing(Loca) Then Return Loca
        Return ""
    End Function
    Public Overrides Function Set_ValueString(Que As BG3_Obj_Template_Class) As String
        Dim value As LSLib.LS.NodeAttribute = Nothing
        If Que.NodeLSLIB.Attributes.TryGetValue(UTAM_Handle, value) = False Then Return ""
        Return value.Value.ToString
    End Function
End Class

<ToolboxBitmap(GetType(System.Windows.Forms.ComboBox))>
Public MustInherit Class Combobox_Editor_Generic_GenericAttribute
    Inherits Editor_Template_GenericAttribute
    Sub New(Key As String)
        Me.Key = Key
        Me.EditorType = BG3_Editor_Type.Combobox
    End Sub
    Sub New(Key As String, AttributeType As LSLib.LS.AttributeType)
        Me.Key = Key
        Me.AttributeType = AttributeType
        Me.EditorType = BG3_Editor_Type.Combobox
    End Sub
    Sub New()
    End Sub
End Class

<ToolboxBitmap(GetType(System.Windows.Forms.NumericUpDown))>
Public MustInherit Class Numeric_Editor_Template_GenericAttribute
    Inherits Editor_Template_GenericAttribute
    Sub New(Key As String, AttributeType As LSLib.LS.AttributeType)
        Me.Key = Key
        Me.AttributeType = AttributeType
        NumericMinimum = 0
        NumericMaximum = 100
        NumericValue = 0
        NumericDecimalPlaces = 0
        NumericIncrement = 1
        Me.EditorType = BG3_Editor_Type.NumericUpDown
    End Sub
    Sub New(Key As String, Minimum As Decimal, Maximum As Decimal, DecimalPlaces As Integer, Increment As Integer, AttributeType As LSLib.LS.AttributeType)
        Me.Key = Key
        Me.AttributeType = AttributeType
        Me.NumericMinimum = Minimum
        Me.NumericMaximum = Maximum
        Me.NumericDecimalPlaces = DecimalPlaces
        Me.NumericIncrement = Increment
        Me.EditorType = BG3_Editor_Type.NumericUpDown
    End Sub
    Sub New()
    End Sub
End Class
