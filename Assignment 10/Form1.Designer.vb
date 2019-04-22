<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblGreeting = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.imgPicture = New System.Windows.Forms.PictureBox()
        CType(Me.imgPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblGreeting
        '
        Me.lblGreeting.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGreeting.Location = New System.Drawing.Point(264, 24)
        Me.lblGreeting.Name = "lblGreeting"
        Me.lblGreeting.Size = New System.Drawing.Size(344, 72)
        Me.lblGreeting.TabIndex = 0
        Me.lblGreeting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(360, 384)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(160, 40)
        Me.btnExit.TabIndex = 1
        '
        'imgPicture
        '
        Me.imgPicture.Location = New System.Drawing.Point(264, 112)
        Me.imgPicture.Name = "imgPicture"
        Me.imgPicture.Size = New System.Drawing.Size(344, 248)
        Me.imgPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgPicture.TabIndex = 2
        Me.imgPicture.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(640, 446)
        Me.Controls.Add(Me.imgPicture)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.lblGreeting)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Assignment #10"
        CType(Me.imgPicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblGreeting As System.Windows.Forms.Label
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents imgPicture As System.Windows.Forms.PictureBox
End Class
