Imports DoAnMemDAL
Imports DoAnMemDTO
Imports Utility
Public Class HoSoDaiLyBUS
    Private dlDAL As HoSoDaiLyDAL
    Private qdtcDAL As QDToChucDAL
    Dim qdtc As QDToChucDTO
    Public Sub New()
        dlDAL = New HoSoDaiLyDAL
        qdtcDAL = New QDToChucDAL
        qdtc = New QDToChucDTO
        qdtcDAL.loadQCToChuc(qdtc)
    End Sub
    Public Function insertDL(dl As HoSoDaiLyDTO) As Result
        Return dlDAL.insertDL(dl)
    End Function
    Public Function loadQuan(listQuan As List(Of QuanDTO)) As Result
        Return dlDAL.loadQuan(listQuan)
    End Function
    Public Function loadDL(ByRef listDL As List(Of HoSoDaiLyDTO)) As Result
        Return dlDAL.loadDL(listDL)
    End Function
    Public Function loadLoaiDL(listLoaiDL As List(Of LoaiDLDTO)) As Result
        Return dlDAL.loadLoaiDL(listLoaiDL)
    End Function
    Public Function isFull(maQuan As Int64) As Boolean
        Try
            Dim sodl As Int64
            dlDAL.loadSoDL(sodl, maQuan)
            If (sodl >= qdtc.SoDLMax) Then
                Return True
            End If
        Catch ex As Exception
        End Try
        Return False
    End Function
    Public Function checkinfo(dl As HoSoDaiLyDTO) As Boolean
        Return dl.TenDL.Length > 0
    End Function
    Public Function deleteDL(madl As Int64, maQuan As Int64) As Result
        Return dlDAL.deleteDL(madl, maQuan)
    End Function
    Public Function updateDL(dl As HoSoDaiLyDTO) As Result
        Return dlDAL.updateDL(dl)
    End Function
End Class

