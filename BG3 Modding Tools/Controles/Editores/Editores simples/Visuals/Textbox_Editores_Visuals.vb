Imports LSLib.Granny
Imports LSLib.LS.Story

Public Class BG3Editor_Textures_ID_Fixed
    Inherits Editor_Visuals_GenericAttribute
    Sub New()
        MyBase.New("ID", LSLib.LS.AttributeType.FixedString)
        Label = "ID"
    End Sub
End Class
Public Class BG3Editor_Textures_Name
    Inherits Editor_Visuals_GenericAttribute
    Sub New()
        MyBase.New("Name", LSLib.LS.AttributeType.LSString)
        Label = "Name"
    End Sub
End Class
Public Class BG3Editor_Visuals_Bone
    Inherits Editor_Visuals_GenericAttribute
    Sub New()
        MyBase.New("Bone", LSLib.LS.AttributeType.FixedString)
        Label = "Bone"
    End Sub
End Class

Public Class BG3Editor_Textures_Template
    Inherits Editor_Visuals_GenericAttribute
    Sub New()
        MyBase.New("Template", LSLib.LS.AttributeType.FixedString)
        Label = "Template"
    End Sub
End Class
Public Class BG3Editor_Visuals_DiffusionProfileUUID
    Inherits Editor_Visuals_GenericAttribute
    Sub New()
        MyBase.New("DiffusionProfileUUID", LSLib.LS.AttributeType.FixedString)
        Label = "Diffusion profile"
    End Sub
End Class
Public Class BG3Editor_ScalarsandVectors_BaseValueVec3
    Inherits Editor_Visuals_GenericAttribute
    Sub New()
        MyBase.New("BaseValue", LSLib.LS.AttributeType.Vec3)
        Label = "Base value"
    End Sub
End Class
Public Class BG3Editor_ScalarsandVectors_ValueVec3
    Inherits Editor_Visuals_GenericAttribute
    Sub New()
        MyBase.New("Value", LSLib.LS.AttributeType.Vec3)
        Label = "Value"
    End Sub
End Class
Public Class BG3Editor_ScalarsandVectors_GroupName
    Inherits Editor_Visuals_GenericAttribute
    Sub New()
        MyBase.New("GroupName", LSLib.LS.AttributeType.FixedString)
        Label = "Group name"
    End Sub
End Class

Public Class BG3Editor_ScalarsandVectors_BaseValueVec4
    Inherits Editor_Visuals_GenericAttribute
    Sub New()
        MyBase.New("BaseValue", LSLib.LS.AttributeType.Vec4)
        Label = "Base value"
    End Sub
End Class
Public Class BG3Editor_ScalarsandVectors_ValueVec4
    Inherits Editor_Visuals_GenericAttribute
    Sub New()
        MyBase.New("Value", LSLib.LS.AttributeType.Vec4)
        Label = "Value"
    End Sub
End Class

Public Class BG3Editor_Textures_SourceFile
    Inherits Editor_Visuals_GenericAttribute
    Sub New()
        MyBase.New("SourceFile", LSLib.LS.AttributeType.LSString)
        Label = "Source file"
    End Sub


    Public Overrides Function Drop_Verify_OBJ(Obj As BG3_Obj_VisualBank_Class) As Boolean
        If IsNothing(Obj) Then Return False
        If Obj.Type <> BG3_Enum_VisualBank_Type.TextureBank Then Return False
        Return True
    End Function
    Public Overrides Sub Drop_OBJ(Obj As BG3_Obj_VisualBank_Class)
        TextBox1.Text = Obj.ReadAttribute_Or_Empty("SourceFile")
    End Sub
End Class
Public Class BG3Editor_Materialbank_SourceFile
    Inherits Editor_Visuals_GenericAttribute
    Sub New()
        MyBase.New("SourceFile", LSLib.LS.AttributeType.LSString)
        Label = "Base material"
    End Sub


    Public Overrides Function Drop_Verify_OBJ(Obj As BG3_Obj_VisualBank_Class) As Boolean
        If IsNothing(Obj) Then Return False
        If Obj.Type <> BG3_Enum_VisualBank_Type.MaterialShader Then Return False
        Return True
    End Function
    Public Overrides Sub Drop_OBJ(Obj As BG3_Obj_VisualBank_Class)
        TextBox1.Text = Obj.Mapkey_WithoutOverride
    End Sub
