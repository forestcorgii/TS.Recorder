Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmStream
    Inherits System.Windows.Forms.Form

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
        Me.components = New System.ComponentModel.Container()
        Me.fvStream = New Neurotec.Biometrics.Gui.NFaceView()
        Me.tmChecker = New System.Windows.Forms.Timer(Me.components)
        Me.tmClosingAttempt = New System.Windows.Forms.Timer(Me.components)
        Me.tmCamera2Checking = New System.Windows.Forms.Timer(Me.components)
        Me.tmRefresher = New System.Windows.Forms.Timer(Me.components)
        Me.pnlSuccess = New System.Windows.Forms.Panel()
        Me.pnlError = New System.Windows.Forms.Panel()
        Me.lbResultMessage = New System.Windows.Forms.Label()
        Me.pnlError.SuspendLayout()
        Me.SuspendLayout()
        '
        'fvStream
        '
        Me.fvStream.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fvStream.BackColor = System.Drawing.Color.Black
        Me.fvStream.Face = Nothing
        Me.fvStream.FaceIds = Nothing
        Me.fvStream.IcaoArrowsColor = System.Drawing.Color.Red
        Me.fvStream.Location = New System.Drawing.Point(1, 1)
        Me.fvStream.Margin = New System.Windows.Forms.Padding(1)
        Me.fvStream.Name = "fvStream"
        Me.fvStream.ShowIcaoArrows = True
        Me.fvStream.ShowTokenImageRectangle = True
        Me.fvStream.Size = New System.Drawing.Size(394, 235)
        Me.fvStream.TabIndex = 0
        Me.fvStream.TokenImageRectangleColor = System.Drawing.Color.White
        '
        'tmChecker
        '
        Me.tmChecker.Interval = 2000
        '
        'tmClosingAttempt
        '
        Me.tmClosingAttempt.Interval = 500
        '
        'tmCamera2Checking
        '
        Me.tmCamera2Checking.Interval = 500
        '
        'tmRefresher
        '
        Me.tmRefresher.Interval = 10000
        '
        'pnlSuccess
        '
        Me.pnlSuccess.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlSuccess.BackColor = System.Drawing.Color.PaleGreen
        Me.pnlSuccess.BackgroundImage = Global.Time_Recorder_v5s._0.My.Resources.Resources.icons8_ok_240
        Me.pnlSuccess.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pnlSuccess.Location = New System.Drawing.Point(0, 0)
        Me.pnlSuccess.Name = "pnlSuccess"
        Me.pnlSuccess.Size = New System.Drawing.Size(394, 235)
        Me.pnlSuccess.TabIndex = 1
        Me.pnlSuccess.Visible = False
        '
        'pnlError
        '
        Me.pnlError.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlError.BackColor = System.Drawing.Color.MistyRose
        Me.pnlError.BackgroundImage = Global.Time_Recorder_v5s._0.My.Resources.Resources.icons8_cancel_240
        Me.pnlError.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pnlError.Controls.Add(Me.pnlSuccess)
        Me.pnlError.Location = New System.Drawing.Point(1, 1)
        Me.pnlError.Name = "pnlError"
        Me.pnlError.Size = New System.Drawing.Size(394, 235)
        Me.pnlError.TabIndex = 2
        Me.pnlError.Visible = False
        '
        'lbResultMessage
        '
        Me.lbResultMessage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbResultMessage.BackColor = System.Drawing.Color.Transparent
        Me.lbResultMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbResultMessage.ForeColor = System.Drawing.Color.Black
        Me.lbResultMessage.Location = New System.Drawing.Point(-3, 242)
        Me.lbResultMessage.Name = "lbResultMessage"
        Me.lbResultMessage.Size = New System.Drawing.Size(398, 30)
        Me.lbResultMessage.TabIndex = 2
        Me.lbResultMessage.Text = "Welcome!"
        Me.lbResultMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmStream
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(394, 281)
        Me.Controls.Add(Me.pnlError)
        Me.Controls.Add(Me.lbResultMessage)
        Me.Controls.Add(Me.fvStream)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.KeyPreview = True
        Me.Name = "frmStream"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.pnlError.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fvStream As Neurotec.Biometrics.Gui.NFaceView
    Friend WithEvents tmChecker As System.Windows.Forms.Timer
    Friend WithEvents tmClosingAttempt As System.Windows.Forms.Timer
    Friend WithEvents tmCamera2Checking As System.Windows.Forms.Timer
    Friend WithEvents tmRefresher As System.Windows.Forms.Timer
    Friend WithEvents pnlSuccess As Panel
    Friend WithEvents pnlError As Panel
    Friend WithEvents lbResultMessage As Label
End Class
