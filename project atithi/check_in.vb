Public Class check_in
    Dim no_of_dep As Integer
    Dim room(10) As Integer
    Dim double_room, single_room As Integer
    Dim cust_id As Integer
    Private Sub check_in_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label10.Focus()
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        dependent_info.Show()
        Label5.Text = TextBox23.Text
        no_of_dep = Val(Label5.Text)
        Label4.Text = Label4.Text & Label5.Text
        Dim sql As String
        sql = "insert into customer (fname, mname, lname, address_line1, address_line2, city, state, pincode, gender, dob, nationality, religion, blood_group, id_proof, id_proof_no, dependent)"
        sql = sql & "values (" & "'" & TextBox16.Text & "', " & "'" & TextBox17.Text & "', " & "'" & TextBox18.Text & "', " & "'" & TextBox15.Text & "', " & "'" & TextBox12.Text & "', " & "'" & TextBox13.Text & "', " & "'" & ComboBox9.SelectedItem & "', " & "'" & TextBox14.Text & "', " & "'" & ComboBox10.SelectedItem & "', " & "'" & TextBox24.Text & "', " & "'" & ComboBox14.SelectedItem & "', " & "'" & ComboBox13.SelectedItem & "', " & "'" & ComboBox11.SelectedItem & "', " & "'" & ComboBox12.SelectedItem & "', " & "'" & TextBox20.Text & "', " & "'" & TextBox23.Text & "'" & ")"
        splash1.com = New MySql.Data.MySqlClient.MySqlCommand(sql, splash1.conn)
        Try
            splash1.reader = splash1.com.ExecuteReader
            splash1.reader.Close()
        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(ex.Message)
        End Try

        sql = "select max(cust_id) from customer"
        splash1.com = New MySql.Data.MySqlClient.MySqlCommand(sql, splash1.conn)
        Try
            splash1.reader = splash1.com.ExecuteReader
        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(ex.Message)
        End Try
        If splash1.reader.Read Then
            cust_id = Val(splash1.reader.GetString("max(cust_id)"))
        End If
        splash1.reader.Close()

        Dim i As Integer = 0
        While room(i) <> 0
            sql = "update room set closed = 1 where room_no = " & room(i)
            splash1.com = New MySql.Data.MySqlClient.MySqlCommand(sql, splash1.conn)
            Try
                splash1.reader = splash1.com.ExecuteReader
                splash1.reader.Close()
            Catch ex As MySql.Data.MySqlClient.MySqlException
                MessageBox.Show(ex.Message)
            End Try
            Dim today As DateTime = DateTime.Now
            sql = "insert into room_booking values ('" & cust_id & "', '" & room(i) & "', '" & today.Year & "-" & today.Month & "-" & today.Day & "')"
            splash1.com = New MySql.Data.MySqlClient.MySqlCommand(sql, splash1.conn)
            Try
                splash1.reader = splash1.com.ExecuteReader
                splash1.reader.Close()
            Catch ex As MySql.Data.MySqlClient.MySqlException
                MessageBox.Show(ex.Message)
            End Try
            i += 1
        End While
    End Sub

    Private Sub TextBox1_HandleDestroyed(sender As Object, e As EventArgs) Handles TextBox1.HandleDestroyed

    End Sub

    Private Sub TextBox16_GotFocus(sender As Object, e As EventArgs) Handles TextBox16.GotFocus
        TextBox16.Text = ""
    End Sub
    Private Sub TextBox17_GotFocus(sender As Object, e As EventArgs) Handles TextBox17.GotFocus
        TextBox17.Text = ""
    End Sub
    Private Sub TextBox18_GotFocus(sender As Object, e As EventArgs) Handles TextBox18.GotFocus
        TextBox18.Text = ""
    End Sub
    Private Sub TextBox15_GotFocus(sender As Object, e As EventArgs) Handles TextBox15.GotFocus
        TextBox15.Text = ""
    End Sub
    Private Sub TextBox12_GotFocus(sender As Object, e As EventArgs) Handles TextBox12.GotFocus
        TextBox12.Text = ""
    End Sub
    Private Sub TextBox13_GotFocus(sender As Object, e As EventArgs) Handles TextBox13.GotFocus
        TextBox13.Text = ""
    End Sub
    Private Sub TextBox14_GotFocus(sender As Object, e As EventArgs) Handles TextBox14.GotFocus
        TextBox14.Text = ""
    End Sub
    Private Sub TextBox24_GotFocus(sender As Object, e As EventArgs) Handles TextBox24.GotFocus
        TextBox24.Text = ""
    End Sub
    Private Sub TextBox20_GotFocus(sender As Object, e As EventArgs) Handles TextBox20.GotFocus
        TextBox20.Text = ""
    End Sub
    Private Sub TextBox23_GotFocus(sender As Object, e As EventArgs) Handles TextBox23.GotFocus
        TextBox23.Text = ""
    End Sub

    Private Sub ComboBox9_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox9.SelectedIndexChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        'save to database
        Dim sql As String
        sql = "insert into dependent_info (customer_id, fname, mname, lname, gender, dob, blood_group, id_proof, id_proof_no)"
        sql = sql & "values (" & "'" & cust_id & "', " & "'" & TextBox19.Text & "', " & "'" & TextBox25.Text & "', " & "'" & TextBox26.Text & "', " & "'" & ComboBox19.SelectedItem & "', " & "'" & TextBox28.Text & "', " & "'" & ComboBox17.SelectedItem & "', " & "'" & ComboBox18.SelectedItem & "', " & "'" & TextBox27.Text & "'" & ")"
        splash1.com = New MySql.Data.MySqlClient.MySqlCommand(sql, splash1.conn)
        Try
            splash1.reader = splash1.com.ExecuteReader
            splash1.reader.Close()
        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(ex.Message)
        End Try
        no_of_dep -= 1
        Label4.Text = "Remaining: " & no_of_dep
        If no_of_dep = 0 Then
            MsgBox("complete!")
        Else
            TextBox19.Text = "Firstname"
            dependent_info.Refresh()
        End If
    End Sub

    Private Sub ComboBox15_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox15.SelectedIndexChanged
        suggestion.Text = ""
        Dim sql As String
        Dim singl, doubl As Integer
        singl = Val(TextBox29.Text)
        doubl = Val(TextBox22.Text)
        Dim i As Integer = 0
        Dim Generator As System.Random = New System.Random()
        Dim offset As Integer = Generator.Next(0, 40)

        If singl > 0 Then
            sql = "select room_no from room where bed=1 and closed=0 and type='" & ComboBox15.SelectedItem & "' limit " & offset & ", 1234"
            splash1.com = New MySql.Data.MySqlClient.MySqlCommand(sql, splash1.conn)
            Try
                splash1.reader = splash1.com.ExecuteReader
            Catch ex As MySql.Data.MySqlClient.MySqlException
                MessageBox.Show(ex.Message)
            End Try

            While i < singl And splash1.reader.Read
                room(i) = Val(splash1.reader.GetString("room_no"))
                i += 1
            End While
            splash1.reader.Close()
        End If
        If doubl > 0 Then
            sql = "select room_no from room where bed=2 and closed=0 and type='" & ComboBox15.SelectedItem & "' limit " & offset & ", 1234"
            splash1.com = New MySql.Data.MySqlClient.MySqlCommand(sql, splash1.conn)
            Try
                splash1.reader = splash1.com.ExecuteReader
            Catch ex As MySql.Data.MySqlClient.MySqlException
                MessageBox.Show(ex.Message)
            End Try
            Dim j As Integer = 0
            While j < doubl And splash1.reader.Read
                room(i) = splash1.reader.GetString("room_no") & ", "
                i += 1
                j += 1
            End While
            splash1.reader.Close()
        End If
        suggestion.Text = "Rooms selected: "
        For index = 0 To 10
            If room(index) <> 0 Then
                suggestion.Text &= room(index).ToString & " "
            End If

        Next

    End Sub

    Private Sub TextBox23_TextChanged(sender As Object, e As EventArgs) Handles TextBox23.TextChanged
        
    End Sub
End Class