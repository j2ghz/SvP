Imports System.Text
Imports System.IO

Public Class Form1
    Dim vsazena As New List(Of String)
    Dim vylosovana As New List(Of Byte)
    Dim r As New Random
    Dim WithEvents sr As StreamWriter
    Dim rr As StreamReader
    Dim soubor As String
    Private Function losuj(Optional nahodne As Boolean = False) As Integer
        If CheckBox1.Checked Then
            Dim p As String = r.Next(0, 1000000).ToString.PadLeft(6, "0")   'losovani sance
            Dim d As String = IIf(NumericUpDown1.Value = -1, r.Next(0, 1000000).ToString.PadLeft(6, "0"), NumericUpDown1.Value)
            If p = d Then
                sance(200000)       'vysledky sance
            ElseIf p.ToString.Substring(1) = d.ToString.Substring(1) Then
                sance(50000)
            ElseIf p.ToString.Substring(2) = d.ToString.Substring(2) Then
                sance(5000)
            ElseIf p.ToString.Substring(3) = d.ToString.Substring(3) Then
                sance(500)
            ElseIf p.ToString.Substring(4) = d.ToString.Substring(4) Then
                sance(50)
            ElseIf p.ToString.Substring(5) = d.ToString.Substring(5) Then
                sance(20)
            End If
        End If
        If nahodne Then
            vsazena.Clear()
            For i = 0 To 5
                Dim x As Integer = r.Next(1, 50)    'generovani nahodnych sazek
                While vsazena.Contains(x)
                    x = r.Next(1, 50)
                End While
                vsazena.Add(x)
            Next
        End If
        If vsazena.Count = 6 Then
            vsazena.Sort()              'kontrola sazek
            For Each s As Integer In vsazena
                sr.Write(s & ",")
            Next
            vylosovana = New List(Of Byte)
            For i As Integer = 1 To 6
                Dim x As Integer = r.Next(1, 50)    'losovani
                While vylosovana.Contains(x)
                    x = r.Next(1, 50)
                End While
                vylosovana.Add(x)
            Next
            Dim ii As Integer = r.Next(1, 50)
            While vylosovana.Contains(ii)       'losovani dodatkoveho
                ii = r.Next(1, 50)
            End While
            Dim dodatkove As Integer = ii
            Dim pocetvyher As Integer
            For Each y As Integer In vsazena            'kontrola poctu stejnych cisel
                If vylosovana.Contains(y) Then pocetvyher += 1
            Next

            Select Case pocetvyher                      'vyhodnoceni vyher
                Case 6
                    sr.WriteLine(" - Cena:1")
                    Return 1
                Case 5
                    sr.WriteLine(" - cena:" & IIf(vylosovana.Contains(dodatkove), 2, 3))
                    Return IIf(vylosovana.Contains(dodatkove), 2, 3)
                Case 4
                    sr.WriteLine(" - Cena:4")
                    Return 4
                Case 3
                    sr.WriteLine(" - Cena:5")
                    Return 5
                Case Else
                    sr.WriteLine(" - Bez vyhry")
                    Return 0
            End Select
        Else
            Return -1
        End If
        For Each i In TabControl1.TabPages
            i.refresh()
        Next
        TabPage1_Paint(Nothing, Nothing)
    End Function

    Private Sub TabPage1_Paint(sender As Object, e As PaintEventArgs) Handles TabPage1.Paint
        Dim x As Graphics = TabPage1.CreateGraphics 'kresleni tabulky
        For i = 0 To 48
            x.FillRectangle(IIf(vylosovana.Contains(i + 1), Brushes.Green, Brushes.Gray), 1 + (i Mod 5) * 50, 1 + (i \ 5) * 50, 48, 48)
            x.DrawString(i + 1, Me.Font, IIf(vsazena.Contains(i + 1), Brushes.Red, Brushes.Black), (i Mod 5) * 50, (i \ 5) * 50)
        Next
    End Sub


    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles Button1.Click
        los(False)
    End Sub

    Sub los(nah As Boolean)
        Dim sb As New StringBuilder
        If NumericUpDown1.Value > 0 Then
            For i As Integer = 1 To NumericUpDown1.Value    'spusteni losovani
                Me.Text = i & "/" & NumericUpDown1.Value
                vypis(losuj(nah))
            Next
        ElseIf NumericUpDown1.Value = -1 Then   'spusteni losovani dokud nevyhrajem
            Dim x As Integer
            Do
                x = losuj(nah)
            Loop While x = 0
            vypis(x)
        Else                                'spatny pocet sazek - kontrola
            MsgBox("Nelze vsadit 0x")
        End If
    End Sub
    ''' <summary>
    ''' vypsani vyhry
    ''' </summary>
    ''' <param name="i"></param>
    ''' <remarks></remarks>
    Sub vypis(i As Integer)
        Select Case i
            Case 1
                MsgBox("první cena")
            Case 2
                MsgBox("druhá cena")
            Case 3
                MsgBox("třetí cena")
            Case 4
                MsgBox("čtvrtá cena")
            Case 5
                MsgBox("pátá cena")
            Case 0
                Debug.WriteLine("žádná výhra")
            Case -1
                MsgBox("Neplatná sázka")
            Case Else
                Throw New Exception("Neznámá chyba")
        End Select
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        los(True)
    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click
        For i As Integer = 0 To 48
            Dim r As New Rectangle(TabPage1.PointToClient(MousePosition), New Size(1, 1))
            Dim rr As New Rectangle(1 + (i Mod 5) * 50, 1 + (i \ 5) * 50, 48, 48)           'obsluha sazek pri klikani na tabulku
            If rr.IntersectsWith(r) Then
                If vsazena.Contains(i + 1) Then
                    vsazena.Remove(i + 1)
                Else
                    If vsazena.Count = 6 Then
                        MsgBox("Příliš mnoho sázek")            'kontrola chyb
                    Else
                        vsazena.Add(i + 1)
                    End If
                End If
            End If
        Next
        TabPage1_Paint(Nothing, Nothing)
    End Sub
    ''' <summary>
    ''' otevreni souboru
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        sr.Flush()
        System.Diagnostics.Process.Start(soubor)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        soubor = Path.GetTempFileName
        sr = New StreamWriter(soubor)
    End Sub
    ''' <summary>
    ''' vypsani vyhry sance
    ''' </summary>
    ''' <param name="p1"></param>
    ''' <remarks></remarks>
    Private Sub sance(p1 As Integer)
        MsgBox("Šance- výhra: " & p1)
        sr.WriteLine("Šance- výhra: " & p1)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        sr.Flush()
        sr.Close()
        TextBox1.Text = File.ReadAllText(soubor)
        sr = New StreamWriter(soubor)
    End Sub
End Class
