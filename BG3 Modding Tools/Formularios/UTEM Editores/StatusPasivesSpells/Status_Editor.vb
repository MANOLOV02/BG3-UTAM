Public Class Status_Editor
    Protected Overrides Property Stattype As BG3_Enum_StatType = BG3_Enum_StatType.StatusData
    Protected Overrides ReadOnly Property UtamType As BG3_Enum_UTAM_Type = BG3_Enum_UTAM_Type.Status
    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Public Sub New(ByRef MdiParent As Main, Source As BG3_Pak_SourceOfResource_Class)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Initialize(MdiParent, Source)
    End Sub
    Protected Overrides Sub Initialize_Specifics()
    End Sub

    Protected Overrides Sub Create_Initial_Specific(ByRef nuevonod As BG3_Obj_Stats_Class)

    End Sub
    Protected Overrides Sub Habilita_Edicion_Botones_Specific(Edicion As Boolean)
    End Sub
    Protected Overrides Sub Process_Selection_Change_specific()
        If Not IsNothing(SelectedTmp) Then


        Else

        End If
    End Sub
    Protected Overrides Sub Process_Save_Edits_Specifics()

    End Sub

    Protected Overrides Sub Create_Stat_Transfers_Specific(ByRef Lista As List(Of ToolStripMenuItem))
        'Lista.AddRange(
        '    {New ToolStripMenuItem("Texture specific|Height|False|Attribute", Nothing, AddressOf BG3Selector_Visuals1.TransferSibligsClick) With {.Tag = {"Height"}},
        '    New ToolStripMenuItem("Texture specific|Width|False|Attribute", Nothing, AddressOf BG3Selector_Visuals1.TransferSibligsClick) With {.Tag = {"Width"}},
        '    New ToolStripMenuItem("Texture specific|SRGB|True|Attribute", Nothing, AddressOf BG3Selector_Visuals1.TransferSibligsClick) With {.Tag = {"SRGB"}},
        '    New ToolStripMenuItem("Texture specific|Type|True|Attribute", Nothing, AddressOf BG3Selector_Visuals1.TransferSibligsClick) With {.Tag = {"Type"}},
        '    New ToolStripMenuItem("Texture specific|Format|True|Attribute", Nothing, AddressOf BG3Selector_Visuals1.TransferSibligsClick) With {.Tag = {"Format"}},
        '    New ToolStripMenuItem("Texture specific|Localized|True|Attribute", Nothing, AddressOf BG3Selector_Visuals1.TransferSibligsClick) With {.Tag = {"Localized"}},
        '    New ToolStripMenuItem("Texture specific|Depth|True|Attribute", Nothing, AddressOf BG3Selector_Visuals1.TransferSibligsClick) With {.Tag = {"Depth"}},
        '    New ToolStripMenuItem("Texture specific|Streaming|True|Attribute", Nothing, AddressOf BG3Selector_Visuals1.TransferSibligsClick) With {.Tag = {"Streaming"}}
        '    })

    End Sub
    Protected Overrides Sub Transfer_stats_specifics(Template As BG3_Obj_Stats_Class, statsList() As String)
        For Each stat In statsList
            Select Case stat
                'Case "Height"
                '    BG3Editor_Texture_Height1.Read(Template)
                '    BG3Editor_Texture_Height1.Write(SelectedTmp)
                'Case "Width"
                '    BG3Editor_Texture_Width1.Read(Template)
                '    BG3Editor_Texture_Width1.Write(SelectedTmp)
                'Case "SRGB"
                '    BG3Editor_Visuals_srgb1.Read(Template)
                '    BG3Editor_Visuals_srgb1.Write(SelectedTmp)
                'Case "Type"
                '    BG3Editor_Texture_Type1.Read(Template)
                '    BG3Editor_Texture_Type1.Write(SelectedTmp)
                'Case "Format"
                '    BG3Editor_Texture_Format1.Read(Template)
                '    BG3Editor_Texture_Format1.Write(SelectedTmp)
                'Case "Localized"
                '    BG3Editor_Visuals_Localized1.Read(Template)
                '    BG3Editor_Visuals_Localized1.Write(SelectedTmp)
                'Case "Depth"
                '    BG3Editor_Texture_Depth1.Read(Template)
                '    BG3Editor_Texture_Depth1.Write(SelectedTmp)
                'Case "Streaming"
                '    BG3Editor_Visuals_Streaming1.Read(Template)
                '    BG3Editor_Visuals_Streaming1.Write(SelectedTmp)
            End Select
        Next
    End Sub
    Protected Overrides Sub Capture_Clone_specific(obj As BG3_Obj_Stats_Class, tipo As BG3Cloner.Clonetype)
        Select Case tipo
            Case BG3Cloner.Clonetype.Clone
                'BG3Editor_Textures_iD_Fixed1.Replace_Attribute(Clone_Nuevonod, Template_guid)
                'BG3Editor_Textures_Name1.Replace_Attribute(Clone_Nuevonod, obj.Name + "_Cloned")
            Case BG3Cloner.Clonetype.Override
                'BG3Editor_Textures_iD_Fixed1.Replace_Attribute(Clone_Nuevonod, obj.MapKey)
                'BG3Editor_Textures_Name1.Replace_Attribute(Clone_Nuevonod, obj.Name + "_Overrided")
        End Select

    End Sub
End Class