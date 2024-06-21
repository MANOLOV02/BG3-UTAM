<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Tags_Editor
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
        PictureBox3 = New PictureBox()
        LabelInfoName = New Label()
        LabelInfoDescription = New Label()
        GroupBox3 = New GroupBox()
        LabelTechnical = New Label()
        TabPage1 = New TabPage()
        GroupBox9 = New GroupBox()
        GroupBoxProperties = New GroupBox()
        TextBox2 = New TextBox()
        ButtonDeletePropery = New Button()
        ListBox2 = New ListBox()
        Button4 = New Button()
        GroupBoxCategories = New GroupBox()
        TextBox1 = New TextBox()
        ButtonDeleteCategory = New Button()
        ListBox1 = New ListBox()
        Button2 = New Button()
        BG3Editor_Complex_Localization1 = New BG3Editor_Complex_Localization()
        GroupBoxBasicTemplates = New GroupBox()
        BG3Editor_FlagsandTag_Icon1 = New BG3Editor_FlagsandTag_Icon()
        BG3Editor_FlagsandTag_DisplayDescription1 = New BG3Editor_FlagsandTag_DisplayDescription()
        BG3Editor_FlagsandTag_DisplayName1 = New BG3Editor_FlagsandTag_DisplayName()
        BG3Editor_FlagsAndTag_Description1 = New BG3Editor_FlagsAndTag_Description()
        BG3Editor_FlagsAndTag_Name1 = New BG3Editor_FlagsAndTag_Name()
        BG3Editor_FlagsAndTags_uuid1 = New BG3Editor_FlagsAndTags_UUID()
        TabControl1 = New TabControl()
        TabPageAttributes = New TabPage()
        GroupBoxAttributes = New GroupBox()
        BG3Editor_Complex_Advanced_Attributes1 = New BG3Editor_Complex_Advanced_Attributes()
        SplitContainer1 = New SplitContainer()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox3.SuspendLayout()
        TabPage1.SuspendLayout()
        GroupBox9.SuspendLayout()
        GroupBoxProperties.SuspendLayout()
        GroupBoxCategories.SuspendLayout()
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
        BG3Selector_FlagsandTags1.Selection = BG3_Enum_UTAM_Type.Tag
        BG3Selector_FlagsandTags1.Size = New Size(350, 596)
        BG3Selector_FlagsandTags1.Stat_MustDescend_From = New String() {"None"}
        BG3Selector_FlagsandTags1.TabIndex = 4
        BG3Selector_FlagsandTags1.Template_MustDescend_From = New String() {"None"}
        ' 
        ' PictureBox3
        ' 
        PictureBox3.Location = New Point(6, 17)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(64, 64)
        PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox3.TabIndex = 32
        PictureBox3.TabStop = False
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
        GroupBox3.Controls.Add(PictureBox3)
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
        GroupBox9.Controls.Add(GroupBoxProperties)
        GroupBox9.Controls.Add(GroupBoxCategories)
        GroupBox9.Controls.Add(BG3Editor_Complex_Localization1)
        GroupBox9.Controls.Add(GroupBoxBasicTemplates)
        GroupBox9.Dock = DockStyle.Fill
        GroupBox9.Location = New Point(0, 0)
        GroupBox9.Name = "GroupBox9"
        GroupBox9.Size = New Size(807, 472)
        GroupBox9.TabIndex = 4
        GroupBox9.TabStop = False
        ' 
        ' GroupBoxProperties
        ' 
        GroupBoxProperties.Controls.Add(TextBox2)
        GroupBoxProperties.Controls.Add(ButtonDeletePropery)
        GroupBoxProperties.Controls.Add(ListBox2)
        GroupBoxProperties.Controls.Add(Button4)
        GroupBoxProperties.Location = New Point(419, 180)
        GroupBoxProperties.Name = "GroupBoxProperties"
        GroupBoxProperties.Size = New Size(371, 164)
        GroupBoxProperties.TabIndex = 10
        GroupBoxProperties.TabStop = False
        GroupBoxProperties.Text = "Properties"
        ' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(6, 134)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(279, 23)
        TextBox2.TabIndex = 11
        ' 
        ' ButtonDeletePropery
        ' 
        ButtonDeletePropery.Location = New Point(287, 108)
        ButtonDeletePropery.Name = "ButtonDeletePropery"
        ButtonDeletePropery.Size = New Size(78, 23)
        ButtonDeletePropery.TabIndex = 9
        ButtonDeletePropery.Text = "Delete"
        ButtonDeletePropery.UseVisualStyleBackColor = True
        ' 
        ' ListBox2
        ' 
        ListBox2.FormattingEnabled = True
        ListBox2.ItemHeight = 15
        ListBox2.Location = New Point(6, 22)
        ListBox2.Name = "ListBox2"
        ListBox2.Size = New Size(279, 109)
        ListBox2.TabIndex = 8
        ' 
        ' Button4
        ' 
        Button4.Location = New Point(287, 134)
        Button4.Name = "Button4"
        Button4.Size = New Size(78, 23)
        Button4.TabIndex = 10
        Button4.Text = "Add"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' GroupBoxCategories
        ' 
        GroupBoxCategories.Controls.Add(TextBox1)
        GroupBoxCategories.Controls.Add(ButtonDeleteCategory)
        GroupBoxCategories.Controls.Add(ListBox1)
        GroupBoxCategories.Controls.Add(Button2)
        GroupBoxCategories.Location = New Point(419, 10)
        GroupBoxCategories.Name = "GroupBoxCategories"
        GroupBoxCategories.Size = New Size(371, 164)
        GroupBoxCategories.TabIndex = 9
        GroupBoxCategories.TabStop = False
        GroupBoxCategories.Text = "Categories"
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(6, 134)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(279, 23)
        TextBox1.TabIndex = 11
        ' 
        ' ButtonDeleteCategory
        ' 
        ButtonDeleteCategory.Location = New Point(287, 108)
        ButtonDeleteCategory.Name = "ButtonDeleteCategory"
        ButtonDeleteCategory.Size = New Size(78, 23)
        ButtonDeleteCategory.TabIndex = 9
        ButtonDeleteCategory.Text = "Delete"
        ButtonDeleteCategory.UseVisualStyleBackColor = True
        ' 
        ' ListBox1
        ' 
        ListBox1.FormattingEnabled = True
        ListBox1.ItemHeight = 15
        ListBox1.Location = New Point(6, 22)
        ListBox1.Name = "ListBox1"
        ListBox1.Size = New Size(279, 109)
        ListBox1.TabIndex = 8
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(287, 134)
        Button2.Name = "Button2"
        Button2.Size = New Size(78, 23)
        Button2.TabIndex = 10
        Button2.Text = "Add"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' BG3Editor_Complex_Localization1
        ' 
        BG3Editor_Complex_Localization1.Location = New Point(6, 320)
        BG3Editor_Complex_Localization1.Name = "BG3Editor_Complex_Localization1"
        BG3Editor_Complex_Localization1.Size = New Size(791, 146)
        BG3Editor_Complex_Localization1.TabIndex = 1
        ' 
        ' GroupBoxBasicTemplates
        ' 
        GroupBoxBasicTemplates.Controls.Add(BG3Editor_FlagsandTag_Icon1)
        GroupBoxBasicTemplates.Controls.Add(BG3Editor_FlagsandTag_DisplayDescription1)
        GroupBoxBasicTemplates.Controls.Add(BG3Editor_FlagsandTag_DisplayName1)
        GroupBoxBasicTemplates.Controls.Add(BG3Editor_FlagsAndTag_Description1)
        GroupBoxBasicTemplates.Controls.Add(BG3Editor_FlagsAndTag_Name1)
        GroupBoxBasicTemplates.Controls.Add(BG3Editor_FlagsAndTags_uuid1)
        GroupBoxBasicTemplates.Location = New Point(6, 10)
        GroupBoxBasicTemplates.Name = "GroupBoxBasicTemplates"
        GroupBoxBasicTemplates.Size = New Size(407, 164)
        GroupBoxBasicTemplates.TabIndex = 0
        GroupBoxBasicTemplates.TabStop = False
        GroupBoxBasicTemplates.Text = "Tag"
        ' 
        ' BG3Editor_FlagsandTag_Icon1
        ' 
        BG3Editor_FlagsandTag_Icon1.EditIsConditional = False
        BG3Editor_FlagsandTag_Icon1.Label = "Icon"
        BG3Editor_FlagsandTag_Icon1.Location = New Point(3, 134)
        BG3Editor_FlagsandTag_Icon1.Margin = New Padding(0)
        BG3Editor_FlagsandTag_Icon1.MaximumSize = New Size(3000, 23)
        BG3Editor_FlagsandTag_Icon1.MinimumSize = New Size(100, 23)
        BG3Editor_FlagsandTag_Icon1.Name = "BG3Editor_FlagsandTag_Icon1"
        BG3Editor_FlagsandTag_Icon1.Size = New Size(395, 23)
        BG3Editor_FlagsandTag_Icon1.TabIndex = 7
        ' 
        ' BG3Editor_FlagsandTag_DisplayDescription1
        ' 
        BG3Editor_FlagsandTag_DisplayDescription1.EditIsConditional = False
        BG3Editor_FlagsandTag_DisplayDescription1.Label = "Display descript."
        BG3Editor_FlagsandTag_DisplayDescription1.Location = New Point(3, 111)
        BG3Editor_FlagsandTag_DisplayDescription1.Margin = New Padding(0)
        BG3Editor_FlagsandTag_DisplayDescription1.MaximumSize = New Size(3000, 23)
        BG3Editor_FlagsandTag_DisplayDescription1.MinimumSize = New Size(100, 23)
        BG3Editor_FlagsandTag_DisplayDescription1.Name = "BG3Editor_FlagsandTag_DisplayDescription1"
        BG3Editor_FlagsandTag_DisplayDescription1.Size = New Size(395, 23)
        BG3Editor_FlagsandTag_DisplayDescription1.TabIndex = 6
        ' 
        ' BG3Editor_FlagsandTag_DisplayName1
        ' 
        BG3Editor_FlagsandTag_DisplayName1.EditIsConditional = False
        BG3Editor_FlagsandTag_DisplayName1.Label = "Display name"
        BG3Editor_FlagsandTag_DisplayName1.Location = New Point(3, 88)
        BG3Editor_FlagsandTag_DisplayName1.Margin = New Padding(0)
        BG3Editor_FlagsandTag_DisplayName1.MaximumSize = New Size(3000, 23)
        BG3Editor_FlagsandTag_DisplayName1.MinimumSize = New Size(100, 23)
        BG3Editor_FlagsandTag_DisplayName1.Name = "BG3Editor_FlagsandTag_DisplayName1"
        BG3Editor_FlagsandTag_DisplayName1.Size = New Size(395, 23)
        BG3Editor_FlagsandTag_DisplayName1.TabIndex = 5
        ' 
        ' BG3Editor_FlagsAndTag_Description1
        ' 
        BG3Editor_FlagsAndTag_Description1.EditIsConditional = False
        BG3Editor_FlagsAndTag_Description1.Label = "Description"
        BG3Editor_FlagsAndTag_Description1.Location = New Point(3, 65)
        BG3Editor_FlagsAndTag_Description1.Margin = New Padding(0)
        BG3Editor_FlagsAndTag_Description1.MaximumSize = New Size(3000, 23)
        BG3Editor_FlagsAndTag_Description1.MinimumSize = New Size(100, 23)
        BG3Editor_FlagsAndTag_Description1.Name = "BG3Editor_FlagsAndTag_Description1"
        BG3Editor_FlagsAndTag_Description1.Size = New Size(395, 23)
        BG3Editor_FlagsAndTag_Description1.TabIndex = 4
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
        ' Tags_Editor
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1169, 596)
        Controls.Add(SplitContainer1)
        MinimumSize = New Size(0, 0)
        Name = "Tags_Editor"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Tag editor"
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        GroupBox3.ResumeLayout(False)
        TabPage1.ResumeLayout(False)
        GroupBox9.ResumeLayout(False)
        GroupBoxProperties.ResumeLayout(False)
        GroupBoxProperties.PerformLayout()
        GroupBoxCategories.ResumeLayout(False)
        GroupBoxCategories.PerformLayout()
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
    Protected Friend WithEvents PictureBox3 As PictureBox
    Protected Friend WithEvents LabelInfoName As Label
    Protected Friend WithEvents LabelInfoDescription As Label
    Protected Friend WithEvents BG3Selector_FlagsandTags1 As BG3Selector_FlagsAndTags
    Protected Friend WithEvents GroupBox3 As GroupBox
    Protected Friend WithEvents LabelTechnical As Label
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
    Friend WithEvents BG3Editor_FlagsandTag_Icon1 As BG3Editor_FlagsandTag_Icon
    Friend WithEvents BG3Editor_FlagsandTag_DisplayDescription1 As BG3Editor_FlagsandTag_DisplayDescription
    Friend WithEvents BG3Editor_FlagsandTag_DisplayName1 As BG3Editor_FlagsandTag_DisplayName
    Friend WithEvents BG3Editor_FlagsAndTag_Description1 As BG3Editor_FlagsAndTag_Description
    Friend WithEvents BG3Editor_Complex_Localization1 As BG3Editor_Complex_Localization
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents GroupBoxCategories As GroupBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents ButtonDeleteCategory As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents GroupBoxProperties As GroupBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents ButtonDeletePropery As Button
    Friend WithEvents ListBox2 As ListBox
    Friend WithEvents Button4 As Button
End Class
