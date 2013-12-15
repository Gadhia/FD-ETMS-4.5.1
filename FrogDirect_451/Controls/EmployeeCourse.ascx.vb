Imports Forg.ETMS
Imports Forg.ETMS.Helper

Partial Class Controls_EmployeeCourse
    Inherits Forg.ETMS.UC_Base

#Region "Data Table Info Comments"
    'EmployeeID
    'Name	
    'HireDate 
#End Region

#Region "Public properties"

    Public ReadOnly Property UpdateEmpCourses() As List(Of EmployeeCourse)
        Get
            Dim _EmployeeCourses As List(Of EmployeeCourse) = New List(Of EmployeeCourse)
            If Me.ViewState("EmployeeCourses") IsNot Nothing Then
                _EmployeeCourses = CType(Me.ViewState("EmployeeCourses"), List(Of EmployeeCourse))
                Select Case Mode
                    Case ControlMode.Edit, ControlMode.Add
                        For Each _Item As DataListItem In Me.dlEmployeeCourse.Items
                            If _Item.ItemType = ListItemType.Item Or _Item.ItemType = ListItemType.AlternatingItem Then
                                Dim _chkIsPassed As CheckBox = CType(_Item.FindControl("chkIsPassed"), CheckBox)
                                _EmployeeCourses(_Item.ItemIndex).isPass = _chkIsPassed.Checked
                            End If
                        Next
                End Select
            End If
            Return _EmployeeCourses
        End Get
    End Property

    Public Property EmpCourses() As List(Of EmployeeCourse)
        Get
            Dim _EmployeeCourses As List(Of EmployeeCourse) = New List(Of EmployeeCourse)
            If Me.ViewState("EmployeeCourses") IsNot Nothing Then
                _EmployeeCourses = CType(Me.ViewState("EmployeeCourses"), List(Of EmployeeCourse))
            End If
            Return _EmployeeCourses
        End Get
        Set(ByVal value As List(Of EmployeeCourse))
            Me.ViewState("EmployeeCourses") = value
            Select Case Mode
                Case Mode = ControlMode.Add, ControlMode.Edit
                    Me.getData()
                Case ControlMode.List
                    If Not IsPostBack Then
                        Me.getData()
                    End If
            End Select
        End Set
    End Property

    Private Sub getData()
        Me.dlEmployeeCourse.DataSource = Me.EmpCourses
        Me.dlEmployeeCourse.DataBind()
    End Sub

    Public Property Mode() As ControlMode
        Get
            Dim _Mode As ControlMode = ControlMode.Add
            If Me.ViewState("Mode") IsNot Nothing Then
                _Mode = CType(Me.ViewState("Mode"), ControlMode)
            End If
            Return _Mode
        End Get
        Set(ByVal value As ControlMode)
            Me.ViewState("Mode") = value
        End Set
    End Property

#End Region

    Protected Sub dlEmployeeCourse_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dlEmployeeCourse.ItemCommand

        If e.CommandName = "myUpdate" Then
            Dim _EmployeeCourseID = CType(e.CommandArgument, Integer)
            Dim _EmployeeCourse As EmployeeCourse = EmployeeCourseData.EmployeeCourse_Select(_EmployeeCourseID)
            Dim _flag As Boolean = _EmployeeCourse.isPass
            _EmployeeCourse.isPass = Not _flag
            EmployeeCourseData.EmployeeCourse_Update(_EmployeeCourse)
            Me.EmpCourses = EmployeeCourseData.EmployeeCourse_Select_For_Employee(_EmployeeCourse.EmployeeID)
            Me.getData()
        End If

        'Bubble event is not need here as event is not invoke to host page 
        'RaiseBubbleEvent(source, e)

    End Sub


    Protected Sub dlEmployeeCourse_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlEmployeeCourse.ItemDataBound

        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim _chkIsPassed As CheckBox = CType(e.Item.FindControl("chkIsPassed"), CheckBox)
            Dim EmpCourse As EmployeeCourse = CType(e.Item.DataItem, EmployeeCourse)
            Dim _lbIsPassed As LinkButton = CType(e.Item.FindControl("lbIsPassed"), LinkButton)

            Select Case Me.Mode
                Case ControlMode.Add
                    'No used till so =ControlMode.Edit
                Case ControlMode.Edit, ControlMode.Add
                    'allow update
                    _lbIsPassed.Visible = False
                    _chkIsPassed.Visible = True
                    _chkIsPassed.Checked = EmpCourse.isPass
                Case ControlMode.List
                    'allow change mode on Image click
                    _lbIsPassed.Visible = True
                    _chkIsPassed.Visible = False
                    _lbIsPassed.CommandName = "myUpdate"
                    _lbIsPassed.CommandArgument = EmpCourse.EmployeeCourseID.ToString
            End Select

        End If
    End Sub

End Class
