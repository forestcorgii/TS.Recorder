
Imports utility_service
Imports hrms_api_service

Module SharedObject



    Public HRMSAPIManager As Manager.API.HRMS
    Public FaceProfileAPIManager As face_recognition_service.Manager.API.FaceProfile

    Public DatabaseManager As Manager.Mysql
    Public DatabaseConfiguration As Configuration.Mysql

End Module
