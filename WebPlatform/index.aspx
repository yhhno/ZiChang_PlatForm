<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>行业主管平台</title>
    <link href="CSS/Main.css" rel="stylesheet" type="text/css" />

    <script src="Myjs/js_setShortcut.js" type="text/javascript"></script>

    <script language="javascript" src="Myjs/winModel.js" type="text/javascript"></script>

    <script language="javascript" src="Myjs/drag.js" type="text/javascript"></script>

    <script language="javascript" src="Myjs/createHTML.js" type="text/javascript"></script>

    <script language="javascript" src="Myjs/js_webFormForModel.js" type="text/javascript"></script>

    <script src="Myjs/jquery-132min.js" type="text/javascript"></script>

    <!--script type="text/javascript" src="Myjs/Silverlight.js"></script-->
    <style type="text/css">
        .ui-sortable
        {
            width: 398px;
            background-color: red;
            margin: 0 1px 1px 0;
            padding: 0 1px 1px;
            cursor: move;
            font-family: 微软雅黑;
        }
        .cbox
        {
            border: 0px solid #D6D6D6;
            float: right;
            width: 60px;
            height: 80px;
        }
        .cbox img
        {
            margin-bottom: 3px;
            vertical-align: middle;
        }
        #img ul
        {
            margin: 0;
            padding: 0;
            list-style: none;
            width: 100000px;
        }
        #img li
        {
            margin: 0;
            padding-top: 0px;
            width: 60px;
            display: block;
            float: left;
        }
        #img_bag
        {
            width: 620px;
            height: 20px;
            margin: 3 auto;
        }
        #img_bag a
        {
            float: left;
            width: 20px;
            display: block;
            height: 20px;
            font-size: 9pt;
            color: #ffffff;
            text-decoration: none;
        }
        #img_bag #img
        {
            width: 480px;
            height: 80px;
            overflow: hidden;
            float: left;
        }
        #scrollBar
        {
            width: 500px;
            height: 20px;
            background: #757f81;
            margin: 0 auto;
            position: relative;
        }
        #scroll
        {
            width: 30px;
            height: 20px;
            cursor: pointer;
            position: absolute;
            background-color: ButtonFace;
        }
        .minus
        {
            background-image: url(../images/green_minus.gif);
        }
        .silverlightcontentcss
        {
            width: 350px;
            height: 300px;
            position: absolute;
            top: 0px;
            left: 0px;
        }
    </style>
    <!--silverlight -->

    <script type="text/javascript">
        function onSilverlightError(sender, args) {
            var appSource = "";
            if (sender != null && sender != 0) {
                appSource = sender.getHost().Source;
            }

            var errorType = args.ErrorType;
            var iErrorCode = args.ErrorCode;

            if (errorType == "ImageError" || errorType == "MediaError") {
                return;
            }

            var errMsg = "Unhandled Error in Silverlight Application " + appSource + "\n";

            errMsg += "Code: " + iErrorCode + "    \n";
            errMsg += "Category: " + errorType + "       \n";
            errMsg += "Message: " + args.ErrorMessage + "     \n";

            if (errorType == "ParserError") {
                errMsg += "File: " + args.xamlFile + "     \n";
                errMsg += "Line: " + args.lineNumber + "     \n";
                errMsg += "Position: " + args.charPosition + "     \n";
            }
            else if (errorType == "RuntimeError") {
                if (args.lineNumber != 0) {
                    errMsg += "Line: " + args.lineNumber + "     \n";
                    errMsg += "Position: " + args.charPosition + "     \n";
                }
                errMsg += "MethodName: " + args.methodName + "     \n";
            }

            throw new Error(errMsg);
        }

        function slcontentDisplayOrHidden() {

            if (silverlightcontent.style.visibility == "hidden")
                silverlightcontent.style.visibility = "visible";
            else
                silverlightcontent.style.visibility = "hidden";
        }
    </script>

    <script type="text/javascript">
        function pageInit() {
            /*document.getElementById("mainIframe").height = window.screen.height - 106 - window.screenTop - 53;
            document.getElementById("index_center_left").style.height = window.screen.height - 128 - window.screenTop - 53;*/
            document.getElementById("trHeader").style.display = 'none';
            resetSize();
            silverlightcontent.style.left = window.screen.width - 350 - 1;
            silverlightcontent.style.top = (window.screen.height - window.screenTop) - 400 - 5;
        }

        function resetSize() {
            document.getElementById("mainIframe").height = window.screen.height - 106 - window.screenTop - 43;
            document.getElementById("index_center_left").style.height = window.screen.height - 128 - window.screenTop - 23;
            document.getElementById("divTree").style.height = window.screen.height - 128 - window.screenTop -52;
        }
        var resizeTimer = null;
        function doResize() {
            resetSize();
        }
        window.onresize = function() { if (resizeTimer) clearTimeout(resizeTimer); resizeTimer = setTimeout("doResize()", 300); }

        function UpdatePwd() {
            var form = new js_webFormForModel_Forms('Updatepwd.aspx', 'UpdateForm', '修改密码', 'model', { width: 400, height: 150 });
            form.initforms();
            form.remethod = function() {

            }
        }
        //隐藏右边面板
        function hideLeftPanel() {
            //$("#center_left").hide("fast");
            document.getElementById("show_div").style.height = document.getElementById("show_panel").offsetHeight;
            $("#center_left").animate({ left: '-=214' }, 200, function() {
                document.getElementById("center_left").style.display = "none";
                $("#show_div").show("slow");
                document.getElementById("show_panel").style.width = "30px";
            });
        }
        //显示右边面板
        function showLeftPanel() {
            //$("#center_left").show("fast");
            $("#show_div").hide("slow", function() {
                document.getElementById("center_left").style.display = "block";
                $("#center_left").animate({ left: '+=214' }, 200);
                document.getElementById("show_panel").style.width = "5px";
            });
        }

        function setTitleAndUrl(val, url) {
            document.getElementById('trHeader').style.display = 'block';
            document.getElementById("spanTitle").innerHTML = val;
            window.mainIframe.location = url;
        }
        
      
    </script>

    <script src="Myjs/js_webForm.js" type="text/javascript"></script>

    <script type="text/javascript">

        function UpdatePwd() {
            var form = new js_webFormForModel_Forms('Updatepwd.aspx', 'UpdateForm', '修改密码', 'model', { width: 400, height: 150 });
            form.initforms();
            form.remethod = function() {

            }
        }

        function TextToSpeech(text) {
            document.getElementById("xam").content.RegManager.Speecher(text.toString());

        }     
        
    </script>

