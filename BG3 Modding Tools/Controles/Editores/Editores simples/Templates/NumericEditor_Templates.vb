Public Class BG3Editor_Template_maxStackAmount
    Inherits Numeric_Editor_Template_GenericAttribute
    Sub New()
        MyBase.New("maxStackAmount", 1, 99, 0, 1, LSLib.LS.AttributeType.Int)
        Label = "Max stack"
    End Sub
End Class
Public Class BG3Editor_Template_LevelOverride
    Inherits Numeric_Editor_Template_GenericAttribute
    Sub New()
        MyBase.New("LevelOverride", -1, 500, 0, 1, LSLib.LS.AttributeType.Int)
        Label = "Level override"
    End Sub
End Class

