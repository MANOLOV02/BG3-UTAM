<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Treasure_table_editor
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
        BG3Selector_Treasure1 = New BG3Selector_Treasures()
        TabPage1 = New TabPage()
        GroupBox9 = New GroupBox()
        GroupBoxContent = New GroupBox()
        ListBox2 = New ListBox()
        GroupBoxItems = New GroupBox()
        RadioButton2 = New RadioButton()
        RadioButton1 = New RadioButton()
        Label11 = New Label()
        Label10 = New Label()
        Label9 = New Label()
        Label8 = New Label()
        Label7 = New Label()
        Label6 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        NumericUpDown8 = New NumericUpDown()
        NumericUpDown7 = New NumericUpDown()
        NumericUpDown6 = New NumericUpDown()
        NumericUpDown5 = New NumericUpDown()
        NumericUpDown4 = New NumericUpDown()
        NumericUpDown3 = New NumericUpDown()
        NumericUpDown2 = New NumericUpDown()
        NumericUpDown1 = New NumericUpDown()
        Label2 = New Label()
        BG3Editor_Treasure_SubItemDefinition1 = New BG3Editor_Treasure_SubItemDefinition()
        Label1 = New Label()
        Button3 = New Button()
        GroupBoxSubtables = New GroupBox()
        BG3Editor_Treasure_SubtableDefinition1 = New BG3Editor_Treasure_SubtableDefinition()
        Button2 = New Button()
        Button1 = New Button()
        ListBox1 = New ListBox()
        GroupBoxBasicStats = New GroupBox()
        BG3Editor_Treasure_CanMerge1 = New BG3Editor_Treasure_CanMerge()
        BG3Editor_Treasure_Name1 = New BG3Editor_Treasure_Name()
        TabControl1 = New TabControl()
        SplitContainer1 = New SplitContainer()
        TabPage1.SuspendLayout()
        GroupBox9.SuspendLayout()
        GroupBoxContent.SuspendLayout()
        GroupBoxItems.SuspendLayout()
        CType(NumericUpDown8, ComponentModel.ISupportInitialize).BeginInit()
        CType(NumericUpDown7, ComponentModel.ISupportInitialize).BeginInit()
        CType(NumericUpDown6, ComponentModel.ISupportInitialize).BeginInit()
        CType(NumericUpDown5, ComponentModel.ISupportInitialize).BeginInit()
        CType(NumericUpDown4, ComponentModel.ISupportInitialize).BeginInit()
        CType(NumericUpDown3, ComponentModel.ISupportInitialize).BeginInit()
        CType(NumericUpDown2, ComponentModel.ISupportInitialize).BeginInit()
        CType(NumericUpDown1, ComponentModel.ISupportInitialize).BeginInit()
        GroupBoxSubtables.SuspendLayout()
        GroupBoxBasicStats.SuspendLayout()
        TabControl1.SuspendLayout()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.Panel1.SuspendLayout()
        SplitContainer1.Panel2.SuspendLayout()
        SplitContainer1.SuspendLayout()
        SuspendLayout()
        ' 
        ' BG3Selector_Treasure1
        ' 
        BG3Selector_Treasure1.Dock = DockStyle.Fill
        BG3Selector_Treasure1.Location = New Point(0, 0)
        BG3Selector_Treasure1.Name = "BG3Selector_Treasure1"
        BG3Selector_Treasure1.NameField = "Name"
        BG3Selector_Treasure1.NameType = "Attribute"
        BG3Selector_Treasure1.Selection = BG3_Enum_UTAM_Type.Status
        BG3Selector_Treasure1.Size = New Size(350, 596)
        BG3Selector_Treasure1.Stat_MustDescend_From = New String() {"None"}
        BG3Selector_Treasure1.TabIndex = 4
        BG3Selector_Treasure1.Template_MustDescend_From = New String() {"None"}
        ' 
        ' TabPage1
        ' 
        TabPage1.Controls.Add(GroupBox9)
        TabPage1.Location = New Point(4, 27)
        TabPage1.Name = "TabPage1"
        TabPage1.Size = New Size(807, 562)
        TabPage1.TabIndex = 0
        TabPage1.Text = "Main"
        ' 
        ' GroupBox9
        ' 
        GroupBox9.Controls.Add(GroupBoxContent)
        GroupBox9.Controls.Add(GroupBoxBasicStats)
        GroupBox9.Dock = DockStyle.Fill
        GroupBox9.Location = New Point(0, 0)
        GroupBox9.Name = "GroupBox9"
        GroupBox9.Size = New Size(807, 562)
        GroupBox9.TabIndex = 4
        GroupBox9.TabStop = False
        ' 
        ' GroupBoxContent
        ' 
        GroupBoxContent.Controls.Add(ListBox2)
        GroupBoxContent.Controls.Add(GroupBoxItems)
        GroupBoxContent.Controls.Add(GroupBoxSubtables)
        GroupBoxContent.Controls.Add(ListBox1)
        GroupBoxContent.Location = New Point(6, 87)
        GroupBoxContent.Name = "GroupBoxContent"
        GroupBoxContent.Size = New Size(796, 468)
        GroupBoxContent.TabIndex = 2
        GroupBoxContent.TabStop = False
        GroupBoxContent.Text = "Content (from this mod)"
        ' 
        ' ListBox2
        ' 
        ListBox2.AllowDrop = True
        ListBox2.FormattingEnabled = True
        ListBox2.ItemHeight = 15
        ListBox2.Location = New Point(223, 22)
        ListBox2.Name = "ListBox2"
        ListBox2.Size = New Size(565, 274)
        ListBox2.TabIndex = 4
        ' 
        ' GroupBoxItems
        ' 
        GroupBoxItems.Controls.Add(RadioButton2)
        GroupBoxItems.Controls.Add(RadioButton1)
        GroupBoxItems.Controls.Add(Label11)
        GroupBoxItems.Controls.Add(Label10)
        GroupBoxItems.Controls.Add(Label9)
        GroupBoxItems.Controls.Add(Label8)
        GroupBoxItems.Controls.Add(Label7)
        GroupBoxItems.Controls.Add(Label6)
        GroupBoxItems.Controls.Add(Label5)
        GroupBoxItems.Controls.Add(Label4)
        GroupBoxItems.Controls.Add(Label3)
        GroupBoxItems.Controls.Add(NumericUpDown8)
        GroupBoxItems.Controls.Add(NumericUpDown7)
        GroupBoxItems.Controls.Add(NumericUpDown6)
        GroupBoxItems.Controls.Add(NumericUpDown5)
        GroupBoxItems.Controls.Add(NumericUpDown4)
        GroupBoxItems.Controls.Add(NumericUpDown3)
        GroupBoxItems.Controls.Add(NumericUpDown2)
        GroupBoxItems.Controls.Add(NumericUpDown1)
        GroupBoxItems.Controls.Add(Label2)
        GroupBoxItems.Controls.Add(BG3Editor_Treasure_SubItemDefinition1)
        GroupBoxItems.Controls.Add(Label1)
        GroupBoxItems.Controls.Add(Button3)
        GroupBoxItems.Location = New Point(223, 305)
        GroupBoxItems.Name = "GroupBoxItems"
        GroupBoxItems.Size = New Size(565, 159)
        GroupBoxItems.TabIndex = 3
        GroupBoxItems.TabStop = False
        GroupBoxItems.Text = "Item"
        ' 
        ' RadioButton2
        ' 
        RadioButton2.AutoSize = True
        RadioButton2.Location = New Point(238, 53)
        RadioButton2.Name = "RadioButton2"
        RadioButton2.Size = New Size(201, 19)
        RadioButton2.TabIndex = 26
        RadioButton2.Text = "Use item category when available"
        RadioButton2.UseVisualStyleBackColor = True
        ' 
        ' RadioButton1
        ' 
        RadioButton1.AutoSize = True
        RadioButton1.Checked = True
        RadioButton1.Location = New Point(88, 53)
        RadioButton1.Name = "RadioButton1"
        RadioButton1.Size = New Size(114, 19)
        RadioButton1.TabIndex = 25
        RadioButton1.TabStop = True
        RadioButton1.Text = "Use specific item"
        RadioButton1.UseVisualStyleBackColor = True
        ' 
        ' Label11
        ' 
        Label11.Location = New Point(10, 83)
        Label11.Name = "Label11"
        Label11.Size = New Size(69, 25)
        Label11.TabIndex = 24
        Label11.Text = "Count"
        Label11.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label10
        ' 
        Label10.BorderStyle = BorderStyle.FixedSingle
        Label10.Location = New Point(505, 83)
        Label10.Name = "Label10"
        Label10.Size = New Size(54, 18)
        Label10.TabIndex = 23
        Label10.Text = "Unique"
        Label10.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label9
        ' 
        Label9.BorderStyle = BorderStyle.FixedSingle
        Label9.Location = New Point(445, 83)
        Label9.Name = "Label9"
        Label9.Size = New Size(54, 18)
        Label9.TabIndex = 22
        Label9.Text = "Divine"
        Label9.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label8
        ' 
        Label8.BorderStyle = BorderStyle.FixedSingle
        Label8.Location = New Point(385, 83)
        Label8.Name = "Label8"
        Label8.Size = New Size(54, 18)
        Label8.TabIndex = 21
        Label8.Text = "Leg."
        Label8.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label7
        ' 
        Label7.BorderStyle = BorderStyle.FixedSingle
        Label7.Location = New Point(325, 83)
        Label7.Name = "Label7"
        Label7.Size = New Size(54, 18)
        Label7.TabIndex = 20
        Label7.Text = "V. rare"
        Label7.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label6
        ' 
        Label6.BorderStyle = BorderStyle.FixedSingle
        Label6.Location = New Point(265, 83)
        Label6.Name = "Label6"
        Label6.Size = New Size(54, 18)
        Label6.TabIndex = 19
        Label6.Text = "Rare"
        Label6.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label5
        ' 
        Label5.BorderStyle = BorderStyle.FixedSingle
        Label5.Location = New Point(205, 83)
        Label5.Name = "Label5"
        Label5.Size = New Size(54, 18)
        Label5.TabIndex = 18
        Label5.Text = "Uncom."
        Label5.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label4
        ' 
        Label4.BorderStyle = BorderStyle.FixedSingle
        Label4.Location = New Point(145, 83)
        Label4.Name = "Label4"
        Label4.Size = New Size(54, 18)
        Label4.TabIndex = 17
        Label4.Text = "Comm."
        Label4.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label3
        ' 
        Label3.BorderStyle = BorderStyle.FixedSingle
        Label3.Location = New Point(85, 83)
        Label3.Name = "Label3"
        Label3.Size = New Size(54, 18)
        Label3.TabIndex = 16
        Label3.Text = "Frec."
        Label3.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' NumericUpDown8
        ' 
        NumericUpDown8.Location = New Point(505, 101)
        NumericUpDown8.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        NumericUpDown8.Name = "NumericUpDown8"
        NumericUpDown8.Size = New Size(54, 23)
        NumericUpDown8.TabIndex = 15
        NumericUpDown8.TextAlign = HorizontalAlignment.Right
        ' 
        ' NumericUpDown7
        ' 
        NumericUpDown7.Location = New Point(445, 101)
        NumericUpDown7.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        NumericUpDown7.Name = "NumericUpDown7"
        NumericUpDown7.Size = New Size(54, 23)
        NumericUpDown7.TabIndex = 14
        NumericUpDown7.TextAlign = HorizontalAlignment.Right
        ' 
        ' NumericUpDown6
        ' 
        NumericUpDown6.Location = New Point(385, 101)
        NumericUpDown6.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        NumericUpDown6.Name = "NumericUpDown6"
        NumericUpDown6.Size = New Size(54, 23)
        NumericUpDown6.TabIndex = 13
        NumericUpDown6.TextAlign = HorizontalAlignment.Right
        ' 
        ' NumericUpDown5
        ' 
        NumericUpDown5.Location = New Point(325, 101)
        NumericUpDown5.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        NumericUpDown5.Name = "NumericUpDown5"
        NumericUpDown5.Size = New Size(54, 23)
        NumericUpDown5.TabIndex = 12
        NumericUpDown5.TextAlign = HorizontalAlignment.Right
        ' 
        ' NumericUpDown4
        ' 
        NumericUpDown4.Location = New Point(265, 101)
        NumericUpDown4.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        NumericUpDown4.Name = "NumericUpDown4"
        NumericUpDown4.Size = New Size(54, 23)
        NumericUpDown4.TabIndex = 11
        NumericUpDown4.TextAlign = HorizontalAlignment.Right
        ' 
        ' NumericUpDown3
        ' 
        NumericUpDown3.Location = New Point(205, 101)
        NumericUpDown3.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        NumericUpDown3.Name = "NumericUpDown3"
        NumericUpDown3.Size = New Size(54, 23)
        NumericUpDown3.TabIndex = 10
        NumericUpDown3.TextAlign = HorizontalAlignment.Right
        ' 
        ' NumericUpDown2
        ' 
        NumericUpDown2.Location = New Point(145, 101)
        NumericUpDown2.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        NumericUpDown2.Name = "NumericUpDown2"
        NumericUpDown2.Size = New Size(54, 23)
        NumericUpDown2.TabIndex = 9
        NumericUpDown2.TextAlign = HorizontalAlignment.Right
        ' 
        ' NumericUpDown1
        ' 
        NumericUpDown1.Location = New Point(85, 101)
        NumericUpDown1.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        NumericUpDown1.Name = "NumericUpDown1"
        NumericUpDown1.Size = New Size(54, 23)
        NumericUpDown1.TabIndex = 8
        NumericUpDown1.TextAlign = HorizontalAlignment.Right
        ' 
        ' Label2
        ' 
        Label2.Location = New Point(10, 22)
        Label2.Name = "Label2"
        Label2.Size = New Size(69, 25)
        Label2.TabIndex = 7
        Label2.Text = "Item"
        Label2.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' BG3Editor_Treasure_SubItemDefinition1
        ' 
        BG3Editor_Treasure_SubItemDefinition1.EditIsConditional = False
        BG3Editor_Treasure_SubItemDefinition1.Label = "Text"
        BG3Editor_Treasure_SubItemDefinition1.Location = New Point(10, 127)
        BG3Editor_Treasure_SubItemDefinition1.Margin = New Padding(0)
        BG3Editor_Treasure_SubItemDefinition1.MaximumSize = New Size(3000, 23)
        BG3Editor_Treasure_SubItemDefinition1.MinimumSize = New Size(100, 23)
        BG3Editor_Treasure_SubItemDefinition1.Name = "BG3Editor_Treasure_SubItemDefinition1"
        BG3Editor_Treasure_SubItemDefinition1.ReadOnly = True
        BG3Editor_Treasure_SubItemDefinition1.Size = New Size(549, 23)
        BG3Editor_Treasure_SubItemDefinition1.SplitterDistance = 55
        BG3Editor_Treasure_SubItemDefinition1.TabIndex = 6
        ' 
        ' Label1
        ' 
        Label1.AllowDrop = True
        Label1.BackColor = SystemColors.Window
        Label1.BorderStyle = BorderStyle.FixedSingle
        Label1.Location = New Point(85, 22)
        Label1.Name = "Label1"
        Label1.Size = New Size(354, 25)
        Label1.TabIndex = 5
        Label1.Text = "Drop an item or a treasure table to add"
        Label1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(445, 22)
        Button3.Name = "Button3"
        Button3.Size = New Size(114, 25)
        Button3.TabIndex = 4
        Button3.Text = "Delete"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' GroupBoxSubtables
        ' 
        GroupBoxSubtables.Controls.Add(BG3Editor_Treasure_SubtableDefinition1)
        GroupBoxSubtables.Controls.Add(Button2)
        GroupBoxSubtables.Controls.Add(Button1)
        GroupBoxSubtables.Location = New Point(6, 389)
        GroupBoxSubtables.Name = "GroupBoxSubtables"
        GroupBoxSubtables.Size = New Size(211, 75)
        GroupBoxSubtables.TabIndex = 2
        GroupBoxSubtables.TabStop = False
        GroupBoxSubtables.Text = "Subtable"
        ' 
        ' BG3Editor_Treasure_SubtableDefinition1
        ' 
        BG3Editor_Treasure_SubtableDefinition1.EditIsConditional = False
        BG3Editor_Treasure_SubtableDefinition1.Label = "Count"
        BG3Editor_Treasure_SubtableDefinition1.Location = New Point(6, 19)
        BG3Editor_Treasure_SubtableDefinition1.Margin = New Padding(0)
        BG3Editor_Treasure_SubtableDefinition1.MaximumSize = New Size(3000, 23)
        BG3Editor_Treasure_SubtableDefinition1.MinimumSize = New Size(100, 23)
        BG3Editor_Treasure_SubtableDefinition1.Name = "BG3Editor_Treasure_SubtableDefinition1"
        BG3Editor_Treasure_SubtableDefinition1.Size = New Size(199, 23)
        BG3Editor_Treasure_SubtableDefinition1.SplitterDistance = 40
        BG3Editor_Treasure_SubtableDefinition1.TabIndex = 4
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(110, 45)
        Button2.Name = "Button2"
        Button2.Size = New Size(95, 25)
        Button2.TabIndex = 3
        Button2.Text = "Delete"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(6, 45)
        Button1.Name = "Button1"
        Button1.Size = New Size(95, 25)
        Button1.TabIndex = 0
        Button1.Text = "Add"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' ListBox1
        ' 
        ListBox1.FormattingEnabled = True
        ListBox1.ItemHeight = 15
        ListBox1.Location = New Point(6, 22)
        ListBox1.Name = "ListBox1"
        ListBox1.Size = New Size(211, 364)
        ListBox1.TabIndex = 0
        ' 
        ' GroupBoxBasicStats
        ' 
        GroupBoxBasicStats.Controls.Add(BG3Editor_Treasure_CanMerge1)
        GroupBoxBasicStats.Controls.Add(BG3Editor_Treasure_Name1)
        GroupBoxBasicStats.Location = New Point(6, 12)
        GroupBoxBasicStats.Name = "GroupBoxBasicStats"
        GroupBoxBasicStats.Size = New Size(795, 72)
        GroupBoxBasicStats.TabIndex = 1
        GroupBoxBasicStats.TabStop = False
        GroupBoxBasicStats.Text = "Treasure Table "
        ' 
        ' BG3Editor_Treasure_CanMerge1
        ' 
        BG3Editor_Treasure_CanMerge1.EditIsConditional = False
        BG3Editor_Treasure_CanMerge1.EditorType = BG3_Editor_Type.Combobox
        BG3Editor_Treasure_CanMerge1.Label = "Can merge"
        BG3Editor_Treasure_CanMerge1.Location = New Point(6, 42)
        BG3Editor_Treasure_CanMerge1.Margin = New Padding(0)
        BG3Editor_Treasure_CanMerge1.MaximumSize = New Size(3000, 23)
        BG3Editor_Treasure_CanMerge1.MinimumSize = New Size(100, 23)
        BG3Editor_Treasure_CanMerge1.Name = "BG3Editor_Treasure_CanMerge1"
        BG3Editor_Treasure_CanMerge1.Size = New Size(271, 23)
        BG3Editor_Treasure_CanMerge1.SplitterDistance = 119
        BG3Editor_Treasure_CanMerge1.TabIndex = 5
        ' 
        ' BG3Editor_Treasure_Name1
        ' 
        BG3Editor_Treasure_Name1.EditIsConditional = False
        BG3Editor_Treasure_Name1.Label = "Treasure table name"
        BG3Editor_Treasure_Name1.Location = New Point(6, 19)
        BG3Editor_Treasure_Name1.Margin = New Padding(0)
        BG3Editor_Treasure_Name1.MaximumSize = New Size(2000, 23)
        BG3Editor_Treasure_Name1.MinimumSize = New Size(0, 23)
        BG3Editor_Treasure_Name1.Name = "BG3Editor_Treasure_Name1"
        BG3Editor_Treasure_Name1.Size = New Size(786, 23)
        BG3Editor_Treasure_Name1.SplitterDistance = 119
        BG3Editor_Treasure_Name1.TabIndex = 4
        ' 
        ' TabControl1
        ' 
        TabControl1.Appearance = TabAppearance.FlatButtons
        TabControl1.Controls.Add(TabPage1)
        TabControl1.Dock = DockStyle.Top
        TabControl1.Location = New Point(0, 0)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(815, 593)
        TabControl1.SizeMode = TabSizeMode.FillToRight
        TabControl1.TabIndex = 31
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
        SplitContainer1.Panel1.Controls.Add(BG3Selector_Treasure1)
        ' 
        ' SplitContainer1.Panel2
        ' 
        SplitContainer1.Panel2.Controls.Add(TabControl1)
        SplitContainer1.Size = New Size(1169, 596)
        SplitContainer1.SplitterDistance = 350
        SplitContainer1.TabIndex = 36
        ' 
        ' Treasure_table_editor
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1169, 596)
        Controls.Add(SplitContainer1)
        MinimumSize = New Size(0, 0)
        Name = "Treasure_table_editor"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Treasure table editor"
        TabPage1.ResumeLayout(False)
        GroupBox9.ResumeLayout(False)
        GroupBoxContent.ResumeLayout(False)
        GroupBoxItems.ResumeLayout(False)
        GroupBoxItems.PerformLayout()
        CType(NumericUpDown8, ComponentModel.ISupportInitialize).EndInit()
        CType(NumericUpDown7, ComponentModel.ISupportInitialize).EndInit()
        CType(NumericUpDown6, ComponentModel.ISupportInitialize).EndInit()
        CType(NumericUpDown5, ComponentModel.ISupportInitialize).EndInit()
        CType(NumericUpDown4, ComponentModel.ISupportInitialize).EndInit()
        CType(NumericUpDown3, ComponentModel.ISupportInitialize).EndInit()
        CType(NumericUpDown2, ComponentModel.ISupportInitialize).EndInit()
        CType(NumericUpDown1, ComponentModel.ISupportInitialize).EndInit()
        GroupBoxSubtables.ResumeLayout(False)
        GroupBoxBasicStats.ResumeLayout(False)
        TabControl1.ResumeLayout(False)
        SplitContainer1.Panel1.ResumeLayout(False)
        SplitContainer1.Panel2.ResumeLayout(False)
        CType(SplitContainer1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Protected Friend WithEvents BG3Selector_Treasure1 As BG3Selector_Treasures
    Protected Friend WithEvents TabPage1 As TabPage
    Protected Friend WithEvents GroupBox9 As GroupBox
    Protected Friend WithEvents TabControl1 As TabControl
    Friend WithEvents SplitContainer1 As SplitContainer
    Protected Friend WithEvents GroupBoxBasicStats As GroupBox
    Protected Friend WithEvents BG3Editor_Treasure_Name1 As BG3Editor_Treasure_Name
    Friend WithEvents BG3Editor_Treasure_CanMerge1 As BG3Editor_Treasure_CanMerge
    Friend WithEvents GroupBoxContent As GroupBox
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents GroupBoxSubtables As GroupBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents GroupBoxItems As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents BG3Editor_Treasure_SubtableDefinition1 As BG3Editor_Treasure_SubtableDefinition
    Friend WithEvents ListBox2 As ListBox
    Friend WithEvents BG3Editor_Treasure_SubItemDefinition1 As BG3Editor_Treasure_SubItemDefinition
    Friend WithEvents Label2 As Label
    Friend WithEvents NumericUpDown5 As NumericUpDown
    Friend WithEvents NumericUpDown4 As NumericUpDown
    Friend WithEvents NumericUpDown3 As NumericUpDown
    Friend WithEvents NumericUpDown2 As NumericUpDown
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents NumericUpDown8 As NumericUpDown
    Friend WithEvents NumericUpDown7 As NumericUpDown
    Friend WithEvents NumericUpDown6 As NumericUpDown
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
End Class
