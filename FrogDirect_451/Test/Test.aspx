<%@ Page Title="" Language="VB" MasterPageFile="~/Frog.master" AutoEventWireup="false" CodeFile="Test.aspx.vb" Inherits="Test_Test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <asp:Button ID="Button1" runat="server" Text="Button" />
    <asp:DataList ID="DataList1" runat="server" DataKeyField="EmployeeCourseID" 
        DataSourceID="SqlDataSource1" RepeatColumns="2">
        <ItemTemplate>
            EmployeeCourseID:
            <asp:Label ID="EmployeeCourseIDLabel" runat="server" 
                Text='<%# Eval("EmployeeCourseID") %>' />
            <br />
            EmployeeID:
            <asp:Label ID="EmployeeIDLabel" runat="server" 
                Text='<%# Eval("EmployeeID") %>' />
            <br />
            CourseID:
            <asp:Label ID="CourseIDLabel" runat="server" Text='<%# Eval("CourseID") %>' />
            <br />
            isPass:
            <asp:Label ID="isPassLabel" runat="server" Text='<%# Eval("isPass") %>' />
            <br />
            Note:
            <asp:Label ID="NoteLabel" runat="server" Text='<%# Eval("Note") %>' />
            <br />
            <br />
        </ItemTemplate>
    </asp:DataList>
    <table cellpadding="5" cellspacing="0" 
        style="width: 100%; border: 1px solid #CCCCCC">
        <tr>
            <td>
                <img src="../Img/cal.gif" 
                    style="width: 16px; height: 16px; padding-left: 5px;" /></td>
            <td>
                <img src="../Img/arrow3.gif" 
                    style="width: 11px; height: 11px; padding-right: 10px;" /></td>
            <td>
                <img alt="" src="../Img/no.gif" style="width: 16px; height: 16px" /></td>
        </tr>
        <tr>
            <td>
                <img src="../Img/no2.gif" style="width: 16px; height: 16px" /></td>
            <td>
                <img src="../Img/yes.gif" style="width: 14px; height: 13px" /></td>
            <td rowspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <img src="../App_Themes/Frog/Img_lv_vista/sort_asc.gif" 
                    style="width: 13px; height: 13px" /></td>
            <td>
                <img src="../Img/no.gif" style="width: 15px; height: 15px" /></td>
        </tr>
    </table>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:Conn_Str_Forg %>" 
        SelectCommand="SELECT * FROM [EmployeeCourse]">
    </asp:SqlDataSource>
    
    <br />
    
    
    
    <br />
    
</asp:Content>

