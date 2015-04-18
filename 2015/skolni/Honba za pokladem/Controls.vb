Public Class Controls
    Event polickoSizeChanged(sender As Object, e As EventArgs)
    Event pohyb(sender As Object, e As EventArgs)
    Private Sub Button_Click(sender As Object, e As EventArgs) Handles Button4.Click, Button3.Click, Button2.Click, Button1.Click
        RaiseEvent pohyb(sender, e)
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        RaiseEvent polickoSizeChanged(NumericUpDown1, EventArgs.Empty)
    End Sub

    Private Sub Controls_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class