<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BG3Editor_Complex_ArmorEquipment
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        TreeView1 = New TreeView()
        BG3Editor_Template_ParentRaceMapkey1 = New BG3Editor_Template_Node_ParentRaceMapkey()
        GroupboxRace = New GroupBox()
        Button3 = New Button()
        DropVisualLabel = New Label()
        Button2 = New Button()
        Button1 = New Button()
        GroupboxElement = New GroupBox()
        TableLayoutPanel1 = New TableLayoutPanel()
        RadioButton1 = New RadioButton()
        RadioButton2 = New RadioButton()
        DropArmorLabel = New Label()
        TableLayoutPanel2 = New TableLayoutPanel()
        CheckBox1 = New CheckBox()
        TabControl1 = New TabControl()
        TabPageEquip1 = New TabPage()
        TabPageEquip2 = New TabPage()
        BG3Editor_Complex_Dyecolor1 = New BG3Editor_Complex_Dyecolor()
        GroupboxRace.SuspendLayout()
        GroupboxElement.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        TabControl1.SuspendLayout()
        TabPageEquip1.SuspendLayout()
        TabPageEquip2.SuspendLayout()
        SuspendLayout()
        ' 
        ' TreeView1
        ' 
        TreeView1.Dock = DockStyle.Fill
        TreeView1.Location = New Point(3, 26)
        TreeView1.Name = "TreeView1"
        TableLayoutPanel2.SetRowSpan(TreeView1, 2)
        TreeView1.Size = New Size(462, 469)
        TreeView1.TabIndex = 0
        ' 
        ' BG3Editor_Template_ParentRaceMapkey1
        ' 
        BG3Editor_Template_ParentRaceMapkey1.DropIcon = True
        BG3Editor_Template_ParentRaceMapkey1.EditIsConditional = False
        BG3Editor_Template_ParentRaceMapkey1.KeyToRead = "MapValue"
        BG3Editor_Template_ParentRaceMapkey1.Label = "Race override"
        BG3Editor_Template_ParentRaceMapkey1.Location = New Point(3, 19)
        BG3Editor_Template_ParentRaceMapkey1.Margin = New Padding(0)
        BG3Editor_Template_ParentRaceMapkey1.MaximumSize = New Size(3000, 23)
        BG3Editor_Template_ParentRaceMapkey1.MinimumSize = New Size(100, 23)
        BG3Editor_Template_ParentRaceMapkey1.Name = "BG3Editor_Template_ParentRaceMapkey1"
        BG3Editor_Template_ParentRaceMapkey1.ReadOnly = True
        BG3Editor_Template_ParentRaceMapkey1.Size = New Size(411, 23)
        BG3Editor_Template_ParentRaceMapkey1.TabIndex = 1
        ' 
        ' GroupboxRace
        ' 
        GroupboxRace.Controls.Add(Button3)
        GroupboxRace.Controls.Add(DropVisualLabel)
        GroupboxRace.Controls.Add(Button2)
        GroupboxRace.Controls.Add(Button1)
        GroupboxRace.Controls.Add(BG3Editor_Template_ParentRaceMapkey1)
        GroupboxRace.Dock = DockStyle.Fill
        GroupboxRace.Location = New Point(471, 26)
        GroupboxRace.Name = "GroupboxRace"
        GroupboxRace.Size = New Size(417, 231)
        GroupboxRace.TabIndex = 2
        GroupboxRace.TabStop = False
        GroupboxRace.Text = "Race"
        ' 
        ' Button3
        ' 
        Button3.Dock = DockStyle.Bottom
        Button3.Location = New Point(3, 200)
        Button3.Name = "Button3"
        Button3.Size = New Size(411, 28)
        Button3.TabIndex = 5
        Button3.Text = "Delete selected"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' DropVisualLabel
        ' 
        DropVisualLabel.AllowDrop = True
        DropVisualLabel.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        DropVisualLabel.BackColor = SystemColors.Window
        DropVisualLabel.BorderStyle = BorderStyle.FixedSingle
        DropVisualLabel.Location = New Point(3, 72)
        DropVisualLabel.Name = "DropVisualLabel"
        DropVisualLabel.Size = New Size(411, 125)
        DropVisualLabel.TabIndex = 4
        DropVisualLabel.Text = "Drop an Visual template to add to current race."
        DropVisualLabel.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(143, 46)
        Button2.Name = "Button2"
        Button2.Size = New Size(117, 23)
        Button2.TabIndex = 3
        Button2.Text = "Default override"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(297, 46)
        Button1.Name = "Button1"
        Button1.Size = New Size(117, 23)
        Button1.TabIndex = 2
        Button1.Text = "Delete override"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' GroupboxElement
        ' 
        GroupboxElement.Controls.Add(TableLayoutPanel1)
        GroupboxElement.Controls.Add(DropArmorLabel)
        GroupboxElement.Dock = DockStyle.Fill
        GroupboxElement.Location = New Point(471, 263)
        GroupboxElement.Name = "GroupboxElement"
        GroupboxElement.Size = New Size(417, 232)
        GroupboxElement.TabIndex = 3
        GroupboxElement.TabStop = False
        GroupboxElement.Text = "Equipment list"
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20F))
        TableLayoutPanel1.Controls.Add(RadioButton1, 0, 0)
        TableLayoutPanel1.Controls.Add(RadioButton2, 1, 0)
        TableLayoutPanel1.Dock = DockStyle.Bottom
        TableLayoutPanel1.Location = New Point(3, 204)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Size = New Size(411, 25)
        TableLayoutPanel1.TabIndex = 1
        ' 
        ' RadioButton1
        ' 
        RadioButton1.AutoSize = True
        RadioButton1.Checked = True
        RadioButton1.Dock = DockStyle.Fill
        RadioButton1.Location = New Point(3, 3)
        RadioButton1.Name = "RadioButton1"
        RadioButton1.Size = New Size(199, 19)
        RadioButton1.TabIndex = 0
        RadioButton1.TabStop = True
        RadioButton1.Text = "Replace"
        RadioButton1.UseVisualStyleBackColor = True
        ' 
        ' RadioButton2
        ' 
        RadioButton2.AutoSize = True
        RadioButton2.Location = New Point(208, 3)
        RadioButton2.Name = "RadioButton2"
        RadioButton2.Size = New Size(59, 19)
        RadioButton2.TabIndex = 1
        RadioButton2.TabStop = True
        RadioButton2.Text = "Merge"
        RadioButton2.UseVisualStyleBackColor = True
        ' 
        ' DropArmorLabel
        ' 
        DropArmorLabel.AllowDrop = True
        DropArmorLabel.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        DropArmorLabel.BackColor = SystemColors.Window
        DropArmorLabel.BorderStyle = BorderStyle.FixedSingle
        DropArmorLabel.Location = New Point(3, 28)
        DropArmorLabel.Name = "DropArmorLabel"
        DropArmorLabel.Size = New Size(411, 173)
        DropArmorLabel.TabIndex = 0
        DropArmorLabel.Text = "Drop an armor to copy or merge equipment"
        DropArmorLabel.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.ColumnCount = 2
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 423F))
        TableLayoutPanel2.Controls.Add(TreeView1, 0, 1)
        TableLayoutPanel2.Controls.Add(GroupboxElement, 1, 2)
        TableLayoutPanel2.Controls.Add(GroupboxRace, 1, 1)
        TableLayoutPanel2.Controls.Add(CheckBox1, 0, 0)
        TableLayoutPanel2.Dock = DockStyle.Fill
        TableLayoutPanel2.Location = New Point(3, 3)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 3
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Absolute, 23F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel2.Size = New Size(891, 498)
        TableLayoutPanel2.TabIndex = 4
        ' 
        ' CheckBox1
        ' 
        CheckBox1.AutoSize = True
        CheckBox1.Location = New Point(3, 3)
        CheckBox1.Name = "CheckBox1"
        CheckBox1.Size = New Size(129, 17)
        CheckBox1.TabIndex = 4
        CheckBox1.Text = "Replace inhheriteds"
        CheckBox1.UseVisualStyleBackColor = True
        ' 
        ' TabControl1
        ' 
        TabControl1.Appearance = TabAppearance.FlatButtons
        TabControl1.Controls.Add(TabPageEquip1)
        TabControl1.Controls.Add(TabPageEquip2)
        TabControl1.Dock = DockStyle.Fill
        TabControl1.Location = New Point(0, 0)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(905, 535)
        TabControl1.TabIndex = 5
        ' 
        ' TabPageEquip1
        ' 
        TabPageEquip1.Controls.Add(TableLayoutPanel2)
        TabPageEquip1.Location = New Point(4, 27)
        TabPageEquip1.Name = "TabPageEquip1"
        TabPageEquip1.Padding = New Padding(3)
        TabPageEquip1.Size = New Size(897, 504)
        TabPageEquip1.TabIndex = 0
        TabPageEquip1.Text = "Assets"
        TabPageEquip1.UseVisualStyleBackColor = True
        ' 
        ' TabPageEquip2
        ' 
        TabPageEquip2.Controls.Add(BG3Editor_Complex_Dyecolor1)
        TabPageEquip2.Location = New Point(4, 27)
        TabPageEquip2.Name = "TabPageEquip2"
        TabPageEquip2.Padding = New Padding(3)
        TabPageEquip2.Size = New Size(897, 504)
        TabPageEquip2.TabIndex = 1
        TabPageEquip2.Text = "Color"
        TabPageEquip2.UseVisualStyleBackColor = True
        ' 
        ' BG3Editor_Complex_Dyecolor1
        ' 
        BG3Editor_Complex_Dyecolor1.Dock = DockStyle.Fill
        BG3Editor_Complex_Dyecolor1.Location = New Point(3, 3)
        BG3Editor_Complex_Dyecolor1.Name = "BG3Editor_Complex_Dyecolor1"
        BG3Editor_Complex_Dyecolor1.Size = New Size(891, 498)
        BG3Editor_Complex_Dyecolor1.TabIndex = 0
        ' 
        ' BG3Editor_Complex_ArmorEquipment
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(TabControl1)
        Name = "BG3Editor_Complex_ArmorEquipment"
        Size = New Size(905, 535)
        GroupboxRace.ResumeLayout(False)
        GroupboxElement.ResumeLayout(False)
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        TableLayoutPanel2.ResumeLayout(False)
        TableLayoutPanel2.PerformLayout()
        TabControl1.ResumeLayout(False)
        TabPageEquip1.ResumeLayout(False)
        TabPageEquip2.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents BG3Editor_Template_ParentRaceMapkey1 As BG3Editor_Template_Node_ParentRaceMapkey
    Friend WithEvents GroupboxRace As GroupBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents GroupboxElement As GroupBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents DropArmorLabel As Label
    Friend WithEvents DropVisualLabel As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPageEquip1 As TabPage
    Friend WithEvents TabPageEquip2 As TabPage
    Friend WithEvents BG3Editor_Complex_Dyecolor1 As BG3Editor_Complex_Dyecolor

End Class
