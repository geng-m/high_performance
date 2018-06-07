<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProfessorHeatMap.aspx.cs"
    Inherits="ProfessorStatic" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>院士信息统计</title>
    <script src="resource/jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="resource/jquery/highmaps.js" type="text/javascript"></script>
    <script src="resource/jquery/china.js" type="text/javascript"></script>
    <script src="resource/js/BaseForAjax.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="resource/themes/gray/easyui.css" />
    <link rel="stylesheet" type="text/css" href="resource/themes/icon.css" />
    <link rel="stylesheet" type="text/css" href="resource/css/demo.css" />
    <link rel="stylesheet" type="text/css" href="resource/css/style.css">
    <script type="text/javascript" src="resource/js/jquery.min.js"></script>
    <script type="text/javascript" src="resource/js/jquery.easyui.min.js"></script>
</head>
<body class="easyui-layout" onload="begin_show()">
    <div style="background-color: #5588AA; float: left; width: 13%; height: 100%">
        <ul>
            <li style="width: 193px; height: 20px"></li>
            <li style="width: 193px; height: 100px"><a href="ProfessorMessage.aspx" target="right"
                title="院士综合信息查询">
                <h1 style="font-family: 微软雅黑; font-size: 20px">
                    院士综合信息查询</h1>
            </a></li>
            <li style="width: 193px; height: 100px"><a href="ProfessorStatic.aspx" target="right"
                title="院士统计信息查询">
                <h1 style="font-family: 微软雅黑; font-size: 20px">
                    院士统计信息查询</h1>
            </a></li>
            <li style="width: 193px; height: 100px"><a href="ProfessorStaticDetails.aspx" target="right"
                title="院士统计detail查询">
                <h1 style="font-family: 微软雅黑; font-size: 20px">
                    院士统计信息查询_1</h1>
            </a></li>
            <li style="width: 193px; height: 100px"><a href="ProfessorStaticDetails_1.aspx" target="right"
                title="院士统计detail查询">
                <h1 style="font-family: 微软雅黑; font-size: 20px">
                    院士统计信息查询_2</h1>
            </a></li>
        </ul>
    </div>
    <div style="float: right; width: 85%; position: relative; top: 20px; background-color:Gray">
        <div id="container_map" style="min-width: 310px; height: 480px; top: 80px">
        </div>
    </div>
    <script type="text/javascript">
        function begin_show() {
            var data_map = JsonNoParameter("webServices/ShowStaticServices.asmx/getProfessorsStaticHeatmap");
            show_map(data_map);
        }
        function show_map(jsonDate) {
            var result = []

            $.each(jsonDate.d, function (index, element) {
                d = element.split(",");
                result[index] = d[1];
            });
            var map = new Highcharts.Map('container_map', {
                title: {
                    text: '院士出生地分布图'
                },
                colorAxis: {
                    min: 0,
                    minColor: 'rgb(255,255,255)',
                    maxColor: 'rgb(255,0,0)'
                },
                series: [{
                    data:[{ "name": "北京", "value": parseInt(result[0]) }, { "name": "天津", "value": parseInt(result[1]) } ,{ "name": "上海", "value": parseInt(result[2]) } ,{ "name": "重庆", "value": parseInt(result[3]) } ,{ "name":"河北", "value": parseInt(result[4]) } ,{ "name": "山西", "value": parseInt(result[5]) } ,{ "name": "辽宁", "value": parseInt(result[6]) } ,{ "name": "吉林", "value": parseInt(result[7]) } ,{ "name": "黑龙江", "value": parseInt(result[8]) } ,{ "name": "江苏", "value": parseInt(result[9]) } ,{ "name": "浙江", "value": parseInt(result[10]) } ,{ "name":"安徽", "value": parseInt(result[11]) } ,{ "name": "福建", "value": parseInt(result[12]) } ,{ "name": "江西", "value": parseInt(result[13]) } ,{ "name": "山东", "value": parseInt(result[14]) } ,{ "name": "河南", "value": parseInt(result[15]) } ,{ "name": "湖北", "value": parseInt(result[16]) } ,{ "name": "湖南", "value": parseInt(result[17]) } ,{ "name": "广东", "value": parseInt(result[18]) } ,{ "name": "海南", "value": parseInt(result[19]) } ,{ "name": "四川", "value": parseInt(result[20]) } ,{ "name": "贵州", "value": parseInt(result[21]) } ,{ "name": "云南", "value": parseInt(result[22]) } ,{ "name": "陕西", "value": parseInt(result[23]) } ,{ "name": "甘肃", "value": parseInt(result[24]) } ,{ "name": "青海", "value": parseInt(result[25]) } ,{ "name": "内蒙古", "value": parseInt(result[26]) } ,{ "name": "广西", "value": parseInt(result[27]) } ,{ "name": "西藏", "value": parseInt(result[28]) } ,{ "name": "宁夏", "value": parseInt(result[29]) } ,{ "name": "新疆", "value": parseInt(result[30]) } ,{ "name": "香港", "value": parseInt(result[31]) } ,{ "name": "澳门", "value": parseInt(result[32])}],
                    //data: [{ "name": "北京", "value" :34 }],
                    name: 'number',
                    mapData: Highcharts.maps['cn/china'],
                    joinBy: 'name' // 根据 name 属性进行关联
                }]
            });
        }
    </script>
</body>
</html>
