Public Class ThongTinMHDTO
    Private _maMH As Int64
    Private _tenMH As String
    Private _donGia As Int64
    Private _dvTinh As String
    Public Sub New()
        _maMH = 0
        _donGia = 0
        _dvTinh = ""
        _tenMH = ""
    End Sub
    Public Sub New(maMH As Int64, tenMH As String, donGia As Int64, dvTinh As String)
        _maMH = maMH
        _donGia = donGia
        _dvTinh = dvTinh
        _tenMH = tenMH
    End Sub
    Property MaMH As Int64
        Get
            Return _maMH
        End Get
        Set(value As Int64)
            _maMH = value
        End Set
    End Property
    Property DonGia As Int64
        Get
            Return _donGia
        End Get
        Set(value As Int64)
            _donGia = value
        End Set
    End Property
    Property DVTinh As String
        Get
            Return _dvTinh
        End Get
        Set(value As String)
            _dvTinh = value
        End Set
    End Property
    Property TenMH As String
        Get
            Return _tenMH
        End Get
        Set(value As String)
            _tenMH = value
        End Set
    End Property

End Class
