Public Class mypic
    Public Property Pen As Pen
    Public Property size As Integer
    Dim m_image As Image
    Dim m_a As Point
    Dim m_pic As Image

    Public Sub New(i As Image, a As Point, Pic As Image)
        m_pic = Pic
        m_image = i
        m_a = a
        size = 10
    End Sub

    Public Sub Draw()
        Using g As Graphics = Graphics.FromImage(m_image)
            g.DrawImage(m_pic, m_a.X, m_a.Y, size, size)

        End Using
    End Sub

End Class
