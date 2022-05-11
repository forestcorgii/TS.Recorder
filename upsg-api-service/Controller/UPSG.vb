Imports MySql.Data.MySqlClient
Imports Newtonsoft.Json

Namespace Controller
    Public Class UPSG
        Public Shared Async Function SendUPSGQueuedLogAsync(databaseManager As utility_service.Manager.Mysql, upsgAPIManager As Manager.API.UPSG) As Task(Of Boolean)
            Dim logs As New List(Of Model.UPSG)
            Try
                Using reader As MySqlDataReader = databaseManager.ExecuteDataReader("SELECT * FROM upsg_log_queue;")
                    While reader.Read
                        logs.Add(New Model.UPSG(reader))
                    End While
                End Using

                'MsgBox(logs.Count)

                For Each log As Model.UPSG In logs
                    Try
                        Dim res = Await upsgAPIManager.SendTimelog(log.EE_Id, log.TimeStamp)
                        If res(0) Then
                            'MsgBox(res(1) & res(0))
                            DeleteLogFromQueue(databaseManager, log)
                        End If
                    Catch ex As Exception
                        'MsgBox(ex.Message, Title:="inner send exception")
                        Console.WriteLine(ex.Message)
                    End Try
                Next
                Return True
            Catch ex As Exception
                'MsgBox(ex.Message, Title:="outer send exception")
                Console.WriteLine(ex.Message)
            End Try

            Return False
        End Function


        Public Shared Sub SaveLogToQueue(databaseManager As utility_service.Manager.Mysql, ee_id As String, timestamp As Date)
            Try
                Dim command As New MySqlCommand("INSERT INTO upsg_log_queue(ee_id,timestamp) VALUES(?,?);", databaseManager.Connection)
                command.Parameters.AddWithValue("p2", ee_id)
                command.Parameters.AddWithValue("p1", timestamp)
                command.ExecuteNonQuery()
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End Sub
        Public Shared Sub DeleteLogFromQueue(databaseManager As utility_service.Manager.Mysql, log As Model.UPSG)
            Try
                Dim command As New MySqlCommand("DELETE FROM upsg_log_queue WHERE timestamp=? AND ee_id=?;", databaseManager.Connection)
                command.Parameters.AddWithValue("p1", log.TimeStamp)
                command.Parameters.AddWithValue("p2", log.EE_Id)
                command.ExecuteNonQuery()
            Catch ex As Exception
                'MsgBox(ex.Message, Title:="delete query")

                Console.WriteLine(ex.Message)
            End Try
        End Sub
    End Class

End Namespace
