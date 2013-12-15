Imports Microsoft.VisualBasic
Namespace Forg.ETMS


    <Serializable()> Public Class Employee
#Region "Data Table Info Comments"
        'EmployeeID	int	Unchecked
        'Name	nchar(200)	Checked
        'HireDate datatime
#End Region

#Region "Constructor(s)"
        Public Sub New()
            _Name = String.Empty
            _EmployeeID = 0
            _HireDate = Date.MinValue
            _EmpCourses = New List(Of EmployeeCourse)
        End Sub
#End Region

#Region "Private Variables and Public Properties"

        Private _EmpCourses As List(Of EmployeeCourse)
        Public Property EmpCourses() As List(Of EmployeeCourse)
            Get
                Return _EmpCourses
            End Get
            Set(ByVal value As List(Of EmployeeCourse))
                _EmpCourses = value
            End Set
        End Property

        Private _HireDate As DateTime
        Public Property HireDate() As DateTime
            Get
                Return _HireDate
            End Get
            Set(ByVal value As DateTime)
                _HireDate = value
            End Set
        End Property

        Private _EmployeeID As Integer
        Public Property EmployeeID() As Integer
            Get
                Return _EmployeeID
            End Get
            Set(ByVal value As Integer)
                _EmployeeID = value
                If _EmployeeID > 0 Then
                    _EmpCourses = EmployeeCourseData.EmployeeCourse_Select_For_Employee(value)
                End If
            End Set
        End Property

        Private _Name As String
        Public Property Name() As String
            Get
                Return _Name
            End Get
            Set(ByVal value As String)
                _Name = value
            End Set
        End Property
#End Region

    End Class
End Namespace