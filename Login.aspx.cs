using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_login_Click(object sender, EventArgs e)
    {
        string userandpasswd = Server.MapPath("./resource/UserAndPasswd.txt");
        StreamReader sr = File.OpenText(userandpasswd);
        String line;
        while ((line = sr.ReadLine()) != null)
        {
            string[] userinfo = line.Split(',');
            string userName = userinfo[0];
            string passWord = userinfo[1];
            if (this.txt_username.Text.Trim() == userName && this.txt_passwd.Text.Trim() == passWord)
            {
                Session["username"] = userName;
                Response.Redirect("ProfessorMessage.aspx");
            }
        }
        Response.Write("<script>alert('用户名或密码错误')</script>");
    }
   
}