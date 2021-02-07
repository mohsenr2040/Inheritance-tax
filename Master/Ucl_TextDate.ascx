<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Ucl_TextDate.ascx.cs" Inherits="Ers_Pro.Master.Ucl_TextDate" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<table dir="rtl" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <asp:TextBox AutoCompleteType="Disabled" ID="Txt_Date" dir="ltr" CssClass="Txt_Date" runat="server"></asp:TextBox>
            <ajax:maskededitextender  id="Msk_Date" ViewStateMode="Enabled"   inputdirection="LeftToRight" runat="server" filtered="" clearmaskonlostfocus="false" targetcontrolid="Txt_Date" mask="9999/99/99" ClipboardEnabled="True"></ajax:maskededitextender>
         </td>
        <td style="direction: rtl " dir="rtl"> 
             <asp:RegularExpressionValidator ID="valRegDate" runat="server" ControlToValidate="Txt_Date" ErrorMessage="*" ForeColor="Red" ValidationExpression="(13[0-9][0-9])/(0[1-9]|1[012])/(0[1-9]|[12][0-9]|3[01])" ValidationGroup="OrderAdd"></asp:RegularExpressionValidator>
        </td>
    </tr>
</table>