End Class
Public Class BG3Editor_Visuals_VirtualTexture
    Inherits Editor_Visuals_GenericAttribute
    Protected Overridable Property NodeName As String = "VirtualTextureParameters"
    Protected Overridable Property GroupName As String = "TextureMaps"

    Sub New()
        MyBase.New("virtualtexture", LSLib.LS.AttributeType.FixedString)
        Label = "Virtual texture"
    End Sub
    Sub New(key As String, atttype As LSLib.LS.AttributeType)
        Me.Key = key
        Me.AttributeType = atttype
    End Sub
    Public Overrides Sub Clear()
        TextBox1.Text = ""
        CheckBox1.Checked = False
    End Sub
    Public Overrides Function Read(Que As BG3_Obj_VisualBank_Class) As Boolean
        If IsNothing(Que) Then Clear() : Return False
        Dim value As LSLib.LS.Node = Nothing
        Dim att As LSLib.LS.NodeAttribute = Nothing
        Dim values As List(Of LSLib.LS.Node) = Nothing
        If Que.NodeLSLIB.Children.TryGetValue(NodeName, values) Then
            For Each child In values
                If child.Attributes.TryGetValue("ParameterName", att) = True Then
                    If att.AsString(Funciones.Guid_to_string) = Key Then value = child : Exit For
                End If
            Next
        End If
        If IsNothing(value) Then Clear() : Return False
        If value.Attributes.TryGetValue("ID", att) = False Then Debugger.Break() : Clear() : Return False
        TextBox1.Text = att.AsString(Funciones.Guid_to_string)
        Return True
    End Function
    Private Function Create_Node() As LSLib.LS.Node
        Dim value As LSLib.LS.Node
        value = New LSLib.LS.Node With {.Name = NodeName, .KeyAttribute = NodeName}
        value.Attributes.TryAdd("ParameterName", New LSLib.LS.NodeAttribute(LSLib.LS.AttributeType.FixedString) With {.Value = Key})
        value.Attributes.TryAdd("ID", New LSLib.LS.NodeAttribute(LSLib.LS.AttributeType.FixedString) With {.Value = TextBox1.Text})
        value.Attributes.TryAdd("Index", New LSLib.LS.NodeAttribute(LSLib.LS.AttributeType.Int) With {.Value = 0})
        value.Attributes.TryAdd("GroupName", New LSLib.LS.NodeAttribute(LSLib.LS.AttributeType.FixedString) With {.Value = GroupName})
        value.Attributes.TryAdd("ExportAsPreset", New LSLib.LS.NodeAttribute(LSLib.LS.AttributeType.Bool) With {.Value = True})
        value.Attributes.TryAdd("Enabled", New LSLib.LS.NodeAttribute(LSLib.LS.AttributeType.Bool) With {.Value = True})
        Return value
    End Function
    Public Overrides Function Write(Que As BG3_Obj_VisualBank_Class) As Boolean
        If IsNothing(Que) Then Clear() : Return False
        Dim value As LSLib.LS.Node = Nothing
        Dim att As LSLib.LS.NodeAttribute = Nothing
        Dim values As List(Of LSLib.LS.Node) = Nothing
        If Que.NodeLSLIB.Children.TryGetValue(NodeName, values) Then
            For Each child In values
                If child.Attributes.TryGetValue("ParameterName", att) = True Then
                    If att.AsString(Funciones.Guid_to_string) = Key Then value = child : Exit For
                End If
            Next
        End If
        If IsNothing(value) Then value = Create_Node() : Que.NodeLSLIB.AppendChild(value)
        att = New LSLib.LS.NodeAttribute(LSLib.LS.AttributeType.FixedString)
        att.FromString(TextBox1.Text, Funciones.Guid_to_string)
        If value.Attributes.TryAdd("ID", att) = False Then value.Attributes("ID").Value = att.Value
        att = New LSLib.LS.NodeAttribute(LSLib.LS.AttributeType.Bool)
        If TextBox1.Text = "" Then
            att.FromString("False", Funciones.Guid_to_string)
        Else
            att.FromString("True", Funciones.Guid_to_string)
        End If
        If value.Attributes.TryAdd("Enabled", att) = False Then value.Attributes("Enabled").Value = att.Value
        Return True
    End Function
    Public Overrides Function Drop_Verify_OBJ(Obj As BG3_Obj_VisualBank_Class) As Boolean
        If IsNothing(Obj) Then Return False
        If Obj.Type <> BG3_Enum_VisualBank_Type.VirtualTextureBank Then Return False
        Return True
    End Function
    Public Overrides Sub Drop_OBJ(Obj As BG3_Obj_VisualBank_Class)
        TextBox1.Text = Obj.Mapkey_WithoutOverride
    End Sub

