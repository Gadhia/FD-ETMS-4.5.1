
Partial Class Controls_App_Visit_Apps
    Inherits System.Web.UI.UserControl

    Public Enum TabMode
        Tab_A
        Tab_B
        Tab_C
        Tab_D
    End Enum
    Public WriteOnly Property Tab() As TabMode
        Set(ByVal value As TabMode)
            Me.tr2.Visible = False
            Me.tr3.Visible = False
            Me.tr4.Visible = False
            Me.tr1.Visible = False
            Me.tr5.Visible = False
            Me.tr6.Visible = False
            Select Case value
                Case TabMode.Tab_A
                    Me.tr2.Visible = True
                    Me.tr3.Visible = True
                    Me.tr4.Visible = True
                Case TabMode.Tab_B
                    Me.tr1.Visible = True
                    Me.tr5.Visible = True
                    Me.tr6.Visible = True
                Case TabMode.Tab_C
                    Me.tr2.Visible = True
                    Me.tr4.Visible = True
                    Me.tr6.Visible = True
                Case TabMode.Tab_D
                    Me.tr1.Visible = True
                    Me.tr3.Visible = True
                    Me.tr5.Visible = True
            End Select
        End Set
    End Property


End Class
