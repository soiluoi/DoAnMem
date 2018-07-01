Public Class ChiTietXHDTO
    Private _maMH As Int64
    Private _maP As Int64
    Private _sl As Int64
    Private _thanhtien As Int64
    Private _tenMH As String
    Private _dvt As String
    Private _donGia As Int64
    Public Sub New()
        _maMH = 0
        _maP = 0
        _sl = 0
        _thanhtien = 0
        _tenMH = ""
        _dvt = ""
        _donGia = 0
    End Sub
    Public Sub New(maMH As Int64, maP As Int64, sl As Int64, thanhtien As Int64)
        _maMH = maMH
        _maP = maP
        _sl = sl
        _thanhtien = thanhtien
    End Sub
    Public Sub New(maMH As Int64, tenMh As String, dvTinh As String, sl As Int64, donGia As Int64, thanhtien As Int64)
        _maMH = maMH
        _maP = MaP
        _sl = sl
        _thanhtien = thanhtien
        _tenMH = tenMh
        _dvt = dvTinh
        _donGia = donGia
    End Sub

    Public Property MaMH As Int64
        Get
            Return _maMH
        End Get
        Set(value As Int64)
            _maMH = value
        End Set
    End Property
    Public Property MaP As Int64
        Get
            Return _maP
        End Get
        Set(value As Int64)
            _maP = value
        End Set
    End Property
    Public Property SL As Int64
        Get
            Return _sl
        End Get
        Set(value As Int64)
            _sl = value
        End Set
    End Property
    Public Property ThanhTien As Int64
        Get
            Return _thanhtien
        End Get
        Set(value As Int64)
            _thanhtien = value
        End Set
    End Property
    Public Property DonGia As Int64
        Get
            Return _donGia
        End Get
        Set(value As Int64)
            _donGia = value
        End Set
    End Property
    Public Property DVT As String
        Get
            Return _dvt
        End Get
        Set(value As String)
            _dvt = value
        End Set
    End Property

    Public Property TenMH As String
        Get
            Return _tenMH
        End Get
        Set(value As String)
            _tenMH = value
        End Set
    End Property
End Class
