Public Class Form1
    Private m_Previous As System.Nullable(Of Point) = Nothing
    Dim m_shapes As New Collection
    Dim type As Integer
    Dim currentimage As Image

    Sub AddShape(curr As Point, c As Color)
        Select Case type
            Case 1
                Dim l As New Line(PictureBox1.Image, m_Previous, curr, c)
                l.Pen.Width = TrackBar1.Value
                m_shapes.Add(l)

            Case 2
                Dim r As New Rectangle(PictureBox1.Image, curr, c)
                r.fill = fillCheckBox.Checked
                r.width = widthTrackBar.Value
                r.height = heightTrackBar.Value
                m_shapes.Add(r)

            Case 3
                Dim p As New mypic(PictureBox1.Image, curr, currentimage)
                p.size = TrackBar2.Value
                m_shapes.Add(p)

            Case 4
                Dim e As New ellipse(PictureBox1.Image, curr, c)
                e.fill = fillCheckBox.Checked
                e.width = widthTrackBar.Value
                e.height = heightTrackBar.Value
                m_shapes.Add(e)

            Case 5
                Dim a As New arc(PictureBox1.Image, curr, c)
                a.fill = fillCheckBox.Checked
                a.width = widthTrackBar.Value
                a.height = heightTrackBar.Value
                m_shapes.Add(a)

            Case 6
                Dim t As New triangle(PictureBox1.Image, curr, c)
                t.fill = fillCheckBox.Checked
                t.width = widthTrackBar.Value
                t.height = heightTrackBar.Value
                m_shapes.Add(t)

            Case 7
                Dim p As New polygon(PictureBox1.Image, curr, c)
                p.fill = fillCheckBox.Checked
                p.width = widthTrackBar.Value
                p.height = heightTrackBar.Value
                m_shapes.Add(p)

            Case 8
                Dim n As New Ngon(PictureBox1.Image, curr, c)
                n.fill = fillCheckBox.Checked
                n.width = widthTrackBar.Value
                n.sides = sidesTrackBar.Value
                m_shapes.Add(n)

            Case 9
                Dim g As New gradiant(PictureBox1.Image, curr, c)
                g.fill = fillCheckBox.Checked
                g.width = widthTrackBar.Value
                m_shapes.Add(g)

                Dim linGrBrush As New Drawing.Drawing2D.LinearGradientBrush(New Point(0, 10),
                                                                            New Point(200, 10),
                                                                         Grad1.BackColor,
                                                                         Grad2.BackColor)


                g.brush = linGrBrush

            Case 10
                Dim h As New House(PictureBox1.Image, curr, c)
                h.fill = fillCheckBox.Checked
                m_shapes.Add(h)

            Case 11
                Dim h As New Shape(PictureBox1.Image, curr, c)
                h.fill = fillCheckBox.Checked
                m_shapes.Add(h)

            Case 12
                Dim s As New Shapee(PictureBox1.Image, curr, c)
                s.fill = fillCheckBox.Checked
                m_shapes.Add(s)

            Case 13
                Dim s As New eeesh(PictureBox1.Image, curr, c)
                s.fill = fillCheckBox.Checked
                m_shapes.Add(s)

            Case 14
                Dim l As New Eraser(PictureBox1.Image, m_Previous, curr, c)
                l.Pen.Width = TrackBar1.Value
                m_shapes.Add(l)

            Case Else

        End Select

    End Sub
    Private Sub pictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        m_Previous = e.Location
        pictureBox1_MouseMove(sender, e)
    End Sub

    Private Sub pictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        If m_Previous IsNot Nothing Then
            AddShape(e.Location, colorButton.BackColor)
            PictureBox1.Invalidate()
            m_Previous = e.Location
        End If
    End Sub

    Private Sub pictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp
        m_Previous = Nothing
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        If PictureBox1.Image Is Nothing Then
            Reset()
        End If
        type = 1
        m_Previous = Nothing
    End Sub

    Sub Reset()
        Dim bmp As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.Clear(Color.White)
        End Using
        PictureBox1.Image = bmp
    End Sub
    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint
        For Each s As Object In m_shapes
            s.Draw()
        Next
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles colorButton.Click
        ColorDialog1.ShowDialog()
        colorButton.BackColor = ColorDialog1.Color
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        type = 1
        m_Previous = Nothing
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        type = 2
        m_Previous = Nothing
    End Sub

    Private Sub PictureBox2_MouseClick(sender As Object, e As MouseEventArgs) Handles PictureBox2.MouseClick
        type = 3
        currentimage = sender.image
        m_Previous = Nothing
        If e.Button = MouseButtons.Left Then
            OpenFileDialog1.ShowDialog()
            sender.load(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        OpenFileDialog1.ShowDialog()
        PictureBox1.Load(OpenFileDialog1.FileName)
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        SaveFileDialog1.ShowDialog()
        PictureBox1.Image.Save(SaveFileDialog1.FileName)
    End Sub

    Private Sub ResetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetToolStripMenuItem.Click
        Reset()
        m_shapes.Clear()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        For Each s As Object In m_shapes
            Try
                s.move(5, 5)
            Catch ex As Exception

            End Try
        Next
        Refresh()
    End Sub

    Private Sub animateCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles animateCheckBox.CheckedChanged
        Timer1.Enabled = sender.checked
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs)
        type = 4
        m_Previous = Nothing
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        colorButton.BackColor = Color.Red
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        colorButton.BackColor = Color.Orange
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        colorButton.BackColor = Color.Yellow
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        colorButton.BackColor = Color.Cyan
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        colorButton.BackColor = Color.Blue
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        colorButton.BackColor = Color.Fuchsia
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        colorButton.BackColor = Color.Black
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        colorButton.BackColor = Color.DarkGoldenrod
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        colorButton.BackColor = Color.Gray
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs)
        type = 5
        m_Previous = Nothing
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs)
        type = 6
        m_Previous = Nothing
    End Sub

    Private Sub polygonButton_Click(sender As Object, e As EventArgs)
        type = 7
        m_Previous = Nothing
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs)
        type = 8
        m_Previous = Nothing
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        type = 2
        m_Previous = Nothing
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs)
        type = 4
        m_Previous = Nothing
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs)
        type = 6
        m_Previous = Nothing
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs)
        type = 7
        m_Previous = Nothing
    End Sub

    Private Sub Grad2_Click(sender As Object, e As EventArgs) Handles Grad2.Click, Grad1.Click
        ColorDialog1.ShowDialog()
        sender.backcolor = ColorDialog1.Color
    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click
        type = 2
        m_Previous = Nothing
    End Sub

    Private Sub ToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem7.Click
        type = 4
        m_Previous = Nothing

    End Sub

    Private Sub ToolStripMenuItem8_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem8.Click
        type = 6
        m_Previous = Nothing
    End Sub

    Private Sub ToolStripMenuItem9_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem9.Click
        type = 7
        m_Previous = Nothing
    End Sub

    Private Sub ToolStripMenuItem3_Click_1(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        type = 1
        m_Previous = Nothing
    End Sub

    Private Sub NgonToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NgonToolStripMenuItem.Click
        type = 8
        m_Previous = Nothing
    End Sub

    Private Sub ArcToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArcToolStripMenuItem.Click
        type = 5
        m_Previous = Nothing
    End Sub

    Private Sub GradiantToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GradiantToolStripMenuItem.Click
        type = 9
        m_Previous = Nothing
    End Sub

    Private Sub HouseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HouseToolStripMenuItem.Click
        type = 10
        m_Previous = Nothing
    End Sub

    Private Sub IdkToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IdkToolStripMenuItem.Click
        type = 11
        m_Previous = Nothing
    End Sub

    Private Sub ShapeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShapeToolStripMenuItem.Click
        type = 12
        m_Previous = Nothing
    End Sub

    Private Sub EeshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EeshToolStripMenuItem.Click
        type = 13
        m_Previous = Nothing
    End Sub

    Private Sub PictureBox3_MouseClick(sender As Object, e As MouseEventArgs) Handles PictureBox3.MouseClick
        type = 14
        m_Previous = Nothing
        colorButton.BackColor = Color.White
    End Sub
End Class
