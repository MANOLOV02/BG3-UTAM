<ToolboxBitmap(GetType(System.Windows.Forms.TextBox))>
Public MustInherit Class Editor_Stats_Generic
    Inherits BG3_Value_Editor_Generic

    Protected Key As String = "ToDefine"
    Public Overrides Function Create(Value As String, Que As BG3_Obj_Stats_Class) As Boolean
        Select Case Key
            Case "Name"
                Que.Stat_Name = Value
                Return False
            Case "Using"
                Que.Using = Value
                Return False
            Case "Type"
                Dim typ As BG3_Enum_StatType = Nothing
                If [Enum].TryParse(Of BG3_Enum_StatType)(Value, typ) Then typ = BG3_Enum_StatType.Object
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
                Que.Stat_Name = Value
                Return False
            Case "Using"
                Que.Using = Value
                Return False
            Case "Type"
                Dim typ As BG3_Enum_StatType = Nothing
                If [Enum].TryParse(Of BG3_Enum_StatType)(Value, typ) Then typ = BG3_Enum_StatType.Object
                Que.Type = typ
                Return False
            Case Else
                Return Que.Data.TryAdd(Key, Value)
        End Select
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
                Que.Data.TryGetValue(Key, value)
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
                Que.Data.TryGetValue(Key, value)
        End Select
        Return Get_ValueString(value)
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
                        Que.Stat_Name = value
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
        Me.EditorType = BG3_Editor_Type.NumericUpDown
    End Sub
    Sub New(Key As String, Minimum As Decimal, Maximum As Decimal, DecimalPlaces As Integer)
        Me.Key = Key
        Me.NumericMinimum = Minimum
        Me.NumericMaximum = Maximum
        Me.NumericDecimalPlaces = DecimalPlaces
        Me.EditorType = BG3_Editor_Type.NumericUpDown
    End Sub
    Sub New()
    End Sub
End Class