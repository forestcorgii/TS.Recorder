
Imports Newtonsoft.Json
Imports time_recorder_service

Public Class sfrmSettings

    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            tbHRMSToken.Text = HRMSAPIManager.Apitoken
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
            VerilookManager = New VerilookLib2.Manager.Verilook
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If MsgBox("Are You sure you want to save?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

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
            HRMSAPIManager.Apitoken = tbHRMSToken.Text
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

            settings = New Model.Settings() With {
                .Name = "VerilookManager.Settings",
                .JSON_Arguments = JsonConvert.SerializeObject(VerilookManager.Settings)
            }
            Controller.Settings.SaveSettings(DatabaseManager, settings)

            DialogResult = System.Windows.Forms.DialogResult.OK
            Close()
        End If
    End Sub

    Private Sub btnOpenBiometricClientSettings_Click(sender As Object, e As EventArgs) Handles btnOpenBiometricClientSettings.Click
        'VerilookManager.SetBiometricClientParams()
        Using _verilookSettings As New VerilookLib2.dlgSettings(VerilookManager.Settings)
            If _verilookSettings.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                VerilookManager.Settings = _verilookSettings.Settings
            End If
        End Using
    End Sub
End Class