﻿Imports System.Drawing.Printing
Imports BG3_Modding_Tools.FuncionesHelpers
Public Class Information_Form_TreasureTables

    Private LastObject As BG3_Obj_TreasureTable_Class = Nothing
    Sub New(MdiParent As Main, ObjectExplorer As BG3Explorer_TreasureTables)
        MyBase.New(MdiParent, ObjectExplorer)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.DoubleBuffered = True

    End Sub
    Sub New(MdiParent As Main, UtamMod As Explorer_Form_TreasureTables)
        MyBase.New(MdiParent, UtamMod)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Public Overrides Sub Explorer_Hide_Unhide(Show As Boolean)
        Me.Visible = Show
        If Me.Visible Then Pone_info(LastObject)
    End Sub

    Public Overrides Sub Pone_info(obj As Object)
        Pone_info(CType(obj, BG3_Obj_TreasureTable_Class))
    End Sub
    Public Overloads Sub Pone_info(obj As BG3_Obj_TreasureTable_Class)
        LastObject = obj
        If Me.Visible = False Then Exit Sub
        Cursor.Current = Cursors.WaitCursor
        XmLtoRichText2.Text = "Loading..."
        If IsNothing(obj) Then
            XmLtoRichText2.Text = "Not found"
        Else
            XmLtoRichText2.Process_Ttable(obj)
        End If
        Cursor.Current = Cursors.Default
    End Sub



End Class