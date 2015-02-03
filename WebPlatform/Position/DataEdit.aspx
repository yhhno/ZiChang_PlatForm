<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeFile="DataEdit.aspx.cs"
    Inherits="Position_DataEdit" Theme="Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>

    <script src="../Myjs/Valid.js" type="text/javascript" language="javascript"></script>

</head>
<body style="background-color: #C7D6E9;" onkeydown="if(event.keyCode==13){event.keyCode = 9;event.returnValue = false;document.getElementById('btn_Save').click();}">
    <form id="form1" runat="server">
    <input id="h_orgID" runat="server" type="hidden" />
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="upDepartAdd" runat="server">
            <ContentTemplate>
                <table class="style1">
                    <tr>
                        <td colspan="2" style="height: 20px">
                        </td>
                    </tr>
                    <%--<tr>
                <td style="width: 20%" align="right">
                    职位编号</td>
                <td style="width: 80%" align="left">
                    <asp:TextBox ID="txt_PositionCode" runat="server" MaxLength="10" Width="180px"></asp:TextBox><asp:Label ID="Label2" runat="server"  ForeColor="Red" Text="*"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txt_PositionCode" ErrorMessage="职位编号不能为空！" 
                        Display="None"></asp:RequiredFieldValidator>
                </td>
                
            </tr>--%>
                    <tr>
                        <td style="width: 20%" align="right">
                            职位名称
                        </td>
                        <td style="width: 80%" align="left">
                            <asp:TextBox ID="txt_PositionName" onkeypress="return ValidateSpecialCharacter();"  onpaste="return ValidateSpecialCharacter();"
                                runat="server" MaxLength="32" Width="180px"></asp:TextBox><asp:Label ID="Label1"
                                    runat="server" ForeColor="Red" Text="*"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_PositionName"
                                ErrorMessage="职位名称不能为空！" Display="None"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20%" align="right">
                            描 述
                        </td>
                        <td style="width: 80%" align="left">
                            <asp:TextBox ID="txt_Remark" runat="server" TextMode="MultiLine" MaxLength="64" Rows="5"
                                Height="60px" Width="300px" onkeypress="return ValidateSpecialCharacter();"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center" style="height: 40px" valign="bottom">
                            <asp:ImageButton ID="btn_Save" runat="server" ImageUrl="~/Images/baocun.gif" OnClick="btn_Save_Click" />
                            &nbsp;&nbsp;<asp:ImageButton ID="btn_chongzhi" runat="server" ImageUrl="~/Images/chongzhi.gif"
                                OnClick="btn_chongzhi_Click" CausesValidation="false" />
                            &nbsp;
                            <asp:ImageButton ID="btnCancel" runat="server" CausesValidation="False" ImageUrl="~/Images/close.gif"
                                OnClick="btnCancel_Click" />
                        </td>
                    </tr>
                </table>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                    ShowSummary="False" />
                <asp:RegularExpressionValidator ID="revRemark" runat="server" ControlToValidate="txt_Remark"
                    Display="None" ErrorMessage="描述输入长度不能超过200" ValidationExpression="[\s\S]{0,200}"></asp:RegularExpressionValidator>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
