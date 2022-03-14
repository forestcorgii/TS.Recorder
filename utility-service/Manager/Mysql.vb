Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Namespace Manager
    Public Class Mysql
        Public Connection As New MySqlConnection
        Public config As Configuration.Mysql


        Public Sub New()

        End Sub
        Public Sub New(_config As Configuration.Mysql)
            config = _config
            Connection = config.ToMysqlConnection
        End Sub

        Public Sub Close()
            Connection.Close()
            Connection.Dispose()
            GC.Collect()
            GC.WaitForPendingFinalizers()
        End Sub

        Public Function ExecuteDataReader(sql As String) As MySqlDataReader
            Return New MySqlCommand(sql, Connection).ExecuteReader
        End Function

        Public Sub ExecuteNonQuery(ByVal sql As String)
            Dim cmd As MySqlCommand
            cmd = New MySqlCommand(sql, Connection)
            cmd.ExecuteNonQuery()
        End Sub
    End Class

End Namespace
