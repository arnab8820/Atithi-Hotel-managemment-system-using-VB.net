Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class main

    Private Sub main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dashboard.BringToFront()
        Timer1.Start()
        Dim webClient As New System.Net.WebClient
        Dim result As String = webClient.DownloadString("http://quotes.rest/qod.json?category=inspire")
        '"http://api.forismatic.com/api/1.0/?method=getQuote&format=text&lang=en"
        'Dim result As String = System.IO.File.ReadAllText("C:\Users\Arnab\OneDrive\visual_studio_source\project atithi\project atithi\json.txt")
        Try
            Dim jsonobject As JObject = JObject.Parse(result)
            'Dim jsonarray As JArray = JArray.Parse(jsonobject.SelectToken("contents"))
            Dim jsonobject2 As JObject = JObject.Parse(jsonobject.SelectToken("contents").ToString)
            Dim jsonarray As JArray = JArray.Parse(jsonobject2.SelectToken("quotes").ToString)
            Dim jsonobject3 As JObject = JObject.Parse(jsonarray.First.ToString)
            Label20.Text = jsonobject3.SelectToken("quote").ToString & vbNewLine & "- " & jsonobject3.SelectToken("author").ToString
        Catch ex As Newtonsoft.Json.JsonException
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    'dashboard navigation
    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        dashboard.BringToFront()
    End Sub

    Private Sub Label4_MouseEnter(sender As Object, e As EventArgs) Handles Label4.MouseEnter
        Label4.ForeColor = Color.Yellow
    End Sub

    Private Sub Label4_MouseLeave(sender As Object, e As EventArgs) Handles Label4.MouseLeave
        Label4.ForeColor = Color.White
    End Sub
    'dashboard nav end

    'check in nav start
    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        check_in.Show()
    End Sub

    Private Sub Label5_MouseEnter(sender As Object, e As EventArgs) Handles Label5.MouseEnter
        Label5.ForeColor = Color.Yellow
    End Sub

    Private Sub Label5_MouseLeave(sender As Object, e As EventArgs) Handles Label5.MouseLeave
        Label5.ForeColor = Color.White
    End Sub
    'check in nav end

    'check out nav start
    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        check_out.BringToFront()
    End Sub

    Private Sub Label6_MouseEnter(sender As Object, e As EventArgs) Handles Label6.MouseEnter
        Label6.ForeColor = Color.Yellow
    End Sub

    Private Sub Label6_MouseLeave(sender As Object, e As EventArgs) Handles Label6.MouseLeave
        Label6.ForeColor = Color.White
    End Sub
    'check out nav end

    'check status nav start
    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        dashboard.BringToFront()
    End Sub

    Private Sub Label7_MouseEnter(sender As Object, e As EventArgs) Handles Label7.MouseEnter
        Label7.ForeColor = Color.Yellow
    End Sub

    Private Sub Label7_MouseLeave(sender As Object, e As EventArgs) Handles Label7.MouseLeave
        Label7.ForeColor = Color.White
    End Sub
    'check status nav end

    'change password nav start
    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        dashboard.BringToFront()
    End Sub

    Private Sub Label8_MouseEnter(sender As Object, e As EventArgs) Handles Label8.MouseEnter
        Label8.ForeColor = Color.Yellow
    End Sub

    Private Sub Label8_MouseLeave(sender As Object, e As EventArgs) Handles Label8.MouseLeave
        Label8.ForeColor = Color.White
    End Sub
    'change password nav end

    Private Sub proceed_btn_Click(sender As Object, e As EventArgs) Handles proceed_btn.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ListBox1.Items.Add(RichTextBox1.Text)
        RichTextBox1.Text = "Add a note ..."
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If Not IsNothing(ListBox1.SelectedItem) Then
            Label15.Text = ListBox1.SelectedItem.ToString
            Label15.Visible = True
            Label16.Visible = True
            Label17.Visible = True
        End If
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ListBox1.Items.RemoveAt(ListBox1.SelectedIndex)
        Label15.Visible = False
        Label16.Visible = False
        Label17.Visible = False
    End Sub

    Private Sub Label16_Click(sender As Object, e As EventArgs) Handles Label16.Click
        Label15.Visible = False
        Label16.Visible = False
        Label17.Visible = False
    End Sub

    Private Sub RichTextBox1_GotFocus(sender As Object, e As EventArgs) Handles RichTextBox1.GotFocus
        RichTextBox1.Text = ""
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim days() As String = {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"}
        Dim months() As String = {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"}
        Dim today As DateTime = DateTime.Now
        If today.Hour Mod 12 > 10 Then
            Label19.Text = today.Hour Mod 12
        Else
            Label19.Text = "0" & today.Hour Mod 12
        End If
        Label19.Text = Label19.Text & ":"
        If today.Minute > 9 Then
            Label19.Text = Label19.Text & today.Minute
        Else
            Label19.Text = Label19.Text & "0" & today.Minute
        End If
        Label21.Text = days(TimeOfDay.DayOfWeek - 1) & ", " & today.Day & " " & months(today.Month - 1) & ", " & today.Year
    End Sub
End Class