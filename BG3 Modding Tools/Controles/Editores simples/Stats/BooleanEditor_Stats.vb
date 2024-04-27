Public MustInherit Class Boolean_Editor_Stats_GenericAttribute
    Inherits Combobox_Editor_Stats_GenericAttribute
    Sub New(key)
        MyBase.New(key)
        ComboItems = New List(Of String) From {"False", "True"}
        Reload_Combo()
    End Sub
    Protected Overrides Function Text_to_Combo(Value As String) As String
        If Value = "True" Then Return "True"
        Return "False"
    End Function
    Protected Overrides Function Combo_To_Text(Value As String) As String
        If Value = "True" Then Return "True"
        Return "False"
    End Function
End Class

Public Class BG3Editor_Stat_Unique
    Inherits Boolean_Editor_Stats_GenericAttribute
    Sub New()
        MyBase.New("Unique")
        Label = "Unique"
    End Sub
    Protected Overrides Function Text_to_Combo(Value As String) As String
        If Value = "1" Then Return "True"
        Return "False"
    End Function
    Protected Overrides Function Combo_To_Text(Value As String) As String
        If Value = "True" Then Return "1"
        Return "0"
    End Function
End Class
Public Class BG3Editor_Stat_Special_UnlimitedDye
    Inherits Boolean_Editor_Stats_GenericAttribute
    Sub New()
        MyBase.New("Transform 1")
        Label = "Unlimited"
        Me.EditIsConditional = False
        Me.ShowConditional = False
    End Sub
    Protected Overrides Function Text_to_Combo(Value As String) As String
        If Value = "None" Then Return "True"
        Return "False"
    End Function
    Protected Overrides Function Combo_To_Text(Value As String) As String
        If Value = "True" Then Return "None"
        Return "Consume"
    End Function
End Class
Public Class BG3Editor_Stat_Special_RemoverDye
    Inherits Boolean_Editor_Stats_GenericAttribute
    Public Colorpreset As String = Nothing
    Sub New()
        MyBase.New("DyeColorPresetResource")
        Label = "Remover"
        Me.EditIsConditional = False
        Me.ShowConditional = False
    End Sub
    Public Overrides Function Read(Que As BG3_Obj_Stats_Class) As Boolean
        If Que.Data.ContainsKey(Key) Then TextBox1.Text = "False" Else TextBox1.Text = "True"
        Return True
    End Function
    Public Overrides Function Write(Que As BG3_Obj_Stats_Class) As Boolean
        If TextBox1.Text = "True" Then Que.Data.Remove(Key) : Return True
        If Not IsNothing(Colorpreset) Then
            If Que.Data.TryAdd("DyeColorPresetResource", Colorpreset) = False Then Que.Data("DyeColorPresetResource") = Colorpreset
            Return True
        Else
            Return False
        End If
    End Function
    Public Overloads Function Write(Que As BG3_Obj_Stats_Class, ColorPresetKey As String) As Boolean
        Colorpreset = ColorPresetKey
        Return Write(Que)
    End Function

End Class

