<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Books_Editor
    Inherits Generic_Item_Editor

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
        GroupBox5 = New GroupBox()
        BG3Editor_Template_OnUseDescription1 = New BG3Editor_Template_OnUseDescription()
        BG3Editor_Stats_UseConditions1 = New BG3Editor_Stats_UseConditions()
        BG3Editor_Stats_DefaultBoosts1 = New BG3Editor_Stats_DefaultBoosts()
        BG3Editor_Stats_ItemUseType1 = New BG3Editor_Stats_ItemUseType()
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
        GroupBoxBasicTemplates.SuspendLayout()
        GroupBoxVisuals.SuspendLayout()
        GroupBoxBasicStats.SuspendLayout()
        TabControl1.SuspendLayout()
        GroupBox5.SuspendLayout()
        SuspendLayout()
        ' 
        ' BG3Selector_Template1
        ' 
        BG3Selector_Template1.CloneLabel = "Drop a Stat or a Template to add from it. It must descend from books bases."
        BG3Selector_Template1.Selection = BG3_Enum_UTAM_Type.Book
        BG3Selector_Template1.Stat_MustDescend_From = New String() {"_Book", "Not _MagicScroll"}
        BG3Selector_Template1.Template_MustDescend_From = New String() {"23f65dff-a1ca-42fb-91ee-4cbb69450336", "Not 4ffd5c4b-4c56-4f05-a228-a33754bb1806"}
        ' 
        ' GroupBox9
        ' 
        GroupBox9.Controls.Add(GroupBox5)
        GroupBox9.Controls.SetChildIndex(GroupBoxBasicStats, 0)
        GroupBox9.Controls.SetChildIndex(GroupBoxVisuals, 0)
        GroupBox9.Controls.SetChildIndex(GroupBoxBasicTemplates, 0)
        GroupBox9.Controls.SetChildIndex(GroupBox5, 0)
        ' 
        ' GroupBoxBasicTemplates
        ' 
        GroupBoxBasicTemplates.Controls.Add(BG3Editor_Stats_ItemUseType1)
        GroupBoxBasicTemplates.Controls.SetChildIndex(BG3Editor_Template_Parent1, 0)
        GroupBoxBasicTemplates.Controls.SetChildIndex(BG3Editor_Template_Mapkey1, 0)
        GroupBoxBasicTemplates.Controls.SetChildIndex(BG3Editor_Template_Type1, 0)
        GroupBoxBasicTemplates.Controls.SetChildIndex(BG3Editor_Template_Name1, 0)
        GroupBoxBasicTemplates.Controls.SetChildIndex(BG3Editor_Template_StoryItem1, 0)
        GroupBoxBasicTemplates.Controls.SetChildIndex(BG3Editor_Stats_ItemUseType1, 0)
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
        BG3Editor_Template_Parent1.MustDescendFrom = New String() {"23f65dff-a1ca-42fb-91ee-4cbb69450336", "Not 4ffd5c4b-4c56-4f05-a228-a33754bb1806"}
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
        ' BG3Editor_Template_Stats1
        ' 
        BG3Editor_Template_Stats1.EditorType = BG3_Editor_Type.Textbox
        ' 
        ' BG3Editor_Stat_Using1
        ' 
        BG3Editor_Stat_Using1.EditorType = BG3_Editor_Type.Textbox
        BG3Editor_Stat_Using1.MustDescendFrom = New String() {"_Book", "Not _MagicScroll"}
        ' 
        ' GroupBox5
        ' 
        GroupBox5.Controls.Add(BG3Editor_Template_OnUseDescription1)
        GroupBox5.Controls.Add(BG3Editor_Stats_UseConditions1)
        GroupBox5.Controls.Add(BG3Editor_Stats_DefaultBoosts1)
        GroupBox5.Enabled = False
        GroupBox5.Location = New Point(416, 10)
        GroupBox5.Name = "GroupBox5"
        GroupBox5.Size = New Size(385, 191)
        GroupBox5.TabIndex = 6
        GroupBox5.TabStop = False
        GroupBox5.Text = "Book specifics"
        ' 
        ' BG3Editor_Template_OnUseDescription1
        ' 
        BG3Editor_Template_OnUseDescription1.Label = "Use description"
        BG3Editor_Template_OnUseDescription1.Location = New Point(3, 65)
        BG3Editor_Template_OnUseDescription1.Margin = New Padding(0)
        BG3Editor_Template_OnUseDescription1.MaximumSize = New Size(3000, 23)
        BG3Editor_Template_OnUseDescription1.MinimumSize = New Size(100, 23)
        BG3Editor_Template_OnUseDescription1.Name = "BG3Editor_Template_OnUseDescription1"
        BG3Editor_Template_OnUseDescription1.Size = New Size(378, 23)
        BG3Editor_Template_OnUseDescription1.TabIndex = 11
        ' 
        ' BG3Editor_Stats_UseConditions1
        ' 
        BG3Editor_Stats_UseConditions1.Label = "Use conditions"
        BG3Editor_Stats_UseConditions1.Location = New Point(3, 42)
        BG3Editor_Stats_UseConditions1.Margin = New Padding(0)
        BG3Editor_Stats_UseConditions1.MaximumSize = New Size(3000, 23)
        BG3Editor_Stats_UseConditions1.MinimumSize = New Size(100, 23)
        BG3Editor_Stats_UseConditions1.Name = "BG3Editor_Stats_UseConditions1"
        BG3Editor_Stats_UseConditions1.Size = New Size(378, 23)
        BG3Editor_Stats_UseConditions1.TabIndex = 9
        ' 
        ' BG3Editor_Stats_DefaultBoosts1
        ' 
        BG3Editor_Stats_DefaultBoosts1.Label = "Default boosts"
        BG3Editor_Stats_DefaultBoosts1.Location = New Point(3, 19)
        BG3Editor_Stats_DefaultBoosts1.Margin = New Padding(0)
        BG3Editor_Stats_DefaultBoosts1.MaximumSize = New Size(3000, 23)
        BG3Editor_Stats_DefaultBoosts1.MinimumSize = New Size(100, 23)
        BG3Editor_Stats_DefaultBoosts1.Name = "BG3Editor_Stats_DefaultBoosts1"
        BG3Editor_Stats_DefaultBoosts1.Size = New Size(378, 23)
        BG3Editor_Stats_DefaultBoosts1.TabIndex = 8
        ' 
        ' BG3Editor_Stats_ItemUseType1
        ' 
        BG3Editor_Stats_ItemUseType1.EditorType = BG3_Editor_Type.Combobox
        BG3Editor_Stats_ItemUseType1.Label = "Use type"
        BG3Editor_Stats_ItemUseType1.Location = New Point(3, 111)
        BG3Editor_Stats_ItemUseType1.Margin = New Padding(0)
        BG3Editor_Stats_ItemUseType1.MaximumSize = New Size(3000, 23)
        BG3Editor_Stats_ItemUseType1.MinimumSize = New Size(100, 23)
        BG3Editor_Stats_ItemUseType1.Name = "BG3Editor_Stats_ItemUseType1"
        BG3Editor_Stats_ItemUseType1.Size = New Size(395, 23)
        BG3Editor_Stats_ItemUseType1.TabIndex = 6
        ' 
        ' Books_Editor
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1169, 596)
        Name = "Books_Editor"
        Text = "Book editor"
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
        GroupBoxBasicTemplates.ResumeLayout(False)
        GroupBoxVisuals.ResumeLayout(False)
        GroupBoxBasicStats.ResumeLayout(False)
        TabControl1.ResumeLayout(False)
        GroupBox5.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents BG3Editor_Stats_DefaultBoosts1 As BG3Editor_Stats_DefaultBoosts
    Friend WithEvents BG3Editor_Stats_ItemUseType1 As BG3Editor_Stats_ItemUseType
    Friend WithEvents BG3Editor_Stats_UseConditions1 As BG3Editor_Stats_UseConditions
    Friend WithEvents BG3Editor_Template_OnUseDescription1 As BG3Editor_Template_OnUseDescription
End Class
