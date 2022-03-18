
Imports System.Text.RegularExpressions
Imports time_recorder_service
Imports utility_service
Imports hrms_api_service
Imports upsg_api_service
Imports face_recognition_service

Module SharedObject



    Public HRMSAPIManager As Manager.API.HRMS
    Public UPSGAPIManager As Manager.API.UPSG
    Public AttendanceAPIManager As Manager.API.Attendance
    Public FaceProfileAPIManager As Manager.API.FaceProfile

    Public DatabaseManager As Manager.Mysql
    Public DatabaseConfiguration As Configuration.Mysql

    Public FaceRecognitionManager As Manager.FaceRecognition


    Public Function IsConnectedToInternet() As Boolean
        Dim host As Net.IPAddress = Net.IPAddress.Parse("8.8.8.8")
        Dim result As Boolean = False
        Dim p As New Net.NetworkInformation.Ping
        Try
            Dim reply As Net.NetworkInformation.PingReply = p.Send(host, 500)
            If reply.Status = Net.NetworkInformation.IPStatus.Success Then
                Return True
            End If
        Catch ex As Exception
        End Try
        Return False
    End Function

End Module
