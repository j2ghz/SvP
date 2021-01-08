Public Class Form1
    Dim WithEvents control As Controls
    Dim hraci As New List(Of hrac)
    Dim velikost As Point
    Dim rand As New Random
    ''' <summary>
    ''' Velikost políčka v poli
    ''' </summary>
    Private _velikostPole As Integer = 30
    Public Property VP() As Integer
        Get
            Return _velikostPole
        End Get
        Set(ByVal value As Integer)
            _velikostPole = value
            PictureBox1.Size = New Size(value * velikost.X, value * velikost.Y)
        End Set
    End Property

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load 'Vygenerování pole, pozic, zjištění velikosti
        Debug.WriteLine(Now.ToString & " ---------------------------------------------------")
        Debug.WriteLine(Now.ToString & " Start aplikace")
        Dim start As New Startup
        If start.ShowDialog() = DialogResult.OK Then
            velikost.X = start.NumericUpDownX.Value
            velikost.Y = start.NumericUpDownY.Value
            VP = start.NumericUpDown1.Value
            For Each jmenohrace As String In start.CheckedListBox1.Items
                hraci.Add(New hrac(jmenohrace, nahodnapozice()))
            Next
            Poklad = nahodnapozice()
            Do
                createMaze(start.NumericUpDownX.Value, start.NumericUpDownY.Value, 0.4)
                Debug.WriteLine(Now.ToString & " Bludiste zahozeno")
            Loop Until jeCesta(hraci, Poklad)
        Else
            Application.Exit()
        End If
        control = New Controls
        control.Show()
        control.BringToFront()
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
        Me.Refresh()
        Debug.WriteLine(Now.ToString & " Form1 loaded")
    End Sub

    Private Function nahodnapozice() As Point
        Return New Point(rand.NextDouble * velikost.X, rand.NextDouble * velikost.Y)
    End Function

    Public Sub changesize(sender As Object, e As EventArgs) Handles control.polickoSizeChanged
        VP = sender.value
        Me.Refresh()
    End Sub

    ''' <summary>
    ''' Vykreslovani
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint
        e.Graphics.Clear(Color.White)
        Dim p As New Pen(Me.BackColor)
        p.DashStyle = Drawing2D.DashStyle.Dash
        For x As Integer = 0 To velikost.X + 1
            e.Graphics.DrawLine(p, x * VP, 0, x * VP, velikost.Y * VP)
        Next
        For y As Integer = 0 To velikost.Y + 1
            e.Graphics.DrawLine(p, 0, y * VP, velikost.X * VP, y * VP)
        Next
        For x As Integer = 1 To velikost.X - 1
            For y As Integer = 1 To velikost.Y - 1
                e.Graphics.FillRectangle(Brushes.Black, x * VP - 1, y * VP - 1, 3, 3)
            Next
        Next
        For x As Integer = 0 To velikost.X - 1
            For y As Integer = 0 To velikost.Y - 1
                If ZedDole(x)(y) Then
                    e.Graphics.FillRectangle(Brushes.Black, x * VP, (y + 1) * VP - 1, VP, 3)
                End If
                If ZedVpravo(x)(y) Then
                    e.Graphics.FillRectangle(Brushes.Black, (x + 1) * VP - 1, y * VP, 3, VP)
                End If
            Next
        Next
        For Each h As hrac In hraci
            e.Graphics.FillRectangle(Brushes.LightGray, h.Pozice.X * VP + 2, h.Pozice.Y * VP + 2, VP - 3, VP - 3)
            e.Graphics.DrawString(hraci.IndexOf(h), Me.Font, Brushes.Red, h.Pozice.X * VP, h.Pozice.Y * VP)
        Next
        e.Graphics.FillRectangle(Brushes.Red, Poklad.X * VP + 2, Poklad.Y * VP + 2, VP - 3, VP - 3)
    End Sub

    Private Sub control_pohyb(sender As Object, e As EventArgs) Handles control.pohyb
        'TODO: pohyb hráče
        Debug.WriteLine(Now.ToString & " " & sender.tag)
    End Sub

End Class
''' <summary>
''' Struktura pro ukládání bludiště
''' </summary>
Module maze
    Dim Rand As New Random
    Private _poklad As Point
    Public ZedDole As Boolean()()
    Public ZedVpravo As Boolean()()
    ''' <summary>
    ''' Struktura pro pozici pokladu
    ''' </summary>
    ''' <returns>Kde je poklad v osuradnicich x a y ne pixelech</returns>
    Public Property Poklad As Point
        Get
            Return _poklad
        End Get
        Set(ByVal value As Point)
            _poklad = value
        End Set
    End Property
    ''' <summary>
    ''' Vytvori bludiste o urcite velikosti s urcitou sanci na zed
    ''' </summary>
    ''' <param name="xm">sirka</param>
    ''' <param name="ym">vyska</param>
    ''' <param name="sance">sance na zed, 0=0%, 1=skoro 100%, nedoporucuje se</param>
    Sub createMaze(xm As Byte, ym As Byte, sance As Double)
        ZedDole = New Boolean(xm - 1)() {}
        ZedVpravo = New Boolean(xm - 1)() {}
        For x As Integer = 1 To xm
            ZedDole(x - 1) = New Boolean(ym - 1) {}
            ZedVpravo(x - 1) = New Boolean(ym - 1) {}
            For y As Integer = 1 To ym
                ZedDole(x - 1)(y - 1) = IIf(y = ym, True, Rand.NextDouble < sance)
                ZedVpravo(x - 1)(y - 1) = IIf(x = xm, True, Rand.NextDouble < sance)
            Next
        Next
    End Sub

    Function jeCesta(ByVal hraci As List(Of hrac), poklad As Point) As Boolean 'rozbite
        Dim s As New Queue(Of Point)
        Dim old As New List(Of Point)
        s.Enqueue(poklad)
        Dim hraci3 As New List(Of hrac)
        hraci3.AddRange(hraci)
        Do
            Dim aktualni As Point = s.Dequeue
            old.Add(aktualni)
            If Not ZedDole(aktualni.X)(aktualni.Y) Then
                Dim p As New Point(aktualni.X, aktualni.Y + 1)
                If Not old.Contains(p) Then s.Enqueue(p)
            End If
            If Not ZedVpravo(aktualni.X)(aktualni.Y) Then
                Dim p As New Point(aktualni.X + 1, aktualni.Y)
                If Not old.Contains(p) Then s.Enqueue(p)
            End If
            If aktualni.Y > 0 AndAlso Not ZedDole(aktualni.X)(aktualni.Y - 1) Then
                Dim p As New Point(aktualni.X, aktualni.Y - 1)
                If Not old.Contains(p) Then s.Enqueue(p)
            End If
            If aktualni.X > 0 AndAlso Not ZedVpravo(aktualni.X - 1)(aktualni.Y) Then
                Dim p As New Point(aktualni.X - 1, aktualni.Y)
                If Not old.Contains(p) Then s.Enqueue(p)
            End If
            Dim hraci2 As New List(Of hrac)
            hraci2.AddRange(hraci3)
            For Each h As hrac In hraci2
                If h.Pozice = aktualni Then
                    hraci3.Remove(h)
                End If
            Next
            Application.DoEvents()
        Loop Until s.Count = 0 Or hraci3.Count = 0
        Return hraci3.Count = 0
    End Function

End Module
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
    Private _color As Color
    Public Property Color() As Color
        Get
            Return _color
        End Get
        Set(ByVal value As Color)
            _color = value
        End Set
    End Property
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