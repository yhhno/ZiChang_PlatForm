/****************************************************************************************************************
*版本：js图表v1.0
*日期：2009.5.4
*作者：卢俊哲
*联系方式：ljzforever@yahoo.com.cn
*说明：此js可画立体柱状图与立体饼图
*用法：具体见Demo
*
*版本：js图表v1.1
*日期：2009.5.9
*更新：增加立体折线图，解决立体饼图与立体折线图的命名冲突问题
*
*版本：js图表v1.2
*日期：2009.5.11
*更新：现在可以在同一页面内画多个同一种图

*版本：js图表v1.3
*日期：2010.1.15
*更新：更改了多处bug
*
*
*****************************************************************************************************************/
//画柱状图
//参数含义(数据源数组，横坐标，纵坐标，图表的宽度，图表的高度,图表标题，X轴单位，Y轴单位,维一性ID)
//数据源数组结构：数值，标题，提示信息，链接信息
function drawHistogram(data_Array, table_left, table_top, all_width, all_height, table_title, x_unit, y_unit, uniqueId) {
    //颜色列表：预设10个。
    var colors = ["#ff1919","#ffff19","#1919ff","#19ff19","#fc0","#3cc","#ff19ff","#993300","#f60","#f60"];

    //数据个数
    var num = data_Array.length;
    //图形宽度
    var item_width = parseInt(20000/num + 0.5);
    //起始坐标
    var begin_x = parseInt(((item_width-1200)/2)+2200);
    
    //算比例高度
    //取所有值的最大值
    var value_max = 0;
    for(i=0; i<num; i++)
    {
        if(value_max<data_Array[i][0])
        {
            value_max = data_Array[i][0]
        }
    }

    value_max = parseInt(value_max);
    value_max_str = value_max + "";

    if(value_max > 9)
    {
        temp = value_max_str.substring(2,1);
        if(temp > 4)
        {
         temp2 = (parseInt(value_max/Math.pow(10,value_max_str.length-1))+1) * Math.pow(10,value_max_str.length-1)
        }
        else
        {
           temp2 = (parseInt(value_max/Math.pow(10,value_max_str.length-1))+0.5) * Math.pow(10,value_max_str.length-1)
        }
    }
    else if(value_max > 4)
    {
        temp2 = 10;
    }
    else
    {
        temp2 = 5;
    }
    //横坐标有五条线，折算成每条线的高度。
    item_height = temp2/5;
    
    //开始作图
    var result = "";
    
    //大背景
    result += "<v:shapetype id='" + uniqueId + "Box' coordsize='21600,21600' o:spt='16' adj='5400'></v:shapetype>";
    result += "<v:rect id='"  + uniqueId + "background' style='position:absolute;left:"+table_left+"px;top:"+table_top+"px;WIDTH:"+all_width+"px;HEIGHT:"+all_height+"px;' fillcolor='#EFEFEF' strokecolor='gray'>";
    result += " <v:shadow on='t' type='single' color='silver' offset='4pt,4pt'/>";
    result += "</v:rect>";
    result += "<v:group ID='" + uniqueId + "table' style='position:absolute;left:"+table_left+"px;top:"+table_top+"px;WIDTH:"+all_width+"px;HEIGHT:"+all_height+"px;' coordsize = '23500,12700'>" ;
    result += " <v:Rect style='position:relative;left:1500;top:200;width:20000;height:800'filled='false' stroked='false'>";
    result += " <v:TextBox inset='0pt,0pt,0pt,0pt'>";
    
    //标题
    result += " <table width='100%' border='0' align='center' cellspacing='0'>";
    result += " <tr>";
    result += " <td align='center' valign='middle'><div style='font-size:15pt; font-family:黑体;'><B>"+table_title+"</B></div></td>";
    result += " </tr>";
    result += " </table>";
    result += " </v:TextBox>";
    result += " </v:Rect> ";
    
    //背景与箭头
    result += " <v:rect id='" + uniqueId + "back' style='position:relative;left:1700;top:1200;width:20500; height:10500;' fillcolor='#9cf' strokecolor='#DFDFDF'>";
    result += " <v:fill rotate='t' angle='-45' focus='100%' type='gradient'/>";
    result += " </v:rect>";
    result += " <v:line ID='" + uniqueId + "X' from='1700,11700' to='22700,11700' style='z-index:2' strokecolor='#000000' strokeWeight=1pt><v:stroke EndArrow='Classic'/></v:line>";
    result += " <v:line ID='" + uniqueId + "Y' from='1700,900' to='1700,11700' style='z-index:2' strokecolor='#000000' strokeWeight=1pt><v:stroke StartArrow='Classic'/></v:line>";
    
    //X轴与Y轴的单位
    result += " <v:Rect style='position:relative;left:100;top:700;width:1500;height:500' filled='false' stroked='false'>"
    result += " <v:TextBox inset='0pt,0pt,0pt,0pt' style='font-size:9pt;'><div align='right'>"+y_unit+"</div></v:TextBox>"
    result += " </v:Rect> " 
    result += " <v:Rect style='position:relative;left:22200;top:11900;width:2000;height:500' filled='false' stroked='false'>"
    result += " <v:TextBox inset='0pt,0pt,0pt,0pt' style='font-size:9pt;'><div align='left'>"+x_unit+"</div></v:TextBox>"
    result += " </v:Rect> " 
    
    //画五条横坐标
    for(i=0; i<=4; i++)
    {
        result += " <v:line from='1200,"+(i*2000+1700)+"' to='1700,"+(i*2000+1700)+"' style='z-index:2' strokecolor='#000000'></v:line>";
        result += " <v:line from='1700,"+(i*2000+1700)+"' to='2200,"+(i*2000+1200)+"' style='z-index:2' strokecolor='#0099FF'></v:line>";
        result += " <v:line from='2200,"+(i*2000+1200)+"' to='22200,"+(i*2000+1200)+"' style='z-index:2' strokecolor='#0099FF'></v:line>";
        result += " <v:line from='2200,"+(i*2000+2200)+"' to='22200,"+(i*2000+2200)+"' style='z-index:2' strokecolor='#0099FF'>";
        result += " <v:stroke dashstyle='Dot'/>"
        result += " </v:line>"
        
        result += " <v:Rect style='position:relative;left:100;top:"+(i*2000+1250)+";width:1500;height:500' filled='false' stroked='false'>";
        result += " <v:TextBox inset='0pt,0pt,0pt,0pt' style='font-size:9pt;'><div align='right'>"+item_height*(5-i)+"</div></v:TextBox>";
        result += " </v:Rect> " ;
    }
    
    //画三条让图形变得立体的线
    result += " <v:line from='2200,11200' to='22200,11200' style='z-index:2' strokecolor='#0099FF'></v:line>";
    result += " <v:line from='2200,1200' to='2200,11200' style='z-index:2' strokecolor='#0099FF'></v:line>";
    result += " <v:line from='1700,11700' to='2200,11200' style='z-index:2' strokecolor='#0099FF'></v:line>";
    
    //画柱子了
    for(i=0; i<num; i++)
    {
        this_hight = parseInt(data_Array[i][0]/(5*item_height)*10000+420);
        result += " <v:shape id='" + uniqueId + "Box"+i+"' type='#" + uniqueId + "Box' fillcolor='"+colors[i]+"' strokecolor='#5f5f5f' style='position:relative; left:"+(i*item_width+begin_x)+";top:"+parseInt(10000-this_hight+1620)+";width:1200;height:"+this_hight+";z-index:10' title='" + data_Array[i][2] + "'>";
        result += " <v:fill o:opacity2='52429f' rotate='t' angle='-45' focus='100%' type='gradient'/>";
        result += " </v:shape>";
        result += " <v:Rect style='position:relative;left:"+(i*item_width+2200)+";top:"+parseInt(10000-this_hight+1150)+";width:"+item_width+";height:500' filled='false' stroked='false'>";
        result += " <v:TextBox inset='0pt,0pt,0pt,0pt' style='font-size:9pt;'><div align='center'>"+data_Array[i][0]+"</div></v:TextBox>";
        result += " </v:Rect>" ;
        
        result += " <v:Rect style='position:relative;left:"+(i*item_width+2200)+";top:11850;width:"+item_width+";height:500' filled='false' stroked='false'>";
        result += " <v:TextBox inset='0pt,0pt,0pt,0pt' style='font-size:9pt;'><div align='center'><a href='" + data_Array[i][3] + "'>"+data_Array[i][1]+"</a></div></v:TextBox>";
        result += " </v:Rect> " ;
    }
    result += "</v:group>";
    return result;
}