</head>
<body scroll="no" onload="pageInit();initMainFrame();" style="margin: 0; background-color: #d9e7f8;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    
    <div class="silverlightcontentcss" style="z-index: 1000000; visibility: hidden;"
        id="silverlightcontent">
        <table border="0" cellpadding="0" cellspacing="0" class="dragTable" width="100%">
            <tr>
                <td style="background-image: url(Images/desk/skin1/1_03.gif); width: 3px; height: 26px">
                </td>
                <td style="background-image: url(Images/desk/skin1/1_05.gif); height: 26px">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr>
                            <td onmousedown="drag(this.offsetParent.offsetParent.offsetParent.offsetParent,event);"
                                style="cursor: move;">
                                <table cellpadding="0" cellspacing="0" class="dragTable" width="100%">
                                    <tr>
                                        <td style="width: 17px;">
                                            <img src="Images/desk/skin1/sys_config.gif" />
                                        </td>
                                        <td style="color: #000000;">
                                            &nbsp;语言报警
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="width: 18px">
                                <div onmouseover="this.style.backgroundPosition='-15px 0px';" title="关闭" onmouseout="this.style.backgroundPosition='0px 0px';"
                                    style="background: url(Images/desk/skin1/sprites.gif) no-repeat 0px 0px; width: 15px;
                                    height: 15px" onclick="slcontentDisplayOrHidden();">
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="background-image: url(Images/desk/skin1/1_07.gif); width: 5px; height: 26px">
                </td>
            </tr>
            <tr>
                <td style="background-image: url(Images/desk/skin1/1_12.gif)">
                </td>
                <td id="td_content" style="background-image: url(Images/desk/skin1/1_13.gif); height: 300px;"
                    valign="top">
                    <div id="silverlightControlHost">
                        <object id="xam" data="data:application/x-silverlight-2," type="application/x-silverlight-2"
                            width="100%" height="300px">
                            <param name="source" value="ClientBin/TextToSpeech.xap" />
                            <param name="onError" value="onSilverlightError" />
                            <param name="background" value="white" />
                            <param name="minRuntimeVersion" value="3.0.40624.0" />
                            <param name="autoUpgrade" value="true" />
                            <a href="http://go.microsoft.com/fwlink/?LinkID=149156&v=3.0.40624.0" style="text-decoration: none">
                                <img src="http://go.microsoft.com/fwlink/?LinkId=108181" alt="Get Microsoft Silverlight"
                                    style="border-style: none" />
                            </a>
                        </object>
                        <iframe id="_sl_historyFrame" style="visibility: hidden; height: 0px; width: 0px;
                            border: 0px"></iframe>
                    </div>
                </td>
                <td style="background-image: url(Images/desk/skin1/1_14.gif)">
                </td>
            </tr>
            <tr>
                <td style="background-image: url(Images/desk/skin1/1_18.gif); height: 5px">
                </td>
                <td style="background-image: url(Images/desk/skin1/1_19.gif); height: 5px">
                </td>
                <td style="background-image: url(Images/desk/skin1/1_20.gif); height: 5px">
                </td>
            </tr>
        </table>
    </div>
    
    
    
    <div>
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <table cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td style="background-image: url('Images/index_top_left.gif'); width: 127px; height: 82px;">
                            </td>
                            <td style="background-image: url('Images/index_top_center.gif');" valign="top">
                                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                    <tr>
                                        <td style="width: 5px;">
                                        </td>
                                        <td style="width: 181px;">
                                            <img src="Images/index_top_center_pic.gif" />
                                        </td>
                                        <td style="width: 70px;">
                                        </td>
                                        <td valign="top">
                                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                <tr>
                                                    <td>
                                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                            <tr>
                                                                <td style="background-image: url('Images/index_top_right_pic1.gif'); width: 29px;
                                                                    height: 25px;">
                                                                </td>
                                                                <td style="background-image: url('Images/index_top_right_pic2.gif')">
                                                                    &nbsp;
                                                                    <div id="img_bag" style="border-style: none; border-color: inherit; border-width: medium;
                                                                        position: absolute; top: 5px; left: 420px;">
                                                                        <a href="javascript:void(0)" style="padding-top: 0px;" onmousedown="moveLeft()">
                                                                            <img id="move_left" title="左移" src="images/pic_moveleft.gif" style="border: none;"
                                                                                alt="" /></a>
                                                                        <div id="img" style="border: none; vertical-align: middle">
                                                                            <ul id="ul_content" style="height: 32px; border: none; vertical-align: middle;">
                                                                            </ul>
                                                                        </div>
                                                                        <a href="javascript:void(0)" style="padding-top: 0px;" onmousedown="moveRight()">
                                                                            <img id="move_right" title="右移" src="images/pic_moveright.gif" style="border: none;
                                                                                padding-left: 3px;" alt="" /></a>
                                                                    </div>

                                                                    <script type="text/javascript">
                                                                        getShortcut();
                                                                        function moveLeft() {
                                                                            var le = parseInt(document.getElementById("img").scrollLeft);
                                                                            if (le > 200) {
                                                                                targetx = parseInt(document.getElementById("img").scrollLeft) - 200;
                                                                            }
                                                                            else { targetx = parseInt(document.getElementById("img").scrollLeft) - le - 1 }
                                                                            scLeft();
                                                                        }
                                                                        function scLeft() {
                                                                            dx = parseInt(document.getElementById("img").scrollLeft) - targetx;
                                                                            document.getElementById("img").scrollLeft -= dx * .3;

                                                                            clearScroll = setTimeout(scLeft, 50);
                                                                            if (dx * .3 < 1) { clearTimeout(clearScroll) }
                                                                        }
                                                                        function moveRight() {
                                                                            var le = parseInt(document.getElementById("img").scrollLeft) + 200;
                                                                            var maxL = maxWidth - 600;
                                                                            if (le < maxL) {
                                                                                targetx = parseInt(document.getElementById("img").scrollLeft) + 200;
                                                                            }
                                                                            else { targetx = maxL }
                                                                            scRight();
                                                                        }
                                                                        function scRight() {
                                                                            dx = targetx - parseInt(document.getElementById("img").scrollLeft);
                                                                            document.getElementById("img").scrollLeft += dx * .3;

                                                                            a = setTimeout(scRight, 50);
                                                                            if (dx * .3 < 1) { clearTimeout(a) }
                                                                        }
                                                                    </script>

                                                                </td>
                                                                <td style="background-image: url('Images/index_top_right_pic3.gif'); width: 29px;">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 15px;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                            <tr>
                                                                <td style="height: 25px;">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="color: #3356b4; width: 200px;" valign="bottom" align="left">
                                                                    欢迎您：<asp:Label ID="lbUserName" runat="server" Text=""></asp:Label>
                                                                    &nbsp;<a href="#" style="color: #3356b4" onclick="parent.location.href='LoginPlatform.aspx'">注销</a>
                                                                </td>
                                                                <td style="width: 350px;">
                                                                    <img alt="" src="Images/topbg3_17.gif" style="vertical-align: bottom;" />
                                                                    <a href="javascript:void(0)" style="vertical-align: bottom; height: 22px; margin-right: 10px;
                                                                        text-decoration: none"><font style="color: #3356b4">短信</font></a>
                                                                    <img alt="" src="Images/topbg3_20.gif" style="vertical-align: bottom;" />
                                                                    <a href="javascript:void(0)" style="vertical-align: bottom; height: 22px; margin-right: 10px;
                                                                        text-decoration: none"><font style="color: #3356b4">通知</font></a>
                                                                    <img alt="" src="Images/topbg3_22.gif" style="vertical-align: bottom;" />
                                                                    <a href="javascript:slcontentDisplayOrHidden();" style="vertical-align: bottom; height: 22px;
                                                                        margin-right: 10px; text-decoration: none"><font style="color: #3356b4">报警</font></a>
                                                                    <img alt="" src="Images/topbg3_24.gif" style="vertical-align: bottom;" />
                                                                    <a href="javascript:UpdatePwd();" style="vertical-align: bottom; height: 22px; margin-right: 15px;
                                                                        text-decoration: none"><font style="color: #3356b4">修改密码</font></a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="background-image: url('Images/index_top_right.gif'); width: 25px;">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td style="width: 214px; position: relative; top: 0; left: 0; display: block;" valign="top"
                                id="center_left">
                                <table cellpadding="0" cellspacing="0" border="0" width="100%" style="border: 1px solid #99bbe8;">
                                    <tr>
                                        <td style="background-color: #d9e7f8;">
                                            <div id="index_center_left" style="">
                                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                    <tr>
                                                        <td style="background-image: url('Images/sysnav1.jpg'); height: 30px; color: #3356b4;
                                                            font-weight: bold;">
                                                            <table>
                                                                <tr>
                                                                    <td style="width: 39px">
                                                                    </td>
                                                                    <td style="width: 160px" align="left">
                                                                        <a href="#" onclick="document.getElementById('mainIframe').src='Default.aspx';document.getElementById('trHeader').style.display='none';">
                                                                            <asp:Label ID="lbSys" runat="server" ForeColor="#15428B" ToolTip="回到首页"></asp:Label></a>
                                                                    </td>
                                                                    <td style="width: 15px">
                                                                        <div title="隐藏左侧菜单" onmouseover="this.style.backgroundPosition = '-15px -180px'"
                                                                            onmouseout="this.style.backgroundPosition = '0px -180px'" onclick="hideLeftPanel();"
                                                                            style="background-position: 0px 1px; cursor: hand; background: url('Images/desk/sprites.gif') no-repeat 0px -180px;
                                                                            width: 15px; height: 15px; margin-right: 5px;">
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                <ContentTemplate>
                                                                    <div id="divTree" style="overflow-y:auto;overflow-x:hidden;width: 214px;">
                                                                    <asp:TreeView ID="TreeView1" runat="server">
                                                                        <HoverNodeStyle BackColor="#EEEEEE" ForeColor="#FF0066" />
                                                                        <RootNodeStyle Font-Bold="True" Font-Size="13px" />
                                                                        <NodeStyle Font-Size="12px" />
                                                                        <LeafNodeStyle Font-Size="13px" />
                                                                    </asp:TreeView>
                                                                    </div>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td id="show_panel" style="width: 5px;" align="center" valign="top">
                                <div id="show_div" style="border: 1px solid #99bbe8; width: 20px; display: none;">
                                    <div title="显示左侧菜单" onmouseover="this.style.backgroundPosition = '-15px -165px'"
                                        onmouseout="this.style.backgroundPosition = '0px -165px'" onclick="showLeftPanel();"
                                        style="background-position: 0px 1px; cursor: hand; background: url('Images/desk/sprites.gif') no-repeat 0px -165px;
                                        width: 15px; height: 15px; margin-top: 5px;">
                                    </div>
                                </div>
                            </td>
                            <td valign="top" align="left" style="background-color: #dfe8f6;">
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <tr id="trHeader">
                                        <td style="background-image: url('../Images/gridheadbg.jpg')">
                                            <table border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="width: 24px; height: 24px; background-image: url('Images/headerleft.gif');">
                                                    </td>
                                                    <td style="height: 24px; background-image: url('Images/headercenter.gif'); background-repeat: repeat-x">
                                                        <span class="header" id="spanTitle"></span>
                                                    </td>
                                                    <td style="width: 10px; height: 24px; background-image: url('Images/headerright.gif');">
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <iframe id="mainIframe" name="mainIframe" src="Default.aspx" style="width: 100%;"
                                                frameborder="0"></iframe>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="background-image: url('Images/index_footer.gif'); height: 24px;">
                </td>
            </tr>
        </table>
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </div>
    </form>
</body>
</html>
