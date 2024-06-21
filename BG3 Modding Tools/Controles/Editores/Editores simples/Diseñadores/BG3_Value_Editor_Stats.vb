Imports LSLib.LS

<ToolboxBitmap(GetType(System.Windows.Forms.TextBox))>
Public MustInherit Class Editor_Stats_Generic
    Inherits BG3_Value_Editor_Generic
    Protected Key As String = "ToDefine"
    Public Overrides Function Create(Value As String, Que As BG3_Obj_Stats_Class) As Boolean
        Select Case Key
            Case "Name"
                Que.Name_Write = Value
                Return False
            Case "Using"
                Que.Using = Value
                Return False
            Case "Type"
                Dim typ As BG3_Enum_StatType = Nothing
                If [Enum].TryParse(Of BG3_Enum_StatType)(Value, typ) = False Then typ = BG3_Enum_StatType.Object
                Que.Type = typ
                Return False
            Case Else
                Return Que.Data.TryAdd(Key, Value)
        End Select
        Return False
    End Function
    Public Shared Function Create_Generic(Key As String, Value As String, Que As BG3_Obj_Stats_Class) As Boolean
        Select Case Key
            Case "Name"
                Que.Name_Write = Value
                Return False
            Case "Using"
                Que.Using = Value
                Return False
            Case "Type"
                Dim typ As BG3_Enum_StatType = Nothing
                If [Enum].TryParse(Of BG3_Enum_StatType)(Value, typ) = False Then typ = BG3_Enum_StatType.Object
                Que.Type = typ
                Return False
            Case Else
                Return Que.Data.TryAdd(Key, Value)
        End Select
        Return False
    End Function
    Public Shared Function Replace_Generic(Key As String, Value As String, Que As BG3_Obj_Stats_Class) As Boolean
        Select Case Key
            Case "Name"
                Que.Name_Write = Value
                Return False
            Case "Using"
                Que.Using = Value
                Return False
            Case "Type"
                Dim typ As BG3_Enum_StatType = Nothing
                If [Enum].TryParse(Of BG3_Enum_StatType)(Value, typ) = False Then typ = BG3_Enum_StatType.Object
                Que.Type = typ
                Return False
            Case Else
                If Que.Data.TryAdd(Key, Value) = False Then
                    Que.Data(Key) = Value
                End If
                Return True
        End Select
        Return False
    End Function
End Class
<ToolboxBitmap(GetType(System.Windows.Forms.TextBox))>
Public MustInherit Class Editor_Stat_GenericTranslate
    Inherits TextBox_Editor_Stats_GenericAttribute
    Protected UTAM_Handle As String = "ToDefine"
    Public Function Create_Attribute(ByRef Que As BG3_Obj_Stats_Class, Value As String) As Boolean
        Que.Data.TryAdd(UTAM_Handle, Value)
        Return True
    End Function

    Sub New()
        MyBase.New()
        MyBase.Key=""
    End Sub
    Sub New(Key As String, Utam_Handle As String)
        MyBase.Key = Key
        Me.UTAM_Handle = Utam_Handle
    End Sub
    Public Overrides Function Conditional_changed_Empty(Que As BG3_Obj_Stats_Class) As String
        Dim value As String = Nothing
        Que.Data.TryGetValue(UTAM_Handle, value)
        Dim Loca As String = FuncionesHelpers.GameEngine.ProcessedLocalizationList.Localize(value, Bg3_Enum_Languages.English)
        If IsNothing(Loca) Then
            Dim handle As String = Que.Get_Data_Or_Inherited(Key)
            If Not IsNothing(handle) Then value = handle
        End If
        Return value
    End Function

    Public Function GetPropertyName() As String
        Return Key
    End Function
    Public Function Get_Utam_Handle(Que As BG3_Obj_Stats_Class) As String
        Dim value As String = Nothing
        If IsNothing(Que) Then Return ""
        If Que.Data.TryGetValue(UTAM_Handle, value) = False OrElse IsNothing(value) Then _LastHandle = "" Else _LastHandle = value
        Return _LastHandle
    End Function
    Public Function Get_inherited_Handle(Que As BG3_Obj_Stats_Class) As String
        If IsNothing(Que.Parent) Then Return Nothing
        Return Que.Get_Data_Or_Inherited(Key)
    End Function
    Public Function Get_Current_Handle(Que As BG3_Obj_Stats_Class) As String
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
    Public Overrides Function Conditional_GetParent_Value(Parent As BG3_Obj_Stats_Class) As String
        Dim handle As String
        handle = Parent.Get_Data_Or_Inherited(Key)
        Dim Loca As String = FuncionesHelpers.GameEngine.ProcessedLocalizationList.Localize(handle, Bg3_Enum_Languages.English)
        If Not IsNothing(Loca) Then Return Loca
        Return ""
    End Function
    Public Overrides Function Set_ValueString(Que As BG3_Obj_Stats_Class) As String
        Dim value As String = Nothing
        If Que.Data.TryGetValue(UTAM_Handle, value) = False Then Return ""
        Return value
    End Function
    Public Overrides Function Get_ValueString(ByRef value As String) As Boolean
        Dim handle As String
        If IsNothing(value) Then
            TextBox1.Text = "Not defined"
            Return False
        End If
        handle = value
        Dim Loca As String = FuncionesHelpers.GameEngine.ProcessedLocalizationList.Localize(handle, Bg3_Enum_Languages.English)
        If Not IsNothing(Loca) Then
            TextBox1.Text = Loca
            Return True
        End If
        TextBox1.Text = "Not defined"
        Return False
    End Function
