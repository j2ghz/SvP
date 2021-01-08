Imports System.IO
Imports System.Linq

Public Class Form1
    Dim pary As New Dictionary(Of Integer, Integer())
    Dim tahy = 0
    Dim start As DateTime = Now

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load 'Mapovani, z ktereho policka na ktere je mozne presouvat
        pary.Add(1, {2, 4})
        pary.Add(2, {1, 3, 5})
        pary.Add(3, {2, 6})
        pary.Add(4, {1, 5, 7})
        pary.Add(5, {2, 4, 6, 8})
        pary.Add(6, {3, 5, 9})
        pary.Add(7, {4, 8})
        pary.Add(8, {5, 7, 9})
        pary.Add(9, {6, 8})
    End Sub

    Private Sub Label_Click(sender As Object, e As EventArgs) Handles Label1.Click, Label2.Click, Label3.Click, Label4.Click, Label5.Click, Label6.Click, Label7.Click, Label8.Click, Label9.Click
        Dim kam As Control
        For Each i As Integer In pary(sender.tag)
            Dim lbl = (From a As Control In TableLayoutPanel1.Controls Where a.Tag = i).First() 'najit prazdne policko ktere je vedle
            If lbl.Text = "" Then
                kam = lbl
                Exit For
            End If
        Next
        If IsNothing(kam) Then Exit Sub 'pokud nenalezeno, skonci

        tahy += 1
        ToolStripStatusLabel1.Text = "Počet tahů: " & tahy 'pocitac tahu
        kam.Text = sender.text
        sender.text = ""

        Try 'kontrola vyhry
            If Label1.Text = 1 AndAlso Label2.Text = 2 AndAlso Label3.Text = 3 AndAlso Label4.Text = 4 AndAlso Label5.Text = 5 AndAlso Label6.Text = 6 AndAlso Label7.Text = 7 AndAlso Label8.Text = 8 AndAlso Label9.Text = "" Then
                TableLayoutPanel1.BackColor = Color.Yellow
                Timer1.Enabled = False
                MsgBox("Výhra " & (Now - start).ToString())
                Application.Restart()
            End If
        Catch
        End Try

    End Sub

    Private Sub NačístToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NačístToolStripMenuItem.Click 'Nacteni ze souboru
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim sr As New StreamReader(OpenFileDialog1.FileName)
            Dim pole = sr.ReadToEnd.Replace(Environment.NewLine, " ").Split(" ") 'rozdeleni souboru na policka
            Label1.Text = IIf(pole(0) = 0, "", pole(0)) 'vlozeni do kazde bunky
            Label2.Text = IIf(pole(1) = 0, "", pole(1))
            Label3.Text = IIf(pole(2) = 0, "", pole(2))
            Label4.Text = IIf(pole(3) = 0, "", pole(3))
            Label5.Text = IIf(pole(4) = 0, "", pole(4))
            Label6.Text = IIf(pole(5) = 0, "", pole(5))
            Label7.Text = IIf(pole(6) = 0, "", pole(6))
            Label8.Text = IIf(pole(7) = 0, "", pole(7))
            Label9.Text = IIf(pole(8) = 0, "", pole(8))
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick 'pocitani casu
        ToolStripStatusLabel2.Text = "Čas: " & (Now - start).ToString()
    End Sub
End Class
