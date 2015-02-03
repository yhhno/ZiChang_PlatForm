<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DictionaryList.aspx.cs" Inherits="Dictionary_DictionaryList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script language="javascript" src="../Myjs/winModel.js" type="text/javascript"></script>

    <script language="javascript" src="../Myjs/drag.js" type="text/javascript"></script>

    <script language="javascript" src="../Myjs/createHTML.js" type="text/javascript"></script>

    <script language="javascript" src="../Myjs/js_webFormForModel.js" type="text/javascript"></script>

    <script language="javascript" src="../Myjs/GridViewSet.js" type="text/javascript"></script>


    <script language="javascript" type="text/javascript">
        //表头CheckBox的选中
        function CheckBoxAll(obj) {
            var es = document.getElementsByTagName("input");
            var j = 1;
            var trArr = $get('gdv_Dic');
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

        //行CheckBox的选中
        function RowCheck(obj) {
            var b = obj.parentNode.parentNode;
            if (obj.checked) {
                b.className = 'RowStyleChecked';
            }
            else {
                b.className = 'RowStyle';
            }
        }

        //单击行时设置CheckBox
        function RowClick(obj) {
            var chk = obj.cells[0].children[0];
            if (obj.className == 'RowStyleChecked') {
                chk.checked = false;
                obj.className = 'RowStyle';
            }
            else {
                chk.checked = true;
                obj.className = 'RowStyleChecked';
            }

        }

        function CheckBoxSingle(obj) {
            var es = document.getElementsByTagName("input");
            for (var i = 0; i < es.length; i++) {
                if (es[i].type == "checkbox") {
                    if (es[i] != obj)
                        es[i].checked = false;
                }
            }
            
        }

    </script>

    <style type="text/css">
        .style1
        {
            width: 86px;
        }
    </style>

</head>
<body>

    <script language="javascript" type="text/javascript">
    
     function DelSelect()
		{
			var iRowCount=<%=gdv_Dic.Rows.Count%>;
			var iselCount=0;
			var isCheckked;
			
			isCheckked = document.all.cbxAll.checked;
			
			for(i= 1;i<=iRowCount;i++ )
			{
				if(typeof(document.all.gdv_Org.rows(i).cells(0).children(0)) == "object")
               	{                                                                       
					if(document.all.gdv_Org.rows(i).cells(0).children(0).checked)
					{
					  iselCount = iselCount+1;
					}			
				}
			}
			
			if(iselCount>0)
			{
			
			   return confirm("确定要删除所选的行？");
			  
			}
			else
			{
			  alert("请选择要删除的行!");
			  return false;
			}
			
		}
        
        function AddFrom(orgID) {
            var form = new js_webFormForModel_Forms('Dictionary/DictionaryAdd.aspx?typeid=' + orgID, 'OperForm', '新增字典', '', { width: 450, height: 200 });
            form.initforms();
            form.remethod = function() {document.getElementById("Button1").click();
               //$get('lk').click();
            }
        }
        
      function EditFrom(did,tid) {
            var form = new js_webFormForModel_Forms('Dictionary/DictionaryAdd.aspx?did='+did + '&tid=' + tid, 'OperForm', '修改字典', '', { width: 450, height: 200 });
            form.initforms();
            form.remethod = function() {document.getElementById("Button1").click();
               //$get('lk').click();
            }
        }
        
        function Role(ID) {
            var form = new js_webFormForModel_Forms('Position/RoleRight.aspx?PositonID=' + ID, 'OperForm', '设置权限', '', { width: 500, height: 510 });
            form.initforms();
            form.remethod = function() {
               //$get('lk').click();
            }
        }
    </script>

    <form id="formOrg" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <asp:HiddenField ID="hd" runat="server" />
            <div>
                <table cellpadding="0" cellspacing="0" style="width: 100%" border="0">
                    <tr>
                        <td style="background-color: #F4F8FD;" valign="top" class="style1">
                            <div style="overflow: auto; width: 191px;">
                                <asp:TreeView ID="tvDictionaryType" runat="server" OnSelectedNodeChanged="tvDepart_SelectedNodeChanged"
                                    ShowLines="True" Width="158px">
                                    <SelectedNodeStyle BackColor="#B8CFEE" />
                                    <%--  <HoverNodeStyle BackColor="#EEEEEE" ForeColor="#FF0066" />--%><RootNodeStyle 
                                        ImageUrl="~/Images/topbg3_03.gif" />
                                    <NodeStyle ImageUrl="~/Images/application.png" />
                                </asp:TreeView>
                            </div>
                        </td>
                        <td style="width: 75%;" align="left" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                <tr>
                                    <td style="background-image: url('../Images/navbg.jpg')">
                                        <table border="0" cellpadding="0" cellspacing="0" width="250px">
                                            <tr>
                                                <td align="center" style="width: 60px;">
                                                    <div>
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
                                                                                <img alt="" src="../Images/icons/add.png" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:LinkButton ID="lkAdd" runat="server" OnClick="lkAdd_Click"><font 
                                                                                    color="black">添加</font></asp:LinkButton>
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
                                                <td align="center" style="width: 60px;">
                                                    <div>
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
                                                                                <img alt="" src="../Images/icons/edit.png" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:LinkButton ID="lkUpdate" runat="server" OnClick="lkUpdate_Click"><font 
                                                                                    color="black">修改</font></asp:LinkButton>
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
                                                <td align="center" style="width: 60px;">
                                                    <div>
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
                                                                                <asp:LinkButton ID="lnkbtnForbid" runat="server" OnClick="lnkbtnForbid_Click" 
                                                                                    
                                                                                    
                                                                                    OnClientClick="return GridSelect('gdv_Dic', 'more', 'hdKey','您确定要禁用选定的记录吗？')"><font 
                                                                                    color="black">禁用</font></asp:LinkButton>
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
                                                <td align="center" style="width: 60px;">
                                                    <div>
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
                                                                                <asp:LinkButton ID="lkDelete" runat="server" OnClick="lkDelete_Click" 
                                                                                    
                                                                                    OnClientClick="return GridSelect('gdv_Dic', 'more', 'hdKey','您确定要启用选定的记录吗？')"><font 
                                                                                    color="black">启用</font></asp:LinkButton>
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
                                        <asp:GridView ID="gdv_Dic" runat="server" DataKeyNames="businID,businTypeID" AutoGenerateColumns="False"
                                            Width="100%" BorderStyle="None" OnRowDataBound="gdv_Org_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField HeaderText="<input id='cbxAll' type='checkbox' onclick='CheckBoxAll(this);' />">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="cbx" runat="server" />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="30px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="businName" HeaderText="名称" />
                                                <asp:BoundField DataField="typeName" HeaderText="类型" />
                                                <asp:TemplateField HeaderText="是否禁用">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblstatus" runat="server" Text='<%# Bind("status") %>'></asp:Label>
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
                                        <webdiyer:AspNetPager ID="anp_Dic" runat="server" AlwaysShow="true" 
                                            FirstPageText="第一页" HorizontalAlign="Left" LastPageText="最后一页" 
                                            NextPageText="下一页" OnPageChanging="anp_Org_PageChanging" PageSize="15" 
                                            PrevPageText="上一页" ShowCustomInfoSection="Left">
                                        </webdiyer:AspNetPager>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            
            <asp:HiddenField ID="hdKey" runat="server" />
            <asp:LinkButton ID="lk" runat="server" OnClick="lk_Click"></asp:LinkButton>
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" Height="0px"
                Width="0px" />
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