//画饼图
//参数含义(数据源数组，横坐标，纵坐标，图表的宽度，图表的高度,图表标题,单位,维一性ID)
//数据源数组结构：数值，标题
function drawPie(data_Array, table_Left, table_Top, all_Width, all_Height, table_Title, unit, uniqueId)
{
    //预设十种颜色
    var colors = ["#ff1919","#ffff19","#1919ff","#19ff19","#fc0","#3cc","#ff19ff","#993300","#f60","#ff8c19"];
    //饼数组
    var pie = [];
    //数据个数
    var num = data_Array.length;
    //数据值总数
    var allValue = 0;
    for(i=0; i<num; i++)
    {
        allValue += data_Array[i][0];
    }
    //计算饼的比例
    var k=0;
    for(i=0; i<num-1; i++)
    {
        if(allValue == 0)
          pie[i] = 0;
        else
          pie[i] = Round(data_Array[i][0]/allValue, 4);
        //pie[i] = Number((data_Array[i][0]/allValue).toFixed(4));
        k += pie[i];
    }
    pie[num-1] = Round(1-k,4);
    
    //开始作图
    var result = "";
    
    //初始化数据
    result += "<v:shapetype id='" + uniqueId + "Cake_3D' coordsize='21600,21600' o:spt='95' adj='11796480,5400' path='al10800,10800@0@0@2@14,10800,10800,10800,10800@3@15xe'></v:shapetype>"
    result += "<v:shapetype id='" + uniqueId + "3dtxt' coordsize='21600,21600' o:spt='136' adj='10800' path='m@7,l@8,m@5,21600l@6,21600e'> "
    result += " <v:path textpathok='t' o:connecttype='custom' o:connectlocs='@9,0;@10,10800;@11,21600;@12,10800' o:connectangles='270,180,90,0'/>"
    result += " <v:textpath on='t' fitshape='t'/>"
    result += " <o:lock v:ext='edit' text='t' shapetype='t'/>"
    result += "</v:shapetype>"

    //画大背景
    result += "<v:rect id='" + uniqueId + "background' style='position:absolute;left:"+table_Left+"px;top:"+table_Top+"px;WIDTH:"+all_Width+"px;HEIGHT:"+all_Height+"px;' fillcolor='#EFEFEF' strokecolor='gray'>"
    result += " <v:shadow on='t' type='single' color='silver' offset='4pt,4pt'/>"
    result += "</v:rect>"

    //画标题
    result += "<v:group ID='" + uniqueId + "table' style='position:absolute;left:"+table_Left+"px;top:"+table_Top+"px;WIDTH:"+all_Width+"px;HEIGHT:"+all_Height+"px;' coordsize = '21000,11500'>" 
    result += " <v:Rect style='position:relative;left:500;top:200;width:20000;height:800'filled='false' stroked='false'>"
    result += " <v:TextBox inset='0pt,0pt,0pt,0pt'>"
    result += " <table width='100%' border='0' align='center' cellspacing='0'>"
    result += " <tr>"
    result += " <td align='center' valign='middle'><div style='font-size:15pt; font-family:黑体;'><B>"+table_Title+"</B></div></td>"
    result += " </tr>"
    result += " </table>"
    result += " </v:TextBox>"
    result += " </v:Rect> "

    //画饼的背景
    result += " <v:rect id='" + uniqueId + "back' style='position:relative;left:500;top:1000;width:20000; height:10000;' onmouseover='movereset(1)' onmouseout='movereset(0)' fillcolor='#9cf' strokecolor='#888888'>"
    result += " <v:fill rotate='t' angle='-45' focus='100%' type='gradient'/>"
    result += " </v:rect>"

    //画图示背景
    result += " <v:rect id='" + uniqueId + "back' style='position:relative;left:15000;top:1400;width:5000; height:"+((num+1)*9000/11+200)+";' fillcolor='#9cf' stroked='t' strokecolor='#0099ff'>"
    result += " <v:fill rotate='t' angle='-175' focus='100%' type='gradient'/>"
    result += " <v:shadow on='t' type='single' color='silver' offset='3pt,3pt'/>"
    result += " </v:rect>"
    //画图示标题
    result += " <v:Rect style='position:relative;left:15500;top:1500;width:4000;height:700' fillcolor='#000000' stroked='f' strokecolor='#000000'>"
    result += " <v:TextBox inset='8pt,4pt,3pt,3pt' style='font-size:11pt;'><div align='left'><font color='#ffffff'><B>总数:"+allValue+unit+"</B></font></div></v:TextBox>"
    result += " </v:Rect> " 
    //画图示
    for(i=0; i<num; i++)
    {
        result += " <v:Rect id='" + uniqueId + "pieRec"+i+"' style='position:relative;left:15400;top:"+((i+1)*9000/11+1450)+";width:4300;height:800;display:none' fillcolor='#efefef' strokecolor='"+colors[i]+"'>"
        result += " <v:fill opacity='.6' color2='fill darken(118)' o:opacity2='.6' rotate='t' method='linear sigma' focus='100%' type='gradient'/>"
        result += " </v:Rect>"
        result += " <v:Rect style='position:relative;left:15500;top:"+((i+1)*9000/11+1500)+";width:600;height:700' fillcolor='"+colors[i]+"' stroked='f'/>"
        result += " <v:Rect style='position:relative;left:16300;top:"+((i+1)*9000/11+1500)+";width:3400;height:700' filled='f' stroked='f'>"
        result += " <v:TextBox inset='0pt,5pt,0pt,0pt' style='font-size:9pt; cursor:pointer;' "
        if(allValue != 0)
        {
            result += "onmouseover='moveup(" + uniqueId + "cake"+i+","+(table_Top+all_Height/14)+"," + uniqueId + "txt"+i+"," + uniqueId + "pieRec"+i+")'; onmouseout='movedown(" + uniqueId + "cake"+i+","+(table_Top+all_Height/14)+"," + uniqueId + "txt"+i+"," + uniqueId + "pieRec"+i+");'"
        }
        result += "><div align='left'>"+data_Array[i][1]+":"+data_Array[i][0]+unit+"</div></v:TextBox>"
        result += " </v:Rect> " 
    }

    result += " </v:group> "
    
    //画饼与提示
    k1=180;
    k4=10;
    for(i=0; i<num; i++)
    {
        k2 = 360*pie[i]/2;
        k3 = k1 + k2;
        if(k3 >= 360)
        {
            k3 = k3 - 360;
        }
        kkk = -11796480*pie[i]+5898240;
        
        k5 = 3.1415926*2*(180-(k3-180))/360;
        r = all_Height / 2;
        txt_X = table_Left + all_Height/8 - 30 + r + r * Math.sin(k5) * 0.7;
        txt_Y = table_Top + all_Height/14 - 39 + r + r * Math.cos(k5) * 0.7 * 0.5;
        
        var titleStr = "&nbsp;名&nbsp;&nbsp;称："+data_Array[i][1]+"&#13;&#10;&nbsp;数&nbsp;&nbsp;值："+data_Array[i][0]+unit+"&#13;&#10;&nbsp;比例:"+(pie[i]*100).toFixed(2)+"%&nbsp;&nbsp;"
        result += " <div style='cursor:hand;'>"
        result += " <v:shape id='" + uniqueId + "cake"+i+"' type='#" + uniqueId + "Cake_3D' title='"+titleStr+"'"
        result += " style='position:absolute;left:"+(table_Left+all_Height/8)+"px;top:"+(table_Top+all_Height/14)+"px;WIDTH:"+all_Height+"px;HEIGHT:"+all_Height+"px;rotation:"+k3+";z-index:"+k4+"'"
        result += " adj='"+kkk+",0' fillcolor='"+colors[i]+"' onmouseover='moveup(" + uniqueId + "cake"+i+","+(table_Top+all_Height/14)+"," + uniqueId + "txt"+i+"," + uniqueId + "pieRec"+i+")'; onmouseout='movedown(" + uniqueId + "cake"+i+","+(table_Top+all_Height/14)+"," + uniqueId + "txt"+i+"," + uniqueId + "pieRec"+i+");'>"
        result += " <v:fill opacity='60293f' color2='fill lighten(120)' o:opacity2='60293f' rotate='t' angle='-135' method='linear sigma' focus='100%' type='gradient'/>"
        result += " <o:extrusion v:ext='view' on='t'backdepth='25' rotationangle='60' viewpoint='0,0'viewpointorigin='0,0' skewamt='0' lightposition='-50000,-50000' lightposition2='50000'/>"
        result += " </v:shape>"
        result += " <v:shape id='" + uniqueId + "txt"+i+"' type='#" + uniqueId + "3dtxt' style='position:absolute;left:"+txt_X+"px;top:"+txt_Y+"px;z-index:20;display:none;width:50; height:18;' fillcolor='#ffffff'"
        result += " onmouseover='ontxt(" + uniqueId + "cake"+i+","+(table_Top+all_Height/14)+"," + uniqueId + "txt"+i+"," + uniqueId + "pieRec"+i+")'>"
        result += " <v:fill opacity='60293f' color2='fill lighten(120)' o:opacity2='60293f' rotate='t' angle='-135' method='linear sigma' focus='100%' type='gradient'/>"
        result += " <v:textpath style='font-family:'宋体';v-text-kern:t' trim='t' fitpath='t' string='"+(pie[i]*100).toFixed(2)+"%'/>"
        result += " <o:extrusion v:ext='view' backdepth='8pt' on='t' lightposition='0,0' lightposition2='0,0'/>"
        result += " </v:shape>" 
        result += " </div>"
        
        k1 = k1 + k2 * 2;
        if(k1 >=360)
        {
            k1 = k1 - 360;
        }
        if(k1 > 180)
        {
            k4 = k4 + 1;
        }
        else
        {
            k4 = k4 - 1;
        }
    }
    
    return result;
}

