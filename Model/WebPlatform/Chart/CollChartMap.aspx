<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CollChartMap.aspx.cs" Inherits="Chart_CollChartMap" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<STYLE>
v\:* { Behavior: url(#default#VML) }
o\:* { behavior: url(#default#VML) }
</STYLE>
<head runat="server">
<script src="js/chart1.3.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="div_Histogram"></div>
    <script language="javascript" type="text/javascript">
    //画柱状图
        function doChart() {
            var mychartArry = document.getElementById("hidCollChart").value;
            if (mychartArry != "") {
                var posArr = [];
                mychartArry = mychartArry.substring(0, mychartArry.length - 1);
                posArr = mychartArry.split('|');
                var histogram_Array = [];
                for (var i = 0; i < posArr.length; i++) {
                    var posXY = posArr[i].split(',');
                    histogram_Array[i] = [posXY[0], posXY[1], posXY[1] + '销量' + posXY[0] + '吨', '#'];
                }
                document.getElementById("div_Histogram").innerHTML = drawHistogram(histogram_Array, 0, 0, 650, 300, "", "", "吨", "div_Histogram");
            }
            else {
                document.getElementById("div_Histogram").innerHTML = "<img src=\"../Images/Default/pic.png\" width='650' height='300' style=\"background-repeat:repeat-x; background-repeat:repeat-y\" alt=\"当前没有煤炭销出\"  />";
            }
        }
    </script>

    <input id="hidCollChart" type="hidden" runat="server"/>
    </form>
</body>
</html>
