Imports System.Data.SqlClient
Imports DoAnMemDTO
Imports Utility

Public Class ChiTietXHDAL
    Dim cnString As String = ConnectionString()
    Public Function cancel(maP As Int64) As Boolean
        Dim query As String = String.Empty
        query &= "delete CHITIETXUATHANG WHERE MAPXH = " & maP
        query &= " delete PHIEUXUATHANG WHERE MAPXH = " & maP
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
    Public Function load(ByRef listCT As List(Of ChiTietXHDTO), maP As Int64) As Boolean
        Dim query As String = String.Empty
        query &= " SELECT MH.MAMH,MH.TENMH,MH.DONVITINH, CT.SOLUONG, MH.DONGIA, CT.THANHTIEN"
        query &= " FROM MATHANG MH,CHITIETXUATHANG CT"
        query &= " WHERE MH.MAMH=CT.MAMH AND CT.MAPXH= " & maP
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
                        listCT.Clear()
                        While reader.Read()
                            listCT.Add(New ChiTietXHDTO(reader("MAMH"), reader("TENMH"), reader("DONVITINH"), reader("SOLUONG"), reader("DONGIA"), reader("THANHTIEN")))
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
    Public Function insertP(ByRef dl As PXuatHangDTO) As Boolean
        Dim query As String = String.Empty
        query &= "INSERT INTO PHIEUXUATHANG"
        query &= "(  MAPXH "
        query &= "  ,MADL "
        query &= "  ,NGAYLAPPHIEU) "
        query &= "VALUES "
        query &= "(   @mapxh"
        query &= "   ,@madl"
        query &= "   ,@ngaylp)"
        Dim nextmaDL As Int16
        Dim result As Result
        result = getNextID(nextmaDL, "MAPXH", "PHIEUXUATHANG")
        If result.FlagResult = False Then
            Return False
        End If
        dl.MaP = nextmaDL
        Using conn As New SqlConnection(cnString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@mapxh", dl.MaP)
                    .Parameters.AddWithValue("@madl", dl.MaDL)
                    .Parameters.AddWithValue("@ngaylp", dl.NgayLap)
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
    Public Function insertCTP(dl As ChiTietXHDTO) As Boolean
        Dim query As String = String.Empty
        query &= "INSERT INTO CHITIETXUATHANG (MAMH,MAPXH,SOLUONG,THANHTIEN)"
        query &= " VALUES (@mamh,@map,@soluong,@thanhtien)"

        Using conn As New SqlConnection(cnString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@mamh", dl.MaMH)
                    .Parameters.AddWithValue("@map", dl.MaP)
                    .Parameters.AddWithValue("@soluong", dl.SL)
                    .Parameters.AddWithValue("@thanhtien", dl.ThanhTien)
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
    Public Function delete(maP As Int64, maMH As Int64) As Boolean
        Dim query As String = String.Empty
        query &= "delete CHITIETXUATHANG WHERE MAPXH = " & maP & " AND MAMH=" & maMH
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
    Public Function update(dl As ChiTietXHDTO) As Boolean
        Dim query As String = String.Empty
        query &= "UPDATE CHITIETXUATHANG SET"
        query &= " SOLUONG= " & dl.SL
        query &= " ,THANHTIEN= " & dl.ThanhTien
        query &= " WHERE MAMH= " & dl.MaMH & " and MAPXH=" & dl.MaP
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
