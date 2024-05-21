<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Weapons_Editor
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
        GroupBoxWeapons1 = New GroupBox()
        BG3Editor_Stats_WeaponFunctors1 = New BG3Editor_Stats_WeaponFunctors()
        BG3Editor_Stats_DefaultBoosts1 = New BG3Editor_Stats_DefaultBoosts()
        BG3Editor_Stats_BoostsOnEquipOffHand1 = New BG3Editor_Stats_BoostsOnEquipOffHand()
        BG3Editor_Stats_BoostsOnEquipMainHand1 = New BG3Editor_Stats_BoostsOnEquipMainHand()
        BG3Editor_Stats_PassivesOnEquip_OffHand1 = New BG3Editor_Stats_PassivesOnEquip_OffHand()
        BG3Editor_Stats_PassivesOnEquip_MainHand1 = New BG3Editor_Stats_PassivesOnEquip_MainHand()
        BG3Editor_Stats_StatusOnEquip1 = New BG3Editor_Stats_StatusOnEquip()
        BG3Editor_Stats_Boosts1 = New BG3Editor_Stats_Boosts()
        BG3Editor_Stats_PassivesOnEquip1 = New BG3Editor_Stats_PassivesOnEquip()
        BG3Editor_Stats_WeaponsProficiencyGroup1 = New BG3Editor_Stats_WeaponProficiency()
        TabControl2 = New TabControl()
        TabPageWeaponsG = New TabPage()
        GroupBoxWeaponsG = New GroupBox()
        Label2 = New Label()
        Label1 = New Label()
        BG3Editor_Template_EquipmenTypeId1 = New BG3Editor_Template_EquipmentTypeID()
        BG3Editor_Stats_WeaponProperties1 = New BG3Editor_Stats_WeaponProperties()
        BG3Editor_Stats_WeaponGroup1 = New BG3Editor_Stats_WeaponGroup()
        TabPageWeaponsB = New TabPage()
        TabPageWeaponsD = New TabPage()
        GroupBoxWeaponsD = New GroupBox()
        BG3Editor_Stats_VersatileDamage1 = New BG3Editor_Stats_VersatileDamage()
        BG3Editor_Stats_Damage1 = New BG3Editor_Stats_Damage()
        BG3Editor_Stats_Damage_Type1 = New BG3Editor_Stats_Damage_Type()
        BG3Editor_Stats_DamageRange1 = New BG3Editor_Stats_DamageRange()
        BG3Editor_Stats_WeaponRange1 = New BG3Editor_Stats_WeaponRange()
        TabPageWeaponsS = New TabPage()
        BG3Editor_Complex_StatusList1 = New BG3Editor_Complex_StatusList()
        GroupBoxWeaponsS = New GroupBox()
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
        GroupBoxWeapons1.SuspendLayout()
        TabControl2.SuspendLayout()
        TabPageWeaponsG.SuspendLayout()
        GroupBoxWeaponsG.SuspendLayout()
        TabPageWeaponsB.SuspendLayout()
        TabPageWeaponsD.SuspendLayout()
        GroupBoxWeaponsD.SuspendLayout()
        TabPageWeaponsS.SuspendLayout()
        GroupBoxWeaponsS.SuspendLayout()
        SuspendLayout()
        ' 
        ' BG3Selector_Template1
        ' 
        BG3Selector_Template1.CloneLabel = "Drop a Stat or a Template to add from it.  It must descend from weapons bases."
        BG3Selector_Template1.Selection = BG3_Enum_UTAM_Type.Weapon
        BG3Selector_Template1.Stat_MustDescend_From = New String() {"_BaseWeapon"}
        BG3Selector_Template1.Template_MustDescend_From = New String() {"f44c9c6f-bc71-42ad-9cad-2dae306e750e", "Not 77bee355-c1be-4182-bbe9-2279d3c856d6"}
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
        BG3Editor_Template_Parent1.MustDescendFrom = New String() {"f44c9c6f-bc71-42ad-9cad-2dae306e750e", "Not 77bee355-c1be-4182-bbe9-2279d3c856d6"}
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
        BG3Editor_Stat_Using1.MustDescendFrom = New String() {"_BaseWeapon"}
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
        BG3Editor_Stat_Slots_Armor1.Slot_Type = BG3Editor_Stats_Slots_Armor.Item_type_Enum.Weapons
        BG3Editor_Stat_Slots_Armor1.SplitterDistance = 100
        BG3Editor_Stat_Slots_Armor1.TabIndex = 7
        ' 
        ' GroupBoxWeapons1
        ' 
        GroupBoxWeapons1.Controls.Add(BG3Editor_Stats_WeaponFunctors1)
        GroupBoxWeapons1.Controls.Add(BG3Editor_Stats_DefaultBoosts1)
        GroupBoxWeapons1.Controls.Add(BG3Editor_Stats_BoostsOnEquipOffHand1)
        GroupBoxWeapons1.Controls.Add(BG3Editor_Stats_BoostsOnEquipMainHand1)
        GroupBoxWeapons1.Controls.Add(BG3Editor_Stats_PassivesOnEquip_OffHand1)
        GroupBoxWeapons1.Controls.Add(BG3Editor_Stats_PassivesOnEquip_MainHand1)
        GroupBoxWeapons1.Controls.Add(BG3Editor_Stats_StatusOnEquip1)
        GroupBoxWeapons1.Controls.Add(BG3Editor_Stats_Boosts1)
        GroupBoxWeapons1.Controls.Add(BG3Editor_Stats_PassivesOnEquip1)
        GroupBoxWeapons1.Dock = DockStyle.Fill
        GroupBoxWeapons1.Enabled = False
        GroupBoxWeapons1.Location = New Point(0, 0)
        GroupBoxWeapons1.Margin = New Padding(0)
        GroupBoxWeapons1.Name = "GroupBoxWeapons1"
        GroupBoxWeapons1.Size = New Size(384, 229)
        GroupBoxWeapons1.TabIndex = 6
        GroupBoxWeapons1.TabStop = False
        ' 
        ' BG3Editor_Stats_WeaponFunctors1
        ' 
        BG3Editor_Stats_WeaponFunctors1.Label = "Weapon functors"
        BG3Editor_Stats_WeaponFunctors1.Location = New Point(3, 199)
        BG3Editor_Stats_WeaponFunctors1.Margin = New Padding(0)
        BG3Editor_Stats_WeaponFunctors1.MaximumSize = New Size(3000, 23)
        BG3Editor_Stats_WeaponFunctors1.MinimumSize = New Size(100, 23)
        BG3Editor_Stats_WeaponFunctors1.Name = "BG3Editor_Stats_WeaponFunctors1"
        BG3Editor_Stats_WeaponFunctors1.Size = New Size(378, 23)
        BG3Editor_Stats_WeaponFunctors1.TabIndex = 12
        ' 
        ' BG3Editor_Stats_DefaultBoosts1
        ' 
        BG3Editor_Stats_DefaultBoosts1.Label = "Default boosts"
        BG3Editor_Stats_DefaultBoosts1.Location = New Point(3, 176)
        BG3Editor_Stats_DefaultBoosts1.Margin = New Padding(0)
        BG3Editor_Stats_DefaultBoosts1.MaximumSize = New Size(3000, 23)
        BG3Editor_Stats_DefaultBoosts1.MinimumSize = New Size(100, 23)
        BG3Editor_Stats_DefaultBoosts1.Name = "BG3Editor_Stats_DefaultBoosts1"
        BG3Editor_Stats_DefaultBoosts1.Size = New Size(378, 23)
        BG3Editor_Stats_DefaultBoosts1.TabIndex = 11
        ' 
        ' BG3Editor_Stats_BoostsOnEquipOffHand1
        ' 
        BG3Editor_Stats_BoostsOnEquipOffHand1.Label = "On off hand"
        BG3Editor_Stats_BoostsOnEquipOffHand1.Location = New Point(3, 130)
        BG3Editor_Stats_BoostsOnEquipOffHand1.Margin = New Padding(0)
        BG3Editor_Stats_BoostsOnEquipOffHand1.MaximumSize = New Size(3000, 23)
        BG3Editor_Stats_BoostsOnEquipOffHand1.MinimumSize = New Size(100, 23)
        BG3Editor_Stats_BoostsOnEquipOffHand1.Name = "BG3Editor_Stats_BoostsOnEquipOffHand1"
        BG3Editor_Stats_BoostsOnEquipOffHand1.Size = New Size(378, 23)
        BG3Editor_Stats_BoostsOnEquipOffHand1.TabIndex = 10
        ' 
        ' BG3Editor_Stats_BoostsOnEquipMainHand1
        ' 
        BG3Editor_Stats_BoostsOnEquipMainHand1.Label = "On main hand"
        BG3Editor_Stats_BoostsOnEquipMainHand1.Location = New Point(3, 107)
        BG3Editor_Stats_BoostsOnEquipMainHand1.Margin = New Padding(0)
        BG3Editor_Stats_BoostsOnEquipMainHand1.MaximumSize = New Size(3000, 23)
        BG3Editor_Stats_BoostsOnEquipMainHand1.MinimumSize = New Size(100, 23)
        BG3Editor_Stats_BoostsOnEquipMainHand1.Name = "BG3Editor_Stats_BoostsOnEquipMainHand1"
        BG3Editor_Stats_BoostsOnEquipMainHand1.Size = New Size(378, 23)
        BG3Editor_Stats_BoostsOnEquipMainHand1.TabIndex = 9
        ' 
        ' BG3Editor_Stats_PassivesOnEquip_OffHand1
        ' 
        BG3Editor_Stats_PassivesOnEquip_OffHand1.Label = "On off hand"
        BG3Editor_Stats_PassivesOnEquip_OffHand1.Location = New Point(3, 61)
        BG3Editor_Stats_PassivesOnEquip_OffHand1.Margin = New Padding(0)
        BG3Editor_Stats_PassivesOnEquip_OffHand1.MaximumSize = New Size(3000, 23)
        BG3Editor_Stats_PassivesOnEquip_OffHand1.MinimumSize = New Size(100, 23)
        BG3Editor_Stats_PassivesOnEquip_OffHand1.Name = "BG3Editor_Stats_PassivesOnEquip_OffHand1"
        BG3Editor_Stats_PassivesOnEquip_OffHand1.Size = New Size(378, 23)
        BG3Editor_Stats_PassivesOnEquip_OffHand1.TabIndex = 8
        ' 
        ' BG3Editor_Stats_PassivesOnEquip_MainHand1
        ' 
        BG3Editor_Stats_PassivesOnEquip_MainHand1.Label = "On main hand"
        BG3Editor_Stats_PassivesOnEquip_MainHand1.Location = New Point(3, 38)
        BG3Editor_Stats_PassivesOnEquip_MainHand1.Margin = New Padding(0)
        BG3Editor_Stats_PassivesOnEquip_MainHand1.MaximumSize = New Size(3000, 23)
        BG3Editor_Stats_PassivesOnEquip_MainHand1.MinimumSize = New Size(100, 23)
        BG3Editor_Stats_PassivesOnEquip_MainHand1.Name = "BG3Editor_Stats_PassivesOnEquip_MainHand1"
        BG3Editor_Stats_PassivesOnEquip_MainHand1.Size = New Size(378, 23)
        BG3Editor_Stats_PassivesOnEquip_MainHand1.TabIndex = 7
        ' 
        ' BG3Editor_Stats_StatusOnEquip1
        ' 
        BG3Editor_Stats_StatusOnEquip1.Label = "Status on equip"
        BG3Editor_Stats_StatusOnEquip1.Location = New Point(3, 153)
        BG3Editor_Stats_StatusOnEquip1.Margin = New Padding(0)
        BG3Editor_Stats_StatusOnEquip1.MaximumSize = New Size(3000, 23)
        BG3Editor_Stats_StatusOnEquip1.MinimumSize = New Size(100, 23)
        BG3Editor_Stats_StatusOnEquip1.Name = "BG3Editor_Stats_StatusOnEquip1"
        BG3Editor_Stats_StatusOnEquip1.Size = New Size(378, 23)
        BG3Editor_Stats_StatusOnEquip1.SplitterDistance = 100
        BG3Editor_Stats_StatusOnEquip1.TabIndex = 3
        ' 
        ' BG3Editor_Stats_Boosts1
        ' 
        BG3Editor_Stats_Boosts1.Label = "Boosts"
        BG3Editor_Stats_Boosts1.Location = New Point(3, 84)
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
        ' BG3Editor_Stats_WeaponsProficiencyGroup1
        ' 
        BG3Editor_Stats_WeaponsProficiencyGroup1.Label = "Proficiencies"
        BG3Editor_Stats_WeaponsProficiencyGroup1.Location = New Point(3, 107)
        BG3Editor_Stats_WeaponsProficiencyGroup1.Margin = New Padding(0)
        BG3Editor_Stats_WeaponsProficiencyGroup1.MaximumSize = New Size(3000, 23)
        BG3Editor_Stats_WeaponsProficiencyGroup1.MinimumSize = New Size(100, 23)
        BG3Editor_Stats_WeaponsProficiencyGroup1.Name = "BG3Editor_Stats_WeaponsProficiencyGroup1"
        BG3Editor_Stats_WeaponsProficiencyGroup1.Size = New Size(378, 23)
        BG3Editor_Stats_WeaponsProficiencyGroup1.SplitterDistance = 100
        BG3Editor_Stats_WeaponsProficiencyGroup1.TabIndex = 6
        ' 
        ' TabControl2
        ' 
        TabControl2.Appearance = TabAppearance.FlatButtons
        TabControl2.Controls.Add(TabPageWeaponsG)
        TabControl2.Controls.Add(TabPageWeaponsB)
        TabControl2.Controls.Add(TabPageWeaponsD)
        TabControl2.Controls.Add(TabPageWeaponsS)
        TabControl2.Location = New Point(413, 10)
        TabControl2.Margin = New Padding(0)
        TabControl2.Name = "TabControl2"
        TabControl2.SelectedIndex = 0
        TabControl2.Size = New Size(392, 260)
        TabControl2.TabIndex = 7
        ' 
        ' TabPageWeaponsG
        ' 
        TabPageWeaponsG.Controls.Add(GroupBoxWeaponsG)
        TabPageWeaponsG.Location = New Point(4, 27)
        TabPageWeaponsG.Name = "TabPageWeaponsG"
        TabPageWeaponsG.Size = New Size(384, 229)
        TabPageWeaponsG.TabIndex = 2
        TabPageWeaponsG.Text = "General"
        TabPageWeaponsG.UseVisualStyleBackColor = True
        ' 
        ' GroupBoxWeaponsG
        ' 
        GroupBoxWeaponsG.Controls.Add(Label2)
        GroupBoxWeaponsG.Controls.Add(Label1)
        GroupBoxWeaponsG.Controls.Add(BG3Editor_Template_EquipmenTypeId1)
        GroupBoxWeaponsG.Controls.Add(BG3Editor_Stats_WeaponProperties1)
        GroupBoxWeaponsG.Controls.Add(BG3Editor_Stats_WeaponGroup1)
        GroupBoxWeaponsG.Controls.Add(BG3Editor_Stats_WeaponsProficiencyGroup1)
        GroupBoxWeaponsG.Dock = DockStyle.Fill
        GroupBoxWeaponsG.Location = New Point(0, 0)
        GroupBoxWeaponsG.Margin = New Padding(0)
        GroupBoxWeaponsG.Name = "GroupBoxWeaponsG"
        GroupBoxWeaponsG.Size = New Size(384, 229)
        GroupBoxWeaponsG.TabIndex = 0
        GroupBoxWeaponsG.TabStop = False
        ' 
        ' Label2
        ' 
        Label2.Location = New Point(3, 61)
        Label2.Name = "Label2"
        Label2.Size = New Size(116, 23)
        Label2.TabIndex = 11
        Label2.Text = "Equipment name"
        Label2.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label1
        ' 
        Label1.Location = New Point(125, 61)
        Label1.Name = "Label1"
        Label1.Size = New Size(255, 23)
        Label1.TabIndex = 10
        Label1.Text = "(Unknown)"
        Label1.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' BG3Editor_Template_EquipmenTypeId1
        ' 
        BG3Editor_Template_EquipmenTypeId1.DropIcon = True
        BG3Editor_Template_EquipmenTypeId1.Label = "Equipment"
        BG3Editor_Template_EquipmenTypeId1.Location = New Point(3, 38)
        BG3Editor_Template_EquipmenTypeId1.Margin = New Padding(0)
        BG3Editor_Template_EquipmenTypeId1.MaximumSize = New Size(3000, 23)
        BG3Editor_Template_EquipmenTypeId1.MinimumSize = New Size(100, 23)
        BG3Editor_Template_EquipmenTypeId1.Name = "BG3Editor_Template_EquipmenTypeId1"
        BG3Editor_Template_EquipmenTypeId1.Size = New Size(378, 23)
        BG3Editor_Template_EquipmenTypeId1.SplitterDistance = 80
        BG3Editor_Template_EquipmenTypeId1.TabIndex = 9
        ' 
        ' BG3Editor_Stats_WeaponProperties1
        ' 
        BG3Editor_Stats_WeaponProperties1.Label = "Properties"
        BG3Editor_Stats_WeaponProperties1.Location = New Point(3, 84)
        BG3Editor_Stats_WeaponProperties1.Margin = New Padding(0)
        BG3Editor_Stats_WeaponProperties1.MaximumSize = New Size(3000, 23)
        BG3Editor_Stats_WeaponProperties1.MinimumSize = New Size(100, 23)
        BG3Editor_Stats_WeaponProperties1.Name = "BG3Editor_Stats_WeaponProperties1"
        BG3Editor_Stats_WeaponProperties1.Size = New Size(378, 23)
        BG3Editor_Stats_WeaponProperties1.TabIndex = 8
        ' 
        ' BG3Editor_Stats_WeaponGroup1
        ' 
        BG3Editor_Stats_WeaponGroup1.EditorType = BG3_Editor_Type.Combobox
        BG3Editor_Stats_WeaponGroup1.Label = "Weapon group"
        BG3Editor_Stats_WeaponGroup1.Location = New Point(3, 15)
        BG3Editor_Stats_WeaponGroup1.Margin = New Padding(0)
        BG3Editor_Stats_WeaponGroup1.MaximumSize = New Size(3000, 23)
        BG3Editor_Stats_WeaponGroup1.MinimumSize = New Size(100, 23)
        BG3Editor_Stats_WeaponGroup1.Name = "BG3Editor_Stats_WeaponGroup1"
        BG3Editor_Stats_WeaponGroup1.Size = New Size(378, 23)
        BG3Editor_Stats_WeaponGroup1.TabIndex = 7
        ' 
        ' TabPageWeaponsB
        ' 
        TabPageWeaponsB.Controls.Add(GroupBoxWeapons1)
        TabPageWeaponsB.Location = New Point(4, 27)
        TabPageWeaponsB.Margin = New Padding(0)
        TabPageWeaponsB.Name = "TabPageWeaponsB"
        TabPageWeaponsB.Size = New Size(384, 229)
        TabPageWeaponsB.TabIndex = 0
        TabPageWeaponsB.Text = "Boost and pasives"
        TabPageWeaponsB.UseVisualStyleBackColor = True
        ' 
        ' TabPageWeaponsD
        ' 
        TabPageWeaponsD.Controls.Add(GroupBoxWeaponsD)
        TabPageWeaponsD.Location = New Point(4, 27)
        TabPageWeaponsD.Margin = New Padding(0)
        TabPageWeaponsD.Name = "TabPageWeaponsD"
        TabPageWeaponsD.Size = New Size(384, 229)
        TabPageWeaponsD.TabIndex = 1
        TabPageWeaponsD.Text = "Damage"
        TabPageWeaponsD.UseVisualStyleBackColor = True
        ' 
        ' GroupBoxWeaponsD
        ' 
        GroupBoxWeaponsD.Controls.Add(BG3Editor_Stats_VersatileDamage1)
        GroupBoxWeaponsD.Controls.Add(BG3Editor_Stats_Damage1)
        GroupBoxWeaponsD.Controls.Add(BG3Editor_Stats_Damage_Type1)
        GroupBoxWeaponsD.Controls.Add(BG3Editor_Stats_DamageRange1)
        GroupBoxWeaponsD.Controls.Add(BG3Editor_Stats_WeaponRange1)
        GroupBoxWeaponsD.Dock = DockStyle.Fill
        GroupBoxWeaponsD.Location = New Point(0, 0)
        GroupBoxWeaponsD.Margin = New Padding(0)
        GroupBoxWeaponsD.Name = "GroupBoxWeaponsD"
        GroupBoxWeaponsD.Size = New Size(384, 229)
        GroupBoxWeaponsD.TabIndex = 0
        GroupBoxWeaponsD.TabStop = False
        ' 
        ' BG3Editor_Stats_VersatileDamage1
        ' 
        BG3Editor_Stats_VersatileDamage1.Label = "Versatile damage"
        BG3Editor_Stats_VersatileDamage1.Location = New Point(3, 61)
        BG3Editor_Stats_VersatileDamage1.Margin = New Padding(0)
        BG3Editor_Stats_VersatileDamage1.MaximumSize = New Size(3000, 23)
        BG3Editor_Stats_VersatileDamage1.MinimumSize = New Size(100, 23)
        BG3Editor_Stats_VersatileDamage1.Name = "BG3Editor_Stats_VersatileDamage1"
        BG3Editor_Stats_VersatileDamage1.Size = New Size(377, 23)
        BG3Editor_Stats_VersatileDamage1.TabIndex = 4
        ' 
        ' BG3Editor_Stats_Damage1
        ' 
        BG3Editor_Stats_Damage1.Label = "Damage"
        BG3Editor_Stats_Damage1.Location = New Point(3, 38)
        BG3Editor_Stats_Damage1.Margin = New Padding(0)
        BG3Editor_Stats_Damage1.MaximumSize = New Size(3000, 23)
        BG3Editor_Stats_Damage1.MinimumSize = New Size(100, 23)
        BG3Editor_Stats_Damage1.Name = "BG3Editor_Stats_Damage1"
        BG3Editor_Stats_Damage1.Size = New Size(377, 23)
        BG3Editor_Stats_Damage1.TabIndex = 3
        ' 
        ' BG3Editor_Stats_Damage_Type1
        ' 
        BG3Editor_Stats_Damage_Type1.EditorType = BG3_Editor_Type.Combobox
        BG3Editor_Stats_Damage_Type1.Label = "Damage type"
        BG3Editor_Stats_Damage_Type1.Location = New Point(3, 15)
        BG3Editor_Stats_Damage_Type1.Margin = New Padding(0)
        BG3Editor_Stats_Damage_Type1.MaximumSize = New Size(3000, 23)
        BG3Editor_Stats_Damage_Type1.MinimumSize = New Size(100, 23)
        BG3Editor_Stats_Damage_Type1.Name = "BG3Editor_Stats_Damage_Type1"
        BG3Editor_Stats_Damage_Type1.Size = New Size(377, 23)
        BG3Editor_Stats_Damage_Type1.TabIndex = 2
        ' 
        ' BG3Editor_Stats_DamageRange1
        ' 
        BG3Editor_Stats_DamageRange1.EditorType = BG3_Editor_Type.NumericUpDown
        BG3Editor_Stats_DamageRange1.Label = "Damage range"
        BG3Editor_Stats_DamageRange1.Location = New Point(3, 107)
        BG3Editor_Stats_DamageRange1.Margin = New Padding(0)
        BG3Editor_Stats_DamageRange1.MaximumSize = New Size(3000, 23)
        BG3Editor_Stats_DamageRange1.MinimumSize = New Size(100, 23)
        BG3Editor_Stats_DamageRange1.Name = "BG3Editor_Stats_DamageRange1"
        BG3Editor_Stats_DamageRange1.Size = New Size(198, 23)
        BG3Editor_Stats_DamageRange1.TabIndex = 1
        ' 
        ' BG3Editor_Stats_WeaponRange1
        ' 
        BG3Editor_Stats_WeaponRange1.EditorType = BG3_Editor_Type.NumericUpDown
        BG3Editor_Stats_WeaponRange1.Label = "Weapon range"
        BG3Editor_Stats_WeaponRange1.Location = New Point(3, 84)
        BG3Editor_Stats_WeaponRange1.Margin = New Padding(0)
        BG3Editor_Stats_WeaponRange1.MaximumSize = New Size(3000, 23)
        BG3Editor_Stats_WeaponRange1.MinimumSize = New Size(100, 23)
        BG3Editor_Stats_WeaponRange1.Name = "BG3Editor_Stats_WeaponRange1"
        BG3Editor_Stats_WeaponRange1.Size = New Size(198, 23)
        BG3Editor_Stats_WeaponRange1.TabIndex = 0
        ' 
        ' TabPageWeaponsS
        ' 
        TabPageWeaponsS.Controls.Add(GroupBoxWeaponsS)
        TabPageWeaponsS.Location = New Point(4, 27)
        TabPageWeaponsS.Name = "TabPageWeaponsS"
        TabPageWeaponsS.Size = New Size(384, 229)
        TabPageWeaponsS.TabIndex = 3
        TabPageWeaponsS.Text = "Status list"
        TabPageWeaponsS.UseVisualStyleBackColor = True
        ' 
        ' BG3Editor_Complex_StatusList1
        ' 
        BG3Editor_Complex_StatusList1.Dock = DockStyle.Fill
        BG3Editor_Complex_StatusList1.Location = New Point(3, 19)
        BG3Editor_Complex_StatusList1.Name = "BG3Editor_Complex_StatusList1"
        BG3Editor_Complex_StatusList1.Size = New Size(378, 207)
        BG3Editor_Complex_StatusList1.TabIndex = 0
        ' 
        ' GroupBoxWeaponsS
        ' 
        GroupBoxWeaponsS.Controls.Add(BG3Editor_Complex_StatusList1)
        GroupBoxWeaponsS.Dock = DockStyle.Fill
        GroupBoxWeaponsS.Location = New Point(0, 0)
        GroupBoxWeaponsS.Margin = New Padding(0)
        GroupBoxWeaponsS.Name = "GroupBoxWeaponsS"
        GroupBoxWeaponsS.Size = New Size(384, 229)
        GroupBoxWeaponsS.TabIndex = 1
        GroupBoxWeaponsS.TabStop = False
        ' 
        ' Weapons_Editor
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1169, 596)
        Name = "Weapons_Editor"
        Text = "Weapons editor"
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
        GroupBoxWeapons1.ResumeLayout(False)
        TabControl2.ResumeLayout(False)
        TabPageWeaponsG.ResumeLayout(False)
        GroupBoxWeaponsG.ResumeLayout(False)
        TabPageWeaponsB.ResumeLayout(False)
        TabPageWeaponsD.ResumeLayout(False)
        GroupBoxWeaponsD.ResumeLayout(False)
        TabPageWeaponsS.ResumeLayout(False)
        GroupBoxWeaponsS.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Friend WithEvents BG3Editor_Stat_Slots_Armor1 As BG3Editor_Stats_Slots_Armor
    Friend WithEvents GroupBoxWeapons1 As GroupBox
    Friend WithEvents BG3Editor_Stats_PassivesOnEquip1 As BG3Editor_Stats_PassivesOnEquip
    Friend WithEvents BG3Editor_Stats_Boosts1 As BG3Editor_Stats_Boosts
    Friend WithEvents BG3Editor_Stats_StatusOnEquip1 As BG3Editor_Stats_StatusOnEquip
    Friend WithEvents BG3Editor_Stats_WeaponsProficiencyGroup1 As BG3Editor_Stats_WeaponProficiency
    Friend WithEvents BG3Editor_Stats_PassivesOnEquip_MainHand1 As BG3Editor_Stats_PassivesOnEquip_MainHand
    Friend WithEvents BG3Editor_Stats_PassivesOnEquip_OffHand1 As BG3Editor_Stats_PassivesOnEquip_OffHand
    Friend WithEvents BG3Editor_Stats_BoostsOnEquipOffHand1 As BG3Editor_Stats_BoostsOnEquipOffHand
    Friend WithEvents BG3Editor_Stats_BoostsOnEquipMainHand1 As BG3Editor_Stats_BoostsOnEquipMainHand
    Friend WithEvents TabControl2 As TabControl
    Friend WithEvents TabPageWeaponsB As TabPage
    Friend WithEvents TabPageWeaponsD As TabPage
    Friend WithEvents TabPageWeaponsG As TabPage
    Friend WithEvents GroupBoxWeaponsG As GroupBox
    Friend WithEvents BG3Editor_Stats_DefaultBoosts1 As BG3Editor_Stats_DefaultBoosts
    Friend WithEvents BG3Editor_Stats_WeaponFunctors1 As BG3Editor_Stats_WeaponFunctors
    Friend WithEvents BG3Editor_Stats_WeaponGroup1 As BG3Editor_Stats_WeaponGroup
    Friend WithEvents BG3Editor_Stats_WeaponProperties1 As BG3Editor_Stats_WeaponProperties
    Friend WithEvents GroupBoxWeaponsD As GroupBox
    Friend WithEvents BG3Editor_Stats_DamageRange1 As BG3Editor_Stats_DamageRange
    Friend WithEvents BG3Editor_Stats_WeaponRange1 As BG3Editor_Stats_WeaponRange
    Friend WithEvents BG3Editor_Stats_VersatileDamage1 As BG3Editor_Stats_VersatileDamage
    Friend WithEvents BG3Editor_Stats_Damage1 As BG3Editor_Stats_Damage
    Friend WithEvents BG3Editor_Stats_Damage_Type1 As BG3Editor_Stats_Damage_Type
    Friend WithEvents BG3Editor_Template_EquipmenTypeId1 As BG3Editor_Template_EquipmentTypeID
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TabPageWeaponsS As TabPage
    Friend WithEvents BG3Editor_Complex_StatusList1 As BG3Editor_Complex_StatusList
    Friend WithEvents GroupBoxWeaponsS As GroupBox
End Class
