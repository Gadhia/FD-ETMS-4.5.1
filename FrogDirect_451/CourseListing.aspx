<%@ Page Title="Course Listing" Language="VB" MasterPageFile="~/Frog.master" AutoEventWireup="false" CodeFile="CourseListing.aspx.vb" Inherits="CourseListing" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
   <div>
   <h3>Listing of Employee who has not till completed a particular course</h3><br />
   
 <asp:LinqDataSource 
                ID="lds" runat="server"
                ContextTypeName="CourseListDataContext"
                TableName="CourseLists" 
               Select="new(Key, Count() as Count, It as Items)" GroupBy="CodeCourse" OrderGroupsBy="key"

            />
            <div>              
                <asp:UpdatePanel ID="upd" runat="server">
                    <ContentTemplate>
                        <asp:ListView ID="lvCourse" runat="server" DataSourceID="lds" OnSorting="LvSorting" OnSorted="LvSorted">
                            <LayoutTemplate>
                                <div id="grid" class="lv_vista">
                                    <div class="titlebar-teal">Employee Listing By Course<asp:LinkButton ID="btnSort" runat="server" 
                                                   CssClass="sort asc" Width ="13px" CommandName="Sort"/></div>
                                    <table class="datatable" cellpadding="0" cellspacing="0">
                                        <tr class="header">
                                            <th class="first">&nbsp;</th>
                                            <th>#</th>
                                            <th>ID</th>
                                            <th>Employee Name</th>
                                            <th>Hire Date</th>
                                            <th align = "center">Is Pass?</th>
                                        </tr>
                                        <tr id="itemPlaceholder" runat="server" /> 
                                    </table>
                                    <table class="datapager" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <asp:DataPager ID="pager" runat="server" PageSize="12">
                                                <Fields>
                                                    <asp:TemplatePagerField OnPagerCommand="PagerCommand">
                                                        <PagerTemplate>
                                                            <td class="commands">
                                                                <asp:LinkButton ID="btnFirst" runat="server" CommandName="First" CssClass="first-page page-command" AlternateText="First Page" ToolTip="First Page" />
                                                                <asp:LinkButton ID="btnPrevious" runat="server" CommandName="Previous" CssClass="prev-page page-command" AlternateText="Previous Page" ToolTip="Previous Page" />    
                                                                <asp:LinkButton ID="btnNext" runat="server" CommandName="Next" CssClass="next-page page-command" AlternateText="Next Page" ToolTip="Next Page" />
                                                                <asp:LinkButton ID="btnLast" runat="server" CommandName="Last" CssClass="last-page page-command" AlternateText="Last Page" ToolTip="Last Page" />                                                                                                           
                                                            </td>
                                                            <td class="info">
                                                                Page 
                                                                <b>
                                      <%#If(Container.TotalRowCount > 0, Math.Ceiling((CDbl((Container.StartRowIndex + Container.MaximumRows)) / Container.MaximumRows)), 0)%>
                                                                </b>
                                                                of
                                                                <b>
                                                                    <%#Math.Ceiling(CDbl(Container.TotalRowCount) / Container.MaximumRows)%>
                                                                </b>
                                                                (<%# Container.TotalRowCount %> items)  
                                                            </td>                                                          
                                                        </PagerTemplate>
                                                    </asp:TemplatePagerField>
                                                </Fields>
                                            </asp:DataPager>
                                        </tr>                                 
                                    </table>
                                </div>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr class="group">
                                    <th class="first">
                                        <a class="toggle expand" title='Group: <%# Eval("Key")%>' href="#" onclick="toggleGroup(this, '<%# Eval("count") %>');" />
                                    </th>
                                    <th colspan="4"><%# Eval("Key")%></th><th colspan="2" > <%# Eval("Count") %> Employee(s)</th>
                                </tr>
                                <asp:ListView ID="lvEmp" runat="server" DataSource='<%# Eval("Items") %>'>
                                    <LayoutTemplate>
                                        <tr runat="server" id="itemPlaceholder" />
                                    </LayoutTemplate>
                                    <ItemTemplate>
                                        <tr class='hidden <%# If(Container.DisplayIndex Mod 2 = 0, "item", "altitem") %>'>
                                            <td class="first">&nbsp;</td>
                                            <td><b><%# Container.DataItemIndex + 1 %></td>
                                            <td><%#Eval("EmployeeID")%></td>
                                            <td><%#Eval("Name")%></td>
                                            <td><%#CType(Eval("HireDate"), Date).ToString("dd-MMM-yy")%></td>
                                           <%-- <td><%#Eval("isPass")%></td>--%>
                                            <td align ="center" ><img alt="" src="Img/no2.gif" style="width: 16px; height: 16px" /></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:ListView>
                            </ItemTemplate>
                        </asp:ListView>
                    </ContentTemplate>
                </asp:UpdatePanel>  
            </div>          
        </div>
            <img src="Img/spacer.gif" height="200px" width="5px" /><br />

<script type="text/javascript">
    function toggleGroup(e, numberOfRows) {
        var tr = e.parentNode.parentNode;
        var table = tr.parentNode.parentNode;
       var startIndex = tr.rowIndex + 1;
        var stopIndex = startIndex + parseInt(numberOfRows);
        if (Sys.UI.DomElement.containsCssClass(e, 'expand')) {
            for (var i = startIndex; i < stopIndex; i++) {
                Sys.UI.DomElement.removeCssClass(table.rows[i], 'hidden');
            }
           Sys.UI.DomElement.removeCssClass(e, 'expand');
            Sys.UI.DomElement.addCssClass(e, 'collapse');
        }
        else {
            for (var i = startIndex; i < stopIndex; i++) {
                Sys.UI.DomElement.addCssClass(table.rows[i], 'hidden');
            }
           Sys.UI.DomElement.removeCssClass(e, 'collapse');
            Sys.UI.DomElement.addCssClass(e, 'expand');
        }
    }
    </script>
</asp:Content>


