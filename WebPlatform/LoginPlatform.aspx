<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginPlatform.aspx.cs" Inherits="LoginPlatform" %>

<html>
<head id="Head1" runat="server">
    <title id="title" runat="server">行业主管平台登陆页</title>
    <link href="CSS/Main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" autocomplete="off">
    <%     
        Response.Buffer = true;
        Response.Expires = 0;
        Response.CacheControl = "no-cache";
    %>
    <table id="__01" width="100%" height="613px" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td rowspan="3" style="background: url(images/1_01.gif) repeat; height: 613px; width: 700px">
            </td>
            <td rowspan="3">
                <img src="images/1_02.gif" width="1" height="613" alt="" />
            </td>
            <td colspan="2">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <img src="images/1_03.gif" width="482" height="242" alt="" />
            </td>
            <td rowspan="3" style="background: url(images/1_01.gif) repeat; height: 613px; width: 700px">
            </td>
        </tr>
        <tr>
            <td colspan="2" style="background: url(images/1_05.gif); height: 152px; width: 482px">
                <table width="100%">
                    <tr>
                        <td width="23%">
                        </td>
                        <td onkeydown="aaaa()">
                            <font color="2c397d">请选择部门：</font>
                        </td>
                        <td colspan="2">
                            <span class="required">
                                <asp:DropDownList ID="ddldept" runat="server" Width="140px" AutoPostBack="true" OnSelectedIndexChanged="ddldept_SelectedIndexChanged">
                                </asp:DropDownList>
                                * </span>
                        </td>
                    </tr>
                    <tr>
                        <td width="23%">
                        </td>
                        <td onkeydown="aaaa()">
                            <font color="2c397d">请选择用户：</font>
                        </td>
                        <td colspan="2">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddluser" runat="server" Width="140px">
                                    </asp:DropDownList>
                                    <span class="required">*</span>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddldept" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td width="23%">
                        </td>
                        <td>
                            <font color="2c397d">请输入密码：</font>
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="138px" MaxLength="100"
                                ToolTip="请输入密码">
                            </asp:TextBox>
                            <span class="required">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td width="23%">
                        </td>
                        <td>
                            <font color="2c397d">输入验证码：</font>
                        </td>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtCheckCode" runat="server" Width="88px" Font-Names="黑体" Font-Size="14px"
                                            ForeColor="Black" ToolTip="请输入验证码" CausesValidation="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;<img alt="验证码" style="height: 19px" src="ValidateCode/ValidateCode.aspx" />
                                        <span class="required">*</span>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="center">
                            <asp:ImageButton ID="ibnLogin" ImageUrl="~/Images/login.gif" runat="server" OnClick="ibnLogin_Click"
                                CausesValidation="False" /><asp:ImageButton ID="ibnCancel" ImageUrl="~/Images/cancel.gif"
                                    runat="server" OnClick="ibnCancel_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <img src="images/1_06.gif" width="481" height="219px" alt="" />
            </td>
            <td>
                <img src="images/1_07.gif" width="1" height="219px" alt="" />
            </td>
        </tr>
    </table>
    <input id="Hidden1" type="hidden" runat="server" />
    </form>
</body>
</html>
