<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true" CodeBehind="Rpt_TaxOffice.aspx.cs" Inherits="Ers_Pro.Int_Inquiries.TaxOffice.Rpt_TaxOffice" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="AjaxFixedUpdateProgress" Namespace="AjaxFixedUpdateProgress" TagPrefix="cc3" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ajax:ToolkitScriptManager ID="ScriptManager1" runat="server">
    </ajax:ToolkitScriptManager>
     
    <asp:UpdatePanel ID="updatepanel1" runat="server">
        <ContentTemplate>
             <rsweb:ReportViewer ID="Rptv_InqOffice" runat="server" AsyncRendering="false" DocumentMapWidth="100%" Height="17cm" ShowBackButton="False" ShowCredentialPrompts="False" ShowDocumentMapButton="False" ShowExportControls="False" ShowFindControls="False" ShowPageNavigationControls="False" ShowParameterPrompts="False" ShowPromptAreaButton="False" ShowRefreshButton="False" ShowZoomControl="False" SizeToReportContent="True" Width="21cm">
            </rsweb:ReportViewer>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
        <ProgressTemplate>
            <cc3:AjaxFixedUpdateProgress ID="AjaxFixedUpdateProgress1" runat="server">
            </cc3:AjaxFixedUpdateProgress>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
