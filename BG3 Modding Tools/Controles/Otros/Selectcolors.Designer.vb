<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Selectcolors
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        TableLayoutPanel1 = New TableLayoutPanel()
        PictureBox2 = New PictureBox()
        Label1 = New Label()
        Label2 = New Label()
        NumericUpDown1 = New NumericUpDown()
        Label3 = New Label()
        Label4 = New Label()
        NumericUpDown2 = New NumericUpDown()
        PictureBox1 = New PictureBox()
        Button1 = New Button()
        Button2 = New Button()
        TableLayoutPanel1.SuspendLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(NumericUpDown1, ComponentModel.ISupportInitialize).BeginInit()
        CType(NumericUpDown2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 4
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25F))
        TableLayoutPanel1.Controls.Add(PictureBox2, 1, 1)
        TableLayoutPanel1.Controls.Add(Label1, 0, 0)
        TableLayoutPanel1.Controls.Add(Label2, 0, 1)
        TableLayoutPanel1.Controls.Add(NumericUpDown1, 3, 0)
        TableLayoutPanel1.Controls.Add(Label3, 2, 0)
        TableLayoutPanel1.Controls.Add(Label4, 2, 1)
        TableLayoutPanel1.Controls.Add(NumericUpDown2, 3, 1)
        TableLayoutPanel1.Controls.Add(PictureBox1, 1, 0)
        TableLayoutPanel1.Controls.Add(Button1, 2, 2)
        TableLayoutPanel1.Controls.Add(Button2, 3, 2)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 3
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel1.Size = New Size(318, 77)
        TableLayoutPanel1.TabIndex = 0
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Dock = DockStyle.Fill
        PictureBox2.Location = New Point(82, 28)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(73, 19)
        PictureBox2.TabIndex = 7
        PictureBox2.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.Dock = DockStyle.Fill
        Label1.Location = New Point(3, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(73, 25)
        Label1.TabIndex = 0
        Label1.Text = "Value"
        Label1.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label2
        ' 
        Label2.Dock = DockStyle.Fill
        Label2.Location = New Point(3, 25)
        Label2.Name = "Label2"
        Label2.Size = New Size(73, 25)
        Label2.TabIndex = 1
        Label2.Text = "Base value"
        Label2.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' NumericUpDown1
        ' 
        NumericUpDown1.DecimalPlaces = 3
        NumericUpDown1.Dock = DockStyle.Fill
        NumericUpDown1.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        NumericUpDown1.Location = New Point(240, 3)
        NumericUpDown1.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        NumericUpDown1.Name = "NumericUpDown1"
        NumericUpDown1.Size = New Size(75, 23)
        NumericUpDown1.TabIndex = 2
        NumericUpDown1.TextAlign = HorizontalAlignment.Right
        ' 
        ' Label3
        ' 
        Label3.Dock = DockStyle.Fill
        Label3.Location = New Point(161, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(73, 25)
        Label3.TabIndex = 3
        Label3.Text = "Opacity"
        Label3.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label4
        ' 
        Label4.Dock = DockStyle.Fill
        Label4.Location = New Point(161, 25)
        Label4.Name = "Label4"
        Label4.Size = New Size(73, 25)
        Label4.TabIndex = 4
        Label4.Text = "Opacity"
        Label4.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' NumericUpDown2
        ' 
        NumericUpDown2.DecimalPlaces = 3
        NumericUpDown2.Dock = DockStyle.Fill
        NumericUpDown2.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        NumericUpDown2.Location = New Point(240, 28)
        NumericUpDown2.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        NumericUpDown2.Name = "NumericUpDown2"
        NumericUpDown2.Size = New Size(75, 23)
        NumericUpDown2.TabIndex = 5
        NumericUpDown2.TextAlign = HorizontalAlignment.Right
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Dock = DockStyle.Fill
        PictureBox1.Location = New Point(82, 3)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(73, 19)
        PictureBox1.TabIndex = 6
        PictureBox1.TabStop = False
        ' 
        ' Button1
        ' 
        Button1.DialogResult = DialogResult.OK
        Button1.Dock = DockStyle.Fill
        Button1.Location = New Point(161, 53)
        Button1.Name = "Button1"
        Button1.Size = New Size(73, 21)
        Button1.TabIndex = 8
        Button1.Text = "Ok"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.DialogResult = DialogResult.Cancel
        Button2.Dock = DockStyle.Fill
        Button2.Location = New Point(240, 53)
        Button2.Name = "Button2"
        Button2.Size = New Size(75, 21)
        Button2.TabIndex = 9
        Button2.Text = "Cancel"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Selectcolors
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(318, 77)
        Controls.Add(TableLayoutPanel1)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Name = "Selectcolors"
        StartPosition = FormStartPosition.CenterParent
        Text = "Color selection"
        TableLayoutPanel1.ResumeLayout(False)
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(NumericUpDown1, ComponentModel.ISupportInitialize).EndInit()
        CType(NumericUpDown2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents NumericUpDown2 As NumericUpDown
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
End Class
