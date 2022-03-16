Imports MySql.Data.MySqlClient
Namespace Controller
    Public Class Settings
        Public Shared Function GetSettings(databaseManager As utility_service.Manager.Mysql, settingsName As String) As Model.Settings
            Dim settings As Model.Settings = Nothing
            Try
                Using reader As MySqlDataReader = databaseManager.ExecuteDataReader(String.Format("SELECT * FROM settings WHERE name='{0}';", settingsName))
                    If reader.HasRows Then
                        reader.Read()
                        settings = New Model.Settings(reader)
                    End If
                End Using
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
            Return settings
        End Function

        Public Shared Sub SaveSettings(databaseManager As utility_service.Manager.Mysql, settings As Model.Settings)
            Try
                Dim command As New MySqlCommand("REPLACE INTO settings(name,json_argument) VALUES(?,?);", databaseManager.Connection)
                command.Parameters.AddWithValue("name", settings.Name)
                command.Parameters.AddWithValue("json_argument", settings.JSON_Arguments)
                command.ExecuteNonQuery()
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End Sub
    End Class
End Namespace