//功能函数
//对m的第n位四舍五入
function Round(m,n)
{
    return Math.round(Math.pow(10,n)*m)*Math.pow(10,-n);
}

onit=true
num=0
function moveup(iteam,top,txt,rec)
{
    temp=eval(iteam)
    tempat=eval(top)
    temptxt=eval(txt)
    temprec=eval(rec)
    at=parseInt(temp.style.top)
    temprec.style.display = ""; 
    if (num>27)
    {
        temptxt.style.display = "";
    }
    if(at>(tempat-28)&&onit)
    {
        num++
    temp.style.top=at-1
    Stop=setTimeout("moveup(temp,tempat,temptxt,temprec)",10)
    }
    else
    {
        return
    } 
}

function movedown(iteam,top,txt,rec)
{
    temp=eval(iteam)
    temptxt=eval(txt)
    temprec=eval(rec)
    clearTimeout(Stop)
    temp.style.top=top
    num=0
    temptxt.style.display = "none";
    temprec.style.display = "none";
}

function ontxt(iteam,top,txt,rec)
{
    temp = eval(iteam);
    temptxt = eval(txt);
    temprec = eval(rec)
    if (onit)
    {
        temp.style.top = top-28;
        temptxt.style.display = "";
        temprec.style.display = "";
    }
}

function movereset(over)
{
    if (over==1)
    {
        onit=false
    }
    else
    {
        onit=true
    }
}


