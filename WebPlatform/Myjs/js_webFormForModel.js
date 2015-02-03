// JScript 文件

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
            param:窗体的属性(width:宽度 height:高度 minbtn:是否需要最小化按钮(true 要 fasle 不要) maxbtn:是否需要最大化按钮(true 要 fasle 不要))
            returnvalue:返回值
  functions:
            initforms:初始化方法
            registerEvent:给窗体注册事件的方法(divobj:窗体对象)
            setParam:设置共享参数(param:参数列表-----json对象)
            getParam:获得共享参数
            setSkin:设置皮肤
            utmost:用来放大和缩小窗体
            setCurrForm:让当前窗体处于模式状态
            close:关闭窗体
            remethod：返回方法，用来在关闭窗体后执行的方法
  Use For Exemple：
            var form = new js_webFormForModel_Forms('Default3.aspx','f1','abc','single',{width:700,height:300});
            form.initforms();

            form.remethod =  function()
            {
                document.getElementById("TextBox1").value = this.returnvalue;   
            }
------------------------------------------------------------*/
var js_webFormForModel_zIndex = 100;
function js_webFormForModel_Forms(url,id,title,page,param)
{
    this.url = url;
    this.id = id;
    this.title = title;
    this.page = page;
    this.contentobj = null;
    this.parentForm = null;
    this.skinpath = '';
    this.width = param.width;
    this.top = null;
    this.height = param.height;
    this.minbtn = true;
    this.maxbtn = true;
    this.paramobj = null;
    this.returnvalue = "";
    this.remethod = function(){};
    this.initforms = function() {
        msgw = this.width;     //设置高亮层的宽度
        msgh = this.height;    //设置高亮层的高度
        this.top = top;    //保存最外层的窗体
        this.minbtn = param.minbtn == undefined ? true : param.minbtn;
        this.maxbtn = param.maxbtn == undefined ? true : param.maxbtn;

        var data = top.document.getElementById("js_webFormForModel_data");
        var indexId = this.top.document.getElementById("js_webFormForModel_indexId");
        var dataobj;
        if (!data) {
            data = top.document.createElement("input");
            data.setAttribute("id", "js_webFormForModel_data");
            data.setAttribute("type", "hidden");
            top.document.body.appendChild(data);

            indexId = top.document.createElement("input");
            indexId.setAttribute("id", "js_webFormForModel_indexId");
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
            this.parentForm = top.document.getElementById(dataobj.currid);
            js_webFormForModel_zIndex = parseInt(dataobj.currzindex) + 10
        }
        else {
            js_webFormForModel_zIndex += 10;
            this.paramobj.value = '{currid:"",currzindex:"0",fcount:"0"}';
        }
        this.setParam('{currid:"' + this.id + '",currzindex:"' + js_webFormForModel_zIndex + '",fcount:1}'); currform = this;
        if (this.page == "model" || this.page == "single") {
            init(this.page, this.width, this.height);
        }
        //var bgDiv = this.top.document.getElementById("bgDiv");
        //if(bgDiv == null)
        myAlert();     //生成遮荫层
        var msgObj = createDiv2(this.id, js_webFormForModel_zIndex);   //创建显示数据层
        this.setSkin(); //设置样式
        //var msgObj = this.top.document.getElementById(id);  //得到显示数据层
        this.contentobj = msgObj;


        var htmlDiv = html_createForm(url, this.id, title);      //创建页面代码

        msgObj.style.border = "none";


        if (this.parentForm != null)
            this.parentForm.style.zIndex = "98";

        msgObj.innerHTML = htmlDiv;      //生成页面

        this.registerEvent(msgObj);

        GetCenterXY_ForLayer(msgObj);    //让页面居中 

        this.top.currForm = this;

    }
    this.registerEvent = function(divobj) {
        var closeDiv = divobj.childNodes[0].childNodes[0].childNodes[0].childNodes[1].childNodes[0].childNodes[0].childNodes[0].childNodes[1];
        var minFormDiv = null; //divobj.childNodes[0].childNodes[0].childNodes[0].childNodes[1].childNodes[0].childNodes[0].childNodes[0].childNodes[1];
        var utmostDiv = null; //divobj.childNodes[0].childNodes[0].childNodes[0].childNodes[1].childNodes[0].childNodes[0].childNodes[0].childNodes[2].childNodes[0];
        //var titleTd = divobj.childNodes[0].childNodes[0].childNodes[0].childNodes[1].childNodes[0].childNodes[0].childNodes[0].childNodes[0];

        var tempObj = this;
        divobj.childNodes[0].onclick = function() {
            tempObj.setCurrForm();
        }

        closeDiv.onclick = function() {
            tempObj.close();
        }

        /*titleTd.ondblclick = function() {
            tempObj.utmost(this.parentNode.childNodes[1].childNodes[0], msgw, msgh, bodyScrollWidth);
        }*/

//        utmostDiv.onclick = function() {
//            tempObj.utmost(this, msgw, msgh, bodyScrollWidth);
//        }

//        minFormDiv.onclick = function() {
//            tempObj.minOrMaxForm(this.firstChild);
//        }
//        if (!this.minbtn)
//            minFormDiv.style.display = "none";
//        if (!this.maxbtn)
//            utmostDiv.style.display = "none";
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
            }
            else
            {
                width = msgw;
                height = msgh;
                GetCenterXY_ForLayer(currdiv);
                obj.style.backgroundPosition = "0px -30px";
            }
        }
    }
    this.setSkin = function(){
        this.skinpath = 'Images/desk/skin1/';
    }
    this.setCurrForm = function(){
        var msgObj = this.top.document.getElementById(this.id);
        var dataobj = this.getParam();
        js_webFormForModel_zIndex = parseInt(dataobj.currzindex) + 10
        this.setParam('{currid:"' + this.id + '",currzindex:"' + js_webFormForModel_zIndex + '"}');
        msgObj.style.zIndex = js_webFormForModel_zIndex;
    }
    this.close = function(){
        var msgObj = this.top.document.getElementById(this.id);
        this.top.document.body.removeChild(msgObj);
        this.setParam('{fcount:-1}');
        var dataobj = this.getParam();
        if(this.parentForm != null)
            this.parentForm.style.zIndex = dataobj.currzindex;
        if(dataobj.fcount == '0')
        {
            this.top.document.body.removeChild(this.top.document.getElementById('bgDiv'));
            this.setParam('{currid:""}');
        }
        else
            this.setParam('{currid:"' + this.parentForm.id + '"}');

//设置焦点
        var inputs = top.frames["mainIframe"].document.getElementsByTagName("input");
        for (var i = 0; i < inputs.length; i++) {
            if (inputs[i].type == "text") {
                try {
                    inputs[i].focus();
                    break;
               }
                catch (e)
                { }
            }
        }
            
        this.remethod();
        checkSelect();
    }
}