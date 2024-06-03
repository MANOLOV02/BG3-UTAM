<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ExploraForm_code
    Inherits System.Windows.Forms.Form

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
        SuspendLayout()
        ' 
        ' ExploraForm_code
        ' 
        AllowDrop = True
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(284, 261)
        FormBorderStyle = FormBorderStyle.SizableToolWindow
        MaximizeBox = False
        MinimizeBox = False
        MinimumSize = New Size(300, 300)
        Name = "ExploraForm_code"
        Text = "Generic Explorer"
        ResumeLayout(False)
    End Sub

End Class
