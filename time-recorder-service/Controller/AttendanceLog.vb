Imports MySql.Data.MySqlClient
Namespace Controller

    Public Class AttendanceLog
        Public Shared Async Function SendQueuedAttendance(databaseManager As utility_service.Manager.Mysql, AttendanceAPIManager As Manager.API.Attendance) As Task
            Dim attendances As New List(Of Object)

            Using reader As MySqlDataReader = databaseManager.ExecuteDataReader("select * from attendance_send_queue")
                If reader.HasRows Then
                    While reader.Read
                        attendances.Add(New Model.AttendanceLog(reader))
                    End While
                End If
            End Using

            For Each attendance As Model.AttendanceLog In attendances
                Dim res = Await AttendanceAPIManager.SendTimelog(attendance.Argument)
                If res(0) = True Then
                    DeleteQueuedAttendance(databaseManager, attendance)
                End If
            Next
        End Function

        Public Shared Sub DeleteQueuedAttendance(databaseManager As utility_service.Manager.Mysql, attendance As Model.AttendanceLog)
            databaseManager.ExecuteNonQuery(String.Format("DELETE FROM attendance_send_queue WHERE `timestamp`='{0}'", attendance.TimeStamp.ToString("yyyy-MM-dd HH:mm:ss")))
        End Sub
    End Class
End Namespace
