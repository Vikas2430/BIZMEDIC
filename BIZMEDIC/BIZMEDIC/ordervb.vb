Imports System.Collections.ObjectModel
Imports System.Data.SqlClient
Imports System.Windows
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Data

Public Class ordervb
    Dim conn As New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Initial Catalog= Project;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
    Private Sub fill()
        Try
            conn.Open()
            Dim cmd As New SqlCommand("select * from medlist", conn)
            Dim sdr As SqlDataReader = cmd.ExecuteReader()
            DataGridView1.Rows.Clear()
            While sdr.Read()
                DataGridView1.Rows.Add(sdr(0), sdr(2), sdr(3))
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim command As New SqlCommand("select * from medlist", conn)
            conn.Open()
            Dim adapter As New SqlDataAdapter(command)
            Dim table As New DataTable
            adapter.Fill(table)
            DataGridView1.DataSource = table
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Try
            Dim index As Integer
            index = e.RowIndex
            Dim row As DataGridViewRow
            row = DataGridView1.Rows(index)
            TextBox1.Text = row.Cells(0).Value.ToString()
            TextBox3.Text = row.Cells(3).Value.ToString()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub combo1()
        conn.Open()
        Dim command As New SqlCommand("select distinct location from medlist", conn)
        Dim myreader As SqlClient.SqlDataReader = command.ExecuteReader
        ComboBox1.Items.Clear()
        While myreader.Read()
            ComboBox1.Items.Add(myreader("location"))
        End While
        conn.Close()
    End Sub

    Private Sub ordervb_Load(sender As Object, e As EventArgs) Handles Me.Load
        combo1()
        display_datagrig()
        gettraid()

    End Sub
    Private Sub display_datagrig()
        conn.Open()
        Dim command As New SqlCommand("select * from medlist where location like '%" + ComboBox1.Text + "%'", conn)
        Dim dal1 As New SqlDataAdapter
        Dim dtl1 As New DataTable
        dal1.SelectCommand = command
        dtl1.Clear()
        dal1.Fill(dtl1)
        DataGridView1.DataSource = dtl1
        conn.Close()

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        display_datagrig()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim conn As New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Initial Catalog= Project;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
            Dim command As New SqlCommand("insert into order1 values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + ComboBox1.SelectedItem + "','" + TextBox5.Text + "','" + TextBox6.Text + "')", conn)
            conn.Open()
            If command.ExecuteNonQuery() Then
                MessageBox.Show("Record saved", "information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Record not saved", "information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox4.Text = Val(TextBox2.Text * TextBox3.Text)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Hide()
        payment.Show()
    End Sub
    Dim con As New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Initial Catalog= Project;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
    Public cmd As SqlCommand
    Public da As SqlDataAdapter
    Public dr As SqlDataReader
    Public traid As String
    Public query As String
    Public sql As String


    Private Sub gettraid()
        con.Open()
        Try
            Dim cmd As New SqlCommand("select traid from order1 order by traid Desc", con)
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If (dr.Read) = True Then
                Dim id As Integer
                id = (dr(0) + 1)
                traid = id.ToString("000")
            ElseIf IsDBNull(dr) Then
                traid = ("001")
            Else
                traid = ("001")

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
            TextBox5.Text = traid
        End Try
    End Sub
End Class