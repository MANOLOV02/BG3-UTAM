<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class BG3Editor_Complex_Advanced_Attributes
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
        ListView1 = New ListView()
        ColumnHeader1 = New ColumnHeader()
        ColumnHeader2 = New ColumnHeader()
        ColumnHeader3 = New ColumnHeader()
        ContextMenuStripAttributes = New ContextMenuStrip(components)
        CopyValueToolStripMenuItem = New ToolStripMenuItem()
        AddAttributeToolStripMenuItem = New ToolStripMenuItem()
        DeleteNodeToolStripMenuItem = New ToolStripMenuItem()
        CopyNodeToolStripMenuItem = New ToolStripMenuItem()
        PasteNodeToolStripMenuItem = New ToolStripMenuItem()
        TableLayoutPanel1 = New TableLayoutPanel()
        BG3Editor_Template_Undefined1 = New BG3Editor_Template_Undefined()
        ButtonOk = New Button()
        TableLayoutPanel2 = New TableLayoutPanel()
        TreeView1 = New TreeView()
        ContextMenuStripNodes = New ContextMenuStrip(components)
        GroupBoxNodesEdit = New GroupBox()
        TableLayoutPanel3 = New TableLayoutPanel()
        ButtonDeleteNode = New Button()
        ButtonAddNode = New Button()
        ComboBox1 = New ComboBox()
        ContextMenuStripAttributes.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        ContextMenuStripNodes.SuspendLayout()
        GroupBoxNodesEdit.SuspendLayout()
        TableLayoutPanel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' ListView1
        ' 
        ListView1.Columns.AddRange(New ColumnHeader() {ColumnHeader1, ColumnHeader2, ColumnHeader3})
        TableLayoutPanel1.SetColumnSpan(ListView1, 2)
        ListView1.ContextMenuStrip = ContextMenuStripAttributes
        ListView1.Dock = DockStyle.Fill
        ListView1.FullRowSelect = True
        ListView1.Location = New Point(196, 3)
        ListView1.MultiSelect = False
        ListView1.Name = "ListView1"
        ListView1.Size = New Size(486, 404)
        ListView1.TabIndex = 2
        ListView1.UseCompatibleStateImageBehavior = False
        ListView1.View = View.Details
        ' 
        ' ColumnHeader1
        ' 
        ColumnHeader1.Text = "Attribute"
        ColumnHeader1.Width = 34
        ' 
        ' ColumnHeader2
        ' 
        ColumnHeader2.Text = "Type"
        ColumnHeader2.Width = 37
        ' 
        ' ColumnHeader3
        ' 
        ColumnHeader3.Text = "Value"
        ColumnHeader3.Width = 325
        ' 
        ' ContextMenuStripAttributes
        ' 
        ContextMenuStripAttributes.Items.AddRange(New ToolStripItem() {CopyValueToolStripMenuItem, AddAttributeToolStripMenuItem})
        ContextMenuStripAttributes.Name = "ContextMenuStripAttributes"
        ContextMenuStripAttributes.Size = New Size(145, 48)
        ' 
        ' CopyValueToolStripMenuItem
        ' 
        CopyValueToolStripMenuItem.Name = "CopyValueToolStripMenuItem"
        CopyValueToolStripMenuItem.Size = New Size(144, 22)
        CopyValueToolStripMenuItem.Text = "Copy value"
        ' 
        ' AddAttributeToolStripMenuItem
        ' 
        AddAttributeToolStripMenuItem.Name = "AddAttributeToolStripMenuItem"
        AddAttributeToolStripMenuItem.Size = New Size(144, 22)
        AddAttributeToolStripMenuItem.Text = "Add attribute"
        ' 
        ' DeleteNodeToolStripMenuItem
        ' 
        DeleteNodeToolStripMenuItem.Name = "DeleteNodeToolStripMenuItem"
        DeleteNodeToolStripMenuItem.Size = New Size(137, 22)
        DeleteNodeToolStripMenuItem.Text = "Delete node"
        ' 
        ' CopyNodeToolStripMenuItem
        ' 
        CopyNodeToolStripMenuItem.Name = "CopyNodeToolStripMenuItem"
        CopyNodeToolStripMenuItem.Size = New Size(137, 22)
        CopyNodeToolStripMenuItem.Text = "Copy node"
        ' 
        ' PasteNodeToolStripMenuItem
        ' 
        PasteNodeToolStripMenuItem.Name = "PasteNodeToolStripMenuItem"
        PasteNodeToolStripMenuItem.Size = New Size(137, 22)
        PasteNodeToolStripMenuItem.Text = "Paste node"
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 3
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 30F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 70F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 40F))
        TableLayoutPanel1.Controls.Add(BG3Editor_Template_Undefined1, 1, 1)
        TableLayoutPanel1.Controls.Add(ListView1, 1, 0)
        TableLayoutPanel1.Controls.Add(ButtonOk, 2, 1)
        TableLayoutPanel1.Controls.Add(TableLayoutPanel2, 0, 0)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 2
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 24F))
        TableLayoutPanel1.Size = New Size(685, 434)
        TableLayoutPanel1.TabIndex = 3
        ' 
        ' BG3Editor_Template_Undefined1
        ' 
        BG3Editor_Template_Undefined1.AttributeType = LSLib.LS.AttributeType.FixedString
        BG3Editor_Template_Undefined1.Dock = DockStyle.Fill
        BG3Editor_Template_Undefined1.Key = "Undefined"
        BG3Editor_Template_Undefined1.Label = "Select"
        BG3Editor_Template_Undefined1.Location = New Point(196, 410)
        BG3Editor_Template_Undefined1.Margin = New Padding(3, 0, 3, 0)
        BG3Editor_Template_Undefined1.MaximumSize = New Size(3000, 23)
        BG3Editor_Template_Undefined1.MinimumSize = New Size(100, 23)
        BG3Editor_Template_Undefined1.Name = "BG3Editor_Template_Undefined1"
        BG3Editor_Template_Undefined1.Size = New Size(445, 23)
        BG3Editor_Template_Undefined1.SplitterDistance = 160
        BG3Editor_Template_Undefined1.TabIndex = 4
        ' 
        ' ButtonOk
        ' 
        ButtonOk.Dock = DockStyle.Fill
        ButtonOk.Location = New Point(644, 410)
        ButtonOk.Margin = New Padding(0)
        ButtonOk.Name = "ButtonOk"
        ButtonOk.Size = New Size(41, 24)
        ButtonOk.TabIndex = 5
        ButtonOk.Text = "Ok"
        ButtonOk.UseVisualStyleBackColor = True
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.ColumnCount = 1
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.Controls.Add(TreeView1, 0, 0)
        TableLayoutPanel2.Controls.Add(GroupBoxNodesEdit, 0, 1)
        TableLayoutPanel2.Dock = DockStyle.Fill
        TableLayoutPanel2.Location = New Point(3, 3)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 2
        TableLayoutPanel1.SetRowSpan(TableLayoutPanel2, 2)
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Absolute, 109F))
        TableLayoutPanel2.Size = New Size(187, 428)
        TableLayoutPanel2.TabIndex = 7
        ' 
        ' TreeView1
        ' 
        TreeView1.ContextMenuStrip = ContextMenuStripNodes
        TreeView1.Dock = DockStyle.Fill
        TreeView1.Location = New Point(3, 3)
        TreeView1.Name = "TreeView1"
        TreeView1.Size = New Size(181, 313)
        TreeView1.TabIndex = 6
        ' 
        ' ContextMenuStripNodes
        ' 
        ContextMenuStripNodes.Items.AddRange(New ToolStripItem() {DeleteNodeToolStripMenuItem, CopyNodeToolStripMenuItem, PasteNodeToolStripMenuItem})
        ContextMenuStripNodes.Name = "ContextMenuStripNodes"
        ContextMenuStripNodes.Size = New Size(138, 70)
        ' 
        ' GroupBoxNodesEdit
        ' 
        GroupBoxNodesEdit.Controls.Add(TableLayoutPanel3)
        GroupBoxNodesEdit.Dock = DockStyle.Fill
        GroupBoxNodesEdit.Location = New Point(0, 319)
        GroupBoxNodesEdit.Margin = New Padding(0)
        GroupBoxNodesEdit.Name = "GroupBoxNodesEdit"
        GroupBoxNodesEdit.Size = New Size(187, 109)
        GroupBoxNodesEdit.TabIndex = 7
        GroupBoxNodesEdit.TabStop = False
        ' 
        ' TableLayoutPanel3
        ' 
        TableLayoutPanel3.ColumnCount = 1
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20F))
        TableLayoutPanel3.Controls.Add(ButtonDeleteNode, 0, 0)
        TableLayoutPanel3.Controls.Add(ButtonAddNode, 0, 2)
        TableLayoutPanel3.Controls.Add(ComboBox1, 0, 1)
        TableLayoutPanel3.Dock = DockStyle.Fill
        TableLayoutPanel3.Location = New Point(3, 19)
        TableLayoutPanel3.Name = "TableLayoutPanel3"
        TableLayoutPanel3.RowCount = 3
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel3.Size = New Size(181, 87)
        TableLayoutPanel3.TabIndex = 3
        ' 
        ' ButtonDeleteNode
        ' 
        ButtonDeleteNode.Dock = DockStyle.Fill
        ButtonDeleteNode.Location = New Point(3, 3)
        ButtonDeleteNode.Name = "ButtonDeleteNode"
        ButtonDeleteNode.Size = New Size(175, 23)
        ButtonDeleteNode.TabIndex = 1
        ButtonDeleteNode.Text = "Delete"
        ButtonDeleteNode.UseVisualStyleBackColor = True
        ' 
        ' ButtonAddNode
        ' 
        ButtonAddNode.Dock = DockStyle.Fill
        ButtonAddNode.Location = New Point(3, 61)
        ButtonAddNode.Name = "ButtonAddNode"
        ButtonAddNode.Size = New Size(175, 23)
        ButtonAddNode.TabIndex = 2
        ButtonAddNode.Text = "Add"
        ButtonAddNode.UseVisualStyleBackColor = True
        ' 
        ' ComboBox1
        ' 
        ComboBox1.Dock = DockStyle.Fill
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(3, 32)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(175, 23)
        ComboBox1.TabIndex = 0
        ' 
        ' BG3Editor_Complex_Advanced_Attributes
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(TableLayoutPanel1)
        Name = "BG3Editor_Complex_Advanced_Attributes"
        Size = New Size(685, 434)
        ContextMenuStripAttributes.ResumeLayout(False)
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel2.ResumeLayout(False)
        ContextMenuStripNodes.ResumeLayout(False)
        GroupBoxNodesEdit.ResumeLayout(False)
        TableLayoutPanel3.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents BG3Editor_Template_Undefined1 As BG3Editor_Template_Undefined
    Friend WithEvents ButtonOk As Button
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents GroupBoxNodesEdit As GroupBox
    Friend WithEvents ButtonAddNode As Button
    Friend WithEvents ButtonDeleteNode As Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents ContextMenuStripNodes As ContextMenuStrip
    Friend WithEvents ContextMenuStripAttributes As ContextMenuStrip
    Friend WithEvents DeleteNodeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CopyNodeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PasteNodeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CopyValueToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddAttributeToolStripMenuItem As ToolStripMenuItem
End Class
