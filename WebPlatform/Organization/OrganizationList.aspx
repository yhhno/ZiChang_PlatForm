<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrganizationList.aspx.cs" Inherits="Organization_OrganizationList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script language="javascript" src="../Myjs/winModel.js" type="text/javascript"></script>

    <script language="javascript" src="../Myjs/drag.js" type="text/javascript"></script>

    <script language="javascript" src="../Myjs/createHTML.js" type="text/javascript"></script>

    <script language="javascript" src="../Myjs/js_webFormForModel.js" type="text/javascript"></script>

    <script language="javascript" src="../Myjs/GridViewSet.js" type="text/javascript"></script>
    <script src="../Myjs/Valid.js" type="text/javascript" language="javascript"></script>
    <script type="text/javascript" language="javascript">

        function OrganizationAdd(pid) {
            var formAdd = new js_webFormForModel_Forms('Organization/OrganizationAdd.aspx?pid='+pid, 'formAdd', '添加部门', '', { width: 540, height: 390 });
            formAdd.initforms();
            formAdd.remethod = function() {
                //$get('txt_orgCode').value = formAdd.returnvalue; //获取返回值
                $get('lk').click();
            }
        }
        function OrganizationUpdate(orgID) {
            var formUpdate = new js_webFormForModel_Forms('Organization/OrganizationAdd.aspx?orgid=' + orgID, 'formUpdate', '修改部门', '', { width: 540, height: 390 });
            formUpdate.initforms();
            formUpdate.remethod = function() {
                $get('lk').click();
            }
        } 

    </script>

