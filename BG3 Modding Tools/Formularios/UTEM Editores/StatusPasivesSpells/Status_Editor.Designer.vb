<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Status_Editor
    Inherits Status_Generic_editor

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
        TabPage1.SuspendLayout()
        GroupBox9.SuspendLayout()
        TabControl1.SuspendLayout()
        GroupBoxBasicStats.SuspendLayout()
        TabPage2.SuspendLayout()
        GroupBox7.SuspendLayout()
        GroupBox3.SuspendLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' BG3Editor_Stat_Name1
        ' 
        BG3Editor_Stat_Name1.EditorType = BG3_Editor_Type.Textbox
        ' 
        ' BG3Editor_Stat_Using1
        ' 
        BG3Editor_Stat_Using1.EditorType = BG3_Editor_Type.Textbox
        ' 
        ' GroupBox3
        ' 
        GroupBox3.Size = New Size(763, 87)
        ' 
        ' LabelTechnical
        ' 
        LabelTechnical.Size = New Size(681, 15)
        ' 
        ' LabelInfoDescription
        ' 
        LabelInfoDescription.Size = New Size(681, 15)
        ' 
        ' LabelInfoName
        ' 
        LabelInfoName.Size = New Size(681, 15)
        ' 
        ' Status_Editor
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1169, 596)
        Name = "Status_Editor"
        TabPage1.ResumeLayout(False)
        GroupBox9.ResumeLayout(False)
        TabControl1.ResumeLayout(False)
        GroupBoxBasicStats.ResumeLayout(False)
        TabPage2.ResumeLayout(False)
        GroupBox7.ResumeLayout(False)
        GroupBox3.ResumeLayout(False)
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub
End Class
