Public Class mainintro
    Private Sub CustomerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomerToolStripMenuItem.Click
        Me.Hide()
        cintro.Show()
    End Sub

    Private Sub PharmacyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PharmacyToolStripMenuItem.Click
        Me.Hide()
        pintro.Show()
    End Sub

    Private Sub AboutUsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AboutUsToolStripMenuItem1.Click
        Me.Hide()
        about.Show()
    End Sub

    Private Sub ContactUsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ContactUsToolStripMenuItem.Click
        Me.Hide()
        contactus.Show()
    End Sub

    Private Sub AboutFoundersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutFoundersToolStripMenuItem.Click
        Me.Hide()
        founder.Show()

    End Sub

    Private Sub mainintro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
    End Sub
End Class