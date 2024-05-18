
Imports LSLib.LS

Public Class BG3Editor_Template_Undefined
    Inherits Editor_Template_GenericAttribute
    Public Shadows Property Key As String
        Get
            Return MyBase.Key
        End Get
        Set(value As String)
            MyBase.Key = value
        End Set
    End Property
    Public Shadows Property AttributeType As LSLib.LS.AttributeType
        Get
            Return MyBase.AttributeType
        End Get
        Set(value As AttributeType)
            MyBase.AttributeType = value
        End Set
    End Property

    Sub New()
        MyBase.New("Undefined", AttributeType.FixedString)
        Label = "Undefined"
    End Sub
End Class
Public Class BG3Editor_Template_Mapkey
    Inherits Editor_Template_GenericAttribute
    Sub New()
        MyBase.New("MapKey", LSLib.LS.AttributeType.FixedString)
        Label = "Template mapkey"
    End Sub
End Class

Public Class BG3Editor_Template_Name
    Inherits Editor_Template_GenericAttribute
    Sub New()
        MyBase.New("Name", LSLib.LS.AttributeType.LSString)
        Label = "Template name"
    End Sub
End Class
Public Class BG3Editor_Template_ParentId
    Inherits Editor_Template_GenericAttribute
    Public Property MustDescendFrom As String()
    Sub New()
        MyBase.New("ParentTemplateId", LSLib.LS.AttributeType.FixedString)
        Label = "Parent mapkey"
    End Sub
    Public Overrides Function Drop_Verify_OBJ(Obj As BG3_Obj_Template_Class) As Boolean
        If IsNothing(Obj) Then Return False
        If Me.AllowEdit = False Then Return False
        If Obj.ReadAttribute_Or_Empty("ParentTemplateId") = "" Then Return False
        If Not IsNothing(Last_read) AndAlso Obj.Is_Descendant(CType(Last_read, BG3_Obj_Template_Class).MapKey) Then Return False
        Return BG3Cloner.CheckDescendant_Generic(Obj, MustDescendFrom)
    End Function
    Public Overrides Sub Drop_OBJ(Obj As BG3_Obj_Template_Class)
        If Me.EditIsConditional = True Then Me.CheckBox1.Checked = True
        Me.TextBox1.Text = Obj.Mapkey_WithoutOverride
    End Sub
    Public Overrides Function Drop_Verify_OBJ(Obj As BG3_Obj_Stats_Class) As Boolean
        If IsNothing(Obj) Then Return False
        If IsNothing(Obj.AssociatedTemplate) Then Return False
        Return Drop_Verify_OBJ(Obj.AssociatedTemplate)
    End Function
    Public Overrides Sub Drop_OBJ(Obj As BG3_Obj_Stats_Class)
        If IsNothing(Obj) Then Exit Sub
        If IsNothing(Obj.AssociatedTemplate) Then Exit Sub
        Drop_OBJ(Obj.AssociatedTemplate)
    End Sub
End Class
Public Class BG3Editor_Template_ColorPreset
    Inherits Editor_Template_GenericAttribute
    Sub New()
        MyBase.New("ColorPreset", LSLib.LS.AttributeType.UUID)
        Label = "Color preset"
    End Sub
