Public Class Ngon
    Public Property Pen As Pen
    Public Property fill As Boolean
    Public Property width As Integer
    Public Property height As Integer
    Public Property sides As Integer

    Dim m_image As Image
    Dim m_a As Point
    Dim m_b As Point

    Public Sub New(i As Image, a As Point, c As Color)
        Pen = New Pen(c)
        m_image = i
        m_a = a
        width = 30
        height = 30
    End Sub
    Public Sub Draw()
        Using g As Graphics = Graphics.FromImage(m_image)
            Dim p(sides - 1) As Point
            For n = 0 To sides - 1
                Dim x As Integer
                Dim y As Integer
                x = width * Math.Cos(2 * Math.PI * n / sides)
                y = width * Math.Sin(2 * Math.PI * n / sides)
                p(n) = New Point(m_a.X + x, m_a.Y + y)
            Next
            If fill Then
                g.FillPolygon(New SolidBrush(Pen.Color), p)
            Else
                g.DrawPolygon(Pen, p)
            End If
        End Using
    End Sub



    Sub move(x As Integer, y As Integer)
        m_a = New Point(m_a.X + x, m_a.Y + y)
    End Sub
End Class
