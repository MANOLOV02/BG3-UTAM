Imports System.ComponentModel
Imports System.Diagnostics.Eventing
Imports System.IO
Imports LSLib.Granny

Public Class BG3Visualizer_XML
    Inherits RichTextBox

    <DefaultValue(True)>
    Public Property FormattedText As Boolean
        Get
            Return Formatted.Checked
        End Get
        Set(value As Boolean)
            Formatted.Checked = value
        End Set
    End Property

    Public Property IndentedText As Boolean
        Get
            Return Indented.Checked
        End Get
        Set(value As Boolean)
            Indented.Checked = value
        End Set
    End Property
    Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.ReadOnly = True
        Me.WordWrap = False
        Me.ContextMenuStrip = XMLRichContext
        Flickering.EnableDoubleBuffering(Me)
    End Sub
    Public Sub Process_Gameobject(ByRef obj As BG3_Obj_Template_Class)
        Me._text = "Error getting object information"
        If IsNothing(obj) = False Then
            _text = obj.NodeXML
        End If
        Processs_Text()
    End Sub
    Public Sub Process_FlagsandTags(ByRef obj As BG3_Obj_FlagsAndTags_Class)
        Me._text = "Error getting object information"
        If IsNothing(obj) = False Then
            _text = obj.NodeXML
        End If
        Processs_Text()
    End Sub

    Public Sub Process_Visual(ByRef obj As BG3_Obj_VisualBank_Class)
        Me._text = "Error getting object information"
        If IsNothing(obj) = False Then
            _text = obj.NodeXML
        End If
        Processs_Text()
    End Sub
    Public Sub Process_GameObject(Key As String, ByRef Source As BG3_Obj_SortedList_Class(Of BG3_Obj_Template_Class))
        Me._text = "Error getting object information"
        Dim obj As Object = Nothing
        Source.TryGetValue(Key, obj)
        Process_Gameobject(obj)
    End Sub
    Public Sub Process_FlagsandTags(Key As String, ByRef Source As BG3_Obj_SortedList_Class(Of BG3_Obj_FlagsAndTags_Class))
        Me._text = "Error getting object information"
        Dim obj As Object = Nothing
        Source.TryGetValue(Key, obj)
        Process_FlagsandTags(obj)
    End Sub

    Public Sub Process_Metas(ByRef obj As BG3_Obj_Template_Class)
        Me._text = "Error getting meta information"
        Dim modfolder = obj.SourceOfResorce.ModFolder
        If IsNothing(obj) = False Then
            Dim folder = obj.SourceOfResorce.ModFolder
            Dim filtro = FuncionesHelpers.GameEngine.ProcessedModuleList.Where(Function(pf) pf.Folder = folder)
            If filtro.Any Then
                _text = filtro.First.MetaXML
            Else
                Debugger.Break()
            End If
        End If
        Processs_Text()
    End Sub

    Public Sub Process_Metas(Key As String, ByRef Source As BG3_Obj_SortedList_Class(Of BG3_Obj_Template_Class))
        Me._text = "Error getting meta information"
        Dim obj As Object = Nothing
        Source.TryGetValue(Key, obj)
        Process_Metas(obj)
    End Sub
    Public Sub Process_Stat(obj As BG3_Obj_Stats_Class, ByRef source2 As BG3_Obj_SortedList_Class(Of BG3_Obj_Stats_Class))
        Me._text = "Error getting " + Funciones.ManoloSep + " stats"
        If IsNothing(obj) = False Then
            _text = obj.Get_TXT(source2)
        End If
        Processs_Text()
    End Sub
    Public Sub Process_Ttable(obj As BG3_Obj_TreasureTable_Class)
        Me._text = "Error getting " + Funciones.ManoloSep + " stats"
        If IsNothing(obj) = False Then
            _text = obj.Get_txt
        End If
        Processs_Text()
    End Sub
    Public Sub Process_Tags(Str As String)
        Me._text = "Error getting " + Funciones.ManoloSep + " tags"
        If IsNothing(Str) = False Then
            _text = Str
        End If
        Processs_Text()
    End Sub
    Public Sub Process_Attributes(Str As String)
        Me._text = "Error getting " + Funciones.ManoloSep + " attributes"
        If IsNothing(Str) = False Then
            _text = Str
        End If
        Processs_Text()
    End Sub

    Private Sub Processs_Text()
        Me.SuspendLayout()
        If IndentedText = False Then
            If FormattedText = False Then
                MyBase.Text = _text.Replace(vbTab, "").Replace(Funciones.ManoloSep, "")
            Else
                If _text.Contains("<?xml") Then LSXtoRich(_text.Replace(vbTab, "")) Else StattoRich(_text.Replace(vbTab, ""))
            End If
        Else
            If FormattedText = False Then
                MyBase.Text = _text.Replace(Funciones.ManoloSep, "")
            Else
                If _text.Contains("<?xml") Then LSXtoRich(_text) Else StattoRich(_text)
            End If
        End If

        Me.ResumeLayout()
    End Sub

    Public Sub Process_XML(ByRef XML As String)
        Me._text = XML
        Processs_Text()
    End Sub


    Private _text As String = ""
    Public Overrides Property [Text] As String
        Get
            Return _text
        End Get
        Set(value As String)
            _text = value
            Processs_Text()
        End Set
    End Property

    Public Property ValueColor As Color = Color.Blue
    Public Property NamesColor As Color = Color.Brown
    Public Property NodesColor As Color = Color.Black
    Public Property Overridedolor As Color = Color.Gray

    'Private Shared Normal As New Font(SystemFonts.DefaultFont, SystemFonts.DefaultFont.Style)
    'Private Shared Bold As New Font(Normal, FontStyle.Bold)
    Private Sub LSXtoRich(ByVal XMLString As String)
        MyBase.Text = ""
        Me.SuspendLayout()
        If XMLString = "" Then Exit Sub
        Try
            Dim reader As Xml.XmlReader = Xml.XmlReader.Create(New StringReader(XMLString), New Xml.XmlReaderSettings)
            Dim tabs As Integer = 0
            While reader.Read

                Select Case reader.NodeType
                    Case Xml.XmlNodeType.XmlDeclaration
                        MyBase.SelectionColor = Overridedolor
                        MyBase.AppendText("<?xml ")
                        MyBase.AppendText(reader.Value)
                        MyBase.AppendText("?>" + vbCrLf)
                    Case Xml.XmlNodeType.Element
                        MyBase.AppendText("".PadLeft(tabs, vbTab))
                        If IndentedText = True Then tabs += 1
                        'The node is an element.
                        MyBase.SelectionColor = NodesColor
                        MyBase.AppendText("<")
                        If reader.Name = "children" Then MyBase.SelectionColor = NamesColor
                        MyBase.AppendText(reader.Name)
                        If reader.IsEmptyElement = True Then
                            While reader.MoveToNextAttribute
                                MyBase.SelectionColor = NamesColor
                                MyBase.AppendText(" " + reader.Name)
                                MyBase.SelectionColor = NodesColor
                                MyBase.AppendText("=" + Chr(34))
                                'RichTextBox.SelectionFont = Bold
                                MyBase.SelectionColor = ValueColor
                                MyBase.AppendText(reader.Value)
                                'RichTextBox.SelectionFont = Normal
                                MyBase.SelectionColor = Color.Blue
                                MyBase.AppendText(Chr(34))
                            End While
                            MyBase.SelectionColor = NodesColor
                            MyBase.AppendText(" />" + vbCrLf)
                            If IndentedText = True Then tabs += -1
                        Else
                            While reader.MoveToNextAttribute
                                MyBase.SelectionColor = NamesColor
                                MyBase.AppendText(" " + reader.Name)
                                MyBase.SelectionColor = NodesColor
                                MyBase.AppendText("=" + Chr(34))
                                MyBase.SelectionColor = ValueColor
                                MyBase.AppendText(reader.Value)
                                MyBase.SelectionColor = Color.Blue
                                MyBase.AppendText(Chr(34))
                            End While
                            MyBase.SelectionColor = NodesColor
                            MyBase.AppendText(">" + vbCrLf)
                        End If
                        Exit Select
                    Case Xml.XmlNodeType.Text
                        'Display the text in each element.
                        MyBase.SelectionColor = ValueColor
                        MyBase.AppendText(reader.Value)
                        Exit Select
                    Case Xml.XmlNodeType.EndElement
                        'Display the end of the element.
                        If IndentedText = True Then tabs += -1
                        MyBase.AppendText("".PadLeft(tabs, vbTab))
                        MyBase.SelectionColor = NodesColor
                        MyBase.AppendText("</")
                        MyBase.SelectionColor = NodesColor
                        If reader.Name = "children" Then MyBase.SelectionColor = NamesColor
                        MyBase.AppendText(reader.Name)
                        MyBase.SelectionColor = NodesColor
                        MyBase.AppendText(">")
                        MyBase.AppendText(vbLf)
                        Exit Select
                    Case Xml.XmlNodeType.Whitespace

                    Case Xml.XmlNodeType.XmlDeclaration

                    Case Else
                        Debugger.Break()
                End Select
            End While
            reader.Close()

        Catch ex As Exception
            MyBase.Text = "Error formating XML"
        End Try
        Me.ResumeLayout()
    End Sub
    Private Sub StattoRich(ByVal XMLString As String)
        MyBase.Text = ""
        Me.SuspendLayout()
        If XMLString = "" Then Exit Sub
        Try
            Dim lins = XMLString.Split(vbCrLf)
            Dim overrided As Boolean
            For Each lin In lins
                Dim parts As String() = lin.Split(Funciones.ManoloSep)
                overrided = False
                For x = 0 To parts.Length - 1
                    Select Case x
                        Case 0
                            If parts(x).Contains("(Overrided) data") Or parts(x).Contains("(Overrided) Attribu") Then
                                overrided = True
                                parts(x) = parts(x).Replace("(Overrided) ", "")
                            End If
                            MyBase.SelectionColor = NodesColor
                            If overrided Then MyBase.SelectionColor = Overridedolor
                            MyBase.AppendText("" + parts(x))
                        Case 1
                            MyBase.SelectionColor = NamesColor
                            If overrided Then MyBase.SelectionColor = Overridedolor
                            MyBase.AppendText("" + parts(x))
                        Case 2
                            MyBase.SelectionColor = ValueColor
                            If overrided Then MyBase.SelectionColor = Overridedolor
                            MyBase.AppendText("" + parts(x))
                        Case 3
                            MyBase.SelectionColor = NodesColor
                            If overrided Then MyBase.SelectionColor = Overridedolor
                            MyBase.AppendText("" + parts(x))
                        Case Else
                            Debugger.Break()
                    End Select
                Next
                MyBase.AppendText(vbCrLf)
            Next

        Catch ex As Exception
            MyBase.Text = "Error formating XML"
        End Try
        Me.ResumeLayout()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CopyAll.Click
        Clipboard.SetText(Me.Text.Replace(Funciones.ManoloSep, ""))
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles Formatted.Click
        Processs_Text()
    End Sub
    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles Indented.Click
        Processs_Text()
    End Sub

    Private Sub XMLRichContext_Opening(sender As Object, e As CancelEventArgs) Handles XMLRichContext.Opening
        If Me.SelectedText = "" Then CopySelected.Enabled = False Else CopySelected.Enabled = True
    End Sub

    Private Sub CopySelected_Click(sender As Object, e As EventArgs) Handles CopySelected.Click
        Clipboard.SetText(Me.SelectedText.Replace(Funciones.ManoloSep, ""))
    End Sub
End Class
