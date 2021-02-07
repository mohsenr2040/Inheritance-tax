<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rpt_Print.aspx.cs" Inherits="Ers_Pro.Int_Cert.Rpt_Print" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" style="margin:0;">
         <ajax:ToolkitScriptManager ID="ScriptManager1" runat="server">
    </ajax:ToolkitScriptManager>
    <div>
    <rsweb:ReportViewer ID="Rpt_Viw1" runat="server" AsyncRendering="false" Height="29.7cm" Width="21cm" DocumentMapWidth="100%" ShowBackButton="False" ShowCredentialPrompts="False" ShowDocumentMapButton="False" ShowExportControls="False" ShowFindControls="False" ShowPageNavigationControls="False" ShowParameterPrompts="False" ShowPromptAreaButton="False" ShowRefreshButton="False" ShowZoomControl="False" SizeToReportContent="True" ShowPrintButton="False">
     </rsweb:ReportViewer>
    </div>
    </form>
</body>
</html>
