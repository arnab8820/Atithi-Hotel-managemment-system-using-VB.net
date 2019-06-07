Imports MySql.Data
Public Class splash1

    Dim login As Object
    Public conn As MySqlClient.MySqlConnection
    Public com As MySqlClient.MySqlCommand
    Public reader As MySqlClient.MySqlDataReader

    'defining global variables to be used throughout the program
    Public username As String
    Public fname As String
    Public mname As String
    Public lname As String
    Public uname As String


    Private Sub splash1_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        
    End Sub
    Private Sub splash1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        PictureBox2.Width += 2
        Label4.Text = "Loading(" + (PictureBox2.Width / 2).ToString + "%)..."
        If PictureBox2.Width = 40 Then
            conn = New MySqlClient.MySqlConnection
            conn.ConnectionString = "server=localhost;userid=root;password=password;database=atithi"
            Try
                conn.Open()
            Catch Ex As MySqlClient.MySqlException
                MessageBox.Show(Ex.Message)
            End Try
        End If
        If PictureBox2.Width = 200 Then
            Timer1.Stop()
            'debug point
            Global.project_atithi.check_in.Show()
            Me.Hide()
        End If
    End Sub
End Class
