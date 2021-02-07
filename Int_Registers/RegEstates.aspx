<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true" CodeBehind="RegEstates.aspx.cs" Inherits="Ers_Pro.RegEstates" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="AjaxFixedUpdateProgress" Namespace="AjaxFixedUpdateProgress" TagPrefix="cc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ajax:ToolkitScriptManager ID="ScriptManager1" runat="server">
    </ajax:ToolkitScriptManager>

    <asp:UpdatePanel ID="updatepanel1" runat="server">
        <ContentTemplate>
            <table cellspacing="0" cellpadding="0">

                <tr>
                    <td>
                        <table>
                            <tr>
                                <td class="label">حوزه مالیاتی:</td>
                                <td>
                                    <asp:TextBox AutoCompleteType="Disabled" ID="Txt_Hozeh" runat="server" CssClass="normal_TextBox" Enabled="False"></asp:TextBox></td>

                                <td class="label">کلاسه پرونده:</td>
                                <td>
                                    <asp:TextBox AutoCompleteType="Disabled" ID="Txt_Klasse" runat="server" CssClass="normal_TextBox"></asp:TextBox></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="Txt_Klasse" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
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
                                <td></td>
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
                                    <asp:Label ID="Lbl_DedName" runat="server"   SkinID="Lbl_Normal"></asp:Label>
                                </td>
                                <td></td>
                                <td class="label">کدملی متوفی:</td>
                                <td class="lable">
                                    <asp:Label ID="Lbl_DedNationalcode" SkinID="Lbl_Normal" runat="server"  ></asp:Label>
                                </td>
                            </tr>
                        </table>

                    </td>
                </tr>
                <tr>
                    <td>

                        <table>
                            <tr>
                                <td class="label">نوع دارایی:
                                </td>
                                <td>
                                    <asp:DropDownList ID="Ddl_Estatetype" CssClass="normal_DropDownList" runat="server" AppendDataBoundItems="True" DataSourceID="Lds_EstateType" DataTextField="xEstType" DataValueField="xEstTypeId_pk">
                                        <asp:ListItem Text="" Value="" />
                                    </asp:DropDownList>
                                </td>
                                <td dir="rtl">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Ddl_Estatetype" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>

                            </tr>

                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td class="label">شرح دارایی:
                                </td>
                                <td>
                                    <asp:TextBox AutoCompleteType="Disabled" ID="Txt_EstateDesc" runat="server" CssClass=" normal_TextBox" Width="549px" Height="60px" TextMode="MultiLine"></asp:TextBox>
                                </td>
                                <td dir="rtl">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="Txt_EstateDesc" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
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

                                    <asp:Button ID="Btn_New" CssClass="btn-Public" runat="server" Text="جدید" OnClick="Btn_New_Click" Visible="False" />

                                    <asp:Button ID="Btn_Cancel" runat="server" CssClass="btn-Cancel" OnClick="Btn_Cancel_Click" Text="انصراف" Visible="False" />

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
                <tr>
                    <td>
                        <asp:GridView ID="Gvw_Estate" runat="server" SkinID="Mto_Gvw" AutoGenerateColumns="false"
                            AllowPaging="True" DataKeyNames="xEstId_pk" OnSelectedIndexChanged="Gvw_Estate_SelectedIndexChanged" OnRowDeleting="Gvw_Estate_RowDeleting" OnPageIndexChanging="Gvw_Estate_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="ردیف" ControlStyle-Width="35px">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="نوع دارایی " DataField="EstateType" />
                                <asp:BoundField HeaderText="شرح دارایی" DataField="xEstDescription" />
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
            </table>
            <asp:LinqDataSource ID="Lds_EstateType" runat="server" ContextTypeName="Ers_Pro.App_Code.Intd_Lts.Lts_InheritedDataContext" EntityTypeName="" Select="new (xEstType, xEstTypeId_pk)" TableName="Tb_EstateTypes">
            </asp:LinqDataSource>
            <asp:HiddenField ID="Hfld_Command" runat="server" Value="Save" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
        <ProgressTemplate>
            <cc3:AjaxFixedUpdateProgress ID="AjaxFixedUpdateProgress1" runat="server">
            </cc3:AjaxFixedUpdateProgress>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
