Imports System.Diagnostics
Imports System.IO
Imports System.IO.Compression
Imports System.Linq
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Xml.Linq

Public Class Form1
    Private Enum OperationMode
        CloneSingleSet = 0
        MergeAddMaterial = 1
        ReplaceTexturesOnly = 2
        DeleteMaterial = 3
    End Enum

    Private Class MergeTemplateResult
        Public Property NewTemplateGuid As String
        Public Property SourceStatsId As String
        Public Property SourceHandleH1 As String
        Public Property SourceHandleH2 As String
        Public Property SourceHandleH3 As String
        Public Property NewHandleH1 As String
        Public Property NewHandleH2 As String
        Public Property NewHandleH3 As String
        Public ReadOnly Property RemovedStatsIds As New List(Of String)()
        Public ReadOnly Property RemovedLocaHandles As New List(Of String)()
    End Class

    Private Class DeleteMaterialResult
        Public ReadOnly Property RemovedTemplateGuids As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        Public ReadOnly Property RemovedStatsIds As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        Public ReadOnly Property RemovedLocaHandles As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
    End Class

    Private _selectedModFolderPath As String
    Private _selectedZipPath As String

    Private Shared ReadOnly TextExtensions As HashSet(Of String) =
        New HashSet(Of String)(StringComparer.OrdinalIgnoreCase) From {".lsx", ".xml", ".txt", ".bat"}
    Private Shared ReadOnly ShaderExtensions As HashSet(Of String) =
        New HashSet(Of String)(StringComparer.OrdinalIgnoreCase) From {".bshd", ".shd"}

    Private Sub AppendLog(message As String, Optional level As String = "INFO")
        If txtLog Is Nothing Then
            Return
        End If

        Dim line = $"[{Date.Now:HH:mm:ss}] [{level}] {message}"
        txtLog.AppendText(line & Environment.NewLine)
    End Sub

    Private Function GetModeDisplayName(mode As OperationMode) As String
        Select Case mode
            Case OperationMode.CloneSingleSet
                Return "CLONE"
            Case OperationMode.MergeAddMaterial
                Return "MERGE"
            Case OperationMode.ReplaceTexturesOnly
                Return "REEMPLAZO"
            Case OperationMode.DeleteMaterial
                Return "BORRAR"
            Case Else
                Return "PROCESO"
        End Select
    End Function

    Private Sub SetReadyVisualState(isReady As Boolean, mode As OperationMode, targetFolder As String, validationMessage As String)
        If Not isReady Then
            lblValidation.ForeColor = Color.FromArgb(154, 47, 26)
            lblValidation.BackColor = Color.FromArgb(255, 238, 233)
            lblValidation.Text = validationMessage
            lblProcessType.Text = "PENDIENTE DE DATOS"
            lblProcessType.BackColor = Color.FromArgb(240, 240, 240)
            lblProcessType.ForeColor = Color.FromArgb(70, 70, 70)
            Return
        End If

        Dim statusText As String
        Dim statusBack As Color
        Dim statusFore As Color = Color.FromArgb(30, 30, 30)

        Select Case mode
            Case OperationMode.CloneSingleSet
                Dim willRegenerate = Directory.Exists(targetFolder)
                If willRegenerate Then
                    statusText = "CLONE | REGENERAR CARPETA"
                    statusBack = Color.FromArgb(255, 225, 225)
                    lblValidation.ForeColor = Color.FromArgb(140, 30, 30)
                    lblValidation.BackColor = Color.FromArgb(255, 225, 225)
                    lblValidation.Text = "Atencion: se regenerara la carpeta destino (limpieza total)."
                Else
                    statusText = "CLONE | CARPETA NUEVA"
                    statusBack = Color.FromArgb(219, 245, 227)
                    lblValidation.ForeColor = Color.FromArgb(31, 123, 52)
                    lblValidation.BackColor = Color.FromArgb(219, 245, 227)
                    lblValidation.Text = validationMessage
                End If
            Case OperationMode.MergeAddMaterial
                statusText = "MERGE | SOBRE CARPETA EXISTENTE"
                statusBack = Color.FromArgb(255, 245, 204)
                lblValidation.ForeColor = Color.FromArgb(118, 90, 11)
                lblValidation.BackColor = Color.FromArgb(255, 245, 204)
                lblValidation.Text = validationMessage
            Case OperationMode.ReplaceTexturesOnly
                statusText = "REEMPLAZO | SOLO TEXTURAS"
                statusBack = Color.FromArgb(255, 245, 204)
                lblValidation.ForeColor = Color.FromArgb(118, 90, 11)
                lblValidation.BackColor = Color.FromArgb(255, 245, 204)
                lblValidation.Text = validationMessage
            Case OperationMode.DeleteMaterial
                statusText = "BORRAR | SOBRE CARPETA EXISTENTE"
                statusBack = Color.FromArgb(255, 225, 225)
                lblValidation.ForeColor = Color.FromArgb(140, 30, 30)
                lblValidation.BackColor = Color.FromArgb(255, 225, 225)
                lblValidation.Text = validationMessage
            Case Else
                statusText = "PROCESO"
                statusBack = Color.FromArgb(240, 240, 240)
                lblValidation.ForeColor = Color.FromArgb(70, 70, 70)
                lblValidation.BackColor = Color.FromArgb(240, 240, 240)
                lblValidation.Text = validationMessage
        End Select

        lblProcessType.Text = statusText
        lblProcessType.BackColor = statusBack
        lblProcessType.ForeColor = statusFore
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbMode.Items.Clear()
        cmbMode.Items.Add("Clone: dejar solo el material del ZIP")
        cmbMode.Items.Add("Merge: agregar material al mod")
        cmbMode.Items.Add("Reemplazar texturas: solo PNG/DDS")
        cmbMode.Items.Add("Borrar material: quitar un set existente del mod")
        cmbMode.SelectedIndex = 0

        txtSelectedFolder.Text = "No seleccionada"
        AppendLog("Aplicacion iniciada.")
        UpdateState()
    End Sub

    Private Sub btnBrowseFolder_Click(sender As Object, e As EventArgs) Handles btnBrowseFolder.Click
        Using dialog As New FolderBrowserDialog()
            dialog.Description = "Selecciona la carpeta del mod origen"

            If dialog.ShowDialog(Me) = DialogResult.OK AndAlso Directory.Exists(dialog.SelectedPath) Then
                _selectedModFolderPath = dialog.SelectedPath
                txtSelectedFolder.Text = _selectedModFolderPath

                Dim folderName = New DirectoryInfo(_selectedModFolderPath).Name
                txtSourceMaterial.Text = GuessMaterialFromFolderName(folderName)
                AppendLog($"Carpeta origen seleccionada: {_selectedModFolderPath}")
            End If
        End Using

        UpdateState()
    End Sub

    Private Sub pnlZipDrop_Click(sender As Object, e As EventArgs) Handles pnlZipDrop.Click, lblZipDrop.Click
        ChooseZipWithDialog()
    End Sub

    Private Sub pnlZipDrop_DragEnter(sender As Object, e As DragEventArgs) Handles pnlZipDrop.DragEnter
        If HasValidZipInDrop(e) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub pnlZipDrop_DragDrop(sender As Object, e As DragEventArgs) Handles pnlZipDrop.DragDrop
        If Not e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Return
        End If

        Dim files = DirectCast(e.Data.GetData(DataFormats.FileDrop), String())
        Dim firstZip = files.FirstOrDefault(Function(path) IsValidZipPath(path))

        If String.IsNullOrWhiteSpace(firstZip) Then
            MessageBox.Show(Me, "Debes soltar un archivo .zip valido.", "ZIP invalido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        SetZipPath(firstZip)
    End Sub

    Private Sub txtSourceMaterial_TextChanged(sender As Object, e As EventArgs) Handles txtSourceMaterial.TextChanged
        UpdateState()
    End Sub

    Private Sub txtTargetMaterial_TextChanged(sender As Object, e As EventArgs) Handles txtTargetMaterial.TextChanged
        UpdateState()
    End Sub

    Private Sub cmbMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMode.SelectedIndexChanged
        AppendLog($"Modo seleccionado: {GetModeDisplayName(GetSelectedMode())}")
        UpdateState()
    End Sub

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        Dim validationMessage As String = String.Empty
        Dim targetFolder As String = String.Empty

        If Not CanGenerate(validationMessage, targetFolder) Then
            Return
        End If

        Try
            Cursor = Cursors.WaitCursor
            btnGenerate.Enabled = False

            Dim sourceFolderName = New DirectoryInfo(_selectedModFolderPath).Name
            Dim targetMaterialTechnical = SanitizeTechnicalName(txtTargetMaterial.Text.Trim())
            Dim sourceMaterialTechnical = SanitizeTechnicalName(txtSourceMaterial.Text.Trim())
            Dim mode = GetSelectedMode()
            Dim targetModFolderName As String
            Dim destinationRoot As String
            Dim preservedCloneUuid As String = String.Empty
            Dim destinationExistedBeforeClone As Boolean = False
            AppendLog($"Inicio de proceso: {GetModeDisplayName(mode)}", "RUN")
            AppendLog($"Origen: {_selectedModFolderPath}")
            If mode <> OperationMode.DeleteMaterial Then
                AppendLog($"ZIP: {_selectedZipPath}")
            End If

            If mode = OperationMode.CloneSingleSet Then
                targetModFolderName = BuildCloneFolderName(sourceFolderName, sourceMaterialTechnical, targetMaterialTechnical)
                destinationRoot = Path.Combine(Directory.GetParent(_selectedModFolderPath).FullName, targetModFolderName)
            Else
                targetModFolderName = sourceFolderName
                destinationRoot = _selectedModFolderPath
            End If
            AppendLog($"Destino: {destinationRoot}")

            If mode = OperationMode.DeleteMaterial Then
                DeleteMaterialFromMod(destinationRoot, targetModFolderName, targetMaterialTechnical)
                CleanupRedundantBinaryPairs(destinationRoot)
                EnsureStatsTreasureConsistency(destinationRoot, targetModFolderName)
                AppendLog("Proceso de borrado finalizado correctamente.", "OK")

                MessageBox.Show(
                    Me,
                    $"Proceso finalizado ({mode}).{Environment.NewLine}{Environment.NewLine}Destino: {destinationRoot}",
                    "OK",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information)
                Return
            End If

            If mode = OperationMode.CloneSingleSet AndAlso IsSamePath(destinationRoot, _selectedModFolderPath) Then
                Throw New InvalidOperationException("Seguridad: el destino del clone coincide con la carpeta origen. Cancela y revisa nombres.")
            End If

            If mode = OperationMode.CloneSingleSet AndAlso Directory.Exists(destinationRoot) Then
                destinationExistedBeforeClone = True
                preservedCloneUuid = TryReadModUuidFromMeta(destinationRoot, targetModFolderName)
                If String.IsNullOrWhiteSpace(preservedCloneUuid) Then
                    Throw New InvalidOperationException("No se pudo leer el UUID del mod existente para preservarlo durante la sobreescritura.")
                End If
                AppendLog("Destino existente detectado. Se solicitara confirmacion para regenerar carpeta.", "WARN")
                Cursor = Cursors.Default
                Dim overwrite = MessageBox.Show(
                    Me,
                    "La carpeta destino ya existe." & Environment.NewLine &
                    "Si continuas, se eliminara completamente antes de clonar." & Environment.NewLine & Environment.NewLine &
                    destinationRoot,
                    "Confirmar sobreescritura",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning)

                If overwrite <> DialogResult.Yes Then
                    AppendLog("Proceso cancelado por usuario al confirmar sobreescritura.", "WARN")
                    Return
                End If

                Cursor = Cursors.WaitCursor
                Directory.Delete(destinationRoot, True)
                AppendLog("Carpeta destino eliminada para regeneracion.", "WARN")
            End If

            CloneModFromZip(
                _selectedModFolderPath,
                _selectedZipPath,
                destinationRoot,
                sourceMaterialTechnical,
                targetMaterialTechnical,
                sourceFolderName,
                targetModFolderName,
                mode,
                preservedCloneUuid,
                Not destinationExistedBeforeClone)
            AppendLog("Proceso finalizado correctamente.", "OK")

            MessageBox.Show(
                Me,
                $"Proceso finalizado ({mode}).{Environment.NewLine}{Environment.NewLine}Destino: {destinationRoot}",
                "OK",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)
        Catch ex As Exception
            AppendLog(ex.Message, "ERR")
            MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
            UpdateState()
        End Try
    End Sub

    Private Sub ChooseZipWithDialog()
        Using dialog As New OpenFileDialog()
            dialog.Filter = "Archivos ZIP (*.zip)|*.zip"
            dialog.Multiselect = False
            dialog.Title = "Selecciona el ZIP del material"

            If dialog.ShowDialog(Me) = DialogResult.OK Then
                SetZipPath(dialog.FileName)
            End If
        End Using
    End Sub

    Private Sub SetZipPath(zipPath As String)
        _selectedZipPath = zipPath
        lblZipDrop.Text = _selectedZipPath
        AppendLog($"ZIP seleccionado: {_selectedZipPath}")

        Dim detectedFromZip = GetZipRootTechnicalName(zipPath)
        If Not String.IsNullOrWhiteSpace(detectedFromZip) Then
            txtTargetMaterial.Text = detectedFromZip
        ElseIf String.IsNullOrWhiteSpace(txtTargetMaterial.Text) Then
            txtTargetMaterial.Text = Path.GetFileNameWithoutExtension(zipPath)
        End If

        UpdateState()
    End Sub

    Private Sub UpdateState()
        If String.IsNullOrWhiteSpace(_selectedModFolderPath) Then
            txtSelectedFolder.Text = "No seleccionada"
        End If

        If String.IsNullOrWhiteSpace(_selectedZipPath) Then
            lblZipDrop.Text = "Suelta aqui el ZIP o haz click para elegir"
        End If

        Dim validationMessage As String = String.Empty
        Dim targetFolder As String = String.Empty

        Dim mode = GetSelectedMode()
        Dim zipRequired = mode <> OperationMode.DeleteMaterial
        lblZip.Enabled = zipRequired
        pnlZipDrop.Enabled = zipRequired
        lblZipDrop.Enabled = zipRequired
        If zipRequired Then
            lblZip.Text = "2) ZIP del material (drag && drop)"
            lblTargetMaterial.Text = "4) Nuevo material (desde el ZIP)"
        Else
            lblZip.Text = "2) ZIP del material (no se usa en borrar)"
            lblTargetMaterial.Text = "4) Material a borrar (tecnico)"
        End If
        lblTargetFolderCaption.Text = GetModeTargetCaption(mode)
        btnGenerate.Text = GetModeButtonText(mode)

        If CanGenerate(validationMessage, targetFolder) Then
            lblTargetFolderValue.Text = targetFolder
            btnGenerate.Enabled = True
            SetReadyVisualState(True, mode, targetFolder, validationMessage)
            Return
        End If

        lblTargetFolderValue.Text = If(String.IsNullOrWhiteSpace(targetFolder), "-", targetFolder)
        btnGenerate.Enabled = False
        SetReadyVisualState(False, mode, targetFolder, validationMessage)
    End Sub

    Private Function CanGenerate(ByRef validationMessage As String, ByRef targetFolder As String) As Boolean
        validationMessage = String.Empty
        targetFolder = String.Empty
        Dim mode = GetSelectedMode()

        If String.IsNullOrWhiteSpace(_selectedModFolderPath) OrElse Not Directory.Exists(_selectedModFolderPath) Then
            validationMessage = "Selecciona una carpeta de mod valida."
            Return False
        End If

        If mode <> OperationMode.DeleteMaterial AndAlso Not IsValidZipPath(_selectedZipPath) Then
            validationMessage = "Selecciona o suelta un archivo .zip valido."
            Return False
        End If

        Dim targetMaterialName = SanitizeTechnicalName(txtTargetMaterial.Text.Trim())
        If String.IsNullOrWhiteSpace(targetMaterialName) Then
            validationMessage = "Ingresa el nombre tecnico del material objetivo."
            Return False
        End If

        Dim sourceMaterialName = SanitizeTechnicalName(txtSourceMaterial.Text.Trim())
        If mode <> OperationMode.ReplaceTexturesOnly AndAlso
           mode <> OperationMode.DeleteMaterial AndAlso
           String.IsNullOrWhiteSpace(sourceMaterialName) Then
            validationMessage = "Indica el material original del mod base."
            Return False
        End If

        Dim sourceFolderName = New DirectoryInfo(_selectedModFolderPath).Name
        Dim parentDirectory = Directory.GetParent(_selectedModFolderPath)?.FullName

        If String.IsNullOrWhiteSpace(parentDirectory) Then
            validationMessage = "No se pudo resolver el directorio destino."
            Return False
        End If

        If mode = OperationMode.MergeAddMaterial Then
            targetFolder = _selectedModFolderPath
            validationMessage = "Todo valido. El merge se aplicara sobre la carpeta origen."
            Return True
        End If

        If mode = OperationMode.ReplaceTexturesOnly Then
            targetFolder = _selectedModFolderPath
            validationMessage = "Todo valido. Solo se reemplazaran PNG/DDS del material objetivo."
            Return True
        End If

        If mode = OperationMode.DeleteMaterial Then
            targetFolder = _selectedModFolderPath
            validationMessage = "Todo valido. Se eliminaran solo las entradas del material indicado."
            Return True
        End If

        Dim cloneFolderName = BuildCloneFolderName(sourceFolderName, sourceMaterialName, targetMaterialName)
        targetFolder = Path.Combine(parentDirectory, cloneFolderName)

        If Directory.Exists(targetFolder) Then
            validationMessage = "Destino existente: al generar pedira confirmacion para limpiar y sobreescribir."
            Return True
        End If

        validationMessage = "Todo valido. Puedes generar el clone."
        Return True
    End Function

    Private Function GetSelectedMode() As OperationMode
        Select Case cmbMode.SelectedIndex
            Case 0
                Return OperationMode.CloneSingleSet
            Case 1
                Return OperationMode.MergeAddMaterial
            Case 2
                Return OperationMode.ReplaceTexturesOnly
            Case 3
                Return OperationMode.DeleteMaterial
            Case Else
                Return OperationMode.CloneSingleSet
        End Select
    End Function

    Private Function GetModeButtonText(mode As OperationMode) As String
        Select Case mode
            Case OperationMode.CloneSingleSet
                Return "Generar clone"
            Case OperationMode.MergeAddMaterial
                Return "Generar merge"
            Case OperationMode.ReplaceTexturesOnly
                Return "Reemplazar texturas"
            Case OperationMode.DeleteMaterial
                Return "Borrar material"
            Case Else
                Return "Generar"
        End Select
    End Function

    Private Function GetModeTargetCaption(mode As OperationMode) As String
        Select Case mode
            Case OperationMode.CloneSingleSet
                Return "Carpeta destino propuesta:"
            Case OperationMode.MergeAddMaterial
                Return "Destino de merge:"
            Case OperationMode.ReplaceTexturesOnly
                Return "Destino de texturas:"
            Case OperationMode.DeleteMaterial
                Return "Destino de borrado:"
            Case Else
                Return "Destino:"
        End Select
    End Function

    Private Function HasValidZipInDrop(e As DragEventArgs) As Boolean
        If Not e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Return False
        End If

        Dim files = DirectCast(e.Data.GetData(DataFormats.FileDrop), String())
        Return files.Any(Function(path) IsValidZipPath(path))
    End Function

    Private Function IsValidZipPath(filePath As String) As Boolean
        If String.IsNullOrWhiteSpace(filePath) Then
            Return False
        End If

        Return File.Exists(filePath) AndAlso String.Equals(Path.GetExtension(filePath), ".zip", StringComparison.OrdinalIgnoreCase)
    End Function

    Private Function IsSamePath(pathA As String, pathB As String) As Boolean
        If String.IsNullOrWhiteSpace(pathA) OrElse String.IsNullOrWhiteSpace(pathB) Then
            Return False
        End If

        Dim fullA = Path.GetFullPath(pathA).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)
        Dim fullB = Path.GetFullPath(pathB).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)
        Return String.Equals(fullA, fullB, StringComparison.OrdinalIgnoreCase)
    End Function

    Private Function TryReadModUuidFromMeta(modRoot As String, modFolderName As String) As String
        Try
            Dim metaPath = Path.Combine(modRoot, "Mods", modFolderName, "meta.lsx")
            If Not File.Exists(metaPath) Then
                Return String.Empty
            End If

            Dim metaDoc = XDocument.Load(metaPath)
            Return metaDoc.Descendants("attribute").
                Where(Function(a) String.Equals(CStr(a.Attribute("id")), "UUID", StringComparison.OrdinalIgnoreCase)).
                Select(Function(a) CStr(a.Attribute("value"))).
                FirstOrDefault()
        Catch
            Return String.Empty
        End Try
    End Function

    Private Function BuildCloneFolderName(sourceFolderName As String, sourceMaterialName As String, newMaterialName As String) As String
        If String.IsNullOrWhiteSpace(sourceFolderName) Then
            Return newMaterialName
        End If

        Dim sanitizedSource = sourceFolderName.Trim()

        If String.Equals(sanitizedSource, newMaterialName, StringComparison.OrdinalIgnoreCase) Then
            Return $"{newMaterialName}_Clone"
        End If

        If Not String.IsNullOrWhiteSpace(sourceMaterialName) Then
            Dim escaped = Regex.Escape(sourceMaterialName.Trim())
            Dim replaced = Regex.Replace(sanitizedSource, escaped, newMaterialName, RegexOptions.IgnoreCase)

            If Not String.Equals(replaced, sanitizedSource, StringComparison.Ordinal) Then
                Return replaced
            End If
        End If

        Return sanitizedSource & "_" & newMaterialName
    End Function

    Private Function GuessMaterialFromFolderName(folderName As String) As String
        If String.IsNullOrWhiteSpace(folderName) Then
            Return String.Empty
        End If

        Dim trimmed = folderName.Trim()
        Dim firstUnderscore = trimmed.IndexOf("_"c)
        If firstUnderscore >= 0 AndAlso firstUnderscore < trimmed.Length - 1 Then
            Return trimmed.Substring(firstUnderscore + 1).Trim()
        End If

        Return trimmed
    End Function

    Private Function SanitizeTechnicalName(value As String) As String
        If String.IsNullOrWhiteSpace(value) Then
            Return String.Empty
        End If

        Dim normalized = Regex.Replace(value.Trim(), "[^A-Za-z0-9_]+", "_")
        normalized = Regex.Replace(normalized, "_+", "_")
        Return normalized.Trim("_"c)
    End Function

    Private Function ToVisibleName(technical As String) As String
        If String.IsNullOrWhiteSpace(technical) Then
            Return String.Empty
        End If

        Return Regex.Replace(technical.Replace("_", " "), "\s+", " ").Trim()
    End Function

    Private Function GetZipRootTechnicalName(zipPath As String) As String
        Try
            Using archive = ZipFile.OpenRead(zipPath)
                Dim firstEntry = archive.Entries.
                    Select(Function(e) e.FullName).
                    FirstOrDefault(Function(full) Not String.IsNullOrWhiteSpace(full))

                If String.IsNullOrWhiteSpace(firstEntry) Then
                    Return String.Empty
                End If

                Dim parts = firstEntry.Split("/"c, StringSplitOptions.RemoveEmptyEntries)
                If parts.Length = 0 Then
                    Return String.Empty
                End If

                Return SanitizeTechnicalName(parts(0))
            End Using
        Catch
            Return String.Empty
        End Try
    End Function

    Private Sub CloneModFromZip(sourceRoot As String,
                                zipPath As String,
                                destinationRoot As String,
                                sourceMaterialTechnical As String,
                                targetMaterialTechnical As String,
                                sourceFolderName As String,
                                targetModFolderName As String,
                                mode As OperationMode,
                                preservedCloneUuid As String,
                                generateNewCloneUuid As Boolean)

        Dim sourceVisible = DetectSourceVisibleName(sourceRoot, sourceMaterialTechnical)
        Dim targetVisible = ToVisibleName(targetMaterialTechnical)
        AppendLog($"Resolviendo nombres: origen='{sourceMaterialTechnical}', objetivo='{targetMaterialTechnical}'.", "STEP")

        If mode = OperationMode.CloneSingleSet Then
            AppendLog("Creando estructura base del clone y copiando subset del mod origen.", "STEP")
            Directory.CreateDirectory(destinationRoot)
            Dim replacements = BuildReplacements(sourceFolderName, targetModFolderName, sourceMaterialTechnical, targetMaterialTechnical, sourceVisible, targetVisible)
            CopySourceSubset(sourceRoot, destinationRoot, replacements)
        End If

        Dim tempExtractPath = Path.Combine(Path.GetTempPath(), "ModReplicator_" & Guid.NewGuid().ToString("N"))
        Directory.CreateDirectory(tempExtractPath)
        AppendLog($"Extrayendo ZIP temporalmente en: {tempExtractPath}", "STEP")

        Try
            ZipFile.ExtractToDirectory(zipPath, tempExtractPath)

            Dim zipRoot = ResolveZipRootDirectory(tempExtractPath)
            Dim zipMaterialTechnical = SanitizeTechnicalName(New DirectoryInfo(zipRoot).Name)
            Dim zipVisible = DetectZipVisibleName(zipRoot, zipMaterialTechnical)
            AppendLog($"ZIP detectado: material='{zipMaterialTechnical}', visible='{zipVisible}'.", "STEP")

            OverlayZipPngs(zipRoot, destinationRoot, targetModFolderName, zipMaterialTechnical, targetMaterialTechnical)
            AppendLog("Texturas PNG aplicadas y DDS previo removido para regeneracion.", "STEP")

            If mode = OperationMode.ReplaceTexturesOnly Then
                AppendLog("Modo reemplazo: ejecutando conversion DDS y finalizando sin tocar LSX/Template.", "STEP")
                RunConversionBatIfPresent(destinationRoot, targetModFolderName)
                Return
            End If

            Dim destinationSharedMaterialsPath = GetSharedMaterialsLsxPath(destinationRoot, targetModFolderName)
            Dim oldMapSharedMaterialsPath = destinationSharedMaterialsPath
            If mode = OperationMode.CloneSingleSet Then
                oldMapSharedMaterialsPath = GetSharedMaterialsLsxPath(sourceRoot, sourceFolderName)
            End If

            Dim oldRaceToMaterialId = BuildRaceToMaterialIdMap(oldMapSharedMaterialsPath, sourceMaterialTechnical)
            Dim oldRaceToVisualId = BuildRaceToVisualIdMap(oldMapSharedMaterialsPath, sourceMaterialTechnical)

            Dim originResourceIds As HashSet(Of String) = Nothing
            If mode = OperationMode.CloneSingleSet Then
                Dim sourceSharedMaterialsPath = GetSharedMaterialsLsxPath(sourceRoot, sourceFolderName)
                originResourceIds = CollectSharedMaterialsResourceIds(sourceSharedMaterialsPath)
            End If

            AppendLog("Inyectando LSX de textura/material/visual bank con relink de IDs.", "STEP")
            InjectZipLsx(
                zipRoot,
                destinationRoot,
                targetModFolderName,
                targetMaterialTechnical,
                targetVisible,
                zipMaterialTechnical,
                zipVisible,
                mode,
                originResourceIds)
            If mode = OperationMode.CloneSingleSet Then
                NormalizeUtamGroupInDestination(destinationRoot, targetVisible)
                AppendLog("Normalizando UTAM_Group y relinkeando referencias de RootTemplate (material/visual).", "STEP")
            End If

            Dim newRaceToMaterialId = BuildRaceToMaterialIdMap(destinationSharedMaterialsPath, targetMaterialTechnical)
            Dim newRaceToVisualId = BuildRaceToVisualIdMap(destinationSharedMaterialsPath, targetMaterialTechnical)

            If mode = OperationMode.CloneSingleSet Then
                RemapRootTemplateMaterialReferences(destinationRoot, targetModFolderName, oldRaceToMaterialId, newRaceToMaterialId)
                RemapRootTemplateMaterialReferences(destinationRoot, targetModFolderName, oldRaceToVisualId, newRaceToVisualId)
                Dim cloneLink = NormalizeRootTemplateForClone(destinationRoot, targetModFolderName, targetMaterialTechnical, targetVisible)
                If cloneLink IsNot Nothing Then
                    NormalizeStatsAndTreasureForClone(destinationRoot, targetModFolderName, cloneLink.Item1, cloneLink.Item2)
                End If
                SyncCloneLocalizationWithNewIds(
                    destinationRoot,
                    targetModFolderName,
                    sourceMaterialTechnical,
                    targetMaterialTechnical,
                    sourceVisible,
                    targetVisible)
                AppendLog("Clone: stats/treasure/localizacion sincronizados.", "STEP")
            Else
                Dim mergeLink = DuplicateRootTemplateForMerge(
                    destinationRoot,
                    targetModFolderName,
                    sourceMaterialTechnical,
                    targetMaterialTechnical,
                    targetVisible,
                    oldRaceToMaterialId,
                    newRaceToMaterialId,
                    oldRaceToVisualId,
                    newRaceToVisualId)

                If mergeLink IsNot Nothing Then
                    DuplicateStatsAndTreasureForMerge(
                        destinationRoot,
                        targetModFolderName,
                        mergeLink.NewTemplateGuid,
                        mergeLink.SourceStatsId,
                        mergeLink.RemovedStatsIds)

                    SyncMergeLocalizationWithNewIds(
                        destinationRoot,
                        targetModFolderName,
                        sourceMaterialTechnical,
                        targetMaterialTechnical,
                        sourceVisible,
                        targetVisible,
                        mergeLink)
                End If
                AppendLog("Merge: template, stats, treasure y localizacion actualizados.", "STEP")
            End If

            CleanupRedundantBinaryPairs(destinationRoot)
            EnsureTemplateLocalizationCoverage(destinationRoot, targetModFolderName)
            EnsureStatsTreasureConsistency(destinationRoot, targetModFolderName)
            RunConversionBatIfPresent(destinationRoot, targetModFolderName)
            If mode = OperationMode.CloneSingleSet Then
                WriteUtamConfigForClone(destinationRoot, targetModFolderName, targetVisible, preservedCloneUuid, generateNewCloneUuid)
            End If
            AppendLog("Limpieza final de pares binarios y conversion DDS completadas.", "STEP")
        Finally
            Try
                Directory.Delete(tempExtractPath, True)
            Catch
                ' Best effort cleanup.
            End Try
        End Try
    End Sub

    Private Function BuildReplacements(sourceFolderName As String,
                                       targetModFolderName As String,
                                       sourceMaterialTechnical As String,
                                       targetMaterialTechnical As String,
                                       sourceVisible As String,
                                       targetVisible As String) As List(Of KeyValuePair(Of String, String))

        Dim pairs As New List(Of KeyValuePair(Of String, String)) From {
            New KeyValuePair(Of String, String)(sourceFolderName, targetModFolderName),
            New KeyValuePair(Of String, String)(sourceMaterialTechnical, targetMaterialTechnical),
            New KeyValuePair(Of String, String)(ToVisibleName(sourceMaterialTechnical), targetVisible)
        }

        If Not String.IsNullOrWhiteSpace(sourceVisible) Then
            pairs.Add(New KeyValuePair(Of String, String)(sourceVisible, targetVisible))
        End If

        Return pairs.
            Where(Function(p) Not String.IsNullOrWhiteSpace(p.Key) AndAlso Not String.IsNullOrWhiteSpace(p.Value)).
            OrderByDescending(Function(p) p.Key.Length).
            ToList()
    End Function

    Private Function CopySourceSubset(sourceRoot As String,
                                      destinationRoot As String,
                                      replacements As List(Of KeyValuePair(Of String, String))) As List(Of String)

        Dim copiedTextFiles As New List(Of String)()
        Dim sourceFiles = Directory.GetFiles(sourceRoot, "*", SearchOption.AllDirectories)

        For Each sourceFile In sourceFiles
            Dim relativePath = Path.GetRelativePath(sourceRoot, sourceFile)
            Dim extension = Path.GetExtension(sourceFile)

            If Not ShouldCopySourceFile(relativePath, extension) Then
                Continue For
            End If

            Dim destinationRelative = ApplyReplacements(relativePath, replacements)
            Dim destinationFile = Path.Combine(destinationRoot, destinationRelative)
            Dim destinationDir = Path.GetDirectoryName(destinationFile)
            If Not String.IsNullOrWhiteSpace(destinationDir) Then
                Directory.CreateDirectory(destinationDir)
            End If

            If TextExtensions.Contains(extension) Then
                Dim content = File.ReadAllText(sourceFile)
                content = ApplyReplacements(content, replacements)
                File.WriteAllText(destinationFile, content, Encoding.UTF8)
                copiedTextFiles.Add(destinationFile)
            Else
                File.Copy(sourceFile, destinationFile, True)
            End If
        Next

        Return copiedTextFiles
    End Function

    Private Function ShouldCopySourceFile(relativePath As String, extension As String) As Boolean
        If TextExtensions.Contains(extension) Then
            Return True
        End If

        If ShaderExtensions.Contains(extension) Then
            Return True
        End If

        If String.Equals(extension, ".loca", StringComparison.OrdinalIgnoreCase) Then
            Return True
        End If

        Dim normalized = relativePath.Replace("/", "\")
        Return normalized.IndexOf("\Assets\Cloned\", StringComparison.OrdinalIgnoreCase) >= 0
    End Function

    Private Function ApplyReplacements(input As String, replacements As IEnumerable(Of KeyValuePair(Of String, String))) As String
        Dim output = input

        For Each pair In replacements
            output = Regex.Replace(output, Regex.Escape(pair.Key), pair.Value, RegexOptions.IgnoreCase)
        Next

        Return output
    End Function

    Private Function DetectSourceVisibleName(sourceRoot As String, fallbackTechnical As String) As String
        Dim lsxFiles = Directory.GetFiles(sourceRoot, "*.lsx", SearchOption.AllDirectories)

        For Each filePath In lsxFiles
            Dim content = File.ReadAllText(filePath)
            Dim match = Regex.Match(content, "<attribute\s+id=""UTAM_Group""[^>]*value=""([^""]+)""", RegexOptions.IgnoreCase)
            If match.Success Then
                Return match.Groups(1).Value.Trim()
            End If
        Next

        Return ToVisibleName(fallbackTechnical)
    End Function

    Private Function DetectZipVisibleName(zipRoot As String, fallbackTechnical As String) As String
        Dim lsxPath = Directory.GetFiles(zipRoot, "*.lsx", SearchOption.AllDirectories).
            FirstOrDefault(Function(p) p.EndsWith("_only.lsx", StringComparison.OrdinalIgnoreCase))

        If String.IsNullOrWhiteSpace(lsxPath) Then
            Return ToVisibleName(fallbackTechnical)
        End If

        Dim content = File.ReadAllText(lsxPath)
        Dim match = Regex.Match(content, "<attribute\s+id=""UTAM_Group""[^>]*value=""([^""]+)""", RegexOptions.IgnoreCase)
        If match.Success Then
            Return match.Groups(1).Value.Trim()
        End If

        Return ToVisibleName(fallbackTechnical)
    End Function

    Private Function ResolveZipRootDirectory(extractPath As String) As String
        Dim dirs = Directory.GetDirectories(extractPath)
        If dirs.Length = 1 Then
            Return dirs(0)
        End If

        Return extractPath
    End Function

    Private Sub OverlayZipPngs(zipRoot As String,
                               destinationRoot As String,
                               targetModFolderName As String,
                               zipMaterialTechnical As String,
                               targetMaterialTechnical As String)

        Dim zipPngDir = Path.Combine(zipRoot, "Textures", "PNG")
        If Not Directory.Exists(zipPngDir) Then
            Return
        End If

        Dim targetAssetsDir = Path.Combine(destinationRoot, "Generated", "Public", targetModFolderName, "Assets")
        Directory.CreateDirectory(targetAssetsDir)

        For Each pngFile In Directory.GetFiles(zipPngDir, "*.png", SearchOption.TopDirectoryOnly)
            Dim name = Path.GetFileNameWithoutExtension(pngFile)
            Dim renamed = Regex.Replace(name, Regex.Escape(zipMaterialTechnical), targetMaterialTechnical, RegexOptions.IgnoreCase)
            Dim destinationFile = Path.Combine(targetAssetsDir, renamed & ".png")
            File.Copy(pngFile, destinationFile, True)

            Dim destinationDds = Path.Combine(targetAssetsDir, renamed & ".dds")
            If File.Exists(destinationDds) Then
                File.Delete(destinationDds)
            End If
        Next
    End Sub

    Private Sub InjectZipLsx(zipRoot As String,
                             destinationRoot As String,
                             targetModFolderName As String,
                             targetMaterialTechnical As String,
                             targetVisibleName As String,
                             zipMaterialTechnical As String,
                             zipVisibleName As String,
                             mode As OperationMode,
                             originResourceIds As HashSet(Of String))

        Dim zipLsxPath = Directory.GetFiles(Path.Combine(zipRoot, "Generated", "LSX"), "*.lsx", SearchOption.TopDirectoryOnly).
            FirstOrDefault()

        If String.IsNullOrWhiteSpace(zipLsxPath) Then
            Return
        End If

        Dim destinationLsxPath = Directory.GetFiles(
            Path.Combine(destinationRoot, "Public", targetModFolderName, "Content", "Assets", "Characters", "[PAK]_Shared_Materials"),
            "*.lsx",
            SearchOption.TopDirectoryOnly).FirstOrDefault()

        If String.IsNullOrWhiteSpace(destinationLsxPath) Then
            Return
        End If

        Dim zipDoc = XDocument.Load(zipLsxPath)
        Dim dstDoc = XDocument.Load(destinationLsxPath)

        Dim bankIds As String() = {"TextureBank", "MaterialBank", "VisualBank"}
        Dim bankPairs As New List(Of Tuple(Of XElement, XElement))()

        For Each bankId In bankIds
            Dim zipChildren = GetBankChildrenNode(zipDoc, bankId)
            Dim dstChildren = GetBankChildrenNode(dstDoc, bankId)
            If zipChildren IsNot Nothing AndAlso dstChildren IsNot Nothing Then
                bankPairs.Add(Tuple.Create(zipChildren, dstChildren))
            End If
        Next

        If bankPairs.Count = 0 Then
            Return
        End If

        For Each pair In bankPairs
            Dim dstChildren = pair.Item2
            Dim existingResourceNodes = dstChildren.Elements("node").
                Where(Function(n) String.Equals(CStr(n.Attribute("id")), "Resource", StringComparison.OrdinalIgnoreCase)).
                ToList()

            For Each node In existingResourceNodes
                If mode = OperationMode.CloneSingleSet Then
                    If IsUtamManagedResource(node) Then
                        node.Remove()
                    End If
                Else
                    Dim nameValue = GetNodeAttributeValue(node, "Name")
                    Dim templateValue = GetNodeAttributeValue(node, "Template")
                    Dim sourceValue = GetNodeAttributeValue(node, "SourceFile")

                    If ContainsEquivalent(nameValue, targetMaterialTechnical, targetVisibleName) OrElse
                       ContainsEquivalent(templateValue, targetMaterialTechnical, targetVisibleName) OrElse
                       ContainsEquivalent(sourceValue, targetMaterialTechnical, targetVisibleName) Then
                        node.Remove()
                    End If
                End If
            Next
        Next

        Dim pendingAdds As New List(Of Tuple(Of XElement, XElement))()
        For Each pair In bankPairs
            Dim zipChildren = pair.Item1
            Dim dstChildren = pair.Item2

            Dim zipResourceNodes = zipChildren.Elements("node").
                Where(Function(n) String.Equals(CStr(n.Attribute("id")), "Resource", StringComparison.OrdinalIgnoreCase)).
                Select(Function(n) New XElement(n)).
                ToList()

            For Each node In zipResourceNodes
                pendingAdds.Add(Tuple.Create(node, dstChildren))
            Next
        Next

        If pendingAdds.Count = 0 Then
            dstDoc.Save(destinationLsxPath)
            Return
        End If

        Dim idRemap As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)
        If mode = OperationMode.CloneSingleSet Then
            If originResourceIds Is Nothing Then
                originResourceIds = New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
            End If

            Dim occupiedIds As New HashSet(Of String)(originResourceIds, StringComparer.OrdinalIgnoreCase)
            For Each pair In bankPairs
                For Each existingNode In pair.Item2.Elements("node").
                    Where(Function(n) String.Equals(CStr(n.Attribute("id")), "Resource", StringComparison.OrdinalIgnoreCase))
                    Dim existingId = GetNodeAttributeValue(existingNode, "ID")
                    If Not String.IsNullOrWhiteSpace(existingId) Then
                        occupiedIds.Add(existingId)
                    End If
                Next
            Next

            For Each pair In pendingAdds
                Dim resourceNode = pair.Item1
                Dim oldId = GetNodeAttributeValue(resourceNode, "ID")
                If String.IsNullOrWhiteSpace(oldId) Then
                    Continue For
                End If

                If idRemap.ContainsKey(oldId) Then
                    Continue For
                End If

                Dim mustRemap = occupiedIds.Contains(oldId)
                If mustRemap Then
                    Dim newId = Guid.NewGuid().ToString()
                    While occupiedIds.Contains(newId)
                        newId = Guid.NewGuid().ToString()
                    End While

                    idRemap(oldId) = newId
                    occupiedIds.Add(newId)
                Else
                    occupiedIds.Add(oldId)
                End If
            Next
        End If

        For Each pair In pendingAdds
            Dim resourceNode = pair.Item1

            For Each attributeElement In resourceNode.Descendants("attribute")
                Dim valueAttr = attributeElement.Attribute("value")
                If valueAttr Is Nothing Then
                    Continue For
                End If

                Dim updated = valueAttr.Value
                updated = Regex.Replace(updated, Regex.Escape(zipMaterialTechnical), targetMaterialTechnical, RegexOptions.IgnoreCase)
                updated = Regex.Replace(updated, Regex.Escape("Utam_Bodysuit_Collection"), targetModFolderName, RegexOptions.IgnoreCase)
                If Not String.IsNullOrWhiteSpace(zipVisibleName) Then
                    updated = Regex.Replace(updated, Regex.Escape(zipVisibleName), targetVisibleName, RegexOptions.IgnoreCase)
                End If

                If idRemap.ContainsKey(updated) Then
                    updated = idRemap(updated)
                End If

                valueAttr.Value = updated
            Next
        Next

        For Each pair In pendingAdds
            pair.Item2.Add(pair.Item1)
        Next

        dstDoc.Save(destinationLsxPath)
    End Sub

    Private Function CollectSharedMaterialsResourceIds(sharedMaterialsLsxPath As String) As HashSet(Of String)
        Dim ids As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        If String.IsNullOrWhiteSpace(sharedMaterialsLsxPath) OrElse Not File.Exists(sharedMaterialsLsxPath) Then
            Return ids
        End If

        Dim doc = XDocument.Load(sharedMaterialsLsxPath)
        Dim bankIds As String() = {"TextureBank", "MaterialBank", "VisualBank"}

        For Each bankId In bankIds
            Dim children = GetBankChildrenNode(doc, bankId)
            If children Is Nothing Then
                Continue For
            End If

            For Each node In children.Elements("node").
                Where(Function(n) String.Equals(CStr(n.Attribute("id")), "Resource", StringComparison.OrdinalIgnoreCase))
                Dim idValue = GetNodeAttributeValue(node, "ID")
                If Not String.IsNullOrWhiteSpace(idValue) Then
                    ids.Add(idValue)
                End If
            Next
        Next

        Return ids
    End Function

    Private Function GetBankChildrenNode(doc As XDocument, bankId As String) As XElement
        Dim bankRegion = doc.Descendants("region").
            FirstOrDefault(Function(r) String.Equals(CStr(r.Attribute("id")), bankId, StringComparison.OrdinalIgnoreCase))

        If bankRegion Is Nothing Then
            Return Nothing
        End If

        Dim bankNode = bankRegion.Descendants("node").
            FirstOrDefault(Function(n) String.Equals(CStr(n.Attribute("id")), bankId, StringComparison.OrdinalIgnoreCase))

        If bankNode Is Nothing Then
            Return Nothing
        End If

        Return bankNode.Element("children")
    End Function

    Private Function GetNodeAttributeValue(node As XElement, id As String) As String
        Dim attrNode = node.Elements("attribute").
            FirstOrDefault(Function(a) String.Equals(CStr(a.Attribute("id")), id, StringComparison.OrdinalIgnoreCase))

        If attrNode Is Nothing Then
            Return String.Empty
        End If

        Dim valueAttr = attrNode.Attribute("value")
        If valueAttr Is Nothing Then
            Return String.Empty
        End If

        Return valueAttr.Value
    End Function

    Private Function ContainsEquivalent(value As String, targetMaterialTechnical As String, targetVisibleName As String) As Boolean
        If String.IsNullOrWhiteSpace(value) Then
            Return False
        End If

        If value.IndexOf(targetMaterialTechnical, StringComparison.OrdinalIgnoreCase) >= 0 Then
            Return True
        End If

        If Not String.IsNullOrWhiteSpace(targetVisibleName) AndAlso value.IndexOf(targetVisibleName, StringComparison.OrdinalIgnoreCase) >= 0 Then
            Return True
        End If

        Return False
    End Function

    Private Function IsUtamManagedResource(node As XElement) As Boolean
        Dim utamGroup = GetNodeAttributeValue(node, "UTAM_Group")
        If Not String.IsNullOrWhiteSpace(utamGroup) Then
            Return True
        End If

        Dim utamType = GetNodeAttributeValue(node, "UTAM_Type")
        If utamType = "6" OrElse utamType = "7" OrElse utamType = "8" Then
            Return True
        End If

        Return False
    End Function

    Private Function GetSharedMaterialsLsxPath(destinationRoot As String, targetModFolderName As String) As String
        Dim dirPath = Path.Combine(destinationRoot, "Public", targetModFolderName, "Content", "Assets", "Characters", "[PAK]_Shared_Materials")
        If Not Directory.Exists(dirPath) Then
            Return String.Empty
        End If

        Return Directory.GetFiles(dirPath, "*.lsx", SearchOption.TopDirectoryOnly).FirstOrDefault()
    End Function

    Private Function BuildRaceToMaterialIdMap(sharedMaterialsLsxPath As String, materialTechnicalToken As String) As Dictionary(Of String, String)
        Return BuildRaceToResourceIdMap(sharedMaterialsLsxPath, materialTechnicalToken, "MaterialBank", "7")
    End Function

    Private Function BuildRaceToVisualIdMap(sharedMaterialsLsxPath As String, materialTechnicalToken As String) As Dictionary(Of String, String)
        Return BuildRaceToResourceIdMap(sharedMaterialsLsxPath, materialTechnicalToken, "VisualBank", "8")
    End Function

    Private Function BuildRaceToResourceIdMap(sharedMaterialsLsxPath As String,
                                              materialTechnicalToken As String,
                                              bankId As String,
                                              utamTypeValue As String) As Dictionary(Of String, String)
        Dim map As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)
        If String.IsNullOrWhiteSpace(sharedMaterialsLsxPath) OrElse Not File.Exists(sharedMaterialsLsxPath) Then
            Return map
        End If

        Dim doc = XDocument.Load(sharedMaterialsLsxPath)
        Dim children = GetBankChildrenNode(doc, bankId)
        If children Is Nothing Then
            Return map
        End If

        For Each node In children.Elements("node")
            If Not String.Equals(CStr(node.Attribute("id")), "Resource", StringComparison.OrdinalIgnoreCase) Then
                Continue For
            End If

            Dim utamType = GetNodeAttributeValue(node, "UTAM_Type")
            If Not String.Equals(utamType, utamTypeValue, StringComparison.OrdinalIgnoreCase) Then
                Continue For
            End If

            Dim resourceName = GetNodeAttributeValue(node, "Name")
            If Not String.IsNullOrWhiteSpace(materialTechnicalToken) AndAlso
               resourceName.IndexOf(materialTechnicalToken, StringComparison.OrdinalIgnoreCase) < 0 Then
                Continue For
            End If

            Dim resourceId = GetNodeAttributeValue(node, "ID")
            Dim raceCode = ExtractRaceCodeFromName(resourceName)

            If String.IsNullOrWhiteSpace(raceCode) OrElse String.IsNullOrWhiteSpace(resourceId) Then
                Continue For
            End If

            If Not map.ContainsKey(raceCode) Then
                map(raceCode) = resourceId
            End If
        Next

        Return map
    End Function

    Private Function DuplicateRootTemplateForMerge(destinationRoot As String,
                                                   targetModFolderName As String,
                                                   sourceMaterialTechnical As String,
                                                   targetMaterialTechnical As String,
                                                   targetVisibleName As String,
                                                   oldRaceToMaterialId As Dictionary(Of String, String),
                                                   newRaceToMaterialId As Dictionary(Of String, String),
                                                   oldRaceToVisualId As Dictionary(Of String, String),
                                                   newRaceToVisualId As Dictionary(Of String, String)) As MergeTemplateResult
        Dim rootTemplateDir = Path.Combine(destinationRoot, "Public", targetModFolderName, "RootTemplates")
        If Not Directory.Exists(rootTemplateDir) Then
            Return Nothing
        End If

        Dim rootTemplatePath = Directory.GetFiles(rootTemplateDir, "*.lsx", SearchOption.TopDirectoryOnly).FirstOrDefault()
        If String.IsNullOrWhiteSpace(rootTemplatePath) Then
            Return Nothing
        End If

        Dim doc = XDocument.Load(rootTemplatePath)
        Dim candidates = doc.Descendants("node").
            Where(Function(n) String.Equals(CStr(n.Attribute("id")), "GameObjects", StringComparison.OrdinalIgnoreCase)).
            Where(Function(n) GetNodeAttributeValue(n, "Stats").StartsWith("UTAM_Armor_OBJ_", StringComparison.OrdinalIgnoreCase)).
            ToList()

        Dim templateNode = candidates.
            FirstOrDefault(Function(n) GetNodeAttributeValue(n, "Name").IndexOf(sourceMaterialTechnical, StringComparison.OrdinalIgnoreCase) >= 0)

        If templateNode Is Nothing Then
            templateNode = candidates.FirstOrDefault()
        End If

        If templateNode Is Nothing Then
            Return Nothing
        End If

        Dim result As New MergeTemplateResult()
        Dim clonedNode As New XElement(templateNode)
        result.SourceStatsId = GetNodeAttributeValue(clonedNode, "Stats")
        If String.IsNullOrWhiteSpace(result.SourceStatsId) Then
            result.SourceStatsId = "UTAM_Armor_OBJ_" & GetNodeAttributeValue(clonedNode, "MapKey")
        End If

        result.SourceHandleH1 = GetPreferredHandle(clonedNode, "UTAM_h1", "DisplayName")
        result.SourceHandleH2 = GetPreferredHandle(clonedNode, "UTAM_h2", "Description")
        result.SourceHandleH3 = GetPreferredHandle(clonedNode, "UTAM_h3", "TechnicalDescription")

        result.NewTemplateGuid = Guid.NewGuid().ToString()
        SetNodeAttributeValue(clonedNode, "MapKey", result.NewTemplateGuid)
        SetNodeAttributeValue(clonedNode, "Name", targetMaterialTechnical)
        SetNodeAttributeValue(clonedNode, "Stats", "UTAM_Armor_OBJ_" & result.NewTemplateGuid)
        SetNodeAttributeValue(clonedNode, "UTAM_Group", targetVisibleName)

        result.NewHandleH1 = BuildLocaHandle()
        result.NewHandleH2 = BuildLocaHandle()
        result.NewHandleH3 = BuildLocaHandle()
        SetNodeHandleValue(clonedNode, "UTAM_h1", result.NewHandleH1)
        SetNodeHandleValue(clonedNode, "DisplayName", result.NewHandleH1)
        SetNodeHandleValue(clonedNode, "UTAM_h2", result.NewHandleH2)
        SetNodeHandleValue(clonedNode, "Description", result.NewHandleH2)
        SetNodeHandleValue(clonedNode, "UTAM_h3", result.NewHandleH3)
        SetNodeHandleValue(clonedNode, "TechnicalDescription", result.NewHandleH3)

        Dim targetNodes = candidates.
            Where(Function(n) IsTargetTemplateNode(n, targetMaterialTechnical, targetVisibleName)).
            ToList()

        For Each oldTargetNode In targetNodes
            Dim oldStatsId = GetNodeAttributeValue(oldTargetNode, "Stats")
            If Not String.IsNullOrWhiteSpace(oldStatsId) AndAlso
               Not result.RemovedStatsIds.Contains(oldStatsId, StringComparer.OrdinalIgnoreCase) Then
                result.RemovedStatsIds.Add(oldStatsId)
            End If

            For Each locaHandle As String In GetTemplateLocaHandles(oldTargetNode)
                If Not result.RemovedLocaHandles.Contains(locaHandle, StringComparer.OrdinalIgnoreCase) Then
                    result.RemovedLocaHandles.Add(locaHandle)
                End If
            Next

            oldTargetNode.Remove()
        Next

        Dim xml = clonedNode.ToString(SaveOptions.DisableFormatting)
        xml = ApplyRaceIdReplacements(xml, oldRaceToMaterialId, newRaceToMaterialId)
        xml = ApplyRaceIdReplacements(xml, oldRaceToVisualId, newRaceToVisualId)

        Dim parsedClonedNode = XElement.Parse(xml)
        Dim insertionAnchor = candidates.LastOrDefault(Function(n) n.Parent IsNot Nothing)
        If insertionAnchor IsNot Nothing AndAlso insertionAnchor.Parent IsNot Nothing Then
            insertionAnchor.AddAfterSelf(parsedClonedNode)
        Else
            Dim templatesNode = doc.Descendants("node").
                FirstOrDefault(Function(n) String.Equals(CStr(n.Attribute("id")), "Templates", StringComparison.OrdinalIgnoreCase))
            Dim childrenNode = If(templatesNode Is Nothing, Nothing, templatesNode.Element("children"))
            If childrenNode IsNot Nothing Then
                childrenNode.Add(parsedClonedNode)
            End If
        End If

        doc.Save(rootTemplatePath)

        Return result
    End Function

    Private Function ApplyRaceIdReplacements(xml As String,
                                             oldMap As Dictionary(Of String, String),
                                             newMap As Dictionary(Of String, String)) As String
        If String.IsNullOrWhiteSpace(xml) OrElse oldMap Is Nothing OrElse newMap Is Nothing Then
            Return xml
        End If

        Dim updated = xml
        For Each race In oldMap.Keys
            If Not newMap.ContainsKey(race) Then
                Continue For
            End If

            Dim oldId = oldMap(race)
            Dim newId = newMap(race)
            If String.IsNullOrWhiteSpace(oldId) OrElse String.IsNullOrWhiteSpace(newId) Then
                Continue For
            End If

            updated = Regex.Replace(updated, Regex.Escape(oldId), newId, RegexOptions.IgnoreCase)
        Next

        Return updated
    End Function

    Private Sub SetNodeAttributeValue(node As XElement, attributeId As String, newValue As String)
        Dim attrNode = node.Elements("attribute").
            FirstOrDefault(Function(a) String.Equals(CStr(a.Attribute("id")), attributeId, StringComparison.OrdinalIgnoreCase))

        If attrNode Is Nothing Then
            Return
        End If

        Dim valueAttr = attrNode.Attribute("value")
        If valueAttr Is Nothing Then
            Return
        End If

        valueAttr.Value = newValue
    End Sub

    Private Function BuildLocaHandle() As String
        Return "h" & Guid.NewGuid().ToString("D").Replace("-", "g").ToLowerInvariant()
    End Function

    Private Function GetNodeHandleValue(node As XElement, attributeId As String) As String
        Dim attrNode = node.Elements("attribute").
            FirstOrDefault(Function(a) String.Equals(CStr(a.Attribute("id")), attributeId, StringComparison.OrdinalIgnoreCase))

        If attrNode Is Nothing Then
            Return String.Empty
        End If

        Return CStr(attrNode.Attribute("handle"))
    End Function

    Private Function GetPreferredHandle(node As XElement, ParamArray attributeIds As String()) As String
        For Each attributeId In attributeIds
            Dim handleValue = GetNodeHandleValue(node, attributeId)
            If Not String.IsNullOrWhiteSpace(handleValue) Then
                Return handleValue
            End If
        Next

        Return String.Empty
    End Function

    Private Sub SetNodeHandleValue(node As XElement, attributeId As String, handleValue As String)
        Dim attrNode = node.Elements("attribute").
            FirstOrDefault(Function(a) String.Equals(CStr(a.Attribute("id")), attributeId, StringComparison.OrdinalIgnoreCase))

        If attrNode Is Nothing Then
            Return
        End If

        attrNode.SetAttributeValue("handle", handleValue)
        attrNode.SetAttributeValue("version", "1")
    End Sub

    Private Function GetTemplateLocaHandles(templateNode As XElement) As IEnumerable(Of String)
        Dim ids As String() = {"UTAM_h1", "UTAM_h2", "UTAM_h3", "DisplayName", "Description", "TechnicalDescription"}
        Dim handleValues As New List(Of String)()

        For Each id In ids
            Dim handle = GetNodeHandleValue(templateNode, id)
            If Not String.IsNullOrWhiteSpace(handle) Then
                handleValues.Add(handle)
            End If
        Next

        Return handleValues.Distinct(StringComparer.OrdinalIgnoreCase)
    End Function

    Private Function IsTargetTemplateNode(node As XElement, targetMaterialTechnical As String, targetVisibleName As String) As Boolean
        Dim nameValue = GetNodeAttributeValue(node, "Name")
        If ContainsEquivalent(nameValue, targetMaterialTechnical, targetVisibleName) Then
            Return True
        End If

        Dim groupValue = GetNodeAttributeValue(node, "UTAM_Group")
        If ContainsEquivalent(groupValue, targetMaterialTechnical, targetVisibleName) Then
            Return True
        End If

        Return False
    End Function

    Private Sub DuplicateStatsAndTreasureForMerge(destinationRoot As String,
                                                  targetModFolderName As String,
                                                  newTemplateGuid As String,
                                                  sourceStatsId As String,
                                                  removedStatsIds As IEnumerable(Of String))
        Dim statsDir = Path.Combine(destinationRoot, "Public", targetModFolderName, "Stats", "Generated")
        Dim objectStatsPath = Path.Combine(statsDir, "Data", "Object.txt")
        Dim treasurePath = Path.Combine(statsDir, "TreasureTable.txt")

        Dim newObjectId = "UTAM_Armor_OBJ_" & newTemplateGuid
        Dim removedStats = removedStatsIds.
            Where(Function(id) Not String.IsNullOrWhiteSpace(id)).
            Distinct(StringComparer.OrdinalIgnoreCase).
            ToList()

        If File.Exists(objectStatsPath) Then
            Dim objectContent = File.ReadAllText(objectStatsPath)
            For Each oldStatsId In removedStats
                If String.Equals(oldStatsId, sourceStatsId, StringComparison.OrdinalIgnoreCase) Then
                    Continue For
                End If

                Dim removePattern = New Regex("(?ms)^\s*new entry """ & Regex.Escape(oldStatsId) & """[\s\S]*?(?=^\s*new entry ""|\z)", RegexOptions.IgnoreCase)
                objectContent = removePattern.Replace(objectContent, "")
            Next

            If Not Regex.IsMatch(objectContent, "new entry """ & Regex.Escape(newObjectId) & """", RegexOptions.IgnoreCase) Then
                Dim blockMatch As Match = Nothing

                If Not String.IsNullOrWhiteSpace(sourceStatsId) Then
                    Dim exactPattern = New Regex("(?ms)^\s*new entry """ & Regex.Escape(sourceStatsId) & """[\s\S]*?(?=^\s*new entry ""|\z)", RegexOptions.IgnoreCase)
                    blockMatch = exactPattern.Match(objectContent)
                End If

                If blockMatch Is Nothing OrElse Not blockMatch.Success Then
                    Dim blockPattern = New Regex("new entry ""UTAM_Armor_OBJ_[^""]+""[\s\S]*?data ""RootTemplate"" ""[^""]+""", RegexOptions.IgnoreCase)
                    blockMatch = blockPattern.Match(objectContent)
                End If

                Dim newBlock As String
                If blockMatch.Success Then
                    newBlock = Regex.Replace(blockMatch.Value, "UTAM_Armor_OBJ_[0-9a-fA-F\-]{36}", newObjectId, RegexOptions.IgnoreCase)
                Else
                    newBlock = String.Join(Environment.NewLine, {
                        $"new entry ""{newObjectId}""",
                        "type ""Armor""",
                        "using ""ARM_Underwear""",
                        $"data ""RootTemplate"" ""{newTemplateGuid}"""
                    })
                End If

                newBlock = SyncStatTemplateReferences(newBlock, newTemplateGuid)

                objectContent = objectContent.TrimEnd() & Environment.NewLine & Environment.NewLine & newBlock & Environment.NewLine
                File.WriteAllText(objectStatsPath, objectContent, Encoding.UTF8)
            End If
        End If

        If File.Exists(treasurePath) Then
            Dim treasureContent = File.ReadAllText(treasurePath)
            For Each oldStatsId In removedStats
                If String.Equals(oldStatsId, sourceStatsId, StringComparison.OrdinalIgnoreCase) Then
                    Continue For
                End If

                Dim pairPattern = New Regex("(?im)^\s*new subtable\s+""1,1""\s*\r?\n\s*object category\s+""I_" & Regex.Escape(oldStatsId) & """[^\r\n]*\r?\n?", RegexOptions.IgnoreCase)
                treasureContent = pairPattern.Replace(treasureContent, "")
            Next

            Dim newObjectPairPattern = New Regex("(?im)^\s*new subtable\s+""1,1""\s*\r?\n\s*object category\s+""I_" & Regex.Escape(newObjectId) & """[^\r\n]*\r?\n?")
            If Not newObjectPairPattern.IsMatch(treasureContent) Then
                Dim objectLine = BuildTreasureObjectLine(newObjectId)
                If Not String.IsNullOrWhiteSpace(sourceStatsId) Then
                    Dim sourcePairPattern = New Regex("(?im)^\s*new subtable\s+""1,1""\s*\r?\n(?<line>\s*object category\s+""I_" & Regex.Escape(sourceStatsId) & """[^\r\n]*)")
                    Dim sourcePairMatch = sourcePairPattern.Match(treasureContent)
                    If sourcePairMatch.Success Then
                        objectLine = Regex.Replace(
                            sourcePairMatch.Groups("line").Value.Trim(),
                            "I_UTAM_Armor_OBJ_[0-9a-fA-F\-]{36}",
                            "I_" & newObjectId,
                            RegexOptions.IgnoreCase)
                    End If
                End If

                Dim newBlock = BuildTreasureBlock(newObjectId, objectLine)
                treasureContent = treasureContent.TrimEnd() & Environment.NewLine & newBlock & Environment.NewLine

                File.WriteAllText(treasurePath, treasureContent, Encoding.UTF8)
            End If
        End If
    End Sub

    Private Function NormalizeRootTemplateForClone(destinationRoot As String,
                                                   targetModFolderName As String,
                                                   targetMaterialTechnical As String,
                                                   targetVisible As String) As Tuple(Of String, String)
        Dim rootTemplateDir = Path.Combine(destinationRoot, "Public", targetModFolderName, "RootTemplates")
        If Not Directory.Exists(rootTemplateDir) Then
            Return Nothing
        End If

        Dim rootTemplatePath = Directory.GetFiles(rootTemplateDir, "*.lsx", SearchOption.TopDirectoryOnly).FirstOrDefault()
        If String.IsNullOrWhiteSpace(rootTemplatePath) Then
            Return Nothing
        End If

        Dim doc = XDocument.Load(rootTemplatePath)
        Dim gameObjectNodes = doc.Descendants("node").
            Where(Function(n) String.Equals(CStr(n.Attribute("id")), "GameObjects", StringComparison.OrdinalIgnoreCase)).
            Where(Function(n) GetNodeAttributeValue(n, "Stats").StartsWith("UTAM_Armor_OBJ_", StringComparison.OrdinalIgnoreCase)).
            ToList()

        If gameObjectNodes.Count = 0 Then
            Return Nothing
        End If

        Dim primary = gameObjectNodes(0)
        For i = 1 To gameObjectNodes.Count - 1
            gameObjectNodes(i).Remove()
        Next

        ' Clone must always get a brand new template GUID.
        Dim templateGuid = Guid.NewGuid().ToString()
        SetNodeAttributeValue(primary, "MapKey", templateGuid)

        Dim statId = "UTAM_Armor_OBJ_" & templateGuid
        SetNodeAttributeValue(primary, "Stats", statId)
        SetNodeAttributeValue(primary, "Name", targetMaterialTechnical)
        SetNodeAttributeValue(primary, "UTAM_Group", targetVisible)

        doc.Save(rootTemplatePath)
        Return Tuple.Create(templateGuid, statId)
    End Function

    Private Sub NormalizeStatsAndTreasureForClone(destinationRoot As String,
                                                  targetModFolderName As String,
                                                  templateGuid As String,
                                                  statId As String)
        Dim statsDir = Path.Combine(destinationRoot, "Public", targetModFolderName, "Stats", "Generated")
        Dim objectStatsPath = Path.Combine(statsDir, "Data", "Object.txt")
        Dim treasurePath = Path.Combine(statsDir, "TreasureTable.txt")

        If File.Exists(objectStatsPath) Then
            Dim content = File.ReadAllText(objectStatsPath)
            Dim utamBlockPattern As New Regex("(?ms)^\s*new entry ""UTAM_Armor_OBJ_[^""]+"".*?(?=^\s*new entry ""|\z)", RegexOptions.IgnoreCase)
            Dim firstUtam = utamBlockPattern.Match(content)

            Dim selectedBlock As String
            If firstUtam.Success Then
                selectedBlock = firstUtam.Value
            Else
                selectedBlock = String.Join(Environment.NewLine, {
                    $"new entry ""{statId}""",
                    "type ""Armor""",
                    "using ""ARM_Underwear""",
                    $"data ""RootTemplate"" ""{templateGuid}"""
                })
            End If

            selectedBlock = Regex.Replace(selectedBlock, "new entry ""UTAM_Armor_OBJ_[^""]+""", $"new entry ""{statId}""", RegexOptions.IgnoreCase)
            selectedBlock = SyncStatTemplateReferences(selectedBlock, templateGuid)

            Dim withoutUtamBlocks = utamBlockPattern.Replace(content, "").TrimEnd()
            Dim finalContent As String
            If String.IsNullOrWhiteSpace(withoutUtamBlocks) Then
                finalContent = selectedBlock.TrimEnd() & Environment.NewLine
            Else
                finalContent = withoutUtamBlocks & Environment.NewLine & Environment.NewLine & selectedBlock.TrimEnd() & Environment.NewLine
            End If

            File.WriteAllText(objectStatsPath, finalContent, Encoding.UTF8)
        End If

        If File.Exists(treasurePath) Then
            Dim treasureContent = File.ReadAllText(treasurePath)
            Dim utamPairPattern As New Regex("(?im)^\s*new subtable\s+""1,1""\s*\r?\n\s*object category\s+""I_UTAM_Armor_OBJ_[^""]+""[^\r\n]*\r?\n?")
            Dim cleaned = utamPairPattern.Replace(treasureContent, "").TrimEnd()
            Dim newBlock = BuildTreasureBlock(statId)

            If String.IsNullOrWhiteSpace(cleaned) Then
                treasureContent = newBlock & Environment.NewLine
            Else
                treasureContent = cleaned & Environment.NewLine & newBlock & Environment.NewLine
            End If

            File.WriteAllText(treasurePath, treasureContent, Encoding.UTF8)
        End If
    End Sub

    Private Sub SyncCloneLocalizationWithNewIds(destinationRoot As String,
                                                targetModFolderName As String,
                                                sourceMaterialTechnical As String,
                                                targetMaterialTechnical As String,
                                                sourceVisible As String,
                                                targetVisible As String)
        If String.IsNullOrWhiteSpace(targetVisible) Then
            Return
        End If

        Dim rootTemplateDir = Path.Combine(destinationRoot, "Public", targetModFolderName, "RootTemplates")
        If Not Directory.Exists(rootTemplateDir) Then
            Return
        End If

        Dim rootTemplatePath = Directory.GetFiles(rootTemplateDir, "*.lsx", SearchOption.TopDirectoryOnly).FirstOrDefault()
        If String.IsNullOrWhiteSpace(rootTemplatePath) Then
            Return
        End If

        Dim rootDoc = XDocument.Load(rootTemplatePath)
        Dim gameObject = rootDoc.Descendants("node").
            Where(Function(n) String.Equals(CStr(n.Attribute("id")), "GameObjects", StringComparison.OrdinalIgnoreCase)).
            FirstOrDefault(Function(n) GetNodeAttributeValue(n, "Stats").StartsWith("UTAM_Armor_OBJ_", StringComparison.OrdinalIgnoreCase))

        If gameObject Is Nothing Then
            Return
        End If

        Dim previousHandles = GetTemplateLocaHandles(gameObject).ToList()
        Dim oldH1 = GetPreferredHandle(gameObject, "UTAM_h1", "DisplayName")
        Dim oldH2 = GetPreferredHandle(gameObject, "UTAM_h2", "Description")
        Dim oldH3 = GetPreferredHandle(gameObject, "UTAM_h3", "TechnicalDescription")

        Dim newH1 = BuildLocaHandle()
        Dim newH2 = BuildLocaHandle()
        Dim newH3 = BuildLocaHandle()

        SetNodeHandleValue(gameObject, "UTAM_h1", newH1)
        SetNodeHandleValue(gameObject, "DisplayName", newH1)
        SetNodeHandleValue(gameObject, "UTAM_h2", newH2)
        SetNodeHandleValue(gameObject, "Description", newH2)
        SetNodeHandleValue(gameObject, "UTAM_h3", newH3)
        SetNodeHandleValue(gameObject, "TechnicalDescription", newH3)

        rootDoc.Save(rootTemplatePath)

        Dim locaDir = Path.Combine(destinationRoot, "Localization", "English")
        If Not Directory.Exists(locaDir) Then
            Return
        End If

        Dim locaXmlPath = Directory.GetFiles(locaDir, "*.loca.xml", SearchOption.TopDirectoryOnly).FirstOrDefault()
        If String.IsNullOrWhiteSpace(locaXmlPath) Then
            Return
        End If

        Dim locaDoc = XDocument.Load(locaXmlPath)
        Dim contentList = locaDoc.Descendants("contentList").FirstOrDefault()
        If contentList Is Nothing Then
            contentList = New XElement("contentList")
            If locaDoc.Root IsNot Nothing Then
                locaDoc.Root.Add(contentList)
            Else
                locaDoc.Add(contentList)
            End If
        End If

        Dim sourceTexts As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)
        For Each contentNode In contentList.Elements("content")
            Dim uid = CStr(contentNode.Attribute("contentuid"))
            If String.IsNullOrWhiteSpace(uid) Then
                Continue For
            End If

            If Not sourceTexts.ContainsKey(uid) Then
                sourceTexts(uid) = contentNode.Value
            End If
        Next

        Dim referencedHandles = CollectReferencedLocaHandles(rootTemplatePath)
        For Each oldHandle In previousHandles.
            Where(Function(h) Not String.IsNullOrWhiteSpace(h)).
            Distinct(StringComparer.OrdinalIgnoreCase)

            If referencedHandles.Contains(oldHandle) Then
                Continue For
            End If

            For Each nodeToRemove In contentList.Elements("content").
                Where(Function(c) String.Equals(CStr(c.Attribute("contentuid")), oldHandle, StringComparison.OrdinalIgnoreCase)).
                ToList()
                nodeToRemove.Remove()
            Next
        Next

        Dim sourceDisplayText As String = String.Empty
        If Not String.IsNullOrWhiteSpace(oldH1) AndAlso sourceTexts.ContainsKey(oldH1) Then
            sourceDisplayText = sourceTexts(oldH1)
        End If
        Dim displayText = BuildDisplayTextFromSource(sourceDisplayText, targetVisible)

        Dim h2Text = ResolveMergeLocaText(
            sourceTexts,
            oldH2,
            sourceMaterialTechnical,
            targetMaterialTechnical,
            sourceVisible,
            targetVisible,
            String.Empty)

        Dim h3Text = ResolveMergeLocaText(
            sourceTexts,
            oldH3,
            sourceMaterialTechnical,
            targetMaterialTechnical,
            sourceVisible,
            targetVisible,
            String.Empty)

        UpsertLocaContent(contentList, newH1, displayText)
        UpsertLocaContent(contentList, newH2, h2Text)
        UpsertLocaContent(contentList, newH3, h3Text)

        locaDoc.Save(locaXmlPath)
    End Sub

    Private Sub SyncMergeLocalizationWithNewIds(destinationRoot As String,
                                                targetModFolderName As String,
                                                sourceMaterialTechnical As String,
                                                targetMaterialTechnical As String,
                                                sourceVisible As String,
                                                targetVisible As String,
                                                mergeResult As MergeTemplateResult)
        If mergeResult Is Nothing Then
            Return
        End If

        Dim locaDir = Path.Combine(destinationRoot, "Localization", "English")
        If Not Directory.Exists(locaDir) Then
            Return
        End If

        Dim locaXmlPath = Directory.GetFiles(locaDir, "*.loca.xml", SearchOption.TopDirectoryOnly).FirstOrDefault()
        If String.IsNullOrWhiteSpace(locaXmlPath) Then
            Return
        End If

        Dim rootTemplateDir = Path.Combine(destinationRoot, "Public", targetModFolderName, "RootTemplates")
        If Not Directory.Exists(rootTemplateDir) Then
            Return
        End If

        Dim rootTemplatePath = Directory.GetFiles(rootTemplateDir, "*.lsx", SearchOption.TopDirectoryOnly).FirstOrDefault()
        If String.IsNullOrWhiteSpace(rootTemplatePath) Then
            Return
        End If

        Dim referencedHandles = CollectReferencedLocaHandles(rootTemplatePath)
        Dim locaDoc = XDocument.Load(locaXmlPath)
        Dim contentList = locaDoc.Descendants("contentList").FirstOrDefault()
        If contentList Is Nothing Then
            contentList = New XElement("contentList")
            If locaDoc.Root IsNot Nothing Then
                locaDoc.Root.Add(contentList)
            Else
                locaDoc.Add(contentList)
            End If
        End If

        Dim sourceTexts As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)
        For Each contentNode In contentList.Elements("content")
            Dim uid = CStr(contentNode.Attribute("contentuid"))
            If String.IsNullOrWhiteSpace(uid) Then
                Continue For
            End If

            If Not sourceTexts.ContainsKey(uid) Then
                sourceTexts(uid) = contentNode.Value
            End If
        Next

        For Each oldHandle In mergeResult.RemovedLocaHandles.
            Where(Function(h) Not String.IsNullOrWhiteSpace(h)).
            Distinct(StringComparer.OrdinalIgnoreCase)

            If referencedHandles.Contains(oldHandle) Then
                Continue For
            End If

            For Each nodeToRemove In contentList.Elements("content").
                Where(Function(c) String.Equals(CStr(c.Attribute("contentuid")), oldHandle, StringComparison.OrdinalIgnoreCase)).
                ToList()
                nodeToRemove.Remove()
            Next
        Next

        Dim sourceDisplayText As String = String.Empty
        If Not String.IsNullOrWhiteSpace(mergeResult.SourceHandleH1) AndAlso sourceTexts.ContainsKey(mergeResult.SourceHandleH1) Then
            sourceDisplayText = sourceTexts(mergeResult.SourceHandleH1)
        End If
        Dim displayText = BuildDisplayTextFromSource(sourceDisplayText, targetVisible)

        Dim h2Text = ResolveMergeLocaText(
            sourceTexts,
            mergeResult.SourceHandleH2,
            sourceMaterialTechnical,
            targetMaterialTechnical,
            sourceVisible,
            targetVisible,
            String.Empty)

        Dim h3Text = ResolveMergeLocaText(
            sourceTexts,
            mergeResult.SourceHandleH3,
            sourceMaterialTechnical,
            targetMaterialTechnical,
            sourceVisible,
            targetVisible,
            String.Empty)

        UpsertLocaContent(contentList, mergeResult.NewHandleH1, displayText)
        UpsertLocaContent(contentList, mergeResult.NewHandleH2, h2Text)
        UpsertLocaContent(contentList, mergeResult.NewHandleH3, h3Text)

        locaDoc.Save(locaXmlPath)
    End Sub

    Private Function CollectReferencedLocaHandles(rootTemplatePath As String) As HashSet(Of String)
        Dim handleSet As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        Dim doc = XDocument.Load(rootTemplatePath)

        Dim gameObjects = doc.Descendants("node").
            Where(Function(n) String.Equals(CStr(n.Attribute("id")), "GameObjects", StringComparison.OrdinalIgnoreCase)).
            Where(Function(n) GetNodeAttributeValue(n, "Stats").StartsWith("UTAM_Armor_OBJ_", StringComparison.OrdinalIgnoreCase))

        For Each node In gameObjects
            For Each locaHandle As String In GetTemplateLocaHandles(node)
                handleSet.Add(locaHandle)
            Next
        Next

        Return handleSet
    End Function

    Private Sub UpsertLocaContent(contentList As XElement, contentUid As String, text As String)
        If String.IsNullOrWhiteSpace(contentUid) Then
            Return
        End If

        Dim node = contentList.Elements("content").
            FirstOrDefault(Function(c) String.Equals(CStr(c.Attribute("contentuid")), contentUid, StringComparison.OrdinalIgnoreCase))

        If node Is Nothing Then
            node = New XElement("content")
            node.SetAttributeValue("contentuid", contentUid)
            contentList.Add(node)
        End If

        node.SetAttributeValue("version", "1")
        node.Value = If(text, String.Empty)
    End Sub

    Private Function ResolveMergeLocaText(sourceTexts As Dictionary(Of String, String),
                                          sourceHandle As String,
                                          sourceMaterialTechnical As String,
                                          targetMaterialTechnical As String,
                                          sourceVisible As String,
                                          targetVisible As String,
                                          fallbackText As String) As String
        Dim text As String = String.Empty
        If Not String.IsNullOrWhiteSpace(sourceHandle) AndAlso sourceTexts.ContainsKey(sourceHandle) Then
            text = sourceTexts(sourceHandle)
        End If

        If String.IsNullOrWhiteSpace(text) Then
            Return fallbackText
        End If

        Dim updated = text
        If Not String.IsNullOrWhiteSpace(sourceVisible) Then
            updated = Regex.Replace(updated, Regex.Escape(sourceVisible), targetVisible, RegexOptions.IgnoreCase)
        End If

        Dim sourceVisibleFromTechnical = ToVisibleName(sourceMaterialTechnical)
        If Not String.IsNullOrWhiteSpace(sourceVisibleFromTechnical) Then
            updated = Regex.Replace(updated, Regex.Escape(sourceVisibleFromTechnical), targetVisible, RegexOptions.IgnoreCase)
        End If

        If Not String.IsNullOrWhiteSpace(sourceMaterialTechnical) Then
            updated = Regex.Replace(updated, Regex.Escape(sourceMaterialTechnical), targetMaterialTechnical, RegexOptions.IgnoreCase)
        End If

        If String.IsNullOrWhiteSpace(updated.Trim()) Then
            Return fallbackText
        End If

        Return updated
    End Function

    Private Function BuildDisplayTextFromSource(sourceText As String, targetVisible As String) As String
        If String.IsNullOrWhiteSpace(targetVisible) Then
            Return String.Empty
        End If

        If String.IsNullOrWhiteSpace(sourceText) Then
            Return targetVisible
        End If

        Dim existing = sourceText.Trim()
        Dim openParen = existing.IndexOf("("c)
        If openParen > 0 Then
            Dim suffix = existing.Substring(openParen).Trim()
            If Not String.IsNullOrWhiteSpace(suffix) Then
                Return targetVisible & " " & suffix
            End If
        End If

        Return targetVisible
    End Function

    Private Sub EnsureTemplateLocalizationCoverage(destinationRoot As String, targetModFolderName As String)
        Dim rootTemplateDir = Path.Combine(destinationRoot, "Public", targetModFolderName, "RootTemplates")
        If Not Directory.Exists(rootTemplateDir) Then
            Return
        End If

        Dim rootTemplatePath = Directory.GetFiles(rootTemplateDir, "*.lsx", SearchOption.TopDirectoryOnly).FirstOrDefault()
        If String.IsNullOrWhiteSpace(rootTemplatePath) Then
            Return
        End If

        Dim locaDir = Path.Combine(destinationRoot, "Localization", "English")
        If Not Directory.Exists(locaDir) Then
            Return
        End If

        Dim locaXmlPath = Directory.GetFiles(locaDir, "*.loca.xml", SearchOption.TopDirectoryOnly).FirstOrDefault()
        If String.IsNullOrWhiteSpace(locaXmlPath) Then
            Return
        End If

        Dim rootDoc = XDocument.Load(rootTemplatePath)
        Dim locaDoc = XDocument.Load(locaXmlPath)
        Dim contentList = locaDoc.Descendants("contentList").FirstOrDefault()
        If contentList Is Nothing Then
            contentList = New XElement("contentList")
            If locaDoc.Root IsNot Nothing Then
                locaDoc.Root.Add(contentList)
            Else
                locaDoc.Add(contentList)
            End If
        End If

        Dim gameObjects = rootDoc.Descendants("node").
            Where(Function(n) String.Equals(CStr(n.Attribute("id")), "GameObjects", StringComparison.OrdinalIgnoreCase)).
            Where(Function(n) GetNodeAttributeValue(n, "Stats").StartsWith("UTAM_Armor_OBJ_", StringComparison.OrdinalIgnoreCase)).
            ToList()

        For Each gameObject In gameObjects
            Dim displayHandle = GetPreferredHandle(gameObject, "DisplayName", "UTAM_h1")
            Dim descriptionHandle = GetPreferredHandle(gameObject, "Description", "UTAM_h2")
            Dim technicalHandle = GetPreferredHandle(gameObject, "TechnicalDescription", "UTAM_h3")

            Dim visibleName = GetNodeAttributeValue(gameObject, "UTAM_Group")
            If String.IsNullOrWhiteSpace(visibleName) Then
                visibleName = ToVisibleName(GetNodeAttributeValue(gameObject, "Name"))
            End If

            If Not String.IsNullOrWhiteSpace(displayHandle) Then
                Dim existingDisplay = contentList.Elements("content").
                    FirstOrDefault(Function(c) String.Equals(CStr(c.Attribute("contentuid")), displayHandle, StringComparison.OrdinalIgnoreCase))
                Dim desiredDisplay = BuildDisplayTextFromSource(If(existingDisplay?.Value, String.Empty), visibleName)
                UpsertLocaContent(contentList, displayHandle, desiredDisplay)
            End If

            If Not String.IsNullOrWhiteSpace(descriptionHandle) Then
                Dim existingDesc = contentList.Elements("content").
                    FirstOrDefault(Function(c) String.Equals(CStr(c.Attribute("contentuid")), descriptionHandle, StringComparison.OrdinalIgnoreCase))
                UpsertLocaContent(contentList, descriptionHandle, If(existingDesc?.Value, String.Empty))
            End If

            If Not String.IsNullOrWhiteSpace(technicalHandle) Then
                Dim existingTech = contentList.Elements("content").
                    FirstOrDefault(Function(c) String.Equals(CStr(c.Attribute("contentuid")), technicalHandle, StringComparison.OrdinalIgnoreCase))
                UpsertLocaContent(contentList, technicalHandle, If(existingTech?.Value, String.Empty))
            End If
        Next

        locaDoc.Save(locaXmlPath)
    End Sub

    Private Function SyncStatTemplateReferences(statBlock As String, templateGuid As String) As String
        Dim updated = statBlock

        If Regex.IsMatch(updated, "data ""RootTemplate"" ""[^""]+""", RegexOptions.IgnoreCase) Then
            updated = Regex.Replace(updated, "data ""RootTemplate"" ""[^""]+""", $"data ""RootTemplate"" ""{templateGuid}""", RegexOptions.IgnoreCase)
        Else
            updated = updated.TrimEnd() & Environment.NewLine & $"data ""RootTemplate"" ""{templateGuid}"""
        End If

        ' Some mods use TemplateId/Template_id in the same block; keep it aligned when present.
        Dim templateIdMatch = Regex.Match(updated, "data\s+""(?<key>Template_?Id)""\s+""[^""]+""", RegexOptions.IgnoreCase)
        If templateIdMatch.Success Then
            Dim key = templateIdMatch.Groups("key").Value
            updated = Regex.Replace(updated, "data\s+""Template_?Id""\s+""[^""]+""", $"data ""{key}"" ""{templateGuid}""", RegexOptions.IgnoreCase)
        End If

        Return updated
    End Function

    Private Sub CleanupRedundantBinaryPairs(destinationRoot As String)
        If String.IsNullOrWhiteSpace(destinationRoot) OrElse Not Directory.Exists(destinationRoot) Then
            Return
        End If

        Dim allFiles = Directory.GetFiles(destinationRoot, "*", SearchOption.AllDirectories)
        For Each filePath In allFiles
            Dim ext = Path.GetExtension(filePath)

            If String.Equals(ext, ".lsf", StringComparison.OrdinalIgnoreCase) Then
                Dim lsxPair = filePath & ".lsx"
                If File.Exists(lsxPair) Then
                    File.Delete(filePath)
                End If
                Continue For
            End If

            If String.Equals(ext, ".loca", StringComparison.OrdinalIgnoreCase) Then
                Dim xmlPair = filePath & ".xml"
                If File.Exists(xmlPair) Then
                    File.Delete(filePath)
                End If
            End If
        Next
    End Sub

    Private Sub EnsureStatsTreasureConsistency(destinationRoot As String, targetModFolderName As String)
        Dim objectStatsPath = Path.Combine(destinationRoot, "Public", targetModFolderName, "Stats", "Generated", "Data", "Object.txt")
        Dim treasurePath = Path.Combine(destinationRoot, "Public", targetModFolderName, "Stats", "Generated", "TreasureTable.txt")

        If Not File.Exists(objectStatsPath) OrElse Not File.Exists(treasurePath) Then
            Return
        End If

        Dim objectContent = File.ReadAllText(objectStatsPath)
        Dim treasureContent = File.ReadAllText(treasurePath)

        Dim objectIds = Regex.Matches(objectContent, "(?im)^\s*new entry\s+""(UTAM_Armor_OBJ_[^""]+)""").
            Cast(Of Match)().
            Select(Function(m) m.Groups(1).Value).
            Distinct(StringComparer.OrdinalIgnoreCase).
            ToList()

        If objectIds.Count = 0 Then
            Return
        End If

        Dim treasureIds = Regex.Matches(treasureContent, "(?im)^\s*object category\s+""I_(UTAM_Armor_OBJ_[^""]+)""").
            Cast(Of Match)().
            Select(Function(m) m.Groups(1).Value).
            ToList()

        Dim staleTreasureIds = treasureIds.
            Where(Function(id) Not objectIds.Contains(id, StringComparer.OrdinalIgnoreCase)).
            Distinct(StringComparer.OrdinalIgnoreCase).
            ToList()

        For Each staleId In staleTreasureIds
            Dim pairedPattern = New Regex("(?im)^\s*new subtable\s+""1,1""\s*\r?\n\s*object category\s+""I_" & Regex.Escape(staleId) & """[^\r\n]*\r?\n?")
            treasureContent = pairedPattern.Replace(treasureContent, "")
        Next

        Dim remainingTreasureIds = Regex.Matches(treasureContent, "(?im)^\s*new subtable\s+""1,1""\s*\r?\n\s*object category\s+""I_(UTAM_Armor_OBJ_[^""]+)""").
            Cast(Of Match)().
            Select(Function(m) m.Groups(1).Value).
            Distinct(StringComparer.OrdinalIgnoreCase).
            ToList()

        For Each objectId In objectIds
            If remainingTreasureIds.Contains(objectId, StringComparer.OrdinalIgnoreCase) Then
                Continue For
            End If

            Dim newBlock = String.Join(Environment.NewLine, {
                "new subtable ""1,1""",
                BuildTreasureObjectLine(objectId)
            })
            treasureContent = treasureContent.TrimEnd() & Environment.NewLine & newBlock & Environment.NewLine
        Next

        File.WriteAllText(treasurePath, treasureContent, Encoding.UTF8)
    End Sub

    Private Sub DeleteMaterialFromMod(destinationRoot As String, targetModFolderName As String, targetMaterialTechnical As String)
        Dim targetVisible = ToVisibleName(targetMaterialTechnical)
        AppendLog($"Borrando material: {targetMaterialTechnical}", "STEP")

        Dim removedSharedResources = RemoveMaterialEntriesFromSharedMaterials(destinationRoot, targetModFolderName, targetMaterialTechnical, targetVisible)
        AppendLog($"SharedMaterials: recursos eliminados = {removedSharedResources}", "STEP")

        Dim deletedTemplates = RemoveMaterialTemplates(destinationRoot, targetModFolderName, targetMaterialTechnical, targetVisible)
        AppendLog($"RootTemplates: templates eliminados = {deletedTemplates.RemovedTemplateGuids.Count}", "STEP")

        Dim removedStatsFromObject = RemoveStatsForDeletedMaterial(destinationRoot, targetModFolderName, deletedTemplates.RemovedStatsIds, deletedTemplates.RemovedTemplateGuids)
        For Each objectId In removedStatsFromObject
            deletedTemplates.RemovedStatsIds.Add(objectId)
        Next
        AppendLog($"Object.txt: stats eliminados = {removedStatsFromObject.Count}", "STEP")

        Dim removedTreasurePairs = RemoveTreasurePairsForStats(destinationRoot, targetModFolderName, deletedTemplates.RemovedStatsIds)
        AppendLog($"TreasureTable: bloques eliminados = {removedTreasurePairs}", "STEP")

        Dim removedLocaEntries = RemoveLocalizationEntriesByHandle(destinationRoot, deletedTemplates.RemovedLocaHandles)
        AppendLog($"Localization (English): entries eliminadas = {removedLocaEntries}", "STEP")

        If removedSharedResources = 0 AndAlso
           deletedTemplates.RemovedTemplateGuids.Count = 0 AndAlso
           removedStatsFromObject.Count = 0 AndAlso
           removedTreasurePairs = 0 AndAlso
           removedLocaEntries = 0 Then
            AppendLog("No se encontraron entradas para eliminar con el material indicado.", "WARN")
        End If
    End Sub

    Private Function RemoveMaterialEntriesFromSharedMaterials(destinationRoot As String,
                                                              targetModFolderName As String,
                                                              targetMaterialTechnical As String,
                                                              targetVisible As String) As Integer
        Dim sharedMaterialsPath = GetSharedMaterialsLsxPath(destinationRoot, targetModFolderName)
        If String.IsNullOrWhiteSpace(sharedMaterialsPath) OrElse Not File.Exists(sharedMaterialsPath) Then
            Return 0
        End If

        Dim removedCount As Integer = 0
        Dim doc = XDocument.Load(sharedMaterialsPath)

        For Each bankId In New String() {"TextureBank", "MaterialBank", "VisualBank"}
            Dim children = GetBankChildrenNode(doc, bankId)
            If children Is Nothing Then
                Continue For
            End If

            Dim nodesToRemove = children.Elements("node").
                Where(Function(n) String.Equals(CStr(n.Attribute("id")), "Resource", StringComparison.OrdinalIgnoreCase)).
                Where(Function(n) IsTargetSharedMaterialNode(n, targetMaterialTechnical, targetVisible)).
                ToList()

            For Each node In nodesToRemove
                node.Remove()
                removedCount += 1
            Next
        Next

        If removedCount > 0 Then
            doc.Save(sharedMaterialsPath)
        End If

        Return removedCount
    End Function

    Private Function IsTargetSharedMaterialNode(node As XElement, targetMaterialTechnical As String, targetVisible As String) As Boolean
        Dim nameValue = GetNodeAttributeValue(node, "Name")
        If ContainsEquivalent(nameValue, targetMaterialTechnical, targetVisible) Then
            Return True
        End If

        Dim templateValue = GetNodeAttributeValue(node, "Template")
        If ContainsEquivalent(templateValue, targetMaterialTechnical, targetVisible) Then
            Return True
        End If

        Dim sourceValue = GetNodeAttributeValue(node, "SourceFile")
        If ContainsEquivalent(sourceValue, targetMaterialTechnical, targetVisible) Then
            Return True
        End If

        Dim groupValue = GetNodeAttributeValue(node, "UTAM_Group")
        If ContainsEquivalent(groupValue, targetMaterialTechnical, targetVisible) Then
            Return True
        End If

        Return False
    End Function

    Private Function RemoveMaterialTemplates(destinationRoot As String,
                                             targetModFolderName As String,
                                             targetMaterialTechnical As String,
                                             targetVisible As String) As DeleteMaterialResult
        Dim result As New DeleteMaterialResult()
        Dim rootTemplateDir = Path.Combine(destinationRoot, "Public", targetModFolderName, "RootTemplates")
        If Not Directory.Exists(rootTemplateDir) Then
            Return result
        End If

        Dim rootTemplatePath = Directory.GetFiles(rootTemplateDir, "*.lsx", SearchOption.TopDirectoryOnly).FirstOrDefault()
        If String.IsNullOrWhiteSpace(rootTemplatePath) Then
            Return result
        End If

        Dim doc = XDocument.Load(rootTemplatePath)
        Dim templateNodes = doc.Descendants("node").
            Where(Function(n) String.Equals(CStr(n.Attribute("id")), "GameObjects", StringComparison.OrdinalIgnoreCase)).
            Where(Function(n) GetNodeAttributeValue(n, "Stats").StartsWith("UTAM_Armor_OBJ_", StringComparison.OrdinalIgnoreCase)).
            ToList()

        Dim matched = templateNodes.
            Where(Function(n) IsTargetTemplateNode(n, targetMaterialTechnical, targetVisible)).
            ToList()

        For Each node In matched
            Dim templateGuid = GetNodeAttributeValue(node, "MapKey")
            If Not String.IsNullOrWhiteSpace(templateGuid) Then
                result.RemovedTemplateGuids.Add(templateGuid)
            End If

            Dim statsId = GetNodeAttributeValue(node, "Stats")
            If Not String.IsNullOrWhiteSpace(statsId) Then
                result.RemovedStatsIds.Add(statsId)
            End If

            For Each handleValue In GetTemplateLocaHandles(node)
                If Not String.IsNullOrWhiteSpace(handleValue) Then
                    result.RemovedLocaHandles.Add(handleValue)
                End If
            Next

            node.Remove()
        Next

        If matched.Count > 0 Then
            doc.Save(rootTemplatePath)
        End If

        Return result
    End Function

    Private Function RemoveStatsForDeletedMaterial(destinationRoot As String,
                                                   targetModFolderName As String,
                                                   removedStatsIds As IEnumerable(Of String),
                                                   removedTemplateGuids As IEnumerable(Of String)) As HashSet(Of String)
        Dim removedObjectIds As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        Dim objectStatsPath = Path.Combine(destinationRoot, "Public", targetModFolderName, "Stats", "Generated", "Data", "Object.txt")
        If Not File.Exists(objectStatsPath) Then
            Return removedObjectIds
        End If

        Dim statsToDelete As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        If removedStatsIds IsNot Nothing Then
            For Each statsId In removedStatsIds
                If Not String.IsNullOrWhiteSpace(statsId) Then
                    statsToDelete.Add(statsId.Trim())
                End If
            Next
        End If

        Dim templatesToDelete As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        If removedTemplateGuids IsNot Nothing Then
            For Each templateGuid In removedTemplateGuids
                If Not String.IsNullOrWhiteSpace(templateGuid) Then
                    templatesToDelete.Add(templateGuid.Trim())
                End If
            Next
        End If

        If statsToDelete.Count = 0 AndAlso templatesToDelete.Count = 0 Then
            Return removedObjectIds
        End If

        Dim content = File.ReadAllText(objectStatsPath)
        Dim blockPattern As New Regex("(?ms)^\s*new entry ""UTAM_Armor_OBJ_[^""]+""[\s\S]*?(?=^\s*new entry ""|\z)", RegexOptions.IgnoreCase)
        Dim blocks = blockPattern.Matches(content).Cast(Of Match)().ToList()
        If blocks.Count = 0 Then
            Return removedObjectIds
        End If

        Dim output As New StringBuilder(content.Length)
        Dim cursor As Integer = 0
        Dim changed As Boolean = False

        For Each blockMatch In blocks
            If blockMatch.Index > cursor Then
                output.Append(content.Substring(cursor, blockMatch.Index - cursor))
            End If

            Dim blockText = blockMatch.Value
            Dim objectId = ExtractObjectStatIdFromBlock(blockText)
            Dim removeBlock =
                (Not String.IsNullOrWhiteSpace(objectId) AndAlso statsToDelete.Contains(objectId)) OrElse
                BlockReferencesAnyTemplateGuid(blockText, templatesToDelete)

            If removeBlock Then
                changed = True
                If Not String.IsNullOrWhiteSpace(objectId) Then
                    removedObjectIds.Add(objectId)
                End If
            Else
                output.Append(blockText)
            End If

            cursor = blockMatch.Index + blockMatch.Length
        Next

        If cursor < content.Length Then
            output.Append(content.Substring(cursor))
        End If

        If changed Then
            File.WriteAllText(objectStatsPath, output.ToString(), Encoding.UTF8)
        End If

        Return removedObjectIds
    End Function

    Private Function ExtractObjectStatIdFromBlock(blockText As String) As String
        If String.IsNullOrWhiteSpace(blockText) Then
            Return String.Empty
        End If

        Dim match = Regex.Match(blockText, "(?im)^\s*new entry\s+""(?<id>UTAM_Armor_OBJ_[^""]+)""")
        If Not match.Success Then
            Return String.Empty
        End If

        Return match.Groups("id").Value
    End Function

    Private Function BlockReferencesAnyTemplateGuid(blockText As String, templateGuids As HashSet(Of String)) As Boolean
        If String.IsNullOrWhiteSpace(blockText) OrElse templateGuids Is Nothing OrElse templateGuids.Count = 0 Then
            Return False
        End If

        For Each templateGuid In templateGuids
            Dim rootTemplatePattern = "data\s+""RootTemplate""\s+""" & Regex.Escape(templateGuid) & """"
            If Regex.IsMatch(blockText, rootTemplatePattern, RegexOptions.IgnoreCase) Then
                Return True
            End If
        Next

        Return False
    End Function

    Private Function RemoveTreasurePairsForStats(destinationRoot As String,
                                                 targetModFolderName As String,
                                                 statsIds As IEnumerable(Of String)) As Integer
        Dim treasurePath = Path.Combine(destinationRoot, "Public", targetModFolderName, "Stats", "Generated", "TreasureTable.txt")
        If Not File.Exists(treasurePath) Then
            Return 0
        End If

        Dim statsToDelete As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        If statsIds IsNot Nothing Then
            For Each statsId In statsIds
                If Not String.IsNullOrWhiteSpace(statsId) Then
                    statsToDelete.Add(statsId.Trim())
                End If
            Next
        End If

        If statsToDelete.Count = 0 Then
            Return 0
        End If

        Dim content = File.ReadAllText(treasurePath)
        Dim removedCount As Integer = 0

        For Each statsId In statsToDelete
            Dim pairPattern = New Regex("(?im)^\s*new subtable\s+""1,1""\s*\r?\n\s*object category\s+""I_" & Regex.Escape(statsId) & """[^\r\n]*\r?\n?")
            removedCount += pairPattern.Matches(content).Count
            content = pairPattern.Replace(content, "")
        Next

        If removedCount > 0 Then
            File.WriteAllText(treasurePath, content, Encoding.UTF8)
        End If

        Return removedCount
    End Function

    Private Function RemoveLocalizationEntriesByHandle(destinationRoot As String, locaHandles As IEnumerable(Of String)) As Integer
        Dim locaDir = Path.Combine(destinationRoot, "Localization", "English")
        If Not Directory.Exists(locaDir) Then
            Return 0
        End If

        Dim locaXmlPath = Directory.GetFiles(locaDir, "*.loca.xml", SearchOption.TopDirectoryOnly).FirstOrDefault()
        If String.IsNullOrWhiteSpace(locaXmlPath) Then
            Return 0
        End If

        Dim handlesToDelete As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        If locaHandles IsNot Nothing Then
            For Each handleValue In locaHandles
                If Not String.IsNullOrWhiteSpace(handleValue) Then
                    handlesToDelete.Add(handleValue.Trim())
                End If
            Next
        End If

        If handlesToDelete.Count = 0 Then
            Return 0
        End If

        Dim doc = XDocument.Load(locaXmlPath)
        Dim contentList = doc.Descendants("contentList").FirstOrDefault()
        If contentList Is Nothing Then
            Return 0
        End If

        Dim removedCount As Integer = 0
        For Each contentNode In contentList.Elements("content").ToList()
            Dim contentUid = CStr(contentNode.Attribute("contentuid"))
            If String.IsNullOrWhiteSpace(contentUid) Then
                Continue For
            End If

            If handlesToDelete.Contains(contentUid) Then
                contentNode.Remove()
                removedCount += 1
            End If
        Next

        If removedCount > 0 Then
            doc.Save(locaXmlPath)
        End If

        Return removedCount
    End Function

    Private Function BuildTreasureBlock(statId As String, Optional objectLine As String = Nothing) As String
        Dim resolvedObjectLine = objectLine
        If String.IsNullOrWhiteSpace(resolvedObjectLine) Then
            resolvedObjectLine = BuildTreasureObjectLine(statId)
        End If

        Return String.Join(Environment.NewLine, {
            "new subtable ""1,1""",
            resolvedObjectLine.Trim()
        })
    End Function

    Private Function BuildTreasureObjectLine(statId As String) As String
        Return $"object category ""I_{statId}"",1,0,0,0,0,0,0,0"
    End Function

    Private Function ExtractRaceCodeFromName(resourceName As String) As String
        If String.IsNullOrWhiteSpace(resourceName) Then
            Return String.Empty
        End If

        Dim upper = resourceName.ToUpperInvariant()

        If upper.Contains("DGB_F_NKD_") OrElse upper.EndsWith("_DGBF", StringComparison.Ordinal) Then Return "DGBF"
        If upper.Contains("DWR_F_NKD_") OrElse upper.EndsWith("_DWRF", StringComparison.Ordinal) Then Return "DWRF"
        If upper.Contains("GNO_F_NKD_") OrElse upper.EndsWith("_GNOF", StringComparison.Ordinal) Then Return "GNOF"
        If upper.Contains("GOB_F_NKD_") OrElse upper.EndsWith("_GOBF", StringComparison.Ordinal) Then Return "GOBF"
        If upper.Contains("GTY_F_NKD_") OrElse upper.EndsWith("_GTYF", StringComparison.Ordinal) Then Return "GTYF"
        If upper.Contains("HFL_F_NKD_") OrElse upper.EndsWith("_HFLF", StringComparison.Ordinal) Then Return "HFLF"
        If upper.Contains("HRC_F_NKD_") OrElse upper.EndsWith("_HRCF", StringComparison.Ordinal) Then Return "HRCF"
        If upper.Contains("HUM_FS_NKD_") OrElse upper.EndsWith("_HUMFS", StringComparison.Ordinal) Then Return "HUMFS"
        If upper.Contains("HUM_F_NKD_") OrElse upper.EndsWith("_HUM_F", StringComparison.Ordinal) Then Return "HUM_F"
        If upper.Contains("TIF_FS_NKD_") OrElse upper.EndsWith("_TIFFS", StringComparison.Ordinal) Then Return "TIFFS"
        If upper.Contains("TIF_F_NKD_") OrElse upper.EndsWith("_TIFF", StringComparison.Ordinal) Then Return "TIFF"

        Return String.Empty
    End Function

    Private Sub RemapRootTemplateMaterialReferences(destinationRoot As String,
                                                    targetModFolderName As String,
                                                    oldRaceToMaterialId As Dictionary(Of String, String),
                                                    newRaceToMaterialId As Dictionary(Of String, String))
        If oldRaceToMaterialId.Count = 0 OrElse newRaceToMaterialId.Count = 0 Then
            Return
        End If

        Dim rootTemplateDir = Path.Combine(destinationRoot, "Public", targetModFolderName, "RootTemplates")
        If Not Directory.Exists(rootTemplateDir) Then
            Return
        End If

        Dim rootTemplatePath = Directory.GetFiles(rootTemplateDir, "*.lsx", SearchOption.TopDirectoryOnly).FirstOrDefault()
        If String.IsNullOrWhiteSpace(rootTemplatePath) Then
            Return
        End If

        Dim content = File.ReadAllText(rootTemplatePath)
        Dim changed As Boolean = False

        For Each race In oldRaceToMaterialId.Keys
            If Not newRaceToMaterialId.ContainsKey(race) Then
                Continue For
            End If

            Dim oldId = oldRaceToMaterialId(race)
            Dim newId = newRaceToMaterialId(race)
            If String.Equals(oldId, newId, StringComparison.OrdinalIgnoreCase) Then
                Continue For
            End If

            Dim replaced = Regex.Replace(content, Regex.Escape(oldId), newId, RegexOptions.IgnoreCase)
            If Not String.Equals(replaced, content, StringComparison.Ordinal) Then
                content = replaced
                changed = True
            End If
        Next

        If changed Then
            File.WriteAllText(rootTemplatePath, content, Encoding.UTF8)
        End If
    End Sub

    Private Sub NormalizeUtamGroupInDestination(destinationRoot As String, targetVisibleName As String)
        If String.IsNullOrWhiteSpace(targetVisibleName) Then
            Return
        End If

        Dim lsxPattern As New Regex("(<attribute\s+id=""UTAM_Group""[^>]*value="")([^""]*)("")", RegexOptions.IgnoreCase)
        Dim txtPattern As New Regex("(""(?:UTAM_Group)""\s*"")([^""]*)("")", RegexOptions.IgnoreCase)

        For Each filePath In Directory.GetFiles(destinationRoot, "*", SearchOption.AllDirectories)
            Dim ext = Path.GetExtension(filePath)
            If Not TextExtensions.Contains(ext) Then
                Continue For
            End If

            Dim content = File.ReadAllText(filePath)
            Dim rewritten = lsxPattern.Replace(content, "$1" & targetVisibleName & "$3")
            rewritten = txtPattern.Replace(rewritten, "$1" & targetVisibleName & "$3")

            If Not String.Equals(rewritten, content, StringComparison.Ordinal) Then
                File.WriteAllText(filePath, rewritten, Encoding.UTF8)
            End If
        Next
    End Sub

    Private Sub WriteUtamConfigForClone(destinationRoot As String,
                                        targetModFolderName As String,
                                        fallbackVisibleName As String,
                                        preferredModUuid As String,
                                        generateNewCloneUuid As Boolean)
        Dim metaPath = Path.Combine(destinationRoot, "Mods", targetModFolderName, "meta.lsx")
        If Not File.Exists(metaPath) Then
            Return
        End If

        Dim createdFolderName = New DirectoryInfo(destinationRoot).Name

        Dim metaDoc = XDocument.Load(metaPath)
        Dim modName = metaDoc.Descendants("attribute").
            Where(Function(a) String.Equals(CStr(a.Attribute("id")), "Name", StringComparison.OrdinalIgnoreCase)).
            Select(Function(a) CStr(a.Attribute("value"))).
            FirstOrDefault()

        Dim modUuid As String
        If generateNewCloneUuid Then
            modUuid = Guid.NewGuid().ToString()
        Else
            modUuid = preferredModUuid
            If String.IsNullOrWhiteSpace(modUuid) Then
                Throw New InvalidOperationException("No hay UUID previo para conservar en la sobreescritura del clone.")
            End If
        End If

        If String.IsNullOrWhiteSpace(modName) Then
            modName = fallbackVisibleName
        End If
        If String.IsNullOrWhiteSpace(modName) Then
            modName = targetModFolderName
        End If

        Dim uuidAttributes = metaDoc.Descendants("attribute").
            Where(Function(a) String.Equals(CStr(a.Attribute("id")), "UUID", StringComparison.OrdinalIgnoreCase)).
            ToList()

        If uuidAttributes.Count > 0 Then
            For Each uuidAttr In uuidAttributes
                uuidAttr.SetAttributeValue("value", modUuid)
            Next
            metaDoc.Save(metaPath)
        End If

        Dim parentDir = Directory.GetParent(destinationRoot)?.FullName
        If String.IsNullOrWhiteSpace(parentDir) Then
            Return
        End If

        Dim fileSafeName = BuildSafeFileName(modName)
        Dim utamPath = Path.Combine(parentDir, fileSafeName & ".utam")

        Dim json = String.Join(Environment.NewLine, {
            "{",
            $"  ""SaveFolder"": ""{EscapeJson(createdFolderName)}"",",
            "  ""BuildPak"": true,",
            "  ""BuildZip"": true,",
            "  ""BuildModFixer"": true,",
            "  ""AddToGame"": true,",
            "  ""ShinyhoboCompatible"": true,",
            "  ""PackPriority"": 30,",
            $"  ""SaveUUID"": ""{EscapeJson(modUuid)}""",
            "}"
        })

        File.WriteAllText(utamPath, json, Encoding.UTF8)
    End Sub

    Private Function BuildSafeFileName(value As String) As String
        Dim cleaned = value
        For Each ch In Path.GetInvalidFileNameChars()
            cleaned = cleaned.Replace(ch, "_"c)
        Next

        cleaned = cleaned.Trim()
        If String.IsNullOrWhiteSpace(cleaned) Then
            Return "Mod"
        End If

        Return cleaned
    End Function

    Private Function EscapeJson(value As String) As String
        If value Is Nothing Then
            Return String.Empty
        End If

        Return value.Replace("\", "\\").Replace("""", "\""")
    End Function

    Private Sub RunConversionBatIfPresent(destinationRoot As String, targetModFolderName As String)
        Dim batPath = Path.Combine(destinationRoot, "Generated", "Public", targetModFolderName, "Assets", "convert_to_dds_texconv.bat")
        If Not File.Exists(batPath) Then
            Return
        End If

        Dim psi As New ProcessStartInfo() With {
            .FileName = "cmd.exe",
            .Arguments = $"/c ""{batPath}""",
            .WorkingDirectory = Path.GetDirectoryName(batPath),
            .UseShellExecute = False,
            .CreateNoWindow = True,
            .RedirectStandardInput = True,
            .RedirectStandardOutput = True,
            .RedirectStandardError = True
        }

        Using process As Process = Process.Start(psi)
            If process Is Nothing Then
                Throw New InvalidOperationException("No se pudo iniciar el .bat de conversion a DDS.")
            End If

            process.StandardInput.WriteLine()
            process.StandardInput.Close()

            Dim output = process.StandardOutput.ReadToEnd()
            Dim [error] = process.StandardError.ReadToEnd()
            process.WaitForExit()

            If process.ExitCode <> 0 Then
                Dim details = (output & Environment.NewLine & [error]).Trim()
                Throw New InvalidOperationException("Fallo la conversion DDS con el .bat." & Environment.NewLine & details)
            End If
        End Using
    End Sub
End Class
