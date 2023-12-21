Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Userreg
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
        If TextBox2.TextLength <= 9 Then
            MsgBox("enter proper number")
            Exit Sub
        End If
        If TextBox3.Text = "" Then
            TextBox3.Focus()
            MsgBox("enter the data")
            Exit Sub
        End If
        If TextBox4.Text = "" Then
            TextBox4.Focus()
            MsgBox("enter the data")
            Exit Sub
        End If
        If TextBox5.Text = "" Then
            TextBox5.Focus()
            MsgBox("enter the data")
            Exit Sub
        End If

        Dim conn As New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Initial Catalog= Project;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        Dim command As New SqlCommand("insert into userreg(name,phno,email,uname,pass) values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "')", conn)

        Try
            conn.Open()
            If command.ExecuteNonQuery() Then
                MessageBox.Show("Registration done", "information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Hide()
                userlogin.Show()
            Else
                MessageBox.Show("not done", "information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        mainintro.Show()
    End Sub


    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) And Not e.KeyChar = Chr(Keys.Space) Then
            e.Handled = True
            MessageBox.Show(" this field will accept numbers only")
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Not Char.IsLetter(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) And Not e.KeyChar = Chr(Keys.Space) Then
            e.Handled = True
            MessageBox.Show(" this field will accept letter only")
        End If
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress

    End Sub

    Private Sub Userreg_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class