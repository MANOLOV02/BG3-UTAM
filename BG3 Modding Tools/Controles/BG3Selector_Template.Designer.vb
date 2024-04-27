<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BG3Selector_Template
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
        SplitContainer1 = New SplitContainer()
        TreeView1 = New TreeView()
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
        TableLayoutPanel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' SplitContainer1
        ' 
        SplitContainer1.Dock = DockStyle.Fill
        SplitContainer1.FixedPanel = FixedPanel.Panel2
        SplitContainer1.Location = New Point(0, 0)
        SplitContainer1.Name = "SplitContainer1"
        SplitContainer1.Orientation = Orientation.Horizontal
        ' 
        ' SplitContainer1.Panel1
        ' 
        SplitContainer1.Panel1.Controls.Add(TreeView1)
        ' 
        ' SplitContainer1.Panel2
        ' 
        SplitContainer1.Panel2.Controls.Add(TableLayoutPanel1)
        SplitContainer1.Size = New Size(269, 483)
        SplitContainer1.SplitterDistance = 386
        SplitContainer1.TabIndex = 0
        ' 
        ' TreeView1
        ' 
        TreeView1.Dock = DockStyle.Fill
        TreeView1.HideSelection = False
        TreeView1.Location = New Point(0, 0)
        TreeView1.Name = "TreeView1"
        TreeView1.Size = New Size(269, 386)
        TreeView1.TabIndex = 0
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
        TableLayoutPanel1.Size = New Size(269, 93)
        TableLayoutPanel1.TabIndex = 1
        ' 
        ' ButtonCancel
        ' 
        ButtonCancel.Dock = DockStyle.Fill
        ButtonCancel.Enabled = False
        ButtonCancel.Location = New Point(138, 64)
        ButtonCancel.Name = "ButtonCancel"
        ButtonCancel.Size = New Size(126, 24)
        ButtonCancel.TabIndex = 0
        ButtonCancel.Text = "Cancel"
        ButtonCancel.UseVisualStyleBackColor = True
        ' 
        ' ButtonSave
        ' 
        ButtonSave.Dock = DockStyle.Fill
        ButtonSave.Enabled = False
        ButtonSave.Location = New Point(5, 64)
        ButtonSave.Name = "ButtonSave"
        ButtonSave.Size = New Size(125, 24)
        ButtonSave.TabIndex = 4
        ButtonSave.Text = "Save"
        ButtonSave.UseVisualStyleBackColor = True
        ' 
        ' ButtonNew
        ' 
        ButtonNew.Dock = DockStyle.Fill
        ButtonNew.Location = New Point(5, 32)
        ButtonNew.Name = "ButtonNew"
        ButtonNew.Size = New Size(125, 24)
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
        ButtonEdit.Size = New Size(126, 24)
        ButtonEdit.TabIndex = 2
        ButtonEdit.Text = "Edit"
        ButtonEdit.UseVisualStyleBackColor = True
        ' 
        ' BG3Selector_Template
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(SplitContainer1)
        Name = "BG3Selector_Template"
        Size = New Size(269, 483)
        SplitContainer1.Panel1.ResumeLayout(False)
        SplitContainer1.Panel2.ResumeLayout(False)
        CType(SplitContainer1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
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

End Class
