Imports DoAnMemDAL
Imports DoAnMemDTO
Imports Utility
Public Class PXuatHangBUS
    Dim dlDAL As HoSoDaiLyDAL
    Dim mhDAl As ThongTinMHDAL
    Dim ctDAL As ChiTietXHDAL
    Dim ldlDAL As LoaiDLDAL
    Dim ldl As List(Of LoaiDLDTO)
    Public Sub New()
        dlDAL = New HoSoDaiLyDAL
        mhDAl = New ThongTinMHDAL
        ctDAL = New ChiTietXHDAL
        ldlDAL = New LoaiDLDAL
        ldl = New List(Of LoaiDLDTO)
        ldlDAL.loadLoaiDL(ldl)
    End Sub
    Public Function ktTienNo(tien As Int64, tenLDL As String) As Result
        Dim i As Int64 = 0
        While ldl.Item(i).TenLoaiDL <> tenLDL
            i += 1
        End While
        If tien > ldl.Item(i).TienNoMax Then
            Return New Result(False, "Tiền nợ quá giới hạn. Vui lòng kiểm tra lại")
        End If
        Return New Result()
    End Function
    Public Function ganNo(tien As Int64, madl As Int64) As Result
        Return New Result(dlDAL.ganNo(tien, madl))
    End Function
    Public Function taoP(ByRef p As PXuatHangDTO) As Result
        Return New Result(ctDAL.insertP(p))
    End Function
    Public Function checkinfo(p As ChiTietXHDTO) As Result
        If p.SL <= 0 Then
            Return New Result(False, "Số lượng chưa đúng. Vui lòng kiểm tra lại")
        End If
        Return New Result()
    End Function
    Public Function loadCTXH(ctxh As List(Of ChiTietXHDTO), mP As Int64) As Result
        Return New Result(ctDAL.load(ctxh, mP))
    End Function
    Public Function insert(ct As ChiTietXHDTO) As Result
        Return New Result(ctDAL.insertCTP(ct))
    End Function
    Public Function delete(maP As Int64, maMH As Int64) As Result
        Return New Result(ctDAL.delete(maP, maMH))
    End Function
    Public Function update(ct As ChiTietXHDTO) As Result
        Return New Result(ctDAL.update(ct))
    End Function
    Public Function cancel(maP As Int64) As Result
        Return New Result(ctDAL.cancel(maP))
    End Function
    Public Function loadCBB(ByRef dl As List(Of HoSoDaiLyDTO), ByRef mh As List(Of ThongTinMHDTO)) As Result
        Dim rsdl As Boolean = dlDAL.loadDL(dl)
        If rsdl = False Then
            Return New Result(rsdl, "Load danh sách đại lý không thành công")
        End If
        Dim rsmh As Boolean = mhDAl.load(mh)
        If rsmh = False Then
            Return New Result(rsmh, "Load danh sách mặt hàng không thành công ")
        End If
        If dl.Count = 0 Then
            Return New Result(False, "Không có đại lý nào tồn tại")
        End If
        If mh.Count = 0 Then
            Return New Result(False, "Không có mặt hàng nào tồn tại")
        End If
        Return New Result()
    End Function
End Class
