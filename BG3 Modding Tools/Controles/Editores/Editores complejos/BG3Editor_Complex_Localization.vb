﻿Imports System.DirectoryServices.ActiveDirectory
Imports System.Net
Imports System.Net.Mime.MediaTypeNames
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports LSLib.Granny
Imports LSLib.LS.Story

Public Class BG3Editor_Complex_Localization
    Private ReadOnly dataset As New DataSet
    Private ReadOnly table As New Data.DataTable("Localizations")
    Private Controles_Linkeados As New List(Of BG3_Value_Editor_Generic)

    Private ReadOnly Property ModSource As BG3_Pak_SourceOfResource_Class
        Get
            Return CType(Me.ParentForm, Object).ActiveModSource
        End Get
    End Property

    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim dc As DataColumn
        dc = New DataColumn With {.ColumnName = "PropertyName", .DataType = System.Type.GetType("System.String"), .Unique = True}
        table.Columns.Add(dc)
        dc = New DataColumn With {.ColumnName = "Mapkey", .DataType = System.Type.GetType("System.String"), .Unique = True}
        table.Columns.Add(dc)
        For Each nam In [Enum].GetNames(Of Bg3_Enum_Languages)
            dc = New DataColumn With {.ColumnName = nam, .DataType = System.Type.GetType("System.String")}
            table.Columns.Add(dc)
        Next
        dataset.Tables.Add(table)
        DataGridView1.ShowCellToolTips = False
        AddHandler DataGridView1.Paint, AddressOf FirstPaint
        DataGridView1.DataSource = table
        Oculta_columnas()
    End Sub
    Private Sub FirstPaint(sender As Object, e As PaintEventArgs)
        RemoveHandler DataGridView1.Paint, AddressOf FirstPaint
        ' The datagrid tooltips works poorly - if enabled it will make an unremoveable tooltip
        'DataGridView1.ShowCellToolTips = True
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Oculta_columnas()
    End Sub
    Public Sub Link_Controls(Controles() As BG3Editor_Template_LocalizationBase)
        For Each cont In Controles
            Controles_Linkeados.Add(cont)
            AddHandler cont.Inside_Text_Changed, AddressOf Control_changed
            AddHandler cont.Inside_Checkbox_Changed, AddressOf Control_changed
        Next
    End Sub
    Public Sub Link_Controls(Controles() As BG3Editor_stat_LocalizationBase)
        For Each cont In Controles
            Controles_Linkeados.Add(cont)
            AddHandler cont.Inside_Text_Changed, AddressOf Control_changed
            AddHandler cont.Inside_Checkbox_Changed, AddressOf Control_changed
        Next
    End Sub
    Public Sub Link_Controls(Controles() As BG3Editor_FlagsAndTag_LocalizationBase)
        For Each cont In Controles
            Controles_Linkeados.Add(cont)
            AddHandler cont.Inside_Text_Changed, AddressOf Control_changed
            AddHandler cont.Inside_Checkbox_Changed, AddressOf Control_changed
        Next
    End Sub

    Private Sub Control_changed(quien As BG3_Value_Editor_Generic)
        If table.Select("Mapkey='" + CType(quien, Object).Get_Last_Utam_Handle + "'").Length <> 0 Then
            Dim dr As DataRow = table.Select("Mapkey='" + CType(quien, Object).Get_Last_Utam_Handle + "'").First
            If quien.CheckBox1.Checked = True Then
                dr.Item("English") = quien.Text
            Else
                Dim Loca As String = FuncionesHelpers.GameEngine.ProcessedLocalizationList.Localize(CType(quien, Object).Get_Last_Utam_Handle, Bg3_Enum_Languages.English)
                If Not IsNothing(Loca) Then
                    dr.Item("English") = Loca
                Else
                    dr.Item("English") = quien.Text
                End If

            End If
        End If
        RaiseEvent LocaTextChanged(Me)
    End Sub

    Public Sub Clear()
        table.Clear()
    End Sub

    Public Sub Read_Data(Template As BG3_Obj_Generic_Class)
        If Not IsNothing(Template) Then
            table.BeginLoadData()
            table.Clear()
            For Each cont In Controles_Linkeados
                Dim nr As DataRow = table.NewRow
                Dim key As String = CType(cont, Object).Get_Utam_Handle(Template)
                If key <> "" Then
                    nr.Item("Mapkey") = key
                    nr.Item("PropertyName") = CType(cont, Object).GetPropertyName
                    table.Rows.Add(nr)
                End If
            Next
            table.EndLoadData()
        End If
        LoadLocalizations()
    End Sub
    Public Function Get_Localization(quien As BG3_Value_Editor_Generic, template As BG3_Obj_Generic_Class, lang As Bg3_Enum_Languages) As String
        If quien.EditIsConditional = True AndAlso quien.CheckBox1.Checked = False Then
            Dim hand As String = CType(quien, Object).Get_inherited_Handle(template)
            If FuncionesHelpers.GameEngine.ProcessedLocalizationList.Key_Has_Language(hand, lang) Then
                Return FuncionesHelpers.GameEngine.ProcessedLocalizationList.Localize(hand, lang)
            Else
                If lang <> Bg3_Enum_Languages.English Then Return Get_Localization(quien, template, Bg3_Enum_Languages.English)
            End If
            Return "Unknown"
        Else
            Dim key As String = CType(quien, Object).Get_Utam_Handle(template)
            If key <> "" AndAlso table.Select("Mapkey='" + key + "'").Length <> 0 Then
                Dim dr As DataRow = table.Select("Mapkey='" + key + "'").First
                If IsDBNull(dr.Item(lang.ToString)) = False AndAlso Not IsNothing(dr.Item(lang.ToString)) Then
                    Return dr.Item(lang.ToString)
                Else
                    If lang <> Bg3_Enum_Languages.English Then Return Get_Localization(quien, template, Bg3_Enum_Languages.English)
                End If
            End If
            Return "Unknown"
        End If
    End Function

    Private Sub Oculta_columnas()
        Dim lista = [Enum].GetNames(Of Bg3_Enum_Languages).ToList
        For Each col As DataGridViewColumn In DataGridView1.Columns
            If col.Name = "MapKey" Or col.Name = "English" Or col.Name = "PropertyName" Or CheckBox1.Checked = True Then
                col.Visible = True
            Else
                If lista.IndexOf(col.Name) = FuncionesHelpers.GameEngine.Settings.SelectedLocalization Then
                    col.Visible = True
                Else
                    col.Visible = False
                End If
            End If
        Next
    End Sub

    Private Sub LoadLocalizations()
        For Each nr As DataRow In table.Rows
            Dim lista = [Enum].GetNames(Of Bg3_Enum_Languages).ToList
            For Each nam In lista
                Dim lang As Bg3_Enum_Languages
                If [Enum].TryParse(Of Bg3_Enum_Languages)(nam, lang) = True Then
                    If FuncionesHelpers.GameEngine.ProcessedLocalizationList.Key_Has_Language(nr.Item("MapKey"), lang) Then
                        nr.Item(nam) = FuncionesHelpers.GameEngine.ProcessedLocalizationList.Localize(nr.Item("MapKey"), lang)
                    Else
                        nr.Item(nam) = Nothing
                    End If
                End If
            Next
        Next
    End Sub

    Public Sub Write_Data()
        For Each nr As DataRow In table.Rows
            Dim lista = [Enum].GetNames(Of Bg3_Enum_Languages).ToList
            For Each nam In lista
                Dim lang As Bg3_Enum_Languages
                If [Enum].TryParse(Of Bg3_Enum_Languages)(nam, lang) = True Then
                    Dim objl As BG3_Loca_Localization_Class = Nothing
                    If IsDBNull(nr.Item(nam)) = False AndAlso Not IsNothing(nr.Item(nam)) Then
                        Dim entry As New LSLib.LS.LocalizedText With {.Key = nr.Item("MapKey").split(";")(0), .Version = nr.Item("MapKey").split(";")(1), .Text = nr.Item(nam)}
                        If FuncionesHelpers.GameEngine.ProcessedLocalizationList.TryGetValue(entry.Key, objl) Then
                            objl = FuncionesHelpers.GameEngine.ProcessedLocalizationList(entry.Key)
                            objl.AddSpecific(entry.Version, lang, Bg3_Enum_Genders.Male, Bg3_Enum_GendersTo.M_to_M, entry.Text, ModSource)
                        Else
                            objl = New BG3_Loca_Localization_Class(lang, Bg3_Enum_Genders.Male, Bg3_Enum_GendersTo.M_to_M, entry, ModSource)
                        End If
                        If FuncionesHelpers.GameEngine.ProcessedLocalizationList.TryAdd(objl.Handle, objl) = False Then
                            FuncionesHelpers.GameEngine.ProcessedLocalizationList(objl.Handle) = objl
                        End If
                    End If
                End If
            Next
        Next
    End Sub


    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        RaiseEvent Cell_EndEdit(table.Rows(e.RowIndex)("Mapkey"), table.Rows(e.RowIndex)(e.ColumnIndex))
        RaiseEvent LocaTextChanged(Me)
    End Sub



    Public Event Cell_EndEdit(Mapkey As String, Value As Object)
    Public Event LocaTextChanged(sender As Object)
End Class
