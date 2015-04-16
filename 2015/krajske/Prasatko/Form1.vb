Public Class Form1
    Dim starttime As Date = Now
    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim time As Double = (Now - starttime).Seconds / 2
        If time > 1 Then e.Graphics.DrawLine(Pens.Black, 100, 100, 300, 100)
        If time > 2 Then e.Graphics.DrawLine(Pens.Black, 300, 200, 300, 100)
        If time > 3 Then e.Graphics.DrawLine(Pens.Black, 300, 200, 100, 200)
        If time > 4 Then e.Graphics.DrawLine(Pens.Black, 100, 200, 100, 100)
        If time > 5 Then e.Graphics.DrawLine(Pens.Black, 50, 150, 100, 100)
        If time > 6 Then e.Graphics.DrawLine(Pens.Black, 50, 150, 100, 200)

        If time > 7 Then e.Graphics.DrawLine(Pens.Black, 100, 200, 75, 300)
        If time > 8 Then e.Graphics.DrawLine(Pens.Black, 100, 200, 125, 300)

        If time > 9 Then e.Graphics.DrawLine(Pens.Black, 300, 200, 275, 300)
        If time > 10 Then e.Graphics.DrawLine(Pens.Black, 300, 200, 325, 300)

        If time > 11 Then e.Graphics.DrawLine(Pens.Black, 300, 100, 325, 125)
        If time > 12 Then e.Graphics.DrawEllipse(Pens.Black, 80, 120, 15, 15)
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Me.Refresh()
    End Sub
End Class