End Class
Public Class BG3Editor_Template_EquipmentTypeID
    Inherits Editor_Template_GenericAttribute
    Sub New()
        MyBase.New("EquipmentTypeID", LSLib.LS.AttributeType.UUID)
        Label = "Equipment type"
    End Sub
    Public Overrides Function Drop_Verify_OBJ(Obj As BG3_Obj_FlagsAndTags_Class) As Boolean
        If IsNothing(Obj) Then Return False
        If Obj.Type <> BG3_Enum_FlagsandTagsType.EquipmentTypes Then Return False
        Return True
    End Function
    Public Overrides Sub Drop_OBJ(Obj As BG3_Obj_FlagsAndTags_Class)
        If IsNothing(Obj) Then Exit Sub
        If Me.EditIsConditional = True Then Me.CheckBox1.Checked = True
        Me.TextBox1.Text = Obj.Mapkey_WithoutOverride
    End Sub
    Public Overrides Function Drop_Verify_OBJ(Obj As BG3_Obj_Template_Class) As Boolean
        If IsNothing(Obj.ReadAttribute_Or_Inhterithed(Key)) Then Return False
        Return Me.AllowEdit
    End Function
    Public Overrides Sub Drop_OBJ(Obj As BG3_Obj_Template_Class)
        If Me.EditIsConditional = True Then Me.CheckBox1.Checked = True
        Me.TextBox1.Text = Obj.ReadAttribute_Or_Inhterithed(Key)
    End Sub
    Public Overrides Function Drop_Verify_OBJ(Obj As BG3_Obj_Stats_Class) As Boolean
        If IsNothing(Obj.AssociatedTemplate) Then Return False
        Return Drop_Verify_OBJ(Obj.AssociatedTemplate)
    End Function
    Public Overrides Sub Drop_OBJ(Obj As BG3_Obj_Stats_Class)
        Drop_OBJ(Obj.AssociatedTemplate)
    End Sub

End Class
Public Class BG3Editor_Template_ContainerContentFilterCondition
    Inherits Editor_Template_GenericAttribute
    Sub New()
        MyBase.New("ContainerContentFilterCondition", LSLib.LS.AttributeType.LSString)
        Label = "Filter condition"
    End Sub
End Class

Public Class BG3Editor_Template_LocalizationBase
    Inherits Editor_Template_GenericTranslate
    Sub New(Key As String, Utam_Handle As String)
        MyBase.New(Key, Utam_Handle)
    End Sub


End Class
Public Class BG3Editor_Template_DisplayName
    Inherits BG3Editor_Template_LocalizationBase
    Sub New()
        MyBase.New("DisplayName", "UTAM_h1")
        Label = "Display name"
    End Sub
End Class
Public Class BG3Editor_Template_Description
    Inherits BG3Editor_Template_LocalizationBase
    Sub New()
        MyBase.New("Description", "UTAM_h2")
        Label = "Description"
    End Sub
End Class

Public Class BG3Editor_Template_TechnicalDescription
    Inherits BG3Editor_Template_LocalizationBase
    Sub New()
        MyBase.New("TechnicalDescription", "UTAM_h3")
        Label = "Technical description"
    End Sub
End Class
Public Class BG3Editor_Template_VisualTemplate
    Inherits Editor_Template_GenericAttribute
    Sub New()
        MyBase.New("VisualTemplate", LSLib.LS.AttributeType.FixedString)
        Label = "Visual template"
    End Sub

    Public Overrides Function Drop_Verify_OBJ(Obj As BG3_Obj_Template_Class) As Boolean
        If IsNothing(Obj.ReadAttribute_Or_Inhterithed(Key)) Then Return False
        Return Me.AllowEdit
    End Function
    Public Overrides Sub Drop_OBJ(Obj As BG3_Obj_Template_Class)
        If Me.EditIsConditional = True Then Me.CheckBox1.Checked = True
        Me.TextBox1.Text = Obj.ReadAttribute_Or_Inhterithed(Key)
    End Sub
    Public Overrides Function Drop_Verify_OBJ(Obj As BG3_Obj_Stats_Class) As Boolean
        If IsNothing(Obj.AssociatedTemplate) Then Return False
        Return Drop_Verify_OBJ(Obj.AssociatedTemplate)
    End Function
    Public Overrides Sub Drop_OBJ(Obj As BG3_Obj_Stats_Class)
        Drop_OBJ(Obj.AssociatedTemplate)
    End Sub

    Public Overrides Function Drop_Verify_OBJ(Obj As BG3_Obj_VisualBank_Class) As Boolean
        If IsNothing(Obj) Then Return False
        If Obj.Type = BG3_Enum_VisualBank_Type.VisualBank Then Return Me.AllowEdit
        Return False
    End Function
    Public Overrides Sub Drop_OBJ(Obj As BG3_Obj_VisualBank_Class)
        If Me.EditIsConditional = True Then Me.CheckBox1.Checked = True
        Me.TextBox1.Text = Obj.Mapkey_WithoutOverride
    End Sub

