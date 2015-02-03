<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoleRight.aspx.cs" Inherits="Position_RoleRight" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>

    <script src="../Myjs/js_webFormForModel.js" type="text/javascript"></script>

    <script src="../Myjs/TreeViewCheck.js" type="text/javascript"></script>

    <script src="../Myjs/winModel.js" type="text/javascript"></script>

    <style type="text/css">
        .blueTable
        {
            border: 1px solid #B1CBE8;
            background-color: #C7D6E9; 
            font: 12px "宋体";
            width: 100%;
            padding: 2px;
            line-height: 20px;
        }
        a:visited
        {
            color: #797979;
            text-decoration: none;
        }
        a:hover
        {
            color: #FF0000;
            text-decoration: none;
        }
        a:active
        {
            color: #FF0000;
            text-decoration: none;
        }
    </style>
    
</head>
<body style="background-color: #C7D6E9;" onkeydown="if(event.keyCode==13){event.keyCode = 9;event.returnValue = false;document.getElementById('btn_Edit').click();}">
    <form id="form1" runat="server">
    <input id="h_Count" runat="server" type="hidden" />
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="upDepartAdd" runat="server">
            <ContentTemplate>
                <table cellpadding="0" cellspacing="0" width="100%" class="blueTable" align="center">
                    <tr>
                        <td align="left">
                            <b><asp:Label ID="lblName" runat="server"></asp:Label>
                            职位权限设置</b>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" class="blueTable" align="center">
                                <tr>
                                    <td valign="top" style="width: 100%">
                                        <div style="width: 480px;height:440px;overflow-y:auto">
                                            <asp:TreeView ID="tvmeun" runat="server" NodeIndent="20" ShowLines="True" ShowCheckBoxes="All">
                                            </asp:TreeView>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:ImageButton ID="btn_Edit" runat="server" ImageUrl="~/Images/baocun.gif" OnClick="btn_Edit_Click" />
                            &nbsp;
                            <asp:ImageButton ID="btn_chongzhi" runat="server" ImageUrl="~/Images/chongzhi.gif"
                                OnClick="btn_chongzhi_Click" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
