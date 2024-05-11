<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BG3Editor_Complex_Advanced_Stats
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        BG3Editor_Stats_Undefined1 = New BG3Editor_Stats_Undefined()
        ListView1 = New ListView()
        ColumnHeader1 = New ColumnHeader()
        ColumnHeader2 = New ColumnHeader()
        ColumnHeader3 = New ColumnHeader()
        TableLayoutPanel1 = New TableLayoutPanel()
        TableLayoutPanel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' BG3Editor_Stats_Undefined1
        ' 
        BG3Editor_Stats_Undefined1.Dock = DockStyle.Fill
        BG3Editor_Stats_Undefined1.Key = "Undefined"
        BG3Editor_Stats_Undefined1.Label = "Select"
        BG3Editor_Stats_Undefined1.Location = New Point(3, 410)
        BG3Editor_Stats_Undefined1.Margin = New Padding(3, 0, 3, 0)
        BG3Editor_Stats_Undefined1.MaximumSize = New Size(3000, 23)
        BG3Editor_Stats_Undefined1.MinimumSize = New Size(100, 23)
        BG3Editor_Stats_Undefined1.Name = "BG3Editor_Stats_Undefined1"
        BG3Editor_Stats_Undefined1.Size = New Size(418, 23)
        BG3Editor_Stats_Undefined1.SplitterDistance = 160
        BG3Editor_Stats_Undefined1.TabIndex = 1
        ' 
        ' ListView1
        ' 
        ListView1.Columns.AddRange(New ColumnHeader() {ColumnHeader1, ColumnHeader2, ColumnHeader3})
        ListView1.Dock = DockStyle.Fill
        ListView1.FullRowSelect = True
        ListView1.Location = New Point(3, 3)
        ListView1.MultiSelect = False
        ListView1.Name = "ListView1"
        ListView1.Size = New Size(418, 404)
        ListView1.TabIndex = 2
        ListView1.UseCompatibleStateImageBehavior = False
        ListView1.View = View.Details
        ' 
        ' ColumnHeader1
        ' 
        ColumnHeader1.Text = "Stat"
        ColumnHeader1.Width = 34
        ' 
        ' ColumnHeader2
        ' 
        ColumnHeader2.Text = "Type"
        ColumnHeader2.Width = 37
        ' 
        ' ColumnHeader3
        ' 
        ColumnHeader3.Text = "Value"
        ColumnHeader3.Width = 325
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 1
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Controls.Add(BG3Editor_Stats_Undefined1, 0, 1)
        TableLayoutPanel1.Controls.Add(ListView1, 0, 0)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 2
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 24F))
        TableLayoutPanel1.Size = New Size(424, 434)
        TableLayoutPanel1.TabIndex = 3
        ' 
        ' BG3Editor_Complex_Advanced_Stats
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(TableLayoutPanel1)
        Name = "BG3Editor_Complex_Advanced_Stats"
        Size = New Size(424, 434)
        TableLayoutPanel1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Friend WithEvents BG3Editor_Stats_Undefined1 As BG3Editor_Stats_Undefined
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel

End Class
