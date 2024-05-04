<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BG3Visualizer_XML
    Inherits System.Windows.Forms.RichTextBox

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
        components = New ComponentModel.Container()
        XMLRichContext = New ContextMenuStrip(components)
        CopySelected = New ToolStripMenuItem()
        CopyAll = New ToolStripMenuItem()
        Formatted = New ToolStripMenuItem()
        Indented = New ToolStripMenuItem()
        XMLRichContext.SuspendLayout()
        SuspendLayout()
        ' 
        ' XMLRichContext
        ' 
        XMLRichContext.Items.AddRange(New ToolStripItem() {CopySelected, CopyAll, Formatted, Indented})
        XMLRichContext.Name = "ContextMenuStrip1"
        XMLRichContext.Size = New Size(149, 92)
        XMLRichContext.Text = "Copy"
        ' 
        ' CopySelected
        ' 
        CopySelected.Name = "CopySelected"
        CopySelected.Size = New Size(148, 22)
        CopySelected.Text = "Copy selected"
        ' 
        ' CopyAll
        ' 
        CopyAll.Name = "CopyAll"
        CopyAll.Size = New Size(148, 22)
        CopyAll.Text = "Copy all"
        ' 
        ' Formatted
        ' 
        Formatted.Checked = True
        Formatted.CheckOnClick = True
        Formatted.CheckState = CheckState.Checked
        Formatted.Name = "Formatted"
        Formatted.Size = New Size(148, 22)
        Formatted.Text = "Colored"
        ' 
        ' Indented
        ' 
        Indented.Checked = True
        Indented.CheckOnClick = True
        Indented.CheckState = CheckState.Checked
        Indented.Name = "Indented"
        Indented.Size = New Size(148, 22)
        Indented.Text = "Indented"
        ' 
        ' XMLtoRichText
        ' 
        Size = New Size(648, 637)
        XMLRichContext.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents XMLRichContext As ContextMenuStrip
    Friend WithEvents CopyAll As ToolStripMenuItem
    Friend WithEvents Formatted As ToolStripMenuItem
    Friend WithEvents CopySelected As ToolStripMenuItem
    Friend WithEvents Indented As ToolStripMenuItem

End Class
