Imports MySql.Data.MySqlClient

Namespace Controller
    Public Class Employee
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="databaseManager"></param>
        ''' <param name="ee_id"></param>
        ''' <param name="shouldCompleteDetail"></param>
        ''' <param name="hrmsAPIManager">If supplied and there is no existing Employee in the Database, will find Employee using the HRMS API.</param>
        ''' <returns></returns>
        Public Shared Async Function FindAsync(databaseManager As utility_service.Manager.Mysql, ee_id As String, Optional shouldCompleteDetail As Boolean = False, Optional hrmsAPIManager As hrms_api_service.Manager.API.HRMS = Nothing) As Task(Of Model.Employee)
            Dim employee As Model.Employee = Nothing
            Using reader As MySqlDataReader = databaseManager.ExecuteDataReader(String.Format("SELECT * FROM employee WHERE ee_id='{0}' LIMIT 1", ee_id))
                If reader.HasRows Then
                    reader.Read()
                    employee = New Model.Employee(reader)
                End If
            End Using

            If employee Is Nothing Then
                Try
                    Dim employeeFound As hrms_api_service.IInterface.IEmployee = Await hrmsAPIManager.GetEmployeeFromServer_NoPrompt(ee_id)
                    If employeeFound IsNot Nothing Then
                        employee = New Model.Employee(employeeFound)
                        Save(databaseManager, New Model.Employee(employeeFound))
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                End Try
            End If

            If employee IsNot Nothing AndAlso shouldCompleteDetail Then
                CompleteDetail(databaseManager, employee)
            End If

            Return employee
        End Function
        Public Shared Function Find(databaseManager As utility_service.Manager.Mysql, ee_id As String, Optional shouldCompleteDetail As Boolean = False) As Model.Employee
            Dim employee As Model.Employee = Nothing
            Using reader As MySqlDataReader = databaseManager.ExecuteDataReader(String.Format("SELECT * FROM employee WHERE ee_id='{0}' LIMIT 1", ee_id))
                If reader.HasRows Then
                    reader.Read()
                    employee = New Model.Employee(reader)
                End If
            End Using

            If employee IsNot Nothing AndAlso shouldCompleteDetail Then
                CompleteDetail(databaseManager, employee)
            End If

            Return employee
        End Function

        Public Shared Function Collect(databaseManager As utility_service.Manager.Mysql, Optional shouldCompleteDetail As Boolean = False) As List(Of Model.Employee)
            Dim employees As New List(Of Model.Employee)
            Using reader As MySqlDataReader = databaseManager.ExecuteDataReader("SELECT * FROM employee")
                While reader.Read
                    employees.Add(New Model.Employee(reader))
                End While
            End Using

            If shouldCompleteDetail Then
                employees.ForEach(Sub(item As Model.Employee) CompleteDetail(databaseManager, item))
            End If

            Return employees
        End Function

        Public Shared Sub Save(databaseManager As utility_service.Manager.Mysql, employee As Model.Employee)
            Try
                Dim command As New MySqlCommand("INSERT INTO employee (`first_name`,`last_name`,`middle_name`,`ee_id`,job_code,lowest_matching_score) VALUES(@p1,@p2,@p3,@p5,@p4,@p6)" &
                                                "ON DUPLICATE KEY UPDATE `first_name`=@p1,`last_name`=@p2,`middle_name`=@p3,`ee_id`=@p5,job_code=@p4,lowest_matching_score=@p6;", databaseManager.Connection)
                command.Parameters.AddWithValue("p1", employee.First_Name)
                command.Parameters.AddWithValue("p2", employee.Last_Name)
                command.Parameters.AddWithValue("p3", employee.Middle_Name)
                command.Parameters.AddWithValue("p5", employee.EE_Id)
                command.Parameters.AddWithValue("p4", employee.Job_Code)
                command.Parameters.AddWithValue("p6", If(employee.Lowest_Matching_Score > 0, employee.Lowest_Matching_Score, 65))
                command.ExecuteNonQuery()
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End Sub


        Public Shared Sub CompleteDetail(databaseManager As utility_service.Manager.Mysql, employee As Model.Employee)
            Try
                employee.FaceProfile = FaceProfile.Find(databaseManager, employee.EE_Id)
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End Sub

    End Class

End Namespace
