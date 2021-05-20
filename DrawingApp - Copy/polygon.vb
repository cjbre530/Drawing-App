Public Class polygon
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
        width = 30
        height = 30
    End Sub
    Public Sub Draw()
        Using g As Graphics = Graphics.FromImage(m_image)
            Dim p(7) As Point
            p(0) = New Point(m_a.X, m_a.Y)
            p(1) = New Point(m_a.X - width, m_a.Y - height)
            p(2) = New Point(m_a.X - 2 * width, m_a.Y)
            p(3) = New Point(m_a.X - 2.5 * width, m_a.Y - height)
            p(4) = New Point(m_a.X - 2.5 * width, m_a.Y + height)
            p(5) = New Point(m_a.X - 2 * width, m_a.Y)
            p(6) = New Point(m_a.X - width, m_a.Y + height)
            p(7) = New Point(m_a.X, m_a.Y)

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
