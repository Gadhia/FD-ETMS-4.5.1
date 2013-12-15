<%@ Page Title="" Language="VB" MasterPageFile="~/Frog.master" AutoEventWireup="false" CodeFile="TestUC.aspx.vb" Inherits="Test_TestUC" %>

<%@ Register src="../Controls/EmployeeCourse.ascx" tagname="EmployeeCourse" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:EmployeeCourse ID="EmployeeCourse1" runat="server" /><br />
    <asp:Button ID="Button1" runat="server" Text="Button" />
</asp:Content>

