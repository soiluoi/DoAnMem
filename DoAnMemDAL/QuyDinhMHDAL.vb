Imports System.Data.SqlClient
Imports DoAnMemDTO
Imports Utility
Public Class QuyDinhMHDAL
    Dim cnString As String = ConnectionString()
    Public Function load(ByRef mh As List(Of QuyDinhMHDTO)) As Boolean
        Dim query As String = String.Empty
        query &= " SELECT QD.MAMH,TENMH,DONVITINH, DONGIA "
        query &= " FROM QDMATHANG QD, MATHANG MH"
        query &= " WHERE QD.MAMH=MH.MAMH"
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
                    If reader.HasRows Then
                        mh.Clear()
                        While reader.Read()
                            mh.Add(New QuyDinhMHDTO(reader("MAMH"), reader("TENMH"), reader("DONVITINH"), reader("DONGIA")))
                        End While
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return False
                End Try
            End Using
        End Using
        Return True
    End Function
    Public Function update(dl As QuyDinhMHDTO) As Boolean
        Dim query As String = String.Empty
        query &= "UPDATE QDMATHANG SET"
        query &= ",DONGIA= " & dl.DonGia
        query &= ",DONVITINH= '" & dl.DVTinh & "'"
        query &= "WHERE MAMH= " & dl.MaMH
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