End Class
Public Class BG3Editor_Visuals_MaskTexture
    Inherits BG3Editor_Visuals_VirtualTexture
    Protected Overrides Property GroupName As String = "01 Texture Map"
    Protected Overrides Property NodeName As String = "Texture2DParameters"
    Sub New(key As String, atttype As LSLib.LS.AttributeType)
        Me.Key = key
        Me.AttributeType = atttype
    End Sub
    Sub New()
        MyBase.New("MSKColor", LSLib.LS.AttributeType.FixedString)
        Label = "Mask color"
    End Sub
    Public Overrides Function Drop_Verify_OBJ(Obj As BG3_Obj_VisualBank_Class) As Boolean
        If IsNothing(Obj) Then Return False
        If Obj.Type <> BG3_Enum_VisualBank_Type.TextureBank Then Return False
        Return True
    End Function
    Public Overrides Sub Drop_OBJ(Obj As BG3_Obj_VisualBank_Class)
        TextBox1.Text = Obj.Mapkey_WithoutOverride
    End Sub
End Class
Public Class BG3Editor_Visuals_NormalMap
    Inherits BG3Editor_Visuals_MaskTexture
    Protected Overrides Property GroupName As String = "01 Texture Map"
    Protected Overrides Property NodeName As String = "Texture2DParameters"

    Sub New()
        MyBase.New("normalmap", LSLib.LS.AttributeType.FixedString)
        Label = "Normal map"
    End Sub
End Class
Public Class BG3Editor_Visuals_MSKcloth
    Inherits BG3Editor_Visuals_MaskTexture
    Protected Overrides Property GroupName As String = "01 Texture Map"
    Protected Overrides Property NodeName As String = "Texture2DParameters"

    Sub New()
        MyBase.New("MSKcloth", LSLib.LS.AttributeType.FixedString)
        Label = "Mask cloth"
    End Sub
End Class
Public Class BG3Editor_Visuals_VertexColor_MSK
    Inherits BG3Editor_Visuals_MaskTexture
    Protected Overrides Property GroupName As String = "01 Texture Map"
    Protected Overrides Property NodeName As String = "Texture2DParameters"

    Sub New()
        MyBase.New("VertexColor_MSK", LSLib.LS.AttributeType.FixedString)
        Label = "Mask vertex"
    End Sub
End Class

Public Class BG3Editor_Visuals_MSKSkin
    Inherits BG3Editor_Visuals_MaskTexture
    Protected Overrides Property GroupName As String = "01 Texture Map"
    Protected Overrides Property NodeName As String = "Texture2DParameters"

    Sub New()
        MyBase.New("MSKskin", LSLib.LS.AttributeType.FixedString)
        Label = "Mask skin"
    End Sub
End Class

Public Class BG3Editor_Visuals_BasecolorMap
    Inherits BG3Editor_Visuals_MaskTexture
    Protected Overrides Property GroupName As String = "01 Texture Map"
    Protected Overrides Property NodeName As String = "Texture2DParameters"

    Sub New()
        MyBase.New("basecolor", LSLib.LS.AttributeType.FixedString)
        Label = "Base map"
    End Sub
End Class
Public Class BG3Editor_Visuals_PhisicalMap
    Inherits BG3Editor_Visuals_MaskTexture
    Protected Overrides Property GroupName As String = "01 Texture Map"
    Protected Overrides Property NodeName As String = "Texture2DParameters"

    Sub New()
        MyBase.New("physicalmap", LSLib.LS.AttributeType.FixedString)
        Label = "Physical map"
    End Sub
End Class


Public Class BG3Editor_Visuals_TemplateGR2
    Inherits Editor_Visuals_GenericAttribute
    Sub New()
        MyBase.New("Template", LSLib.LS.AttributeType.FixedString)
        Label = "Template"
    End Sub
    Public Overrides Function Drop_Verify_OBJ(Obj As BG3_Obj_VisualBank_Class) As Boolean
        If IsNothing(Obj) Then Return False
        If Obj.Type <> BG3_Enum_VisualBank_Type.VisualBank Then Return False
        Return True
    End Function
    Public Overrides Sub Drop_OBJ(Obj As BG3_Obj_VisualBank_Class)
        TextBox1.Text = Obj.ReadAttribute_Or_Inhterithed_Or_Empty("Template")
        RaiseEvent Dropped(Me)
    End Sub
    Public Shadows Event Dropped(sender As Object)
End Class

