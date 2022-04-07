

Imports hrms_api_service.IInterface
Imports Newtonsoft.Json
Namespace Model

    Public Class Employee
        Public FaceProfile As FaceProfile

        Public Property EE_Id As String
        Public Property First_Name As String
        Public Property Last_Name As String
        Public Property Middle_Name As String

        Public Property Job_Code As String

        Public Property Lowest_Matching_Score As Integer

        <JsonIgnore> Public ReadOnly Property FullName As String
            Get
                Return String.Format("{0}, {1} {2}.", Last_Name, First_Name, MI)
            End Get
        End Property

        <JsonIgnore> Public ReadOnly Property MI As String
            Get
                If Middle_Name = "" Then Return ""
                Return Middle_Name.Substring(0, 1)
            End Get
        End Property


        Public Overrides Function ToString() As String
            Return EE_Id
        End Function

        Sub New()
        End Sub

        Sub New(rdr As MySql.Data.MySqlClient.MySqlDataReader)
            EE_Id = rdr("ee_id")

            First_Name = rdr("first_name")
            Last_Name = rdr("last_name")
            Middle_Name = rdr("middle_name")

            Job_Code = rdr("job_code")
            Lowest_Matching_Score = rdr("lowest_matching_score")
        End Sub

        Sub New(emp As IEmployee)
            EE_Id = emp.ee_id

            First_Name = emp.first_name
            Last_Name = emp.last_name
            Middle_Name = emp.middle_name

            Job_Code = emp.jobcode
        End Sub

    End Class
End Namespace