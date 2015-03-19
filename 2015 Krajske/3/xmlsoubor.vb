Imports System.Xml

Public Class xmlsoubor

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            TextBox1.Text = OpenFileDialog1.FileName
        End If
        If TextBox1.Text.Contains("4") Then
            ListBox1.SelectedIndex = 0
        Else
            ListBox1.SelectedIndex = 1
        End If
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox2.Text = ""
        Dim xml As New XmlDocument
        xml.Load(TextBox1.Text)
        xml.Normalize()
        For Each clovek As XmlElement In xml.GetElementsByTagName("pomxml")
            TextBox2.Text &= clovek("pc").InnerText & "  ->  "
            clovek("pc").InnerText = IIf(ListBox1.SelectedIndex = 0, 400, 800) + CInt(clovek("pc").InnerText.TrimEnd("."))
            TextBox2.Text &= clovek("pc").InnerText & Environment.NewLine

            TextBox2.Text &= clovek("prihl_na_o").InnerText & "  ->  "
            clovek("prihl_na_o").InnerText = "79-41-K/" & IIf(ListBox1.SelectedIndex = 0, "41", "81")
            TextBox2.Text &= clovek("prihl_na_o").InnerText & Environment.NewLine

            TextBox2.Text &= clovek("bydliste").InnerText & "  ->  "
            clovek("bydliste").InnerText = clovek("bydliste").InnerText.Replace(",", ";")
            TextBox2.Text &= clovek("bydliste").InnerText & Environment.NewLine

            TextBox2.Text &= clovek("puv_izo").InnerText & "  ->  "
            clovek("puv_izo").InnerText = clovek("puv_izo").InnerText.PadLeft(9, "0"c)
            TextBox2.Text &= clovek("puv_izo").InnerText & Environment.NewLine & Environment.NewLine

            Dim rocn As Xml.XmlElement = xml.CreateElement("rocnik")
            rocn.InnerText = IIf(ListBox1.SelectedIndex = 0, "5", "9")
            clovek.AppendChild(rocn)
        Next
        For Each row As XmlElement In xml.GetElementsByTagName("Row")
            If Integer.TryParse(row.ChildNodes(0).ChildNodes(0).InnerText, Nothing) Then
                TextBox2.Text &= row.ChildNodes(0).ChildNodes(0).InnerText & "  ->  "
                row.ChildNodes(0).ChildNodes(0).InnerText = IIf(ListBox1.SelectedIndex = 0, 400, 800) + CInt(row.ChildNodes(0).ChildNodes(0).InnerText.TrimEnd("."))
                TextBox2.Text &= row.ChildNodes(0).ChildNodes(0).InnerText & Environment.NewLine

                TextBox2.Text &= row.ChildNodes(7).ChildNodes(0).InnerText & "  ->  "
                row.ChildNodes(7).ChildNodes(0).InnerText = "79-41-K/" & IIf(ListBox1.SelectedIndex = 0, "41", "81")
                TextBox2.Text &= row.ChildNodes(7).ChildNodes(0).InnerText & Environment.NewLine

                TextBox2.Text &= row.ChildNodes(5).ChildNodes(0).InnerText & "  ->  "
                row.ChildNodes(5).ChildNodes(0).InnerText = row.ChildNodes(5).ChildNodes(0).InnerText.Replace(",", ";")
                TextBox2.Text &= row.ChildNodes(5).ChildNodes(0).InnerText & Environment.NewLine

                TextBox2.Text &= row.ChildNodes(10).ChildNodes(0).InnerText & "  ->  "
                row.ChildNodes(10).ChildNodes(0).InnerText = row.ChildNodes(10).ChildNodes(0).InnerText.PadLeft(9, "0"c)
                TextBox2.Text &= row.ChildNodes(10).ChildNodes(0).InnerText & Environment.NewLine & Environment.NewLine

                Dim rocn As Xml.XmlElement = xml.CreateElement("Cell")
                rocn.InnerXml = row.ChildNodes(10).InnerXml
                rocn.ChildNodes(0).InnerText = IIf(ListBox1.SelectedIndex = 0, "5", "9")
                row.AppendChild(rocn)
            Else
                Dim rocn As Xml.XmlElement = xml.CreateElement("Cell")
                Dim da As Xml.XmlElement = xml.CreateElement("Data")
                da.InnerText = "Ročník"
                da.SetAttribute("ss:Type", "String")
                rocn.AppendChild(da)
                row.AppendChild(rocn)
            End If
        Next
        xml.Save(TextBox1.Text.Replace("vstup", "vystup"))
        Process.Start(TextBox1.Text.Replace("vstup", "vystup"))
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If TextBox1.Text.Contains("4") Then
            ListBox1.SelectedIndex = 0
        Else
            ListBox1.SelectedIndex = 1
        End If
    End Sub

End Class