Public Class BG3Editor_Visuals_OBjectID
    Inherits Editor_Visuals_GenericAttribute
    Sub New()
        MyBase.New("ObjectID", LSLib.LS.AttributeType.FixedString)
        Label = "Object ID"
    End Sub
    Public Overrides Function Drop_Verify_OBJ(Obj As BG3_Obj_VisualBank_Class) As Boolean
        If IsNothing(Obj) Then Return False
        If Obj.Type <> BG3_Enum_VisualBank_Type.VisualBank Then Return False
        Return True
    End Function
    Public Overrides Sub Drop_OBJ(Obj As BG3_Obj_VisualBank_Class)
        TextBox1.Text = Obj.ReadAttribute_Or_Inhterithed_Or_Empty("Template")
    End Sub

End Class

Public Class BG3Editor_Visuals_MaterialID
    Inherits Editor_Visuals_GenericAttribute
    Sub New()
        MyBase.New("MaterialID", LSLib.LS.AttributeType.FixedString)
        Label = "Material"
    End Sub
    Public Overrides Function Drop_Verify_OBJ(Obj As BG3_Obj_VisualBank_Class) As Boolean
        If IsNothing(Obj) Then Return False
        If Obj.Type <> BG3_Enum_VisualBank_Type.MaterialBank Then Return False
        Return True
    End Function
    Public Overrides Sub Drop_OBJ(Obj As BG3_Obj_VisualBank_Class)
        TextBox1.Text = Obj.Mapkey_WithoutOverride
        RaiseEvent Dropped(Me)
    End Sub

    Public Shadows Event Dropped(sender As Object)
End Class
Public Class BG3Editor_Visuals_BaseVisual
    Inherits Editor_Visuals_GenericAttribute
    Sub New()
        MyBase.New("BaseVisual", LSLib.LS.AttributeType.FixedString)
        Label = "Base visual"
    End Sub
    Public Overrides Function Drop_Verify_OBJ(Obj As BG3_Obj_VisualBank_Class) As Boolean
        If IsNothing(Obj) Then Return False
        If Obj.Type <> BG3_Enum_VisualBank_Type.VisualBank Then Return False
        Return True
    End Function
    Public Overrides Sub Drop_OBJ(Obj As BG3_Obj_VisualBank_Class)
        TextBox1.Text = Obj.Mapkey_WithoutOverride
        RaiseEvent Dropped(Me)
    End Sub

    Public Shadows Event Dropped(sender As Object)
End Class
Public Class BG3Editor_Visuals_VisualResource
    Inherits Editor_Visuals_GenericAttribute
    Sub New()
        MyBase.New("VisualResource", LSLib.LS.AttributeType.FixedString)
        Label = "Visual Resource"
    End Sub
    Public Overrides Function Drop_Verify_OBJ(Obj As BG3_Obj_VisualBank_Class) As Boolean
        If IsNothing(Obj) Then Return False
        If Obj.Type <> BG3_Enum_VisualBank_Type.VisualBank Then Return False
        Return True
    End Function
    Public Overrides Sub Drop_OBJ(Obj As BG3_Obj_VisualBank_Class)
        TextBox1.Text = Obj.Mapkey_WithoutOverride
        RaiseEvent Dropped(Me)
    End Sub

    Public Shadows Event Dropped(sender As Object)
End Class
Public Class BG3Editor_Visuals_BodySetVisual
    Inherits Editor_Visuals_GenericAttribute
    Sub New()
        MyBase.New("BodySetVisual", LSLib.LS.AttributeType.FixedString)
        Label = "Body set visual"
    End Sub
    Public Overrides Function Drop_Verify_OBJ(Obj As BG3_Obj_VisualBank_Class) As Boolean
        If IsNothing(Obj) Then Return False
        If Obj.Type <> BG3_Enum_VisualBank_Type.VisualBank Then Return False
        Return True
    End Function
    Public Overrides Sub Drop_OBJ(Obj As BG3_Obj_VisualBank_Class)
        TextBox1.Text = Obj.Mapkey_WithoutOverride
        RaiseEvent Dropped(Me)
    End Sub

    Public Shadows Event Dropped(sender As Object)
End Class

Public Class BG3Editor_Visualbank_SourceFile
    Inherits Editor_Visuals_GenericAttribute
    Sub New()
        MyBase.New("SourceFile", LSLib.LS.AttributeType.LSString)
        Label = "Base mesh"
    End Sub

    Public Overrides Function Drop_Verify_OBJ(Obj As BG3_Obj_VisualBank_Class) As Boolean
        If IsNothing(Obj) Then Return False
        If Obj.Type <> BG3_Enum_VisualBank_Type.VisualBank Then Return False
        Return True
    End Function
    Public Overrides Sub Drop_OBJ(Obj As BG3_Obj_VisualBank_Class)
        TextBox1.Text = Obj.ReadAttribute_Or_Inhterithed_Or_Empty("SourceFile")
    End Sub
End Class



