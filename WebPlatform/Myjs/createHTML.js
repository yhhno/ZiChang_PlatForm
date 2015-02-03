// JScript 文件

//创建快捷方式
function html_setShortcut(obj) {
    var document, imgUrl;
    if (model == "model") {
        document = "document.getElementById";
        imgUrl = "../../images/leftdia.jpg";
    }
    else {
        document = "document.frames['iframe'].document.getElementById";
        imgUrl = "../images/leftdia.jpg";
    }
    var htmlDiv = '<table width="100%"   cellpadding="0" cellspacing="0" border="0" style="padding-left:15px;" onselectstart="return false"><tr id="title" onmousedown="drag(this.parentNode.parentNode.parentNode,event);" style="cursor:move;"><td style="background-image:url(' + css_menu + ');height:26px;"><table width="100%" border="0" cellpadding="0" cellspacing="0"><tr><td style="color:#ffffff;"><table width="100%" border="0" cellpadding="0" cellspacing="0"><tr><td style="color:#ffffff;"><table><tr><td><img src="' + area_Title + '"  /></td><td>快捷导航设置</td></tr></table></td><td align="right"">'
    + '<div style="width:50px;height:16px;padding:3px;filter:progid:DXImageTransform.Microsoft.Alpha(startX=20, startY=20, finishX=100, finishY=100,style=1,opacity=75,finishOpacity=100);' +
    'opacity:0.75;font:12px 宋体;color:white;cursor:pointer" onclick="var bgObj = top.document.getElementById(\'bgDiv\');var msgObj = top.document.getElementById(\'msgDiv\');top.document.body.removeChild(bgObj);top.document.body.removeChild(msgObj);checkSelect();">['
    + '关闭]</div></td></tr></table></td></tr></table></td></tr>';

    htmlDiv += '<tr><td align="center"><table width="90%"   cellpadding="0" cellspacing="0" border="0"><tr><td style="height:8px;"></td></tr>';
    htmlDiv += '<tr><td><table style="background-color:#cccccc;border:1px solid #000000;"  width="100%"   cellpadding="0" cellspacing="0" border="0"><tr><td style="border-right:1px solid #000000;" align="center"><b><font color="#000000">未设快捷方式的导航</font></b></td><td style="border-right:1px solid #000000;"><font color="#cccccc">-----</font></td><td align="center"><b><font color="#000000">已设快捷方式的导航</font></b></td></tr></table></td></tr>';

    htmlDiv += '<tr><td><table width="100%" style="background-color:#cccccc;border-left:1px solid #000000;border-right:1px solid #000000;border-bottom:1px solid #000000;"   cellpadding="0" cellspacing="0" border="0"><tr><td align="center" style="width:206px;border-right:1px solid #000000;">';

    htmlDiv += '<select id="select1"  name="select1" ondblclick="jsRemoveSelectedItemFromSelect(this,2);" MULTIPLE  style="width:187px;height:280px;">';

    if (obj.shortcut[1].count != '0') {
        for (var i = 0; i < obj.shortcut[1].count; i++) {
            htmlDiv += '<option value="' + obj.shortcut[1].nolimit[i].id + '" >' + obj.shortcut[1].nolimit[i].name + '</option>';
        }
    }

    htmlDiv += '</select>';

    htmlDiv += '<input type="button" class="btn3_mouseout test" onmouseover="this.className=\'btn3_mouseover test\'" onmouseout="this.className=\'btn3_mouseout test\'" onmousedown="this.className=\'btn3_mousedown test\'"  value="全选" onclick="writechr(\'select1\');"/></td>';

    htmlDiv += '<td style="background-color:#999999;width:45px;" align="center"><input style="width:40px;" type="button" value="→" onclick="MoveOption(\'select1\',\'select2\')" class="btn3_mouseout test" onmouseover="this.className=\'btn3_mouseover test\'" onmouseout="this.className=\'btn3_mouseout test\'" onmousedown="this.className=\'btn3_mousedown test\'" /><br/><br/>';

    htmlDiv += '<input type="button" value="←" style="width:40px;" onclick="MoveOption(\'select2\',\'select1\')" class="btn3_mouseout test" onmouseover="this.className=\'btn3_mouseover test\'" onmouseout="this.className=\'btn3_mouseout test\'" onmousedown="this.className=\'btn3_mousedown test\'"/></td><td align="center" style="width:206px;border-left:1px solid #000000;">';

    htmlDiv += '<select id="select2"  name="select2" ondblclick="jsRemoveSelectedItemFromSelect(this,1);" MULTIPLE  style="width:187px;height:280px">';
    if (obj.shortcut[0].count != '0') {
        for (var i = 0; i < obj.shortcut[0].count; i++) {
            try {
                htmlDiv += '<option value="' + obj.shortcut[0].haslimit[i].id + '" >' + obj.shortcut[0].haslimit[i].name + '</option>';
            }
            catch (e)
            { }
        }
    }

    htmlDiv += '</select>';

    htmlDiv += '<input type="button" value="全选" onclick="writechr(\'select2\');"  class="btn3_mouseout test" onmouseover="this.className=\'btn3_mouseover test\'" onmouseout="this.className=\'btn3_mouseout test\'" onmousedown="this.className=\'btn3_mousedown test\'"/></td></tr></table></td></tr>';

    htmlDiv += '<tr><td align="center">点击条目时，可以组合CTRL或SHIFT键进行多选<br/><input type="button" value="保存" onclick="saveShortcut();" class="btn3_mouseout test" onmouseover="this.className=\'btn3_mouseover test\'" onmouseout="this.className=\'btn3_mouseout test\'" onmousedown="this.className=\'btn3_mousedown test\'"/><br/><div id="div_prog"></div></td></tr></table>'
    htmlDiv += '</td></tr></table>';
    return htmlDiv;
}


