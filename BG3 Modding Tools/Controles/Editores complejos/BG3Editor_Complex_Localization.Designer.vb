<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BG3Editor_Complex_Localization
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
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As DataGridViewCellStyle = New DataGridViewCellStyle()
        DataGridView1 = New DataGridView()
        SplitContainer1 = New SplitContainer()
        CheckBox1 = New CheckBox()
        PropertyName = New DataGridViewTextBoxColumn()
        MapKey = New DataGridViewTextBoxColumn()
        English = New DataGridViewTextBoxColumn()
        BrazilianPortuguese = New DataGridViewTextBoxColumn()
        Chinese = New DataGridViewTextBoxColumn()
        ChineseTraditional = New DataGridViewTextBoxColumn()
        French = New DataGridViewTextBoxColumn()
        German = New DataGridViewTextBoxColumn()
        Italian = New DataGridViewTextBoxColumn()
        Korean = New DataGridViewTextBoxColumn()
        LatinSpanish = New DataGridViewTextBoxColumn()
        Polish = New DataGridViewTextBoxColumn()
        Russian = New DataGridViewTextBoxColumn()
        Spanish = New DataGridViewTextBoxColumn()
        Turkish = New DataGridViewTextBoxColumn()
        Ukrainian = New DataGridViewTextBoxColumn()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.Panel1.SuspendLayout()
        SplitContainer1.Panel2.SuspendLayout()
        SplitContainer1.SuspendLayout()
        SuspendLayout()
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.AllowUserToOrderColumns = True
        DataGridView1.AllowUserToResizeRows = False
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Columns.AddRange(New DataGridViewColumn() {PropertyName, MapKey, English, BrazilianPortuguese, Chinese, ChineseTraditional, French, German, Italian, Korean, LatinSpanish, Polish, Russian, Spanish, Turkish, Ukrainian})
        DataGridView1.Dock = DockStyle.Fill
        DataGridView1.Enabled = False
        DataGridView1.Location = New Point(0, 0)
        DataGridView1.MultiSelect = False
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersVisible = False
        DataGridView1.Size = New Size(1240, 380)
        DataGridView1.TabIndex = 0
        ' 
        ' SplitContainer1
        ' 
        SplitContainer1.Dock = DockStyle.Fill
        SplitContainer1.FixedPanel = FixedPanel.Panel1
        SplitContainer1.Location = New Point(0, 0)
        SplitContainer1.Name = "SplitContainer1"
        SplitContainer1.Orientation = Orientation.Horizontal
        ' 
        ' SplitContainer1.Panel1
        ' 
        SplitContainer1.Panel1.Controls.Add(CheckBox1)
        ' 
        ' SplitContainer1.Panel2
        ' 
        SplitContainer1.Panel2.Controls.Add(DataGridView1)
        SplitContainer1.Size = New Size(1240, 409)
        SplitContainer1.SplitterDistance = 25
        SplitContainer1.TabIndex = 1
        ' 
        ' CheckBox1
        ' 
        CheckBox1.AutoSize = True
        CheckBox1.Location = New Point(3, 4)
        CheckBox1.Name = "CheckBox1"
        CheckBox1.Size = New Size(127, 19)
        CheckBox1.TabIndex = 0
        CheckBox1.Text = "Show all languages"
        CheckBox1.UseVisualStyleBackColor = True
        ' 
        ' PropertyName
        ' 
        PropertyName.DataPropertyName = "PropertyName"
        DataGridViewCellStyle4.BackColor = SystemColors.Control
        PropertyName.DefaultCellStyle = DataGridViewCellStyle4
        PropertyName.Frozen = True
        PropertyName.HeaderText = "Property"
        PropertyName.Name = "PropertyName"
        PropertyName.ReadOnly = True
        PropertyName.Width = 75
        ' 
        ' MapKey
        ' 
        MapKey.DataPropertyName = "MapKey"
        DataGridViewCellStyle5.BackColor = SystemColors.Control
        MapKey.DefaultCellStyle = DataGridViewCellStyle5
        MapKey.Frozen = True
        MapKey.HeaderText = "MapKey"
        MapKey.Name = "MapKey"
        MapKey.ReadOnly = True
        MapKey.Width = 75
        ' 
        ' English
        ' 
        English.DataPropertyName = "English"
        DataGridViewCellStyle6.BackColor = SystemColors.Control
        English.DefaultCellStyle = DataGridViewCellStyle6
        English.Frozen = True
        English.HeaderText = "English"
        English.Name = "English"
        English.ReadOnly = True
        English.Width = 75
        ' 
        ' BrazilianPortuguese
        ' 
        BrazilianPortuguese.DataPropertyName = "BrazilianPortuguese"
        BrazilianPortuguese.HeaderText = "BrazilianPortuguese"
        BrazilianPortuguese.Name = "BrazilianPortuguese"
        BrazilianPortuguese.Width = 75
        ' 
        ' Chinese
        ' 
        Chinese.DataPropertyName = "Chinese"
        Chinese.HeaderText = "Chinese"
        Chinese.Name = "Chinese"
        Chinese.Width = 75
        ' 
        ' ChineseTraditional
        ' 
        ChineseTraditional.DataPropertyName = "ChineseTraditional"
        ChineseTraditional.HeaderText = "ChineseTraditional"
        ChineseTraditional.Name = "ChineseTraditional"
        ChineseTraditional.Width = 75
        ' 
        ' French
        ' 
        French.DataPropertyName = "French"
        French.HeaderText = "French"
        French.Name = "French"
        French.Width = 75
        ' 
        ' German
        ' 
        German.DataPropertyName = "German"
        German.HeaderText = "German"
        German.Name = "German"
        German.Width = 75
        ' 
        ' Italian
        ' 
        Italian.DataPropertyName = "Italian"
        Italian.HeaderText = "Italian"
        Italian.Name = "Italian"
        Italian.Width = 75
        ' 
        ' Korean
        ' 
        Korean.DataPropertyName = "Korean"
        Korean.HeaderText = "Korean"
        Korean.Name = "Korean"
        Korean.Width = 75
        ' 
        ' LatinSpanish
        ' 
        LatinSpanish.DataPropertyName = "LatinSpanish"
        LatinSpanish.HeaderText = "LatinSpanish"
        LatinSpanish.Name = "LatinSpanish"
        LatinSpanish.Width = 75
        ' 
        ' Polish
        ' 
        Polish.DataPropertyName = "Polish"
        Polish.HeaderText = "Polish"
        Polish.Name = "Polish"
        Polish.Width = 75
        ' 
        ' Russian
        ' 
        Russian.DataPropertyName = "Russian"
        Russian.HeaderText = "Russian"
        Russian.Name = "Russian"
        Russian.Width = 75
        ' 
        ' Spanish
        ' 
        Spanish.DataPropertyName = "Spanish"
        Spanish.HeaderText = "Spanish"
        Spanish.Name = "Spanish"
        Spanish.Width = 75
        ' 
        ' Turkish
        ' 
        Turkish.DataPropertyName = "Turkish"
        Turkish.HeaderText = "Turkish"
        Turkish.Name = "Turkish"
        Turkish.Width = 75
        ' 
        ' Ukrainian
        ' 
        Ukrainian.DataPropertyName = "Ukrainian"
        Ukrainian.HeaderText = "Ukrainian"
        Ukrainian.Name = "Ukrainian"
        Ukrainian.Width = 75
        ' 
        ' BG3Editor_Complex_Localization
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(SplitContainer1)
        Name = "BG3Editor_Complex_Localization"
        Size = New Size(1240, 409)
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.Panel1.ResumeLayout(False)
        SplitContainer1.Panel1.PerformLayout()
        SplitContainer1.Panel2.ResumeLayout(False)
        CType(SplitContainer1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents PropertyName As DataGridViewTextBoxColumn
    Friend WithEvents MapKey As DataGridViewTextBoxColumn
    Friend WithEvents English As DataGridViewTextBoxColumn
    Friend WithEvents BrazilianPortuguese As DataGridViewTextBoxColumn
    Friend WithEvents Chinese As DataGridViewTextBoxColumn
    Friend WithEvents ChineseTraditional As DataGridViewTextBoxColumn
    Friend WithEvents French As DataGridViewTextBoxColumn
    Friend WithEvents German As DataGridViewTextBoxColumn
    Friend WithEvents Italian As DataGridViewTextBoxColumn
    Friend WithEvents Korean As DataGridViewTextBoxColumn
    Friend WithEvents LatinSpanish As DataGridViewTextBoxColumn
    Friend WithEvents Polish As DataGridViewTextBoxColumn
    Friend WithEvents Russian As DataGridViewTextBoxColumn
    Friend WithEvents Spanish As DataGridViewTextBoxColumn
    Friend WithEvents Turkish As DataGridViewTextBoxColumn
    Friend WithEvents Ukrainian As DataGridViewTextBoxColumn

End Class
