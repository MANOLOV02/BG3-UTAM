Imports System.ComponentModel
Imports System.Diagnostics.Contracts
Imports LSLib.Granny

Public Class ModLoader
    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
    End Sub

    Public WithEvents LoadWorker As New BackgroundWorker With {.WorkerReportsProgress = True, .WorkerSupportsCancellation = True}

    Sub New(mdiparent As Main)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.MdiParent = mdiparent
        AddHandler mdiparent.BackGroundWorkstarted, AddressOf BackgroundWork_WorkStarted_Sub
        AddHandler mdiparent.BackGroundWorkFinished, AddressOf BackgroundWork_Finished_Sub
        AddHandler mdiparent.BackGroundReport, AddressOf BackgroundWork_Report_SuB
        AddHandler mdiparent.BackGround_SingleTaskEnd, AddressOf BackGround_SingleTaskEnd_sub
        AddHandler mdiparent.BackGround_SingleTaskStart, AddressOf BackGround_SingleTaskStart_sub

        AddHandler LoadWorker.ProgressChanged, AddressOf BackgroundWork_Report_SuB
        AddHandler LoadWorker.RunWorkerCompleted, AddressOf BackGround_SingleTaskEnd_sub
        AddHandler LoadWorker.DoWork, AddressOf Load_Mod

        Button1.Enabled = False

        Dim archivos() As String = IO.Directory.GetFiles(FuncionesHelpers.GameEngine.Settings.UTAMModFolder, "*.utam")
        For Each arc In archivos
            ListBox1.Items.Add(IO.Path.GetFileNameWithoutExtension(arc))
        Next

        If ListBox1.Items.Count > 0 Then ListBox1.SelectedIndex = 0
    End Sub

    Public Event Mod_load(ByRef ModLoaded As UtamMod)

    Public Overridable Sub BackgroundWork_WorkStarted_Sub()
        Habilita_deshabilita(False)
    End Sub
    Public Overridable Sub BackgroundWork_Finished_Sub()
        habilita_deshabilita(True)
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
                If e.ProgressPercentage < 0 Then
                    ProgressBarCache.Maximum = -e.ProgressPercentage
                Else
                    ProgressBarCache.Value += e.ProgressPercentage
                End If
            Case sender Is LoadWorker
                Dim progr As BG3_Custom_Progreso_Class = CType(e.UserState, BG3_Custom_Progreso_Class)
                If progr.MaxP2 <> 0 Then ProgressBar1.Value = CDbl(progr.ValueP2 / progr.MaxP2) * 100
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
                LoadWorker.RunWorkerAsync()
            Case sender Is LoadWorker
                If e.Cancelled = False Then
                    Dim ModLoaded = New UtamMod(Me.MdiParent, CurrentMod.Isnew)
                    If CurrentMod.Isnew = False Then ModLoaded.Load_finished(CurrentMod)
                    ModLoaded.Show()
                    RaiseEvent Mod_load(ModLoaded)
                    Me.Close()
                End If
        End Select
    End Sub

    Private Sub Habilita_deshabilita(habilita As Boolean)
        ListBox1.Enabled = habilita
        Button1.Enabled = habilita
        Button2.Enabled = habilita
        Button3.Enabled = habilita
    End Sub
    Private Sub Load_Mod(Worker As Object, e As DoWorkEventArgs)
        If Not IsNothing(CurrentMod) AndAlso CurrentMod.Isnew = False Then
            Funciones.Lee_UtamMod(IO.Path.Combine(FuncionesHelpers.GameEngine.Settings.UTAMModFolder, CurrentMod.SaveFolder), LoadWorker, RadioButton2.Checked)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ListBox1.SelectedIndex = -1 Then Exit Sub
        If CheckBox1.Checked Then
            CType(Me.MdiParent, Main).LoadCache()
        Else
            LoadWorker.RunWorkerAsync()
        End If
    End Sub

    Private CurrentMod As Utam_CurrentModClass
    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedIndex = -1 Then Exit Sub
        Dim filename As String = IO.Path.Combine(FuncionesHelpers.GameEngine.Settings.UTAMModFolder, ListBox1.Items(ListBox1.SelectedIndex).ToString + ".utam")
        CurrentMod = System.Text.Json.JsonSerializer.Deserialize(IO.File.ReadAllText(filename), GetType(Utam_CurrentModClass), FuncionesHelpers.Jsonoptions)
        CurrentMod.Isnew = False
        Button2.Enabled = CurrentMod.SaveFolder <> ""
        Dim path = IO.Path.Combine(IO.Path.GetDirectoryName(filename), CurrentMod.SaveFolder)
        Dim source As BG3_Pak_SourceOfResource_Class
        Dim moduselected As BG3_Mod_Module_Class = Nothing
        For Each meta In IO.Directory.GetFiles(path, "*.*", IO.SearchOption.AllDirectories).Where(Function(pf) pf.EndsWith("meta.lsx", StringComparison.OrdinalIgnoreCase))
            source = New BG3_Pak_SourceOfResource_Class(path, meta)
            Dim recurso = (source).ReadResource
            If Not IsNothing(recurso) Then
                Try
                    Dim rec = recurso.Regions("Config").Children("ModuleInfo").First
                    Dim UUID As String = rec.Attributes("UUID").Value
                    If UUID = CurrentMod.SaveUUID Then
                        moduselected = New BG3_Mod_Module_Class With {.SourceOfResource = source}
                        moduselected.Update(recurso)

                        Exit For
                    End If
                Catch ex As Exception

                End Try
            End If
        Next

        If Not IsNothing(moduselected) Then
            CurrentMod.ModLsx = moduselected
            CurrentMod.Versionconverter = LSLib.LS.PackedVersion.FromInt64(CurrentMod.ModLsx.Version)
            TextBoxName.Text = CurrentMod.ModLsx.Name
            TextBoxFolder.Text = CurrentMod.ModLsx.Folder
            TextBoxDescription.Text = CurrentMod.ModLsx.Description
            TextBoxAuthor.Text = CurrentMod.ModLsx.Author
            TextBoxUUID.Text = CurrentMod.ModLsx.UUID
            TextBoxVersion.Text = CurrentMod.ModLsx.Version.ToString + " (" + CurrentMod.Versionconverter.Major.ToString + "." + CurrentMod.Versionconverter.Minor.ToString + "." + CurrentMod.Versionconverter.Revision.ToString + "." + CurrentMod.Versionconverter.Build.ToString + ")"
            Button1.Enabled = True
        Else
            TextBoxName.Text = ""
            TextBoxFolder.Text = ""
            TextBoxDescription.Text = ""
            TextBoxAuthor.Text = ""
            TextBoxUUID.Text = ""
            TextBoxVersion.Text = ""
            Button1.Enabled = False
        End If
    End Sub

    Private Sub ModLoader_Closing(sender As Object, e As CancelEventArgs) Handles MyBase.Closing
        If LoadWorker.IsBusy Then
            e.Cancel = True
            Exit Sub
        End If

        RemoveHandler CType(MdiParent, Main).BackGroundWorkstarted, AddressOf BackgroundWork_WorkStarted_Sub
        RemoveHandler CType(MdiParent, Main).BackGroundWorkFinished, AddressOf BackgroundWork_Finished_Sub
        RemoveHandler CType(MdiParent, Main).BackGroundReport, AddressOf BackgroundWork_Report_SuB
        RemoveHandler CType(MdiParent, Main).BackGround_SingleTaskEnd, AddressOf BackGround_SingleTaskEnd_sub
        RemoveHandler CType(MdiParent, Main).BackGround_SingleTaskStart, AddressOf BackGround_SingleTaskStart_sub
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        CurrentMod = New Utam_CurrentModClass With {.Isnew = True}
        If CheckBox1.Checked Then
            CType(Me.MdiParent, Main).LoadCache()
        Else
            LoadWorker.RunWorkerAsync()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Not IsNothing(CurrentMod) AndAlso CurrentMod.SaveFolder <> "" Then
            Dim path = IO.Path.Combine(FuncionesHelpers.GameEngine.Settings.UTAMModFolder, CurrentMod.SaveFolder)
            If IO.Directory.Exists(path) Then
                Try
                    System.Diagnostics.Process.Start("explorer.exe", path)
                Catch ex As Exception
                End Try
            End If
        End If
    End Sub
End Class