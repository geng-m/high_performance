using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net;
using System.IO;
using System.Text;
using System.Collections;
using System.Text.RegularExpressions;
using System.Threading;
using HAQS_Enter;

namespace Search
{
    /// <summary>
    /// obSearch 的摘要说明
    /// </summary>
    public class obUser
    {
        public obUser()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 判断是否管理员用户

        public static long IsValidAdminUser(string userName, string password)
        {
            long @nRet;

            ArrayList objArray = new ArrayList();

            password = obEncrypt.EncryptToMD5(password);//对密码进行加密，存入数据库中的密码是乱码的形式

            objArray.Add(obDbType.GetParamVarchar("@UserName", userName));
            objArray.Add(obDbType.GetParamVarchar("@Password", password));
            objArray.Add(obDbType.GetParamOutput("@nRet"));

            nRet = Convert.ToInt64(SqlHelper.ExecProc("prIsValidAdminUser", objArray, "@nRet"));
            return nRet;
        }
        #endregion

        #region 添加分站管理员
        public static void AddUser(
            string userName,
            string linkMan,
            string password,
            string linkPhone,
            long classId)
        {

            ArrayList objArray = new ArrayList();
            password = obEncrypt.EncryptToMD5(password);

            objArray.Add(obDbType.GetParamVarchar("@UserName", userName));
            objArray.Add(obDbType.GetParamVarchar("@LinkMan", linkMan));
            objArray.Add(obDbType.GetParamVarchar("@PassWord", password));
            objArray.Add(obDbType.GetParamVarchar("@LinkPhone", linkPhone));
            objArray.Add(obDbType.GetParamBigint("@ClassId", classId));

            SqlHelper.ExecProc("prInsT_User_Admin", objArray);

        }
        #endregion

        #region 修改分站管理员
        public static void UpdUser(
            long nid,
            string userName,
            string linkMan,
            string linkPhone,
            long classId)
        {

            ArrayList objArray = new ArrayList();

            objArray.Add(obDbType.GetParamBigint("@Nid", nid));
            objArray.Add(obDbType.GetParamVarchar("@UserName", userName));
            objArray.Add(obDbType.GetParamVarchar("@LinkMan", linkMan));
            objArray.Add(obDbType.GetParamVarchar("@LinkPhone", linkPhone));
            objArray.Add(obDbType.GetParamBigint("@ClassId", classId));

            SqlHelper.ExecProc("prUpdT_User_Admin", objArray);

        }
        #endregion

        #region 删除分站管理员
        public static void DelUser(
            long nid)
        {

            ArrayList objArray = new ArrayList();

            objArray.Add(obDbType.GetParamBigint("@Nid", nid));

            SqlHelper.ExecProc("prDelT_User_Admin", objArray);

        }
        #endregion

        #region 设定管理员密码

        public static void SetUserAdminPassword(long nid, string password)
        {

            ArrayList objArray = new ArrayList();

            password = obEncrypt.EncryptToMD5(password);

            objArray.Add(obDbType.GetParamBigint("@Nid", nid));
            objArray.Add(obDbType.GetParamVarchar("@Password", password));

            SqlHelper.ExecProc("prUpdAdminUserPassword", objArray);
        }

        #endregion

        #region 修改个人信息
        public static void UpdUserPersonal(
            long nid,
            string linkMan,
            string linkPhone)
        {

            ArrayList objArray = new ArrayList();

            objArray.Add(obDbType.GetParamBigint("@Nid", nid));
            objArray.Add(obDbType.GetParamVarchar("@LinkMan", linkMan));
            objArray.Add(obDbType.GetParamVarchar("@LinkPhone", linkPhone));

            SqlHelper.ExecProc("prUpdT_User_Admin_Personal", objArray);

        }
        #endregion
    
    }
}