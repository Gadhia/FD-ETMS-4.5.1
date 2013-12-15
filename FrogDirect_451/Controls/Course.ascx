<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Course.ascx.vb" Inherits="Controls_Course" %>

<asp:Panel ID="pnlEditor" Width="400px" runat ="server" >
</asp:Panel>

<asp:ValidationSummary ID="vlsMain" runat="server" 
    BorderStyle="None"
   Font-Size=Smaller  
   HeaderText="Please correct below ..." 
 />
<table class="gv" cellpadding="5" cellspacing="0">
    <tr>
        <td colspan="2" class ="gv-tl">
            <asp:Label ID="lblTitle" runat="server"></asp:Label>
        </td>
    </tr>
    <tr id="trID" runat ="server" >
        <th class ="gv-th">
            Course ID</th>
        <td>
            <asp:Label ID="lblID" Text="0"  runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <th class ="gv-th">
            Course Name</th>
        <td>
            <asp:TextBox ID="txtCourse" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="txtCourse" ErrorMessage="Name Required!">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <th class ="gv-th">
            Code </th>
        <td>
            <asp:TextBox ID="txtCode" runat="server" MaxLength="4" Width="45px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="txtCode" ErrorMessage="Code Required!">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <th valign="top" class ="gv-th">
            Description </th>
        <td>
            <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="5" 
                Width="437px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2" class ="gv-ft">
    
    <asp:Button ID="btnAddEdit" runat="server" Font-Bold="True" 
                 />
              &nbsp;&nbsp;&nbsp;
                   
            <asp:Button ID="btnCancel" runat="server" CausesValidation="False" 
                               Text=" Cancel " Visible="False" Font-Bold="True" />
                               
         </td>
    </tr>
    
    
</table>

