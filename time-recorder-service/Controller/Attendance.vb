Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports Newtonsoft.Json

Namespace Controller

    Public Class Attendance
        Public Shared Async Function GetAttendancesAsync(databaseManager As utility_service.Manager.Mysql, Optional completeDetail As Boolean = False, Optional limit As Integer = 100, Optional hrmsAPIManager As hrms_api_service.Manager.API.HRMS = Nothing) As Task(Of List(Of Model.Attendance))
            Dim attendances As New List(Of Model.Attendance)
            Using reader As MySqlDataReader = databaseManager.ExecuteDataReader(String.Format("SELECT * FROM attendance ORDER BY `time` DESC LIMIT {0}", limit))
                If reader.HasRows Then
                    While reader.Read
                        attendances.Add(New Model.Attendance(reader))
                    End While
                End If
            End Using

            If completeDetail Then
                For Each item As Model.Attendance In attendances
                    If hrmsAPIManager Is Nothing Then
                        item.Employee = Controller.Employee.Find(databaseManager, item.EE_Id)
                    Else
                        item.Employee = Await Controller.Employee.FindAsync(databaseManager, item.EE_Id, hrmsAPIManager:=hrmsAPIManager)
                        Employee.Save(databaseManager, item.Employee)
                    End If
                Next
            End If
            Return attendances
        End Function

        Public Shared Function GetLastAttendanceSyncLogDate(databaseManager As utility_service.Manager.Mysql) As Date
            Dim lastAttendanceSyncLogDate As Date = Nothing
            Using reader As MySqlDataReader = databaseManager.ExecuteDataReader("SELECT `timestamp` FROM attendance_sync_log ORDER BY `timestamp` DESC LIMIT 1;")
                If reader.HasRows Then
                    reader.Read()
                    lastAttendanceSyncLogDate = reader.Item("timestamp")
                Else : lastAttendanceSyncLogDate = Now.AddDays(-1)
                End If
            End Using

            Return lastAttendanceSyncLogDate
        End Function
        Public Shared Async Function SyncAttendance(databaseManager As utility_service.Manager.Mysql, AttendanceAPIManager As Manager.API.Attendance, hrmsAPIManager As hrms_api_service.Manager.API.HRMS) As Task(Of Boolean)
            Dim tms As New List(Of AttendanceFromServer)
            Dim serverResponse = Await AttendanceAPIManager.RequestUpdateAsync_NoPrompt(GetLastAttendanceSyncLogDate(databaseManager).ToString("yyyy-MM-dd HH:mm:ss"))
            'Dim serverResponse = Await AttendanceAPIManager.RequestUpdateAsync_NoPrompt("2022-04-28 01:00:00")
            If serverResponse(0) Then
                Try
                    tms = JsonConvert.DeserializeObject(serverResponse(1), tms.GetType)

                    For i As Integer = 0 To tms.Count - 1
                        Dim loginf As AttendanceFromServer = tms(i)
                        Try
                            Dim empinfo As Model.Employee = Await Employee.FindAsync(databaseManager, loginf.id_number, hrmsAPIManager:=hrmsAPIManager)

                            If empinfo IsNot Nothing Then
                                Dim attendance As Model.Attendance
                                If loginf.no_time_in = False Then
                                    attendance = New Model.Attendance
                                    With attendance
                                        .EE_Id = loginf.id_number
                                        .LogDate = loginf.log_date
                                        .LogStatus = AttendanceStatusChoices.TIME_IN
                                        .TimeStamp = loginf.new_time_in
                                    End With
                                    InsertAttendance(databaseManager, attendance, empinfo)
                                End If

                                If loginf.no_time_out = False Then
                                    attendance = New Model.Attendance
                                    With attendance
                                        .EE_Id = loginf.id_number
                                        .LogDate = loginf.log_date
                                        .LogStatus = AttendanceStatusChoices.TIME_OUT
                                        .TimeStamp = loginf.new_time_out
                                    End With
                                    InsertAttendance(databaseManager, attendance, empinfo)
                                End If
                            End If
                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Return False
                        End Try
                    Next
                    If tms.Count > 0 Then
                        databaseManager.ExecuteNonQuery(String.Format("DELETE FROM attendance where `time` < '{0:yyyy-MM-dd HH:mm:ss}';", Now.AddDays(-4)))
                        databaseManager.ExecuteNonQuery("INSERT INTO attendance_sync_log ()VALUES();")
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            End If

            Return True
        End Function

        Public Shared Function SaveAttendance(databaseManager As utility_service.Manager.Mysql, employee As Model.Employee) As Model.Attendance
            Try
                Dim attendanceStatus As Byte = 0
                Dim attendanceDate As Date = Now
                Dim currentAttendance As Model.Attendance = GetLatestAttendance(databaseManager, employee.EE_Id)
                If (Now - currentAttendance.TimeStamp).TotalMinutes < 2 Then Return Nothing 'IF CURRENT ATTENDANCE IS LESS THAN 2MINS FROM NOW THEN DISREGARD ATTENDANCE ENTRY.

                attendanceStatus = GetNextAttendanceStatus(currentAttendance.TimeStamp, currentAttendance.LogDate, currentAttendance.LogStatus)
                attendanceDate = GetAttendanceDate(attendanceStatus, attendanceDate, currentAttendance.LogStatus, currentAttendance.TimeStamp, currentAttendance.LogDate)

                Dim newAttendance As New Model.Attendance
                With newAttendance
                    .EE_Id = employee.EE_Id
                    .LogDate = attendanceDate
                    .LogStatus = attendanceStatus
                    .TimeStamp = Now
                End With

                InsertAttendanceSendQueue(databaseManager, newAttendance)
                InsertAttendance(databaseManager, newAttendance, employee)

                Return GetLatestAttendance(databaseManager, employee.EE_Id)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error occured while saving the time log.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            Return Nothing
        End Function


