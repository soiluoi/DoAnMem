Public Class HoSoDaiLyDTO
    Private _maQuan As Int64
    Private _tenQuan As String
    Private _tienNo As Int64
    Private _soDL As Int64
    Private _maDL As Int64
    Private _tenDL As String
    Private _maLoaiDL As Int64
    Private _diaChi As String
    Private _sdt As String
    Private _email As String
    Private _ngayTN As String
    Private _tenLoaiDL As String
    Public Sub New()
        _maDL = 1
        _tenDL = "Dai ly 1"
        _maQuan = 1
        _maLoaiDL = 1
        _tienNo = 0
    End Sub
    Public Sub New(maDL As Int64, tenDL As String, maLoaiDL As Int64, maQuan As Int64)
        _maDL = maDL
        _tenDL = tenDL
        _maLoaiDL = maLoaiDL
        _maDL = maQuan
        _tienNo = 0
    End Sub
    'Public Sub New(maDL As Int64, tenDL As String, maLoaiDL As Int64, diaChi As String, maQuan As Int64, sdt As String, email As String, ngayTN As String, tienNo As Int64)
    '    _maDL = maDL
    '    _tenDL = tenDL
    '    _maQuan = maQuan
    '    _diaChi = diaChi
    '    _sdt = sdt
    '    _maLoaiDL = maLoaiDL
    '    _email = email
    '    _ngayTN = ngayTN
    '    _tienNo = tienNo
    'End Sub
    Public Sub New(maDL As Int64, tenDL As String, tenLoaiDL As String, diaChi As String, tenQuan As String, sdt As String, email As String, ngayTN As String, tienNo As Int64)
        _maDL = maDL
        _tenDL = tenDL
        _tenQuan = tenQuan
        _diaChi = diaChi
        _sdt = sdt
        _tenLoaiDL = tenLoaiDL
        _email = email
        _ngayTN = ngayTN
        _tienNo = tienNo
    End Sub

    Public Property MaQuan As Int64
        Get
            Return _maQuan
        End Get
        Set(ByVal Value As Int64)
            _maQuan = Value
        End Set
    End Property
    Public Property TenDL As String
        Get
            Return _tenDL
        End Get
        Set(ByVal Value As String)
            _tenDL = Value
        End Set
    End Property
    Public Property MaDL As Int64
        Get
            Return _maDL
        End Get
        Set(ByVal Value As Int64)
            _maDL = Value
        End Set
    End Property
    Public Property MaLoaiDL As Int64
        Get
            Return _maLoaiDL
        End Get
        Set(ByVal Value As Int64)
            _maLoaiDL = Value
        End Set
    End Property
    Public Property DiaChi As String
        Get
            Return _diaChi
        End Get
        Set(ByVal Value As String)
            _diaChi = Value
        End Set
    End Property
    Public Property SDT As String
        Get
            Return _sdt
        End Get
        Set(ByVal Value As String)
            _sdt = Value
        End Set
    End Property
    Public Property Email As String
        Get
            Return _email
        End Get
        Set(ByVal Value As String)
            _email = Value
        End Set
    End Property
    Public Property NgayTN As String
        Get
            Return _ngayTN
        End Get
        Set(ByVal Value As String)
            _ngayTN = Value
        End Set
    End Property
    Public Property TenLoaiDL As String
        Get
            Return _tenLoaiDL
        End Get
        Set(ByVal Value As String)
            _tenLoaiDL = Value
        End Set
    End Property
    Public Property TenQuan As String
        Get
            Return _tenQuan
        End Get
        Set(ByVal Value As String)
            _tenQuan = Value
        End Set
    End Property
    Public Property TienNo As Int64
        Get
            Return _tienNo
        End Get
        Set(ByVal Value As Int64)
            _tienNo = Value
        End Set
    End Property
End Class
