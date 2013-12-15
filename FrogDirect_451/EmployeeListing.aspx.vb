Imports Forg.ETMS

Partial Class EmployeeListing
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

    Protected Sub gvEmployee_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvEmployee.RowDataBound
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(0).Text += "              ( " + "<img src='Img/yes.gif' style='width: 14px; height: 13px' />" + " - Passed, "
            e.Row.Cells(0).Text += "<img src='Img/no.gif' style='width: 15px; height: 15px' />" + "- Pending,"
            e.Row.Cells(0).Text += "  Click on a course to change a status ) "
        End If

        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim _EmployeeCourse1 As Controls_EmployeeCourse = CType(e.Row.FindControl("EmployeeCourse1"), Controls_EmployeeCourse)
            If _EmployeeCourse1 IsNot Nothing Then
                Dim _EmpCourses As New List(Of EmployeeCourse)
                _EmpCourses = CType(e.Row.DataItem, Employee).EmpCourses
                _EmployeeCourse1.EmpCourses = _EmpCourses
            End If
            Helper.AddAttributesToRow(e.Row, "#fffaaa")
        End If
    End Sub

End Class
