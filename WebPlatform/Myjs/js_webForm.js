// JScript 文件
 /*-----------------------------------------------------------
  author:  shuh
  create date:2008-11-29
  description:一个窗体类(可以实现代替弹出窗体的作用)
  attributes:
            url:想要连接的地址
            id:窗体的ID（必须指定）
            title:窗体的标题
            window:在什么页面进行弹出(window:框架 model:弹出窗体 single 单页面)
            contentobj:窗体对象
            parentForm:父窗体对象
            skinpath:皮肤路径
            paramobj:用来保存中间数据的对象(hidden)
            param:窗体的属性(width:宽度 height:高度)
  functions:
            initforms:初始化方法
            registerEvent:给窗体注册事件的方法(divobj:窗体对象)
            setParam:设置共享参数(param:参数列表-----json对象)
            getParam:获得共享参数
            setSkin:设置皮肤
            utmost:用来放大和缩小窗体
            setCurrForm:让当前窗体处于模式状态
            close:关闭窗体
 Use For Exemple：
            var form = new js_webForm_Forms('Default3.aspx','f1','abc','single',{width:700,height:300});
            form.initforms();
------------------------------------------------------------*/
var js_webForm_zIndex = 100;
function js_webForm_Forms(url,id,title,window,param,contentobj)
{
    this.url = url;
    this.id = id;
    this.title = title;
    this.window = window;
    this.contentobj = null;
    this.parentForm = null;
    this.skinpath = '';
    this.width = param.width;
    this.top = null;
    this.height = param.height;
    this.paramobj = null;
    this.content = contentobj;
    this.initforms = function() {
        msgw = this.width;     //设置高亮层的宽度
        msgh = this.height;    //设置高亮层的高度

        this.top = top;    //保存最外层的窗体

        var data = this.top.document.getElementById("js_webForm_data");
        var indexId = this.top.document.getElementById("js_webForm_indexId");
        var dataobj;
        if (!data) {
            data = top.document.createElement("input");
            data.setAttribute("id", "js_webForm_data");
            data.setAttribute("type", "hidden");
            top.document.body.appendChild(data);
            indexId = top.document.createElement("input");
            indexId.setAttribute("id", "js_webForm_indexId");
            indexId.setAttribute("type", "hidden");
            indexId.value = "0";
            top.document.body.appendChild(indexId);
        }
        this.paramobj = data;
        if (this.id == "") {
            this.id = "form" + indexId.value;
            indexId.value = parseInt(indexId.value) + 1;
        }
        if (data.value != "") {
            dataobj = this.getParam();
            //this.parentForm = top.document.getElementById(dataobj.currid);
            js_webForm_zIndex = parseInt(dataobj.currzindex) + 10
        }
        else {
            js_webForm_zIndex += 10;
            this.paramobj.value = '{currid:"",currzindex:"0",fcount:"0"}';
        }
        this.setParam('{currid:"' + this.id + '",currzindex:"' + js_webForm_zIndex + '",fcount:1}');
        currform = this;
        if (this.window == "model" || this.window == "single") {
            init(this.window, this.width, this.height);
        }
        var bgDiv = this.top.document.getElementById("bgDiv");
        if (bgDiv == null)
            myAlert();     //生成遮荫层
        this.top.document.getElementById("bgDiv").style.display = "none";
        initParameter();
        var msgObj = createDiv2(this.id, js_webForm_zIndex);   //创建显示数据层
        this.setSkin(); //设置样式
        //var msgObj = this.top.document.getElementById(this.id);  //得到显示数据层
        this.contentobj = msgObj;


        var htmlDiv = html_createForm2(this.id, title);      //创建页面代码

        msgObj.style.border = "none";

        //top.document.getElementById(id).innerHTML = htmlDiv;      //生成页面

        //contentobj.style.display = "block";
        msgObj.innerHTML = htmlDiv;
            //msgObj.appendChild(contentobj);
        this.registerEvent(msgObj, contentobj);

        GetCenterXY_ForLayer(msgObj);    //让页面居中 
    }
    this.registerEvent = function(divobj, contentobj) {
        var closeDiv = divobj.childNodes[0].childNodes[0].childNodes[0].childNodes[1].childNodes[0].childNodes[0].childNodes[0].childNodes[1];
        var contenttd = document.getElementById("td_content");
        contenttd.appendChild(contentobj);
        contentobj.style.display = "block";
        /*var minFormDiv = divobj.childNodes[0].childNodes[0].childNodes[0].childNodes[1].childNodes[0].childNodes[0].childNodes[0].childNodes[1];
        var utmostDiv = divobj.childNodes[0].childNodes[0].childNodes[0].childNodes[1].childNodes[0].childNodes[0].childNodes[0].childNodes[2].childNodes[0];
        var titleTd = divobj.childNodes[0].childNodes[0].childNodes[0].childNodes[1].childNodes[0].childNodes[0].childNodes[0].childNodes[0];*/

        var tempObj = this;
        /*divobj.childNodes[0].onclick = function(){
        tempObj.setCurrForm();
        }*/

        closeDiv.onclick = function() {
            tempObj.close();
        }

        /*titleTd.ondblclick = function(){
        tempObj.utmost(this.parentNode.childNodes[1].childNodes[0],msgw,msgh,bodyScrollWidth);
        }
        
        utmostDiv.onclick = function(){
        tempObj.utmost(this,msgw,msgh,bodyScrollWidth);
        }
        
        minFormDiv.onclick = function(){
        tempObj.minOrMaxForm(this.firstChild);
        }*/

        /*titleTd.onmousedown = function(){
        drag(this.offsetParent.offsetParent.offsetParent.offsetParent,event)
        }*/
    }
    this.setParam = function(param)
    {
        if(this.paramobj != '')
        {
            newParam = eval('(' + this.paramobj.value + ')');
            
            param = eval('(' + param + ')')
            
            newParam.currid = param.currid != undefined?param.currid : newParam.currid;
            
            newParam.currzindex = param.currzindex != undefined?param.currzindex : newParam.currzindex ;
            
            newParam.fcount = param.fcount != undefined?(parseInt(param.fcount) + parseInt(newParam.fcount)) : newParam.fcount;
            this.paramobj.value = '{currid:"' + newParam.currid + '",currzindex:"' + newParam.currzindex + '",fcount:"' + newParam.fcount + '"}';
        }
    } 
    this.getParam = function(){
        return eval('(' + this.paramobj.value + ')');
    }
    this.utmost = function(obj,width,height,bswidth){
        var currdiv = obj.offsetParent.offsetParent.offsetParent.offsetParent.offsetParent;
        bodyScrollWidth = bswidth;
        with(currdiv.style)
        {
            if(obj.style.backgroundPositionY == "-30px")
            {
                msgw = width;
                msgh = height; 
                width = this.top.document.body.clientWidth;
                height = this.top.document.body.clientHeight - 42;
                top = "0";
                left = "0";
                obj.style.backgroundPosition = "0px -46px"
                obj.title = "还原";
            }
            else
            {
                width = msgw;
                height = msgh;
                GetCenterXY_ForLayer(currdiv);
                obj.style.backgroundPosition = "0px -30px";
                obj.title = "最大化";
            }
        }
    }
    this.setSkin = function(){
        this.skinpath = 'Images/desk/skin1/';
    }
    this.setCurrForm = function(){
        var msgObj = this.contentobj;
        var dataobj = this.getParam();
        js_webForm_zIndex = parseInt(dataobj.currzindex) + 10
        this.setParam('{currid:"' + this.id + '",currzindex:"' + js_webForm_zIndex + '"}');
        msgObj.style.zIndex = js_webForm_zIndex;
    }
    this.minOrMaxForm = function(obj){
       var msgObj = this.contentobj;
       var content = msgObj.childNodes[0].childNodes[0].childNodes[1];
       if(content.style.display == "none")
       {
            content.style.display = "block";
            msgObj.style.width = this.width;
            msgObj.style.height = this.height;
            obj.style.backgroundPosition = "-16px -15px";
            obj.title = "最小化";
       }
       else
       {
         content.style.display = "none"
         msgObj.style.height = "0px";
         msgObj.style.width = "200px";
         obj.style.backgroundPosition = "0px -46px";
         obj.title = "还原";
       }
    }
    this.close = function() {
        var msgObj = this.contentobj;
        this.top.document.body.removeChild(msgObj);
        this.setParam('{fcount:-1}');
        var dataobj = this.getParam();
        if (dataobj.fcount == '0') {
            if (this.top.document.getElementById('bgDiv') != null)
                this.top.document.body.removeChild(this.top.document.getElementById('bgDiv'));
            checkSelect();
        }
        //this.top.document.frames[curr_FN].location.reload();
        //this.top.document.getElementById(curr_FN).document.location.href = this.top.document.getElementById(curr_FN).document.location.href;
    }
}