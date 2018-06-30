Public Class QuanDTO
    Private _maQuan As Int64
    Private _tenQuan As String
    Private _soDL As Int64
    Public Sub New()
        _maQuan = 1
        _tenQuan = "Quan 1"
        _soDL = 0
    End Sub
    Public Sub New(maQuan, tenQuan, soDL)
        _maQuan = maQuan
        _tenQuan = tenQuan
        _soDL = soDL
    End Sub
    Public Property MaQuan As Int64
        Get
            Return _maQuan
        End Get
        Set(value As Int64)
            _maQuan = value

        End Set
    End Property
    Public Property SoDL As Int64
        Get
            Return _soDL
        End Get
        Set(value As Int64)
            _soDL = value

        End Set
    End Property
    Public Property TenQuan As String
        Get
            Return _tenQuan
        End Get
        Set(value As String)
            _tenQuan = value

        End Set
    End Property

End Class
