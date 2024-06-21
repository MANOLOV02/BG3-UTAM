<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Status_Generic_editor
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
        BG3Selector_Stat1 = New BG3Selector_Stat()
        TabPage1 = New TabPage()
        GroupBox9 = New GroupBox()
        GroupBoxBasicStats = New GroupBox()
        BG3Editor_stats_Icon1 = New BG3Editor_Stats_Icon()
        BG3Editor_stats_Description1 = New BG3Editor_Stats_Description()
        BG3Editor_stats_DisplayName1 = New BG3Editor_Stats_DisplayName()
        ButtonVT = New Button()
        BG3Editor_Stat_Name1 = New BG3Editor_Stats_Name()
        BG3Editor_Stat_Type1 = New BG3Editor_Stats_Type()
        BG3Editor_Stat_Using1 = New BG3Editor_Stat_Using_Bytype()
        TabControl1 = New TabControl()
        TabPage2 = New TabPage()
        GroupBox7 = New GroupBox()
        BG3Editor_Complex_Localization1 = New BG3Editor_Complex_Localization()
        TabPage4 = New TabPage()
        GroupBoxStats = New GroupBox()
        BG3Editor_Complex_Advanced_Stats1 = New BG3Editor_Complex_Advanced_Stats()
        SplitContainer1 = New SplitContainer()
        GroupBox3 = New GroupBox()
        LabelTechnical = New Label()
        PictureBox3 = New PictureBox()
        LabelInfoDescription = New Label()
        LabelInfoName = New Label()
        BG3Editor_Stats_ExtraDescription1 = New BG3Editor_Stats_ExtraDescription()
        TabPage1.SuspendLayout()
        GroupBox9.SuspendLayout()
        GroupBoxBasicStats.SuspendLayout()
        TabControl1.SuspendLayout()
        TabPage2.SuspendLayout()
        GroupBox7.SuspendLayout()
        TabPage4.SuspendLayout()
        GroupBoxStats.SuspendLayout()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.Panel1.SuspendLayout()
        SplitContainer1.Panel2.SuspendLayout()
        SplitContainer1.SuspendLayout()
        GroupBox3.SuspendLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' BG3Selector_Stat1
        ' 
        BG3Selector_Stat1.Dock = DockStyle.Fill
        BG3Selector_Stat1.Location = New Point(0, 0)
        BG3Selector_Stat1.Name = "BG3Selector_Stat1"
        BG3Selector_Stat1.NameField = "Name"
        BG3Selector_Stat1.NameType = "Attribute"
        BG3Selector_Stat1.Selection = BG3_Enum_UTAM_Type.Status
        BG3Selector_Stat1.Size = New Size(350, 596)
        BG3Selector_Stat1.Stat_MustDescend_From = New String() {"None"}
        BG3Selector_Stat1.TabIndex = 4
        BG3Selector_Stat1.Template_MustDescend_From = New String() {"None"}
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
        GroupBox9.Controls.Add(GroupBoxBasicStats)
        GroupBox9.Dock = DockStyle.Fill
        GroupBox9.Location = New Point(0, 0)
        GroupBox9.Name = "GroupBox9"
        GroupBox9.Size = New Size(807, 472)
        GroupBox9.TabIndex = 4
        GroupBox9.TabStop = False
        ' 
        ' GroupBoxBasicStats
        ' 
        GroupBoxBasicStats.Controls.Add(BG3Editor_Stats_ExtraDescription1)
        GroupBoxBasicStats.Controls.Add(BG3Editor_stats_Icon1)
        GroupBoxBasicStats.Controls.Add(BG3Editor_stats_Description1)
        GroupBoxBasicStats.Controls.Add(BG3Editor_stats_DisplayName1)
        GroupBoxBasicStats.Controls.Add(ButtonVT)
        GroupBoxBasicStats.Controls.Add(BG3Editor_Stat_Name1)
        GroupBoxBasicStats.Controls.Add(BG3Editor_Stat_Type1)
        GroupBoxBasicStats.Controls.Add(BG3Editor_Stat_Using1)
        GroupBoxBasicStats.Location = New Point(6, 12)
        GroupBoxBasicStats.Name = "GroupBoxBasicStats"
        GroupBoxBasicStats.Size = New Size(795, 191)
        GroupBoxBasicStats.TabIndex = 1
        GroupBoxBasicStats.TabStop = False
        GroupBoxBasicStats.Text = "Stat"
        ' 
        ' BG3Editor_stats_Icon1
        ' 
        BG3Editor_stats_Icon1.Label = "Icon"
        BG3Editor_stats_Icon1.Location = New Point(6, 161)
        BG3Editor_stats_Icon1.Margin = New Padding(0)
        BG3Editor_stats_Icon1.MaximumSize = New Size(3000, 23)
        BG3Editor_stats_Icon1.MinimumSize = New Size(100, 23)
        BG3Editor_stats_Icon1.Name = "BG3Editor_stats_Icon1"
        BG3Editor_stats_Icon1.Size = New Size(786, 23)
        BG3Editor_stats_Icon1.TabIndex = 10
        ' 
        ' BG3Editor_stats_Description1
        ' 
        BG3Editor_stats_Description1.Label = "Description"
        BG3Editor_stats_Description1.Location = New Point(6, 115)
        BG3Editor_stats_Description1.Margin = New Padding(0)
        BG3Editor_stats_Description1.MaximumSize = New Size(3000, 23)
        BG3Editor_stats_Description1.MinimumSize = New Size(100, 23)
        BG3Editor_stats_Description1.Name = "BG3Editor_stats_Description1"
        BG3Editor_stats_Description1.Size = New Size(787, 23)
        BG3Editor_stats_Description1.TabIndex = 9
        ' 
        ' BG3Editor_stats_DisplayName1
        ' 
        BG3Editor_stats_DisplayName1.Label = "Display name"
        BG3Editor_stats_DisplayName1.Location = New Point(6, 88)
        BG3Editor_stats_DisplayName1.Margin = New Padding(0)
        BG3Editor_stats_DisplayName1.MaximumSize = New Size(3000, 23)
        BG3Editor_stats_DisplayName1.MinimumSize = New Size(100, 23)
        BG3Editor_stats_DisplayName1.Name = "BG3Editor_stats_DisplayName1"
        BG3Editor_stats_DisplayName1.Size = New Size(786, 23)
        BG3Editor_stats_DisplayName1.TabIndex = 8
        ' 
        ' ButtonVT
        ' 
        ButtonVT.Location = New Point(767, 65)
        ButtonVT.Name = "ButtonVT"
        ButtonVT.Size = New Size(25, 23)
        ButtonVT.TabIndex = 7
        ButtonVT.Text = "X"
        ButtonVT.UseVisualStyleBackColor = True
        ' 
        ' BG3Editor_Stat_Name1
        ' 
        BG3Editor_Stat_Name1.EditIsConditional = False
        BG3Editor_Stat_Name1.Label = "Stat name"
        BG3Editor_Stat_Name1.Location = New Point(6, 19)
        BG3Editor_Stat_Name1.Margin = New Padding(0)
        BG3Editor_Stat_Name1.MaximumSize = New Size(2000, 23)
        BG3Editor_Stat_Name1.MinimumSize = New Size(0, 23)
        BG3Editor_Stat_Name1.Name = "BG3Editor_Stat_Name1"
        BG3Editor_Stat_Name1.Size = New Size(786, 23)
        BG3Editor_Stat_Name1.SplitterDistance = 100
        BG3Editor_Stat_Name1.TabIndex = 4
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
        BG3Editor_Stat_Type1.Size = New Size(238, 23)
        BG3Editor_Stat_Type1.SplitterDistance = 100
        BG3Editor_Stat_Type1.TabIndex = 5
        ' 
        ' BG3Editor_Stat_Using1
        ' 
        BG3Editor_Stat_Using1.DropIcon = True
        BG3Editor_Stat_Using1.EditIsConditional = False
        BG3Editor_Stat_Using1.Label = "Using"
        BG3Editor_Stat_Using1.Location = New Point(6, 65)
        BG3Editor_Stat_Using1.Margin = New Padding(0)
        BG3Editor_Stat_Using1.MaximumSize = New Size(2000, 23)
        BG3Editor_Stat_Using1.MinimumSize = New Size(0, 23)
        BG3Editor_Stat_Using1.Name = "BG3Editor_Stat_Using1"
        BG3Editor_Stat_Using1.ReadOnly = True
        BG3Editor_Stat_Using1.Size = New Size(758, 23)
        BG3Editor_Stat_Using1.SplitterDistance = 80
        BG3Editor_Stat_Using1.TabIndex = 6
        ' 
        ' TabControl1
        ' 
        TabControl1.Appearance = TabAppearance.FlatButtons
        TabControl1.Controls.Add(TabPage1)
        TabControl1.Controls.Add(TabPage2)
        TabControl1.Controls.Add(TabPage4)
        TabControl1.Dock = DockStyle.Top
        TabControl1.Location = New Point(0, 0)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(815, 503)
        TabControl1.SizeMode = TabSizeMode.FillToRight
        TabControl1.TabIndex = 31
        ' 
        ' TabPage2
        ' 
        TabPage2.Controls.Add(GroupBox7)
        TabPage2.Location = New Point(4, 27)
        TabPage2.Name = "TabPage2"
        TabPage2.Size = New Size(807, 472)
        TabPage2.TabIndex = 7
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
        ' TabPage4
        ' 
        TabPage4.Controls.Add(GroupBoxStats)
        TabPage4.Location = New Point(4, 27)
        TabPage4.Name = "TabPage4"
        TabPage4.Size = New Size(807, 472)
        TabPage4.TabIndex = 6
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
        SplitContainer1.Panel1.Controls.Add(BG3Selector_Stat1)
        ' 
        ' SplitContainer1.Panel2
        ' 
        SplitContainer1.Panel2.Controls.Add(GroupBox3)
        SplitContainer1.Panel2.Controls.Add(TabControl1)
        SplitContainer1.Size = New Size(1169, 596)
        SplitContainer1.SplitterDistance = 350
        SplitContainer1.TabIndex = 36
        ' 
        ' GroupBox3
        ' 
        GroupBox3.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        GroupBox3.Controls.Add(LabelTechnical)
        GroupBox3.Controls.Add(PictureBox3)
        GroupBox3.Controls.Add(LabelInfoDescription)
        GroupBox3.Controls.Add(LabelInfoName)
        GroupBox3.Location = New Point(4, 505)
        GroupBox3.Name = "GroupBox3"
        GroupBox3.Size = New Size(807, 87)
        GroupBox3.TabIndex = 36
        GroupBox3.TabStop = False
        ' 
        ' LabelTechnical
        ' 
        LabelTechnical.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LabelTechnical.AutoEllipsis = True
        LabelTechnical.Location = New Point(76, 65)
        LabelTechnical.Name = "LabelTechnical"
        LabelTechnical.Size = New Size(725, 15)
        LabelTechnical.TabIndex = 35
        LabelTechnical.Text = "Technical:"
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
        ' LabelInfoDescription
        ' 
        LabelInfoDescription.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LabelInfoDescription.AutoEllipsis = True
        LabelInfoDescription.Location = New Point(76, 42)
        LabelInfoDescription.Name = "LabelInfoDescription"
        LabelInfoDescription.Size = New Size(725, 15)
        LabelInfoDescription.TabIndex = 34
        LabelInfoDescription.Text = "Description:"
        ' 
        ' LabelInfoName
        ' 
        LabelInfoName.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LabelInfoName.AutoEllipsis = True
        LabelInfoName.Location = New Point(76, 19)
        LabelInfoName.Name = "LabelInfoName"
        LabelInfoName.Size = New Size(725, 15)
        LabelInfoName.TabIndex = 33
        LabelInfoName.Text = "Name:"
        ' 
        ' BG3Editor_Stats_ExtraDescription1
        ' 
        BG3Editor_Stats_ExtraDescription1.Label = "ExtraDescription"
        BG3Editor_Stats_ExtraDescription1.Location = New Point(6, 138)
        BG3Editor_Stats_ExtraDescription1.Margin = New Padding(0)
        BG3Editor_Stats_ExtraDescription1.MaximumSize = New Size(3000, 23)
        BG3Editor_Stats_ExtraDescription1.MinimumSize = New Size(100, 23)
        BG3Editor_Stats_ExtraDescription1.Name = "BG3Editor_Stats_ExtraDescription1"
        BG3Editor_Stats_ExtraDescription1.Size = New Size(786, 23)
        BG3Editor_Stats_ExtraDescription1.TabIndex = 11
        ' 
        ' Status_editor
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1169, 596)
        Controls.Add(SplitContainer1)
        MinimumSize = New Size(0, 0)
        Name = "Status_editor"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Status editor"
        TabPage1.ResumeLayout(False)
        GroupBox9.ResumeLayout(False)
        GroupBoxBasicStats.ResumeLayout(False)
        TabControl1.ResumeLayout(False)
        TabPage2.ResumeLayout(False)
        GroupBox7.ResumeLayout(False)
        TabPage4.ResumeLayout(False)
        GroupBoxStats.ResumeLayout(False)
        SplitContainer1.Panel1.ResumeLayout(False)
        SplitContainer1.Panel2.ResumeLayout(False)
        CType(SplitContainer1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
        GroupBox3.ResumeLayout(False)
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub
    Protected Friend WithEvents BG3Selector_Stat1 As BG3Selector_Stat
    Protected Friend WithEvents TabPage1 As TabPage
    Protected Friend WithEvents GroupBox9 As GroupBox
    Protected Friend WithEvents TabControl1 As TabControl
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents GroupBoxStats As GroupBox
    Friend WithEvents BG3Editor_Complex_Advanced_Stats1 As BG3Editor_Complex_Advanced_Stats
    Protected Friend WithEvents GroupBoxBasicStats As GroupBox
    Protected Friend WithEvents BG3Editor_Stat_Name1 As BG3Editor_Stats_Name
    Protected Friend WithEvents BG3Editor_Stat_Type1 As BG3Editor_Stats_Type
    Protected Friend WithEvents BG3Editor_Stat_Using1 As BG3Editor_Stat_Using_Bytype
    Friend WithEvents ButtonVT As Button
    Friend WithEvents BG3Editor_stats_DisplayName1 As BG3Editor_Stats_DisplayName
    Protected Friend WithEvents TabPage2 As TabPage
    Protected Friend WithEvents GroupBox7 As GroupBox
    Protected Friend WithEvents BG3Editor_Complex_Localization1 As BG3Editor_Complex_Localization
    Friend WithEvents BG3Editor_stats_Description1 As BG3Editor_Stats_Description
    Protected Friend WithEvents GroupBox3 As GroupBox
    Protected Friend WithEvents LabelTechnical As Label
    Protected Friend WithEvents PictureBox3 As PictureBox
    Protected Friend WithEvents LabelInfoDescription As Label
    Protected Friend WithEvents LabelInfoName As Label
    Friend WithEvents BG3Editor_stats_Icon1 As BG3Editor_Stats_Icon
    Friend WithEvents BG3Editor_Stats_ExtraDescription1 As BG3Editor_Stats_ExtraDescription
End Class
