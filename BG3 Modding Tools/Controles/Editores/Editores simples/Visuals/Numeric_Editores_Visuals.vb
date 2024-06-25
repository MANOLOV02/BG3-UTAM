Public Class BG3Editor_Texture_Height
    Inherits Numeric_Editor_Visuals_GenericAttribute
    Sub New()
        MyBase.New("Height", 4, 4096, 0, 1, LSLib.LS.AttributeType.Int)
        Label = "Height"
    End Sub
End Class
Public Class BG3Editor_Texture_Width
    Inherits Numeric_Editor_Visuals_GenericAttribute
    Sub New()
        MyBase.New("Width", 4, 4096, 0, 1, LSLib.LS.AttributeType.Int)
        Label = "Width"
    End Sub
End Class
Public Class BG3Editor_Texture_Depth
    Inherits Numeric_Editor_Visuals_GenericAttribute
    Sub New()
        MyBase.New("Depth", 1, 100, 0, 1, LSLib.LS.AttributeType.Int)
        Label = "Depth"
    End Sub
End Class
Public Class BG3Editor_Texture_Type
    Inherits Numeric_Editor_Visuals_GenericAttribute
    Sub New()
        MyBase.New("Type", 1, 100, 0, 1, LSLib.LS.AttributeType.Int)
        Label = "Type"
    End Sub
End Class
Public Class BG3Editor_Texture_Format
    Inherits Numeric_Editor_Visuals_GenericAttribute
    Sub New()
        MyBase.New("Format", 1, 100, 0, 1, LSLib.LS.AttributeType.UInt)
        Label = "Format"
    End Sub
End Class

Public Class BG3Editor_Visuals_MaterialType
    Inherits Numeric_Editor_Visuals_GenericAttribute
    Sub New()
        MyBase.New("MaterialType", 0, 255, 0, 1, LSLib.LS.AttributeType.Byte)
        Label = "Material type"
    End Sub
End Class
Public Class BG3Editor_Visuals_LOD
    Inherits Numeric_Editor_Visuals_GenericAttribute
    Sub New()
        MyBase.New("LOD", 0, 255, 0, 1, LSLib.LS.AttributeType.Byte)
        Label = "LOD"
    End Sub
End Class
Public Class BG3Editor_ScalarsandVectors_ValueFloat
    Inherits Numeric_Editor_Visuals_GenericAttribute
    Sub New()
        MyBase.New("Value", -1000, 1000, 5, 0.1, LSLib.LS.AttributeType.Float)
        Label = "Value"
    End Sub
End Class

Public Class BG3Editor_ScalarsandVectors_BaseValueFloat
    Inherits Numeric_Editor_Visuals_GenericAttribute
    Sub New()
        MyBase.New("BaseValue", -1000, 1000, 5, 0.1, LSLib.LS.AttributeType.Float)
        Label = "BaseValue"
    End Sub
End Class
