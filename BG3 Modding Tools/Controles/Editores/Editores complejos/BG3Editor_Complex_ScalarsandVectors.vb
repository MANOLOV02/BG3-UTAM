Imports System.ComponentModel
Imports LSLib.LS.Story

Public Class BG3Editor_Complex_ScalarsandVectors
    Public NameParameter As String = Nothing
    Public _Write_Node As LSLib.LS.Node = Nothing
    Public _LastReadScalar As LSLib.LS.Node = Nothing
    Public _LastReadVector3 As LSLib.LS.Node = Nothing
    Public _LastReadVector4 As LSLib.LS.Node = Nothing
    Private SelectedIdx1 As String = ""
    Private SelectedIdx2 As String = ""
    Private SelectedIdx3 As String = ""

    Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        ListBoxScalars.Sorted = True
        ListBoxVectors3.Sorted = True
        ListBoxVectors4.Sorted = True
    End Sub
    Private _Readonly As Boolean = True

    <DefaultValue(True)>
    Public Property [ReadOnly] As Boolean
        Get
            Return _Readonly
        End Get
        Set(value As Boolean)
            _Readonly = value
            Habilita_deshabilita()
        End Set
    End Property

    Private Sub Habilita_deshabilita()
        If _Readonly = True Then
            GroupBox1.Enabled = False
            GroupBox2.Enabled = False
            GroupBox3.Enabled = False
            Button1.Enabled = False
            Button2.Enabled = False
            Button3.Enabled = False
            Button4.Enabled = False
            Button5.Enabled = False
            Button6.Enabled = False
        Else
            GroupBox1.Enabled = ListBoxScalars.SelectedIndex <> -1
            GroupBox2.Enabled = ListBoxVectors3.SelectedIndex <> -1
            GroupBox3.Enabled = ListBoxVectors4.SelectedIndex <> -1
            Button1.Enabled = True
            Button2.Enabled = ListBoxScalars.SelectedIndex <> -1
            Button3.Enabled = True
            Button4.Enabled = ListBoxVectors3.SelectedIndex <> -1
            PictureBox1.Enabled = ListBoxVectors3.SelectedIndex <> -1
            Button5.Enabled = True
            Button6.Enabled = ListBoxVectors4.SelectedIndex <> -1
            PictureBox2.Enabled = ListBoxVectors4.SelectedIndex <> -1
        End If
    End Sub


    Public Sub InitializeByType(Type As BG3_Enum_VisualBank_Type)
        Select Case Type
            Case BG3_Enum_VisualBank_Type.CharacterVisualBank
                NameParameter = "Parameter"
                BG3Editor_ScalarsandVectors_ParameterScalar1.ComboItems = FuncionesHelpers.Characters_Scalars
                BG3Editor_ScalarsandVectors_ParameterScalar1.SetKey(NameParameter)
                BG3Editor_ScalarsandVectors_ParameterScalar1.Reload_Combo()
                BG3Editor_ScalarsandVectors_BaseValueFloat1.AllowEdit = False
                BG3Editor_ScalarsandVectors_BaseValueFloat1.Enabled = False
                BG3Editor_ScalarsandVectors_ExportAsPreset1.AllowEdit = False
                BG3Editor_ScalarsandVectors_ExportAsPreset1.Enabled = False
                BG3Editor_ScalarsandVectors_ParameterScalar2.ComboItems = FuncionesHelpers.Characters_Vec3
                BG3Editor_ScalarsandVectors_ParameterScalar2.SetKey(NameParameter)
                BG3Editor_ScalarsandVectors_ParameterScalar2.Reload_Combo()
                BG3Editor_ScalarsandVectors_BaseValueVec32.AllowEdit = False
                BG3Editor_ScalarsandVectors_BaseValueVec32.Enabled = False
                BG3Editor_ScalarsandVectors_ExportAsPreset2.AllowEdit = False
                BG3Editor_ScalarsandVectors_ExportAsPreset2.Enabled = False
                BG3Editor_ScalarsandVectors_GroupName2.AllowEdit = False
                BG3Editor_ScalarsandVectors_GroupName2.Enabled = False
                BG3Editor_ScalarsandVectors_ParameterScalar3.ComboItems = FuncionesHelpers.Characters_Vec4
                BG3Editor_ScalarsandVectors_ParameterScalar3.SetKey(NameParameter)
                BG3Editor_ScalarsandVectors_ParameterScalar3.Reload_Combo()
                BG3Editor_ScalarsandVectors_BaseValueVec43.AllowEdit = False
                BG3Editor_ScalarsandVectors_BaseValueVec43.Enabled = False
                BG3Editor_ScalarsandVectors_ExportAsPreset3.AllowEdit = False
                BG3Editor_ScalarsandVectors_ExportAsPreset3.Enabled = False
                BG3Editor_ScalarsandVectors_GroupName3.AllowEdit = False
                BG3Editor_ScalarsandVectors_GroupName3.Enabled = False

            Case BG3_Enum_VisualBank_Type.MaterialBank
                NameParameter = "ParameterName"
                BG3Editor_ScalarsandVectors_ParameterScalar1.ComboItems = FuncionesHelpers.Material_Scalars
                BG3Editor_ScalarsandVectors_ParameterScalar1.SetKey(NameParameter)
                BG3Editor_ScalarsandVectors_ParameterScalar1.Reload_Combo()
                BG3Editor_ScalarsandVectors_Color1.AllowEdit = False
                BG3Editor_ScalarsandVectors_Color1.Enabled = False
                BG3Editor_ScalarsandVectors_Custom1.AllowEdit = False
                BG3Editor_ScalarsandVectors_Custom1.Enabled = False
                BG3Editor_ScalarsandVectors_ParameterScalar2.ComboItems = FuncionesHelpers.Material_Vec3
                BG3Editor_ScalarsandVectors_ParameterScalar2.SetKey(NameParameter)
                BG3Editor_ScalarsandVectors_ParameterScalar2.Reload_Combo()
                BG3Editor_ScalarsandVectors_Color2.SetKey("IsColor")
                BG3Editor_ScalarsandVectors_Custom2.AllowEdit = False
                BG3Editor_ScalarsandVectors_Custom2.Enabled = False
                BG3Editor_ScalarsandVectors_ParameterScalar3.ComboItems = FuncionesHelpers.Material_Vec4
                BG3Editor_ScalarsandVectors_ParameterScalar3.SetKey(NameParameter)
                BG3Editor_ScalarsandVectors_ParameterScalar3.Reload_Combo()
                BG3Editor_ScalarsandVectors_Color3.SetKey("IsColor")
                BG3Editor_ScalarsandVectors_Custom3.AllowEdit = False
                BG3Editor_ScalarsandVectors_Custom3.Enabled = False
            Case Else
                Debugger.Break()
                Throw New Exception
        End Select

    End Sub
    Public Sub Clear()
        SelectedIdx1 = ""
        SelectedIdx2 = ""
        SelectedIdx3 = ""
        If ListBoxScalars.SelectedIndex >= 0 Then SelectedIdx1 = ListBoxScalars.Items(ListBoxScalars.SelectedIndex).text
        If ListBoxVectors3.SelectedIndex >= 0 Then SelectedIdx2 = ListBoxVectors3.Items(ListBoxVectors3.SelectedIndex).text
        If ListBoxVectors4.SelectedIndex >= 0 Then SelectedIdx3 = ListBoxVectors4.Items(ListBoxVectors4.SelectedIndex).text
        ListBoxScalars.Items.Clear()
        ListBoxVectors3.Items.Clear()
        ListBoxVectors4.Items.Clear()
    End Sub
    Public Sub Read_Data(Template As BG3_Obj_VisualBank_Class)
        _Write_Node = Nothing
        ListBoxScalars.BeginUpdate()
        ListBoxVectors3.BeginUpdate()
        ListBoxVectors4.BeginUpdate()
        Clear()

        Select Case Template.Type
            Case BG3_Enum_VisualBank_Type.CharacterVisualBank
                _Write_Node = Create_Or_Select(Template.NodeLSLIB, "MaterialOverrides")
            Case BG3_Enum_VisualBank_Type.MaterialBank
                _Write_Node = Template.NodeLSLIB
            Case Else
                Debugger.Break()
                Throw New Exception
        End Select
        If _Write_Node.Children.ContainsKey("ScalarParameters") Then
            For Each scal In _Write_Node.Children("ScalarParameters")
                Dim att As LSLib.LS.NodeAttribute = Nothing
                If scal.Attributes.TryGetValue(NameParameter, att) Then
                    Dim cust As New BG3_Custom_ComboboxItem With {.Text = att.AsString(Funciones.Guid_to_string), .Value = scal}
                    Dim idx = ListBoxScalars.Items.Add(cust)
                    If cust.Text = SelectedIdx1 Then ListBoxScalars.SelectedItem = cust
                End If

            Next
        End If
        If _Write_Node.Children.ContainsKey("Vector3Parameters") Then
            For Each scal In _Write_Node.Children("Vector3Parameters")
                Dim att As LSLib.LS.NodeAttribute = Nothing
                If scal.Attributes.TryGetValue(NameParameter, att) Then
                    Dim cust As New BG3_Custom_ComboboxItem With {.Text = att.AsString(Funciones.Guid_to_string), .Value = scal}
                    Dim idx = ListBoxVectors3.Items.Add(cust)
                    If cust.Text = SelectedIdx2 Then ListBoxVectors3.SelectedItem = cust
                End If

            Next
        End If

        If _Write_Node.Children.ContainsKey("VectorParameters") Then
            For Each scal In _Write_Node.Children("VectorParameters")
                Dim att As LSLib.LS.NodeAttribute = Nothing
                If scal.Attributes.TryGetValue(NameParameter, att) Then
                    Dim cust As New BG3_Custom_ComboboxItem With {.Text = att.AsString(Funciones.Guid_to_string), .Value = scal}
                    Dim idx = ListBoxVectors4.Items.Add(cust)
                    If cust.Text = SelectedIdx3 Then ListBoxVectors4.SelectedItem = cust
                End If

            Next
        End If
        ListBoxScalars.EndUpdate()
        ListBoxVectors3.EndUpdate()
        ListBoxVectors4.EndUpdate()
        Habilita_deshabilita()
    End Sub

    Private Function Create_Or_Select(BaseNode As LSLib.LS.Node, NodeName As String)
        Dim Selected As LSLib.LS.Node
        If BaseNode.Children.ContainsKey(NodeName) Then
            Selected = BaseNode.Children(NodeName).First
        Else
            Selected = New LSLib.LS.Node With {.Name = NodeName, .Parent = BaseNode}
            BaseNode.AppendChild(Selected)
        End If
        Return Selected
    End Function

    Private Sub ListBoxScalars_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxScalars.SelectedIndexChanged
        Habilita_deshabilita()
        Read_values_Scalars()
    End Sub
    Private Sub ListBoxVectors3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxVectors3.SelectedIndexChanged
        Habilita_deshabilita()
        Read_values_Vectors3()
    End Sub
    Private Sub ListBoxVectors4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxVectors4.SelectedIndexChanged
        Habilita_deshabilita()
        Read_values_Vectors4()
    End Sub
    Private Sub Read_values_Scalars()
        If ListBoxScalars.SelectedIndex <> -1 Then
            _LastReadScalar = ListBoxScalars.Items(ListBoxScalars.SelectedIndex).value
            BG3Editor_ScalarsandVectors_Color1.Read(_LastReadScalar)
            BG3Editor_ScalarsandVectors_ExportAsPreset1.Read(_LastReadScalar)
            BG3Editor_ScalarsandVectors_BaseValueFloat1.Read(_LastReadScalar)
            BG3Editor_ScalarsandVectors_ValueFloat1.Read(_LastReadScalar)
            BG3Editor_ScalarsandVectors_Custom1.Read(_LastReadScalar)
            BG3Editor_ScalarsandVectors_ParameterScalar1.Read(_LastReadScalar)
        Else
            _LastReadScalar = Nothing
            BG3Editor_ScalarsandVectors_Color1.Clear()
            BG3Editor_ScalarsandVectors_ExportAsPreset1.Clear()
            BG3Editor_ScalarsandVectors_BaseValueFloat1.Clear()
            BG3Editor_ScalarsandVectors_ValueFloat1.Clear()
            BG3Editor_ScalarsandVectors_Custom1.Clear()
            BG3Editor_ScalarsandVectors_ParameterScalar1.Clear()
        End If

    End Sub
    Public Shared Sub RefreshItemAt(ByVal listBox As ListBox, ByVal itemIndex As Integer)
        If itemIndex >= 0 Then
            listBox.Items(itemIndex) = listBox.Items(itemIndex)
        End If
    End Sub

    Private Sub Save_values_Scalars()
        If ListBoxScalars.SelectedIndex = -1 Or GroupBox1.Enabled = False Then Exit Sub
        BG3Editor_ScalarsandVectors_Color1.Write(_LastReadScalar)
        BG3Editor_ScalarsandVectors_ExportAsPreset1.Write(_LastReadScalar)
        BG3Editor_ScalarsandVectors_BaseValueFloat1.Write(_LastReadScalar)
        BG3Editor_ScalarsandVectors_ValueFloat1.Write(_LastReadScalar)
        BG3Editor_ScalarsandVectors_Custom1.Write(_LastReadScalar)
        BG3Editor_ScalarsandVectors_ParameterScalar1.Write(_LastReadScalar)
        ListBoxScalars.Items(ListBoxScalars.SelectedIndex).text = BG3Editor_ScalarsandVectors_ParameterScalar1.TextBox1.Text
        RefreshItemAt(ListBoxScalars, ListBoxScalars.SelectedIndex)
    End Sub
    Private Sub Read_values_Vectors3()
        If ListBoxVectors3.SelectedIndex <> -1 Then
            _LastReadVector3 = ListBoxVectors3.Items(ListBoxVectors3.SelectedIndex).value
            BG3Editor_ScalarsandVectors_Color2.Read(_LastReadVector3)
            BG3Editor_ScalarsandVectors_ExportAsPreset2.Read(_LastReadVector3)
            BG3Editor_ScalarsandVectors_BaseValueVec32.Read(_LastReadVector3)
            BG3Editor_ScalarsandVectors_ValueVec32.Read(_LastReadVector3)
            BG3Editor_ScalarsandVectors_Custom2.Read(_LastReadVector3)
            BG3Editor_ScalarsandVectors_ParameterScalar2.Read(_LastReadVector3)
            BG3Editor_ScalarsandVectors_GroupName2.Read(_LastReadVector3)
            PictureBox1.BackColor = BG3Editor_Complex_Dyecolor.SRGB0_1(BG3Editor_ScalarsandVectors_ValueVec32.TextBox1.Text)
            If BG3Editor_ScalarsandVectors_BaseValueVec32.Text = "" Then
                BG3Editor_ScalarsandVectors_BaseValueVec32.TextBox1.Text = "0 0 0"
            End If
        Else
            _LastReadVector3 = Nothing
            BG3Editor_ScalarsandVectors_Color2.Clear()
            BG3Editor_ScalarsandVectors_ExportAsPreset2.Clear()
            BG3Editor_ScalarsandVectors_BaseValueVec32.Clear()
            BG3Editor_ScalarsandVectors_ValueVec32.Clear()
            BG3Editor_ScalarsandVectors_Custom2.Clear()
            BG3Editor_ScalarsandVectors_ParameterScalar2.Clear()
            BG3Editor_ScalarsandVectors_GroupName2.Clear()
            PictureBox1.BackColor = BG3Editor_ScalarsandVectors_ValueVec43.BackColor
        End If

    End Sub
    Private Sub Save_values_Vectors3()
        If ListBoxVectors3.SelectedIndex = -1 Or GroupBox2.Enabled = False Then Exit Sub
        BG3Editor_ScalarsandVectors_Color2.Write(_LastReadVector3)
        BG3Editor_ScalarsandVectors_ExportAsPreset2.Write(_LastReadVector3)
        BG3Editor_ScalarsandVectors_BaseValueVec32.Write(_LastReadVector3)
        BG3Editor_ScalarsandVectors_ValueVec32.Write(_LastReadVector3)
        BG3Editor_ScalarsandVectors_Custom2.Write(_LastReadVector3)
        BG3Editor_ScalarsandVectors_ParameterScalar2.Write(_LastReadVector3)
        BG3Editor_ScalarsandVectors_GroupName2.Write(_LastReadVector3)
        ListBoxVectors3.Items(ListBoxVectors3.SelectedIndex).text = BG3Editor_ScalarsandVectors_ParameterScalar2.TextBox1.Text
        RefreshItemAt(ListBoxVectors3, ListBoxVectors3.SelectedIndex)
    End Sub

    Private Sub Read_values_Vectors4()
        If ListBoxVectors4.SelectedIndex <> -1 Then
            _LastReadVector4 = ListBoxVectors4.Items(ListBoxVectors4.SelectedIndex).value
            BG3Editor_ScalarsandVectors_Color3.Read(_LastReadVector4)
            BG3Editor_ScalarsandVectors_ExportAsPreset3.Read(_LastReadVector4)
            BG3Editor_ScalarsandVectors_BaseValueVec43.Read(_LastReadVector4)
            BG3Editor_ScalarsandVectors_ValueVec43.Read(_LastReadVector4)
            BG3Editor_ScalarsandVectors_Custom3.Read(_LastReadVector4)
            BG3Editor_ScalarsandVectors_ParameterScalar3.Read(_LastReadVector4)
            BG3Editor_ScalarsandVectors_GroupName3.Read(_LastReadVector4)
            PictureBox2.BackColor = BG3Editor_Complex_Dyecolor.SRGB0_1(BG3Editor_ScalarsandVectors_ValueVec43.TextBox1.Text)
            If BG3Editor_ScalarsandVectors_BaseValueVec43.Text = "" Then
                BG3Editor_ScalarsandVectors_BaseValueVec43.TextBox1.Text = "0 0 0 1"
            End If
        Else
            _LastReadVector4 = Nothing
            BG3Editor_ScalarsandVectors_Color3.Clear()
            BG3Editor_ScalarsandVectors_ExportAsPreset3.Clear()
            BG3Editor_ScalarsandVectors_BaseValueVec43.Clear()
            BG3Editor_ScalarsandVectors_ValueVec43.Clear()
            BG3Editor_ScalarsandVectors_Custom3.Clear()
            BG3Editor_ScalarsandVectors_ParameterScalar3.Clear()
            BG3Editor_ScalarsandVectors_GroupName3.Clear()
            PictureBox2.BackColor = BG3Editor_ScalarsandVectors_ValueVec43.BackColor
        End If

    End Sub
    Private Sub Save_values_Vectors4()
        If ListBoxVectors4.SelectedIndex = -1 Or GroupBox3.Enabled = False Then Exit Sub
        BG3Editor_ScalarsandVectors_Color3.Write(_LastReadVector4)
        BG3Editor_ScalarsandVectors_ExportAsPreset3.Write(_LastReadVector4)
        BG3Editor_ScalarsandVectors_BaseValueVec43.Write(_LastReadVector4)
        BG3Editor_ScalarsandVectors_ValueVec43.Write(_LastReadVector4)
        BG3Editor_ScalarsandVectors_Custom3.Write(_LastReadVector4)
        BG3Editor_ScalarsandVectors_ParameterScalar3.Write(_LastReadVector4)
        BG3Editor_ScalarsandVectors_GroupName3.Write(_LastReadVector4)
        ListBoxVectors4.Items(ListBoxVectors4.SelectedIndex).text = BG3Editor_ScalarsandVectors_ParameterScalar3.TextBox1.Text
        RefreshItemAt(ListBoxVectors4, ListBoxVectors4.SelectedIndex)
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim nodtodelete As LSLib.LS.Node = ListBoxScalars.Items(ListBoxScalars.SelectedIndex).value
        ListBoxScalars.Items.RemoveAt(ListBoxScalars.SelectedIndex)
        Dim Parentnod As LSLib.LS.Node = _Write_Node
        Dim coleccion As List(Of LSLib.LS.Node) = Nothing
        Parentnod.Children.Remove(nodtodelete.Name, coleccion)
        For Each child In coleccion
            If child IsNot nodtodelete Then
                Parentnod.AppendChild(child)
            End If
        Next
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim nodtodelete As LSLib.LS.Node = ListBoxVectors3.Items(ListBoxVectors3.SelectedIndex).value
        ListBoxVectors3.Items.RemoveAt(ListBoxVectors3.SelectedIndex)
        Dim Parentnod As LSLib.LS.Node = _Write_Node
        Dim coleccion As List(Of LSLib.LS.Node) = Nothing
        Parentnod.Children.Remove(nodtodelete.Name, coleccion)
        For Each child In coleccion
            If child IsNot nodtodelete Then
                Parentnod.AppendChild(child)
            End If
        Next
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim nodtodelete As LSLib.LS.Node = ListBoxVectors4.Items(ListBoxVectors4.SelectedIndex).value
        ListBoxVectors4.Items.RemoveAt(ListBoxVectors4.SelectedIndex)
        Dim Parentnod As LSLib.LS.Node = _Write_Node
        Dim coleccion As List(Of LSLib.LS.Node) = Nothing
        Parentnod.Children.Remove(nodtodelete.Name, coleccion)
        For Each child In coleccion
            If child IsNot nodtodelete Then
                Parentnod.AppendChild(child)
            End If
        Next
    End Sub
    Private Sub Capturesave1() Handles BG3Editor_ScalarsandVectors_Color1.Leave, BG3Editor_ScalarsandVectors_ExportAsPreset1.Leave, BG3Editor_ScalarsandVectors_BaseValueFloat1.Leave, BG3Editor_ScalarsandVectors_ValueFloat1.Leave, BG3Editor_ScalarsandVectors_Custom1.Leave, BG3Editor_ScalarsandVectors_ParameterScalar1.Leave
        Save_values_Scalars()
    End Sub
    Private Sub Capturesave2() Handles BG3Editor_ScalarsandVectors_Color2.Leave, BG3Editor_ScalarsandVectors_ExportAsPreset2.Leave, BG3Editor_ScalarsandVectors_BaseValueVec32.Leave, BG3Editor_ScalarsandVectors_ValueVec32.Leave, BG3Editor_ScalarsandVectors_Custom2.Leave, BG3Editor_ScalarsandVectors_ParameterScalar2.Leave, BG3Editor_ScalarsandVectors_GroupName2.Leave
        Save_values_Vectors3()
    End Sub
    Private Sub Capturesave3() Handles BG3Editor_ScalarsandVectors_Color3.Leave, BG3Editor_ScalarsandVectors_ExportAsPreset3.Leave, BG3Editor_ScalarsandVectors_BaseValueVec43.Leave, BG3Editor_ScalarsandVectors_ValueVec43.Leave, BG3Editor_ScalarsandVectors_Custom3.Leave, BG3Editor_ScalarsandVectors_ParameterScalar3.Leave, BG3Editor_ScalarsandVectors_GroupName3.Leave
        Save_values_Vectors4()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim scal As New LSLib.LS.Node With {.Name = "ScalarParameters", .Parent = _Write_Node}
        Dim att As New LSLib.LS.NodeAttribute(LSLib.LS.AttributeType.FixedString)
        att.FromString("Undefined", Funciones.Guid_to_string)
        scal.Attributes.TryAdd(NameParameter, att)
        att = New LSLib.LS.NodeAttribute(LSLib.LS.AttributeType.Float)
        att.FromString("0", Funciones.Guid_to_string)
        scal.Attributes.TryAdd("Value", att)
        _Write_Node.AppendChild(scal)
        Dim cust As New BG3_Custom_ComboboxItem With {.Text = "Undefined", .Value = scal}
        Dim idx = ListBoxScalars.Items.Add(cust)
        ListBoxScalars.SelectedIndex = idx
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim scal As New LSLib.LS.Node With {.Name = "Vector3Parameters", .Parent = _Write_Node}
        Dim att As New LSLib.LS.NodeAttribute(LSLib.LS.AttributeType.FixedString)
        att.FromString("Undefined", Funciones.Guid_to_string)
        scal.Attributes.TryAdd(NameParameter, att)
        att = New LSLib.LS.NodeAttribute(LSLib.LS.AttributeType.Vec3)
        att.FromString("0 0 0", Funciones.Guid_to_string)
        scal.Attributes.TryAdd("Value", att)
        _Write_Node.AppendChild(scal)
        Dim cust As New BG3_Custom_ComboboxItem With {.Text = "Undefined", .Value = scal}
        Dim idx = ListBoxVectors3.Items.Add(cust)
        ListBoxVectors3.SelectedIndex = idx
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim scal As New LSLib.LS.Node With {.Name = "VectorParameters", .Parent = _Write_Node}
        Dim att As New LSLib.LS.NodeAttribute(LSLib.LS.AttributeType.FixedString)
        att.FromString("Undefined", Funciones.Guid_to_string)
        scal.Attributes.TryAdd(NameParameter, att)
        att = New LSLib.LS.NodeAttribute(LSLib.LS.AttributeType.Vec4)
        att.FromString("0 0 0 1", Funciones.Guid_to_string)
        scal.Attributes.TryAdd("Value", att)
        _Write_Node.AppendChild(scal)
        Dim cust As New BG3_Custom_ComboboxItem With {.Text = "Undefined", .Value = scal}
        Dim idx = ListBoxVectors4.Items.Add(cust)
        ListBoxVectors4.SelectedIndex = idx
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim zz As New Selectcolors With {.StartPosition = FormStartPosition.Manual}
        zz.Location = GroupBox2.PointToScreen(New Point(-7, 0))
        zz.PictureBox1.BackColor = BG3Editor_Complex_Dyecolor.SRGB0_1(BG3Editor_ScalarsandVectors_ValueVec32.TextBox1.Text)
        zz.PictureBox2.BackColor = BG3Editor_Complex_Dyecolor.SRGB0_1(BG3Editor_ScalarsandVectors_BaseValueVec32.TextBox1.Text)
        zz.PictureBox2.Enabled = BG3Editor_ScalarsandVectors_BaseValueVec32.Enabled
        zz.NumericUpDown1.Value = 1
        zz.NumericUpDown2.Value = 1
        zz.NumericUpDown1.Enabled = False
        zz.NumericUpDown2.Enabled = False
        If zz.ShowDialog(Me) = DialogResult.OK Then
            BG3Editor_ScalarsandVectors_ValueVec32.TextBox1.Text = BG3Editor_Complex_Dyecolor.SRGB0_1(zz.PictureBox1.BackColor.R, zz.PictureBox1.BackColor.G, zz.PictureBox1.BackColor.B)
            PictureBox1.BackColor = BG3Editor_Complex_Dyecolor.SRGB0_1(BG3Editor_ScalarsandVectors_ValueVec32.TextBox1.Text)
            If BG3Editor_ScalarsandVectors_BaseValueVec32.TextBox1.Enabled Then
                BG3Editor_ScalarsandVectors_BaseValueVec32.TextBox1.Text = BG3Editor_Complex_Dyecolor.SRGB0_1(zz.PictureBox2.BackColor.R, zz.PictureBox2.BackColor.G, zz.PictureBox2.BackColor.B)
            End If
            Save_values_Vectors3()
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim zz As New Selectcolors With {.StartPosition = FormStartPosition.Manual}
        zz.Location = GroupBox3.PointToScreen(New Point(-7, 0))
        zz.PictureBox1.BackColor = BG3Editor_Complex_Dyecolor.SRGB0_1(BG3Editor_ScalarsandVectors_ValueVec43.TextBox1.Text)
        zz.PictureBox2.BackColor = BG3Editor_Complex_Dyecolor.SRGB0_1(BG3Editor_ScalarsandVectors_BaseValueVec43.TextBox1.Text)
        zz.PictureBox2.Enabled = BG3Editor_ScalarsandVectors_BaseValueVec43.Enabled
        zz.NumericUpDown1.Value = CDec(PictureBox1.BackColor.A / 255)
        zz.NumericUpDown2.Value = CDec(PictureBox2.BackColor.A / 255)
        zz.NumericUpDown1.Enabled = True
        zz.NumericUpDown2.Enabled = True
        If zz.ShowDialog(Me) = DialogResult.OK Then
            Dim alpha1 As Byte = 255 * zz.NumericUpDown1.Value
            Dim alpha2 As Byte = 255 * zz.NumericUpDown2.Value
            BG3Editor_ScalarsandVectors_ValueVec43.TextBox1.Text = BG3Editor_Complex_Dyecolor.SRGB0_1(zz.PictureBox1.BackColor.R, zz.PictureBox1.BackColor.G, zz.PictureBox1.BackColor.B, alpha1)
            PictureBox2.BackColor = BG3Editor_Complex_Dyecolor.SRGB0_1(BG3Editor_ScalarsandVectors_ValueVec43.TextBox1.Text)
            If BG3Editor_ScalarsandVectors_BaseValueVec43.TextBox1.Enabled Then
                BG3Editor_ScalarsandVectors_BaseValueVec43.TextBox1.Text = BG3Editor_Complex_Dyecolor.SRGB0_1(zz.PictureBox2.BackColor.R, zz.PictureBox2.BackColor.G, zz.PictureBox2.BackColor.B, alpha2)
            End If
            Save_values_Vectors4()
        End If
    End Sub


End Class
