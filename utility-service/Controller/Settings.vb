Imports MySql.Data.MySqlClient
Namespace Controller
    Public Class Settings
        Public Shared Function GetSettings(databaseManager As utility_service.Manager.Mysql, settingsName As String, Optional databaseName As String = "") As Model.Settings
            Dim settings As Model.Settings = Nothing
            Try
                If databaseName = "" Then
                    databaseName = databaseManager.Connection.Database
                End If

                If databaseName = "" Then 'if database name is still empty, throw an error
                    Throw New Exception("Database name is Required.")
                End If

                Using reader As MySqlDataReader = databaseManager.ExecuteDataReader(String.Format("SELECT * FROM {0}.settings WHERE name='{1}';", databaseName, settingsName))
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

        Public Shared Sub SaveSettings(databaseManager As utility_service.Manager.Mysql, settings As Model.Settings, Optional databaseName As String = "")
            Try
                If databaseName = "" Then
                    databaseName = databaseManager.Connection.Database
                End If

                If databaseName = "" Then 'if database name is still empty, throw an error
                    Throw New Exception("Database name is Required.")
                End If

                Dim command As New MySqlCommand(String.Format("REPLACE INTO {0}.settings(name,json_argument) VALUES(?,?);", databaseName), databaseManager.Connection)
                command.Parameters.AddWithValue("name", settings.Name)
                command.Parameters.AddWithValue("json_argument", settings.JSON_Arguments)
                command.ExecuteNonQuery()
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End Sub
    End Class
End Namespace