End Class


Public MustInherit Class TextBox_Editor_Stats_GenericAttribute
    Inherits Editor_Stats_Generic
    Sub New(Key As String)
        Me.Key = Key
    End Sub
    Sub New()

    End Sub
    Public Overrides Function Read(Que As BG3_Obj_Stats_Class) As Boolean
        Last_read = Que
        Dim value As String = Nothing
        If Me.EditIsConditional Then
            If Que.Data.TryGetValue(Key, value) = False Then Me.CheckBox1.Checked = False Else Me.CheckBox1.Checked = True
            Return Conditional_Changed(Que)
        End If
        Select Case Key
            Case "Name"
                value = Que.Name
            Case "Using"
                value = Que.Using
            Case "Type"
                value = [Enum].GetName(Of BG3_Enum_StatType)(Que.Type)
            Case Else
                value = Que.Get_Data_Or_Inherited(Key)
        End Select
        Return Get_ValueString(value)
    End Function

    Public Overrides Function Conditional_GetParent_Value(Parent As BG3_Obj_Stats_Class) As String
        Select Case Key
            Case "Name"
                Return "ERROR"
            Case "Using"
                Return Parent.Using
            Case "Type"
                Return Parent.Type
            Case Else
                Return Parent.Get_Data_Or_Inherited(Key)
        End Select
    End Function
    Public Overrides Function Conditional_Changed(Que As BG3_Obj_Stats_Class) As Boolean
        If Me.EditIsConditional = True AndAlso CheckBox1.Checked = False Then
            If Not IsNothing(Que.Parent) Then
                TextBox1.Text = Conditional_GetParent_Value(Que.Parent)
                Return True
            Else
                TextBox1.Text = ""
                Return False
            End If
        End If
        Dim value As String = Nothing
        Select Case Key
            Case "Name"
                value = Que.Name
            Case "Using"
                value = Que.Using
            Case "Type"
                value = [Enum].GetName(Of BG3_Enum_StatType)(Que.Type)
            Case Else
                If Que.Data.TryGetValue(Key, value) = False Then
                    If Not IsNothing(Que.Parent) Then value = Conditional_changed_Empty(Que)
                End If
        End Select
        Return Get_ValueString(value)
    End Function
    Public Overrides Function Conditional_changed_Empty(Que As BG3_Obj_Stats_Class) As String
        Dim value As String = Que.Parent.Get_Data_Or_Inherited(Key)
        Return value
    End Function
    Public Overridable Function Get_ValueString(ByRef value As String) As Boolean
        If IsNothing(value) Then TextBox1.Text = "" : Return False
        TextBox1.Text = value
        Return True
    End Function
    Public Overridable Function Set_ValueString(Que As BG3_Obj_Stats_Class) As String
        Return TextBox1.Text
    End Function

    Public Overrides Function Write(Que As BG3_Obj_Stats_Class) As Boolean
        If Me.AllowEdit = False Then Return False
        If Me.AllowEdit = True Then
            If Me.EditIsConditional AndAlso Me.CheckBox1.Checked = False Then
                Que.Data.Remove(Key)
                Return True
            Else
                Dim value As String = Set_ValueString(Que)
                Select Case Key
                    Case "Name"
                        Que.Name_Write = value
                    Case "Using"
                        Que.Using = value
                    Case "Type"
                        Dim typ As BG3_Enum_StatType = Nothing
                        If [Enum].TryParse(Of BG3_Enum_StatType)(value, typ) Then typ = BG3_Enum_StatType.Object
                        Que.Type = typ
                    Case Else
                        If Que.Data.TryAdd(Key, value) = False Then Que.Data(Key) = value
                End Select
                Return True
            End If
        End If
        Return False
    End Function
End Class

<ToolboxBitmap(GetType(System.Windows.Forms.ComboBox))>
Public MustInherit Class Combobox_Editor_Stats_GenericAttribute
    Inherits TextBox_Editor_Stats_GenericAttribute
    Sub New(Key As String)
        Me.Key = Key
        Me.EditorType = BG3_Editor_Type.Combobox
    End Sub
    Sub New()
        Me.EditorType = BG3_Editor_Type.Combobox
    End Sub
End Class

<ToolboxBitmap(GetType(System.Windows.Forms.NumericUpDown))>
Public MustInherit Class Numeric_Editor_Stats_GenericAttribute
    Inherits TextBox_Editor_Stats_GenericAttribute
    Sub New(Key As String)
        Me.Key = Key
        NumericMinimum = 0
        NumericMaximum = 100
        NumericValue = 0
        NumericDecimalPlaces = 0
        NumericIncrement = 1
        Me.EditorType = BG3_Editor_Type.NumericUpDown
    End Sub
    Sub New(Key As String, Minimum As Decimal, Maximum As Decimal, DecimalPlaces As Integer, Increment As Decimal)
        Me.Key = Key
        Me.NumericMinimum = Minimum
        Me.NumericMaximum = Maximum
        Me.NumericDecimalPlaces = DecimalPlaces
        Me.NumericIncrement = Increment
        Me.EditorType = BG3_Editor_Type.NumericUpDown
    End Sub
    Sub New()
    End Sub
End Class