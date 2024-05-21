Public Class BG3Editor_Stats_Weight
    Inherits Numeric_Editor_Stats_GenericAttribute
    Sub New()
        MyBase.New("Weight", 0, 100, 2, 0.05)
        Label = "Weight"
    End Sub
End Class
Public Class BG3Editor_Stats_ValueOverride
    Inherits Numeric_Editor_Stats_GenericAttribute
    Sub New()
        MyBase.New("ValueOverride", 1, 10000, 2, 0.1)
        Label = "Value override"
    End Sub
End Class
Public Class BG3Editor_Stats_ValueScale
    Inherits Numeric_Editor_Stats_GenericAttribute
    Sub New()
        MyBase.New("ValueScale", 0, 5, 2, 0.1)
        Label = "Value scale"
    End Sub
End Class
Public Class BG3Editor_Stats_ValueLevel
    Inherits Numeric_Editor_Stats_GenericAttribute
    Sub New()
        MyBase.New("ValueLevel", 1, 50, 0, 1)
        Label = "Value level"
    End Sub
End Class
Public Class BG3Editor_Stats_SupplyValue
    Inherits Numeric_Editor_Stats_GenericAttribute
    Sub New()
        MyBase.New("SupplyValue", 1, 80, 0, 1)
        Label = "Supply value"
    End Sub
End Class
Public Class BG3Editor_Stats_MinLevel
    Inherits Numeric_Editor_Stats_GenericAttribute
    Sub New()
        MyBase.New("MinLevel", 1, 50, 0, 1)
        Label = "Minimum level"
    End Sub
End Class

Public Class BG3Editor_Stats_MinAmount
    Inherits Numeric_Editor_Stats_GenericAttribute
    Sub New()
        MyBase.New("MinAmount", 1, 50, 0, 1)
        Label = "Min amount"
    End Sub
End Class
Public Class BG3Editor_Stats_MaxAmount
    Inherits Numeric_Editor_Stats_GenericAttribute
    Sub New()
        MyBase.New("MaxAmount", 1, 50, 0, 1)
        Label = "Max amount"
    End Sub
End Class
Public Class BG3Editor_Stats_ArmorClass
    Inherits Numeric_Editor_Stats_GenericAttribute
    Sub New()
        MyBase.New("ArmorClass", 1, 500, 0, 1)
        Label = "ArmorClass"
    End Sub
End Class
Public Class BG3Editor_Stats_DamageRange
    Inherits Numeric_Editor_Stats_GenericAttribute
    Sub New()
        MyBase.New("Damage Range", 1, 5000, 0, 50)
        Label = "Damage range"
    End Sub
End Class

Public Class BG3Editor_Stats_WeaponRange
    Inherits Numeric_Editor_Stats_GenericAttribute
    Sub New()
        MyBase.New("WeaponRange", 1, 5000, 0, 50)
        Label = "Weapon range"
    End Sub
End Class



