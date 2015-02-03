<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HomePage.aspx.cs" Inherits="HomePage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>信息显示页面</title>

    <script src="Ext/adapter/ext/ext-base.js" type="text/javascript"></script>

    <script src="Ext/ext-all-debug.js" type="text/javascript"></script>
    <style type="text/css">
       .functionGroup
        {
            padding-left: 20px;
            padding-top: 10px;
            font-size: 12pt;
            font-family: 幼圆;
        }
    </style>
    <script type="text/javascript" language="javascript">
        function AddTabPanel(param)
        {
            var title = param.split(',')[0];    //<-- title
            var url = param.split(',')[1];      //<-- url
            
            var tabObject = window.parent.center.find('title', title);  //   <--find tabpanel items from window.parent.center

            if (tabObject.length == 0)      //  <-- not exist
            {
                /*
                *center = window.parent.center
                */
                window.parent.center.add({
                    title: title,
                    //iconCls: node.attributes.iconCls, //从数据库取图标
                    html: "<iframe src='" + url + "'scrolling='yes' frameborder=0 width=100% height=100%></iframe>",
                    closable: true
                }).show();
            }
            else
            {
                window.parent.center.setActiveTab(tabObject[0]);
            }
        }
    </script>
</head>
<body style="margin-top: 0px">
    <form id="form1" runat="server">
    <br /> 
    <%--PicturePath--%>
        <asp:GridView ID="grvContainer" runat="server" EnableTheming="False" 
            DataKeyNames="FunCode"  ShowHeader="False" SkinID="myskin" 
            AutoGenerateColumns="False" BorderStyle="None" BorderColor="Transparent" 
            GridLines="None" onrowdatabound="grvContainer_RowDataBound">
           
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                    <div style="padding-left:20px;">
                    <p class="functionGroup"><%#Eval("FunName") %></p>
                        <asp:DataList ID="dtlContainer" runat="server" RepeatDirection="Horizontal" 
                            ShowFooter="False" ShowHeader="False" RepeatColumns="5"
                            onitemdatabound="dtlContainer_ItemDataBound" DataKeyField="DataKey">
                            <ItemTemplate>
                                <div  style="cursor:pointer;"  style="text-align:center; vertical-align:middle; padding-left:5px; padding-bottom:8px; width:145px;">
                                    <a name='<%# Eval("DataKey")%>' onclick="AddTabPanel(this.name);" style="hover:hand;">
                                        <img src='<%#Eval("ModulePicture") %>'  style="width:60px; height:60px;border-top: none; border-left: none; border-right: none; border-bottom: none;"/></a><br />
                                    <a name='<%# Eval("DataKey") %>' onclick="AddTabPanel(this.name);" style="hover:hand;" ><%#Eval("FunName") %></a>
                                </div>
                            </ItemTemplate>
                        </asp:DataList>
                     </div>
                     <hr style="color:White;" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
