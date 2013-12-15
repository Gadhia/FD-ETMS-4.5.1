Imports Microsoft.VisualBasic
Namespace Forg.ETMS

    Public Class UC_Base
        Inherits System.Web.UI.UserControl

#Region "Delegate and EventHandler"
        Delegate Sub AddEditClick_EventHandler(ByVal sender As Object, ByVal e As System.EventArgs)
        Event AddEditClick As AddEditClick_EventHandler
        Protected Sub OnAddEditClick(ByVal sender As Object, ByVal e As System.EventArgs)
            RaiseEvent AddEditClick(sender, e)
        End Sub
#End Region



    End Class
End Namespace