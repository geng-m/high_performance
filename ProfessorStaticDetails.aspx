<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProfessorStaticDetails.aspx.cs"
    Inherits="ProfessorStatic" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>院士信息统计</title>
    <script src="resource/jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="resource/jquery/exporting.js" type="text/javascript"></script>
    <script src="resource/jquery/highcharts-zh_CN.js" type="text/javascript"></script>
    <script src="resource/jquery/highcharts.js" type="text/javascript"></script>
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
    <div style="float: right; width: 85%; position: relative; top: 20px;">
        <div style="float: left; width: 50%; height: 100%">
            <div id="div_gender" style="width: 100%; height: 28px; left: 0px">
                Gender
            </div>
            <div id="container_gender" style="min-width: 310px; height: 480px; top: 80px">
            </div>
        </div>
        <div style="float: right; width: 50%; height: 100%;right:5%">
            <div id="div1" style="width: 100%; height: 28px; left: 0px">
                Abord
            </div>
            <div id="container_abord" style="min-width: 310px; height: 480px; top: 80px">
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function begin_show() {
            var data_gender = JsonNoParameter("webServices/ShowStaticServices.asmx/getProfessorsStaticGender");
            var data_abord = JsonNoParameter("webServices/ShowStaticServices.asmx/getProfessorsStaticAbord");
            show_gender(data_gender);
            show_abord(data_abord);
        }
        function show_gender(jsonDate) {
            var result = [];
            var sum = 0;
            for (var i = 0; i < 2; i++) {
                result.push(i);
            }
            $.each(jsonDate.d, function (index, element) {
                d = element.split(",");
                result[index] += parseInt(d[1]);
                sum += parseInt(d[1]);
            });
            var chart = Highcharts.chart('container_gender', {
                title: {
                    text: '工程院院士性别分布饼状统计图'
                },
                tooltip: {
                    headerFormat: '{series.name}<br>',
                    pointFormat: '{point.name}: <b>{point.percentage:.1f}%</b>'
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,  // 可以被选择
                        cursor: 'pointer',       // 鼠标样式
                        dataLabels: {
                            enabled: true,
                            format: '<b>{point.name}</b>: {point.percentage:.1f} %',
                            style: {
                                color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'gray'
                            }
                        }
                    }
                },
                series: [{
                    type: 'pie',
                    name: '不同性别占比',
                    data: [
            {
                name: '女',
                y: Number(result[0] / sum),
                sliced: true,  // 默认突出
                selected:true
            },
            ['男', Number(result[1] / sum)]
        ]
                }]
            });
        }
        function show_abord(jsonDate) {
            var result = [];
            var sum = 0;
            for (var i = 0; i < 2; i++) {
                result.push(i);
            }
            $.each(jsonDate.d, function (index, element) {
                d = element.split(",");
                result[index] += parseInt(d[1]);
                sum += parseInt(d[1]);
            });
            var chart = Highcharts.chart('container_abord', {
                title: {
                    text: '工程院院士留学布饼状统计图'
                },
                tooltip: {
                    headerFormat: '{series.name}<br>',
                    pointFormat: '{point.name}: <b>{point.percentage:.1f}%</b>'
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,  // 可以被选择
                        cursor: 'pointer',       // 鼠标样式
                        dataLabels: {
                            enabled: true,
                            format: '<b>{point.name}</b>: {point.percentage:.1f} %',
                            style: {
                                color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'gray'
                            }
                        }
                    }
                },
                series: [{
                    type: 'pie',
                    name: '是否留学占比',
                    data: [
            {
                name: 'N',
                y: Number(result[0] / sum),
                sliced: true,  // 默认突出
                selected: true
            },
            ['Y', Number(result[1] / sum)]
        ]
                }]
            });
        }
    </script>
</body>
</html>
