<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    Friend WithEvents lblTitle As Label
    Friend WithEvents lblFolder As Label
    Friend WithEvents txtSelectedFolder As TextBox
    Friend WithEvents btnBrowseFolder As Button
    Friend WithEvents lblZip As Label
    Friend WithEvents pnlZipDrop As Panel
    Friend WithEvents lblZipDrop As Label
    Friend WithEvents lblSourceMaterial As Label
    Friend WithEvents txtSourceMaterial As TextBox
    Friend WithEvents lblTargetMaterial As Label
    Friend WithEvents txtTargetMaterial As TextBox
    Friend WithEvents lblTargetFolderCaption As Label
    Friend WithEvents lblTargetFolderValue As Label
    Friend WithEvents lblValidation As Label
    Friend WithEvents btnGenerate As Button
    Friend WithEvents lblMode As Label
    Friend WithEvents cmbMode As ComboBox
    Friend WithEvents lblProcessType As Label
    Friend WithEvents lblLog As Label
    Friend WithEvents txtLog As TextBox

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        lblTitle = New Label()
        lblFolder = New Label()
        txtSelectedFolder = New TextBox()
        btnBrowseFolder = New Button()
        lblZip = New Label()
        pnlZipDrop = New Panel()
        lblZipDrop = New Label()
        lblSourceMaterial = New Label()
        txtSourceMaterial = New TextBox()
        lblTargetMaterial = New Label()
        txtTargetMaterial = New TextBox()
        lblTargetFolderCaption = New Label()
        lblTargetFolderValue = New Label()
        lblValidation = New Label()
        btnGenerate = New Button()
        lblMode = New Label()
        cmbMode = New ComboBox()
        lblProcessType = New Label()
        lblLog = New Label()
        txtLog = New TextBox()
        pnlZipDrop.SuspendLayout()
        SuspendLayout()
        '
        'lblTitle
        '
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 16.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitle.Location = New Point(20, 14)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(214, 30)
        lblTitle.TabIndex = 0
        lblTitle.Text = "BG3 Mod Replicator"
        '
        'lblFolder
        '
        lblFolder.AutoSize = True
        lblFolder.Location = New Point(20, 62)
        lblFolder.Name = "lblFolder"
        lblFolder.Size = New Size(167, 15)
        lblFolder.TabIndex = 1
        lblFolder.Text = "1) Carpeta del mod de origen"
        '
        'txtSelectedFolder
        '
        txtSelectedFolder.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtSelectedFolder.Location = New Point(20, 82)
        txtSelectedFolder.Name = "txtSelectedFolder"
        txtSelectedFolder.ReadOnly = True
        txtSelectedFolder.Size = New Size(640, 23)
        txtSelectedFolder.TabIndex = 2
        '
        'btnBrowseFolder
        '
        btnBrowseFolder.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnBrowseFolder.Location = New Point(670, 81)
        btnBrowseFolder.Name = "btnBrowseFolder"
        btnBrowseFolder.Size = New Size(120, 25)
        btnBrowseFolder.TabIndex = 3
        btnBrowseFolder.Text = "Elegir carpeta"
        btnBrowseFolder.UseVisualStyleBackColor = True
        '
        'lblZip
        '
        lblZip.AutoSize = True
        lblZip.Location = New Point(20, 122)
        lblZip.Name = "lblZip"
        lblZip.Size = New Size(185, 15)
        lblZip.TabIndex = 4
        lblZip.Text = "2) ZIP del material (drag && drop)"
        '
        'pnlZipDrop
        '
        pnlZipDrop.AllowDrop = True
        pnlZipDrop.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        pnlZipDrop.BorderStyle = BorderStyle.FixedSingle
        pnlZipDrop.Controls.Add(lblZipDrop)
        pnlZipDrop.Location = New Point(20, 142)
        pnlZipDrop.Name = "pnlZipDrop"
        pnlZipDrop.Size = New Size(770, 90)
        pnlZipDrop.TabIndex = 5
        '
        'lblZipDrop
        '
        lblZipDrop.Dock = DockStyle.Fill
        lblZipDrop.Location = New Point(0, 0)
        lblZipDrop.Name = "lblZipDrop"
        lblZipDrop.Size = New Size(768, 88)
        lblZipDrop.TabIndex = 0
        lblZipDrop.Text = "Suelta aqui el ZIP o haz click para elegir"
        lblZipDrop.TextAlign = ContentAlignment.MiddleCenter
        '
        'lblSourceMaterial
        '
        lblSourceMaterial.AutoSize = True
        lblSourceMaterial.Location = New Point(20, 247)
        lblSourceMaterial.Name = "lblSourceMaterial"
        lblSourceMaterial.Size = New Size(197, 15)
        lblSourceMaterial.TabIndex = 6
        lblSourceMaterial.Text = "3) Material original detectado/editable"
        '
        'txtSourceMaterial
        '
        txtSourceMaterial.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtSourceMaterial.Location = New Point(20, 267)
        txtSourceMaterial.Name = "txtSourceMaterial"
        txtSourceMaterial.Size = New Size(770, 23)
        txtSourceMaterial.TabIndex = 7
        '
        'lblTargetMaterial
        '
        lblTargetMaterial.AutoSize = True
        lblTargetMaterial.Location = New Point(20, 302)
        lblTargetMaterial.Name = "lblTargetMaterial"
        lblTargetMaterial.Size = New Size(181, 15)
        lblTargetMaterial.TabIndex = 8
        lblTargetMaterial.Text = "4) Nuevo material (desde el ZIP)"
        '
        'txtTargetMaterial
        '
        txtTargetMaterial.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtTargetMaterial.Location = New Point(20, 322)
        txtTargetMaterial.Name = "txtTargetMaterial"
        txtTargetMaterial.Size = New Size(770, 23)
        txtTargetMaterial.TabIndex = 9
        '
        'lblMode
        '
        lblMode.AutoSize = True
        lblMode.Location = New Point(20, 352)
        lblMode.Name = "lblMode"
        lblMode.Size = New Size(173, 15)
        lblMode.TabIndex = 10
        lblMode.Text = "5) Modo de proceso del material"
        '
        'cmbMode
        '
        cmbMode.DropDownStyle = ComboBoxStyle.DropDownList
        cmbMode.FormattingEnabled = True
        cmbMode.Location = New Point(20, 372)
        cmbMode.Name = "cmbMode"
        cmbMode.Size = New Size(300, 23)
        cmbMode.TabIndex = 11
        '
        'lblProcessType
        '
        lblProcessType.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblProcessType.BorderStyle = BorderStyle.FixedSingle
        lblProcessType.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblProcessType.Location = New Point(332, 372)
        lblProcessType.Name = "lblProcessType"
        lblProcessType.Size = New Size(458, 23)
        lblProcessType.TabIndex = 16
        lblProcessType.Text = "Modo no listo"
        lblProcessType.TextAlign = ContentAlignment.MiddleCenter
        '
        'lblTargetFolderCaption
        '
        lblTargetFolderCaption.AutoSize = True
        lblTargetFolderCaption.Location = New Point(20, 407)
        lblTargetFolderCaption.Name = "lblTargetFolderCaption"
        lblTargetFolderCaption.Size = New Size(152, 15)
        lblTargetFolderCaption.TabIndex = 12
        lblTargetFolderCaption.Text = "Carpeta destino propuesta:"
        '
        'lblTargetFolderValue
        '
        lblTargetFolderValue.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblTargetFolderValue.BorderStyle = BorderStyle.FixedSingle
        lblTargetFolderValue.Location = New Point(20, 427)
        lblTargetFolderValue.Name = "lblTargetFolderValue"
        lblTargetFolderValue.Size = New Size(770, 45)
        lblTargetFolderValue.TabIndex = 13
        lblTargetFolderValue.Text = "-"
        '
        'lblValidation
        '
        lblValidation.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblValidation.ForeColor = Color.FromArgb(CInt(CByte(154)), CInt(CByte(47)), CInt(CByte(26)))
        lblValidation.Location = New Point(20, 486)
        lblValidation.Name = "lblValidation"
        lblValidation.Size = New Size(620, 25)
        lblValidation.TabIndex = 14
        lblValidation.Text = "Selecciona carpeta y ZIP para continuar."
        lblValidation.TextAlign = ContentAlignment.MiddleLeft
        '
        'btnGenerate
        '
        btnGenerate.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnGenerate.Enabled = False
        btnGenerate.Location = New Point(650, 485)
        btnGenerate.Name = "btnGenerate"
        btnGenerate.Size = New Size(140, 27)
        btnGenerate.TabIndex = 15
        btnGenerate.Text = "Generar clon"
        btnGenerate.UseVisualStyleBackColor = True
        '
        'lblLog
        '
        lblLog.AutoSize = True
        lblLog.Location = New Point(20, 521)
        lblLog.Name = "lblLog"
        lblLog.Size = New Size(181, 15)
        lblLog.TabIndex = 17
        lblLog.Text = "Log de proceso (sesion actual)"
        '
        'txtLog
        '
        txtLog.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        txtLog.BackColor = Color.White
        txtLog.Location = New Point(20, 541)
        txtLog.Multiline = True
        txtLog.Name = "txtLog"
        txtLog.ReadOnly = True
        txtLog.ScrollBars = ScrollBars.Vertical
        txtLog.Size = New Size(770, 140)
        txtLog.TabIndex = 18
        txtLog.WordWrap = False
        '
        'Form1
        '
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(814, 700)
        Controls.Add(txtLog)
        Controls.Add(lblLog)
        Controls.Add(lblProcessType)
        Controls.Add(btnGenerate)
        Controls.Add(lblValidation)
        Controls.Add(lblTargetFolderValue)
        Controls.Add(lblTargetFolderCaption)
        Controls.Add(cmbMode)
        Controls.Add(lblMode)
        Controls.Add(txtTargetMaterial)
        Controls.Add(lblTargetMaterial)
        Controls.Add(txtSourceMaterial)
        Controls.Add(lblSourceMaterial)
        Controls.Add(pnlZipDrop)
        Controls.Add(lblZip)
        Controls.Add(btnBrowseFolder)
        Controls.Add(txtSelectedFolder)
        Controls.Add(lblFolder)
        Controls.Add(lblTitle)
        MinimumSize = New Size(830, 739)
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "BG3 Mod Replicator"
        pnlZipDrop.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

End Class
