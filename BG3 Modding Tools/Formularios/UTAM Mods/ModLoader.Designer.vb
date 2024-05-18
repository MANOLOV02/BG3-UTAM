<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModLoader
    Inherits System.Windows.Forms.Form

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
        ListBox1 = New ListBox()
        GroupBox1 = New GroupBox()
        TextBoxName = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        TextBoxFolder = New TextBox()
        Label3 = New Label()
        TextBoxDescription = New TextBox()
        Label4 = New Label()
        TextBoxAuthor = New TextBox()
        TextBoxVersion = New TextBox()
        Label5 = New Label()
        Label7 = New Label()
        TextBoxUUID = New TextBox()
        Button1 = New Button()
        ProgressBarCache = New ProgressBar()
        ProgressBar1 = New ProgressBar()
        GroupBox2 = New GroupBox()
        RadioButton2 = New RadioButton()
        RadioButton1 = New RadioButton()
        CheckBox1 = New CheckBox()
        Button2 = New Button()
        Button3 = New Button()
        GroupBox1.SuspendLayout()
        GroupBox2.SuspendLayout()
        SuspendLayout()
        ' 
        ' ListBox1
        ' 
        ListBox1.FormattingEnabled = True
        ListBox1.ItemHeight = 15
        ListBox1.Location = New Point(12, 7)
        ListBox1.Name = "ListBox1"
        ListBox1.Size = New Size(360, 349)
        ListBox1.Sorted = True
        ListBox1.TabIndex = 0
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(TextBoxName)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(TextBoxFolder)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(TextBoxDescription)
        GroupBox1.Controls.Add(Label4)
        GroupBox1.Controls.Add(TextBoxAuthor)
        GroupBox1.Controls.Add(TextBoxVersion)
        GroupBox1.Controls.Add(Label5)
        GroupBox1.Controls.Add(Label7)
        GroupBox1.Controls.Add(TextBoxUUID)
        GroupBox1.Location = New Point(378, 12)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(408, 210)
        GroupBox1.TabIndex = 1
        GroupBox1.TabStop = False
        GroupBox1.Text = "Mod details"
        ' 
        ' TextBoxName
        ' 
        TextBoxName.Location = New Point(114, 21)
        TextBoxName.Name = "TextBoxName"
        TextBoxName.ReadOnly = True
        TextBoxName.Size = New Size(282, 23)
        TextBoxName.TabIndex = 14
        ' 
        ' Label1
        ' 
        Label1.Location = New Point(13, 21)
        Label1.Name = "Label1"
        Label1.Size = New Size(95, 23)
        Label1.TabIndex = 15
        Label1.Text = "Mod name"
        Label1.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label2
        ' 
        Label2.Location = New Point(13, 50)
        Label2.Name = "Label2"
        Label2.Size = New Size(95, 23)
        Label2.TabIndex = 17
        Label2.Text = "Mod folder"
        Label2.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' TextBoxFolder
        ' 
        TextBoxFolder.Location = New Point(114, 50)
        TextBoxFolder.Name = "TextBoxFolder"
        TextBoxFolder.ReadOnly = True
        TextBoxFolder.Size = New Size(282, 23)
        TextBoxFolder.TabIndex = 16
        ' 
        ' Label3
        ' 
        Label3.Location = New Point(13, 79)
        Label3.Name = "Label3"
        Label3.Size = New Size(95, 23)
        Label3.TabIndex = 19
        Label3.Text = "Description"
        Label3.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' TextBoxDescription
        ' 
        TextBoxDescription.Location = New Point(114, 79)
        TextBoxDescription.Name = "TextBoxDescription"
        TextBoxDescription.ReadOnly = True
        TextBoxDescription.Size = New Size(282, 23)
        TextBoxDescription.TabIndex = 18
        ' 
        ' Label4
        ' 
        Label4.Location = New Point(13, 108)
        Label4.Name = "Label4"
        Label4.Size = New Size(95, 23)
        Label4.TabIndex = 21
        Label4.Text = "Author"
        Label4.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' TextBoxAuthor
        ' 
        TextBoxAuthor.Location = New Point(114, 108)
        TextBoxAuthor.Name = "TextBoxAuthor"
        TextBoxAuthor.ReadOnly = True
        TextBoxAuthor.Size = New Size(282, 23)
        TextBoxAuthor.TabIndex = 20
        ' 
        ' TextBoxVersion
        ' 
        TextBoxVersion.Location = New Point(113, 166)
        TextBoxVersion.Name = "TextBoxVersion"
        TextBoxVersion.ReadOnly = True
        TextBoxVersion.Size = New Size(282, 23)
        TextBoxVersion.TabIndex = 25
        ' 
        ' Label5
        ' 
        Label5.Location = New Point(13, 137)
        Label5.Name = "Label5"
        Label5.Size = New Size(95, 23)
        Label5.TabIndex = 23
        Label5.Text = "UUID"
        Label5.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label7
        ' 
        Label7.Location = New Point(12, 166)
        Label7.Name = "Label7"
        Label7.Size = New Size(95, 23)
        Label7.TabIndex = 24
        Label7.Text = "Version"
        Label7.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' TextBoxUUID
        ' 
        TextBoxUUID.Location = New Point(114, 137)
        TextBoxUUID.Name = "TextBoxUUID"
        TextBoxUUID.ReadOnly = True
        TextBoxUUID.Size = New Size(282, 23)
        TextBoxUUID.TabIndex = 22
        ' 
        ' Button1
        ' 
        Button1.Enabled = False
        Button1.Location = New Point(517, 325)
        Button1.Name = "Button1"
        Button1.Size = New Size(128, 23)
        Button1.TabIndex = 2
        Button1.Text = "Load"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' ProgressBarCache
        ' 
        ProgressBarCache.Location = New Point(193, 25)
        ProgressBarCache.Name = "ProgressBarCache"
        ProgressBarCache.Size = New Size(206, 10)
        ProgressBarCache.TabIndex = 17
        ' 
        ' ProgressBar1
        ' 
        ProgressBar1.Location = New Point(6, 72)
        ProgressBar1.Name = "ProgressBar1"
        ProgressBar1.Size = New Size(394, 10)
        ProgressBar1.TabIndex = 18
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(RadioButton2)
        GroupBox2.Controls.Add(ProgressBar1)
        GroupBox2.Controls.Add(RadioButton1)
        GroupBox2.Controls.Add(ProgressBarCache)
        GroupBox2.Controls.Add(CheckBox1)
        GroupBox2.Location = New Point(378, 228)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(407, 91)
        GroupBox2.TabIndex = 19
        GroupBox2.TabStop = False
        GroupBox2.Text = "Load options"
        ' 
        ' RadioButton2
        ' 
        RadioButton2.Location = New Point(188, 47)
        RadioButton2.Name = "RadioButton2"
        RadioButton2.Size = New Size(207, 19)
        RadioButton2.TabIndex = 2
        RadioButton2.Text = "Load from lsf.lsx and loca.xml files"
        RadioButton2.UseVisualStyleBackColor = True
        ' 
        ' RadioButton1
        ' 
        RadioButton1.Checked = True
        RadioButton1.Location = New Point(6, 47)
        RadioButton1.Name = "RadioButton1"
        RadioButton1.Size = New Size(145, 19)
        RadioButton1.TabIndex = 1
        RadioButton1.TabStop = True
        RadioButton1.Text = "Load from packed files"
        RadioButton1.UseVisualStyleBackColor = True
        ' 
        ' CheckBox1
        ' 
        CheckBox1.AutoEllipsis = True
        CheckBox1.Location = New Point(6, 22)
        CheckBox1.Name = "CheckBox1"
        CheckBox1.Size = New Size(183, 19)
        CheckBox1.TabIndex = 0
        CheckBox1.Text = "Clean load (reload cache first)"
        CheckBox1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Enabled = False
        Button2.Location = New Point(656, 325)
        Button2.Name = "Button2"
        Button2.Size = New Size(128, 23)
        Button2.TabIndex = 20
        Button2.Text = "Open folder"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(378, 325)
        Button3.Name = "Button3"
        Button3.Size = New Size(128, 23)
        Button3.TabIndex = 21
        Button3.Text = "New"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' ModLoader
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(792, 360)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(GroupBox2)
        Controls.Add(Button1)
        Controls.Add(GroupBox1)
        Controls.Add(ListBox1)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Name = "ModLoader"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Load an UTAM mod"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        GroupBox2.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Button1 As Button
    Friend WithEvents ProgressBarCache As ProgressBar
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents TextBoxName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBoxFolder As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBoxDescription As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBoxAuthor As TextBox
    Friend WithEvents TextBoxVersion As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents TextBoxUUID As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
End Class
