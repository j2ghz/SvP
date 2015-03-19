Imports System.Xml

Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            TextBox1.Text = OpenFileDialog1.FileName
        End If
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim xml As New XmlDocument
        xml.Load(TextBox1.Text)
        For Each clovek As XmlElement In xml.GetElementsByTagName("pomxml")
            clovek("pc").InnerText = IIf(ListBox1.SelectedIndex = 0, "400", "800") & clovek("pc").InnerText
            clovek("prihl_na_o").InnerText = clovek("prihl_na_o").InnerText.Replace("G", "79-41-K/")
            TextBox2.Text &= clovek("bydliste").InnerText & "  ->  "
            clovek("bydliste").InnerText = clovek("bydliste").InnerText.Replace(",", ";")
            TextBox2.Text &= clovek("bydliste").InnerText & Environment.NewLine
            clovek("puv_izo").InnerText = clovek("puv_izo").InnerText.PadRight(9, "0"c)
        Next
        Debug.WriteLine(xml.InnerXml)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListBox1.SelectedIndex = 0
    End Sub
End Class
