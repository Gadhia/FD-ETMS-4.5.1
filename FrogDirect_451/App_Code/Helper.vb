Imports Microsoft.VisualBasic
Namespace Forg.ETMS

    Public Class Helper

        Public Shared Sub AddAttributesToRow(ByVal Row As DataListItem, ByVal MouseOverColor As String)
            Row.Attributes.Add("onmouseover", _
                "this.style.backgroundColor='" _
               + MouseOverColor + _
                "'; this.style.cursor='hand'")

            Row.Attributes.Add("onmouseout", _
            "this.style.backgroundColor='';")
        End Sub

        Public Shared Sub AddAttributesToRow(ByVal Row As GridViewRow, ByVal MouseOverColor As String)
            Row.Attributes.Add("onmouseover", _
                "this.style.backgroundColor='" _
               + MouseOverColor + _
                "'; this.style.cursor='hand'")

            Row.Attributes.Add("onmouseout", _
            "this.style.backgroundColor='';")
        End Sub

        Public Enum ControlMode As Integer
            Add
            Edit
            List
        End Enum

        Public Shared ReadOnly Property ConnectionString() As String
            Get
                Dim conStr As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Frog.mdf;Integrated Security=True;User Instance=True"
                If ConfigurationManager.ConnectionStrings("Conn_Str_Forg") IsNot Nothing Then
                    conStr = ConfigurationManager.ConnectionStrings("Conn_Str_Forg").ConnectionString
                End If
                Return conStr
            End Get
        End Property
    End Class

End Namespace