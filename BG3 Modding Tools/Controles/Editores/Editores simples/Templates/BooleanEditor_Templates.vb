Public Class BG3Editor_Template_ContainerAutoAddOnPickup
    Inherits Editor_Template_GenericAttribute
    Sub New()
        MyBase.New("ContainerAutoAddOnPickup", LSLib.LS.AttributeType.Bool)
        Label = "Auto pickup"
        ComboItems = New List(Of String) From {"False", "True"}
        Reload_Combo()
    End Sub

End Class
Public Class BG3Editor_Template_StoryItem
    Inherits Editor_Template_GenericAttribute
    Sub New()
        MyBase.New("StoryItem", LSLib.LS.AttributeType.Bool)
        Label = "Story item"
        ComboItems = New List(Of String) From {"False", "True"}
        Reload_Combo()
    End Sub

End Class

