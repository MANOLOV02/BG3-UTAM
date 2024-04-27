<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Information_Form_VisualTemplates
    Inherits Information_Form_Code

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
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Information_Form_VisualTemplates))
        Visual = New TabPage()
        XmLtoRichText2 = New BG3Visualizer_XML()
        TabControl1 = New TabControl()
        Visual.SuspendLayout()
        TabControl1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Visual
        ' 
        Visual.BackColor = Color.Transparent
        Visual.Controls.Add(XmLtoRichText2)
        Visual.Location = New Point(4, 27)
        Visual.Name = "Visual"
        Visual.Size = New Size(543, 253)
        Visual.TabIndex = 1
        Visual.Text = "Visual"
        ' 
        ' XmLtoRichText2
        ' 
        XmLtoRichText2.Dock = DockStyle.Fill
        XmLtoRichText2.IndentedText = True
        XmLtoRichText2.Location = New Point(0, 0)
        XmLtoRichText2.Name = "XmLtoRichText2"
        XmLtoRichText2.NamesColor = Color.Brown
        XmLtoRichText2.NodesColor = Color.Black
        XmLtoRichText2.Overridedolor = Color.Gray
        XmLtoRichText2.ReadOnly = True
        XmLtoRichText2.Size = New Size(543, 253)
        XmLtoRichText2.TabIndex = 0
        XmLtoRichText2.Text = ""
        XmLtoRichText2.ValueColor = Color.Blue
        XmLtoRichText2.WordWrap = False
        ' 
        ' TabControl1
        ' 
        TabControl1.Appearance = TabAppearance.FlatButtons
        TabControl1.Controls.Add(Visual)
        TabControl1.Dock = DockStyle.Fill
        TabControl1.Location = New Point(0, 0)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(551, 284)
        TabControl1.SizeMode = TabSizeMode.Fixed
        TabControl1.TabIndex = 16
        ' 
        ' Visuals_Information_Form
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(551, 284)
        Controls.Add(TabControl1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Visuals_Information_Form"
        Visual.ResumeLayout(False)
        TabControl1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents Visual As TabPage
    Friend WithEvents XmLtoRichText2 As BG3Visualizer_XML
    Friend WithEvents TabControl1 As TabControl

End Class
