Imports DoAnMemDAL
Imports DoAnMemDTO
Imports Utility
Public Class LoaiDLBUS
    Private loaidlDAL As LoaiDLDAL
    Public Sub New()
        loaidlDAL = New LoaiDLDAL
    End Sub
    Public Function checkinfo(ldl As LoaiDLDTO) As Result
        Return New Result(ldl.TenLoaiDL.Length > 0 And ldl.TienNoMax > 0)
    End Function
    Public Function load(ByRef ldl As List(Of LoaiDLDTO)) As Result
        Return New Result(loaidlDAL.loadLoaiDL(ldl))
    End Function
    Public Function insert(ldl As LoaiDLDTO) As Result
        Return New Result(loaidlDAL.insert(ldl))
    End Function
    Public Function delete(id As Int64) As Result
        Return New Result(loaidlDAL.delete(id))
    End Function
    Public Function update(ldl As LoaiDLDTO) As Result
        Return New Result(loaidlDAL.update(ldl))
    End Function
End Class
