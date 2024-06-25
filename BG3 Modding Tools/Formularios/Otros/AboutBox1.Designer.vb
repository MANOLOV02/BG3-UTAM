<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AboutBox1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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
    Friend WithEvents OKButton As System.Windows.Forms.Button

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AboutBox1))
        OKButton = New Button()
        Label1 = New Label()
        Label2 = New Label()
        LinkLabel1 = New LinkLabel()
        LinkLabel2 = New LinkLabel()
        Label3 = New Label()
        SuspendLayout()
        ' 
        ' OKButton
        ' 
        OKButton.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        OKButton.DialogResult = DialogResult.Cancel
        OKButton.Location = New Point(682, 528)
        OKButton.Margin = New Padding(4, 3, 4, 3)
        OKButton.Name = "OKButton"
        OKButton.Size = New Size(88, 27)
        OKButton.TabIndex = 0
        OKButton.Text = "&Ok"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.SpringGreen
        Label1.Location = New Point(148, 47)
        Label1.Name = "Label1"
        Label1.Size = New Size(570, 32)
        Label1.TabIndex = 1
        Label1.Text = "BG3 UTAM (Ultimate Tool for Amateur Modders)"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.SpringGreen
        Label2.Location = New Point(313, 79)
        Label2.Name = "Label2"
        Label2.Size = New Size(241, 32)
        Label2.TabIndex = 2
        Label2.Text = "Author: ManoloV02"
        ' 
        ' LinkLabel1
        ' 
        LinkLabel1.AutoSize = True
        LinkLabel1.BackColor = Color.Transparent
        LinkLabel1.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold)
        LinkLabel1.LinkColor = Color.Cyan
        LinkLabel1.Location = New Point(196, 111)
        LinkLabel1.Name = "LinkLabel1"
        LinkLabel1.Size = New Size(567, 30)
        LinkLabel1.TabIndex = 3
        LinkLabel1.TabStop = True
        LinkLabel1.Text = "https://www.nexusmods.com/baldursgate3/mods/9035 "
        LinkLabel1.VisitedLinkColor = Color.Silver
        ' 
        ' LinkLabel2
        ' 
        LinkLabel2.AutoSize = True
        LinkLabel2.BackColor = Color.Transparent
        LinkLabel2.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold)
        LinkLabel2.LinkColor = Color.Cyan
        LinkLabel2.Location = New Point(241, 141)
        LinkLabel2.Name = "LinkLabel2"
        LinkLabel2.Size = New Size(461, 30)
        LinkLabel2.TabIndex = 4
        LinkLabel2.TabStop = True
        LinkLabel2.Text = "https://github.com/MANOLOV02/BG3-UTAM"
        LinkLabel2.VisitedLinkColor = Color.Silver
        ' 
        ' Label3
        ' 
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.LightGray
        Label3.Location = New Point(31, 238)
        Label3.Name = "Label3"
        Label3.Size = New Size(242, 217)
        Label3.TabIndex = 5
        Label3.Text = "Acknowledgements:  \r\n •" & vbTab & "NorByte for its LSLIB Library without which anything of this would be impossible (https://github.com/Norbyte/lslib)"
        ' 
        ' AboutBox1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Center
        CancelButton = OKButton
        ClientSize = New Size(784, 561)
        Controls.Add(Label3)
        Controls.Add(LinkLabel2)
        Controls.Add(LinkLabel1)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(OKButton)
        DoubleBuffered = True
        FormBorderStyle = FormBorderStyle.FixedDialog
        Margin = New Padding(4, 3, 4, 3)
        MaximizeBox = False
        MinimizeBox = False
        Name = "AboutBox1"
        Padding = New Padding(10)
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterParent
        Text = "AboutBox1"
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents Label3 As Label

End Class
