<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeFile="OrganizationAdd.aspx.cs"
    Inherits="Organization_OrganizationAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Myjs/js_webFormForModel.js" type="text/javascript"></script>

    <script src="../Myjs/winModel.js" type="text/javascript"></script>
    <script src="../Myjs/Valid.js" type="text/javascript" language="javascript"></script>
</head>
<body style="background-color: #C7D6E9;" onkeydown="if(event.keyCode==13){event.keyCode = 9;event.returnValue = false;document.getElementById('btnSave').click();}">
    <form id="form1" runat="server">
    <div>
        <table style="width: 100%;">
            <tr>
                <td colspan="2">
                    &nbsp;
                </td>
            </tr>
            <%--<tr>
                <td style="width: 25%" align="right">
                    部门代码：
                </td>
                <td style="width: 75%" align="left">
                    <asp:TextBox ID="txt_OrgCode" runat="server" MaxLength="10" Width="200px"></asp:TextBox>
                    &nbsp;<span style="color: Red">*</span>
                </td>
            </tr>--%>
            <tr>
                <td style="width: 25%" align="right">
                    部门名称：
                </td>
                <td style="width: 75%" align="left">
                    <asp:TextBox ID="txt_OrgName" runat="server" MaxLength="64" Width="200px" onkeypress="return ValidateSpecialCharacter();"></asp:TextBox>
                    &nbsp;<span style="color: Red">*</span>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ErrorMessage="部门名称不能为空" ControlToValidate="txt_OrgName" Display="None"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                    runat="server" ControlToValidate="txt_OrgName" ErrorMessage="您输入的部门代码不能包含特殊字符" 
                    Display="None" ValidationExpression="^[^<>/'\|\\]+$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 25%" align="right">
                    父级部门：
                </td>
                <td style="width: 75%" align="left">
                    <asp:DropDownList ID="ddl_parentOrgID" runat="server" Width="208px">
                    </asp:DropDownList>
                </td>
            </tr>
             <tr>
                <td style="width: 25%" align="right">
                    部门类别：
                </td>
                <td style="width: 75%" align="left">
                    <asp:DropDownList ID="ddlOrgType" runat="server" Width="208px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 25%" align="right">
                    联系人：
                </td>
                <td style="width: 75%" align="left">
                    <asp:TextBox ID="txt_LinkMan" runat="server" MaxLength="20" Width="200px" onkeypress="return ValidateSpecialCharacter();"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 25%" align="right">
                    联系人电话：
                </td>
                <td style="width: 75%" align="left">
                    <asp:TextBox ID="txt_LinkManTel" runat="server" Width="200px" MaxLength="30" onkeypress="return ValidateSpecialCharacter();"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 25%" align="right">
                    电子邮件：
                </td>
                <td style="width: 75%" align="left">
                    <asp:TextBox ID="txt_Email" runat="server" Width="200px" MaxLength="100" onkeypress="return ValidateSpecialCharacter();"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 25%" align="right">
                    备 注：
                </td>
                <td style="width: 75%" align="left">
                    <asp:TextBox ID="txt_memo" runat="server" TextMode="MultiLine" Height="55px" Width="350px" onkeypress="return ValidateSpecialCharacter();"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2" height="40px" valign="bottom">
                    <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/Images/baocun.gif" OnClick="btnSave_Click" />
                    &nbsp;&nbsp;
                    <asp:ImageButton ID="btnReset" runat="server" ImageUrl="~/Images/chongzhi.gif" OnClick="btnReset_Click"
                        ValidationGroup="gr" />
                    &nbsp;&nbsp;
                    <asp:ImageButton ID="btnCancel" runat="server" ImageUrl="~/Images/close.gif" OnClick="btnCancel_Click"
                        ValidationGroup="gr" />
                </td>
            </tr>
        </table>
    </div>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_email"
        Display="None" ErrorMessage="电子邮件格式输入不正确!" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
        ShowSummary="False" />
    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
        ControlToValidate="txt_memo" Display="None" ErrorMessage="备注输入长度不能超过200" 
        ValidationExpression="[\s\S]{0,200}"></asp:RegularExpressionValidator>
    </form>
</body>
</html>
