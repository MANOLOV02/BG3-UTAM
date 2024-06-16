Public Class BG3Editor_FlagsAndTags_UUID
    Inherits Editor_FlagsandTags_GenericAttribute
    Sub New()
        MyBase.New("UUID", LSLib.LS.AttributeType.UUID)
        Label = "UUID"
    End Sub
End Class
Public Class BG3Editor_FlagsAndTag_Name
    Inherits Editor_FlagsandTags_GenericAttribute
    Sub New()
        MyBase.New("Name", LSLib.LS.AttributeType.FixedString)
        Label = "Name"
    End Sub
End Class
Public Class BG3Editor_FlagsAndTag_Description
    Inherits Editor_FlagsandTags_GenericAttribute
    Sub New()
        MyBase.New("Description", LSLib.LS.AttributeType.LSString)
        Label = "Description"
    End Sub
End Class

Public Class BG3Editor_FlagsAndTag_LocalizationBase
    Inherits Editor_FlagsAndTags_GenericTranslate
    Sub New(Key As String, Utam_Handle As String)
        MyBase.New(Key, Utam_Handle)
    End Sub
End Class

Public Class BG3Editor_FlagsandTag_DisplayName
    Inherits BG3Editor_FlagsAndTag_LocalizationBase
    Sub New()
        MyBase.New("DisplayName", "UTAM_h1")
        Label = "Display name"
    End Sub
End Class
Public Class BG3Editor_FlagsandTag_DisplayDescription
    Inherits BG3Editor_FlagsAndTag_LocalizationBase
    Sub New()
        MyBase.New("DisplayDescription", "UTAM_h2")
        Label = "Display description"
    End Sub
End Class
Public Class BG3Editor_FlagsandTag_TranslatedError
    Inherits BG3Editor_FlagsAndTag_LocalizationBase
    Sub New()
        MyBase.New("Error", "UTAM_h3")
        Label = "Error description"
    End Sub
End Class
Public Class BG3Editor_FlagsandTag_TranslatedDescription
    Inherits BG3Editor_FlagsAndTag_LocalizationBase
    Sub New()
        MyBase.New("Description", "UTAM_h2")
        Label = "Description"
    End Sub
End Class
Public Class BG3Editor_FlagsandTag_Icon
    Inherits Editor_FlagsandTags_GenericAttribute
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