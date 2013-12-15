<%@ Page Title="" Language="VB" MasterPageFile="~/Frog.master" AutoEventWireup="false" CodeFile="AjaxTest.aspx.vb" Inherits="Test_AjaxTest" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


  <asp:Panel ID="VA_hd" runat="server" style="cursor: pointer;">
         aaa: 
           
   </asp:Panel>
 

  <asp:Panel id="VA_dt" runat="server" style="overflow:hidden;">
    aaa  
</asp:Panel>

    
 <ajaxtoolkit:collapsiblepanelextender ID="cx_GP" runat="Server"
            TargetControlID="VA_dt"
            ExpandControlID="VA_hd"
            CollapseControlID="VA_hd"
            Collapsed="True"
            ExpandDirection="Vertical"
            ImageControlID="VA_tg"
            ExpandedImage="~/img/a-up.png"
            ExpandedText="Expand"
            CollapsedImage="~/img/a-down.png"
            CollapsedText="Collapse"
            SuppressPostBack="true" /> 
            <br />
 
</asp:Content>

