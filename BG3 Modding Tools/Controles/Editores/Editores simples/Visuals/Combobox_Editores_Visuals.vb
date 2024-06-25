Imports LSLib.Granny

Public Class BG3Editor_Visuals_SRGB
    Inherits Combobox_Editor_Visuals_GenericAttribute
    Sub New()
        MyBase.New("SRGB", LSLib.LS.AttributeType.Bool)
        Label = "SRGB"
        ComboItems = New List(Of String) From {"False", "True"}
        Reload_Combo()
    End Sub

End Class
Public Class BG3Editor_Visuals_Streaming
    Inherits Combobox_Editor_Visuals_GenericAttribute
    Sub New()
        MyBase.New("Streaming", LSLib.LS.AttributeType.Bool)
        Label = "Streaming"
        ComboItems = New List(Of String) From {"True", "False"}
        Reload_Combo()
    End Sub

End Class
Public Class BG3Editor_Visuals_ShowEquipmentVisuals
    Inherits Combobox_Editor_Visuals_GenericAttribute
    Sub New()
        MyBase.New("ShowEquipmentVisuals", LSLib.LS.AttributeType.Bool)
        Label = "Show equipment"
        ComboItems = New List(Of String) From {"True", "False"}
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
Public Class BG3Editor_ScalarsandVectors_Enabled
    Inherits Combobox_Editor_Visuals_GenericAttribute
    Sub New()
        MyBase.New("Enabled", LSLib.LS.AttributeType.Bool)
        Label = "Enabled"
        ComboItems = New List(Of String) From {"True", "False"}
        Reload_Combo()
    End Sub
End Class
Public Class BG3Editor_ScalarsandVectors_Custom
    Inherits Combobox_Editor_Visuals_GenericAttribute
    Sub New()
        MyBase.New("Custom", LSLib.LS.AttributeType.Bool)
        Label = "Custom"
        ComboItems = New List(Of String) From {"True", "False"}
        Reload_Combo()
    End Sub
End Class
Public Class BG3Editor_ScalarsandVectors_ExportAsPreset
    Inherits Combobox_Editor_Visuals_GenericAttribute
    Sub New()
        MyBase.New("ExportAsPreset", LSLib.LS.AttributeType.Bool)
        Label = "ExportAsPreset"
        ComboItems = New List(Of String) From {"True", "False"}
        Reload_Combo()
    End Sub
End Class
Public Class BG3Editor_ScalarsandVectors_Color
    Inherits Combobox_Editor_Visuals_GenericAttribute
    Sub New()
        MyBase.New("Color", LSLib.LS.AttributeType.Bool)
        Label = "Color"
        ComboItems = New List(Of String) From {"True", "False"}
        Reload_Combo()
    End Sub
    Public Sub SetKey(Key As String)
        Me.Key = Key
    End Sub
End Class
Public Class BG3Editor_ScalarsandVectors_ParameterScalar
    Inherits Combobox_Editor_Visuals_GenericAttribute
    Sub New()
        MyBase.New("Parameter", LSLib.LS.AttributeType.FixedString)
        Label = "Parameter"
        ComboItems = FuncionesHelpers.Characters_Scalars
        Reload_Combo()
    End Sub
    Public Sub SetKey(Key As String)
        Me.Key = Key
    End Sub

End Class






