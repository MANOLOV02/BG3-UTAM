<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Explorer_Form_Templates
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Explorer_Form_Templates))
        ObjectsTree = New BG3Explorer_Templates()
        SuspendLayout()
        ' 
        ' ObjectsTree
        ' 
        ObjectsTree.DetailsVisibles = True
        ObjectsTree.Dock = DockStyle.Fill
        ObjectsTree.Location = New Point(0, 0)
        ObjectsTree.Name = "ObjectsTree"
        ObjectsTree.ObjectList = Nothing
        ObjectsTree.Size = New Size(284, 561)
        ObjectsTree.SourceFilter = Nothing
        ObjectsTree.TabIndex = 0
        ' 
        ' Template_Explorer_Form
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(284, 561)
        Controls.Add(ObjectsTree)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Template_Explorer_Form"
        Text = "Objects Explorer"
        ResumeLayout(False)
    End Sub

    Friend WithEvents ObjectsTree As BG3Explorer_Templates

End Class
