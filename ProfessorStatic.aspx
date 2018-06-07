<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProfessorStatic.aspx.cs"
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
<body onload="begin_show()" class="easyui-layout">
    <div style="background-color:#5588AA; float: left; width: 13%; height: 100%">
        <ul>
            <li style="width: 193px; height: 20px"></li>
            <li style="width: 193px; height: 100px"><a href="ProfessorMessage.aspx"
                target="right" title="院士综合信息查询">
                <h1 style="font-family: 微软雅黑; font-size: 20px">
                    院士综合信息查询</h1>
            </a></li>
            <li style="width: 193px; height: 100px"><a href="ProfessorStatic.aspx"
                target="right" title="院士统计信息查询">
                <h1 style="font-family: 微软雅黑; font-size: 20px">
                    院士统计信息查询</h1>
            </a></li>
             <li style="width: 193px; height: 100px"><a href="ProfessorStaticDetails.aspx" target="right"
                title="院士统计detail查询">
                <h1 style="font-family: 微软雅黑; font-size: 20px; color:Gray">
                    院士统计信息查询_1</h1>
            </a></li>
            <li style="width: 193px; height: 100px"><a href="ProfessorStaticDetails_1.aspx" target="right"
                title="院士统计detail查询">
                <h1 style="font-family: 微软雅黑; font-size: 20px">
                    院士统计信息查询_2</h1>
            </a></li>
        </ul>
    </div>
    <div style="float:right;width: 85%; position: relative; top: 20px;">
        <div id="id_divSelect" style="width: 80%; height: 28px; left: 0px">
            选择类型：<select id="id_select" onchange="begin_show()">
                <option selected="selected" value="columns">columns</option>
                <option value="pie">pie</option>
            </select>
        </div>
        <div id="container" style="min-width: 310px; height: 480px; top: 80px">
        </div>
    </div>
    <script type="text/javascript">
        function begin_show() {
            var jsonDate = JsonNoParameter("webServices/ShowStaticServices.asmx/getProfessorsStatic");
            var option = $("#id_select option:selected").val();
            if (option == "columns") {
                show_columns(jsonDate);
            }
            else {
                show_pie(jsonDate);
            }
        }
        function show_pie(jsonDate) {
            var result = [];
            var sum = 0;
            for (var i = 0; i < 10; i++) {
                result.push(i);
            }
            $.each(jsonDate.d, function (index, element) {
                d = element.split(",");
                var index = parseInt((d[0] - 1900) / 10);
                result[index] += parseInt(d[1]);
                sum += parseInt(d[1]);
            });
            var chart = Highcharts.chart('container', {
                title: {
                    text: '工程院院士出生年份分布饼状统计图'
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
                                color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                            }
                        }
                    }
                },
                series: [{
                    type: 'pie',
                    name: '不同年龄段占比',
                    data: [
            {
                name: '1900-1909',
                y: Number(result[0] / sum),
                sliced: false  // 默认突出
            },
            ['1910-1919', Number(result[1] / sum)],
            ['1920-1929', Number(result[2] / sum)],
            {
                name: '1930-1939',
                y: Number(result[3] / sum),
                sliced: true,  // 默认突出
                selected: true // 默认选中 
            },
            ['1940-1949', Number(result[4] / sum)],
            ['1950-1959', Number(result[5] / sum)],
            ['1960-1969', Number(result[6] / sum)],
            ['1970-1979', Number(result[7] / sum)],
            ['1980-1989', Number(result[8] / sum)],
            ['1990-2000', Number(result[9] / sum)]
        ]
                }]
            });
        }
        function show_columns(jsonDate) {
            var result = "[";
            $.each(jsonDate.d, function (index, element) {
                d = element.split(",");
                result = result + "[" + d[0] + "," + d[1] + "],";
            });
            result = result.substr(0, result.length - 1) + "]";
            result = JSON.parse(result);
            var chart = Highcharts.chart('container', {
                chart: {
                    type: 'column'
                },
                title: {
                    text: '工程院院士出生年份分布柱状统计图'
                },
                subtitle: {
                    text: 'Homework'
                },
                xAxis: {
                    min: 1905,
                    title: {
                        text: 'year'
                    },
                    type: 'category',
                    labels: {
                        rotation: -45  // 设置轴标签旋转角度
                    }
                },
                yAxis: {
                    min: 0,
                    title: {
                        text: 'number'
                    }
                },
                legend: {
                    enabled: false
                },
                tooltip: {
                    pointFormat: 'number: <b>{point.y} 个</b>'
                },
                series: [{
                    name: '',
                    data: result,
                    dataLabels: {
                        enabled: true,
                        rotation: -90,
                        color: '#FFFFFF',
                        align: 'right',
                        y: 10
                    }
                }]
            });
        }
    </script>
</body>
</html>
