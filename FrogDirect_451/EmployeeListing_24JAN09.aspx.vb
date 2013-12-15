Imports Forg.ETMS

Partial Class EmployeeListing_24JAN09
    Inherits System.Web.UI.Page

    Private Sub getData()
        Me.gvEmployee.DataSource = Forg.ETMS.EmployeeData.Employee_Select_All
        Me.gvEmployee.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.getData()
        End If
    End Sub

    'Protected Overrides Function OnBubbleEvent(ByVal source As Object, ByVal e As EventArgs) As Boolean
    '    'Not used
    'End Function

    Protected Sub gvEmployee_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvEmployee.RowDataBound
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(0).Text += " ( " + "<img src='Img/yes.gif' style='width: 14px; height: 13px' />" + " - Passed, "
            e.Row.Cells(0).Text += "<img src='Img/no.gif' style='width: 15px; height: 15px' />" + "- Pending )"
        End If

        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim dlEmployeeCourse As DataList = CType(e.Row.FindControl("dlEmployeeCourse"), DataList)
            If dlEmployeeCourse IsNot Nothing Then
                Dim es As New List(Of EmployeeCourse)
                es = CType(e.Row.DataItem, Employee).EmpCourses
                dlEmployeeCourse.DataSource = es
                dlEmployeeCourse.DataBind()
            End If
            Helper.AddAttributesToRow(e.Row, "#fffaaa")
        End If

    End Sub
End Class
