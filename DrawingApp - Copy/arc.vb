Public Class arc
    Public Property Pen As Pen
    Public Property fill As Boolean
    Public Property width As Integer
    Public Property height As Integer
    Public Property start As Integer
    Public Property sweep As Integer
    Dim m_image As Image
    Dim m_a As Point
    Dim m_b As Point

    Public Sub New(i As Image, a As Point, c As Color)
        Pen = New Pen(c)
        m_image = i
        m_a = a
        width = 30
        height = 30
        start = 5
        sweep = 10
    End Sub
    Public Sub Draw()
        Using g As Graphics = Graphics.FromImage(m_image)
            g.DrawArc(Pen, m_a.X, m_a.Y, width, height, start, sweep)
        End Using
    End Sub

    Sub move(x As Integer, y As Integer)
        m_a = New Point(m_a.X + x, m_a.Y + y)
    End Sub
End Class