/*-----------------------------------------------------------
author:  shuh
create date:2007-8-11
description:生成一个窗体的HTML代码

param req:返回一个包含数据的对象

------------------------------------------------------------*/
function html_createForm(url, id, title) {
    var htmlDiv = '<table border="0" cellpadding="0" cellspacing="0" class="dragTable" width="100%">'
    htmlDiv += '  <tr>'
    htmlDiv += '        <td style="background-image: url(' + currform.skinpath + '1_03.gif); width: 3px; height: 26px">'
    htmlDiv += '        </td>'
    htmlDiv += '            <td style="background-image: url(' + currform.skinpath + '1_05.gif); height: 26px">'
    htmlDiv += '                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">'
    htmlDiv += '                    <tr>'
    htmlDiv += '                        <td  onmousedown="drag(this.offsetParent.offsetParent.offsetParent.offsetParent,event);" style="cursor:move;">'
    htmlDiv += '                        <table cellpadding="0" cellspacing="0" class="dragTable" width="100%"><tr><td style="width:17px;"><img  src="' + currform.skinpath + 'sys_config.gif"/></td><td style="color:#000000;">&nbsp;' + title + '</td></tr></table></td>'
//    htmlDiv += '                        <td style="width: 18px">'
//    htmlDiv += '                           <div onmouseover="this.style.backgroundPositionX=\'-16px\';" title="最小化" onmouseout="this.style.backgroundPositionX=\'0px\';" style="background: url(' + currform.skinpath + 'sprites.gif) no-repeat 0px -15px;'
//    htmlDiv += '                                width: 15px; height: 15px">'
//    htmlDiv += '                            </div>'
//    htmlDiv += '                        </td>'
//    htmlDiv += '                        <td style="width: 18px">'
//    htmlDiv += '                           <div onmouseover="this.style.backgroundPositionX=\'-16px\';" title="最大化" onmouseout="this.style.backgroundPositionX=\'0px\';" style="background: url(' + currform.skinpath + 'sprites.gif) no-repeat 0px -30px;'
//    htmlDiv += '                                width: 15px; height: 15px">'
//    htmlDiv += '                            </div>'
//    htmlDiv += '                        </td>'
    htmlDiv += '                        <td style="width: 18px">'
    htmlDiv += '                            <div onmouseover="this.style.backgroundPosition=\'-15px 0px\';" title="关闭" onmouseout="this.style.backgroundPosition=\'0px 0px\';"  style="background: url(' + currform.skinpath + 'sprites.gif) no-repeat 0px 0px;'
    htmlDiv += '                                width: 15px; height: 15px">'
    htmlDiv += '                            </div>'
    htmlDiv += '                        </td>'
    htmlDiv += '                    </tr>'
    htmlDiv += '                </table>'
    htmlDiv += '            </td>'
    htmlDiv += '        <td style="background-image: url(' + currform.skinpath + '1_07.gif); width: 5px; height: 26px">'
    htmlDiv += '        </td>'
    htmlDiv += '    </tr>'
    htmlDiv += '    <tr>'
    htmlDiv += '        <td style="background-image: url(' + currform.skinpath + '1_12.gif)">'
    htmlDiv += '        </td>'
    htmlDiv += '        <td id="Td5" style="background-image: url(' + currform.skinpath + '1_13.gif); height:' + msgh + ';" valign="top">'
    htmlDiv += '             <img src="' + currform.skinpath + 'formLoading.gif" /><iframe   src="' + url + '" frameborder="0" onload="this.parentNode.childNodes[0].style.display=\'none\';" width="100%" height="100%"></iframe>'
    htmlDiv += '        </td>'
    htmlDiv += '        <td style="background-image: url(' + currform.skinpath + '1_14.gif)">'
    htmlDiv += '        </td>'
    htmlDiv += '    </tr>'
    htmlDiv += '    <tr>'
    htmlDiv += '        <td style="background-image: url(' + currform.skinpath + '1_18.gif); height: 5px">'
    htmlDiv += '        </td>'
    htmlDiv += '        <td style="background-image: url(' + currform.skinpath + '1_19.gif); height: 5px">'
    htmlDiv += '        </td>'
    htmlDiv += '        <td style="background-image: url(' + currform.skinpath + '1_20.gif); height: 5px">'
    htmlDiv += '        </td>'
    htmlDiv += '    </tr>'
    htmlDiv += '</table>'

    return htmlDiv;
}

/*-----------------------------------------------------------
author:  shuh
create date:2009-1-23
description:生成一个ALERT框

param content:提示的内容
  reparam htmlDiv:返回的页面HTML

------------------------------------------------------------*/
function html_createAlert(content) {
    var htmlDiv = '<table width="100%"   cellpadding="0" cellspacing="0" border="0" style="padding-left:15px;" onselectstart="return false"><tr id="title" onmousedown="drag(this.parentNode.parentNode.parentNode,event);" style="cursor:move;"><td style="background-image:url(' + css_menu + ');height:26px;"><table width="100%" border="0" cellpadding="0" cellspacing="0"><tr><td style="color:#ffffff;"><table width="100%" border="0" cellpadding="0" cellspacing="0"><tr><td style="color:#ffffff;"><table><tr><td><img src="' + area_Title + '"  /></td><td>操作提示</td></tr></table></td><td align="right"">'
    + '</td></tr></table></td></tr></table></td></tr>';

    htmlDiv += '<tr><td height="30px" valign="middle">' + content + '</td></tr>';

    htmlDiv += '</table>';

    return htmlDiv;
}

     
