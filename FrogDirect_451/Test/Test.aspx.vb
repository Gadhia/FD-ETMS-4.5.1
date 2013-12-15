Imports Forg.ETMS
Partial Class Test_Test
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim es As New List(Of Employee)
        es = EmployeeData.Employee_Select_All

        For i As Integer = 0 To es.Count - 1
            'EmployeeData.Employee_All_Courses_Insert(es(i).EmployeeID)
        Next

    End Sub
End Class
