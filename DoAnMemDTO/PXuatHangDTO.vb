Public Class PXuatHangDTO
    Private _maP As Int64
    Private _maDL As Int64
    Private _ngayLap As String
    Public Sub New()
        _maDL = 0
        _maP = 0
        _ngayLap = ""
    End Sub
    Public Sub New(maP As Int64, maDL As Int64, ngayLap As String)
        _maP = maP
        _maDL = maDL
        _ngayLap = ngayLap
    End Sub
    Public Property MaDL As Int64
        Get
            Return _maDL
        End Get
        Set(value As Int64)
            _maDL = value
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
    Public Property NgayLap As String
        Get
            Return _ngayLap
        End Get
        Set(value As String)
            _ngayLap = value
        End Set
    End Property
End Class
