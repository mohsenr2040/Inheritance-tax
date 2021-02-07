<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Ers_Pro.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>مالیات بر ارث</title>
    <link rel="shortcut icon" type="image/x-icon" href="App_Themes/Icon/Web_icon.ico" />
    <style type="text/css">
        body
        {
            margin-left: 0px;
            margin-top: 0px;
            margin-right: 0px;
            margin-bottom: 0px;
            background-color: #A1E7BD;
        }
        .tbl1
        {
            height: 340px;
            width: 100%;
        }
        .td2
        {
            background-image: url('App_Themes/Skin/imagesLogin/02.png');
            background-repeat: no-repeat;
            width: 145px;
        }
        .td3
        {
            background-image: url('App_Themes/Skin/imagesLogin/03.png');
            background-repeat: no-repeat;
            width: 145px;
        }
        .td4
        {
            background-image: url('App_Themes/Skin/imagesLogin/04.png');
            background-repeat: repeat-x;
            text-align: center;
        }
        .box
        {
            height: 215px;
            width: 325px;
            background-image: url('App_Themes/Skin/imagesLogin/06.png');
            background-repeat: no-repeat;
        }
        .footer
        {
            font-family: tahoma, Arial;
            text-align: center;
            font-size: 12px;
        }
        input
        {
            font-family: tahoma, Arial, Helvetica, sans-serif;
            font-size: 10pt;
            margin-top: 0px;
        }
        .logintbl
        {
            margin-top: 65px;
        }
        .btn-login
        {
            background-image: url('../../App_Themes/Skin/imagesLogin/btn1.png');
            background-position: right;
            background-repeat: no-repeat;
            width: 49px;
            height: 86px;
        }
        .btn-login:hover
        {
            background-image: url('../../App_Themes/Skin/imagesLogin/btn2.png');
            background-repeat: no-repeat;
            background-position: right;
            width: 49px;
            height: 86px;
        }
       
        .auto-style1 {
            font-family: tahoma, Arial;
            text-align: center;
            font-size: 12px;
            height: 14px;
        }
       
    </style>
</head>
<body>
    <form id="form1" runat="server" style="padding-top:100px">
    <table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td>
                <table border="0"   class="tbl1" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="td2">
                        </td>
                        <td class="td4">
                            <table border="0" align="center"   class="box">
                                <tr>
                                    <td  style="height: 4px">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <table style="width: 100%; height: 100%">
                                            <tr>
                                                <td style="height: 35px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align:center">
                                                    <table cellspacing="0" cellpadding="0">
                                                        <tr>
                                                        <td style="width:20px"></td>
                                                            <td>
                                                                <asp:ImageButton ID="Ibtn_Login" runat="server" 
                                                                    ImageUrl="~/App_Themes/Skin/imagesLogin/btn1.png" onclick="Ibtn_Login_Click" />
                                                            </td>
                                                            <td style="vertical-align:central">
                                                                <table cellspacing="5" cellpadding="0">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                                                ControlToValidate="Txt_UserName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                            <asp:TextBox  ID="Txt_UserName" runat="server"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                   
                                                                    <tr>
                                                                        <td style="vertical-align:bottom">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                                                ControlToValidate="Txt_Pass" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                            <asp:TextBox  ID="Txt_Pass" runat="server" TextMode="Password"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td style="width: 50px">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align:center;height:7px">
                                                    <asp:Label ID="Lbl_Msg" runat="server" Font-Names="Tahoma" Font-Size="9pt" 
                                                        ForeColor="Red"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:center;height:0px">
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="td3">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="footer">
                <asp:Label ID="Lbl_Version" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>