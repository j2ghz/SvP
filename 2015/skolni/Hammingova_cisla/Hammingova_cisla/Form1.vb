Imports System.IO
Imports System.Text

Public Class Form1
    Dim hamming As New SortedDictionary(Of Integer, String)
    Private Sub btn_Prepare_Click(sender As Object, e As EventArgs) Handles btn_Prepare.Click 'vygenerování všech hammingových čísel do 1000000 (některá větší, ale kompletní seznam jen do 1000000
        Me.Text = "Počkejte asi 25 sekund"
        Me.Cursor = Cursors.WaitCursor
        For c As Integer = 0 To 10
            For b As Integer = 0 To 14
                For a As Integer = 0 To 21
                    Application.DoEvents()
                    Try
                        hamming.Add(CInt(Math.Pow(2, a)) * CInt(Math.Pow(3, b)) * CInt(Math.Pow(5, c)), String.Join(",", a, b, c)) 'pridani do seznamu i s tim jak se vypocetlo
                    Catch

                    End Try
                Next
            Next
        Next
        Me.Text = "Hammingova čísla"    'uvolnění ovládání
        Me.Cursor = Cursors.Default
        btn_Prepare.Enabled = False
        GroupBox1.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click 'zjištění zda je hammingovo číslo
        If hamming.ContainsKey(NumericUpDown1.Value) Then
            Dim i = hamming(NumericUpDown1.Value).Split(",")
            MsgBox(NumericUpDown1.Value & " = " & String.Join(" * ", "2na" & i(0), "3na" & i(1), "5na" & i(2)))
        Else
            MsgBox("Neni")
        End If
        NumericUpDown2.Maximum = hamming.Count - 1
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click   'n-te hammingovo číslo
        MsgBox(nte(NumericUpDown2.Value - 1))
    End Sub
    Function nte(vstup As Integer) As String    'metoda pro zjištění n teho hammingova čísla
        Dim a = hamming.Keys(vstup)
        Dim i = hamming(a).Split(",")
        Return (a & " = " & String.Join(" * ", "2na" & i(0), "3na" & i(1), "5na" & i(2)))   'zformatovani
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click 'vypsani n prvnich hemmingovych cisel
        Dim sb As New StringBuilder
        For i As Integer = 0 To NumericUpDown2.Value - 1
            'sb.AppendLine()
            ListBox1.Items.Add(nte(i))
        Next

    End Sub



    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click 'vypsani prvnich n superhammingovych cisel
        Dim sb As New StringBuilder
        Dim i As Integer = 0
        Dim r As Integer = 0
        While r < NumericUpDown2.Value  'dokud jich nemame dost, vem dalsi z normalnich a zkus jestli je super
            Dim c = nte(i)
            If Not c.Contains("na0") Then
                sb.AppendLine(c)
                r += 1
            End If
            i += 1
        End While
        ListBox1.Items.Add(sb.ToString)
    End Sub


    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click   'export do souboru
        Dim file As String = Path.ChangeExtension(Path.GetTempFileName(), "txt")
        Dim rr As New StreamWriter(file)
        For Each c In hamming
            Dim i = c.Value.Split(",")
            rr.WriteLine(c.Key & " = " & String.Join(" * ", "2na" & i(0), "3na" & i(1), "5na" & i(2)))  'zapsání a formátování
        Next
        Process.Start(file)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click   'hledání císla do dvojice
        Dim i As Integer = 1
        Dim a = hamming.Keys(NumericUpDown2.Value - 1)
        Dim konec As Boolean = True
        While konec
            If hamming.ContainsKey(a + hamming.Keys(NumericUpDown2.Value - 1 + i)) Then 'zkusime dvojici s císlem o i vetsim
                Dim x = hamming(a + hamming.Keys(NumericUpDown2.Value - 1 + i)).Split(",")  'zformatovani vystupu
                Dim tx As String = (a + hamming.Keys(NumericUpDown2.Value - 1 + i)) & " = " & String.Join(" * ", "2na" & x(0), "3na" & x(1), "5na" & x(2))
                MsgBox(String.Join(Environment.NewLine, nte(NumericUpDown2.Value - 1), nte(NumericUpDown2.Value - 1 + i), tx))
                konec = False
            ElseIf hamming.ContainsKey(a + hamming.Keys(NumericUpDown2.Value - 1 - i)) 'zkusime dvojici s cislem o i mensim
                Dim x = hamming(a + hamming.Keys(NumericUpDown2.Value - 1 - i)).Split(",")  'zformatovani vystupu
                Dim tx As String = (a + hamming.Keys(NumericUpDown2.Value - 1 - i)) & " = " & String.Join(" * ", "2na" & x(0), "3na" & x(1), "5na" & x(2))
                MsgBox(String.Join(Environment.NewLine, nte(NumericUpDown2.Value - 1), nte(NumericUpDown2.Value - 1 - i), tx))
                konec = False
            End If
            i += 1  'pokud sme nenasli tak zetsime i
        End While
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalHandler  'handle neosetrenych chyb
    End Sub
    Sub GlobalHandler(sender As Object, e As UnhandledExceptionEventArgs)
        Beep()
    End Sub
End Class
