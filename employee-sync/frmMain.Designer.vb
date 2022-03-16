<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.pb = New System.Windows.Forms.ProgressBar()
        Me.lbStatus = New System.Windows.Forms.Label()
        Me.tmLister = New System.Windows.Forms.Timer(Me.components)
        Me.bgwSync = New System.ComponentModel.BackgroundWorker()
        Me.SuspendLayout()
        '
        'pb
        '
        Me.pb.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pb.Location = New System.Drawing.Point(0, 77)
        Me.pb.Name = "pb"
        Me.pb.Size = New System.Drawing.Size(376, 23)
        Me.pb.TabIndex = 3
        '
        'lbStatus
        '
        Me.lbStatus.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbStatus.Location = New System.Drawing.Point(12, 4)
        Me.lbStatus.Name = "lbStatus"
        Me.lbStatus.Size = New System.Drawing.Size(352, 70)
        Me.lbStatus.TabIndex = 2
        Me.lbStatus.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'tmLister
        '
        Me.tmLister.Enabled = True
        '
        'bgwSync
        '
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(376, 100)
        Me.Controls.Add(Me.pb)
        Me.Controls.Add(Me.lbStatus)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.Text = "Employee Sync"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pb As ProgressBar
    Friend WithEvents lbStatus As Label
    Friend WithEvents tmLister As Timer
    Friend WithEvents bgwSync As System.ComponentModel.BackgroundWorker
End Class
