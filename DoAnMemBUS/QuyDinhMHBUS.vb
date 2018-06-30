Imports DoAnMemDAL
Imports DoAnMemDTO
Imports Utility
Public Class QuyDinhMHBUS
    Private qdmhDAL As QuyDinhMHDAL
    Public Sub New()
        qdmhDAL = New QuyDinhMHDAL
    End Sub
    Public Function load(ByRef mh As List(Of QuyDinhMHDTO)) As Result
        Return New Result(qdmhDAL.load(mh))
    End Function
End Class
