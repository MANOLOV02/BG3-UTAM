<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Textures_Editor
    Inherits Generic_Visuals_Editor

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
        GroupBoxTexture = New GroupBox()
        Label2 = New Label()
        Label1 = New Label()
        BG3Editor_Visuals_srgb1 = New BG3Editor_Visuals_SRGB()
        BG3Editor_Visuals_Localized1 = New BG3Editor_Visuals_Localized()
        BG3Editor_Texture_Height1 = New BG3Editor_Texture_Height()
        BG3Editor_Texture_Width1 = New BG3Editor_Texture_Width()
        BG3Editor_Texture_Type1 = New BG3Editor_Texture_Type()
        BG3Editor_Texture_Format1 = New BG3Editor_Texture_Format()
        BG3Editor_Texture_Depth1 = New BG3Editor_Texture_Depth()
        BG3Editor_Textures_Template1 = New BG3Editor_Textures_Template()
        BG3Editor_Textures_Name1 = New BG3Editor_Textures_Name()
        BG3Editor_Textures_iD_Fixed1 = New BG3Editor_Textures_ID_Fixed()
        BG3Editor_Textures_SourceFile1 = New BG3Editor_Textures_SourceFile()
        GroupboxAsset = New GroupBox()
        ButtonAsset = New Button()
        PictureBox1 = New PictureBox()
        TabPage1.SuspendLayout()
        GroupBox9.SuspendLayout()
        TabControl1.SuspendLayout()
        GroupBoxTexture.SuspendLayout()
        GroupboxAsset.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GroupBox9
        ' 
        GroupBox9.Controls.Add(PictureBox1)
        GroupBox9.Controls.Add(GroupboxAsset)
        GroupBox9.Controls.Add(GroupBoxTexture)
        ' 
        ' GroupBoxTexture
        ' 
        GroupBoxTexture.Controls.Add(Label2)
        GroupBoxTexture.Controls.Add(Label1)
        GroupBoxTexture.Controls.Add(BG3Editor_Visuals_srgb1)
        GroupBoxTexture.Controls.Add(BG3Editor_Visuals_Localized1)
        GroupBoxTexture.Controls.Add(BG3Editor_Texture_Height1)
        GroupBoxTexture.Controls.Add(BG3Editor_Texture_Width1)
        GroupBoxTexture.Controls.Add(BG3Editor_Texture_Type1)
        GroupBoxTexture.Controls.Add(BG3Editor_Texture_Format1)
        GroupBoxTexture.Controls.Add(BG3Editor_Texture_Depth1)
        GroupBoxTexture.Controls.Add(BG3Editor_Textures_Template1)
        GroupBoxTexture.Controls.Add(BG3Editor_Textures_Name1)
        GroupBoxTexture.Controls.Add(BG3Editor_Textures_iD_Fixed1)
        GroupBoxTexture.Location = New Point(6, 10)
        GroupBoxTexture.Name = "GroupBoxTexture"
        GroupBoxTexture.Size = New Size(407, 256)
        GroupBoxTexture.TabIndex = 1
        GroupBoxTexture.TabStop = False
        GroupBoxTexture.Text = "Texture"
        ' 
        ' Label2
        ' 
        Label2.Location = New Point(229, 180)
        Label2.Name = "Label2"
        Label2.Size = New Size(159, 23)
        Label2.TabIndex = 11
        Label2.Text = "Asset height: 0"
        Label2.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label1
        ' 
        Label1.Location = New Point(229, 157)
        Label1.Name = "Label1"
        Label1.Size = New Size(159, 23)
        Label1.TabIndex = 10
        Label1.Text = "Asset width: 0"
        Label1.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' BG3Editor_Visuals_srgb1
        ' 
        BG3Editor_Visuals_srgb1.EditIsConditional = False
        BG3Editor_Visuals_srgb1.EditorType = BG3_Editor_Type.Combobox
        BG3Editor_Visuals_srgb1.Label = "SRGB"
        BG3Editor_Visuals_srgb1.Location = New Point(3, 226)
        BG3Editor_Visuals_srgb1.Margin = New Padding(0)
        BG3Editor_Visuals_srgb1.MaximumSize = New Size(3000, 23)
        BG3Editor_Visuals_srgb1.MinimumSize = New Size(100, 23)
        BG3Editor_Visuals_srgb1.Name = "BG3Editor_Visuals_srgb1"
        BG3Editor_Visuals_srgb1.Size = New Size(212, 23)
        BG3Editor_Visuals_srgb1.TabIndex = 9
        ' 
        ' BG3Editor_Visuals_Localized1
        ' 
        BG3Editor_Visuals_Localized1.EditorType = BG3_Editor_Type.Combobox
        BG3Editor_Visuals_Localized1.Label = "Localized"
        BG3Editor_Visuals_Localized1.Location = New Point(3, 203)
        BG3Editor_Visuals_Localized1.Margin = New Padding(0)
        BG3Editor_Visuals_Localized1.MaximumSize = New Size(3000, 23)
        BG3Editor_Visuals_Localized1.MinimumSize = New Size(100, 23)
        BG3Editor_Visuals_Localized1.Name = "BG3Editor_Visuals_Localized1"
        BG3Editor_Visuals_Localized1.Size = New Size(212, 23)
        BG3Editor_Visuals_Localized1.TabIndex = 8
        ' 
        ' BG3Editor_Texture_Height1
        ' 
        BG3Editor_Texture_Height1.EditIsConditional = False
        BG3Editor_Texture_Height1.EditorType = BG3_Editor_Type.NumericUpDown
        BG3Editor_Texture_Height1.Label = "Height"
        BG3Editor_Texture_Height1.Location = New Point(3, 180)
        BG3Editor_Texture_Height1.Margin = New Padding(0)
        BG3Editor_Texture_Height1.MaximumSize = New Size(3000, 23)
        BG3Editor_Texture_Height1.MinimumSize = New Size(100, 23)
        BG3Editor_Texture_Height1.Name = "BG3Editor_Texture_Height1"
        BG3Editor_Texture_Height1.Size = New Size(212, 23)
        BG3Editor_Texture_Height1.TabIndex = 7
        ' 
        ' BG3Editor_Texture_Width1
        ' 
        BG3Editor_Texture_Width1.EditIsConditional = False
        BG3Editor_Texture_Width1.EditorType = BG3_Editor_Type.NumericUpDown
        BG3Editor_Texture_Width1.Label = "Width"
        BG3Editor_Texture_Width1.Location = New Point(3, 157)
        BG3Editor_Texture_Width1.Margin = New Padding(0)
        BG3Editor_Texture_Width1.MaximumSize = New Size(3000, 23)
        BG3Editor_Texture_Width1.MinimumSize = New Size(100, 23)
        BG3Editor_Texture_Width1.Name = "BG3Editor_Texture_Width1"
        BG3Editor_Texture_Width1.Size = New Size(212, 23)
        BG3Editor_Texture_Width1.TabIndex = 6
        ' 
        ' BG3Editor_Texture_Type1
        ' 
        BG3Editor_Texture_Type1.EditIsConditional = False
        BG3Editor_Texture_Type1.EditorType = BG3_Editor_Type.NumericUpDown
        BG3Editor_Texture_Type1.Label = "Type"
        BG3Editor_Texture_Type1.Location = New Point(3, 111)
        BG3Editor_Texture_Type1.Margin = New Padding(0)
        BG3Editor_Texture_Type1.MaximumSize = New Size(3000, 23)
        BG3Editor_Texture_Type1.MinimumSize = New Size(100, 23)
        BG3Editor_Texture_Type1.Name = "BG3Editor_Texture_Type1"
        BG3Editor_Texture_Type1.Size = New Size(212, 23)
        BG3Editor_Texture_Type1.TabIndex = 5
        ' 
        ' BG3Editor_Texture_Format1
        ' 
        BG3Editor_Texture_Format1.EditorType = BG3_Editor_Type.NumericUpDown
        BG3Editor_Texture_Format1.Label = "Format"
        BG3Editor_Texture_Format1.Location = New Point(3, 134)
        BG3Editor_Texture_Format1.Margin = New Padding(0)
        BG3Editor_Texture_Format1.MaximumSize = New Size(3000, 23)
        BG3Editor_Texture_Format1.MinimumSize = New Size(100, 23)
        BG3Editor_Texture_Format1.Name = "BG3Editor_Texture_Format1"
        BG3Editor_Texture_Format1.Size = New Size(212, 23)
        BG3Editor_Texture_Format1.TabIndex = 4
        ' 
        ' BG3Editor_Texture_Depth1
        ' 
        BG3Editor_Texture_Depth1.EditIsConditional = False
        BG3Editor_Texture_Depth1.EditorType = BG3_Editor_Type.NumericUpDown
        BG3Editor_Texture_Depth1.Label = "Depth"
        BG3Editor_Texture_Depth1.Location = New Point(3, 88)
        BG3Editor_Texture_Depth1.Margin = New Padding(0)
        BG3Editor_Texture_Depth1.MaximumSize = New Size(3000, 23)
        BG3Editor_Texture_Depth1.MinimumSize = New Size(100, 23)
        BG3Editor_Texture_Depth1.Name = "BG3Editor_Texture_Depth1"
        BG3Editor_Texture_Depth1.Size = New Size(212, 23)
        BG3Editor_Texture_Depth1.TabIndex = 3
        ' 
        ' BG3Editor_Textures_Template1
        ' 
        BG3Editor_Textures_Template1.EditIsConditional = False
        BG3Editor_Textures_Template1.Label = "Template"
        BG3Editor_Textures_Template1.Location = New Point(3, 65)
        BG3Editor_Textures_Template1.Margin = New Padding(0)
        BG3Editor_Textures_Template1.MaximumSize = New Size(3000, 23)
        BG3Editor_Textures_Template1.MinimumSize = New Size(100, 23)
        BG3Editor_Textures_Template1.Name = "BG3Editor_Textures_Template1"
        BG3Editor_Textures_Template1.Size = New Size(401, 23)
        BG3Editor_Textures_Template1.TabIndex = 2
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
        ' BG3Editor_Textures_SourceFile1
        ' 
        BG3Editor_Textures_SourceFile1.DropIcon = True
        BG3Editor_Textures_SourceFile1.EditIsConditional = False
        BG3Editor_Textures_SourceFile1.Label = "Source file"
        BG3Editor_Textures_SourceFile1.Location = New Point(3, 13)
        BG3Editor_Textures_SourceFile1.Margin = New Padding(0)
        BG3Editor_Textures_SourceFile1.MaximumSize = New Size(3000, 23)
        BG3Editor_Textures_SourceFile1.MinimumSize = New Size(100, 23)
        BG3Editor_Textures_SourceFile1.Name = "BG3Editor_Textures_SourceFile1"
        BG3Editor_Textures_SourceFile1.ReadOnly = True
        BG3Editor_Textures_SourceFile1.Size = New Size(743, 23)
        BG3Editor_Textures_SourceFile1.TabIndex = 10
        ' 
        ' GroupboxAsset
        ' 
        GroupboxAsset.Controls.Add(ButtonAsset)
        GroupboxAsset.Controls.Add(BG3Editor_Textures_SourceFile1)
        GroupboxAsset.Location = New Point(6, 272)
        GroupboxAsset.Name = "GroupboxAsset"
        GroupboxAsset.Size = New Size(795, 43)
        GroupboxAsset.TabIndex = 11
        GroupboxAsset.TabStop = False
        GroupboxAsset.Text = "Asset"
        ' 
        ' ButtonAsset
        ' 
        ButtonAsset.Location = New Point(749, 13)
        ButtonAsset.Name = "ButtonAsset"
        ButtonAsset.Size = New Size(40, 23)
        ButtonAsset.TabIndex = 11
        ButtonAsset.Text = "....."
        ButtonAsset.UseVisualStyleBackColor = True
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BorderStyle = BorderStyle.FixedSingle
        PictureBox1.Location = New Point(502, 16)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(250, 250)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 12
        PictureBox1.TabStop = False
        ' 
        ' Textures_Editor
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1169, 596)
        Name = "Textures_Editor"
        Text = "Textures bank editor"
        TabPage1.ResumeLayout(False)
        GroupBox9.ResumeLayout(False)
        TabControl1.ResumeLayout(False)
        GroupBoxTexture.ResumeLayout(False)
        GroupboxAsset.ResumeLayout(False)
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend Protected WithEvents GroupBoxTexture As GroupBox
    Friend WithEvents BG3Editor_Textures_iD_Fixed1 As BG3Editor_Textures_ID_Fixed
    Friend WithEvents BG3Editor_Textures_Template1 As BG3Editor_Textures_Template
    Friend WithEvents BG3Editor_Textures_Name1 As BG3Editor_Textures_Name
    Friend WithEvents BG3Editor_Texture_Height1 As BG3Editor_Texture_Height
    Friend WithEvents BG3Editor_Texture_Width1 As BG3Editor_Texture_Width
    Friend WithEvents BG3Editor_Texture_Type1 As BG3Editor_Texture_Type
    Friend WithEvents BG3Editor_Texture_Format1 As BG3Editor_Texture_Format
    Friend WithEvents BG3Editor_Texture_Depth1 As BG3Editor_Texture_Depth
    Friend WithEvents BG3Editor_Visuals_srgb1 As BG3Editor_Visuals_SRGB
    Friend WithEvents BG3Editor_Visuals_Localized1 As BG3Editor_Visuals_Localized
    Friend WithEvents BG3Editor_Textures_SourceFile1 As BG3Editor_Textures_SourceFile
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents GroupboxAsset As GroupBox
    Friend WithEvents ButtonAsset As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
