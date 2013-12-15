Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Namespace Forg.ETMS

    Public Class EmployeeCourseData

#Region "Data Table Info Comments"
        'EmployeeID	int	Unchecked
        'EmployeeCourseID	int	Checked
        'CourseID	int	Checked
        'isPass	bit	Checked
        'Note	nchar(1000)	Checked
#End Region


        Public Shared Function EmployeeCourse_AssigneCount(ByVal CourseID As Integer) As Integer

            Dim Sp As String = "EmployeeCourse_AssigneCount"
            Dim _Count As Integer
            Try
                Using myConnection As New SqlConnection(Helper.ConnectionString)

                    Dim myCommand As SqlCommand = New SqlCommand(Sp, myConnection)
                    myCommand.CommandType = CommandType.StoredProcedure

                    myCommand.Parameters.AddWithValue("@CourseID", CourseID)

                    myConnection.Open()

                    _Count = myCommand.ExecuteScalar
                    myConnection.Close()

                End Using
            Catch ex As Exception
                ' Error would be caught by the Name in the Global.asax 
                Throw

            End Try
            Return _Count

        End Function

        Public Shared Sub EmployeeCourse_Insert(ByVal theEmployeeCourse As EmployeeCourse)

            Dim Sp As String = "EmployeeCourse_Insert"

            Try
                Using myConnection As New SqlConnection(Helper.ConnectionString)

                    Dim myCommand As SqlCommand = New SqlCommand(Sp, myConnection)
                    myCommand.CommandType = CommandType.StoredProcedure

                    myCommand.Parameters.AddWithValue("@CourseID", theEmployeeCourse.CourseID)
                    myCommand.Parameters.AddWithValue("@isPass", theEmployeeCourse.isPass)
                    myCommand.Parameters.AddWithValue("@EmployeeID", theEmployeeCourse.EmployeeID)
                    myCommand.Parameters.AddWithValue("@Note", theEmployeeCourse.Note)

                    myConnection.Open()

                    myCommand.ExecuteNonQuery()
                    myConnection.Close()
                End Using
            Catch ex As Exception
                '    Error would be caught by the Name in the Global.asax 
                Throw

            End Try
        End Sub

        Public Shared Sub EmployeeCourse_Update(ByVal theEmployeeCourse As EmployeeCourse)

            Dim Sp As String = "EmployeeCourse_Update"

            Try
                Using myConnection As New SqlConnection(Helper.ConnectionString)

                    Dim myCommand As SqlCommand = New SqlCommand(Sp, myConnection)
                    myCommand.CommandType = CommandType.StoredProcedure

                    myCommand.Parameters.AddWithValue("@EmployeeCourseID", theEmployeeCourse.EmployeeCourseID)
                    myCommand.Parameters.AddWithValue("@CourseID", theEmployeeCourse.CourseID)
                    myCommand.Parameters.AddWithValue("@isPass", theEmployeeCourse.isPass)
                    myCommand.Parameters.AddWithValue("@EmployeeID", theEmployeeCourse.EmployeeID)
                    myCommand.Parameters.AddWithValue("@Note", theEmployeeCourse.Note)

                    myConnection.Open()
                    myCommand.ExecuteNonQuery()
                    myConnection.Close()
                End Using
            Catch ex As Exception
                ' Error would be caught by the Name in the Global.asax 
                Throw
            End Try
        End Sub

        Public Shared Sub EmployeeCourse_Delete(ByVal theEmployeeCourse As EmployeeCourse)
            EmployeeCourse_Delete(theEmployeeCourse.EmployeeCourseID)
        End Sub

        Public Shared Sub EmployeeCourse_Delete(ByVal EmployeeCourseID As Integer)

            Dim Sp As String = "EmployeeCourse_Delete"

            Try
                Using myConnection As New SqlConnection(Helper.ConnectionString)

                    Dim myCommand As SqlCommand = New SqlCommand("Sp", myConnection)
                    myCommand.CommandType = CommandType.StoredProcedure

                    myCommand.Parameters.AddWithValue("@EmployeeCourseID", EmployeeCourseID)

                    myConnection.Open()

                    myCommand.ExecuteNonQuery()
                    myConnection.Close()
                End Using
            Catch ex As Exception
                ' Error would be caught by the Name in the Global.asax 
                Throw
            End Try
        End Sub

        Public Shared Function EmployeeCourse_Select_For_Employee(ByVal EmployeeID As Integer) As Generic.List(Of EmployeeCourse)

            Dim Sp As String = "EmployeeCourse_Select_For_Employee"

            Using connection As New SqlConnection(Helper.ConnectionString)
                Using command As New SqlCommand(Sp, connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@EmployeeID", EmployeeID))
                    connection.Open()
                    Dim allEmployeeCourse As New Generic.List(Of EmployeeCourse)()
                    Using reader As SqlDataReader = command.ExecuteReader()
                        Do While (reader.Read())
                            Dim aEmployeeCourse As New EmployeeCourse
                            aEmployeeCourse = GetEmployeeCourseFromDataReader(reader)
                            allEmployeeCourse.Add(aEmployeeCourse)
                        Loop
                    End Using
                    Return allEmployeeCourse
                End Using
            End Using
        End Function

        Public Shared Function EmployeeCourse_Select(ByVal EmployeeCourseID As Integer) As EmployeeCourse

            Dim Sp As String = "EmployeeCourse_Select"

            Using connection As New SqlConnection(Helper.ConnectionString)
                Using command As New SqlCommand(Sp, connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@EmployeeCourseID", EmployeeCourseID))
                    connection.Open()
                    Dim aEmployeeCourse As New EmployeeCourse
                    Using reader As SqlDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            aEmployeeCourse = GetEmployeeCourseFromDataReader(reader)
                        End If
                    End Using
                    Return aEmployeeCourse
                End Using
            End Using
        End Function



        Private Shared Function GetEmployeeCourseFromDataReader(ByVal reader As IDataReader) As EmployeeCourse
            Dim aEmployeeCourse As EmployeeCourse = New EmployeeCourse

            aEmployeeCourse.EmployeeCourseID = CInt(reader("EmployeeCourseID"))
            aEmployeeCourse.CourseID = CInt(reader("CourseID"))
            aEmployeeCourse.EmployeeID = CInt(reader("EmployeeID"))
            aEmployeeCourse.Note = CStr(reader("Note"))
            aEmployeeCourse.isPass = CType(reader("isPass"), Boolean)

            Return aEmployeeCourse
        End Function

#Region "Removed methods"

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

    End Class

End Namespace