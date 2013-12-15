
Partial Class Controls_App_Tech_Demonstrated
    Inherits System.Web.UI.UserControl

    Public WriteOnly Property width() As Unit
        Set(ByVal value As Unit)
            Me.pnlMain.Width = value
        End Set
    End Property

End Class
