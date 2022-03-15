

Imports Neurotec.Biometrics
Imports Neurotec.IO
Imports Newtonsoft.Json
Imports VerilookLib2.Interface_
Imports hrms_api_service.IInterface
Namespace Model

    Public Class Employee
        Implements IFace, IEmployee

        Public Property id As Integer
        Public Property first_name As String Implements IEmployee.first_name
        Public Property last_name As String Implements IEmployee.last_name
        Public Property middle_name As String Implements IEmployee.middle_name
        Public Property department As String Implements IEmployee.department
        Public Property company As String = ""
        Public Property schedule As String
        Public Property project As String
        Public Property admin As Boolean = False
        Public Property owner As String = ""
        Public Property Active As Boolean Implements IFace.Active
        Public Property Employee_Id As String Implements IFace.Employee_Id, IEmployee.idno

        Public Property tin As String Implements IEmployee.tin
        Public Property bank_name As String Implements IEmployee.bank_name
        Public Property bank_category As String Implements IEmployee.bank_category
        Public Property account_number As String Implements IEmployee.account_number
        Public Property card_number As String Implements IEmployee.card_number
        Public Property payroll_code As String Implements IEmployee.payroll_code
        Public Property jobcode As String Implements IEmployee.jobcode


        Public Property face_data1 As Byte() Implements IFace.face_data1
        Public Property face_data2 As Byte() Implements IFace.face_data2
        Public Property face_data3 As Byte() Implements IFace.face_data3

        Public Property FaceImage_1 As NSubject Implements IFace.FaceImage_1
        Public Property FaceImage_2 As NSubject Implements IFace.FaceImage_2
        Public Property FaceImage_3 As NSubject Implements IFace.FaceImage_3


#Region "for API use"
        Public Property face_data1_string As String
            Get
                Return String.Join(" ", face_data1)
            End Get
            Set(value As String)

            End Set
        End Property
        Public Property face_data2_string As String
            Get
                Return String.Join(" ", face_data2)
            End Get
            Set(value As String)

            End Set
        End Property
        Public Property face_data3_string As String
            Get
                Return String.Join(" ", face_data3)
            End Get
            Set(value As String)

            End Set
        End Property
#End Region


#Region "Public Properties"


        <JsonIgnore> Public ReadOnly Property NoFaceImage As Boolean
            Get
                Return face_data1 Is Nothing Or face_data2 Is Nothing Or face_data3 Is Nothing
            End Get
        End Property

        <JsonIgnore> Public ReadOnly Property FullName As String
            Get
                Return String.Format("{0}, {1} {2}.", last_name, first_name, MI)
            End Get
        End Property

        <JsonIgnore> Public ReadOnly Property MI As String
            Get
                If middle_name = "" Then Return ""
                Return middle_name.Substring(0, 1)
            End Get
        End Property



        Public Overrides Function ToString() As String
            Return Employee_Id
        End Function
#End Region

        Sub New()
        End Sub

        Sub New(rdr As MySql.Data.MySqlClient.MySqlDataReader)
            id = rdr("id")
            first_name = rdr("firstname")
            last_name = rdr("lastname")
            middle_name = rdr("middlename")
            Employee_Id = rdr("employee_id")
            admin = rdr("admin")
            Active = rdr("active")

            owner = rdr("owner")
            Dim f1 = rdr("face_img1")
            Dim f2 = rdr("face_img2")
            Dim f3 = rdr("face_img3")

            If IsDBNull(f1) = False Then
                face_data1 = f1
                FaceImage_1 = NSubject.FromMemory(NBuffer.FromArray(face_data1))
            End If
            If IsDBNull(f2) = False Then
                face_data2 = f2
                FaceImage_2 = NSubject.FromMemory(NBuffer.FromArray(face_data2))
            End If
            If IsDBNull(f3) = False Then
                face_data3 = f3
                FaceImage_3 = NSubject.FromMemory(NBuffer.FromArray(face_data3))
            End If

        End Sub



    End Class
End Namespace