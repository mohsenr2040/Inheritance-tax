<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true" CodeBehind="ApplyFormReg.aspx.cs" Inherits="Ers_Pro.ApplyFormReg" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="AjaxFixedUpdateProgress" Namespace="AjaxFixedUpdateProgress" TagPrefix="cc3" %>
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
                                <td class="auto-style1">&nbsp;&nbsp;</td>
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
                                <td class="label">نام متوفی:</td>
                                <td class="label_Search">
                                    <asp:Label ID="Lbl_DedName" runat="server" SkinID="Lbl_Normal"></asp:Label>
                                </td>
                                <td>&nbsp;&nbsp;</td>
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
                        <table>
                            <tr>
                                <td class="label">کد هویتی:</td>
                                <td class="lable">
                                    <asp:TextBox ID="Txt_CodeHoviati" runat="server" AutoCompleteType="Disabled" CssClass="normal_TextBox"></asp:TextBox>
                                    <ajax:FilteredTextBoxExtender ID="Filteredtextboxextender6" runat="server" FilterType="Numbers" TargetControlID="Txt_CodeHoviati">
                                    </ajax:FilteredTextBoxExtender>
                                </td>
                                <td class="auto-style9" dir="rtl">&nbsp;</td>
                                <td class="label">&nbsp;</td>
                                <td class="lable">&nbsp;</td>
                                <td class="auto-style3" dir="rtl">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="label">شماره درخواست:
                                </td>
                                <td class="lable">
                                    <asp:TextBox AutoCompleteType="Disabled" ID="Txt_AppNo" runat="server" CssClass="normal_TextBox"></asp:TextBox>
                                </td>
                                <td class="auto-style5" dir="rtl">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Txt_AppNo" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                                <td class="lable">تاریخ درخواست:
                                </td>
                                <td class="lable">
                                    <asp:TextBox AutoCompleteType="Disabled" ID="Txt_ApplyDate" dir="ltr" CssClass="Txt_Date" runat="server"></asp:TextBox>
                                    <ajax:MaskedEditExtender ID="Msk_Date" InputDirection="LeftToRight" runat="server" Filtered="" ClearMaskOnLostFocus="false" TargetControlID="Txt_ApplyDate" Mask="9999/99/99"></ajax:MaskedEditExtender>
                                </td>
                                <td class="auto-style4" dir="rtl">
                                    <asp:RegularExpressionValidator ID="valRegDate" runat="server" ControlToValidate="Txt_ApplyDate" ErrorMessage="*" ForeColor="Red" ValidationExpression="(13[0-9][0-9])/(0[1-9]|1[012])/(0[1-9]|[12][0-9]|3[01])" ValidationGroup="OrderAdd"></asp:RegularExpressionValidator>

                                </td>
                            </tr>
                            <tr>
                                <td class="label">شماره حصر وراثت:
                                </td>
                                <td>
                                    <asp:TextBox AutoCompleteType="Disabled" ID="Txt_HasrNo" runat="server" CssClass="normal_TextBox"></asp:TextBox>
                                </td>
                                <td dir="rtl" class="auto-style8">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Txt_HasrNo" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                                <td class="label">تاریخ حصر وراثت: </td>
                                <td>
                                    <asp:TextBox AutoCompleteType="Disabled" ID="Txt_HasrDate" dir="ltr" CssClass="Txt_Date" runat="server"></asp:TextBox>
                                    <ajax:MaskedEditExtender ID="MaskedEditExtender1" InputDirection="LeftToRight" runat="server" Filtered="" ClearMaskOnLostFocus="false" TargetControlID="Txt_HasrDate" Mask="9999/99/99"></ajax:MaskedEditExtender>

                                    <td style="direction: rtl" class="auto-style4" dir="rtl">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Txt_HasrDate" ErrorMessage="*" ForeColor="Red" ValidationExpression="(13[0-9][0-9])/(0[1-9]|1[012])/(0[1-9]|[12][0-9]|3[01])" ValidationGroup="OrderAdd"></asp:RegularExpressionValidator>

                                    </td>
                            </tr>
                            <tr>
                                <td class="label">شعبه دادگاه :
                                </td>
                                <td class="lable">
                                    <asp:TextBox AutoCompleteType="Disabled" ID="Txt_ShobeNo" runat="server" CssClass="normal_TextBox"></asp:TextBox>
                                </td>
                                <td dir="rtl" class="auto-style9">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Txt_ShobeNo" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                                <td class="label">دادگاه :
                                </td>
                                <td class="lable">
                                    <asp:TextBox AutoCompleteType="Disabled" ID="Txt_Dadgah" runat="server" CssClass="normal_TextBox"></asp:TextBox>
                                </td>
                                <td class="auto-style3" dir="rtl">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="Txt_Dadgah" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>

                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table class="btn-tbl" dir="ltr">
                            <tr>
                                <td class="btn-td">

                                    <asp:Button runat="server" ID="Btn_Save" CssClass="btn-save" Text="ذخیره" OnClick="Btn_Save_Click" Enabled="False" />

                                </td>
                                <td>

                                    <asp:Button ID="Btn_New" CssClass="btn-Public" runat="server" Text="جدید" OnClick="Btn_New_Click" Visible="False" Width="80px" />

                                    <asp:Button ID="Btn_Cancel" runat="server" CausesValidation="False" CssClass="btn-Cancel" OnClick="Btn_Cancel_Click" Text="انصراف" Visible="False" />

                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>

                <tr>
                    <td></td>
                </tr>

                <tr>
                    <td dir="rtl">
                        <asp:GridView ID="Gvw_Applies" runat="server" SkinID="Mto_Gvw" AutoGenerateColumns="false"
                            AllowPaging="True" DataKeyNames="xAppId_pk" OnRowDeleting="Gvw_Applies_RowDeleting" OnSelectedIndexChanged="Gvw_Applies_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField HeaderText="شماره درخواست " DataField="xAppRegNo" />
                                <asp:BoundField HeaderText=" تاریخ درخواست" DataField="xAppRegDate" />
                                <asp:BoundField HeaderText="شماره حصر وراثت" DataField="xAppHasrNo" />
                                <asp:BoundField HeaderText="تاریخ حصر وراثت" DataField="xAppHasrDate" />
                                <asp:BoundField HeaderText="دادگاه" DataField="xAppDadgah" />
                                <asp:BoundField HeaderText="شعبه" DataField="xAppShobeDadgah" />
                                <asp:BoundField HeaderText="کد هویتی" DataField="Str_xCodeHoviati" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="Ibtn_Edit" runat="server" CommandName="Select" SkinID="Ibtn_Edit" CausesValidation="False" />
                                        <asp:ImageButton ID="Ibtn_Delete" runat="server" CommandName="Delete" OnClientClick="return confirm('آیا برای عملیات حذف مطمئن هستید؟')"
                                            SkinID="Ibtn_Del" CausesValidation="False" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HiddenField ID="Hfld_Command" runat="server" Value="Save" />
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
