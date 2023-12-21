Imports System.Collections.ObjectModel
Imports System.Data.SqlClient
Public Class Medicinlist
    Dim conn1 As New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Initial Catalog= Project;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
    Private Sub fill()
        Try
            conn1.Open()
            Dim cmd As New SqlCommand("select * from medlist", conn1)
            Dim sdr As SqlDataReader = cmd.ExecuteReader()
            DataGridView1.Rows.Clear()
            While sdr.Read()
                DataGridView1.Rows.Add(sdr(0), sdr(2), sdr(3))
            End While
            conn1.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim conn1 As New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Initial Catalog= Project;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        Dim command As New SqlCommand("insert into medlist values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + ComboBox1.SelectedItem + "')", conn1)
        conn1.Open()
        Try
            If command.ExecuteNonQuery() Then
                MessageBox.Show("Record saved", "information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Record not saved", "information", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        conn1.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim conn As New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Initial Catalog= Project;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        Dim command As New SqlCommand("select * from medlist", conn)
        conn.Open()
        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable
        adapter.Fill(table)
        DataGridView1.DataSource = table
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Dim conn As New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Initial Catalog= Project;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
            Dim command As New SqlCommand("update medlist set mg='" + TextBox2.Text + "',qut='" + TextBox3.Text + "',price='" + TextBox4.Text + "',location='" + ComboBox1.SelectedItem + "' where medname = '" + TextBox1.Text + "'", conn)
            conn.Open()
            command.ExecuteNonQuery()
            conn.Close()
            MsgBox("data Updated")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Try
            Dim index As Integer
            index = e.RowIndex
            Dim selectrow As DataGridViewRow
            selectrow = DataGridView1.Rows(index)
            TextBox1.Text = selectrow.Cells(0).Value.ToString()
            TextBox2.Text = selectrow.Cells(1).Value.ToString()
            TextBox3.Text = selectrow.Cells(2).Value.ToString()
            TextBox4.Text = selectrow.Cells(3).Value.ToString()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim conn As New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Initial Catalog= Project;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
            Dim command As New SqlCommand("delete from medlist where medname = '" + TextBox1.Text + "'", conn)
            conn.Open()
            command.ExecuteNonQuery()
            conn.Close()
            MsgBox("data deleted")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Hide()
        podertrack.Show()
    End Sub


End Class