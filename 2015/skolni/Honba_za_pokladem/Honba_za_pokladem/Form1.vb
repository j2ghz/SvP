Public Class Form1
    Dim control As Controls
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load 'Vygenerování pole, pozic, zjištění velikosti
        Dim start As New Startup
        If start.ShowDialog() = DialogResult.OK Then

        Else
            Application.Exit()
        End If
        control = New Controls
        control.Show()
    End Sub

    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint
        'Text = IIf(narade1, "Hráč 1", "Hráč 2") 'Zobrazení kdo hraje
        'For w As Integer = 0 To PictureBox1.Width Step 20
        '    For h As Integer = 0 To PictureBox1.Height Step 20
        '        e.Graphics.DrawRectangle(Pens.Black, w, h, 20, 20) 'Vykreslení sítě
        '    Next
        'Next
        'e.Graphics.FillEllipse(Brushes.Red, h1.X * 20, h1.Y * 20, 20, 20)   'hráč 1
        'e.Graphics.FillEllipse(Brushes.Blue, h2.X * 20, h2.Y * 20, 20, 20)  'hráč 2
        'e.Graphics.FillEllipse(Brushes.Black, p.X * 20, p.Y * 20, 20, 20)   'poklad
        'If h1 = p Then  'oznámení o výhře
        '    MsgBox("Hráč 1 vyhrál")
        '    Application.Restart()
        'ElseIf h2 = p
        '    Application.Restart()
        '    MsgBox("Hráč 2 vyhrál")
        'End If
    End Sub

End Class
''' <summary>
''' Struktura pro ukádání hráčů
''' </summary>
Class hrac

    Sub New(name As String, x As Integer, y As Integer, Optional body As Integer = 0)
        _name = name
        _pozice = New Point(x, y)
        _body = body
    End Sub
    Sub New(name As String, pozice As Point, Optional body As Integer = 0)
        _name = name
        _pozice = pozice
        _body = body
    End Sub

    Private _name As String
    ''' <summary>
    ''' Jméno hráče
    ''' </summary>
    ''' <returns>String se jménem hráče</returns>
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property
    Private _pozice As Point
    ''' <summary>
    ''' Ukládá pozici hráče, {1,1} je 1 řádek, 1 sloupec, ne 1 pixel, 1 pixel
    ''' </summary>
    ''' <returns>Pozice hráče</returns>
    Public Property Pozice() As Point
        Get
            Return _pozice
        End Get
        Set(ByVal value As Point)
            _pozice = value
        End Set
    End Property

    Private _body As Integer
    ''' <summary>
    ''' Ukládá počet bodů hráče
    ''' </summary>
    ''' <returns>počet bodů</returns>
    Public Property Body() As Integer
        Get
            Return _body
        End Get
        Set(ByVal value As Integer)
            _body = value
        End Set
    End Property

End Class