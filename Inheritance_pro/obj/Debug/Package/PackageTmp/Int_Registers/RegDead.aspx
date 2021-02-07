<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true" CodeBehind="RegDead.aspx.cs" Inherits="Ers_Pro.Int_Registers.RegDead" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="AjaxFixedUpdateProgress" Namespace="AjaxFixedUpdateProgress" TagPrefix="cc3" %>
<%@ Register Assembly="MaskTextBox" Namespace="MaskTextBox" TagPrefix="mtx" %>
<%@ Register Assembly="Ext_TextBox" Namespace="TextBoxExtention" TagPrefix="Ext" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="shortcut icon" type="image/x-icon" href="App_Themes/Icon/Web_icon.ico" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ajax:ToolkitScriptManager ID="ScriptManager1" runat="server">
    </ajax:ToolkitScriptManager>
    <asp:UpdatePanel ID="updatepanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
        <ContentTemplate>
            <table dir="rtl">

                <tr>
                    <td>

                        <table>
                            <tr>
                                <td class="label">حوزه مالیاتی:</td>
                                <td class="lable">
                                    <asp:TextBox AutoCompleteType="Disabled" ID="Txt_Hozeh" runat="server" CssClass="normal_TextBox" Enabled="False"></asp:TextBox></td>
                                <td>&nbsp;&nbsp;</td>
                                <td class="label">کلاسه پرونده:</td>
                                <td class="label">
                                    <asp:TextBox AutoCompleteType="Disabled" ID="Txt_Klasse" runat="server" CssClass="normal_TextBox" Enabled="False"></asp:TextBox></td>
                            </tr>

                        </table>

                    </td>
                </tr>
                <tr>
                    <td class="caption" style="background-color: #CCFFCC; height: 20px">مشخصات متوفی</td>
                </tr>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td class="label">شماره ملی:
                                </td>
                                <td class="lable">
                                    <table class="table" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="TxtNationalcode" runat="server" AutoCompleteType="Disabled" CssClass="normal_TextBox1" MaxLength="10"></asp:TextBox>
                                                <ajax:FilteredTextBoxExtender ID="Filteredtextboxextender3" runat="server" FilterType="Numbers" TargetControlID="TxtNationalcode">
                                                </ajax:FilteredTextBoxExtender>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="Imgbtn_Sssearch" runat="server" CausesValidation="False" ImageUrl="~/App_Themes/Skin/Pub_Images/SearchIt.gif" OnClick="Imgbtn_Sssearch_Click" Style="height: 16px" Enabled="False" />

                                            </td>
                                        </tr>
                                    </table>

                                </td>
                                <td class="auto-style3" dir="rtl">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="TxtNationalcode" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                                <td class="label">جنسیت:</td>
                                <td class="lable">
                                    <asp:RadioButtonList ID="Rbtn_DSex" runat="server" CssClass="normal_TextBox" Height="15px" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" Value="male">مرد</asp:ListItem>
                                        <asp:ListItem Value="fmale">زن</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td dir="rtl">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="label">نام :
                                </td>
                                <td class="lable">
                                    <asp:TextBox AutoCompleteType="Disabled" ID="Txt_FirstName" runat="server" CssClass="normal_TextBox"></asp:TextBox>
                                    <ajax:FilteredTextBoxExtender ID="Filteredtextboxextender1" runat="server" Enabled="true" InvalidChars="1,2,3,4,5,6,7,8,9,0" FilterMode="InvalidChars" FilterType="Custom" TargetControlID="Txt_FirstName"></ajax:FilteredTextBoxExtender>

                                </td>
                                <td class="auto-style3" dir="rtl">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="Txt_FirstName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                                <td class="label">نام خانوادگی:
                                </td>
                                <td class="lable">
                                    <asp:TextBox AutoCompleteType="Disabled" ID="Txt_LastName" runat="server" CssClass="normal_TextBox" onkeypress="charChange(this, event.keyCode)"></asp:TextBox>
                                    <ajax:FilteredTextBoxExtender ID="Filteredtextboxextender2" runat="server" Enabled="true" InvalidChars="1,2,3,4,5,6,7,8,9,0" FilterMode="InvalidChars" FilterType="Custom" TargetControlID="Txt_LastName"></ajax:FilteredTextBoxExtender>

                                </td>
                                <td dir="rtl">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="Txt_LastName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="lable">نام پدر :
                                </td>
                                <td>
                                    <asp:TextBox AutoCompleteType="Disabled" ID="Txt_FatherName" runat="server" CssClass="normal_TextBox" onkeypress="charChange(this, event.keyCode)"></asp:TextBox>
                                    <ajax:FilteredTextBoxExtender ID="Filteredtextboxextender5" runat="server" Enabled="true" InvalidChars="1,2,3,4,5,6,7,8,9,0" FilterMode="InvalidChars" FilterType="Custom" TargetControlID="Txt_FatherName"></ajax:FilteredTextBoxExtender>

                                </td>
                                <td class="auto-style4" dir="rtl">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="Txt_FatherName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                                <td class="label">شماره شناسنامه :
                                </td>
                                <td>
                                    <asp:TextBox AutoCompleteType="Disabled" ID="Txt_IDNo" runat="server" CssClass="normal_TextBox" MaxLength="10"></asp:TextBox>
                                    <ajax:FilteredTextBoxExtender ID="Filteredtextboxextender4" runat="server" Enabled="true" FilterType="Numbers" TargetControlID="Txt_IDNo"></ajax:FilteredTextBoxExtender>

                                </td>
                                <td dir="rtl">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="Txt_IDNo" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="lable">محل صدور  :
                                </td>
                                <td>
                                    <asp:TextBox AutoCompleteType="Disabled" ID="Txt_SodoorPlace" runat="server" CssClass="normal_TextBox"></asp:TextBox>
                                </td>
                                <td class="auto-style4" dir="rtl">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="Txt_SodoorPlace" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                                <td class="label">تاریخ فوت: 
                                </td>
                                <td>
                                    <%--<asp:DropDownList ID="Ddl_Fday" Style="margin-left: 0px" runat="server" CssClass="normal_DropDownList" Width="46px">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="Ddl_FMounth" Style="margin-left: 0px" runat="server" CssClass="normal_DropDownList" Width="50px">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="Ddl_FYear" Style="margin-left: 0px" CssClass="normal_DropDownList" runat="server" Width="70px">
                                    </asp:DropDownList>--%>
                                    <asp:TextBox AutoCompleteType="Disabled" ID="Txt_FotDate" dir="ltr" CssClass="Txt_Date" runat="server"></asp:TextBox>
                                    <ajax:MaskedEditExtender ID="Msk_Date" InputDirection="LeftToRight" runat="server" Filtered="" ClearMaskOnLostFocus="false" TargetControlID="Txt_FotDate" Mask="9999/99/99"></ajax:MaskedEditExtender>
                                    <%--<ajax:MaskedEditValidator  ID="Msk_Validate" runat="server"  MaximumValueMessage="EWWWWW" ErrorMessage="!!!" MaximumValue="13991230" ControlExtender="Msk_Date" ControlToValidate="Txt_FotDate"></ajax:MaskedEditValidator>--%>
                                                     
                                </td>
                                <td style="direction: rtl" dir="rtl">
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="Txt_FotDate" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                    <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="Ddl_FMounth" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="Ddl_FYear" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                    <asp:RegularExpressionValidator ID="valRegDate" runat="server" ControlToValidate="Txt_FotDate" ErrorMessage="*" ForeColor="Red" ValidationExpression="(13[0-9][0-9])/(0[1-9]|1[012])/(0[1-9]|[12][0-9]|3[01])" ValidationGroup="OrderAdd"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="lable">محل فوت :
                                </td>
                                <td>
                                    <asp:TextBox AutoCompleteType="Disabled" ID="Txt_DeadPlace" runat="server" CssClass="normal_TextBox"></asp:TextBox>
                                </td>
                                <td class="auto-style4" dir="rtl">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="Txt_DeadPlace" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                                <td class="label">کد اتباع خارجی :</td>
                                <td>
                                    <asp:TextBox ID="Txt_CodAtba" runat="server" AutoCompleteType="Disabled" CssClass="normal_TextBox" MaxLength="10"></asp:TextBox>
                                    <ajax:FilteredTextBoxExtender ID="Txt_CodAtba_FilteredTextBoxExtender" runat="server" FilterType="Numbers" TargetControlID="Txt_CodAtba">
                                    </ajax:FilteredTextBoxExtender>
                                </td>
                                <td dir="rtl">&nbsp;</td>
                            </tr>

                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table class="btn-tbl" dir="ltr">
                            <tr>
                                <td class="btn-td">

                                    <asp:Button runat="server" ID="Btn_Save" CssClass="btn-save" Text="ذخیره" OnClick="Btn_Save_Click" />

                                </td>
                                <td>
                                    <asp:Button ID="Btn_Cancel" runat="server" CausesValidation="False" CssClass="btn-Cancel" OnClick="Btn_Cancel_Click" Text="انصراف" Visible="False" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="caption" style="background-color: #CCFFCC; height: 20px">جستجو</td>
                </tr>
                <tr>
                    <td>
                        <table>

                            <tr>
                                <td class="label">شماره ملی :
                                </td>
                                <td class="lable">
                                    <asp:TextBox ID="Txt_searchNationalcode" runat="server" AutoCompleteType="Disabled" CssClass="normal_TextBox" MaxLength="10"></asp:TextBox>
                                    <ajax:FilteredTextBoxExtender ID="Txt_searchNationalcode_FilteredTextBoxExtender" runat="server" FilterType="Numbers" TargetControlID="Txt_searchNationalcode">
                                    </ajax:FilteredTextBoxExtender>

                                </td>
                                <td dir="rtl">&nbsp;&nbsp;</td>
                                <td class="label">کلاسه پرونده :
                                </td>
                                <td class="lable">
                                    <asp:TextBox ID="Txt_searchClasse" runat="server" AutoCompleteType="Disabled" CssClass="normal_TextBox" MaxLength="10"></asp:TextBox>
                                    <ajax:FilteredTextBoxExtender ID="Txt_searchClasse_FilteredTextBoxExtender" runat="server" FilterType="Numbers" TargetControlID="Txt_searchClasse">
                                    </ajax:FilteredTextBoxExtender>

                                </td>
                                <td dir="rtl"></td>
                            </tr>
                            <tr>
                                <td class="label">نام :
                                </td>
                                <td class="lable">
                                    <asp:TextBox AutoCompleteType="Disabled" ID="Txt_searchFName" runat="server" CssClass="normal_TextBox"></asp:TextBox>
                                    <ajax:FilteredTextBoxExtender ID="Filteredtextboxextender7" runat="server" Enabled="true" InvalidChars="1,2,3,4,5,6,7,8,9,0" FilterMode="InvalidChars" FilterType="Custom" TargetControlID="Txt_searchFName"></ajax:FilteredTextBoxExtender>

                                </td>
                                <td dir="rtl"></td>
                                <td class="label">نام خانوادگی :
                                </td>
                                <td class="lable">
                                    <asp:TextBox AutoCompleteType="Disabled" ID="Txt_searchLname" runat="server" CssClass="normal_TextBox"></asp:TextBox>
                                    <ajax:FilteredTextBoxExtender ID="Filteredtextboxextender8" runat="server" Enabled="true" InvalidChars="1,2,3,4,5,6,7,8,9,0" FilterMode="InvalidChars" FilterType="Custom" TargetControlID="Txt_searchLname"></ajax:FilteredTextBoxExtender>

                                </td>
                                <td dir="rtl"></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table class="btn-tbl" dir="ltr">
                            <tr>
                                <td>
                                    <asp:Button ID="Btn_Search" runat="server" CausesValidation="False" CssClass="btn-search" OnClick="Btn_Search_Click" Text="جستجو" ValidateRequestMode="Disabled" />
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
                                    <asp:Label ID="Lbl_Rec" Visible="false" runat="server" Text="تعداد کل رکوردها :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Lbl_Records" Visible="false" runat="server" ></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>

                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="Gvw_Dead" runat="server" AllowPaging="True" AutoGenerateColumns="false" DataKeyNames="xDedId_pk"
                            SkinID="Mto_Gvw" OnPageIndexChanging="Gvw_Dead_PageIndexChanging" OnRowDeleting="Gvw_Dead_RowDeleting"
                            OnSelectedIndexChanged="Gvw_Dead_SelectedIndexChanged" >
                            <Columns>
                                <asp:TemplateField ControlStyle-Width="35px" HeaderText="ردیف">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="xDedFName" HeaderText="نام  "  ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right"/>
                                <asp:BoundField DataField="xDedLName" HeaderText=" نام خانوادگی "  ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right"/>
                                <asp:BoundField DataField="xDedFatherName" HeaderText="نام پدر" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" />
                                <asp:BoundField DataField="xDedDeadDate" HeaderText="تاریخ فوت" />
                                <asp:BoundField DataField="xDedNationalCode" HeaderText="کد ملی" />
                                <asp:BoundField DataField="xDedIdNo" HeaderText="شماره شناسنامه" />
                                <asp:BoundField DataField="xHozeh" HeaderText="حوزه مالیاتی" />
                                <asp:BoundField DataField="xClass" HeaderText="کلاسه" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="Ibtn_Edit" runat="server" CausesValidation="False" CommandName="Select" SkinID="Ibtn_Edit" />
                                        <asp:ImageButton ID="Ibtn_Delete" runat="server" CausesValidation="False" CommandName="Delete" OnClientClick="return confirm('آیا برای عملیات حذف مطمئن هستید؟')" SkinID="Ibtn_Del" />
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
