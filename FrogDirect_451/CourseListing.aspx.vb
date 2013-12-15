
Partial Class CourseListing
    Inherits System.Web.UI.Page

    Protected Sub PagerCommand(ByVal sender As Object, ByVal e As DataPagerCommandEventArgs)
        Select Case e.CommandName
            Case "Next"
                e.NewStartRowIndex = Math.Min(e.Item.Pager.StartRowIndex + e.Item.Pager.MaximumRows, e.Item.Pager.TotalRowCount - e.Item.Pager.MaximumRows)
                e.NewMaximumRows = e.Item.Pager.MaximumRows
                Exit Select
            Case "Previous"
                e.NewStartRowIndex = Math.Max(0, e.Item.Pager.StartRowIndex - e.Item.Pager.MaximumRows)
                e.NewMaximumRows = e.Item.Pager.MaximumRows
                Exit Select
            Case "Last"
                e.NewStartRowIndex = e.Item.Pager.TotalRowCount - e.Item.Pager.MaximumRows
                e.NewMaximumRows = e.Item.Pager.MaximumRows
                Exit Select
            Case "First"
                e.NewStartRowIndex = 0
                e.NewMaximumRows = e.Item.Pager.MaximumRows
                Exit Select
        End Select

    End Sub

    Protected Sub LvSorting(ByVal sender As Object, ByVal args As ListViewSortEventArgs)
        Me.lds.OrderGroupsBy = String.Format("Key {0}", args.SortDirection)
    End Sub

    Protected Sub LvSorted(ByVal sender As Object, ByVal args As EventArgs)
        Dim btn As LinkButton = TryCast(Me.lvCourse.FindControl("btnSort"), LinkButton)

        If btn.CssClass.Contains("asc") Then
            btn.CssClass = btn.CssClass.Replace("asc", "desc")
        Else
            btn.CssClass = btn.CssClass.Replace("desc", "asc")
        End If
    End Sub

End Class
