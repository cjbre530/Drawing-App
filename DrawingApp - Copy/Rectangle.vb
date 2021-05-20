Public Class Rectangle
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
            If fill Then
                g.FillRectangle(New SolidBrush(Pen.Color), m_a.X, m_a.Y, width, height)
            Else
                g.DrawRectangle(Pen, m_a.X, m_a.Y, width, height)
            End If
        End Using
    End Sub


    Sub move(x As Integer, y As Integer)
        m_a = New Point(m_a.X + x, m_a.Y + y)
    End Sub

End Class
