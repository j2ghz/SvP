Public Class Startup
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        CheckedListBox1.Items.Add(TextBox1.Text, CheckState.Unchecked)
        TextBox1.Text = ""
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        CheckedListBox1.Items.RemoveAt(CheckedListBox1.SelectedIndex)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Startup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class