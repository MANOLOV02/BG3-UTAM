<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MaterialBank_Editor
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
        BG3Editor_Visuals_DiffusionProfileuuid1 = New BG3Editor_Visuals_DiffusionProfileUUID()
        BG3Editor_Visuals_MaterialType1 = New BG3Editor_Visuals_MaterialType()
        BG3Editor_Textures_Name1 = New BG3Editor_Textures_Name()
        BG3Editor_Textures_iD_Fixed1 = New BG3Editor_Textures_ID_Fixed()
        BG3Editor_Material_SourceFile1 = New BG3Editor_Materialbank_SourceFile()
        GroupboxAsset = New GroupBox()
        GroupBoxVT = New GroupBox()
        ButtonVT = New Button()
        LabelVT = New Label()
        BG3Editor_Visuals_VirtualTexture1 = New BG3Editor_Visuals_VirtualTexture()
        GroupBoxTextures2d = New GroupBox()
        ButtonPM = New Button()
        ButtonNM = New Button()
        ButtonBM = New Button()
        LabelPM = New Label()
        LabelNM = New Label()
        LabelBM = New Label()
        BG3Editor_Visuals_PhisicalMap1 = New BG3Editor_Visuals_PhisicalMap()
        BG3Editor_Visuals_NormalMap1 = New BG3Editor_Visuals_NormalMap()
        BG3Editor_Visuals_BasecolorMap1 = New BG3Editor_Visuals_BasecolorMap()
        GroupBoxMsk = New GroupBox()
        ButtonGM = New Button()
        LabelGM = New Label()
        BG3Editor_Visuals_Glow_msk1 = New BG3Editor_Visuals_VertexColor_MSK()
        ButtonVertexMsk = New Button()
        LabelVertexMSK = New Label()
        ButtonMSKClt = New Button()
        LabelMskclt = New Label()
        BG3Editor_Visuals_msKcloth1 = New BG3Editor_Visuals_MSKcloth()
        BG3Editor_Visuals_VertexColor_msk1 = New BG3Editor_Visuals_VertexColor_MSK()
        ButtonMSK = New Button()
        LabelColorMSK = New Label()
        BG3Editor_Visuals_MaskTexture1 = New BG3Editor_Visuals_MaskTexture()
        TabPageDyes = New TabPage()
        GroupBox6 = New GroupBox()
        BG3Editor_Complex_Dyecolor1 = New BG3Editor_Complex_Dyecolor()
        TabPageScalars = New TabPage()
        GroupBoxScalars = New GroupBox()
        BG3Editor_Complex_ScalarsandVectors1 = New BG3Editor_Complex_ScalarsandVectors()
        TabPage1.SuspendLayout()
        GroupBox9.SuspendLayout()
        TabControl1.SuspendLayout()
        GroupBoxTexture.SuspendLayout()
        GroupboxAsset.SuspendLayout()
        GroupBoxVT.SuspendLayout()
        GroupBoxTextures2d.SuspendLayout()
        GroupBoxMsk.SuspendLayout()
        TabPageDyes.SuspendLayout()
        GroupBox6.SuspendLayout()
        TabPageScalars.SuspendLayout()
        GroupBoxScalars.SuspendLayout()
        SuspendLayout()
        ' 
        ' BG3Selector_Visuals1
        ' 
        BG3Selector_Visuals1.Selection = BG3_Enum_UTAM_Type.MaterialBank
        ' 
        ' GroupBox9
        ' 
        GroupBox9.Controls.Add(GroupBoxMsk)
        GroupBox9.Controls.Add(GroupBoxTextures2d)
        GroupBox9.Controls.Add(GroupBoxVT)
        GroupBox9.Controls.Add(GroupboxAsset)
        GroupBox9.Controls.Add(GroupBoxTexture)
        ' 
        ' TabControl1
        ' 
        TabControl1.Controls.Add(TabPageDyes)
        TabControl1.Controls.Add(TabPageScalars)
        TabControl1.Controls.SetChildIndex(TabPageScalars, 0)
        TabControl1.Controls.SetChildIndex(TabPageDyes, 0)
        TabControl1.Controls.SetChildIndex(TabPage1, 0)
        ' 
        ' GroupBoxTexture
        ' 
        GroupBoxTexture.Controls.Add(BG3Editor_Visuals_DiffusionProfileuuid1)
        GroupBoxTexture.Controls.Add(BG3Editor_Visuals_MaterialType1)
        GroupBoxTexture.Controls.Add(BG3Editor_Textures_Name1)
        GroupBoxTexture.Controls.Add(BG3Editor_Textures_iD_Fixed1)
        GroupBoxTexture.Location = New Point(6, 59)
        GroupBoxTexture.Name = "GroupBoxTexture"
        GroupBoxTexture.Size = New Size(407, 121)
        GroupBoxTexture.TabIndex = 1
        GroupBoxTexture.TabStop = False
        GroupBoxTexture.Text = "Material"
        ' 
        ' BG3Editor_Visuals_DiffusionProfileuuid1
        ' 
        BG3Editor_Visuals_DiffusionProfileuuid1.EditIsConditional = False
        BG3Editor_Visuals_DiffusionProfileuuid1.Label = "Diffusion profile"
        BG3Editor_Visuals_DiffusionProfileuuid1.Location = New Point(3, 65)
        BG3Editor_Visuals_DiffusionProfileuuid1.Margin = New Padding(0)
        BG3Editor_Visuals_DiffusionProfileuuid1.MaximumSize = New Size(3000, 23)
        BG3Editor_Visuals_DiffusionProfileuuid1.MinimumSize = New Size(100, 23)
        BG3Editor_Visuals_DiffusionProfileuuid1.Name = "BG3Editor_Visuals_DiffusionProfileuuid1"
        BG3Editor_Visuals_DiffusionProfileuuid1.Size = New Size(401, 23)
        BG3Editor_Visuals_DiffusionProfileuuid1.TabIndex = 3
        ' 
        ' BG3Editor_Visuals_MaterialType1
        ' 
        BG3Editor_Visuals_MaterialType1.EditIsConditional = False
        BG3Editor_Visuals_MaterialType1.EditorType = BG3_Editor_Type.NumericUpDown
        BG3Editor_Visuals_MaterialType1.Label = "Material type"
        BG3Editor_Visuals_MaterialType1.Location = New Point(3, 88)
        BG3Editor_Visuals_MaterialType1.Margin = New Padding(0)
        BG3Editor_Visuals_MaterialType1.MaximumSize = New Size(3000, 23)
        BG3Editor_Visuals_MaterialType1.MinimumSize = New Size(100, 23)
        BG3Editor_Visuals_MaterialType1.Name = "BG3Editor_Visuals_MaterialType1"
        BG3Editor_Visuals_MaterialType1.Size = New Size(287, 23)
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
        ' BG3Editor_Material_SourceFile1
        ' 
        BG3Editor_Material_SourceFile1.DropIcon = True
        BG3Editor_Material_SourceFile1.EditIsConditional = False
        BG3Editor_Material_SourceFile1.Label = "Material shader"
        BG3Editor_Material_SourceFile1.Location = New Point(3, 13)
        BG3Editor_Material_SourceFile1.Margin = New Padding(0)
        BG3Editor_Material_SourceFile1.MaximumSize = New Size(3000, 23)
        BG3Editor_Material_SourceFile1.MinimumSize = New Size(100, 23)
        BG3Editor_Material_SourceFile1.Name = "BG3Editor_Material_SourceFile1"
        BG3Editor_Material_SourceFile1.ReadOnly = True
        BG3Editor_Material_SourceFile1.Size = New Size(789, 23)
        BG3Editor_Material_SourceFile1.SplitterDistance = 100
        BG3Editor_Material_SourceFile1.TabIndex = 10
        ' 
        ' GroupboxAsset
        ' 
        GroupboxAsset.Controls.Add(BG3Editor_Material_SourceFile1)
        GroupboxAsset.Location = New Point(6, 10)
        GroupboxAsset.Name = "GroupboxAsset"
        GroupboxAsset.Size = New Size(795, 43)
        GroupboxAsset.TabIndex = 11
        GroupboxAsset.TabStop = False
        GroupboxAsset.Text = "Base"
        ' 
        ' GroupBoxVT
        ' 
        GroupBoxVT.Controls.Add(ButtonVT)
        GroupBoxVT.Controls.Add(LabelVT)
        GroupBoxVT.Controls.Add(BG3Editor_Visuals_VirtualTexture1)
        GroupBoxVT.Location = New Point(6, 186)
        GroupBoxVT.Name = "GroupBoxVT"
        GroupBoxVT.Size = New Size(795, 43)
        GroupBoxVT.TabIndex = 12
        GroupBoxVT.TabStop = False
        GroupBoxVT.Text = "Vrtual texture"
        ' 
        ' ButtonVT
        ' 
        ButtonVT.Location = New Point(377, 17)
        ButtonVT.Name = "ButtonVT"
        ButtonVT.Size = New Size(24, 23)
        ButtonVT.TabIndex = 2
        ButtonVT.Text = "X"
        ButtonVT.UseVisualStyleBackColor = True
        ' 
        ' LabelVT
        ' 
        LabelVT.Location = New Point(407, 17)
        LabelVT.Name = "LabelVT"
        LabelVT.Size = New Size(382, 23)
        LabelVT.TabIndex = 1
        LabelVT.Text = "(None)"
        LabelVT.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' BG3Editor_Visuals_VirtualTexture1
        ' 
        BG3Editor_Visuals_VirtualTexture1.DropIcon = True
        BG3Editor_Visuals_VirtualTexture1.EditIsConditional = False
        BG3Editor_Visuals_VirtualTexture1.Label = "Gtex name"
        BG3Editor_Visuals_VirtualTexture1.Location = New Point(3, 17)
        BG3Editor_Visuals_VirtualTexture1.Margin = New Padding(0)
        BG3Editor_Visuals_VirtualTexture1.MaximumSize = New Size(3000, 23)
        BG3Editor_Visuals_VirtualTexture1.MinimumSize = New Size(100, 23)
        BG3Editor_Visuals_VirtualTexture1.Name = "BG3Editor_Visuals_VirtualTexture1"
        BG3Editor_Visuals_VirtualTexture1.ReadOnly = True
        BG3Editor_Visuals_VirtualTexture1.Size = New Size(371, 23)
        BG3Editor_Visuals_VirtualTexture1.SplitterDistance = 100
        BG3Editor_Visuals_VirtualTexture1.TabIndex = 0
        ' 
        ' GroupBoxTextures2d
        ' 
        GroupBoxTextures2d.Controls.Add(ButtonPM)
        GroupBoxTextures2d.Controls.Add(ButtonNM)
        GroupBoxTextures2d.Controls.Add(ButtonBM)
        GroupBoxTextures2d.Controls.Add(LabelPM)
        GroupBoxTextures2d.Controls.Add(LabelNM)
        GroupBoxTextures2d.Controls.Add(LabelBM)
        GroupBoxTextures2d.Controls.Add(BG3Editor_Visuals_PhisicalMap1)
        GroupBoxTextures2d.Controls.Add(BG3Editor_Visuals_NormalMap1)
        GroupBoxTextures2d.Controls.Add(BG3Editor_Visuals_BasecolorMap1)
        GroupBoxTextures2d.Location = New Point(6, 235)
        GroupBoxTextures2d.Name = "GroupBoxTextures2d"
        GroupBoxTextures2d.Size = New Size(795, 103)
        GroupBoxTextures2d.TabIndex = 13
        GroupBoxTextures2d.TabStop = False
        GroupBoxTextures2d.Text = "Textures 2D"
        ' 
        ' ButtonPM
        ' 
        ButtonPM.Location = New Point(377, 65)
        ButtonPM.Name = "ButtonPM"
        ButtonPM.Size = New Size(24, 23)
        ButtonPM.TabIndex = 8
        ButtonPM.Text = "X"
        ButtonPM.UseVisualStyleBackColor = True
        ' 
        ' ButtonNM
        ' 
        ButtonNM.Location = New Point(377, 42)
        ButtonNM.Name = "ButtonNM"
        ButtonNM.Size = New Size(24, 23)
        ButtonNM.TabIndex = 7
        ButtonNM.Text = "X"
        ButtonNM.UseVisualStyleBackColor = True
        ' 
        ' ButtonBM
        ' 
        ButtonBM.Location = New Point(377, 19)
        ButtonBM.Name = "ButtonBM"
        ButtonBM.Size = New Size(24, 23)
        ButtonBM.TabIndex = 6
        ButtonBM.Text = "X"
        ButtonBM.UseVisualStyleBackColor = True
        ' 
        ' LabelPM
        ' 
        LabelPM.Location = New Point(407, 65)
        LabelPM.Name = "LabelPM"
        LabelPM.Size = New Size(382, 23)
        LabelPM.TabIndex = 5
        LabelPM.Text = "(None)"
        LabelPM.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' LabelNM
        ' 
        LabelNM.Location = New Point(407, 42)
        LabelNM.Name = "LabelNM"
        LabelNM.Size = New Size(382, 23)
        LabelNM.TabIndex = 4
        LabelNM.Text = "(None)"
        LabelNM.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' LabelBM
        ' 
        LabelBM.Location = New Point(407, 19)
        LabelBM.Name = "LabelBM"
        LabelBM.Size = New Size(382, 23)
        LabelBM.TabIndex = 3
        LabelBM.Text = "(None)"
        LabelBM.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' BG3Editor_Visuals_PhisicalMap1
        ' 
        BG3Editor_Visuals_PhisicalMap1.DropIcon = True
        BG3Editor_Visuals_PhisicalMap1.EditIsConditional = False
        BG3Editor_Visuals_PhisicalMap1.Label = "Physical map"
        BG3Editor_Visuals_PhisicalMap1.Location = New Point(3, 65)
        BG3Editor_Visuals_PhisicalMap1.Margin = New Padding(0)
        BG3Editor_Visuals_PhisicalMap1.MaximumSize = New Size(3000, 23)
        BG3Editor_Visuals_PhisicalMap1.MinimumSize = New Size(100, 23)
        BG3Editor_Visuals_PhisicalMap1.Name = "BG3Editor_Visuals_PhisicalMap1"
        BG3Editor_Visuals_PhisicalMap1.ReadOnly = True
        BG3Editor_Visuals_PhisicalMap1.Size = New Size(371, 23)
        BG3Editor_Visuals_PhisicalMap1.SplitterDistance = 100
        BG3Editor_Visuals_PhisicalMap1.TabIndex = 2
        ' 
        ' BG3Editor_Visuals_NormalMap1
        ' 
        BG3Editor_Visuals_NormalMap1.DropIcon = True
        BG3Editor_Visuals_NormalMap1.EditIsConditional = False
        BG3Editor_Visuals_NormalMap1.Label = "Normal map"
        BG3Editor_Visuals_NormalMap1.Location = New Point(3, 42)
        BG3Editor_Visuals_NormalMap1.Margin = New Padding(0)
        BG3Editor_Visuals_NormalMap1.MaximumSize = New Size(3000, 23)
        BG3Editor_Visuals_NormalMap1.MinimumSize = New Size(100, 23)
        BG3Editor_Visuals_NormalMap1.Name = "BG3Editor_Visuals_NormalMap1"
        BG3Editor_Visuals_NormalMap1.ReadOnly = True
        BG3Editor_Visuals_NormalMap1.Size = New Size(371, 23)
        BG3Editor_Visuals_NormalMap1.SplitterDistance = 100
        BG3Editor_Visuals_NormalMap1.TabIndex = 1
        ' 
        ' BG3Editor_Visuals_BasecolorMap1
        ' 
        BG3Editor_Visuals_BasecolorMap1.DropIcon = True
        BG3Editor_Visuals_BasecolorMap1.EditIsConditional = False
        BG3Editor_Visuals_BasecolorMap1.Label = "Base map"
        BG3Editor_Visuals_BasecolorMap1.Location = New Point(3, 19)
        BG3Editor_Visuals_BasecolorMap1.Margin = New Padding(0)
        BG3Editor_Visuals_BasecolorMap1.MaximumSize = New Size(3000, 23)
        BG3Editor_Visuals_BasecolorMap1.MinimumSize = New Size(100, 23)
        BG3Editor_Visuals_BasecolorMap1.Name = "BG3Editor_Visuals_BasecolorMap1"
        BG3Editor_Visuals_BasecolorMap1.ReadOnly = True
        BG3Editor_Visuals_BasecolorMap1.Size = New Size(371, 23)
        BG3Editor_Visuals_BasecolorMap1.SplitterDistance = 100
        BG3Editor_Visuals_BasecolorMap1.TabIndex = 0
        ' 
        ' GroupBoxMsk
        ' 
        GroupBoxMsk.Controls.Add(ButtonGM)
        GroupBoxMsk.Controls.Add(LabelGM)
        GroupBoxMsk.Controls.Add(BG3Editor_Visuals_Glow_msk1)
        GroupBoxMsk.Controls.Add(ButtonVertexMsk)
        GroupBoxMsk.Controls.Add(LabelVertexMSK)
        GroupBoxMsk.Controls.Add(ButtonMSKClt)
        GroupBoxMsk.Controls.Add(LabelMskclt)
        GroupBoxMsk.Controls.Add(BG3Editor_Visuals_msKcloth1)
        GroupBoxMsk.Controls.Add(BG3Editor_Visuals_VertexColor_msk1)
        GroupBoxMsk.Controls.Add(ButtonMSK)
        GroupBoxMsk.Controls.Add(LabelColorMSK)
        GroupBoxMsk.Controls.Add(BG3Editor_Visuals_MaskTexture1)
        GroupBoxMsk.Location = New Point(6, 344)
        GroupBoxMsk.Name = "GroupBoxMsk"
        GroupBoxMsk.Size = New Size(795, 117)
        GroupBoxMsk.TabIndex = 14
        GroupBoxMsk.TabStop = False
        GroupBoxMsk.Text = "Mask textures"
        ' 
        ' ButtonGM
        ' 
        ButtonGM.Location = New Point(377, 86)
        ButtonGM.Name = "ButtonGM"
        ButtonGM.Size = New Size(24, 23)
        ButtonGM.TabIndex = 12
        ButtonGM.Text = "X"
        ButtonGM.UseVisualStyleBackColor = True
        ' 
        ' LabelGM
        ' 
        LabelGM.Location = New Point(407, 86)
        LabelGM.Name = "LabelGM"
        LabelGM.Size = New Size(382, 23)
        LabelGM.TabIndex = 11
        LabelGM.Text = "(None)"
        LabelGM.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' BG3Editor_Visuals_Glow_msk1
        ' 
        BG3Editor_Visuals_Glow_msk1.DropIcon = True
        BG3Editor_Visuals_Glow_msk1.EditIsConditional = False
        BG3Editor_Visuals_Glow_msk1.Label = "Glow msk"
        BG3Editor_Visuals_Glow_msk1.Location = New Point(3, 86)
        BG3Editor_Visuals_Glow_msk1.Margin = New Padding(0)
        BG3Editor_Visuals_Glow_msk1.MaximumSize = New Size(3000, 23)
        BG3Editor_Visuals_Glow_msk1.MinimumSize = New Size(100, 23)
        BG3Editor_Visuals_Glow_msk1.Name = "BG3Editor_Visuals_Glow_msk1"
        BG3Editor_Visuals_Glow_msk1.ReadOnly = True
        BG3Editor_Visuals_Glow_msk1.Size = New Size(371, 23)
        BG3Editor_Visuals_Glow_msk1.SplitterDistance = 100
        BG3Editor_Visuals_Glow_msk1.TabIndex = 10
        ' 
        ' ButtonVertexMsk
        ' 
        ButtonVertexMsk.Location = New Point(377, 63)
        ButtonVertexMsk.Name = "ButtonVertexMsk"
        ButtonVertexMsk.Size = New Size(24, 23)
        ButtonVertexMsk.TabIndex = 9
        ButtonVertexMsk.Text = "X"
        ButtonVertexMsk.UseVisualStyleBackColor = True
        ' 
        ' LabelVertexMSK
        ' 
        LabelVertexMSK.Location = New Point(407, 63)
        LabelVertexMSK.Name = "LabelVertexMSK"
        LabelVertexMSK.Size = New Size(382, 23)
        LabelVertexMSK.TabIndex = 8
        LabelVertexMSK.Text = "(None)"
        LabelVertexMSK.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' ButtonMSKClt
        ' 
        ButtonMSKClt.Location = New Point(377, 40)
        ButtonMSKClt.Name = "ButtonMSKClt"
        ButtonMSKClt.Size = New Size(24, 23)
        ButtonMSKClt.TabIndex = 7
        ButtonMSKClt.Text = "X"
        ButtonMSKClt.UseVisualStyleBackColor = True
        ' 
        ' LabelMskclt
        ' 
        LabelMskclt.Location = New Point(407, 40)
        LabelMskclt.Name = "LabelMskclt"
        LabelMskclt.Size = New Size(382, 23)
        LabelMskclt.TabIndex = 6
        LabelMskclt.Text = "(None)"
        LabelMskclt.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' BG3Editor_Visuals_msKcloth1
        ' 
        BG3Editor_Visuals_msKcloth1.DropIcon = True
        BG3Editor_Visuals_msKcloth1.EditIsConditional = False
        BG3Editor_Visuals_msKcloth1.Label = "Cloth msk"
        BG3Editor_Visuals_msKcloth1.Location = New Point(3, 40)
        BG3Editor_Visuals_msKcloth1.Margin = New Padding(0)
        BG3Editor_Visuals_msKcloth1.MaximumSize = New Size(3000, 23)
        BG3Editor_Visuals_msKcloth1.MinimumSize = New Size(100, 23)
        BG3Editor_Visuals_msKcloth1.Name = "BG3Editor_Visuals_msKcloth1"
        BG3Editor_Visuals_msKcloth1.ReadOnly = True
        BG3Editor_Visuals_msKcloth1.Size = New Size(371, 23)
        BG3Editor_Visuals_msKcloth1.SplitterDistance = 100
        BG3Editor_Visuals_msKcloth1.TabIndex = 5
        ' 
        ' BG3Editor_Visuals_VertexColor_msk1
        ' 
        BG3Editor_Visuals_VertexColor_msk1.DropIcon = True
        BG3Editor_Visuals_VertexColor_msk1.EditIsConditional = False
        BG3Editor_Visuals_VertexColor_msk1.Label = "Vertex color msk"
        BG3Editor_Visuals_VertexColor_msk1.Location = New Point(3, 63)
        BG3Editor_Visuals_VertexColor_msk1.Margin = New Padding(0)
        BG3Editor_Visuals_VertexColor_msk1.MaximumSize = New Size(3000, 23)
        BG3Editor_Visuals_VertexColor_msk1.MinimumSize = New Size(100, 23)
        BG3Editor_Visuals_VertexColor_msk1.Name = "BG3Editor_Visuals_VertexColor_msk1"
        BG3Editor_Visuals_VertexColor_msk1.ReadOnly = True
        BG3Editor_Visuals_VertexColor_msk1.Size = New Size(371, 23)
        BG3Editor_Visuals_VertexColor_msk1.SplitterDistance = 100
        BG3Editor_Visuals_VertexColor_msk1.TabIndex = 4
        ' 
        ' ButtonMSK
        ' 
        ButtonMSK.Location = New Point(377, 17)
        ButtonMSK.Name = "ButtonMSK"
        ButtonMSK.Size = New Size(24, 23)
        ButtonMSK.TabIndex = 3
        ButtonMSK.Text = "X"
        ButtonMSK.UseVisualStyleBackColor = True
        ' 
        ' LabelColorMSK
        ' 
        LabelColorMSK.Location = New Point(407, 17)
        LabelColorMSK.Name = "LabelColorMSK"
        LabelColorMSK.Size = New Size(382, 23)
        LabelColorMSK.TabIndex = 2
        LabelColorMSK.Text = "(None)"
        LabelColorMSK.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' BG3Editor_Visuals_MaskTexture1
        ' 
        BG3Editor_Visuals_MaskTexture1.DropIcon = True
        BG3Editor_Visuals_MaskTexture1.EditIsConditional = False
        BG3Editor_Visuals_MaskTexture1.Label = "Color msk"
        BG3Editor_Visuals_MaskTexture1.Location = New Point(3, 17)
        BG3Editor_Visuals_MaskTexture1.Margin = New Padding(0)
        BG3Editor_Visuals_MaskTexture1.MaximumSize = New Size(3000, 23)
        BG3Editor_Visuals_MaskTexture1.MinimumSize = New Size(100, 23)
        BG3Editor_Visuals_MaskTexture1.Name = "BG3Editor_Visuals_MaskTexture1"
        BG3Editor_Visuals_MaskTexture1.ReadOnly = True
        BG3Editor_Visuals_MaskTexture1.Size = New Size(371, 23)
        BG3Editor_Visuals_MaskTexture1.SplitterDistance = 100
        BG3Editor_Visuals_MaskTexture1.TabIndex = 0
        ' 
        ' TabPageDyes
        ' 
        TabPageDyes.Controls.Add(GroupBox6)
        TabPageDyes.Location = New Point(4, 27)
        TabPageDyes.Name = "TabPageDyes"
        TabPageDyes.Size = New Size(807, 562)
        TabPageDyes.TabIndex = 7
        TabPageDyes.Text = "Colors definitions"
        ' 
        ' GroupBox6
        ' 
        GroupBox6.Controls.Add(BG3Editor_Complex_Dyecolor1)
        GroupBox6.Dock = DockStyle.Fill
        GroupBox6.Location = New Point(0, 0)
        GroupBox6.Name = "GroupBox6"
        GroupBox6.Size = New Size(807, 562)
        GroupBox6.TabIndex = 2
        GroupBox6.TabStop = False
        ' 
        ' BG3Editor_Complex_Dyecolor1
        ' 
        BG3Editor_Complex_Dyecolor1.Dock = DockStyle.Fill
        BG3Editor_Complex_Dyecolor1.Enabled = False
        BG3Editor_Complex_Dyecolor1.Location = New Point(3, 19)
        BG3Editor_Complex_Dyecolor1.Name = "BG3Editor_Complex_Dyecolor1"
        BG3Editor_Complex_Dyecolor1.Size = New Size(801, 540)
        BG3Editor_Complex_Dyecolor1.TabIndex = 0
        ' 
        ' TabPageScalars
        ' 
        TabPageScalars.Controls.Add(GroupBoxScalars)
        TabPageScalars.Location = New Point(4, 27)
        TabPageScalars.Name = "TabPageScalars"
        TabPageScalars.Size = New Size(807, 562)
        TabPageScalars.TabIndex = 8
        TabPageScalars.Text = "Scalars and vectors"
        ' 
        ' GroupBoxScalars
        ' 
        GroupBoxScalars.Controls.Add(BG3Editor_Complex_ScalarsandVectors1)
        GroupBoxScalars.Dock = DockStyle.Fill
        GroupBoxScalars.Location = New Point(0, 0)
        GroupBoxScalars.Name = "GroupBoxScalars"
        GroupBoxScalars.Size = New Size(807, 562)
        GroupBoxScalars.TabIndex = 1
        GroupBoxScalars.TabStop = False
        ' 
        ' BG3Editor_Complex_ScalarsandVectors1
        ' 
        BG3Editor_Complex_ScalarsandVectors1.Dock = DockStyle.Fill
        BG3Editor_Complex_ScalarsandVectors1.Location = New Point(3, 19)
        BG3Editor_Complex_ScalarsandVectors1.Name = "BG3Editor_Complex_ScalarsandVectors1"
        BG3Editor_Complex_ScalarsandVectors1.Size = New Size(801, 540)
        BG3Editor_Complex_ScalarsandVectors1.TabIndex = 0
        ' 
        ' MaterialBank_Editor
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1169, 596)
        Name = "MaterialBank_Editor"
        Text = "Material bank editor"
        TabPage1.ResumeLayout(False)
        GroupBox9.ResumeLayout(False)
        TabControl1.ResumeLayout(False)
        GroupBoxTexture.ResumeLayout(False)
        GroupboxAsset.ResumeLayout(False)
        GroupBoxVT.ResumeLayout(False)
        GroupBoxTextures2d.ResumeLayout(False)
        GroupBoxMsk.ResumeLayout(False)
        TabPageDyes.ResumeLayout(False)
        GroupBox6.ResumeLayout(False)
        TabPageScalars.ResumeLayout(False)
        GroupBoxScalars.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Protected Friend WithEvents GroupBoxTexture As GroupBox
    Friend WithEvents BG3Editor_Textures_iD_Fixed1 As BG3Editor_Textures_ID_Fixed
    Friend WithEvents BG3Editor_Textures_Name1 As BG3Editor_Textures_Name
    Friend WithEvents BG3Editor_Material_SourceFile1 As BG3Editor_Materialbank_SourceFile
    Friend WithEvents GroupboxAsset As GroupBox
    Friend WithEvents BG3Editor_Visuals_MaterialType1 As BG3Editor_Visuals_MaterialType
    Friend WithEvents BG3Editor_Visuals_DiffusionProfileuuid1 As BG3Editor_Visuals_DiffusionProfileUUID
    Friend WithEvents GroupBoxMsk As GroupBox
    Friend WithEvents GroupBoxTextures2d As GroupBox
    Friend WithEvents GroupBoxVT As GroupBox
    Friend WithEvents BG3Editor_Visuals_VirtualTexture1 As BG3Editor_Visuals_VirtualTexture
    Friend WithEvents LabelVT As Label
    Friend WithEvents LabelColorMSK As Label
    Friend WithEvents BG3Editor_Visuals_MaskTexture1 As BG3Editor_Visuals_MaskTexture
    Friend WithEvents LabelPM As Label
    Friend WithEvents LabelNM As Label
    Friend WithEvents LabelBM As Label
    Friend WithEvents BG3Editor_Visuals_PhisicalMap1 As BG3Editor_Visuals_PhisicalMap
    Friend WithEvents BG3Editor_Visuals_NormalMap1 As BG3Editor_Visuals_NormalMap
    Friend WithEvents BG3Editor_Visuals_BasecolorMap1 As BG3Editor_Visuals_BasecolorMap
    Friend WithEvents ButtonMSK As Button
    Friend WithEvents ButtonPM As Button
    Friend WithEvents ButtonNM As Button
    Friend WithEvents ButtonBM As Button
    Friend WithEvents ButtonVT As Button
    Friend WithEvents BG3Editor_Visuals_msKcloth1 As BG3Editor_Visuals_MSKcloth
    Friend WithEvents BG3Editor_Visuals_VertexColor_msk1 As BG3Editor_Visuals_VertexColor_MSK
    Friend WithEvents ButtonVertexMsk As Button
    Friend WithEvents LabelVertexMSK As Label
    Friend WithEvents ButtonMSKClt As Button
    Friend WithEvents LabelMskclt As Label
    Friend WithEvents TabPageDyes As TabPage
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents BG3Editor_Complex_Dyecolor1 As BG3Editor_Complex_Dyecolor
    Friend Protected WithEvents TabPageScalars As TabPage
    Friend Protected WithEvents GroupBoxScalars As GroupBox
    Friend WithEvents BG3Editor_Complex_ScalarsandVectors1 As BG3Editor_Complex_ScalarsandVectors
    Friend WithEvents ButtonGM As Button
    Friend WithEvents LabelGM As Label
    Friend WithEvents BG3Editor_Visuals_Glow_msk1 As BG3Editor_Visuals_VertexColor_MSK
End Class
