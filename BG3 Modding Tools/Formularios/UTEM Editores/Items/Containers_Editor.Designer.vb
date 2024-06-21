<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Containers_Editor
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
        BG3Editor_Template_Container_tt1 = New BG3Editor_Template_Container_TT()
        GroupBox5 = New GroupBox()
        RadioButtonOrNot = New RadioButton()
        RadioButtonAndNot = New RadioButton()
        RadioButtonOr = New RadioButton()
        RadioButtonAnd = New RadioButton()
        LabelDropTag = New Label()
        BG3Editor_Template_ContainerContentFilterCondition1 = New BG3Editor_Template_ContainerContentFilterCondition()
        BG3Editor_Template_ContainerAutoAddOnPickup1 = New BG3Editor_Template_ContainerAutoAddOnPickup()
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
        BG3Selector_Template1.CloneLabel = "Drop a Stat or a Template to add from it.  It must descend from containers bases."
        BG3Selector_Template1.Selection = BG3_Enum_UTAM_Type.Container
        BG3Selector_Template1.Stat_MustDescend_From = New String() {"_Container"}
        BG3Selector_Template1.Template_MustDescend_From = New String() {"49aba79d-0be8-42f0-9302-3761b3527fa4"}
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
        GroupBoxBasicTemplates.Controls.Add(BG3Editor_Template_Container_tt1)
        GroupBoxBasicTemplates.Controls.SetChildIndex(BG3Editor_Template_Parent1, 0)
        GroupBoxBasicTemplates.Controls.SetChildIndex(BG3Editor_Template_Mapkey1, 0)
        GroupBoxBasicTemplates.Controls.SetChildIndex(BG3Editor_Template_Type1, 0)
        GroupBoxBasicTemplates.Controls.SetChildIndex(BG3Editor_Template_Name1, 0)
        GroupBoxBasicTemplates.Controls.SetChildIndex(BG3Editor_Template_StoryItem1, 0)
        GroupBoxBasicTemplates.Controls.SetChildIndex(BG3Editor_Template_Container_tt1, 0)
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
        BG3Editor_Template_Parent1.MustDescendFrom = New String() {"49aba79d-0be8-42f0-9302-3761b3527fa4"}
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
        BG3Editor_Stat_Using1.MustDescendFrom = New String() {"_Container"}
        ' 
        ' BG3Editor_Template_Container_tt1
        ' 
        BG3Editor_Template_Container_tt1.AllowEdit = False
        BG3Editor_Template_Container_tt1.EditIsConditional = False
        BG3Editor_Template_Container_tt1.Label = "Treasure table"
        BG3Editor_Template_Container_tt1.Location = New Point(3, 111)
        BG3Editor_Template_Container_tt1.Margin = New Padding(0)
        BG3Editor_Template_Container_tt1.MaximumSize = New Size(3000, 23)
        BG3Editor_Template_Container_tt1.MinimumSize = New Size(100, 23)
        BG3Editor_Template_Container_tt1.Name = "BG3Editor_Template_Container_tt1"
        BG3Editor_Template_Container_tt1.Size = New Size(395, 23)
        BG3Editor_Template_Container_tt1.SplitterDistance = 100
        BG3Editor_Template_Container_tt1.TabIndex = 6
        ' 
        ' GroupBox5
        ' 
        GroupBox5.Controls.Add(RadioButtonOrNot)
        GroupBox5.Controls.Add(RadioButtonAndNot)
        GroupBox5.Controls.Add(RadioButtonOr)
        GroupBox5.Controls.Add(RadioButtonAnd)
        GroupBox5.Controls.Add(LabelDropTag)
        GroupBox5.Controls.Add(BG3Editor_Template_ContainerContentFilterCondition1)
        GroupBox5.Controls.Add(BG3Editor_Template_ContainerAutoAddOnPickup1)
        GroupBox5.Enabled = False
        GroupBox5.Location = New Point(416, 10)
        GroupBox5.Name = "GroupBox5"
        GroupBox5.Size = New Size(385, 145)
        GroupBox5.TabIndex = 5
        GroupBox5.TabStop = False
        GroupBox5.Text = "Auto sorting"
        ' 
        ' RadioButtonOrNot
        ' 
        RadioButtonOrNot.AutoSize = True
        RadioButtonOrNot.Location = New Point(318, 74)
        RadioButtonOrNot.Name = "RadioButtonOrNot"
        RadioButtonOrNot.Size = New Size(59, 19)
        RadioButtonOrNot.TabIndex = 6
        RadioButtonOrNot.Text = "Or not"
        RadioButtonOrNot.UseVisualStyleBackColor = True
        ' 
        ' RadioButtonAndNot
        ' 
        RadioButtonAndNot.AutoSize = True
        RadioButtonAndNot.Location = New Point(106, 74)
        RadioButtonAndNot.Name = "RadioButtonAndNot"
        RadioButtonAndNot.Size = New Size(68, 19)
        RadioButtonAndNot.TabIndex = 5
        RadioButtonAndNot.Text = "And not"
        RadioButtonAndNot.UseVisualStyleBackColor = True
        ' 
        ' RadioButtonOr
        ' 
        RadioButtonOr.AutoSize = True
        RadioButtonOr.Location = New Point(227, 74)
        RadioButtonOr.Name = "RadioButtonOr"
        RadioButtonOr.Size = New Size(38, 19)
        RadioButtonOr.TabIndex = 4
        RadioButtonOr.Text = "Or"
        RadioButtonOr.UseVisualStyleBackColor = True
        ' 
        ' RadioButtonAnd
        ' 
        RadioButtonAnd.AutoSize = True
        RadioButtonAnd.Checked = True
        RadioButtonAnd.Location = New Point(6, 74)
        RadioButtonAnd.Name = "RadioButtonAnd"
        RadioButtonAnd.Size = New Size(47, 19)
        RadioButtonAnd.TabIndex = 3
        RadioButtonAnd.TabStop = True
        RadioButtonAnd.Text = "And"
        RadioButtonAnd.UseVisualStyleBackColor = True
        ' 
        ' LabelDropTag
        ' 
        LabelDropTag.AllowDrop = True
        LabelDropTag.BackColor = SystemColors.Window
        LabelDropTag.BorderStyle = BorderStyle.FixedSingle
        LabelDropTag.Location = New Point(6, 96)
        LabelDropTag.Name = "LabelDropTag"
        LabelDropTag.Size = New Size(375, 35)
        LabelDropTag.TabIndex = 2
        LabelDropTag.Text = "Drop a tag to build condition"
        LabelDropTag.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' BG3Editor_Template_ContainerContentFilterCondition1
        ' 
        BG3Editor_Template_ContainerContentFilterCondition1.EditIsConditional = False
        BG3Editor_Template_ContainerContentFilterCondition1.Label = "Filter condition"
        BG3Editor_Template_ContainerContentFilterCondition1.Location = New Point(6, 42)
        BG3Editor_Template_ContainerContentFilterCondition1.Margin = New Padding(0)
        BG3Editor_Template_ContainerContentFilterCondition1.MaximumSize = New Size(3000, 23)
        BG3Editor_Template_ContainerContentFilterCondition1.MinimumSize = New Size(100, 23)
        BG3Editor_Template_ContainerContentFilterCondition1.Name = "BG3Editor_Template_ContainerContentFilterCondition1"
        BG3Editor_Template_ContainerContentFilterCondition1.Size = New Size(375, 23)
        BG3Editor_Template_ContainerContentFilterCondition1.SplitterDistance = 100
        BG3Editor_Template_ContainerContentFilterCondition1.TabIndex = 1
        ' 
        ' BG3Editor_Template_ContainerAutoAddOnPickup1
        ' 
        BG3Editor_Template_ContainerAutoAddOnPickup1.EditIsConditional = False
        BG3Editor_Template_ContainerAutoAddOnPickup1.EditorType = BG3_Editor_Type.Combobox
        BG3Editor_Template_ContainerAutoAddOnPickup1.Label = "Auto pickup"
        BG3Editor_Template_ContainerAutoAddOnPickup1.Location = New Point(6, 19)
        BG3Editor_Template_ContainerAutoAddOnPickup1.Margin = New Padding(0)
        BG3Editor_Template_ContainerAutoAddOnPickup1.MaximumSize = New Size(3000, 23)
        BG3Editor_Template_ContainerAutoAddOnPickup1.MinimumSize = New Size(100, 23)
        BG3Editor_Template_ContainerAutoAddOnPickup1.Name = "BG3Editor_Template_ContainerAutoAddOnPickup1"
        BG3Editor_Template_ContainerAutoAddOnPickup1.Size = New Size(225, 23)
        BG3Editor_Template_ContainerAutoAddOnPickup1.SplitterDistance = 100
        BG3Editor_Template_ContainerAutoAddOnPickup1.TabIndex = 0
        ' 
        ' Containers_Editor
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1169, 596)
        Name = "Containers_Editor"
        Text = "Containers editor"
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
        GroupBox5.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents BG3Editor_Template_Container_tt1 As BG3Editor_Template_Container_TT
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents RadioButtonOrNot As RadioButton
    Friend WithEvents RadioButtonAndNot As RadioButton
    Friend WithEvents RadioButtonOr As RadioButton
    Friend WithEvents RadioButtonAnd As RadioButton
    Friend WithEvents LabelDropTag As Label
    Friend WithEvents BG3Editor_Template_ContainerContentFilterCondition1 As BG3Editor_Template_ContainerContentFilterCondition
    Friend WithEvents BG3Editor_Template_ContainerAutoAddOnPickup1 As BG3Editor_Template_ContainerAutoAddOnPickup
End Class
