Imports System.IO

Public Class Form1
    Dim stromy As New List(Of Point)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        stromy.Clear()
        Dim s() As String
        s = TextBox1.Text.Split(Environment.NewLine)        'cteni
        For Each st As String In s
            Try
                stromy.Add(New Point(st.Split(" ")(0), st.Split(" ")(1)))   'pridani souradnic do listu
            Catch
            End Try

        Next
        PictureBox1.Refresh()

    End Sub
    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint
        For Each p As Point In stromy
            p.Offset(-1, -1)
            e.Graphics.FillRectangle(Brushes.Black, New Rectangle(p, New Size(2, 2)))   'vykresleni
        Next

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim sr As New StreamReader(OpenFileDialog1.FileName)    'nasteni ze souboru
            sr.ReadLine()
            TextBox1.Text = sr.ReadToEnd
            sr.Close()
        End If
    End Sub
End Class
