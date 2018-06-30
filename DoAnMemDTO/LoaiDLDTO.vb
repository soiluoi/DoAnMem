Public Class LoaiDLDTO
    Private _maLoaiDL As Int64
    Private _tenLoaiDL As String
    Private _tienNo As Int64
    Public Sub New()
        _maLoaiDL = 1
        _tenLoaiDL = "Loại 1"
        _tienNo = 0
    End Sub
    Public Sub New(maLoaiDL As Int64, tenLoaiDL As String, tienNo As Int64)
        _maLoaiDL = maLoaiDL
        _tenLoaiDL = tenLoaiDL
        _tienNo = tienNo
    End Sub
    Public Property MaLoaiDL As Int64
        Get
            Return _maLoaiDL
        End Get
        Set(value As Int64)
            _maLoaiDL = value
        End Set
    End Property
    Public Property TenLoaiDL As String
        Get
            Return _tenLoaiDL
        End Get
        Set(value As String)
            _tenLoaiDL = value
        End Set
    End Property
    Public Property TienNoMax As Int64
        Get
            Return _tienNo
        End Get
        Set(value As Int64)
            _tienNo = value
        End Set
    End Property
End Class
