//用于前后台数据交互
function dataForJson(url, dataJson) {
    var json;
  
    $.ajax({
        type: "POST",
        url: url,
        data: dataJson,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false, //如果要在$.ajax外面获取ajax获取到的值，则ajax必须获得同步
        success: function (msg) {
            json = msg;
        }
    });
    return json;
}

//下拉列表制作
function getList(id, url, dataJson) {
    var json = dataForJson(url, dataJson);
    var html = "";
    $.each(json.d, function (index, element) {
        html += "<option value='" + element.code + "'>" + element.description + "</option>";
    });
    $("#" + id).empty().append(html);
}
function getList3(id, url, dataJson) {
    var json = dataForJson(url, dataJson);
    var html = "<option value='0'>全部</option>";
    $.each(json.d, function (index, element) {
        html += "<option value='" + element.code + "'>" + element.description + "</option>";
    });
    $("#" + id).empty().append(html);
}
function getList4(id, url, dataJson) {
    var json = dataForJson(url, dataJson);
    var html = "<option value='0'>全部</option>";
    $.each(json.d, function (index, element) {
        html += "<option value='" + element.code + "'>" + element.description + "</option>";
      

    });
    $("#" + id).empty().append(html);
}
function getList2(id, url, dataJson) {
    var json = dataForJson(url, dataJson);
    var html = "";
    $.each(json.d, function (index, element) {
        html += "<option value='" + element.code + "'>" + element.description + "</option>";
    });
    $("#" + id).empty().append(html);
}



//用于前后台数据交互 没有参数
function JsonNoParameter(url) {
    var json;
    $.ajax({
        type: "POST",
        url: url,
        //data: dataJson,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false, //如果要在$.ajax外面获取ajax获取到的值，则ajax必须获得同步
        success: function (msg) {
            json = msg;
        }
    });
    return json;
}


//统计形式选择
function countTypeSelect() {
    var typeSelect = $("#CountType").val();
    var endTime = new Date();
    var startTime = "";
    if (typeSelect == 1) {
        startTime = new Date(endTime.getTime() - 1000 * 60 * 60 * 24 * 1);
    } else if (typeSelect == 2) {
        startTime = new Date(endTime.getTime() - 1000 * 60 * 60 * 24 * 7);
    } else {
        startTime = new Date(endTime.getTime() - 1000 * 60 * 60 * 24 * preMonthDays());
    }
    $("#startTime").val(CurentTime(startTime));
    $("#endTime").val(CurentTime(endTime));
}


//返回当前一个月的前一个月的天数
function preMonthDays() {
    var days = 0; //时间
    var date = new Date();

    switch (date.getMonth()) {
        case 1:
            days = 31;
            break;
        case 2:
            days = 31;
            break;
        case 3:
            if (isRunYear(date.getYear())) {
                days = 29;
            } else {
                days = 28;
            }
            break;
        case 4:
            days = 31;
            break;
        case 5:
            days = 30;
            break;
        case 6:
            days = 31;
            break;
        case 7:
            days = 30;
            break;
        case 8:
            days = 31;
            break;
        case 9:
            days = 31;
            break;
        case 10:
            days = 30;
            break;
        case 11:
            days = 31;
            break;
        case 12:
            days = 30;
            break;
    }

    return days;
}

function isRunYear(year) {
    if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0) {
        return true;
    } else {
        return false;
    }
}


//若要显示:当前日期加时间(如:2009/06/12 12:00:00)

function CurentTime(now) {

    var year = now.getFullYear();       //年
    var month = now.getMonth() + 1;     //月
    var day = now.getDate();            //日

    var hh = now.getHours();            //时
    var mm = now.getMinutes();          //分
    var ss = now.getSeconds();          //秒
    var clock = "";


    if (month < 10) {
        clock = year + "/" + "0" + month + "/";
    } else {
        clock = year + "/" + month + "/";
    }

    if (day < 10)
        clock += "0";

    clock += day + " ";

    if (hh < 10)
        clock += "0";

    clock += hh + ":";

    if (mm < 10)
        clock += '0';

    clock += mm + ":";

    if (ss < 10)
        clock += '0';

    clock += ss;

    return (clock);
}



//用于折线图切换的动画效果 第一部分
//2013年8月28日
//ZhaoYifan
function chartschange1() {
    $('#container0').slideUp("slow");
    $("#butSearch").attr('disabled', true);
}

//用于折线图切换的动画效果 第二部分
//2013年8月28日
//ZhaoYifan
function chartschange2() {
    setTimeout(function () {
        $('#container0').slideDown("quick");
    }, 1000);
    setTimeout(function () {
        $("#butSearch").attr('disabled', false);
    }, 1300);

}
//获取当前年月日及星期 （如：2013年9月6日 星期五）
function CurentTime2() {
    var week;
    var time;
    if (new Date().getDay() == 0) week = "星期日"
    if (new Date().getDay() == 1) week = "星期一"
    if (new Date().getDay() == 2) week = "星期二"
    if (new Date().getDay() == 3) week = "星期三"
    if (new Date().getDay() == 4) week = "星期四"
    if (new Date().getDay() == 5) week = "星期五"
    if (new Date().getDay() == 6) week = "星期六"
    time = new Date().getFullYear() + "年" + (new Date().getMonth() + 1) + "月" + new Date().getDate() + "日 " + week;
    return time;
}