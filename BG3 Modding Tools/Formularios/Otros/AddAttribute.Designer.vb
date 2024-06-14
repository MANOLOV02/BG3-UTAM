<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AddAttribute
    Inherits System.Windows.Forms.Form

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
        TableLayoutPanel1 = New TableLayoutPanel()
        TextBox1 = New TextBox()
        OK_Button = New Button()
        Cancel_Button = New Button()
        ComboBox1 = New ComboBox()
        TableLayoutPanel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 3
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 60F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 60F))
        TableLayoutPanel1.Controls.Add(TextBox1, 0, 0)
        TableLayoutPanel1.Controls.Add(OK_Button, 1, 1)
        TableLayoutPanel1.Controls.Add(Cancel_Button, 2, 1)
        TableLayoutPanel1.Controls.Add(ComboBox1, 0, 1)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Margin = New Padding(4, 3, 4, 3)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 2
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 25F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 25F))
        TableLayoutPanel1.Size = New Size(360, 54)
        TableLayoutPanel1.TabIndex = 0
        ' 
        ' TextBox1
        ' 
        TableLayoutPanel1.SetColumnSpan(TextBox1, 3)
        TextBox1.Dock = DockStyle.Fill
        TextBox1.Location = New Point(3, 3)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(354, 23)
        TextBox1.TabIndex = 0
        ' 
        ' OK_Button
        ' 
        OK_Button.Dock = DockStyle.Fill
        OK_Button.Location = New Point(240, 25)
        OK_Button.Margin = New Padding(0)
        OK_Button.Name = "OK_Button"
        OK_Button.Size = New Size(60, 29)
        OK_Button.TabIndex = 1
        OK_Button.Text = "Accept"
        ' 
        ' Cancel_Button
        ' 
        Cancel_Button.Dock = DockStyle.Fill
        Cancel_Button.Location = New Point(300, 25)
        Cancel_Button.Margin = New Padding(0)
        Cancel_Button.Name = "Cancel_Button"
        Cancel_Button.Size = New Size(60, 29)
        Cancel_Button.TabIndex = 2
        Cancel_Button.Text = "Cancel"
        ' 
        ' ComboBox1
        ' 
        ComboBox1.Dock = DockStyle.Fill
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(3, 28)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(234, 23)
        ComboBox1.TabIndex = 3
        ' 
        ' AddAttribute
        ' 
        AcceptButton = OK_Button
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        CancelButton = Cancel_Button
        ClientSize = New Size(360, 54)
        Controls.Add(TableLayoutPanel1)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Margin = New Padding(4, 3, 4, 3)
        MaximizeBox = False
        MinimizeBox = False
        Name = "AddAttribute"
        ShowInTaskbar = False
        StartPosition = FormStartPosition.Manual
        Text = "Add attribute"
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents ComboBox1 As ComboBox

End Class
