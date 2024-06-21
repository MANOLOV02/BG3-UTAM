Imports System.IO
Imports System.Security.Policy
Imports System.Text
Imports LSLib.LS

Public NotInheritable Class AboutBox1

    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Establezca el título del formulario.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("Acerca de {0}", ApplicationTitle)

        Label3.Text = "Acknowledgements:" + vbCrLf
        Label3.Text += "• NorByte for its LSLIB Library without which anything of this would be impossible (https://github.com/Norbyte/lslib)" + vbCrLf
        Label3.Text += "• Nickbabcock for simplifying DDS file processing with Pfim (https://github.com/nickbabcock/Pfim)" + vbCrLf
        Label3.Text += "• ShynyHobo for the inspiration provided by its Multitool (https://github.com/ShinyHobo/BG3-Modders-Multitool)"
        LinkLabel1.Links.Add(0, "https://www.nexusmods.com/baldursgate3/mods/9035".Length, "https://www.nexusmods.com/baldursgate3/mods/9035")
        LinkLabel2.Links.Add(0, "https://github.com/MANOLOV02/BG3-UTAM".Length, "https://github.com/MANOLOV02/BG3-UTAM")
        ' Inicialice todo el texto mostrado en el cuadro Acerca de.
        ' TODO: personalice la información del ensamblado de la aplicación en el panel "Aplicación" del 
        '    cuadro de diálogo propiedades del proyecto (bajo el menú "Proyecto").
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub


    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked, LinkLabel2.LinkClicked
        Try
            Process.Start(New ProcessStartInfo(CType(e.Link.LinkData, String)) With {.UseShellExecute = True})
        Catch ex As Exception

        End Try
    End Sub
End Class
