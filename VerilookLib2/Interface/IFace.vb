Imports Neurotec.Biometrics

Namespace Interface_

    Public Interface IFace
        Property face_data1 As Byte()
        Property face_data2 As Byte()
        Property face_data3 As Byte()


        Property FaceImage_1 As NSubject
        Property FaceImage_2 As NSubject
        Property FaceImage_3 As NSubject

        Property Active As Boolean

        Property Employee_Id As String
    End Interface
End Namespace
