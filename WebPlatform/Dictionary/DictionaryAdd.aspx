<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DictionaryAdd.aspx.cs" Inherits="Dictionary_DictionaryAdd" Theme="Default" %>

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
</head>
<body style="background-color: #C7D6E9;" onkeydown="if(event.keyCode==13){event.keyCode = 9;event.returnValue = false;document.getElementById('btn_Save').click();}">
      <form id="form1" runat="server">
    <input id="h_orgID" runat="server" type="hidden" />
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="upDepartAdd" runat="server">
            <ContentTemplate>
                <table class="style1" cellpadding="2" cellspacing="2">
                    <tr>
                        <td style="width: 25%" align="right">
                            名&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 称：
                        </td>
                        <td style="width: 75%" align="left">
                            <asp:TextBox ID="txt_name" runat="server" MaxLength="30" Width="180px"></asp:TextBox>
                            &nbsp;<span class="required">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_name"
                                ErrorMessage="名称不能为空!" Display="None"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 25%">
                            类&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 型：
                        </td>
                        <td align="left" style="width: 75%">
                            <asp:DropDownList ID="ddl_type" runat="server" Width="187px">
                            </asp:DropDownList>
                            &nbsp;<span class="required">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddl_type"
                                ErrorMessage="请选择类型!" InitialValue="0" Display="None"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 25%" align="right">
                            是否禁用：
                        </td>
                        <td style="width: 75%" align="left">
                            <asp:CheckBox ID="cb_status" runat="server" Text="是否禁用" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center" style="height: 40px" valign="bottom">
                            <asp:ImageButton ID="btn_Save" runat="server" ImageUrl="~/Images/baocun.gif" OnClick="btn_Save_Click" />
                            &nbsp;&nbsp;
                            <asp:ImageButton ID="btn_chongzhi" runat="server" ImageUrl="~/Images/chongzhi.gif"
                                OnClick="btn_chongzhi_Click" CausesValidation="false" />&nbsp;&nbsp;
                            <asp:ImageButton ID="btnCancel" runat="server" CausesValidation="False" 
                                ImageUrl="~/Images/close.gif" onclick="btnCancel_Click1"  />
                        </td>
                    </tr>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                ShowMessageBox="True" ShowSummary="False" />
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
  
   
    </form> 
</body>
</html>
