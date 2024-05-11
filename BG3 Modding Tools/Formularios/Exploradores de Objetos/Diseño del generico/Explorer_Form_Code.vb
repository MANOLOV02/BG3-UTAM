Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing.Printing
Imports System.IO
Imports System.Net
Imports System.Reflection.Metadata
Imports System.Runtime.CompilerServices
Imports System.Xml
Imports BG3_Modding_Tools.Funciones
Imports BG3_Modding_Tools.FuncionesHelpers
Imports LSLib.Granny
Imports LSLib.LS.Enums

Public Class ExploraForm_code
    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.DoubleBuffered = True

    End Sub
    Public Sub New(ByRef MdiParent As Main)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.MdiParent = MdiParent
        AddHandler MdiParent.BackGroundWorkstarted, AddressOf BackgroundWork_WorkStarted_Sub
        AddHandler MdiParent.BackGroundWorkFinished, AddressOf BackgroundWork_Finished_Sub
        AddHandler MdiParent.BackGroundReport, AddressOf BackgroundWork_Report_SuB
        AddHandler MdiParent.BackGround_SingleTaskEnd, AddressOf BackGround_SingleTaskEnd_sub
        AddHandler MdiParent.BackGround_SingleTaskStart, AddressOf BackGround_SingleTaskStart_sub
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Habilita_deshabilita(True)
    End Sub

    Public Overridable Sub BackgroundWork_WorkStarted_Sub()
        Habilita_deshabilita(False)
    End Sub
    Public Overridable Sub BackgroundWork_Finished_Sub()
        Habilita_deshabilita(True)
    End Sub
    Public Overridable Sub ObjectsTree_InititatedTask(sender As Object, e As DoWorkEventArgs)
        Habilita_deshabilita(False)
    End Sub
    Public Overridable Sub ObjectsTree_FinishedTask(sender As Object, e As RunWorkerCompletedEventArgs)
        Habilita_deshabilita(True)
    End Sub

    Public Overridable Sub BackgroundWork_Report_SuB(sender As Object, e As ProgressChangedEventArgs)
        If IsNothing(MdiParent) Then Exit Sub
        Select Case True
            Case sender Is CType(MdiParent, Main).ProcessWorker
            Case sender Is CType(MdiParent, Main).CacheWorker
        End Select
    End Sub

    Public Overridable Sub BackGround_SingleTaskStart_sub(sender As Object, e As DoWorkEventArgs)
        If IsNothing(MdiParent) Then Exit Sub
        Select Case True
            Case sender Is CType(MdiParent, Main).ProcessWorker
            Case sender Is CType(MdiParent, Main).CacheWorker
        End Select
    End Sub
    Public Overridable Sub BackGround_SingleTaskEnd_sub(sender As Object, e As RunWorkerCompletedEventArgs)
        If IsNothing(MdiParent) Then Exit Sub
        Select Case True
            Case sender Is CType(MdiParent, Main).ProcessWorker
            Case sender Is CType(MdiParent, Main).CacheWorker
        End Select
    End Sub

    Public Overridable Sub Habilita_deshabilita(Habilita As Boolean)
        Me.Enabled = Habilita
    End Sub
    Public Overridable Sub ProcesarPaks_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        RemoveHandler CType(MdiParent, Main).BackGroundWorkstarted, AddressOf BackgroundWork_WorkStarted_Sub
        RemoveHandler CType(MdiParent, Main).BackGroundWorkFinished, AddressOf BackgroundWork_Finished_Sub
        RemoveHandler CType(MdiParent, Main).BackGroundReport, AddressOf BackgroundWork_Report_SuB
        RemoveHandler CType(MdiParent, Main).BackGround_SingleTaskEnd, AddressOf BackGround_SingleTaskEnd_sub
        RemoveHandler CType(MdiParent, Main).BackGround_SingleTaskStart, AddressOf BackGround_SingleTaskStart_sub
    End Sub



End Class
