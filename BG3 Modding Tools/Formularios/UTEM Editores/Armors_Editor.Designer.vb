<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Armors_Editor
    Inherits Generic_Item_Editor

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
        BG3Editor_Stat_Slots_Armor1 = New BG3Editor_Stats_Slots_Armor()
        BG3Editor_Stats_DefaultBoosts1 = New BG3Editor_Stats_DefaultBoosts()
        BG3Editor_Stats_ProficiencyGroup1 = New BG3Editor_Stats_ProficiencyGroup()
        BG3Editor_Stats_ArmorClass1 = New BG3Editor_Stats_ArmorClass()
        BG3Editor_Stats_ArmorClassAbility1 = New BG3Editor_Stats_ArmorClassAbility()
        BG3Editor_Stats_StatusOnEquip1 = New BG3Editor_Stats_StatusOnEquip()
        BG3Editor_Stats_ArmorType1 = New BG3Editor_Stats_ArmorType()
        BG3Editor_Stats_Boosts1 = New BG3Editor_Stats_Boosts()
        BG3Editor_Stats_PassivesOnEquip1 = New BG3Editor_Stats_PassivesOnEquip()
        TabControl2 = New TabControl()
        TabPageArmorsG = New TabPage()
        GroupBoxArmorsG = New GroupBox()
        TabPageArmorsB = New TabPage()
        GroupBoxArmors1 = New GroupBox()
        TabPageArmorsS = New TabPage()
        GroupBoxArmorsS = New GroupBox()
        BG3Editor_Complex_StatusList1 = New BG3Editor_Complex_StatusList()
        TabPageEquipment = New TabPage()
        BG3Editor_Complex_ArmorEquipment1 = New BG3Editor_Complex_ArmorEquipment()
        GroupBoxEquipment = New GroupBox()
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
        GroupBoxBasicTemplates.SuspendLayout()
        GroupBoxVisuals.SuspendLayout()
        GroupBoxBasicStats.SuspendLayout()
        TabControl1.SuspendLayout()
        TabControl2.SuspendLayout()
        TabPageArmorsG.SuspendLayout()
        GroupBoxArmorsG.SuspendLayout()
        TabPageArmorsB.SuspendLayout()
        GroupBoxArmors1.SuspendLayout()
        TabPageArmorsS.SuspendLayout()
        GroupBoxArmorsS.SuspendLayout()
        TabPageEquipment.SuspendLayout()
        GroupBoxEquipment.SuspendLayout()
        SuspendLayout()
        ' 
        ' BG3Selector_Template1
        ' 
        BG3Selector_Template1.CloneLabel = "Drop a Stat or a Template to add from it.  It must descend from armor bases."
        BG3Selector_Template1.Selection = BG3_Enum_UTAM_Type.Armor
        BG3Selector_Template1.Stat_MustDescend_From = New String() {"_Body"}
        BG3Selector_Template1.Template_MustDescend_From = New String() {"a09273ba-6549-4cf9-ba47-615a962baf9f", "303990e3-5546-44a3-9c5a-f9aa1702ad51", "0af630e0-82eb-4b83-baa2-e296f97a7a4e", "77bee355-c1be-4182-bbe9-2279d3c856d6"}
        ' 
        ' GroupBox9
        ' 
        GroupBox9.Controls.Add(TabControl2)
        GroupBox9.Controls.SetChildIndex(GroupBoxBasicStats, 0)
        GroupBox9.Controls.SetChildIndex(GroupBoxVisuals, 0)
        GroupBox9.Controls.SetChildIndex(GroupBoxBasicTemplates, 0)
        GroupBox9.Controls.SetChildIndex(TabControl2, 0)
        ' 
        ' GroupBoxBasicTemplates
        ' 
        GroupBoxBasicTemplates.Controls.Add(BG3Editor_Stat_Slots_Armor1)
        GroupBoxBasicTemplates.Controls.SetChildIndex(BG3Editor_Template_Parent1, 0)
        GroupBoxBasicTemplates.Controls.SetChildIndex(BG3Editor_Template_Mapkey1, 0)
        GroupBoxBasicTemplates.Controls.SetChildIndex(BG3Editor_Template_Type1, 0)
        GroupBoxBasicTemplates.Controls.SetChildIndex(BG3Editor_Template_Name1, 0)
        GroupBoxBasicTemplates.Controls.SetChildIndex(BG3Editor_Template_StoryItem1, 0)
        GroupBoxBasicTemplates.Controls.SetChildIndex(BG3Editor_Stat_Slots_Armor1, 0)
        ' 
        ' BG3Editor_Template_Name1
        ' 
        BG3Editor_Template_Name1.EditorType = BG3_Editor_Type.Textbox
        ' 
        ' BG3Editor_Template_Mapkey1
        ' 
        BG3Editor_Template_Mapkey1.EditorType = BG3_Editor_Type.Textbox
        ' 
        ' BG3Editor_Template_Parent1
        ' 
        BG3Editor_Template_Parent1.EditorType = BG3_Editor_Type.Textbox
        BG3Editor_Template_Parent1.MustDescendFrom = New String() {"a09273ba-6549-4cf9-ba47-615a962baf9f", "303990e3-5546-44a3-9c5a-f9aa1702ad51", "0af630e0-82eb-4b83-baa2-e296f97a7a4e", "77bee355-c1be-4182-bbe9-2279d3c856d6"}
        ' 
        ' BG3Editor_Template_TechnicalDescription1
        ' 
        BG3Editor_Template_TechnicalDescription1.EditorType = BG3_Editor_Type.Textbox
        ' 
        ' BG3Editor_Template_Description1
        ' 
        BG3Editor_Template_Description1.EditorType = BG3_Editor_Type.Textbox
        ' 
        ' BG3Editor_Template_DisplayName1
        ' 
        BG3Editor_Template_DisplayName1.EditorType = BG3_Editor_Type.Textbox
        ' 
        ' BG3Editor_Template_Icon1
        ' 
        BG3Editor_Template_Icon1.EditorType = BG3_Editor_Type.Textbox
        ' 
        ' BG3Editor_Template_VisualTemplate1
        ' 
        BG3Editor_Template_VisualTemplate1.EditorType = BG3_Editor_Type.Textbox
        ' 
        ' BG3Editor_Template_Stats1
        ' 
        BG3Editor_Template_Stats1.EditorType = BG3_Editor_Type.Textbox
        ' 
        ' BG3Editor_Stat_Using1
        ' 
        BG3Editor_Stat_Using1.EditorType = BG3_Editor_Type.Textbox
        BG3Editor_Stat_Using1.MustDescendFrom = New String() {"_Body"}
        ' 
        ' TabControl1
        ' 
        TabControl1.Controls.Add(TabPageEquipment)
        TabControl1.Controls.SetChildIndex(TabPageEquipment, 0)
        TabControl1.Controls.SetChildIndex(TabPage3, 0)
        TabControl1.Controls.SetChildIndex(TabPage5, 0)
        TabControl1.Controls.SetChildIndex(TabPage2, 0)
        TabControl1.Controls.SetChildIndex(TabPage1, 0)
        ' 
        ' BG3Editor_Stat_Slots_Armor1
        ' 
        BG3Editor_Stat_Slots_Armor1.EditorType = BG3_Editor_Type.Combobox
        BG3Editor_Stat_Slots_Armor1.Label = "Slot"
        BG3Editor_Stat_Slots_Armor1.Location = New Point(6, 111)
        BG3Editor_Stat_Slots_Armor1.Margin = New Padding(0)
        BG3Editor_Stat_Slots_Armor1.MaximumSize = New Size(3000, 23)
        BG3Editor_Stat_Slots_Armor1.MinimumSize = New Size(100, 23)
        BG3Editor_Stat_Slots_Armor1.Name = "BG3Editor_Stat_Slots_Armor1"
        BG3Editor_Stat_Slots_Armor1.Size = New Size(392, 23)
        BG3Editor_Stat_Slots_Armor1.Slot_Type = BG3Editor_Stats_Slots_Armor.Item_type_Enum.Armor
        BG3Editor_Stat_Slots_Armor1.SplitterDistance = 100
        BG3Editor_Stat_Slots_Armor1.TabIndex = 7
        ' 
        ' BG3Editor_Stats_DefaultBoosts1
        ' 
        BG3Editor_Stats_DefaultBoosts1.Label = "Default boosts"
        BG3Editor_Stats_DefaultBoosts1.Location = New Point(3, 61)
        BG3Editor_Stats_DefaultBoosts1.Margin = New Padding(0)
        BG3Editor_Stats_DefaultBoosts1.MaximumSize = New Size(3000, 23)
        BG3Editor_Stats_DefaultBoosts1.MinimumSize = New Size(100, 23)
        BG3Editor_Stats_DefaultBoosts1.Name = "BG3Editor_Stats_DefaultBoosts1"
        BG3Editor_Stats_DefaultBoosts1.Size = New Size(378, 23)
        BG3Editor_Stats_DefaultBoosts1.TabIndex = 7
        ' 
        ' BG3Editor_Stats_ProficiencyGroup1
        ' 
        BG3Editor_Stats_ProficiencyGroup1.EditorType = BG3_Editor_Type.Combobox
        BG3Editor_Stats_ProficiencyGroup1.Label = "Proficiency"
        BG3Editor_Stats_ProficiencyGroup1.Location = New Point(3, 61)
        BG3Editor_Stats_ProficiencyGroup1.Margin = New Padding(0)
        BG3Editor_Stats_ProficiencyGroup1.MaximumSize = New Size(3000, 23)
        BG3Editor_Stats_ProficiencyGroup1.MinimumSize = New Size(100, 23)
        BG3Editor_Stats_ProficiencyGroup1.Name = "BG3Editor_Stats_ProficiencyGroup1"
        BG3Editor_Stats_ProficiencyGroup1.Size = New Size(375, 23)
        BG3Editor_Stats_ProficiencyGroup1.Slot_Type = BG3Editor_Stats_ProficiencyGroup.Item_type_Enum.Armor
        BG3Editor_Stats_ProficiencyGroup1.SplitterDistance = 100
        BG3Editor_Stats_ProficiencyGroup1.TabIndex = 6
        ' 
        ' BG3Editor_Stats_ArmorClass1
        ' 
        BG3Editor_Stats_ArmorClass1.EditorType = BG3_Editor_Type.NumericUpDown
        BG3Editor_Stats_ArmorClass1.Label = "ArmorClass"
        BG3Editor_Stats_ArmorClass1.Location = New Point(3, 84)
        BG3Editor_Stats_ArmorClass1.Margin = New Padding(0)
        BG3Editor_Stats_ArmorClass1.MaximumSize = New Size(3000, 23)
        BG3Editor_Stats_ArmorClass1.MinimumSize = New Size(100, 23)
        BG3Editor_Stats_ArmorClass1.Name = "BG3Editor_Stats_ArmorClass1"
        BG3Editor_Stats_ArmorClass1.Size = New Size(260, 23)
        BG3Editor_Stats_ArmorClass1.SplitterDistance = 100
        BG3Editor_Stats_ArmorClass1.TabIndex = 5
        ' 
        ' BG3Editor_Stats_ArmorClassAbility1
        ' 
        BG3Editor_Stats_ArmorClassAbility1.EditorType = BG3_Editor_Type.Combobox
        BG3Editor_Stats_ArmorClassAbility1.Label = "Armor Ability"
        BG3Editor_Stats_ArmorClassAbility1.Location = New Point(3, 38)
        BG3Editor_Stats_ArmorClassAbility1.Margin = New Padding(0)
        BG3Editor_Stats_ArmorClassAbility1.MaximumSize = New Size(3000, 23)
        BG3Editor_Stats_ArmorClassAbility1.MinimumSize = New Size(100, 23)
        BG3Editor_Stats_ArmorClassAbility1.Name = "BG3Editor_Stats_ArmorClassAbility1"
        BG3Editor_Stats_ArmorClassAbility1.Size = New Size(375, 23)
        BG3Editor_Stats_ArmorClassAbility1.SplitterDistance = 100
        BG3Editor_Stats_ArmorClassAbility1.TabIndex = 4
        ' 
        ' BG3Editor_Stats_StatusOnEquip1
        ' 
        BG3Editor_Stats_StatusOnEquip1.Label = "Status on equip"
        BG3Editor_Stats_StatusOnEquip1.Location = New Point(3, 84)
        BG3Editor_Stats_StatusOnEquip1.Margin = New Padding(0)
        BG3Editor_Stats_StatusOnEquip1.MaximumSize = New Size(3000, 23)
        BG3Editor_Stats_StatusOnEquip1.MinimumSize = New Size(100, 23)
        BG3Editor_Stats_StatusOnEquip1.Name = "BG3Editor_Stats_StatusOnEquip1"
        BG3Editor_Stats_StatusOnEquip1.Size = New Size(378, 23)
        BG3Editor_Stats_StatusOnEquip1.SplitterDistance = 100
        BG3Editor_Stats_StatusOnEquip1.TabIndex = 3
        ' 
        ' BG3Editor_Stats_ArmorType1
        ' 
        BG3Editor_Stats_ArmorType1.EditorType = BG3_Editor_Type.Combobox
        BG3Editor_Stats_ArmorType1.Label = "Armor type"
        BG3Editor_Stats_ArmorType1.Location = New Point(3, 15)
        BG3Editor_Stats_ArmorType1.Margin = New Padding(0)
        BG3Editor_Stats_ArmorType1.MaximumSize = New Size(3000, 23)
        BG3Editor_Stats_ArmorType1.MinimumSize = New Size(100, 23)
        BG3Editor_Stats_ArmorType1.Name = "BG3Editor_Stats_ArmorType1"
        BG3Editor_Stats_ArmorType1.Size = New Size(375, 23)
        BG3Editor_Stats_ArmorType1.SplitterDistance = 100
        BG3Editor_Stats_ArmorType1.TabIndex = 2
        ' 
        ' BG3Editor_Stats_Boosts1
        ' 
        BG3Editor_Stats_Boosts1.Label = "Boosts"
        BG3Editor_Stats_Boosts1.Location = New Point(3, 38)
        BG3Editor_Stats_Boosts1.Margin = New Padding(0)
        BG3Editor_Stats_Boosts1.MaximumSize = New Size(3000, 23)
        BG3Editor_Stats_Boosts1.MinimumSize = New Size(100, 23)
        BG3Editor_Stats_Boosts1.Name = "BG3Editor_Stats_Boosts1"
        BG3Editor_Stats_Boosts1.Size = New Size(378, 23)
        BG3Editor_Stats_Boosts1.SplitterDistance = 100
        BG3Editor_Stats_Boosts1.TabIndex = 1
        ' 
        ' BG3Editor_Stats_PassivesOnEquip1
        ' 
        BG3Editor_Stats_PassivesOnEquip1.Label = "Passives on equip"
        BG3Editor_Stats_PassivesOnEquip1.Location = New Point(3, 15)
        BG3Editor_Stats_PassivesOnEquip1.Margin = New Padding(0)
        BG3Editor_Stats_PassivesOnEquip1.MaximumSize = New Size(3000, 23)
        BG3Editor_Stats_PassivesOnEquip1.MinimumSize = New Size(100, 23)
        BG3Editor_Stats_PassivesOnEquip1.Name = "BG3Editor_Stats_PassivesOnEquip1"
        BG3Editor_Stats_PassivesOnEquip1.Size = New Size(378, 23)
        BG3Editor_Stats_PassivesOnEquip1.SplitterDistance = 100
        BG3Editor_Stats_PassivesOnEquip1.TabIndex = 0
        ' 
        ' TabControl2
        ' 
        TabControl2.Appearance = TabAppearance.FlatButtons
        TabControl2.Controls.Add(TabPageArmorsG)
        TabControl2.Controls.Add(TabPageArmorsB)
        TabControl2.Controls.Add(TabPageArmorsS)
        TabControl2.Location = New Point(419, 10)
        TabControl2.Margin = New Padding(0)
        TabControl2.Name = "TabControl2"
        TabControl2.SelectedIndex = 0
        TabControl2.Size = New Size(392, 260)
        TabControl2.TabIndex = 8
        ' 
        ' TabPageArmorsG
        ' 
        TabPageArmorsG.Controls.Add(GroupBoxArmorsG)
        TabPageArmorsG.Location = New Point(4, 27)
        TabPageArmorsG.Name = "TabPageArmorsG"
        TabPageArmorsG.Size = New Size(384, 229)
        TabPageArmorsG.TabIndex = 2
        TabPageArmorsG.Text = "General"
        TabPageArmorsG.UseVisualStyleBackColor = True
        ' 
        ' GroupBoxArmorsG
        ' 
        GroupBoxArmorsG.Controls.Add(BG3Editor_Stats_ArmorClass1)
        GroupBoxArmorsG.Controls.Add(BG3Editor_Stats_ProficiencyGroup1)
        GroupBoxArmorsG.Controls.Add(BG3Editor_Stats_ArmorType1)
        GroupBoxArmorsG.Controls.Add(BG3Editor_Stats_ArmorClassAbility1)
        GroupBoxArmorsG.Dock = DockStyle.Fill
        GroupBoxArmorsG.Location = New Point(0, 0)
        GroupBoxArmorsG.Margin = New Padding(0)
        GroupBoxArmorsG.Name = "GroupBoxArmorsG"
        GroupBoxArmorsG.Size = New Size(384, 229)
        GroupBoxArmorsG.TabIndex = 0
        GroupBoxArmorsG.TabStop = False
        ' 
        ' TabPageArmorsB
        ' 
        TabPageArmorsB.Controls.Add(GroupBoxArmors1)
        TabPageArmorsB.Location = New Point(4, 27)
        TabPageArmorsB.Margin = New Padding(0)
        TabPageArmorsB.Name = "TabPageArmorsB"
        TabPageArmorsB.Size = New Size(384, 229)
        TabPageArmorsB.TabIndex = 0
        TabPageArmorsB.Text = "Boost and pasives"
        TabPageArmorsB.UseVisualStyleBackColor = True
        ' 
        ' GroupBoxArmors1
        ' 
        GroupBoxArmors1.Controls.Add(BG3Editor_Stats_DefaultBoosts1)
        GroupBoxArmors1.Controls.Add(BG3Editor_Stats_PassivesOnEquip1)
        GroupBoxArmors1.Controls.Add(BG3Editor_Stats_Boosts1)
        GroupBoxArmors1.Controls.Add(BG3Editor_Stats_StatusOnEquip1)
        GroupBoxArmors1.Dock = DockStyle.Fill
        GroupBoxArmors1.Enabled = False
        GroupBoxArmors1.Location = New Point(0, 0)
        GroupBoxArmors1.Margin = New Padding(0)
        GroupBoxArmors1.Name = "GroupBoxArmors1"
        GroupBoxArmors1.Size = New Size(384, 229)
        GroupBoxArmors1.TabIndex = 6
        GroupBoxArmors1.TabStop = False
        ' 
        ' TabPageArmorsS
        ' 
        TabPageArmorsS.Controls.Add(GroupBoxArmorsS)
        TabPageArmorsS.Location = New Point(4, 27)
        TabPageArmorsS.Name = "TabPageArmorsS"
        TabPageArmorsS.Size = New Size(384, 229)
        TabPageArmorsS.TabIndex = 3
        TabPageArmorsS.Text = "Status list"
        TabPageArmorsS.UseVisualStyleBackColor = True
        ' 
        ' GroupBoxArmorsS
        ' 
        GroupBoxArmorsS.Controls.Add(BG3Editor_Complex_StatusList1)
        GroupBoxArmorsS.Dock = DockStyle.Fill
        GroupBoxArmorsS.Location = New Point(0, 0)
        GroupBoxArmorsS.Margin = New Padding(0)
        GroupBoxArmorsS.Name = "GroupBoxArmorsS"
        GroupBoxArmorsS.Size = New Size(384, 229)
        GroupBoxArmorsS.TabIndex = 1
        GroupBoxArmorsS.TabStop = False
        ' 
        ' BG3Editor_Complex_StatusList1
        ' 
        BG3Editor_Complex_StatusList1.Dock = DockStyle.Fill
        BG3Editor_Complex_StatusList1.Location = New Point(3, 19)
        BG3Editor_Complex_StatusList1.Name = "BG3Editor_Complex_StatusList1"
        BG3Editor_Complex_StatusList1.Size = New Size(378, 207)
        BG3Editor_Complex_StatusList1.TabIndex = 0
        ' 
        ' TabPageEquipment
        ' 
        TabPageEquipment.Controls.Add(GroupBoxEquipment)
        TabPageEquipment.Location = New Point(4, 27)
        TabPageEquipment.Name = "TabPageEquipment"
        TabPageEquipment.Size = New Size(807, 472)
        TabPageEquipment.TabIndex = 7
        TabPageEquipment.Text = "Equipment"
        TabPageEquipment.UseVisualStyleBackColor = True
        ' 
        ' BG3Editor_Complex_ArmorEquipment1
        ' 
        BG3Editor_Complex_ArmorEquipment1.Dock = DockStyle.Fill
        BG3Editor_Complex_ArmorEquipment1.Location = New Point(3, 19)
        BG3Editor_Complex_ArmorEquipment1.Name = "BG3Editor_Complex_ArmorEquipment1"
        BG3Editor_Complex_ArmorEquipment1.Readonly = False
        BG3Editor_Complex_ArmorEquipment1.Size = New Size(801, 450)
        BG3Editor_Complex_ArmorEquipment1.TabIndex = 0
        ' 
        ' GroupBoxEquipment
        ' 
        GroupBoxEquipment.Controls.Add(BG3Editor_Complex_ArmorEquipment1)
        GroupBoxEquipment.Dock = DockStyle.Fill
        GroupBoxEquipment.Location = New Point(0, 0)
        GroupBoxEquipment.Margin = New Padding(0)
        GroupBoxEquipment.Name = "GroupBoxEquipment"
        GroupBoxEquipment.Size = New Size(807, 472)
        GroupBoxEquipment.TabIndex = 1
        GroupBoxEquipment.TabStop = False
        ' 
        ' Armors_Editor
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1169, 596)
        Name = "Armors_Editor"
        Text = "Armors editor"
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
        GroupBoxBasicTemplates.ResumeLayout(False)
        GroupBoxVisuals.ResumeLayout(False)
        GroupBoxBasicStats.ResumeLayout(False)
        TabControl1.ResumeLayout(False)
        TabControl2.ResumeLayout(False)
        TabPageArmorsG.ResumeLayout(False)
        GroupBoxArmorsG.ResumeLayout(False)
        TabPageArmorsB.ResumeLayout(False)
        GroupBoxArmors1.ResumeLayout(False)
        TabPageArmorsS.ResumeLayout(False)
        GroupBoxArmorsS.ResumeLayout(False)
        TabPageEquipment.ResumeLayout(False)
        GroupBoxEquipment.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Friend WithEvents BG3Editor_Stat_Slots_Armor1 As BG3Editor_Stats_Slots_Armor
    Friend WithEvents BG3Editor_Stats_PassivesOnEquip1 As BG3Editor_Stats_PassivesOnEquip
    Friend WithEvents BG3Editor_Stats_Boosts1 As BG3Editor_Stats_Boosts
    Friend WithEvents BG3Editor_Stats_StatusOnEquip1 As BG3Editor_Stats_StatusOnEquip
    Friend WithEvents BG3Editor_Stats_ArmorType1 As BG3Editor_Stats_ArmorType
    Friend WithEvents BG3Editor_Stats_ProficiencyGroup1 As BG3Editor_Stats_ProficiencyGroup
    Friend WithEvents BG3Editor_Stats_ArmorClass1 As BG3Editor_Stats_ArmorClass
    Friend WithEvents BG3Editor_Stats_ArmorClassAbility1 As BG3Editor_Stats_ArmorClassAbility
    Friend WithEvents BG3Editor_Stats_DefaultBoosts1 As BG3Editor_Stats_DefaultBoosts
    Friend WithEvents TabControl2 As TabControl
    Friend WithEvents TabPageArmorsG As TabPage
    Friend WithEvents GroupBoxArmorsG As GroupBox
    Friend WithEvents TabPageArmorsB As TabPage
    Friend WithEvents GroupBoxArmors1 As GroupBox
    Friend WithEvents TabPageArmorsS As TabPage
    Friend WithEvents GroupBoxArmorsS As GroupBox
    Friend WithEvents BG3Editor_Complex_StatusList1 As BG3Editor_Complex_StatusList
    Friend WithEvents TabPageEquipment As TabPage
    Friend WithEvents BG3Editor_Complex_ArmorEquipment1 As BG3Editor_Complex_ArmorEquipment
    Friend WithEvents GroupBoxEquipment As GroupBox
End Class
