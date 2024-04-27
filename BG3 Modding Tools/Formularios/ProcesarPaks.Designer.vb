<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ProcesarPaks
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        ProgressBarPacks = New ProgressBar()
        ProgressBarFiles = New ProgressBar()
        ButtonProcess = New Button()
        TextBoxGameFolder = New TextBox()
        TextBoxModFolder = New TextBox()
        GroupBox1 = New GroupBox()
        CheckBoxIncludeMods = New CheckBox()
        ProgressBarCache = New ProgressBar()
        ButtonClearCache = New Button()
        ButtonLoadCache = New Button()
        Label1 = New Label()
        Label2 = New Label()
        Button2 = New Button()
        Button3 = New Button()
        TreeViewPacks = New TreeView()
        Label3 = New Label()
        TextBoxUTAMModFolder = New TextBox()
        Button1 = New Button()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' ProgressBarPacks
        ' 
        ProgressBarPacks.Location = New Point(7, 147)
        ProgressBarPacks.Name = "ProgressBarPacks"
        ProgressBarPacks.Size = New Size(496, 10)
        ProgressBarPacks.TabIndex = 1
        ' 
        ' ProgressBarFiles
        ' 
        ProgressBarFiles.Location = New Point(7, 164)
        ProgressBarFiles.Name = "ProgressBarFiles"
        ProgressBarFiles.Size = New Size(496, 10)
        ProgressBarFiles.TabIndex = 2
        ' 
        ' ButtonProcess
        ' 
        ButtonProcess.Enabled = False
        ButtonProcess.Location = New Point(6, 77)
        ButtonProcess.Name = "ButtonProcess"
        ButtonProcess.Size = New Size(501, 35)
        ButtonProcess.TabIndex = 3
        ButtonProcess.Text = "Process and save Cache"
        ButtonProcess.UseVisualStyleBackColor = True
        ' 
        ' TextBoxGameFolder
        ' 
        TextBoxGameFolder.Location = New Point(157, 12)
        TextBoxGameFolder.Name = "TextBoxGameFolder"
        TextBoxGameFolder.ReadOnly = True
        TextBoxGameFolder.Size = New Size(324, 23)
        TextBoxGameFolder.TabIndex = 5
        ' 
        ' TextBoxModFolder
        ' 
        TextBoxModFolder.Location = New Point(157, 43)
        TextBoxModFolder.Name = "TextBoxModFolder"
        TextBoxModFolder.ReadOnly = True
        TextBoxModFolder.Size = New Size(324, 23)
        TextBoxModFolder.TabIndex = 6
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(CheckBoxIncludeMods)
        GroupBox1.Controls.Add(ProgressBarCache)
        GroupBox1.Controls.Add(ButtonClearCache)
        GroupBox1.Controls.Add(ButtonLoadCache)
        GroupBox1.Controls.Add(ButtonProcess)
        GroupBox1.Controls.Add(ProgressBarPacks)
        GroupBox1.Controls.Add(ProgressBarFiles)
        GroupBox1.Location = New Point(12, 100)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(513, 183)
        GroupBox1.TabIndex = 7
        GroupBox1.TabStop = False
        ' 
        ' CheckBoxIncludeMods
        ' 
        CheckBoxIncludeMods.AutoSize = True
        CheckBoxIncludeMods.Location = New Point(7, 118)
        CheckBoxIncludeMods.Name = "CheckBoxIncludeMods"
        CheckBoxIncludeMods.Size = New Size(132, 19)
        CheckBoxIncludeMods.TabIndex = 17
        CheckBoxIncludeMods.Text = "Include active mods"
        CheckBoxIncludeMods.UseVisualStyleBackColor = True
        ' 
        ' ProgressBarCache
        ' 
        ProgressBarCache.Location = New Point(6, 60)
        ProgressBarCache.Name = "ProgressBarCache"
        ProgressBarCache.Size = New Size(497, 11)
        ProgressBarCache.TabIndex = 16
        ' 
        ' ButtonClearCache
        ' 
        ButtonClearCache.Enabled = False
        ButtonClearCache.Location = New Point(285, 19)
        ButtonClearCache.Name = "ButtonClearCache"
        ButtonClearCache.Size = New Size(222, 35)
        ButtonClearCache.TabIndex = 6
        ButtonClearCache.Text = "Clear Cache"
        ButtonClearCache.UseVisualStyleBackColor = True
        ' 
        ' ButtonLoadCache
        ' 
        ButtonLoadCache.Enabled = False
        ButtonLoadCache.Location = New Point(6, 19)
        ButtonLoadCache.Name = "ButtonLoadCache"
        ButtonLoadCache.Size = New Size(222, 35)
        ButtonLoadCache.TabIndex = 5
        ButtonLoadCache.Text = "Load Cache"
        ButtonLoadCache.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.ImageAlign = ContentAlignment.MiddleRight
        Label1.Location = New Point(12, 12)
        Label1.Name = "Label1"
        Label1.Size = New Size(139, 23)
        Label1.TabIndex = 8
        Label1.Text = "Game bin folder"
        Label1.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label2
        ' 
        Label2.ImageAlign = ContentAlignment.MiddleRight
        Label2.Location = New Point(12, 43)
        Label2.Name = "Label2"
        Label2.Size = New Size(139, 23)
        Label2.TabIndex = 9
        Label2.Text = "Game mod folder"
        Label2.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(487, 11)
        Button2.Name = "Button2"
        Button2.Size = New Size(38, 23)
        Button2.TabIndex = 10
        Button2.Text = "..."
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(487, 43)
        Button3.Name = "Button3"
        Button3.Size = New Size(38, 23)
        Button3.TabIndex = 11
        Button3.Text = "..."
        Button3.UseVisualStyleBackColor = True
        ' 
        ' TreeViewPacks
        ' 
        TreeViewPacks.Location = New Point(12, 289)
        TreeViewPacks.Name = "TreeViewPacks"
        TreeViewPacks.Size = New Size(513, 257)
        TreeViewPacks.TabIndex = 14
        ' 
        ' Label3
        ' 
        Label3.ImageAlign = ContentAlignment.MiddleRight
        Label3.Location = New Point(12, 74)
        Label3.Name = "Label3"
        Label3.Size = New Size(139, 23)
        Label3.TabIndex = 15
        Label3.Text = "UTAM mod folder"
        Label3.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' TextBoxUTAMModFolder
        ' 
        TextBoxUTAMModFolder.Location = New Point(157, 74)
        TextBoxUTAMModFolder.Name = "TextBoxUTAMModFolder"
        TextBoxUTAMModFolder.ReadOnly = True
        TextBoxUTAMModFolder.Size = New Size(324, 23)
        TextBoxUTAMModFolder.TabIndex = 16
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(487, 74)
        Button1.Name = "Button1"
        Button1.Size = New Size(38, 23)
        Button1.TabIndex = 17
        Button1.Text = "..."
        Button1.UseVisualStyleBackColor = True
        ' 
        ' ProcesarPaks
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(537, 559)
        Controls.Add(Button1)
        Controls.Add(TextBoxUTAMModFolder)
        Controls.Add(Label3)
        Controls.Add(TreeViewPacks)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(GroupBox1)
        Controls.Add(TextBoxModFolder)
        Controls.Add(TextBoxGameFolder)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        MaximizeBox = False
        MinimizeBox = False
        Name = "ProcesarPaks"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Process game and packs files"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents ProgressBarPacks As ProgressBar
    Friend WithEvents ProgressBarFiles As ProgressBar
    Friend WithEvents ButtonProcess As Button
    Friend WithEvents TextBoxGameFolder As TextBox
    Friend WithEvents TextBoxModFolder As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents ButtonClearCache As Button
    Friend WithEvents ButtonLoadCache As Button
    Friend WithEvents ProgressBarCache As ProgressBar
    Friend WithEvents CheckBoxIncludeMods As CheckBox
    Friend WithEvents TreeViewPacks As TreeView
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBoxUTAMModFolder As TextBox
    Friend WithEvents Button1 As Button

End Class
