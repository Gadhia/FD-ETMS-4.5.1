<%@ Control Language="VB" AutoEventWireup="false" CodeFile="EmployeeCourse.ascx.vb" Inherits="Controls_EmployeeCourse" %>
     <asp:DataList Width ="100%" ID="dlEmployeeCourse" runat="server" DataKeyField="EmployeeCourseID"  
     RepeatColumns="2" CellPadding="5" BackColor="#FFFFCC" BorderWidth="0px" 
    BorderColor="#FFFFCC" CssClass="gvNoBorder" ShowFooter="False" 
    ShowHeader="False">
        <ItemTemplate>
  <%--      <table border ="0", cellpadding ="5" , cellspacing ="0"><tr><td valign ="middle" align ="center"  >
  --%>          <asp:CheckBox ID="chkIsPassed" Text='<%# Space(5) & Eval("CourseTextNoImage") %>' runat="server" />
     
            <asp:LinkButton ID="lbIsPassed"  Text='<%# Eval("CourseText") %>' runat="server"></asp:LinkButton>
 <%--           </td> 
 
            
            </tr></table>--%>
        </ItemTemplate>
    </asp:DataList>