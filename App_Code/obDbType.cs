using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Collections;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Security;
using System.Web.Security;

/// <summary>
/// obDbType 的摘要说明
/// </summary>
public class obDbType
{
	public obDbType()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    #region 获取Bigint参数
    public static SqlParameter GetParamBigint(string paramName, long paramValue)
    {

        SqlParameter objParam;
        objParam = new SqlParameter(paramName, SqlDbType.BigInt);
        objParam.Value = paramValue;
        return objParam;

    }
    #endregion

    #region 获取Float参数
    public static SqlParameter GetParamFloat(string paramName, float paramValue)
    {

        SqlParameter objParam;
        objParam = new SqlParameter(paramName, SqlDbType.Float);
        objParam.Value = paramValue;
        return objParam;

    }
    #endregion

    #region 获取Double参数
    public static SqlParameter GetParamDouble(string paramName, double paramValue)
    {

        SqlParameter objParam;
        objParam = new SqlParameter(paramName, SqlDbType.Decimal);
        objParam.Value = paramValue;
        return objParam;

    }
    #endregion

    #region 获取Varchar参数
    public static SqlParameter GetParamVarchar(string paramName, string paramValue)
    {

        SqlParameter objParam;
        objParam = new SqlParameter(paramName, SqlDbType.VarChar);
        objParam.DbType = DbType.String;
        objParam.Value = paramValue;
        return objParam;

    }
    #endregion

    #region 获取Text参数
    public static SqlParameter GetParamText(string paramName, string paramValue)
    {

        SqlParameter objParam;
        objParam = new SqlParameter(paramName, SqlDbType.Text);
        objParam.Value = paramValue;
        return objParam;

    }
    #endregion

    #region 获取DateTime参数
    public static SqlParameter GetParamDateTime(string paramName, DateTime paramValue)
    {

        SqlParameter objParam;
        objParam = new SqlParameter(paramName, SqlDbType.DateTime);
        objParam.Value = paramValue;
        return objParam;

    }
    #endregion

    #region 获取Image参数
    public static SqlParameter GetParamImage(string paramName, byte[] paramValue)
    {

        SqlParameter objParam;
        objParam = new SqlParameter(paramName, SqlDbType.Image);
        objParam.Value = paramValue;
        return objParam;

    }
    #endregion

    #region 获取返回参数
    public static SqlParameter GetParamOutput(string paramName)
    {

        SqlParameter objParam;
        objParam = new SqlParameter(paramName, SqlDbType.BigInt);
        objParam.Direction = ParameterDirection.Output;
        return objParam;

    }
    #endregion

    #region 获取字符串返回参数
    public static SqlParameter GetParamOutputVarchar(string paramName,int paramLen)
    {

        SqlParameter objParam;
        objParam = new SqlParameter(paramName, SqlDbType.VarChar,paramLen);
        objParam.DbType = DbType.String;
        objParam.Direction = ParameterDirection.Output;
        return objParam;

    }
    #endregion

    #region 获取Int参数
    public static SqlParameter GetParamInt(string paramName, int paramValue)
    {

        SqlParameter objParam;
        objParam = new SqlParameter(paramName, SqlDbType.Int);
        objParam.Value = paramValue;
        return objParam;

    }
    #endregion

    #region 获取bool参数
    public static SqlParameter GetParamBool(string paramName, bool paramValue)
    {

        SqlParameter objParam;
        objParam = new SqlParameter(paramName, SqlDbType.Bit);
        objParam.Value = paramValue;
        return objParam;

    }
    #endregion



}
