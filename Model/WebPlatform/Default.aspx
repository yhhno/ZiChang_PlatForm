<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>行业主管平台主界面</title>
   <script language="javascript" type="text/javascript">
       function setTitleAndUrl(val, url) {
           var doc = window.parent.document;
           doc.getElementById('trHeader').style.display = 'block';
           doc.getElementById("spanTitle").innerHTML = val;
           doc.mainIframe.location = url;
       }
       function Init() {
           var url = window.parent.location.href;
           var iLen = url.length;
           document.getElementById('hdSys').value = url.substring(iLen - 5);
       }
  </script>
    <style type="text/css">
        #ifmChat
        {
            height: 300px;
        }
    </style>
</head>
<body style="margin:5px">
    <form id="form1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" border="0" style="width:100%">
            <tr>
                <td style="width:100%" align="left">
                    <table>
                    <tr>
                        <td><img src="images/default/ico.png" /></td>
                        <td><div style="font-size:13px;color:#3356B4;font-family:微软雅黑;"><b>&nbsp;&nbsp;查&nbsp;&nbsp;询</b></div></td>
                    </tr>
                    </table>
                    
                </td>
            </tr>
            <tr>
                <td style="width:100%">
                    <!--放置查询按钮-->
                    <table>
                    <%=strHtml %>
                        <%--<tr>
                            <td style="width:150px" align="center">
                               <a href="#"><img src="Images/Default/s002.png" /> </a>
                            </td>
                            <td  style="width:150px" align="center">
                                <a href="#"><img src="Images/Default/s001.png" /></a>
                            </td>
                            <td  style="width:150px" align="center">
                                <a href="#"><img src="Images/Default/s003.png"/></a>
                            </td>
                            <td  style="width:150px" align="center">
                                <a href="#"><img src="Images/Default/s004.png"/></a>
                            </td>
                            <td  style="width:150px" align="center">
                                <a href="#"><img src="Images/Default/s005.png"/></a>
                            </td>
                        </tr>
                        <tr>
                            <td  style="width:150px" align="center">
                                <a href="#">人员查询</a>
                            </td>
                            <td  style="width:150px" align="center">
                               <a href="#">过磅记录实时查询</a>
                            </td>
                            <td style="width:150px" align="center">
                                煤矿余额实时查询
                            </td>
                            <td style="width:150px" align="center">
                                税费分配统计
                            </td>
                            <td style="width:150px" align="center">
                                违规记录查询
                            </td>
                        </tr>--%>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="height:10px"></td>
            </tr>
            <tr>
                <td style="width:100%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td width="34"><img src="images/default/table_top_left.png" width="34" height="30"></td>
                        <td background="images/default/table_top_center.png" valign="middle">
                            <div style="font-size:12px;color:#3356B4;font-family:微软雅黑;">
                                <b>&nbsp;&nbsp;柱状图标</b></div>
                          </td>
                        <td width="12"><img src="images/default/table_top_right.png" width="12" height="30"></td>
                      </tr>
                      <tr>
                        <td background="images/default/table_center_left.png">&nbsp;</td>
                        <td><div align="center">
                        <iframe id="ifmChat" width="650" src="Chart/CollChartMap.aspx" marginheight=0 
                                marginwidth=0 frameborder=0 scrolling=no></iframe>
                        
                        
                        </div></td>
                        <td background="images/default/table_center_right.png">&nbsp;</td>
                      </tr>
                      <tr>
                        <td><img src="images/default/table_foot_left.png" width="34" height="17"></td>
                        <td background="images/default/table_foot_center.png">&nbsp;</td>
                        <td background="images/default/table_foot_right.png">&nbsp;</td>
                      </tr>
                    </table>
                 </td>
             </tr>
             <tr>
                <td style="height:10px"></td>
             </tr>
             <tr>
                <td>
                     <table width="100%" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td width="49%">
		                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                          <tr>
                                            <td width="34"><img src="images/default/table_top_left.png" width="34" height="30"></td>
                                            <td background="images/default/table_top_center.png" valign="middle">
                                            <div style="font-size:12px;color:#3356B4;font-family:微软雅黑;"><b>&nbsp;&nbsp;通知</b></div></td>
                                            <td width="12"><img src="images/default/table_top_right.png" width="12" height="30"></td>
                                          </tr>
                                          <tr>
                                            <td background="images/default/table_center_left.png">&nbsp;</td>
                                            <td style="height:70px" valign="top">
                                                <div align="center">
                                                <div align="left"> 
                                                    <a>※调运系统上线</a>
                                                    <br />
                                                    <a>※调运系统上线</a>
                                                    <br />
                                                    <a>※调运系统上线</a>
                                                </div>
                                                </div></td>
                                            <td background="images/default/table_center_right.png">&nbsp;</td>
                                          </tr>
                                          <tr>
                                            <td><img src="images/default/table_foot_left.png" width="34" height="17"></td>
                                            <td background="images/default/table_foot_center.png">&nbsp;</td>
                                            <td background="images/default/table_foot_right.png">&nbsp;</td>
                                          </tr>
                                        </table>
					                    </td>
                        <td width="2%">&nbsp;</td>
                        <td width="49%">
		                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td width="34"><img src="images/default/table_top_left.png" width="34" height="30"></td>
                        <td background="images/default/table_top_center.png" valign="middle"><div style="font-size:12px;color:#3356B4;font-family:微软雅黑;"><b>&nbsp;&nbsp;操作指南</b></div></td>
                        <td width="12"><img src="images/default/table_top_right.png" width="12" height="30"></td>
                      </tr>
                      <tr>
                        <td background="images/default/table_center_left.png" >&nbsp;</td>
                        <td style="height:70px;color:#3356B4"  valign="top">
                            <div align="left"> 
                                <asp:LinkButton ID="lkRoom" runat="server" onclick="lkRoom_Click">※计量站操作手册</asp:LinkButton>
                                <br />
                                <asp:LinkButton ID="lkCheck" runat="server" onclick="lkCheck_Click">※验票站操作手册</asp:LinkButton>
                                <br />
                                <asp:LinkButton ID="lkCenter" runat="server" onclick="lkCenter_Click">※中心端操作手册</asp:LinkButton>
                            </div>
                        </td>
                        <td background="images/default/table_center_right.png">&nbsp;</td>
                      </tr>
                      <tr>
                        <td><img src="images/default/table_foot_left.png" width="34" height="17"></td>
                        <td background="images/default/table_foot_center.png">&nbsp;</td>
                        <td background="images/default/table_foot_right.png">&nbsp;</td>
                      </tr>
                    </table>
                    </td>
                  </tr>
                </table>
                </td>
             </tr>
             <tr>
		        <td height="40px" valign="bottom"><div align="center" style="color:#3356B4">
				<div align="center" >
                    北京天大天科科技有限公司 版权所有<br />

				</div>
				<div align="center">Copyright(C) 1999-2010 TDTK All Rights Reserved.
				</div>
			</div>
		</td>
	</tr>
          </table>
        <asp:HiddenField ID="hdSys" runat="server" />
    </div>
    </form>
</body>
</html>
