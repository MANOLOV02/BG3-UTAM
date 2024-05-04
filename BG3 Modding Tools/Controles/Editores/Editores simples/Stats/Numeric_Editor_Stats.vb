Public Class BG3Editor_Stat_Weight
    Inherits Numeric_Editor_Stats_GenericAttribute
    Sub New()
        MyBase.New("Weight", 0, 100, 2)
        Label = "Weight"
    End Sub
End Class
Public Class BG3Editor_Stat_ValueOverride
    Inherits Numeric_Editor_Stats_GenericAttribute
    Sub New()
        MyBase.New("ValueOverride", 1, 10000, 2)
        Label = "Value override"
    End Sub
End Class


