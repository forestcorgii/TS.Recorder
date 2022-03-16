Imports MySql.Data.MySqlClient

Namespace Model
    Public Class Settings
        Public Name As String
        Public JSON_Arguments As String

        Sub New()

        End Sub

        Sub New(reader As MySqlDataReader)
            Name = reader("name")
            JSON_Arguments = reader("json_argument")
        End Sub
    End Class

End Namespace
