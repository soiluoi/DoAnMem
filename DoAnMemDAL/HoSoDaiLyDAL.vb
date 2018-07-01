
Imports System.Data.SqlClient
Imports DoAnMemDTO
Imports Utility
Public Class HoSoDaiLyDAL
    Dim cnString As String = ConnectionString()

    Public Function insertDL(dl As HoSoDaiLyDTO) As Result
        Dim query As String = String.Empty
        query &= "INSERT INTO DAILY"
        query &= "(  MADL "
        query &= "  ,TENDL "
        query &= "  ,MALOAIDL "
        query &= "  ,DIACHI"
        query &= "  ,MAQUAN"
        query &= "  ,SDT "
        query &= "  ,EMAIL "
        query &= "  ,NGAYTN "
        query &= "  ,TIENNO) "
        query &= "VALUES "
        query &= "(   @madl"
        query &= "   ,@tendl"
        query &= "   ,@maloaidl"
        query &= "   ,@diachi"
        query &= "   ,@maquan"
        query &= "   ,@sdt"
        query &= "   ,@email"
        query &= "   ,@ngaytn"
        query &= "   ,@tienno)"
        Dim nextmaDL As Int16
        Dim result As Result
        result = getNextID(nextmaDL, "MADL", "DAILY")
        If result.FlagResult = False Then
            Return result
        End If
        dl.MaDL = nextmaDL
        Using conn As New SqlConnection(cnString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@madl", dl.MaDL)
                    .Parameters.AddWithValue("@tendl", dl.TenDL)
                    .Parameters.AddWithValue("@maloaidl", dl.MaLoaiDL)
                    .Parameters.AddWithValue("@diachi", dl.DiaChi)
                    .Parameters.AddWithValue("@maquan", dl.MaQuan)
                    .Parameters.AddWithValue("@sdt", dl.SDT)
                    .Parameters.AddWithValue("@email", dl.Email)
                    .Parameters.AddWithValue("@ngaytn", dl.NgayTN)
                    .Parameters.AddWithValue("@tienno", dl.TienNo)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Thêm dai ly không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function
    Public Function loadQuan(listQuan As List(Of QuanDTO)) As Result
        Dim query As String = String.Empty
        query &= " SELECT MAQUAN, TENQUAN, SODL"
        query &= " FROM DSQUAN"
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
                        listQuan.Clear()
                        While reader.Read()
                            listQuan.Add(New QuanDTO(reader("MAQUAN"), reader("TENQUAN"), reader("SODL")))
                        End While
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Load quan khong thanh cong", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
    Public Function loadSoDL(ByRef sodl As Int64, maQuan As Int64) As Boolean
        Dim query As String = String.Empty
        query &= " SELECT COUNT(*)"
        query &= " FROM DSQUAN"
        query &= " WHERE MAQUAN=" & maQuan
        Using conn As New SqlConnection(cnString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                End With
                Try
                    conn.Open()
                    sodl = comm.ExecuteScalar()
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
    Public Function loadLoaiDL(listLoaiDL As List(Of LoaiDLDTO)) As Result
        Dim query As String = String.Empty
        query &= " SELECT MALOAIDL, TENLOAIDL"
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
                            listLoaiDL.Add(New LoaiDLDTO(reader("MALOAIDL"), reader("TENLOAIDL"), 0))
                        End While
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Load Loại đại lý không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
    Public Function loadDL(ByRef listDL As List(Of HoSoDaiLyDTO)) As Boolean
        Dim query As String = String.Empty
        query &= " SELECT MADL,TENDL,TENLOAIDL,DIACHI,TENQUAN,SDT,EMAIL,NGAYTN,TIENNO"
        query &= " FROM DAILY DL,DSQUAN Q,LOAIDL L"
        query &= " WHERE DL.MALOAIDL=L.MALOAIDL AND DL.MAQUAN=Q.MAQUAN"
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
                        listDL.Clear()
                        While reader.Read()
                            listDL.Add(New HoSoDaiLyDTO(reader("MADL"), reader("TENDL"), reader("TENLOAIDL"), reader("DIACHI"), reader("TENQUAN"), reader("SDT"), reader("EMAIL"), reader("NGAYTN"), reader("TIENNO")))
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
    Public Function deleteDL(maDL As Int64, maQuan As Int64) As Result
        Dim query As String = String.Empty
        query &= "delete DAILY WHERE MADL = " & maDL

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
                    Return New Result(False, "Xóa đại lý không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function
    Public Function updateDL(dl As HoSoDaiLyDTO) As Result
        Dim query As String = String.Empty
        query &= "UPDATE DAILY SET"
        query &= " TENDL= N'" & dl.TenDL & "'"
        query &= ",MALOAIDL= " & dl.MaLoaiDL
        query &= ",DIACHI= N'" & dl.DiaChi & "'"
        query &= ",MAQUAN= " & dl.MaQuan
        query &= ",SDT= '" & dl.SDT & "'"
        query &= ",EMAIL= '" & dl.Email & "'"
        query &= ",NGAYTN= '" & dl.NgayTN & "'"
        query &= " WHERE MADL = " & dl.MaDL
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
                    Return New Result(False, "Xóa đại lý không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function
    Public Function ganNo(tien As Int64, madl As Int64) As Boolean
        Dim query As String = String.Empty
        query &= "UPDATE DAILY SET"
        query &= " TIENNO= " & tien
        query &= " WHERE MADL = " & madl
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
