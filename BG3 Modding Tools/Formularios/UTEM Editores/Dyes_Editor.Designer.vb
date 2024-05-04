<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dyes_Editor
    Inherits Generic_Editor

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
        BG3Editor_Template_ColorPreset1 = New BG3Editor_Template_ColorPreset()
        BG3Editor_Stat_Special_RemoverDye1 = New BG3Editor_Stat_Special_RemoverDye()
        BG3Editor_Stat_Special_UnlimitedDye1 = New BG3Editor_Stat_Special_UnlimitedDye()
        GroupBox5 = New GroupBox()
        BG3Editor_Template_DyeColorView15 = New BG3Editor_Template_DyeColorView()
        BG3Editor_Template_DyeColorView14 = New BG3Editor_Template_DyeColorView()
        BG3Editor_Template_DyeColorView13 = New BG3Editor_Template_DyeColorView()
        BG3Editor_Template_DyeColorView12 = New BG3Editor_Template_DyeColorView()
        BG3Editor_Template_DyeColorView11 = New BG3Editor_Template_DyeColorView()
        BG3Editor_Template_DyeColorView10 = New BG3Editor_Template_DyeColorView()
        BG3Editor_Template_DyeColorView9 = New BG3Editor_Template_DyeColorView()
        BG3Editor_Template_DyeColorView8 = New BG3Editor_Template_DyeColorView()
        BG3Editor_Template_DyeColorView7 = New BG3Editor_Template_DyeColorView()
        BG3Editor_Template_DyeColorView6 = New BG3Editor_Template_DyeColorView()
        BG3Editor_Template_DyeColorView5 = New BG3Editor_Template_DyeColorView()
        BG3Editor_Template_DyeColorView4 = New BG3Editor_Template_DyeColorView()
        BG3Editor_Template_DyeColorView3 = New BG3Editor_Template_DyeColorView()
        BG3Editor_Template_DyeColorView2 = New BG3Editor_Template_DyeColorView()
        BG3Editor_Template_DyeColorView1 = New BG3Editor_Template_DyeColorView()
        TabPage4 = New TabPage()
        GroupBox6 = New GroupBox()
        BG3Editor_Complex_Dyecolor1 = New BG3Editor_Complex_Dyecolor()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox3.SuspendLayout()
        TabPage3.SuspendLayout()
        GroupBox8.SuspendLayout()
        TabPage5.SuspendLayout()
        GroupBox10.SuspendLayout()
        TabPage2.SuspendLayout()
        GroupBox7.SuspendLayout()
        TabPage1.SuspendLayout()
        GroupBox9.SuspendLayout()
        GroupBox1.SuspendLayout()
        GroupBox2.SuspendLayout()
        GroupBox4.SuspendLayout()
        TabControl1.SuspendLayout()
        GroupBox5.SuspendLayout()
        TabPage4.SuspendLayout()
        GroupBox6.SuspendLayout()
        SuspendLayout()
        ' 
        ' BG3Selector_Template1
        ' 
        BG3Selector_Template1.Selection = BG3_Enum_UTAM_Type.Containers
        ' 
        ' GroupBox9
        ' 
        GroupBox9.Controls.Add(GroupBox5)
        GroupBox9.Controls.SetChildIndex(GroupBox4, 0)
        GroupBox9.Controls.SetChildIndex(GroupBox2, 0)
        GroupBox9.Controls.SetChildIndex(GroupBox1, 0)
        GroupBox9.Controls.SetChildIndex(BG3Cloner1, 0)
        GroupBox9.Controls.SetChildIndex(GroupBox5, 0)
        ' 
        ' BG3Cloner1
        ' 
        BG3Cloner1.Label = "Drop a dye stat or dye template to add new from it. They must be dyes descendants"
        BG3Cloner1.Stat_MustDescend_From = {"_Dyes"}
        BG3Cloner1.Template_MustDescend_From = {"1a750a66-e5c2-40be-9f62-0a4bf3ddb403"}
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(BG3Editor_Template_ColorPreset1)
        GroupBox1.Controls.SetChildIndex(BG3Editor_Template_Parent1, 0)
        GroupBox1.Controls.SetChildIndex(BG3Editor_Template_Mapkey1, 0)
        GroupBox1.Controls.SetChildIndex(BG3Editor_Template_Type1, 0)
        GroupBox1.Controls.SetChildIndex(BG3Editor_Template_Name1, 0)
        GroupBox1.Controls.SetChildIndex(BG3Editor_Template_StoryItem1, 0)
        GroupBox1.Controls.SetChildIndex(BG3Editor_Template_ColorPreset1, 0)
        ' 
        ' BG3Editor_Template_Name1
        ' 
        BG3Editor_Template_Name1.EditorType = BG3_Editor_Type.Textbox
        ' 
        ' BG3Editor_Template_Mapkey1
        ' 
        BG3Editor_Template_Mapkey1.EditorType = BG3_Editor_Type.Textbox
        ' 
        ' BG3Editor_Template_Parent1
        ' 
        BG3Editor_Template_Parent1.EditorType = BG3_Editor_Type.Textbox
        BG3Editor_Template_Parent1.MustDescendFrom = {"1a750a66-e5c2-40be-9f62-0a4bf3ddb403"}
        ' 
        ' BG3Editor_Template_TechnicalDescription1
        ' 
        BG3Editor_Template_TechnicalDescription1.EditorType = BG3_Editor_Type.Textbox
        ' 
        ' BG3Editor_Template_Description1
        ' 
        BG3Editor_Template_Description1.EditorType = BG3_Editor_Type.Textbox
        ' 
        ' BG3Editor_Template_DisplayName1
        ' 
        BG3Editor_Template_DisplayName1.EditorType = BG3_Editor_Type.Textbox
        ' 
        ' BG3Editor_Template_Icon1
        ' 
        BG3Editor_Template_Icon1.EditorType = BG3_Editor_Type.Textbox
        ' 
        ' BG3Editor_Template_VisualTemplate1
        ' 
        BG3Editor_Template_VisualTemplate1.EditorType = BG3_Editor_Type.Textbox
        ' 
        ' GroupBox4
        ' 
        GroupBox4.Controls.Add(BG3Editor_Stat_Special_RemoverDye1)
        GroupBox4.Controls.Add(BG3Editor_Stat_Special_UnlimitedDye1)
        GroupBox4.Controls.SetChildIndex(BG3Editor_Stat_Using1, 0)
        GroupBox4.Controls.SetChildIndex(BG3Editor_Stat_Weight1, 0)
        GroupBox4.Controls.SetChildIndex(BG3Editor_Stat_Type1, 0)
        GroupBox4.Controls.SetChildIndex(BG3Editor_Stat_Rarity1, 0)
        GroupBox4.Controls.SetChildIndex(BG3Editor_Stat_ValueOverride1, 0)
        GroupBox4.Controls.SetChildIndex(BG3Editor_Stat_Unique1, 0)
        GroupBox4.Controls.SetChildIndex(BG3Editor_Stat_Special_UnlimitedDye1, 0)
        GroupBox4.Controls.SetChildIndex(BG3Editor_Template_Stats1, 0)
        GroupBox4.Controls.SetChildIndex(BG3Editor_Stat_Special_RemoverDye1, 0)
        ' 
        ' BG3Editor_Template_Stats1
        ' 
        BG3Editor_Template_Stats1.EditorType = BG3_Editor_Type.Textbox
        ' 
        ' BG3Editor_Stat_Using1
        ' 
        BG3Editor_Stat_Using1.EditorType = BG3_Editor_Type.Textbox
        BG3Editor_Stat_Using1.MustDescendFrom = {"_Dyes"}
        ' 
        ' TabControl1
        ' 
        TabControl1.Controls.Add(TabPage4)
        TabControl1.Controls.SetChildIndex(TabPage3, 0)
        TabControl1.Controls.SetChildIndex(TabPage5, 0)
        TabControl1.Controls.SetChildIndex(TabPage2, 0)
        TabControl1.Controls.SetChildIndex(TabPage4, 0)
        TabControl1.Controls.SetChildIndex(TabPage1, 0)
        ' 
        ' BG3Editor_Template_ColorPreset1
        ' 
        BG3Editor_Template_ColorPreset1.AllowEdit = False
        BG3Editor_Template_ColorPreset1.EditIsConditional = False
        BG3Editor_Template_ColorPreset1.Label = "Color preset"
        BG3Editor_Template_ColorPreset1.Location = New Point(6, 111)
        BG3Editor_Template_ColorPreset1.Margin = New Padding(0)
        BG3Editor_Template_ColorPreset1.MaximumSize = New Size(2000, 23)
        BG3Editor_Template_ColorPreset1.MinimumSize = New Size(0, 23)
        BG3Editor_Template_ColorPreset1.Name = "BG3Editor_Template_ColorPreset1"
        BG3Editor_Template_ColorPreset1.Size = New Size(392, 23)
        BG3Editor_Template_ColorPreset1.SplitterDistance = 100
        BG3Editor_Template_ColorPreset1.TabIndex = 36
        ' 
        ' BG3Editor_Stat_Special_RemoverDye1
        ' 
        BG3Editor_Stat_Special_RemoverDye1.EditIsConditional = False
        BG3Editor_Stat_Special_RemoverDye1.EditorType = BG3_Editor_Type.Combobox
        BG3Editor_Stat_Special_RemoverDye1.Label = "Remover"
        BG3Editor_Stat_Special_RemoverDye1.Location = New Point(241, 134)
        BG3Editor_Stat_Special_RemoverDye1.Margin = New Padding(0)
        BG3Editor_Stat_Special_RemoverDye1.MaximumSize = New Size(2000, 23)
        BG3Editor_Stat_Special_RemoverDye1.MinimumSize = New Size(0, 23)
        BG3Editor_Stat_Special_RemoverDye1.Name = "BG3Editor_Stat_Special_RemoverDye1"
        BG3Editor_Stat_Special_RemoverDye1.ShowConditional = False
        BG3Editor_Stat_Special_RemoverDye1.Size = New Size(157, 23)
        BG3Editor_Stat_Special_RemoverDye1.SplitterDistance = 80
        BG3Editor_Stat_Special_RemoverDye1.TabIndex = 12
        ' 
        ' BG3Editor_Stat_Special_UnlimitedDye1
        ' 
        BG3Editor_Stat_Special_UnlimitedDye1.EditIsConditional = False
        BG3Editor_Stat_Special_UnlimitedDye1.EditorType = BG3_Editor_Type.Combobox
        BG3Editor_Stat_Special_UnlimitedDye1.Label = "Unlimited"
        BG3Editor_Stat_Special_UnlimitedDye1.Location = New Point(241, 111)
        BG3Editor_Stat_Special_UnlimitedDye1.Margin = New Padding(0)
        BG3Editor_Stat_Special_UnlimitedDye1.MaximumSize = New Size(2000, 23)
        BG3Editor_Stat_Special_UnlimitedDye1.MinimumSize = New Size(0, 23)
        BG3Editor_Stat_Special_UnlimitedDye1.Name = "BG3Editor_Stat_Special_UnlimitedDye1"
        BG3Editor_Stat_Special_UnlimitedDye1.ShowConditional = False
        BG3Editor_Stat_Special_UnlimitedDye1.Size = New Size(157, 23)
        BG3Editor_Stat_Special_UnlimitedDye1.SplitterDistance = 80
        BG3Editor_Stat_Special_UnlimitedDye1.TabIndex = 11
        ' 
        ' GroupBox5
        ' 
        GroupBox5.Controls.Add(BG3Editor_Template_DyeColorView15)
        GroupBox5.Controls.Add(BG3Editor_Template_DyeColorView14)
        GroupBox5.Controls.Add(BG3Editor_Template_DyeColorView13)
        GroupBox5.Controls.Add(BG3Editor_Template_DyeColorView12)
        GroupBox5.Controls.Add(BG3Editor_Template_DyeColorView11)
        GroupBox5.Controls.Add(BG3Editor_Template_DyeColorView10)
        GroupBox5.Controls.Add(BG3Editor_Template_DyeColorView9)
        GroupBox5.Controls.Add(BG3Editor_Template_DyeColorView8)
        GroupBox5.Controls.Add(BG3Editor_Template_DyeColorView7)
        GroupBox5.Controls.Add(BG3Editor_Template_DyeColorView6)
        GroupBox5.Controls.Add(BG3Editor_Template_DyeColorView5)
        GroupBox5.Controls.Add(BG3Editor_Template_DyeColorView4)
        GroupBox5.Controls.Add(BG3Editor_Template_DyeColorView3)
        GroupBox5.Controls.Add(BG3Editor_Template_DyeColorView2)
        GroupBox5.Controls.Add(BG3Editor_Template_DyeColorView1)
        GroupBox5.Location = New Point(425, 10)
        GroupBox5.Name = "GroupBox5"
        GroupBox5.Size = New Size(385, 256)
        GroupBox5.TabIndex = 9
        GroupBox5.TabStop = False
        GroupBox5.Text = "Colors"
        ' 
        ' BG3Editor_Template_DyeColorView15
        ' 
        BG3Editor_Template_DyeColorView15.ColorIndex = 14
        BG3Editor_Template_DyeColorView15.Location = New Point(196, 144)
        BG3Editor_Template_DyeColorView15.MaximumSize = New Size(3000, 23)
        BG3Editor_Template_DyeColorView15.MinimumSize = New Size(100, 23)
        BG3Editor_Template_DyeColorView15.Name = "BG3Editor_Template_DyeColorView15"
        BG3Editor_Template_DyeColorView15.Size = New Size(173, 23)
        BG3Editor_Template_DyeColorView15.TabIndex = 62
        ' 
        ' BG3Editor_Template_DyeColorView14
        ' 
        BG3Editor_Template_DyeColorView14.ColorIndex = 13
        BG3Editor_Template_DyeColorView14.Location = New Point(196, 119)
        BG3Editor_Template_DyeColorView14.MaximumSize = New Size(3000, 23)
        BG3Editor_Template_DyeColorView14.MinimumSize = New Size(100, 23)
        BG3Editor_Template_DyeColorView14.Name = "BG3Editor_Template_DyeColorView14"
        BG3Editor_Template_DyeColorView14.Size = New Size(173, 23)
        BG3Editor_Template_DyeColorView14.TabIndex = 61
        ' 
        ' BG3Editor_Template_DyeColorView13
        ' 
        BG3Editor_Template_DyeColorView13.ColorIndex = 12
        BG3Editor_Template_DyeColorView13.Location = New Point(196, 94)
        BG3Editor_Template_DyeColorView13.MaximumSize = New Size(3000, 23)
        BG3Editor_Template_DyeColorView13.MinimumSize = New Size(100, 23)
        BG3Editor_Template_DyeColorView13.Name = "BG3Editor_Template_DyeColorView13"
        BG3Editor_Template_DyeColorView13.Size = New Size(173, 23)
        BG3Editor_Template_DyeColorView13.TabIndex = 60
        ' 
        ' BG3Editor_Template_DyeColorView12
        ' 
        BG3Editor_Template_DyeColorView12.ColorIndex = 11
        BG3Editor_Template_DyeColorView12.Location = New Point(196, 69)
        BG3Editor_Template_DyeColorView12.MaximumSize = New Size(3000, 23)
        BG3Editor_Template_DyeColorView12.MinimumSize = New Size(100, 23)
        BG3Editor_Template_DyeColorView12.Name = "BG3Editor_Template_DyeColorView12"
        BG3Editor_Template_DyeColorView12.Size = New Size(173, 23)
        BG3Editor_Template_DyeColorView12.TabIndex = 59
        ' 
        ' BG3Editor_Template_DyeColorView11
        ' 
        BG3Editor_Template_DyeColorView11.ColorIndex = 10
        BG3Editor_Template_DyeColorView11.Location = New Point(196, 44)
        BG3Editor_Template_DyeColorView11.MaximumSize = New Size(3000, 23)
        BG3Editor_Template_DyeColorView11.MinimumSize = New Size(100, 23)
        BG3Editor_Template_DyeColorView11.Name = "BG3Editor_Template_DyeColorView11"
        BG3Editor_Template_DyeColorView11.Size = New Size(173, 23)
        BG3Editor_Template_DyeColorView11.TabIndex = 58
        ' 
        ' BG3Editor_Template_DyeColorView10
        ' 
        BG3Editor_Template_DyeColorView10.ColorIndex = 9
        BG3Editor_Template_DyeColorView10.Location = New Point(196, 19)
        BG3Editor_Template_DyeColorView10.MaximumSize = New Size(3000, 23)
        BG3Editor_Template_DyeColorView10.MinimumSize = New Size(100, 23)
        BG3Editor_Template_DyeColorView10.Name = "BG3Editor_Template_DyeColorView10"
        BG3Editor_Template_DyeColorView10.Size = New Size(173, 23)
        BG3Editor_Template_DyeColorView10.TabIndex = 57
        ' 
        ' BG3Editor_Template_DyeColorView9
        ' 
        BG3Editor_Template_DyeColorView9.ColorIndex = 8
        BG3Editor_Template_DyeColorView9.Location = New Point(6, 219)
        BG3Editor_Template_DyeColorView9.MaximumSize = New Size(3000, 23)
        BG3Editor_Template_DyeColorView9.MinimumSize = New Size(100, 23)
        BG3Editor_Template_DyeColorView9.Name = "BG3Editor_Template_DyeColorView9"
        BG3Editor_Template_DyeColorView9.Size = New Size(173, 23)
        BG3Editor_Template_DyeColorView9.TabIndex = 56
        ' 
        ' BG3Editor_Template_DyeColorView8
        ' 
        BG3Editor_Template_DyeColorView8.ColorIndex = 7
        BG3Editor_Template_DyeColorView8.Location = New Point(6, 194)
        BG3Editor_Template_DyeColorView8.MaximumSize = New Size(3000, 23)
        BG3Editor_Template_DyeColorView8.MinimumSize = New Size(100, 23)
        BG3Editor_Template_DyeColorView8.Name = "BG3Editor_Template_DyeColorView8"
        BG3Editor_Template_DyeColorView8.Size = New Size(173, 23)
        BG3Editor_Template_DyeColorView8.TabIndex = 55
        ' 
        ' BG3Editor_Template_DyeColorView7
        ' 
        BG3Editor_Template_DyeColorView7.ColorIndex = 6
        BG3Editor_Template_DyeColorView7.Location = New Point(6, 169)
        BG3Editor_Template_DyeColorView7.MaximumSize = New Size(3000, 23)
        BG3Editor_Template_DyeColorView7.MinimumSize = New Size(100, 23)
        BG3Editor_Template_DyeColorView7.Name = "BG3Editor_Template_DyeColorView7"
        BG3Editor_Template_DyeColorView7.Size = New Size(173, 23)
        BG3Editor_Template_DyeColorView7.TabIndex = 54
        ' 
        ' BG3Editor_Template_DyeColorView6
        ' 
        BG3Editor_Template_DyeColorView6.ColorIndex = 5
        BG3Editor_Template_DyeColorView6.Location = New Point(6, 144)
        BG3Editor_Template_DyeColorView6.MaximumSize = New Size(3000, 23)
        BG3Editor_Template_DyeColorView6.MinimumSize = New Size(100, 23)
        BG3Editor_Template_DyeColorView6.Name = "BG3Editor_Template_DyeColorView6"
        BG3Editor_Template_DyeColorView6.Size = New Size(173, 23)
        BG3Editor_Template_DyeColorView6.TabIndex = 53
        ' 
        ' BG3Editor_Template_DyeColorView5
        ' 
        BG3Editor_Template_DyeColorView5.ColorIndex = 4
        BG3Editor_Template_DyeColorView5.Location = New Point(6, 119)
        BG3Editor_Template_DyeColorView5.MaximumSize = New Size(3000, 23)
        BG3Editor_Template_DyeColorView5.MinimumSize = New Size(100, 23)
        BG3Editor_Template_DyeColorView5.Name = "BG3Editor_Template_DyeColorView5"
        BG3Editor_Template_DyeColorView5.Size = New Size(173, 23)
        BG3Editor_Template_DyeColorView5.TabIndex = 52
        ' 
        ' BG3Editor_Template_DyeColorView4
        ' 
        BG3Editor_Template_DyeColorView4.ColorIndex = 3
        BG3Editor_Template_DyeColorView4.Location = New Point(6, 94)
        BG3Editor_Template_DyeColorView4.MaximumSize = New Size(3000, 23)
        BG3Editor_Template_DyeColorView4.MinimumSize = New Size(100, 23)
        BG3Editor_Template_DyeColorView4.Name = "BG3Editor_Template_DyeColorView4"
        BG3Editor_Template_DyeColorView4.Size = New Size(173, 23)
        BG3Editor_Template_DyeColorView4.TabIndex = 51
        ' 
        ' BG3Editor_Template_DyeColorView3
        ' 
        BG3Editor_Template_DyeColorView3.ColorIndex = 2
        BG3Editor_Template_DyeColorView3.Location = New Point(6, 69)
        BG3Editor_Template_DyeColorView3.MaximumSize = New Size(3000, 23)
        BG3Editor_Template_DyeColorView3.MinimumSize = New Size(100, 23)
        BG3Editor_Template_DyeColorView3.Name = "BG3Editor_Template_DyeColorView3"
        BG3Editor_Template_DyeColorView3.Size = New Size(173, 23)
        BG3Editor_Template_DyeColorView3.TabIndex = 50
        ' 
        ' BG3Editor_Template_DyeColorView2
        ' 
        BG3Editor_Template_DyeColorView2.ColorIndex = 1
        BG3Editor_Template_DyeColorView2.Location = New Point(6, 44)
        BG3Editor_Template_DyeColorView2.MaximumSize = New Size(3000, 23)
        BG3Editor_Template_DyeColorView2.MinimumSize = New Size(100, 23)
        BG3Editor_Template_DyeColorView2.Name = "BG3Editor_Template_DyeColorView2"
        BG3Editor_Template_DyeColorView2.Size = New Size(173, 23)
        BG3Editor_Template_DyeColorView2.TabIndex = 49
        ' 
        ' BG3Editor_Template_DyeColorView1
        ' 
        BG3Editor_Template_DyeColorView1.ColorIndex = 0
        BG3Editor_Template_DyeColorView1.Location = New Point(6, 19)
        BG3Editor_Template_DyeColorView1.MaximumSize = New Size(3000, 23)
        BG3Editor_Template_DyeColorView1.MinimumSize = New Size(100, 23)
        BG3Editor_Template_DyeColorView1.Name = "BG3Editor_Template_DyeColorView1"
        BG3Editor_Template_DyeColorView1.Size = New Size(173, 23)
        BG3Editor_Template_DyeColorView1.TabIndex = 48
        ' 
        ' TabPage4
        ' 
        TabPage4.Controls.Add(GroupBox6)
        TabPage4.Location = New Point(4, 27)
        TabPage4.Name = "TabPage4"
        TabPage4.Size = New Size(816, 473)
        TabPage4.TabIndex = 5
        TabPage4.Text = "Colors definitions"
        ' 
        ' GroupBox6
        ' 
        GroupBox6.Controls.Add(BG3Editor_Complex_Dyecolor1)
        GroupBox6.Dock = DockStyle.Fill
        GroupBox6.Location = New Point(0, 0)
        GroupBox6.Name = "GroupBox6"
        GroupBox6.Size = New Size(816, 473)
        GroupBox6.TabIndex = 2
        GroupBox6.TabStop = False
        ' 
        ' BG3Editor_Complex_Dyecolor1
        ' 
        BG3Editor_Complex_Dyecolor1.Dock = DockStyle.Fill
        BG3Editor_Complex_Dyecolor1.Enabled = False
        BG3Editor_Complex_Dyecolor1.Location = New Point(3, 19)
        BG3Editor_Complex_Dyecolor1.Name = "BG3Editor_Complex_Dyecolor1"
        BG3Editor_Complex_Dyecolor1.Size = New Size(810, 451)
        BG3Editor_Complex_Dyecolor1.TabIndex = 0
        ' 
        ' Dyes_Editor
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1097, 601)
        Name = "Dyes_Editor"
        Text = "Dyes editor"
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        GroupBox3.ResumeLayout(False)
        TabPage3.ResumeLayout(False)
        GroupBox8.ResumeLayout(False)
        TabPage5.ResumeLayout(False)
        GroupBox10.ResumeLayout(False)
        TabPage2.ResumeLayout(False)
        GroupBox7.ResumeLayout(False)
        TabPage1.ResumeLayout(False)
        GroupBox9.ResumeLayout(False)
        GroupBox1.ResumeLayout(False)
        GroupBox2.ResumeLayout(False)
        GroupBox4.ResumeLayout(False)
        TabControl1.ResumeLayout(False)
        GroupBox5.ResumeLayout(False)
        TabPage4.ResumeLayout(False)
        GroupBox6.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents BG3Editor_Template_ColorPreset1 As BG3Editor_Template_ColorPreset
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents BG3Editor_Template_DyeColorView15 As BG3Editor_Template_DyeColorView
    Friend WithEvents BG3Editor_Template_DyeColorView14 As BG3Editor_Template_DyeColorView
    Friend WithEvents BG3Editor_Template_DyeColorView13 As BG3Editor_Template_DyeColorView
    Friend WithEvents BG3Editor_Template_DyeColorView12 As BG3Editor_Template_DyeColorView
    Friend WithEvents BG3Editor_Template_DyeColorView11 As BG3Editor_Template_DyeColorView
    Friend WithEvents BG3Editor_Template_DyeColorView10 As BG3Editor_Template_DyeColorView
    Friend WithEvents BG3Editor_Template_DyeColorView9 As BG3Editor_Template_DyeColorView
    Friend WithEvents BG3Editor_Template_DyeColorView8 As BG3Editor_Template_DyeColorView
    Friend WithEvents BG3Editor_Template_DyeColorView7 As BG3Editor_Template_DyeColorView
    Friend WithEvents BG3Editor_Template_DyeColorView6 As BG3Editor_Template_DyeColorView
    Friend WithEvents BG3Editor_Template_DyeColorView5 As BG3Editor_Template_DyeColorView
    Friend WithEvents BG3Editor_Template_DyeColorView4 As BG3Editor_Template_DyeColorView
    Friend WithEvents BG3Editor_Template_DyeColorView3 As BG3Editor_Template_DyeColorView
    Friend WithEvents BG3Editor_Template_DyeColorView2 As BG3Editor_Template_DyeColorView
    Friend WithEvents BG3Editor_Template_DyeColorView1 As BG3Editor_Template_DyeColorView
    Friend WithEvents BG3Editor_Stat_Special_RemoverDye1 As BG3Editor_Stat_Special_RemoverDye
    Friend WithEvents BG3Editor_Stat_Special_UnlimitedDye1 As BG3Editor_Stat_Special_UnlimitedDye
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents BG3Editor_Complex_Dyecolor1 As BG3Editor_Complex_Dyecolor
End Class
