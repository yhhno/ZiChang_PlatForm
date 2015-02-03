<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddMenu.aspx.cs" Inherits="Menu_AddMenu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加新菜单</title>
    <link href="../CSS/Main.css" rel="stylesheet" type="text/css" />

    <script src="../Myjs/js_webFormForModel.js" type="text/javascript"></script>

    <script src="../Myjs/winModel.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        function chkLeafClick() {
            var menuAction = document.getElementById("trMenuAction");
            var chkLeaf = document.getElementById("chkIsLeaf");
            menuAction.style.display = menuAction.style.display == "none" ? "block" : "none";
            var rfvMenuAction = document.getElementById("rfvMenuAction");
            rfvMenuAction.enabled = chkLeaf.checked ? true : false;
        }
        function bodyLoad() {
            var menuAction = document.getElementById("trMenuAction");
            var chkIsLeaf = document.getElementById("chkIsLeaf");
            menuAction.style.display = chkIsLeaf.checked ? "block" : "none";
        }
    </script>

    <style type="text/css">
        .style1
        {
            width: 150px;
            text-align: right;
        }
    </style>

</head>
<body onload="bodyLoad();" style="background-color: #C7D6E9" onkeydown="if(event.keyCode==13){event.keyCode = 9;event.returnValue = false;document.getElementById('btnSave').click();}">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="smMenu" runat="server">
    </asp:ScriptManager>
    <div>
        <table align="center" width="100%">
            <tbody>
                <tr>
                    <td class="style1">
                        菜单名称：
                    </td>
                    <td>
                        <asp:TextBox ID="txtMenuName" runat="server" MaxLength="64" Width="200px"></asp:TextBox>
                        <span style="color: Red">*<asp:RequiredFieldValidator ID="rfvMenuName" runat="server"
                            ControlToValidate="txtMenuName" ErrorMessage="菜单名称为必填项!" Display="None"></asp:RequiredFieldValidator>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        是否为叶节点：
                    </td>
                    <td>
                        <asp:CheckBox ID="chkIsLeaf" runat="server" onclick="chkLeafClick();" />
                    </td>
                </tr>
                <tr id="trMenuAction">
                    <td class="style1">
                        菜单链接：
                    </td>
                    <td>
                        <asp:TextBox ID="txtMenuAction" runat="server" MaxLength="256" Width="200px"></asp:TextBox>
                        <span style="color: Red">*</span>
                        <asp:RequiredFieldValidator ID="rfvMenuAction" runat="server" ControlToValidate="txtMenuAction"
                            Display="None" ErrorMessage="菜单链接不能为空！" Enabled="False"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr id="trFunctionID" style="display: none;">
                    <td class="style1">
                        业务功能编号：
                    </td>
                    <td>
                        <asp:TextBox ID="txtFunctionID" runat="server" MaxLength="64"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        父节点名称：
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlParents" runat="server" Width="206px">
                        </asp:DropDownList>
                        <span style="color: Red">*</span>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        显示顺序：
                    </td>
                    <td>
                        <asp:TextBox ID="txtDisplayOrder" runat="server" MaxLength="2" Width="30px"></asp:TextBox>
                        <span style="color: Red">*</span>
                        <asp:RequiredFieldValidator ID="rfvDisplayOrder" runat="server" ControlToValidate="txtDisplayOrder"
                            Display="None" ErrorMessage="显示顺序不能为空！"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revDisplayOrder" runat="server" ControlToValidate="txtDisplayOrder"
                            Display="None" ErrorMessage="显示顺序只能输入1~99内的数字。" 
                            ValidationExpression="^[1-9][0-9]?$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        是否弹出：
                    </td>
                    <td>
                        <asp:CheckBox ID="chkIsPop" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                    </td>
                    <td>
                        <asp:TextBox ID="txtICValue" runat="server" MaxLength="200" Width="200px" 
                            Visible="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/Images/baocun.gif" OnClick="btnSave_Click" />
                        &nbsp;&nbsp;
                        <asp:ImageButton ID="btnReset" runat="server" ImageUrl="~/Images/chongzhi.gif" 
                            OnClick="btnReset_Click" CausesValidation="False" />
                        &nbsp;&nbsp;
                        <asp:ImageButton ID="btnCancel" runat="server" ImageUrl="~/Images/close.gif" OnClick="btnCancel_Click"
                            CausesValidation="False" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <asp:ValidationSummary ID="vsMenu" runat="server" ShowMessageBox="True" ShowSummary="False" />
    </form>
</body>
</html>