#Region "Private Methods"
        Private Shared Function GetNextAttendanceStatus(currentAttendanceTime As Date, currentAttendanceDate As Date, currentAttendanceStatus As AttendanceStatusChoices) As AttendanceStatusChoices
            If currentAttendanceDate.ToString("yyyyMMdd HHmmss") = "00010101 000000" Then Return currentAttendanceStatus

            Dim nextLogStatus As AttendanceStatusChoices = AttendanceStatusChoices.TIME_IN
            Select Case currentAttendanceStatus
                Case AttendanceStatusChoices.TIME_IN
                    If (Now - currentAttendanceTime).TotalHours > 20 And Now.Day <> currentAttendanceTime.Day Then
                        nextLogStatus = AttendanceStatusChoices.TIME_IN
                    Else
                        nextLogStatus = AttendanceStatusChoices.TIME_OUT
                    End If
                Case AttendanceStatusChoices.TIME_OUT
                    If (Now - currentAttendanceTime).TotalHours >= 8 Then
                        nextLogStatus = AttendanceStatusChoices.TIME_IN
                    Else
                        nextLogStatus = AttendanceStatusChoices.TIME_OUT
                    End If
            End Select
            Return nextLogStatus
        End Function

        Private Shared Function GetAttendanceDate(newAttendanceStatus As Integer, newAttendanceDate As Date, lastAttendanceStatus As Integer, lastAttendanceTime As Date, lastAttendanceDate As Date) As Date
            'IF 
            If newAttendanceStatus = AttendanceStatusChoices.TIME_OUT AndAlso lastAttendanceStatus = AttendanceStatusChoices.TIME_IN Then '
                Dim timeDifference As Integer = (Now - lastAttendanceTime).TotalHours
                Dim dayDifference As Integer = CInt(newAttendanceDate.ToString("yyyyMMdd")) - CInt(lastAttendanceDate.ToString("yyyyMMdd"))
                If timeDifference <= 24 AndAlso dayDifference > 0 Then 'If the timedifference exceeds 24 hours and the day change, use the previous day
                    newAttendanceDate = newAttendanceDate.AddDays(-1)
                End If
            ElseIf newAttendanceStatus = AttendanceStatusChoices.TIME_OUT AndAlso lastAttendanceStatus = AttendanceStatusChoices.TIME_OUT Then
                'IF THE NEW ATTENDANCE STATUS RESULTED TO AN OUT AND THE LAST ATTENDANCE IS ALSO AN OUT, COPY THE LOG DATE OF THE LAST ATTENDANCE
                newAttendanceDate = lastAttendanceDate
            End If

            If newAttendanceStatus = AttendanceStatusChoices.TIME_IN AndAlso (CInt(Now.ToString("HHmm")) >= 2331) Then 'If time exceeds 11:30PM, Consider the logdate as the next day.
                newAttendanceDate = newAttendanceDate.AddDays(1)
            End If


            Return newAttendanceDate
        End Function


        Private Shared Function GetLatestAttendance(databaseManager As utility_service.Manager.Mysql, ee_id As String, Optional logStatus As Integer = -1) As Model.Attendance
            Dim attendance As New Model.Attendance
            Dim query As String = String.Format("SELECT * FROM `attendance` WHERE `ee_id`='{0}' ORDER BY `time` DESC LIMIT 1", ee_id)

            If logStatus > -1 Then query = String.Format("SELECT * FROM `attendance` WHERE `ee_id`='{0}' and logstatus={1} ORDER BY `time` DESC LIMIT 1", ee_id, logStatus)

            Using reader As MySqlDataReader = databaseManager.ExecuteDataReader(query)
                If reader.HasRows Then
                    reader.Read()
                    attendance = New Model.Attendance(reader)
                    'attendance.EE_Id = reader.Item("ee_id")
                    'attendance.LogStatus = reader.Item("logstatus")
                    'attendance.SendStatus = reader.Item("status")
                    'attendance.TimeStamp = reader.Item("time")
                    'attendance.LogDate = reader.Item("date")
                End If
            End Using
            Return attendance
        End Function


        Private Shared Function FillAttendanceAPIPostData(databaseManager As utility_service.Manager.Mysql, attendance As Model.Attendance)
            Dim apiLogDetail As New AttendanceAPIPostData
            apiLogDetail.EmployeeID = attendance.EE_Id
            apiLogDetail.LogDate = attendance.LogDate.ToString("yyyy-MM-dd")
            If attendance.LogStatus = 0 Then
                apiLogDetail.Timein = ToTimeString(Now)
            ElseIf attendance.LogStatus = 1 Then
                Dim previousAttendance As Model.Attendance = GetLatestAttendance(databaseManager, attendance.EE_Id, AttendanceStatusChoices.TIME_IN)
                apiLogDetail.Timein = ToTimeString(previousAttendance.TimeStamp)
                apiLogDetail.Timeout = ToTimeString(Now)
            End If
            Return apiLogDetail
        End Function

        Private Shared Function GetAttendance(databaseManager As utility_service.Manager.Mysql, attendanceName As String) As Model.Attendance
            Dim attendance As Model.Attendance = Nothing
            Dim query As String = String.Format("SELECT * FROM `attendance` WHERE `attendance_name`='{0}' LIMIT 1", attendanceName)

            Using reader As MySqlDataReader = databaseManager.ExecuteDataReader(query)
                If reader.HasRows Then
                    reader.Read()
                    attendance = New Model.Attendance
                    attendance.EE_Id = reader.Item("ee_id")
                    attendance.LogStatus = reader.Item("logstatus")
                    attendance.SendStatus = reader.Item("status")
                    attendance.TimeStamp = Date.Parse(reader.Item("time"))
                    attendance.LogDate = Date.Parse(reader.Item("date"))
                End If
            End Using

            Return attendance
        End Function

        Private Shared Sub InsertAttendance(databaseManager As utility_service.Manager.Mysql, attendance As Model.Attendance, employee As Model.Employee)
            Try
                Dim currentAttendance As Model.Attendance = GetAttendance(databaseManager, attendance.Attendance_Name)
                If currentAttendance Is Nothing OrElse currentAttendance.TimeStamp <> attendance.TimeStamp Then
                    Dim command As New MySqlCommand()

                    command = New MySqlCommand("insert into `attendance_send_log` (argument_summary)values(@argument_summary)", databaseManager.Connection)
                    If currentAttendance IsNot Nothing AndAlso currentAttendance.TimeStamp <> attendance.TimeStamp Then
                        command.Parameters.AddWithValue("argument_summary", String.Format("{0} {4} log was overwritten: from {1:yyyy-MM-dd HH:mm:ss} to {2:yyyy-MM-dd HH:mm:ss} in logdate {3:yyyy-MM-dd}.", attendance.EE_Id, currentAttendance.TimeStamp, attendance.TimeStamp, attendance.LogDate, attendance.LogStatus))
                    Else
                        command.Parameters.AddWithValue("argument_summary", String.Format("{0} new {3} log was added: {1:yyyy-MM-dd HH:mm:ss} in logdate {2:yyyy-MM-dd}.", attendance.EE_Id, attendance.TimeStamp, attendance.LogDate, attendance.LogStatus))
                    End If
                    command.ExecuteNonQuery()

                    Dim query As String = "INSERT INTO `attendance`(ee_id,`date`,`name`,`time`,logstatus,status,attendance_name) VALUES(@ee_id,@date,@name,@time,@logstatus,@status,@attendance_name) ON DUPLICATE KEY UPDATE ee_id=@ee_id, `date`=@date, `name`=@name, `time`=@time, logstatus=@logstatus, status=@status;"

                    command = New MySqlCommand(query, databaseManager.Connection)
                    command.Parameters.AddWithValue("ee_id", attendance.EE_Id)
                    command.Parameters.AddWithValue("date", attendance.LogDate)
                    command.Parameters.AddWithValue("name", employee.FullName)
                    command.Parameters.AddWithValue("time", attendance.TimeStamp.ToString("yyyy-MM-dd HH:mm:00"))
                    command.Parameters.AddWithValue("logstatus", attendance.LogStatus)
                    command.Parameters.AddWithValue("status", 0)
                    command.Parameters.AddWithValue("attendance_name", attendance.Attendance_Name)
                    command.ExecuteNonQuery()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error occured while inserting attendance.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Console.WriteLine(ex.Message)
            End Try
        End Sub

        Private Shared Sub InsertAttendanceSendQueue(databaseManager As utility_service.Manager.Mysql, attendance As Model.Attendance)
            Try
                Dim apiLogDetail As AttendanceAPIPostData = FillAttendanceAPIPostData(databaseManager, attendance)

                Dim args = JsonConvert.SerializeObject(apiLogDetail, Formatting.Indented)

                Dim command As New MySqlCommand("insert into `attendance_send_queue` (argument,argument_summary)values(@argument,@argument_summary)", databaseManager.Connection)
                command.Parameters.AddWithValue("argument", args)
                command.Parameters.AddWithValue("argument_summary", String.Format("{0} worked from {1} to {2} in logdate {3}.", apiLogDetail.EmployeeID, apiLogDetail.Timein, apiLogDetail.Timeout, apiLogDetail.LogDate))

                command.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error occured while inserting attendance on queue.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Console.WriteLine(ex.Message)
            End Try
        End Sub


        Private Shared Function ToTimeString(value As Date) As String
            Return value.ToString("yyyy-MM-dd HH:mm:00")
        End Function
