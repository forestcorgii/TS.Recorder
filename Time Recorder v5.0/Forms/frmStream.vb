
Imports System.ComponentModel
Imports System.Windows.Forms
Imports time_recorder_service
Imports VerilookLib2
Imports VerilookLib2.Manager

Public Class frmStream
    Public ScannedUsers As New clsUsedUsers
    Public UsersOnQueue As New List(Of String)
    Public AllowAuth As Boolean
    Public PendingAuth As Boolean
    Private userReloginTime As Double

    Private WithEvents Speaker As New BackgroundWorker
    Private Sub Speak(speechcode As Integer)
        If Speaker.IsBusy = False Then
            Select Case speechcode
                Case 0
                    Speaker.RunWorkerAsync("ftw.wav") 'audio location
                Case 1
                    Speaker.RunWorkerAsync("denied.wav")
                Case 2
                    Speaker.RunWorkerAsync("contact_tracing_cleared.wav")
                Case 3
                    Speaker.RunWorkerAsync("contact_tracing_denied.wav")
            End Select
        End If
    End Sub

    Private Sub Speaker_DoWork(sender As Object, e As DoWorkEventArgs) Handles Speaker.DoWork
        Try
            My.Computer.Audio.Play(Application.StartupPath & "\" & e.Argument, AudioPlayMode.WaitToComplete)

        Catch ex As Exception
            MsgBox("Speaker_DoWork")
        End Try
    End Sub

    Private Async Sub frmStream_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DatabaseManager.Connection.Open()
        Dim employees As List(Of Model.Employee) = Controller.Employee.CollectEmployees(DatabaseManager)
        DatabaseManager.Connection.Close()

        VerilookManager.EmployeeFaceSubjects = Controller.Verilook.CollectFaceSubjects(employees, True)
        VerilookManager.FillBiometricTask()

        Location = New Point(50, 300)
        tmClosingAttempt.Enabled = False
        tmCamera2Checking.Enabled = True
        userReloginTime = 1 'VerilookManager.Settings.UserReloginTime

        AddHandler VerilookManager.FaceIdentified, AddressOf FaceManager_FaceIdentified
        If ScannedUsers Is Nothing Then
            ScannedUsers = New clsUsedUsers
        End If

        Await VerilookManager.StartProcess(Me, fvStream, FaceProcessType.Identify)
    End Sub

    Private Sub FaceManager_FaceIdentified(sender As Object, e As VerilookEventArgs)
        DatabaseManager.Connection.Open()
        Try
            If e.Status = Neurotec.Biometrics.NBiometricStatus.Ok Then
                Dim userId As String = e.UserID.Split("_")(0)

                If PendingAuth Then
                    If Controller.Employee.GetEmployee(DatabaseManager, userId).admin Then
                        Splash("Access allowed.", StatusChoices.SCAN_SUCCESS)
                        sfrmUserProfiles.Show()
                        Close()
                    Else
                        Splash("Access not allowed.", StatusChoices.SCAN_ERROR)
                    End If
                    PendingAuth = False
                    '                End Sub)
                ElseIf Not ScannedUsers.Contains(userId) And Not UsersOnQueue.Contains(userId) Then
                    If e.Score > VerilookManager.Settings.MatchingScoreThreshold Then
                        Dim validLog As Boolean = True
                        If e.Score < (VerilookManager.Settings.MatchingScoreThreshold + 5) Then
                            If MessageBox.Show("Are You " & userId & "?", "Matching score is too low.",
                                               MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = System.Windows.Forms.DialogResult.Yes Then
                                validLog = True
                            Else
                                validLog = False
                            End If
                            Dim rawMatches As String = String.Join(",", e.RawMatches)
                            DatabaseManager.ExecuteNonQuery(String.Format("INSERT INTO `low_matching_scores_log` (`employee_id`,`score`,`is_match`,`raw_matches`)VALUES('{0}',{1},{2},'{3}')",
                                                                      userId, e.Score, validLog, rawMatches))
                        End If

                        If validLog Then
                            Splash("Found " & userId, StatusChoices.SCAN_SUCCESS)
                            ScannedUsers.Add(New clsUsedUser() With {.ID = userId})

                            Controller.Attendance.SaveAttendance(DatabaseManager, userId)
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error occured while identifying face.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        DatabaseManager.Connection.Close()
    End Sub
    Public Sub Splash(message As String, result As StatusChoices)
        lbResultMessage.Text = message
        If result = StatusChoices.SCAN_SUCCESS Then
            pnlSuccess.BringToFront()
            pnlSuccess.Visible = True
        Else
            pnlError.BringToFront()
            pnlError.Visible = True
        End If
        tmRefresher.Interval = 500 'TimeSpan.FromSeconds(0.5).TotalMilliseconds
        tmRefresher.Enabled = True
    End Sub

    Public Enum StatusChoices
        SCAN_SUCCESS
        SCAN_ERROR
    End Enum
    Private Sub frmStream_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not closeForm Then
            RemoveHandler VerilookManager.FaceIdentified, AddressOf FaceManager_FaceIdentified
            VerilookManager.ForceCapture()
            tmClosingAttempt.Enabled = True
            e.Cancel = True
        Else : VerilookManager.StopProcess()
        End If
    End Sub

    Private closeForm As Boolean
    Private Sub tmClosingAttempt_Tick(sender As Object, e As EventArgs) Handles tmClosingAttempt.Tick
        closeForm = True
        tmClosingAttempt.Enabled = False
        Me.Close()
    End Sub

    Private Sub NFaceView1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles fvStream.MouseDoubleClick
        If Me.FormBorderStyle = FormBorderStyle.Sizable Then
            Me.FormBorderStyle = FormBorderStyle.None
            Me.WindowState = FormWindowState.Maximized
        Else
            Me.FormBorderStyle = FormBorderStyle.Sizable
            Me.WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub tmChecker_Tick(sender As Object, e As EventArgs) Handles tmChecker.Tick
        If ScannedUsers.Count > 0 Then
            Dim updatedItems As clsUsedUser() = (From res As clsUsedUser In ScannedUsers Where res.Elapse.TotalSeconds < userReloginTime * 60 Select res).ToArray
            ScannedUsers = New clsUsedUsers(updatedItems)
        Else : tmChecker.Enabled = False
        End If
    End Sub

    Private Sub tmRefresher_Tick(sender As Object, e As EventArgs) Handles tmRefresher.Tick
        lbResultMessage.Text = "Welcome!"

        pnlSuccess.Visible = False
        pnlError.Visible = False
                   tmRefresher.Enabled = False

    End Sub
End Class


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
