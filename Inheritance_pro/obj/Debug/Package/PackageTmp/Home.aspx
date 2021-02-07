<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Ers_Pro.Home" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxFixedUpdateProgress" Namespace="AjaxFixedUpdateProgress" TagPrefix="cc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="shortcut icon" type="image/x-icon" href="App_Themes/Icon/Web_icon.ico" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
      <cc1:ToolkitScriptManager ID="ScriptManager1" runat="server">

      </cc1:ToolkitScriptManager>
    <asp:UpdatePanel ID="updatepanel1" runat="server">
        <ContentTemplate>
            <table style="width: 100%; height: 100%">
                <tr>
                    <td>
                      </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
        <ProgressTemplate >
            <cc3:AjaxFixedUpdateProgress  ID="AjaxFixedUpdateProgress1" runat="server">
                
            </cc3:AjaxFixedUpdateProgress>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
