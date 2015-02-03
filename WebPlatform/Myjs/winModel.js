
var msgw, msgh, bordercolor;   //定义全局变量
var bodyScrollWidth, bodyScrollHeight;
var model, ddlnames;
var area_Title;
var css_menu;
var css_line = "#c8c8c8";     //弹出层线条的颜色
var css_bline = "#717171";
var css_link;
var hd_name, txt_name;
var currform;

if (navigator.appName.indexOf("Explorer") > -1) {//ieg
    var exp = 1;
}
else {//for ff
    var exp = 2;
}

//创建遮荫层的大小
function reCalBodySize() {
    //判断用户当前是在什么窗体下点击弹出框的，以用来改变不同的菜单色调路径
    if (model == "model" || model == "single") {

        css_menu = "../../images/abcd_05.jpg";
    }
    else {

        acss_menu = "../images/abcd_05.jpg";
    }
    if (model == "model" || model == "single")      //单个页面下
    {
        bodyScrollWidth = document.documentElement.scrollWidth;

        if (document.documentElement.scrollHeight < top.screen.height) {
            bodyScrollHeight = top.screen.height; //窗口滚动条位置不在０点，则遮罩层高度为屏幕高度
        }
        else {
            bodyScrollHeight = document.documentElement.scrollHeight + 80;
        }

    }
    else     //框架下
    {
        bodyScrollWidth = screen.width;
        if (document.documentElement.scrollHeight < top.screen.height) {
            bodyScrollHeight = top.screen.height; //窗口滚动条位置不在０点，则遮罩层高度为屏幕高度
        }
        else {
            bodyScrollHeight = document.documentElement.scrollHeight + document.frames.screenTop;
        }
    }
}
//创建层的样式
function set_div_style
(obj, id, top, left, width, height, position, border, cursor, background) {
    var obj = obj;
    obj.id = id ? id : null;
    obj.style.top = top ? top : '0px';
    obj.style.left = left ? left : '0px';
    obj.style.width = width ? width : '0px';
    obj.style.height = height ? height : '0px';
    obj.style.position = position ? position : "static";
    obj.style.border = border ? border : "1px #000 solid";
    obj.style.cursor = cursor ? cursor : "default";
    obj.style.background = background ? background : "";
    obj.style.cursor = "not-allowed";
    return obj
}
function GetCenterXY_ForLayer(objdiv) {


    //判断用户打开的是框架窗口还是模式窗口
    if (model == "model" || model == "single")     //模式窗口或单页面下打开
    {
        /*objdiv.style.display='block';
        var styleWidth=objdiv.style.width.substring(0,objdiv.style.width.length-2);
        var clientHeight=objdiv.style.height.substring(0,objdiv.style.width.length-2);
        var objLeft = parseInt(document.documentElement.scrollLeft+(bodyScrollWidth - styleWidth)/2)+'px';
        var relTop=(document.documentElement.clientHeight-clientHeight)/2 > 0 ? (document.documentElement.clientHeight-clientHeight)/2:0;
        var objTop = parseInt((bodyScrollHeight - clientHeight)/2 - 60)+'px';
        objdiv.style.top = objTop;
        objdiv.style.left = objLeft;
        checkAndResetStyleTop(objdiv);*/
        objdiv.style.display = 'block';
        var styleWidth = objdiv.style.width.substring(0, objdiv.style.width.length - 2);
        var clientHeight = objdiv.clientHeight;
        var objLeft = parseInt(top.document.documentElement.scrollLeft + (top.document.documentElement.clientWidth - styleWidth) / 2) + 'px';
        var relTop = (top.document.documentElement.clientHeight - clientHeight) / 2 > 0 ? (top.document.documentElement.clientHeight - clientHeight) / 2 : 0;
        var objTop = parseInt(top.document.documentElement.scrollTop + relTop) + 'px';
        objdiv.style.top = objTop;
        objdiv.style.left = objLeft;
        checkAndResetStyleTop(objdiv);
    }
    else       //框架下打开
    {
        objdiv.style.display = 'block';
        var styleWidth = objdiv.style.width.substring(0, objdiv.style.width.length - 2);
        var clientHeight = parseInt(objdiv.style.height, 10);
        var objLeft = parseInt((bodyScrollWidth - styleWidth) / 2) + 'px';
        var objTop = parseInt((600 - clientHeight) / 2) + 'px';
        objdiv.style.top = objTop;
        objdiv.style.left = objLeft;
        checkAndResetStyleTop(objdiv);
    }

}
//创建遮荫层
function buildGlobalDiv() {
    var globalDiv = document.createElement('div');
    globalDiv.id = 'globalDiv';
    globalDiv.style.zIndex = '98';
    globalDiv = set_div_style(globalDiv, 'globalDiv', '0px', '0px', bodyScrollWidth + 'px', bodyScrollHeight + 'px', "absolute", " #333333 0px solid", "default", "darkgray");
    if (1 == exp) {
        globalDiv.style.filter = "alpha(opacity=30)";
    }
    else {
        globalDiv.style.opacity = 30 / 100;
    }
    document.body.appendChild(globalDiv);
}
function checkAndResetStyleTop(obj) {
    var clientHeight = obj.firstChild.clientHeight;
    var styleTop = parseInt(obj.style.top.substring(0, obj.style.top.length - 2));
    if (clientHeight + styleTop > bodyScrollHeight) {
        obj.style.top = (bodyScrollHeight - clientHeight) + 'px';
    }
}
//创建层
function createDiv() {
    //关闭数据读取层
    top.document.body.removeChild(window.tip_loading);
    //掩藏所有DropDownList
    hiddentDdl(ddlnames);
    var msgObj = top.document.createElement("div");
    msgObj.setAttribute("id", "msgDiv");

    msgObj.style.background = "white";
    msgObj.style.border = "1px solid " + bordercolor;
    msgObj.style.position = "absolute";
    msgObj.style.font = "12px 宋体";
    msgObj.style.width = msgw + "px";
    msgObj.style.height = msgh + "px";
    msgObj.style.borderBottom = "6px solid " + css_bline; ;
    msgObj.style.zIndex = "10001";
    msgObj.style.overflow = "auto";
    top.document.body.appendChild(msgObj); //添加高亮层
}
//为了方便重写了个
function createDiv1(id, zindex) {
    id = id == undefined ? "msgDiv" : id;
    zindex = zindex == undefined ? 10001 : zindex;
    //关闭数据读取层
    top.document.body.removeChild(window.tip_loading);
    //掩藏所有DropDownList
    if (undefined != undefined)
        hiddentDdl(ddlnames);

    var msgObj = top.document.createElement("div");
    msgObj.setAttribute("id", id);

    msgObj.style.background = "white";
    msgObj.style.border = "1px solid " + bordercolor;
    msgObj.style.position = "absolute";
    msgObj.style.font = "12px 宋体";
    msgObj.style.width = msgw + "px";
    msgObj.style.height = msgh + "px";
    msgObj.style.borderBottom = "6px solid " + bordercolor;
    msgObj.style.zIndex = zindex;

    top.document.body.appendChild(msgObj); //添加高亮层
}
//重写(多窗体类使用)
function createDiv2(id, zindex) {
    id = id == undefined ? "msgDiv" : id;
    zindex = zindex == undefined ? 10001 : zindex;
    //关闭数据读取层
    try {
        top.document.body.removeChild(window.tip_loading);
    }
    catch (e)
    { }
    //掩藏所有DropDownList
    if (undefined != undefined)
        hiddentDdl(ddlnames);

    var msgObj = top.document.createElement("div");
    msgObj.setAttribute("id", id);

    msgObj.style.background = "white";
    msgObj.style.border = "1px solid " + bordercolor;
    msgObj.style.position = "absolute";
    msgObj.style.font = "12px 宋体";
    msgObj.style.width = msgw + "px";
    msgObj.style.height = msgh + "px";
    msgObj.style.borderBottom = "6px solid " + bordercolor;
    msgObj.style.zIndex = zindex;

    top.document.body.appendChild(msgObj); //添加高亮层
    return msgObj;
}

