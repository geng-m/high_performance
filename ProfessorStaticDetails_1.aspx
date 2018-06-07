<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProfessorStaticDetails_1.aspx.cs"
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
    <div style="float: right; width: 85%; position: relative; top: 20px;right:8px">
        <div style="float: left; width: 50%; height: 100%">
            <div id="div_gender" style="width: 100%; height: 28px; left: 0px">
                
            </div>
            <div id="container_higheste" style="min-width: 310px; height: 480px; top: 80px">
            </div>
        </div>
        <div style="float: right; width: 50%; height: 100%;right:5%">
            <div id="div1" style="width: 100%; height: 28px; left: 0px">
                
            </div>
            <div id="container_awardtime" style="min-width: 310px; height: 480px; top: 80px;left:20px">
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function begin_show() {
            var data_higheste = JsonNoParameter("webServices/ShowStaticServices.asmx/getProfessorsStaticHighestE");
            var data_awardtime = JsonNoParameter("webServices/ShowStaticServices.asmx/getProfessorsStaticAwardTime");
            show_HighestE(data_higheste);
            show_awardtime(data_awardtime);
        }
        function show_awardtime(jsonDate) {
            var result = "[";
            $.each(jsonDate.d, function (index, element) {
                d = element.split(",");
                result = result + "[" + d[0] + "," + d[1] + "],";
            });
            result = result.substr(0, result.length - 1) + "]";
            
            result = eval(result);
            var chart = Highcharts.chart('container_awardtime', {
                chart: {
                    type: 'column'
                },
                title: {
                    text: '工程院院士获奖时间分布柱状统计图'
                },
                subtitle: {
                    text: 'Homework'
                },
                xAxis: {
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
                    data:result,
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
        function show_HighestE(jsonDate) {
            var result = [];
            var sum = 0;
            for (var i = 0; i < 4; i++) {
                result.push(i);
            }
            $.each(jsonDate.d, function (index, element) {
                d = element.split(",");
                result[index] += parseInt(d[1]);
                sum += parseInt(d[1]);
            });
            var chart = Highcharts.chart('container_higheste', {
                title: {
                    text: '工程院院士最高学位分布饼状统计图'
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
                    name: '不同最高学位占比',
                    data: [
            {
                name:'doctor',
                y: Number(result[0] / sum),
                sliced: true,  // 默认突出
                selected:true
            },
            ['master', Number(result[1] / sum)],
            ['bactor', Number(result[2] / sum)],
            ['other', Number(result[3] / sum)]
        ]
                }]
            });
        }

        
    </script>
</body>
</html>
