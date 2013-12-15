Imports Forg.ETMS.Helper

Partial Class Controls_Course
    Inherits Forg.ETMS.UC_Base

#Region "Data Table Info Comments"
    'CourseID	
    'Code	
    'Course	
    'Description	

#End Region

#Region "Public properties"
    Public WriteOnly Property Course() As Forg.ETMS.Course
        Set(ByVal value As Forg.ETMS.Course)
            Me.Mode = ControlMode.Edit
            Me.txtCourse.Text = value.Course
            Me.txtCode.Text = value.Code
            Me.txtDescription.Text = value.Description
            Me.lblID.Text = value.CourseID.ToString.Trim
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
                    Me.lblTitle.Text = "Add new Course record"
                    Me.btnAddEdit.Text = "   Add   "
                    Me.trID.Visible = False
                    Me.btnCancel.Visible = False
                Case ControlMode.Edit
                    Me.lblTitle.Text = "Edit the selected Course record"
                    Me.btnAddEdit.Text = " Update "
                    Me.trID.Visible = True
                    Me.btnCancel.Visible = True
            End Select
        End Set
    End Property

#End Region

    Private Sub ClenForm()
        Me.lblID.Text = "0"
        Me.txtCourse.Text = String.Empty
        Me.txtCode.Text = String.Empty
        Me.txtDescription.Text = String.Empty
        Me.lblID.Text = String.Empty
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.Mode = ControlMode.Add
        End If
    End Sub

    Protected Sub btnAddEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddEdit.Click
        Dim _Course As New Forg.ETMS.Course
        _Course.Course = Me.txtCourse.Text.Trim
        _Course.Description = Me.txtDescription.Text.Trim
        _Course.Code = Me.txtCode.Text.Trim.ToUpper

        Select Case Me.Mode
            Case ControlMode.Add
                Forg.ETMS.CourseData.Course_Insert(_Course)
            Case ControlMode.Edit
                _Course.CourseID = Me.lblID.Text.Trim
                Forg.ETMS.CourseData.Course_Update(_Course)
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
