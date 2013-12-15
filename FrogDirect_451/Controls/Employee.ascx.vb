Imports Forg.ETMS.Helper

Partial Class Controls_Employee
    Inherits Forg.ETMS.UC_Base

#Region "Data Table Info Comments"
    'EmployeeCourseID	int	Unchecked
    'EmployeeID	int	Checked
    'CourseID	int	Checked  >> Course
    'isPass	bit	Checked
    'Note	nchar(1000)	Checked 
#End Region


#Region "Public properties"

    Public WriteOnly Property Employee() As Forg.ETMS.Employee
        Set(ByVal value As Forg.ETMS.Employee)
            Me.Mode = ControlMode.Edit
            Me.txtHireDate.Text = value.HireDate.Date
            Me.txtName.Text = value.Name
            Me.lblID.Text = value.EmployeeID
            Me.EmployeeCourse1.Mode = ControlMode.Edit
            Me.EmployeeCourse1.EmpCourses = value.EmpCourses
        End Set
    End Property

    Public WriteOnly Property Title() As String
        Set(ByVal value As String)
            Me.lblTitle.Text = value
        End Set
    End Property

    Public WriteOnly Property width() As Unit
        Set(ByVal value As Unit)
            Me.pnlEditor.Width = value
        End Set
    End Property

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
            Select Case value
                Case ControlMode.Add
                    Me.ClenForm()
                    Me.lblTitle.Text = "Add new Employee record"
                    Me.btnAddEdit.Text = "   Add   "
                    Me.trID.Visible = False
                    Me.btnCancel.Visible = False
                    Me.trStatus1.Visible = False
                    Me.trStatus2.Visible = False
                Case ControlMode.Edit
                    Me.lblTitle.Text = "Edit the selected Employee record"
                    Me.btnAddEdit.Text = " Update "
                    Me.trID.Visible = True
                    Me.btnCancel.Visible = True
                    Me.trStatus1.Visible = True
                    Me.trStatus2.Visible = True
            End Select
        End Set
    End Property

#End Region

    Private Sub ClenForm()
        Me.lblID.Text = "0"
        Me.txtName.Text = String.Empty
        Me.txtHireDate.Text = String.Empty
        Me.lblID.Text = String.Empty
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.Mode = ControlMode.Add
        End If
    End Sub

    Protected Sub btnAddEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddEdit.Click
        Dim _Employee As New Forg.ETMS.Employee
        _Employee.Name = Me.txtName.Text.Trim
        _Employee.HireDate = CType(Me.txtHireDate.Text.Trim, Date)

        Select Case Me.Mode
            Case ControlMode.Add
                Dim _EmployeeID As Integer = 0
                _EmployeeID = Forg.ETMS.EmployeeData.Employee_Insert(_Employee)
                'Adding here all coerces here instead of by UI
                'Not good idea!
                If _EmployeeID Then
                    Forg.ETMS.EmployeeData.Employee_All_Courses_Insert(_EmployeeID)
                End If
            Case ControlMode.Edit
                _Employee.EmployeeID = CType(Me.lblID.Text, Integer)
                _Employee.EmpCourses = Me.EmployeeCourse1.UpdateEmpCourses
                Forg.ETMS.EmployeeData.Employee_Update(_Employee)
                Me.Mode = ControlMode.Add
        End Select


        Me.ClenForm()

        Me.OnAddEditClick(sender, e)

    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.ClenForm()
        Me.Mode = ControlMode.Add
    End Sub

End Class

