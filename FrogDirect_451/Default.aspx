<%@ Page Title="Wecome to FrogDirect.com" Language="VB" MasterPageFile="~/Frog.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register src="Controls/App/Tech_Demonstrated.ascx" tagname="Tech_Demonstrated" tagprefix="uc2" %>

<%@ Register src="Controls/App/Visit_Apps.ascx" tagname="Visit_Apps" tagprefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

   <h3>Wecome to FrogDirect.com 
       
    </h3>
    
   <br />
   
           <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" CssClass ="tb">
              <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="<b>Application - A</b>">
      <ContentTemplate>       
     <div id="div0" class ="divTab">
       <b><img src="Img/arrow3.gif" style="width: 11px; height: 11px; padding-right: 15px;" />Application - A</b> <br /><br />
     <uc1:Visit_Apps Tab ="Tab_A" ID="Visit_Apps1" runat="server" /> 
     </div>

               </ContentTemplate>
              </ajaxToolkit:TabPanel >
       
              <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="<B>Application - B</B>">
 <ContentTemplate>

     <div id="div1" class ="divTab">
       <b><img src="Img/arrow3.gif" style="width: 11px; height: 11px; padding-right: 15px;" />Application - B</b> <br /><br />
   <uc1:Visit_Apps Tab ="Tab_B" ID="Visit_Apps3" runat="server" /> 
     </div>
               </ContentTemplate></ajaxToolkit:TabPanel>
              
               <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="<b>Application - C</b>" >
           <ContentTemplate>         

     <div id="div2" class ="divTab">
    <b><img src="Img/arrow3.gif" style="width: 11px; height: 11px; padding-right: 15px;" />Application - C</b> <br /><br />
     <uc1:Visit_Apps Tab ="Tab_C" ID="Visit_Apps4" runat="server" /> 
     </div>
  
               </ContentTemplate></ajaxToolkit:TabPanel>
              
              <ajaxToolkit:TabPanel ID="TabPanel4" runat="server"  HeaderText="<b>Application - D</b>" >
         <ContentTemplate>      
                 
     <div id="div3" class ="divTab">  <b><img src="Img/arrow3.gif" style="width: 11px; height: 11px; padding-right: 15px;" />Application - D</b> <br /><br />
    <uc1:Visit_Apps Tab ="Tab_D" ID="Visit_Apps5" runat="server" /> 
     </div>

          </ContentTemplate>     
          </ajaxToolkit:TabPanel>
      
      
          </ajaxToolkit:TabContainer>

   
   
   
        <br />
        
        
             <asp:Panel ID="VA__hd" runat="server" style="cursor: pointer;">
          <div class="cp_header">
            <asp:Image ID="VA__tg" runat="server" ImageUrl="~/Img/collapse.gif" /> Visit my other online applications : 
            </div>
   </asp:Panel>
 
 <div class="cp">
  <asp:Panel id="VA__dt" runat="server" style="overflow:hidden;">
    <div id="div4" class ="divTab" style="padding: 5px 5px 5px 15px">
    <uc1:Visit_Apps ID="Visit_Apps2" runat="server" /> 
    </div> 
</asp:Panel>

</div>
    
 <ajaxtoolkit:collapsiblepanelextender ID="Collapsiblepanelextender1" runat="Server"
            TargetControlID="VA__dt"
            ExpandControlID="VA__hd"
            CollapseControlID="VA__hd"
            Collapsed="True"
            ExpandDirection="Vertical"
            ImageControlID="VA__tg"
            ExpandedImage="~/Img/collapse.gif"
            ExpandedText="Expand"
            CollapsedImage="~/Img/expand.gif"
            CollapsedText="Collapse"
            SuppressPostBack="true" /> 
      
   <br />
        
 
       <asp:Panel ID="TD__hd" runat="server" style="cursor: pointer;" width ="603px">
          <div class="cp_header" width="700px">
            <asp:Image ID="TD__tg" runat="server" ImageUrl="~/Img/collapse.gif" /> Technologies Demonstrated: 
            </div>
   </asp:Panel>

 <div class="cp">
  <asp:Panel id="TD__dt" runat="server" style="overflow:hidden;" width ="601px">
    <uc2:Tech_Demonstrated ID="Tech_Demonstrated1" runat="server" width ="600px" /> 
</asp:Panel>

</div>
    
 <ajaxtoolkit:collapsiblepanelextender ID="cx_GP" runat="Server"
            TargetControlID="TD__dt"
            ExpandControlID="TD__hd"
            CollapseControlID="TD__hd"
            Collapsed="false"
            ExpandDirection="Vertical"
            ImageControlID="TD__tg"
            ExpandedImage="~/Img/collapse.gif"
            ExpandedText="Expand"
            CollapsedImage="~/Img/expand.gif"
            CollapsedText="Collapse"
            SuppressPostBack="true" /> 
            <br />

    <img src="Img/spacer.gif" height="10px" width="5px" /><br />
</asp:Content>



