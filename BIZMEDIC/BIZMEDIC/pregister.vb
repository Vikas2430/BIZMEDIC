Imports System.Data.SqlClient
Public Class pregister
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
        If TextBox6.Text = "" Then
            TextBox6.Focus()
            MsgBox("enter the data")
            Exit Sub
        End If
        If TextBox7.Text = "" Then
            TextBox7.Focus()
            MsgBox("enter the data")
            Exit Sub
        End If

        Dim conn As New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Initial Catalog= Project;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        Dim command As New SqlCommand("insert into wreg(odname,phno,shname,location,lg,pass,gst) values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "')", conn)
        Dim command1 As New SqlCommand("insert into log1(login,pass) values('" + TextBox5.Text + "','" + TextBox6.Text + "')", conn)

        Try
            conn.Open()
            If command.ExecuteNonQuery() And command1.ExecuteNonQuery Then
                MessageBox.Show("Registration done", "information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Hide()
                login.Show()
            Else
                MessageBox.Show("not done", "information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
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
        If Not Char.IsLetter(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) And Not e.KeyChar = Chr(Keys.Space) Then
            e.Handled = True
            MessageBox.Show(" this field will accept letter only")
        End If
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        If Not Char.IsLetter(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) And Not e.KeyChar = Chr(Keys.Space) Then
            e.Handled = True
            MessageBox.Show(" this field will accept letter only")
        End If
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        If Not Char.IsLetter(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) And Not e.KeyChar = Chr(Keys.Space) Then
            e.Handled = True
            MessageBox.Show(" this field will accept letter only")
        End If
    End Sub

    Private Sub TextBox7_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox7.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) And Not e.KeyChar = Chr(Keys.Space) Then
            e.Handled = True
            MessageBox.Show(" this field will accept numbers only")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        pintro.Show()
    End Sub
End Class