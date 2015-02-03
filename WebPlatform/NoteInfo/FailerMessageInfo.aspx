<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FailerMessageInfo.aspx.cs"
    Inherits="NoteInfo_FailerMessageInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <script language="javascript" src="../Js/GridViewSet.js" type="text/javascript"></script>

    <script language="javascript" src="../Js/createHTML.js" type="text/javascript"></script>

    <script language="javascript" src="../Js/drag.js" type="text/javascript"></script>

    <script language="javascript" src="../Js/js_webFormForModel.js" type="text/javascript"></script>

    <script src="../Js/winModel.js" type="text/javascript"></script>

    <script language="javascript" src="../Js/Calendar/WdatePicker.js" type="text/javascript"></script>

</head>
<body onkeydown="if(event.keyCode==13){event.keyCode = 9;event.returnValue = false;}">
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
                                <tr style="display:none">
                                    <td style="width: 24px; height: 24px; background-image: url('../Images/headerleft.gif');">
                                    </td>
                                    <td style="width: 100px; height: 24px; background-image: url('../Images/headercenter.gif');
                                        background-repeat: repeat-x">
                                        <span class="header">&nbsp;发送失败短信</span>
                                    </td>
                                    <td style="width: 10px; height: 24px; background-image: url('../Images/headerright.gif');">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%;" valign="top">
                            <table class="search" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="right" width="80px">
                                        手机号码：
                                    </td>
                                    <td align="left" width="120px" height="25px">
                                        <asp:TextBox ID="TxtPhoneNumber" runat="server"></asp:TextBox>
                                    </td>
                                    <td align="right" width="80px">
                                        开始日期(从)：
                                    </td>
                                    <td align="left" width="120px" height="25px">
                                        <asp:TextBox ID="txtDateStart" runat="server" onclick="WdatePicker()"></asp:TextBox>
                                    </td>
                                    <td align="right" width="80px">
                                        结束日期(至)：
                                    </td>
                                    <td align="left" width="120px">
                                        <asp:TextBox ID="txtDateEnd" runat="server" Width="120px" onclick="WdatePicker()"></asp:TextBox>
                                    </td>
                                    <td align="right" width="80px">
                                        &nbsp;
                                    </td>
                                    <td align="left" width="120px">
                                        <asp:ImageButton ID="imgbtnSearch" runat="server" ImageUrl="../Images/search.jpg"
                                            OnClick="imgbtnSearch_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-image: url('../Images/searchline.jpg'); height: 3px" colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td style="background-image: url('../Images/navbg.jpg')" colspan="3" align="left">
                            <table cellpadding="0" cellspacing="0" border="0" width="250px">
                                <tr>
                                    <td style="width: 200px;" align="left">
                                        <div>
                                            <table cellpadding="0" cellspacing="0" border="0" onmouseover="over(this);" onmouseout="out(this);">
                                                <tr>
                                                    <td style="width: 3px; height: 21px;">
                                                    </td>
                                                    <td style="vertical-align: middle; text-align: center; padding: 0 5px; cursor: pointer;
                                                        white-space: nowrap;">
                                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                            <tr>
                                                                <td>
                                                                    <img src="../Images/icons/edit.png" alt="" />
                                                                </td>
                                                                <td>
                                                                    <asp:LinkButton ID="lkView" runat="server"
                                                                        OnClick="lkView_Click">继续发送短信</asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td style="width: 3px; height: 21px;">
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" style="height: 20px" colspan="3">
                            <asp:GridView ID="gdv_MessageInfo" runat="server" DataKeyNames="FSMID" AutoGenerateColumns="False"
                                Width="100%" BorderStyle="None" 
                                onrowdatabound="gdv_MessageInfo_RowDataBound">
                                <Columns>
                                 <asp:TemplateField  HeaderText="<input id='cbxAll' type='checkbox' onclick=CheckBoxAll(this,'gdv_MessageInfo'); />">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="cbx" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle Width="30px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="MobileNo" HeaderText="接收手机号码">
                                        <ItemStyle Width="100px" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="短信内容">
                                        <ItemTemplate>
                                            <asp:Label ID="LabMContent" runat="server" Text='<%# Eval("MContent") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="FailerDate" HeaderText="发送时间">
                                        <ItemStyle Width="110px" />
                                    </asp:BoundField>
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
                            <webdiyer:AspNetPager AlwaysShow="true" ID="anp_MessageInfo" runat="server" PageSize="20"
                                ShowCustomInfoSection="Left" OnPageChanging="anp_MessageInfo_PageChanging" FirstPageText="第一页"
                                HorizontalAlign="Left" LastPageText="最后一页" NextPageText="下一页" PrevPageText="上一页">
                            </webdiyer:AspNetPager>
                        </td>
                    </tr>
                </table>
                </td> </tr> </table>
            </div>
            <asp:HiddenField ID="hdKey" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
