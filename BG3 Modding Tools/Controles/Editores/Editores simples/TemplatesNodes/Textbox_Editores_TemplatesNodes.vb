Imports LSLib.LS
Imports LSLib
Imports System.DirectoryServices.ActiveDirectory
Imports System.Net.Http.Headers
Imports System.Text.Json
Imports LSLib.LS.Story

Public Class BG3Editor_Template_Node_ParentRaceMapkey
    Inherits BG3_Value_Editor_Generic
    Public Property KeyToRead As String
    Sub New()
        MyBase.New()
        Label = "Race overrided"
        KeyToRead = "MapValue"
    End Sub
    Public Overloads Function Read(Que As LSLib.LS.Node) As Boolean
        If IsNothing(Que) Then TextBox1.Text = "" : Return True
        Dim ov As LSLib.LS.NodeAttribute = Nothing
        If Que.Attributes.TryGetValue(KeyToRead, ov) = False OrElse IsNothing(ov) Then TextBox1.Text = "" : Return True
        Dim str As String = ov.AsString(Funciones.Guid_to_string)
        TextBox1.Text = str
        Return True
    End Function
    Public Overloads Function Write(Que As LSLib.LS.Node) As Boolean
        If IsNothing(Que) Then Return False
        Dim val As String = TextBox1.Text
        Dim ov As New LSLib.LS.NodeAttribute(AttributeType.UUID)
        ov.FromString(TextBox1.Text, Funciones.Guid_to_string)
        If Que.Attributes.TryAdd(KeyToRead, ov) = False Then
            Que.Attributes(KeyToRead).Value = ov.Value
            Return True
        End If
        Return True
    End Function
    Public Overrides Function Drop_Verify_OBJ(Obj As BG3_Obj_FlagsAndTags_Class) As Boolean
        If IsNothing(Obj) Then Return False
        If Obj.Type <> BG3_Enum_FlagsandTagsType.EquipmentRaces Then Return False
        Return True
    End Function

    Public Overrides Sub Drop_OBJ(Obj As BG3_Obj_FlagsAndTags_Class)
        If IsNothing(Obj) Then Exit Sub
        Me.TextBox1.Text = Obj.Mapkey_WithoutOverride
    End Sub

End Class
