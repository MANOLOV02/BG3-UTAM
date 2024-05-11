<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial MustInherit Class BG3_Value_Editor_Generic
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
        CheckBox1 = New CheckBox()
        TextBox1 = New TextBox()
        Label1 = New Label()
        PictureBox1 = New PictureBox()
        Panel1 = New Panel()
        NumericUpDown1 = New NumericUpDown()
        ComboBox1 = New ComboBox()
        TableLayoutPanel1 = New TableLayoutPanel()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        CType(NumericUpDown1, ComponentModel.ISupportInitialize).BeginInit()
        TableLayoutPanel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' CheckBox1
        ' 
        CheckBox1.CheckAlign = ContentAlignment.MiddleCenter
        CheckBox1.Dock = DockStyle.Left
        CheckBox1.Location = New Point(120, 0)
        CheckBox1.Margin = New Padding(0)
        CheckBox1.Name = "CheckBox1"
        CheckBox1.Size = New Size(20, 23)
        CheckBox1.TabIndex = 1
        CheckBox1.UseVisualStyleBackColor = True
        ' 
        ' TextBox1
        ' 
        TextBox1.AllowDrop = True
        TextBox1.Dock = DockStyle.Fill
        TextBox1.Location = New Point(0, 0)
        TextBox1.Margin = New Padding(0)
        TextBox1.Name = "TextBox1"
        TextBox1.ReadOnly = True
        TextBox1.Size = New Size(795, 23)
        TextBox1.TabIndex = 2
        ' 
        ' Label1
        ' 
        Label1.AutoEllipsis = True
        Label1.Dock = DockStyle.Fill
        Label1.Location = New Point(0, 0)
        Label1.Margin = New Padding(0)
        Label1.Name = "Label1"
        Label1.Size = New Size(100, 23)
        Label1.TabIndex = 0
        Label1.Text = "Select a label to show"
        Label1.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImage = My.Resources.Resources.drag_and_drop
        PictureBox1.BackgroundImageLayout = ImageLayout.Center
        PictureBox1.Dock = DockStyle.Left
        PictureBox1.Location = New Point(103, 3)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(14, 17)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(NumericUpDown1)
        Panel1.Controls.Add(TextBox1)
        Panel1.Controls.Add(ComboBox1)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(140, 0)
        Panel1.Margin = New Padding(0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(795, 23)
        Panel1.TabIndex = 5
        ' 
        ' NumericUpDown1
        ' 
        NumericUpDown1.Dock = DockStyle.Fill
        NumericUpDown1.Location = New Point(0, 0)
        NumericUpDown1.Margin = New Padding(0)
        NumericUpDown1.Name = "NumericUpDown1"
        NumericUpDown1.ReadOnly = True
        NumericUpDown1.Size = New Size(795, 23)
        NumericUpDown1.TabIndex = 4
        NumericUpDown1.TextAlign = HorizontalAlignment.Right
        NumericUpDown1.Visible = False
        ' 
        ' ComboBox1
        ' 
        ComboBox1.Dock = DockStyle.Fill
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox1.Enabled = False
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(0, 0)
        ComboBox1.Margin = New Padding(0)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(795, 23)
        ComboBox1.TabIndex = 3
        ComboBox1.Visible = False
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 4
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 100F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Controls.Add(Panel1, 3, 0)
        TableLayoutPanel1.Controls.Add(Label1, 0, 0)
        TableLayoutPanel1.Controls.Add(CheckBox1, 2, 0)
        TableLayoutPanel1.Controls.Add(PictureBox1, 1, 0)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Margin = New Padding(0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Size = New Size(935, 23)
        TableLayoutPanel1.TabIndex = 3
        ' 
        ' BG3_Value_Editor_Generic
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(TableLayoutPanel1)
        Margin = New Padding(0)
        MaximumSize = New Size(3000, 23)
        MinimumSize = New Size(100, 23)
        Name = "BG3_Value_Editor_Generic"
        Size = New Size(935, 23)
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(NumericUpDown1, ComponentModel.ISupportInitialize).EndInit()
        TableLayoutPanel1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel

End Class
