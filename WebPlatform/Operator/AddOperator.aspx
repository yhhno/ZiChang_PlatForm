<%@ Page Language="C#" validateRequest=false AutoEventWireup="true" CodeFile="AddOperator.aspx.cs" Inherits="Operator_AddOperator" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>

    <script src="../Myjs/Calendar.js" type="text/javascript"></script>

    <script src="../Myjs/Calendar/WdatePicker.js" type="text/javascript"></script>

    <script type="text/javascript">
    function SetPostionForm()
    {
        var form = new js_webFormForModel_Forms('AddPostion.aspx','OperForm','添加','',{width:520,height:300}); 
        form.initforms(); 
        form.remethod =  function(){
           Operator_OperatorList.b();
        }
    }

    </script>
</head>
<body style="background-color: #C7D6E9" onkeydown="if(event.keyCode==13){event.keyCode = 9;event.returnValue = false;document.getElementById('ib_save').click();}">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
     <ContentTemplate>
    <table width="600px" align="center">
        <tr>
            <td align="right">
                &nbsp;姓&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;名：
            </td>
            <td>
                <asp:TextBox ID="txt_username" runat="server" MaxLength="20"></asp:TextBox>
                <span class="required">*</span>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator5"
                    runat="server" ControlToValidate="txt_username" ErrorMessage="您输入的姓名不能包含特殊字符" 
                    Display="None" ValidationExpression="^[^<>&/'\|\\]+$"></asp:RegularExpressionValidator>
            </td>
            <td  align="right">
                手&nbsp;&nbsp;机&nbsp;&nbsp;号：</td>
            <td>
                <asp:TextBox ID="txt_mobile" runat="server" MaxLength="11"></asp:TextBox>
                <span class="required">*</span><asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                    runat="server" ControlToValidate="txt_mobile" ErrorMessage="您输入的手机号码格式不正确" 
                    Display="None" ValidationExpression="^1[0-9]{1}[0-9]{1}[0-9]{8}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td  align="right">
                &nbsp;所属部门：
            </td>
            <td>
                <asp:DropDownList ID="ddl_parentOrgID" runat="server" 
                Width="157px" AutoPostBack="True" onselectedindexchanged="ddl_parentOrgID_SelectedIndexChanged">
                </asp:DropDownList>
                <span class="required">*</span>
            <td align="right" id="tdTypeCode" runat="server" visible="false">
                <asp:Label ID="lblTypeCode" runat="server" Text="请选择磅房："></asp:Label>
            </td>
            <td align="left">
                <asp:DropDownList ID="ddl_TypeCode" runat="server" Width="157px">
                </asp:DropDownList>
                <asp:Label ID="lblStar" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
            </td>
            </td>
        </tr>
        <tr>
            <td align="right">
                家庭地址：
            </td>
            <td>
                <asp:TextBox ID="txt_address" runat="server" MaxLength="200"></asp:TextBox>
            </td>
            <td align="right">
                邮政编码：
            </td>
            <td>
                <asp:TextBox ID="zipcode" runat="server" MaxLength="6"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                身份证号：
            </td>
            <td>
                <asp:TextBox ID="txt_pid" runat="server" MaxLength="18"></asp:TextBox>
            </td>
            <td align="right">
                电子邮件：
            </td>
            <td>
                <asp:TextBox ID="txt_email" runat="server" MaxLength="50"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                性&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;别：
            </td>
            <td>
                <asp:RadioButtonList ID="rblist_sex" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="男">男</asp:ListItem>
                    <asp:ListItem Value="女">女</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td align="right">
                办公电话：
            </td>
            <td>
                <asp:TextBox ID="txt_tel" runat="server" MaxLength="20"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="4" valign="bottom" align="center" style="height:50px">
                <asp:ImageButton ID="ib_save" runat="server" ImageUrl="~/Images/baocun.gif" OnClick="ib_save_Click" />&nbsp;
                <asp:ImageButton ID="ib_cav" runat="server" ImageUrl="~/Images/chongzhi.gif" OnClick="ib_cav_Click"
                    CausesValidation="False" />
            &nbsp;
                    <asp:ImageButton ID="btnCancel" runat="server" ImageUrl="~/Images/close.gif" OnClick="btnCancel_Click"
                        ValidationGroup="gr" />
            </td>
        </tr>
    </table>
     
    <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
            ControlToValidate="txt_tel" Display="None" ErrorMessage="电话号码格式不正确!" 
            ValidationExpression="(\(\d{3}\)|\d{3}-)?\d{8}"></asp:RegularExpressionValidator>--%>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txt_pid"
        Display="None" ErrorMessage="身份证格式不正确!" ValidationExpression="\d{17}[\d|X]|\d{15}"></asp:RegularExpressionValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txt_email"
        Display="None" ErrorMessage="电子邮件格式不正确!" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="zipcode"
        Display="None" ErrorMessage="邮政编码格式不正确!" ValidationExpression="\d{6}"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_username"
                    ErrorMessage="姓名不能为空!" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_mobile"
                    ErrorMessage="手机号不能为空!" Display="None"></asp:RequiredFieldValidator>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
        ShowSummary="False" />
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
