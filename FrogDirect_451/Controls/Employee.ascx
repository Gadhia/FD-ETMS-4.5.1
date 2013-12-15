<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Employee.ascx.vb" Inherits="Controls_Employee" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<%@ Register src="EmployeeCourse.ascx" tagname="EmployeeCourse" tagprefix="uc1" %>


<asp:Panel ID="pnlEditor" Width="400px" runat ="server" >
</asp:Panel>

<SCRIPT LANGUAGE="JavaScript" SRC="js/ss_datepicker_settings.js"></SCRIPT>
<SCRIPT LANGUAGE="JavaScript" SRC="js/ss_datepicker.js"></SCRIPT>

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
    Employee ID
         </th>
        <td>
            <asp:Label ID="lblID" Text="0" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <th class ="gv-th">
           Employee Name</th>
        <td>
            <asp:TextBox ID="txtName" runat="server" Width="325px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="txtName" ErrorMessage="Employee Name Required!">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <th class ="gv-th">
            Hire Date </th>
        <td>
        
			
            <asp:TextBox ID="txtHireDate" runat="server" MaxLength="10" Width="70px"></asp:TextBox>
            <asp:ImageButton ImageUrl="~/Img/cal.gif" ID="ibDate" runat="server" CausesValidation="False" />
            <ajaxToolkit:CalendarExtender runat="server" 
                        CssClass="dp" 
                        PopupButtonID="ibDate" 
                        TargetControlID="txtHireDate" />
                        
                        
   <%--        		
   <asp:ImageButton ImageUrl="~/Img/cal.gif" ID="ImageButton1" runat="server" />
   <SCRIPT type="text/javascript">
					var cal= new CalendarPopup("divCalendar");
					cal.showNavigationDropdowns();
				</SCRIPT>      

       <img src="~/Img/cal.gif" 
            onclick='showDatePicker(this, frmMain.ctl00_ContentPlaceHolder1_Employee1_txtHireDate)' 
             style="width: 16px; height: 16px; padding-left: 5px;" 
                id="Image1" runat ="server"  />
                      	     <input type=button onclick='showDatePicker(this, document.form1.ctl00_ContentPlaceHolder1_Employee1_txtHireDate)' value='...'> 

<asp:ImageButton ImageUrl="~/Img/cal.gif" ID="ImageButton1" runat="server" />
         	<asp:HyperLink id="lnkDate" Runat="server" NavigateUrl="javascript:void(cal.select(document.forms[0].elements['{0}'], '{1}', 'MM/dd/yyyy'));">

            <img src="Img/cal.gif"  style="width: 16px; height: 16px; padding-left: 5px;" />

			</asp:HyperLink>--%>
				
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="txtHireDate" ErrorMessage="Hire Date Required!">*</asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" 
                ControlToValidate="txtHireDate" ErrorMessage="Enter valid date." 
                Operator="DataTypeCheck" Type="Date">*</asp:CompareValidator>
        </td>
    </tr>
     <tr id="trStatus1" runat ="server">
          <td colspan="2" class ="gv-tl">
            <asp:Label ID="lblStatus" Text="Course status:" runat="server"></asp:Label>
        </td>
        </tr>
    <tr id="trStatus2" runat ="server">
        <td colspan="2" >
            <uc1:EmployeeCourse ID="EmployeeCourse1" runat="server" Mode ="Edit" />
        </td>
    </tr>
    <tr>
    <td colspan="2" class ="gv-ft">
           
<asp:Button ID="btnAddEdit" runat="server" Font-Bold="True" 
                 />&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCancel" runat="server" CausesValidation="False" 
                               Text=" Cancel " Visible="False" Font-Bold="True" />
                               
            </td>
    </tr>
    
    
</table>
<%--	<DIV id="divCalendar" style="VISIBILITY: hidden; POSITION: absolute; BACKGROUND-COLOR: white; layer-background-color: white"></DIV>
--%>

</asp:Panel>