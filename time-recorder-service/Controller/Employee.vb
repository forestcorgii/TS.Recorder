Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports Newtonsoft.Json
Imports utility_service

Namespace Controller
    Public Class Employee
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
                Dim command As New MySqlCommand("REPLACE INTO employee (`first_name`,`last_name`,`middle_name`,`ee_id`,job_code) VALUES(?,?,?,?,?)", databaseManager.Connection)
                command.Parameters.AddWithValue("p1", employee.First_Name)
                command.Parameters.AddWithValue("p2", employee.Last_Name)
                command.Parameters.AddWithValue("p3", employee.Middle_Name)
                command.Parameters.AddWithValue("p5", employee.EE_Id)
                command.Parameters.AddWithValue("p4", employee.Jobcode)
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
