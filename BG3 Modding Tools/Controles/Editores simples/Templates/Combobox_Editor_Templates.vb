Imports System.Collections.Immutable
Imports System.ComponentModel
Imports System.Windows.Forms.Design
Imports LSLib.Granny

Public Class BG3Editor_Template_Type
    Inherits Combobox_Editor_Generic_GenericAttribute
    Sub New()
        MyBase.New("Type", LSLib.LS.AttributeType.FixedString)
        Label = "Template type"
        ComboItems = [Enum].GetNames(GetType(BG3_Enum_Templates_Type)).Order.ToList
        Reload_Combo()
    End Sub
End Class
Public Class BG3Editor_Template_UtamType
    Inherits Combobox_Editor_Generic_GenericAttribute
    Sub New()
        MyBase.New("UTAM_Type", LSLib.LS.AttributeType.FixedString)
        Label = "Utam type"
        ComboItems = [Enum].GetNames(GetType(BG3_Enum_UTAM_Type)).Order.ToList
        Reload_Combo()
    End Sub
End Class
Public Class BG3Editor_Template_UtamGroup
    Inherits Combobox_Editor_Generic_GenericAttribute
    Sub New()
        MyBase.New("UTAM_Group", LSLib.LS.AttributeType.FixedString)
        Label = "Group"
        ComboItems = FuncionesHelpers.UTAM_Groups
        Me.ComboBox1.DropDownStyle = ComboBoxStyle.DropDown
        Me.ComboBox1.AutoCompleteMode = AutoCompleteMode.Suggest
        Me.ComboBox1.AutoCompleteSource = AutoCompleteSource.ListItems
        Reload_Combo()
    End Sub
    Public Sub Update_Groups()
        Reload_Combo()
    End Sub
End Class

