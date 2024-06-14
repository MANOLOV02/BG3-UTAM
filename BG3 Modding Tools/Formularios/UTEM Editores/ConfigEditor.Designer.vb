<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Config_Editor
    Inherits ExploraForm_code

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
        BG3Editor_Complex_Advanced_Stats1 = New BG3Editor_Complex_Advanced_Stats()
        TableLayoutPanel1 = New TableLayoutPanel()
        GroupBoxBotones = New GroupBox()
        TableLayoutPanel2 = New TableLayoutPanel()
        Button1 = New Button()
        Button2 = New Button()
        Button3 = New Button()
        Button4 = New Button()
        TableLayoutPanel1.SuspendLayout()
        GroupBoxBotones.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' BG3Editor_Complex_Advanced_Stats1
        ' 
        BG3Editor_Complex_Advanced_Stats1.Dock = DockStyle.Fill
        BG3Editor_Complex_Advanced_Stats1.Location = New Point(3, 3)
        BG3Editor_Complex_Advanced_Stats1.Name = "BG3Editor_Complex_Advanced_Stats1"
        BG3Editor_Complex_Advanced_Stats1.ReadOnly = True
        BG3Editor_Complex_Advanced_Stats1.Size = New Size(728, 515)
        BG3Editor_Complex_Advanced_Stats1.TabIndex = 0
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 1
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F))
        TableLayoutPanel1.Controls.Add(BG3Editor_Complex_Advanced_Stats1, 0, 0)
        TableLayoutPanel1.Controls.Add(GroupBoxBotones, 0, 1)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 2
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 60.0F))
        TableLayoutPanel1.Size = New Size(734, 581)
        TableLayoutPanel1.TabIndex = 1
        ' 
        ' GroupBoxBotones
        ' 
        GroupBoxBotones.Controls.Add(TableLayoutPanel2)
        GroupBoxBotones.Dock = DockStyle.Fill
        GroupBoxBotones.Location = New Point(3, 524)
        GroupBoxBotones.Name = "GroupBoxBotones"
        GroupBoxBotones.Size = New Size(728, 54)
        GroupBoxBotones.TabIndex = 1
        GroupBoxBotones.TabStop = False
        GroupBoxBotones.Text = "Actions"
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.ColumnCount = 4
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0F))
        TableLayoutPanel2.Controls.Add(Button1, 0, 0)
        TableLayoutPanel2.Controls.Add(Button2, 1, 0)
        TableLayoutPanel2.Controls.Add(Button3, 2, 0)
        TableLayoutPanel2.Controls.Add(Button4, 3, 0)
        TableLayoutPanel2.Dock = DockStyle.Top
        TableLayoutPanel2.Location = New Point(3, 19)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 1
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
        TableLayoutPanel2.Size = New Size(722, 30)
        TableLayoutPanel2.TabIndex = 0
        ' 
        ' Button1
        ' 
        Button1.Dock = DockStyle.Fill
        Button1.Location = New Point(3, 3)
        Button1.Name = "Button1"
        Button1.Size = New Size(174, 24)
        Button1.TabIndex = 0
        Button1.Text = "Begin edit"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Dock = DockStyle.Fill
        Button2.Location = New Point(183, 3)
        Button2.Name = "Button2"
        Button2.Size = New Size(174, 24)
        Button2.TabIndex = 1
        Button2.Text = "Clear all"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Dock = DockStyle.Fill
        Button3.Location = New Point(363, 3)
        Button3.Name = "Button3"
        Button3.Size = New Size(174, 24)
        Button3.TabIndex = 2
        Button3.Text = "Save"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button4
        ' 
        Button4.Dock = DockStyle.Fill
        Button4.Location = New Point(543, 3)
        Button4.Name = "Button4"
        Button4.Size = New Size(176, 24)
        Button4.TabIndex = 3
        Button4.Text = "Cancel"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' Config_Editor
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(734, 581)
        Controls.Add(TableLayoutPanel1)
        MinimumSize = New Size(0, 0)
        Name = "Config_Editor"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Configuration editor"
        TableLayoutPanel1.ResumeLayout(False)
        GroupBoxBotones.ResumeLayout(False)
        TableLayoutPanel2.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents BG3Editor_Complex_Advanced_Stats1 As BG3Editor_Complex_Advanced_Stats
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents GroupBoxBotones As GroupBox
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
End Class
