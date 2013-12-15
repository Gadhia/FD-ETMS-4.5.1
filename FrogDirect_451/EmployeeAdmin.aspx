<%@ Page Title="Employee Admin" Language="VB" MasterPageFile="~/Frog.master" AutoEventWireup="false" CodeFile="EmployeeAdmin.aspx.vb" Inherits="EmployeeAdmin" %>

<%@ Register src="Controls/Employee.ascx" tagname="Employee" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h3>Employee Admin</h3>
    <uc1:Employee ID="Employee1" runat="server" />
<br />
   
<asp:GridView  CssClass ="gv" ID="gvEmployee" runat="server" Width ="600px" AutoGenerateColumns="False" 
        CellPadding="5" DataKeyNames="EmployeeID" >
        <Columns>
                         <asp:TemplateField HeaderText="#">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                     <HeaderStyle HorizontalAlign ="Center" />
                </asp:TemplateField>  
            <asp:BoundField DataField="EmployeeID" HeaderText="ID" InsertVisible="False" 
                ReadOnly="True" SortExpression="EmployeeID" />
            <asp:BoundField DataField="Name" HeaderText="Employee Name" 
                SortExpression="Name" />
            <asp:BoundField DataField="HireDate" HeaderText="Hire Date" 
                SortExpression="HireDate" DataFormatString="{0:dd-MMM-yy}" />
                 
                 <asp:TemplateField HeaderText="Delete"  ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbDelete" CommandArgument='<%# Bind("EmployeeID")%>' runat="server" CausesValidation="False" CommandName="myDelete"
                            Text="Delete"></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                     <HeaderStyle HorizontalAlign ="Center" />
                </asp:TemplateField>
                
            <asp:TemplateField HeaderText="Edit" ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="lbEdit" runat="server" CausesValidation="False" 
                       CommandArgument='<%# Bind("EmployeeID")%>'   CommandName="mySelect" Text="Edit">
                    </asp:LinkButton>
                </ItemTemplate>
                  <ItemStyle HorizontalAlign="Center" />
                   <HeaderStyle HorizontalAlign ="Center" />
            </asp:TemplateField>
        </Columns>
        <HeaderStyle CssClass="gv-hd" />
    </asp:GridView>
</asp:Content>

