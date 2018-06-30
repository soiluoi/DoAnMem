Public Class QDToChucDTO
    Private _soLoaiDL As Int64
    Private _soDLMax As Int64
    Private _slMH As Int64
    Private _soQuan As Int64
    Public Sub New()
        _soLoaiDL = 2
        _soDLMax = 4
        _slMH = 5
        _soQuan = 20
    End Sub
    Public Sub New(soLoaiDL As Int64, soDLMax As Int64, slMH As Int64, soQuan As Int64)
        _soLoaiDL = soLoaiDL
        _soDLMax = soDLMax
        _slMH = slMH
        _soQuan = soQuan
    End Sub
    Public Property SoLoaiDL As Int64
        Get
            Return _soLoaiDL
        End Get
        Set(value As Int64)
            _soLoaiDL = value
        End Set
    End Property
    Public Property SoDLMax As Int64
        Get
            Return _soDLMax
        End Get
        Set(value As Int64)
            _soDLMax = value
        End Set
    End Property
    Public Property SLMH As Int64
        Get
            Return _slMH
        End Get
        Set(value As Int64)
            _slMH = value
        End Set
    End Property
    Public Property SoQuan As Int64
        Get
            Return _soQuan
        End Get
        Set(value As Int64)
            _soQuan = value
        End Set
    End Property
End Class
