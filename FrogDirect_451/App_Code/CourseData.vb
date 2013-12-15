Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Namespace Forg.ETMS

    Public Class CourseData

#Region "Data Table Info Comments"
        'CourseID	int	Unchecked
        'Code	char(4)	Unchecked
        'Course	nchar(200)	Checked
        'Description	nchar(1000)	Checked
#End Region


        Public Shared Sub Course_Insert(ByVal theCourse As Course)

            Dim Sp As String = "Course_Insert"

            Try
                Using myConnection As New SqlConnection(Helper.ConnectionString)

                    Dim myCommand As SqlCommand = New SqlCommand(Sp, myConnection)
                    myCommand.CommandType = CommandType.StoredProcedure

                    myCommand.Parameters.AddWithValue("@Description", theCourse.Description)
                    myCommand.Parameters.AddWithValue("@Course", theCourse.Course)
                    myCommand.Parameters.AddWithValue("@Code", theCourse.Code)

                    myConnection.Open()

                    myCommand.ExecuteNonQuery()
                    myConnection.Close()
                End Using
            Catch ex As Exception
                ' Error would be caught by the code in the Global.asax 
                Throw

            End Try
        End Sub

        Public Shared Sub Course_Update(ByVal theCourse As Course)

            Dim Sp As String = "Course_Update"

            Try
                Using myConnection As New SqlConnection(Helper.ConnectionString)

                    Dim myCommand As SqlCommand = New SqlCommand(Sp, myConnection)
                    myCommand.CommandType = CommandType.StoredProcedure
                    myCommand.Parameters.AddWithValue("@Description", theCourse.Description)
                    myCommand.Parameters.AddWithValue("@Course", theCourse.Course)
                    myCommand.Parameters.AddWithValue("@Code", theCourse.Code)
                    myCommand.Parameters.AddWithValue("@CourseID", theCourse.CourseID)

                    myConnection.Open()
                    myCommand.ExecuteNonQuery()
                    myConnection.Close()
                End Using
            Catch ex As Exception
                ' Error would be caught by the code in the Global.asax 
                Throw
            End Try
        End Sub

        Public Shared Sub Course_Delete(ByVal theCourse As Course)
            Course_Delete(theCourse.CourseID)
        End Sub

        Public Shared Sub Course_Delete(ByVal CourseID As Integer)

            Dim Sp As String = "Course_Delete"

            Try
                Using myConnection As New SqlConnection(Helper.ConnectionString)

                    Dim myCommand As SqlCommand = New SqlCommand(Sp, myConnection)
                    myCommand.CommandType = CommandType.StoredProcedure

                    myCommand.Parameters.AddWithValue("@CourseID", CourseID)

                    myConnection.Open()

                    myCommand.ExecuteNonQuery()
                    myConnection.Close()
                End Using
            Catch ex As Exception
                ' Error would be caught by the code in the Global.asax 
                Throw
            End Try
        End Sub

        Public Shared Function Course_Select(ByVal CourseID As Integer) As Course

            Dim Sp As String = "Course_Select"

            Using connection As New SqlConnection(Helper.ConnectionString)
                Using command As New SqlCommand(Sp, connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@CourseID", CourseID))
                    connection.Open()
                    Dim aCourse As New Course
                    Using reader As SqlDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            aCourse = GetCourseFromDataReader(reader)
                        End If
                    End Using
                    Return aCourse
                End Using
            End Using
        End Function

        Public Shared Function Course_Select_All() As Generic.List(Of Course)

            Dim Sp As String = "Course_Select_All"

            Using connection As New SqlConnection(Helper.ConnectionString)
                Using command As New SqlCommand(Sp, connection)
                    command.CommandType = CommandType.StoredProcedure
                    connection.Open()
                    Dim allCourse As New Generic.List(Of Course)()
                    Using reader As SqlDataReader = command.ExecuteReader()
                        Do While (reader.Read())
                            Dim aCourse As New Course
                            aCourse = GetCourseFromDataReader(reader)
                            allCourse.Add(aCourse)
                        Loop
                    End Using
                    Return allCourse
                End Using
            End Using
        End Function

        Private Shared Function GetCourseFromDataReader(ByVal reader As IDataReader) As Course
            Dim aCourse As Course = New Course

            aCourse.Code = CStr(reader("Code"))
            aCourse.Course = CStr(reader("Course"))
            If Not IsDBNull(reader("Description")) Then
                aCourse.Description = CStr(reader("Description"))
            End If
            aCourse.CourseID = CInt(reader("CourseID"))

            Return aCourse

        End Function

    End Class
End Namespace