Public Class login

    Private Sub login_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label4.Hide()
        PictureBox1.Focus()
    End Sub

    Private Sub TextBox1_GotFocus(sender As Object, e As EventArgs) Handles TextBox1.GotFocus
        TextBox1.Text = ""
    End Sub

    Private Sub TextBox2_GotFocus(sender As Object, e As EventArgs) Handles TextBox2.GotFocus
        TextBox2.Text = ""
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql As String
        sql = "select * from atithi.user where userid='" & TextBox1.Text & "' and password='" & TextBox2.Text & "'"
        splash1.com = New MySql.Data.MySqlClient.MySqlCommand(sql, splash1.conn)
        Try
            splash1.reader = splash1.com.ExecuteReader
        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(ex.Message)
        End Try
        Dim count As Integer
        count = 0
        While splash1.reader.Read
            count += 1
        End While
        If count <> 1 Then
            Label4.Show()
        Else
            splash1.username = splash1.reader.GetString("userid")
            splash1.fname = splash1.reader.GetString("fname")
            If (splash1.reader.IsDBNull(4)) Then
                splash1.mname = splash1.reader.GetString("mname")
            End If
            splash1.lname = splash1.reader.GetString("lname")
            splash1.uname = splash1.fname
            If splash1.mname = "" Then
                splash1.uname = splash1.uname & " " & splash1.lname
            Else
                splash1.uname = splash1.uname & " " & splash1.mname & " " & splash1.lname
            End If

            splash2.Label4.Text = "Welcome " & splash1.uname
            splash2.Show()
            splash1.reader.Close()
            Me.Close()
        End If

            'close the reader 
        splash1.reader.Close()
        

    End Sub
End Class