//弹出层显示
function myAlert() {
    var bgDiv = top.document.getElementById('bgDiv');

    reCalBodySize();
    if (msgw == null || msgh == null) {
        msgw = 600; //提示窗口的宽度
        msgh = 400; //提示窗口的高度
    }

    titleheight = 25 //提示窗口标题高度
    bordercolor = css_line;
    //提示窗口的边框颜色
    titlecolor = "#99CCFF"; //提示窗口的标题颜色
    if (!bgDiv) {
        //遮罩层
        var bgObj = top.document.createElement("div");
        bgObj.setAttribute('id', 'bgDiv');
        bgObj.style.zIndex = "99";
        bgObj = set_div_style(bgObj, 'bgDiv', '0px', '0px', bodyScrollWidth + 'px', bodyScrollHeight + 'px', "absolute", " #333333 0px solid", "default", "darkgray");
        if (1 == exp) {
            bgObj.style.filter = "alpha(opacity=30)";
        }
        else {
            bgObj.style.opacity = 30 / 100;
        }
        top.document.body.appendChild(bgObj); //添加入窗口中

        checkSelect(); //隐藏select
    }
    tipLoading();                       //生成一个loading的图案

}
/*-----------------------------------------------------------
author:shuh
create date:2007-8-05
summary:在主窗体出现以前起到等待效果的图片

------------------------------------------------------------*/
function tipLoading() {
    var loading = '';
    if (model == "model" || model == "single") {
        //弹出层导航栏的色调
        loading = "url(../../images/busy.gif)";
    }
    else {
        loading = "url(../images/busy.gif)";
    }

    var div_loading = top.document.createElement("div_loading");
    div_loading.setAttribute("id", "div_loading");
    div_loading.style.position = "absolute";
    div_loading.style.width = "16px";
    div_loading.style.height = "16px";
    div_loading.style.backgroundImage = loading;
    div_loading.style.zIndex = "10001";
    top.document.body.appendChild(div_loading); //添加入窗口中
    window.tip_loading = div_loading;
    //判断用户打开的是框架窗口还是模式窗口
    if (model == "model" || model == "single")     //模式窗口或单页面下打开
    {
        div_loading.style.display = 'block';
        var styleWidth = div_loading.style.width.substring(0, div_loading.style.width.length - 2);
        var clientHeight = div_loading.clientHeight;
        var objLeft = parseInt(document.documentElement.scrollLeft + (document.documentElement.clientWidth - styleWidth) / 2) + 'px';
        var relTop = (document.documentElement.clientHeight - clientHeight) / 2 > 0 ? (document.documentElement.clientHeight - clientHeight) / 2 : 0;
        var objTop = parseInt(document.documentElement.scrollTop + relTop) + 'px';
        div_loading.style.top = objTop;
        div_loading.style.left = objLeft;
    }
    else       //框架下打开
    {
        div_loading.style.display = 'block';
        var styleWidth = div_loading.style.width.substring(0, div_loading.style.width.length - 2);
        var clientHeight = div_loading.style.height.substring(0, div_loading.style.width.length - 2);
        var objLeft = parseInt((bodyScrollWidth - styleWidth) / 2) + 'px';
        var objTop = parseInt((600 - clientHeight) / 2) + 'px';
        div_loading.style.top = objTop;
        div_loading.style.left = objLeft;
    }
}
//获得地区
function getAarea(window, width, height, names, hdname, txtname, typeid) {
    ddlnames = names;
    //保存页面控件
    if (hdname && txtname) {
        hd_name = hdname;
        txt_name = txtname;
    }
    else {
        return;
    }
    //获得当前为什么窗体
    model = window;
    if (window == "model" || window == "single") {
        init(window, width, height);
    }
    myAlert();
    initParameter();
    var d = new Date();
    if (typeid == undefined)
        typeid = "14";
    var strUrl = "../serverData/getData.ashx?&id=" + typeid + "&txtname=" + txt_name + "&path=0&hdname=" + hd_name + "&guid=" + d.getTime();
    Request.send(strUrl, "GET", showArea, null, null);    //启用xmlHTTP封装方法获得数据
}
function showArea(req) {

    createDiv();    //创建高亮层
    var xml = req.responseXML.getElementsByTagName("kind");      //得到所有的省
    if (req.responseXML.getElementsByTagName("tname")[0].childNodes.length > 0) {
        txt_name = req.responseXML.getElementsByTagName("tname")[0].firstChild.data;
        hd_name = req.responseXML.getElementsByTagName("hname")[0].firstChild.data;
    }
    var size = xml.length;   //或得数组的长度      
    var msgObj = top.document.getElementById("msgDiv");
    var htmlDiv = createArea(xml, size);
    msgObj.innerHTML = htmlDiv;
    GetCenterXY_ForLayer(msgObj);
}
function init(window, width, height) {
    model = window;
    //判断是模式还是单个页面执行不同的操作
    if (window == "single") {
        msgw = width;
        msgh = height;
    }
    else if (window == "model") {
        bodyScrollWidth = width;
        bodyScrollHeight = height;
    }
}
//得到所有二级地区
function getAreaKinds(title, names, txtname, hdname, path) {
    var strUrl;
    var d = new Date();

    if (model == "model" || model == "single") {
        strUrl = "../serverData/getData.ashx?ddlnames=" + names + "&id=" + title.split('|')[1] + "&txtname=" + txtname + "&hdname=" + hdname + "&path=" + escape(path) + "&guid=" + d.getTime();
    }
    else {
        strUrl = "serverData/getData.ashx?ddlnames=" + names + "&id=" + title.split('|')[1] + "&txtname=" + txtname + "&hdname=" + hdname + "&path=" + escape(path) + "&guid=" + d.getTime();
    }
    Request.send(strUrl, "GET", showAreaKinds, null, null);

}
//二级地区的回调函数
function showAreaKinds(req) {
    var xml = req.responseXML.getElementsByTagName("kind");
    //获得父节点名称
    var xml_fname = req.responseXML.getElementsByTagName("fname")[0];
    //获得所有dropdownlist的名字
    var xml_ddlNames = req.responseXML.getElementsByTagName("ddlnames")[0];
    var size = xml.length;

    if (req.responseXML.getElementsByTagName("tname")[0].childNodes.length > 0) {
        txt_name = req.responseXML.getElementsByTagName("tname")[0].firstChild.data;
        hd_name = req.responseXML.getElementsByTagName("hname")[0].firstChild.data;
    }
    var xml_path = req.responseXML.getElementsByTagName("path")[0];
    var htmlDiv = createAreaKinds(size, xml, xml_ddlNames, xml_fname, xml_path);
    var kind = top.document.getElementById("kind");
    kind.innerHTML = htmlDiv;
}
//掩藏所有dropdownlist
function hiddentDdl(names) {

    if (names != "") {
        var ddl = new Array();
        ddl = names.split('|');
        for (var i = 0; i < ddl.length; i++) {
            if (ddl[i] != "") {
                $(ddl[i]).style.display = "none";
            }
        }
    }
}
//把Dropdownlist显示
function displayDdl(names) {
    if (names != "") {
        var ddl = new Array();
        ddl = names.split('|');
        for (var i = 0; i < ddl.length; i++) {
            if (ddl[i] != "") {
                if (model == "model" || model == "single") {
                    document.getElementById(ddl[i]).style.display = "block";
                }
                else {
                    try {
                        var abc = frames['iframe'].document.getElementById(ddl[i]).value;
                        document.frames['iframe'].document.getElementById(ddl[i]).style.display = "block";
                    }
                    catch (E) {
                        frames[0].frames[0].document.getElementById(ddl[i]).style.display = "block";
                    }

                }
            }
        }
    }
}
//将字符进行替换
function replaceStr(str) {
    str = str.replace('-', ' ');
    str = str.replace('z', '_');
    str = str.replace('f', '_');
    return str;
}
//把文本替换成能链接的形式（适用于消息）
function replaceStr2(str, pom) {
    var newStr;
    if (pom == "1") {
        newStr = '<a onclick="var bgObj = top.document.getElementById(\'bgDiv\');var msgObj = top.document.getElementById(\'msgDiv\');top.document.body.removeChild(bgObj);top.document.body.removeChild(msgObj);" onmouseover="this.style.color=\'' + css_line + '\'" onmouseout="this.style.color=\'' + css_link + '\'"  style="text-decoration:none;color:' + css_link + ';cursor:hand;" target="iframe" href="' + str.split('-')[0] + '">' + str.split('-')[1] + '</a>';
    }
    else {
        newStr = '<a onclick="alert(\'您没有权限访问，请配置权限后在尝试重新进入!\')" onmouseover="this.style.color=\'' + css_line + '\'" onmouseout="this.style.color=\'' + css_link + '\'"  style="text-decoration:none;color:' + css_link + ';cursor:hand;" href="javascript:void">' + str.split('-')[1] + '</a>';
    }
    return newStr;
}
//根据相对路径的不同，显示相同下级图标
function expandPic(forms) {
    var imgUrl;             //用来保存图片路径
    if (forms == "model" || forms == "single") {
        imgUrl = "../../images/collapsed.gif";
    }
    else {
        imgUrl = "../images/collapsed.gif";
    }
    return imgUrl;
}
/**
*
*
*初始化页面参数

*
*
*/
function initParameter() {
    css_link = "428EFF";
    //初始化标题图像
    if (model == "model" || model == "single") {
        //弹出层导航栏的色调
        css_menu = "../../images/t_title1.gif";
        area_Title = "../../images/t_title_pic.gif";
    }
    else {
        css_menu = "../images/t_title1.gif";
        area_Title = "../images/t_title_pic.gif";
    }

}
//掩藏当前页面所有的select
function checkSelect() {
    var selects = document.getElementsByTagName("select");
    if (selects.length != 0) {
        for (var i = 0; i < selects.length; i++) {
            if (selects[i].style.display == "none") {
                selects[i].style.display = "block";
            }
            else {
                if (selects[i].name != "tbSelMonth" && selects[i].name != "tbSelYear")
                    selects[i].style.display = "none";
            }
        }
    }
    else {
        if (top.document.getElementById('curr_tabid') != null) {
            var id = top.document.getElementById('curr_tabid').value;
            var curr_FN = '';
            if (id == "" || id == "0") {
                id = 0;
                curr_FN = 'iframe';
            }
            else {
                curr_FN = 'f' + id;
            }
            var sel = top.frames[curr_FN].document.getElementsByTagName('select');
            for (var i = 0; i < sel.length; i++) {

                if (sel[i].style.display == "none") {
                    sel[i].style.display = "block";
                }
                else {
                    if (sel[i].name != "tbSelMonth" && sel[i].name != "tbSelYear")
                        sel[i].style.display = "none";
                }
            }
            if (top.frames[curr_FN].frames.length > 0)
                checkNextFrameSelect(top.frames[curr_FN].frames);
        }
    }
}
//掩藏页面所有的select
function checkNextFrameSelect(frame) {
    if (frame.length != 0) {
        for (var j = 0; j < frame.length; j++) {
            try {
                var sel = frame[j].document.getElementsByTagName('select');

                for (var i = 0; i < sel.length; i++) {

                    if (sel[i].style.display == "none") {
                        sel[i].style.display = "block";
                    }
                    else {
                        if (sel[i].name != "tbSelMonth" && sel[i].name != "tbSelYear")
                            sel[i].style.display = "none";
                    }
                }
                checkNextFrameSelect(frame[j].frames);
            }
            catch (e)
          { }
        }
    }
    else {
        return;
    }
}

function getTabContentControlId(documents, tid) {
    var values = "";
    var abc;
    try {
        for (var i = 1; i <= documents('TabContainer1_body').childNodes.length; i++) {
            if (documents('TabContainer1$TabPanel' + i + '$' + tid)) {
                values = 'TabContainer' + i + '$TabPanel1$' + tid;
                break;
            }
        }
    }
    catch (e)
    { values = ""; }
    return values;
}
/*-----------------------------------------------------------
author:shuh
create date:2008-11-28
summary:关闭窗体
------------------------------------------------------------*/
function winModel_closeForm() {
    var bgObj = top.document.getElementById('bgDiv');
    var msgObj = top.document.getElementById('msgDiv');
    top.document.body.removeChild(bgObj);
    top.document.body.removeChild(msgObj);
}