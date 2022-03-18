Imports MySql.Data.MySqlClient
Imports Newtonsoft.Json

Namespace Model

    Public Class Attendance
        Public EE_Id As String
        Public Employee As Employee
        Public Name As String
        Public ReadOnly Property Attendance_Name As String
            Get
                Return String.Format("{0}_{1:yyyyMMdd}_{2}", EE_Id, LogDate, LogStatus)
            End Get
        End Property


        Public LogDate As Date
        Public TimeStamp As Date

        Public LogStatus As Controller.Attendance.AttendanceStatusChoices
        Public SendStatus As Integer

        Sub New()

        End Sub

        Sub New(_employee_id As String)
            EE_Id = _employee_id
        End Sub
        Sub New(reader As MySqlDataReader)
            EE_Id = reader("ee_id")
            Name = reader.Item("name")
            LogDate = reader.Item("date")
            TimeStamp = reader.Item("time")
            LogStatus = reader.Item("logstatus")
            SendStatus = reader.Item("status")
        End Sub
    End Class

End Namespace
