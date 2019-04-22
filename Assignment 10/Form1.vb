Imports System.Drawing.Text
Imports System.IO
Imports System.Resources

Public Class Form1

    Dim currResex As ResXResourceSet
    Dim imgFlags As ArrayList
    Const WS_EX_LAYOUTRTL As Integer = &H400000
    Const WS_EX_NOINHERITLAYOUT As Integer = &H100000

    Dim _mirrored As Boolean = False

    Public Property Mirrored() As Boolean
        Get
            Return _mirrored
        End Get
        Set
            If (_mirrored <> Value) Then
                _mirrored = Value
                MyBase.OnRightToLeftChanged(EventArgs.Empty)
            End If
            If (_mirrored) Then
                Me.RightToLeft = RightToLeft.Yes
            Else
                Me.RightToLeft = RightToLeft.No
            End If
        End Set
    End Property



    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim CP As CreateParams = MyBase.CreateParams
            If (Me.Mirrored) Then
                CP.ExStyle = CP.ExStyle Or WS_EX_LAYOUTRTL Or WS_EX_NOINHERITLAYOUT

            End If
            Return CP
        End Get
    End Property



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        imgFlags = New ArrayList(5)
        btnExit.Visible = False

        For Each strFileName As String In Directory.GetFiles(Application.StartupPath)

            If (strFileName.EndsWith(".resx")) Then

                ' if there Is enough room in the flag arraylist...
                If (imgFlags.Count < imgFlags.Capacity) Then
                    Dim Resources As ResXResourceSet = New ResXResourceSet(strFileName)
                    '// check for a culture value
                    If (Resources.GetString("culture") <> Nothing) Then
                        '// create a New picturebox For the flag And add Event handler
                        Dim pbxFlag As PictureBox = New PictureBox()
                        pbxFlag.Size = New Size(152, 72)
                        pbxFlag.SizeMode = PictureBoxSizeMode.StretchImage
                        pbxFlag.Tag = strFileName
                        AddHandler pbxFlag.Click, AddressOf flag_Click
                        '// make sure there Is a valid flag path
                        If (Resources.GetString("flag_path") <> Nothing And File.Exists(Resources.GetString("flag_path"))) Then

                            pbxFlag.Image = Image.FromFile(Resources.GetString("flag_path"))
                        Else
                            pbxFlag.Image = GenerateFlag(Resources.GetString("culture"))
                        End If

                        If (imgFlags.Count = 0) Then
                            '// set base location of first flag
                            pbxFlag.Location = New Point(16, 32)

                        Else
                            '// offset the rest according To the preceding image
                            pbxFlag.Location = New Point(imgFlags(0).Location.X, imgFlags(imgFlags.Count - 1).Location.Y + pbxFlag.Size.Height + 8)
                        End If
                        Me.Controls.Add(pbxFlag) '// add image To the control array
                        imgFlags.Add(pbxFlag)       '// add image To the flags arraylist

                    Else
                    End If
                End If
            End If
        Next

    End Sub

    Private Function GenerateFlag(v As String) As Image
        Dim bmp As Bitmap = New Bitmap(1, 1)    '// create an initial image
        Dim Graphics As Graphics = System.Drawing.Graphics.FromImage(bmp)   '// graphics Object
        Dim Brush As SolidBrush = New SolidBrush(Color.White)       '// brush For drawing text
        Dim Font As Font = New Font("Tahoma", 14, FontStyle.Bold)       '// font For text
        Dim StringFormat As StringFormat = New StringFormat(StringFormat.GenericTypographic)

        '// get sizes for bitmap, so text will fit
        Dim intHeight As Integer = Convert.ToInt32(Graphics.MeasureString(v, Font, New PointF(0, 0), StringFormat).Height)
        Dim intWidth As Integer = 152 / 14 + Convert.ToInt32(Graphics.MeasureString(v, Font, New PointF(0, 0), StringFormat).Width)
        bmp = New Bitmap(intWidth, intHeight)   '// resize image
        Graphics = System.Drawing.Graphics.FromImage(bmp)
        Graphics.Clear(Color.Black)
        Graphics.TextRenderingHint = TextRenderingHint.SystemDefault

        '// draw text on canvas
        Graphics.DrawString(v.Replace(""""c, " "c), Font, Brush, New Rectangle(0, 0, intWidth, intHeight))

        '// dispose of objects
        Font.Dispose()
        StringFormat.Dispose()
        Graphics.Dispose()
        Return bmp
    End Function


    Private Sub exit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub flag_Click(sender As Object, e As EventArgs)
        Dim Graphics As Graphics = lblGreeting.CreateGraphics()
        Dim Font As Font = New Font("Tahoma", 12)
        Dim fltFactor, fltFactorX, fltFactorY As Double

        Me.currResex = New ResXResourceSet(CType(sender, PictureBox).Tag.ToString())
        '// display greeting, if available
        If (currResex.GetString("greeting") <> Nothing) Then

            lblGreeting.Text = currResex.GetString("greeting")
        Else
            lblGreeting.Text = "our default"

        End If

        '// resize font so text will fit
        fltFactorY = lblGreeting.Height / Graphics.MeasureString("  " + lblGreeting.Text + "  ", Font).Height
        fltFactorX = lblGreeting.Width / Graphics.MeasureString("  " + lblGreeting.Text + "  ", Font).Width
        If (fltFactorX > fltFactorY) Then

            fltFactor = fltFactorY

        Else

            fltFactor = fltFactorX
        End If

        lblGreeting.Font = New Font(Font.Name, Font.SizeInPoints * fltFactor)

        '// display representative image, if available
        If (currResex.GetString("image") <> Nothing And File.Exists(currResex.GetString("image"))) Then

            imgPicture.Image = Image.FromFile(currResex.GetString("image"))

        Else

            imgPicture.Image = Nothing
        End If

        '// display exit text, if available
        If (currResex.GetString("exit") <> Nothing) Then

            btnExit.Text = currResex.GetString("exit")

        Else

            btnExit.Text = "our default"
        End If

        '// resize exit font to fit button
        fltFactorY = btnExit.Height / Graphics.MeasureString("  " + btnExit.Text + "  ", Font).Height
        fltFactorX = btnExit.Width / Graphics.MeasureString("  " + btnExit.Text + "  ", Font).Width
        If (fltFactorX > fltFactorY) Then

            fltFactor = fltFactorY

        Else

            fltFactor = fltFactorX
        End If


        btnExit.Font = New Font(Font.Name, Font.SizeInPoints * fltFactor)
        btnExit.Visible = True

        '// set rtl property if rtl Is set in ResX file
        If (currResex.GetString("rtl") <> Nothing) Then

            Me.Mirrored = Convert.ToBoolean(currResex.GetString("rtl"))

        Else

            Me.Mirrored = False
        End If
    End Sub

End Class
