Imports System.Text

Public Class hadani
    Dim kostky As New List(Of Byte())
    Dim rand As New Random
    Dim soucet As Integer = 0
    Dim hrac As Integer = 0
    Dim hrac1 As Integer = 0
    Dim hrac2 As Integer = 0
    Dim kolo As Integer = 1
    Dim poprveZacinal As Integer = 0
    Dim hrac1tipy As String
    Dim hrac2tipy As String
    Dim nejrychlejsiKolo As Integer = -1
    Dim nejrychlejsiKolotipy As Integer = Integer.MaxValue
    Dim totoKoloTipy As Integer = 0
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        zacatekKola()
    End Sub

    Sub zacatekKola()
        If totoKoloTipy > 0 AndAlso totoKoloTipy < nejrychlejsiKolotipy Then 'sledovani nej kola
            nejrychlejsiKolo = kolo
            nejrychlejsiKolotipy = totoKoloTipy
        End If
        totoKoloTipy = 0
        ListBox1.Items.Add("Začíná kolo")
        soucet = 0
        kostky = New List(Of Byte())
        For i As Integer = 0 To rand.Next(0, 6) 'generování cisel
            Dim k(4) As Byte
            For b As Integer = 0 To 4
                k(b) = rand.Next(1, 7)
                soucet += k(b)
            Next
            kostky.Add(k)
        Next
        If poprveZacinal = 0 Then   'kdo zacina
            hrac = rand.Next(1, 3)
        Else
            If poprveZacinal = 1 Then
                hrac = 2
            ElseIf poprveZacinal = 2 Then
                hrac = 1
            Else
                Throw New ArgumentOutOfRangeException("poprveZacinal")
            End If
        End If

        poprveZacinal = hrac
        Label1.Text = "Hraje hráč " & hrac
        Me.Text = soucet
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        totoKoloTipy += 1
        Select Case hrac    'sledovani tipu
            Case 1
                hrac1tipy &= NumericUpDown1.Value & "; "
            Case 2
                hrac2tipy &= NumericUpDown1.Value & "; "
        End Select
        Select Case NumericUpDown1.Value
            Case Is < soucet    'je vetsi mensi uhodl
                ListBox1.Items.Add("Hráč " & hrac & " tipuje " & NumericUpDown1.Value & "; hádané číslo je větší")
                hrac = IIf(hrac = 1, 2, 1)
                Label1.Text = "Hraje hráč " & hrac
            Case Is > soucet
                ListBox1.Items.Add("Hráč " & hrac & " tipuje " & NumericUpDown1.Value & "; hádané číslo je menší")
                hrac = IIf(hrac = 1, 2, 1)
                Label1.Text = "Hraje hráč " & hrac
            Case Is = soucet
                ListBox1.Items.Add("Hráč " & hrac & " tipuje " & NumericUpDown1.Value & "; UHODL")
                vyhra(hrac)
            Case Else
                Throw New Exception
        End Select
        ListBox1.SelectedIndex = ListBox1.Items.Count - 1
    End Sub

    Private Sub vyhra(hrac As Integer)
        ListBox1.Items.Add("Toto kolo vyhrál hráč " & hrac) 'vypis kdyz vyhraje
        ListBox1.Items.Add("Hádané číslo " & soucet & " vzniklo:")
        For Each kostka In kostky
            ListBox1.Items.Add(enumerate(kostka))
        Next
        Select Case hrac
            Case 1
                hrac1 += 1
                ToolStripStatusLabel2.Text = "Hráč 1: " & hrac1
                If hrac1 = 2 Then
                    ListBox1.Items.Add("Hra skončila, vyhrál hráč 1 s počtem bodů 2, hráč 2 měl počet bodů " & hrac2)
                    ListBox1.Items.Add("Tipy hráče 1: " & hrac1tipy)
                    ListBox1.Items.Add("Tipy hráče 2: " & hrac2tipy)
                    ListBox1.Items.Add("nejrychlejsi kolo: " & nejrychlejsiKolo & " s počtem tipů: " & nejrychlejsiKolotipy)
                    ListBox1.Items.Add("Pro další hru restartujte aplikaci!")
                End If
            Case 2
                hrac2 += 1
                ToolStripStatusLabel3.Text = "Hráč 2: " & hrac2
                If hrac2 = 2 Then
                    ListBox1.Items.Add("Hra skončila, vyhrál hráč 2 s počtem bodů 2, hráč 1 měl počet bodů " & hrac1)
                    ListBox1.Items.Add("Tipy hráče 1: " & hrac1tipy)
                    ListBox1.Items.Add("Tipy hráče 2: " & hrac2tipy)
                    ListBox1.Items.Add("nejrychlejsi kolo: " & nejrychlejsiKolo & " s počtem tipů: " & nejrychlejsiKolotipy)
                    ListBox1.Items.Add("Pro další hru restartujte aplikaci!")
                End If
        End Select
        kolo += 1
        ToolStripStatusLabel1.Text = "Kolo : " & kolo
        zacatekKola()
    End Sub

    Function enumerate(ByVal pole() As Byte) As String  'funkce na vypsani kostek
        Dim sb As New StringBuilder
        Dim souc As Integer = 0
        For Each item In pole
            sb.Append(item.ToString)
            souc += item
        Next
        Return sb.ToString & " součet " & souc
    End Function

End Class
