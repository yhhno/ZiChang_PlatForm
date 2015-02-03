<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListLeaveword.aspx.cs" Inherits="Leaveword_ListLeaveword" %>

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
        .style2
        {
            width: 66px;
        }
        .style3
        {
            width: 143px;
        }
    </style>

    <script language="javascript" src="../Myjs/winModel.js" type="text/javascript"></script>

    <script language="javascript" src="../Myjs/drag.js" type="text/javascript"></script>

    <script language="javascript" src="../Myjs/createHTML.js" type="text/javascript"></script>

    <script language="javascript" src="../Myjs/js_webFormForModel.js" type="text/javascript"></script>

    <script type="text/javascript">
        function getForm() {
            var form = new js_webFormForModel_Forms('../Leaveword/AddLeaveword.aspx', 'OperForm', '添加留言', '', { width: 520, height: 300 });
            form.initforms();
            form.remethod = function() {
                //alert('OK');  
                // document.href="http://www.sohu.com";
                Operator_OperatorList.b();
                // window.location.reload();
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

</head>
<body onkeydown="if(event.keyCode==13){ document.getElementById('search').click();}">

    <script language="javascript" type="text/javascript">
        function CheckAllSelect()
		{
			var iRowCount=<%=gv_leavel.Rows.Count%>;
			
			var isCheckked;
			
			isCheckked = document.all.chkAllSelect.checked;
			
			for(i= 1;i<=iRowCount;i++ )
			{
				if(typeof(document.all.gv_leavel.rows(i).cells(0).children(0)) == "object")
               	{        
                                                                   
					document.all.gv_leavel.rows(i).cells(0).children(0).checked = isCheckked;			
				}
				
				if(isCheckked)
				{
				 document.all.gv_leavel.rows(i).className = "RowStyleChecked";           
				}
				else
				{
				  document.all.gv_leavel.rows(i).className = "RowStyleOut";
				}
			}
			
		}
		function DelSelect()
		{
			var iRowCount=<%=gv_leavel.Rows.Count%>;
			var iselCount=0;
			var isCheckked;
			
			isCheckked = document.all.chkAllSelect.checked;
			
			for(i= 1;i<=iRowCount;i++ )
			{
				if(typeof(document.all.gv_leavel.rows(i).cells(0).children(0)) == "object")
               	{                                                                       
					if(document.all.gv_leavel.rows(i).cells(0).children(0).checked)
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
		
		function UpdateSelect()
		{
			var iRowCount=<%=gv_leavel.Rows.Count%>;
			var iselCount=0;
			var isCheckked;
			
			isCheckked = document.all.chkAllSelect.checked;
			var operid="";
			for(i= 1;i<=iRowCount;i++ )
			{
				if(typeof(document.all.gv_leavel.rows(i).cells(0).children(0)) == "object")
               	{                                                                       
					if(document.all.gv_leavel.rows(i).cells(0).children(0).checked)
					{
					  iselCount = iselCount+1;
					  operid=document.all.gv_leavel.rows(i).cells(0).children(1).value;
					}			
				}
			}
			
			if(iselCount>0)
			{
			
			   if(iselCount == 1)
			   {
			       var form = new js_webFormForModel_Forms('../Leaveword/AddLeaveword.aspx?operid='+operid,'OperForm','修改用户','',{width:520,height:300});
                   form.initforms(); 
                   form.remethod =  function(){
                   //window.location.reload();
                     
                      //Operator_OperatorList.b();
                    }
                    
			   }
			   else
			   {
			       alert("只能选取一行记录进行修改!");
			        return false;
			   }
			  
			}
			else
			{
			  alert("请选择要修改的行!");
			  return false;
			}
			
		}
		
		function UpdateSelectpwd()
		{
			var iRowCount=<%=gv_leavel.Rows.Count%>;
			var iselCount=0;
			var isCheckked;
			
			isCheckked = document.all.chkAllSelect.checked;
			var operid="";
			for(i= 1;i<=iRowCount;i++ )
			{
				if(typeof(document.all.gv_leavel.rows(i).cells(0).children(0)) == "object")
               	{                                                                       
					if(document.all.gv_leavel.rows(i).cells(0).children(0).checked)
					{
					  iselCount = iselCount+1;
					  operid=document.all.gv_leavel.rows(i).cells(0).children(1).value;
					}			
				}
			}
			
			if(iselCount>0)
			{
			
			   if(iselCount == 1)
			   {
			       var form = new js_webFormForModel_Forms('Operator/Updatepwd.aspx?operid='+operid,'updatepwdForm','修改用户密码','',{width:400,height:150});
                   form.initforms(); 
                   form.remethod =  function(){
                      //alert('OK');  
                    }
                    
			   }
			   else
			   {
			       alert("只能选取一行记录进行修改!");
			        return false;
			   }
			  
			}
			else
			{
			  alert("请选择要修改的行!");
			  return false;
			}
			
		}
		
		  //单击行时设置CheckBox
        function RowClick(obj) {
            var chk = obj.cells[0].children[0];
            if (obj.className == 'RowStyleChecked') {
                obj.className = 'RowStyle';
                chk.checked = false;
            }
            else {
                obj.className = 'RowStyleChecked';
                chk.checked = true;
            }
            
        }
    </script>

    <form id="form1" runat="server">
    <div>
    </div>
    <table cellpadding="0" cellspacing="0" class="style1">
        <tr>
            <td style="background-image: url('../Images/gridheadbg.jpg')">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <img src="../Images/tabtitle.jpg" alt="" />
            </td>
        </tr>
        <tr>
            <td style="background-image: url('../Images/searchbg.jpg')" height="25px">
                <table class="search">
                    <tr>
                        <td width="100px" align="center">
                            留言标题：
                        </td>
                        <td width="120px">
                            <asp:TextBox ID="txt_title" runat="server"></asp:TextBox>
                        </td>
                        <td class="style2">
                            &nbsp;
                        </td>
                        <td class="style3">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td width="100px" align="center">
                            开始时间：
                        </td>
                        <td width="120px">
                            <asp:TextBox ID="TbStarttime" runat="server"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TbStarttime"
                                Format="yyyy-MM-dd">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                        <td class="style2">
                            结束时间：
                        </td>
                        <td class="style3">
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TBendtime"
                                Format="yyyy-MM-dd">
                            </ajaxToolkit:CalendarExtender>
                            <asp:TextBox ID="TBendtime" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:ImageButton runat="server" ID="search" ImageUrl="../Images/search.jpg" OnClick="search_Click" />
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
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td style="width: 60px;" align="center">
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
                                                    <td onclick="getForm()">
                                                        添加
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
                        <td style="width: 60px;" align="center">
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
                                                    <td onclick="UpdateSelect()">
                                                        查看
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
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gv_leavel" runat="server" AutoGenerateColumns="False" DataKeyNames="operatorID"
                    Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="&lt;input type= checkbox id=chkAllSelect title=全选/全消 onClick=CheckAllSelect();&gt;">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkBoxSelect" runat="server" />
                                <asp:HiddenField ID="hf_operid" runat="server" Value='<%# Eval("leaveID") %>' />
                            </ItemTemplate>
                            <HeaderStyle Width="10px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="LEAVEtitle" HeaderText="留言标题">
                            <HeaderStyle Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="LEAVEdate" HeaderText="留言时间">
                            <HeaderStyle Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ReceiveID" HeaderText="接收人">
                            <HeaderStyle Width="200px" />
                        </asp:BoundField>
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
                <webdiyer:AspNetPager ID="anp_leavel" runat="server" AlwaysShow="True" ShowCustomInfoSection="Left"
                    FirstPageText="第一页" HorizontalAlign="Left" LastPageText="最后一页" NextPageText="下一页"
                    PrevPageText="上一页">
                </webdiyer:AspNetPager>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;<asp:HiddenField ID="hf_where" runat="server" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
