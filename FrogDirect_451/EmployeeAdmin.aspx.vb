Imports Forg.ETMS

Partial Class EmployeeAdmin
    Inherits System.Web.UI.Page

#Region "Handler for Delegate and EventHandler"

    Private Sub AddEditItems1_AddEditClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Employee1.AddEditClick
        Me.getData()
    End Sub

#End Region

    Private Sub getData()
        Me.gvEmployee.DataSource = Forg.ETMS.EmployeeData.Employee_Select_All
        Me.gvEmployee.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.getData()
        End If
    End Sub

    Protected Sub gvEmployee_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvEmployee.RowCommand
        Dim _EmployeeID As Integer = CType(e.CommandArgument, Integer)
        Select Case e.CommandName
            Case "myDelete"
                EmployeeData.Employee_Delete(_EmployeeID)
                Me.getData()
            Case "mySelect"
                Dim _Employee As New Employee
                _Employee = EmployeeData.Employee_Select(_EmployeeID)
                Me.Employee1.Employee = _Employee
        End Select
    End Sub

    Protected Sub gvEmployee_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvEmployee.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim _lbDelete As LinkButton = CType(e.Row.FindControl("lbDelete"), LinkButton)
            _lbDelete.Attributes.Add("onclick", _
               "return confirm(""Are you sure you wish to delete this record?"")")
            Helper.AddAttributesToRow(e.Row, "#fffaaa")
        End If
    End Sub

End Class
