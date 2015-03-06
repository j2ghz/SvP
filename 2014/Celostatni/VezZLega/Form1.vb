Imports System.IO

Public Class Form1
    Dim sr As StreamReader
    Const z As Integer = 20 'zvetseni
    Dim patra As New List(Of Image)

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            TextBox1.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        ProgressBar1.Style = ProgressBarStyle.Marquee
        Dim di As New DirectoryInfo(TextBox1.Text)
        For Each File In di.GetFiles().OrderBy(Function(i) i.Name)
            If File.Extension.ToLower = ".in" Then
                sr = New StreamReader(File.FullName)
                Dim velikosttyp = sr.ReadLine.Split(CChar(" "))
                generuj(velikosttyp(0), velikosttyp(1), velikosttyp(2), sr, File.FullName & ".70")
            End If
        Next
    End Sub

    Private Sub generuj(velikostx As String, velikosty As String, typ As String, sr As StreamReader, name As String)
        'If typ = "P" Then
        Dim kostky As New List(Of kostka)
        While Not sr.EndOfStream
            Dim line = removeempty(sr.ReadLine.ToLower.Split(CChar(" ")))
            Dim k As New kostka
            k.barva = color(line(0))
            k.x = CByte(line(1).Split(CChar("x")).Max)
            k.y = CByte(line(1).Split(CChar("x")).Min)
            For i As Integer = 1 To CInt(line(2))
                kostky.Add(k)
            Next
        End While
        postav(velikostx, velikosty, typ, kostky, name)
        'End If
    End Sub
    Function color(barva As String) As Color
        Select Case barva
            Case "A"
                Return color.FromArgb(0, 255, 255)
            Case "R"
                Return color.FromArgb(255, 0, 0)
            Case "G"
                Return color.FromArgb(0, 255, 0)
            Case "B"
                Return color.FromArgb(0, 0, 255)
            Case "Y"
                Return color.FromArgb(255, 255, 0)
        End Select
    End Function

    Private Function removeempty(p1 As String()) As String()
        Dim p(100) As String
        Dim i = 0
        For Each po As String In p1
            If Not po = "" Then
                p(i) = po
                i += 1
            End If
        Next
        Return p
    End Function

    Private Sub postav(velikostx As String, velikosty As String, typ As String, kostky As List(Of kostka), name As String)
        Dim sw As New StreamWriter(name, False)
        sw.WriteLine(velikostx & " " & velikosty & " " & typ)
        Dim stavim As Boolean = True
        Dim cisopatra As Integer = 1
        While stavim
            Dim patro(CInt(velikostx), CInt(velikosty)) As Boolean
            For x As Integer = 0 To CInt(velikostx)
                For y As Integer = 0 To CInt(velikosty)
                    If patro(x, y) = False Then
                        For i As Integer = 0 To kostky.Count - 1
                            If vlezese(kostky(i).x, kostky(i).y, patro, x, y) Then
                                poloz(patro, x, y, kostky(i).x, kostky(i).y)
                            ElseIf vlezese(kostky(i).y, kostky(i).x, patro, x, y) Then
                                poloz(patro, x, y, kostky(i).y, kostky(i).x)
                            End If
                            Application.DoEvents()
                        Next
                    End If
                Next
            Next
        End While
    End Sub

    Private Function vlezese(kostkax As Integer, kostkay As Integer, patro As Boolean(,), x As Integer, y As Integer) As Boolean
        For xx = 0 To kostkax
            For yy = 0 To kostkay
                If patro(xx, yy) = True Then
                    Return False
                End If
            Next
        Next
        Return True
    End Function

    Private Sub poloz(patro As Boolean(,), x As Integer, y As Integer, x1 As Byte, y1 As Byte)
        For xx = 0 To x1
            For yy = 0 To y1
                    patro(x + x1, y + y1) = True
            Next
        Next
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            TextBox2.Text = OpenFileDialog1.FileName
        End If
    End Sub


    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        patra.Clear()
        ListBox1.Items.Clear()
        For i = 1 To 21
            patra.Add(New Bitmap(400, 400))
        Next
        Dim sr As New StreamReader(TextBox2.Text)
        sr.ReadLine()
        Dim d As New Dictionary(Of String, Integer)
        While Not sr.EndOfStream
            Dim line = removeempty(sr.ReadLine.Split(CChar(" ")))
            If Not line(4) = Nothing Then
                Dim nazev = line(3) & " " & uprav(line(4))
                If d.ContainsKey(nazev) Then
                    d(nazev) += 1
                Else
                    d.Add(nazev, 1)
                End If
                Dim g = Graphics.FromImage(patra(CInt(line(0))))
                g.FillRectangle(New SolidBrush(color(line(3))), z * CInt(line(1)), z * CInt(line(2)), z * CInt(line(4).ToLower.Split(CChar("x"))(0)), z * CInt(line(4).ToLower.Split(CChar("x"))(1)))
                g.DrawRectangle(Pens.Black, z * CInt(line(1)), z * CInt(line(2)), z * CInt(line(4).ToLower.Split(CChar("x"))(0)), z * CInt(line(4).ToLower.Split(CChar("x"))(1)))
                g.Save()
            End If
        End While
        For Each kost In d
            If Not kost.Key = " " Then ListBox1.Items.Add(kost.Key & " - " & kost.Value)
        Next
        PictureBox1.Enabled = True
        ListBox1.Enabled = True
        GroupBox1.Enabled = True
        AcceptButton = Button5
    End Sub

    Private Function uprav(line As String) As String
        Dim l = line.ToLower.Split(CChar("x"))
        If l(0) < l(1) Then
            Return l(0) & "x" & l(1)
        Else
            Return l(1) & "x" & l(0)
        End If
    End Function

    Private Sub NumericUpDown1_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NumericUpDown1.ValueChanged
        RadioButton1.Checked = True
        PictureBox1.Enabled = True
        PictureBox1.Image = patra(CInt(NumericUpDown1.Value))
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        Dim sr As New StreamReader(TextBox2.Text)
        Dim rozm = removeempty(sr.ReadLine().Split(CChar(" ")))
        Dim b As New Bitmap(400, 400)
        Dim g = Graphics.FromImage(b)
        If RadioButton2.Checked Then
            While Not sr.EndOfStream
                Dim line = removeempty(sr.ReadLine.Split(CChar(" ")))
                If Not line(4) = Nothing And CDbl(line(1)) = 1 Then
                    line(1) = line(0)
                    Dim nazev = line(3) & " " & uprav(line(4))
                    g.FillRectangle(New SolidBrush(color(line(3))), z * CInt(line(1)), z * CInt(line(2)), z, z * CInt(line(4).ToLower.Split(CChar("x"))(1)))
                    g.DrawRectangle(Pens.Black, z * CInt(line(1)), z * CInt(line(2)), z, z * CInt(line(4).ToLower.Split(CChar("x"))(1)))
                    g.Save()
                End If
            End While
            PictureBox1.Image = b
            PictureBox1.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
        ElseIf RadioButton1.Checked = True Then
            b = CType(patra(CInt(NumericUpDown1.Value)), Bitmap)

        ElseIf RadioButton3.Checked = True Then
            While Not sr.EndOfStream
                Dim line = removeempty(sr.ReadLine.Split(CChar(" ")))
                If Not line(4) = Nothing And CDbl(line(2)) = 1 Then
                    line(2) = line(0)
                    Dim nazev = line(3) & " " & uprav(line(4))
                    g.FillRectangle(New SolidBrush(color(line(3))), z * CInt(line(1)), z * CInt(line(2)), z * CInt(line(4).ToLower.Split(CChar("x"))(0)), z)
                    g.DrawRectangle(Pens.Black, z * CInt(line(1)), z * CInt(line(2)), z * CInt(line(4).ToLower.Split(CChar("x"))(0)), z)
                    g.Save()
                End If
            End While
            PictureBox1.Image = b
            PictureBox1.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
        ElseIf RadioButton4.Checked = True Then
            While Not sr.EndOfStream
                Dim line = removeempty(sr.ReadLine.Split(CChar(" ")))
                For i As Integer = 3 To 0 Step -1
                    If Not line(4) = Nothing And CDbl(line(1)) = CDbl(rozm(0)) - i Then
                        line(1) = line(0)
                        Dim nazev = line(3) & " " & uprav(line(4))
                        g.FillRectangle(New SolidBrush(color(line(3))), z * CInt(line(1)), z * CInt(line(2)), z, z * CInt(line(4).ToLower.Split(CChar("x"))(1)))
                        g.DrawRectangle(Pens.Black, z * CInt(line(1)), z * CInt(line(2)), z, z * CInt(line(4).ToLower.Split(CChar("x"))(1)))
                        g.Save()
                    End If
                Next
               
            End While
            PictureBox1.Image = b
            PictureBox1.Image.RotateFlip(RotateFlipType.Rotate270FlipX)
        ElseIf RadioButton5.Checked = True Then
            While Not sr.EndOfStream
                Dim line = removeempty(sr.ReadLine.Split(CChar(" ")))
                For i As Integer = 3 To 0 Step -1
                    If Not line(4) = Nothing And CDbl(line(2)) = CDbl(rozm(1)) - i Then
                        line(2) = line(0)
                        Dim nazev = line(3) & " " & uprav(line(4))
                        g.FillRectangle(New SolidBrush(color(line(3))), z * CInt(line(1)), z * CInt(line(2)), z * CInt(line(4).ToLower.Split(CChar("x"))(0)), z)
                        g.DrawRectangle(Pens.Black, z * CInt(line(1)), z * CInt(line(2)), z * CInt(line(4).ToLower.Split(CChar("x"))(0)), z)
                        g.Save()
                    End If
                Next
            End While
            PictureBox1.Image = b
            PictureBox1.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
        End If
       
    End Sub


    Private Sub TabPage2_Enter(sender As System.Object, e As System.EventArgs) Handles TabPage2.Enter
        AcceptButton = Button4
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PictureBox1.Image.Save(SaveFileDialog1.FileName)
        End If
    End Sub
End Class
Class kostka
    Public barva As Color
    Public x As Byte
    Public y As Byte
    Sub New(barva1 As Color, x1 As Integer, y1 As Integer)
        barva = barva1
        x = CByte(x1)
        y = CByte(y1)
    End Sub
    Sub New()
    End Sub
End Class



