
Partial Class Test_TestUC
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.EmployeeCourse1.Mode = Forg.ETMS.Helper.ControlMode.Edit
            Me.EmployeeCourse1.EmpCourses = Forg.ETMS.EmployeeCourseData.EmployeeCourse_Select_For_Employee("99099")
        End If
    End Sub

    'Protected Overrides Function OnBubbleEvent(ByVal source As Object, ByVal e As EventArgs) As Boolean

    '    'Dim args As New DataGridCommandEventArgs = CType(e, DataGridCommandEventArgs))



    '    Return True
    'End Function

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim _EmpCourses As New List(Of Forg.ETMS.EmployeeCourse)
        _EmpCourses = Me.EmployeeCourse1.EmpCourses
        Me.EmployeeCourse1.EmpCourses = _EmpCourses
    End Sub
End Class
