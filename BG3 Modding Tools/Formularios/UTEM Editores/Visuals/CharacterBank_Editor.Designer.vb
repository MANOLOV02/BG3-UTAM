<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CharacterBank_Editor
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
        GroupBoxCharacter = New GroupBox()
        Button1 = New Button()
        LabelBS = New Label()
        ButtonBM = New Button()
        LabelBV = New Label()
        BG3Editor_Visuals_ShowEquipmentVisuals1 = New BG3Editor_Visuals_ShowEquipmentVisuals()
        BG3Editor_Visuals_BodySetVisual1 = New BG3Editor_Visuals_BodySetVisual()
        BG3Editor_Visuals_BaseVisual1 = New BG3Editor_Visuals_BaseVisual()
        BG3Editor_Visuals_Localized1 = New BG3Editor_Visuals_Localized()
        BG3Editor_Textures_Name1 = New BG3Editor_Textures_Name()
        BG3Editor_Textures_iD_Fixed1 = New BG3Editor_Textures_ID_Fixed()
        TabControlSlots = New TabControl()
        TabPageObjects = New TabPage()
        GroupSlots = New GroupBox()
        GroupBoxSlotsDetails = New GroupBox()
        BG3Editor_Visuals_Bone1 = New BG3Editor_Visuals_Bone()
        BG3Editor_Visuals_VisualResource1 = New BG3Editor_Visuals_VisualResource()
        BG3Editor_Visuals_Slot1 = New BG3Editor_Visuals_Slot()
        LabelMat = New Label()
        ListBoxSlots = New ListBox()
        ButtonDeleteObject = New Button()
        ButtonAddObject = New Button()
        TabPageScalars = New TabPage()
        GroupBoxScalars = New GroupBox()
        BG3Editor_Complex_ScalarsandVectors1 = New BG3Editor_Complex_ScalarsandVectors()
        TabPage1.SuspendLayout()
        GroupBox9.SuspendLayout()
        TabControl1.SuspendLayout()
        GroupBoxCharacter.SuspendLayout()
        TabControlSlots.SuspendLayout()
        TabPageObjects.SuspendLayout()
        GroupSlots.SuspendLayout()
        GroupBoxSlotsDetails.SuspendLayout()
        TabPageScalars.SuspendLayout()
        GroupBoxScalars.SuspendLayout()
        SuspendLayout()
        ' 
        ' BG3Selector_Visuals1
        ' 
        BG3Selector_Visuals1.Selection = BG3_Enum_UTAM_Type.CharacterBank
        ' 
        ' GroupBox9
        ' 
        GroupBox9.Controls.Add(TabControlSlots)
        GroupBox9.Controls.Add(GroupBoxCharacter)
        ' 
        ' TabControl1
        ' 
        TabControl1.Controls.Add(TabPageScalars)
        TabControl1.Controls.SetChildIndex(TabPageScalars, 0)
        TabControl1.Controls.SetChildIndex(TabPage1, 0)
        ' 
        ' GroupBoxCharacter
        ' 
        GroupBoxCharacter.Controls.Add(Button1)
        GroupBoxCharacter.Controls.Add(LabelBS)
        GroupBoxCharacter.Controls.Add(ButtonBM)
        GroupBoxCharacter.Controls.Add(LabelBV)
        GroupBoxCharacter.Controls.Add(BG3Editor_Visuals_ShowEquipmentVisuals1)
        GroupBoxCharacter.Controls.Add(BG3Editor_Visuals_BodySetVisual1)
        GroupBoxCharacter.Controls.Add(BG3Editor_Visuals_BaseVisual1)
        GroupBoxCharacter.Controls.Add(BG3Editor_Visuals_Localized1)
        GroupBoxCharacter.Controls.Add(BG3Editor_Textures_Name1)
        GroupBoxCharacter.Controls.Add(BG3Editor_Textures_iD_Fixed1)
        GroupBoxCharacter.Location = New Point(6, 10)
        GroupBoxCharacter.Name = "GroupBoxCharacter"
        GroupBoxCharacter.Size = New Size(795, 139)
        GroupBoxCharacter.TabIndex = 1
        GroupBoxCharacter.TabStop = False
        GroupBoxCharacter.Text = "Character Base"
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(466, 111)
        Button1.Name = "Button1"
        Button1.Size = New Size(24, 23)
        Button1.TabIndex = 15
        Button1.Text = "X"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' LabelBS
        ' 
        LabelBS.Location = New Point(496, 111)
        LabelBS.Name = "LabelBS"
        LabelBS.Size = New Size(293, 23)
        LabelBS.TabIndex = 14
        LabelBS.Text = "(None)"
        LabelBS.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' ButtonBM
        ' 
        ButtonBM.Location = New Point(466, 88)
        ButtonBM.Name = "ButtonBM"
        ButtonBM.Size = New Size(24, 23)
        ButtonBM.TabIndex = 13
        ButtonBM.Text = "X"
        ButtonBM.UseVisualStyleBackColor = True
        ' 
        ' LabelBV
        ' 
        LabelBV.Location = New Point(496, 88)
        LabelBV.Name = "LabelBV"
        LabelBV.Size = New Size(293, 23)
        LabelBV.TabIndex = 12
        LabelBV.Text = "(None)"
        LabelBV.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' BG3Editor_Visuals_ShowEquipmentVisuals1
        ' 
        BG3Editor_Visuals_ShowEquipmentVisuals1.EditIsConditional = False
        BG3Editor_Visuals_ShowEquipmentVisuals1.EditorType = BG3_Editor_Type.Combobox
        BG3Editor_Visuals_ShowEquipmentVisuals1.Label = "Show equipment"
        BG3Editor_Visuals_ShowEquipmentVisuals1.Location = New Point(3, 65)
        BG3Editor_Visuals_ShowEquipmentVisuals1.Margin = New Padding(0)
        BG3Editor_Visuals_ShowEquipmentVisuals1.MaximumSize = New Size(3000, 23)
        BG3Editor_Visuals_ShowEquipmentVisuals1.MinimumSize = New Size(100, 23)
        BG3Editor_Visuals_ShowEquipmentVisuals1.Name = "BG3Editor_Visuals_ShowEquipmentVisuals1"
        BG3Editor_Visuals_ShowEquipmentVisuals1.Size = New Size(261, 23)
        BG3Editor_Visuals_ShowEquipmentVisuals1.SplitterDistance = 121
        BG3Editor_Visuals_ShowEquipmentVisuals1.TabIndex = 11
        ' 
        ' BG3Editor_Visuals_BodySetVisual1
        ' 
        BG3Editor_Visuals_BodySetVisual1.DropIcon = True
        BG3Editor_Visuals_BodySetVisual1.EditIsConditional = False
        BG3Editor_Visuals_BodySetVisual1.Label = "Body set visual"
        BG3Editor_Visuals_BodySetVisual1.Location = New Point(3, 111)
        BG3Editor_Visuals_BodySetVisual1.Margin = New Padding(0)
        BG3Editor_Visuals_BodySetVisual1.MaximumSize = New Size(3000, 23)
        BG3Editor_Visuals_BodySetVisual1.MinimumSize = New Size(100, 23)
        BG3Editor_Visuals_BodySetVisual1.Name = "BG3Editor_Visuals_BodySetVisual1"
        BG3Editor_Visuals_BodySetVisual1.ReadOnly = True
        BG3Editor_Visuals_BodySetVisual1.Size = New Size(459, 23)
        BG3Editor_Visuals_BodySetVisual1.SplitterDistance = 101
        BG3Editor_Visuals_BodySetVisual1.TabIndex = 10
        ' 
        ' BG3Editor_Visuals_BaseVisual1
        ' 
        BG3Editor_Visuals_BaseVisual1.DropIcon = True
        BG3Editor_Visuals_BaseVisual1.EditIsConditional = False
        BG3Editor_Visuals_BaseVisual1.Label = "Base visual"
        BG3Editor_Visuals_BaseVisual1.Location = New Point(3, 88)
        BG3Editor_Visuals_BaseVisual1.Margin = New Padding(0)
        BG3Editor_Visuals_BaseVisual1.MaximumSize = New Size(3000, 23)
        BG3Editor_Visuals_BaseVisual1.MinimumSize = New Size(100, 23)
        BG3Editor_Visuals_BaseVisual1.Name = "BG3Editor_Visuals_BaseVisual1"
        BG3Editor_Visuals_BaseVisual1.ReadOnly = True
        BG3Editor_Visuals_BaseVisual1.Size = New Size(459, 23)
        BG3Editor_Visuals_BaseVisual1.SplitterDistance = 101
        BG3Editor_Visuals_BaseVisual1.TabIndex = 9
        ' 
        ' BG3Editor_Visuals_Localized1
        ' 
        BG3Editor_Visuals_Localized1.EditorType = BG3_Editor_Type.Combobox
        BG3Editor_Visuals_Localized1.Label = "Localized"
        BG3Editor_Visuals_Localized1.Location = New Point(281, 65)
        BG3Editor_Visuals_Localized1.Margin = New Padding(0)
        BG3Editor_Visuals_Localized1.MaximumSize = New Size(3000, 23)
        BG3Editor_Visuals_Localized1.MinimumSize = New Size(100, 23)
        BG3Editor_Visuals_Localized1.Name = "BG3Editor_Visuals_Localized1"
        BG3Editor_Visuals_Localized1.Size = New Size(181, 23)
        BG3Editor_Visuals_Localized1.SplitterDistance = 80
        BG3Editor_Visuals_Localized1.TabIndex = 8
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
        BG3Editor_Textures_Name1.Size = New Size(459, 23)
        BG3Editor_Textures_Name1.SplitterDistance = 121
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
        BG3Editor_Textures_iD_Fixed1.Size = New Size(459, 23)
        BG3Editor_Textures_iD_Fixed1.SplitterDistance = 121
        BG3Editor_Textures_iD_Fixed1.TabIndex = 0
        ' 
        ' TabControlSlots
        ' 
        TabControlSlots.Appearance = TabAppearance.FlatButtons
        TabControlSlots.Controls.Add(TabPageObjects)
        TabControlSlots.Location = New Point(4, 170)
        TabControlSlots.Name = "TabControlSlots"
        TabControlSlots.SelectedIndex = 0
        TabControlSlots.Size = New Size(800, 282)
        TabControlSlots.TabIndex = 13
        ' 
        ' TabPageObjects
        ' 
        TabPageObjects.Controls.Add(GroupSlots)
        TabPageObjects.Location = New Point(4, 27)
        TabPageObjects.Margin = New Padding(0)
        TabPageObjects.Name = "TabPageObjects"
        TabPageObjects.Size = New Size(792, 251)
        TabPageObjects.TabIndex = 0
        TabPageObjects.Text = "Slots"
        TabPageObjects.UseVisualStyleBackColor = True
        ' 
        ' GroupSlots
        ' 
        GroupSlots.Controls.Add(GroupBoxSlotsDetails)
        GroupSlots.Controls.Add(ListBoxSlots)
        GroupSlots.Controls.Add(ButtonDeleteObject)
        GroupSlots.Controls.Add(ButtonAddObject)
        GroupSlots.Dock = DockStyle.Fill
        GroupSlots.Location = New Point(0, 0)
        GroupSlots.Margin = New Padding(0)
        GroupSlots.Name = "GroupSlots"
        GroupSlots.Size = New Size(792, 251)
        GroupSlots.TabIndex = 1
        GroupSlots.TabStop = False
        ' 
        ' GroupBoxSlotsDetails
        ' 
        GroupBoxSlotsDetails.Controls.Add(BG3Editor_Visuals_Bone1)
        GroupBoxSlotsDetails.Controls.Add(BG3Editor_Visuals_VisualResource1)
        GroupBoxSlotsDetails.Controls.Add(BG3Editor_Visuals_Slot1)
        GroupBoxSlotsDetails.Controls.Add(LabelMat)
        GroupBoxSlotsDetails.Location = New Point(169, 72)
        GroupBoxSlotsDetails.Name = "GroupBoxSlotsDetails"
        GroupBoxSlotsDetails.Size = New Size(611, 139)
        GroupBoxSlotsDetails.TabIndex = 16
        GroupBoxSlotsDetails.TabStop = False
        GroupBoxSlotsDetails.Text = "Object properties"
        ' 
        ' BG3Editor_Visuals_Bone1
        ' 
        BG3Editor_Visuals_Bone1.EditIsConditional = False
        BG3Editor_Visuals_Bone1.Label = "Bone"
        BG3Editor_Visuals_Bone1.Location = New Point(6, 65)
        BG3Editor_Visuals_Bone1.Margin = New Padding(0)
        BG3Editor_Visuals_Bone1.MaximumSize = New Size(3000, 23)
        BG3Editor_Visuals_Bone1.MinimumSize = New Size(100, 23)
        BG3Editor_Visuals_Bone1.Name = "BG3Editor_Visuals_Bone1"
        BG3Editor_Visuals_Bone1.Size = New Size(372, 23)
        BG3Editor_Visuals_Bone1.TabIndex = 21
        ' 
        ' BG3Editor_Visuals_VisualResource1
        ' 
        BG3Editor_Visuals_VisualResource1.DropIcon = True
        BG3Editor_Visuals_VisualResource1.EditIsConditional = False
        BG3Editor_Visuals_VisualResource1.Label = "Visual bank"
        BG3Editor_Visuals_VisualResource1.Location = New Point(6, 42)
        BG3Editor_Visuals_VisualResource1.Margin = New Padding(0)
        BG3Editor_Visuals_VisualResource1.MaximumSize = New Size(3000, 23)
        BG3Editor_Visuals_VisualResource1.MinimumSize = New Size(100, 23)
        BG3Editor_Visuals_VisualResource1.Name = "BG3Editor_Visuals_VisualResource1"
        BG3Editor_Visuals_VisualResource1.ReadOnly = True
        BG3Editor_Visuals_VisualResource1.Size = New Size(372, 23)
        BG3Editor_Visuals_VisualResource1.SplitterDistance = 80
        BG3Editor_Visuals_VisualResource1.TabIndex = 20
        ' 
        ' BG3Editor_Visuals_Slot1
        ' 
        BG3Editor_Visuals_Slot1.EditIsConditional = False
        BG3Editor_Visuals_Slot1.EditorType = BG3_Editor_Type.Combobox
        BG3Editor_Visuals_Slot1.Label = "Slot"
        BG3Editor_Visuals_Slot1.Location = New Point(6, 19)
        BG3Editor_Visuals_Slot1.Margin = New Padding(0)
        BG3Editor_Visuals_Slot1.MaximumSize = New Size(3000, 23)
        BG3Editor_Visuals_Slot1.MinimumSize = New Size(100, 23)
        BG3Editor_Visuals_Slot1.Name = "BG3Editor_Visuals_Slot1"
        BG3Editor_Visuals_Slot1.Size = New Size(372, 23)
        BG3Editor_Visuals_Slot1.TabIndex = 19
        ' 
        ' LabelMat
        ' 
        LabelMat.Location = New Point(381, 42)
        LabelMat.Name = "LabelMat"
        LabelMat.Size = New Size(227, 23)
        LabelMat.TabIndex = 6
        LabelMat.Text = "(None)"
        LabelMat.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' ListBoxSlots
        ' 
        ListBoxSlots.FormattingEnabled = True
        ListBoxSlots.ItemHeight = 15
        ListBoxSlots.Location = New Point(6, 18)
        ListBoxSlots.Name = "ListBoxSlots"
        ListBoxSlots.Size = New Size(154, 229)
        ListBoxSlots.TabIndex = 15
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
        ' TabPageScalars
        ' 
        TabPageScalars.Controls.Add(GroupBoxScalars)
        TabPageScalars.Location = New Point(4, 27)
        TabPageScalars.Name = "TabPageScalars"
        TabPageScalars.Size = New Size(807, 472)
        TabPageScalars.TabIndex = 7
        TabPageScalars.Text = "Scalars and vectors"
        ' 
        ' GroupBoxScalars
        ' 
        GroupBoxScalars.Controls.Add(BG3Editor_Complex_ScalarsandVectors1)
        GroupBoxScalars.Dock = DockStyle.Fill
        GroupBoxScalars.Location = New Point(0, 0)
        GroupBoxScalars.Name = "GroupBoxScalars"
        GroupBoxScalars.Size = New Size(807, 472)
        GroupBoxScalars.TabIndex = 1
        GroupBoxScalars.TabStop = False
        ' 
        ' BG3Editor_Complex_ScalarsandVectors1
        ' 
        BG3Editor_Complex_ScalarsandVectors1.Dock = DockStyle.Fill
        BG3Editor_Complex_ScalarsandVectors1.Location = New Point(3, 19)
        BG3Editor_Complex_ScalarsandVectors1.Name = "BG3Editor_Complex_ScalarsandVectors1"
        BG3Editor_Complex_ScalarsandVectors1.Size = New Size(801, 450)
        BG3Editor_Complex_ScalarsandVectors1.TabIndex = 0
        ' 
        ' CharacterBank_Editor
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1169, 596)
        Name = "CharacterBank_Editor"
        Text = "Characters bank editor"
        TabPage1.ResumeLayout(False)
        GroupBox9.ResumeLayout(False)
        TabControl1.ResumeLayout(False)
        GroupBoxCharacter.ResumeLayout(False)
        TabControlSlots.ResumeLayout(False)
        TabPageObjects.ResumeLayout(False)
        GroupSlots.ResumeLayout(False)
        GroupBoxSlotsDetails.ResumeLayout(False)
        TabPageScalars.ResumeLayout(False)
        GroupBoxScalars.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Protected Friend WithEvents GroupBoxCharacter As GroupBox
    Friend WithEvents BG3Editor_Textures_iD_Fixed1 As BG3Editor_Textures_ID_Fixed
    Friend WithEvents BG3Editor_Textures_Name1 As BG3Editor_Textures_Name
    Friend WithEvents BG3Editor_Visuals_Localized1 As BG3Editor_Visuals_Localized
    Friend WithEvents BG3Editor_Visuals_ShowEquipmentVisuals1 As BG3Editor_Visuals_ShowEquipmentVisuals
    Friend WithEvents BG3Editor_Visuals_BodySetVisual1 As BG3Editor_Visuals_BodySetVisual
    Friend WithEvents BG3Editor_Visuals_BaseVisual1 As BG3Editor_Visuals_BaseVisual
    Friend WithEvents Button1 As Button
    Friend WithEvents LabelBS As Label
    Friend WithEvents ButtonBM As Button
    Friend WithEvents LabelBV As Label
    Friend WithEvents TabControlSlots As TabControl
    Friend WithEvents TabPageObjects As TabPage
    Friend WithEvents GroupSlots As GroupBox
    Friend WithEvents GroupBoxSlotsDetails As GroupBox
    Friend WithEvents LabelMat As Label
    Friend WithEvents ListBoxSlots As ListBox
    Friend WithEvents ButtonDeleteObject As Button
    Friend WithEvents ButtonAddObject As Button
    Friend WithEvents BG3Editor_Visuals_VisualResource1 As BG3Editor_Visuals_VisualResource
    Friend WithEvents BG3Editor_Visuals_Slot1 As BG3Editor_Visuals_Slot
    Friend WithEvents BG3Editor_Visuals_Bone1 As BG3Editor_Visuals_Bone
    Protected Friend WithEvents TabPageScalars As TabPage
    Protected Friend WithEvents GroupBoxScalars As GroupBox
    Friend WithEvents BG3Editor_Complex_ScalarsandVectors1 As BG3Editor_Complex_ScalarsandVectors
End Class
