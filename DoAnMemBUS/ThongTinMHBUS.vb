Imports DoAnMemDAL
Imports DoAnMemDTO
Imports Utility
Public Class ThongTinMHBUS
    Private ttmhDAL As ThongTinMHDAL
    Private qdtcDAL As QDToChucDAL
    Dim qdtc As QDToChucDTO
    Public Sub New()
        ttmhDAL = New ThongTinMHDAL
        qdtcDAL = New QDToChucDAL
        qdtc = New QDToChucDTO
        qdtcDAL.loadQCToChuc(qdtc)
    End Sub
    Public Function loadMH(listMH As List(Of ThongTinMHDTO)) As Result
        Return New Result(ttmhDAL.load(listMH))
    End Function
    Public Function isFull() As Result
        Try
            Dim somh As Int64 = 0
            ttmhDAL.soMH(somh)
            If (somh >= qdtc.SLMH) Then
                Return New Result(True)
            End If
        Catch ex As Exception
        End Try
        Return New Result(False)
    End Function
    Public Function checkinfo(ten As String) As Boolean
        Return ten.Length > 0
    End Function
    Public Function insertMH(mh As ThongTinMHDTO) As Result
        Return ttmhDAL.insertMH(mh)
    End Function
    Public Function updateMH(mh As ThongTinMHDTO) As Result
        Return New Result(ttmhDAL.update(mh))
    End Function
    Public Function deleteMH(ID As Int64) As Result
        Return New Result(ttmhDAL.delete(ID))
    End Function

End Class
