Public Class BG3Editor_Visuals_SRGB
    Inherits Combobox_Editor_Visuals_GenericAttribute
    Sub New()
        MyBase.New("SRGB", LSLib.LS.AttributeType.Bool)
        Label = "SRGB"
        ComboItems = New List(Of String) From {"False", "True"}
        Reload_Combo()
    End Sub

End Class
Public Class BG3Editor_Visuals_Localized
    Inherits Combobox_Editor_Visuals_GenericAttribute
    Sub New()
        MyBase.New("Localized", LSLib.LS.AttributeType.Bool)
        Label = "Localized"
        ComboItems = New List(Of String) From {"False", "True"}
        Reload_Combo()
    End Sub

End Class
Public Class BG3Editor_Visuals_SupportsVertexColorMask
    Inherits Combobox_Editor_Visuals_GenericAttribute
    Sub New()
        MyBase.New("SupportsVertexColorMask", LSLib.LS.AttributeType.Bool)
        Label = "Supports vertex color mask"
        ComboItems = New List(Of String) From {"False", "True"}
        Reload_Combo()
    End Sub
End Class

Public Class BG3Editor_Visuals_VertexMasks
    Inherits Combobox_Editor_Visuals_GenericAttribute
    Sub New()
        MyBase.New("VertexColorMaskSlots", LSLib.LS.AttributeType.FixedString)
        Label = "VertexColorMaskSlots"
        ComboItems = FuncionesHelpers.VertexColorMaskSlots.Order.ToList
        Reload_Combo()
    End Sub

End Class
Public Class BG3Editor_Visuals_Slot
    Inherits Combobox_Editor_Visuals_GenericAttribute
    Sub New()
        MyBase.New("Slot", LSLib.LS.AttributeType.FixedString)
        Label = "Slot"
        ComboItems = FuncionesHelpers.Visual_Slots.Order.ToList
        Reload_Combo()
    End Sub

End Class
