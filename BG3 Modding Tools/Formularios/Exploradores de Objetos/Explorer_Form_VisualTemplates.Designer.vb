<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Explorer_Form_VisualTemplates
    Inherits ExploraForm_code

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Explorer_Form_VisualTemplates))
        ObjectsTree = New BG3Explorer_VisualTemplates()
        TableLayoutPanel1 = New TableLayoutPanel()
        Button1 = New Button()
        TableLayoutPanel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' ObjectsTree
        ' 
        ObjectsTree.DetailsVisibles = True
        ObjectsTree.Dock = DockStyle.Fill
        ObjectsTree.Location = New Point(3, 3)
        ObjectsTree.Name = "ObjectsTree"
        ObjectsTree.ObjectList = Nothing
        ObjectsTree.Size = New Size(278, 527)
        ObjectsTree.SourceFilter = Nothing
        ObjectsTree.TabIndex = 0
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 1
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Controls.Add(Button1, 0, 1)
        TableLayoutPanel1.Controls.Add(ObjectsTree, 0, 0)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 2
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 28F))
        TableLayoutPanel1.Size = New Size(284, 561)
        TableLayoutPanel1.TabIndex = 1
        ' 
        ' Button1
        ' 
        Button1.Dock = DockStyle.Fill
        Button1.Enabled = False
        Button1.Location = New Point(3, 536)
        Button1.Name = "Button1"
        Button1.Size = New Size(278, 22)
        Button1.TabIndex = 18
        Button1.Text = "Export asset"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Explorer_Form_VisualTemplates
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(284, 561)
        Controls.Add(TableLayoutPanel1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Explorer_Form_VisualTemplates"
        Text = "Objects Explorer"
        TableLayoutPanel1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents ObjectsTree As BG3Explorer_VisualTemplates
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Button1 As Button

End Class
