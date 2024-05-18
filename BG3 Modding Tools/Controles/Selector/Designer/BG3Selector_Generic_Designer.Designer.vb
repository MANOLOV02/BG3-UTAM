<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class BG3Selector_Generic_Designer
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        components = New ComponentModel.Container()
        SplitContainer1 = New SplitContainer()
        SplitContainer2 = New SplitContainer()
        TreeView1 = New TreeView()
        ContextMenuStrip1 = New ContextMenuStrip(components)
        DesignToolStripMenuItem = New ToolStripMenuItem()
        ToolStripMenuItem1 = New ToolStripMenuItem()
        DisplayNAmeOption_1 = New ToolStripMenuItem()
        DisplayNAmeOption_2 = New ToolStripMenuItem()
        DisplayNAmeOption_3 = New ToolStripMenuItem()
        DisplayNAmeOption_4 = New ToolStripMenuItem()
        CollapseAll = New ToolStripMenuItem()
        ExpandAll = New ToolStripMenuItem()
        RenameGroupButton = New ToolStripMenuItem()
        AddGroupButton = New ToolStripMenuItem()
        RemoveGroupButton = New ToolStripMenuItem()
        MergeGroupButton = New ToolStripMenuItem()
        SplitGroupButton = New ToolStripMenuItem()
        CloneGroupButton = New ToolStripMenuItem()
        ByInheritingToolStripMenuItem = New ToolStripMenuItem()
        ByCloningToolStripMenuItem = New ToolStripMenuItem()
        ToolStripSeparator3 = New ToolStripSeparator()
        MoveObjectButton = New ToolStripMenuItem()
        TransferToSiblingsButton = New ToolStripMenuItem()
        PropertiesToolStripMenuItem = New ToolStripMenuItem()
        TagsToolStripMenuItem = New ToolStripMenuItem()
        TreasureTablesToolStripMenuItem = New ToolStripMenuItem()
        LocalizationToolStripMenuItem = New ToolStripMenuItem()
        AllToolStripMenuItem = New ToolStripMenuItem()
        ToolStripSeparator1 = New ToolStripSeparator()
        OnlyDisplayNameToolStripMenuItem = New ToolStripMenuItem()
        OnlyDescriptionToolStripMenuItem = New ToolStripMenuItem()
        OnlyTechnicalDescriptionToolStripMenuItem = New ToolStripMenuItem()
        ToolStripSeparator2 = New ToolStripSeparator()
        GenerateNewHandlesToolStripMenuItem = New ToolStripMenuItem()
        TransferToAllButton = New ToolStripMenuItem()
        PropertiesToolStripMenuItem1 = New ToolStripMenuItem()
        TagsToolStripMenuItem1 = New ToolStripMenuItem()
        WorldInjectionToolStripMenuItem = New ToolStripMenuItem()
        BG3Cloner1 = New BG3Cloner()
        TableLayoutPanel1 = New TableLayoutPanel()
        ButtonCancel = New Button()
        ButtonSave = New Button()
        ButtonNew = New Button()
        BG3Editor_Template_UtamGroup1 = New BG3Editor_Template_UtamGroup()
        ButtonEdit = New Button()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.Panel1.SuspendLayout()
        SplitContainer1.Panel2.SuspendLayout()
        SplitContainer1.SuspendLayout()
        CType(SplitContainer2, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer2.Panel1.SuspendLayout()
        SplitContainer2.Panel2.SuspendLayout()
        SplitContainer2.SuspendLayout()
        ContextMenuStrip1.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' SplitContainer1
        ' 
        SplitContainer1.Dock = DockStyle.Fill
        SplitContainer1.FixedPanel = FixedPanel.Panel2
        SplitContainer1.IsSplitterFixed = True
        SplitContainer1.Location = New Point(0, 0)
        SplitContainer1.Name = "SplitContainer1"
        SplitContainer1.Orientation = Orientation.Horizontal
        ' 
        ' SplitContainer1.Panel1
        ' 
        SplitContainer1.Panel1.Controls.Add(SplitContainer2)
        ' 
        ' SplitContainer1.Panel2
        ' 
        SplitContainer1.Panel2.Controls.Add(TableLayoutPanel1)
        SplitContainer1.Size = New Size(269, 483)
        SplitContainer1.SplitterDistance = 388
        SplitContainer1.TabIndex = 0
        ' 
        ' SplitContainer2
        ' 
        SplitContainer2.Dock = DockStyle.Fill
        SplitContainer2.FixedPanel = FixedPanel.Panel2
        SplitContainer2.IsSplitterFixed = True
        SplitContainer2.Location = New Point(0, 0)
        SplitContainer2.Name = "SplitContainer2"
        SplitContainer2.Orientation = Orientation.Horizontal
        ' 
        ' SplitContainer2.Panel1
        ' 
        SplitContainer2.Panel1.Controls.Add(TreeView1)
        ' 
        ' SplitContainer2.Panel2
        ' 
        SplitContainer2.Panel2.Controls.Add(BG3Cloner1)
        SplitContainer2.Panel2MinSize = 110
        SplitContainer2.Size = New Size(269, 388)
        SplitContainer2.SplitterDistance = 276
        SplitContainer2.SplitterWidth = 2
        SplitContainer2.TabIndex = 1
        ' 
        ' TreeView1
        ' 
        TreeView1.AllowDrop = True
        TreeView1.ContextMenuStrip = ContextMenuStrip1
        TreeView1.Dock = DockStyle.Fill
        TreeView1.HideSelection = False
        TreeView1.Location = New Point(0, 0)
        TreeView1.Name = "TreeView1"
        TreeView1.Size = New Size(269, 276)
        TreeView1.TabIndex = 0
        ' 
        ' ContextMenuStrip1
        ' 
        ContextMenuStrip1.Items.AddRange(New ToolStripItem() {DesignToolStripMenuItem, RenameGroupButton, AddGroupButton, RemoveGroupButton, MergeGroupButton, SplitGroupButton, CloneGroupButton, ToolStripSeparator3, MoveObjectButton, TransferToSiblingsButton, TransferToAllButton})
        ContextMenuStrip1.Name = "ContextMenuStrip1"
        ContextMenuStrip1.Size = New Size(173, 230)
        ' 
        ' DesignToolStripMenuItem
        ' 
        DesignToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {ToolStripMenuItem1, CollapseAll, ExpandAll})
        DesignToolStripMenuItem.Name = "DesignToolStripMenuItem"
        DesignToolStripMenuItem.Size = New Size(172, 22)
        DesignToolStripMenuItem.Text = "Design"
        ' 
        ' ToolStripMenuItem1
        ' 
        ToolStripMenuItem1.DropDownItems.AddRange(New ToolStripItem() {DisplayNAmeOption_1, DisplayNAmeOption_2, DisplayNAmeOption_3, DisplayNAmeOption_4})
        ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        ToolStripMenuItem1.Size = New Size(151, 22)
        ToolStripMenuItem1.Text = "Display format"
        ' 
        ' DisplayNAmeOption_1
        ' 
        DisplayNAmeOption_1.Name = "DisplayNAmeOption_1"
        DisplayNAmeOption_1.Size = New Size(190, 22)
        DisplayNAmeOption_1.Text = "Name"
        ' 
        ' DisplayNAmeOption_2
        ' 
        DisplayNAmeOption_2.Name = "DisplayNAmeOption_2"
        DisplayNAmeOption_2.Size = New Size(190, 22)
        DisplayNAmeOption_2.Text = "Name (Display Name)"
        ' 
        ' DisplayNAmeOption_3
        ' 
        DisplayNAmeOption_3.Name = "DisplayNAmeOption_3"
        DisplayNAmeOption_3.Size = New Size(190, 22)
        DisplayNAmeOption_3.Text = "Display name"
        ' 
        ' DisplayNAmeOption_4
        ' 
        DisplayNAmeOption_4.Name = "DisplayNAmeOption_4"
        DisplayNAmeOption_4.Size = New Size(190, 22)
        DisplayNAmeOption_4.Text = "Display name (name)"
        ' 
        ' CollapseAll
        ' 
        CollapseAll.Name = "CollapseAll"
        CollapseAll.Size = New Size(151, 22)
        CollapseAll.Text = "Collapse all"
        ' 
        ' ExpandAll
        ' 
        ExpandAll.Name = "ExpandAll"
        ExpandAll.Size = New Size(151, 22)
        ExpandAll.Text = "Expand all"
        ' 
        ' RenameGroupButton
        ' 
        RenameGroupButton.Name = "RenameGroupButton"
        RenameGroupButton.Size = New Size(172, 22)
        RenameGroupButton.Text = "Change name"
        ' 
        ' AddGroupButton
        ' 
        AddGroupButton.Name = "AddGroupButton"
        AddGroupButton.Size = New Size(172, 22)
        AddGroupButton.Text = "Add group"
        ' 
        ' RemoveGroupButton
        ' 
        RemoveGroupButton.Name = "RemoveGroupButton"
        RemoveGroupButton.Size = New Size(172, 22)
        RemoveGroupButton.Text = "Remove"
        ' 
        ' MergeGroupButton
        ' 
        MergeGroupButton.Name = "MergeGroupButton"
        MergeGroupButton.Size = New Size(172, 22)
        MergeGroupButton.Text = "Merge with"
        ' 
        ' SplitGroupButton
        ' 
        SplitGroupButton.Name = "SplitGroupButton"
        SplitGroupButton.Size = New Size(172, 22)
        SplitGroupButton.Text = "Split by"
        ' 
        ' CloneGroupButton
        ' 
        CloneGroupButton.DropDownItems.AddRange(New ToolStripItem() {ByInheritingToolStripMenuItem, ByCloningToolStripMenuItem})
        CloneGroupButton.Name = "CloneGroupButton"
        CloneGroupButton.Size = New Size(172, 22)
        CloneGroupButton.Text = "Clone"
        ' 
        ' ByInheritingToolStripMenuItem
        ' 
        ByInheritingToolStripMenuItem.Name = "ByInheritingToolStripMenuItem"
        ByInheritingToolStripMenuItem.Size = New Size(141, 22)
        ByInheritingToolStripMenuItem.Text = "By inheriting"
        ' 
        ' ByCloningToolStripMenuItem
        ' 
        ByCloningToolStripMenuItem.Name = "ByCloningToolStripMenuItem"
        ByCloningToolStripMenuItem.Size = New Size(141, 22)
        ByCloningToolStripMenuItem.Text = "By cloning"
        ' 
        ' ToolStripSeparator3
        ' 
        ToolStripSeparator3.Name = "ToolStripSeparator3"
        ToolStripSeparator3.Size = New Size(169, 6)
        ' 
        ' MoveObjectButton
        ' 
        MoveObjectButton.Name = "MoveObjectButton"
        MoveObjectButton.Size = New Size(172, 22)
        MoveObjectButton.Text = "Move to"
        ' 
        ' TransferToSiblingsButton
        ' 
        TransferToSiblingsButton.DropDownItems.AddRange(New ToolStripItem() {PropertiesToolStripMenuItem, TagsToolStripMenuItem, TreasureTablesToolStripMenuItem, LocalizationToolStripMenuItem})
        TransferToSiblingsButton.Name = "TransferToSiblingsButton"
        TransferToSiblingsButton.Size = New Size(172, 22)
        TransferToSiblingsButton.Text = "Transfer to siblings"
        ' 
        ' PropertiesToolStripMenuItem
        ' 
        PropertiesToolStripMenuItem.Name = "PropertiesToolStripMenuItem"
        PropertiesToolStripMenuItem.Size = New Size(181, 22)
        PropertiesToolStripMenuItem.Text = "Properties"
        ' 
        ' TagsToolStripMenuItem
        ' 
        TagsToolStripMenuItem.Name = "TagsToolStripMenuItem"
        TagsToolStripMenuItem.Size = New Size(181, 22)
        TagsToolStripMenuItem.Text = "Tags"
        ' 
        ' TreasureTablesToolStripMenuItem
        ' 
        TreasureTablesToolStripMenuItem.Name = "TreasureTablesToolStripMenuItem"
        TreasureTablesToolStripMenuItem.Size = New Size(181, 22)
        TreasureTablesToolStripMenuItem.Text = "World injection"
        ' 
        ' LocalizationToolStripMenuItem
        ' 
        LocalizationToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {AllToolStripMenuItem, ToolStripSeparator1, OnlyDisplayNameToolStripMenuItem, OnlyDescriptionToolStripMenuItem, OnlyTechnicalDescriptionToolStripMenuItem, ToolStripSeparator2, GenerateNewHandlesToolStripMenuItem})
        LocalizationToolStripMenuItem.Name = "LocalizationToolStripMenuItem"
        LocalizationToolStripMenuItem.Size = New Size(181, 22)
        LocalizationToolStripMenuItem.Text = "Localization handles"
        ' 
        ' AllToolStripMenuItem
        ' 
        AllToolStripMenuItem.Name = "AllToolStripMenuItem"
        AllToolStripMenuItem.Size = New Size(213, 22)
        AllToolStripMenuItem.Text = "All"
        ' 
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New Size(210, 6)
        ' 
        ' OnlyDisplayNameToolStripMenuItem
        ' 
        OnlyDisplayNameToolStripMenuItem.Name = "OnlyDisplayNameToolStripMenuItem"
        OnlyDisplayNameToolStripMenuItem.Size = New Size(213, 22)
        OnlyDisplayNameToolStripMenuItem.Text = "Only Display Name"
        ' 
        ' OnlyDescriptionToolStripMenuItem
        ' 
        OnlyDescriptionToolStripMenuItem.Name = "OnlyDescriptionToolStripMenuItem"
        OnlyDescriptionToolStripMenuItem.Size = New Size(213, 22)
        OnlyDescriptionToolStripMenuItem.Text = "Only Description"
        ' 
        ' OnlyTechnicalDescriptionToolStripMenuItem
        ' 
        OnlyTechnicalDescriptionToolStripMenuItem.Name = "OnlyTechnicalDescriptionToolStripMenuItem"
        OnlyTechnicalDescriptionToolStripMenuItem.Size = New Size(213, 22)
        OnlyTechnicalDescriptionToolStripMenuItem.Text = "Only Technical description"
        ' 
        ' ToolStripSeparator2
        ' 
        ToolStripSeparator2.Name = "ToolStripSeparator2"
        ToolStripSeparator2.Size = New Size(210, 6)
        ' 
        ' GenerateNewHandlesToolStripMenuItem
        ' 
        GenerateNewHandlesToolStripMenuItem.Name = "GenerateNewHandlesToolStripMenuItem"
        GenerateNewHandlesToolStripMenuItem.Size = New Size(213, 22)
        GenerateNewHandlesToolStripMenuItem.Text = "Generate new handles"
        ' 
        ' TransferToAllButton
        ' 
        TransferToAllButton.DropDownItems.AddRange(New ToolStripItem() {PropertiesToolStripMenuItem1, TagsToolStripMenuItem1, WorldInjectionToolStripMenuItem})
        TransferToAllButton.Name = "TransferToAllButton"
        TransferToAllButton.Size = New Size(172, 22)
        TransferToAllButton.Text = "Transfer to all"
        ' 
        ' PropertiesToolStripMenuItem1
        ' 
        PropertiesToolStripMenuItem1.Name = "PropertiesToolStripMenuItem1"
        PropertiesToolStripMenuItem1.Size = New Size(155, 22)
        PropertiesToolStripMenuItem1.Text = "Properties"
        ' 
        ' TagsToolStripMenuItem1
        ' 
        TagsToolStripMenuItem1.Name = "TagsToolStripMenuItem1"
        TagsToolStripMenuItem1.Size = New Size(155, 22)
        TagsToolStripMenuItem1.Text = "Tags"
        ' 
        ' WorldInjectionToolStripMenuItem
        ' 
        WorldInjectionToolStripMenuItem.Name = "WorldInjectionToolStripMenuItem"
        WorldInjectionToolStripMenuItem.Size = New Size(155, 22)
        WorldInjectionToolStripMenuItem.Text = "World Injection"
        ' 
        ' BG3Cloner1
        ' 
        BG3Cloner1.Dock = DockStyle.Fill
        BG3Cloner1.Location = New Point(0, 0)
        BG3Cloner1.Name = "BG3Cloner1"
        BG3Cloner1.Size = New Size(269, 110)
        BG3Cloner1.Stat_MustDescend_From = Nothing
        BG3Cloner1.TabIndex = 0
        BG3Cloner1.Template_MustDescend_From = Nothing
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Controls.Add(ButtonCancel, 1, 2)
        TableLayoutPanel1.Controls.Add(ButtonSave, 0, 2)
        TableLayoutPanel1.Controls.Add(ButtonNew, 0, 1)
        TableLayoutPanel1.Controls.Add(BG3Editor_Template_UtamGroup1, 0, 0)
        TableLayoutPanel1.Controls.Add(ButtonEdit, 1, 1)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 3
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 25F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Size = New Size(269, 91)
        TableLayoutPanel1.TabIndex = 1
        ' 
        ' ButtonCancel
        ' 
        ButtonCancel.Dock = DockStyle.Fill
        ButtonCancel.Enabled = False
        ButtonCancel.Location = New Point(138, 63)
        ButtonCancel.Name = "ButtonCancel"
        ButtonCancel.Size = New Size(126, 23)
        ButtonCancel.TabIndex = 0
        ButtonCancel.Text = "Cancel"
        ButtonCancel.UseVisualStyleBackColor = True
        ' 
        ' ButtonSave
        ' 
        ButtonSave.Dock = DockStyle.Fill
        ButtonSave.Enabled = False
        ButtonSave.Location = New Point(5, 63)
        ButtonSave.Name = "ButtonSave"
        ButtonSave.Size = New Size(125, 23)
        ButtonSave.TabIndex = 4
        ButtonSave.Text = "Save"
        ButtonSave.UseVisualStyleBackColor = True
        ' 
        ' ButtonNew
        ' 
        ButtonNew.Dock = DockStyle.Fill
        ButtonNew.Location = New Point(5, 32)
        ButtonNew.Name = "ButtonNew"
        ButtonNew.Size = New Size(125, 23)
        ButtonNew.TabIndex = 1
        ButtonNew.Text = "Add New"
        ButtonNew.UseVisualStyleBackColor = True
        ' 
        ' BG3Editor_Template_UtamGroup1
        ' 
        BG3Editor_Template_UtamGroup1.AllowEdit = False
        TableLayoutPanel1.SetColumnSpan(BG3Editor_Template_UtamGroup1, 2)
        BG3Editor_Template_UtamGroup1.Dock = DockStyle.Fill
        BG3Editor_Template_UtamGroup1.EditIsConditional = False
        BG3Editor_Template_UtamGroup1.EditorType = BG3_Editor_Type.Combobox
        BG3Editor_Template_UtamGroup1.Label = "Group"
        BG3Editor_Template_UtamGroup1.Location = New Point(6, 2)
        BG3Editor_Template_UtamGroup1.Margin = New Padding(4, 0, 4, 0)
        BG3Editor_Template_UtamGroup1.MaximumSize = New Size(2000, 23)
        BG3Editor_Template_UtamGroup1.MinimumSize = New Size(0, 23)
        BG3Editor_Template_UtamGroup1.Name = "BG3Editor_Template_UtamGroup1"
        BG3Editor_Template_UtamGroup1.Size = New Size(257, 23)
        BG3Editor_Template_UtamGroup1.SplitterDistance = 50
        BG3Editor_Template_UtamGroup1.TabIndex = 3
        ' 
        ' ButtonEdit
        ' 
        ButtonEdit.Dock = DockStyle.Fill
        ButtonEdit.Enabled = False
        ButtonEdit.Location = New Point(138, 32)
        ButtonEdit.Name = "ButtonEdit"
        ButtonEdit.Size = New Size(126, 23)
        ButtonEdit.TabIndex = 2
        ButtonEdit.Text = "Edit"
        ButtonEdit.UseVisualStyleBackColor = True
        ' 
        ' BG3Selector_Generic_Designer
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(SplitContainer1)
        Name = "BG3Selector_Generic_Designer"
        Size = New Size(269, 483)
        SplitContainer1.Panel1.ResumeLayout(False)
        SplitContainer1.Panel2.ResumeLayout(False)
        CType(SplitContainer1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
        SplitContainer2.Panel1.ResumeLayout(False)
        SplitContainer2.Panel2.ResumeLayout(False)
        CType(SplitContainer2, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer2.ResumeLayout(False)
        ContextMenuStrip1.ResumeLayout(False)
        TableLayoutPanel1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents BG3Editor_Template_UtamGroup1 As BG3Editor_Template_UtamGroup
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents ButtonSave As Button
    Friend WithEvents ButtonNew As Button
    Friend WithEvents ButtonEdit As Button
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents TransferToSiblingsButton As ToolStripMenuItem
    Friend WithEvents PropertiesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TagsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TreasureTablesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MoveObjectButton As ToolStripMenuItem
    Friend WithEvents LocalizationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents OnlyDisplayNameToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OnlyDescriptionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OnlyTechnicalDescriptionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BG3Cloner1 As BG3Cloner
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents MergeGroupButton As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents GenerateNewHandlesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RenameGroupButton As ToolStripMenuItem
    Friend WithEvents AddGroupButton As ToolStripMenuItem
    Friend WithEvents RemoveGroupButton As ToolStripMenuItem
    Friend WithEvents CloneGroupButton As ToolStripMenuItem
    Friend WithEvents ByInheritingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ByCloningToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents SplitGroupButton As ToolStripMenuItem
    Friend WithEvents TransferToAllButton As ToolStripMenuItem
    Friend WithEvents PropertiesToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents TagsToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents WorldInjectionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DesignToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents DisplayNAmeOption_1 As ToolStripMenuItem
    Friend WithEvents DisplayNAmeOption_2 As ToolStripMenuItem
    Friend WithEvents DisplayNAmeOption_3 As ToolStripMenuItem
    Friend WithEvents DisplayNAmeOption_4 As ToolStripMenuItem
    Friend WithEvents CollapseAll As ToolStripMenuItem
    Friend WithEvents ExpandAll As ToolStripMenuItem

End Class
