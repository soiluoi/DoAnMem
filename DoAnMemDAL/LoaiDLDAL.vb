Imports System.Data.SqlClient
Imports DoAnMemDTO
Imports Utility

Public Class LoaiDLDAL
    Dim cnString As String = ConnectionString()
    Public Function loadLoaiDL(ByRef listLoaiDL As List(Of LoaiDLDTO)) As Boolean
        Dim query As String = String.Empty
        query &= " SELECT MALOAIDL, TENLOAIDL, TIENNOMAX"
        query &= " FROM LOAIDL"
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
                        listLoaiDL.Clear()
                        While reader.Read()
                            listLoaiDL.Add(New LoaiDLDTO(reader("MALOAIDL"), reader("TENLOAIDL"), reader("TIENNOMAX")))
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
        Return True ' thanh cong
    End Function
    Public Function insert(dl As LoaiDLDTO) As Boolean
        Dim query As String = String.Empty
        query &= "INSERT INTO  LOAIDL"
        query &= "(  MALOAIDL "
        query &= "  ,TENLOAIDL "
        query &= "  ,TIENNOMAX) "
        query &= "VALUES "
        query &= "(   @maloaidl"
        query &= "   ,@tenloaidl"
        query &= "   ,@tiennomax)"
        Dim nextmaDL As Int16
        Dim result As Result
        result = getNextID(nextmaDL, "MALOAIDL", "LOAIDL")
        If result.FlagResult = False Then
            Return False
        End If
        dl.MaLoaiDL = nextmaDL
        Using conn As New SqlConnection(cnString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@maloaidl", dl.MaLoaiDL)
                    .Parameters.AddWithValue("@tenloaidl", dl.TenLoaiDL)
                    .Parameters.AddWithValue("@tiennomax", dl.TienNoMax)
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
    Public Function delete(ID As Int64) As Boolean
        Dim query As String = String.Empty
        query &= "delete LOAIDL WHERE MALOAIDL = " & ID
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
                    Return False
                End Try
            End Using
        End Using
        Return True
    End Function
    Public Function update(dl As LoaiDLDTO) As Boolean
        Dim query As String = String.Empty
        query &= "UPDATE LOAIDL SET"
        query &= " TENLOAIDL= N'" & dl.TenLoaiDL & "'"
        query &= ",MALOAIDL= " & dl.MaLoaiDL
        query &= ",TIENNOMAX= " & dl.TienNoMax
        query &= " WHERE MALOAIDL = " & dl.MaLoaiDL
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
