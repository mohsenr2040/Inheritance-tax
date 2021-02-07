<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true" CodeBehind="AccPay.aspx.cs" Inherits="Ers_Pro.AccPay" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="AjaxFixedUpdateProgress" Namespace="AjaxFixedUpdateProgress" TagPrefix="cc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <ajax:ToolkitScriptManager ID="ScriptManager1" runat="server">
    </ajax:ToolkitScriptManager>
    <asp:UpdatePanel ID="updatepanel1" runat="server">
        <ContentTemplate>
            <table dir="rtl" id="MainTable" runat="server" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <table >
                            <tr>
                                <td class="label">حوزه مالیاتی:</td>
                                <td  class="lable">
                                    <asp:TextBox AutoCompleteType="Disabled" ID="Txt_Hozeh" runat="server" CssClass="normal_TextBox" Enabled="False"></asp:TextBox></td>

                                <td class="label">کلاسه پرونده:</td>
                                <td>
                                    <asp:TextBox AutoCompleteType="Disabled" ID="Txt_Klasse" runat="server" CssClass="normal_TextBox"></asp:TextBox></td>
                                <td>&nbsp;</td>
                            </tr>

                        </table>
                    </td>
                </tr>
                <tr>
                    <td>

                        <table class="btn-tbl" dir="ltr">
                            <tr>
                                <td>
                                    <asp:Button ID="Btn_Search" runat="server" CssClass="btn-search" OnClick="Btn_Search_Click" Text="جستجو" CausesValidation="False" ValidateRequestMode="Disabled" />
                                </td>
                                <td></td>

                            </tr>
                        </table>

                    </td>
                </tr>
                <tr>
                    <td>

                        <table cellpadding="0" cellspacing="0">
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
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="label">شماره گواهی:
                                </td>
                                <td class="lable">
                                    <asp:TextBox AutoCompleteType="Disabled" ID="Txt_CrtNo" runat="server" CssClass="normal_TextBox"></asp:TextBox>
                                </td>
                                <td dir="rtl">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Txt_CrtNo" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                                <td class="label">تاریخ گواهی:
                                </td>
                                <td class="lable">

                                    <asp:DropDownList ID="Ddl_day" runat="server" CssClass="normal_DropDownList" Style="margin-left: 0px" Width="46px">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="Ddl_Mounth" runat="server" CssClass="normal_DropDownList" Style="margin-left: 0px" Width="50px">
                                    </asp:DropDownList>

                                    <asp:DropDownList ID="Ddl_Year" runat="server" CssClass="normal_DropDownList" Style="margin-left: 0px" Width="70px">
                                    </asp:DropDownList>

                                </td>
                                <td dir="rtl">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Ddl_day" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="Ddl_Mounth" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="Ddl_Year" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="label">وراث :</td>
                                <td>

                                    <asp:CheckBoxList ID="Chk_Heirs" CssClass="address_TextBox" runat="server" RepeatColumns="2">
                                        <asp:ListItem Value="0"> وراث...</asp:ListItem>
                                    </asp:CheckBoxList>

                                </td>
                            </tr>
                            <tr>
                                <td class="label">دارایی ها:</td>
                                <td>
                                    <asp:CheckBoxList ID="Chk_Estates" runat="server" CssClass="address_TextBox" RepeatColumns="2">
                                        <asp:ListItem Value="0">دارایی...</asp:ListItem>
                                    </asp:CheckBoxList>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="label">ارائه به:
                                </td>
                                <td>
                                    <asp:TextBox ID="Txt_Nahad" runat="server" AutoCompleteType="Disabled" CssClass="normal_TextBox"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Txt_Nahad" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>

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
                                    <asp:Button runat="server" ID="Btn_Sodor" CssClass="btn-Public" Text="صدور گواهی" OnClick="Btn_Sodor_Click" />

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
                                    <asp:Label ID="Lbl_Msg" runat="server" Visible="False" ForeColor="#33CC33"></asp:Label>

                                </td>

                            </tr>

                        </table>
                    </td>

                </tr>
                <tr>
                    <td class="caption" style="background-color: #CCFFCC; height: 20px" id="tdcaption" runat="server" visible="false">گواهی های صادر شده
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="Gvw_CertPay" runat="server" SkinID="Mto_Gvw" AutoGenerateColumns="false"
                            AllowPaging="True" DataKeyNames="xCrtId_pk" OnSelectedIndexChanged="Gvw_CertPay_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField HeaderText="شماره گواهی " DataField="xCrtRegNo" />
                                <asp:BoundField HeaderText=" تاریخ گواهی" DataField="xCrtRegDate" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="Lbtn_Print" runat="server" CommandName="select" CausesValidation="False" Text="مشاهده و چاپ">

                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>

                    </td>
                </tr>
                <tr>
                    <td></td>
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
