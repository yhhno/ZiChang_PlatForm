<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeFile="CollieryList.aspx.cs" Inherits="Colliery_CollieryList" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>



     <script language="javascript" src="../Myjs/GridViewSet.js" type="text/javascript"></script>

    <script language="javascript" src="../Myjs/createHTML.js" type="text/javascript"></script>

    <script language="javascript" src="../Myjs/drag.js" type="text/javascript"></script>

    <script language="javascript" src="../Myjs/js_webFormForModel.js" type="text/javascript"></script>

    <script src="../Myjs/winModel.js" type="text/javascript"></script>
</head>
<body onkeydown="if(event.keyCode==13){event.keyCode = 9;event.returnValue = false;document.getElementById('imgbtnSearch').click();}">

    <script language="javascript" type="text/javascript">

        function AddFrom() {
      //Colliery/
            var form = new js_webFormForModel_Forms('Colliery/CollieryEdit.aspx', 'OperForm', '新增煤矿信息', '', { width: 680, height: 520, minbtn: false, maxbtn: false });
            form.initforms();
            form.remethod = function() {
            document.getElementById("imgbtnSearch").click();
            }
        }

        function EditFrom(strCollCode) {
            var form = new js_webFormForModel_Forms('Colliery/CollieryEdit.aspx?dat='+new Date()+'&CollID=' + strCollCode, 'OperForm', '修改煤矿信息', '', { width: 680, height: 520, minbtn: false, maxbtn: false });
            form.initforms();
            form.remethod = function() {
            document.getElementById("lk").click();
            }
        }
  
        
    </script>

    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <table cellpadding="0" cellspacing="0" style="width: 100%" border="0">
                    <tr  style="display:none">
                        <td style="background-image: url('../Images/gridheadbg.jpg')" align="left">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 24px; height: 24px; background-image: url('../Images/headerleft.gif');">
                                    </td>
                                    <td style="width: 100px; height: 24px; background-image: url('../Images/headercenter.gif');
                                        background-repeat: repeat-x">
                                        <span class="header">&nbsp;煤矿维护</span>
                                    </td>
                                    <td style="width: 10px; height: 24px; background-image: url('../Images/headerright.gif');">
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
                                                <td width="80px" align="right">
                                                    煤矿编号：
                                                </td>
                                                <td width="140px" align="left">
                                                    <asp:TextBox ID="txtCollCode" runat="server" MaxLength="20"></asp:TextBox>
                                                </td>
                                                <td width="80px" align="right">
                                                    煤矿名称：
                                                </td>
                                                <td width="140px" align="left">
                                                    <asp:TextBox ID="txtCollName" runat="server" MaxLength="50"></asp:TextBox>
                                                </td>
                                               <td></td>
                                            </tr>
                                            <tr>
                                             <td width="80px" align="right">
                                                    所属乡镇：
                                                </td>
                                                <td width="120px" align="left">
                                                    <asp:DropDownList ID="ddlVillageCode" runat="server" Width="157px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="80px" align="right">
                                                    是否禁用：
                                                </td>
                                                <td width="140px" align="left">
                                                    <asp:DropDownList ID="ddlIsForbid" runat="server" Width="157px">
                                                        <asp:ListItem Value="-1">请选择是否禁用</asp:ListItem>
                                                        <asp:ListItem Value="0">否</asp:ListItem>
                                                        <asp:ListItem Value="1">是</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <td>
                                                        <asp:ImageButton ID="imgbtnSearch" ImageUrl="../Images/search.jpg" runat="server"
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
                                        <table cellpadding="0" cellspacing="0" border="0" width="280px">
                                            <tr>
                                                <td style="width: 3px">
                                                </td>
                                                <td style="width: 70px;" align="left">
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
                                                                                <img src="../Images/icons/add.png" alt="" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:LinkButton ID="lkAdd" runat="server" OnClick="lkAdd_Click">添 加</asp:LinkButton>
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
                                                <td style="width: 1px;">
                                                    <span class="spilt"></span>
                                                </td>
                                                <td style="width: 70px;" align="left">
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
                                                                                <asp:LinkButton ID="lkUpdate" runat="server" OnClientClick="return GridSelect('gdv_Colliery', 'one', 'hdKey','')"
                                                                                    OnClick="lkUpdate_Click">修 改</asp:LinkButton>
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
                                                <td style="width: 1px;">
                                                    <span class="spilt"></span>
                                                </td>
                                                
                                                <td style="width: 70px;" align="left">
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
                                                                                <img alt="" src="../Images/icons/delete.png" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:LinkButton ID="lkForbid0" runat="server" OnClick="lkForbid_Click" 
                                                                                    OnClientClick="return GridSelect('gdv_Colliery', 'more', 'hdKey','您确定要禁用选定的记录吗？')"><font 
                                                                                    color="black">禁 用</font></asp:LinkButton>
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
                                                <td style="width: 1px;">
                                                    <span class="spilt"></span>
                                                </td>
                                                <td style="width: 70px;" align="left">
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
                                                                                <img src="../Images/icons/hotelmanage.png" alt="" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:LinkButton ID="LkEmbargoor" runat="server" 
                                                                                    meta:resourcekey="LkEmbargoorResource1" OnClick="LkEmbargoor_Click" 
                                                                                    OnClientClick="return GridSelect('gdv_Colliery', 'more', 'hdKey','您确定要启用选定的记录吗？')"><font 
                                                                                    color="black">启 用</font></asp:LinkButton>
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
                                        <asp:GridView ID="gdv_Colliery" runat="server" DataKeyNames="CollCode" AutoGenerateColumns="False"
                                            Width="100%" BorderStyle="None" OnRowDataBound="gdv_Colliery_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField HeaderText="<input id='cbxAll' type='checkbox' onclick=CheckBoxAll(this,'gdv_Colliery'); />">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="cbx" runat="server" />
                                                        <asp:HiddenField ID="hdIsForbid" runat="server" Value='<%# Eval("IsForbid") %>'/>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="30px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="CollCode" HeaderText="煤矿编号">
                                                <ItemStyle Width="60px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="CollName" HeaderText="煤矿名称" />
                                                <asp:BoundField DataField="VillageName" HeaderText="所属乡镇" />
                                                <asp:BoundField DataField="MinePhone" HeaderText="煤矿电话" />
                                                <asp:BoundField DataField="CollStateName" HeaderText="煤矿状态">
                                                    <ItemStyle Width="80px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="CollProperty" HeaderText="煤矿属性">
                                                    <ItemStyle Width="80px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ParcelName" HeaderText="所属片区" />
                                                <asp:BoundField DataField="Forbid" HeaderText="是否禁用">
                                                    <ItemStyle Width="60px" />
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
                                        <webdiyer:AspNetPager AlwaysShow="true" ID="anp_Colliery" runat="server" PageSize="10"
                                            ShowCustomInfoSection="Left" OnPageChanging="anp_Colliery_PageChanging" FirstPageText="第一页"
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
            
            <asp:LinkButton ID="lk" runat="server" onclick="lk_Click"></asp:LinkButton>
            
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
