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
    Public Enum Item_type_Enum
        Armor
        Weapons
        All
        Others
    End Enum

    Private _Slot_type As Item_type_Enum = Item_type_Enum.Armor
    Public Property Slot_Type As Item_type_Enum
        Get
            Return _Slot_type
        End Get
        Set(value As Item_type_Enum)
            _Slot_type = value
            Select Case value
                Case Item_type_Enum.All
                    ComboItems = FuncionesHelpers.Itemslot
                Case Item_type_Enum.Armor
                    ComboItems = FuncionesHelpers.Slots_Armor
                Case Item_type_Enum.Weapons
                    ComboItems = FuncionesHelpers.Slots_Weapons
                Case Item_type_Enum.Others
                    ComboItems = FuncionesHelpers.Slots_Others
            End Select
            Reload_Combo()
        End Set
    End Property

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
    Public Enum Item_type_Enum
        Armor
        Weapons
        All
        Others
    End Enum
    Private _Slot_type As Item_type_Enum = Item_type_Enum.Armor
    Public Property Slot_Type As Item_type_Enum
        Get
            Return _Slot_type
        End Get
        Set(value As Item_type_Enum)
            _Slot_type = value
            Select Case value
                Case Item_type_Enum.All
                    ComboItems = FuncionesHelpers.ProficiencyGroupFlags
                Case Item_type_Enum.Armor
                    ComboItems = FuncionesHelpers.ProficiencyGroup_Armor
                Case Item_type_Enum.Weapons
                    ComboItems = FuncionesHelpers.ProficiencyGroup_Weapons
                Case Item_type_Enum.Others
                    ComboItems = FuncionesHelpers.ProficiencyGroup_Others
            End Select
            Reload_Combo()
        End Set
    End Property

    Sub New()
        MyBase.New("Proficiency Group")
        Label = "Proficiency group"
        ComboItems = FuncionesHelpers.ProficiencyGroup_Armor
        Reload_Combo()
    End Sub
    Protected Overrides Function Text_to_Combo(Value As String) As String
        If Value = "" Then Return "None"
        Return Value
    End Function
    Protected Overrides Function Combo_To_Text(Value As String) As String
        If Value = "None" Then Return "None"
        Return Value
    End Function

End Class
Public Class BG3Editor_Stats_WeaponGroup
    Inherits Combobox_Editor_Stats_GenericAttribute
    Sub New()
        MyBase.New("Weapon Group")
        Label = "Weapon group"
        ComboItems = FuncionesHelpers.Weapon_Group
        Reload_Combo()
    End Sub
End Class
Public Class BG3Editor_Stats_Damage_Type
    Inherits Combobox_Editor_Stats_GenericAttribute
    Sub New()
        MyBase.New("Damage Type")
        Label = "Damage type"
        ComboItems = FuncionesHelpers.Damage_Type
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


