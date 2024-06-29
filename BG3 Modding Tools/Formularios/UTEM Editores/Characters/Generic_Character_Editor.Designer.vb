<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Generic_Character_Editor
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
        TabPage5 = New TabPage()
        GroupBox10 = New GroupBox()
        BG3Editor_Complex_Tags1 = New BG3Editor_Complex_Tags()
        TabPage2 = New TabPage()
        GroupBox7 = New GroupBox()
        BG3Editor_Complex_Localization1 = New BG3Editor_Complex_Localization()
        TabPage1 = New TabPage()
        GroupBox9 = New GroupBox()
        GroupBoxInventory = New GroupBox()
        BG3Editor_Template_maxStackAmount1 = New BG3Editor_Template_maxStackAmount()
        BG3Editor_Stats_MaxAmount1 = New BG3Editor_Stats_MaxAmount()
        BG3Editor_Stats_MinAmount1 = New BG3Editor_Stats_MinAmount()
        BG3Editor_Stats_InventoryTab1 = New BG3Editor_Stats_InventoryTab()
        BG3Editor_Stat_Weight1 = New BG3Editor_Stats_Weight()
        GroupBoxTrade = New GroupBox()
        BG3Editor_Stats_ValueRounding1 = New BG3Editor_Stats_ValueRounding()
        BG3Editor_Stats_ValueScale1 = New BG3Editor_Stats_ValueScale()
        BG3Editor_Stats_Valueuuid1 = New BG3Editor_Stats_ValueUUID()
        BG3Editor_Stat_ValueOverride1 = New BG3Editor_Stats_ValueOverride()
        BG3Editor_Stats_ValueLevel1 = New BG3Editor_Stats_ValueLevel()
        GroupBoxBasicTemplates = New GroupBox()
        BG3Editor_Template_StoryItem1 = New BG3Editor_Template_StoryItem()
        BG3Editor_Template_Name1 = New BG3Editor_Template_Name()
        BG3Editor_Template_Type1 = New BG3Editor_Template_Type()
        BG3Editor_Template_Mapkey1 = New BG3Editor_Template_Mapkey()
        BG3Editor_Template_Parent1 = New BG3Editor_Template_ParentId()
        GroupBoxVisuals = New GroupBox()
        BG3Editor_Template_TechnicalDescription1 = New BG3Editor_Template_TechnicalDescription()
        BG3Editor_Template_Description1 = New BG3Editor_Template_Description()
        BG3Editor_Template_DisplayName1 = New BG3Editor_Template_DisplayName()
        BG3Editor_Template_Icon1 = New BG3Editor_Template_Icon()
        BG3Editor_Template_VisualTemplate1 = New BG3Editor_Template_VisualTemplate()
        GroupBoxBasicStats = New GroupBox()
        BG3Editor_Stats_GameSize1 = New BG3Editor_Stats_GameSize()
        BG3Editor_Stats_ObjectCategory1 = New BG3Editor_Stats_ObjectCategory()
        BG3Editor_Stats_MinLevel1 = New BG3Editor_Stats_MinLevel()
        BG3Editor_Template_Stats1 = New BG3Editor_Template_Stats()
        BG3Editor_Stat_Unique1 = New BG3Editor_Stat_Unique()
        BG3Editor_Stat_Rarity1 = New BG3Editor_Stats_Rarity()
        BG3Editor_Stat_Type1 = New BG3Editor_Stats_Type()
        BG3Editor_Stat_Using1 = New BG3Editor_Stat_Using()
        TabControl1 = New TabControl()
        TabPage4 = New TabPage()
        GroupBoxStats = New GroupBox()
        BG3Editor_Complex_Advanced_Stats1 = New BG3Editor_Complex_Advanced_Stats()
        TabPageAttributes = New TabPage()
        GroupBoxAttributes = New GroupBox()
        BG3Editor_Complex_Advanced_Attributes1 = New BG3Editor_Complex_Advanced_Attributes()
        SplitContainer1 = New SplitContainer()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox3.SuspendLayout()
        TabPage5.SuspendLayout()
        GroupBox10.SuspendLayout()
        TabPage2.SuspendLayout()
        GroupBox7.SuspendLayout()
        TabPage1.SuspendLayout()
        GroupBox9.SuspendLayout()
        GroupBoxInventory.SuspendLayout()
        GroupBoxTrade.SuspendLayout()
        GroupBoxBasicTemplates.SuspendLayout()
        GroupBoxVisuals.SuspendLayout()
        GroupBoxBasicStats.SuspendLayout()
        TabControl1.SuspendLayout()
        TabPage4.SuspendLayout()
        GroupBoxStats.SuspendLayout()
        TabPageAttributes.SuspendLayout()
        GroupBoxAttributes.SuspendLayout()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.Panel1.SuspendLayout()
        SplitContainer1.Panel2.SuspendLayout()
        SplitContainer1.SuspendLayout()
        SuspendLayout()
        ' 
        ' BG3Selector_Template1
        ' 
        BG3Selector_Template1.Dock = DockStyle.Fill
        BG3Selector_Template1.Location = New Point(0, 0)
        BG3Selector_Template1.Name = "BG3Selector_Template1"
        BG3Selector_Template1.NameField = "Name"
        BG3Selector_Template1.NameType = "Attribute"
        BG3Selector_Template1.Selection = BG3_Enum_UTAM_Type.Character
        BG3Selector_Template1.Size = New Size(350, 596)
        BG3Selector_Template1.Stat_MustDescend_From = New String() {"_Base"}
        BG3Selector_Template1.TabIndex = 4
        BG3Selector_Template1.Template_MustDescend_From = New String() {"None"}
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
        ' TabPage5
        ' 
        TabPage5.Controls.Add(GroupBox10)
        TabPage5.Location = New Point(4, 27)
        TabPage5.Name = "TabPage5"
        TabPage5.Size = New Size(807, 472)
        TabPage5.TabIndex = 4
        TabPage5.Text = "Tags"
        ' 
        ' GroupBox10
        ' 
        GroupBox10.Controls.Add(BG3Editor_Complex_Tags1)
        GroupBox10.Dock = DockStyle.Fill
        GroupBox10.Location = New Point(0, 0)
        GroupBox10.Name = "GroupBox10"
        GroupBox10.Size = New Size(807, 472)
        GroupBox10.TabIndex = 1
        GroupBox10.TabStop = False
        ' 
        ' BG3Editor_Complex_Tags1
        ' 
        BG3Editor_Complex_Tags1.Dock = DockStyle.Fill
        BG3Editor_Complex_Tags1.Location = New Point(3, 19)
        BG3Editor_Complex_Tags1.Name = "BG3Editor_Complex_Tags1"
        BG3Editor_Complex_Tags1.Size = New Size(801, 450)
        BG3Editor_Complex_Tags1.TabIndex = 0
        ' 
        ' TabPage2
        ' 
        TabPage2.Controls.Add(GroupBox7)
        TabPage2.Location = New Point(4, 27)
        TabPage2.Name = "TabPage2"
        TabPage2.Size = New Size(807, 472)
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
        GroupBox7.Size = New Size(807, 472)
        GroupBox7.TabIndex = 1
        GroupBox7.TabStop = False
        ' 
        ' BG3Editor_Complex_Localization1
        ' 
        BG3Editor_Complex_Localization1.Dock = DockStyle.Fill
        BG3Editor_Complex_Localization1.Location = New Point(3, 19)
        BG3Editor_Complex_Localization1.Name = "BG3Editor_Complex_Localization1"
        BG3Editor_Complex_Localization1.Size = New Size(801, 450)
        BG3Editor_Complex_Localization1.TabIndex = 0
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
        GroupBox9.Controls.Add(GroupBoxInventory)
        GroupBox9.Controls.Add(GroupBoxTrade)
        GroupBox9.Controls.Add(GroupBoxBasicTemplates)
        GroupBox9.Controls.Add(GroupBoxVisuals)
        GroupBox9.Controls.Add(GroupBoxBasicStats)
        GroupBox9.Dock = DockStyle.Fill
        GroupBox9.Location = New Point(0, 0)
        GroupBox9.Name = "GroupBox9"
        GroupBox9.Size = New Size(807, 472)
        GroupBox9.TabIndex = 4
        GroupBox9.TabStop = False
        ' 
        ' GroupBoxInventory
        ' 
        GroupBoxInventory.Controls.Add(BG3Editor_Template_maxStackAmount1)
        GroupBoxInventory.Controls.Add(BG3Editor_Stats_MaxAmount1)
        GroupBoxInventory.Controls.Add(BG3Editor_Stats_MinAmount1)
        GroupBoxInventory.Controls.Add(BG3Editor_Stats_InventoryTab1)
        GroupBoxInventory.Controls.Add(BG3Editor_Stat_Weight1)
        GroupBoxInventory.Location = New Point(416, 270)
        GroupBoxInventory.Name = "GroupBoxInventory"
        GroupBoxInventory.Size = New Size(385, 91)
        GroupBoxInventory.TabIndex = 4
        GroupBoxInventory.TabStop = False
        GroupBoxInventory.Text = "Inventory"
        ' 
        ' BG3Editor_Template_maxStackAmount1
        ' 
        BG3Editor_Template_maxStackAmount1.EditorType = BG3_Editor_Type.NumericUpDown
        BG3Editor_Template_maxStackAmount1.Label = "Max stack"
        BG3Editor_Template_maxStackAmount1.Location = New Point(205, 42)
        BG3Editor_Template_maxStackAmount1.Margin = New Padding(0)
        BG3Editor_Template_maxStackAmount1.MaximumSize = New Size(3000, 23)
        BG3Editor_Template_maxStackAmount1.MinimumSize = New Size(100, 23)
        BG3Editor_Template_maxStackAmount1.Name = "BG3Editor_Template_maxStackAmount1"
        BG3Editor_Template_maxStackAmount1.Size = New Size(176, 23)
        BG3Editor_Template_maxStackAmount1.SplitterDistance = 77
        BG3Editor_Template_maxStackAmount1.TabIndex = 8
        ' 
        ' BG3Editor_Stats_MaxAmount1
        ' 
        BG3Editor_Stats_MaxAmount1.EditorType = BG3_Editor_Type.NumericUpDown
        BG3Editor_Stats_MaxAmount1.Label = "Max amount"
        BG3Editor_Stats_MaxAmount1.Location = New Point(205, 65)
        BG3Editor_Stats_MaxAmount1.Margin = New Padding(0)
        BG3Editor_Stats_MaxAmount1.MaximumSize = New Size(3000, 23)
        BG3Editor_Stats_MaxAmount1.MinimumSize = New Size(100, 23)
        BG3Editor_Stats_MaxAmount1.Name = "BG3Editor_Stats_MaxAmount1"
        BG3Editor_Stats_MaxAmount1.Size = New Size(176, 23)
        BG3Editor_Stats_MaxAmount1.SplitterDistance = 77
        BG3Editor_Stats_MaxAmount1.TabIndex = 7
        ' 
        ' BG3Editor_Stats_MinAmount1
        ' 
        BG3Editor_Stats_MinAmount1.EditorType = BG3_Editor_Type.NumericUpDown
        BG3Editor_Stats_MinAmount1.Label = "Min amount"
        BG3Editor_Stats_MinAmount1.Location = New Point(3, 65)
        BG3Editor_Stats_MinAmount1.Margin = New Padding(0)
        BG3Editor_Stats_MinAmount1.MaximumSize = New Size(3000, 23)
        BG3Editor_Stats_MinAmount1.MinimumSize = New Size(100, 23)
        BG3Editor_Stats_MinAmount1.Name = "BG3Editor_Stats_MinAmount1"
        BG3Editor_Stats_MinAmount1.Size = New Size(199, 23)
        BG3Editor_Stats_MinAmount1.TabIndex = 6
        ' 
        ' BG3Editor_Stats_InventoryTab1
        ' 
        BG3Editor_Stats_InventoryTab1.EditorType = BG3_Editor_Type.Combobox
        BG3Editor_Stats_InventoryTab1.Label = "InventoryTab"
        BG3Editor_Stats_InventoryTab1.Location = New Point(3, 19)
        BG3Editor_Stats_InventoryTab1.Margin = New Padding(0)
        BG3Editor_Stats_InventoryTab1.MaximumSize = New Size(3000, 23)
        BG3Editor_Stats_InventoryTab1.MinimumSize = New Size(100, 23)
        BG3Editor_Stats_InventoryTab1.Name = "BG3Editor_Stats_InventoryTab1"
        BG3Editor_Stats_InventoryTab1.Size = New Size(378, 23)
        BG3Editor_Stats_InventoryTab1.TabIndex = 5
        ' 
        ' BG3Editor_Stat_Weight1
        ' 
        BG3Editor_Stat_Weight1.EditorType = BG3_Editor_Type.NumericUpDown
        BG3Editor_Stat_Weight1.Label = "Weight"
        BG3Editor_Stat_Weight1.Location = New Point(3, 42)
        BG3Editor_Stat_Weight1.Margin = New Padding(0)
        BG3Editor_Stat_Weight1.MaximumSize = New Size(2000, 23)
        BG3Editor_Stat_Weight1.MinimumSize = New Size(0, 23)
        BG3Editor_Stat_Weight1.Name = "BG3Editor_Stat_Weight1"
        BG3Editor_Stat_Weight1.Size = New Size(199, 23)
        BG3Editor_Stat_Weight1.SplitterDistance = 100
        BG3Editor_Stat_Weight1.TabIndex = 4
        ' 
        ' GroupBoxTrade
        ' 
        GroupBoxTrade.Controls.Add(BG3Editor_Stats_ValueRounding1)
        GroupBoxTrade.Controls.Add(BG3Editor_Stats_ValueScale1)
        GroupBoxTrade.Controls.Add(BG3Editor_Stats_Valueuuid1)
        GroupBoxTrade.Controls.Add(BG3Editor_Stat_ValueOverride1)
        GroupBoxTrade.Controls.Add(BG3Editor_Stats_ValueLevel1)
        GroupBoxTrade.Location = New Point(416, 367)
        GroupBoxTrade.Name = "GroupBoxTrade"
        GroupBoxTrade.Size = New Size(385, 96)
        GroupBoxTrade.TabIndex = 3
        GroupBoxTrade.TabStop = False
        GroupBoxTrade.Text = "Trade"
        ' 
        ' BG3Editor_Stats_ValueRounding1
        ' 
        BG3Editor_Stats_ValueRounding1.EditorType = BG3_Editor_Type.Combobox
        BG3Editor_Stats_ValueRounding1.Label = "Rounding"
        BG3Editor_Stats_ValueRounding1.Location = New Point(205, 65)
        BG3Editor_Stats_ValueRounding1.Margin = New Padding(0)
        BG3Editor_Stats_ValueRounding1.MaximumSize = New Size(3000, 23)
        BG3Editor_Stats_ValueRounding1.MinimumSize = New Size(100, 23)
        BG3Editor_Stats_ValueRounding1.Name = "BG3Editor_Stats_ValueRounding1"
        BG3Editor_Stats_ValueRounding1.Size = New Size(176, 23)
        BG3Editor_Stats_ValueRounding1.SplitterDistance = 77
        BG3Editor_Stats_ValueRounding1.TabIndex = 3
        ' 
        ' BG3Editor_Stats_ValueScale1
        ' 
        BG3Editor_Stats_ValueScale1.EditorType = BG3_Editor_Type.NumericUpDown
        BG3Editor_Stats_ValueScale1.Label = "Value scale"
        BG3Editor_Stats_ValueScale1.Location = New Point(3, 42)
        BG3Editor_Stats_ValueScale1.Margin = New Padding(0)
        BG3Editor_Stats_ValueScale1.MaximumSize = New Size(3000, 23)
        BG3Editor_Stats_ValueScale1.MinimumSize = New Size(100, 23)
        BG3Editor_Stats_ValueScale1.Name = "BG3Editor_Stats_ValueScale1"
        BG3Editor_Stats_ValueScale1.Size = New Size(199, 23)
        BG3Editor_Stats_ValueScale1.TabIndex = 2
        ' 
        ' BG3Editor_Stats_Valueuuid1
        ' 
        BG3Editor_Stats_Valueuuid1.DropIcon = True
        BG3Editor_Stats_Valueuuid1.Label = "Value UUID"
        BG3Editor_Stats_Valueuuid1.Location = New Point(3, 19)
        BG3Editor_Stats_Valueuuid1.Margin = New Padding(0)
        BG3Editor_Stats_Valueuuid1.MaximumSize = New Size(3000, 23)
        BG3Editor_Stats_Valueuuid1.MinimumSize = New Size(100, 23)
        BG3Editor_Stats_Valueuuid1.Name = "BG3Editor_Stats_Valueuuid1"
        BG3Editor_Stats_Valueuuid1.ReadOnly = True
        BG3Editor_Stats_Valueuuid1.Size = New Size(378, 23)
        BG3Editor_Stats_Valueuuid1.SplitterDistance = 80
        BG3Editor_Stats_Valueuuid1.TabIndex = 1
        ' 
        ' BG3Editor_Stat_ValueOverride1
        ' 
        BG3Editor_Stat_ValueOverride1.EditorType = BG3_Editor_Type.NumericUpDown
        BG3Editor_Stat_ValueOverride1.Label = "Value override"
        BG3Editor_Stat_ValueOverride1.Location = New Point(3, 65)
        BG3Editor_Stat_ValueOverride1.Margin = New Padding(0)
        BG3Editor_Stat_ValueOverride1.MaximumSize = New Size(2000, 23)
        BG3Editor_Stat_ValueOverride1.MinimumSize = New Size(0, 23)
        BG3Editor_Stat_ValueOverride1.Name = "BG3Editor_Stat_ValueOverride1"
        BG3Editor_Stat_ValueOverride1.Size = New Size(199, 23)
        BG3Editor_Stat_ValueOverride1.SplitterDistance = 100
        BG3Editor_Stat_ValueOverride1.TabIndex = 5
        ' 
        ' BG3Editor_Stats_ValueLevel1
        ' 
        BG3Editor_Stats_ValueLevel1.EditorType = BG3_Editor_Type.NumericUpDown
        BG3Editor_Stats_ValueLevel1.Label = "Value level"
        BG3Editor_Stats_ValueLevel1.Location = New Point(205, 42)
        BG3Editor_Stats_ValueLevel1.Margin = New Padding(0)
        BG3Editor_Stats_ValueLevel1.MaximumSize = New Size(3000, 23)
        BG3Editor_Stats_ValueLevel1.MinimumSize = New Size(100, 23)
        BG3Editor_Stats_ValueLevel1.Name = "BG3Editor_Stats_ValueLevel1"
        BG3Editor_Stats_ValueLevel1.Size = New Size(176, 23)
        BG3Editor_Stats_ValueLevel1.SplitterDistance = 77
        BG3Editor_Stats_ValueLevel1.TabIndex = 0
        ' 
        ' GroupBoxBasicTemplates
        ' 
        GroupBoxBasicTemplates.Controls.Add(BG3Editor_Template_StoryItem1)
        GroupBoxBasicTemplates.Controls.Add(BG3Editor_Template_Name1)
        GroupBoxBasicTemplates.Controls.Add(BG3Editor_Template_Type1)
        GroupBoxBasicTemplates.Controls.Add(BG3Editor_Template_Mapkey1)
        GroupBoxBasicTemplates.Controls.Add(BG3Editor_Template_Parent1)
        GroupBoxBasicTemplates.Location = New Point(6, 10)
        GroupBoxBasicTemplates.Name = "GroupBoxBasicTemplates"
        GroupBoxBasicTemplates.Size = New Size(404, 145)
        GroupBoxBasicTemplates.TabIndex = 0
        GroupBoxBasicTemplates.TabStop = False
        GroupBoxBasicTemplates.Text = "Template"
        ' 
        ' BG3Editor_Template_StoryItem1
        ' 
        BG3Editor_Template_StoryItem1.EditIsConditional = False
        BG3Editor_Template_StoryItem1.EditorType = BG3_Editor_Type.Combobox
        BG3Editor_Template_StoryItem1.Label = "Story item"
        BG3Editor_Template_StoryItem1.Location = New Point(244, 88)
        BG3Editor_Template_StoryItem1.Margin = New Padding(0)
        BG3Editor_Template_StoryItem1.MaximumSize = New Size(3000, 23)
        BG3Editor_Template_StoryItem1.MinimumSize = New Size(100, 23)
        BG3Editor_Template_StoryItem1.Name = "BG3Editor_Template_StoryItem1"
        BG3Editor_Template_StoryItem1.ShowConditional = False
        BG3Editor_Template_StoryItem1.Size = New Size(154, 23)
        BG3Editor_Template_StoryItem1.SplitterDistance = 77
        BG3Editor_Template_StoryItem1.TabIndex = 5
        ' 
        ' BG3Editor_Template_Name1
        ' 
        BG3Editor_Template_Name1.AllowDrop = True
        BG3Editor_Template_Name1.EditIsConditional = False
        BG3Editor_Template_Name1.Label = "Name"
        BG3Editor_Template_Name1.Location = New Point(3, 19)
        BG3Editor_Template_Name1.Margin = New Padding(0)
        BG3Editor_Template_Name1.MaximumSize = New Size(2000, 23)
        BG3Editor_Template_Name1.MinimumSize = New Size(0, 23)
        BG3Editor_Template_Name1.Name = "BG3Editor_Template_Name1"
        BG3Editor_Template_Name1.Size = New Size(395, 23)
        BG3Editor_Template_Name1.SplitterDistance = 100
        BG3Editor_Template_Name1.TabIndex = 0
        ' 
        ' BG3Editor_Template_Type1
        ' 
        BG3Editor_Template_Type1.AllowEdit = False
        BG3Editor_Template_Type1.EditIsConditional = False
        BG3Editor_Template_Type1.EditorType = BG3_Editor_Type.Combobox
        BG3Editor_Template_Type1.Label = "Type"
        BG3Editor_Template_Type1.Location = New Point(3, 88)
        BG3Editor_Template_Type1.Margin = New Padding(0)
        BG3Editor_Template_Type1.MaximumSize = New Size(2000, 23)
        BG3Editor_Template_Type1.MinimumSize = New Size(0, 23)
        BG3Editor_Template_Type1.Name = "BG3Editor_Template_Type1"
        BG3Editor_Template_Type1.Size = New Size(238, 23)
        BG3Editor_Template_Type1.SplitterDistance = 100
        BG3Editor_Template_Type1.TabIndex = 3
        ' 
        ' BG3Editor_Template_Mapkey1
        ' 
        BG3Editor_Template_Mapkey1.AllowDrop = True
        BG3Editor_Template_Mapkey1.AllowEdit = False
        BG3Editor_Template_Mapkey1.EditIsConditional = False
        BG3Editor_Template_Mapkey1.Label = "Mapkey"
        BG3Editor_Template_Mapkey1.Location = New Point(3, 42)
        BG3Editor_Template_Mapkey1.Margin = New Padding(0)
        BG3Editor_Template_Mapkey1.MaximumSize = New Size(2000, 23)
        BG3Editor_Template_Mapkey1.MinimumSize = New Size(0, 23)
        BG3Editor_Template_Mapkey1.Name = "BG3Editor_Template_Mapkey1"
        BG3Editor_Template_Mapkey1.Size = New Size(395, 23)
        BG3Editor_Template_Mapkey1.SplitterDistance = 100
        BG3Editor_Template_Mapkey1.TabIndex = 1
        ' 
        ' BG3Editor_Template_Parent1
        ' 
        BG3Editor_Template_Parent1.AllowDrop = True
        BG3Editor_Template_Parent1.DropIcon = True
        BG3Editor_Template_Parent1.EditIsConditional = False
        BG3Editor_Template_Parent1.Label = "Parent Id"
        BG3Editor_Template_Parent1.Location = New Point(3, 65)
        BG3Editor_Template_Parent1.Margin = New Padding(0)
        BG3Editor_Template_Parent1.MaximumSize = New Size(2000, 23)
        BG3Editor_Template_Parent1.MinimumSize = New Size(0, 23)
        BG3Editor_Template_Parent1.MustDescendFrom = New String() {""}
        BG3Editor_Template_Parent1.Name = "BG3Editor_Template_Parent1"
        BG3Editor_Template_Parent1.ReadOnly = True
        BG3Editor_Template_Parent1.Size = New Size(395, 23)
        BG3Editor_Template_Parent1.SplitterDistance = 80
        BG3Editor_Template_Parent1.TabIndex = 2
        ' 
        ' GroupBoxVisuals
        ' 
        GroupBoxVisuals.Controls.Add(BG3Editor_Template_TechnicalDescription1)
        GroupBoxVisuals.Controls.Add(BG3Editor_Template_Description1)
        GroupBoxVisuals.Controls.Add(BG3Editor_Template_DisplayName1)
        GroupBoxVisuals.Controls.Add(BG3Editor_Template_Icon1)
        GroupBoxVisuals.Controls.Add(BG3Editor_Template_VisualTemplate1)
        GroupBoxVisuals.Location = New Point(6, 159)
        GroupBoxVisuals.Name = "GroupBoxVisuals"
        GroupBoxVisuals.Size = New Size(404, 142)
        GroupBoxVisuals.TabIndex = 1
        GroupBoxVisuals.TabStop = False
        GroupBoxVisuals.Text = "Visuals"
        ' 
        ' BG3Editor_Template_TechnicalDescription1
        ' 
        BG3Editor_Template_TechnicalDescription1.Label = "Technical"
        BG3Editor_Template_TechnicalDescription1.Location = New Point(3, 65)
        BG3Editor_Template_TechnicalDescription1.Margin = New Padding(0)
        BG3Editor_Template_TechnicalDescription1.MaximumSize = New Size(2000, 23)
        BG3Editor_Template_TechnicalDescription1.MinimumSize = New Size(0, 23)
        BG3Editor_Template_TechnicalDescription1.Name = "BG3Editor_Template_TechnicalDescription1"
        BG3Editor_Template_TechnicalDescription1.Size = New Size(395, 23)
        BG3Editor_Template_TechnicalDescription1.SplitterDistance = 100
        BG3Editor_Template_TechnicalDescription1.TabIndex = 2
        ' 
        ' BG3Editor_Template_Description1
        ' 
        BG3Editor_Template_Description1.Label = "Description"
        BG3Editor_Template_Description1.Location = New Point(3, 42)
        BG3Editor_Template_Description1.Margin = New Padding(0)
        BG3Editor_Template_Description1.MaximumSize = New Size(2000, 23)
        BG3Editor_Template_Description1.MinimumSize = New Size(0, 23)
        BG3Editor_Template_Description1.Name = "BG3Editor_Template_Description1"
        BG3Editor_Template_Description1.Size = New Size(395, 23)
        BG3Editor_Template_Description1.SplitterDistance = 100
        BG3Editor_Template_Description1.TabIndex = 1
        ' 
        ' BG3Editor_Template_DisplayName1
        ' 
        BG3Editor_Template_DisplayName1.Label = "Display name"
        BG3Editor_Template_DisplayName1.Location = New Point(3, 19)
        BG3Editor_Template_DisplayName1.Margin = New Padding(0)
        BG3Editor_Template_DisplayName1.MaximumSize = New Size(2000, 23)
        BG3Editor_Template_DisplayName1.MinimumSize = New Size(0, 23)
        BG3Editor_Template_DisplayName1.Name = "BG3Editor_Template_DisplayName1"
        BG3Editor_Template_DisplayName1.Size = New Size(395, 23)
        BG3Editor_Template_DisplayName1.SplitterDistance = 100
        BG3Editor_Template_DisplayName1.TabIndex = 0
        ' 
        ' BG3Editor_Template_Icon1
        ' 
        BG3Editor_Template_Icon1.AllowDrop = True
        BG3Editor_Template_Icon1.DropIcon = True
        BG3Editor_Template_Icon1.Label = "Icon"
        BG3Editor_Template_Icon1.Location = New Point(3, 88)
        BG3Editor_Template_Icon1.Margin = New Padding(0)
        BG3Editor_Template_Icon1.MaximumSize = New Size(2000, 23)
        BG3Editor_Template_Icon1.MinimumSize = New Size(0, 23)
        BG3Editor_Template_Icon1.Name = "BG3Editor_Template_Icon1"
        BG3Editor_Template_Icon1.Size = New Size(395, 23)
        BG3Editor_Template_Icon1.SplitterDistance = 80
        BG3Editor_Template_Icon1.TabIndex = 3
        ' 
        ' BG3Editor_Template_VisualTemplate1
        ' 
        BG3Editor_Template_VisualTemplate1.AllowDrop = True
        BG3Editor_Template_VisualTemplate1.DropIcon = True
        BG3Editor_Template_VisualTemplate1.Label = "Visual temp."
        BG3Editor_Template_VisualTemplate1.Location = New Point(3, 111)
        BG3Editor_Template_VisualTemplate1.Margin = New Padding(0)
        BG3Editor_Template_VisualTemplate1.MaximumSize = New Size(2000, 23)
        BG3Editor_Template_VisualTemplate1.MinimumSize = New Size(0, 23)
        BG3Editor_Template_VisualTemplate1.Name = "BG3Editor_Template_VisualTemplate1"
        BG3Editor_Template_VisualTemplate1.Size = New Size(395, 23)
        BG3Editor_Template_VisualTemplate1.SplitterDistance = 80
        BG3Editor_Template_VisualTemplate1.TabIndex = 4
        ' 
        ' GroupBoxBasicStats
        ' 
        GroupBoxBasicStats.Controls.Add(BG3Editor_Stats_GameSize1)
        GroupBoxBasicStats.Controls.Add(BG3Editor_Stats_ObjectCategory1)
        GroupBoxBasicStats.Controls.Add(BG3Editor_Stats_MinLevel1)
        GroupBoxBasicStats.Controls.Add(BG3Editor_Template_Stats1)
        GroupBoxBasicStats.Controls.Add(BG3Editor_Stat_Unique1)
        GroupBoxBasicStats.Controls.Add(BG3Editor_Stat_Rarity1)
        GroupBoxBasicStats.Controls.Add(BG3Editor_Stat_Type1)
        GroupBoxBasicStats.Controls.Add(BG3Editor_Stat_Using1)
        GroupBoxBasicStats.Location = New Point(6, 302)
        GroupBoxBasicStats.Name = "GroupBoxBasicStats"
        GroupBoxBasicStats.Size = New Size(404, 161)
        GroupBoxBasicStats.TabIndex = 2
        GroupBoxBasicStats.TabStop = False
        GroupBoxBasicStats.Text = "Stat attributes"
        ' 
        ' BG3Editor_Stats_GameSize1
        ' 
        BG3Editor_Stats_GameSize1.EditorType = BG3_Editor_Type.Combobox
        BG3Editor_Stats_GameSize1.Label = "Size"
        BG3Editor_Stats_GameSize1.Location = New Point(244, 111)
        BG3Editor_Stats_GameSize1.Margin = New Padding(0)
        BG3Editor_Stats_GameSize1.MaximumSize = New Size(3000, 23)
        BG3Editor_Stats_GameSize1.MinimumSize = New Size(100, 23)
        BG3Editor_Stats_GameSize1.Name = "BG3Editor_Stats_GameSize1"
        BG3Editor_Stats_GameSize1.Size = New Size(154, 23)
        BG3Editor_Stats_GameSize1.SplitterDistance = 57
        BG3Editor_Stats_GameSize1.TabIndex = 9
        ' 
        ' BG3Editor_Stats_ObjectCategory1
        ' 
        BG3Editor_Stats_ObjectCategory1.Label = "Object category"
        BG3Editor_Stats_ObjectCategory1.Location = New Point(3, 134)
        BG3Editor_Stats_ObjectCategory1.Margin = New Padding(0)
        BG3Editor_Stats_ObjectCategory1.MaximumSize = New Size(3000, 23)
        BG3Editor_Stats_ObjectCategory1.MinimumSize = New Size(100, 23)
        BG3Editor_Stats_ObjectCategory1.Name = "BG3Editor_Stats_ObjectCategory1"
        BG3Editor_Stats_ObjectCategory1.Size = New Size(395, 23)
        BG3Editor_Stats_ObjectCategory1.SplitterDistance = 100
        BG3Editor_Stats_ObjectCategory1.TabIndex = 6
        ' 
        ' BG3Editor_Stats_MinLevel1
        ' 
        BG3Editor_Stats_MinLevel1.EditorType = BG3_Editor_Type.NumericUpDown
        BG3Editor_Stats_MinLevel1.Label = "Minimum level"
        BG3Editor_Stats_MinLevel1.Location = New Point(3, 111)
        BG3Editor_Stats_MinLevel1.Margin = New Padding(0)
        BG3Editor_Stats_MinLevel1.MaximumSize = New Size(3000, 23)
        BG3Editor_Stats_MinLevel1.MinimumSize = New Size(100, 23)
        BG3Editor_Stats_MinLevel1.Name = "BG3Editor_Stats_MinLevel1"
        BG3Editor_Stats_MinLevel1.Size = New Size(238, 23)
        BG3Editor_Stats_MinLevel1.TabIndex = 8
        ' 
        ' BG3Editor_Template_Stats1
        ' 
        BG3Editor_Template_Stats1.AllowEdit = False
        BG3Editor_Template_Stats1.EditIsConditional = False
        BG3Editor_Template_Stats1.Label = "Stat name"
        BG3Editor_Template_Stats1.Location = New Point(3, 19)
        BG3Editor_Template_Stats1.Margin = New Padding(0)
        BG3Editor_Template_Stats1.MaximumSize = New Size(2000, 23)
        BG3Editor_Template_Stats1.MinimumSize = New Size(0, 23)
        BG3Editor_Template_Stats1.Name = "BG3Editor_Template_Stats1"
        BG3Editor_Template_Stats1.Size = New Size(395, 23)
        BG3Editor_Template_Stats1.SplitterDistance = 100
        BG3Editor_Template_Stats1.TabIndex = 0
        ' 
        ' BG3Editor_Stat_Unique1
        ' 
        BG3Editor_Stat_Unique1.EditorType = BG3_Editor_Type.Combobox
        BG3Editor_Stat_Unique1.Label = "Unique"
        BG3Editor_Stat_Unique1.Location = New Point(244, 42)
        BG3Editor_Stat_Unique1.Margin = New Padding(0)
        BG3Editor_Stat_Unique1.MaximumSize = New Size(2000, 23)
        BG3Editor_Stat_Unique1.MinimumSize = New Size(0, 23)
        BG3Editor_Stat_Unique1.Name = "BG3Editor_Stat_Unique1"
        BG3Editor_Stat_Unique1.Size = New Size(154, 23)
        BG3Editor_Stat_Unique1.SplitterDistance = 57
        BG3Editor_Stat_Unique1.TabIndex = 6
        ' 
        ' BG3Editor_Stat_Rarity1
        ' 
        BG3Editor_Stat_Rarity1.EditorType = BG3_Editor_Type.Combobox
        BG3Editor_Stat_Rarity1.Label = "Rarity"
        BG3Editor_Stat_Rarity1.Location = New Point(3, 65)
        BG3Editor_Stat_Rarity1.Margin = New Padding(0)
        BG3Editor_Stat_Rarity1.MaximumSize = New Size(2000, 23)
        BG3Editor_Stat_Rarity1.MinimumSize = New Size(0, 23)
        BG3Editor_Stat_Rarity1.Name = "BG3Editor_Stat_Rarity1"
        BG3Editor_Stat_Rarity1.Size = New Size(395, 23)
        BG3Editor_Stat_Rarity1.SplitterDistance = 100
        BG3Editor_Stat_Rarity1.TabIndex = 2
        ' 
        ' BG3Editor_Stat_Type1
        ' 
        BG3Editor_Stat_Type1.AllowEdit = False
        BG3Editor_Stat_Type1.EditIsConditional = False
        BG3Editor_Stat_Type1.EditorType = BG3_Editor_Type.Combobox
        BG3Editor_Stat_Type1.Label = "Stat type"
        BG3Editor_Stat_Type1.Location = New Point(3, 42)
        BG3Editor_Stat_Type1.Margin = New Padding(0)
        BG3Editor_Stat_Type1.MaximumSize = New Size(2000, 23)
        BG3Editor_Stat_Type1.MinimumSize = New Size(0, 23)
        BG3Editor_Stat_Type1.Name = "BG3Editor_Stat_Type1"
        BG3Editor_Stat_Type1.Size = New Size(238, 23)
        BG3Editor_Stat_Type1.SplitterDistance = 100
        BG3Editor_Stat_Type1.TabIndex = 1
        ' 
        ' BG3Editor_Stat_Using1
        ' 
        BG3Editor_Stat_Using1.DropIcon = True
        BG3Editor_Stat_Using1.EditIsConditional = False
        BG3Editor_Stat_Using1.Label = "Using"
        BG3Editor_Stat_Using1.Location = New Point(3, 88)
        BG3Editor_Stat_Using1.Margin = New Padding(0)
        BG3Editor_Stat_Using1.MaximumSize = New Size(2000, 23)
        BG3Editor_Stat_Using1.MinimumSize = New Size(0, 23)
        BG3Editor_Stat_Using1.MustDescendFrom = New String() {"_Base"}
        BG3Editor_Stat_Using1.Name = "BG3Editor_Stat_Using1"
        BG3Editor_Stat_Using1.ReadOnly = True
        BG3Editor_Stat_Using1.Size = New Size(395, 23)
        BG3Editor_Stat_Using1.SplitterDistance = 80
        BG3Editor_Stat_Using1.TabIndex = 3
        ' 
        ' TabControl1
        ' 
        TabControl1.Appearance = TabAppearance.FlatButtons
        TabControl1.Controls.Add(TabPage1)
        TabControl1.Controls.Add(TabPage2)
        TabControl1.Controls.Add(TabPage5)
        TabControl1.Controls.Add(TabPage4)
        TabControl1.Controls.Add(TabPageAttributes)
        TabControl1.Dock = DockStyle.Top
        TabControl1.Location = New Point(0, 0)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(815, 503)
        TabControl1.SizeMode = TabSizeMode.FillToRight
        TabControl1.TabIndex = 31
        ' 
        ' TabPage4
        ' 
        TabPage4.Controls.Add(GroupBoxStats)
        TabPage4.Location = New Point(4, 27)
        TabPage4.Name = "TabPage4"
        TabPage4.Size = New Size(807, 472)
        TabPage4.TabIndex = 5
        TabPage4.Text = "Stats advanced"
        TabPage4.UseVisualStyleBackColor = True
        ' 
        ' GroupBoxStats
        ' 
        GroupBoxStats.Controls.Add(BG3Editor_Complex_Advanced_Stats1)
        GroupBoxStats.Dock = DockStyle.Fill
        GroupBoxStats.Location = New Point(0, 0)
        GroupBoxStats.Name = "GroupBoxStats"
        GroupBoxStats.Size = New Size(807, 472)
        GroupBoxStats.TabIndex = 1
        GroupBoxStats.TabStop = False
        ' 
        ' BG3Editor_Complex_Advanced_Stats1
        ' 
        BG3Editor_Complex_Advanced_Stats1.Dock = DockStyle.Fill
        BG3Editor_Complex_Advanced_Stats1.Location = New Point(3, 19)
        BG3Editor_Complex_Advanced_Stats1.Name = "BG3Editor_Complex_Advanced_Stats1"
        BG3Editor_Complex_Advanced_Stats1.ReadOnly = True
        BG3Editor_Complex_Advanced_Stats1.Size = New Size(801, 450)
        BG3Editor_Complex_Advanced_Stats1.TabIndex = 0
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
        SplitContainer1.Panel1.Controls.Add(BG3Selector_Template1)
        ' 
        ' SplitContainer1.Panel2
        ' 
        SplitContainer1.Panel2.Controls.Add(GroupBox3)
        SplitContainer1.Panel2.Controls.Add(TabControl1)
        SplitContainer1.Size = New Size(1169, 596)
        SplitContainer1.SplitterDistance = 350
        SplitContainer1.TabIndex = 36
        ' 
        ' Generic_Character_Editor
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1169, 596)
        Controls.Add(SplitContainer1)
        MinimumSize = New Size(0, 0)
        Name = "Generic_Character_Editor"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Generic Editor"
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        GroupBox3.ResumeLayout(False)
        TabPage5.ResumeLayout(False)
        GroupBox10.ResumeLayout(False)
        TabPage2.ResumeLayout(False)
        GroupBox7.ResumeLayout(False)
        TabPage1.ResumeLayout(False)
        GroupBox9.ResumeLayout(False)
        GroupBoxInventory.ResumeLayout(False)
        GroupBoxTrade.ResumeLayout(False)
        GroupBoxBasicTemplates.ResumeLayout(False)
        GroupBoxVisuals.ResumeLayout(False)
        GroupBoxBasicStats.ResumeLayout(False)
        TabControl1.ResumeLayout(False)
        TabPage4.ResumeLayout(False)
        GroupBoxStats.ResumeLayout(False)
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
    Protected Friend WithEvents BG3Selector_Template1 As BG3Selector_Template
    Protected Friend WithEvents GroupBox3 As GroupBox
    Protected Friend WithEvents LabelTechnical As Label
    Protected Friend WithEvents TabPage5 As TabPage
    Protected Friend WithEvents GroupBox10 As GroupBox
    Protected Friend WithEvents BG3Editor_Complex_Tags1 As BG3Editor_Complex_Tags
    Protected Friend WithEvents TabPage2 As TabPage
    Protected Friend WithEvents GroupBox7 As GroupBox
    Protected Friend WithEvents BG3Editor_Complex_Localization1 As BG3Editor_Complex_Localization
    Protected Friend WithEvents TabPage1 As TabPage
    Protected Friend WithEvents GroupBox9 As GroupBox
    Protected Friend WithEvents GroupBoxBasicTemplates As GroupBox
    Protected Friend WithEvents BG3Editor_Template_StoryItem1 As BG3Editor_Template_StoryItem
    Protected Friend WithEvents BG3Editor_Template_Name1 As BG3Editor_Template_Name
    Protected Friend WithEvents BG3Editor_Template_Mapkey1 As BG3Editor_Template_Mapkey
    Protected Friend WithEvents BG3Editor_Template_Parent1 As BG3Editor_Template_ParentId
    Protected Friend WithEvents GroupBoxVisuals As GroupBox
    Protected Friend WithEvents BG3Editor_Template_TechnicalDescription1 As BG3Editor_Template_TechnicalDescription
    Protected Friend WithEvents BG3Editor_Template_Description1 As BG3Editor_Template_Description
    Protected Friend WithEvents BG3Editor_Template_DisplayName1 As BG3Editor_Template_DisplayName
    Protected Friend WithEvents BG3Editor_Template_Icon1 As BG3Editor_Template_Icon
    Protected Friend WithEvents BG3Editor_Template_VisualTemplate1 As BG3Editor_Template_VisualTemplate
    Protected Friend WithEvents GroupBoxBasicStats As GroupBox
    Protected Friend WithEvents BG3Editor_Template_Stats1 As BG3Editor_Template_Stats
    Protected Friend WithEvents BG3Editor_Stat_Unique1 As BG3Editor_Stat_Unique
    Protected Friend WithEvents BG3Editor_Stat_ValueOverride1 As BG3Editor_Stats_ValueOverride
    Protected Friend WithEvents BG3Editor_Stat_Rarity1 As BG3Editor_Stats_Rarity
    Protected Friend WithEvents BG3Editor_Stat_Type1 As BG3Editor_Stats_Type
    Protected Friend WithEvents BG3Editor_Stat_Weight1 As BG3Editor_Stats_Weight
    Protected Friend WithEvents BG3Editor_Stat_Using1 As BG3Editor_Stat_Using
    Protected Friend WithEvents TabControl1 As TabControl
    Protected Friend WithEvents BG3Editor_Template_Type1 As BG3Editor_Template_Type
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents BG3Editor_Complex_Advanced_Stats1 As BG3Editor_Complex_Advanced_Stats
    Friend WithEvents GroupBoxTrade As GroupBox
    Friend WithEvents BG3Editor_Stats_ValueRounding1 As BG3Editor_Stats_ValueRounding
    Friend WithEvents BG3Editor_Stats_ValueScale1 As BG3Editor_Stats_ValueScale
    Friend WithEvents BG3Editor_Stats_Valueuuid1 As BG3Editor_Stats_ValueUUID
    Friend WithEvents BG3Editor_Stats_ValueLevel1 As BG3Editor_Stats_ValueLevel
    Friend WithEvents GroupBoxStats As GroupBox
    Friend WithEvents GroupBoxInventory As GroupBox
    Friend WithEvents BG3Editor_Stats_MinLevel1 As BG3Editor_Stats_MinLevel
    Friend WithEvents TabPageAttributes As TabPage
    Friend WithEvents GroupBoxAttributes As GroupBox
    Friend WithEvents BG3Editor_Complex_Advanced_Attributes1 As BG3Editor_Complex_Advanced_Attributes
    Friend WithEvents BG3Editor_Stats_InventoryTab1 As BG3Editor_Stats_InventoryTab
    Friend WithEvents BG3Editor_Stats_ObjectCategory1 As BG3Editor_Stats_ObjectCategory
    Friend WithEvents BG3Editor_Template_maxStackAmount1 As BG3Editor_Template_maxStackAmount
    Friend WithEvents BG3Editor_Stats_MaxAmount1 As BG3Editor_Stats_MaxAmount
    Friend WithEvents BG3Editor_Stats_MinAmount1 As BG3Editor_Stats_MinAmount
    Friend WithEvents BG3Editor_Stats_GameSize1 As BG3Editor_Stats_GameSize
End Class
