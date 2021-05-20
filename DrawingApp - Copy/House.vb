Public Class House
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
        Using h As Graphics = Graphics.FromImage(m_image)
            Dim p(4) As Point
            p(0) = New Point(m_a.X, m_a.Y)
            p(1) = New Point(m_a.X - width, m_a.Y)
            p(2) = New Point(m_a.X, m_a.Y + height)
            p(3) = New Point(m_a.X + width, m_a.Y)
            p(4) = New Point(m_a.X, m_a.Y - height)


            If fill Then
                h.FillPolygon(New SolidBrush(Pen.Color), p)
            Else
                h.DrawPolygon(Pen, p)
            End If
        End Using
    End Sub


    Sub move(x As Integer, y As Integer)
        m_a = New Point(m_a.X + x, m_a.Y + y)
    End Sub
End Class
