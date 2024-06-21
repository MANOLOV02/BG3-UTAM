<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Generic_Visuals_Editor
    Inherits ExploraForm_code

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
        BG3Selector_Visuals1 = New BG3Selector_Visuals()
        TabPage1 = New TabPage()
        GroupBox9 = New GroupBox()
        TabControl1 = New TabControl()
        TabPageAttributes = New TabPage()
        GroupBoxAttributes = New GroupBox()
        BG3Editor_Complex_Advanced_Attributes1 = New BG3Editor_Complex_Advanced_Attributes()
        SplitContainer1 = New SplitContainer()
        TabPage1.SuspendLayout()
        TabControl1.SuspendLayout()
        TabPageAttributes.SuspendLayout()
        GroupBoxAttributes.SuspendLayout()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.Panel1.SuspendLayout()
        SplitContainer1.Panel2.SuspendLayout()
        SplitContainer1.SuspendLayout()
        SuspendLayout()
        ' 
        ' BG3Selector_Visuals1
        ' 
        BG3Selector_Visuals1.Dock = DockStyle.Fill
        BG3Selector_Visuals1.Location = New Point(0, 0)
        BG3Selector_Visuals1.Name = "BG3Selector_Visuals1"
        BG3Selector_Visuals1.Selection = BG3_Enum_UTAM_Type.Texture
        BG3Selector_Visuals1.Size = New Size(350, 596)
        BG3Selector_Visuals1.Stat_MustDescend_From = New String() {"None"}
        BG3Selector_Visuals1.TabIndex = 4
        BG3Selector_Visuals1.Template_MustDescend_From = New String() {"None"}
        ' 
        ' TabPage1
        ' 
        TabPage1.Controls.Add(GroupBox9)
        TabPage1.Location = New Point(4, 27)
        TabPage1.Name = "TabPage1"
        TabPage1.Size = New Size(807, 472)
        TabPage1.TabIndex = 0
        TabPage1.Text = "Main"
        ' 
        ' GroupBox9
        ' 
        GroupBox9.Dock = DockStyle.Fill
        GroupBox9.Location = New Point(0, 0)
        GroupBox9.Name = "GroupBox9"
        GroupBox9.Size = New Size(807, 472)
        GroupBox9.TabIndex = 4
        GroupBox9.TabStop = False
        ' 
        ' TabControl1
        ' 
        TabControl1.Appearance = TabAppearance.FlatButtons
        TabControl1.Controls.Add(TabPage1)
        TabControl1.Controls.Add(TabPageAttributes)
        TabControl1.Dock = DockStyle.Top
        TabControl1.Location = New Point(0, 0)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(815, 503)
        TabControl1.SizeMode = TabSizeMode.FillToRight
        TabControl1.TabIndex = 31
        ' 
        ' TabPageAttributes
        ' 
        TabPageAttributes.Controls.Add(GroupBoxAttributes)
        TabPageAttributes.Location = New Point(4, 27)
        TabPageAttributes.Name = "TabPageAttributes"
        TabPageAttributes.Size = New Size(807, 472)
        TabPageAttributes.TabIndex = 6
        TabPageAttributes.Text = "Attributes advanced"
        TabPageAttributes.UseVisualStyleBackColor = True
        ' 
        ' GroupBoxAttributes
        ' 
        GroupBoxAttributes.Controls.Add(BG3Editor_Complex_Advanced_Attributes1)
        GroupBoxAttributes.Dock = DockStyle.Fill
        GroupBoxAttributes.Location = New Point(0, 0)
        GroupBoxAttributes.Margin = New Padding(0)
        GroupBoxAttributes.Name = "GroupBoxAttributes"
        GroupBoxAttributes.Size = New Size(807, 472)
        GroupBoxAttributes.TabIndex = 1
        GroupBoxAttributes.TabStop = False
        ' 
        ' BG3Editor_Complex_Advanced_Attributes1
        ' 
        BG3Editor_Complex_Advanced_Attributes1.Dock = DockStyle.Fill
        BG3Editor_Complex_Advanced_Attributes1.Location = New Point(3, 19)
        BG3Editor_Complex_Advanced_Attributes1.Name = "BG3Editor_Complex_Advanced_Attributes1"
        BG3Editor_Complex_Advanced_Attributes1.Size = New Size(801, 450)
        BG3Editor_Complex_Advanced_Attributes1.TabIndex = 0
        ' 
        ' SplitContainer1
        ' 
        SplitContainer1.Dock = DockStyle.Fill
        SplitContainer1.FixedPanel = FixedPanel.Panel2
        SplitContainer1.IsSplitterFixed = True
        SplitContainer1.Location = New Point(0, 0)
        SplitContainer1.Name = "SplitContainer1"
        ' 
        ' SplitContainer1.Panel1
        ' 
        SplitContainer1.Panel1.Controls.Add(BG3Selector_Visuals1)
        ' 
        ' SplitContainer1.Panel2
        ' 
        SplitContainer1.Panel2.Controls.Add(TabControl1)
        SplitContainer1.Size = New Size(1169, 596)
        SplitContainer1.SplitterDistance = 350
        SplitContainer1.TabIndex = 36
        ' 
        ' Generic_Visuals_Editor
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1169, 596)
        Controls.Add(SplitContainer1)
        MinimumSize = New Size(0, 0)
        Name = "Generic_Visuals_Editor"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Generic Editor"
        TabPage1.ResumeLayout(False)
        TabControl1.ResumeLayout(False)
        TabPageAttributes.ResumeLayout(False)
        GroupBoxAttributes.ResumeLayout(False)
        SplitContainer1.Panel1.ResumeLayout(False)
        SplitContainer1.Panel2.ResumeLayout(False)
        CType(SplitContainer1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Protected Friend WithEvents BG3Selector_Visuals1 As BG3Selector_Visuals
    Protected Friend WithEvents TabPage1 As TabPage
    Protected Friend WithEvents GroupBox9 As GroupBox
    Protected Friend WithEvents TabControl1 As TabControl
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents TabPageAttributes As TabPage
    Friend WithEvents GroupBoxAttributes As GroupBox
    Friend WithEvents BG3Editor_Complex_Advanced_Attributes1 As BG3Editor_Complex_Advanced_Attributes
End Class
