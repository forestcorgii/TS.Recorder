Imports System.Net.Http
Imports Newtonsoft.Json

Namespace Manager
    Namespace API
        Public Class UPSG
            Private Client As New HttpClient
            Public APIUrl As String '= "http://idcsi-officesuites.com:8082/upsg/bio_api/API_Receiver"
            Public token As String
            Public action As String
            Public site As SiteChoices

            Sub New()
                Client = New HttpClient
                Client.Timeout = TimeSpan.FromSeconds(10)
            End Sub

            Public Async Function SendTimelog(ee_id As String, timeStamp As Date) As Task(Of Object())
                Try
                    Dim values As New Dictionary(Of String, String)
                    values.Add("token", token)
                    values.Add("action", action)
                    values.Add("site", site.ToString)
                    values.Add("bio_id", ee_id)
                    values.Add("added_ts", timeStamp.ToString("yyyy-MM-dd HH:mm:ss"))

                    Dim content As New FormUrlEncodedContent(values)

                    Dim response As HttpResponseMessage = Await Client.PostAsync(APIUrl, content)
                    Dim responseString As String = Await response.Content.ReadAsStringAsync()

                    Return {response.IsSuccessStatusCode, responseString}
                Catch ex As Exception
                    Return {False, ""}
                End Try
            End Function

        End Class
        Public Enum SiteChoices
            LEYTE
            MANILA
        End Enum
    End Namespace

End Namespace
