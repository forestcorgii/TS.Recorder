Imports hrms_api_service
Imports Newtonsoft.Json
Imports utility_service
Imports time_recorder_service
Imports System.ComponentModel

Public Class frmMain

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        SetupConfiguration()

        bgwSync.RunWorkerAsync()

    End Sub

    Private Sub SetupConfiguration()
        DatabaseConfiguration = New Configuration.Mysql()
        DatabaseConfiguration.Setup("TIME_RECORDER_DB_URL_2")

        DatabaseManager = New Manager.Mysql(DatabaseConfiguration)
        DatabaseManager.Connection.Open()
        SetupManager()
        DatabaseManager.Connection.Close()
    End Sub
    Private Function SetupManager()

        Dim settings As Model.Settings = Controller.Settings.GetSettings(DatabaseManager, "HRMSAPIManager")
        If settings IsNot Nothing Then
            HRMSAPIManager = JsonConvert.DeserializeObject(Of Manager.API.HRMS)(settings.JSON_Arguments)
        End If

        Return True
    End Function


    Private Async Sub bgwSync_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwSync.DoWork
        Try
            DatabaseManager.Connection.Open()
            Dim employees As List(Of Model.FaceProfile) = Controller.FaceProfile.Collect(DatabaseManager)

            Invoke(Sub()
                       pb.Maximum = employees.Count
                       pb.Value = 0
                   End Sub)

            For i As Integer = 0 To employees.Count - 1
                Dim employee As Model.FaceProfile = employees(i)
                Try
                    Dim employeeFound As IInterface.IEmployee = Await HRMSAPIManager.GetEmployeeFromServer(employee.EE_Id)
                    If employeeFound IsNot Nothing Then
                        Controller.Employee.Save(DatabaseManager, New Model.Employee(employeeFound))
                    End If

                    Invoke(Sub()
                               pb.Value += 1
                               lbStatus.Text = String.Format("Updating {1} of {2}... Employee ID: {0}", employee.EE_Id, i + 1, employees.Count)
                           End Sub)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Console.WriteLine(ex.Message)
                End Try
            Next

            DatabaseManager.Connection.Close()
            'MessageBox.Show("Done", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Invoke(Sub() Close())
        Catch ex As Exception
            DatabaseManager.Connection.Close()
            MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bgwSync_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgwSync.RunWorkerCompleted
    End Sub
End Class
