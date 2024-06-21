<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ActionResource_Editor
    Inherits ExploraForm_code

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        BG3Selector_FlagsandTags1 = New BG3Selector_FlagsAndTags()
        LabelInfoName = New Label()
        LabelInfoDescription = New Label()
        GroupBox3 = New GroupBox()
        LabelTechnical = New Label()
        TabPage1 = New TabPage()
        GroupBox9 = New GroupBox()
        BG3Editor_Complex_Localization1 = New BG3Editor_Complex_Localization()
        GroupBoxBasicTemplates = New GroupBox()
        BG3Editor_ActionResources_MaxValue1 = New BG3Editor_ActionResources_MaxValue()
        BG3Editor_ActionResources_MaxLevel1 = New BG3Editor_ActionResources_MaxLevel()
        BG3Editor_ActionResources_Dicetype1 = New BG3Editor_ActionResources_Dicetype()
        BG3Editor_FlagsandTag_TranslatedError1 = New BG3Editor_FlagsandTag_TranslatedError()
        BG3Editor_FlagsandTag_TranslatedDescription1 = New BG3Editor_FlagsandTag_TranslatedDescription()
        BG3Editor_FlagsandTag_DisplayName1 = New BG3Editor_FlagsandTag_DisplayName()
        BG3Editor_FlagsAndTag_Name1 = New BG3Editor_FlagsAndTag_Name()
        BG3Editor_FlagsAndTags_uuid1 = New BG3Editor_FlagsAndTags_UUID()
        TabControl1 = New TabControl()
        TabPageAttributes = New TabPage()
        GroupBoxAttributes = New GroupBox()
        BG3Editor_Complex_Advanced_Attributes1 = New BG3Editor_Complex_Advanced_Attributes()
        SplitContainer1 = New SplitContainer()
        BG3Editor_ActionResource_IsHidden1 = New BG3Editor_ActionResource_IsHidden()
        BG3Editor_ActionResource_IsSpellResource1 = New BG3Editor_ActionResource_IsSpellResource()
        BG3Editor_ActionResource_PartyActionResource1 = New BG3Editor_ActionResource_PartyActionResource()
        BG3Editor_ActionResource_ReplenishType1 = New BG3Editor_ActionResource_ReplenishType()
        BG3Editor_ActionResource_ShowOnActionResourcePanel1 = New BG3Editor_ActionResource_ShowOnActionResourcePanel()
        BG3Editor_ActionResource_UpdateSpellPowerLevel1 = New BG3Editor_ActionResource_UpdatesSpellPowerLevel()
        GroupBox3.SuspendLayout()
        TabPage1.SuspendLayout()
        GroupBox9.SuspendLayout()
        GroupBoxBasicTemplates.SuspendLayout()
        TabControl1.SuspendLayout()
        TabPageAttributes.SuspendLayout()
        GroupBoxAttributes.SuspendLayout()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.Panel1.SuspendLayout()
        SplitContainer1.Panel2.SuspendLayout()
        SplitContainer1.SuspendLayout()
        SuspendLayout()
        ' 
        ' BG3Selector_FlagsandTags1
        ' 
        BG3Selector_FlagsandTags1.Dock = DockStyle.Fill
        BG3Selector_FlagsandTags1.Location = New Point(0, 0)
        BG3Selector_FlagsandTags1.Name = "BG3Selector_FlagsandTags1"
        BG3Selector_FlagsandTags1.Selection = BG3_Enum_UTAM_Type.ActionResource
        BG3Selector_FlagsandTags1.Size = New Size(350, 596)
        BG3Selector_FlagsandTags1.Stat_MustDescend_From = New String() {"None"}
        BG3Selector_FlagsandTags1.TabIndex = 4
        BG3Selector_FlagsandTags1.Template_MustDescend_From = New String() {"None"}
        ' 
        ' LabelInfoName
        ' 
        LabelInfoName.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LabelInfoName.AutoEllipsis = True
        LabelInfoName.Location = New Point(76, 19)
        LabelInfoName.Name = "LabelInfoName"
        LabelInfoName.Size = New Size(721, 15)
        LabelInfoName.TabIndex = 33
        LabelInfoName.Text = "Name:"
        ' 
        ' LabelInfoDescription
        ' 
        LabelInfoDescription.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LabelInfoDescription.AutoEllipsis = True
        LabelInfoDescription.Location = New Point(76, 42)
        LabelInfoDescription.Name = "LabelInfoDescription"
        LabelInfoDescription.Size = New Size(721, 15)
        LabelInfoDescription.TabIndex = 34
        LabelInfoDescription.Text = "Description:"
        ' 
        ' GroupBox3
        ' 
        GroupBox3.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        GroupBox3.Controls.Add(LabelTechnical)
        GroupBox3.Controls.Add(LabelInfoDescription)
        GroupBox3.Controls.Add(LabelInfoName)
        GroupBox3.Location = New Point(4, 503)
        GroupBox3.Name = "GroupBox3"
        GroupBox3.Size = New Size(807, 87)
        GroupBox3.TabIndex = 35
        GroupBox3.TabStop = False
        ' 
        ' LabelTechnical
        ' 
        LabelTechnical.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LabelTechnical.AutoEllipsis = True
        LabelTechnical.Location = New Point(76, 65)
        LabelTechnical.Name = "LabelTechnical"
        LabelTechnical.Size = New Size(780, 15)
        LabelTechnical.TabIndex = 35
        LabelTechnical.Text = "Technical:"
        ' 
        ' TabPage1
        ' 
        TabPage1.Controls.Add(GroupBox9)
        TabPage1.Location = New Point(4, 27)
        TabPage1.Name = "TabPage1"
        TabPage1.Size = New Size(807, 472)
        TabPage1.TabIndex = 0
        TabPage1.Text = "Main"
        ' 
        ' GroupBox9
        ' 
        GroupBox9.Controls.Add(BG3Editor_Complex_Localization1)
        GroupBox9.Controls.Add(GroupBoxBasicTemplates)
        GroupBox9.Dock = DockStyle.Fill
        GroupBox9.Location = New Point(0, 0)
        GroupBox9.Name = "GroupBox9"
        GroupBox9.Size = New Size(807, 472)
        GroupBox9.TabIndex = 4
        GroupBox9.TabStop = False
        ' 
        ' BG3Editor_Complex_Localization1
        ' 
        BG3Editor_Complex_Localization1.Location = New Point(6, 273)
        BG3Editor_Complex_Localization1.Name = "BG3Editor_Complex_Localization1"
        BG3Editor_Complex_Localization1.Size = New Size(791, 193)
        BG3Editor_Complex_Localization1.TabIndex = 1
        ' 
        ' GroupBoxBasicTemplates
        ' 
        GroupBoxBasicTemplates.Controls.Add(BG3Editor_ActionResource_UpdateSpellPowerLevel1)
        GroupBoxBasicTemplates.Controls.Add(BG3Editor_ActionResource_ShowOnActionResourcePanel1)
        GroupBoxBasicTemplates.Controls.Add(BG3Editor_ActionResource_ReplenishType1)
        GroupBoxBasicTemplates.Controls.Add(BG3Editor_ActionResource_PartyActionResource1)
        GroupBoxBasicTemplates.Controls.Add(BG3Editor_ActionResource_IsSpellResource1)
        GroupBoxBasicTemplates.Controls.Add(BG3Editor_ActionResource_IsHidden1)
        GroupBoxBasicTemplates.Controls.Add(BG3Editor_ActionResources_MaxValue1)
        GroupBoxBasicTemplates.Controls.Add(BG3Editor_ActionResources_MaxLevel1)
        GroupBoxBasicTemplates.Controls.Add(BG3Editor_ActionResources_Dicetype1)
        GroupBoxBasicTemplates.Controls.Add(BG3Editor_FlagsandTag_TranslatedError1)
        GroupBoxBasicTemplates.Controls.Add(BG3Editor_FlagsandTag_TranslatedDescription1)
        GroupBoxBasicTemplates.Controls.Add(BG3Editor_FlagsandTag_DisplayName1)
        GroupBoxBasicTemplates.Controls.Add(BG3Editor_FlagsAndTag_Name1)
        GroupBoxBasicTemplates.Controls.Add(BG3Editor_FlagsAndTags_uuid1)
        GroupBoxBasicTemplates.Location = New Point(6, 10)
        GroupBoxBasicTemplates.Name = "GroupBoxBasicTemplates"
        GroupBoxBasicTemplates.Size = New Size(407, 257)
        GroupBoxBasicTemplates.TabIndex = 0
        GroupBoxBasicTemplates.TabStop = False
        GroupBoxBasicTemplates.Text = "Tag"
        ' 
        ' BG3Editor_ActionResources_MaxValue1
        ' 
        BG3Editor_ActionResources_MaxValue1.EditIsConditional = False
        BG3Editor_ActionResources_MaxValue1.EditorType = BG3_Editor_Type.NumericUpDown
        BG3Editor_ActionResources_MaxValue1.Label = "Max value"
        BG3Editor_ActionResources_MaxValue1.Location = New Point(213, 134)
        BG3Editor_ActionResources_MaxValue1.Margin = New Padding(0)
        BG3Editor_ActionResources_MaxValue1.MaximumSize = New Size(3000, 23)
        BG3Editor_ActionResources_MaxValue1.MinimumSize = New Size(100, 23)
        BG3Editor_ActionResources_MaxValue1.Name = "BG3Editor_ActionResources_MaxValue1"
        BG3Editor_ActionResources_MaxValue1.Size = New Size(185, 23)
        BG3Editor_ActionResources_MaxValue1.SplitterDistance = 77
        BG3Editor_ActionResources_MaxValue1.TabIndex = 10
        ' 
        ' BG3Editor_ActionResources_MaxLevel1
        ' 
        BG3Editor_ActionResources_MaxLevel1.EditIsConditional = False
        BG3Editor_ActionResources_MaxLevel1.EditorType = BG3_Editor_Type.NumericUpDown
        BG3Editor_ActionResources_MaxLevel1.Label = "Max level"
        BG3Editor_ActionResources_MaxLevel1.Location = New Point(3, 134)
        BG3Editor_ActionResources_MaxLevel1.Margin = New Padding(0)
        BG3Editor_ActionResources_MaxLevel1.MaximumSize = New Size(3000, 23)
        BG3Editor_ActionResources_MaxLevel1.MinimumSize = New Size(100, 23)
        BG3Editor_ActionResources_MaxLevel1.Name = "BG3Editor_ActionResources_MaxLevel1"
        BG3Editor_ActionResources_MaxLevel1.Size = New Size(209, 23)
        BG3Editor_ActionResources_MaxLevel1.TabIndex = 9
        ' 
        ' BG3Editor_ActionResources_Dicetype1
        ' 
        BG3Editor_ActionResources_Dicetype1.EditIsConditional = False
        BG3Editor_ActionResources_Dicetype1.EditorType = BG3_Editor_Type.NumericUpDown
        BG3Editor_ActionResources_Dicetype1.Label = "Dice type"
        BG3Editor_ActionResources_Dicetype1.Location = New Point(4, 227)
        BG3Editor_ActionResources_Dicetype1.Margin = New Padding(0)
        BG3Editor_ActionResources_Dicetype1.MaximumSize = New Size(3000, 23)
        BG3Editor_ActionResources_Dicetype1.MinimumSize = New Size(100, 23)
        BG3Editor_ActionResources_Dicetype1.Name = "BG3Editor_ActionResources_Dicetype1"
        BG3Editor_ActionResources_Dicetype1.Size = New Size(209, 23)
        BG3Editor_ActionResources_Dicetype1.TabIndex = 8
        ' 
        ' BG3Editor_FlagsandTag_TranslatedError1
        ' 
        BG3Editor_FlagsandTag_TranslatedError1.EditIsConditional = False
        BG3Editor_FlagsandTag_TranslatedError1.Label = "Error description"
        BG3Editor_FlagsandTag_TranslatedError1.Location = New Point(3, 111)
        BG3Editor_FlagsandTag_TranslatedError1.Margin = New Padding(0)
        BG3Editor_FlagsandTag_TranslatedError1.MaximumSize = New Size(3000, 23)
        BG3Editor_FlagsandTag_TranslatedError1.MinimumSize = New Size(100, 23)
        BG3Editor_FlagsandTag_TranslatedError1.Name = "BG3Editor_FlagsandTag_TranslatedError1"
        BG3Editor_FlagsandTag_TranslatedError1.Size = New Size(395, 23)
        BG3Editor_FlagsandTag_TranslatedError1.TabIndex = 7
        ' 
        ' BG3Editor_FlagsandTag_TranslatedDescription1
        ' 
        BG3Editor_FlagsandTag_TranslatedDescription1.EditIsConditional = False
        BG3Editor_FlagsandTag_TranslatedDescription1.Label = "Description"
        BG3Editor_FlagsandTag_TranslatedDescription1.Location = New Point(3, 88)
        BG3Editor_FlagsandTag_TranslatedDescription1.Margin = New Padding(0)
        BG3Editor_FlagsandTag_TranslatedDescription1.MaximumSize = New Size(3000, 23)
        BG3Editor_FlagsandTag_TranslatedDescription1.MinimumSize = New Size(100, 23)
        BG3Editor_FlagsandTag_TranslatedDescription1.Name = "BG3Editor_FlagsandTag_TranslatedDescription1"
        BG3Editor_FlagsandTag_TranslatedDescription1.Size = New Size(395, 23)
        BG3Editor_FlagsandTag_TranslatedDescription1.TabIndex = 6
        ' 
        ' BG3Editor_FlagsandTag_DisplayName1
        ' 
        BG3Editor_FlagsandTag_DisplayName1.EditIsConditional = False
        BG3Editor_FlagsandTag_DisplayName1.Label = "Display name"
        BG3Editor_FlagsandTag_DisplayName1.Location = New Point(3, 65)
        BG3Editor_FlagsandTag_DisplayName1.Margin = New Padding(0)
        BG3Editor_FlagsandTag_DisplayName1.MaximumSize = New Size(3000, 23)
        BG3Editor_FlagsandTag_DisplayName1.MinimumSize = New Size(100, 23)
        BG3Editor_FlagsandTag_DisplayName1.Name = "BG3Editor_FlagsandTag_DisplayName1"
        BG3Editor_FlagsandTag_DisplayName1.Size = New Size(395, 23)
        BG3Editor_FlagsandTag_DisplayName1.TabIndex = 5
        ' 
        ' BG3Editor_FlagsAndTag_Name1
        ' 
        BG3Editor_FlagsAndTag_Name1.EditIsConditional = False
        BG3Editor_FlagsAndTag_Name1.Label = "Name"
        BG3Editor_FlagsAndTag_Name1.Location = New Point(3, 19)
        BG3Editor_FlagsAndTag_Name1.Margin = New Padding(0)
        BG3Editor_FlagsAndTag_Name1.MaximumSize = New Size(3000, 23)
        BG3Editor_FlagsAndTag_Name1.MinimumSize = New Size(100, 23)
        BG3Editor_FlagsAndTag_Name1.Name = "BG3Editor_FlagsAndTag_Name1"
        BG3Editor_FlagsAndTag_Name1.Size = New Size(395, 23)
        BG3Editor_FlagsAndTag_Name1.TabIndex = 3
        ' 
        ' BG3Editor_FlagsAndTags_uuid1
        ' 
        BG3Editor_FlagsAndTags_uuid1.AllowEdit = False
        BG3Editor_FlagsAndTags_uuid1.EditIsConditional = False
        BG3Editor_FlagsAndTags_uuid1.Label = "UUID"
        BG3Editor_FlagsAndTags_uuid1.Location = New Point(3, 42)
        BG3Editor_FlagsAndTags_uuid1.Margin = New Padding(0)
        BG3Editor_FlagsAndTags_uuid1.MaximumSize = New Size(3000, 23)
        BG3Editor_FlagsAndTags_uuid1.MinimumSize = New Size(100, 23)
        BG3Editor_FlagsAndTags_uuid1.Name = "BG3Editor_FlagsAndTags_uuid1"
        BG3Editor_FlagsAndTags_uuid1.Size = New Size(395, 23)
        BG3Editor_FlagsAndTags_uuid1.TabIndex = 2
        ' 
        ' TabControl1
        ' 
        TabControl1.Appearance = TabAppearance.FlatButtons
        TabControl1.Controls.Add(TabPage1)
        TabControl1.Controls.Add(TabPageAttributes)
        TabControl1.Dock = DockStyle.Top
        TabControl1.Location = New Point(0, 0)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(815, 503)
        TabControl1.SizeMode = TabSizeMode.FillToRight
        TabControl1.TabIndex = 31
        ' 
        ' TabPageAttributes
        ' 
        TabPageAttributes.Controls.Add(GroupBoxAttributes)
        TabPageAttributes.Location = New Point(4, 27)
        TabPageAttributes.Name = "TabPageAttributes"
        TabPageAttributes.Size = New Size(807, 472)
        TabPageAttributes.TabIndex = 6
        TabPageAttributes.Text = "Attributes advanced"
        TabPageAttributes.UseVisualStyleBackColor = True
        ' 
        ' GroupBoxAttributes
        ' 
        GroupBoxAttributes.Controls.Add(BG3Editor_Complex_Advanced_Attributes1)
        GroupBoxAttributes.Dock = DockStyle.Fill
        GroupBoxAttributes.Location = New Point(0, 0)
        GroupBoxAttributes.Margin = New Padding(0)
        GroupBoxAttributes.Name = "GroupBoxAttributes"
        GroupBoxAttributes.Size = New Size(807, 472)
        GroupBoxAttributes.TabIndex = 1
        GroupBoxAttributes.TabStop = False
        ' 
        ' BG3Editor_Complex_Advanced_Attributes1
        ' 
        BG3Editor_Complex_Advanced_Attributes1.Dock = DockStyle.Fill
        BG3Editor_Complex_Advanced_Attributes1.Location = New Point(3, 19)
        BG3Editor_Complex_Advanced_Attributes1.Name = "BG3Editor_Complex_Advanced_Attributes1"
        BG3Editor_Complex_Advanced_Attributes1.Size = New Size(801, 450)
        BG3Editor_Complex_Advanced_Attributes1.TabIndex = 0
        ' 
        ' SplitContainer1
        ' 
        SplitContainer1.Dock = DockStyle.Fill
        SplitContainer1.FixedPanel = FixedPanel.Panel2
        SplitContainer1.IsSplitterFixed = True
        SplitContainer1.Location = New Point(0, 0)
        SplitContainer1.Name = "SplitContainer1"
        ' 
        ' SplitContainer1.Panel1
        ' 
        SplitContainer1.Panel1.Controls.Add(BG3Selector_FlagsandTags1)
        ' 
        ' SplitContainer1.Panel2
        ' 
        SplitContainer1.Panel2.Controls.Add(GroupBox3)
        SplitContainer1.Panel2.Controls.Add(TabControl1)
        SplitContainer1.Size = New Size(1169, 596)
        SplitContainer1.SplitterDistance = 350
        SplitContainer1.TabIndex = 36
        ' 
        ' BG3Editor_ActionResource_IsHidden1
        ' 
        BG3Editor_ActionResource_IsHidden1.EditIsConditional = False
        BG3Editor_ActionResource_IsHidden1.EditorType = BG3_Editor_Type.Combobox
        BG3Editor_ActionResource_IsHidden1.Label = "Hidden"
        BG3Editor_ActionResource_IsHidden1.Location = New Point(213, 181)
        BG3Editor_ActionResource_IsHidden1.Margin = New Padding(0)
        BG3Editor_ActionResource_IsHidden1.MaximumSize = New Size(3000, 23)
        BG3Editor_ActionResource_IsHidden1.MinimumSize = New Size(100, 23)
        BG3Editor_ActionResource_IsHidden1.Name = "BG3Editor_ActionResource_IsHidden1"
        BG3Editor_ActionResource_IsHidden1.Size = New Size(185, 23)
        BG3Editor_ActionResource_IsHidden1.SplitterDistance = 77
        BG3Editor_ActionResource_IsHidden1.TabIndex = 11
        ' 
        ' BG3Editor_ActionResource_IsSpellResource1
        ' 
        BG3Editor_ActionResource_IsSpellResource1.EditIsConditional = False
        BG3Editor_ActionResource_IsSpellResource1.EditorType = BG3_Editor_Type.Combobox
        BG3Editor_ActionResource_IsSpellResource1.Label = "Spell resource"
        BG3Editor_ActionResource_IsSpellResource1.Location = New Point(3, 204)
        BG3Editor_ActionResource_IsSpellResource1.Margin = New Padding(0)
        BG3Editor_ActionResource_IsSpellResource1.MaximumSize = New Size(3000, 23)
        BG3Editor_ActionResource_IsSpellResource1.MinimumSize = New Size(100, 23)
        BG3Editor_ActionResource_IsSpellResource1.Name = "BG3Editor_ActionResource_IsSpellResource1"
        BG3Editor_ActionResource_IsSpellResource1.Size = New Size(209, 23)
        BG3Editor_ActionResource_IsSpellResource1.TabIndex = 12
        ' 
        ' BG3Editor_ActionResource_PartyActionResource1
        ' 
        BG3Editor_ActionResource_PartyActionResource1.EditIsConditional = False
        BG3Editor_ActionResource_PartyActionResource1.EditorType = BG3_Editor_Type.Combobox
        BG3Editor_ActionResource_PartyActionResource1.Label = "Party action"
        BG3Editor_ActionResource_PartyActionResource1.Location = New Point(213, 158)
        BG3Editor_ActionResource_PartyActionResource1.Margin = New Padding(0)
        BG3Editor_ActionResource_PartyActionResource1.MaximumSize = New Size(3000, 23)
        BG3Editor_ActionResource_PartyActionResource1.MinimumSize = New Size(100, 23)
        BG3Editor_ActionResource_PartyActionResource1.Name = "BG3Editor_ActionResource_PartyActionResource1"
        BG3Editor_ActionResource_PartyActionResource1.Size = New Size(185, 23)
        BG3Editor_ActionResource_PartyActionResource1.SplitterDistance = 77
        BG3Editor_ActionResource_PartyActionResource1.TabIndex = 13
        ' 
        ' BG3Editor_ActionResource_ReplenishType1
        ' 
        BG3Editor_ActionResource_ReplenishType1.EditIsConditional = False
        BG3Editor_ActionResource_ReplenishType1.EditorType = BG3_Editor_Type.Combobox
        BG3Editor_ActionResource_ReplenishType1.Label = "Replenish"
        BG3Editor_ActionResource_ReplenishType1.Location = New Point(3, 158)
        BG3Editor_ActionResource_ReplenishType1.Margin = New Padding(0)
        BG3Editor_ActionResource_ReplenishType1.MaximumSize = New Size(3000, 23)
        BG3Editor_ActionResource_ReplenishType1.MinimumSize = New Size(100, 23)
        BG3Editor_ActionResource_ReplenishType1.Name = "BG3Editor_ActionResource_ReplenishType1"
        BG3Editor_ActionResource_ReplenishType1.Size = New Size(210, 23)
        BG3Editor_ActionResource_ReplenishType1.TabIndex = 14
        ' 
        ' BG3Editor_ActionResource_ShowOnActionResourcePanel1
        ' 
        BG3Editor_ActionResource_ShowOnActionResourcePanel1.EditIsConditional = False
        BG3Editor_ActionResource_ShowOnActionResourcePanel1.EditorType = BG3_Editor_Type.Combobox
        BG3Editor_ActionResource_ShowOnActionResourcePanel1.Label = "Show on panel"
        BG3Editor_ActionResource_ShowOnActionResourcePanel1.Location = New Point(4, 181)
        BG3Editor_ActionResource_ShowOnActionResourcePanel1.Margin = New Padding(0)
        BG3Editor_ActionResource_ShowOnActionResourcePanel1.MaximumSize = New Size(3000, 23)
        BG3Editor_ActionResource_ShowOnActionResourcePanel1.MinimumSize = New Size(100, 23)
        BG3Editor_ActionResource_ShowOnActionResourcePanel1.Name = "BG3Editor_ActionResource_ShowOnActionResourcePanel1"
        BG3Editor_ActionResource_ShowOnActionResourcePanel1.Size = New Size(208, 23)
        BG3Editor_ActionResource_ShowOnActionResourcePanel1.SplitterDistance = 100
        BG3Editor_ActionResource_ShowOnActionResourcePanel1.TabIndex = 15
        ' 
        ' BG3Editor_ActionResource_UpdateSpellPowerLevel1
        ' 
        BG3Editor_ActionResource_UpdateSpellPowerLevel1.EditIsConditional = False
        BG3Editor_ActionResource_UpdateSpellPowerLevel1.EditorType = BG3_Editor_Type.Combobox
        BG3Editor_ActionResource_UpdateSpellPowerLevel1.Label = "Update level"
        BG3Editor_ActionResource_UpdateSpellPowerLevel1.Location = New Point(213, 204)
        BG3Editor_ActionResource_UpdateSpellPowerLevel1.Margin = New Padding(0)
        BG3Editor_ActionResource_UpdateSpellPowerLevel1.MaximumSize = New Size(3000, 23)
        BG3Editor_ActionResource_UpdateSpellPowerLevel1.MinimumSize = New Size(100, 23)
        BG3Editor_ActionResource_UpdateSpellPowerLevel1.Name = "BG3Editor_ActionResource_UpdateSpellPowerLevel1"
        BG3Editor_ActionResource_UpdateSpellPowerLevel1.Size = New Size(185, 23)
        BG3Editor_ActionResource_UpdateSpellPowerLevel1.SplitterDistance = 77
        BG3Editor_ActionResource_UpdateSpellPowerLevel1.TabIndex = 16
        ' 
        ' ActionResource_Editor
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1169, 596)
        Controls.Add(SplitContainer1)
        MinimumSize = New Size(0, 0)
        Name = "ActionResource_Editor"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Action resource editor"
        GroupBox3.ResumeLayout(False)
        TabPage1.ResumeLayout(False)
        GroupBox9.ResumeLayout(False)
        GroupBoxBasicTemplates.ResumeLayout(False)
        TabControl1.ResumeLayout(False)
        TabPageAttributes.ResumeLayout(False)
        GroupBoxAttributes.ResumeLayout(False)
        SplitContainer1.Panel1.ResumeLayout(False)
        SplitContainer1.Panel2.ResumeLayout(False)
        CType(SplitContainer1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Protected Friend WithEvents LabelInfoName As Label
    Protected Friend WithEvents LabelInfoDescription As Label
    Protected Friend WithEvents BG3Selector_FlagsandTags1 As BG3Selector_FlagsAndTags
    Protected Friend WithEvents GroupBox3 As GroupBox
    Protected Friend WithEvents TabPage1 As TabPage
    Protected Friend WithEvents GroupBox9 As GroupBox
    Protected Friend WithEvents GroupBoxBasicTemplates As GroupBox
    Protected Friend WithEvents TabControl1 As TabControl
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents TabPageAttributes As TabPage
    Friend WithEvents GroupBoxAttributes As GroupBox
    Friend WithEvents BG3Editor_Complex_Advanced_Attributes1 As BG3Editor_Complex_Advanced_Attributes
    Friend WithEvents BG3Editor_FlagsAndTags_uuid1 As BG3Editor_FlagsAndTags_UUID
    Friend WithEvents BG3Editor_FlagsAndTag_Name1 As BG3Editor_FlagsAndTag_Name
    Friend WithEvents BG3Editor_FlagsandTag_TranslatedDescription1 As BG3Editor_FlagsandTag_TranslatedDescription
    Friend WithEvents BG3Editor_FlagsandTag_DisplayName1 As BG3Editor_FlagsandTag_DisplayName
    Friend WithEvents BG3Editor_Complex_Localization1 As BG3Editor_Complex_Localization
    Friend Protected WithEvents LabelTechnical As Label
    Friend WithEvents BG3Editor_ActionResources_MaxValue1 As BG3Editor_ActionResources_MaxValue
    Friend WithEvents BG3Editor_ActionResources_MaxLevel1 As BG3Editor_ActionResources_MaxLevel
    Friend WithEvents BG3Editor_ActionResources_Dicetype1 As BG3Editor_ActionResources_Dicetype
    Friend WithEvents BG3Editor_FlagsandTag_TranslatedError1 As BG3Editor_FlagsandTag_TranslatedError
    Friend WithEvents BG3Editor_ActionResource_UpdateSpellPowerLevel1 As BG3Editor_ActionResource_UpdatesSpellPowerLevel
    Friend WithEvents BG3Editor_ActionResource_ShowOnActionResourcePanel1 As BG3Editor_ActionResource_ShowOnActionResourcePanel
    Friend WithEvents BG3Editor_ActionResource_ReplenishType1 As BG3Editor_ActionResource_ReplenishType
    Friend WithEvents BG3Editor_ActionResource_PartyActionResource1 As BG3Editor_ActionResource_PartyActionResource
    Friend WithEvents BG3Editor_ActionResource_IsSpellResource1 As BG3Editor_ActionResource_IsSpellResource
    Friend WithEvents BG3Editor_ActionResource_IsHidden1 As BG3Editor_ActionResource_IsHidden
End Class
