Imports System.Data.SqlClient
Public Class payment
    Dim conn As New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Initial Catalog= Project;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If RadioButton1.Checked = True Then
            Dim command As New SqlCommand("insert into payment(paymentmode,transaction_id) values('cod','-')", conn)
            conn.Open()

            Try
                If command.ExecuteNonQuery() Then
                    MessageBox.Show("Payment Successful", "information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Payment not Successful", "information", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            conn.Close()
        End If
        If RadioButton2.Checked = True Then
            Dim command1 As New SqlCommand("insert into payment(paymentmode,transaction_id) values('online','" + TextBox1.Text + "')", conn)
            conn.Open()
            Try
                If command1.ExecuteNonQuery() Then
                    MessageBox.Show("Payment Successful", "information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Payment not Successful", "information", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            conn.Close()
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) And Not e.KeyChar = Chr(Keys.Space) Then
            e.Handled = True
            MessageBox.Show(" this field will accept numbers only")
        End If
    End Sub
End Class