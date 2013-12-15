Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Namespace Forg.ETMS

    Public Class EmployeeData
#Region "Data Table Info Comments"
        'EmployeeID	int	Unchecked
        'Name	nchar(200)	Checked
        'HireDate
#End Region

        Public Shared Sub Employee_All_Courses_Insert(ByVal EmployeeID As Integer)
            Dim _Courses As New List(Of Course)
            Dim e As New EmployeeCourse

            _Courses = CourseData.Course_Select_All()
            Dim c As New Course
            For i As Integer = 0 To _Courses.Count - 1
                e = New EmployeeCourse
                c = _Courses(i)
                e.CourseID = c.CourseID
                e.EmployeeID = EmployeeID
                e.isPass = False

                EmployeeCourseData.EmployeeCourse_Insert(e)
            Next


        End Sub

        Public Shared Function Employee_Insert(ByVal theEmployee As Employee) As Integer

            Dim Sp As String = "Employee_Insert"
            Dim EmployeeID As String

            Try
                Using myConnection As New SqlConnection(Helper.ConnectionString)

                    Dim myCommand As SqlCommand = New SqlCommand(Sp, myConnection)
                    myCommand.CommandType = CommandType.StoredProcedure

                    myCommand.Parameters.AddWithValue("@Name", theEmployee.Name)
                    myCommand.Parameters.AddWithValue("@HireDate", theEmployee.HireDate)

                    myConnection.Open()

                    EmployeeID = myCommand.ExecuteScalar
                    myConnection.Close()

                    For Each _EmpCourse As EmployeeCourse In theEmployee.EmpCourses
                        EmployeeCourseData.EmployeeCourse_Update(_EmpCourse)
                    Next

                End Using
            Catch ex As Exception
                ' Error would be caught by the Name in the Global.asax 
                Throw

            End Try
            Return EmployeeID

        End Function

        Public Shared Sub Employee_Update(ByVal theEmployee As Employee)

            Dim Sp As String = "Employee_Update"

            Try
                Using myConnection As New SqlConnection(Helper.ConnectionString)

                    Dim myCommand As SqlCommand = New SqlCommand(Sp, myConnection)
                    myCommand.CommandType = CommandType.StoredProcedure

                    myCommand.Parameters.AddWithValue("@Name", theEmployee.Name)
                    myCommand.Parameters.AddWithValue("@EmployeeID", theEmployee.EmployeeID)
                    myCommand.Parameters.AddWithValue("@HireDate", theEmployee.HireDate)

                    myConnection.Open()
                    myCommand.ExecuteNonQuery()
                    myConnection.Close()

                    For Each _EmpCourse As EmployeeCourse In theEmployee.EmpCourses
                        EmployeeCourseData.EmployeeCourse_Update(_EmpCourse)
                    Next

                End Using
            Catch ex As Exception
                ' Error would be caught by the Name in the Global.asax 
                Throw
            End Try
        End Sub

        Public Shared Sub Employee_Delete(ByVal theEmployee As Employee)
            Employee_Delete(theEmployee.EmployeeID)
        End Sub

        Public Shared Sub Employee_Delete(ByVal EmployeeID As Integer)

            Dim Sp As String = "Employee_Delete"

            Try
                Using myConnection As New SqlConnection(Helper.ConnectionString)

                    Dim myCommand As SqlCommand = New SqlCommand(Sp, myConnection)
                    myCommand.CommandType = CommandType.StoredProcedure

                    myCommand.Parameters.AddWithValue("@EmployeeID", EmployeeID)

                    myConnection.Open()

                    myCommand.ExecuteNonQuery()
                    myConnection.Close()
                End Using
            Catch ex As Exception
                ' Error would be caught by the Name in the Global.asax 
                Throw
            End Try
        End Sub

        Public Shared Function Employee_Select(ByVal EmployeeID As Integer) As Employee

            Dim Sp As String = "Employee_Select"

            Using connection As New SqlConnection(Helper.ConnectionString)
                Using command As New SqlCommand(Sp, connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@EmployeeID", EmployeeID))
                    connection.Open()
                    Dim aEmployee As New Employee
                    Using reader As SqlDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            aEmployee = GetEmployeeFromDataReader(reader)
                        End If
                    End Using
                    Return aEmployee
                End Using
            End Using
        End Function

        Public Shared Function Employee_Select_All() As Generic.List(Of Employee)

            Dim Sp As String = "Employee_Select_All"

            Using connection As New SqlConnection(Helper.ConnectionString)
                Using command As New SqlCommand(Sp, connection)
                    command.CommandType = CommandType.StoredProcedure
                    connection.Open()
                    Dim allEmployee As New Generic.List(Of Employee)()
                    Using reader As SqlDataReader = command.ExecuteReader()
                        Do While (reader.Read())
                            Dim aEmployee As New Employee
                            aEmployee = GetEmployeeFromDataReader(reader)
                            allEmployee.Add(aEmployee)
                        Loop
                    End Using
                    Return allEmployee
                End Using
            End Using
        End Function

        Private Shared Function GetEmployeeFromDataReader(ByVal reader As IDataReader) As Employee
            Dim aEmployee As Employee = New Employee

            aEmployee.Name = reader("Name").ToString
            aEmployee.EmployeeID = CInt(reader("EmployeeID"))
            aEmployee.HireDate = CType(reader("HireDate"), Date)

            Return aEmployee
        End Function

    End Class

End Namespace