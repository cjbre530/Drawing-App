Public Class Line
    Public Property Pen As Pen
    Dim m_image As Image
    Dim m_a As Point
    Dim m_b As Point

    Public Sub New(i As Image, a As Point, b As Point, c As Color)
        Pen = New Pen(c)
        m_image = i
        m_a = a
        m_b = b
    End Sub

    Public Sub Draw()
        Using g As Graphics = Graphics.FromImage(m_image)
            g.DrawLine(Pen, m_a, m_b)
        End Using

    End Sub

    Public Sub move(x As Integer, y As Integer)
        m_a = New Point(m_a.X + x, m_a.Y + y)
        m_b = New Point(m_a.X + x, m_a.Y + y)
    End Sub

End Class
