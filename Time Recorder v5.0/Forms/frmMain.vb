Imports System.ComponentModel
Imports System.IO
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports Newtonsoft.Json
Imports time_recorder_service
Imports utility_service
Imports VerilookLib2

Public Class frmMain
    Public AuthButton As Object

    Public FaceManager As Manager.Verilook

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        SetupConfiguration()
        SetupDGV(dgv)

        tmUserSync.Interval = TimeSpan.FromHours(1).TotalMilliseconds
        tmTimelogSync.Interval = TimeSpan.FromHours(1).TotalMilliseconds
        tmSendTimelog.Interval = TimeSpan.FromMinutes(3).TotalMilliseconds

        tmSendTimelog.Enabled = True
        tmRefreshStream.Enabled = True
        tmTimelogSync.Enabled = True
        tmUserSync.Enabled = True

        tmTimelogSync_Tick(Nothing, Nothing)

        tmRefreshStream.Enabled = False
        tmSendTimelog_Tick(Nothing, Nothing)

        changeStatus("Employee Detail Syncing, Wait for the Camera to Open.", Color.Firebrick)

        Me.Text = Application.ProductName & " v" & Application.ProductVersion
        lbCompany.Text = Environment.GetEnvironmentVariable("TIME_RECORDER_COMPANY")
    End Sub

#Region "Setup"

    Private Sub SetupConfiguration()
        DatabaseConfiguration = New Configuration.Mysql()
        DatabaseConfiguration.Setup("TIME_RECORDER_DB_URL")

        DatabaseManager = New Manager.Mysql(DatabaseConfiguration)
        DatabaseManager.Connection.Open()
        SetupManager()
        DatabaseManager.Connection.Close()
    End Sub
    Private Function SetupManager()
        Dim valid As Boolean = True

        Dim settings As Model.Settings = Controller.Settings.GetSettings(DatabaseManager, "AttendanceAPIManager")
        If settings IsNot Nothing Then
            AttendanceAPIManager = JsonConvert.DeserializeObject(Of Manager.API.Attendance)(settings.JSON_Arguments)
        Else : valid = False
        End If

        settings = Controller.Settings.GetSettings(DatabaseManager, "EmployeeAPIManager")
        If settings IsNot Nothing Then
            EmployeeAPIManager = JsonConvert.DeserializeObject(Of Manager.API.Employee)(settings.JSON_Arguments)
        Else : valid = False
        End If

        settings = Controller.Settings.GetSettings(DatabaseManager, "HRMSAPIManager")
        If settings IsNot Nothing Then
            HRMSAPIManager = JsonConvert.DeserializeObject(Of hrms_api_service.Manager.API.HRMS)(settings.JSON_Arguments)
        Else : valid = False
        End If

        settings = Controller.Settings.GetSettings(DatabaseManager, "VerilookManager.Settings")
        If settings IsNot Nothing Then
            VerilookManager = New Manager.Verilook
            VerilookManager.Settings = JsonConvert.DeserializeObject(Of Configuration.Face)(settings.JSON_Arguments)
            VerilookManager.Setup()
        Else : valid = False
        End If

        If Not valid Then
            If sfrmSettings.ShowDialog = DialogResult.OK Then
                SetupManager()
            Else Return False
            End If
        End If
        Return True
    End Function



    Private Sub SetupDGV(dgv As DataGridView)
        dgv.Rows.Clear()
        DatabaseManager.Connection.Open()
        Dim attendances As List(Of Model.Attendance) = Controller.Attendance.GetAttendances(DatabaseManager, limit:=100)
        DatabaseManager.Connection.Close()

        For Each attendance As Model.Attendance In attendances
            Dim dgvr As New DataGridViewRow
            dgvr.CreateCells(dgv)
            With dgvr
                .Cells(0).Value = attendance.Name
                .Cells(3).Value = attendance.LogDate.ToString("yyyy-MM-dd")
                .Cells(4).Value = attendance.TimeStamp.ToString("hh:mm tt")
            End With
            dgv.Rows.Add(dgvr)
        Next

        dgv.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgv.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        If Not dgv.Rows.Count = 0 Then dgv.CurrentCell = dgv.Item(0, 0)
        Application.DoEvents()
    End Sub


#End Region

#Region "Controls"

    Private Sub btnProfiles_Click(sender As Object, e As EventArgs) Handles btnProfiles.Click
        If tryAccess(btnProfiles) Then
            frmStream.Close()

            sfrmUserProfiles.ShowDialog()

            'Dim employees As List(Of VerilookLib2.Interface_.IFace) = Controller.Employee.CollectEmployees(DatabaseManager)
            'NOTE: USE VERILOOK MANAGER

            frmStream.Show()
        End If
    End Sub


    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        If tryAccess(btnSettings) Then
            frmStream.Close()
            If sfrmSettings.ShowDialog() = DialogResult.OK Then lbCompany.Text = Environment.GetEnvironmentVariable("TIME_RECORDER_COMPANY")
            frmStream.Show()
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Function tryAccess(btn As Object) As Boolean
        With frmStream
            If .AllowAuth Then
                AuthButton = Nothing
                tbAdminID.Visible = False
                .AllowAuth = False
                .PendingAuth = False
                Return True
            ElseIf Not .AllowAuth And Not .PendingAuth And tbAdminID.Visible Then
                AuthButton = Nothing
                tbAdminID.Visible = False
                Return False
            Else
                AuthButton = btn
                tbAdminID.Visible = True
                .PendingAuth = True
                Return False
            End If
        End With
    End Function
#End Region

