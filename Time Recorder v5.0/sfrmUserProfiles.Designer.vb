<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class sfrmUserProfiles
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(sfrmUserProfiles))
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.clEmpNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clFname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clLName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clMName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clActive = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.clAdmin = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.cbSearchActive = New System.Windows.Forms.CheckBox()
        Me.cbSearchAdmin = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tbSearch = New System.Windows.Forms.TextBox()
        Me.cbSearchOption = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
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
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btnOpenBiometricClientSettings = New System.Windows.Forms.Button()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnSaveAPI = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.tbUPSGURL = New System.Windows.Forms.TextBox()
        Me.tbUPSGSite = New System.Windows.Forms.TextBox()
        Me.tbUPSGAction = New System.Windows.Forms.TextBox()
        Me.tbUPSGToken = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
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
        Me.tbEmployeeURL = New System.Windows.Forms.TextBox()
        Me.tbEmployeeSite = New System.Windows.Forms.TextBox()
        Me.tbEmployeeTerminal = New System.Windows.Forms.TextBox()
        Me.tbEmployeeToken = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.tbAttendanceURL = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToResizeRows = False
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clEmpNo, Me.clFname, Me.clLName, Me.clMName, Me.clActive, Me.clAdmin})
        Me.dgv.EnableHeadersVisualStyles = False
        Me.dgv.Location = New System.Drawing.Point(326, 40)
        Me.dgv.MultiSelect = False
        Me.dgv.Name = "dgv"
        Me.dgv.RowHeadersVisible = False
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(115, Byte), Integer), CType(CType(5, Byte), Integer), CType(CType(23, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.AliceBlue
        Me.dgv.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(664, 469)
        Me.dgv.TabIndex = 1
        '
        'clEmpNo
        '
        Me.clEmpNo.FillWeight = 102.6831!
        Me.clEmpNo.HeaderText = "Emp No."
        Me.clEmpNo.Name = "clEmpNo"
        Me.clEmpNo.ReadOnly = True
        Me.clEmpNo.Width = 85
        '
        'clFname
        '
        Me.clFname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.clFname.FillWeight = 102.6831!
        Me.clFname.HeaderText = "Firstname"
        Me.clFname.Name = "clFname"
        Me.clFname.ReadOnly = True
        '
        'clLName
        '
        Me.clLName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.clLName.FillWeight = 102.6831!
        Me.clLName.HeaderText = "Lastname"
        Me.clLName.Name = "clLName"
        Me.clLName.ReadOnly = True
        '
        'clMName
        '
        Me.clMName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.clMName.FillWeight = 102.6831!
        Me.clMName.HeaderText = "MI"
        Me.clMName.Name = "clMName"
        Me.clMName.ReadOnly = True
        Me.clMName.Width = 35
        '
        'clActive
        '
        Me.clActive.HeaderText = "Active"
        Me.clActive.Name = "clActive"
        Me.clActive.ReadOnly = True
        Me.clActive.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.clActive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'clAdmin
        '
        Me.clAdmin.FillWeight = 81.21828!
        Me.clAdmin.HeaderText = "Admin"
        Me.clAdmin.Name = "clAdmin"
        Me.clAdmin.ReadOnly = True
        Me.clAdmin.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.clAdmin.Width = 60
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.cbSearchActive)
        Me.Panel1.Controls.Add(Me.cbSearchAdmin)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.tbSearch)
        Me.Panel1.Controls.Add(Me.cbSearchOption)
        Me.Panel1.Location = New System.Drawing.Point(326, 8)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(664, 28)
        Me.Panel1.TabIndex = 2
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(584, 5)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 36
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'cbSearchActive
        '
        Me.cbSearchActive.AutoSize = True
        Me.cbSearchActive.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSearchActive.Location = New System.Drawing.Point(507, 7)
        Me.cbSearchActive.Name = "cbSearchActive"
        Me.cbSearchActive.Size = New System.Drawing.Size(60, 19)
        Me.cbSearchActive.TabIndex = 36
        Me.cbSearchActive.Text = "Active"
        Me.cbSearchActive.UseVisualStyleBackColor = True
        '
        'cbSearchAdmin
        '
        Me.cbSearchAdmin.AutoSize = True
        Me.cbSearchAdmin.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSearchAdmin.Location = New System.Drawing.Point(439, 7)
        Me.cbSearchAdmin.Name = "cbSearchAdmin"
        Me.cbSearchAdmin.Size = New System.Drawing.Size(62, 19)
        Me.cbSearchAdmin.TabIndex = 37
        Me.cbSearchAdmin.Text = "Admin"
        Me.cbSearchAdmin.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(117, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 15)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Search :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbSearch
        '
        Me.tbSearch.BackColor = System.Drawing.Color.GhostWhite
        Me.tbSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbSearch.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSearch.Location = New System.Drawing.Point(311, 5)
        Me.tbSearch.MaxLength = 1000
        Me.tbSearch.Name = "tbSearch"
        Me.tbSearch.Size = New System.Drawing.Size(122, 23)
        Me.tbSearch.TabIndex = 10
        '
        'cbSearchOption
        '
        Me.cbSearchOption.BackColor = System.Drawing.Color.DimGray
        Me.cbSearchOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSearchOption.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbSearchOption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSearchOption.ForeColor = System.Drawing.Color.White
        Me.cbSearchOption.FormattingEnabled = True
        Me.cbSearchOption.Items.AddRange(New Object() {"Employee Number", "Firstname", "Lastname", "Middle Initial", "Company", "Department"})
        Me.cbSearchOption.Location = New System.Drawing.Point(169, 5)
        Me.cbSearchOption.Name = "cbSearchOption"
        Me.cbSearchOption.Size = New System.Drawing.Size(136, 23)
        Me.cbSearchOption.TabIndex = 9
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
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
        Me.Panel2.Size = New System.Drawing.Size(317, 506)
        Me.Panel2.TabIndex = 3
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
        Me.lbMessage2.Location = New System.Drawing.Point(12, 155)
        Me.lbMessage2.Name = "lbMessage2"
        Me.lbMessage2.Size = New System.Drawing.Size(170, 42)
        Me.lbMessage2.TabIndex = 39
        Me.lbMessage2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnRegFace
        '
        Me.btnRegFace.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRegFace.Location = New System.Drawing.Point(188, 157)
        Me.btnRegFace.Name = "btnRegFace"
        Me.btnRegFace.Size = New System.Drawing.Size(115, 39)
        Me.btnRegFace.TabIndex = 38
        Me.btnRegFace.Text = "Register Face Image"
        Me.btnRegFace.UseVisualStyleBackColor = True
        '
        'btnSaveProfile
        '
        Me.btnSaveProfile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveProfile.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveProfile.Location = New System.Drawing.Point(160, 461)
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
        Me.tbFirstName.Size = New System.Drawing.Size(209, 23)
        Me.tbFirstName.TabIndex = 7
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1001, 538)
        Me.TabControl1.TabIndex = 46
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.btnOpenBiometricClientSettings)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(993, 512)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "General"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btnOpenBiometricClientSettings
        '
        Me.btnOpenBiometricClientSettings.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnOpenBiometricClientSettings.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpenBiometricClientSettings.Location = New System.Drawing.Point(6, 6)
        Me.btnOpenBiometricClientSettings.Name = "btnOpenBiometricClientSettings"
        Me.btnOpenBiometricClientSettings.Size = New System.Drawing.Size(190, 23)
        Me.btnOpenBiometricClientSettings.TabIndex = 46
        Me.btnOpenBiometricClientSettings.Text = "Open Biometric Client Settings"
        Me.btnOpenBiometricClientSettings.UseVisualStyleBackColor = True
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
        Me.TabPage1.Size = New System.Drawing.Size(993, 512)
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
        Me.btnSaveAPI.Location = New System.Drawing.Point(886, 483)
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
        Me.GroupBox2.Size = New System.Drawing.Size(978, 109)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "UPSG"
        '
        'tbUPSGURL
        '
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
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(6, 202)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(978, 146)
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 19)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "URL"
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
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 67)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 19)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "What"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.tbEmployeeURL)
        Me.GroupBox3.Controls.Add(Me.tbEmployeeSite)
        Me.GroupBox3.Controls.Add(Me.tbEmployeeTerminal)
        Me.GroupBox3.Controls.Add(Me.tbEmployeeToken)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(978, 109)
        Me.GroupBox3.TabIndex = 10
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Employee"
        '
        'tbEmployeeURL
        '
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
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(321, 36)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(68, 19)
        Me.Label15.TabIndex = 3
        Me.Label15.Text = "Terminal"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 73)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(35, 19)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "URL"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 36)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(35, 19)
        Me.Label17.TabIndex = 1
        Me.Label17.Text = "Site"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(138, 36)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(50, 19)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Token"
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.tbAttendanceURL)
        Me.GroupBox4.Controls.Add(Me.Label19)
        Me.GroupBox4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(6, 130)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(978, 66)
        Me.GroupBox4.TabIndex = 10
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Attendance"
        '
        'tbAttendanceURL
        '
        Me.tbAttendanceURL.Location = New System.Drawing.Point(54, 26)
        Me.tbAttendanceURL.Name = "tbAttendanceURL"
        Me.tbAttendanceURL.Size = New System.Drawing.Size(465, 27)
        Me.tbAttendanceURL.TabIndex = 9
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 34)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(35, 19)
        Me.Label19.TabIndex = 8
        Me.Label19.Text = "URL"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.dgv)
        Me.TabPage3.Controls.Add(Me.Panel2)
        Me.TabPage3.Controls.Add(Me.Panel1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(993, 512)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Profiles"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'sfrmUserProfiles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(1025, 562)
        Me.Controls.Add(Me.TabControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "sfrmUserProfiles"
        Me.Text = "UserProfiles"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tbSearch As System.Windows.Forms.TextBox
    Friend WithEvents cbSearchOption As System.Windows.Forms.ComboBox
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
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnSaveProfile As System.Windows.Forms.Button
    Friend WithEvents cbSearchActive As System.Windows.Forms.CheckBox
    Friend WithEvents cbSearchAdmin As System.Windows.Forms.CheckBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents lbMessage2 As System.Windows.Forms.Label
    Friend WithEvents btnRegFace As System.Windows.Forms.Button
    Friend WithEvents cbActive As System.Windows.Forms.CheckBox
    Friend WithEvents clEmpNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clFname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clLName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clMName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clActive As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents clAdmin As System.Windows.Forms.DataGridViewCheckBoxColumn
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
End Class
