

Imports Neurotec.Biometrics
Imports Neurotec.IO
Imports Newtonsoft.Json


Namespace Model

    Public Class FaceProfile
        Inherits face_recognition_service.Model.FaceProfile

        Public Owner As String
        Public employee_id As String
        Public Property EE_Id As String
            Get
                If Employee_Id <> "" Then
                    Return Employee_Id
                Else
                    Return Id
                End If
            End Get
            Set(value As String)
                Id = value
            End Set
        End Property

        Sub New()
        End Sub

        Sub New(rdr As MySql.Data.MySqlClient.MySqlDataReader)
            EE_Id = rdr("id")

            Admin = rdr("admin")
            Active = rdr("active")

            Owner = rdr("owner")

            Dim f1 = rdr("face_img1")

            If IsDBNull(f1) = False Then
                face_data1 = f1
                FaceImage_1 = NSubject.FromMemory(NBuffer.FromArray(face_data1))
            End If
        End Sub


#Region "for API use"
        Public Property face_data1_string As String
            Get
                Return String.Join(" ", face_data1)
            End Get
            Set(value As String)

            End Set
        End Property

#End Region

        <JsonIgnore> Public ReadOnly Property NoFaceImage As Boolean
            Get
                Return face_data1 Is Nothing
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return EE_Id
        End Function

    End Class
End Namespace