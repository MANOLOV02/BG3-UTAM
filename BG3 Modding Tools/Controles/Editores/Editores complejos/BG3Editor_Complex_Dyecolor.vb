Imports System.IO
Imports System.Reflection
Imports System.Reflection.Metadata
Imports System.Windows
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports LSLib.Granny
Imports LSLib.LS
Imports LSLib.LS.Story
Imports Windows.Win32.System

Public Class BG3Editor_Complex_Dyecolor

    Private ReadOnly labels As New List(Of System.Windows.Forms.Label)
    Public ReadOnly Pictures As New List(Of System.Windows.Forms.PictureBox)
    Private ReadOnly Texts As New List(Of System.Windows.Forms.TextBox)
    Private ReadOnly Darkers As New List(Of System.Windows.Forms.Button)
    Private ReadOnly Brighters As New List(Of System.Windows.Forms.Button)
    Private ReadOnly Colors As New List(Of Color)
    Public NodeToSave As LSLib.LS.Node
    Private ReadOnly ColorsCopy As New List(Of Color)
    Public ComboItem_Parent As BG3_Obj_Stats_Class
    Public Color_Preset As BG3_Obj_VisualBank_Class

    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        labels.Add(Label1)
        labels.Add(Label2)
        labels.Add(Label3)
        labels.Add(Label4)
        labels.Add(Label5)
        labels.Add(Label6)
        labels.Add(Label7)
        labels.Add(Label8)
        labels.Add(Label9)
        labels.Add(Label10)
        labels.Add(Label11)
        labels.Add(Label12)
        labels.Add(Label13)
        labels.Add(Label14)
        labels.Add(Label15)
        Pictures.Add(PictureBox1)
        Pictures.Add(PictureBox2)
        Pictures.Add(PictureBox3)
        Pictures.Add(PictureBox4)
        Pictures.Add(PictureBox5)
        Pictures.Add(PictureBox6)
        Pictures.Add(PictureBox7)
        Pictures.Add(PictureBox8)
        Pictures.Add(PictureBox9)
        Pictures.Add(PictureBox10)
        Pictures.Add(PictureBox11)
        Pictures.Add(PictureBox12)
        Pictures.Add(PictureBox13)
        Pictures.Add(PictureBox14)
        Pictures.Add(PictureBox15)
        Texts.Add(TextBox1)
        Texts.Add(TextBox2)
        Texts.Add(TextBox3)
        Texts.Add(TextBox4)
        Texts.Add(TextBox5)
        Texts.Add(TextBox6)
        Texts.Add(TextBox7)
        Texts.Add(TextBox8)
        Texts.Add(TextBox9)
        Texts.Add(TextBox10)
        Texts.Add(TextBox11)
        Texts.Add(TextBox12)
        Texts.Add(TextBox13)
        Texts.Add(TextBox14)
        Texts.Add(TextBox15)
        Darkers.Add(ButtonDark1)
        Darkers.Add(ButtonDark2)
        Darkers.Add(ButtonDark3)
        Darkers.Add(ButtonDark4)
        Darkers.Add(ButtonDark5)
        Darkers.Add(ButtonDark6)
        Darkers.Add(ButtonDark7)
        Darkers.Add(ButtonDark8)
        Darkers.Add(ButtonDark9)
        Darkers.Add(ButtonDark10)
        Darkers.Add(ButtonDark11)
        Darkers.Add(ButtonDark12)
        Darkers.Add(ButtonDark13)
        Darkers.Add(ButtonDark14)
        Darkers.Add(ButtonDark15)
        Brighters.Add(ButtonBrigh1)
        Brighters.Add(ButtonBrigh2)
        Brighters.Add(ButtonBrigh3)
        Brighters.Add(ButtonBrigh4)
        Brighters.Add(ButtonBrigh5)
        Brighters.Add(ButtonBrigh6)
        Brighters.Add(ButtonBrigh7)
        Brighters.Add(ButtonBrigh8)
        Brighters.Add(ButtonBrigh9)
        Brighters.Add(ButtonBrigh10)
        Brighters.Add(ButtonBrigh11)
        Brighters.Add(ButtonBrigh12)
        Brighters.Add(ButtonBrigh13)
        Brighters.Add(ButtonBrigh14)
        Brighters.Add(ButtonBrigh15)
        For x = 0 To FuncionesHelpers.ColorMaterialsNames.Count - 1
            Colors.Add(Color.FromKnownColor(KnownColor.White))
            ColorsCopy.Add(Color.FromKnownColor(KnownColor.White))
            AddHandler Pictures(x).Click, AddressOf PictureBoxXX_Click
            AddHandler Texts(x).Leave, AddressOf TextBoxXX_Leave
            AddHandler Darkers(x).Click, AddressOf DarkersXX_Click
            AddHandler Brighters(x).Click, AddressOf BrightersXX_Click
        Next
        Clear()
    End Sub
    Public Sub Clear()
        For x = 0 To FuncionesHelpers.ColorMaterialsNames.Count - 1
            labels(x).Text = FuncionesHelpers.ColorMaterialsNames(x)
            Pictures(x).BackColor = Color.FromKnownColor(KnownColor.White)
            Texts(x).Text = "1.00000 1.00000 1.00000"
            Colors(x) = Color.FromKnownColor(KnownColor.White)
        Next
    End Sub
    Public Function Create(Template_guid As String, Stat_Name As String, Color_template_guid As String, modsource As BG3_Pak_SourceOfResource_Class) As Boolean
        Create_Color_Temp(Color_template_guid, Template_guid, modsource)
        Create_Combo_Temp(Stat_Name, Color_template_guid, modsource)
        Return True
    End Function
    Public Function Read(Obj As BG3_Obj_VisualBank_Class) As Boolean
        If IsNothing(Obj) Then Return False
        Clear()
        Drop_OBJ_VisualBank2(Obj)
        Return True
    End Function
    Public Function Read(Obj As BG3_Obj_Template_Class) As Boolean
        If IsNothing(Obj) Then Return False
        Clear()
        If Obj.Utam_Type <> BG3_Enum_UTAM_Type.Armor Then Return False
        Drop_OBJ_Armor(Obj)
        Return True
    End Function

    Public Function Change_selected(Template_guid As String, Stat_Name As String, Color_template_guid As String, modsource As BG3_Pak_SourceOfResource_Class) As Boolean
        If FuncionesHelpers.GameEngine.ProcessedVisualBanksList.TryGetValue(Color_template_guid, Color_Preset) = False Then
            Create_Color_Temp(Color_template_guid, Template_guid, modsource)
        End If
        Drop_OBJ_VisualBank2(Color_Preset)
        If FuncionesHelpers.GameEngine.ProcessedStatList.TryGetValue("IC:" + Stat_Name, ComboItem_Parent) = False Then
            Create_Combo_Temp(Stat_Name, Color_template_guid, modsource)
        End If
        If IsNothing(ComboItem_Parent.Itemresult) Then
            ComboItem_Parent.Itemresult = New BG3_Obj_Stats_Class(modsource, Stat_Name + "_1") With {.Type = BG3_Enum_StatType.ItemCombination, .[Using] = ComboItem_Parent.Name}
            Editor_Stats_Generic.Create_Generic("ResultAmount 1", "1", ComboItem_Parent.Itemresult)
        End If
        Return True
    End Function


    Private Function Create_Combo_Temp(Stat_Name As String, Color_template_guid As String, modsource As BG3_Pak_SourceOfResource_Class) As Boolean
        Dim par As New BG3_Obj_Stats_Class(modsource, Stat_Name) With {.Type = BG3_Enum_StatType.ItemCombination}
        Editor_Stats_Generic.Create_Generic("Type 1", "Object", par)
        Editor_Stats_Generic.Create_Generic("Object 1", Stat_Name, par)
        Editor_Stats_Generic.Create_Generic("Transform 1", "Consume", par)
        Editor_Stats_Generic.Create_Generic("Type 2", "Category", par)
        Editor_Stats_Generic.Create_Generic("Object 2", "DyableArmor", par)
        Editor_Stats_Generic.Create_Generic("Transform 2", "Dye", par)
        Editor_Stats_Generic.Create_Generic("DyeColorPresetResource", Color_template_guid, par)
        par.Itemresult = New BG3_Obj_Stats_Class(modsource, Stat_Name + "_1") With {.Type = BG3_Enum_StatType.ItemCombination, .[Using] = par.Name}
        Editor_Stats_Generic.Create_Generic("ResultAmount 1", "1", par.Itemresult)
        par = FuncionesHelpers.GameEngine.ProcessedStatList.Manage_Overrides(par)
        ComboItem_Parent = par
        Return True
    End Function
    Private Function Create_Color_Temp(Color_template_guid As String, Template_guid As String, modsource As BG3_Pak_SourceOfResource_Class) As Boolean
        Dim nuevonodcp As New LSLib.LS.Node With {.Name = "Resource"}
        Editor_Generic_GenericAttribute.Create_Attribute_Generic(nuevonodcp, "ID", Color_template_guid, AttributeType.FixedString)
        Editor_Generic_GenericAttribute.Create_Attribute_Generic(nuevonodcp, "Name", "UTAM_Dye_ColorPreset" + Template_guid, AttributeType.LSString)
        Dim nuevonodcp2 As New LSLib.LS.Node With {.Name = "Presets", .Parent = nuevonodcp}
        Editor_Generic_GenericAttribute.Create_Attribute_Generic(nuevonodcp2, "MaterialResource", "", AttributeType.FixedString)
        nuevonodcp.AppendChild(nuevonodcp2)
        Dim nuevonodcp3 As New LSLib.LS.Node With {.Name = "MaterialPresets", .Parent = nuevonodcp2}
        nuevonodcp2.AppendChild(nuevonodcp3)
        For Each col In FuncionesHelpers.ColorMaterialsNames
            Dim nod As New LSLib.LS.Node With {.Name = "Vector3Parameters", .Parent = nuevonodcp2}
            Editor_Generic_GenericAttribute.Create_Attribute_Generic(nod, "Color", "True", AttributeType.Bool)
            Editor_Generic_GenericAttribute.Create_Attribute_Generic(nod, "Custom", "False", AttributeType.Bool)
            Editor_Generic_GenericAttribute.Create_Attribute_Generic(nod, "Enabled", "True", AttributeType.Bool)
            Editor_Generic_GenericAttribute.Create_Attribute_Generic(nod, "Parameter", col, AttributeType.FixedString)
            Editor_Generic_GenericAttribute.Create_Attribute_Generic(nod, "Value", "1 1 1", AttributeType.Vec3)
            nuevonodcp2.AppendChild(nod)
        Next
        Color_Preset = FuncionesHelpers.GameEngine.ProcessedVisualBanksList.Manage_Overrides(New BG3_Obj_VisualBank_Class(nuevonodcp, modsource, BG3_Enum_VisualBank_Type.MaterialPresetBank))
        Return True
    End Function

    Private Sub PictureBoxXX_Click(sender As Object, e As EventArgs)
        DePicture_a_Texto(sender)
    End Sub
    Private Sub TextBoxXX_Leave(sender As Object, e As EventArgs)
        DeTexto_aPicture(sender)
    End Sub
    Private Sub DarkersXX_Click(sender As Object, e As EventArgs)
        Darker(sender)
    End Sub
    Private Sub BrightersXX_Click(sender As Object, e As EventArgs)
        Darker(sender, True)
    End Sub
    Private Sub Darker(quien As System.Windows.Forms.Button, Optional inverse As Boolean = False)
        Dim indice As Integer
        If inverse = True Then
            indice = Brighters.IndexOf(quien)
        Else
            indice = Darkers.IndexOf(quien)
        End If
        Dim texto = Texts(indice)
        Dim ncolor = SRGB0_1(texto.Text)
        Dim pic As PictureBox = Pictures(indice)
        If ncolor.ToArgb <> pic.BackColor.ToArgb Then
            pic.BackColor = Color.FromArgb(ncolor.R, ncolor.G, ncolor.B)
        End If
        Dim mult As Double = 0.95
        If inverse Then mult = 1.05
        Dim nrd As Integer = pic.BackColor.R
        Dim nrg As Integer = pic.BackColor.G
        Dim nrb As Integer = pic.BackColor.B
        If DarkerR.Checked = True Then nrd = CInt(nrd * mult)
        If DarkerG.Checked = True Then nrg = CInt(nrg * mult)
        If DarkerB.Checked = True Then nrb = CInt(nrb * mult)
        If DarkerR.Checked = True And inverse = True And pic.BackColor.R <> 0 Then If nrd = pic.BackColor.R Then nrd += 1
        If DarkerG.Checked = True And inverse = True And pic.BackColor.G <> 0 Then If nrg = pic.BackColor.G Then nrg += 1
        If DarkerB.Checked = True And inverse = True And pic.BackColor.B <> 0 Then If nrb = pic.BackColor.B Then nrb += 1
        If nrd > 255 Then nrd = 255
        If nrg > 255 Then nrg = 255
        If nrb > 255 Then nrb = 255
        If nrd < 0 Then nrd = 0
        If nrg < 0 Then nrg = 0
        If nrb < 0 Then nrb = 0
        texto.Text = SRGB0_1(nrd, nrg, nrb)
        Colors(indice) = pic.BackColor
    End Sub
    Private Sub DePicture_a_Texto(ByRef pic As PictureBox)
        ColorDialog1.Color = pic.BackColor
        If ColorDialog1.ShowDialog() <> DialogResult.OK Then ColorDialog1.Color = pic.BackColor
        Dim indice As Integer = Pictures.IndexOf(pic)
        Dim Tex = Texts(indice)
        pic.BackColor = ColorDialog1.Color
        Dim bntexto As String = SRGB0_1(pic.BackColor.R, pic.BackColor.G, pic.BackColor.B)
        If bntexto <> Tex.Text Then
            Tex.Text = SRGB0_1(pic.BackColor.R, pic.BackColor.G, pic.BackColor.B)
        End If
        Colors(indice) = pic.BackColor
    End Sub
    Private Sub DeTexto_aPicture(ByRef tex As System.Windows.Forms.TextBox)
        Dim indice As Integer = Texts.IndexOf(tex)
        Dim pic = Pictures(indice)
        Dim ncolor As Color = SRGB0_1(tex.Text)
        If ncolor.ToArgb <> pic.BackColor.ToArgb Then
            pic.BackColor = Color.FromArgb(ncolor.R, ncolor.G, ncolor.B)
        End If
        tex.Text = SRGB0_1(pic.BackColor.R, pic.BackColor.G, pic.BackColor.B)
        Colors(indice) = pic.BackColor
    End Sub
    Public Shared Function SRGB0_1(r As Byte, g As Byte, b As Byte) As String
        Dim s1 As String = Format(Math.Round(r / 255, 8), "0.00000")
        Dim s2 As String = Format(Math.Round(g / 255, 8), "0.00000")
        Dim s3 As String = Format(Math.Round(b / 255, 8), "0.00000")
        Return (s1 + " " + s2 + " " + s3).Replace(Application.CurrentCulture.NumberFormat.NumberDecimalSeparator, ".")
    End Function
    Public Shared Function SRGB0_1(r As Byte, g As Byte, b As Byte, alpha As Byte) As String
        Dim s1 As String = Format(Math.Round(r / 255, 8), "0.00000")
        Dim s2 As String = Format(Math.Round(g / 255, 8), "0.00000")
        Dim s3 As String = Format(Math.Round(b / 255, 8), "0.00000")
        Dim s4 As String = Format(Math.Round(alpha / 255, 8), "0.00000")
        Return (s1 + " " + s2 + " " + s3 + " " + s4).Replace(Application.CurrentCulture.NumberFormat.NumberDecimalSeparator, ".")
    End Function
    Public Shared Function SRGB0_1(texto As String) As Color
        Dim r As Byte
        Dim g As Byte
        Dim b As Byte
        Dim alpha As Byte = 255
        Dim s() As String = texto.Split(" ")
        If s.Length <> 3 AndAlso s.Length <> 4 Then Return Color.FromArgb(0, 0, 0)
        If s.Length = 4 Then
            alpha = CInt(CDbl(s(3).Replace(".", Application.CurrentCulture.NumberFormat.NumberDecimalSeparator)) * 255)
            If alpha < 0 Then alpha = 255
            If alpha > 255 Then alpha = 255
        Else
            alpha = 255
        End If

        Try
            r = CInt(CDbl(s(0).Replace(".", Application.CurrentCulture.NumberFormat.NumberDecimalSeparator)) * 255)
            g = CInt(CDbl(s(1).Replace(".", Application.CurrentCulture.NumberFormat.NumberDecimalSeparator)) * 255)
            b = CInt(CDbl(s(2).Replace(".", Application.CurrentCulture.NumberFormat.NumberDecimalSeparator)) * 255)
        Catch ex As Exception
            r = 0
            g = 0
            b = 0
        End Try
        If r < 0 Or r > 255 Then Return Color.FromArgb(0, 0, 0)
        If g < 0 Or g > 255 Then Return Color.FromArgb(0, 0, 0)
        If b < 0 Or b > 255 Then Return Color.FromArgb(0, 0, 0)
        Return Color.FromArgb(alpha, r, g, b)
    End Function

    Public Sub Drop_OBJ_VisualBank1(Obj As BG3_Obj_VisualBank_Class)
        Dim value0 As List(Of LSLib.LS.Node) = Nothing
        If Obj.NodeLSLIB.ChildCount > 0 AndAlso Obj.NodeLSLIB.Children.TryGetValue("Objects", value0) Then
            Dim curnodes = value0
            For Each nod In curnodes
                Dim value4 As LSLib.LS.NodeAttribute = Nothing
                If nod.Attributes.TryGetValue("MaterialID", value4) Then
                    Dim cp As String = value4.Value.ToString
                    Dim cpObj As BG3_Obj_VisualBank_Class = Nothing
                    If FuncionesHelpers.GameEngine.ProcessedVisualBanksList.TryGetValue(cp, cpObj) = False Then Exit For
                    Drop_OBJ_VisualBank2(cpObj)
                End If
            Next
        End If
    End Sub
    Public Sub Drop_OBJ_VisualBank2(cpObj As BG3_Obj_VisualBank_Class)
        If cpObj.NodeLSLIB.ChildCount = 0 Then Exit Sub
        Select Case cpObj.Type
            Case BG3_Enum_VisualBank_Type.MaterialPresetBank
                For Each chil In cpObj.NodeLSLIB.Children.Where(Function(Pf) Pf.Key = "Presets")
                    For Each params In chil.Value
                        For Each chil2 In params.Children.Where(Function(Pf) Pf.Key = "Vector3Parameters")
                            Drop_OBJ(chil2.Value, False)
                        Next
                    Next
                Next
            Case BG3_Enum_VisualBank_Type.MaterialBank
                For Each chil2 In cpObj.NodeLSLIB.Children.Where(Function(Pf) Pf.Key = "Vector3Parameters")
                    Drop_OBJ(chil2.Value, False)
                Next
            Case Else
                Debugger.Break()
        End Select

    End Sub
    Public Sub Write(cpObj As BG3_Obj_VisualBank_Class)
        If cpObj.NodeLSLIB.ChildCount = 0 Then Exit Sub
        Select Case cpObj.Type
            Case BG3_Enum_VisualBank_Type.MaterialPresetBank
                For Each chil In cpObj.NodeLSLIB.Children.Where(Function(Pf) Pf.Key = "Presets")
                    For Each params In chil.Value
                        Save_Nodes_Generic(params, Typesave.ArmorDye)
                    Next
                Next
            Case BG3_Enum_VisualBank_Type.MaterialBank
                Save_Nodes_Generic(cpObj.NodeLSLIB, Typesave.MaterialBank)

            Case Else
                Debugger.Break()
        End Select

    End Sub
    Public Sub Write(MaterialOverride As LSLib.LS.Node)
        If IsNothing(MaterialOverride) Then Exit Sub

        Dim value3 As List(Of LSLib.LS.Node) = Nothing
        If MaterialOverride.ChildCount > 0 AndAlso MaterialOverride.Children.TryGetValue("MaterialPresets", value3) Then
            For Each nod4 In value3
                Dim value6 As List(Of LSLib.LS.Node) = Nothing
                If nod4.ChildCount > 0 AndAlso nod4.Children.TryGetValue("Object", value6) Then
                    Dim force As Boolean = False
                    Dim groupname As String = ""
                    For Each nod5 In value6
                        Dim value4 As LSLib.LS.NodeAttribute = Nothing
                        Dim valuef As LSLib.LS.NodeAttribute = Nothing
                        If nod5.Attributes.TryGetValue("ForcePresetValues", value4) Then
                            force = value4.Value
                        End If
                        If nod5.Attributes.TryGetValue("GroupName", value4) Then
                            groupname = value4.Value
                        End If
                        If groupname = "02 Colour" And force = True Then
                            nod5.Attributes("ForcePresetValues").Value = False
                        End If
                    Next
                End If
            Next
        End If
        If MaterialOverride.ChildCount > 0 AndAlso MaterialOverride.Children.TryGetValue("ColorPreset", value3) Then
            For Each nod4 In value3
                Dim value4 As LSLib.LS.NodeAttribute = Nothing
                Dim force As Boolean = False
                Dim groupname As String = ""
                If nod4.Attributes.TryGetValue("ForcePresetValues", value4) Then
                    force = value4.Value
                End If
                If nod4.Attributes.TryGetValue("GroupName", value4) Then
                    groupname = value4.Value
                End If
                If groupname = "02 Colour" And force = True Then
                    nod4.Attributes("ForcePresetValues").Value = False
                End If
            Next
        End If

        Save_Nodes_Generic(MaterialOverride, Typesave.ArmorDye)

    End Sub
    Private Enum Typesave
        ArmorDye
        MaterialBank
    End Enum
    Private Sub Save_Nodes_Generic(Node As LSLib.LS.Node, typesave As Typesave)
        Dim puestos(14) As Integer
        Dim nam As String = "Parameter"
        Dim iscolor As String = "Color"
        Dim Groupname As String = "02 Colour"
        If typesave = Typesave.MaterialBank Then
            nam = "ParameterName"
            iscolor = "IsColor"
        End If

        Dim value3 As List(Of LSLib.LS.Node) = Nothing
        If Node.Children.TryGetValue("Vector3Parameters", value3) Then
            For Each nod2 As LSLib.LS.Node In value3
                Dim value As LSLib.LS.NodeAttribute = Nothing
                nod2.Attributes.TryGetValue(nam, value)
                If Not IsNothing(value) Then
                    Dim par As String = value.Value
                    Dim ind As Integer = FuncionesHelpers.ColorMaterialsNames.IndexOf(par)
                    If ind <> -1 Then
                        puestos(ind) = 1
                        Dim value4 As New LSLib.LS.NodeAttribute(AttributeType.Vec3)
                        If nod2.Attributes.TryAdd(iscolor, New NodeAttribute(AttributeType.Bool) With {.Value = True}) = False Then nod2.Attributes(iscolor).Value = True
                        If nod2.Attributes.TryAdd("Enabled", New NodeAttribute(AttributeType.Bool) With {.Value = True}) = False Then nod2.Attributes("Enabled").Value = True
                        If nod2.Attributes.TryAdd("GroupName", New NodeAttribute(AttributeType.FixedString) With {.Value = Groupname}) = False Then nod2.Attributes("GroupName").Value = Groupname
                        If nod2.Attributes.TryAdd(nam, New NodeAttribute(AttributeType.FixedString) With {.Value = FuncionesHelpers.ColorMaterialsNames(ind)}) = False Then nod2.Attributes(nam).Value = FuncionesHelpers.ColorMaterialsNames(ind)
                        value4.FromString(Texts(ind).Text, Funciones.Guid_to_string)
                        If nod2.Attributes.TryAdd("Value", value4) = False Then nod2.Attributes("Value").Value = value4.Value
                        If typesave = Typesave.ArmorDye Then
                            If nod2.Attributes.TryAdd("Custom", New NodeAttribute(AttributeType.Bool) With {.Value = True}) = False Then nod2.Attributes("Custom").Value = True
                        End If
                        If typesave = Typesave.MaterialBank Then
                            If nod2.Attributes.TryAdd("BaseValue", value4) = False Then nod2.Attributes("BaseValue").Value = value4.Value
                            If nod2.Attributes.TryAdd("ExportAsPreset", New NodeAttribute(AttributeType.Bool) With {.Value = True}) = False Then nod2.Attributes("ExportAsPreset").Value = True
                        End If
                    End If
                End If
            Next
        End If


        For ind = 0 To puestos.Length - 1
            If puestos(ind) = 0 Then
                Dim nod2 As New LSLib.LS.Node With {.Parent = Node, .Name = "Vector3Parameters"}
                Dim value4 As New LSLib.LS.NodeAttribute(AttributeType.Vec3)
                If nod2.Attributes.TryAdd(iscolor, New NodeAttribute(AttributeType.Bool) With {.Value = True}) = False Then nod2.Attributes(iscolor).Value = True
                If nod2.Attributes.TryAdd("Enabled", New NodeAttribute(AttributeType.Bool) With {.Value = True}) = False Then nod2.Attributes("Enabled").Value = True
                If nod2.Attributes.TryAdd("GroupName", New NodeAttribute(AttributeType.FixedString) With {.Value = Groupname}) = False Then nod2.Attributes("GroupName").Value = Groupname
                If nod2.Attributes.TryAdd(nam, New NodeAttribute(AttributeType.FixedString) With {.Value = FuncionesHelpers.ColorMaterialsNames(ind)}) = False Then nod2.Attributes(nam).Value = FuncionesHelpers.ColorMaterialsNames(ind)
                value4.FromString(Texts(ind).Text, Funciones.Guid_to_string)
                If nod2.Attributes.TryAdd("Value", value4) = False Then nod2.Attributes("Value").Value = value4.Value
                If typesave = Typesave.ArmorDye Then
                    If nod2.Attributes.TryAdd("Custom", New NodeAttribute(AttributeType.Bool) With {.Value = True}) = False Then nod2.Attributes("Custom").Value = True
                End If
                If typesave = Typesave.MaterialBank Then
                    If nod2.Attributes.TryAdd("BaseValue", value4) = False Then nod2.Attributes("BaseValue").Value = value4.Value
                    If nod2.Attributes.TryAdd("ExportAsPreset", New NodeAttribute(AttributeType.Bool) With {.Value = True}) = False Then nod2.Attributes("ExportAsPreset").Value = True
                End If
                Node.AppendChild(nod2)
            End If
        Next
        'Node.Children.Remove("VectorParameters")
        'Save_Nodes_GenericV4(Node, typesave)
    End Sub
    Private Sub Save_Nodes_GenericV4(Node As LSLib.LS.Node, typesave As Typesave)
        Dim puestos(4) As Integer
        Dim nam As String = "Parameter"
        Dim iscolor As String = "Color"
        Dim Groupname As String = "Colour"
        If typesave = Typesave.MaterialBank Then
            nam = "ParameterName"
            iscolor = "IsColor"
        End If
        Dim copies(4) As String
        copies(0) = "0 0 1 1" ' Texts(FuncionesHelpers.ColorMaterialsNames.IndexOf("Color_01")).Text + " 1"
        copies(1) = "0 0 1 1" 'Texts(FuncionesHelpers.ColorMaterialsNames.IndexOf("Color_02")).Text + " 1"
        copies(2) = "0 0 1 1" 'Texts(FuncionesHelpers.ColorMaterialsNames.IndexOf("Color_03")).Text + " 1"
        copies(3) = "0 0 1 1" 'Texts(FuncionesHelpers.ColorMaterialsNames.IndexOf("Custom_1")).Text + " 1"
        copies(4) = "0 0 1 1" 'Texts(FuncionesHelpers.ColorMaterialsNames.IndexOf("Custom_2")).Text + " 1"

        Dim value3 As List(Of LSLib.LS.Node) = Nothing
        If Node.Children.TryGetValue("VectorParameters", value3) Then
            For Each nod2 As LSLib.LS.Node In value3
                Dim value As LSLib.LS.NodeAttribute = Nothing
                nod2.Attributes.TryGetValue(nam, value)
                If Not IsNothing(value) Then
                    Dim par As String = value.Value
                    Dim ind As Integer = FuncionesHelpers.ColorMaterialsNames2.IndexOf(par)
                    If ind <> -1 Then
                        puestos(ind) = 1
                        Dim value4 As New LSLib.LS.NodeAttribute(AttributeType.Vec4)
                        If nod2.Attributes.TryAdd(iscolor, New NodeAttribute(AttributeType.Bool) With {.Value = True}) = False Then nod2.Attributes(iscolor).Value = True
                        If nod2.Attributes.TryAdd("Enabled", New NodeAttribute(AttributeType.Bool) With {.Value = True}) = False Then nod2.Attributes("Enabled").Value = True
                        If nod2.Attributes.TryAdd("GroupName", New NodeAttribute(AttributeType.FixedString) With {.Value = Groupname}) = False Then nod2.Attributes("GroupName").Value = Groupname
                        If nod2.Attributes.TryAdd(nam, New NodeAttribute(AttributeType.FixedString) With {.Value = FuncionesHelpers.ColorMaterialsNames2(ind)}) = False Then nod2.Attributes(nam).Value = FuncionesHelpers.ColorMaterialsNames2(ind)
                        value4.FromString(copies(ind), Funciones.Guid_to_string)
                        If nod2.Attributes.TryAdd("Value", value4) = False Then nod2.Attributes("Value").Value = value4.Value
                        If typesave = Typesave.ArmorDye Then
                            If nod2.Attributes.TryAdd("Custom", New NodeAttribute(AttributeType.Bool) With {.Value = True}) = False Then nod2.Attributes("Custom").Value = True
                        End If
                        If typesave = Typesave.MaterialBank Then
                            'If nod2.Attributes.TryAdd("BaseValue", value4) = False Then nod2.Attributes("BaseValue").Value = value4.Value
                            If nod2.Attributes.TryAdd("ExportAsPreset", New NodeAttribute(AttributeType.Bool) With {.Value = True}) = False Then nod2.Attributes("ExportAsPreset").Value = True
                        End If
                    End If
                End If
            Next
        End If


        For ind = 0 To puestos.Length - 1
            If puestos(ind) = 0 Then
                Dim nod2 As New LSLib.LS.Node With {.Parent = Node, .Name = "VectorParameters"}
                Dim value4 As New LSLib.LS.NodeAttribute(AttributeType.Vec4)
                If nod2.Attributes.TryAdd(iscolor, New NodeAttribute(AttributeType.Bool) With {.Value = True}) = False Then nod2.Attributes(iscolor).Value = True
                If nod2.Attributes.TryAdd("Enabled", New NodeAttribute(AttributeType.Bool) With {.Value = True}) = False Then nod2.Attributes("Enabled").Value = True
                If nod2.Attributes.TryAdd("GroupName", New NodeAttribute(AttributeType.FixedString) With {.Value = Groupname}) = False Then nod2.Attributes("GroupName").Value = Groupname
                If nod2.Attributes.TryAdd(nam, New NodeAttribute(AttributeType.FixedString) With {.Value = FuncionesHelpers.ColorMaterialsNames2(ind)}) = False Then nod2.Attributes(nam).Value = FuncionesHelpers.ColorMaterialsNames2(ind)
                value4.FromString(copies(ind), Funciones.Guid_to_string)
                If nod2.Attributes.TryAdd("Value", value4) = False Then nod2.Attributes("Value").Value = value4.Value
                If typesave = Typesave.ArmorDye Then
                    If nod2.Attributes.TryAdd("Custom", New NodeAttribute(AttributeType.Bool) With {.Value = True}) = False Then nod2.Attributes("Custom").Value = True
                End If
                If typesave = Typesave.MaterialBank Then
                    'If nod2.Attributes.TryAdd("BaseValue", value4) = False Then nod2.Attributes("BaseValue").Value = value4.Value
                    If nod2.Attributes.TryAdd("ExportAsPreset", New NodeAttribute(AttributeType.Bool) With {.Value = True}) = False Then nod2.Attributes("ExportAsPreset").Value = True
                End If
                Node.AppendChild(nod2)
            End If
        Next
    End Sub
    Public Sub Drop_OBJ(Obj As BG3_Obj_Template_Class)
        Dim cp As String = Obj.ReadAttribute_Or_Nothing("ColorPreset")
        Dim cpObj As BG3_Obj_VisualBank_Class = Nothing

        ' Si esta en el template
        If Not IsNothing(Obj.ReadAttribute_Or_Nothing("ColorPreset")) Then
            If FuncionesHelpers.GameEngine.ProcessedVisualBanksList.TryGetValue(cp, cpObj) = True Then
                Drop_OBJ_VisualBank2(cpObj)
            End If
        End If

        ' Voy al item combination
        Dim Stat As String = Obj.AssociatedStats.Name
        If IsNothing(Stat) Then Exit Sub
        Dim StatObj As BG3_Obj_Stats_Class = Nothing
        If FuncionesHelpers.GameEngine.ProcessedStatList.TryGetValue("IC:" + Stat, StatObj) = True Then
            If StatObj.Data.TryGetValue("DyeColorPresetResource", cp) Then
                If FuncionesHelpers.GameEngine.ProcessedVisualBanksList.TryGetValue(cp, cpObj) = True Then
                    Drop_OBJ_VisualBank2(cpObj)
                End If
            End If
        End If

    End Sub

    Private Sub Clear_colors()
        For x = 0 To FuncionesHelpers.ColorMaterialsNames.Count - 1
            Pictures(x).BackColor = SRGB0_1("1.00000 1.00000 1.00000")
            Texts(x).Text = SRGB0_1(Pictures(x).BackColor.R, Pictures(x).BackColor.G, Pictures(x).BackColor.B)
            Colors(x) = Pictures(x).BackColor
            Forceds(x) = 0
        Next
    End Sub

    Public Sub Drop_OBJ(Subnodos As List(Of LSLib.LS.Node), ForcedAvoid As Boolean)
        For Each nod In Subnodos
            Dim value As LSLib.LS.NodeAttribute = Nothing
            If nod.Attributes.TryGetValue("Parameter", value) = False Then
                nod.Attributes.TryGetValue("ParameterName", value)
            End If

            If Not IsNothing(value) Then
                Dim par As String = value.Value
                Dim ind As Integer = FuncionesHelpers.ColorMaterialsNames.IndexOf(par)
                Dim col As String
                If ind <> -1 And nod.Attributes.ContainsKey("Value") Then
                    If ForcedAvoid = False OrElse Forceds(ind) = 0 Then
                        Select Case nod.Attributes("Value").Type
                            Case LSLib.LS.AttributeType.Vec3
                                col = nod.Attributes("Value").Value(0).ToString + " " + nod.Attributes("Value").Value(1).ToString + " " + nod.Attributes("Value").Value(2).ToString
                            Case LSLib.LS.AttributeType.FixedString
                                col = nod.Attributes("Value").Value
                            Case Else
                                col = "1.00000 1.00000 1.00000"
                        End Select
                        If ForcedAvoid = False Then Forceds(ind) = 1
                        Pictures(ind).BackColor = SRGB0_1(col)
                        Texts(ind).Text = SRGB0_1(Pictures(ind).BackColor.R, Pictures(ind).BackColor.G, Pictures(ind).BackColor.B)
                        Colors(ind) = Pictures(ind).BackColor
                    End If
                End If
                End If
        Next
    End Sub
    Private Forceds() As Integer = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
    Private Sub Drop_OBJ_Armor(Obj As BG3_Obj_Template_Class)
        Forceds = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        Dim esta_tiene As Boolean = False
        Dim value0 As List(Of LSLib.LS.Node) = Nothing
        If Obj.NodeLSLIB.ChildCount > 0 AndAlso Obj.NodeLSLIB.Children.TryGetValue("Equipment", value0) Then
            Dim curnodes = value0
            For Each nod In curnodes
                Dim value As List(Of LSLib.LS.Node) = Nothing
                ' Primero de visuals
                If nod.ChildCount > 0 AndAlso nod.Children.TryGetValue("Visuals", value) Then
                    Dim curnodes2 = value
                    For Each nod2 In curnodes2
                        Dim value2 As List(Of LSLib.LS.Node) = Nothing
                        If nod2.ChildCount > 0 AndAlso nod2.Children.TryGetValue("Object", value2) Then
                            Dim curnodes3 = value2
                            For Each nod3 In curnodes3
                                Dim value3 As List(Of LSLib.LS.Node) = Nothing
                                If nod3.ChildCount > 0 AndAlso nod3.Children.TryGetValue("MapValue", value3) Then
                                    For Each nod4 In value3
                                        Dim value4 As LSLib.LS.NodeAttribute = Nothing
                                        If nod4.Attributes.TryGetValue("Object", value4) Then
                                            Dim vis As String = value4.Value.ToString
                                            Dim VisObj As BG3_Obj_VisualBank_Class = Nothing
                                            If FuncionesHelpers.GameEngine.ProcessedVisualBanksList.TryGetValue(vis, VisObj) = True Then
                                                If VisObj.Type = BG3_Enum_VisualBank_Type.VisualBank Then
                                                    esta_tiene = True
                                                    Drop_OBJ_VisualBank1(VisObj)
                                                End If
                                            End If
                                        End If
                                    Next

                                End If
                            Next
                        End If
                    Next
                End If

                ' Despues de visualsSets (overrides)
                If nod.ChildCount > 0 AndAlso nod.Children.TryGetValue("VisualSet", value) Then
                    Dim curnodes2 = value
                    For Each nod2 In curnodes2
                        Dim value2 As List(Of LSLib.LS.Node) = Nothing
                        If nod2.ChildCount > 0 AndAlso nod2.Children.TryGetValue("MaterialOverrides", value2) Then
                            Dim curnodes3 = value2
                            Dim forced As Boolean = False
                            For Each nod3 In curnodes3
                                Dim value3 As List(Of LSLib.LS.Node) = Nothing
                                If nod3.ChildCount > 0 AndAlso nod3.Children.TryGetValue("ColorPreset", value3) Then
                                    For Each nod4 In value3
                                        Dim value4 As LSLib.LS.NodeAttribute = Nothing
                                        Dim force As Boolean = False
                                        Dim groupname As String = ""
                                        Dim matcp As String = ""
                                        If nod4.Attributes.TryGetValue("ForcePresetValues", value4) Then
                                            force = value4.Value
                                        End If
                                        If nod4.Attributes.TryGetValue("GroupName", value4) Then
                                            groupname = value4.Value
                                        End If
                                        If nod4.Attributes.TryGetValue("MaterialPresetResource", value4) Then
                                            matcp = value4.Value
                                        End If
                                        If groupname = "02 Colour" And force = True Then forced = True
                                        If groupname = "02 Colour" Then
                                            Dim VisObj As BG3_Obj_VisualBank_Class = Nothing
                                            If FuncionesHelpers.GameEngine.ProcessedVisualBanksList.TryGetValue(matcp, VisObj) = True Then
                                                If VisObj.Type = BG3_Enum_VisualBank_Type.MaterialPresetBank Then
                                                    esta_tiene = True
                                                    Drop_OBJ_VisualBank1(VisObj)
                                                End If
                                            End If
                                        End If
                                    Next
                                End If
                                If nod3.ChildCount > 0 AndAlso nod3.Children.TryGetValue("MaterialPresets", value3) Then
                                    For Each nod4 In value3
                                        Dim value6 As List(Of LSLib.LS.Node) = Nothing
                                        If nod4.ChildCount > 0 AndAlso nod4.Children.TryGetValue("Object", value6) Then
                                            Dim force As Boolean = False
                                            Dim groupname As String = ""
                                            For Each nod5 In value6
                                                Dim value4 As LSLib.LS.NodeAttribute = Nothing
                                                Dim valuef As LSLib.LS.NodeAttribute = Nothing
                                                If nod5.Attributes.TryGetValue("ForcePresetValues", value4) Then
                                                    force = value4.Value
                                                End If
                                                If nod5.Attributes.TryGetValue("GroupName", value4) Then
                                                    groupname = value4.Value
                                                End If
                                                If groupname = "02 Colour" And force = True Then forced = True
                                                If nod5.Attributes.TryGetValue("MaterialPresetResource", value4) Then
                                                    Dim cual As String = value4.Value
                                                    Dim cpObj As BG3_Obj_VisualBank_Class = Nothing
                                                    If FuncionesHelpers.GameEngine.ProcessedVisualBanksList.TryGetValue(cual, cpObj) = True Then
                                                        esta_tiene = True
                                                        Drop_OBJ_VisualBank2(cpObj)
                                                    End If
                                                End If
                                            Next
                                        End If
                                    Next
                                End If
                                Dim value5 As List(Of LSLib.LS.Node) = Nothing
                                If nod3.ChildCount > 0 AndAlso nod3.Children.TryGetValue("Vector3Parameters", value5) Then
                                    Drop_OBJ(value5, forced)
                                    esta_tiene = True
                                End If
                            Next
                        End If
                    Next
                End If
            Next
        End If

        If esta_tiene = False Then
            If Not IsNothing(Obj.Parent) AndAlso Obj.Parent.Is_Descendant("a09273ba-6549-4cf9-ba47-615a962baf9f") Then
                Drop_OBJ_Armor(Obj.Parent)
            End If
        End If

    End Sub
    Private Sub Label16_DragDrop(sender As Object, e As DragEventArgs) Handles Label16.DragDrop
        If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class))) Then
            Dim obj As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class)))
            If CType(obj.Objeto, BG3_Obj_Template_Class).Is_Descendant("1a750a66-e5c2-40be-9f62-0a4bf3ddb403") Then
                Clear_colors()
                Drop_OBJ(CType(obj.Objeto, BG3_Obj_Template_Class))
            End If
            If CType(obj.Objeto, BG3_Obj_Template_Class).Is_Descendant("a09273ba-6549-4cf9-ba47-615a962baf9f") Then
                Clear_colors()
                Drop_OBJ_Armor(CType(obj.Objeto, BG3_Obj_Template_Class))
            End If
        End If
        If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Stats_Class))) Then
            Dim obj2 As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Stats_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Stats_Class)))
            Dim obj = CType(obj2.Objeto, BG3_Obj_Stats_Class).AssociatedTemplate
            If obj.Is_Descendant("1a750a66-e5c2-40be-9f62-0a4bf3ddb403") Then
                Clear_colors()
                Drop_OBJ(obj)
            End If
            If obj.Is_Descendant("a09273ba-6549-4cf9-ba47-615a962baf9f") Then
                Clear_colors()
                Drop_OBJ_Armor(obj)
            End If
        End If
        If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_VisualBank_Class))) Then
            Dim obj As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_VisualBank_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_VisualBank_Class)))
            If CType(obj.Objeto, BG3_Obj_VisualBank_Class).Type = BG3_Enum_VisualBank_Type.MaterialPresetBank OrElse CType(obj.Objeto, BG3_Obj_VisualBank_Class).Type = BG3_Enum_VisualBank_Type.MaterialBank Then
                Clear_colors()
                Drop_OBJ_VisualBank2(CType(obj.Objeto, BG3_Obj_VisualBank_Class))
            End If
        End If
    End Sub

    Private Sub Label16n_DragEnter(sender As Object, e As DragEventArgs) Handles Label16.DragEnter
        If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class))) Then
            Dim obj As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class)))
            If Not IsNothing(obj.Objeto) Then
                Dim escorrecto As Boolean = False
                If CType(obj.Objeto, BG3_Obj_Template_Class).Is_Descendant("1a750a66-e5c2-40be-9f62-0a4bf3ddb403") Then escorrecto = True ' DYE
                If CType(obj.Objeto, BG3_Obj_Template_Class).Is_Descendant("a09273ba-6549-4cf9-ba47-615a962baf9f") Then escorrecto = True ' Base Armor
                If escorrecto Then
                    e.Effect = DragDropEffects.Copy
                    Exit Sub
                End If
            End If
        End If
        If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Stats_Class))) Then
            Dim obj As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Stats_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Stats_Class)))
            If Not IsNothing(obj.Objeto) AndAlso Not IsNothing(CType(obj.Objeto, BG3_Obj_Stats_Class).AssociatedTemplate) Then
                Dim escorrecto As Boolean = False
                If CType(obj.Objeto, BG3_Obj_Stats_Class).AssociatedTemplate.Is_Descendant("1a750a66-e5c2-40be-9f62-0a4bf3ddb403") Then escorrecto = True ' DYE
                If CType(obj.Objeto, BG3_Obj_Stats_Class).AssociatedTemplate.Is_Descendant("a09273ba-6549-4cf9-ba47-615a962baf9f") Then escorrecto = True ' Base Armor
                If escorrecto Then
                    e.Effect = DragDropEffects.Copy
                    Exit Sub
                End If
            End If
        End If
        If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_VisualBank_Class))) Then
            Dim obj As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_VisualBank_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_VisualBank_Class)))
            If Not IsNothing(obj.Objeto) Then
                If CType(obj.Objeto, BG3_Obj_VisualBank_Class).Type = BG3_Enum_VisualBank_Type.MaterialPresetBank OrElse CType(obj.Objeto, BG3_Obj_VisualBank_Class).Type = BG3_Enum_VisualBank_Type.MaterialBank Then
                    e.Effect = DragDropEffects.Copy
                    Exit Sub
                End If
            End If
        End If
        e.Effect = DragDropEffects.None
    End Sub

    Private Sub Button29_Click(sender As Object, e As EventArgs) Handles Button29.Click
        CopyColors
    End Sub
    Public Sub CopyColors()
        For x = 0 To Colors.Count - 1
            ColorsCopy(x) = Colors(x)
        Next
    End Sub
    Public Sub PasteColors()
        For x = 0 To Colors.Count - 1
            Colors(x) = ColorsCopy(x)
            Pictures(x).BackColor = Colors(x)
            Texts(x).Text = SRGB0_1(Colors(x).R, Colors(x).G, Colors(x).B)
        Next
    End Sub
    Private Sub Button30_Click(sender As Object, e As EventArgs) Handles Button30.Click
        PasteColors
    End Sub

    Private Sub Label16_Click(sender As Object, e As EventArgs) Handles Label16.Click

    End Sub

    Public ReadOnly Property GetValueStr(nam As String) As Color
        Get
            Return Colors(FuncionesHelpers.ColorMaterialsNames.IndexOf(nam))
        End Get
    End Property
    Public ReadOnly Property GetValueStr(Idx As Integer) As Color
        Get
            Return Colors(Idx)
        End Get
    End Property
    Public ReadOnly Property Getcolors() As List(Of Color)
        Get
            Return Colors
        End Get
    End Property

End Class
