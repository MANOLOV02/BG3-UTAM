<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Generic_Editor
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
        BG3Selector_Template1 = New BG3Selector_Template()
        PictureBox3 = New PictureBox()
        LabelInfoName = New Label()
        LabelInfoDescription = New Label()
        GroupBox3 = New GroupBox()
        LabelTechnical = New Label()
        TabPage3 = New TabPage()
        GroupBox8 = New GroupBox()
        BG3Editor_Complex_WorldInjection1 = New BG3Editor_Complex_WorldInjection()
        TabPage5 = New TabPage()
        GroupBox10 = New GroupBox()
        BG3Editor_Complex_Tags1 = New BG3Editor_Complex_Tags()
        TabPage2 = New TabPage()
        GroupBox7 = New GroupBox()
        BG3Editor_Complex_Localization1 = New BG3Editor_Complex_Localization()
        TabPage1 = New TabPage()
        GroupBox9 = New GroupBox()
        BG3Cloner1 = New BG3Cloner()
        GroupBox1 = New GroupBox()
        BG3Editor_Template_StoryItem1 = New BG3Editor_Template_StoryItem()
        BG3Editor_Template_Name1 = New BG3Editor_Template_Name()
        BG3Editor_Template_Type1 = New BG3Editor_Template_Type()
        BG3Editor_Template_Mapkey1 = New BG3Editor_Template_Mapkey()
        BG3Editor_Template_Parent1 = New BG3Editor_Template_ParentId()
        GroupBox2 = New GroupBox()
        BG3Editor_Template_TechnicalDescription1 = New BG3Editor_Template_TechnicalDescription()
        BG3Editor_Template_Description1 = New BG3Editor_Template_Description()
        BG3Editor_Template_DisplayName1 = New BG3Editor_Template_DisplayName()
        BG3Editor_Template_Icon1 = New BG3Editor_Template_Icon()
        BG3Editor_Template_VisualTemplate1 = New BG3Editor_Template_VisualTemplate()
        GroupBox4 = New GroupBox()
        BG3Editor_Template_Stats1 = New BG3Editor_Template_Stats()
        BG3Editor_Stat_Unique1 = New BG3Editor_Stat_Unique()
        BG3Editor_Stat_ValueOverride1 = New BG3Editor_Stat_ValueOverride()
        BG3Editor_Stat_Rarity1 = New BG3Editor_Stat_Rarity()
        BG3Editor_Stat_Type1 = New BG3Editor_Stat_Type()
        BG3Editor_Stat_Weight1 = New BG3Editor_Stat_Weight()
        BG3Editor_Stat_Using1 = New BG3Editor_Stat_Using()
        TabControl1 = New TabControl()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox3.SuspendLayout()
        TabPage3.SuspendLayout()
        GroupBox8.SuspendLayout()
        TabPage5.SuspendLayout()
        GroupBox10.SuspendLayout()
        TabPage2.SuspendLayout()
        GroupBox7.SuspendLayout()
        TabPage1.SuspendLayout()
        GroupBox9.SuspendLayout()
        GroupBox1.SuspendLayout()
        GroupBox2.SuspendLayout()
        GroupBox4.SuspendLayout()
        TabControl1.SuspendLayout()
        SuspendLayout()
        ' 
        ' BG3Selector_Template1
        ' 
        BG3Selector_Template1.IsEditing = False
        BG3Selector_Template1.Location = New Point(2, 4)
        BG3Selector_Template1.Name = "BG3Selector_Template1"
        BG3Selector_Template1.Selection = BG3_Enum_UTAM_Type.Dyes
        BG3Selector_Template1.Size = New Size(265, 593)
        BG3Selector_Template1.TabIndex = 4
        ' 
        ' PictureBox3
        ' 
        PictureBox3.Anchor = AnchorStyles.Top Or AnchorStyles.Right
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
        LabelInfoName.Size = New Size(730, 15)
        LabelInfoName.TabIndex = 33
        LabelInfoName.Text = "Name:"
        ' 
        ' LabelInfoDescription
        ' 
        LabelInfoDescription.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LabelInfoDescription.AutoEllipsis = True
        LabelInfoDescription.Location = New Point(76, 42)
        LabelInfoDescription.Name = "LabelInfoDescription"
        LabelInfoDescription.Size = New Size(730, 15)
        LabelInfoDescription.TabIndex = 34
        LabelInfoDescription.Text = "Description:"
        ' 
        ' GroupBox3
        ' 
        GroupBox3.Controls.Add(LabelTechnical)
        GroupBox3.Controls.Add(PictureBox3)
        GroupBox3.Controls.Add(LabelInfoDescription)
        GroupBox3.Controls.Add(LabelInfoName)
        GroupBox3.Location = New Point(277, 510)
        GroupBox3.Name = "GroupBox3"
        GroupBox3.Size = New Size(816, 87)
        GroupBox3.TabIndex = 35
        GroupBox3.TabStop = False
        ' 
        ' LabelTechnical
        ' 
        LabelTechnical.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LabelTechnical.AutoEllipsis = True
        LabelTechnical.Location = New Point(76, 65)
        LabelTechnical.Name = "LabelTechnical"
        LabelTechnical.Size = New Size(730, 15)
        LabelTechnical.TabIndex = 35
        LabelTechnical.Text = "Technical:"
        ' 
        ' TabPage3
        ' 
        TabPage3.Controls.Add(GroupBox8)
        TabPage3.Location = New Point(4, 27)
        TabPage3.Name = "TabPage3"
        TabPage3.Size = New Size(816, 473)
        TabPage3.TabIndex = 2
        TabPage3.Text = "World Injection"
        ' 
        ' GroupBox8
        ' 
        GroupBox8.Controls.Add(BG3Editor_Complex_WorldInjection1)
        GroupBox8.Dock = DockStyle.Fill
        GroupBox8.Location = New Point(0, 0)
        GroupBox8.Name = "GroupBox8"
        GroupBox8.Size = New Size(816, 473)
        GroupBox8.TabIndex = 1
        GroupBox8.TabStop = False
        ' 
        ' BG3Editor_Complex_WorldInjection1
        ' 
        BG3Editor_Complex_WorldInjection1.Dock = DockStyle.Fill
        BG3Editor_Complex_WorldInjection1.Location = New Point(3, 19)
        BG3Editor_Complex_WorldInjection1.Name = "BG3Editor_Complex_WorldInjection1"
        BG3Editor_Complex_WorldInjection1.Size = New Size(810, 451)
        BG3Editor_Complex_WorldInjection1.TabIndex = 0
        ' 
        ' TabPage5
        ' 
        TabPage5.Controls.Add(GroupBox10)
        TabPage5.Location = New Point(4, 27)
        TabPage5.Name = "TabPage5"
        TabPage5.Size = New Size(816, 473)
        TabPage5.TabIndex = 4
        TabPage5.Text = "Tags"
        ' 
        ' GroupBox10
        ' 
        GroupBox10.Controls.Add(BG3Editor_Complex_Tags1)
        GroupBox10.Dock = DockStyle.Fill
        GroupBox10.Location = New Point(0, 0)
        GroupBox10.Name = "GroupBox10"
        GroupBox10.Size = New Size(816, 473)
        GroupBox10.TabIndex = 1
        GroupBox10.TabStop = False
        ' 
        ' BG3Editor_Complex_Tags1
        ' 
        BG3Editor_Complex_Tags1.Dock = DockStyle.Fill
        BG3Editor_Complex_Tags1.Location = New Point(3, 19)
        BG3Editor_Complex_Tags1.Name = "BG3Editor_Complex_Tags1"
        BG3Editor_Complex_Tags1.Size = New Size(810, 451)
        BG3Editor_Complex_Tags1.TabIndex = 0
        ' 
        ' TabPage2
        ' 
        TabPage2.Controls.Add(GroupBox7)
        TabPage2.Location = New Point(4, 27)
        TabPage2.Name = "TabPage2"
        TabPage2.Size = New Size(816, 473)
        TabPage2.TabIndex = 1
        TabPage2.Text = "Localization"
        ' 
        ' GroupBox7
        ' 
        GroupBox7.Controls.Add(BG3Editor_Complex_Localization1)
        GroupBox7.Dock = DockStyle.Fill
        GroupBox7.Location = New Point(0, 0)
        GroupBox7.Margin = New Padding(0)
        GroupBox7.Name = "GroupBox7"
        GroupBox7.Size = New Size(816, 473)
        GroupBox7.TabIndex = 1
        GroupBox7.TabStop = False
        ' 
        ' BG3Editor_Complex_Localization1
        ' 
        BG3Editor_Complex_Localization1.Dock = DockStyle.Fill
        BG3Editor_Complex_Localization1.Location = New Point(3, 19)
        BG3Editor_Complex_Localization1.Name = "BG3Editor_Complex_Localization1"
        BG3Editor_Complex_Localization1.Size = New Size(810, 451)
        BG3Editor_Complex_Localization1.TabIndex = 0
        ' 
        ' TabPage1
        ' 
        TabPage1.Controls.Add(GroupBox9)
        TabPage1.Location = New Point(4, 27)
        TabPage1.Name = "TabPage1"
        TabPage1.Size = New Size(816, 473)
        TabPage1.TabIndex = 0
        TabPage1.Text = "Main"
        ' 
        ' GroupBox9
        ' 
        GroupBox9.Controls.Add(BG3Cloner1)
        GroupBox9.Controls.Add(GroupBox1)
        GroupBox9.Controls.Add(GroupBox2)
        GroupBox9.Controls.Add(GroupBox4)
        GroupBox9.Dock = DockStyle.Fill
        GroupBox9.Location = New Point(0, 0)
        GroupBox9.Name = "GroupBox9"
        GroupBox9.Size = New Size(816, 473)
        GroupBox9.TabIndex = 4
        GroupBox9.TabStop = False
        ' 
        ' BG3Cloner1
        ' 
        BG3Cloner1.Location = New Point(425, 302)
        BG3Cloner1.Name = "BG3Cloner1"
        BG3Cloner1.Size = New Size(385, 161)
        BG3Cloner1.Stat_MustDescend_From = {""}
        BG3Cloner1.TabIndex = 4
        BG3Cloner1.Template_MustDescend_From = {""}
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(BG3Editor_Template_StoryItem1)
        GroupBox1.Controls.Add(BG3Editor_Template_Name1)
        GroupBox1.Controls.Add(BG3Editor_Template_Type1)
        GroupBox1.Controls.Add(BG3Editor_Template_Mapkey1)
        GroupBox1.Controls.Add(BG3Editor_Template_Parent1)
        GroupBox1.Location = New Point(6, 10)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(404, 145)
        GroupBox1.TabIndex = 0
        GroupBox1.TabStop = False
        GroupBox1.Text = "Template"
        ' 
        ' BG3Editor_Template_StoryItem1
        ' 
        BG3Editor_Template_StoryItem1.EditIsConditional = False
        BG3Editor_Template_StoryItem1.EditorType = BG3_Editor_Type.Combobox
        BG3Editor_Template_StoryItem1.Label = "Story item"
        BG3Editor_Template_StoryItem1.Location = New Point(241, 88)
        BG3Editor_Template_StoryItem1.Margin = New Padding(0)
        BG3Editor_Template_StoryItem1.MaximumSize = New Size(3000, 23)
        BG3Editor_Template_StoryItem1.MinimumSize = New Size(100, 23)
        BG3Editor_Template_StoryItem1.Name = "BG3Editor_Template_StoryItem1"
        BG3Editor_Template_StoryItem1.ShowConditional = False
        BG3Editor_Template_StoryItem1.Size = New Size(157, 23)
        BG3Editor_Template_StoryItem1.SplitterDistance = 80
        BG3Editor_Template_StoryItem1.TabIndex = 5
        ' 
        ' BG3Editor_Template_Name1
        ' 
        BG3Editor_Template_Name1.AllowDrop = True
        BG3Editor_Template_Name1.EditIsConditional = False
        BG3Editor_Template_Name1.Label = "Name"
        BG3Editor_Template_Name1.Location = New Point(6, 19)
        BG3Editor_Template_Name1.Margin = New Padding(0)
        BG3Editor_Template_Name1.MaximumSize = New Size(2000, 23)
        BG3Editor_Template_Name1.MinimumSize = New Size(0, 23)
        BG3Editor_Template_Name1.Name = "BG3Editor_Template_Name1"
        BG3Editor_Template_Name1.Size = New Size(392, 23)
        BG3Editor_Template_Name1.SplitterDistance = 100
        BG3Editor_Template_Name1.TabIndex = 0
        ' 
        ' BG3Editor_Template_Type1
        ' 
        BG3Editor_Template_Type1.AllowEdit = False
        BG3Editor_Template_Type1.EditIsConditional = False
        BG3Editor_Template_Type1.EditorType = BG3_Editor_Type.Combobox
        BG3Editor_Template_Type1.Label = "Type"
        BG3Editor_Template_Type1.Location = New Point(6, 88)
        BG3Editor_Template_Type1.Margin = New Padding(0)
        BG3Editor_Template_Type1.MaximumSize = New Size(2000, 23)
        BG3Editor_Template_Type1.MinimumSize = New Size(0, 23)
        BG3Editor_Template_Type1.Name = "BG3Editor_Template_Type1"
        BG3Editor_Template_Type1.Size = New Size(235, 23)
        BG3Editor_Template_Type1.SplitterDistance = 100
        BG3Editor_Template_Type1.TabIndex = 3
        ' 
        ' BG3Editor_Template_Mapkey1
        ' 
        BG3Editor_Template_Mapkey1.AllowDrop = True
        BG3Editor_Template_Mapkey1.AllowEdit = False
        BG3Editor_Template_Mapkey1.EditIsConditional = False
        BG3Editor_Template_Mapkey1.Label = "Mapkey"
        BG3Editor_Template_Mapkey1.Location = New Point(6, 42)
        BG3Editor_Template_Mapkey1.Margin = New Padding(0)
        BG3Editor_Template_Mapkey1.MaximumSize = New Size(2000, 23)
        BG3Editor_Template_Mapkey1.MinimumSize = New Size(0, 23)
        BG3Editor_Template_Mapkey1.Name = "BG3Editor_Template_Mapkey1"
        BG3Editor_Template_Mapkey1.Size = New Size(392, 23)
        BG3Editor_Template_Mapkey1.SplitterDistance = 100
        BG3Editor_Template_Mapkey1.TabIndex = 1
        ' 
        ' BG3Editor_Template_Parent1
        ' 
        BG3Editor_Template_Parent1.AllowDrop = True
        BG3Editor_Template_Parent1.DropIcon = True
        BG3Editor_Template_Parent1.EditIsConditional = False
        BG3Editor_Template_Parent1.Label = "Parent Id"
        BG3Editor_Template_Parent1.Location = New Point(6, 65)
        BG3Editor_Template_Parent1.Margin = New Padding(0)
        BG3Editor_Template_Parent1.MaximumSize = New Size(2000, 23)
        BG3Editor_Template_Parent1.MinimumSize = New Size(0, 23)
        BG3Editor_Template_Parent1.MustDescendFrom = {""}
        BG3Editor_Template_Parent1.Name = "BG3Editor_Template_Parent1"
        BG3Editor_Template_Parent1.ReadOnly = True
        BG3Editor_Template_Parent1.Size = New Size(392, 23)
        BG3Editor_Template_Parent1.SplitterDistance = 100
        BG3Editor_Template_Parent1.TabIndex = 2
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(BG3Editor_Template_TechnicalDescription1)
        GroupBox2.Controls.Add(BG3Editor_Template_Description1)
        GroupBox2.Controls.Add(BG3Editor_Template_DisplayName1)
        GroupBox2.Controls.Add(BG3Editor_Template_Icon1)
        GroupBox2.Controls.Add(BG3Editor_Template_VisualTemplate1)
        GroupBox2.Location = New Point(6, 159)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(404, 142)
        GroupBox2.TabIndex = 1
        GroupBox2.TabStop = False
        GroupBox2.Text = "Visuals"
        ' 
        ' BG3Editor_Template_TechnicalDescription1
        ' 
        BG3Editor_Template_TechnicalDescription1.Label = "Technical"
        BG3Editor_Template_TechnicalDescription1.Location = New Point(6, 65)
        BG3Editor_Template_TechnicalDescription1.Margin = New Padding(0)
        BG3Editor_Template_TechnicalDescription1.MaximumSize = New Size(2000, 23)
        BG3Editor_Template_TechnicalDescription1.MinimumSize = New Size(0, 23)
        BG3Editor_Template_TechnicalDescription1.Name = "BG3Editor_Template_TechnicalDescription1"
        BG3Editor_Template_TechnicalDescription1.Size = New Size(392, 23)
        BG3Editor_Template_TechnicalDescription1.SplitterDistance = 100
        BG3Editor_Template_TechnicalDescription1.TabIndex = 2
        ' 
        ' BG3Editor_Template_Description1
        ' 
        BG3Editor_Template_Description1.Label = "Description"
        BG3Editor_Template_Description1.Location = New Point(6, 42)
        BG3Editor_Template_Description1.Margin = New Padding(0)
        BG3Editor_Template_Description1.MaximumSize = New Size(2000, 23)
        BG3Editor_Template_Description1.MinimumSize = New Size(0, 23)
        BG3Editor_Template_Description1.Name = "BG3Editor_Template_Description1"
        BG3Editor_Template_Description1.Size = New Size(392, 23)
        BG3Editor_Template_Description1.SplitterDistance = 100
        BG3Editor_Template_Description1.TabIndex = 1
        ' 
        ' BG3Editor_Template_DisplayName1
        ' 
        BG3Editor_Template_DisplayName1.Label = "Display name"
        BG3Editor_Template_DisplayName1.Location = New Point(6, 19)
        BG3Editor_Template_DisplayName1.Margin = New Padding(0)
        BG3Editor_Template_DisplayName1.MaximumSize = New Size(2000, 23)
        BG3Editor_Template_DisplayName1.MinimumSize = New Size(0, 23)
        BG3Editor_Template_DisplayName1.Name = "BG3Editor_Template_DisplayName1"
        BG3Editor_Template_DisplayName1.Size = New Size(392, 23)
        BG3Editor_Template_DisplayName1.SplitterDistance = 100
        BG3Editor_Template_DisplayName1.TabIndex = 0
        ' 
        ' BG3Editor_Template_Icon1
        ' 
        BG3Editor_Template_Icon1.AllowDrop = True
        BG3Editor_Template_Icon1.DropIcon = True
        BG3Editor_Template_Icon1.Label = "Icon"
        BG3Editor_Template_Icon1.Location = New Point(6, 88)
        BG3Editor_Template_Icon1.Margin = New Padding(0)
        BG3Editor_Template_Icon1.MaximumSize = New Size(2000, 23)
        BG3Editor_Template_Icon1.MinimumSize = New Size(0, 23)
        BG3Editor_Template_Icon1.Name = "BG3Editor_Template_Icon1"
        BG3Editor_Template_Icon1.Size = New Size(392, 23)
        BG3Editor_Template_Icon1.SplitterDistance = 100
        BG3Editor_Template_Icon1.TabIndex = 3
        ' 
        ' BG3Editor_Template_VisualTemplate1
        ' 
        BG3Editor_Template_VisualTemplate1.AllowDrop = True
        BG3Editor_Template_VisualTemplate1.DropIcon = True
        BG3Editor_Template_VisualTemplate1.Label = "Visual temp."
        BG3Editor_Template_VisualTemplate1.Location = New Point(6, 111)
        BG3Editor_Template_VisualTemplate1.Margin = New Padding(0)
        BG3Editor_Template_VisualTemplate1.MaximumSize = New Size(2000, 23)
        BG3Editor_Template_VisualTemplate1.MinimumSize = New Size(0, 23)
        BG3Editor_Template_VisualTemplate1.Name = "BG3Editor_Template_VisualTemplate1"
        BG3Editor_Template_VisualTemplate1.Size = New Size(392, 23)
        BG3Editor_Template_VisualTemplate1.SplitterDistance = 100
        BG3Editor_Template_VisualTemplate1.TabIndex = 4
        ' 
        ' GroupBox4
        ' 
        GroupBox4.Controls.Add(BG3Editor_Template_Stats1)
        GroupBox4.Controls.Add(BG3Editor_Stat_Unique1)
        GroupBox4.Controls.Add(BG3Editor_Stat_ValueOverride1)
        GroupBox4.Controls.Add(BG3Editor_Stat_Rarity1)
        GroupBox4.Controls.Add(BG3Editor_Stat_Type1)
        GroupBox4.Controls.Add(BG3Editor_Stat_Weight1)
        GroupBox4.Controls.Add(BG3Editor_Stat_Using1)
        GroupBox4.Location = New Point(6, 302)
        GroupBox4.Name = "GroupBox4"
        GroupBox4.Size = New Size(404, 161)
        GroupBox4.TabIndex = 2
        GroupBox4.TabStop = False
        GroupBox4.Text = "Stat attributes"
        ' 
        ' BG3Editor_Template_Stats1
        ' 
        BG3Editor_Template_Stats1.AllowEdit = False
        BG3Editor_Template_Stats1.EditIsConditional = False
        BG3Editor_Template_Stats1.Label = "Stat name"
        BG3Editor_Template_Stats1.Location = New Point(6, 19)
        BG3Editor_Template_Stats1.Margin = New Padding(0)
        BG3Editor_Template_Stats1.MaximumSize = New Size(2000, 23)
        BG3Editor_Template_Stats1.MinimumSize = New Size(0, 23)
        BG3Editor_Template_Stats1.Name = "BG3Editor_Template_Stats1"
        BG3Editor_Template_Stats1.Size = New Size(392, 23)
        BG3Editor_Template_Stats1.SplitterDistance = 100
        BG3Editor_Template_Stats1.TabIndex = 0
        ' 
        ' BG3Editor_Stat_Unique1
        ' 
        BG3Editor_Stat_Unique1.EditIsConditional = False
        BG3Editor_Stat_Unique1.EditorType = BG3_Editor_Type.Combobox
        BG3Editor_Stat_Unique1.Label = "Unique"
        BG3Editor_Stat_Unique1.Location = New Point(241, 65)
        BG3Editor_Stat_Unique1.Margin = New Padding(0)
        BG3Editor_Stat_Unique1.MaximumSize = New Size(2000, 23)
        BG3Editor_Stat_Unique1.MinimumSize = New Size(0, 23)
        BG3Editor_Stat_Unique1.Name = "BG3Editor_Stat_Unique1"
        BG3Editor_Stat_Unique1.Size = New Size(157, 23)
        BG3Editor_Stat_Unique1.SplitterDistance = 54
        BG3Editor_Stat_Unique1.TabIndex = 6
        ' 
        ' BG3Editor_Stat_ValueOverride1
        ' 
        BG3Editor_Stat_ValueOverride1.EditorType = BG3_Editor_Type.NumericUpDown
        BG3Editor_Stat_ValueOverride1.Label = "Value override"
        BG3Editor_Stat_ValueOverride1.Location = New Point(6, 134)
        BG3Editor_Stat_ValueOverride1.Margin = New Padding(0)
        BG3Editor_Stat_ValueOverride1.MaximumSize = New Size(2000, 23)
        BG3Editor_Stat_ValueOverride1.MinimumSize = New Size(0, 23)
        BG3Editor_Stat_ValueOverride1.Name = "BG3Editor_Stat_ValueOverride1"
        BG3Editor_Stat_ValueOverride1.Size = New Size(235, 23)
        BG3Editor_Stat_ValueOverride1.SplitterDistance = 100
        BG3Editor_Stat_ValueOverride1.TabIndex = 5
        ' 
        ' BG3Editor_Stat_Rarity1
        ' 
        BG3Editor_Stat_Rarity1.EditorType = BG3_Editor_Type.Combobox
        BG3Editor_Stat_Rarity1.Label = "Rarity"
        BG3Editor_Stat_Rarity1.Location = New Point(6, 65)
        BG3Editor_Stat_Rarity1.Margin = New Padding(0)
        BG3Editor_Stat_Rarity1.MaximumSize = New Size(2000, 23)
        BG3Editor_Stat_Rarity1.MinimumSize = New Size(0, 23)
        BG3Editor_Stat_Rarity1.Name = "BG3Editor_Stat_Rarity1"
        BG3Editor_Stat_Rarity1.Size = New Size(235, 23)
        BG3Editor_Stat_Rarity1.SplitterDistance = 100
        BG3Editor_Stat_Rarity1.TabIndex = 2
        ' 
        ' BG3Editor_Stat_Type1
        ' 
        BG3Editor_Stat_Type1.AllowEdit = False
        BG3Editor_Stat_Type1.EditIsConditional = False
        BG3Editor_Stat_Type1.EditorType = BG3_Editor_Type.Combobox
        BG3Editor_Stat_Type1.Label = "Stat type"
        BG3Editor_Stat_Type1.Location = New Point(6, 42)
        BG3Editor_Stat_Type1.Margin = New Padding(0)
        BG3Editor_Stat_Type1.MaximumSize = New Size(2000, 23)
        BG3Editor_Stat_Type1.MinimumSize = New Size(0, 23)
        BG3Editor_Stat_Type1.Name = "BG3Editor_Stat_Type1"
        BG3Editor_Stat_Type1.Size = New Size(392, 23)
        BG3Editor_Stat_Type1.SplitterDistance = 100
        BG3Editor_Stat_Type1.TabIndex = 1
        ' 
        ' BG3Editor_Stat_Weight1
        ' 
        BG3Editor_Stat_Weight1.EditorType = BG3_Editor_Type.NumericUpDown
        BG3Editor_Stat_Weight1.Label = "Weight"
        BG3Editor_Stat_Weight1.Location = New Point(6, 111)
        BG3Editor_Stat_Weight1.Margin = New Padding(0)
        BG3Editor_Stat_Weight1.MaximumSize = New Size(2000, 23)
        BG3Editor_Stat_Weight1.MinimumSize = New Size(0, 23)
        BG3Editor_Stat_Weight1.Name = "BG3Editor_Stat_Weight1"
        BG3Editor_Stat_Weight1.Size = New Size(235, 23)
        BG3Editor_Stat_Weight1.SplitterDistance = 100
        BG3Editor_Stat_Weight1.TabIndex = 4
        ' 
        ' BG3Editor_Stat_Using1
        ' 
        BG3Editor_Stat_Using1.DropIcon = True
        BG3Editor_Stat_Using1.EditIsConditional = False
        BG3Editor_Stat_Using1.Label = "Using"
        BG3Editor_Stat_Using1.Location = New Point(6, 88)
        BG3Editor_Stat_Using1.Margin = New Padding(0)
        BG3Editor_Stat_Using1.MaximumSize = New Size(2000, 23)
        BG3Editor_Stat_Using1.MinimumSize = New Size(0, 23)
        BG3Editor_Stat_Using1.MustDescendFrom = {""}
        BG3Editor_Stat_Using1.Name = "BG3Editor_Stat_Using1"
        BG3Editor_Stat_Using1.ReadOnly = True
        BG3Editor_Stat_Using1.Size = New Size(392, 23)
        BG3Editor_Stat_Using1.SplitterDistance = 100
        BG3Editor_Stat_Using1.TabIndex = 3
        ' 
        ' TabControl1
        ' 
        TabControl1.Appearance = TabAppearance.FlatButtons
        TabControl1.Controls.Add(TabPage1)
        TabControl1.Controls.Add(TabPage2)
        TabControl1.Controls.Add(TabPage5)
        TabControl1.Controls.Add(TabPage3)
        TabControl1.Location = New Point(273, 4)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(824, 504)
        TabControl1.SizeMode = TabSizeMode.Fixed
        TabControl1.TabIndex = 31
        ' 
        ' Generic_Editor
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1100, 601)
        Controls.Add(BG3Selector_Template1)
        Controls.Add(TabControl1)
        Controls.Add(GroupBox3)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Name = "Generic_Editor"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Generic Editor"
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        GroupBox3.ResumeLayout(False)
        TabPage3.ResumeLayout(False)
        GroupBox8.ResumeLayout(False)
        TabPage5.ResumeLayout(False)
        GroupBox10.ResumeLayout(False)
        TabPage2.ResumeLayout(False)
        GroupBox7.ResumeLayout(False)
        TabPage1.ResumeLayout(False)
        GroupBox9.ResumeLayout(False)
        GroupBox1.ResumeLayout(False)
        GroupBox2.ResumeLayout(False)
        GroupBox4.ResumeLayout(False)
        TabControl1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Protected Friend WithEvents PictureBox3 As PictureBox
    Protected Friend WithEvents LabelInfoName As Label
    Protected Friend WithEvents LabelInfoDescription As Label
    Protected Friend WithEvents BG3Selector_Template1 As BG3Selector_Template
    Protected Friend WithEvents GroupBox3 As GroupBox
    Protected Friend WithEvents LabelTechnical As Label
    Protected Friend WithEvents TabPage3 As TabPage
    Protected Friend WithEvents GroupBox8 As GroupBox
    Protected Friend WithEvents BG3Editor_Complex_WorldInjection1 As BG3Editor_Complex_WorldInjection
    Protected Friend WithEvents TabPage5 As TabPage
    Protected Friend WithEvents GroupBox10 As GroupBox
    Protected Friend WithEvents BG3Editor_Complex_Tags1 As BG3Editor_Complex_Tags
    Protected Friend WithEvents TabPage2 As TabPage
    Protected Friend WithEvents GroupBox7 As GroupBox
    Protected Friend WithEvents BG3Editor_Complex_Localization1 As BG3Editor_Complex_Localization
    Protected Friend WithEvents TabPage1 As TabPage
    Protected Friend WithEvents GroupBox9 As GroupBox
    Protected Friend WithEvents BG3Cloner1 As BG3Cloner
    Protected Friend WithEvents GroupBox1 As GroupBox
    Protected Friend WithEvents BG3Editor_Template_StoryItem1 As BG3Editor_Template_StoryItem
    Protected Friend WithEvents BG3Editor_Template_Name1 As BG3Editor_Template_Name
    Protected Friend WithEvents BG3Editor_Template_Mapkey1 As BG3Editor_Template_Mapkey
    Protected Friend WithEvents BG3Editor_Template_Parent1 As BG3Editor_Template_ParentId
    Protected Friend WithEvents GroupBox2 As GroupBox
    Protected Friend WithEvents BG3Editor_Template_TechnicalDescription1 As BG3Editor_Template_TechnicalDescription
    Protected Friend WithEvents BG3Editor_Template_Description1 As BG3Editor_Template_Description
    Protected Friend WithEvents BG3Editor_Template_DisplayName1 As BG3Editor_Template_DisplayName
    Protected Friend WithEvents BG3Editor_Template_Icon1 As BG3Editor_Template_Icon
    Protected Friend WithEvents BG3Editor_Template_VisualTemplate1 As BG3Editor_Template_VisualTemplate
    Protected Friend WithEvents GroupBox4 As GroupBox
    Protected Friend WithEvents BG3Editor_Template_Stats1 As BG3Editor_Template_Stats
    Protected Friend WithEvents BG3Editor_Stat_Unique1 As BG3Editor_Stat_Unique
    Protected Friend WithEvents BG3Editor_Stat_ValueOverride1 As BG3Editor_Stat_ValueOverride
    Protected Friend WithEvents BG3Editor_Stat_Rarity1 As BG3Editor_Stat_Rarity
    Protected Friend WithEvents BG3Editor_Stat_Type1 As BG3Editor_Stat_Type
    Protected Friend WithEvents BG3Editor_Stat_Weight1 As BG3Editor_Stat_Weight
    Protected Friend WithEvents BG3Editor_Stat_Using1 As BG3Editor_Stat_Using
    Protected Friend WithEvents TabControl1 As TabControl
    Friend Protected WithEvents BG3Editor_Template_Type1 As BG3Editor_Template_Type
End Class
