<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public MustInherit Class Explorer_Generic_Designer
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
    Protected Sub InitializeComponent()
        components = New ComponentModel.Container()
        ButtonFilter = New Button()
        TextBoxFilter = New TextBox()
        Label3 = New Label()
        ComboBoxParent = New ComboBox()
        ProgressBarTree = New ProgressBar()
        ComboBoxItems = New ComboBox()
        TreeView1 = New TreeView()
        TreeContext = New ContextMenuStrip(components)
        DesignToolStripMenuItem = New ToolStripMenuItem()
        ToolStripMenuItem1 = New ToolStripMenuItem()
        ToolStripMenuItem2 = New ToolStripMenuItem()
        ToolStripMenuItem3 = New ToolStripMenuItem()
        ToolStripMenuItem4 = New ToolStripMenuItem()
        ToolStripMenuItem5 = New ToolStripMenuItem()
        CollapseAll = New ToolStripMenuItem()
        ExpandAll = New ToolStripMenuItem()
        ToolsToolStripMenuItem = New ToolStripMenuItem()
        CopyMapkeyToolStripMenuItem = New ToolStripMenuItem()
        CopyNameToolStripMenuItem = New ToolStripMenuItem()
        SourceDataToolStripMenuItem = New ToolStripMenuItem()
        PackToolStripMenuItem = New ToolStripMenuItem()
        FileToolStripMenuItem = New ToolStripMenuItem()
        DetailsVisiblesOrNot = New Button()
        CheckBoxDeep = New CheckBox()
        SplitContainer1 = New SplitContainer()
        Panel1 = New Panel()
        TreeContext.SuspendLayout()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.Panel1.SuspendLayout()
        SplitContainer1.Panel2.SuspendLayout()
        SplitContainer1.SuspendLayout()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' ButtonFilter
        ' 
        ButtonFilter.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        ButtonFilter.Location = New Point(243, 73)
        ButtonFilter.Name = "ButtonFilter"
        ButtonFilter.Size = New Size(50, 23)
        ButtonFilter.TabIndex = 24
        ButtonFilter.Text = "Filter"
        ButtonFilter.UseVisualStyleBackColor = True
        ' 
        ' TextBoxFilter
        ' 
        TextBoxFilter.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        TextBoxFilter.Location = New Point(3, 73)
        TextBoxFilter.Name = "TextBoxFilter"
        TextBoxFilter.Size = New Size(181, 23)
        TextBoxFilter.TabIndex = 23
        ' 
        ' Label3
        ' 
        Label3.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label3.Location = New Point(188, 54)
        Label3.Name = "Label3"
        Label3.Size = New Size(105, 16)
        Label3.TabIndex = 22
        Label3.Text = "(of 0)"
        Label3.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' ComboBoxParent
        ' 
        ComboBoxParent.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        ComboBoxParent.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBoxParent.FormattingEnabled = True
        ComboBoxParent.Location = New Point(3, 28)
        ComboBoxParent.Name = "ComboBoxParent"
        ComboBoxParent.Size = New Size(237, 23)
        ComboBoxParent.TabIndex = 21
        ' 
        ' ProgressBarTree
        ' 
        ProgressBarTree.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        ProgressBarTree.Location = New Point(3, 57)
        ProgressBarTree.Name = "ProgressBarTree"
        ProgressBarTree.Size = New Size(179, 10)
        ProgressBarTree.TabIndex = 20
        ' 
        ' ComboBoxItems
        ' 
        ComboBoxItems.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        ComboBoxItems.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBoxItems.FormattingEnabled = True
        ComboBoxItems.Location = New Point(3, 3)
        ComboBoxItems.Name = "ComboBoxItems"
        ComboBoxItems.Size = New Size(237, 23)
        ComboBoxItems.TabIndex = 19
        ' 
        ' TreeView1
        ' 
        TreeView1.BorderStyle = BorderStyle.FixedSingle
        TreeView1.ContextMenuStrip = TreeContext
        TreeView1.Dock = DockStyle.Fill
        TreeView1.HideSelection = False
        TreeView1.Location = New Point(0, 0)
        TreeView1.Name = "TreeView1"
        TreeView1.Size = New Size(296, 437)
        TreeView1.TabIndex = 18
        ' 
        ' TreeContext
        ' 
        TreeContext.Items.AddRange(New ToolStripItem() {DesignToolStripMenuItem, ToolsToolStripMenuItem})
        TreeContext.Name = "TreeContext"
        TreeContext.Size = New Size(111, 48)
        ' 
        ' DesignToolStripMenuItem
        ' 
        DesignToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {ToolStripMenuItem1, CollapseAll, ExpandAll})
        DesignToolStripMenuItem.Name = "DesignToolStripMenuItem"
        DesignToolStripMenuItem.Size = New Size(110, 22)
        DesignToolStripMenuItem.Text = "Design"
        ' 
        ' ToolStripMenuItem1
        ' 
        ToolStripMenuItem1.DropDownItems.AddRange(New ToolStripItem() {ToolStripMenuItem2, ToolStripMenuItem3, ToolStripMenuItem4, ToolStripMenuItem5})
        ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        ToolStripMenuItem1.Size = New Size(151, 22)
        ToolStripMenuItem1.Text = "Display format"
        ' 
        ' ToolStripMenuItem2
        ' 
        ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        ToolStripMenuItem2.Size = New Size(190, 22)
        ToolStripMenuItem2.Text = "Name"
        ' 
        ' ToolStripMenuItem3
        ' 
        ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        ToolStripMenuItem3.Size = New Size(190, 22)
        ToolStripMenuItem3.Text = "Name (Display Name)"
        ' 
        ' ToolStripMenuItem4
        ' 
        ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        ToolStripMenuItem4.Size = New Size(190, 22)
        ToolStripMenuItem4.Text = "Display name"
        ' 
        ' ToolStripMenuItem5
        ' 
        ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        ToolStripMenuItem5.Size = New Size(190, 22)
        ToolStripMenuItem5.Text = "Display name (name)"
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
        ' ToolsToolStripMenuItem
        ' 
        ToolsToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {CopyMapkeyToolStripMenuItem, CopyNameToolStripMenuItem, SourceDataToolStripMenuItem})
        ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        ToolsToolStripMenuItem.Size = New Size(110, 22)
        ToolsToolStripMenuItem.Text = "Tools"
        ' 
        ' CopyMapkeyToolStripMenuItem
        ' 
        CopyMapkeyToolStripMenuItem.Name = "CopyMapkeyToolStripMenuItem"
        CopyMapkeyToolStripMenuItem.Size = New Size(147, 22)
        CopyMapkeyToolStripMenuItem.Text = "Copy Mapkey"
        ' 
        ' CopyNameToolStripMenuItem
        ' 
        CopyNameToolStripMenuItem.Name = "CopyNameToolStripMenuItem"
        CopyNameToolStripMenuItem.Size = New Size(147, 22)
        CopyNameToolStripMenuItem.Text = "Copy Name"
        ' 
        ' SourceDataToolStripMenuItem
        ' 
        SourceDataToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {PackToolStripMenuItem, FileToolStripMenuItem})
        SourceDataToolStripMenuItem.Name = "SourceDataToolStripMenuItem"
        SourceDataToolStripMenuItem.Size = New Size(147, 22)
        SourceDataToolStripMenuItem.Text = "Source Data"
        ' 
        ' PackToolStripMenuItem
        ' 
        PackToolStripMenuItem.Name = "PackToolStripMenuItem"
        PackToolStripMenuItem.Size = New Size(99, 22)
        PackToolStripMenuItem.Text = "Pack"
        ' 
        ' FileToolStripMenuItem
        ' 
        FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        FileToolStripMenuItem.Size = New Size(99, 22)
        FileToolStripMenuItem.Text = "File"
        ' 
        ' DetailsVisiblesOrNot
        ' 
        DetailsVisiblesOrNot.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        DetailsVisiblesOrNot.BackgroundImage = My.Resources.Resources.layer_visible_on
        DetailsVisiblesOrNot.BackgroundImageLayout = ImageLayout.Center
        DetailsVisiblesOrNot.Location = New Point(246, 0)
        DetailsVisiblesOrNot.Name = "DetailsVisiblesOrNot"
        DetailsVisiblesOrNot.Size = New Size(47, 51)
        DetailsVisiblesOrNot.TabIndex = 25
        DetailsVisiblesOrNot.UseVisualStyleBackColor = True
        ' 
        ' CheckBoxDeep
        ' 
        CheckBoxDeep.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        CheckBoxDeep.AutoSize = True
        CheckBoxDeep.Location = New Point(190, 75)
        CheckBoxDeep.Name = "CheckBoxDeep"
        CheckBoxDeep.Size = New Size(53, 19)
        CheckBoxDeep.TabIndex = 28
        CheckBoxDeep.Text = "Deep"
        CheckBoxDeep.UseVisualStyleBackColor = True
        ' 
        ' SplitContainer1
        ' 
        SplitContainer1.Dock = DockStyle.Fill
        SplitContainer1.FixedPanel = FixedPanel.Panel1
        SplitContainer1.IsSplitterFixed = True
        SplitContainer1.Location = New Point(0, 0)
        SplitContainer1.Name = "SplitContainer1"
        SplitContainer1.Orientation = Orientation.Horizontal
        ' 
        ' SplitContainer1.Panel1
        ' 
        SplitContainer1.Panel1.Controls.Add(Panel1)
        ' 
        ' SplitContainer1.Panel2
        ' 
        SplitContainer1.Panel2.Controls.Add(TreeView1)
        SplitContainer1.Size = New Size(296, 540)
        SplitContainer1.SplitterDistance = 99
        SplitContainer1.TabIndex = 29
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(ComboBoxItems)
        Panel1.Controls.Add(ProgressBarTree)
        Panel1.Controls.Add(ComboBoxParent)
        Panel1.Controls.Add(CheckBoxDeep)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(DetailsVisiblesOrNot)
        Panel1.Controls.Add(TextBoxFilter)
        Panel1.Controls.Add(ButtonFilter)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(296, 99)
        Panel1.TabIndex = 30
        ' 
        ' Explorer_Generic_Designer
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(SplitContainer1)
        DoubleBuffered = True
        Name = "Explorer_Generic_Designer"
        Size = New Size(296, 540)
        TreeContext.ResumeLayout(False)
        SplitContainer1.Panel1.ResumeLayout(False)
        SplitContainer1.Panel2.ResumeLayout(False)
        CType(SplitContainer1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents TreeContext As ContextMenuStrip
    Friend WithEvents ExpandAll As ToolStripMenuItem
    Friend WithEvents CollapseAll As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As ToolStripMenuItem
    Friend WithEvents ButtonFilter As Button
    Friend WithEvents TextBoxFilter As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents ComboBoxParent As ComboBox
    Friend WithEvents ProgressBarTree As ProgressBar
    Friend WithEvents ComboBoxItems As ComboBox
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents DetailsVisiblesOrNot As Button
    Friend WithEvents CheckBoxDeep As CheckBox
    Friend WithEvents ToolsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CopyMapkeyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CopyNameToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SourceDataToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PackToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DesignToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Panel1 As Panel

End Class
