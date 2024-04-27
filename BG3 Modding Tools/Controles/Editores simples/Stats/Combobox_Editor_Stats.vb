Public Class BG3Editor_Stat_Type
    Inherits Combobox_Editor_Stats_GenericAttribute
    Sub New()
        MyBase.New("Type")
        Label = "Stat type"
        ComboItems = [Enum].GetNames(GetType(BG3_Enum_StatType)).Order.ToList
        Reload_Combo()
    End Sub
End Class
Public Class BG3Editor_Stat_Rarity
    Inherits Combobox_Editor_Stats_GenericAttribute
    Sub New()
        MyBase.New("Rarity")
        Label = "Rarity"
        ComboItems = FuncionesHelpers.ItemRarity
        Reload_Combo()
    End Sub
End Class






