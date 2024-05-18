<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BG3Cloner
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
        GroupBox1 = New GroupBox()
        Panel1 = New Panel()
        TableLayoutPanel2 = New TableLayoutPanel()
        RadioButtonItemOnly = New RadioButton()
        RadioButtonItemAndChilds = New RadioButton()
        RadioButtonOnlyChilds = New RadioButton()
        TableLayoutPanel1 = New TableLayoutPanel()
        RadioButtonOverride = New RadioButton()
        RadioButtonClone = New RadioButton()
        RadioButtonInherit = New RadioButton()
        Label1 = New Label()
        GroupBox1.SuspendLayout()
        Panel1.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(Panel1)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Dock = DockStyle.Fill
        GroupBox1.Location = New Point(0, 0)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(485, 288)
        GroupBox1.TabIndex = 0
        GroupBox1.TabStop = False
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(TableLayoutPanel2)
        Panel1.Controls.Add(TableLayoutPanel1)
        Panel1.Dock = DockStyle.Bottom
        Panel1.Location = New Point(3, 239)
        Panel1.Margin = New Padding(3, 0, 3, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(479, 46)
        Panel1.TabIndex = 7
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.ColumnCount = 3
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.33333F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333359F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333359F))
        TableLayoutPanel2.Controls.Add(RadioButtonItemOnly, 0, 0)
        TableLayoutPanel2.Controls.Add(RadioButtonItemAndChilds, 1, 0)
        TableLayoutPanel2.Controls.Add(RadioButtonOnlyChilds, 2, 0)
        TableLayoutPanel2.Dock = DockStyle.Bottom
        TableLayoutPanel2.Location = New Point(0, 23)
        TableLayoutPanel2.Margin = New Padding(3, 0, 3, 0)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 1
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Absolute, 23F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel2.Size = New Size(479, 23)
        TableLayoutPanel2.TabIndex = 11
        ' 
        ' RadioButtonItemOnly
        ' 
        RadioButtonItemOnly.AutoEllipsis = True
        RadioButtonItemOnly.Checked = True
        RadioButtonItemOnly.Dock = DockStyle.Fill
        RadioButtonItemOnly.Location = New Point(3, 0)
        RadioButtonItemOnly.Margin = New Padding(3, 0, 3, 0)
        RadioButtonItemOnly.Name = "RadioButtonItemOnly"
        RadioButtonItemOnly.Size = New Size(153, 23)
        RadioButtonItemOnly.TabIndex = 6
        RadioButtonItemOnly.TabStop = True
        RadioButtonItemOnly.Text = "Single item"
        RadioButtonItemOnly.UseVisualStyleBackColor = True
        ' 
        ' RadioButtonItemAndChilds
        ' 
        RadioButtonItemAndChilds.AutoEllipsis = True
        RadioButtonItemAndChilds.Dock = DockStyle.Fill
        RadioButtonItemAndChilds.Location = New Point(162, 0)
        RadioButtonItemAndChilds.Margin = New Padding(3, 0, 3, 0)
        RadioButtonItemAndChilds.Name = "RadioButtonItemAndChilds"
        RadioButtonItemAndChilds.Size = New Size(153, 23)
        RadioButtonItemAndChilds.TabIndex = 5
        RadioButtonItemAndChilds.Text = "Item and childs"
        RadioButtonItemAndChilds.UseVisualStyleBackColor = True
        ' 
        ' RadioButtonOnlyChilds
        ' 
        RadioButtonOnlyChilds.AutoEllipsis = True
        RadioButtonOnlyChilds.Dock = DockStyle.Fill
        RadioButtonOnlyChilds.Location = New Point(321, 0)
        RadioButtonOnlyChilds.Margin = New Padding(3, 0, 3, 0)
        RadioButtonOnlyChilds.Name = "RadioButtonOnlyChilds"
        RadioButtonOnlyChilds.Size = New Size(155, 23)
        RadioButtonOnlyChilds.TabIndex = 4
        RadioButtonOnlyChilds.Text = "Only childs"
        RadioButtonOnlyChilds.UseVisualStyleBackColor = True
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 3
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.33333F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333359F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333359F))
        TableLayoutPanel1.Controls.Add(RadioButtonOverride, 2, 0)
        TableLayoutPanel1.Controls.Add(RadioButtonClone, 1, 0)
        TableLayoutPanel1.Controls.Add(RadioButtonInherit, 0, 0)
        TableLayoutPanel1.Dock = DockStyle.Top
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Margin = New Padding(3, 0, 3, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 23F))
        TableLayoutPanel1.Size = New Size(479, 23)
        TableLayoutPanel1.TabIndex = 10
        ' 
        ' RadioButtonOverride
        ' 
        RadioButtonOverride.AutoEllipsis = True
        RadioButtonOverride.Dock = DockStyle.Fill
        RadioButtonOverride.Location = New Point(321, 0)
        RadioButtonOverride.Margin = New Padding(3, 0, 3, 0)
        RadioButtonOverride.Name = "RadioButtonOverride"
        RadioButtonOverride.Size = New Size(155, 23)
        RadioButtonOverride.TabIndex = 3
        RadioButtonOverride.Text = "Override"
        RadioButtonOverride.UseVisualStyleBackColor = True
        ' 
        ' RadioButtonClone
        ' 
        RadioButtonClone.AutoEllipsis = True
        RadioButtonClone.Dock = DockStyle.Fill
        RadioButtonClone.Location = New Point(162, 0)
        RadioButtonClone.Margin = New Padding(3, 0, 3, 0)
        RadioButtonClone.Name = "RadioButtonClone"
        RadioButtonClone.Size = New Size(153, 23)
        RadioButtonClone.TabIndex = 2
        RadioButtonClone.Text = "Clone"
        RadioButtonClone.UseVisualStyleBackColor = True
        ' 
        ' RadioButtonInherit
        ' 
        RadioButtonInherit.AutoEllipsis = True
        RadioButtonInherit.Checked = True
        RadioButtonInherit.Dock = DockStyle.Fill
        RadioButtonInherit.Location = New Point(3, 0)
        RadioButtonInherit.Margin = New Padding(3, 0, 3, 0)
        RadioButtonInherit.Name = "RadioButtonInherit"
        RadioButtonInherit.Size = New Size(153, 23)
        RadioButtonInherit.TabIndex = 1
        RadioButtonInherit.TabStop = True
        RadioButtonInherit.Text = "Inherit"
        RadioButtonInherit.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AllowDrop = True
        Label1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Label1.BackColor = SystemColors.Window
        Label1.BorderStyle = BorderStyle.FixedSingle
        Label1.Location = New Point(6, 13)
        Label1.Name = "Label1"
        Label1.Size = New Size(472, 218)
        Label1.TabIndex = 0
        Label1.Text = "Drop an object to clone"
        Label1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' BG3Cloner
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(GroupBox1)
        Name = "BG3Cloner"
        Size = New Size(485, 288)
        GroupBox1.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        TableLayoutPanel2.ResumeLayout(False)
        TableLayoutPanel1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RadioButtonOverride As RadioButton
    Friend WithEvents RadioButtonClone As RadioButton
    Friend WithEvents RadioButtonInherit As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents RadioButtonItemOnly As RadioButton
    Friend WithEvents RadioButtonItemAndChilds As RadioButton
    Friend WithEvents RadioButtonOnlyChilds As RadioButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel

End Class
