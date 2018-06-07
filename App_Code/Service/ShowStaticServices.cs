using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Collections;
using System.Data;
using HAQS_Enter;

/// <summary>
///ShowStaticServices 的摘要说明
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
//若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。 
[System.Web.Script.Services.ScriptService]
public class ShowStaticServices : System.Web.Services.WebService {

    public ShowStaticServices () {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
    public ArrayList getProfessorsStatic()//全部显示
    {
        ArrayList objs = new ArrayList();
        string select = "SELECT *FROM (SELECT t.birthday,COUNT(t.birthday)AS number FROM (SELECT datepart(yy,Birthday) AS birthday FROM dbo.T_professorMessage WHERE Birthday<'2000') AS t GROUP BY t.birthday) AS result ORDER BY result.birthday ASC";
        DataTable dt = SqlHelper.GetTable(select);
        foreach (DataRow dr in dt.Rows)
        {
            objs.Add(dr["birthday"] + "," + dr["number"]);
        }
        return objs;
    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
    public ArrayList getProfessorsStaticGender()//全部显示
    {
        ArrayList objs = new ArrayList();
        string select = "select Gender,count(Gender)AS number from dbo.T_professorMessage group by Gender";
        DataTable dt = SqlHelper.GetTable(select);
        foreach (DataRow dr in dt.Rows)
        {
            objs.Add(dr["Gender"] + "," + dr["number"]);
        }
        return objs;
    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
    public ArrayList getProfessorsStaticAbord()//全部显示
    {
        ArrayList objs = new ArrayList();
        string select = "select Abord,count(Abord)AS number from dbo.T_professorMessage group by Abord";
        DataTable dt = SqlHelper.GetTable(select);
        foreach (DataRow dr in dt.Rows)
        {
            objs.Add(dr["Abord"] + "," + dr["number"]);
        }
        return objs;
    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
    public ArrayList getProfessorsStaticHighestE()//全部显示
    {
        ArrayList objs = new ArrayList();
        string select = "SELECT HightestE,COUNT(HightestE) AS number FROM dbo.T_professorMessage GROUP BY HightestE;";
        DataTable dt = SqlHelper.GetTable(select);
        foreach (DataRow dr in dt.Rows)
        {
            objs.Add(dr["HightestE"] + "," + dr["number"]);
        }
        return objs;
    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
    public ArrayList getProfessorsStaticAwardTime()//全部显示
    {
        ArrayList objs = new ArrayList();
        string select = "SELECT AwardTime,COUNT(AwardTime)AS number FROM dbo.T_professorMessage GROUP BY AwardTime";
        DataTable dt = SqlHelper.GetTable(select);
        foreach (DataRow dr in dt.Rows)
        {
            objs.Add(dr["AwardTime"] + "," + dr["number"]);
        }
        return objs;
    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
    public ArrayList getProfessorsStaticHeatmap()//全部显示
    {
        Dictionary<string, int> result = new Dictionary<string, int>();
        string provinces = "北京,天津,上海,重庆,河北,山西,辽宁,吉林,黑龙江,江苏,浙江,安徽,福建,江西,山东,河南,湖北,湖南,广东,海南,四川,贵州,云南,陕西,甘肃,青海,台湾，内蒙古,广西,西藏,宁夏,新疆,香港,澳门";
        string[] p = provinces.Split(',');
        for (int i = 0; i < p.Length;i++ ) {
            result.Add(p[i],0);
        }
        ArrayList objs = new ArrayList();
        string select = "SELECT Jiguan FROM dbo.T_professorMessage;";
        DataTable dt = SqlHelper.GetTable(select);
        foreach (DataRow dr in dt.Rows)
        {
            foreach (string key in result.Keys)
            {
                if(dr["Jiguan"].ToString().Contains(key)){
                    result[key] += 1;
                    break;
                }
            }  
        }
        foreach(string key in result.Keys){
            objs.Add(key + ',' + Convert.ToString(result[key]));
        }
        return objs;
    }
}
