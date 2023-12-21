Imports System.Data.SqlClient
Public Class login
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            TextBox1.Focus()
            MsgBox("enter the data")
            Exit Sub
        End If
        If TextBox2.Text = "" Then
            TextBox2.Focus()
            MsgBox("enter the data")
            Exit Sub
        End If
        Dim conn As New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Initial Catalog= Project;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        Dim command As New SqlCommand("select * from log1 where login='" + TextBox1.Text + "' and pass='" + TextBox2.Text + "'", conn)
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet()
        conn.Open()
        Try
            command.Connection = conn
            da.SelectCommand = command
            da.Fill(ds, "log1")
            If (ds.Tables("log1").Rows.Count > 0) Then
                MessageBox.Show("Login success welcome to BIZMEDIC", "Infromation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Hide()
                Medicinlist.Show()
            Else
                MessageBox.Show("incorrect username or password,try again", "Infromation", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        pintro.Show()
    End Sub
End Class