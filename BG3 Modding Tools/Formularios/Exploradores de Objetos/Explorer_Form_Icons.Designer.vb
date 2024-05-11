<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Explorer_Form_Icons
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
        ObjectsTree = New BG3Explorer_Icons()
        PictureBox1 = New PictureBox()
        PictureBox2 = New PictureBox()
        Label4 = New Label()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        TableLayoutPanel1 = New TableLayoutPanel()
        TableLayoutPanel2 = New TableLayoutPanel()
        TableLayoutPanel3 = New TableLayoutPanel()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        TableLayoutPanel1.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        TableLayoutPanel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' ObjectsTree
        ' 
        TableLayoutPanel1.SetColumnSpan(ObjectsTree, 2)
        ObjectsTree.DetailsVisibles = True
        ObjectsTree.Dock = DockStyle.Fill
        ObjectsTree.Location = New Point(3, 3)
        ObjectsTree.Name = "ObjectsTree"
        ObjectsTree.ObjectList = Nothing
        ObjectsTree.Size = New Size(418, 554)
        ObjectsTree.SourceFilter = Nothing
        ObjectsTree.TabIndex = 0
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BorderStyle = BorderStyle.FixedSingle
        PictureBox1.Dock = DockStyle.Fill
        PictureBox1.Location = New Point(0, 0)
        PictureBox1.Margin = New Padding(0)
        PictureBox1.Name = "PictureBox1"
        TableLayoutPanel2.SetRowSpan(PictureBox1, 2)
        PictureBox1.Size = New Size(64, 64)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BorderStyle = BorderStyle.FixedSingle
        PictureBox2.Dock = DockStyle.Fill
        PictureBox2.Location = New Point(0, 0)
        PictureBox2.Margin = New Padding(0)
        PictureBox2.Name = "PictureBox2"
        TableLayoutPanel3.SetRowSpan(PictureBox2, 2)
        PictureBox2.Size = New Size(64, 64)
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.TabIndex = 1
        PictureBox2.TabStop = False
        ' 
        ' Label4
        ' 
        Label4.Dock = DockStyle.Fill
        Label4.Location = New Point(67, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(136, 20)
        Label4.TabIndex = 5
        Label4.Text = "None"
        ' 
        ' Label1
        ' 
        Label1.AutoEllipsis = True
        Label1.Dock = DockStyle.Fill
        Label1.Location = New Point(67, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(136, 20)
        Label1.TabIndex = 2
        Label1.Text = "Atlas"
        ' 
        ' Label2
        ' 
        Label2.Dock = DockStyle.Fill
        Label2.Location = New Point(67, 20)
        Label2.Name = "Label2"
        Label2.Size = New Size(136, 44)
        Label2.TabIndex = 3
        Label2.Text = "Archive"
        ' 
        ' Label3
        ' 
        Label3.Dock = DockStyle.Fill
        Label3.Location = New Point(67, 20)
        Label3.Name = "Label3"
        Label3.Size = New Size(136, 44)
        Label3.TabIndex = 4
        Label3.Text = "None"
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Controls.Add(ObjectsTree, 0, 0)
        TableLayoutPanel1.Controls.Add(TableLayoutPanel2, 0, 1)
        TableLayoutPanel1.Controls.Add(TableLayoutPanel3, 1, 1)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 3
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 64F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 4F))
        TableLayoutPanel1.Size = New Size(424, 628)
        TableLayoutPanel1.TabIndex = 3
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.ColumnCount = 2
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 64F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.Controls.Add(PictureBox1, 0, 0)
        TableLayoutPanel2.Controls.Add(Label1, 1, 0)
        TableLayoutPanel2.Controls.Add(Label3, 1, 1)
        TableLayoutPanel2.Dock = DockStyle.Fill
        TableLayoutPanel2.Location = New Point(3, 560)
        TableLayoutPanel2.Margin = New Padding(3, 0, 3, 0)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 2
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Absolute, 44F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel2.Size = New Size(206, 64)
        TableLayoutPanel2.TabIndex = 5
        ' 
        ' TableLayoutPanel3
        ' 
        TableLayoutPanel3.ColumnCount = 2
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 64F))
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel3.Controls.Add(Label4, 1, 0)
        TableLayoutPanel3.Controls.Add(Label2, 1, 1)
        TableLayoutPanel3.Controls.Add(PictureBox2, 0, 0)
        TableLayoutPanel3.Dock = DockStyle.Fill
        TableLayoutPanel3.Location = New Point(215, 560)
        TableLayoutPanel3.Margin = New Padding(3, 0, 3, 0)
        TableLayoutPanel3.Name = "TableLayoutPanel3"
        TableLayoutPanel3.RowCount = 2
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Absolute, 42F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel3.Size = New Size(206, 64)
        TableLayoutPanel3.TabIndex = 4
        ' 
        ' Explorer_Form_Icons
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(424, 628)
        Controls.Add(TableLayoutPanel1)
        Name = "Explorer_Form_Icons"
        Text = "ExploraIcons"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel2.ResumeLayout(False)
        TableLayoutPanel3.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents ObjectsTree As BG3Explorer_Icons
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel

End Class
