﻿Imports System.Drawing.Printing
Imports BG3_Modding_Tools.FuncionesHelpers
Public Class Template_Information_Form

    Private LastObject As BG3_Obj_Template_Class = Nothing
    Sub New(ByRef MdiParent As Main, ByRef ObjectExplorer As Explorer_Form_Templates)
        MyBase.New(MdiParent, ObjectExplorer)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.DoubleBuffered = True

    End Sub
    Public Overrides Sub Explorer_Hide_Unhide(Show As Boolean)
        Me.Visible = Show
        If Me.Visible Then Pone_info(LastObject)
    End Sub
    Public Overrides Sub Pone_info(obj As Object)
        Pone_info(CType(obj, BG3_Obj_Template_Class))
    End Sub
    Public Overloads Sub Pone_info(obj As BG3_Obj_Template_Class)
        LastObject = obj
        If Me.Visible = False Then Exit Sub
        Cursor.Current = Cursors.WaitCursor
        PictureBoxIcon.Image = Nothing
        XmLtoRichText1.Text = "Loading..."
        XmLtoRichText2.Text = "Loading..."
        XmLtoRichText3.Text = "Loading..."
        XmLtoRichText4.Text = "Loading..."
        If IsNothing(obj) Then
            LabelInfoName.Text = "Name: Not selected"
            LabelInfoDisplayName.Text = "Display Name:"
            LabelInfoIcon.Text = "Icon:"
            LabelInfoModule.Text = "Module:"
            LabelInfoPack.Text = "Pack:"
            LabelInfoStats.Text = "Stats:"
            PictureBoxIcon.Image = Nothing
            XmLtoRichText1.Text = "Not found"
            XmLtoRichText2.Text = "Not found"
            XmLtoRichText3.Text = "Not found"
        Else
            LabelInfoName.Text = "Name: " + obj.Name.TryGetOrEmpty
            LabelInfoDisplayName.Text = "Display Name: " + obj.DisplayName.TryGetOrEmpty
            LabelInfoIcon.Text = "Icon: " + obj.Icon.TryGetOrEmpty
            LabelInfoModule.Text = "Module: " + obj.SourceOfResorce.ModFolder.TryGetOrEmpty
            If obj.SourceOfResorce.PackageType = BG3_Enum_Package_Type.Loose_Files Then
                LabelInfoPack.Text = "Pack: " + "Loose files"
            Else
                LabelInfoPack.Text = "Pack: " + obj.SourceOfResorce.Pak_Or_Folder.TryGetOrEmpty
            End If

            XmLtoRichText1.Process_Gameobject(obj)

            If IsNothing(obj.AssociatedStats) Then
                LabelInfoStats.Text = "Stats: None"
                XmLtoRichText2.Text = "No associated stats"
            Else
                LabelInfoStats.Text = "Stats: " + obj.AssociatedStats.Name.TryGetOrEmpty
                XmLtoRichText2.Process_Stat(obj.AssociatedStats, GameEngine.ProcessedStatList)
            End If

            XmLtoRichText3.Process_Metas(obj)

            XmLtoRichText5.Process_Tags(obj.Get_Tags_TXT)
            BG3Visualizer_xml1.Process_Attributes(obj.Get_Attributes_TXT)


            Dim visual As BG3_Obj_VisualBank_Class = Nothing
            If IsNothing(CType(obj, BG3_Obj_Template_Class).ReadAttribute_Or_Inhterithed("VisualTemplate")) OrElse GameEngine.ProcessedVisualBanksList.TryGetValue(obj.ReadAttribute_Or_Inhterithed("VisualTemplate"), visual) = False Then
                XmLtoRichText4.Text = "No associated visual template"
            Else
                XmLtoRichText4.Process_XML(visual.NodeXML)
            End If

            If IsNothing(obj.Icon) = False OrElse obj.Icon <> "" Then
                Pinta_Icon(obj)
            Else
                PictureBoxIcon.Image = Nothing
            End If

        End If
        Cursor.Current = Cursors.Default
    End Sub
    Private Sub Pinta_Icon(obj As BG3_Obj_Template_Class)
        PictureBoxIcon.Image = Nothing

        If GameEngine.ProcessedIcons.Containskey(obj.Icon) = True Then
            PictureBoxIcon.Image = GameEngine.ProcessedIcons(obj.Icon).Get_Icon_FromAtlass_or_File
        End If
    End Sub


End Class