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
        SplitContainer1 = New SplitContainer()
        Label1 = New Label()
        SplitContainer2 = New SplitContainer()
        Panel1 = New Panel()
        NumericUpDown1 = New NumericUpDown()
        ComboBox1 = New ComboBox()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.Panel1.SuspendLayout()
        SplitContainer1.Panel2.SuspendLayout()
        SplitContainer1.SuspendLayout()
        CType(SplitContainer2, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer2.Panel1.SuspendLayout()
        SplitContainer2.Panel2.SuspendLayout()
        SplitContainer2.SuspendLayout()
        Panel1.SuspendLayout()
        CType(NumericUpDown1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' CheckBox1
        ' 
        CheckBox1.CheckAlign = ContentAlignment.MiddleCenter
        CheckBox1.Location = New Point(1, 3)
        CheckBox1.Name = "CheckBox1"
        CheckBox1.Size = New Size(20, 20)
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
        TextBox1.Size = New Size(384, 23)
        TextBox1.TabIndex = 2
        ' 
        ' SplitContainer1
        ' 
        SplitContainer1.Dock = DockStyle.Fill
        SplitContainer1.FixedPanel = FixedPanel.Panel1
        SplitContainer1.IsSplitterFixed = True
        SplitContainer1.Location = New Point(0, 0)
        SplitContainer1.Name = "SplitContainer1"
        ' 
        ' SplitContainer1.Panel1
        ' 
        SplitContainer1.Panel1.Controls.Add(Label1)
        ' 
        ' SplitContainer1.Panel2
        ' 
        SplitContainer1.Panel2.Controls.Add(SplitContainer2)
        SplitContainer1.Size = New Size(461, 23)
        SplitContainer1.SplitterWidth = 1
        SplitContainer1.TabIndex = 2
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Label1.AutoEllipsis = True
        Label1.Location = New Point(1, 4)
        Label1.Name = "Label1"
        Label1.Size = New Size(48, 16)
        Label1.TabIndex = 0
        Label1.Text = "Select a label to show"
        Label1.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' SplitContainer2
        ' 
        SplitContainer2.Dock = DockStyle.Fill
        SplitContainer2.FixedPanel = FixedPanel.Panel1
        SplitContainer2.IsSplitterFixed = True
        SplitContainer2.Location = New Point(0, 0)
        SplitContainer2.Name = "SplitContainer2"
        ' 
        ' SplitContainer2.Panel1
        ' 
        SplitContainer2.Panel1.Controls.Add(CheckBox1)
        SplitContainer2.Panel1MinSize = 22
        ' 
        ' SplitContainer2.Panel2
        ' 
        SplitContainer2.Panel2.Controls.Add(Panel1)
        SplitContainer2.Size = New Size(410, 23)
        SplitContainer2.SplitterDistance = 25
        SplitContainer2.SplitterWidth = 1
        SplitContainer2.TabIndex = 6
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(NumericUpDown1)
        Panel1.Controls.Add(TextBox1)
        Panel1.Controls.Add(ComboBox1)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(384, 23)
        Panel1.TabIndex = 5
        ' 
        ' NumericUpDown1
        ' 
        NumericUpDown1.Dock = DockStyle.Fill
        NumericUpDown1.Location = New Point(0, 0)
        NumericUpDown1.Margin = New Padding(0)
        NumericUpDown1.Name = "NumericUpDown1"
        NumericUpDown1.ReadOnly = True
        NumericUpDown1.Size = New Size(384, 23)
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
        ComboBox1.Size = New Size(384, 23)
        ComboBox1.TabIndex = 3
        ComboBox1.Visible = False
        ' 
        ' BG3_Value_Editor_Generic
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(SplitContainer1)
        Margin = New Padding(0)
        MaximumSize = New Size(3000, 23)
        MinimumSize = New Size(100, 23)
        Name = "BG3_Value_Editor_Generic"
        Size = New Size(461, 23)
        SplitContainer1.Panel1.ResumeLayout(False)
        SplitContainer1.Panel2.ResumeLayout(False)
        CType(SplitContainer1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
        SplitContainer2.Panel1.ResumeLayout(False)
        SplitContainer2.Panel2.ResumeLayout(False)
        CType(SplitContainer2, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer2.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(NumericUpDown1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Label1 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents Panel1 As Panel
    Friend WithEvents SplitContainer2 As SplitContainer

End Class
