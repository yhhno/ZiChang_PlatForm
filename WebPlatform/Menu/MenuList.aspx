<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MenuList.aspx.cs" Inherits="Menu_MenuList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>菜单列表</title>

    <script language="javascript" src="../Myjs/winModel.js" type="text/javascript"></script>

    <script language="javascript" src="../Myjs/drag.js" type="text/javascript"></script>

    <script language="javascript" src="../Myjs/createHTML.js" type="text/javascript"></script>

    <script language="javascript" src="../Myjs/js_webFormForModel.js" type="text/javascript"></script>

    <script language="javascript" src="../Myjs/GridViewSet.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        function MenuAdd() {
            var form = new js_webFormForModel_Forms('Menu/AddMenu.aspx', 'OperForm', '添加菜单项', '', { width: 450, height: 300 });
            form.initforms();
            form.remethod = function() {
                $get('lk').click();
            }
        }

        function MenuUpdate(menuID) {
            var form = new js_webFormForModel_Forms('menu/AddMenu.aspx?menuID=' + menuID, 'OperForm', '修改菜单项', '', { width: 450, height: 300 });
            form.initforms();
            form.remethod = function() {
                $get('lk').click();
            }
        }
    </script>

</head>
<body onkeydown="if(event.keyCode==13){ $get('lk').click();}">
    <form id="form1" runat="server">
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
                                        <span class="header">&nbsp;菜单维护</span>
                                    </td>
                                    <td style="width: 10px; height: 24px; background-image: url('../../Images/headerright.gif');">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>--%>
                    <tr>
                        <td rowspan="5" style="width:20%; background-color: #F4F8FD;" valign="top">
                            <div style="overflow: auto; width: 100%">
                                <asp:TreeView ID="tv_Menu" runat="server" OnSelectedNodeChanged="tv_Menu_SelectedNodeChanged"
                                    ShowLines="True">
                                    <ParentNodeStyle ImageUrl="~/Images/application_add.png" />
                                    <SelectedNodeStyle BackColor="#6699FF" />
                                    <RootNodeStyle ImageUrl="~/Images/application.png" />
                                    <LeafNodeStyle ImageUrl="~/Images/application_cascade.png" />
                                </asp:TreeView>
                            </div>
                        </td>
                        <td valign="top" style="width:80%">
                            <!--fdsf-->
                            <table cellpadding="0" cellspacing="0" style="width:100%">
                                <tr>
                                    <td style="width: 100%; background-image: url('../Images/searchbg.jpg')" height="25px" align="left">
                                        <table class="search" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="right" width="80px">
                                                    菜单名称：
                                                </td>
                                                <td align="left" width="150px">
                                                    <asp:TextBox ID="txt_MenuName" runat="server"></asp:TextBox>
                                                </td>
                                                <td width="80px" align="right">
                                                    菜单编号：
                                                </td>
                                                <td width="150px" align="left">
                                                    <asp:TextBox ID="txt_MenuID" runat="server"></asp:TextBox>
                                                </td>
                                                <td align="center">
                                                    <asp:ImageButton ID="imgbtnSearch" ImageUrl="../Images/search.jpg" runat="server" OnClick="imgbtnSearch_Click" />
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
                                    <td style="background-image: url('../Images/navbg.jpg')">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:ImageButton ID="imgbtnAdd" CssClass="imgHover" ImageUrl="~/Images/button/add.jpg"
                                                        runat="server" OnClick="imgbtnAdd_Click" />
                                                </td>
                                                <td>
                                                    <img alt="" src="../Images/button/sp.jpg" />
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="imgbtnUpdate" CssClass="imgHover" OnClientClick="return GridSelect('gdv_Menu', 'one', 'hdKey','')"
                                                        ImageUrl="~/Images/button/update.jpg" runat="server" OnClick="imgbtnUpdate_Click" />
                                                </td>
                                                <td>
                                                    <img alt="" src="../Images/button/sp.jpg" />
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="imgbtnDelete" CssClass="imgHover" OnClientClick="return GridSelect('gdv_Menu', 'more', 'hdKey','删除时，该菜单项的下级菜单项均被删除，您确定要删除选吗？')"
                                                        ImageUrl="~/Images/button/delete.jpg" runat="server" OnClick="imgbtnDelete_Click" />
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" style="height: 20px">
                                        <asp:GridView ID="gdv_Menu" runat="server" AutoGenerateColumns="False" DataKeyNames="MenuID,ParentsID"
                                            Width="100%" OnRowDataBound="gdv_Menu_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField HeaderText="&lt;input id='cbxAll'  type='checkbox'  onclick=CheckBoxAll(this,'gdv_Menu') /&gt;">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="cbx" runat="server" />
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="30px" />
                                                    <ItemStyle Width="30px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="MenuID" HeaderText="菜单编号" />
                                                <asp:BoundField DataField="MenuName" HeaderText="菜单名称" />
                                                <asp:BoundField DataField="MeunUrl" HeaderText="菜单链接" Visible="false" />
                                                <asp:TemplateField HeaderText="叶子菜单" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("isLeaf")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="父菜单">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="menuLevel" HeaderText="菜单级别" />
                                                <asp:BoundField DataField="ICValue" HeaderText="图片地址" Visible="false" />
                                                <asp:TemplateField HeaderText="是否弹出" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("isPOP") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <div align="center">
                                                    <b>无数据...</b></div>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="page">
                                        <webdiyer:AspNetPager ID="anp_Menu" runat="server" PageSize="15" ShowCustomInfoSection="Left" FirstPageText="第一页"
                                            HorizontalAlign="Left" LastPageText="最后一页" NextPageText="下一页" PrevPageText="上一页"
                                            OnPageChanging="anp_Menu_PageChanging" ShowBoxThreshold="10" AlwaysShow="true">
                                        </webdiyer:AspNetPager>
                                    </td>
                                </tr>
                            </table>
                            <!--end-->
                        </td>
                    </tr>
                </table>
            </div>
            <asp:HiddenField ID="hdKey" runat="server" />
            <asp:LinkButton ID="lk" runat="server" OnClick="lk_Click"></asp:LinkButton>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <p>
&nbsp;</p>
</body>
</html>
