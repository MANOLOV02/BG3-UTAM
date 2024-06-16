Public Class BG3Editor_ActionResource_IsHidden
    Inherits Combobox_Editor_FlagsAndTags_GenericAttribute
    Sub New()
        MyBase.New("IsHidden", LSLib.LS.AttributeType.Bool)
        Label = "Hidden"
        ComboItems = New List(Of String) From {"False", "True"}
        Reload_Combo()
    End Sub

End Class
Public Class BG3Editor_ActionResource_IsSpellResource
    Inherits Combobox_Editor_FlagsAndTags_GenericAttribute
    Sub New()
        MyBase.New("IsSpellResource", LSLib.LS.AttributeType.Bool)
        Label = "Spell resource"
        ComboItems = New List(Of String) From {"False", "True"}
        Reload_Combo()
    End Sub

End Class
Public Class BG3Editor_ActionResource_PartyActionResource
    Inherits Combobox_Editor_FlagsAndTags_GenericAttribute
    Sub New()
        MyBase.New("PartyActionResource", LSLib.LS.AttributeType.Bool)
        Label = "Party action"
        ComboItems = New List(Of String) From {"False", "True"}
        Reload_Combo()
    End Sub

End Class
Public Class BG3Editor_ActionResource_ShowOnActionResourcePanel
    Inherits Combobox_Editor_FlagsAndTags_GenericAttribute
    Sub New()
        MyBase.New("ShowOnActionResourcePanel", LSLib.LS.AttributeType.Bool)
        Label = "Show on panel"
        ComboItems = New List(Of String) From {"False", "True"}
        Reload_Combo()
    End Sub

End Class
Public Class BG3Editor_ActionResource_UpdatesSpellPowerLevel
    Inherits Combobox_Editor_FlagsAndTags_GenericAttribute
    Sub New()
        MyBase.New("UpdatesSpellPowerLevel", LSLib.LS.AttributeType.Bool)
        Label = "Updates level"
        ComboItems = New List(Of String) From {"False", "True"}
        Reload_Combo()
    End Sub

End Class
Public Class BG3Editor_ActionResource_ReplenishType
    Inherits Combobox_Editor_FlagsAndTags_GenericAttribute
    Sub New()
        MyBase.New("ReplenishType", LSLib.LS.AttributeType.FixedString)
        Label = "Replenish"
        ComboItems = FuncionesHelpers.ReplenishType
        Reload_Combo()
    End Sub

End Class


