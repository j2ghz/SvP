Imports System.Windows.Forms
Imports System.IO

Module Module1
    Dim opf As New OpenFileDialog
    Dim saf As New SaveFileDialog
    Dim rr As StreamReader
    Sub Main()
        opf.InitialDirectory = "C:\Users\Jozef\Desktop\prog14\mnohocleny"
        If opf.ShowDialog = DialogResult.OK Then
            saf.FileName = Path.Combine(Path.GetPathRoot(opf.FileName), "/mnohocleny.dat")
            If saf.ShowDialog() = DialogResult.OK Then
                Dim sw As New StreamWriter(saf.FileName)
                rr = New StreamReader(opf.FileName) 'otevreni souboru a vybrani souboru k ulozeni
                While Not rr.EndOfStream
                    Dim radek As String = rr.ReadLine
                    If radek.Contains(";") And radek.Split(";").Count = 2 And Not radek.Contains(",,") Then 'rozdeleni na jednotlive mnohocleny
                        Console.Write(radek & " = ")
                        Dim prvni As New List(Of Integer)
                        For Each i As String In radek.Split(";")(0).Split(",")
                            prvni.Add(i)
                        Next
                        Dim druhy As New List(Of Integer)
                        For Each i As String In radek.Split(";")(1).Split(",")      'ulozeni prvniho a druheho mnohoclenu do listu
                            druhy.Add(i)
                        Next
                        Dim vysl As New List(Of List(Of Integer))
                        For i As Integer = 0 To druhy.Count - 1         'nasobeni prvniho m. kazdym clenem druheho
                            vysl.Add(posun(prvni, i))                   'pridani nul podle aktualniho nasobice
                            For x = 0 To vysl.Last.Count - 1
                                While vysl.Last.Count - 1 < x + i
                                    vysl.Last.Add(0)
                                End While
                                vysl.Last()(x + i) *= druhy(i)          'nasobeni
                            Next
                        Next
                        Dim vysle As New List(Of Integer)               'scitani vysledku
                        For Each i As List(Of Integer) In vysl
                            While vysle.Count - 1 < i.Count - 1
                                vysle.Add(0)
                            End While
                            For x = 0 To i.Count - 1
                                vysle(x) += i(x)
                            Next
                        Next
                        vysle.Reverse()
                        vysle.RemoveRange(0, druhy.Count - 1)           'odstraneni prebytecnych nul
                        vysle.Reverse()
                        For Each i As Integer In vysle
                            Console.Write(i.ToString & ",")             'zobrazeni
                            sw.Write(i.ToString & ",")                  'zapsani
                        Next
                        sw.WriteLine()
                        sw.Flush()
                        Console.WriteLine()
                    ElseIf radek.Length = 0 Then
                    Else
                        Console.WriteLine("Špatný formát vstupu")
                    End If
                End While
            End If
        End If
        Console.ReadKey()
    End Sub
    ''' <summary>
    ''' pridava i nul do listu
    ''' </summary>
    ''' <param name="list"></param>
    ''' <param name="i"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function posun(list As List(Of Integer), i As Integer) As List(Of Integer)
        Dim l As New List(Of Integer)
        For x = 1 To i
            l.Add(0)
        Next
        l.AddRange(list)
        Return l
    End Function

End Module
