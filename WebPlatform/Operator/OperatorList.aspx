<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OperatorList.aspx.cs" Inherits="Operator_OperatorList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>

    <script src="../Myjs/js_setShortcut.js" type="text/javascript"></script>

    <style type="text/css">
        .style1 
        {
            width: 100%;
        }
    </style>

    <script language="javascript" src="../Myjs/winModel.js" type="text/javascript"></script>

    <script language="javascript" src="../Myjs/drag.js" type="text/javascript"></script>

    <script language="javascript" src="../Myjs/createHTML.js" type="text/javascript"></script>

    <script language="javascript" src="../Myjs/js_webFormForModel.js" type="text/javascript"></script>

    <script language="javascript" src="../Myjs/GridViewSet.js" type="text/javascript"></script>

</head>
<body onkeydown="if(event.keyCode==13){event.keyCode = 9;event.returnValue = false;document.getElementById('search').click();}">

    <script type="text/javascript">
    function getForm()
    {
        var form = new js_webFormForModel_Forms('Operator/AddOperator.aspx','OperForm','添加用户','',{width:620,height:300});
        form.initforms(); 
        form.remethod =  function(){
              $get('lk').click();
        }
    }
    
    function EditForm(operid)
    {
        var form = new js_webFormForModel_Forms('Operator/UpdateOperator.aspx?operid=' + operid, 'OperForm', '修改用户', '', { width: 620, height: 300 });
       form.initforms(); 
       form.remethod =  function(){
            $get('lk').click(); 
            }
   }


   function SetPosition(operid) {

       var form = new js_webFormForModel_Forms('Operator/AddPostion.aspx?operid=' + operid, 'SetForm', '职位分配', '', { width: 520, height: 400 });
       form.initforms();
       form.remethod = function() {
           $get('lk').click();
       }
   }
    
    function over(obj) {
            obj.firstChild.firstChild.childNodes[0].className = 'tool_over_left';
            obj.firstChild.firstChild.childNodes[1].className = 'tool_over_center';
            obj.firstChild.firstChild.childNodes[2].className = 'tool_over_right';
    }
    function out(obj) {
        obj.firstChild.firstChild.childNodes[0].className = '';
        obj.firstChild.firstChild.childNodes[1].className = '';
        obj.firstChild.firstChild.childNodes[2].className = '';
    }
    </script>

    <script language="javascript" type="text/javascript">
        function CheckAllSelect()
		{
			var iRowCount=<%=gv_oper.Rows.Count%>;
			
			var isCheckked;
			
			isCheckked = document.all.chkAllSelect.checked;
			
			for(i= 1;i<=iRowCount;i++ )
			{
				if(typeof(document.all.gv_oper.rows(i).cells(0).children(0)) == "object")
               	{        
                                                                   
					document.all.gv_oper.rows(i).cells(0).children(0).checked = isCheckked;			
				}
				
				if(isCheckked)
				{
				 document.all.gv_oper.rows(i).className = "RowStyleChecked";           
				}
				else
				{
				  document.all.gv_oper.rows(i).className = "RowStyleOut";
				}
			}
			
		}
    </script>

    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" class="style1">
                <%--<tr>
                    <td style="background-image: url('../Images/gridheadbg.jpg')">
                        <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 24px; height: 24px; background-image: url('../../Images/headerleft.gif');">
                                    </td>
                                    <td style="width: 100px; height: 24px; background-image: url('../../Images/headercenter.gif');
                                        background-repeat: repeat-x">
                                        <span class="header">&nbsp;用户维护</span>
                                    </td>
                                    <td style="width: 10px; height: 24px; background-image: url('../../Images/headerright.gif');">
                                    </td>
                                </tr>
                            </table>
                    </td>
                </tr>--%>
                <tr>
                    <td style="background-image: url('../Images/searchbg.jpg')" height="25px" align="left">
                        <table class="search">
                            <tr>
                                <td width="60px" align="right">
                                    姓 名：
                                </td>
                                <td width="120px" align="left">
                                    <asp:TextBox ID="txt_username" runat="server" CssClass="textbox_focus"></asp:TextBox>
                                </td>
                                <td width="80px" align="right">
                                    职位名称：
                                </td>
                                <td width="150px" align="left">
                                    <asp:DropDownList ID="ddl_position" runat="server"  Width="157px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:ImageButton runat="server" ID="search" ImageUrl="../Images/search.jpg" OnClick="search_Click" />
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
                    <td style="background-image: url('../Images/searchline.jpg'); height: 3px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 23px; background-image: url('../Images/form/bg.gif'); border: 1px solid #99bbe8;">
                        <table cellpadding="0" cellspacing="0" border="0" width="480px">
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
                                                               <asp:LinkButton ID="lkAdd" runat="server" onclick="lkAdd_Click">添 加</asp:LinkButton>
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
                                                                <asp:LinkButton ID="lkUpdate" runat="server" OnClientClick="return GridSelect('gv_oper', 'one', 'hdKey','')"
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
                                                                <img src="../Images/icons/edit.png" />
                                                            </td>
                                                            <td>
                                                                <asp:LinkButton ID="lbsetpwd"  runat="server" OnClientClick="return GridSelect('gv_oper', 'more', 'hdKey','')" OnClick="lbsetpwd_Click"><font color="black">重置密码</font></asp:LinkButton>
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
                                <td style="width: 85px;" align="center">
                                    <div>
                                        <table cellpadding="0" cellspacing="0" border="0" onmouseover="over(this);" onmouseout="out(this);">
                                            <tr>
                                                <td style="width: 3px; height: 21px;">
                                                </td>
                                                <td style="vertical-align: middle; text-align: center; padding: 0 5px; cursor: pointer;
                                                    white-space: nowrap;">
                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                        <tr>
                                                            <td><img src="../Images/icons/edit.png" /></td>
                                                            <td>
                                                                <asp:LinkButton ID="lnbtnSetPosition" runat="server" OnClick="lnbtnSetPosition_Click" 
                                                                    OnClientClick="return GridSelect('gv_oper', 'one', 'hdKey','')">职位分配</asp:LinkButton>
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
                                    <div>
                                        <table border="0" cellpadding="0" cellspacing="0" onmouseout="out(this);" onmouseover="over(this);">
                                            <tr>
                                                <td style="width: 3px; height: 21px;">
                                                </td>
                                                <td style="vertical-align: middle; text-align: center; padding: 0 5px; cursor: pointer;
                                                    white-space: nowrap;">
                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td><img src="../Images/icons/delete.png"/></td>
                                                            <td>
                                                                <asp:LinkButton ID="lkForbid" runat="server" OnClick="lkForbid_Click" 
                                                                    OnClientClick="return GridSelect('gv_oper', 'more', 'hdKey','')">禁 用</asp:LinkButton>
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
                                                            <td><img src="../Images/icons/hotelmanage.png" alt="" /></td>
                                                            <td>
                                                                <asp:LinkButton ID="lkStart" runat="server" OnClick="lkStart_Click" 
                                                                    OnClientClick="return GridSelect('gv_oper', 'more', 'hdKey','')">启 用</asp:LinkButton>
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
                    <td>
                        <asp:GridView ID="gv_oper" runat="server" AutoGenerateColumns="False" DataKeyNames="UserCode"
                            Width="100%" OnRowDataBound="gv_oper_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="&lt;input type= checkbox id=chkAllSelect title=全选/全消 onClick=CheckAllSelect();&gt;">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkBoxSelect" runat="server" />
                                        <asp:HiddenField ID="hf_operid" runat="server" Value='<%# Eval("UserCode") %>' />
                                        <asp:HiddenField ID="hdIsForbid" runat="server" Value='<%# Eval("IsForbid") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Width="30px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="UserName" HeaderText="姓名">
                                    <ItemStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MobileNo" HeaderText="手机号">
                                    <ItemStyle Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="OrgName" HeaderText="所属部门"></asp:BoundField>
                                <asp:TemplateField HeaderText="职位">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" 
                                            Text='<%# GetPositonByUc(Eval("UserCode").ToString()) %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="250px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="状态">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIsForbid" runat="server" 
                                            Text='<%# GetStatus(Eval("IsForbid").ToString()) %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="50px" />
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <div align="center">
                                    <b>无数据...</b></div>
                            </EmptyDataTemplate>
                            <HeaderStyle CssClass="GridViewHead" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="page">
                        <webdiyer:AspNetPager ID="anp_oper" runat="server" AlwaysShow="True" ShowCustomInfoSection="Left"
                            FirstPageText="第一页" HorizontalAlign="Left" LastPageText="最后一页" NextPageText="下一页"
                            PrevPageText="上一页" OnPageChanging="anp_oper_PageChanging" PageSize="15">
                        </webdiyer:AspNetPager>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;<asp:HiddenField ID="hf_where" runat="server" />
                        <asp:LinkButton ID="lk" runat="server" OnClick="lk_Click"></asp:LinkButton>
                        <asp:HiddenField ID="hdKey" runat="server" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
