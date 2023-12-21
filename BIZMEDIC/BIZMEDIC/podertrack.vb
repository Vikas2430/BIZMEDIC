Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class podertrack
    Dim conn1 As New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Initial Catalog= Project;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim conn As New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Initial Catalog= Project;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        Dim command As New SqlCommand("select * from order1", conn)
        conn.Open()
        Try
            Dim adapter As New SqlDataAdapter(command)
            Dim table As New DataTable
            adapter.Fill(table)
            DataGridView1.DataSource = table
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
        Dim command1 As New SqlCommand("select * from payment", conn)
        Try
            Dim adapter As New SqlDataAdapter(command1)
            Dim table As New DataTable
            adapter.Fill(table)
            DataGridView2.DataSource = table
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim command As New SqlCommand("insert into tracking values('" + TextBox1.Text + "','" + TextBox2.Text + "')", conn1)
        conn1.Open()
        Try
            If command.ExecuteNonQuery() Then
                MessageBox.Show("Record saved", "information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Record not saved", "information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn1.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim command As New SqlCommand("delete from order1 where traid = '" + TextBox2.Text + "'", conn1)
            conn1.Open()
            command.ExecuteNonQuery()
            conn1.Close()
            MsgBox("data deleted")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try
            Dim command1 As New SqlCommand("delete from payment where transaction_id = '" + TextBox3.Text + "'", conn1)
            conn1.Open()
            command1.ExecuteNonQuery()
            conn1.Close()
            MsgBox("data deleted")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class