using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HAQS_Enter;
using System.Data;
using System.Collections;
using setusrinfo;
using Search;

public partial class DeviceMessage : System.Web.UI.Page
{ 
    int pageindex = 1;//初始化当前点击的页码值
    int pagesize = 12;//页面上显示的内容的条数
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["pageindex"] = pageindex;
            Session["pagesize"] = pagesize;
            GridBind(pageindex, pagesize);
            
        }
    }
    
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        pageindex = e.NewPageIndex;//获取点击的当前页码值
        Session["pageindex"] = pageindex;//记录当前点击的页码值，存储在session中

        GridBind(pageindex, pagesize);

    }

    public void GridBind(int pageindex, int pagesize) // 实现分页功能
    {
        pageindex = Convert.ToInt32(Session["pageindex"].ToString());
        DataTable dt;
        ArrayList objArray = new ArrayList();
        objArray.Add(obDbType.GetParamBigint("PageNo", pageindex));
        objArray.Add(obDbType.GetParamBigint("PageSize", pagesize));
        dt = SqlHelper.GetTable("prGetT_professorMessagePage", objArray);
        this.Gvlist.DataSource = dt;
        this.Gvlist.DataBind();
        if (dt.Rows.Count > 0)
        {
            this.AspNetPager1.RecordCount = int.Parse(dt.Rows[0]["total"].ToString());//总页数
        }
        this.AspNetPager1.PageSize = pagesize;//页面上显示的内容条数
    }
}