Imports Newtonsoft.Json
Imports time_recorder_service
Imports verilook_service
Imports utility_service
Public Class frmUserProfiles
    Public Employees As New List(Of Model.Employee)
    Private SelectedEmployee As New Model.Employee
    Public FaceManager As verilook_service.Manager.Verilook

    Private Function CheckFaceProfile(_user As Model.Employee) As Boolean
        Dim value As Boolean = Not (_user.FaceImage_1 Is Nothing Or _user.FaceImage_2 Is Nothing Or _user.FaceImage_3 Is Nothing)
        If value Then
            lbMessage2.ForeColor = Color.MidnightBlue
            lbMessage2.Text = "Your Face has been registered."
        Else
            lbMessage2.ForeColor = Color.Maroon
            lbMessage2.Text = "Your Face is not yet registered."
        End If
        Return value
    End Function

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub sfrmUserProfiles_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadAPISettings()

        LoadEmployeesToDGV()
        cbSearchOption.SelectedIndex = 0
    End Sub

    Public Sub LoadEmployeesToDGV()
        dgv.Rows.Clear()
        DatabaseManager.Connection.Open()
        Employees = Controller.Employee.CollectEmployees(DatabaseManager)
        For Each employee As Model.Employee In Employees
            With employee
                dgv.Rows.Add(employee, .first_name, .last_name, .MI, .Active, .admin)
            End With
        Next
        DatabaseManager.Connection.Close()
    End Sub

    Private Sub dgv_CurrentCellChanged(sender As Object, e As EventArgs) Handles dgv.CurrentCellChanged
        If Not dgv.Rows.Count = 0 And dgv.CurrentRow IsNot Nothing Then
            SelectedEmployee = dgv.CurrentRow.Cells(0).Value
            With SelectedEmployee
                tbEmployeeNumber.Text = .Employee_Id
                tbFirstName.Text = .first_name
                tbLastName.Text = .last_name
                tbMiddleName.Text = .middle_name
                cbAdmin.Checked = .admin
                cbActive.Checked = .Active

                cbActive.Enabled = (.NoFaceImage = False)
            End With
            checkFaceProfile(SelectedEmployee)
        End If
    End Sub


    Private Sub btnRegFace_Click(sender As Object, e As EventArgs) Handles btnRegFace.Click
        If checkFaceProfile(SelectedEmployee) Then
            If MsgBox("Re-scan? Previous data will be overwritten.", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Else : Exit Sub
            End If
        End If

        Controller.Verilook.EditFaceTemplate(VerilookManager, SelectedEmployee)
        checkFaceProfile(SelectedEmployee)
    End Sub


    Private Sub btnSaveProfile_Click(sender As Object, e As EventArgs) Handles btnSaveProfile.Click
        Dim changes As New List(Of String)
        With SelectedEmployee
            .Employee_Id = tbEmployeeNumber.Text
            .admin = cbAdmin.Checked
            .Active = cbActive.Checked

            .owner = EmployeeAPIManager.Terminal

            Controller.Employee.SaveEmployee(DatabaseManager, SelectedEmployee)
        End With


        With dgv.CurrentRow
            .Cells(0).Value = SelectedEmployee.Employee_Id
            .Cells(1).Value = SelectedEmployee.first_name
            .Cells(2).Value = SelectedEmployee.last_name
            .Cells(3).Value = SelectedEmployee.middle_name
            .Cells(8).Value = SelectedEmployee.Active
            .Cells(9).Value = SelectedEmployee.admin
        End With

        MsgBox("All Changes Has been Saved.")
    End Sub

    Private Async Sub tbEmployeeNumber_TextChanged(sender As Object, e As EventArgs) Handles tbEmployeeNumber.TextChanged
        If tbEmployeeNumber.TextLength >= 3 Then
            Dim employeeFound As hrms_api_service.IInterface.IEmployee = Await HRMSAPIManager.GetEmployeeFromServer(tbEmployeeNumber.Text)
            If employeeFound IsNot Nothing Then
                With SelectedEmployee
                    .Employee_Id = tbEmployeeNumber.Text
                    .jobcode = employeeFound.jobcode
                    .first_name = employeeFound.first_name
                    .last_name = employeeFound.last_name
                    .middle_name = employeeFound.middle_name
                    .admin = False
                    .Active = True

                    tbJobcode.Text = .jobcode
                    tbFirstName.Text = .first_name
                    tbLastName.Text = .last_name
                    tbMiddleName.Text = .middle_name
                    cbAdmin.Checked = .admin
                    cbActive.Checked = .Active
                End With
            End If
        Else
            tbJobcode.Text = ""
            tbFirstName.Text = ""
            tbLastName.Text = ""
            tbMiddleName.Text = ""
            cbAdmin.Checked = False
            cbActive.Checked = False
        End If
    End Sub

    'Private Sub tbSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles tbSearch.KeyDown
    '    If e.KeyCode = Keys.Enter Then
    '        btnSearch.PerformClick()
    '    End If
    'End Sub

    Private Sub cbSearchAdmin_CheckedChanged(sender As Object, e As EventArgs) Handles cbSearchAdmin.CheckedChanged, cbSearchActive.CheckedChanged
        'NOTE: Create Controller.Employee.FilterEmployees
        'readUserDB(Employees)
    End Sub


    'Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
    '    filteredUserDB = New EmployeeRecordCollection
    '    Select Case cbSearchOption.Text.ToUpper
    '        Case "EMPLOYEE NUMBER"
    '            filteredUserDB.AddRange(
    '                (From res In employees Where res.Employee_Id.ToUpper = tbSearch.Text And res.admin = cbSearchAdmin.Checked And res.Active = cbSearchActive.Checked).ToList)
    '        Case "COMPANY"
    '            filteredUserDB.AddRange(
    '                (From res In employees Where res.company.ToUpper = tbSearch.Text And res.admin = cbSearchAdmin.Checked And res.Active = cbSearchActive.Checked).ToList)
    '        Case "DEPARTMENT"
    '            filteredUserDB.AddRange(
    '                (From res In employees Where res.department.ToUpper = tbSearch.Text And res.admin = cbSearchAdmin.Checked And res.Active = cbSearchActive.Checked).ToList)
    '        Case "FIRSTNAME"
    '            filteredUserDB.AddRange(
    '                (From res In employees Where res.first_name.ToUpper = tbSearch.Text And res.admin = cbSearchAdmin.Checked And res.Active = cbSearchActive.Checked).ToList)
    '        Case "LASTNAME"
    '            filteredUserDB.AddRange(
    '                (From res In employees Where res.last_name.ToUpper = tbSearch.Text And res.admin = cbSearchAdmin.Checked And res.Active = cbSearchActive.Checked).ToList)
    '        Case "MIDDLE INITIAL"
    '            filteredUserDB.AddRange(
    '                (From res In employees Where res.MI.ToUpper = tbSearch.Text And res.admin = cbSearchAdmin.Checked And res.Active = cbSearchActive.Checked).ToList)
    '        Case Else
    '            Exit Sub
    '    End Select
    '    readUserDB(filteredUserDB)
    'End Sub


    Private Sub LoadAPISettings()
        If AttendanceAPIManager IsNot Nothing Then
            tbAttendanceURL.Text = AttendanceAPIManager.ApiUrl
        Else : AttendanceAPIManager = New Manager.API.Attendance
        End If

        If EmployeeAPIManager IsNot Nothing Then
            tbEmployeeSite.Text = EmployeeAPIManager.Site
            tbEmployeeTerminal.Text = EmployeeAPIManager.Terminal
            tbEmployeeURL.Text = EmployeeAPIManager.Url
            tbEmployeeToken.Text = EmployeeAPIManager.ApiToken
        Else : EmployeeAPIManager = New Manager.API.Employee
        End If

        If HRMSAPIManager IsNot Nothing Then
            tbHRMSURL.Text = HRMSAPIManager.Url
            tbHRMSToken.Text = HRMSAPIManager.APIToken
            tbHRMSWhat.Text = HRMSAPIManager.What
            tbHRMSSearch.Text = HRMSAPIManager.Search
            tbHRMSField.Text = HRMSAPIManager.Field
        Else : HRMSAPIManager = New hrms_api_service.Manager.API.HRMS
        End If

        If UPSGAPIManager IsNot Nothing Then
            tbUPSGAction.Text = UPSGAPIManager.action
            tbUPSGToken.Text = UPSGAPIManager.token
            tbUPSGSite.Text = UPSGAPIManager.site
            tbUPSGURL.Text = UPSGAPIManager.APIUrl

        Else : UPSGAPIManager = New upsg_api_service.Manager.API.UPSG
        End If

        If VerilookManager Is Nothing Then
            VerilookManager = New verilook_service.Manager.Verilook
        End If
    End Sub

    Private Sub btnSaveAPI_Click(sender As Object, e As EventArgs) Handles btnSaveAPI.Click
        If MsgBox("Are You sure you want to save?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            DatabaseManager.Connection.Open()
            AttendanceAPIManager.ApiUrl = tbAttendanceURL.Text
            Dim settings As New Model.Settings() With {
                .Name = "AttendanceAPIManager",
                .JSON_Arguments = JsonConvert.SerializeObject(AttendanceAPIManager)
            }
            Controller.Settings.SaveSettings(DatabaseManager, settings)

            EmployeeAPIManager.Site = tbEmployeeSite.Text
            EmployeeAPIManager.Terminal = tbEmployeeTerminal.Text
            EmployeeAPIManager.Url = tbEmployeeURL.Text
            EmployeeAPIManager.ApiToken = tbEmployeeToken.Text
            settings = New Model.Settings() With {
                .Name = "EmployeeAPIManager",
                .JSON_Arguments = JsonConvert.SerializeObject(EmployeeAPIManager)
            }
            Controller.Settings.SaveSettings(DatabaseManager, settings)

            HRMSAPIManager.Url = tbHRMSURL.Text
            HRMSAPIManager.APIToken = tbHRMSToken.Text
            HRMSAPIManager.What = tbHRMSWhat.Text
            HRMSAPIManager.Search = tbHRMSSearch.Text
            HRMSAPIManager.Field = tbHRMSField.Text
            settings = New Model.Settings() With {
                .Name = "HRMSAPIManager",
                .JSON_Arguments = JsonConvert.SerializeObject(HRMSAPIManager)
            }
            Controller.Settings.SaveSettings(DatabaseManager, settings)

            UPSGAPIManager.action = tbUPSGAction.Text
            UPSGAPIManager.token = tbUPSGToken.Text
            UPSGAPIManager.site = tbUPSGSite.Text
            UPSGAPIManager.APIUrl = tbUPSGURL.Text
            settings = New Model.Settings() With {
                .Name = "UPSGAPIManager",
                .JSON_Arguments = JsonConvert.SerializeObject(UPSGAPIManager)
            }
            Controller.Settings.SaveSettings(DatabaseManager, settings)
            DatabaseManager.Connection.Close()
        End If
    End Sub

    Private Sub btnOpenBiometricClientSettings_Click(sender As Object, e As EventArgs) Handles btnOpenBiometricClientSettings.Click
        'VerilookManager.SetBiometricClientParams()
        Using _verilookSettings As New verilook_service.dlgSettings(VerilookManager.Settings)
            If _verilookSettings.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                VerilookManager.Settings = _verilookSettings.Settings

                Dim settings As New Model.Settings() With {
                    .Name = "VerilookManager.Settings",
                    .JSON_Arguments = JsonConvert.SerializeObject(VerilookManager.Settings)
                }
                Controller.Settings.SaveSettings(DatabaseManager, settings)

            End If
        End Using
    End Sub

End Class