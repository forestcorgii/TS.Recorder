Imports MySql.Data.MySqlClient
Imports Newtonsoft.Json

Namespace Controller
    Public Class FaceProfile

        Public Shared Function Find(databaseManager As utility_service.Manager.Mysql, ee_id As String) As Model.FaceProfile
            Dim faceProfile As Model.FaceProfile = Nothing
            Using reader As MySqlDataReader = databaseManager.ExecuteDataReader(String.Format("SELECT * FROM face_profile WHERE id='{0}' LIMIT 1", ee_id))
                If reader.HasRows Then
                    reader.Read()
                    faceProfile = New Model.FaceProfile(reader)
                End If
            End Using
            Return faceProfile
        End Function

        Public Shared Function Collect(databaseManager As utility_service.Manager.Mysql) As List(Of Model.FaceProfile)
            Dim faceProfiles As New List(Of Model.FaceProfile)
            Using reader As MySqlDataReader = databaseManager.ExecuteDataReader("SELECT * FROM face_profile")
                While reader.Read
                    faceProfiles.Add(New Model.FaceProfile(reader))
                End While
            End Using

            ' Create subjects from selected templates
            For i As Integer = 0 To faceProfiles.Count - 1
                With faceProfiles.Item(i)
                    If .Active Then
                        If .FaceImage_1 IsNot Nothing Then .FaceImage_1.Id = .EE_Id & "_1"
                    End If
                End With
            Next i
            Return faceProfiles
        End Function

        Public Shared Sub Save(databaseManager As utility_service.Manager.Mysql, employee As Model.FaceProfile, Optional owner As String = "")
            Try
                If owner <> "" Then
                    employee.Owner = owner
                End If

                Dim command As New MySqlCommand("REPLACE INTO face_profile (`id`,`admin`,`active`,`owner`,`face_img1`) VALUES(?,?,?,?,?)", databaseManager.Connection)
                command.Parameters.Add("@ee_id", MySqlDbType.MediumBlob).Value = employee.EE_Id
                command.Parameters.Add("@admin", MySqlDbType.String).Value = employee.Admin
                command.Parameters.Add("@active", MySqlDbType.String).Value = employee.Active
                command.Parameters.Add("@owner", MySqlDbType.String).Value = employee.Owner

                If employee.NoFaceImage = False Then
                    command.Parameters.Add("@face_img1", MySqlDbType.Binary).Value = employee.face_data1
                End If

                command.ExecuteNonQuery()
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End Sub

        Public Shared Sub SetFaceProfileActivation(databaseManager As utility_service.Manager.Mysql, eeId As String, isActive As Boolean)
            Try
                Dim faceProfile As Model.FaceProfile = Find(databaseManager, eeId)
                faceProfile.Active = isActive
                Save(databaseManager, faceProfile)
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End Sub



        Public Class FaceProfileSyncPostData
            Public site As String
            Public terminal As String
            Public employees As List(Of Model.FaceProfile)
        End Class
        Public Shared Async Function SaveToServer(databaseManager As utility_service.Manager.Mysql, employeeAPIManager As face_recognition_service.Manager.API.FaceProfile) As Task(Of Integer)
            Dim EmployeeRecords As New List(Of Model.FaceProfile)

            Dim success As Boolean = False
            Dim postMessage As String = ""
            Dim startTimestamp As Date = Now

            Try 'POST
                Dim lastSynced As Date = Nothing
                Using reader As MySqlDataReader = databaseManager.ExecuteDataReader("SELECT * FROM face_profile_sync_log WHERE `request_type` = 'POST' AND `succeeded` = 1 ORDER BY `exec_datetime` DESC LIMIT 1;")
                    While reader.Read
                        lastSynced = reader.Item("exec_datetime")
                    End While
                End Using

                'get newly Updated USERS
                Using reader As MySqlDataReader = databaseManager.ExecuteDataReader(String.Format("SELECT * FROM face_profile WHERE `owner` = '{0}' AND `date_modified` > '{1}'", employeeAPIManager.Terminal, lastSynced.ToString("yyyy-MM-dd HH:mm:ss")))
                    While reader.Read
                        EmployeeRecords.Add(New Model.FaceProfile(reader))
                    End While
                End Using

                If EmployeeRecords.Count > 0 Then
                    Dim postData As New FaceProfileSyncPostData
                    With postData
                        .site = employeeAPIManager.Site
                        .terminal = employeeAPIManager.Terminal
                        .employees = EmployeeRecords
                    End With
                    Dim dataString As String = JsonConvert.SerializeObject(postData, Formatting.Indented)

                    Await employeeAPIManager.SendSyncPOSTRequest_NoPrompt(dataString)

                    postMessage = "Employees Sent Count: " & EmployeeRecords.Count
                    success = True
                Else
                    postMessage = "No newly registered Employee."
                End If
            Catch ex As Exception
                postMessage = "POST Request Failed due to an Exception: " & ex.Message
            End Try

            databaseManager.ExecuteNonQuery(String.Format("INSERT INTO face_profile_sync_log (`description`,`request_type`,`succeeded`,`exec_datetime`) VALUES ('{0}','{1}',{2},'{3:yyyy-MM-dd HH:mm:ss}');", postMessage, "POST", success, startTimestamp))

            Return EmployeeRecords.Count
        End Function

        Public Shared Async Function CollectFromServer(databaseManager As utility_service.Manager.Mysql, employeeAPIManager As face_recognition_service.Manager.API.FaceProfile) As Task(Of Integer)
            'get last GET Sync Request date
            Dim EmployeeRecords As New List(Of Model.FaceProfile)

            Dim success As Boolean = False
            Dim getMessage As String = ""

            Dim startTimestamp As Date = Now
            Try 'GET
                Dim lastSynced As Date = Nothing
                Using reader As MySqlDataReader = databaseManager.ExecuteDataReader(String.Format("SELECT * FROM face_profile_sync_log WHERE `request_type` = 'GET' AND `succeeded` = 1 ORDER BY `exec_datetime` DESC LIMIT 1;"))
                    While reader.Read
                        lastSynced = reader.Item("exec_datetime")
                    End While
                End Using

                EmployeeRecords = JsonConvert.DeserializeObject(Of Model.FaceProfile())(Await employeeAPIManager.SendSyncGETRequest_NoPrompt(lastSynced)).ToList
                If EmployeeRecords.Count > 0 Then
                    For i As Integer = 0 To EmployeeRecords.Count - 1
                        Save(databaseManager, EmployeeRecords(i))
                    Next
                    success = True
                    getMessage = "Received Employee Count: " & EmployeeRecords.Count
                Else
                    getMessage = "No Employee received."
                End If
            Catch ex As Exception
                success = False
                getMessage = "GET Request Failed due to an Exception: " & ex.Message
                Console.WriteLine(ex.Message)
            End Try

            databaseManager.ExecuteNonQuery(String.Format("INSERT INTO face_profile_sync_log (`description`,`request_type`,`succeeded`,`exec_datetime`) VALUES ('{0}','{1}',{2},'{3:yyyy-MM-dd HH:mm:ss}');", getMessage, "GET", success, startTimestamp))

            Return EmployeeRecords.Count
        End Function
    End Class

End Namespace
