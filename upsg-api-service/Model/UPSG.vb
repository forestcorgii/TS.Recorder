Imports MySql.Data.MySqlClient

Namespace Model
    Public Class UPSG
        Public EE_Id As String
        Public TimeStamp As Date

        Sub New()

        End Sub
        Sub New(reader As MySqlDataReader)
            EE_Id = reader("EE_Id")
            TimeStamp = reader("timestamp")
        End Sub
    End Class

End Namespace
