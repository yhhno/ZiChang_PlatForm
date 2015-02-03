<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PositionList.aspx.cs" Inherits="Organization_OrganizationList" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script language="javascript" src="../Myjs/winModel.js" type="text/javascript"></script>

    <script language="javascript" src="../Myjs/drag.js" type="text/javascript"></script>

    <script language="javascript" src="../Myjs/createHTML.js" type="text/javascript"></script>

    <script language="javascript" src="../Myjs/js_webFormForModel.js" type="text/javascript"></script>

    <script language="javascript" src="../Myjs/GridViewSet.js" type="text/javascript"></script>
    <script src="../Myjs/Valid.js" type="text/javascript" language="javascript"></script>
    
    <script language="javascript" type="text/javascript">
        //表头CheckBox的选中
        function CheckBoxAll(obj) {
            var es = document.getElementsByTagName("input");
            var j = 1;
            var trArr = $get('gdv_Org');
            for (var i = 0; i < es.length; i++) {
                if (es[i].type == "checkbox") {
                    es[i].checked = obj.checked;
                    if (j < trArr.rows.length) {
                        if (obj.checked == true) {
                            trArr.rows[j].className = "RowStyleChecked";
                        }
                        else {
                            trArr.rows[j].className = "RowStyleOut";
                        }
                        j++;
                    }
                }
            }
        }
    </script>

</head>
<body onkeydown="if(event.keyCode==13){event.keyCode = 9;event.returnValue = false;document.getElementById('btn_Select').click();}">

    <script language="javascript" type="text/javascript">
        
        function AddFrom(orgID) {
            var form = new js_webFormForModel_Forms('Position/DataEdit.aspx?orgid=' + orgID, 'OperForm', '新增职位', '', { width: 450, height: 220 });
            form.initforms();
            form.remethod = function() {
                $get('btn_Select').click();
            }
        }
        
      function EditFrom(strname) {
          var form = new js_webFormForModel_Forms('Position/DataEdit.aspx?PositonID=' + strname, 'OperForm', '修改职位', '', { width: 450, height: 280 });
            form.initforms();
            form.remethod = function() {
                $get('btn_Select').click();
            }
        }
        
        function Role(ID) {
            var form = new js_webFormForModel_Forms('Position/RoleRight.aspx?PositonID=' + ID, 'OperForm', '设置权限', '', { width: 500, height: 510 });
            form.initforms();
            form.remethod = function() {
                //$get('btn_Select').click();
            }
        }
    </script>

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
                                        <span class="header">&nbsp;职位维护</span>
                                    </td>
                                    <td style="width: 10px; height: 24px; background-image: url('../../Images/headerright.gif');">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>--%>
                    <tr>
                        <td style="width: 75%;" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                <tr>
                                    <td style="width: 100%; background-image: url('../Images/searchbg.jpg')" height="25px"
                                        colspan="3">
                                        <table class="search" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="80px" align="right">
                                                    职位名称：
                                                </td>
                                                <td width="150px" align="left">
                                                    <asp:TextBox ID="txt_position" runat="server" onkeypress="return ValidateSpecialCharacter();"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="btn_Select" ImageUrl="../Images/search.jpg" runat="server" OnClick="btn_Select_Click" />
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
                                    <td style="background-image: url('../Images/navbg.jpg')" colspan="3">
                                        <table cellpadding="0" cellspacing="0" border="0" width="380px">
                                            <tr>
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
                                                                                <asp:LinkButton ID="lkUpdate" runat="server" OnClick="lkUpdate_Click" OnClientClick="return GridSelect('gdv_Org', 'one', 'hdKey','')">修 改</asp:LinkButton>
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
                                                
                                                <td style="width: 80px;" align="center">
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
                                                                                <img src="../Images/icons/usericon.png" alt="" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:LinkButton ID="lkSetpower" runat="server" OnClick="lkSetpower_Click" OnClientClick="return GridSelect('gdv_Org', 'one', 'hdKey','')"><font color="black">权限设置</font></asp:LinkButton>
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
                                                 <td align="center" style="width: 70px;">
                                                    <table border="0" cellpadding="0" cellspacing="0" onmouseout="out(this);" 
                                                        onmouseover="over(this);">
                                                        <tr>
                                                            <td style="width: 3px; height: 21px;">
                                                            </td>
                                                            <td style="vertical-align: middle; text-align: center; padding: 0 5px; cursor: pointer;
                                                                    white-space: nowrap;">
                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                    <tr>
                                                                        <td>
                                                                            <img alt="" src="../Images/icons/delete.png" />
                                                                        </td>
                                                                        <td>
                                                                             <asp:LinkButton ID="LinkButton2" runat="server" OnClick="lkDelete_Click" 
                                                                                
                                                                                 OnClientClick="return GridSelect('gdv_Org', 'more', 'hdKey','您确定要禁用选定的记录吗？')"><font 
                                                                                color="black">禁 用</font></asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td style="width: 3px; height: 21px;">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="width: 1px;">
                                                    <span class="spilt"></span>
                                                </td>
                                                <td align="center" style="width:70px;">
                                                <table border="0" cellpadding="0" cellspacing="0" onmouseout="out(this);" 
                                                        onmouseover="over(this);">
                                                        <tr>
                                                            <td style="width: 3px; height: 21px;">
                                                            </td>
                                                            <td style="vertical-align: middle; text-align: center; padding: 0 5px; cursor: pointer;
                                                                    white-space: nowrap;">
                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                    <tr>
                                                                        <td>
                                                                            <img alt="" src="../Images/icons/hotelmanage.png" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LkEmbargoor_Click" 
                                                                                
                                                                                OnClientClick="return GridSelect('gdv_Org', 'more', 'hdKey','您确定要启用选定的记录吗？')"><font 
                                                                                color="black">启 用</font></asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td style="width: 3px; height: 21px;">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" style="height: 20px" colspan="3">
                                        <asp:GridView ID="gdv_Org" runat="server" DataKeyNames="PositionCode" AutoGenerateColumns="False"
                                            Width="100%" BorderStyle="None" OnRowDataBound="gdv_Org_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField HeaderText="<input id='cbxAll' type='checkbox' onclick='CheckBoxAll(this);' />">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="cbx" runat="server" />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="30px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="PositionCode" HeaderText="职位编号" />
                                                <asp:BoundField DataField="PositionName" HeaderText="职位名称" />
                                                <asp:TemplateField HeaderText="状态">
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="hdIsForbid" Value='<%# Eval("IsForbid") %>' runat="server" />
                                                        <asp:Label ID="lblIsForbid" runat="server" Text='<%# GetStatus(Eval("IsForbid").ToString()) %>'></asp:Label>
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
                                    <td class="page" colspan="3">
                                        <webdiyer:AspNetPager AlwaysShow="true" ID="anp_Org" runat="server" PageSize="15"
                                            ShowCustomInfoSection="Left" OnPageChanging="anp_Org_PageChanging" FirstPageText="第一页"
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
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