End Class
Public Class BG3Editor_Template_PhysicsTemplate
    Inherits Editor_Template_GenericAttribute
    Sub New()
        MyBase.New("PhysicsTemplate", LSLib.LS.AttributeType.FixedString)
        Label = "Physics template"
    End Sub


    Public Overrides Function Drop_Verify_OBJ(Obj As BG3_Obj_Template_Class) As Boolean
        If IsNothing(Obj.ReadAttribute_Or_Inhterithed(Key)) Then Return False
        Return Me.AllowEdit
    End Function
    Public Overrides Sub Drop_OBJ(Obj As BG3_Obj_Template_Class)
        If Me.EditIsConditional = True Then Me.CheckBox1.Checked = True
        Me.TextBox1.Text = Obj.ReadAttribute_Or_Inhterithed(Key)
    End Sub

End Class
Public Class BG3Editor_Template_Icon
    Inherits Editor_Template_GenericAttribute
    Sub New()
        MyBase.New("Icon", LSLib.LS.AttributeType.FixedString)
        Label = "Icon"
    End Sub
    Public Overrides Function Drop_Verify_OBJ(Obj As BG3_Obj_IconUV_Class) As Boolean
        If IsNothing(Obj.MapKey) Then Return False
        Return Me.AllowEdit
    End Function
    Public Overrides Sub Drop_OBJ(Obj As BG3_Obj_IconUV_Class)
        If Me.EditIsConditional = True Then Me.CheckBox1.Checked = True
        Me.TextBox1.Text = Obj.MapKey
    End Sub
    Public Overrides Function Drop_Verify_OBJ(Obj As BG3_Obj_Template_Class) As Boolean
        If IsNothing(Obj.Icon) Then Return False
        Return Me.AllowEdit
    End Function
    Public Overrides Sub Drop_OBJ(Obj As BG3_Obj_Template_Class)
        If Me.EditIsConditional = True Then Me.CheckBox1.Checked = True
        Me.TextBox1.Text = Obj.Icon
    End Sub
    Public Overrides Function Drop_Verify_OBJ(Obj As BG3_Obj_Stats_Class) As Boolean
        If IsNothing(Obj.AssociatedTemplate) Then Return False
        Return Drop_Verify_OBJ(Obj.AssociatedTemplate)
    End Function
    Public Overrides Sub Drop_OBJ(Obj As BG3_Obj_Stats_Class)
        Drop_OBJ(Obj.AssociatedTemplate)
    End Sub
End Class
Public Class BG3Editor_Template_Stats
    Inherits Editor_Template_GenericAttribute
    Sub New()
        MyBase.New("Stats", LSLib.LS.AttributeType.FixedString)
        Label = "Stats"
    End Sub
    Public Overrides Function Drop_Verify_OBJ(Obj As BG3_Obj_Stats_Class) As Boolean
        If IsNothing(Obj.MapKey) Then Return False
        Return Me.AllowEdit
    End Function
    Public Overrides Sub Drop_OBJ(Obj As BG3_Obj_Stats_Class)
        If Me.EditIsConditional = True Then Me.CheckBox1.Checked = True
        Me.TextBox1.Text = Obj.Mapkey_WithoutOverride
    End Sub
    Public Overrides Function Drop_Verify_OBJ(Obj As BG3_Obj_Template_Class) As Boolean
        If IsNothing(Obj.AssociatedStats) Then Return False
        Return Me.AllowEdit
    End Function
    Public Overrides Sub Drop_OBJ(Obj As BG3_Obj_Template_Class)
        If Me.EditIsConditional = True Then Me.CheckBox1.Checked = True
        Me.TextBox1.Text = Obj.AssociatedStats.Mapkey_WithoutOverride
    End Sub

End Class


