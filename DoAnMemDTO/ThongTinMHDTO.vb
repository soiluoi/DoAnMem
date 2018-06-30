Public Class ThongTinMHDTO
    Private _maMH As Int64
    Private _tenMH As String
    Public Sub New()
        _maMH = 1
        _tenMH = ""
    End Sub
    Public Sub New(maMH As Int64, tenMH As String)
        _maMH = maMH
        _tenMH = tenMH
    End Sub
    Public Property MaMH As Int64
        Get
            Return _maMH
        End Get
        Set(value As Int64)
            _maMH = value
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
