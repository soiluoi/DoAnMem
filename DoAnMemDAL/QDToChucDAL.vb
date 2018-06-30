Imports System.Data.SqlClient
Imports DoAnMemDTO
Imports Utility
Public Class QDToChucDAL
    Dim cnString As String = ConnectionString()
    Public Function loadQCToChuc(ByRef QDTC As QDToChucDTO) As Boolean
        Dim query As String = String.Empty
        query &= " SELECT SOLOAIDL,SODLMAX,SLMH,SLQUAN"
        query &= " FROM QDTOCHUC"
        Using conn As New SqlConnection(cnString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If reader.HasRows = True Then
                        While reader.Read()
                            QDTC = New QDToChucDTO(reader("SOLOAIDL"), reader("SODLMAX"), reader("SLMH"), reader("SLQUAN"))
                        End While
                    End If
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    Return False
                End Try
            End Using
        End Using
        Return True
    End Function
    Public Function update(dl As QDToChucDTO) As Boolean
        Dim query As String = String.Empty
        query &= "UPDATE QDTOCHUC SET"
        query &= " SOLOAIDL= " & dl.SoLoaiDL
        query &= ",SODLMAX= " & dl.SoDLMax
        query &= ",SLMH= " & dl.SLMH
        query &= ",SLQUAN= " & dl.SoQuan
        Using conn As New SqlConnection(cnString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    Return False
                End Try
            End Using
        End Using
        Return True
    End Function
End Class
