Imports DoAnMemDAL
Imports DoAnMemDTO
Imports Utility
Public Class QDToChucBUS
    Dim tc As QDToChucDAL
    Public Sub New()
        tc = New QDToChucDAL
    End Sub
    Public Function update(qd As QDToChucDTO) As Result
        Return New Result(tc.update(qd))
    End Function
    Public Function checkinfo(qd As QDToChucDTO) As Result

    End Function
    Public Function load(ByRef qd As QDToChucDTO) As Result
        Return New Result(tc.loadQCToChuc(qd))
    End Function
End Class
