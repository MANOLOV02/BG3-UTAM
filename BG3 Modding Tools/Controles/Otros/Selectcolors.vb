Public Class Selectcolors


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim xx As New ColorDialog
        xx.Color = PictureBox1.BackColor
        If xx.ShowDialog() = DialogResult.OK Then
            PictureBox1.BackColor = xx.Color
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim xx As New ColorDialog
        xx.Color = PictureBox2.BackColor
        If xx.ShowDialog() = DialogResult.OK Then
            PictureBox2.BackColor = xx.Color
        End If

    End Sub
End Class