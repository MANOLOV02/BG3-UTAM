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
        GroupBox1.Size = New Size(711, 195)
        GroupBox1.TabIndex = 0
        GroupBox1.TabStop = False
        GroupBox1.Text = "Add from object"
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Panel1.Controls.Add(TableLayoutPanel2)
        Panel1.Controls.Add(TableLayoutPanel1)
        Panel1.Location = New Point(6, 141)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(699, 45)
        Panel1.TabIndex = 7
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.ColumnCount = 3
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel2.Controls.Add(RadioButtonItemOnly, 0, 0)
        TableLayoutPanel2.Controls.Add(RadioButtonItemAndChilds, 1, 0)
        TableLayoutPanel2.Controls.Add(RadioButtonOnlyChilds, 2, 0)
        TableLayoutPanel2.Dock = DockStyle.Bottom
        TableLayoutPanel2.Location = New Point(0, 22)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 1
        TableLayoutPanel2.RowStyles.Add(New RowStyle())
        TableLayoutPanel2.Size = New Size(699, 23)
        TableLayoutPanel2.TabIndex = 8
        ' 
        ' RadioButtonItemOnly
        ' 
        RadioButtonItemOnly.AutoSize = True
        RadioButtonItemOnly.Checked = True
        RadioButtonItemOnly.Location = New Point(3, 3)
        RadioButtonItemOnly.Name = "RadioButtonItemOnly"
        RadioButtonItemOnly.Size = New Size(84, 19)
        RadioButtonItemOnly.TabIndex = 6
        RadioButtonItemOnly.TabStop = True
        RadioButtonItemOnly.Text = "Single item"
        RadioButtonItemOnly.UseVisualStyleBackColor = True
        ' 
        ' RadioButtonItemAndChilds
        ' 
        RadioButtonItemAndChilds.AutoSize = True
        RadioButtonItemAndChilds.Location = New Point(236, 3)
        RadioButtonItemAndChilds.Name = "RadioButtonItemAndChilds"
        RadioButtonItemAndChilds.Size = New Size(106, 19)
        RadioButtonItemAndChilds.TabIndex = 5
        RadioButtonItemAndChilds.Text = "Item and childs"
        RadioButtonItemAndChilds.UseVisualStyleBackColor = True
        ' 
        ' RadioButtonOnlyChilds
        ' 
        RadioButtonOnlyChilds.AutoSize = True
        RadioButtonOnlyChilds.Location = New Point(469, 3)
        RadioButtonOnlyChilds.Name = "RadioButtonOnlyChilds"
        RadioButtonOnlyChilds.Size = New Size(84, 19)
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
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.Size = New Size(699, 23)
        TableLayoutPanel1.TabIndex = 1
        ' 
        ' RadioButtonOverride
        ' 
        RadioButtonOverride.AutoSize = True
        RadioButtonOverride.Location = New Point(468, 3)
        RadioButtonOverride.Name = "RadioButtonOverride"
        RadioButtonOverride.Size = New Size(70, 19)
        RadioButtonOverride.TabIndex = 3
        RadioButtonOverride.Text = "Override"
        RadioButtonOverride.UseVisualStyleBackColor = True
        ' 
        ' RadioButtonClone
        ' 
        RadioButtonClone.AutoSize = True
        RadioButtonClone.Location = New Point(235, 3)
        RadioButtonClone.Name = "RadioButtonClone"
        RadioButtonClone.Size = New Size(56, 19)
        RadioButtonClone.TabIndex = 2
        RadioButtonClone.Text = "Clone"
        RadioButtonClone.UseVisualStyleBackColor = True
        ' 
        ' RadioButtonInherit
        ' 
        RadioButtonInherit.AutoSize = True
        RadioButtonInherit.Checked = True
        RadioButtonInherit.Location = New Point(3, 3)
        RadioButtonInherit.Name = "RadioButtonInherit"
        RadioButtonInherit.Size = New Size(59, 19)
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
        Label1.Location = New Point(6, 19)
        Label1.Name = "Label1"
        Label1.Size = New Size(698, 119)
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
        Size = New Size(711, 195)
        GroupBox1.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        TableLayoutPanel2.ResumeLayout(False)
        TableLayoutPanel2.PerformLayout()
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents RadioButtonOverride As RadioButton
    Friend WithEvents RadioButtonClone As RadioButton
    Friend WithEvents RadioButtonInherit As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents RadioButtonItemOnly As RadioButton
    Friend WithEvents RadioButtonItemAndChilds As RadioButton
    Friend WithEvents RadioButtonOnlyChilds As RadioButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel

End Class
