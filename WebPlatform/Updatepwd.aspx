<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Updatepwd.aspx.cs" Inherits="Updatepwd" Theme="Default"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
   
    
</head>
<body style="background-color:#C7D6E9">
    <form id="form1" runat="server">
    <div>
    
        <table class="style1" align="center">
            <tr>
                <td class="style2">
                    输入原密码：</td>
                <td>
                    <asp:TextBox ID="txt_oldpwd" runat="server" TextMode="Password" MaxLength="30"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    输入新密码：</td>
                <td>
                    <asp:TextBox ID="txt_newpwd" runat="server" TextMode="Password" MaxLength="30"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    确认新密码：</td>
                <td>
                    <asp:TextBox ID="txt_rnewped" runat="server" TextMode="Password" MaxLength="30"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:ImageButton ID="ib_save" runat="server" ImageUrl="~/Images/baocun.gif" 
                        onclick="ib_save_Click" />
                
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txt_oldpwd" Display="None" ErrorMessage="原密码不能为空!"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txt_newpwd" Display="None" ErrorMessage="新密码不能为空!"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToCompare="txt_rnewped" ControlToValidate="txt_newpwd" Display="None" 
                        ErrorMessage="确认新密码与新密码输入不一致!"></asp:CompareValidator>
                </td>
            </tr>
        </table>
    
    </div>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
        ShowMessageBox="True" ShowSummary="False" />
    </form>
</body>
</html>
