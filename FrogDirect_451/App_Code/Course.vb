Imports Microsoft.VisualBasic

Namespace Forg.ETMS

    <Serializable()> Public Class Course
#Region "Data Table Info Comments"
        'CourseID	int	Unchecked
        'Code	char(4)	Unchecked
        'Course	nchar(200)	Checked
        'Description	nchar(1000)	Checked
#End Region

#Region "Constructor(s)"
        Public Sub New()
            _Code = String.Empty
            _Course = String.Empty
            _Description = String.Empty
            _CourseID = 0
        End Sub
#End Region

#Region "Private Variables and Public Properties"

        Private _CourseID As Integer
        Public Property CourseID() As Integer
            Get
                Return _CourseID
            End Get
            Set(ByVal value As Integer)
                _CourseID = value
            End Set
        End Property

        Private _Course As String
        Public Property Course() As String
            Get
                Return _Course
            End Get
            Set(ByVal value As String)
                _Course = value
            End Set
        End Property


        Private _Code As String
        Public Property Code() As String
            Get
                Return _Code
            End Get
            Set(ByVal value As String)
                _Code = value
            End Set
        End Property

        Private _Description As String
        Public Property Description() As String
            Get
                Return _Description
            End Get
            Set(ByVal value As String)
                _Description = value
            End Set
        End Property


#End Region

    End Class


End Namespace