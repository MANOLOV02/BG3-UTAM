<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class BG3Editor_Complex_StatusList
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        ListBox1 = New ListBox()
        Label1 = New Label()
        TableLayoutPanel1 = New TableLayoutPanel()
        TableLayoutPanel2 = New TableLayoutPanel()
        Button1 = New Button()
        ListBox2 = New ListBox()
        Label2 = New Label()
        TableLayoutPanel1.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' ListBox1
        ' 
        ListBox1.Dock = DockStyle.Fill
        ListBox1.Enabled = False
        ListBox1.FormattingEnabled = True
        ListBox1.ItemHeight = 15
        ListBox1.Location = New Point(3, 19)
        ListBox1.Name = "ListBox1"
        ListBox1.Size = New Size(355, 515)
        ListBox1.Sorted = True
        ListBox1.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoEllipsis = True
        Label1.Dock = DockStyle.Fill
        Label1.Location = New Point(3, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(355, 16)
        Label1.TabIndex = 1
        Label1.Text = "Inherited status"
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0F))
        TableLayoutPanel1.Controls.Add(TableLayoutPanel2, 1, 1)
        TableLayoutPanel1.Controls.Add(Label2, 1, 0)
        TableLayoutPanel1.Controls.Add(Label1, 0, 0)
        TableLayoutPanel1.Controls.Add(ListBox1, 0, 1)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 2
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 16.0F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
        TableLayoutPanel1.Size = New Size(722, 537)
        TableLayoutPanel1.TabIndex = 2
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.ColumnCount = 1
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F))
        TableLayoutPanel2.Controls.Add(Button1, 0, 1)
        TableLayoutPanel2.Controls.Add(ListBox2, 0, 0)
        TableLayoutPanel2.Dock = DockStyle.Fill
        TableLayoutPanel2.Location = New Point(364, 19)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 2
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Absolute, 30.0F))
        TableLayoutPanel2.Size = New Size(355, 515)
        TableLayoutPanel2.TabIndex = 3
        ' 
        ' Button1
        ' 
        Button1.Dock = DockStyle.Fill
        Button1.Enabled = False
        Button1.Location = New Point(3, 488)
        Button1.Name = "Button1"
        Button1.Size = New Size(349, 24)
        Button1.TabIndex = 0
        Button1.Text = "Delete"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' ListBox2
        ' 
        ListBox2.AllowDrop = True
        ListBox2.Dock = DockStyle.Fill
        ListBox2.FormattingEnabled = True
        ListBox2.ItemHeight = 15
        ListBox2.Location = New Point(3, 3)
        ListBox2.Name = "ListBox2"
        ListBox2.Size = New Size(349, 479)
        ListBox2.Sorted = True
        ListBox2.TabIndex = 4
        ' 
        ' Label2
        ' 
        Label2.AutoEllipsis = True
        Label2.Location = New Point(364, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(262, 16)
        Label2.TabIndex = 3
        Label2.Text = "Template status (drop to replace)"
        ' 
        ' BG3Editor_Complex_StatusList
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(TableLayoutPanel1)
        Name = "BG3Editor_Complex_StatusList"
        Size = New Size(722, 537)
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel2.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label2 As Label
    Friend WithEvents ListBox2 As ListBox
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Button1 As Button

End Class
