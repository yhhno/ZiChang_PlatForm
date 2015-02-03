<%@ Page Language="C#" AutoEventWireup="true" CodeFile="main.aspx.cs" Inherits="main" Theme="Default"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="CSS/Main.css" rel="stylesheet" type="text/css" />
     <script src="Myjs/js_setShortcut.js" type="text/javascript"></script>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style4
        {
            width: 90px;
        }
        </style>
    
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    
    </div>
<table cellpadding="0" cellspacing="0" class="style1">
   <tr>
        <td style="background-image:url('Images/gridheadbg.jpg')">
           <img src="Images/tabtitle.jpg" alt=""/></td>
    </tr>
    <tr>
        <td style="background-image:url('Images/searchbg.jpg')" height="25px">
            <table class="search">
                <tr>
                    <td width="100px" align="center">
                        用户名：</td>
                    <td width="120px">
                        <input id="Text1" type="text" class="searchinput"/></td>
                    <td>
                        <img src="Images/search.jpg" alt=""/></td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </td>
    </tr>
     <tr>
        <td style="background-image:url('Images/searchline.jpg');height:3px">
         </td>
    </tr>
    
    <tr>
        <td style="background-image:url('Images/navbg.jpg')">
       <table>
                <tr>
                    <td>
                        <img alt="" src="Images/button/add.jpg" /></td>
                    <td>
                       <img alt="" src="Images/button/sp.jpg" /></td>
                    <td>
                        <img alt="" src="Images/button/update.jpg" /></td>
                    <td>
                        <img alt="" src="Images/button/sp.jpg" /></td>
                    <td>
                        <img alt="" src="Images/button/delete.jpg" /></td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
          </td>
    </tr>
     
    
    <tr>
        <td>
           
        <table width="100%" border="1">
            <tr style="background-image:url('../Images/gridbg.jpg')">
                <td style="background-image:url('Images/gridbg.jpg')">
                    </td>
                <td style="background-image:url('Images/gridbg.jpg')">
                    用户名</td>
                <td style="background-image:url('Images/gridbg.jpg')">
                    性别</td>
                <td style="background-image:url('Images/gridbg.jpg')">
                    地址</td>
                <td style="background-image:url('Images/gridbg.jpg')">
                    邮箱</td>
                <td style="background-image:url('Images/gridbg.jpg')">
                    联系电话</td>
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
            </td>
    </tr>
    <tr><td class="page">ww</td>
    </tr>
    <tr><td>fdsa
         
           
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
         
           
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server">
        </webdiyer:AspNetPager>
         
           
    </td></tr>
</table>
    </form>
</body>
</html>
