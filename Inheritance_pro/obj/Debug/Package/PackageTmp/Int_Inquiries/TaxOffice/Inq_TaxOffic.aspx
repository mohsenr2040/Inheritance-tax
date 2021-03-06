﻿<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true" CodeBehind="Inq_TaxOffic.aspx.cs" Inherits="Ers_Pro.Int_Inquiries.TaxOffice.Inq_TaxOffic" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="AjaxFixedUpdateProgress" Namespace="AjaxFixedUpdateProgress" TagPrefix="cc3" %>
<%@ Register Assembly="MaskTextBox" Namespace="MaskTextBox" TagPrefix="mtx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <ajax:ToolkitScriptManager ID="ScriptManager1" runat="server">
    </ajax:ToolkitScriptManager>
    <asp:UpdatePanel ID="updatepanel1" runat="server">
        <ContentTemplate>
            <table>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td class="label">حوزه مالیاتی:</td>
                                <td>
                                    <asp:TextBox AutoCompleteType="Disabled" ID="Txt_Hozeh" runat="server" CssClass="normal_TextBox" Enabled="False"></asp:TextBox></td>
                                <td></td>
                                <td class="label">کلاسه پرونده:</td>
                                <td>
                                    <asp:TextBox AutoCompleteType="Disabled" ID="Txt_Klasse" runat="server" CssClass="normal_TextBox"></asp:TextBox></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Txt_Klasse" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>

                        </table>

                    </td>
                </tr>
                <tr>
                    <td>

                        <table class="btn-tbl" dir="ltr">
                            <tr>
                                <td>
                                    <asp:Button ID="Btn_Search" runat="server" CssClass="btn-search" Text="جستجو" CausesValidation="False" OnClick="Btn_Search_Click" />
                                </td>
                            </tr>
                        </table>

                    </td>
                </tr>
                <tr>
                    <td>

                        <table>
                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <td class="label">نام متوفی:</td>
                                            <td class="label_Search">
                                                <asp:Label ID="Lbl_DedName" runat="server" SkinID="Lbl_Normal"></asp:Label>
                                            </td>
                                            <td></td>
                                            <td class="label">کدملی متوفی:</td>
                                            <td class="lable">
                                                <asp:Label ID="Lbl_DedNationalcode" SkinID="Lbl_Normal" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>

                        </table>

                    </td>
                </tr>

                <tr>
                    <td>
                        <table class="table">
                            <tr>
                                <td class="label">شماره استعلام:
                                </td>
                                <td class="lable">
                                    <asp:TextBox AutoCompleteType="Disabled" ID="Txt_InqNo" runat="server" CssClass="normal_TextBox"></asp:TextBox>
                                </td>
                                <td dir="rtl">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Txt_InqNo" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                                <td class="label">تاریخ استعلام:
                                </td>
                                <td class="Calender-td">
                                    <mtx:TextDatePicker ID="Tdp_InqDate" runat="server" CssClass="Calender" dir="rtl"></mtx:TextDatePicker>
                                </td>
                                <td dir="rtl"></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td class="label">دارایی ها:</td>
                                <td class="lable">
                                    <asp:CheckBoxList ID="Chk_Estates" CssClass="address_TextBox" runat="server" RepeatColumns="2">
                                        <asp:ListItem Value="0">دارایی ها....</asp:ListItem>
                                    </asp:CheckBoxList>

                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table class="table">
                            <tr>
                                <td class="label">اداره امور مالیاتی :
                                </td>
                                <td class="lable">
                                    <asp:TextBox ID="Txt_Office" AutoCompleteType="Disabled" runat="server" CssClass="normal_TextBox"></asp:TextBox>
                                </td>


                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table class="btn-tbl" dir="ltr">
                            <tr>
                                <td>
                                    <asp:Button ID="Btn_Sodor" runat="server" CssClass="btn-Public" OnClick="Btn_Sodor_Click" Text="صدور استعلام" Enabled="False" />
                                </td>

                            </tr>
                        </table>
                    </td>
                </tr>


                <tr>
                    <td>
                        <table>
                            <tr>
                                <td class="caption">پیغام سیستم :</td>
                                <td>
                                    <asp:Label ID="Lbl_Msg" runat="server" ForeColor="#33CC33" Visible="False"></asp:Label>
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
