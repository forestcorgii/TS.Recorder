Imports System.Net.Http
Imports System.Windows.Forms
Imports Newtonsoft.Json

Namespace Manager
    Namespace API
        Public Class UPSG
            Private Client As New HttpClient
            Public APIUrl As String
            Public token As String
            Public action As String
            Public site As SiteChoices

            Sub New()
                Client = New HttpClient
                Client.Timeout = TimeSpan.FromSeconds(30)
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
                    If response.IsSuccessStatusCode Then
                        Return {response.IsSuccessStatusCode, responseString}
                    Else
                        Select Case response.StatusCode
                            Case 404
                                Throw New Exception(String.Format("Page not Found.", response.StatusCode.ToString))
                                'MessageBox.Show("Page not Found.", response.StatusCode.ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Case Else
                                Throw New Exception(String.Format(responseString, response.StatusCode.ToString))
                                'MessageBox.Show(responseString, response.StatusCode.ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Select
                    End If
                Catch ex As Exception
                    Throw New Exception(String.Format(ex.Message, "SendTimelog"))
                    'MessageBox.Show(ex.Message, "SendTimelog UPSG", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

                Return Nothing
            End Function
        End Class

        Public Enum SiteChoices
            LEYTE
            MANILA
        End Enum
    End Namespace

End Namespace
