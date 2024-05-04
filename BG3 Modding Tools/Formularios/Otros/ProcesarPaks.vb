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

Public Class ProcesarPaks

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Public Sub New(ByRef MdiParent As Main)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.MdiParent = MdiParent
        AddHandler MdiParent.BackGroundWorkstarted, AddressOf BackgroundWork_WorkStarted
        AddHandler MdiParent.BackGroundWorkFinished, AddressOf BackgroundWork_Finished
        AddHandler MdiParent.BackGroundReport, AddressOf BackgroundWork_Report
        AddHandler MdiParent.BackGround_SingleTaskEnd, AddressOf BackGround_SingleTaskEnd
        AddHandler MdiParent.BackGround_SingleTaskStart, AddressOf BackGround_SingleTaskStart
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TreeViewPacks.Nodes.AddRange(GameEngine.ProcessedPackList.ReprocessNodes)
        TextBoxGameFolder.Text = GameEngine.Settings.GameExeFolder
        TextBoxModFolder.Text = GameEngine.Settings.GameModFolder
        TextBoxUTAMModFolder.Text = GameEngine.Settings.UTAMModFolder
        TextBoxUTAMCacheFolder.Text = GameEngine.Settings.UTAMCacheFolder
        Habilita_deshabilita(True)
    End Sub

    Public Sub BackgroundWork_WorkStarted()
        Habilita_deshabilita(False)
    End Sub
    Public Sub BackgroundWork_Finished()
        TreeViewPacks.Nodes.Clear()
        TreeViewPacks.Nodes.AddRange(GameEngine.ProcessedPackList.ReprocessNodes)
        Habilita_deshabilita(True)
    End Sub
    Private Sub ObjectsTree_InititatedTask(sender As Object, e As DoWorkEventArgs)
        Habilita_deshabilita(False)
    End Sub
    Private Sub ObjectsTree_FinishedTask(sender As Object, e As RunWorkerCompletedEventArgs)
        Habilita_deshabilita(True)
    End Sub

    Private Sub BackgroundWork_Report(sender As Object, e As ProgressChangedEventArgs)
        Select Case True
            Case sender Is CType(MdiParent, Main).ProcessWorker
                Dim progr As BG3_Custom_Progreso_Class = CType(e.UserState, BG3_Custom_Progreso_Class)
                If progr.MaxP1 <> 0 Then ProgressBarPacks.Value = CDbl(progr.ValueP1 / progr.MaxP1) * 100
                If progr.MaxP2 <> 0 Then ProgressBarFiles.Value = CDbl(progr.ValueP2 / progr.MaxP2) * 100
            Case sender Is CType(MdiParent, Main).CacheWorker
                If e.ProgressPercentage < 0 Then
                    ProgressBarCache.Maximum = -e.ProgressPercentage
                    ProgressBarCache.Value = 0
                Else
                    ProgressBarCache.Value += e.ProgressPercentage
                End If
        End Select
    End Sub

    Private Sub BackGround_SingleTaskStart(sender As Object, e As DoWorkEventArgs)
        Select Case True
            Case sender Is CType(MdiParent, Main).ProcessWorker
            Case sender Is CType(MdiParent, Main).CacheWorker
        End Select

    End Sub
    Private Sub BackGround_SingleTaskEnd(sender As Object, e As RunWorkerCompletedEventArgs)
        Select Case True
            Case sender Is CType(MdiParent, Main).ProcessWorker
                ProgressBarPacks.Value = 0
                ProgressBarFiles.Value = 0
            Case sender Is CType(MdiParent, Main).CacheWorker
                ProgressBarCache.Value = 0
        End Select
    End Sub

    Public Sub Habilita_deshabilita(Habilita As Boolean)
        ButtonProcess.Enabled = False
        Dim cheks As Boolean = GameEngine.CheckFolders
        If GameEngine.Check_folders_GameExe Then
            Label1.Image = Small_Ok
        Else
            Label1.Image = Small_No_Ok
        End If
        If GameEngine.Check_folders_GameMods Then
            Label2.Image = Small_Ok
        Else
            Label2.Image = Small_No_Ok
        End If

        If GameEngine.Check_folders_UtamMods Then
            Label3.Image = Small_Ok
        Else
            Label3.Image = Small_No_Ok
        End If

        If GameEngine.Check_folders_UtamCache Then
            Label4.Image = Small_Ok
        Else
            Label4.Image = Small_No_Ok
        End If

        TextBoxGameFolder.Enabled = Habilita
        TextBoxModFolder.Enabled = Habilita
        TextBoxUTAMModFolder.Enabled = Habilita
        TextBoxUTAMCacheFolder.Enabled = Habilita

        Button2.Enabled = Habilita
        Button3.Enabled = Habilita
        Button4.Enabled = Habilita
        Button1.Enabled = Habilita

        ButtonProcess.Enabled = Habilita And cheks
        CheckBoxIncludeMods.Enabled = Habilita And cheks
        TreeViewPacks.Enabled = Habilita And cheks
        ButtonClearCache.Enabled = Habilita And cheks

        If Habilita = False Then
            ButtonLoadCache.Enabled = Habilita And cheks
        Else
            ButtonLoadCache.Enabled = CType(MdiParent, Main).CanLoadCache And cheks
        End If


    End Sub
    Private Sub ProcesarPaks_Closing(sender As Object, e As CancelEventArgs) Handles MyBase.Closing
        If CType(MdiParent, Main).BackgroundTasks > 0 Then
            e.Cancel = True
            CType(MdiParent, Main).CancellButton.PerformClick()
            Exit Sub
        End If

        RemoveHandler CType(MdiParent, Main).BackGroundWorkstarted, AddressOf BackgroundWork_WorkStarted
        RemoveHandler CType(MdiParent, Main).BackGroundWorkFinished, AddressOf BackgroundWork_Finished
        RemoveHandler CType(MdiParent, Main).BackGroundReport, AddressOf BackgroundWork_Report
        RemoveHandler CType(MdiParent, Main).BackGround_SingleTaskEnd, AddressOf BackGround_SingleTaskEnd
        RemoveHandler CType(MdiParent, Main).BackGround_SingleTaskStart, AddressOf BackGround_SingleTaskStart

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ButtonProcess.Click
        CType(Me.MdiParent, Main).Processpacks(CheckBoxIncludeMods.Checked)
    End Sub
    Private Sub ButtonClearCache_Click(sender As Object, e As EventArgs) Handles ButtonClearCache.Click
        CType(Me.MdiParent, Main).ClearCache()
    End Sub

    Private Sub ButtonLoadCache_Click(sender As Object, e As EventArgs) Handles ButtonLoadCache.Click
        CType(Me.MdiParent, Main).LoadCache()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim openfold As New FolderBrowserDialog With {.SelectedPath = GameEngine.Settings.GameExeFolder}
        If openfold.ShowDialog = DialogResult.OK Then
            GameEngine.Settings.GameExeFolder = openfold.SelectedPath
            TextBoxGameFolder.Text = openfold.SelectedPath
        End If
        Habilita_deshabilita(True)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim openfold As New FolderBrowserDialog With {.SelectedPath = GameEngine.Settings.GameModFolder}
        If openfold.ShowDialog = DialogResult.OK Then
            GameEngine.Settings.GameModFolder = openfold.SelectedPath
            TextBoxModFolder.Text = openfold.SelectedPath
        End If
        Habilita_deshabilita(True)
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim openfold As New FolderBrowserDialog With {.SelectedPath = GameEngine.Settings.UTAMModFolder}
        If openfold.ShowDialog = DialogResult.OK Then
            GameEngine.Settings.UTAMModFolder = openfold.SelectedPath
            TextBoxUTAMModFolder.Text = openfold.SelectedPath
        End If
        Habilita_deshabilita(True)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim openfold As New FolderBrowserDialog With {.SelectedPath = GameEngine.Settings.UTAMCacheFolder}
        If openfold.ShowDialog = DialogResult.OK Then
            GameEngine.Settings.UTAMCacheFolder = openfold.SelectedPath
            TextBoxUTAMCacheFolder.Text = openfold.SelectedPath
        End If
        Habilita_deshabilita(True)
    End Sub
End Class
