Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Namespace Controller

    Public Class AttendanceLog
        Public Shared Async Function SendQueuedAttendance(databaseManager As utility_service.Manager.Mysql, AttendanceAPIManager As Manager.API.Attendance) As Task
            Dim attendances As New List(Of Object)
            Try
                Using reader As MySqlDataReader = databaseManager.ExecuteDataReader("select * from attendance_send_queue")
                    If reader.HasRows Then
                        While reader.Read
                            attendances.Add(New Model.AttendanceLog(reader))
                        End While
                    End If
                End Using

                For Each attendance As Model.AttendanceLog In attendances
                    Dim res = Await AttendanceAPIManager.SendTimelog(attendance.Argument)
                    'MsgBox(res(0) & "  " & res(1))
                    If res(0) = True Or res(1).ToString.ToUpper.Contains("MESSAGE SENT") Then
                        DeleteQueuedAttendance(databaseManager, attendance)
                    End If
                Next
            Catch ex As Exception
                Console.WriteLine(ex.Message)
                'MessageBox.Show(ex.Message, "SendQueuedAttendance", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Function

        Public Shared Sub DeleteQueuedAttendance(databaseManager As utility_service.Manager.Mysql, attendance As Model.AttendanceLog)
            Try
                databaseManager.ExecuteNonQuery(String.Format("DELETE FROM attendance_send_queue WHERE `timestamp`='{0}'", attendance.TimeStamp.ToString("yyyy-MM-dd HH:mm:ss")))
            Catch ex As Exception
                MessageBox.Show(ex.Message, "DeleteQueuedAttendance", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class
End Namespace
