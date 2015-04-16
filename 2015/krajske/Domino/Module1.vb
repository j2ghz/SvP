Imports System.Windows.Forms
Imports System.IO

Module Module1
    Dim ofd As New OpenFileDialog
    Dim sfd As New SaveFileDialog
    Dim kostky As New List(Of String)
    Sub Main()
        ofd.InitialDirectory = "C:\Users\Jozef\Documents\KK"
        If ofd.ShowDialog = DialogResult.OK Then
            Dim rr As New StreamReader(ofd.FileName)
            kostky.AddRange(rr.ReadToEnd.Replace("][", "*").Trim("]", "[").Split("*"))
            Console.WriteLine(zapis(vyber(Nothing, kostky)))
        End If
        Console.ReadKey()
    End Sub

    Function vyber(ByVal rada As List(Of String), ByVal mozne As List(Of String)) As List(Of String)
        Dim rady As New List(Of List(Of String))
        Dim kolikrat = 0
        For Each kostka In mozne
            If rada Is Nothing Then
                kolikrat += 1
                Dim mozne2 As New List(Of String)
                mozne2.AddRange(mozne)
                mozne2.Remove(kostka)
                rady.Add(vyber(spoj(rada, kostka), mozne2))
            ElseIf rada.Last()(2) = kostka(0) Then
                kolikrat += 1
                Dim mozne2 As New List(Of String)
                mozne2.AddRange(mozne)
                mozne2.Remove(kostka)
                rady.Add(vyber(spoj(rada, kostka), mozne2))
            ElseIf rada.Last()(2) = kostka(2) Then
                kolikrat += 1
                kostka = kostka(2) & kostka(1) & kostka(0)
                Dim mozne2 As New List(Of String)
                mozne2.AddRange(mozne)
                mozne2.Remove(kostka)
                rady.Add(vyber(spoj(rada, kostka), mozne2))
            End If
        Next
        If mozne.Count = 0 Or kolikrat = 0 Then
            Return rada
        End If
        Dim max As List(Of String) = rady(0)
        For Each r In rady
            If r.Count > max.Count Then
                max = r
            End If
        Next
        Return max
    End Function

    Private Function pasuje(s As Stack(Of String), kostka As String) As Boolean
        If s.Peek()(2) = kostka(0) Or s.Peek()(2) = kostka(2) Then Return True
        Return False
    End Function

    Private Function spoj(rada As List(Of String), kostka As String) As List(Of String)
        If rada Is Nothing Then
            rada = New List(Of String)
        End If
        rada.Add(kostka)
        Return rada
    End Function

    Private Function zapis(p1 As List(Of String)) As String
        Dim s As String = ""
        For Each prvek In p1
            s &= "[" & prvek & "]"
        Next
        Return s
    End Function

End Module
