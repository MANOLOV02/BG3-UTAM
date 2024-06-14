<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UtamMod
    Inherits ExploraForm_code

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        TabControl1 = New TabControl()
        LSXCode = New TabPage()
        XmLtoRichText1 = New BG3Visualizer_XML()
        GroupBox3 = New GroupBox()
        ButtonCancel = New Button()
        ButtonSave = New Button()
        ButtonEdit = New Button()
        GroupBox2 = New GroupBox()
        Label11 = New Label()
        TextBoxName = New TextBox()
        NumericUpDown4 = New NumericUpDown()
        Label1 = New Label()
        Label10 = New Label()
        Label2 = New Label()
        NumericUpDown3 = New NumericUpDown()
        TextBoxFolder = New TextBox()
        Label9 = New Label()
        Label3 = New Label()
        NumericUpDown2 = New NumericUpDown()
        TextBoxDescription = New TextBox()
        Label8 = New Label()
        Label4 = New Label()
        NumericUpDown1 = New NumericUpDown()
        TextBoxAuthor = New TextBox()
        TextBoxVersion = New TextBox()
        Label5 = New Label()
        Label7 = New Label()
        TextBoxUUID = New TextBox()
        GroupBox1 = New GroupBox()
        Label6 = New Label()
        NumericUpDownPriority = New NumericUpDown()
        CheckBoxModFixer = New CheckBox()
        CheckBoxmultitoolcomp = New CheckBox()
        CheckBoxBuildzip = New CheckBox()
        CheckBoxBuildpak = New CheckBox()
        CheckBoxAddtogame = New CheckBox()
        TabControl1.SuspendLayout()
        LSXCode.SuspendLayout()
        GroupBox3.SuspendLayout()
        GroupBox2.SuspendLayout()
        CType(NumericUpDown4, ComponentModel.ISupportInitialize).BeginInit()
        CType(NumericUpDown3, ComponentModel.ISupportInitialize).BeginInit()
        CType(NumericUpDown2, ComponentModel.ISupportInitialize).BeginInit()
        CType(NumericUpDown1, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        CType(NumericUpDownPriority, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TabControl1
        ' 
        TabControl1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        TabControl1.Appearance = TabAppearance.FlatButtons
        TabControl1.Controls.Add(LSXCode)
        TabControl1.Location = New Point(410, 3)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(531, 424)
        TabControl1.SizeMode = TabSizeMode.Fixed
        TabControl1.TabIndex = 0
        ' 
        ' LSXCode
        ' 
        LSXCode.BackColor = Color.Transparent
        LSXCode.BorderStyle = BorderStyle.FixedSingle
        LSXCode.Controls.Add(XmLtoRichText1)
        LSXCode.Location = New Point(4, 27)
        LSXCode.Name = "LSXCode"
        LSXCode.Size = New Size(523, 393)
        LSXCode.TabIndex = 1
        LSXCode.Text = "LSX Code"
        ' 
        ' XmLtoRichText1
        ' 
        XmLtoRichText1.BorderStyle = BorderStyle.None
        XmLtoRichText1.Dock = DockStyle.Fill
        XmLtoRichText1.IndentedText = True
        XmLtoRichText1.Location = New Point(0, 0)
        XmLtoRichText1.Name = "XmLtoRichText1"
        XmLtoRichText1.NamesColor = Color.Brown
        XmLtoRichText1.NodesColor = Color.Black
        XmLtoRichText1.Overridedolor = Color.Gray
        XmLtoRichText1.ReadOnly = True
        XmLtoRichText1.Size = New Size(521, 391)
        XmLtoRichText1.TabIndex = 0
        XmLtoRichText1.Text = ""
        XmLtoRichText1.ValueColor = Color.Blue
        XmLtoRichText1.WordWrap = False
        ' 
        ' GroupBox3
        ' 
        GroupBox3.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        GroupBox3.Controls.Add(ButtonCancel)
        GroupBox3.Controls.Add(ButtonSave)
        GroupBox3.Controls.Add(ButtonEdit)
        GroupBox3.Location = New Point(2, 355)
        GroupBox3.Name = "GroupBox3"
        GroupBox3.Size = New Size(402, 68)
        GroupBox3.TabIndex = 30
        GroupBox3.TabStop = False
        GroupBox3.Text = "Actions"
        ' 
        ' ButtonCancel
        ' 
        ButtonCancel.Enabled = False
        ButtonCancel.Location = New Point(290, 22)
        ButtonCancel.Name = "ButtonCancel"
        ButtonCancel.Size = New Size(96, 39)
        ButtonCancel.TabIndex = 24
        ButtonCancel.Text = "Cancel"
        ButtonCancel.UseVisualStyleBackColor = True
        ' 
        ' ButtonSave
        ' 
        ButtonSave.Enabled = False
        ButtonSave.Location = New Point(147, 23)
        ButtonSave.Name = "ButtonSave"
        ButtonSave.Size = New Size(96, 39)
        ButtonSave.TabIndex = 23
        ButtonSave.Text = "Save"
        ButtonSave.UseVisualStyleBackColor = True
        ' 
        ' ButtonEdit
        ' 
        ButtonEdit.Location = New Point(4, 23)
        ButtonEdit.Name = "ButtonEdit"
        ButtonEdit.Size = New Size(96, 39)
        ButtonEdit.TabIndex = 22
        ButtonEdit.Text = "Edit"
        ButtonEdit.UseVisualStyleBackColor = True
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(Label11)
        GroupBox2.Controls.Add(TextBoxName)
        GroupBox2.Controls.Add(NumericUpDown4)
        GroupBox2.Controls.Add(Label1)
        GroupBox2.Controls.Add(Label10)
        GroupBox2.Controls.Add(Label2)
        GroupBox2.Controls.Add(NumericUpDown3)
        GroupBox2.Controls.Add(TextBoxFolder)
        GroupBox2.Controls.Add(Label9)
        GroupBox2.Controls.Add(Label3)
        GroupBox2.Controls.Add(NumericUpDown2)
        GroupBox2.Controls.Add(TextBoxDescription)
        GroupBox2.Controls.Add(Label8)
        GroupBox2.Controls.Add(Label4)
        GroupBox2.Controls.Add(NumericUpDown1)
        GroupBox2.Controls.Add(TextBoxAuthor)
        GroupBox2.Controls.Add(TextBoxVersion)
        GroupBox2.Controls.Add(Label5)
        GroupBox2.Controls.Add(Label7)
        GroupBox2.Controls.Add(TextBoxUUID)
        GroupBox2.Enabled = False
        GroupBox2.Location = New Point(2, 3)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(402, 248)
        GroupBox2.TabIndex = 29
        GroupBox2.TabStop = False
        GroupBox2.Text = "Definitions"
        ' 
        ' Label11
        ' 
        Label11.Location = New Point(331, 191)
        Label11.Name = "Label11"
        Label11.Size = New Size(53, 23)
        Label11.TabIndex = 21
        Label11.Text = "Build"
        Label11.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' TextBoxName
        ' 
        TextBoxName.Location = New Point(106, 22)
        TextBoxName.Name = "TextBoxName"
        TextBoxName.Size = New Size(282, 23)
        TextBoxName.TabIndex = 1
        ' 
        ' NumericUpDown4
        ' 
        NumericUpDown4.Location = New Point(331, 215)
        NumericUpDown4.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        NumericUpDown4.Name = "NumericUpDown4"
        NumericUpDown4.Size = New Size(53, 23)
        NumericUpDown4.TabIndex = 20
        NumericUpDown4.TextAlign = HorizontalAlignment.Right
        ' 
        ' Label1
        ' 
        Label1.Location = New Point(5, 22)
        Label1.Name = "Label1"
        Label1.Size = New Size(95, 23)
        Label1.TabIndex = 1
        Label1.Text = "Mod name"
        Label1.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label10
        ' 
        Label10.Location = New Point(261, 191)
        Label10.Name = "Label10"
        Label10.Size = New Size(53, 23)
        Label10.TabIndex = 19
        Label10.Text = "Revision"
        Label10.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label2
        ' 
        Label2.Location = New Point(5, 51)
        Label2.Name = "Label2"
        Label2.Size = New Size(95, 23)
        Label2.TabIndex = 3
        Label2.Text = "Mod folder"
        Label2.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' NumericUpDown3
        ' 
        NumericUpDown3.Location = New Point(261, 215)
        NumericUpDown3.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        NumericUpDown3.Name = "NumericUpDown3"
        NumericUpDown3.Size = New Size(53, 23)
        NumericUpDown3.TabIndex = 18
        NumericUpDown3.TextAlign = HorizontalAlignment.Right
        ' 
        ' TextBoxFolder
        ' 
        TextBoxFolder.Location = New Point(106, 51)
        TextBoxFolder.Name = "TextBoxFolder"
        TextBoxFolder.Size = New Size(282, 23)
        TextBoxFolder.TabIndex = 2
        ' 
        ' Label9
        ' 
        Label9.Location = New Point(191, 191)
        Label9.Name = "Label9"
        Label9.Size = New Size(53, 23)
        Label9.TabIndex = 17
        Label9.Text = "Minor"
        Label9.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label3
        ' 
        Label3.Location = New Point(5, 80)
        Label3.Name = "Label3"
        Label3.Size = New Size(95, 23)
        Label3.TabIndex = 5
        Label3.Text = "Description"
        Label3.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' NumericUpDown2
        ' 
        NumericUpDown2.Location = New Point(191, 215)
        NumericUpDown2.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        NumericUpDown2.Name = "NumericUpDown2"
        NumericUpDown2.Size = New Size(53, 23)
        NumericUpDown2.TabIndex = 16
        NumericUpDown2.TextAlign = HorizontalAlignment.Right
        ' 
        ' TextBoxDescription
        ' 
        TextBoxDescription.Location = New Point(106, 80)
        TextBoxDescription.Name = "TextBoxDescription"
        TextBoxDescription.Size = New Size(282, 23)
        TextBoxDescription.TabIndex = 4
        ' 
        ' Label8
        ' 
        Label8.Location = New Point(121, 191)
        Label8.Name = "Label8"
        Label8.Size = New Size(53, 23)
        Label8.TabIndex = 15
        Label8.Text = "Major"
        Label8.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label4
        ' 
        Label4.Location = New Point(5, 109)
        Label4.Name = "Label4"
        Label4.Size = New Size(95, 23)
        Label4.TabIndex = 7
        Label4.Text = "Author"
        Label4.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' NumericUpDown1
        ' 
        NumericUpDown1.Location = New Point(121, 215)
        NumericUpDown1.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        NumericUpDown1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        NumericUpDown1.Name = "NumericUpDown1"
        NumericUpDown1.Size = New Size(53, 23)
        NumericUpDown1.TabIndex = 14
        NumericUpDown1.TextAlign = HorizontalAlignment.Right
        NumericUpDown1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' TextBoxAuthor
        ' 
        TextBoxAuthor.Location = New Point(106, 109)
        TextBoxAuthor.Name = "TextBoxAuthor"
        TextBoxAuthor.Size = New Size(282, 23)
        TextBoxAuthor.TabIndex = 6
        ' 
        ' TextBoxVersion
        ' 
        TextBoxVersion.Location = New Point(105, 167)
        TextBoxVersion.Name = "TextBoxVersion"
        TextBoxVersion.ReadOnly = True
        TextBoxVersion.Size = New Size(282, 23)
        TextBoxVersion.TabIndex = 13
        ' 
        ' Label5
        ' 
        Label5.Location = New Point(5, 138)
        Label5.Name = "Label5"
        Label5.Size = New Size(95, 23)
        Label5.TabIndex = 9
        Label5.Text = "UUID"
        Label5.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label7
        ' 
        Label7.Location = New Point(4, 167)
        Label7.Name = "Label7"
        Label7.Size = New Size(95, 23)
        Label7.TabIndex = 12
        Label7.Text = "Version"
        Label7.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' TextBoxUUID
        ' 
        TextBoxUUID.Location = New Point(106, 138)
        TextBoxUUID.Name = "TextBoxUUID"
        TextBoxUUID.ReadOnly = True
        TextBoxUUID.Size = New Size(282, 23)
        TextBoxUUID.TabIndex = 8
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(Label6)
        GroupBox1.Controls.Add(NumericUpDownPriority)
        GroupBox1.Controls.Add(CheckBoxModFixer)
        GroupBox1.Controls.Add(CheckBoxmultitoolcomp)
        GroupBox1.Controls.Add(CheckBoxBuildzip)
        GroupBox1.Controls.Add(CheckBoxBuildpak)
        GroupBox1.Controls.Add(CheckBoxAddtogame)
        GroupBox1.Enabled = False
        GroupBox1.Location = New Point(2, 252)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(402, 102)
        GroupBox1.TabIndex = 28
        GroupBox1.TabStop = False
        GroupBox1.Text = "Save settings"
        ' 
        ' Label6
        ' 
        Label6.Location = New Point(10, 73)
        Label6.Name = "Label6"
        Label6.Size = New Size(89, 23)
        Label6.TabIndex = 31
        Label6.Text = "Pak priority"
        Label6.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' NumericUpDownPriority
        ' 
        NumericUpDownPriority.Location = New Point(121, 73)
        NumericUpDownPriority.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        NumericUpDownPriority.Name = "NumericUpDownPriority"
        NumericUpDownPriority.Size = New Size(71, 23)
        NumericUpDownPriority.TabIndex = 30
        NumericUpDownPriority.TextAlign = HorizontalAlignment.Right
        NumericUpDownPriority.Value = New Decimal(New Integer() {30, 0, 0, 0})
        ' 
        ' CheckBoxModFixer
        ' 
        CheckBoxModFixer.AutoSize = True
        CheckBoxModFixer.Checked = True
        CheckBoxModFixer.CheckState = CheckState.Checked
        CheckBoxModFixer.Location = New Point(210, 47)
        CheckBoxModFixer.Name = "CheckBoxModFixer"
        CheckBoxModFixer.Size = New Size(119, 19)
        CheckBoxModFixer.TabIndex = 29
        CheckBoxModFixer.Text = "Include mod fixer"
        CheckBoxModFixer.UseVisualStyleBackColor = True
        ' 
        ' CheckBoxmultitoolcomp
        ' 
        CheckBoxmultitoolcomp.AutoSize = True
        CheckBoxmultitoolcomp.Checked = True
        CheckBoxmultitoolcomp.CheckState = CheckState.Checked
        CheckBoxmultitoolcomp.Location = New Point(121, 22)
        CheckBoxmultitoolcomp.Name = "CheckBoxmultitoolcomp"
        CheckBoxmultitoolcomp.Size = New Size(208, 19)
        CheckBoxmultitoolcomp.TabIndex = 28
        CheckBoxmultitoolcomp.Text = "ShinyHobo's Multitool compatible"
        CheckBoxmultitoolcomp.UseVisualStyleBackColor = True
        ' 
        ' CheckBoxBuildzip
        ' 
        CheckBoxBuildzip.AutoSize = True
        CheckBoxBuildzip.Checked = True
        CheckBoxBuildzip.CheckState = CheckState.Checked
        CheckBoxBuildzip.Location = New Point(121, 47)
        CheckBoxBuildzip.Name = "CheckBoxBuildzip"
        CheckBoxBuildzip.Size = New Size(71, 19)
        CheckBoxBuildzip.TabIndex = 25
        CheckBoxBuildzip.Text = "Build zip"
        CheckBoxBuildzip.UseVisualStyleBackColor = True
        ' 
        ' CheckBoxBuildpak
        ' 
        CheckBoxBuildpak.AutoSize = True
        CheckBoxBuildpak.Checked = True
        CheckBoxBuildpak.CheckState = CheckState.Checked
        CheckBoxBuildpak.Location = New Point(10, 47)
        CheckBoxBuildpak.Name = "CheckBoxBuildpak"
        CheckBoxBuildpak.Size = New Size(75, 19)
        CheckBoxBuildpak.TabIndex = 26
        CheckBoxBuildpak.Text = "Build pak"
        CheckBoxBuildpak.UseVisualStyleBackColor = True
        ' 
        ' CheckBoxAddtogame
        ' 
        CheckBoxAddtogame.AutoSize = True
        CheckBoxAddtogame.Checked = True
        CheckBoxAddtogame.CheckState = CheckState.Checked
        CheckBoxAddtogame.Location = New Point(10, 22)
        CheckBoxAddtogame.Name = "CheckBoxAddtogame"
        CheckBoxAddtogame.Size = New Size(95, 19)
        CheckBoxAddtogame.TabIndex = 27
        CheckBoxAddtogame.Text = "Add to game"
        CheckBoxAddtogame.UseVisualStyleBackColor = True
        ' 
        ' UtamMod
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(944, 431)
        Controls.Add(GroupBox3)
        Controls.Add(TabControl1)
        Controls.Add(GroupBox1)
        Controls.Add(GroupBox2)
        MinimumSize = New Size(960, 470)
        Name = "UtamMod"
        StartPosition = FormStartPosition.CenterScreen
        Text = "UTAM Mod (New)"
        TabControl1.ResumeLayout(False)
        LSXCode.ResumeLayout(False)
        GroupBox3.ResumeLayout(False)
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        CType(NumericUpDown4, ComponentModel.ISupportInitialize).EndInit()
        CType(NumericUpDown3, ComponentModel.ISupportInitialize).EndInit()
        CType(NumericUpDown2, ComponentModel.ISupportInitialize).EndInit()
        CType(NumericUpDown1, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(NumericUpDownPriority, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents LSXCode As TabPage
    Friend WithEvents XmLtoRichText1 As BG3Visualizer_XML
    Friend WithEvents TextBoxVersion As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TextBoxUUID As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBoxAuthor As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBoxDescription As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBoxFolder As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBoxName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents NumericUpDown3 As NumericUpDown
    Friend WithEvents Label9 As Label
    Friend WithEvents NumericUpDown2 As NumericUpDown
    Friend WithEvents Label8 As Label
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents Label11 As Label
    Friend WithEvents NumericUpDown4 As NumericUpDown
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents ButtonSave As Button
    Friend WithEvents ButtonEdit As Button
    Friend WithEvents CheckBoxAddtogame As CheckBox
    Friend WithEvents CheckBoxBuildpak As CheckBox
    Friend WithEvents CheckBoxBuildzip As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents CheckBoxmultitoolcomp As CheckBox
    Friend WithEvents CheckBoxModFixer As CheckBox
    Friend WithEvents Label6 As Label
    Friend WithEvents NumericUpDownPriority As NumericUpDown
End Class
