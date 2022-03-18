﻿Imports System.ComponentModel
Imports System.Windows.Forms
Imports face_recognition_service.Manager
Imports Newtonsoft.Json
Imports time_recorder_service
Imports utility_service


Public Class frmMain


    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Text = Application.ProductName & " v" & Application.ProductVersion
        lbCompany.Text = Environment.GetEnvironmentVariable("TIME_RECORDER_COMPANY")

    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load

        SetupConfiguration()
        'SetupDGV()
        SetupTimer()


    End Sub

#Region "Setup"

    Private Sub SetupConfiguration()
        DatabaseConfiguration = New Configuration.Mysql()
        DatabaseConfiguration.Setup("TIME_RECORDER_DB_URL_2")

        DatabaseManager = New Manager.Mysql(DatabaseConfiguration)
        DatabaseManager.Connection.Open()
        SetupManager()
        DatabaseManager.Connection.Close()
    End Sub
    Private Function SetupManager()

        Dim settings As Model.Settings = Controller.Settings.GetSettings(DatabaseManager, "AttendanceAPIManager")
        If settings IsNot Nothing Then
            AttendanceAPIManager = JsonConvert.DeserializeObject(Of Manager.API.Attendance)(settings.JSON_Arguments)
        End If

        settings = Controller.Settings.GetSettings(DatabaseManager, "FaceRecognitionAPIManager")
        If settings IsNot Nothing Then
            FaceRecognitionAPIManager = JsonConvert.DeserializeObject(Of API.FaceProfile)(settings.JSON_Arguments)
        End If

        settings = Controller.Settings.GetSettings(DatabaseManager, "HRMSAPIManager")
        If settings IsNot Nothing Then
            HRMSAPIManager = JsonConvert.DeserializeObject(Of hrms_api_service.Manager.API.HRMS)(settings.JSON_Arguments)
        End If

        settings = Controller.Settings.GetSettings(DatabaseManager, "UPSGAPIManager")
        If settings IsNot Nothing Then
            UPSGAPIManager = JsonConvert.DeserializeObject(Of upsg_api_service.Manager.API.UPSG)(settings.JSON_Arguments)
        End If

        settings = Controller.Settings.GetSettings(DatabaseManager, "VerilookManager.Settings")
        If settings IsNot Nothing Then
            VerilookManager = New FaceRecognition
            VerilookManager.Settings = JsonConvert.DeserializeObject(Of face_recognition_service.Configuration.Face)(settings.JSON_Arguments)
            VerilookManager.Setup()
        End If

        Return True
    End Function
    Private Sub SetupDGV()
        dgv.Rows.Clear()
        DatabaseManager.Connection.Open()
        Dim attendances As List(Of Model.Attendance) = Controller.Attendance.GetAttendances(DatabaseManager, completeDetail:=True, limit:=100)
        DatabaseManager.Connection.Close()

        For Each attendance As Model.Attendance In attendances
            Dim dgvr As New DataGridViewRow
            dgvr.CreateCells(dgv)
            With dgvr
                .Cells(0).Value = attendance.Name
                .Cells(1).Value = attendance.Employee.Jobcode
                .Cells(2).Value = attendance.LogStatus.ToString
                .Cells(3).Value = attendance.LogDate.ToString("yyyy-MM-dd")
                .Cells(4).Value = attendance.TimeStamp.ToString("hh:mm tt")
            End With
            dgv.Rows.Add(dgvr)
        Next

        dgv.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft 'name
        dgv.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter 'jobcode
        dgv.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter 'log status
        dgv.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter 'log date
        dgv.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter 'log time

        If Not dgv.Rows.Count = 0 Then dgv.CurrentCell = dgv.Item(0, 0)
        Application.DoEvents()
    End Sub
    Private Sub SetupTimer()
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

        Me.Clock1.UtcOffset = TimeZone.CurrentTimeZone.GetUtcOffset(Date.Now)
    End Sub

#End Region

#Region "Administrator Access"
    Private Sub btnAdministrator_Click(sender As Object, e As EventArgs) Handles btnAdministrator.Click
        TryAccess(btnAdministrator)
    End Sub

    Private Function TryAccess(btn As Object) As Boolean
        If Not PendingAuth And tbAdminID.Visible Then
            tbAdminID.Visible = False
            Return False
        Else
            tbAdminID.Visible = True
            PendingAuth = True
            Return False
        End If
    End Function
