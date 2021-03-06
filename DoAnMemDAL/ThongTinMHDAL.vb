﻿Imports System.Data.SqlClient
Imports DoAnMemDTO
Imports Utility
Public Class ThongTinMHDAL
    Dim cnString As String = ConnectionString()

    Public Function load(ByRef mh As List(Of ThongTinMHDTO)) As Boolean
        Dim query As String = String.Empty
        query &= " SELECT MAMH,TENMH,DONGIA, DONVITINH "
        query &= " FROM  MATHANG "
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
                            mh.Add(New ThongTinMHDTO(reader("MAMH"), reader("TENMH"), reader("DONGIA"), reader("DONVITINH")))
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
    Public Function update(dl As ThongTinMHDTO) As Boolean
        Dim query As String = String.Empty
        query &= "UPDATE MATHANG SET"
        query &= " TENMH= N'" & dl.TenMH & "'"
        query &= ",DONGIA= " & dl.DonGia
        query &= ",DONVITINH= '" & dl.DVTinh & "'"
        query &= " WHERE MAMH= " & dl.MaMH
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
    Public Function soMH(ByRef num As Int64) As Boolean
        Dim query As String = String.Empty
        query &= " SELECT count(*)"
        query &= " FROM MATHANG"
        Using conn As New SqlConnection(cnString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                End With
                Try
                    conn.Open()
                    num = comm.ExecuteScalar()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return False
                End Try
            End Using
        End Using
        ' thanh cong
        Return True
    End Function
    Public Function insertMH(dl As ThongTinMHDTO) As Result
        Dim query As String = String.Empty
        query &= "INSERT INTO MATHANG"
        query &= "(MAMH , TENMH, DONGIA,DONVITINH)"
        query &= " VALUES "
        query &= " (@mamh,@tenmh,@dongia,@dvtinh)"
        Dim nextID As Int16
        Dim result As Result
        result = getNextID(nextID, "MAMH", "MATHANG")
        If result.FlagResult = False Then
            Return result
        End If
        dl.MaMH = nextID
        Using conn As New SqlConnection(cnString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@mamh", dl.MaMH)
                    .Parameters.AddWithValue("@tenmh", dl.TenMH)
                    .Parameters.AddWithValue("@dongia", dl.DonGia)
                    .Parameters.AddWithValue("@dvtinh", dl.DVTinh)

                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Thêm mặt hàng không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function
    Public Function delete(ID As Int64) As Boolean
        Dim query As String = String.Empty
        query &= "delete MATHANG WHERE MAMH = " & ID
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
End Class
