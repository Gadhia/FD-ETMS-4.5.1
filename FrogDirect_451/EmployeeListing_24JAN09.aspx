<%@ Page Title="Employee Listing" Language="VB" MasterPageFile="~/Frog.master" AutoEventWireup="false" CodeFile="EmployeeListing_24JAN09.aspx.vb" Inherits="EmployeeListing_24JAN09" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h3>Employee Listing</h3>
<br />

<asp:GridView CssClass ="gv" ID="gvEmployee" Width="700" runat="server" AutoGenerateColumns="False" 
        CellPadding="0" DataKeyNames="EmployeeID" BorderWidth="0px" >
        <Columns>
               
   <asp:TemplateField HeaderText="Course status of the employee " 
   InsertVisible="False" 
                SortExpression="EmployeeID">
   <ItemTemplate><table cellpadding="1" cellspacing="0"  style="width: 100%; border: 1px solid #CCCCCC">
        <tr>
            <td>
               <b>ID:</b>
               <asp:Label ID="Label1" runat="server" Text='<%# Bind("EmployeeID") %>'></asp:Label><br />
                <b>Name:</b>
                 <asp:Label ID="Label2" runat="server" Text='<%# Bind("Name") %>'></asp:Label><br />

                <b>Hire Date</b>

                    <asp:Label ID="Label4" runat="server" 
                        Text='<%# Bind("HireDate", "{0:dd-MMM-yy}") %>'></asp:Label>
               </td>
 </tr>
 <tr><td  class ="gv-hd"><img src="Img/arrow3.gif" style="width: 11px; height: 11px; padding-right: 15px;" /><b><asp:Label ID="Label3" runat="server" Text='<%# Bind("Name") %>'></asp:Label></b> : Status of Course:  </td>

        </tr>
        <tr>
              <td >
     <asp:DataList Width ="100%" ID="dlEmployeeCourse" runat="server" DataKeyField="EmployeeCourseID"  
     RepeatColumns="2" CellPadding="3" BackColor="#FFFFCC" BorderWidth="1" BorderColor="#CCCCCC">
        <ItemTemplate>
            <asp:Label ID="EmployeeCourseIDLabel" runat="server" Text='<%# Eval("CourseText") %>' />
            <asp:LinkButton ID="LinkButton1" CommandArgument='<%# Eval("CourseId") %>' runat="server">LinkButton</asp:LinkButton>
        </ItemTemplate>
    </asp:DataList>
                
                
                </td>
        </tr>
    </table>                
                     
                    </ItemTemplate>
                </asp:TemplateField>
                
        </Columns>
  <HeaderStyle CssClass="gv-th" />
</asp:GridView>

<br />
<br />
</asp:Content>