#End Region

        Public Enum AttendanceStatusChoices
            TIME_IN = 0
            TIME_OUT = 1
        End Enum

        Public Class AttendanceAPIPostData
            Public EmployeeID As String

            Public _type As String = "Send"

            Public Property encrypted_data As String
                Get
                    Return encrypt(LogDate)
                End Get
                Set(value As String)

                End Set
            End Property
            Public LogDate As String


            Private _timein As String
            Public Property Timein As String
                Get
                    If _timein <> Nothing And _timein <> "" Then
                        Return _timein
                    Else : Return "null"
                    End If
                End Get
                Set(value As String)
                    _timein = value
                End Set
            End Property

            Private _timeout As String
            Public Property Timeout As String
                Get
                    If _timeout <> Nothing And _timeout <> "" Then
                        Return _timeout
                    Else : Return "null"
                    End If
                End Get
                Set(value As String)
                    _timeout = value
                End Set
            End Property

            Public Shared Function encrypt(val As String) As String
                Dim newVal As String = ""
                For i As Integer = 0 To val.Length - 1
                    Dim v As String = val(i)
                    If Char.IsNumber(v) Then
                        newVal &= Chr(Asc(val(i)) + CInt(v))
                    Else
                        newVal &= Chr(Asc(val(i)) + 3)
                    End If
                Next
                Return newVal
            End Function
        End Class


        Public Class AttendanceRequest
            Public from As String
            Public _type As String
            Public Property encrypted_data As String
                Get
                    Return encrypt(from)
                End Get
                Set(value As String)

                End Set
            End Property
            Private Function encrypt(val As String) As String
                Dim newVal As String = ""
                For i As Integer = 0 To val.Length - 1
                    Dim v As String = val(i)
                    If Char.IsNumber(v) Then
                        newVal &= Chr(Asc(val(i)) + CInt(v))
                    Else
                        newVal &= Chr(Asc(val(i)) + 3)
                    End If
                Next
                Return newVal
            End Function
        End Class

        Public Class AttendanceFromServer
            Public id_number As String
            Public log_date As String
            Public original_time_in As String
            Public original_time_out As String
            Public edited_time_in As String
            Public edited_time_out As String

            Public ReadOnly Property new_time_in As String
                Get
                    If edited_time_in = "0000-00-00 00:00:00" Then
                        Return original_time_in
                    Else : Return edited_time_in
                    End If
                End Get
            End Property

            Public ReadOnly Property new_time_out As String
                Get
                    If edited_time_out = "0000-00-00 00:00:00" Then
                        Return original_time_out
                    Else : Return edited_time_out
                    End If
                End Get
            End Property

            Public ReadOnly Property no_time_in As Boolean
                Get
                    Return new_time_in = "0000-00-00 00:00:00"
                End Get
            End Property
            Public ReadOnly Property no_time_out As Boolean
                Get
                    Return new_time_out = "0000-00-00 00:00:00"
                End Get
            End Property



        End Class

    End Class
End Namespace