#Region "Timer Eventhandler"
    Private NoInternetPromptCounter As Integer = 0
    Private NoInternetConnection As Boolean
    Private Sub tmClock_Tick(sender As Object, e As EventArgs) Handles tmClock.Tick
        tmClock.Enabled = False
        lbTime.Text = Microsoft.VisualBasic.Strings.Format(Date.Now, "hh:mm:ss tt")
        lbDate.Text = Microsoft.VisualBasic.Strings.Format(Date.Now, "dd dddd MMMM yyyy")

        If IsConnectedToInternet() = False Then
            If NoInternetPromptCounter > 10 Then
                NoInternetConnection = True
                changeStatus("Cannot access the Internet, Please request assistance from IT Technician.", Color.Firebrick)
            Else : NoInternetPromptCounter += 1
            End If
        Else
            NoInternetPromptCounter = 0
            NoInternetConnection = False
            changeStatus("Ready", Color.FromArgb(37, 40, 45))
        End If

        tmClock.Enabled = True
    End Sub

    Private Sub Clock1_TimeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Clock1.TimeChanged
        Me.Clock1.UtcOffset = TimeZone.CurrentTimeZone.GetUtcOffset(Date.Now)
    End Sub

#End Region
#Region "Stream"

    Public Sub changeStatus(resultString As String, statBarColor As Color)
        lbState.Text = resultString
        stState.BackColor = statBarColor
        Application.DoEvents()
    End Sub

#End Region

    Private Sub tmSendTimelog_Tick(sender As Object, e As EventArgs) Handles tmSendTimelog.Tick
        If bgwSendTimelog.IsBusy = False Then
            bgwSendTimelog.RunWorkerAsync()
        End If
    End Sub

    Private Async Sub bgwSendTimelog_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwSendTimelog.DoWork
        Dim _databaseManager As New Manager.Mysql(DatabaseConfiguration)
        _databaseManager.Connection.Open()
        Try
            Await Controller.AttendanceLog.GetQueuedAttendance(_databaseManager, AttendanceAPIManager)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
        _databaseManager.Connection.Close()
    End Sub

    Private Sub tmTimelogSync_Tick(sender As Object, e As EventArgs) Handles tmTimelogSync.Tick
        'If NoInternetConnection Then Exit Sub

        If bgwTimelogSync.IsBusy = False Then
            bgwTimelogSync.RunWorkerAsync()
        End If

        If bgwUserSync.IsBusy = False Then
            bgwUserSync.RunWorkerAsync()
        End If
    End Sub

    Private Async Sub bgwTimelogSync_DoWorkAsync(sender As Object, e As DoWorkEventArgs) Handles bgwTimelogSync.DoWork
        Dim _databaseManager As New Manager.Mysql(DatabaseConfiguration)
        _databaseManager.Connection.Open()
        Try
            Invoke(Sub()
                       pbStatus.Visible = True
                       lbLastTimelogSync.Text = "Syncing..."
                   End Sub)
            Dim res As Boolean = Await Controller.Attendance.SyncAttendance(_databaseManager, AttendanceAPIManager)

            Invoke(Sub()
                       If res Then
                           lbLastTimelogSync.Text = Now.ToString("yyyy-MM-dd HH:mm:ss")
                       Else
                           lbLastTimelogSync.Text = "Sync attempt resulted to an Error!"
                       End If

                       pbStatus.Visible = False
                       SetupDGV(dgv)
                   End Sub)

        Catch ex As Exception
            Invoke(Sub() lbLastTimelogSync.Text = "Sync attempt resulted to an Error!")
        End Try
        _DatabaseManager.Connection.Close()
    End Sub
    Private Async Sub bgwUserSync_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwUserSync.DoWork
        Dim _databaseManager As New Manager.Mysql(DatabaseConfiguration)
        _databaseManager.Connection.Open()
        Try
            Invoke(Sub()
                       pbStatus.Visible = True
                       lbLastUserSync.Text = "Syncing..."
                   End Sub)

            Dim userSent As Integer = Await Controller.Employee.SendEmployeeToServer(_databaseManager, EmployeeAPIManager)
            Dim userReceived As Integer = Await Controller.Employee.GetEmployeeFromServer(_databaseManager, EmployeeAPIManager)

            Invoke(Sub()
                       lbLastUserSync.Text = String.Format("Last Synced: {0}   Received: {1} Sent: {2}", Now.ToString("yyyy-MM-dd HH:mm:ss"), userReceived, userSent)
                   End Sub)
        Catch ex As Exception
            Invoke(Sub() lbLastUserSync.Text = "Sync attempt resulted to an Error!")
            MessageBox.Show(ex.Message, "Error occured while saving the time log.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        _databaseManager.Connection.Close()

        Invoke(Sub()
                   pbStatus.Visible = False
                   refreshStream()
               End Sub)
    End Sub

    Private refreshing As Boolean
    Private Sub refreshStream()
        refreshing = True
        tmRefreshStream.Enabled = True
        changeStatus("Camera Refreshing, Please wait...", Color.Firebrick)
    End Sub
    Private Sub btnRefreshCamera_Click(sender As Object, e As EventArgs) Handles btnRefreshCamera.Click
        refreshStream()
    End Sub
    Private Sub tmRefreshStream_Tick(sender As Object, e As EventArgs) Handles tmRefreshStream.Tick
        If refreshing Then
            frmStream.Close()
            refreshing = False
        Else
            frmStream.Show()
            tmRefreshStream.Enabled = False
            changeStatus("Ready.", Color.FromArgb(37, 40, 45))
        End If
    End Sub


End Class


