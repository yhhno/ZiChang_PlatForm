// JScript 文件
var js_setShortcut_timeObj;

var xmlRe = false;                                  //XMLHTTP对象变量

//创建以个xmlhttp对象
try {
    xmlRe = new ActiveXObject("Msxm12.XMLHTTP");   //IE高版本创建的XMLHTTP对象
}
catch (E) {
    try {
        xmlRe = new ActiveXObject("Microsoft.XMLHTTP"); //IE低版本创建的XMLHTTP对象
    }
    catch (E) {
        xmlRe = new XMLHttpRequest();     //兼容非IE浏览器，直接创建XMLhttpRequest对象;
    }
}

//获得快捷导航
function getShortcut()
{
    var d = new Date();
    var strUrl = "GetNavHandler.ashx?SysCode=s0001&guid=" + d.getTime();
    xmlRe.Open("get", strUrl, true)
    xmlRe.onreadystatechange = cb_getShortcut;
    xmlRe.Send(null);
   
}

function cb_getShortcut() {

    var html = "";
    //如果请求已经加载并且服务器返回成功
    if(xmlRe.readyState == 4 && xmlRe.status == 200)
    {
        html = xmlRe.responseText;    //保存已经查询过的用户名，下次直接返回
    }

    $("ul_content").innerHTML = html;                 
    function $(obj) { return document.getElementById(obj) }
    window.maxWidth = $("img").getElementsByTagName("ul")[0].getElementsByTagName("li").length * 140;
    window.isScroll = false;
    window.modiLeft;

    window.targetx = 200; //一次滚动距离
    window.dx;
    window.a = null;
    //xmlHttp = null;

            
}
 /*-----------------------------------------------------------
  author:  shuh
  create date:2007-8-11
  description:设置快捷导航的动画效果

  param req:主体对象

------------------------------------------------------------*/
function openAnimation(obj,url,name)
{
    var img = obj.firstChild.childNodes[0].firstChild; //得到图片对象
    img.style.filter = "Glow(Color=#000000, Strength=2)";
}
 /*-----------------------------------------------------------
  author:  shuh
  create date:2007-8-11
  description:设置快捷导航的移开效果

  param req:主体对象

------------------------------------------------------------*/
function closeAnimation(obj)
{
    var img = obj.firstChild.childNodes[0].firstChild; //得到图片对象
    img.style.filter = "Chroma()";
}
 /*-----------------------------------------------------------
  author:  shuh
  create date:2007-8-11
  description:连接到指定页面
------------------------------------------------------------*/
function linkpage(obj)
{
    var link = obj.parentNode.childNodes[0].href;
    window.frames[0].location = link;
}

function loadTreeData(sysid)
{

location.href="index.aspx?sysid"+sysid;
}

 /*-----------------------------------------------------------
  author:  shuh
  create date:2007-8-11
  description:一个对象,用来获浏览器的版本
------------------------------------------------------------*/
function Browser() { 

var ua, s, i; 

this.isIE = false; // Internet Explorer 
this.isNS = false; // Netscape 
this.version = null; 

ua = navigator.userAgent; 

s = "MSIE"; 
if ((i = ua.indexOf(s)) >= 0) { 
this.isIE = true; 
this.version = parseFloat(ua.substr(i + s.length)); 
return; 
} 

s = "Netscape6/"; 
if ((i = ua.indexOf(s)) >= 0) { 
this.isNS = true; 
this.version = parseFloat(ua.substr(i + s.length)); 
return; 
} 

// Treat any other "Gecko" browser as NS 6.1. 

s = "Gecko"; 
if ((i = ua.indexOf(s)) >= 0) { 
this.isNS = true; 
this.version = 6.1; 
return; 
}
}
//getElementById的进一步封装
function $() {
    var elements = new Array(); //用于返回的数组元素
    for (var i = 0; i < arguments.length; i++) {
        var element = arguments[i];
        if (typeof element == 'string')//得到元素
            element = document.getElementById(element);
        if (arguments.length == 1)//存在一个元素，直接返回这个元素
            return element;
        elements.push(element); //存在多个元素，添加入数组
    }
    return elements;
}


 

    
        
