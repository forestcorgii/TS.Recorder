Imports System.ComponentModel
Imports System.IO
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports Newtonsoft.Json
Imports time_recorder_service
Imports utility_service
Imports VerilookLib2
Imports VerilookLib2.Manager

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
        SetupDGV()

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

        settings = Controller.Settings.GetSettings(DatabaseManager, "UPSGAPIManager")
        If settings IsNot Nothing Then
            UPSGAPIManager = JsonConvert.DeserializeObject(Of upsg_api_service.Manager.API.UPSG)(settings.JSON_Arguments)
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



    Private Sub SetupDGV()
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
        tryAccess(btnProfiles)
    End Sub




    Private Sub btnExit_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Function tryAccess(btn As Object) As Boolean
        If AllowAuth Then
            AuthButton = Nothing
            tbAdminID.Visible = False
            AllowAuth = False
            PendingAuth = False
            Return True
        ElseIf Not AllowAuth And Not PendingAuth And tbAdminID.Visible Then
            AuthButton = Nothing
            tbAdminID.Visible = False
            Return False
        Else
            AuthButton = btn
            tbAdminID.Visible = True
            PendingAuth = True
            Return False
        End If
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

    Private Sub tmSendTimelog_Tick(sender As Object, e As EventArgs) Handles tmSendTimelog.Tick
        If bgwSendTimelog.IsBusy = False Then
            bgwSendTimelog.RunWorkerAsync()
        End If
    End Sub

    Private Async Sub bgwSendTimelog_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwSendTimelog.DoWork
        Dim _databaseManager As New Manager.Mysql(DatabaseConfiguration)
        _databaseManager.Connection.Open()
        Try
            Await Controller.AttendanceLog.SendQueuedAttendance(_databaseManager, AttendanceAPIManager)
            Await upsg_api_service.Controller.UPSG.SendUPSGQueuedLogAsync(_databaseManager, UPSGAPIManager)
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
                       Else : lbLastTimelogSync.Text = "Sync attempt resulted to an Error!"
                       End If

                       pbStatus.Visible = False
                       SetupDGV()
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
                   OpenStream()
                   'refreshStream()
               End Sub)
    End Sub



#Region ""
    Public ScannedUsers As New clsUsedUsers
    Public UsersOnQueue As New List(Of String)
    Public AllowAuth As Boolean
    Public PendingAuth As Boolean

    Private Async Sub OpenStream()
        changeStatus("Camera Refreshing, Please wait...", Color.Firebrick)

        DatabaseManager.Connection.Open()
        Dim employees As List(Of Model.Employee) = Controller.Employee.CollectEmployees(DatabaseManager)
        DatabaseManager.Connection.Close()

        VerilookManager.EmployeeFaceSubjects = Controller.Verilook.CollectFaceSubjects(employees, True)
        VerilookManager.FillBiometricTask()


        AddHandler VerilookManager.FaceIdentified, AddressOf FaceManager_FaceIdentified
        If ScannedUsers Is Nothing Then
            ScannedUsers = New clsUsedUsers
        End If

        Await VerilookManager.StartProcess(Me, fvStream, FaceProcessType.Identify)
    End Sub

    Private Sub FaceManager_FaceIdentified(sender As Object, e As VerilookEventArgs)
        Try
            If e.Status = Neurotec.Biometrics.NBiometricStatus.Ok Then
                DatabaseManager.Connection.Open()
                Dim employee As Model.Employee = Controller.Employee.GetEmployee(DatabaseManager, e.UserID.Split("_")(0))
                DatabaseManager.Connection.Close()

                If PendingAuth Then
                    If employee.admin Then
                        Splash("Access allowed.", StatusChoices.SCAN_SUCCESS)
                        StreamClose()
                        sfrmUserProfiles.ShowDialog()
                        OpenStream()
                    Else
                        Splash("Access not allowed.", StatusChoices.SCAN_ERROR)
                    End If
                    PendingAuth = False
                ElseIf Not ScannedUsers.Contains(employee.Employee_Id) And Not UsersOnQueue.Contains(employee.Employee_Id) Then
                    If e.Score > VerilookManager.Settings.MatchingScoreThreshold Then
                        Dim validLog As Boolean = True
                        If e.Score < (VerilookManager.Settings.MatchingScoreThreshold + 5) Then
                            If MessageBox.Show("Are You " & employee.Employee_Id & "?", "Matching score is too low.",
                                               MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = System.Windows.Forms.DialogResult.Yes Then
                                validLog = True
                            Else
                                validLog = False
                            End If
                            Dim rawMatches As String = String.Join(",", e.RawMatches)
                            DatabaseManager.Connection.Open()
                            DatabaseManager.ExecuteNonQuery(String.Format("INSERT INTO `low_matching_scores_log` (`employee_id`,`score`,`is_match`,`raw_matches`)VALUES('{0}',{1},{2},'{3}')",
                                                                      employee.Employee_Id, e.Score, validLog, rawMatches))
                            DatabaseManager.Connection.Close()
                        End If

                        If validLog Then
                            Splash("Found " & employee.FullName, StatusChoices.SCAN_SUCCESS)
                            ScannedUsers.Add(New clsUsedUser() With {.ID = employee.Employee_Id})

                            DatabaseManager.Connection.Open()

                            Controller.Attendance.SaveAttendance(DatabaseManager, employee)

                            Dim upsgLog As New upsg_api_service.Model.UPSG
                            upsgLog.EE_Id = employee.Employee_Id
                            upsgLog.TimeStamp = Now
                            upsg_api_service.Controller.UPSG.SaveLogToQueue(DatabaseManager, upsgLog)

                            DatabaseManager.Connection.Close()

                            SetupDGV()
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error occured while identifying face.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        If DatabaseManager.Connection.State = ConnectionState.Open Then
            DatabaseManager.Connection.Close()
        End If
    End Sub


    Public Enum StatusChoices
        SCAN_SUCCESS
        SCAN_ERROR
    End Enum

    Private Sub StreamClose()
        RemoveHandler VerilookManager.FaceIdentified, AddressOf FaceManager_FaceIdentified
        VerilookManager.ForceCapture()
        VerilookManager.StopProcess()
    End Sub

    Private closeForm As Boolean


    Private Sub tmChecker_Tick(sender As Object, e As EventArgs) Handles tmChecker.Tick
        If ScannedUsers.Count > 0 Then
            Dim updatedItems As clsUsedUser() = (From res As clsUsedUser In ScannedUsers Where res.Elapse.TotalSeconds < VerilookManager.Settings.UserReloginTime * 60 Select res).ToArray
            ScannedUsers = New clsUsedUsers(updatedItems)
        Else : tmChecker.Enabled = False
        End If
    End Sub
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
        tmRefreshStream.Interval = 500 'TimeSpan.FromSeconds(0.5).TotalMilliseconds
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




    Public Class clsUsedUsers
        Inherits List(Of clsUsedUser)

        Sub New()

        End Sub

        Sub New(_users As clsUsedUser())
            AddRange(_users)
        End Sub

        Public Shadows Function Contains(userID As String) As Boolean
            If Count > 0 Then
                Return (From res As clsUsedUser In Me Where res.ID = userID Select res).ToList.Count > 0
            End If
            Return False
        End Function
    End Class

    Public Class clsUsedUser
        Public ID As String
        Private timeCreated As Date

        Public ReadOnly Property Elapse As TimeSpan
            Get
                Return Now - timeCreated
            End Get
        End Property

        Sub New()
            timeCreated = Now
        End Sub
    End Class

#End Region
End Class


