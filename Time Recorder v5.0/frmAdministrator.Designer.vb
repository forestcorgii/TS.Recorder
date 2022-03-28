<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdministrator
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAdministrator))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.tbJobcode = New System.Windows.Forms.TextBox()
        Me.cbActive = New System.Windows.Forms.CheckBox()
        Me.lbMessage2 = New System.Windows.Forms.Label()
        Me.btnRegFace = New System.Windows.Forms.Button()
        Me.btnSaveProfile = New System.Windows.Forms.Button()
        Me.cbAdmin = New System.Windows.Forms.CheckBox()
        Me.tbEmployeeNumber = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbMiddleName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbLastName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbFirstName = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnSaveAPI = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnUPSGApiTest = New System.Windows.Forms.Button()
        Me.tbUPSGURL = New System.Windows.Forms.TextBox()
        Me.tbUPSGSite = New System.Windows.Forms.TextBox()
        Me.tbUPSGAction = New System.Windows.Forms.TextBox()
        Me.tbUPSGToken = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnHRMSApiTest = New System.Windows.Forms.Button()
        Me.tbHRMSToken = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tbHRMSWhat = New System.Windows.Forms.TextBox()
        Me.tbHRMSSearch = New System.Windows.Forms.TextBox()
        Me.tbHRMSURL = New System.Windows.Forms.TextBox()
        Me.tbHRMSField = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnFaceProfileApiTest = New System.Windows.Forms.Button()
        Me.tbEmployeeURL = New System.Windows.Forms.TextBox()
        Me.tbEmployeeSite = New System.Windows.Forms.TextBox()
        Me.tbEmployeeTerminal = New System.Windows.Forms.TextBox()
        Me.tbEmployeeToken = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnAttendanceApiTest = New System.Windows.Forms.Button()
        Me.tbAttendanceURL = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btnOpenBiometricClientSettings = New System.Windows.Forms.Button()
        Me.Panel2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label20)
        Me.Panel2.Controls.Add(Me.tbJobcode)
        Me.Panel2.Controls.Add(Me.cbActive)
        Me.Panel2.Controls.Add(Me.lbMessage2)
        Me.Panel2.Controls.Add(Me.btnRegFace)
        Me.Panel2.Controls.Add(Me.btnSaveProfile)
        Me.Panel2.Controls.Add(Me.cbAdmin)
        Me.Panel2.Controls.Add(Me.tbEmployeeNumber)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.tbMiddleName)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.tbLastName)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.tbFirstName)
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(315, 594)
        Me.Panel2.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(3, 241)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(302, 183)
        Me.Label8.TabIndex = 44
        Me.Label8.Text = "To Register:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "1. Input Employee ID." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "2. Click the 'Register Face' Button." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "3. C" &
    "lick Save."
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(3, 154)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(87, 30)
        Me.Label20.TabIndex = 42
        Me.Label20.Text = "Jobcode:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbJobcode
        '
        Me.tbJobcode.BackColor = System.Drawing.Color.GhostWhite
        Me.tbJobcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbJobcode.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbJobcode.Location = New System.Drawing.Point(96, 157)
        Me.tbJobcode.MaxLength = 50
        Me.tbJobcode.Name = "tbJobcode"
        Me.tbJobcode.ReadOnly = True
        Me.tbJobcode.Size = New System.Drawing.Size(71, 23)
        Me.tbJobcode.TabIndex = 41
        '
        'cbActive
        '
        Me.cbActive.AutoSize = True
        Me.cbActive.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbActive.Location = New System.Drawing.Point(245, 39)
        Me.cbActive.Name = "cbActive"
        Me.cbActive.Size = New System.Drawing.Size(60, 19)
        Me.cbActive.TabIndex = 40
        Me.cbActive.Text = "Active"
        Me.cbActive.UseVisualStyleBackColor = True
        '
        'lbMessage2
        '
        Me.lbMessage2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMessage2.ForeColor = System.Drawing.Color.Black
        Me.lbMessage2.Location = New System.Drawing.Point(14, 186)
        Me.lbMessage2.Name = "lbMessage2"
        Me.lbMessage2.Size = New System.Drawing.Size(170, 42)
        Me.lbMessage2.TabIndex = 39
        Me.lbMessage2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnRegFace
        '
        Me.btnRegFace.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRegFace.Location = New System.Drawing.Point(190, 188)
        Me.btnRegFace.Name = "btnRegFace"
        Me.btnRegFace.Size = New System.Drawing.Size(115, 39)
        Me.btnRegFace.TabIndex = 38
        Me.btnRegFace.Text = "Register Face Profile"
        Me.btnRegFace.UseVisualStyleBackColor = True
        '
        'btnSaveProfile
        '
        Me.btnSaveProfile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveProfile.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveProfile.Location = New System.Drawing.Point(158, 549)
        Me.btnSaveProfile.Name = "btnSaveProfile"
        Me.btnSaveProfile.Size = New System.Drawing.Size(145, 35)
        Me.btnSaveProfile.TabIndex = 34
        Me.btnSaveProfile.Text = "Save Changes"
        Me.btnSaveProfile.UseVisualStyleBackColor = True
        '
        'cbAdmin
        '
        Me.cbAdmin.AutoSize = True
        Me.cbAdmin.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAdmin.Location = New System.Drawing.Point(173, 39)
        Me.cbAdmin.Name = "cbAdmin"
        Me.cbAdmin.Size = New System.Drawing.Size(62, 19)
        Me.cbAdmin.TabIndex = 30
        Me.cbAdmin.Text = "Admin"
        Me.cbAdmin.UseVisualStyleBackColor = True
        '
        'tbEmployeeNumber
        '
        Me.tbEmployeeNumber.BackColor = System.Drawing.Color.GhostWhite
        Me.tbEmployeeNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbEmployeeNumber.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbEmployeeNumber.Location = New System.Drawing.Point(96, 39)
        Me.tbEmployeeNumber.MaxLength = 4
        Me.tbEmployeeNumber.Name = "tbEmployeeNumber"
        Me.tbEmployeeNumber.Size = New System.Drawing.Size(71, 23)
        Me.tbEmployeeNumber.TabIndex = 23
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(3, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 18)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "Employee ID:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(3, 125)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 30)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Middle Name:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbMiddleName
        '
        Me.tbMiddleName.BackColor = System.Drawing.Color.GhostWhite
        Me.tbMiddleName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbMiddleName.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbMiddleName.Location = New System.Drawing.Point(96, 128)
        Me.tbMiddleName.MaxLength = 50
        Me.tbMiddleName.Name = "tbMiddleName"
        Me.tbMiddleName.ReadOnly = True
        Me.tbMiddleName.Size = New System.Drawing.Size(209, 23)
        Me.tbMiddleName.TabIndex = 22
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(3, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 30)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Last Name :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbLastName
        '
        Me.tbLastName.BackColor = System.Drawing.Color.GhostWhite
        Me.tbLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbLastName.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbLastName.Location = New System.Drawing.Point(96, 98)
        Me.tbLastName.MaxLength = 50
        Me.tbLastName.Name = "tbLastName"
        Me.tbLastName.ReadOnly = True
        Me.tbLastName.Size = New System.Drawing.Size(209, 23)
        Me.tbLastName.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(3, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 30)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "First Name :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbFirstName
        '
        Me.tbFirstName.BackColor = System.Drawing.Color.GhostWhite
        Me.tbFirstName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbFirstName.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbFirstName.Location = New System.Drawing.Point(96, 68)
        Me.tbFirstName.MaxLength = 50
        Me.tbFirstName.Name = "tbFirstName"
        Me.tbFirstName.ReadOnly = True
        Me.tbFirstName.Size = New System.Drawing.Size(209, 23)
        Me.tbFirstName.TabIndex = 7
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(618, 448)
        Me.TabControl1.TabIndex = 46
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Panel2)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(610, 422)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Profiles"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btnSaveAPI)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.GroupBox4)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(610, 422)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "APIs"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btnSaveAPI
        '
        Me.btnSaveAPI.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveAPI.BackColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(5, Byte), Integer), CType(CType(23, Byte), Integer))
        Me.btnSaveAPI.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveAPI.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnSaveAPI.ForeColor = System.Drawing.Color.White
        Me.btnSaveAPI.Location = New System.Drawing.Point(503, 393)
        Me.btnSaveAPI.Name = "btnSaveAPI"
        Me.btnSaveAPI.Size = New System.Drawing.Size(98, 23)
        Me.btnSaveAPI.TabIndex = 45
        Me.btnSaveAPI.Text = "SAVE"
        Me.btnSaveAPI.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.btnUPSGApiTest)
        Me.GroupBox2.Controls.Add(Me.tbUPSGURL)
        Me.GroupBox2.Controls.Add(Me.tbUPSGSite)
        Me.GroupBox2.Controls.Add(Me.tbUPSGAction)
        Me.GroupBox2.Controls.Add(Me.tbUPSGToken)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(6, 266)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(301, 145)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "UPSG"
        '
        'btnUPSGApiTest
        '
        Me.btnUPSGApiTest.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnUPSGApiTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUPSGApiTest.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnUPSGApiTest.ForeColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(5, Byte), Integer), CType(CType(23, Byte), Integer))
        Me.btnUPSGApiTest.Location = New System.Drawing.Point(197, 50)
        Me.btnUPSGApiTest.Name = "btnUPSGApiTest"
        Me.btnUPSGApiTest.Size = New System.Drawing.Size(98, 23)
        Me.btnUPSGApiTest.TabIndex = 48
        Me.btnUPSGApiTest.Text = "Test"
        Me.btnUPSGApiTest.UseVisualStyleBackColor = False
        '
        'tbUPSGURL
        '
        Me.tbUPSGURL.Location = New System.Drawing.Point(54, 22)
        Me.tbUPSGURL.Name = "tbUPSGURL"
        Me.tbUPSGURL.Size = New System.Drawing.Size(241, 23)
        Me.tbUPSGURL.TabIndex = 7
        '
        'tbUPSGSite
        '
        Me.tbUPSGSite.Location = New System.Drawing.Point(54, 80)
        Me.tbUPSGSite.Name = "tbUPSGSite"
        Me.tbUPSGSite.Size = New System.Drawing.Size(134, 23)
        Me.tbUPSGSite.TabIndex = 6
        '
        'tbUPSGAction
        '
        Me.tbUPSGAction.Location = New System.Drawing.Point(54, 51)
        Me.tbUPSGAction.Name = "tbUPSGAction"
        Me.tbUPSGAction.Size = New System.Drawing.Size(134, 23)
        Me.tbUPSGAction.TabIndex = 5
        '
        'tbUPSGToken
        '
        Me.tbUPSGToken.Location = New System.Drawing.Point(54, 109)
        Me.tbUPSGToken.Name = "tbUPSGToken"
        Me.tbUPSGToken.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbUPSGToken.Size = New System.Drawing.Size(134, 23)
        Me.tbUPSGToken.TabIndex = 4
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(3, 54)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(46, 15)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "Action:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(17, 25)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(32, 15)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "URL:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(17, 83)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(32, 15)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "Site:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 112)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(43, 15)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Token:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnHRMSApiTest)
        Me.GroupBox1.Controls.Add(Me.tbHRMSToken)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.tbHRMSWhat)
        Me.GroupBox1.Controls.Add(Me.tbHRMSSearch)
        Me.GroupBox1.Controls.Add(Me.tbHRMSURL)
        Me.GroupBox1.Controls.Add(Me.tbHRMSField)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(313, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(285, 182)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "HRMS"
        '
        'btnHRMSApiTest
        '
        Me.btnHRMSApiTest.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnHRMSApiTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHRMSApiTest.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnHRMSApiTest.ForeColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(5, Byte), Integer), CType(CType(23, Byte), Integer))
        Me.btnHRMSApiTest.Location = New System.Drawing.Point(181, 58)
        Me.btnHRMSApiTest.Name = "btnHRMSApiTest"
        Me.btnHRMSApiTest.Size = New System.Drawing.Size(98, 23)
        Me.btnHRMSApiTest.TabIndex = 48
        Me.btnHRMSApiTest.Text = "Test"
        Me.btnHRMSApiTest.UseVisualStyleBackColor = False
        '
        'tbHRMSToken
        '
        Me.tbHRMSToken.Location = New System.Drawing.Point(67, 146)
        Me.tbHRMSToken.Name = "tbHRMSToken"
        Me.tbHRMSToken.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbHRMSToken.Size = New System.Drawing.Size(108, 23)
        Me.tbHRMSToken.TabIndex = 9
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(18, 149)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 15)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Token:"
        '
        'tbHRMSWhat
        '
        Me.tbHRMSWhat.Location = New System.Drawing.Point(67, 59)
        Me.tbHRMSWhat.Name = "tbHRMSWhat"
        Me.tbHRMSWhat.Size = New System.Drawing.Size(108, 23)
        Me.tbHRMSWhat.TabIndex = 13
        '
        'tbHRMSSearch
        '
        Me.tbHRMSSearch.Location = New System.Drawing.Point(67, 117)
        Me.tbHRMSSearch.Name = "tbHRMSSearch"
        Me.tbHRMSSearch.Size = New System.Drawing.Size(108, 23)
        Me.tbHRMSSearch.TabIndex = 12
        '
        'tbHRMSURL
        '
        Me.tbHRMSURL.Location = New System.Drawing.Point(67, 26)
        Me.tbHRMSURL.Name = "tbHRMSURL"
        Me.tbHRMSURL.Size = New System.Drawing.Size(212, 23)
        Me.tbHRMSURL.TabIndex = 9
        '
        'tbHRMSField
        '
        Me.tbHRMSField.Location = New System.Drawing.Point(67, 88)
        Me.tbHRMSField.Name = "tbHRMSField"
        Me.tbHRMSField.Size = New System.Drawing.Size(108, 23)
        Me.tbHRMSField.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 15)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "URL:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(17, 120)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 15)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Search:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(24, 91)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 15)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Field:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 62)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 15)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "What:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.btnFaceProfileApiTest)
        Me.GroupBox3.Controls.Add(Me.tbEmployeeURL)
        Me.GroupBox3.Controls.Add(Me.tbEmployeeSite)
        Me.GroupBox3.Controls.Add(Me.tbEmployeeTerminal)
        Me.GroupBox3.Controls.Add(Me.tbEmployeeToken)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(301, 182)
        Me.GroupBox3.TabIndex = 10
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Face Profile"
        '
        'btnFaceProfileApiTest
        '
        Me.btnFaceProfileApiTest.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnFaceProfileApiTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFaceProfileApiTest.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnFaceProfileApiTest.ForeColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(5, Byte), Integer), CType(CType(23, Byte), Integer))
        Me.btnFaceProfileApiTest.Location = New System.Drawing.Point(197, 58)
        Me.btnFaceProfileApiTest.Name = "btnFaceProfileApiTest"
        Me.btnFaceProfileApiTest.Size = New System.Drawing.Size(98, 23)
        Me.btnFaceProfileApiTest.TabIndex = 46
        Me.btnFaceProfileApiTest.Text = "Test"
        Me.btnFaceProfileApiTest.UseVisualStyleBackColor = False
        '
        'tbEmployeeURL
        '
        Me.tbEmployeeURL.Location = New System.Drawing.Point(71, 27)
        Me.tbEmployeeURL.Name = "tbEmployeeURL"
        Me.tbEmployeeURL.Size = New System.Drawing.Size(224, 23)
        Me.tbEmployeeURL.TabIndex = 7
        '
        'tbEmployeeSite
        '
        Me.tbEmployeeSite.Location = New System.Drawing.Point(71, 89)
        Me.tbEmployeeSite.Name = "tbEmployeeSite"
        Me.tbEmployeeSite.Size = New System.Drawing.Size(117, 23)
        Me.tbEmployeeSite.TabIndex = 6
        '
        'tbEmployeeTerminal
        '
        Me.tbEmployeeTerminal.Location = New System.Drawing.Point(71, 56)
        Me.tbEmployeeTerminal.Name = "tbEmployeeTerminal"
        Me.tbEmployeeTerminal.Size = New System.Drawing.Size(117, 23)
        Me.tbEmployeeTerminal.TabIndex = 5
        '
        'tbEmployeeToken
        '
        Me.tbEmployeeToken.Location = New System.Drawing.Point(71, 118)
        Me.tbEmployeeToken.Name = "tbEmployeeToken"
        Me.tbEmployeeToken.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbEmployeeToken.Size = New System.Drawing.Size(117, 23)
        Me.tbEmployeeToken.TabIndex = 4
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 59)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(58, 15)
        Me.Label15.TabIndex = 3
        Me.Label15.Text = "Terminal:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(32, 30)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(32, 15)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "URL:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(32, 92)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(32, 15)
        Me.Label17.TabIndex = 1
        Me.Label17.Text = "Site:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(26, 121)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(43, 15)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Token:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.btnAttendanceApiTest)
        Me.GroupBox4.Controls.Add(Me.tbAttendanceURL)
        Me.GroupBox4.Controls.Add(Me.Label19)
        Me.GroupBox4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(6, 194)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(592, 66)
        Me.GroupBox4.TabIndex = 10
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Attendance"
        '
        'btnAttendanceApiTest
        '
        Me.btnAttendanceApiTest.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnAttendanceApiTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAttendanceApiTest.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnAttendanceApiTest.ForeColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(5, Byte), Integer), CType(CType(23, Byte), Integer))
        Me.btnAttendanceApiTest.Location = New System.Drawing.Point(488, 25)
        Me.btnAttendanceApiTest.Name = "btnAttendanceApiTest"
        Me.btnAttendanceApiTest.Size = New System.Drawing.Size(98, 23)
        Me.btnAttendanceApiTest.TabIndex = 47
        Me.btnAttendanceApiTest.Text = "Test"
        Me.btnAttendanceApiTest.UseVisualStyleBackColor = False
        '
        'tbAttendanceURL
        '
        Me.tbAttendanceURL.Location = New System.Drawing.Point(54, 26)
        Me.tbAttendanceURL.Name = "tbAttendanceURL"
        Me.tbAttendanceURL.Size = New System.Drawing.Size(428, 23)
        Me.tbAttendanceURL.TabIndex = 9
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 34)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(28, 15)
        Me.Label19.TabIndex = 8
        Me.Label19.Text = "URL"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.btnOpenBiometricClientSettings)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(610, 422)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "General"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btnOpenBiometricClientSettings
        '
        Me.btnOpenBiometricClientSettings.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpenBiometricClientSettings.Location = New System.Drawing.Point(6, 6)
        Me.btnOpenBiometricClientSettings.Name = "btnOpenBiometricClientSettings"
        Me.btnOpenBiometricClientSettings.Size = New System.Drawing.Size(190, 23)
        Me.btnOpenBiometricClientSettings.TabIndex = 46
        Me.btnOpenBiometricClientSettings.Text = "Open Biometric Client Settings"
        Me.btnOpenBiometricClientSettings.UseVisualStyleBackColor = True
        '
        'frmAdministrator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(642, 472)
        Me.Controls.Add(Me.TabControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmAdministrator"
        Me.Text = "Administrator"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbFirstName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbLastName As System.Windows.Forms.TextBox
    Friend WithEvents tbEmployeeNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbMiddleName As System.Windows.Forms.TextBox
    Friend WithEvents cbAdmin As System.Windows.Forms.CheckBox
    Friend WithEvents btnSaveProfile As System.Windows.Forms.Button
    Friend WithEvents lbMessage2 As System.Windows.Forms.Label
    Friend WithEvents btnRegFace As System.Windows.Forms.Button
    Friend WithEvents cbActive As System.Windows.Forms.CheckBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents tbUPSGURL As System.Windows.Forms.TextBox
    Friend WithEvents tbUPSGSite As System.Windows.Forms.TextBox
    Friend WithEvents tbUPSGAction As System.Windows.Forms.TextBox
    Friend WithEvents tbUPSGToken As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tbHRMSToken As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tbHRMSWhat As System.Windows.Forms.TextBox
    Friend WithEvents tbHRMSSearch As System.Windows.Forms.TextBox
    Friend WithEvents tbHRMSURL As System.Windows.Forms.TextBox
    Friend WithEvents tbHRMSField As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents tbEmployeeURL As System.Windows.Forms.TextBox
    Friend WithEvents tbEmployeeSite As System.Windows.Forms.TextBox
    Friend WithEvents tbEmployeeTerminal As System.Windows.Forms.TextBox
    Friend WithEvents tbEmployeeToken As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents tbAttendanceURL As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents btnOpenBiometricClientSettings As System.Windows.Forms.Button
    Friend WithEvents btnSaveAPI As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents tbJobcode As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnUPSGApiTest As System.Windows.Forms.Button
    Friend WithEvents btnHRMSApiTest As System.Windows.Forms.Button
    Friend WithEvents btnFaceProfileApiTest As System.Windows.Forms.Button
    Friend WithEvents btnAttendanceApiTest As System.Windows.Forms.Button
End Class
