Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports Newtonsoft.Json
Imports utility_service

Namespace Controller
    Public Class Employee
        Public Shared Function GetEmployee(databaseManager As utility_service.Manager.Mysql, employee_id As String) As Model.Employee
            Dim employee As Model.Employee = Nothing
            Using reader As MySqlDataReader = databaseManager.ExecuteDataReader(String.Format("SELECT * FROM faces_schema.employee WHERE employee_id='{0}' LIMIT 1", employee_id))
                If reader.HasRows Then
                    reader.Read()
                    employee = New Model.Employee(reader)
                End If
            End Using
            Return employee
        End Function

        Public Shared Function CollectEmployees(databaseManager As utility_service.Manager.Mysql) As List(Of Model.Employee)
            Dim employees As New List(Of Model.Employee)
            Using reader As MySqlDataReader = databaseManager.ExecuteDataReader("SELECT * FROM faces_schema.employee")
                'Collect the Users
                While reader.Read
                    employees.Add(New Model.Employee(reader))
                End While
            End Using

            ' Create subjects from selected templates
            For i As Integer = 0 To employees.Count - 1
                With employees.Item(i)
                    If .Active Then
                        If .FaceImage_1 IsNot Nothing Then .FaceImage_1.Id = .Employee_Id & "_1"
                        If .FaceImage_2 IsNot Nothing Then .FaceImage_2.Id = .Employee_Id & "_2"
                        If .FaceImage_3 IsNot Nothing Then .FaceImage_3.Id = .Employee_Id & "_3"
                    End If
                End With
            Next i
            Return employees
        End Function

        Public Shared Sub SaveEmployee(databaseManager As utility_service.Manager.Mysql, employee As Model.Employee)
            Try
                Dim cmd As New MySqlCommand()
                cmd.Connection = databaseManager.Connection
                With cmd.Parameters
                    .Add("@owner", MySqlDbType.String).Value = employee.owner
                    .Add("@id", MySqlDbType.MediumBlob).Value = employee.id
                    .Add("@firstname", MySqlDbType.String).Value = employee.first_name
                    .Add("@lastname", MySqlDbType.String).Value = employee.last_name
                    .Add("@middlename", MySqlDbType.String).Value = employee.middle_name
                    .Add("@employee_id", MySqlDbType.String).Value = employee.Employee_Id
                    .Add("@department", MySqlDbType.String).Value = employee.department
                    .Add("@company", MySqlDbType.String).Value = employee.company
                    .Add("@schedule", MySqlDbType.String).Value = employee.schedule
                    .Add("@project", MySqlDbType.String).Value = employee.project
                    .Add("@admin", MySqlDbType.String).Value = employee.admin

                    If employee.NoFaceImage = False Then
                        .Add("@active", MySqlDbType.String).Value = employee.Active
                        .Add("@face_img1", MySqlDbType.Binary).Value = employee.face_data1
                        .Add("@face_img2", MySqlDbType.Binary).Value = employee.face_data2
                        .Add("@face_img3", MySqlDbType.Binary).Value = employee.face_data3
                    Else : .Add("@active", MySqlDbType.String).Value = False
                        .Add("@face_img1", MySqlDbType.Binary).Value = Nothing
                        .Add("@face_img2", MySqlDbType.Binary).Value = Nothing
                        .Add("@face_img3", MySqlDbType.Binary).Value = Nothing
                    End If
                End With
                Dim qry As String

                Dim existingUserID As Integer = -1
                Dim rdr As MySqlDataReader
                rdr = databaseManager.ExecuteDataReader("SELECT * FROM faces_schema.employee WHERE `employee_id` = '" & employee.Employee_Id & "'")
                If rdr.HasRows Then
                    rdr.Read()
                    existingUserID = rdr.Item("id")
                End If
                rdr.Close()

                If existingUserID > 0 Then
                    qry = "UPDATE faces_schema.employee SET `employee_id`=@employee_id, `firstname`=@firstname, `lastname`=@lastname, `middlename`=@middlename, `project`=@project, `department`=@department," _
                    & " `company`=@company, `schedule`=@schedule, `admin`=@admin, `active`=@active, `face_img1`=@face_img1, `face_img2`=@face_img2, `face_img3`=@face_img3, `owner`=@owner WHERE `id`=@id"
                Else
                    qry = "REPLACE INTO faces_schema.employee (`id`,`firstname`,`lastname`,`middlename`,`employee_id`,`project`,`department`,`company`,`schedule`,`admin`,`active`,`face_img1`,`face_img2`,`face_img3`,`owner`)" _
                        & "VALUES(@id,@firstname,@lastname,@middlename,@employee_id,@project,@department,@company,@schedule,@admin,@active,@face_img1,@face_img2,@face_img3,@owner)"
                End If

                cmd.CommandText = qry
                cmd.ExecuteNonQuery()
            Catch ex As Exception

            End Try
        End Sub

        Sub New(mysql As Configuration.Mysql)
            Dim bin As String = "" 'New DirectoryInfo(Application.StartupPath).Parent.FullName
            Dim conf As String = bin & "\conf\"

            'mngr = mysql

            'Time_Recorder_API = New EmployeeSyncClasses.TimeUser_API

            'StartSync()
        End Sub


        Public Class EmployeeSyncPostData
            Public site As String
            Public terminal As String
            Public employees As List(Of Model.Employee)
        End Class
        Public Shared Async Function SendEmployeeToServer(databaseManager As utility_service.Manager.Mysql, employeeAPIManager As Manager.API.Employee) As Task(Of Integer)
            Dim EmployeeRecords As New List(Of Model.Employee)

            Dim lastSynced As Date = Nothing
            Using reader As MySqlDataReader = databaseManager.ExecuteDataReader("SELECT * FROM faces_schema.employee_sync_log WHERE `request_type` = 'POST' AND `succeeded` = 1 ORDER BY `exec_datetime` DESC LIMIT 1;")
                While reader.Read
                    lastSynced = reader.Item("exec_datetime")
                End While
            End Using

            Dim success As Boolean = True
            Dim postMessage As String = "POST Request Succeeded"
            Try 'POST
                'get newly Updated USERS
                Dim owner As String = Environment.GetEnvironmentVariable("USERDOMAIN")
                Using reader As MySqlDataReader = databaseManager.ExecuteDataReader(String.Format("SELECT * FROM faces_schema.employee WHERE `owner` = '{0}' AND `date_modified` > '{1}'", owner, lastSynced.ToString("yyyy-MM-dd HH:mm:ss")))
                    While reader.Read
                        EmployeeRecords.Add(New Model.Employee(reader))
                    End While
                End Using

                If EmployeeRecords.Count > 0 Then
                    postMessage = "Employees Sent Count: " & EmployeeRecords.Count

                    Dim postData As New EmployeeSyncPostData
                    With postData
                        .site = employeeAPIManager.site
                        .terminal = employeeAPIManager.terminal
                        .employees = EmployeeRecords
                    End With
                    Dim dataString As String = JsonConvert.SerializeObject(postData, Formatting.Indented)

                    Await employeeAPIManager.SendSyncPOSTRequest(dataString)
                Else
                End If
            Catch ex As Exception
                postMessage = "POST Request Failed due to an Exception"
                success = False
                Return 0
            End Try

            databaseManager.ExecuteNonQuery(String.Format("INSERT INTO faces_schema.employee_sync_log (`description`,`request_type`,`succeeded`) VALUES ('{0}','{1}',{2});", postMessage, "POST", success))

            Return EmployeeRecords.Count
        End Function

        Public Shared Async Function GetEmployeeFromServer(databaseManager As utility_service.Manager.Mysql, employeeAPIManager As Manager.API.Employee) As Task(Of Integer)
            'get last GET Sync Request date
            Dim EmployeeRecords As New List(Of Model.Employee)
            Dim lastSynced As Date = Nothing
            Using reader As MySqlDataReader = databaseManager.ExecuteDataReader(String.Format("SELECT * FROM faces_schema.employee_sync_log WHERE `request_type` = 'GET' AND `succeeded` = 1 ORDER BY `exec_datetime` DESC LIMIT 1;"))
                While reader.Read
                    lastSynced = reader.Item("exec_datetime")
                End While
            End Using

            Dim success As Boolean = True
            Dim getMessage As String = "GET Request Succeeded"

            Try 'GET
                EmployeeRecords = JsonConvert.DeserializeObject(Of Model.Employee())(Await employeeAPIManager.SendSyncGETRequest(lastSynced)).ToList
                If EmployeeRecords.Count > 0 Then
                    For i As Integer = 0 To EmployeeRecords.Count - 1
                        SaveEmployee(databaseManager, EmployeeRecords(i))
                    Next
                End If
                success = True
            Catch ex As Exception
                success = False
                getMessage = "GET Request Failed due to an Exception"
                Console.WriteLine(ex.Message)
            End Try

            databaseManager.ExecuteNonQuery(String.Format("INSERT INTO faces_schema.employee_sync_log (`description`,`request_type`,`succeeded`) VALUES ('{0}','{1}',{2});", getMessage, "GET", success))

            Return EmployeeRecords.Count
        End Function
    End Class

End Namespace
