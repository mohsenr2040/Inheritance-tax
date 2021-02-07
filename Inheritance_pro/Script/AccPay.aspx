<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true" CodeBehind="AccPay.aspx.cs" Inherits="Ers_Pro.AccPay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 138px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table dir="rtl">
        <tr>
            <td>
                <table>
                    <tr>
                        <td class="label">کد ملی متوفی:</td>
                        <td class="label">
                            <asp:TextBox ID="TxtNationalcode" runat="server" CssClass="normal_TextBox"></asp:TextBox>
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
                        <td>
                            <asp:Button ID="Btn_Search" runat="server" CssClass="btn-search" OnClick="Btn_Search_Click" Text="جستجو" CausesValidation="False" ValidateRequestMode="Disabled" />
                        </td>
                    </tr>
                </table>

            </td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td class="label">شماره گواهی:
                        </td>
                        <td class="label">
                            <asp:TextBox ID="Txt_CrtNo" runat="server" CssClass="normal_TextBox"></asp:TextBox>
                        </td>
                        <td class="auto-style2" dir="rtl">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Txt_CrtNo" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                        <td class="label">تاریخ گواهی:
                        </td>
                        <td class="auto-style2">
                            <asp:DropDownList ID="Ddl_day" Style="margin-left: 0px" runat="server" CssClass="normal_DropDownList" Width="46px">
                            </asp:DropDownList>
                            <asp:DropDownList ID="Ddl_Mounth" Style="margin-left: 0px" runat="server" CssClass="normal_DropDownList" Width="50px">
                            </asp:DropDownList>
                            <asp:DropDownList ID="Ddl_Year" Style="margin-left: 0px" CssClass="normal_DropDownList" runat="server" Width="70px">
                            </asp:DropDownList></td>
                        <td class="auto-style3" dir="rtl">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Ddl_day" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="Ddl_Mounth" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="Ddl_Year" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td  class="label">

                            وراث :</td>
                         <td  class="lable">

                             <asp:CheckBoxList ID="Chk_Heirs" CssClass="normal_TextBox" runat="server">
                             </asp:CheckBoxList>

                        </td>
                        <td></td>
                         <td  class="label">

                             دارایی ها:</td>
                         <td >

                             <asp:CheckBoxList ID="Chk_Estates" CssClass="normal_TextBox" runat="server">
                             </asp:CheckBoxList>

                        </td>
                        <td></td>

                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table class="btn-tbl" dir="ltr">
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button runat="server" ID="Btn_Sodor" CssClass="btn-Public" Text="صدور گواهی" OnClick="Btn_Sodor_Click"  />

                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td class="auto-style1">&nbsp;</td>
                        <td>
                            <asp:Label ID="Lbl_Msg" runat="server" Visible="False" ForeColor="#33CC33"></asp:Label>

                        </td>
                        <td>&nbsp;</td>
                    </tr>

                </table>
            </td>

        </tr>

    </table>

</asp:Content>
