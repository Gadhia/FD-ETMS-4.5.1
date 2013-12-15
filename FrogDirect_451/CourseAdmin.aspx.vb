Imports Forg.ETMS

Partial Class CourseAdmin
    Inherits System.Web.UI.Page

#Region "Handler for Delegate and EventHandler"

    Private Sub AddEditItems1_AddEditClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Course1.AddEditClick
        Me.getData()
    End Sub

#End Region

    Private Sub getData()
        Me.gvCourse.DataSource = Forg.ETMS.CourseData.Course_Select_All
        Me.gvCourse.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.getData()
        End If
    End Sub

    Protected Sub gvCourse_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvCourse.RowCommand
        Dim _CourseID As Integer = CType(e.CommandArgument, Integer)
        Select Case e.CommandName
            Case "myDelete"
                CourseData.Course_Delete(_CourseID)
                Me.getData()
            Case "mySelect"
                Dim _Course As New Course
                _Course = CourseData.Course_Select(_CourseID)
                Me.Course1.Course = _Course
        End Select
    End Sub

    Protected Sub gvCourse_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvCourse.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim _lbDelete As LinkButton = CType(e.Row.FindControl("lbDelete"), LinkButton)
            Dim _CourseID As Integer = CInt(_lbDelete.CommandArgument)
            Dim _Count As Integer = EmployeeCourseData.EmployeeCourse_AssigneCount(_CourseID)
            If _Count > 0 Then
                _lbDelete.Attributes.Add("onclick", _
             "alert(""This course cannot delete as it already assigned!""); return false;")
            Else
                _lbDelete.Attributes.Add("onclick", _
                 "return confirm(""Are you sure you wish to delete this record?"")")
            End If
            Helper.AddAttributesToRow(e.Row, "#fffaaa")
        End If
    End Sub

End Class