</head>
<body onkeydown="if(event.keyCode==13){event.keyCode = 9;event.returnValue = false;document.getElementById('imgbtnSearch').click();}">
    <form id="formOrg" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <table cellpadding="0" cellspacing="0" style="width: 100%" border="0">
                    <%--<tr>
                        <td colspan="2" style="background-image: url('../Images/gridheadbg.jpg')">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 24px; height: 24px; background-image: url('../../Images/headerleft.gif');">
                                    </td>
                                    <td style="width: 100px; height: 24px; background-image: url('../../Images/headercenter.gif');
                                        background-repeat: repeat-x">
                                        <span class="header">&nbsp;部门维护</span>
                                    </td>
                                    <td style="width: 10px; height: 24px; background-image: url('../../Images/headerright.gif');">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>--%>
                    <tr>
                        <td style="width: 25%; background-color: #F4F8FD;" valign="top">
                            <div style="overflow-x: auto;">
                                <asp:TreeView CssClass="tree" ID="tv_Org" runat="server" OnSelectedNodeChanged="tv_Org_SelectedNodeChanged">
                                    <ParentNodeStyle ImageUrl="~/Images/application_add.png" />
                                    <SelectedNodeStyle BackColor="#B8CFEE" />
                                    <RootNodeStyle ImageUrl="~/Images/application.png" />
                                    <LeafNodeStyle ImageUrl="~/Images/application_cascade.png" />
                                </asp:TreeView>
                            </div>
                        </td>
                        <td valign="top" style="width:75%">
                            <table border="0" cellpadding="0" cellspacing="0" style="width:100%">
                                <tr>
                                    <td style="width: 100%; background-image: url('../Images/searchbg.jpg')" height="25px">
                                        <table class="search" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="80px" align="right">
                                                    部门代码：
                                                </td>
                                                <td width="150px" align="left">
                                                    <asp:TextBox ID="txt_orgCode" runat="server" onkeypress="return ValidateSpecialCharacter();"></asp:TextBox>
                                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                    runat="server" ControlToValidate="txt_orgCode" ErrorMessage="您输入的部门代码不能包含特殊字符" 
                    Display="None" ValidationExpression="^[^<>/'\|\\]+$"></asp:RegularExpressionValidator>
                                                </td>
                                                <td align="right" width="80px">
                                                    部门名称：
                                                </td>
                                                <td align="left" width="150px">
                                                    <asp:DropDownList ID="ddl_orgName" runat="server" Width="200px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="imgbtnSearch" ImageUrl="../Images/search.jpg" runat="server"
                                                        OnClick="imgbtnSearch_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="background-image: url('../Images/searchline.jpg'); height: 3px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 23px; background-image: url('../Images/form/bg.gif'); border: 1px solid #99bbe8;">
                                        <table cellpadding="0" cellspacing="0" border="0" style="width:300px">
                                            <tr>
                                                <td style="width: 70px;" align="center">
                                                    <div>
                                                        <table cellpadding="0"  cellspacing="0" border="0" onmouseover="over(this);" onmouseout="out(this);">
                                                            <tr>
                                                                <td style="width: 3px; height: 21px;">
                                                                </td>
                                                                <td style="vertical-align: middle; text-align: center; padding: 0 5px; cursor: pointer;white-space: nowrap;">
                                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                                        <tr>
                                                                            <td>
                                                                                <img src="../Images/icons/add.png" alt="" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:LinkButton ID="lkAdd" runat="server"
                                                                                    OnClick="lkAdd_Click">添 加</asp:LinkButton>
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
                                                <td style="width: 70px;" align="center">
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
                                                                                <asp:LinkButton ID="lkUpdate" runat="server" OnClientClick="return GridSelect('gdv_Org', 'one', 'hdKey','')"
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
                                                <td style="width: 70px;" align="center">
                                                    <div>
                                                        <table cellpadding="0" cellspacing="0" border="0" onmouseover="over(this);" onmouseout="out(this);">
                                                            <tr>
                                                                <td style="width: 3px; height: 21px;">
                                                                </td>
                                                                <td style="vertical-align: middle; text-align: center; padding: 0 5px;">
                                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                                        <tr>
                                                                            <td>
                                                                                <img src="../Images/icons/delete.png" alt="" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:LinkButton ID="lkForbid" runat="server" OnClientClick="return GridSelect('gdv_Org', 'more', 'hdKey','您确认禁用吗？')"
                                                                                    OnClick="lkForbid_Click"><font color="black">禁 用</font></asp:LinkButton>
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
                                                <td style="width: 70px;" align="center">
                                                    <div>
                                                        <table cellpadding="0" cellspacing="0" border="0" onmouseover="over(this);" onmouseout="out(this);">
                                                            <tr>
                                                                <td style="width: 3px; height: 21px;">
                                                                </td>
                                                                <td style="vertical-align: middle; text-align: center; padding: 0 5px;">
                                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                        <tr>
                                                                            <td>
                                                                                <img src="../Images/icons/hotelmanage.png" alt="" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:LinkButton ID="lkStart" runat="server" OnClientClick="return GridSelect('gdv_Org', 'more', 'hdKey','您确认启用吗？')"
                                                                                    OnClick="lkStart_Click"><font color="black">启 用</font></asp:LinkButton>
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
                                    <td valign="top">
                                        <asp:GridView ID="gdv_Org" runat="server" DataKeyNames="OrgCode" AutoGenerateColumns="False"
                                            BorderStyle="None" OnRowDataBound="gdv_Org_RowDataBound">
                                            <Columns>
                                            <asp:TemplateField HeaderText="&lt;input id='cbxAll'  type='checkbox'  onclick=CheckBoxAll(this,'gdv_Org') /&gt;">
                                               
                                                    <ItemTemplate>
                                                       
                                                        <asp:CheckBox ID="cbx" runat="server" /><asp:HiddenField ID="hdIsForbid" runat="server" Value='<%# Eval("IsForbid") %>'/>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="OrgCode" HeaderText="部门代码" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="OrgName" HeaderText="部门名称">
                                                </asp:BoundField>
                                                <asp:BoundField DataField="OrgTypeName" HeaderText="部门类型">
                                                </asp:BoundField>
                                                <asp:BoundField DataField="LinkMan" HeaderText="联系人">
                                                </asp:BoundField>
                                                <asp:BoundField DataField="LinkManTel" HeaderText="联系人电话" />
                                                <asp:TemplateField HeaderText="状态">
                                                    <ItemTemplate>
                                                    
                                                        <asp:Label ID="lblIsForbid" runat="server" 
                                                            Text='<%# GetStatus(Eval("IsForbid").ToString()) %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <div align="center"><b>无数据...</b></div>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="page">
                                        <webdiyer:AspNetPager AlwaysShow="true" ID="anp_Org" runat="server" PageSize="15"
                                            OnPageChanging="anp_Org_PageChanging" ShowCustomInfoSection="Left" FirstPageText="第一页"
                                            HorizontalAlign="Left" LastPageText="最后一页" NextPageText="下一页" PrevPageText="上一页">
                                        </webdiyer:AspNetPager>
                                    </td>
                                </tr>
                            </table>
                        </td></tr>                            
                </table>
                <asp:HiddenField ID="hdKey" runat="server" />
            <asp:LinkButton ID="lk" runat="server" OnClick="lk_Click"></asp:LinkButton>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
