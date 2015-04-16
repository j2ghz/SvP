Imports System.IO

Public Class Form1
    Dim teploty As New Dictionary(Of Integer, List(Of Integer))
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.SuspendLayout()
        DataGridView1.Rows.Clear()          'vymazání grafu a tabulky
        Chart1.Series(0).Points.Clear()
        Chart1.Series(1).Points.Clear()
        Chart1.Series(2).Points.Clear()
        Chart1.Series(3).Points.Clear()
        Dim rr As New StreamReader(TextBox1.Text)   'otevření souboru
        rr.ReadLine()
        While Not rr.EndOfStream
            Dim text() = rr.ReadLine.Split(";")     'čtení hodnot
            If Not teploty.ContainsKey(text(0)) Then    'načtení hodnot
                Dim l As New List(Of Integer)
                For i As Integer = 0 To 51
                    l.Add(Nothing)
                Next
                teploty.Add(text(0), l)
            End If
            teploty(text(0))(text(1) - 1) = text(2)
        End While
        For tyden As Integer = ComboBox2.Text To ComboBox3.Text 'Vkládání hodnot do grafu a tabulky
            Dim teplotytydne As New List(Of Integer)
            For rok As Integer = ComboBox1.Text To ComboBox4.Text
                teplotytydne.Add(teploty(rok)(tyden - 1))
            Next
            Chart1.Series(0).Points.AddXY(tyden, max(teplotytydne)) 'do grafu
            Chart1.Series(1).Points.AddXY(tyden, min(teplotytydne))
            Chart1.Series(2).Points.AddXY(tyden, prum(teplotytydne))
            Chart1.Series(3).Points.AddXY(tyden, namerena(tyden))
            DataGridView1.Rows.Add()                                    'do tabulky
            DataGridView1.Rows(tyden - 1).Cells(0).Value = tyden
            DataGridView1.Rows(tyden - 1).Cells(1).Value = max(teplotytydne)
            DataGridView1.Rows(tyden - 1).Cells(2).Value = min(teplotytydne)
            DataGridView1.Rows(tyden - 1).Cells(3).Value = prum(teplotytydne)
            DataGridView1.Rows(tyden - 1).Cells(4).Value = namerena(tyden)
        Next
        Me.ResumeLayout()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then  'dialog pro výběr souboru
            TextBox1.Text = OpenFileDialog1.FileName
        End If
    End Sub
#Region "metody na max, min, prumernou a namerenou teplotu"
    Private Function max(teplotytydne As List(Of Integer)) As Integer
        Return teplotytydne.Max
    End Function

    Private Function min(teplotytydne As List(Of Integer)) As Integer
        Return teplotytydne.Min
    End Function

    Private Function prum(teplotytydne As List(Of Integer)) As Integer
        Return teplotytydne.Average
    End Function

    Private Function namerena(tyden As Integer) As Integer
        Return teploty(2014)(tyden - 1)
    End Function

#End Region
End Class
