<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Armors_Editor
    Inherits Generic_Editor

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
        GroupBox5 = New GroupBox()
        BG3Editor_Stats_StatusOnEquip1 = New BG3Editor_Stats_StatusOnEquip()
        BG3Editor_Stats_ArmorType1 = New BG3Editor_Stats_ArmorType()
        BG3Editor_Stats_Boosts1 = New BG3Editor_Stats_Boosts()
        BG3Editor_Stats_PassivesOnEquip1 = New BG3Editor_Stats_PassivesOnEquip()
        BG3Editor_Stats_ArmorClassAbility1 = New BG3Editor_Stats_ArmorClassAbility()
        BG3Editor_Stats_ArmorClass1 = New BG3Editor_Stats_ArmorClass()
        BG3Editor_Stats_ProficiencyGroup1 = New BG3Editor_Stats_ProficiencyGroup()
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
        GroupBox5.SuspendLayout()
        SuspendLayout()
        ' 
        ' BG3Selector_Template1
        ' 
        BG3Selector_Template1.CloneLabel = "Drop a Stat or a Templato to add from it.  It must descend from armor bases."
        BG3Selector_Template1.Selection = BG3_Enum_UTAM_Type.Containers
        BG3Selector_Template1.Stat_MustDescend_From = New String() {"_Body"}
        BG3Selector_Template1.Template_MustDescend_From = New String() {"a09273ba-6549-4cf9-ba47-615a962baf9f"}
        ' 
        ' GroupBox9
        ' 
        GroupBox9.Controls.Add(GroupBox5)
        GroupBox9.Controls.SetChildIndex(GroupBoxBasicStats, 0)
        GroupBox9.Controls.SetChildIndex(GroupBoxVisuals, 0)
        GroupBox9.Controls.SetChildIndex(GroupBoxBasicTemplates, 0)
        GroupBox9.Controls.SetChildIndex(GroupBox5, 0)
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
        BG3Editor_Template_Parent1.MustDescendFrom = New String() {"a09273ba-6549-4cf9-ba47-615a962baf9f"}
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
        BG3Editor_Stat_Slots_Armor1.SplitterDistance = 100
        BG3Editor_Stat_Slots_Armor1.TabIndex = 7
        ' 
        ' GroupBox5
        ' 
        GroupBox5.Controls.Add(BG3Editor_Stats_ProficiencyGroup1)
        GroupBox5.Controls.Add(BG3Editor_Stats_ArmorClass1)
        GroupBox5.Controls.Add(BG3Editor_Stats_ArmorClassAbility1)
        GroupBox5.Controls.Add(BG3Editor_Stats_StatusOnEquip1)
        GroupBox5.Controls.Add(BG3Editor_Stats_ArmorType1)
        GroupBox5.Controls.Add(BG3Editor_Stats_Boosts1)
        GroupBox5.Controls.Add(BG3Editor_Stats_PassivesOnEquip1)
        GroupBox5.Enabled = False
        GroupBox5.Location = New Point(416, 10)
        GroupBox5.Name = "GroupBox5"
        GroupBox5.Size = New Size(385, 191)
        GroupBox5.TabIndex = 6
        GroupBox5.TabStop = False
        GroupBox5.Text = "Armor specifics"
        ' 
        ' BG3Editor_Stats_StatusOnEquip1
        ' 
        BG3Editor_Stats_StatusOnEquip1.Label = "Status on equip"
        BG3Editor_Stats_StatusOnEquip1.Location = New Point(3, 65)
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
        BG3Editor_Stats_ArmorType1.Location = New Point(3, 88)
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
        BG3Editor_Stats_Boosts1.Location = New Point(3, 42)
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
        BG3Editor_Stats_PassivesOnEquip1.Location = New Point(3, 19)
        BG3Editor_Stats_PassivesOnEquip1.Margin = New Padding(0)
        BG3Editor_Stats_PassivesOnEquip1.MaximumSize = New Size(3000, 23)
        BG3Editor_Stats_PassivesOnEquip1.MinimumSize = New Size(100, 23)
        BG3Editor_Stats_PassivesOnEquip1.Name = "BG3Editor_Stats_PassivesOnEquip1"
        BG3Editor_Stats_PassivesOnEquip1.Size = New Size(378, 23)
        BG3Editor_Stats_PassivesOnEquip1.SplitterDistance = 100
        BG3Editor_Stats_PassivesOnEquip1.TabIndex = 0
        ' 
        ' BG3Editor_Stats_ArmorClassAbility1
        ' 
        BG3Editor_Stats_ArmorClassAbility1.EditorType = BG3_Editor_Type.Combobox
        BG3Editor_Stats_ArmorClassAbility1.Label = "Armor Ability"
        BG3Editor_Stats_ArmorClassAbility1.Location = New Point(3, 111)
        BG3Editor_Stats_ArmorClassAbility1.Margin = New Padding(0)
        BG3Editor_Stats_ArmorClassAbility1.MaximumSize = New Size(3000, 23)
        BG3Editor_Stats_ArmorClassAbility1.MinimumSize = New Size(100, 23)
        BG3Editor_Stats_ArmorClassAbility1.Name = "BG3Editor_Stats_ArmorClassAbility1"
        BG3Editor_Stats_ArmorClassAbility1.Size = New Size(375, 23)
        BG3Editor_Stats_ArmorClassAbility1.SplitterDistance = 100
        BG3Editor_Stats_ArmorClassAbility1.TabIndex = 4
        ' 
        ' BG3Editor_Stats_ArmorClass1
        ' 
        BG3Editor_Stats_ArmorClass1.EditorType = BG3_Editor_Type.NumericUpDown
        BG3Editor_Stats_ArmorClass1.Label = "ArmorClass"
        BG3Editor_Stats_ArmorClass1.Location = New Point(3, 157)
        BG3Editor_Stats_ArmorClass1.Margin = New Padding(0)
        BG3Editor_Stats_ArmorClass1.MaximumSize = New Size(3000, 23)
        BG3Editor_Stats_ArmorClass1.MinimumSize = New Size(100, 23)
        BG3Editor_Stats_ArmorClass1.Name = "BG3Editor_Stats_ArmorClass1"
        BG3Editor_Stats_ArmorClass1.Size = New Size(260, 23)
        BG3Editor_Stats_ArmorClass1.SplitterDistance = 100
        BG3Editor_Stats_ArmorClass1.TabIndex = 5
        ' 
        ' BG3Editor_Stats_ProficiencyGroup1
        ' 
        BG3Editor_Stats_ProficiencyGroup1.EditorType = BG3_Editor_Type.Combobox
        BG3Editor_Stats_ProficiencyGroup1.Label = "Proficiency"
        BG3Editor_Stats_ProficiencyGroup1.Location = New Point(3, 134)
        BG3Editor_Stats_ProficiencyGroup1.Margin = New Padding(0)
        BG3Editor_Stats_ProficiencyGroup1.MaximumSize = New Size(3000, 23)
        BG3Editor_Stats_ProficiencyGroup1.MinimumSize = New Size(100, 23)
        BG3Editor_Stats_ProficiencyGroup1.Name = "BG3Editor_Stats_ProficiencyGroup1"
        BG3Editor_Stats_ProficiencyGroup1.Size = New Size(378, 23)
        BG3Editor_Stats_ProficiencyGroup1.SplitterDistance = 100
        BG3Editor_Stats_ProficiencyGroup1.TabIndex = 6
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
        GroupBox5.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Friend WithEvents BG3Editor_Stat_Slots_Armor1 As BG3Editor_Stats_Slots_Armor
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents BG3Editor_Stats_PassivesOnEquip1 As BG3Editor_Stats_PassivesOnEquip
    Friend WithEvents BG3Editor_Stats_Boosts1 As BG3Editor_Stats_Boosts
    Friend WithEvents BG3Editor_Stats_StatusOnEquip1 As BG3Editor_Stats_StatusOnEquip
    Friend WithEvents BG3Editor_Stats_ArmorType1 As BG3Editor_Stats_ArmorType
    Friend WithEvents BG3Editor_Stats_ProficiencyGroup1 As BG3Editor_Stats_ProficiencyGroup
    Friend WithEvents BG3Editor_Stats_ArmorClass1 As BG3Editor_Stats_ArmorClass
    Friend WithEvents BG3Editor_Stats_ArmorClassAbility1 As BG3Editor_Stats_ArmorClassAbility
End Class
