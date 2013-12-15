<%@ Page Title="Course Admin" Language="VB" MasterPageFile="~/Frog.master" AutoEventWireup="false" CodeFile="CourseAdmin.aspx.vb" Inherits="CourseAdmin" %>
<%@ Register src="Controls/Course.ascx" tagname="Course" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h3>Course Admin</h3>

    <uc1:Course ID="Course1" runat="server" width="400" Mode="Add" /><br />

    <asp:GridView CssClass ="gv" ID="gvCourse" runat="server" Width ="600px" AutoGenerateColumns="False" 
        CellPadding="5" DataKeyNames="CourseID" >
        <Columns>
                                <asp:TemplateField HeaderText="#">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                     <HeaderStyle HorizontalAlign ="Center" />
                </asp:TemplateField>  
            <asp:BoundField DataField="CourseID" HeaderText="ID" InsertVisible="False" 
                ReadOnly="True" SortExpression="CourseID" />
            <asp:BoundField DataField="Code" HeaderText="Code" SortExpression="Code" />
            <asp:BoundField DataField="Course" HeaderText="Course" 
                SortExpression="Course" />
                 
                 <asp:TemplateField HeaderText="Delete"  ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbDelete" CommandArgument='<%# Bind("CourseID")%>' runat="server" CausesValidation="False" CommandName="myDelete"
                            Text="Delete"></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                     <HeaderStyle HorizontalAlign ="Center" />
                </asp:TemplateField>
                
            <asp:TemplateField HeaderText="Edit" ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="lbEdit" runat="server" CausesValidation="False" 
                       CommandArgument='<%# Bind("CourseID")%>'   CommandName="mySelect" Text="Edit">
                    </asp:LinkButton>
                </ItemTemplate>
                  <ItemStyle HorizontalAlign="Center" />
                   <HeaderStyle HorizontalAlign ="Center" />
            </asp:TemplateField>
        </Columns>
        <HeaderStyle CssClass="gv-hd" />
    </asp:GridView>
<br />
    </asp:Content>

