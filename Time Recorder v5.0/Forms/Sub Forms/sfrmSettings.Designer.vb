<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class sfrmSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(sfrmSettings))
        Me.btnOpenBiometricClientSettings = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.tbEmployeeURL = New System.Windows.Forms.TextBox()
        Me.tbEmployeeSite = New System.Windows.Forms.TextBox()
        Me.tbEmployeeTerminal = New System.Windows.Forms.TextBox()
        Me.tbEmployeeToken = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.tbAttendanceURL = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tbHRMSToken = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tbHRMSWhat = New System.Windows.Forms.TextBox()
        Me.tbHRMSSearch = New System.Windows.Forms.TextBox()
        Me.tbHRMSURL = New System.Windows.Forms.TextBox()
        Me.tbHRMSField = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.tbUPSGURL = New System.Windows.Forms.TextBox()
        Me.tbUPSGSite = New System.Windows.Forms.TextBox()
        Me.tbUPSGAction = New System.Windows.Forms.TextBox()
        Me.tbUPSGToken = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOpenBiometricClientSettings
        '
        Me.btnOpenBiometricClientSettings.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnOpenBiometricClientSettings.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpenBiometricClientSettings.Location = New System.Drawing.Point(8, 576)
        Me.btnOpenBiometricClientSettings.Name = "btnOpenBiometricClientSettings"
        Me.btnOpenBiometricClientSettings.Size = New System.Drawing.Size(190, 23)
        Me.btnOpenBiometricClientSettings.TabIndex = 44
        Me.btnOpenBiometricClientSettings.Text = "Open Biometric Client Settings"
        Me.btnOpenBiometricClientSettings.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(5, Byte), Integer), CType(CType(23, Byte), Integer))
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(459, 576)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(98, 23)
        Me.btnSave.TabIndex = 13
        Me.btnSave.Text = "SAVE"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.tbEmployeeURL)
        Me.GroupBox3.Controls.Add(Me.tbEmployeeSite)
        Me.GroupBox3.Controls.Add(Me.tbEmployeeTerminal)
        Me.GroupBox3.Controls.Add(Me.tbEmployeeToken)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(526, 109)
        Me.GroupBox3.TabIndex = 10
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Employee"
        '
        'tbEmployeeURL
        '
        Me.tbEmployeeURL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbEmployeeURL.Location = New System.Drawing.Point(54, 65)
        Me.tbEmployeeURL.Name = "tbEmployeeURL"
        Me.tbEmployeeURL.Size = New System.Drawing.Size(465, 27)
        Me.tbEmployeeURL.TabIndex = 7
        '
        'tbEmployeeSite
        '
        Me.tbEmployeeSite.Location = New System.Drawing.Point(54, 28)
        Me.tbEmployeeSite.Name = "tbEmployeeSite"
        Me.tbEmployeeSite.Size = New System.Drawing.Size(78, 27)
        Me.tbEmployeeSite.TabIndex = 6
        '
        'tbEmployeeTerminal
        '
        Me.tbEmployeeTerminal.Location = New System.Drawing.Point(402, 28)
        Me.tbEmployeeTerminal.Name = "tbEmployeeTerminal"
        Me.tbEmployeeTerminal.Size = New System.Drawing.Size(117, 27)
        Me.tbEmployeeTerminal.TabIndex = 5
        '
        'tbEmployeeToken
        '
        Me.tbEmployeeToken.Location = New System.Drawing.Point(194, 28)
        Me.tbEmployeeToken.Name = "tbEmployeeToken"
        Me.tbEmployeeToken.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbEmployeeToken.Size = New System.Drawing.Size(121, 27)
        Me.tbEmployeeToken.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(321, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 19)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Terminal"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 19)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "URL"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 19)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Site"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(138, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Token"
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.tbAttendanceURL)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(6, 130)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(526, 66)
        Me.GroupBox4.TabIndex = 10
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Attendance"
        '
        'tbAttendanceURL
        '
        Me.tbAttendanceURL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbAttendanceURL.Location = New System.Drawing.Point(54, 26)
        Me.tbAttendanceURL.Name = "tbAttendanceURL"
        Me.tbAttendanceURL.Size = New System.Drawing.Size(465, 27)
        Me.tbAttendanceURL.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 34)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 19)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "URL"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(8, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(549, 558)
        Me.TabControl1.TabIndex = 45
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(541, 397)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "General"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.GroupBox4)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(541, 532)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "APIs"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.tbHRMSToken)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.tbHRMSWhat)
        Me.GroupBox1.Controls.Add(Me.tbHRMSSearch)
        Me.GroupBox1.Controls.Add(Me.tbHRMSURL)
        Me.GroupBox1.Controls.Add(Me.tbHRMSField)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(6, 202)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(526, 146)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "HRMS"
        '
        'tbHRMSToken
        '
        Me.tbHRMSToken.Location = New System.Drawing.Point(67, 92)
        Me.tbHRMSToken.Name = "tbHRMSToken"
        Me.tbHRMSToken.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbHRMSToken.Size = New System.Drawing.Size(121, 27)
        Me.tbHRMSToken.TabIndex = 9
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(11, 100)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(50, 19)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Token"
        '
        'tbHRMSWhat
        '
        Me.tbHRMSWhat.Location = New System.Drawing.Point(67, 59)
        Me.tbHRMSWhat.Name = "tbHRMSWhat"
        Me.tbHRMSWhat.Size = New System.Drawing.Size(121, 27)
        Me.tbHRMSWhat.TabIndex = 13
        '
        'tbHRMSSearch
        '
        Me.tbHRMSSearch.Location = New System.Drawing.Point(424, 59)
        Me.tbHRMSSearch.Name = "tbHRMSSearch"
        Me.tbHRMSSearch.Size = New System.Drawing.Size(95, 27)
        Me.tbHRMSSearch.TabIndex = 12
        '
        'tbHRMSURL
        '
        Me.tbHRMSURL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbHRMSURL.Location = New System.Drawing.Point(67, 26)
        Me.tbHRMSURL.Name = "tbHRMSURL"
        Me.tbHRMSURL.Size = New System.Drawing.Size(452, 27)
        Me.tbHRMSURL.TabIndex = 9
        '
        'tbHRMSField
        '
        Me.tbHRMSField.Location = New System.Drawing.Point(236, 59)
        Me.tbHRMSField.Name = "tbHRMSField"
        Me.tbHRMSField.Size = New System.Drawing.Size(121, 27)
        Me.tbHRMSField.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 34)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 19)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "URL"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(363, 67)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 19)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Search"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(189, 67)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 19)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Field"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 67)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 19)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "What"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.tbUPSGURL)
        Me.GroupBox2.Controls.Add(Me.tbUPSGSite)
        Me.GroupBox2.Controls.Add(Me.tbUPSGAction)
        Me.GroupBox2.Controls.Add(Me.tbUPSGToken)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(6, 354)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(526, 109)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "UPSG"
        '
        'tbUPSGURL
        '
        Me.tbUPSGURL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbUPSGURL.Location = New System.Drawing.Point(54, 65)
        Me.tbUPSGURL.Name = "tbUPSGURL"
        Me.tbUPSGURL.Size = New System.Drawing.Size(465, 27)
        Me.tbUPSGURL.TabIndex = 7
        '
        'tbUPSGSite
        '
        Me.tbUPSGSite.Location = New System.Drawing.Point(54, 28)
        Me.tbUPSGSite.Name = "tbUPSGSite"
        Me.tbUPSGSite.Size = New System.Drawing.Size(78, 27)
        Me.tbUPSGSite.TabIndex = 6
        '
        'tbUPSGAction
        '
        Me.tbUPSGAction.Location = New System.Drawing.Point(380, 28)
        Me.tbUPSGAction.Name = "tbUPSGAction"
        Me.tbUPSGAction.Size = New System.Drawing.Size(139, 27)
        Me.tbUPSGAction.TabIndex = 5
        '
        'tbUPSGToken
        '
        Me.tbUPSGToken.Location = New System.Drawing.Point(194, 28)
        Me.tbUPSGToken.Name = "tbUPSGToken"
        Me.tbUPSGToken.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbUPSGToken.Size = New System.Drawing.Size(121, 27)
        Me.tbUPSGToken.TabIndex = 4
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(321, 36)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(53, 19)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "Action"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 73)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(35, 19)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "URL"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 36)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(35, 19)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "Site"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(138, 36)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(50, 19)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Token"
        '
        'sfrmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(562, 606)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnOpenBiometricClientSettings)
        Me.Controls.Add(Me.btnSave)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(401, 155)
        Me.Name = "sfrmSettings"
        Me.Text = "Settings"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnOpenBiometricClientSettings As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents tbEmployeeURL As System.Windows.Forms.TextBox
    Friend WithEvents tbEmployeeSite As System.Windows.Forms.TextBox
    Friend WithEvents tbEmployeeTerminal As System.Windows.Forms.TextBox
    Friend WithEvents tbEmployeeToken As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbAttendanceURL As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tbHRMSURL As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tbHRMSWhat As System.Windows.Forms.TextBox
    Friend WithEvents tbHRMSSearch As System.Windows.Forms.TextBox
    Friend WithEvents tbHRMSField As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tbHRMSToken As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents tbUPSGURL As System.Windows.Forms.TextBox
    Friend WithEvents tbUPSGSite As System.Windows.Forms.TextBox
    Friend WithEvents tbUPSGAction As System.Windows.Forms.TextBox
    Friend WithEvents tbUPSGToken As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
End Class
