<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Containers_Editor
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
        GroupBox1 = New GroupBox()
        TextBoxType = New TextBox()
        Label9 = New Label()
        CheckBoxVisual = New CheckBox()
        TextBoxParent = New TextBox()
        TextBoxVisual = New TextBox()
        Label8 = New Label()
        Label3 = New Label()
        TextboxUUID = New TextBox()
        Label2 = New Label()
        TextBoxName = New TextBox()
        Label1 = New Label()
        GroupBox2 = New GroupBox()
        CheckBoxautosort = New CheckBox()
        TextBoxAutosort = New TextBox()
        Label10 = New Label()
        CheckBoxIcon = New CheckBox()
        CheckBoxTechnical = New CheckBox()
        TextBoxIcon = New TextBox()
        Label7 = New Label()
        CheckBoxDescription = New CheckBox()
        TextBoxTechnical = New TextBox()
        Label6 = New Label()
        CheckBoxDisplayName = New CheckBox()
        TextBoxDescription = New TextBox()
        Label5 = New Label()
        TextBoxDisplayName = New TextBox()
        Label4 = New Label()
        ListBox1 = New ListBox()
        ButtonSave = New Button()
        ButtonNew = New Button()
        ButtonEdit = New Button()
        ButtonCancel = New Button()
        GroupBox3 = New GroupBox()
        TabControl1 = New TabControl()
        TabPage1 = New TabPage()
        GroupBox4 = New GroupBox()
        Label15 = New Label()
        NumericUpDownValue = New NumericUpDown()
        Label14 = New Label()
        TextBoxTreasure = New TextBox()
        Label13 = New Label()
        NumericUpDownWeight = New NumericUpDown()
        ComboBoxRarity = New ComboBox()
        Label12 = New Label()
        TextBoxStatName = New TextBox()
        Label11 = New Label()
        TabPage2 = New TabPage()
        LocaTemplate1 = New BG3Editor_Complex_Localization()
        TabPage3 = New TabPage()
        WorldInjectTemplate1 = New BG3Editor_Complex_WorldInjection()
        PictureBox3 = New PictureBox()
        LabelInfoName = New Label()
        LabelInfoDescription = New Label()
        GroupBox1.SuspendLayout()
        GroupBox2.SuspendLayout()
        GroupBox3.SuspendLayout()
        TabControl1.SuspendLayout()
        TabPage1.SuspendLayout()
        GroupBox4.SuspendLayout()
        CType(NumericUpDownValue, ComponentModel.ISupportInitialize).BeginInit()
        CType(NumericUpDownWeight, ComponentModel.ISupportInitialize).BeginInit()
        TabPage2.SuspendLayout()
        TabPage3.SuspendLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(TextBoxType)
        GroupBox1.Controls.Add(Label9)
        GroupBox1.Controls.Add(CheckBoxVisual)
        GroupBox1.Controls.Add(TextBoxParent)
        GroupBox1.Controls.Add(TextBoxVisual)
        GroupBox1.Controls.Add(Label8)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(TextboxUUID)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(TextBoxName)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Location = New Point(6, 6)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(404, 170)
        GroupBox1.TabIndex = 0
        GroupBox1.TabStop = False
        GroupBox1.Text = "Template"
        ' 
        ' TextBoxType
        ' 
        TextBoxType.Location = New Point(116, 106)
        TextBoxType.Name = "TextBoxType"
        TextBoxType.ReadOnly = True
        TextBoxType.Size = New Size(282, 23)
        TextBoxType.TabIndex = 14
        ' 
        ' Label9
        ' 
        Label9.Location = New Point(6, 106)
        Label9.Name = "Label9"
        Label9.Size = New Size(95, 23)
        Label9.TabIndex = 15
        Label9.Text = "Type"
        Label9.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' CheckBoxVisual
        ' 
        CheckBoxVisual.AutoSize = True
        CheckBoxVisual.Location = New Point(95, 140)
        CheckBoxVisual.Name = "CheckBoxVisual"
        CheckBoxVisual.Size = New Size(15, 14)
        CheckBoxVisual.TabIndex = 13
        CheckBoxVisual.UseVisualStyleBackColor = True
        ' 
        ' TextBoxParent
        ' 
        TextBoxParent.AllowDrop = True
        TextBoxParent.Location = New Point(116, 77)
        TextBoxParent.Name = "TextBoxParent"
        TextBoxParent.ReadOnly = True
        TextBoxParent.Size = New Size(282, 23)
        TextBoxParent.TabIndex = 6
        ' 
        ' TextBoxVisual
        ' 
        TextBoxVisual.AllowDrop = True
        TextBoxVisual.Location = New Point(116, 135)
        TextBoxVisual.Name = "TextBoxVisual"
        TextBoxVisual.ReadOnly = True
        TextBoxVisual.Size = New Size(282, 23)
        TextBoxVisual.TabIndex = 11
        ' 
        ' Label8
        ' 
        Label8.Location = New Point(6, 135)
        Label8.Name = "Label8"
        Label8.Size = New Size(83, 23)
        Label8.TabIndex = 12
        Label8.Text = "Visual temp."
        Label8.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label3
        ' 
        Label3.Location = New Point(6, 77)
        Label3.Name = "Label3"
        Label3.Size = New Size(95, 23)
        Label3.TabIndex = 7
        Label3.Text = "Template parent"
        Label3.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' TextboxUUID
        ' 
        TextboxUUID.Location = New Point(116, 48)
        TextboxUUID.Name = "TextboxUUID"
        TextboxUUID.ReadOnly = True
        TextboxUUID.Size = New Size(282, 23)
        TextboxUUID.TabIndex = 4
        ' 
        ' Label2
        ' 
        Label2.Location = New Point(6, 48)
        Label2.Name = "Label2"
        Label2.Size = New Size(95, 23)
        Label2.TabIndex = 5
        Label2.Text = "Template UUID"
        Label2.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' TextBoxName
        ' 
        TextBoxName.Location = New Point(116, 19)
        TextBoxName.Name = "TextBoxName"
        TextBoxName.Size = New Size(282, 23)
        TextBoxName.TabIndex = 2
        ' 
        ' Label1
        ' 
        Label1.Location = New Point(6, 19)
        Label1.Name = "Label1"
        Label1.Size = New Size(95, 23)
        Label1.TabIndex = 3
        Label1.Text = "Template name"
        Label1.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(CheckBoxautosort)
        GroupBox2.Controls.Add(TextBoxAutosort)
        GroupBox2.Controls.Add(Label10)
        GroupBox2.Controls.Add(CheckBoxIcon)
        GroupBox2.Controls.Add(CheckBoxTechnical)
        GroupBox2.Controls.Add(TextBoxIcon)
        GroupBox2.Controls.Add(Label7)
        GroupBox2.Controls.Add(CheckBoxDescription)
        GroupBox2.Controls.Add(TextBoxTechnical)
        GroupBox2.Controls.Add(Label6)
        GroupBox2.Controls.Add(CheckBoxDisplayName)
        GroupBox2.Controls.Add(TextBoxDescription)
        GroupBox2.Controls.Add(Label5)
        GroupBox2.Controls.Add(TextBoxDisplayName)
        GroupBox2.Controls.Add(Label4)
        GroupBox2.Location = New Point(6, 182)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(404, 175)
        GroupBox2.TabIndex = 1
        GroupBox2.TabStop = False
        GroupBox2.Text = "Basic attributes"
        ' 
        ' CheckBoxautosort
        ' 
        CheckBoxautosort.AutoSize = True
        CheckBoxautosort.Location = New Point(95, 143)
        CheckBoxautosort.Name = "CheckBoxautosort"
        CheckBoxautosort.Size = New Size(15, 14)
        CheckBoxautosort.TabIndex = 22
        CheckBoxautosort.UseVisualStyleBackColor = True
        ' 
        ' TextBoxAutosort
        ' 
        TextBoxAutosort.Location = New Point(116, 138)
        TextBoxAutosort.Name = "TextBoxAutosort"
        TextBoxAutosort.ReadOnly = True
        TextBoxAutosort.Size = New Size(282, 23)
        TextBoxAutosort.TabIndex = 20
        ' 
        ' Label10
        ' 
        Label10.Location = New Point(6, 138)
        Label10.Name = "Label10"
        Label10.Size = New Size(83, 23)
        Label10.TabIndex = 21
        Label10.Text = "Auto Pickup"
        Label10.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' CheckBoxIcon
        ' 
        CheckBoxIcon.AutoSize = True
        CheckBoxIcon.Location = New Point(95, 114)
        CheckBoxIcon.Name = "CheckBoxIcon"
        CheckBoxIcon.Size = New Size(15, 14)
        CheckBoxIcon.TabIndex = 19
        CheckBoxIcon.UseVisualStyleBackColor = True
        ' 
        ' CheckBoxTechnical
        ' 
        CheckBoxTechnical.AutoSize = True
        CheckBoxTechnical.Location = New Point(95, 85)
        CheckBoxTechnical.Name = "CheckBoxTechnical"
        CheckBoxTechnical.Size = New Size(15, 14)
        CheckBoxTechnical.TabIndex = 16
        CheckBoxTechnical.UseVisualStyleBackColor = True
        ' 
        ' TextBoxIcon
        ' 
        TextBoxIcon.AllowDrop = True
        TextBoxIcon.Location = New Point(116, 109)
        TextBoxIcon.Name = "TextBoxIcon"
        TextBoxIcon.ReadOnly = True
        TextBoxIcon.Size = New Size(282, 23)
        TextBoxIcon.TabIndex = 17
        ' 
        ' Label7
        ' 
        Label7.Location = New Point(6, 109)
        Label7.Name = "Label7"
        Label7.Size = New Size(83, 23)
        Label7.TabIndex = 18
        Label7.Text = "Icon"
        Label7.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' CheckBoxDescription
        ' 
        CheckBoxDescription.AutoSize = True
        CheckBoxDescription.Location = New Point(95, 56)
        CheckBoxDescription.Name = "CheckBoxDescription"
        CheckBoxDescription.Size = New Size(15, 14)
        CheckBoxDescription.TabIndex = 13
        CheckBoxDescription.UseVisualStyleBackColor = True
        ' 
        ' TextBoxTechnical
        ' 
        TextBoxTechnical.Location = New Point(116, 80)
        TextBoxTechnical.Name = "TextBoxTechnical"
        TextBoxTechnical.ReadOnly = True
        TextBoxTechnical.Size = New Size(282, 23)
        TextBoxTechnical.TabIndex = 14
        ' 
        ' Label6
        ' 
        Label6.Location = New Point(6, 80)
        Label6.Name = "Label6"
        Label6.Size = New Size(83, 23)
        Label6.TabIndex = 15
        Label6.Text = "Technical"
        Label6.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' CheckBoxDisplayName
        ' 
        CheckBoxDisplayName.AutoSize = True
        CheckBoxDisplayName.Location = New Point(95, 27)
        CheckBoxDisplayName.Name = "CheckBoxDisplayName"
        CheckBoxDisplayName.Size = New Size(15, 14)
        CheckBoxDisplayName.TabIndex = 10
        CheckBoxDisplayName.UseVisualStyleBackColor = True
        ' 
        ' TextBoxDescription
        ' 
        TextBoxDescription.Location = New Point(116, 51)
        TextBoxDescription.Name = "TextBoxDescription"
        TextBoxDescription.ReadOnly = True
        TextBoxDescription.Size = New Size(282, 23)
        TextBoxDescription.TabIndex = 11
        ' 
        ' Label5
        ' 
        Label5.Location = New Point(6, 51)
        Label5.Name = "Label5"
        Label5.Size = New Size(83, 23)
        Label5.TabIndex = 12
        Label5.Text = "Description"
        Label5.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' TextBoxDisplayName
        ' 
        TextBoxDisplayName.Location = New Point(116, 22)
        TextBoxDisplayName.Name = "TextBoxDisplayName"
        TextBoxDisplayName.ReadOnly = True
        TextBoxDisplayName.Size = New Size(282, 23)
        TextBoxDisplayName.TabIndex = 8
        ' 
        ' Label4
        ' 
        Label4.Location = New Point(6, 22)
        Label4.Name = "Label4"
        Label4.Size = New Size(83, 23)
        Label4.TabIndex = 9
        Label4.Text = "Display Name"
        Label4.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' ListBox1
        ' 
        ListBox1.FormattingEnabled = True
        ListBox1.ItemHeight = 15
        ListBox1.Location = New Point(2, 4)
        ListBox1.Name = "ListBox1"
        ListBox1.Size = New Size(198, 394)
        ListBox1.TabIndex = 2
        ' 
        ' ButtonSave
        ' 
        ButtonSave.Enabled = False
        ButtonSave.Location = New Point(5, 53)
        ButtonSave.Name = "ButtonSave"
        ButtonSave.Size = New Size(81, 25)
        ButtonSave.TabIndex = 27
        ButtonSave.Text = "Save"
        ButtonSave.UseVisualStyleBackColor = True
        ' 
        ' ButtonNew
        ' 
        ButtonNew.Location = New Point(5, 22)
        ButtonNew.Name = "ButtonNew"
        ButtonNew.Size = New Size(81, 25)
        ButtonNew.TabIndex = 26
        ButtonNew.Text = "New"
        ButtonNew.UseVisualStyleBackColor = True
        ' 
        ' ButtonEdit
        ' 
        ButtonEdit.Enabled = False
        ButtonEdit.Location = New Point(111, 22)
        ButtonEdit.Name = "ButtonEdit"
        ButtonEdit.Size = New Size(81, 25)
        ButtonEdit.TabIndex = 25
        ButtonEdit.Text = "Edit"
        ButtonEdit.UseVisualStyleBackColor = True
        ' 
        ' ButtonCancel
        ' 
        ButtonCancel.Enabled = False
        ButtonCancel.Location = New Point(111, 53)
        ButtonCancel.Name = "ButtonCancel"
        ButtonCancel.Size = New Size(81, 25)
        ButtonCancel.TabIndex = 28
        ButtonCancel.Text = "Cancel"
        ButtonCancel.UseVisualStyleBackColor = True
        ' 
        ' GroupBox3
        ' 
        GroupBox3.Controls.Add(ButtonNew)
        GroupBox3.Controls.Add(ButtonCancel)
        GroupBox3.Controls.Add(ButtonEdit)
        GroupBox3.Controls.Add(ButtonSave)
        GroupBox3.Location = New Point(2, 395)
        GroupBox3.Name = "GroupBox3"
        GroupBox3.Size = New Size(198, 83)
        GroupBox3.TabIndex = 29
        GroupBox3.TabStop = False
        ' 
        ' TabControl1
        ' 
        TabControl1.Appearance = TabAppearance.FlatButtons
        TabControl1.Controls.Add(TabPage1)
        TabControl1.Controls.Add(TabPage2)
        TabControl1.Controls.Add(TabPage3)
        TabControl1.Location = New Point(206, 4)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(882, 394)
        TabControl1.SizeMode = TabSizeMode.Fixed
        TabControl1.TabIndex = 31
        ' 
        ' TabPage1
        ' 
        TabPage1.BackColor = Color.Transparent
        TabPage1.Controls.Add(GroupBox4)
        TabPage1.Controls.Add(GroupBox1)
        TabPage1.Controls.Add(GroupBox2)
        TabPage1.Location = New Point(4, 27)
        TabPage1.Name = "TabPage1"
        TabPage1.Padding = New Padding(3)
        TabPage1.Size = New Size(874, 363)
        TabPage1.TabIndex = 0
        TabPage1.Text = "Main"
        ' 
        ' GroupBox4
        ' 
        GroupBox4.Controls.Add(Label15)
        GroupBox4.Controls.Add(NumericUpDownValue)
        GroupBox4.Controls.Add(Label14)
        GroupBox4.Controls.Add(TextBoxTreasure)
        GroupBox4.Controls.Add(Label13)
        GroupBox4.Controls.Add(NumericUpDownWeight)
        GroupBox4.Controls.Add(ComboBoxRarity)
        GroupBox4.Controls.Add(Label12)
        GroupBox4.Controls.Add(TextBoxStatName)
        GroupBox4.Controls.Add(Label11)
        GroupBox4.Location = New Point(416, 6)
        GroupBox4.Name = "GroupBox4"
        GroupBox4.Size = New Size(452, 170)
        GroupBox4.TabIndex = 2
        GroupBox4.TabStop = False
        GroupBox4.Text = "Stat attributes"
        ' 
        ' Label15
        ' 
        Label15.Location = New Point(6, 106)
        Label15.Name = "Label15"
        Label15.Size = New Size(67, 23)
        Label15.TabIndex = 15
        Label15.Text = "Value"
        Label15.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' NumericUpDownValue
        ' 
        NumericUpDownValue.Location = New Point(117, 106)
        NumericUpDownValue.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        NumericUpDownValue.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        NumericUpDownValue.Name = "NumericUpDownValue"
        NumericUpDownValue.Size = New Size(93, 23)
        NumericUpDownValue.TabIndex = 14
        NumericUpDownValue.TextAlign = HorizontalAlignment.Right
        NumericUpDownValue.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' Label14
        ' 
        Label14.Location = New Point(6, 135)
        Label14.Name = "Label14"
        Label14.Size = New Size(95, 23)
        Label14.TabIndex = 13
        Label14.Text = "Treasure table"
        Label14.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' TextBoxTreasure
        ' 
        TextBoxTreasure.AllowDrop = True
        TextBoxTreasure.Location = New Point(117, 135)
        TextBoxTreasure.Name = "TextBoxTreasure"
        TextBoxTreasure.ReadOnly = True
        TextBoxTreasure.Size = New Size(329, 23)
        TextBoxTreasure.TabIndex = 12
        ' 
        ' Label13
        ' 
        Label13.Location = New Point(6, 77)
        Label13.Name = "Label13"
        Label13.Size = New Size(95, 23)
        Label13.TabIndex = 10
        Label13.Text = "Weight"
        Label13.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' NumericUpDownWeight
        ' 
        NumericUpDownWeight.DecimalPlaces = 2
        NumericUpDownWeight.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        NumericUpDownWeight.Location = New Point(117, 77)
        NumericUpDownWeight.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        NumericUpDownWeight.Minimum = New Decimal(New Integer() {1, 0, 0, 131072})
        NumericUpDownWeight.Name = "NumericUpDownWeight"
        NumericUpDownWeight.Size = New Size(93, 23)
        NumericUpDownWeight.TabIndex = 9
        NumericUpDownWeight.TextAlign = HorizontalAlignment.Right
        NumericUpDownWeight.Value = New Decimal(New Integer() {1, 0, 0, 131072})
        ' 
        ' ComboBoxRarity
        ' 
        ComboBoxRarity.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBoxRarity.Enabled = False
        ComboBoxRarity.FormattingEnabled = True
        ComboBoxRarity.Items.AddRange(New Object() {"Common", "Uncommon", "Rare", "Epic", "Legendary", "Divine", "Unique"})
        ComboBoxRarity.Location = New Point(117, 49)
        ComboBoxRarity.Name = "ComboBoxRarity"
        ComboBoxRarity.Size = New Size(329, 23)
        ComboBoxRarity.TabIndex = 8
        ' 
        ' Label12
        ' 
        Label12.Location = New Point(6, 48)
        Label12.Name = "Label12"
        Label12.Size = New Size(95, 23)
        Label12.TabIndex = 7
        Label12.Text = "Rarity"
        Label12.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' TextBoxStatName
        ' 
        TextBoxStatName.Location = New Point(117, 20)
        TextBoxStatName.Name = "TextBoxStatName"
        TextBoxStatName.ReadOnly = True
        TextBoxStatName.Size = New Size(329, 23)
        TextBoxStatName.TabIndex = 4
        ' 
        ' Label11
        ' 
        Label11.Location = New Point(6, 19)
        Label11.Name = "Label11"
        Label11.Size = New Size(95, 23)
        Label11.TabIndex = 5
        Label11.Text = "Stat Name"
        Label11.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' TabPage2
        ' 
        TabPage2.BackColor = Color.Transparent
        TabPage2.Controls.Add(LocaTemplate1)
        TabPage2.Location = New Point(4, 27)
        TabPage2.Name = "TabPage2"
        TabPage2.Padding = New Padding(3)
        TabPage2.Size = New Size(874, 363)
        TabPage2.TabIndex = 1
        TabPage2.Text = "Localization"
        ' 
        ' LocaTemplate1
        ' 
        LocaTemplate1.Dock = DockStyle.Fill
        LocaTemplate1.Location = New Point(3, 3)
        LocaTemplate1.Name = "LocaTemplate1"
        LocaTemplate1.Size = New Size(868, 357)
        LocaTemplate1.TabIndex = 31
        ' 
        ' TabPage3
        ' 
        TabPage3.Controls.Add(WorldInjectTemplate1)
        TabPage3.Location = New Point(4, 27)
        TabPage3.Name = "TabPage3"
        TabPage3.Size = New Size(874, 363)
        TabPage3.TabIndex = 2
        TabPage3.Text = "World Injection"
        TabPage3.UseVisualStyleBackColor = True
        ' 
        ' WorldInjectTemplate1
        ' 
        WorldInjectTemplate1.Dock = DockStyle.Fill
        WorldInjectTemplate1.Location = New Point(0, 0)
        WorldInjectTemplate1.Name = "WorldInjectTemplate1"
        WorldInjectTemplate1.Size = New Size(874, 363)
        WorldInjectTemplate1.TabIndex = 0
        ' 
        ' PictureBox3
        ' 
        PictureBox3.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        PictureBox3.Location = New Point(206, 425)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(48, 48)
        PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox3.TabIndex = 32
        PictureBox3.TabStop = False
        ' 
        ' LabelInfoName
        ' 
        LabelInfoName.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LabelInfoName.AutoEllipsis = True
        LabelInfoName.Location = New Point(260, 425)
        LabelInfoName.Name = "LabelInfoName"
        LabelInfoName.Size = New Size(824, 23)
        LabelInfoName.TabIndex = 33
        LabelInfoName.Text = "Name:"
        LabelInfoName.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' LabelInfoDescription
        ' 
        LabelInfoDescription.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LabelInfoDescription.AutoEllipsis = True
        LabelInfoDescription.Location = New Point(260, 450)
        LabelInfoDescription.Name = "LabelInfoDescription"
        LabelInfoDescription.Size = New Size(824, 23)
        LabelInfoDescription.TabIndex = 34
        LabelInfoDescription.Text = "Description:"
        LabelInfoDescription.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Containers_Editor
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1100, 484)
        Controls.Add(LabelInfoDescription)
        Controls.Add(LabelInfoName)
        Controls.Add(PictureBox3)
        Controls.Add(TabControl1)
        Controls.Add(ListBox1)
        Controls.Add(GroupBox3)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Name = "Containers_Editor"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Containers Editor"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        GroupBox3.ResumeLayout(False)
        TabControl1.ResumeLayout(False)
        TabPage1.ResumeLayout(False)
        GroupBox4.ResumeLayout(False)
        GroupBox4.PerformLayout()
        CType(NumericUpDownValue, ComponentModel.ISupportInitialize).EndInit()
        CType(NumericUpDownWeight, ComponentModel.ISupportInitialize).EndInit()
        TabPage2.ResumeLayout(False)
        TabPage3.ResumeLayout(False)
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TextBoxParent As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TextboxUUID As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBoxName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents CheckBoxDisplayName As CheckBox
    Friend WithEvents TextBoxDisplayName As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents CheckBoxDescription As CheckBox
    Friend WithEvents TextBoxDescription As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents CheckBoxVisual As CheckBox
    Friend WithEvents TextBoxVisual As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents CheckBoxIcon As CheckBox
    Friend WithEvents CheckBoxTechnical As CheckBox
    Friend WithEvents TextBoxIcon As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TextBoxTechnical As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TextBoxType As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents ButtonSave As Button
    Friend WithEvents ButtonNew As Button
    Friend WithEvents ButtonEdit As Button
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents LocaTemplate1 As BG3Editor_Complex_Localization
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents CheckBoxautosort As CheckBox
    Friend WithEvents TextBoxAutosort As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents TextBoxStatName As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents ComboBoxRarity As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents NumericUpDownWeight As NumericUpDown
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents WorldInjectTemplate1 As BG3Editor_Complex_WorldInjection
    Friend WithEvents LabelInfoName As Label
    Friend WithEvents LabelInfoDescription As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents TextBoxTreasure As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents NumericUpDownValue As NumericUpDown
End Class
