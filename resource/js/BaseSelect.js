// <summary>
// 用于<select>的选择、联动等
// </summary>
// <author name="ZhaoYifan"></author>
// <createtime value="2013/09/01"></createtime>


//绑定手术室等级下拉框
function OPClass() {
    var url = "../webservice/ajaxSelectService.asmx/selectOPClass";
    var json = JsonNoParameter(url).d;
    $.each(json, function (index, item) {
        $("#OPClass").append($("<option></option").val(item[0]).html(item[1]));
    });
}


//根据手术室级别级联
function changeOPClass() {
    var OPClass = $("#OPClass").val();
    var url = "../webservice/ajaxSelectService.asmx/selectOperationRoom";
    var data = "{'code':'" + OPClass + "'}";
    var json = dataForJson(url, data).d;
    $("#OperationRoomList").empty();
    $.each(json, function (index, item) {
        $("#OperationRoomList").append($("<option></option").val(item).html(item));
    });
}


//在选择气体时 只有手术台
function hideOPRound() {
    var PorG = $("#selectPG").val();
    if (PorG == 10) {
        $("#positionTypeId").empty().append("<option value='10'>手术台</option><option  value='11'>手术台周边</option>");
    } else {
        $("#positionTypeId").empty().append("<option value='99'>整体环境</option>")
    }
}


//颗粒物或气体的具体种类
function selectGPkind(code) {
    var url = "../webservice/ajaxSelectService.asmx/selectGPkind";
    var data = "{'code':'" + code + "'}";
    var json = json = dataForJson(url, data).d;
    $("#selectKind").empty();
    $.each(json, function (index, item) {
        $("#selectKind").append($("<option></option").val(item[0]).html(item[1]));
    });
}

//登录界面用户名下拉框（王双宝）
function SltUsername() {
    var url = "webservice/ajaxSelectService.asmx/selectUsername";
    var json = JsonNoParameter(url).d;
    $.each(json, function (index, item) {
        $("#aabb").append($("<option></option").val(item[1]).html(item[1]));
    });
}

