Imports System.Drawing.Printing
Imports LSLib.Granny




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
    Sub New()
        MyBase.New("ParentTemplateId", LSLib.LS.AttributeType.FixedString)
        Label = "Parent mapkey"
    End Sub
End Class
Public Class BG3Editor_Template_ColorPreset
    Inherits Editor_Template_GenericAttribute
    Sub New()
        MyBase.New("ColorPreset", LSLib.LS.AttributeType.UUID)
        Label = "Color preset"
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
        Label = "Visual Template"
    End Sub

    Public Overrides Function Conditional_GetParent_Value(Parent As BG3_Obj_Template_Class) As String
        Return Parent.GetVisualTemplate_Or_Inherited()
    End Function
    Public Overrides Function Drop_Verify_OBJ(Obj As BG3_Obj_Template_Class) As Boolean
        If IsNothing(Obj.GetVisualTemplate_Or_Inherited) Then Return False
        Return Me.AllowEdit
    End Function
    Public Overrides Sub Drop_OBJ(Obj As BG3_Obj_Template_Class)
        If Me.EditIsConditional = True Then Me.CheckBox1.Checked = True
        Me.TextBox1.Text = Obj.GetVisualTemplate_Or_Inherited
    End Sub
    Public Overrides Function Drop_Verify_OBJ(Obj As BG3_Obj_VisualBank_Class) As Boolean
        If IsNothing(Obj) Then Return False
        If Obj.Type = BG3_Enum_VisualBank_Type.VisualBank Then Return Me.AllowEdit
        Return False
    End Function
    Public Overrides Sub Drop_OBJ(Obj As BG3_Obj_VisualBank_Class)
        If Me.EditIsConditional = True Then Me.CheckBox1.Checked = True
        Me.TextBox1.Text = Obj.MapKey
    End Sub

End Class

Public Class BG3Editor_Template_Icon
    Inherits Editor_Template_GenericAttribute
    Sub New()
        MyBase.New("Icon", LSLib.LS.AttributeType.FixedString)
        Label = "Icon"
    End Sub
    Public Overrides Function Conditional_GetParent_Value(Parent As BG3_Obj_Template_Class) As String
        Return Parent.GetIcon_Or_Inherited()
    End Function
    Public Overrides Function Drop_Verify_OBJ(Obj As BG3_Obj_IconUV_Class) As Boolean
        If IsNothing(Obj.MapKey) Then Return False
        Return Me.AllowEdit
    End Function
    Public Overrides Sub Drop_OBJ(Obj As BG3_Obj_IconUV_Class)
        If Me.EditIsConditional = True Then Me.CheckBox1.Checked = True
        Me.TextBox1.Text = Obj.MapKey
    End Sub
    Public Overrides Function Drop_Verify_OBJ(Obj As BG3_Obj_Template_Class) As Boolean
        If IsNothing(Obj.GetIcon_Or_Inherited) Then Return False
        Return Me.AllowEdit
    End Function
    Public Overrides Sub Drop_OBJ(Obj As BG3_Obj_Template_Class)
        If Me.EditIsConditional = True Then Me.CheckBox1.Checked = True
        Me.TextBox1.Text = Obj.GetIcon_Or_Inherited
    End Sub

End Class
Public Class BG3Editor_Template_Stats
    Inherits Editor_Template_GenericAttribute
    Sub New()
        MyBase.New("Stats", LSLib.LS.AttributeType.FixedString)
        Label = "Stats"
    End Sub
    Public Overrides Function Conditional_GetParent_Value(Parent As BG3_Obj_Template_Class) As String
        Return Parent.GetStats_Or_Inherited()
    End Function
    Public Overrides Function Drop_Verify_OBJ(Obj As BG3_Obj_Stats_Class) As Boolean
        If IsNothing(Obj.MapKey) Then Return False
        Return Me.AllowEdit
    End Function
    Public Overrides Sub Drop_OBJ(Obj As BG3_Obj_Stats_Class)
        If Me.EditIsConditional = True Then Me.CheckBox1.Checked = True
        Me.TextBox1.Text = Obj.MapKey
    End Sub
    Public Overrides Function Drop_Verify_OBJ(Obj As BG3_Obj_Template_Class) As Boolean
        If IsNothing(Obj.GetStats_Or_Inherited) Then Return False
        Return Me.AllowEdit
    End Function
    Public Overrides Sub Drop_OBJ(Obj As BG3_Obj_Template_Class)
        If Me.EditIsConditional = True Then Me.CheckBox1.Checked = True
        Me.TextBox1.Text = Obj.GetStats_Or_Inherited
    End Sub

End Class


