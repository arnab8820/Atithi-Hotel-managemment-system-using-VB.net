Public Class splash2
    Dim i As Integer = 0
    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub splash2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If i = 20 Then
            Timer1.Stop()
            main.Show()
            Me.Close()
        End If
        i += 1
    End Sub
End Class
