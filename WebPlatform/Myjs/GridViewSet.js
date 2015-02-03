
/*-----------------------------------------------------------
create date:2009-7-7
obj:表头CheckBox对象
tablename:GridView的ID
description:表头CheckBox的全选/取消全选
------------------------------------------------------------*/
function CheckBoxAll(obj, tablename) {
    var trArr = document.getElementById(tablename);
    for (i = 1; i < trArr.rows.length; i++) {
        if (typeof (trArr.rows(i).cells(0).children(0)) == "object") {
            trArr.rows(i).cells(0).children(0).checked = obj.checked;
            if (obj.checked == true) {
                trArr.rows(i).className = "RowStyleChecked";
            }
            else {
                trArr.rows(i).className = "RowStyleOut";
            }
        }
    }
}

/*-----------------------------------------------------------
create date:2009-7-7
obj:行中CheckBox对象
description:单击行时设置CheckBox
------------------------------------------------------------*/
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


/*-----------------------------------------------------------
create date:2009-7-21
obj:行中CheckBox对象
当点击下一行时，上次行变回原来的样式
------------------------------------------------------------*/
var ViewState;
function RowClick2(obj) {


    if (ViewState != null && obj != ViewState) {
        if (ViewState.cells[0] != null) {
            var ch = ViewState.cells[0].children[0];
            ch.checked = false;
            ViewState.className = 'RowStyle';
        }
    }

    var chk = obj.cells[0].children[0];
    if (obj.className == 'RowStyleChecked') {
        chk.checked = false;
        obj.className = 'RowStyle';
    }
    else {
        chk.checked = true;
        obj.className = 'RowStyleChecked';
    }

    ViewState = obj;


}



/*-----------------------------------------------------------
create date:2009-7-28
obj:行中对象
当点击下一行时，上次行变回原来的样式，不带CheckBox的Gridview
------------------------------------------------------------*/
var ViewState;
function RowClick3(obj) {


    if (ViewState != null && obj != ViewState) {
        if (ViewState.cells[0] != null) {
            ViewState.className = 'RowStyle';
        }
    }

    if (obj.className == 'RowStyleChecked') {
        obj.className = 'RowStyle';
    }
    else {
        obj.className = 'RowStyleChecked';
    }

    ViewState = obj;


}
/*-----------------------------------------------------------
create date:2009-7-7
obj:行中CheckBox对象
description:单击行时设置CheckBox
------------------------------------------------------------*/
function RowClickSingle(obj, tablename) {
    if (document.getElementById(tablename) == null) {
        return false;
    }
    var tableObj = document.getElementById(tablename);
    for (var i = 1; i < tableObj.rows.length; i++) {
        var chk = tableObj.rows[i].cells[0].children[0];
        if (tableObj.rows[i] == obj) {
            if (chk != null) {
                if (obj.className == 'RowStyleChecked') {
                    chk.checked = false;
                    obj.className = 'RowStyle';
                }
                else {
                    chk.checked = true;
                    obj.className = 'RowStyleChecked';
                }
            }
        }
        else {
            tableObj.rows[i].className = 'RowStyle';
            if (chk != null) {
                chk.checked = false;
            }
        }
    }
}

/*-----------------------------------------------------------
create date:2009-7-7
tablename:GridView的ID
type: one:只能单选    more:可以多选
valname:获得GridView选中行的隐藏对象
moreAlert:选择多行时的提示信息
description:获取CheckBox选中的行
------------------------------------------------------------*/
function GridSelect(tablename, type, valname, Alert) {
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
                if (Alert != "")
                    return window.confirm(Alert);
                else
                    return true;
            }
        }
        else if (type == "more") {
            hd.value = hd.value.substr(0, hd.value.length - 1);
            if (Alert != "")
                return window.confirm(Alert);
            else
                return true;
        }
        else if (type == "") {
            hd.value = hd.value.substr(0, hd.value.length - 1);
            return true;
        }
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
