<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true" CodeBehind="RegPreControl.aspx.cs" Inherits="Ers_Pro.RegPreControl" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="AjaxFixedUpdateProgress" Namespace="AjaxFixedUpdateProgress" TagPrefix="cc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ajax:ToolkitScriptManager ID="ScriptManager1" runat="server">
    </ajax:ToolkitScriptManager>

    <asp:UpdatePanel ID="updatepanel1" runat="server">
        <ContentTemplate>
            <table dir="rtl" class="table">
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td class="label">کد ملی متوفی:</td>
                                <td class="label">
                                    <asp:TextBox AutoCompleteType="Disabled" ID="TxtNationalcode" runat="server" CssClass="normal_TextBox" MaxLength="10"></asp:TextBox>
                                    <ajax:FilteredTextBoxExtender ID="Filteredtextboxextender3" runat="server" FilterType="Numbers" TargetControlID="TxtNationalcode"></ajax:FilteredTextBoxExtender>
                                </td>

                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>

                        <table class="btn-tbl" dir="ltr">
                            <tr>
                                <td></td>
                                <td style="width: 300px">
                                    <asp:Button ID="Btn_Search" runat="server" CssClass="btn-Public2" Text="بررسی" CausesValidation="False" ValidateRequestMode="Disabled" OnClick="Btn_Search_Click" />
                                </td>
                            </tr>
                        </table>

                    </td>
                </tr>
                <tr>
                    <td>
                        <table dir="rtl">
                            <tr>
                                <td class="caption">پیغام سیستم :</td>
                                <td>
                                    <asp:Label ID="Lbl_Msg" runat="server" Visible="False" ForeColor="#33CC33"></asp:Label>

                                </td>

                            </tr>

                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
        <ProgressTemplate>
            <cc3:AjaxFixedUpdateProgress ID="AjaxFixedUpdateProgress1" runat="server">
            </cc3:AjaxFixedUpdateProgress>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
