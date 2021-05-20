Public Class eeesh
    Public Property Pen As Pen
    Public Property fill As Boolean
    Public Property width As Integer
    Public Property height As Integer
    Dim m_image As Image
    Dim m_a As Point
    Dim m_b As Point

    Public Sub New(i As Image, a As Point, c As Color)
        Pen = New Pen(c)
        m_image = i
        m_a = a
        width = 60
        height = 60
    End Sub
    Public Sub Draw()
        Using s As Graphics = Graphics.FromImage(m_image)
            Dim p(4) As Point
            p(0) = New Point(m_a.X, m_a.Y)
            p(1) = New Point(m_a.X + 60, m_a.Y)
            p(2) = New Point(m_a.X, m_a.Y)
            p(3) = New Point(m_a.X + 60, m_a.Y + 60)
            p(4) = New Point(m_a.X, m_a.Y)


            If fill Then
                s.FillPolygon(New SolidBrush(Pen.Color), p)
            Else
                s.DrawPolygon(Pen, p)
            End If
        End Using
    End Sub


    Sub move(x As Integer, y As Integer)
        m_a = New Point(m_a.X + x, m_a.Y + y)
    End Sub
End Class
