Imports System.Globalization
Imports System.Threading


Public Class Form1
    Dim r As New Random
    Dim penize As Integer = 0
    Private Sub NumericUpDown6_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown6.ValueChanged 'vypsani castky do tlacitka
        Button2.Text = "Vsaď " & NumericUpDown6.Value.ToString("C")
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load 'Prepnuti na ceske koruny
        Thread.CurrentThread.CurrentCulture = New CultureInfo("cs-CZ")
        Thread.CurrentThread.CurrentUICulture = New CultureInfo("cs-CZ")
        Button2.Text = "Vsaď " & NumericUpDown6.Value.ToString("C")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click 'Uzivatel chce vsadit na nahodna cisla
        Dim cisla = vygenerujxcisel(5)

        NumericUpDown1.Value = cisla(0)
        NumericUpDown2.Value = cisla(1)
        NumericUpDown3.Value = cisla(2)
        NumericUpDown4.Value = cisla(3)
        NumericUpDown5.Value = cisla(4)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click 'Uzivatel vsadil

        Dim vsazenaCisla = New HashSet(Of Integer) 'zpracovani vstupu a kontrola, jestli nevsazi na stejne

        If vsazenaCisla.Add(NumericUpDown1.Value) = False Then
            MsgBox(String.Format("Nemuzete vsadit na stejne cislo ({0}) dvakrat", NumericUpDown1.Value))
            Exit Sub
        End If
        If vsazenaCisla.Add(NumericUpDown2.Value) = False Then
            MsgBox(String.Format("Nemuzete vsadit na stejne cislo ({0}) dvakrat", NumericUpDown2.Value))
            Exit Sub
        End If

        If vsazenaCisla.Add(NumericUpDown3.Value) = False Then
            MsgBox(String.Format("Nemuzete vsadit na stejne cislo ({0}) dvakrat", NumericUpDown3.Value))
            Exit Sub
        End If
        If vsazenaCisla.Add(NumericUpDown4.Value) = False Then
            MsgBox(String.Format("Nemuzete vsadit na stejne cislo ({0}) dvakrat", NumericUpDown4.Value))
            Exit Sub
        End If
        If vsazenaCisla.Add(NumericUpDown5.Value) = False Then
            MsgBox(String.Format("Nemuzete vsadit na stejne cislo ({0}) dvakrat", NumericUpDown5.Value))
            Exit Sub
        End If

        penize -= NumericUpDown6.Value

        Dim tazenaCisla = vygenerujxcisel(NumericUpDown7.Value) 'vygenerovani tazenych cisel

        Dim pocet = pocetstejnych(tazenaCisla, vsazenaCisla) 'zkotroluj, kolikrat vsadil spravne

        'zprava o vyhre
        Label1.Text = String.Format("Vsazená čísla: {5}{4}Vylosovaná čísla: {0} {4}Uhodl jste {1} čísel: {2}{4} Vyhráváte {3:C}", String.Join(", ", tazenaCisla), pocet.Count, String.Join(", ", pocet), vyhra(pocet.Count), Environment.NewLine, String.Join(", ", vsazenaCisla))

        penize += vyhra(pocet.Count)

        ToolStripStatusLabel1.Text = String.Format("Peníze: {0:C}", penize)
    End Sub

    Private Function vyhra(count As Integer) As Integer 'vypis vyhry
        Select Case count
            Case 5
                Return 100000 * NumericUpDown6.Value
            Case 4
                Return 10000 * NumericUpDown6.Value
            Case 3
                Return 100 * NumericUpDown6.Value
            Case 2
                Return NumericUpDown6.Value
            Case Else
                Return 0
        End Select
    End Function

    Function vygenerujxcisel(count As Integer) As HashSet(Of Integer) 'vygeneruje x ruznych cisel
        Dim cisla As New HashSet(Of Integer)
        For i As Integer = 1 To count
            Dim cislo = r.Next(1, 41)
            While cisla.Contains(cislo)
                cislo = r.Next(1, 41)
            End While
            cisla.Add(cislo)
        Next
        Return cisla
    End Function

    Function pocetstejnych(a As HashSet(Of Integer), b As HashSet(Of Integer)) As HashSet(Of Integer) 'zkontroluje, kolik cisel je stejnych v obou kolekcich
        Dim pocet As New HashSet(Of Integer)
        For Each cislo As Integer In a
            If b.Any(Function(cislo2) cislo = cislo2) Then
                pocet.Add(cislo)
            End If
        Next
        Return pocet
    End Function
End Class
