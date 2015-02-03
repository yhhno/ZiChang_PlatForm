<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddLeaveword.aspx.cs" Inherits="Leaveword_AddLeaveword" Theme="Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 96px;
            text-align:right;
        }
    </style>
</head>
<body style="background-color:#C7D6E9">
    <form id="form1" runat="server">
    <div style=" text-align:center;">
    
        <table cellpadding="2" cellspacing="2" width="500">
            <tr>
                <td class="style1">
                    留言标题：</td>
                <td align="left">
                    <asp:TextBox ID="txt_LEAVEtitle" runat="server" Width="173px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    接&nbsp; 收&nbsp; 人：</td>
                <td align="left">
                    <asp:TextBox ID="txt_ReceiveID" runat="server" Width="367px" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td  class="style1" valign="top">
                    留言内容：</td>
                <td align="left">
                    <asp:TextBox ID="txt_LEAVEcontent" runat="server" Width="371px" Height="142px" 
                        TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td  class="style1" valign="top">
                    &nbsp;</td>
                <td align="left">
                    <asp:ImageButton ID="ib_save" runat="server" ImageUrl="~/Images/baocun.gif" 
                        onclick="ib_save_Click"/>&nbsp;<asp:ImageButton ID="ib_cav" runat="server" 
                        ImageUrl="~/Images/chongzhi.gif"/>
                    <asp:HiddenField ID="hf_ReceiveID" runat="server" Value="1,2,3,4,5,6,7" />
                    <asp:HiddenField ID="hf_lid" runat="server" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
