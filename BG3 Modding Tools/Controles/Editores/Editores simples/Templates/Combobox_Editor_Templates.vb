Imports System.Collections.Immutable
Imports System.ComponentModel
Imports System.Windows.Forms.Design
Imports LSLib.Granny
Imports LSLib.LS.Story

Public Class BG3Editor_Template_Type
    Inherits Combobox_Editor_Generic_GenericAttribute
    Sub New()
        MyBase.New("Type", LSLib.LS.AttributeType.FixedString)
        Label = "Template type"
        ComboItems = [Enum].GetNames(GetType(BG3_Enum_Templates_Type)).Order.ToList
        Reload_Combo()
    End Sub
End Class
Public Class BG3Editor_Template_UtamType
    Inherits Combobox_Editor_Generic_GenericAttribute
    Sub New()
        MyBase.New("UTAM_Type", LSLib.LS.AttributeType.FixedString)
        Label = "Utam type"
        ComboItems = [Enum].GetNames(GetType(BG3_Enum_UTAM_Type)).Order.ToList
        Reload_Combo()
    End Sub
End Class
Public Class BG3Editor_Template_UtamGroup
    Inherits Combobox_Editor_Generic_GenericAttribute
    Sub New()
        MyBase.New("UTAM_Group", LSLib.LS.AttributeType.FixedString)
        Label = "Group"
        Reload_Combo()
    End Sub
    Public Sub Update_Groups(ByRef Groups As List(Of String))
        ComboItems = Groups
        Reload_Combo()
    End Sub

    Private Function Do_read(que As BG3_Obj_Generic_Class) As Boolean
        Dim value As LSLib.LS.NodeAttribute = Nothing
        If que.NodeLSLIB.Attributes.TryGetValue(Key, value) = False Then
            TextBox1.Text = "(Default)"
        Else
            TextBox1.Text = value.AsString(Funciones.Guid_to_string)
        End If
        Return True
    End Function
    Private Function Do_read(que As BG3_Obj_Stats_Class) As Boolean
        Dim value As String = Nothing
        If que.Data.TryGetValue(Key, value) = False Then
            TextBox1.Text = "(Default)"
        Else
            TextBox1.Text = value
        End If
        Return True
    End Function

    Public Overrides Function Read(Que As BG3_Obj_Template_Class) As Boolean
        Return Do_read(Que)
    End Function
    Public Overrides Function Write(Que As BG3_Obj_Template_Class) As Boolean
        Return do_write(Que)
    End Function
    Public Overrides Function Read(Que As BG3_Obj_FlagsAndTags_Class) As Boolean
        Return Do_read(Que)
    End Function
    Public Overrides Function Read(Que As BG3_Obj_VisualBank_Class) As Boolean
        Return Do_read(Que)
    End Function
    Public Overrides Function Read(Que As BG3_Obj_Stats_Class) As Boolean
        Return Do_read(Que)
    End Function

    Public Overrides Function Write(Que As BG3_Obj_FlagsAndTags_Class) As Boolean
        Return do_write(Que)
    End Function
    Public Overrides Function Write(Que As BG3_Obj_VisualBank_Class) As Boolean
        Return Do_write(Que)
    End Function
    Public Overrides Function Write(Que As BG3_Obj_Stats_Class) As Boolean
        Return Do_write(Que)
    End Function

    Public Overrides Sub Clear()
        TextBox1.Text = "(Default)"
    End Sub
    Private Function Do_write(que As BG3_Obj_Stats_Class) As Boolean
        If Me.AllowEdit = False Then Return False
        If Me.AllowEdit = True Then
            Dim valueString As String = TextBox1.Text
            Dim value As String = valueString
            If que.Data.TryAdd(Key, value) = False Then
                que.Data(Key) = value
                Return True
            End If
            Return True
        End If
        Return False
    End Function
    Private Function Do_write(que As BG3_Obj_Generic_Class) As Boolean
        If Me.AllowEdit = False Then Return False
        If Me.AllowEdit = True Then
            Dim valueString As String = TextBox1.Text
            Dim value As LSLib.LS.NodeAttribute = Conver_String_to_Node(valueString)
            If que.NodeLSLIB.Attributes.TryAdd(Key, value) = False Then
                que.NodeLSLIB.Attributes(Key) = value
                Return True
            End If
            Return True
        End If
        Return False
    End Function


End Class

