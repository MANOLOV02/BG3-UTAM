<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Template_Information_Form
    Inherits Information_Form_Code

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
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Template_Information_Form))
        TabControl1 = New TabControl()
        Code = New TabPage()
        XmLtoRichText1 = New BG3Visualizer_XML()
        Stats = New TabPage()
        XmLtoRichText2 = New BG3Visualizer_XML()
        Visualtemplate = New TabPage()
        XmLtoRichText4 = New BG3Visualizer_XML()
        Meta = New TabPage()
        XmLtoRichText3 = New BG3Visualizer_XML()
        PictureBoxIcon = New PictureBox()
        LabelInfoName = New Label()
        LabelInfoDisplayName = New Label()
        LabelInfoIcon = New Label()
        LabelInfoStats = New Label()
        LabelInfoModule = New Label()
        LabelInfoPack = New Label()
        GroupBox2 = New GroupBox()
        SplitContainer1 = New SplitContainer()
        TabControl1.SuspendLayout()
        Code.SuspendLayout()
        Stats.SuspendLayout()
        Visualtemplate.SuspendLayout()
        Meta.SuspendLayout()
        CType(PictureBoxIcon, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox2.SuspendLayout()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.Panel1.SuspendLayout()
        SplitContainer1.Panel2.SuspendLayout()
        SplitContainer1.SuspendLayout()
        SuspendLayout()
        ' 
        ' TabControl1
        ' 
        TabControl1.Appearance = TabAppearance.FlatButtons
        TabControl1.Controls.Add(Code)
        TabControl1.Controls.Add(Stats)
        TabControl1.Controls.Add(Visualtemplate)
        TabControl1.Controls.Add(Meta)
        TabControl1.Dock = DockStyle.Fill
        TabControl1.Location = New Point(0, 91)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(551, 193)
        TabControl1.SizeMode = TabSizeMode.Fixed
        TabControl1.TabIndex = 16
        ' 
        ' Code
        ' 
        Code.BackColor = Color.Transparent
        Code.Controls.Add(XmLtoRichText1)
        Code.Location = New Point(4, 27)
        Code.Name = "Code"
        Code.Size = New Size(543, 162)
        Code.TabIndex = 0
        Code.Text = "Objetc code"
        ' 
        ' XmLtoRichText1
        ' 
        XmLtoRichText1.Dock = DockStyle.Fill
        XmLtoRichText1.IndentedText = True
        XmLtoRichText1.Location = New Point(0, 0)
        XmLtoRichText1.Name = "XmLtoRichText1"
        XmLtoRichText1.NamesColor = Color.Brown
        XmLtoRichText1.NodesColor = Color.Black
        XmLtoRichText1.Overridedolor = Color.Gray
        XmLtoRichText1.ReadOnly = True
        XmLtoRichText1.Size = New Size(543, 162)
        XmLtoRichText1.TabIndex = 16
        XmLtoRichText1.Text = ""
        XmLtoRichText1.ValueColor = Color.Blue
        XmLtoRichText1.WordWrap = False
        ' 
        ' Stats
        ' 
        Stats.BackColor = Color.Transparent
        Stats.Controls.Add(XmLtoRichText2)
        Stats.Location = New Point(4, 27)
        Stats.Name = "Stats"
        Stats.Size = New Size(376, 162)
        Stats.TabIndex = 1
        Stats.Text = "Stats"
        ' 
        ' XmLtoRichText2
        ' 
        XmLtoRichText2.Dock = DockStyle.Fill
        XmLtoRichText2.IndentedText = True
        XmLtoRichText2.Location = New Point(0, 0)
        XmLtoRichText2.Name = "XmLtoRichText2"
        XmLtoRichText2.NamesColor = Color.Brown
        XmLtoRichText2.NodesColor = Color.Black
        XmLtoRichText2.Overridedolor = Color.Gray
        XmLtoRichText2.ReadOnly = True
        XmLtoRichText2.Size = New Size(376, 162)
        XmLtoRichText2.TabIndex = 0
        XmLtoRichText2.Text = ""
        XmLtoRichText2.ValueColor = Color.Blue
        XmLtoRichText2.WordWrap = False
        ' 
        ' Visualtemplate
        ' 
        Visualtemplate.Controls.Add(XmLtoRichText4)
        Visualtemplate.Location = New Point(4, 27)
        Visualtemplate.Name = "Visualtemplate"
        Visualtemplate.Size = New Size(376, 162)
        Visualtemplate.TabIndex = 3
        Visualtemplate.Text = "Visual template"
        Visualtemplate.UseVisualStyleBackColor = True
        ' 
        ' XmLtoRichText4
        ' 
        XmLtoRichText4.Dock = DockStyle.Fill
        XmLtoRichText4.IndentedText = True
        XmLtoRichText4.Location = New Point(0, 0)
        XmLtoRichText4.Name = "XmLtoRichText4"
        XmLtoRichText4.NamesColor = Color.Brown
        XmLtoRichText4.NodesColor = Color.Black
        XmLtoRichText4.Overridedolor = Color.Gray
        XmLtoRichText4.ReadOnly = True
        XmLtoRichText4.Size = New Size(376, 162)
        XmLtoRichText4.TabIndex = 1
        XmLtoRichText4.Text = ""
        XmLtoRichText4.ValueColor = Color.Blue
        XmLtoRichText4.WordWrap = False
        ' 
        ' Meta
        ' 
        Meta.BackColor = Color.Transparent
        Meta.Controls.Add(XmLtoRichText3)
        Meta.Location = New Point(4, 27)
        Meta.Name = "Meta"
        Meta.Size = New Size(376, 162)
        Meta.TabIndex = 2
        Meta.Text = "Mod Meta"
        ' 
        ' XmLtoRichText3
        ' 
        XmLtoRichText3.Dock = DockStyle.Fill
        XmLtoRichText3.IndentedText = True
        XmLtoRichText3.Location = New Point(0, 0)
        XmLtoRichText3.Name = "XmLtoRichText3"
        XmLtoRichText3.NamesColor = Color.Brown
        XmLtoRichText3.NodesColor = Color.Black
        XmLtoRichText3.Overridedolor = Color.Gray
        XmLtoRichText3.ReadOnly = True
        XmLtoRichText3.Size = New Size(376, 162)
        XmLtoRichText3.TabIndex = 0
        XmLtoRichText3.Text = ""
        XmLtoRichText3.ValueColor = Color.Blue
        XmLtoRichText3.WordWrap = False
        ' 
        ' PictureBoxIcon
        ' 
        PictureBoxIcon.BorderStyle = BorderStyle.FixedSingle
        PictureBoxIcon.Location = New Point(6, 19)
        PictureBoxIcon.Name = "PictureBoxIcon"
        PictureBoxIcon.Size = New Size(64, 64)
        PictureBoxIcon.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBoxIcon.TabIndex = 17
        PictureBoxIcon.TabStop = False
        ' 
        ' LabelInfoName
        ' 
        LabelInfoName.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LabelInfoName.AutoEllipsis = True
        LabelInfoName.Location = New Point(3, 4)
        LabelInfoName.Name = "LabelInfoName"
        LabelInfoName.Size = New Size(228, 23)
        LabelInfoName.TabIndex = 18
        LabelInfoName.Text = "Name"
        LabelInfoName.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' LabelInfoDisplayName
        ' 
        LabelInfoDisplayName.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LabelInfoDisplayName.AutoEllipsis = True
        LabelInfoDisplayName.Location = New Point(3, 27)
        LabelInfoDisplayName.Name = "LabelInfoDisplayName"
        LabelInfoDisplayName.Size = New Size(228, 23)
        LabelInfoDisplayName.TabIndex = 19
        LabelInfoDisplayName.Text = "Display Name"
        LabelInfoDisplayName.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' LabelInfoIcon
        ' 
        LabelInfoIcon.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LabelInfoIcon.AutoEllipsis = True
        LabelInfoIcon.Location = New Point(3, 50)
        LabelInfoIcon.Name = "LabelInfoIcon"
        LabelInfoIcon.Size = New Size(228, 23)
        LabelInfoIcon.TabIndex = 20
        LabelInfoIcon.Text = "Icon"
        LabelInfoIcon.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' LabelInfoStats
        ' 
        LabelInfoStats.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LabelInfoStats.AutoEllipsis = True
        LabelInfoStats.Location = New Point(5, 48)
        LabelInfoStats.Name = "LabelInfoStats"
        LabelInfoStats.Size = New Size(241, 23)
        LabelInfoStats.TabIndex = 23
        LabelInfoStats.Text = "Stats"
        LabelInfoStats.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' LabelInfoModule
        ' 
        LabelInfoModule.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LabelInfoModule.AutoEllipsis = True
        LabelInfoModule.Location = New Point(5, 27)
        LabelInfoModule.Name = "LabelInfoModule"
        LabelInfoModule.Size = New Size(238, 23)
        LabelInfoModule.TabIndex = 22
        LabelInfoModule.Text = "Module"
        LabelInfoModule.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' LabelInfoPack
        ' 
        LabelInfoPack.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LabelInfoPack.AutoEllipsis = True
        LabelInfoPack.Location = New Point(5, 4)
        LabelInfoPack.Name = "LabelInfoPack"
        LabelInfoPack.Size = New Size(238, 23)
        LabelInfoPack.TabIndex = 21
        LabelInfoPack.Text = "Pack"
        LabelInfoPack.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(SplitContainer1)
        GroupBox2.Controls.Add(PictureBoxIcon)
        GroupBox2.Dock = DockStyle.Top
        GroupBox2.Location = New Point(0, 0)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(551, 91)
        GroupBox2.TabIndex = 24
        GroupBox2.TabStop = False
        ' 
        ' SplitContainer1
        ' 
        SplitContainer1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        SplitContainer1.Location = New Point(76, 12)
        SplitContainer1.Name = "SplitContainer1"
        ' 
        ' SplitContainer1.Panel1
        ' 
        SplitContainer1.Panel1.Controls.Add(LabelInfoName)
        SplitContainer1.Panel1.Controls.Add(LabelInfoDisplayName)
        SplitContainer1.Panel1.Controls.Add(LabelInfoIcon)
        ' 
        ' SplitContainer1.Panel2
        ' 
        SplitContainer1.Panel2.Controls.Add(LabelInfoPack)
        SplitContainer1.Panel2.Controls.Add(LabelInfoStats)
        SplitContainer1.Panel2.Controls.Add(LabelInfoModule)
        SplitContainer1.Size = New Size(469, 79)
        SplitContainer1.SplitterDistance = 234
        SplitContainer1.SplitterWidth = 1
        SplitContainer1.TabIndex = 24
        ' 
        ' Template_Information_Form
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(551, 284)
        Controls.Add(TabControl1)
        Controls.Add(GroupBox2)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Template_Information_Form"
        TabControl1.ResumeLayout(False)
        Code.ResumeLayout(False)
        Stats.ResumeLayout(False)
        Visualtemplate.ResumeLayout(False)
        Meta.ResumeLayout(False)
        CType(PictureBoxIcon, ComponentModel.ISupportInitialize).EndInit()
        GroupBox2.ResumeLayout(False)
        SplitContainer1.Panel1.ResumeLayout(False)
        SplitContainer1.Panel2.ResumeLayout(False)
        CType(SplitContainer1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents Code As TabPage
    Friend WithEvents Stats As TabPage
    Friend WithEvents PictureBoxIcon As PictureBox
    Friend WithEvents Meta As TabPage
    Friend WithEvents LabelInfoName As Label
    Friend WithEvents LabelInfoDisplayName As Label
    Friend WithEvents LabelInfoIcon As Label
    Friend WithEvents LabelInfoStats As Label
    Friend WithEvents LabelInfoModule As Label
    Friend WithEvents LabelInfoPack As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Visualtemplate As TabPage
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents XmLtoRichText1 As BG3Visualizer_XML
    Friend WithEvents XmLtoRichText2 As BG3Visualizer_XML
    Friend WithEvents XmLtoRichText3 As BG3Visualizer_XML
    Friend WithEvents XmLtoRichText4 As BG3Visualizer_XML

End Class
