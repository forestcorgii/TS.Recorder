Imports System.Windows.Forms
Imports Newtonsoft.Json
Imports time_recorder_service
Imports utility_service
Public Class frmAdministrator
    Public Employees As New List(Of Model.Employee)
    Private SelectedEmployee As New Model.Employee
    Public FaceManager As face_recognition_service.Manager.FaceRecognition

    Private Function CheckFaceProfile(_user As Model.FaceProfile) As Boolean
        Dim value As Boolean = _user.face_data1 IsNot Nothing
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
    End Sub


    Private Sub btnRegFace_Click(sender As Object, e As EventArgs) Handles btnRegFace.Click
        If CheckFaceProfile(SelectedEmployee.FaceProfile) Then
            If MsgBox("Re-scan? Previous data will be overwritten.", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Else : Exit Sub
            End If
        End If

        face_recognition_service.Controller.FaceProfile.EditFaceTemplate(FaceRecognitionManager, SelectedEmployee.FaceProfile)
        CheckFaceProfile(SelectedEmployee.FaceProfile)
    End Sub


    Private Sub btnSaveProfile_Click(sender As Object, e As EventArgs) Handles btnSaveProfile.Click
        Dim changes As New List(Of String)
        With SelectedEmployee
            .EE_Id = tbEmployeeNumber.Text

            .FaceProfile.EE_Id = tbEmployeeNumber.Text
            .FaceProfile.Admin = cbAdmin.Checked
            .FaceProfile.Active = cbActive.Checked

            .FaceProfile.Owner = FaceProfileAPIManager.Terminal

            DatabaseManager.Connection.Open()
            Controller.Employee.Save(DatabaseManager, SelectedEmployee)
            Controller.FaceProfile.Save(DatabaseManager, SelectedEmployee.FaceProfile)
            DatabaseManager.Connection.Close()
        End With

        MsgBox("All Changes Has been Saved.")
    End Sub

    Private Async Sub tbEmployeeNumber_TextChanged(sender As Object, e As EventArgs) Handles tbEmployeeNumber.TextChanged
        If tbEmployeeNumber.TextLength >= 4 And Not DatabaseManager.Connection.State = ConnectionState.Open Then
            DatabaseManager.Connection.Open()
            Dim employeeFound As Model.Employee = Await Controller.Employee.FindAsync(DatabaseManager, tbEmployeeNumber.Text, shouldCompleteDetail:=True, hrmsAPIManager:=HRMSAPIManager)

            With SelectedEmployee
                .EE_Id = tbEmployeeNumber.Text

                If employeeFound IsNot Nothing Then
                    .Job_Code = employeeFound.Job_Code
                    .First_Name = employeeFound.First_Name
                    .Last_Name = employeeFound.Last_Name
                    .Middle_Name = employeeFound.Middle_Name

                    tbJobcode.Text = .Job_Code
                    tbFirstName.Text = .First_Name
                    tbLastName.Text = .Last_Name
                    tbMiddleName.Text = .Middle_Name
                Else
                    MessageBox.Show("Please Fill out manually the Names.", "Employee not Found in HRMS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                .FaceProfile = Controller.FaceProfile.Find(DatabaseManager, .EE_Id)
                If .FaceProfile IsNot Nothing Then
                    cbAdmin.Checked = .FaceProfile.Admin
                    cbActive.Checked = .FaceProfile.Active
                Else
                    .FaceProfile = New time_recorder_service.Model.FaceProfile
                    .FaceProfile.EE_Id = tbEmployeeNumber.Text

                    cbAdmin.Checked = False
                    cbActive.Checked = True
                End If

            End With
            DatabaseManager.Connection.Close()
            CheckFaceProfile(SelectedEmployee.FaceProfile)
        Else
            tbJobcode.Text = ""
            tbFirstName.Text = ""
            tbLastName.Text = ""
            tbMiddleName.Text = ""
            cbAdmin.Checked = False
            cbActive.Checked = False
        End If
    End Sub



    Private Sub LoadAPISettings()
        If AttendanceAPIManager IsNot Nothing Then
            tbAttendanceURL.Text = AttendanceAPIManager.ApiUrl
        Else : AttendanceAPIManager = New Manager.API.Attendance
        End If

        If FaceProfileAPIManager IsNot Nothing Then
            tbEmployeeSite.Text = FaceProfileAPIManager.Site
            tbEmployeeTerminal.Text = FaceProfileAPIManager.Terminal
            tbEmployeeURL.Text = FaceProfileAPIManager.Url
            tbEmployeeToken.Text = FaceProfileAPIManager.ApiToken
        Else : FaceProfileAPIManager = New face_recognition_service.Manager.API.FaceProfile
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

        If FaceRecognitionManager Is Nothing Then
            FaceRecognitionManager = New face_recognition_service.Manager.FaceRecognition
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

            FaceProfileAPIManager.Site = tbEmployeeSite.Text
            FaceProfileAPIManager.Terminal = tbEmployeeTerminal.Text
            FaceProfileAPIManager.Url = tbEmployeeURL.Text
            FaceProfileAPIManager.ApiToken = tbEmployeeToken.Text
            settings = New Model.Settings() With {
                .Name = "FaceRecognitionAPIManager",
                .JSON_Arguments = JsonConvert.SerializeObject(FaceProfileAPIManager)
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
        Using _verilookSettings As New face_recognition_service.dlgSettings(FaceRecognitionManager.Settings)
            If _verilookSettings.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                FaceRecognitionManager.Settings = _verilookSettings.Settings

                Dim settings As New Model.Settings() With {
                    .Name = "VerilookManager.Settings",
                    .JSON_Arguments = JsonConvert.SerializeObject(FaceRecognitionManager.Settings)
                }
                Controller.Settings.SaveSettings(DatabaseManager, settings)

            End If
        End Using
    End Sub

End Class