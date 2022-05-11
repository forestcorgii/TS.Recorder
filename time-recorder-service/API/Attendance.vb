Imports System.Net.Http
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports Newtonsoft.Json
Imports utility_service
Namespace Manager
    Namespace API

        Public Class Attendance

            Public ApiUrl As String

            Private Client As New HttpClient

            Sub New()
                Client = New HttpClient
                Client.Timeout = TimeSpan.FromSeconds(30)
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
                    If response.IsSuccessStatusCode Then
                        Return {response.IsSuccessStatusCode, responseString}
                    Else
                        Select Case response.StatusCode
                            Case 404
                                MessageBox.Show("Page not Found.", response.StatusCode.ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Case Else
                                MessageBox.Show(responseString, response.StatusCode.ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Select
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "RequestUpdateAsync", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                Return Nothing
            End Function

            Public Async Function RequestUpdateAsync_NoPrompt(logdate As String) As Task(Of Object())
                Try
                    Dim l As New Controller.Attendance.AttendanceRequest With {.from = logdate, ._type = "Sync"}

                    Dim postData As String = JsonConvert.SerializeObject(l, Formatting.Indented)
                    Dim values As New Dictionary(Of String, String)
                    values.Add("postData", postData)

                    Dim content As New FormUrlEncodedContent(values)

                    Dim response As HttpResponseMessage = Await Client.PostAsync(ApiUrl, content)
                    Dim responseString As String = Await response.Content.ReadAsStringAsync()
                    If response.IsSuccessStatusCode Then
                        Return {response.IsSuccessStatusCode, responseString}
                    Else
                        Select Case response.StatusCode
                            Case 404
                                Throw New Exception(String.Format("Page not Found.", response.StatusCode.ToString))
                            Case Else
                                Throw New Exception(String.Format(responseString, response.StatusCode.ToString))
                        End Select
                    End If
                Catch ex As Exception
                    Throw New Exception(String.Format(ex.Message, "RequestUpdateAsync"))
                End Try
                Return Nothing
            End Function

            Public Async Function SendTimelog(args As String) As Task(Of Object())
                Try
                    Dim values As New Dictionary(Of String, String)
                    values.Add("postData", args)

                    Dim content As New FormUrlEncodedContent(values)

                    Dim response As HttpResponseMessage = Await Client.PostAsync(ApiUrl, content)
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
                    'MessageBox.Show(ex.Message, "SendTimelog", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

                Return Nothing
            End Function
        End Class

    End Namespace
End Namespace