<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddPostion.aspx.cs" Inherits="Operator_AddPostion" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script language="javascript" src="../Myjs/winModel.js" type="text/javascript"></script>
    <script language="javascript" src="../Myjs/drag.js" type="text/javascript"></script>
    <script language="javascript" src="../Myjs/createHTML.js" type="text/javascript"></script>
    <script language="javascript" src="../Myjs/js_webFormForModel.js" type="text/javascript"></script>
    
    <script type="text/javascript" language="javascript">
        function OrganizationAdd() {
            var formAdd = new js_webFormForModel_Forms('Organization/OrganizationAdd.aspx', 'formAdd', '添加部门', '', { width: 540, height: 390 }); 
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

        
        
        //获取CheckBox选中的行
        function GridSelect(tablename, type, valname) {
            //先判断该表的名称是否存在
            if (document.getElementById(tablename) == null) {
                return false;
            }
            var count = 0;
            var tableObj = document.getElementById(tablename);
            var hd = document.getElementById(valname);
            hd.value = "";
            for (var i = 1; i < tableObj.rows.length; i++) {
                var chk = tableObj.rows[i].cells[0].children[0];
                if (chk != null) {
                    if (chk.checked == true) {
                        count++;
                        hd.value = hd.value + (i - 1) + ",";
                    }
                }
            }
            if (count == 0) {
                alert("请选择您要操作的记录!");
                hd.value = "";
                return false;
            }
            else {
                if (type == "one") {
                    if (count > 1) {
                        alert("请选择一条您要操作的记录，不可选择多条!");
                        return false;
                    }
                    else {
                        hd.value = hd.value.substr(0, hd.value.length - 1);
                        return true;
                    }
                }
                else if (type == "more") {
                    hd.value = hd.value.substr(0, hd.value.length - 1);
                    return window.confirm('删除时，该组织下的下级组织及职位均被删除，您确定要删除选吗？');
                }
                else if (type == "") {
                    hd.value = hd.value.substr(0, hd.value.length - 1);
                    return true;
                }
            }
        } 
        	

    </script>

</head>
<body style="background-color:#C7D6E9" onkeydown="if(event.keyCode==13){event.keyCode = 9;event.returnValue = false;document.getElementById('ib_save').click();}">

  <script language="javascript" type="text/javascript">
     function DelSelect()
		{
			var iRowCount=<%=gdv_Org.Rows.Count%>;
			var iselCount=0;
			var isCheckked;
			
			isCheckked = document.all.chkAllSelect.checked;
			
			for(i= 1;i<=iRowCount;i++ )
			{
				if(typeof(document.all.gv1.rows(i).cells(0).children(0)) == "object")
               	{                                                                       
					if(document.all.gv1.rows(i).cells(0).children(0).checked)
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
		
		function CanveSelect()
		{
			 var es = document.getElementsByTagName("input");
            for (var i = 0; i < es.length; i++) {
                if (es[i].type == "checkbox") {
                        es[i].checked = false;
                }
            }
			
		}
		
        
        function AddFrom(orgID) {
            var form = new js_webFormForModel_Forms('Position/DataEdit.aspx?orgid=' + orgID, 'OperForm', '新增职位', '', { width: 540, height: 370 });
            form.initforms();
            form.remethod = function() {document.getElementById("Button1").click();
               //$get('lk').click();
            }
        }
        
      function EditFrom(strname) {
            var form = new js_webFormForModel_Forms('Position/DataEdit.aspx?PositonID='+strname, 'OperForm', '修改职位', '', { width: 540, height: 370 });
            form.initforms();
            form.remethod = function() {document.getElementById("Button1").click();
               //$get('lk').click();
            }
        }
        
        function Role(ID) {
            var form = new js_webFormForModel_Forms('Position/RoleRight.aspx?PositonID=' + ID, 'OperForm', '设置权限', '', { width: 500, height: 530 });
            form.initforms();
            form.remethod = function() {
               //$get('lk').click();
            }
        }
  </script>
    <form id="formOrg" runat="server"><asp:ScriptManager ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <table cellpadding="0" cellspacing="0" style="width: 100%" border="0">
                    <tr>
                        <td style="height: 20px;" valign="top">
                            
                            <asp:GridView ID="gdv_Org" runat="server" AutoGenerateColumns="False" 
                                BorderStyle="None" DataKeyNames="PositionCode" 
                                onrowdatabound="gdv_Org_RowDataBound" Width="100%">
                                <Columns>
                                    <asp:TemplateField HeaderText="&lt;input id='cbxAll' type='checkbox' onclick='CheckBoxAll(this);' /&gt;">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkBoxSelect" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle Width="30px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="PositionCode" HeaderText="职位编号" />
                                    <asp:BoundField DataField="PositionName" HeaderText="职位名称" />
                                   
                                    
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                   <tr>
                    <td>
                       
                        <webdiyer:AspNetPager ID="anp_Org" runat="server" PageSize="1000">
                        </webdiyer:AspNetPager>
                       
                    </td>
                   </tr>
                </table>
            </div>
            <asp:HiddenField ID="hdKey" runat="server" />
             <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" Height="0px"  Width="0px"/>
          
            <div align="center"><asp:ImageButton ID="ib_save" runat="server" ImageUrl="~/Images/baocun.gif" 
                onclick="ib_save_Click" />
            &nbsp;
            <asp:ImageButton ID="ib_cav" runat="server" ImageUrl="~/Images/chongzhi.gif" 
                 CausesValidation="False" onclick="ib_cav_Click"/>&nbsp;
                <asp:ImageButton ID="btnCancel" runat="server" ImageUrl="~/Images/close.gif" 
                    OnClick="btnCancel_Click" ValidationGroup="gr" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel> 

    </form>
</body>
</html>