#End Region

#Region "Clock and No Internet Prompter"
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

#End Region

#Region "Timers"
    Private Sub tmSendTimelog_Tick(sender As Object, e As EventArgs) Handles tmSendTimelog.Tick
        If bgwSendTimelog.IsBusy = False Then
            bgwSendTimelog.RunWorkerAsync()
        End If
    End Sub

    Private Sub tmTimelogSync_Tick(sender As Object, e As EventArgs) Handles tmTimelogSync.Tick
        If sender IsNot Nothing Then CloseStream()

        If bgwUserSync.IsBusy = False Then
            bgwUserSync.RunWorkerAsync()
        End If
    End Sub
#End Region

#Region "Background Tasks"
    Private Async Sub bgwSendTimelog_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwSendTimelog.DoWork
        Dim _databaseManager As New Manager.Mysql(DatabaseConfiguration)
        _databaseManager.Connection.Open()
        Try
            Await Controller.AttendanceLog.SendQueuedAttendance(_databaseManager, AttendanceAPIManager)
            Await upsg_api_service.Controller.UPSG.SendUPSGQueuedLogAsync(_databaseManager, UPSGAPIManager)
        Catch ex As Exception
            'MsgBox(ex.Message, Title:="bgw")
            Console.WriteLine(ex.Message)
        End Try
        _databaseManager.Connection.Close()
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
                       Else : lbLastTimelogSync.Text = "Sync attempt resulted to an Error!"
                       End If

                       pbStatus.Visible = False
                       SetupDGV()
                       OpenStream()
                   End Sub)

        Catch ex As Exception
            Invoke(Sub() lbLastTimelogSync.Text = "Sync attempt resulted to an Error!")
        End Try
        _databaseManager.Connection.Close()
    End Sub

    Private Async Sub bgwUserSync_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwUserSync.DoWork
        Dim _databaseManager As New Manager.Mysql(DatabaseConfiguration)
        _databaseManager.Connection.Open()
        Try
            Invoke(Sub()
                       pbStatus.Visible = True
                       lbLastUserSync.Text = "Syncing..."
                   End Sub)

            Dim userSent As Integer = Await Controller.FaceProfile.SaveToServer(_databaseManager, FaceRecognitionAPIManager)
            Dim userReceived As Integer = Await Controller.FaceProfile.CollectFromServer(_databaseManager, FaceRecognitionAPIManager)

            Invoke(Sub()
                       lbLastUserSync.Text = String.Format("Last Synced: {0}   Received: {1} Sent: {2}", Now.ToString("yyyy-MM-dd HH:mm:ss"), userReceived, userSent)
                   End Sub)
        Catch ex As Exception
            Invoke(Sub() lbLastUserSync.Text = "Sync attempt resulted to an Error!")
            MessageBox.Show(ex.Message, "Error occured while saving the time log.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        _databaseManager.Connection.Close()

        Invoke(Sub()

                   If bgwTimelogSync.IsBusy = False Then
                       bgwTimelogSync.RunWorkerAsync()
                   End If

               End Sub)
    End Sub

#End Region

#Region "Stream Handler"
    Private Async Sub OpenStream()
        changeStatus("Camera Refreshing, Please wait...", Color.Firebrick)

        DatabaseManager.Connection.Open()
        Dim employees As List(Of Model.FaceProfile) = Controller.FaceProfile.Collect(DatabaseManager)
        DatabaseManager.Connection.Close()

        VerilookManager.EmployeeFaceSubjects = face_recognition_service.Controller.FaceProfile.CollectFaceSubjects(employees, True)
        VerilookManager.FillBiometricTask()

        AddHandler VerilookManager.FaceIdentified, AddressOf FaceManager_FaceIdentified

        Await VerilookManager.StartProcess(Me, fvStream, FaceProcessType.Identify)
    End Sub

    Private Sub CloseStream()
        RemoveHandler VerilookManager.FaceIdentified, AddressOf FaceManager_FaceIdentified
        VerilookManager.ForceCapture()
        VerilookManager.StopProcess()
    End Sub


#End Region

#Region "Face Validation Handler"
    Public RecentEE_Ids As New List(Of String)
    Public PendingAuth As Boolean

    Private Sub AccessAdministrator(employee As Model.Employee)
        tbAdminID.Visible = False
        PendingAuth = False

        If employee.FaceProfile.Admin Then
            Splash("Access allowed.", StatusChoices.SCAN_SUCCESS)
            CloseStream()
            frmAdministrator.ShowDialog()
            OpenStream()
        Else
            Splash("Access not allowed.", StatusChoices.SCAN_ERROR)
        End If
    End Sub

    Private Sub ProcessAttendance(score As Integer, employee As Model.Employee)
        If score > VerilookManager.Settings.MatchingScoreThreshold Then
            'Dim validLog As Boolean = True
            'If score < (VerilookManager.Settings.MatchingScoreThreshold + 5) Then
            '    If MessageBox.Show(String.Format("Are You {0}?", employee.FullName), "Matching score is too low.", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = System.Windows.Forms.DialogResult.Yes Then
            '        validLog = True
            '    Else validLog = False
            '    End If
            'End If

            'If validLog Then
            Try
                DatabaseManager.Connection.Open()
                Dim attendance As Model.Attendance = Controller.Attendance.SaveAttendance(DatabaseManager, employee)

                If employee.Jobcode.ToUpper = "UPSG" Or employee.Jobcode.ToUpper = "UPS" Then
                    upsg_api_service.Controller.UPSG.SaveLogToQueue(DatabaseManager, employee.EE_Id, Now)
                End If

                Splash("Found " & employee.FullName, StatusChoices.SCAN_SUCCESS)

                RecentEE_Ids.Insert(0, employee.EE_Id)
                If RecentEE_Ids.Count > 5 Then RecentEE_Ids.RemoveAt(5)

                dgv.Rows.Insert(0,
                                employee.FullName,
                                employee.Jobcode,
                                attendance.LogStatus,
                                attendance.LogDate.ToString("yyyy-mm-dd"),
                                attendance.TimeStamp.ToString("hh:mm tt")
                )

            Catch ex As Exception
                Console.WriteLine(ex.Message)
                End Try
                DatabaseManager.Connection.Close()

            'End If
        End If
    End Sub

    Private Async Sub FaceManager_FaceIdentified(sender As Object, e As FaceRecognizeEventArgs)
        Try
            If e.Status = Neurotec.Biometrics.NBiometricStatus.Ok Then
                DatabaseManager.Connection.Open()
                Dim ee_id As String = e.UserID.Split("_")(0)
                Dim employee As Model.Employee = Controller.Employee.Find(DatabaseManager, ee_id, shouldCompleteDetail:=True)
                If employee Is Nothing Then
                    employee = Await HRMSAPIManager.GetEmployeeFromServer(ee_id)
                End If
                DatabaseManager.Connection.Close()

                If PendingAuth Then
                    AccessAdministrator(employee)
                ElseIf RecentEE_Ids.Contains(employee.EE_Id) = False Then
                    ProcessAttendance(e.Score, employee)
                End If
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            'MessageBox.Show(ex.Message, "Error occured while identifying face.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        If DatabaseManager.Connection.State = ConnectionState.Open Then
            DatabaseManager.Connection.Close()
        End If
    End Sub

#End Region

#Region "Status Handler"
    Public Sub Splash(message As String, result As StatusChoices)
        lbState.Text = message
        If result = StatusChoices.SCAN_SUCCESS Then
            pnlSuccess.BringToFront()
            pnlSuccess.Visible = True
            changeStatus("Ready.", Color.ForestGreen)
        Else
            pnlError.BringToFront()
            pnlError.Visible = True
            changeStatus("Ready.", Color.Firebrick)
        End If
        tmRefreshStream.Interval = 400
        tmRefreshStream.Enabled = True
    End Sub

    Public Sub changeStatus(resultString As String, statBarColor As Color)
        lbState.Text = resultString
        stState.BackColor = statBarColor
        Application.DoEvents()
    End Sub
    Private Sub tmRefreshStream_Tick(sender As Object, e As EventArgs) Handles tmRefreshStream.Tick
        changeStatus("Ready.", Color.FromArgb(37, 40, 45))

        pnlSuccess.Visible = False
        pnlError.Visible = False
        tmRefreshStream.Enabled = False
    End Sub
#End Region

    Public Enum StatusChoices
        SCAN_SUCCESS
        SCAN_ERROR
    End Enum

    Private Sub btnRefreshCamera_Click(sender As Object, e As EventArgs) Handles btnRefreshCamera.Click
        CloseStream()
        OpenStream()
    End Sub
End Class


