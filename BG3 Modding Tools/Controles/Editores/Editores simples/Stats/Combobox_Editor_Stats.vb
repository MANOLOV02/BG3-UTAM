Public Class BG3Editor_Stats_Type
    Inherits Combobox_Editor_Stats_GenericAttribute
    Sub New()
        MyBase.New("Type")
        Label = "Stat type"
        ComboItems = [Enum].GetNames(GetType(BG3_Enum_StatType)).Order.ToList
        Reload_Combo()
    End Sub
End Class
Public Class BG3Editor_Stats_Rarity
    Inherits Combobox_Editor_Stats_GenericAttribute
    Sub New()
        MyBase.New("Rarity")
        Label = "Rarity"
        ComboItems = FuncionesHelpers.Rarity
        Reload_Combo()
    End Sub
End Class

Public Class BG3Editor_Stats_Slots_Armor
    Inherits Combobox_Editor_Stats_GenericAttribute
    Sub New()
        MyBase.New("Slot")
        Label = "Slot"
        ComboItems = FuncionesHelpers.Slots_Armor
        Reload_Combo()
    End Sub

    Protected Overrides Function Text_to_Combo(Value As String) As String
        If Value = "Melee Offhand Weapon" Then Return "Shield (Melee Offhand Weapon)"
        Return Value
    End Function
    Protected Overrides Function Combo_To_Text(Value As String) As String
        If Value = "Shield (Melee Offhand Weapon)" Then Return "Melee Offhand Weapon"
        Return Value
    End Function

End Class

Public Class BG3Editor_Stats_InventoryTab
    Inherits Combobox_Editor_Stats_GenericAttribute
    Sub New()
        MyBase.New("InventoryTab")
        Label = "InventoryTab"
        ComboItems = FuncionesHelpers.InventoryTabs
        Reload_Combo()
    End Sub
End Class
Public Class BG3Editor_Stats_GameSize
    Inherits Combobox_Editor_Stats_GenericAttribute
    Sub New()
        MyBase.New("GameSize")
        Label = "Game size"
        ComboItems = FuncionesHelpers.ObjectSize
        Reload_Combo()
    End Sub
End Class
Public Class BG3Editor_Stats_ArmorType
    Inherits Combobox_Editor_Stats_GenericAttribute
    Sub New()
        MyBase.New("ArmorType")
        Label = "Armor type"
        ComboItems = FuncionesHelpers.ArmorType
        Reload_Combo()
    End Sub
End Class
Public Class BG3Editor_Stats_ProficiencyGroup
    Inherits Combobox_Editor_Stats_GenericAttribute
    Sub New()
        MyBase.New("Proficiency Group")
        Label = "Proficiency group"
        ComboItems = FuncionesHelpers.ProficiencyGroup_Armor
        Reload_Combo()
    End Sub
End Class
Public Class BG3Editor_Stats_ArmorClassAbility
    Inherits Combobox_Editor_Stats_GenericAttribute
    Sub New()
        MyBase.New("Armor Class Ability")
        Label = "Armor class ability"
        ComboItems = FuncionesHelpers.Ability
        Reload_Combo()
    End Sub
End Class


