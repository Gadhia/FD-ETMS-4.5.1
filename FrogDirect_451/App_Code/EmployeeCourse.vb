Imports Microsoft.VisualBasic
Imports System.Collections.Generic

Namespace Forg.ETMS

    <Serializable()> Public Class EmployeeCourse

#Region "Data Table Info Comments"
        'EmployeeCourseID	int	Unchecked
        'EmployeeID	int	Checked
        'CourseID	int	Checked
        'isPass	bit	Checked
        'Note	nchar(1000)	Checked
#End Region

#Region "Constructor(s)"
        Public Sub New()
            _Note = String.Empty
            _EmployeeCourseID = 0
            _EmployeeID = 0
            _CourseID = 0
            _EmpCourse = New Course
            '      _CourseText = String.Empty
        End Sub
#End Region

#Region "RemovedPublic Properties"

        'ReadOnly Property Code() As String
        '    Get
        '        Return _EmpCourse.Code
        '    End Get
        'End Property

        'ReadOnly Property Course() As String
        '    Get
        '        Return _EmpCourse.Course
        '    End Get
        'End Property
#End Region

#Region "Private Variables and Public Properties"
        'Private _CourseText As String

        ReadOnly Property CourseTextNoImage() As String
            Get
                Return _EmpCourse.Code + " : " + _EmpCourse.Course
            End Get
        End Property

        ReadOnly Property CourseText() As String
            Get
                Dim _yes As String = "<img src='Img/yes.gif' style='width: 14px; height: 13px' />"
                Dim _no As String = "<img src='Img/no.gif' style='width: 15px; height: 15px' />"

                Dim _str As String = _EmpCourse.Code + " : " + _EmpCourse.Course
                If _isPass Then
                    '_str += " (Passed)"
                    _str = _yes + Space(2) + _str
                Else
                    '_str += " (Pending)"
                    _str = _no + Space(2) + _str
                End If
                Return _str
            End Get
        End Property

        Private _EmpCourse As Course
        ReadOnly Property EmpCourse() As Course
            Get
                Return _EmpCourse
            End Get
        End Property

        Private _isPass As Boolean
        Public Property isPass() As Boolean
            Get
                Return _isPass
            End Get
            Set(ByVal value As Boolean)
                _isPass = value
            End Set
        End Property

        Private _EmployeeID As Integer
        Public Property EmployeeID() As Integer
            Get
                Return _EmployeeID
            End Get
            Set(ByVal value As Integer)
                _EmployeeID = value
            End Set
        End Property

        Private _EmployeeCourseID As Integer
        Public Property EmployeeCourseID() As Integer
            Get
                Return _EmployeeCourseID
            End Get
            Set(ByVal value As Integer)
                _EmployeeCourseID = value
            End Set
        End Property

        Private _CourseID As Integer
        Public Property CourseID() As Integer
            Get
                Return _CourseID
            End Get
            Set(ByVal value As Integer)
                _CourseID = value
                _EmpCourse = CourseData.Course_Select(value)
            End Set
        End Property

        Private _Note As String
        Public Property Note() As String
            Get
                Return _Note
            End Get
            Set(ByVal value As String)
                _Note = value
            End Set
        End Property

#End Region




    End Class

End Namespace