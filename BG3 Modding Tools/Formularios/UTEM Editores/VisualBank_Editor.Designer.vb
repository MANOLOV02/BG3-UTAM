<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class VisualBank_Editor
    Inherits Generic_Visuals_Editor

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
        GroupBoxTexture = New GroupBox()
        BG3Editor_Visuals_Slot1 = New BG3Editor_Visuals_Slot()
        BG3Editor_Visuals_SupportsVertexColorMask1 = New BG3Editor_Visuals_SupportsVertexColorMask()
        BG3Editor_Visuals_MaterialType1 = New BG3Editor_Visuals_MaterialType()
        BG3Editor_Textures_Name1 = New BG3Editor_Textures_Name()
        BG3Editor_Textures_iD_Fixed1 = New BG3Editor_Textures_ID_Fixed()
        BG3Editor_VisualBank_SourceFile1 = New BG3Editor_Visualbank_SourceFile()
        GroupboxAsset = New GroupBox()
        ButtonAsset = New Button()
        BG3Editor_Visuals_TemplategR21 = New BG3Editor_Visuals_TemplateGR2()
        TabControl2 = New TabControl()
        TabPageObjects = New TabPage()
        GroupBoxObjects = New GroupBox()
        GroupBoxObject = New GroupBox()
        BG3Editor_Visuals_oBjectid3 = New BG3Editor_Visuals_OBjectID()
        BG3Editor_Visuals_oBjectid2 = New BG3Editor_Visuals_OBjectID()
        LabelMat = New Label()
        BG3Editor_Visuals_oBjectid1 = New BG3Editor_Visuals_OBjectID()
        BG3Editor_Visuals_lod1 = New BG3Editor_Visuals_LOD()
        BG3Editor_Visuals_Materialid1 = New BG3Editor_Visuals_MaterialID()
        ListBoxObjects = New ListBox()
        ButtonDeleteObject = New Button()
        ButtonAddObject = New Button()
        TabPageVertexMasks = New TabPage()
        GroupBoxVertex = New GroupBox()
        ListBoxVertex = New ListBox()
        BG3Editor_Visuals_VertexMasks1 = New BG3Editor_Visuals_VertexMasks()
        ButtonDeleteMaskSlot = New Button()
        ButtonAddMaskSlot = New Button()
        TabPage1.SuspendLayout()
        GroupBox9.SuspendLayout()
        TabControl1.SuspendLayout()
        GroupBoxTexture.SuspendLayout()
        GroupboxAsset.SuspendLayout()
        TabControl2.SuspendLayout()
        TabPageObjects.SuspendLayout()
        GroupBoxObjects.SuspendLayout()
        GroupBoxObject.SuspendLayout()
        TabPageVertexMasks.SuspendLayout()
        GroupBoxVertex.SuspendLayout()
        SuspendLayout()
        ' 
        ' BG3Selector_Visuals1
        ' 
        BG3Selector_Visuals1.Selection = BG3_Enum_UTAM_Type.VisualBank
        ' 
        ' GroupBox9
        ' 
        GroupBox9.Controls.Add(TabControl2)
        GroupBox9.Controls.Add(GroupBoxTexture)
        GroupBox9.Controls.Add(GroupboxAsset)
        ' 
        ' GroupBoxTexture
        ' 
        GroupBoxTexture.Controls.Add(BG3Editor_Visuals_Slot1)
        GroupBoxTexture.Controls.Add(BG3Editor_Visuals_SupportsVertexColorMask1)
        GroupBoxTexture.Controls.Add(BG3Editor_Visuals_MaterialType1)
        GroupBoxTexture.Controls.Add(BG3Editor_Textures_Name1)
        GroupBoxTexture.Controls.Add(BG3Editor_Textures_iD_Fixed1)
        GroupBoxTexture.Location = New Point(6, 10)
        GroupBoxTexture.Name = "GroupBoxTexture"
        GroupBoxTexture.Size = New Size(795, 94)
        GroupBoxTexture.TabIndex = 1
        GroupBoxTexture.TabStop = False
        GroupBoxTexture.Text = "Visual bank"
        ' 
        ' BG3Editor_Visuals_Slot1
        ' 
        BG3Editor_Visuals_Slot1.EditIsConditional = False
        BG3Editor_Visuals_Slot1.EditorType = BG3_Editor_Type.Combobox
        BG3Editor_Visuals_Slot1.Label = "Slot"
        BG3Editor_Visuals_Slot1.Location = New Point(440, 43)
        BG3Editor_Visuals_Slot1.Margin = New Padding(0)
        BG3Editor_Visuals_Slot1.MaximumSize = New Size(3000, 23)
        BG3Editor_Visuals_Slot1.MinimumSize = New Size(100, 23)
        BG3Editor_Visuals_Slot1.Name = "BG3Editor_Visuals_Slot1"
        BG3Editor_Visuals_Slot1.Size = New Size(349, 23)
        BG3Editor_Visuals_Slot1.TabIndex = 4
        ' 
        ' BG3Editor_Visuals_SupportsVertexColorMask1
        ' 
        BG3Editor_Visuals_SupportsVertexColorMask1.EditIsConditional = False
        BG3Editor_Visuals_SupportsVertexColorMask1.EditorType = BG3_Editor_Type.Combobox
        BG3Editor_Visuals_SupportsVertexColorMask1.Label = "Vertec color mask"
        BG3Editor_Visuals_SupportsVertexColorMask1.Location = New Point(440, 66)
        BG3Editor_Visuals_SupportsVertexColorMask1.Margin = New Padding(0)
        BG3Editor_Visuals_SupportsVertexColorMask1.MaximumSize = New Size(3000, 23)
        BG3Editor_Visuals_SupportsVertexColorMask1.MinimumSize = New Size(100, 23)
        BG3Editor_Visuals_SupportsVertexColorMask1.Name = "BG3Editor_Visuals_SupportsVertexColorMask1"
        BG3Editor_Visuals_SupportsVertexColorMask1.Size = New Size(349, 23)
        BG3Editor_Visuals_SupportsVertexColorMask1.TabIndex = 3
        ' 
        ' BG3Editor_Visuals_MaterialType1
        ' 
        BG3Editor_Visuals_MaterialType1.EditIsConditional = False
        BG3Editor_Visuals_MaterialType1.EditorType = BG3_Editor_Type.NumericUpDown
        BG3Editor_Visuals_MaterialType1.Label = "Material type"
        BG3Editor_Visuals_MaterialType1.Location = New Point(3, 65)
        BG3Editor_Visuals_MaterialType1.Margin = New Padding(0)
        BG3Editor_Visuals_MaterialType1.MaximumSize = New Size(3000, 23)
        BG3Editor_Visuals_MaterialType1.MinimumSize = New Size(100, 23)
        BG3Editor_Visuals_MaterialType1.Name = "BG3Editor_Visuals_MaterialType1"
        BG3Editor_Visuals_MaterialType1.Size = New Size(401, 23)
        BG3Editor_Visuals_MaterialType1.TabIndex = 2
        ' 
        ' BG3Editor_Textures_Name1
        ' 
        BG3Editor_Textures_Name1.EditIsConditional = False
        BG3Editor_Textures_Name1.Label = "Name"
        BG3Editor_Textures_Name1.Location = New Point(3, 42)
        BG3Editor_Textures_Name1.Margin = New Padding(0)
        BG3Editor_Textures_Name1.MaximumSize = New Size(3000, 23)
        BG3Editor_Textures_Name1.MinimumSize = New Size(100, 23)
        BG3Editor_Textures_Name1.Name = "BG3Editor_Textures_Name1"
        BG3Editor_Textures_Name1.Size = New Size(401, 23)
        BG3Editor_Textures_Name1.TabIndex = 1
        ' 
        ' BG3Editor_Textures_iD_Fixed1
        ' 
        BG3Editor_Textures_iD_Fixed1.AllowEdit = False
        BG3Editor_Textures_iD_Fixed1.EditIsConditional = False
        BG3Editor_Textures_iD_Fixed1.Label = "ID"
        BG3Editor_Textures_iD_Fixed1.Location = New Point(3, 19)
        BG3Editor_Textures_iD_Fixed1.Margin = New Padding(0)
        BG3Editor_Textures_iD_Fixed1.MaximumSize = New Size(3000, 23)
        BG3Editor_Textures_iD_Fixed1.MinimumSize = New Size(100, 23)
        BG3Editor_Textures_iD_Fixed1.Name = "BG3Editor_Textures_iD_Fixed1"
        BG3Editor_Textures_iD_Fixed1.Size = New Size(401, 23)
        BG3Editor_Textures_iD_Fixed1.TabIndex = 0
        ' 
        ' BG3Editor_VisualBank_SourceFile1
        ' 
        BG3Editor_VisualBank_SourceFile1.DropIcon = True
        BG3Editor_VisualBank_SourceFile1.EditIsConditional = False
        BG3Editor_VisualBank_SourceFile1.Label = "Base mesh"
        BG3Editor_VisualBank_SourceFile1.Location = New Point(3, 13)
        BG3Editor_VisualBank_SourceFile1.Margin = New Padding(0)
        BG3Editor_VisualBank_SourceFile1.MaximumSize = New Size(3000, 23)
        BG3Editor_VisualBank_SourceFile1.MinimumSize = New Size(100, 23)
        BG3Editor_VisualBank_SourceFile1.Name = "BG3Editor_VisualBank_SourceFile1"
        BG3Editor_VisualBank_SourceFile1.ReadOnly = True
        BG3Editor_VisualBank_SourceFile1.Size = New Size(743, 23)
        BG3Editor_VisualBank_SourceFile1.SplitterDistance = 100
        BG3Editor_VisualBank_SourceFile1.TabIndex = 10
        ' 
        ' GroupboxAsset
        ' 
        GroupboxAsset.Controls.Add(ButtonAsset)
        GroupboxAsset.Controls.Add(BG3Editor_Visuals_TemplategR21)
        GroupboxAsset.Controls.Add(BG3Editor_VisualBank_SourceFile1)
        GroupboxAsset.Location = New Point(6, 110)
        GroupboxAsset.Name = "GroupboxAsset"
        GroupboxAsset.Size = New Size(795, 68)
        GroupboxAsset.TabIndex = 11
        GroupboxAsset.TabStop = False
        GroupboxAsset.Text = "Base"
        ' 
        ' ButtonAsset
        ' 
        ButtonAsset.Location = New Point(749, 13)
        ButtonAsset.Name = "ButtonAsset"
        ButtonAsset.Size = New Size(40, 23)
        ButtonAsset.TabIndex = 12
        ButtonAsset.Text = "....."
        ButtonAsset.UseVisualStyleBackColor = True
        ' 
        ' BG3Editor_Visuals_TemplategR21
        ' 
        BG3Editor_Visuals_TemplategR21.DropIcon = True
        BG3Editor_Visuals_TemplategR21.EditIsConditional = False
        BG3Editor_Visuals_TemplategR21.Label = "Template"
        BG3Editor_Visuals_TemplategR21.Location = New Point(3, 42)
        BG3Editor_Visuals_TemplategR21.Margin = New Padding(0)
        BG3Editor_Visuals_TemplategR21.MaximumSize = New Size(3000, 23)
        BG3Editor_Visuals_TemplategR21.MinimumSize = New Size(100, 23)
        BG3Editor_Visuals_TemplategR21.Name = "BG3Editor_Visuals_TemplategR21"
        BG3Editor_Visuals_TemplategR21.Size = New Size(786, 23)
        BG3Editor_Visuals_TemplategR21.TabIndex = 11
        ' 
        ' TabControl2
        ' 
        TabControl2.Appearance = TabAppearance.FlatButtons
        TabControl2.Controls.Add(TabPageObjects)
        TabControl2.Controls.Add(TabPageVertexMasks)
        TabControl2.Location = New Point(6, 184)
        TabControl2.Name = "TabControl2"
        TabControl2.SelectedIndex = 0
        TabControl2.Size = New Size(795, 282)
        TabControl2.TabIndex = 12
        ' 
        ' TabPageObjects
        ' 
        TabPageObjects.Controls.Add(GroupBoxObjects)
        TabPageObjects.Location = New Point(4, 27)
        TabPageObjects.Margin = New Padding(0)
        TabPageObjects.Name = "TabPageObjects"
        TabPageObjects.Size = New Size(787, 251)
        TabPageObjects.TabIndex = 0
        TabPageObjects.Text = "Objects"
        TabPageObjects.UseVisualStyleBackColor = True
        ' 
        ' GroupBoxObjects
        ' 
        GroupBoxObjects.Controls.Add(GroupBoxObject)
        GroupBoxObjects.Controls.Add(ListBoxObjects)
        GroupBoxObjects.Controls.Add(ButtonDeleteObject)
        GroupBoxObjects.Controls.Add(ButtonAddObject)
        GroupBoxObjects.Dock = DockStyle.Fill
        GroupBoxObjects.Location = New Point(0, 0)
        GroupBoxObjects.Margin = New Padding(0)
        GroupBoxObjects.Name = "GroupBoxObjects"
        GroupBoxObjects.Size = New Size(787, 251)
        GroupBoxObjects.TabIndex = 1
        GroupBoxObjects.TabStop = False
        ' 
        ' GroupBoxObject
        ' 
        GroupBoxObject.Controls.Add(BG3Editor_Visuals_oBjectid3)
        GroupBoxObject.Controls.Add(BG3Editor_Visuals_oBjectid2)
        GroupBoxObject.Controls.Add(LabelMat)
        GroupBoxObject.Controls.Add(BG3Editor_Visuals_oBjectid1)
        GroupBoxObject.Controls.Add(BG3Editor_Visuals_lod1)
        GroupBoxObject.Controls.Add(BG3Editor_Visuals_Materialid1)
        GroupBoxObject.Location = New Point(169, 72)
        GroupBoxObject.Name = "GroupBoxObject"
        GroupBoxObject.Size = New Size(611, 173)
        GroupBoxObject.TabIndex = 16
        GroupBoxObject.TabStop = False
        GroupBoxObject.Text = "Object properties"
        ' 
        ' BG3Editor_Visuals_oBjectid3
        ' 
        BG3Editor_Visuals_oBjectid3.EditIsConditional = False
        BG3Editor_Visuals_oBjectid3.Label = "Mesh Prefix"
        BG3Editor_Visuals_oBjectid3.Location = New Point(6, 42)
        BG3Editor_Visuals_oBjectid3.Margin = New Padding(0)
        BG3Editor_Visuals_oBjectid3.MaximumSize = New Size(3000, 23)
        BG3Editor_Visuals_oBjectid3.MinimumSize = New Size(100, 23)
        BG3Editor_Visuals_oBjectid3.Name = "BG3Editor_Visuals_oBjectid3"
        BG3Editor_Visuals_oBjectid3.Size = New Size(602, 23)
        BG3Editor_Visuals_oBjectid3.TabIndex = 18
        ' 
        ' BG3Editor_Visuals_oBjectid2
        ' 
        BG3Editor_Visuals_oBjectid2.EditIsConditional = False
        BG3Editor_Visuals_oBjectid2.EditorType = BG3_Editor_Type.Combobox
        BG3Editor_Visuals_oBjectid2.Label = "Mesh Name"
        BG3Editor_Visuals_oBjectid2.Location = New Point(6, 65)
        BG3Editor_Visuals_oBjectid2.Margin = New Padding(0)
        BG3Editor_Visuals_oBjectid2.MaximumSize = New Size(3000, 23)
        BG3Editor_Visuals_oBjectid2.MinimumSize = New Size(100, 23)
        BG3Editor_Visuals_oBjectid2.Name = "BG3Editor_Visuals_oBjectid2"
        BG3Editor_Visuals_oBjectid2.Size = New Size(602, 23)
        BG3Editor_Visuals_oBjectid2.TabIndex = 17
        ' 
        ' LabelMat
        ' 
        LabelMat.Location = New Point(358, 111)
        LabelMat.Name = "LabelMat"
        LabelMat.Size = New Size(250, 23)
        LabelMat.TabIndex = 6
        LabelMat.Text = "(None)"
        LabelMat.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' BG3Editor_Visuals_oBjectid1
        ' 
        BG3Editor_Visuals_oBjectid1.EditIsConditional = False
        BG3Editor_Visuals_oBjectid1.Label = "Object ID"
        BG3Editor_Visuals_oBjectid1.Location = New Point(6, 88)
        BG3Editor_Visuals_oBjectid1.Margin = New Padding(0)
        BG3Editor_Visuals_oBjectid1.MaximumSize = New Size(3000, 23)
        BG3Editor_Visuals_oBjectid1.MinimumSize = New Size(100, 23)
        BG3Editor_Visuals_oBjectid1.Name = "BG3Editor_Visuals_oBjectid1"
        BG3Editor_Visuals_oBjectid1.ReadOnly = True
        BG3Editor_Visuals_oBjectid1.Size = New Size(602, 23)
        BG3Editor_Visuals_oBjectid1.TabIndex = 2
        ' 
        ' BG3Editor_Visuals_lod1
        ' 
        BG3Editor_Visuals_lod1.EditIsConditional = False
        BG3Editor_Visuals_lod1.EditorType = BG3_Editor_Type.NumericUpDown
        BG3Editor_Visuals_lod1.Label = "LOD"
        BG3Editor_Visuals_lod1.Location = New Point(6, 19)
        BG3Editor_Visuals_lod1.Margin = New Padding(0)
        BG3Editor_Visuals_lod1.MaximumSize = New Size(3000, 23)
        BG3Editor_Visuals_lod1.MinimumSize = New Size(100, 23)
        BG3Editor_Visuals_lod1.Name = "BG3Editor_Visuals_lod1"
        BG3Editor_Visuals_lod1.Size = New Size(228, 23)
        BG3Editor_Visuals_lod1.TabIndex = 1
        ' 
        ' BG3Editor_Visuals_Materialid1
        ' 
        BG3Editor_Visuals_Materialid1.DropIcon = True
        BG3Editor_Visuals_Materialid1.EditIsConditional = False
        BG3Editor_Visuals_Materialid1.Label = "Material"
        BG3Editor_Visuals_Materialid1.Location = New Point(6, 111)
        BG3Editor_Visuals_Materialid1.Margin = New Padding(0)
        BG3Editor_Visuals_Materialid1.MaximumSize = New Size(3000, 23)
        BG3Editor_Visuals_Materialid1.MinimumSize = New Size(100, 23)
        BG3Editor_Visuals_Materialid1.Name = "BG3Editor_Visuals_Materialid1"
        BG3Editor_Visuals_Materialid1.ReadOnly = True
        BG3Editor_Visuals_Materialid1.Size = New Size(349, 23)
        BG3Editor_Visuals_Materialid1.SplitterDistance = 80
        BG3Editor_Visuals_Materialid1.TabIndex = 0
        ' 
        ' ListBoxObjects
        ' 
        ListBoxObjects.FormattingEnabled = True
        ListBoxObjects.ItemHeight = 15
        ListBoxObjects.Location = New Point(6, 18)
        ListBoxObjects.Name = "ListBoxObjects"
        ListBoxObjects.Size = New Size(154, 229)
        ListBoxObjects.TabIndex = 15
        ' 
        ' ButtonDeleteObject
        ' 
        ButtonDeleteObject.Location = New Point(166, 44)
        ButtonDeleteObject.Name = "ButtonDeleteObject"
        ButtonDeleteObject.Size = New Size(78, 23)
        ButtonDeleteObject.TabIndex = 13
        ButtonDeleteObject.Text = "Delete"
        ButtonDeleteObject.UseVisualStyleBackColor = True
        ' 
        ' ButtonAddObject
        ' 
        ButtonAddObject.Location = New Point(166, 18)
        ButtonAddObject.Name = "ButtonAddObject"
        ButtonAddObject.Size = New Size(78, 23)
        ButtonAddObject.TabIndex = 14
        ButtonAddObject.Text = "Add"
        ButtonAddObject.UseVisualStyleBackColor = True
        ' 
        ' TabPageVertexMasks
        ' 
        TabPageVertexMasks.Controls.Add(GroupBoxVertex)
        TabPageVertexMasks.Location = New Point(4, 27)
        TabPageVertexMasks.Margin = New Padding(0)
        TabPageVertexMasks.Name = "TabPageVertexMasks"
        TabPageVertexMasks.Size = New Size(787, 251)
        TabPageVertexMasks.TabIndex = 1
        TabPageVertexMasks.Text = "Vertex Mask Slots"
        TabPageVertexMasks.UseVisualStyleBackColor = True
        ' 
        ' GroupBoxVertex
        ' 
        GroupBoxVertex.Controls.Add(ListBoxVertex)
        GroupBoxVertex.Controls.Add(BG3Editor_Visuals_VertexMasks1)
        GroupBoxVertex.Controls.Add(ButtonDeleteMaskSlot)
        GroupBoxVertex.Controls.Add(ButtonAddMaskSlot)
        GroupBoxVertex.Dock = DockStyle.Fill
        GroupBoxVertex.Location = New Point(0, 0)
        GroupBoxVertex.Margin = New Padding(0)
        GroupBoxVertex.Name = "GroupBoxVertex"
        GroupBoxVertex.Size = New Size(787, 251)
        GroupBoxVertex.TabIndex = 0
        GroupBoxVertex.TabStop = False
        ' 
        ' ListBoxVertex
        ' 
        ListBoxVertex.FormattingEnabled = True
        ListBoxVertex.ItemHeight = 15
        ListBoxVertex.Location = New Point(6, 46)
        ListBoxVertex.Name = "ListBoxVertex"
        ListBoxVertex.Size = New Size(334, 184)
        ListBoxVertex.TabIndex = 14
        ' 
        ' BG3Editor_Visuals_VertexMasks1
        ' 
        BG3Editor_Visuals_VertexMasks1.EditIsConditional = False
        BG3Editor_Visuals_VertexMasks1.EditorType = BG3_Editor_Type.Combobox
        BG3Editor_Visuals_VertexMasks1.Label = "Slot"
        BG3Editor_Visuals_VertexMasks1.Location = New Point(6, 20)
        BG3Editor_Visuals_VertexMasks1.Margin = New Padding(0)
        BG3Editor_Visuals_VertexMasks1.MaximumSize = New Size(3000, 23)
        BG3Editor_Visuals_VertexMasks1.MinimumSize = New Size(100, 23)
        BG3Editor_Visuals_VertexMasks1.Name = "BG3Editor_Visuals_VertexMasks1"
        BG3Editor_Visuals_VertexMasks1.Size = New Size(334, 23)
        BG3Editor_Visuals_VertexMasks1.SplitterDistance = 80
        BG3Editor_Visuals_VertexMasks1.TabIndex = 13
        ' 
        ' ButtonDeleteMaskSlot
        ' 
        ButtonDeleteMaskSlot.Location = New Point(346, 46)
        ButtonDeleteMaskSlot.Name = "ButtonDeleteMaskSlot"
        ButtonDeleteMaskSlot.Size = New Size(78, 23)
        ButtonDeleteMaskSlot.TabIndex = 11
        ButtonDeleteMaskSlot.Text = "Delete"
        ButtonDeleteMaskSlot.UseVisualStyleBackColor = True
        ' 
        ' ButtonAddMaskSlot
        ' 
        ButtonAddMaskSlot.Location = New Point(346, 20)
        ButtonAddMaskSlot.Name = "ButtonAddMaskSlot"
        ButtonAddMaskSlot.Size = New Size(78, 23)
        ButtonAddMaskSlot.TabIndex = 12
        ButtonAddMaskSlot.Text = "Add"
        ButtonAddMaskSlot.UseVisualStyleBackColor = True
        ' 
        ' VisualBank_Editor
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1169, 596)
        Name = "VisualBank_Editor"
        Text = "Visual bank editor"
        TabPage1.ResumeLayout(False)
        GroupBox9.ResumeLayout(False)
        TabControl1.ResumeLayout(False)
        GroupBoxTexture.ResumeLayout(False)
        GroupboxAsset.ResumeLayout(False)
        TabControl2.ResumeLayout(False)
        TabPageObjects.ResumeLayout(False)
        GroupBoxObjects.ResumeLayout(False)
        GroupBoxObject.ResumeLayout(False)
        TabPageVertexMasks.ResumeLayout(False)
        GroupBoxVertex.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Protected Friend WithEvents GroupBoxTexture As GroupBox
    Friend WithEvents BG3Editor_Textures_iD_Fixed1 As BG3Editor_Textures_ID_Fixed
    Friend WithEvents BG3Editor_Textures_Name1 As BG3Editor_Textures_Name
    Friend WithEvents BG3Editor_VisualBank_SourceFile1 As BG3Editor_Visualbank_SourceFile
    Friend WithEvents GroupboxAsset As GroupBox
    Friend WithEvents BG3Editor_Visuals_MaterialType1 As BG3Editor_Visuals_MaterialType
    Friend WithEvents BG3Editor_Visuals_TemplategR21 As BG3Editor_Visuals_TemplateGR2
    Friend WithEvents ButtonAsset As Button
    Friend WithEvents TabControl2 As TabControl
    Friend WithEvents TabPageObjects As TabPage
    Friend WithEvents GroupBoxObjects As GroupBox
    Friend WithEvents TabPageVertexMasks As TabPage
    Friend WithEvents GroupBoxVertex As GroupBox
    Friend WithEvents ButtonDeleteMaskSlot As Button
    Friend WithEvents ButtonAddMaskSlot As Button
    Friend WithEvents BG3Editor_Visuals_VertexMasks1 As BG3Editor_Visuals_VertexMasks
    Friend WithEvents ButtonDeleteObject As Button
    Friend WithEvents ButtonAddObject As Button
    Friend WithEvents ListBoxVertex As ListBox
    Friend WithEvents ListBoxObjects As ListBox
    Friend WithEvents GroupBoxObject As GroupBox
    Friend WithEvents BG3Editor_Visuals_oBjectid1 As BG3Editor_Visuals_OBjectID
    Friend WithEvents BG3Editor_Visuals_lod1 As BG3Editor_Visuals_LOD
    Friend WithEvents BG3Editor_Visuals_Materialid1 As BG3Editor_Visuals_MaterialID
    Friend WithEvents BG3Editor_Visuals_SupportsVertexColorMask1 As BG3Editor_Visuals_SupportsVertexColorMask
    Friend WithEvents BG3Editor_Visuals_Slot1 As BG3Editor_Visuals_Slot
    Friend WithEvents LabelMat As Label
    Friend WithEvents BG3Editor_Visuals_oBjectid2 As BG3Editor_Visuals_OBjectID
    Friend WithEvents BG3Editor_Visuals_oBjectid3 As BG3Editor_Visuals_OBjectID
End Class
