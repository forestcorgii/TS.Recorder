Imports System.Net.Http
Imports MySql.Data.MySqlClient
Imports Newtonsoft.Json
Imports utility_service
Namespace Manager
    Namespace API

        Public Class Attendance

            Public ApiUrl As String

            Private Client As New HttpClient

            Sub New()
                ApiUrl = Environment.GetEnvironmentVariable("TIMELOG_SYNC_API_URL")
                If ApiUrl = "" Then
                    Throw New Exception("Set TIMELOG_SYNC_API_URL.")
                End If
            End Sub

            Public Async Function RequestUpdateAsync(logdate As String) As Task(Of Object())
                Try
                    Dim l As New Controller.Attendance.AttendanceRequest With {.from = logdate, ._type = "Sync"}

                    Dim postData As String = JsonConvert.SerializeObject(l, Formatting.Indented)
                    Dim values As New Dictionary(Of String, String)
                    values.Add("postData", postData)

                    Dim content As New FormUrlEncodedContent(values)

                    Dim response As HttpResponseMessage = Await Client.PostAsync(ApiUrl, content)
                    Dim responseString As String = Await response.Content.ReadAsStringAsync()

                    Return {response.IsSuccessStatusCode, responseString}
                Catch ex As Exception
                    Return {False, ""}
                End Try
            End Function

            Public Async Function SendTimelog(args As String) As Task(Of Object())
                Try
                    Dim values As New Dictionary(Of String, String)
                    values.Add("postData", args)

                    Dim content As New FormUrlEncodedContent(values)

                    Dim response As HttpResponseMessage = Await Client.PostAsync(ApiUrl, content)
                    Dim responseString As String = Await response.Content.ReadAsStringAsync()

                    Return {response.IsSuccessStatusCode, responseString}
                Catch ex As Exception
                    Return {False, ""}
                End Try
            End Function
        End Class

    End Namespace
End Namespace