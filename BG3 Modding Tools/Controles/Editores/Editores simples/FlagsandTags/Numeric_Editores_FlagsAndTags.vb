Public Class BG3Editor_ActionResources_Dicetype
    Inherits Numeric_Editor_FlagsandTags_GenericAttribute
    Sub New()
        MyBase.New("DiceType", 4, 4096, 0, 1, LSLib.LS.AttributeType.UInt)
        Label = "Dice type"
    End Sub
End Class
Public Class BG3Editor_ActionResources_MaxLevel
    Inherits Numeric_Editor_FlagsandTags_GenericAttribute
    Sub New()
        MyBase.New("MaxLevel", 0, 88, 0, 1, LSLib.LS.AttributeType.UInt)
        Label = "Max level"
    End Sub
End Class
Public Class BG3Editor_ActionResources_MaxValue
    Inherits Numeric_Editor_FlagsandTags_GenericAttribute
    Sub New()
        MyBase.New("MaxValue", 1, 99, 0, 1, LSLib.LS.AttributeType.UInt)
        Label = "Max value"
    End Sub
End Class
