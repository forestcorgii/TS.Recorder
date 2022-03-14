Imports MySql.Data.MySqlClient

Namespace Model
    Public Class AttendanceLog
        Public Argument As String
        Public TimeStamp As Date
        Public Argument_Summary As String

        Sub New(reader As MySqlDataReader)
            Argument = reader.Item("argument")
            TimeStamp = reader.Item("timestamp")
            Argument_Summary = reader.Item("argument_summary")
        End Sub
    End Class

End Namespace
