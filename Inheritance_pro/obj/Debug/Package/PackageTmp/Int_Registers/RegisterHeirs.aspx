<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true" CodeBehind="RegisterHeirs.aspx.cs" Inherits="Ers_Pro.RegisterHeirs" %>

<%@ Register Assembly="MaskTextBox" Namespace="MaskTextBox" TagPrefix="mtx" %>
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
                                <td>&nbsp;</td>
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
                                <td>&nbsp;</td>
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
                                <td class="label">شماره ملی:
                                </td>
                                <td class="lable">
                                    <table class="table" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:TextBox AutoCompleteType="Disabled" ID="Txt_PNationalCode" runat="server" CssClass="normal_TextBox1" MaxLength="10"></asp:TextBox>
                                                <ajax:FilteredTextBoxExtender ID="Filteredtextboxextender2" runat="server" FilterType="Numbers" TargetControlID="Txt_PNationalCode"></ajax:FilteredTextBoxExtender>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="Imgbtn_Sssearch" runat="server" CausesValidation="False" Enabled="False" ImageUrl="~/App_Themes/Skin/Pub_Images/SearchIt.gif" OnClick="Imgbtn_Sssearch_Click" Style="height: 16px" />

                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td>&nbsp;</td>
                                <td class="label">نسبت:</td>
                                <td class="lable">
                                    <asp:DropDownList ID="Ddl_Ratio" CssClass="normal_DropDownList" runat="server" DataSourceID="Lds_Ratio" DataTextField="xRtoType" DataValueField="xRtoId_pk">
                                       
                                    </asp:DropDownList>
                                </td>
                                <td class="lable" dir="rtl">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="Ddl_Ratio" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="lable">نام :
                            <br />
                                </td>
                                <td>
                                    <asp:TextBox AutoCompleteType="Disabled" ID="Txt_PFirsName" runat="server" CssClass="normal_TextBox" onkeypress="charChange(this, event.keyCode)"></asp:TextBox>
                                    <ajax:FilteredTextBoxExtender ID="Filteredtextboxextender6" runat="server" Enabled="true" InvalidChars="1,2,3,4,5,6,7,8,9,0" FilterMode="InvalidChars" FilterType="Custom" TargetControlID="Txt_PFirsName"></ajax:FilteredTextBoxExtender>

                                </td>
                                <td dir="rtl">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Txt_PFirsName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                                <td class="label">نام خانوادگی: </td>
                                <td style="direction: rtl">
                                    <asp:TextBox AutoCompleteType="Disabled" ID="Txt_PLastName" runat="server" CssClass="normal_TextBox" onkeypress="charChange(this, event.keyCode)"></asp:TextBox>
                                    <ajax:FilteredTextBoxExtender ID="Filteredtextboxextender5" runat="server" Enabled="true" InvalidChars="1,2,3,4,5,6,7,8,9,0" FilterMode="InvalidChars" FilterType="Custom" TargetControlID="Txt_PLastName"></ajax:FilteredTextBoxExtender>

                                </td>
                                <td style="direction: rtl" class="auto-style4" dir="rtl">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Txt_PLastName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>

                                </td>
                            </tr>
                            <tr>
                                <td>نام پدر :
                                </td>
                                <td>
                                    <asp:TextBox AutoCompleteType="Disabled" ID="TxtPFatherName" runat="server" CssClass="normal_TextBox" onkeypress="charChange(this, event.keyCode)"></asp:TextBox>
                                    <ajax:FilteredTextBoxExtender ID="Filteredtextboxextender7" runat="server" Enabled="true" InvalidChars="1,2,3,4,5,6,7,8,9,0" FilterMode="InvalidChars" FilterType="Custom" TargetControlID="TxtPFatherName"></ajax:FilteredTextBoxExtender>

                                </td>
                                <td dir="rtl">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtPFatherName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                                <td class="auto-style2">تاریخ تولد:
                                </td>
                                <td>
                                  <%--  <asp:DropDownList ID="Ddl_day" Style="margin-left: 0px" runat="server" CssClass="normal_DropDownList" Width="46px">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="Ddl_Mounth" Style="margin-left: 0px" runat="server" CssClass="normal_DropDownList" Width="50px">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="Ddl_Year" Style="margin-left: 0px" CssClass="normal_DropDownList" runat="server" Width="70px">
                                    </asp:DropDownList>--%>
                                    <asp:TextBox ID="Txt_BirthDate" runat="server" AutoCompleteType="Disabled" CssClass="Txt_Date" dir="ltr"></asp:TextBox>
                                    <ajax:MaskedEditExtender ID="Msk_Date" runat="server" ClearMaskOnLostFocus="false" Filtered="" InputDirection="LeftToRight" Mask="9999/99/99" TargetControlID="Txt_BirthDate">
                                    </ajax:MaskedEditExtender>
                                </td>
                                <td dir="rtl">
                                    <asp:RegularExpressionValidator ID="valRegDate" runat="server" ControlToValidate="Txt_BirthDate" ErrorMessage="*" ForeColor="Red" ValidationExpression="(13[0-9][0-9])/(0[1-9]|1[012])/(0[1-9]|[12][0-9]|3[01])" ValidationGroup="OrderAdd"></asp:RegularExpressionValidator>

                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="Ddl_day" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="Ddl_Year" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="Ddl_Mounth" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                               --%> </td>
                            </tr>
                            <tr>
                                <td class="lable">محل تولد :
                                </td>
                                <td>
                                    <asp:TextBox AutoCompleteType="Disabled" ID="Txt_PBirthPlace" runat="server" CssClass="normal_TextBox" onkeypress="charChange(this, event.keyCode)"></asp:TextBox>
                                </td>
                                <td dir="rtl">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Txt_PBirthPlace" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                                <td class="label">محل صدور : </td>
                                <td>
                                    <asp:TextBox ID="Txt_PSoodorPlace" runat="server" AutoCompleteType="Disabled" CssClass="normal_TextBox"></asp:TextBox>

                                </td>
                                <td class="auto-style4" dir="rtl">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="Txt_PSoodorPlace" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="lable">کد پستی  :
                                </td>
                                <td>
                                    <asp:TextBox AutoCompleteType="Disabled" ID="Txt_PCodPosti" runat="server" CssClass="normal_TextBox" MaxLength="10"></asp:TextBox>
                                    <ajax:FilteredTextBoxExtender ID="Filteredtextboxextender4" runat="server" FilterType="Numbers" TargetControlID="Txt_PCodPosti"></ajax:FilteredTextBoxExtender>

                                </td>
                                <td dir="rtl">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="Txt_PCodPosti" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                                <td class="label">شماره شناسنامه :</td>
                                <td>
                                    <asp:TextBox ID="Txt_PIdNo" runat="server" AutoCompleteType="Disabled" CssClass="normal_TextBox" MaxLength="10"></asp:TextBox>
                                    <ajax:FilteredTextBoxExtender ID="Txt_PIdNo_FilteredTextBoxExtender" runat="server" FilterType="Numbers" TargetControlID="Txt_PIdNo">
                                    </ajax:FilteredTextBoxExtender>
                                </td>
                                <td class="lable" dir="rtl">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="Txt_PIdNo" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="lable">جنسیت:</td>
                                <td>
                                    <asp:RadioButtonList ID="Rbtn_Sex" CssClass="normal_TextBox" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="male" Selected="True">مرد</asp:ListItem>
                                        <asp:ListItem Value="fmale">زن</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>

                                <td>&nbsp;</td>
                                <td>تلفن:&nbsp;&nbsp;&nbsp; </td>
                                <td>
                                    <asp:TextBox AutoCompleteType="Disabled" ID="Txt_PTel" runat="server" CssClass="normal_TextBox" MaxLength="11"></asp:TextBox>
                                    <ajax:FilteredTextBoxExtender ID="Filteredtextboxextender3" runat="server" FilterType="Numbers" TargetControlID="Txt_PTel"></ajax:FilteredTextBoxExtender>

                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="Txt_PTel" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td class="label">آدرس:
                                </td>
                                <td>
                                    <asp:TextBox AutoCompleteType="Disabled" ID="Txt_PAddrress" runat="server" CssClass="address_TextBox"></asp:TextBox>
                                </td>
                                <td dir="rtl">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="Txt_PAddrress" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
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
                                    <table class="btn-tbl" dir="ltr">
                                        <tr>
                                            <td class="btn-td">

                                                <asp:Button runat="server" ID="Btn_Save" CssClass="btn-save" Text="ذخیره" OnClick="Btn_Save_Click" Enabled="False" />

                                            </td>
                                            <td>

                                                <asp:Button ID="Btn_New" CssClass="btn-Public" runat="server" Text="جدید" OnClick="Btn_New_Click" Visible="False" Width="83px" />

                                                <asp:Button ID="Btn_Cancel" CssClass="btn-Cancel" runat="server" Text="انصراف" OnClick="Btn_Cancel_Click" Visible="False" CausesValidation="False" />

                                            </td>
                                        </tr>
                                    </table>
                                </td>

                            </tr>
                        </table>

                    </td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="Gvw_Heris" runat="server" SkinID="Mto_Gvw" AutoGenerateColumns="false"
                            AllowPaging="True" DataKeyNames="xPrsId_pk" OnSelectedIndexChanged="Gvw_Heris_SelectedIndexChanged" OnRowDeleting="Gvw_Heris_RowDeleting" OnPageIndexChanging="Gvw_Heris_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="ردیف" ControlStyle-Width="35px">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="نام " DataField="xPrsFName" />
                                <asp:BoundField HeaderText=" نام خانوادگی" DataField="xPrsLName" />
                                <asp:BoundField HeaderText="نام پدر" DataField="xPrsFatherName" />
                                <asp:BoundField HeaderText="تاریخ تولد" DataField="xPrsBirthDate" />
                                <asp:BoundField HeaderText="محل تولد" DataField="xPrsBirthPlace" />
                                <asp:BoundField HeaderText="شماره شناسنامه" DataField="xPrsIdNo" />
                                <asp:BoundField HeaderText="محل صدور" DataField="xPrsIssuancePalce" />
                                <asp:BoundField HeaderText="کد ملی" DataField="xPrsNationalCode" />
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
                        <br />
                        <asp:LinqDataSource ID="Lds_Ratio" runat="server" ContextTypeName="Ers_Pro.App_Code.Intd_Lts.Lts_InheritedDataContext" EntityTypeName="" Select="new (xRtoId_pk, xRtoType)" TableName="Tb_RatioTypes">
                        </asp:LinqDataSource>
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
