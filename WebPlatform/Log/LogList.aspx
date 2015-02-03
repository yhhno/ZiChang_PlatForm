<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogList.aspx.cs" Inherits="Log_LogList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <script language="javascript" src="../Myjs/GridViewSet.js" type="text/javascript"></script>

    <script language="javascript" src="../Myjs/createHTML.js" type="text/javascript"></script>

    <script language="javascript" src="../Myjs/drag.js" type="text/javascript"></script>

    <script language="javascript" src="../Myjs/js_webFormForModel.js" type="text/javascript"></script>

    <script src="../Myjs/winModel.js" type="text/javascript"></script>
        <script src="../Myjs/Calendar/WdatePicker.js" type="text/javascript"></script>

</head>
<body onkeydown="if(event.keyCode==13){event.keyCode = 9;event.returnValue = false;document.getElementById('btn_Select').click();}">

    

    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <table cellpadding="0" cellspacing="0" style="width: 100%" border="0">
                    <tr>
                    <td style="background-image: url('../Images/gridheadbg.jpg')" align="left">
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="width:24px;height:24px;background-image: url('../Images/headerleft.gif');" >
                                
                                </td>
                                <td style="width:100px;height:24px;background-image: url('../Images/headercenter.gif'); background-repeat: repeat-x">
                                    <span class="header">&nbsp;操作日志查看</span>
                                </td>
                                <td style="width:10px;height:24px;background-image: url('../Images/headerright.gif');" >
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                    <tr>
                        <td style="width: 100%;" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                <tr>
                                    <td style="width: 100%; background-image: url('../Images/searchbg.jpg')" height="25px"
                                        colspan="3">
                                        <table class="search">
                                            <tr>
                                                 <td width="80px;" align="right">
                                                    操作类型：
                                                </td>
                                                <td width="160px" align="left" >
                                                    <asp:DropDownList ID="ddlLOGTYPE" runat="server" Width="157">
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="90px" align="right">
                                                    &nbsp;操作人：</td>
                                                <td width="160px" align="left">
                                                    <asp:TextBox ID="txtOperatMan" runat="server" MaxLength="20"></asp:TextBox>
                                                </td>
                                                
                                                <td width="90px" align="right">
                                                    &nbsp;</td>
                                                <td align="left">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                
                                                <td width="90px" align="right">
                                                    操作日期(从)：
                                                </td>
                                                <td  align="left"   width="160px">
                                                       <asp:TextBox id="txtBeginDate" runat="server"  onclick="WdatePicker()" ></asp:TextBox> 
                                                </td>
                                                <td width="90px" align="right">
                                                     操作日期(至)：
                                                </td>
                                                <td  align="left"   width="160px">
                                                       <asp:TextBox id="txtEndDate" runat="server"  onclick="WdatePicker()" ></asp:TextBox> 
                                                </td>
                                                <td><asp:ImageButton ID="btn_Select" ImageUrl="../Images/search.jpg" runat="server"
                                                        OnClick="btn_Select_Click" /></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="background-image: url('../Images/searchline.jpg'); height: 3px" colspan="3">
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td valign="top" style="height: 20px" colspan="3">
                                        <asp:GridView ID="gdv_OperateLog" runat="server" DataKeyNames="logID" AutoGenerateColumns="False"
                                            Width="100%">
                                            <Columns>
                                                 
                                                <asp:BoundField DataField="LOGTYPE" HeaderText="操作类型" />
                                                <asp:BoundField DataField="operatTable" HeaderText="操作表" />
                                                <asp:BoundField DataField="username" HeaderText="操作人" />
                                                <asp:BoundField DataField="operatedate" HeaderText="操作时间" />
                                                <asp:BoundField DataField="operateIP" HeaderText="操作IP" />
                                                <asp:BoundField DataField="Remark" HeaderText="具体描述" />
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <div align="center">
                                                    <b>无数据...</b></div>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="page" colspan="3">
                                        <webdiyer:AspNetPager AlwaysShow="true" ID="anp_OperateLog" runat="server" PageSize="15"
                                            ShowCustomInfoSection="Left" OnPageChanging="anp_OperateLog_PageChanging" FirstPageText="第一页"
                                            HorizontalAlign="Left" LastPageText="最后一页" NextPageText="下一页" PrevPageText="上一页">
                                        </webdiyer:AspNetPager>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <asp:HiddenField ID="hdKey" runat="server" />
           <%-- <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" Height="0px"
                Width="0px" />--%>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
