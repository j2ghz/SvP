Imports System.IO

Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then 'dialog pro vyber souboru
            TextBox1.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox2.Text = My.Computer.FileSystem.ReadAllText(TextBox1.Text)       'otevreni vstupu
        TextBox2.Text &= Environment.NewLine & "VYSLEDEK:" & Environment.NewLine
        Dim rr As New StreamReader(TextBox1.Text)
        Dim wr As New StreamWriter(Path.Combine(Path.GetDirectoryName(TextBox1.Text), "vystup.txt"))    'otevreni vystupu
        While Not rr.EndOfStream
            Dim radek() = rr.ReadLine.Split(" ")    'nasteni radku
            Dim a As Long = radek(0)
            Dim b As Long = radek(1)
            Dim c As Long = radek(2)
            Dim d As Long = radek(3)
            Dim x As Long
            Dim z As Long
            Dim y As Long
            z = b * d
            y = a * d + b * c   'vypocet zlomku
            x = 0
            If y >= z Then  'prevod na slozene cislo
                x = z / y
                y = y - (x * z)
            End If
            If y = 0 Then   'pokud je cislo cele
                z = 0
            ElseIf y > 1 And y < 1000000 Then    'zkraceni zlomku, pro velka cisla dlouho, proto omzeneni
                For i As Long = y To 2 Step -1
                    If y Mod i = 0 AndAlso z Mod i = 0 Then
                        y = y / i
                        z = z / i
                    End If
                    Application.DoEvents()
                Next
            End If
            wr.WriteLineAsync(String.Join(" ", x, y, z))        'zapis do souboru a na obrazovku
            TextBox2.Text &= String.Join(" ", x, y, z) & Environment.NewLine
        End While
        TextBox2.Text &= Path.Combine(Path.GetDirectoryName(TextBox1.Text), "vystup.txt")
        rr.Close()
        wr.Close()  'zavrani souboru
    End Sub
End Class
