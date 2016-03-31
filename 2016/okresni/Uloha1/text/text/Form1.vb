Imports System.Text

Public Class Form1
    Private Sub NačístToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NačístToolStripMenuItem.Click 'Otevirani souboru
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            TextBox1.Text = My.Computer.FileSystem.ReadAllText(OpenFileDialog1.FileName, Encoding.Default)
        End If
    End Sub

    Private Sub UložitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UložitToolStripMenuItem.Click 'Ukladani do souboru
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, TextBox1.Text, False)
        End If
    End Sub

    Private Sub OpravitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpravitToolStripMenuItem.Click 'Oprava chyb

        'pridat mezery
        TextBox1.Text = RegularExpressions.Regex.Replace(TextBox1.Text, "([,.])(\w)", "$1 $2")

        'presun spojek
        TextBox1.Text = RegularExpressions.Regex.Replace(TextBox1.Text, " (\w *)" & Environment.NewLine, Environment.NewLine & "$1 ")

        'odebrani mezer
        TextBox1.Text = RegularExpressions.Regex.Replace(TextBox1.Text, " +", " ")

        'odstraneni mezer na konci radku
        TextBox1.Text = RegularExpressions.Regex.Replace(TextBox1.Text, " +" & Environment.NewLine, Environment.NewLine)

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged 'status ve spodni liste

        ToolStripStatusLabel1.Text = "Řádků: " & TextBox1.Lines.Count() 'pocet radku

        ToolStripStatusLabel2.Text = "Znaků: " & TextBox1.Text.Count() 'pocet znaku

        ToolStripStatusLabel3.Text = "Písmen: " & TextBox1.Text.Count(Function(c) Char.IsLetter(c)) 'pocet pismen anglicke abecedy

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TextBox1_TextChanged(Nothing, Nothing)
    End Sub

    Private Sub ŠifrujToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ŠifrujToolStripMenuItem.Click 'sifrovani
        If Integer.TryParse(ToolStripTextBox1.Text, Nothing) = False Then 'Zadal uzivatel cislo?
            MsgBox("Zadejte číslo")
            Exit Sub
        End If
        sifruj(ToolStripTextBox1.Text)
    End Sub

    Sub sifruj(okolik As Integer) 'Sifrovani
        Dim sb As New StringBuilder
        For Each c As Char In TextBox1.Text 'kazdy znak
            sb.Append(ChrW(okolik + AscW(c))) ' zmen o okolik
        Next
        TextBox1.Text = sb.ToString() 'vypis
    End Sub

    Private Sub OdšifrujToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OdšifrujToolStripMenuItem.Click 'odsifrovani
        If Integer.TryParse(ToolStripTextBox1.Text, Nothing) = False Then 'Zadal uzivatel cislo?
            MsgBox("Zadejte číslo")
            Exit Sub
        End If
        sifruj(-ToolStripTextBox1.Text)
    End Sub
End Class
