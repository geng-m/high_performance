using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace HAQS_Enter
{

    /// <summary>
    /// SqlHelper 的摘要说明
    /// </summary>
    public abstract class SqlHelper
    {

        #region 定义变量
        public static readonly string strConn = "server=.;user id=sa;password=gmsa;database=High_Performance";
        public static string GetConnStr()
        {
            return strConn;
        }

        #endregion

        #region 检索单值
        //*****************************************************************************************//
        /// <summary>
        /// 从数据库中检索单个非数值型数据
        /// </summary>
        /// <author name="sky"></author>
        /// <createtime value="2002/08/03"></createtime>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        public static string GetStr(string strSQL)
        {
            string strTmp;
            SqlConnection objConn = new SqlConnection(strConn);
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandText = strSQL;
            objCmd.CommandType = CommandType.Text;

            objConn.Open();
            strTmp = Convert.ToString(objCmd.ExecuteScalar());
            objConn.Close();

            return strTmp;
        }

        //*****************************************************************************************//
        /// <summary>
        ///从数据库中检索单个数值型数据 
        /// </summary>
        /// <author name="sky"></author>
        /// <createtime value="2002/08/03"></createtime>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        public static int GetInt(string strSQL)
        {
            int intTmp;

            SqlConnection objConn = new SqlConnection(strConn);
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandText = strSQL;
            objCmd.CommandType = CommandType.Text;

            objConn.Open();
            intTmp = Convert.ToInt32(objCmd.ExecuteScalar());
            objConn.Close();
            return intTmp;
        }
        /// <summary>
        ///从数据库中检索单个数值型数据 
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        public static long GetLong(string strSQL)
        {
            long nRet;
            SqlConnection objConn = new SqlConnection(strConn);

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandText = strSQL;
            objCmd.CommandType = CommandType.Text;

            objConn.Open();
            nRet = Convert.ToInt64(objCmd.ExecuteScalar());
            objConn.Close();
            return nRet;
        }

        //*****************************************************************************************//

        /// <summary>
        /// 检索数据库中数据的数量
        /// </summary>
        /// <author name="sky"></author>
        /// <createtime value="2003/09"></createtime>
        /// <param name="strSQL">SQL语句</param>
        /// <returns></returns>

        public static int GetCount(string strSQL)
        {
            //王双宝2013年8月13日修改
            int intTmp;
            SqlConnection objConn = new SqlConnection(strConn);

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandText = strSQL;
            objCmd.CommandType = CommandType.Text;

            objConn.Open();
            intTmp = System.Convert.ToInt32(objCmd.ExecuteScalar());
            objConn.Close();

            return intTmp;
        }
        /// <summary>
        /// Lw添加
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        public static int GetCount2(string strSQL)
        {
            int intTmp;
            SqlConnection objConn = new SqlConnection(strConn);
            SqlCommand objCmd = new SqlCommand(strSQL, objConn);
            SqlDataAdapter da = new SqlDataAdapter(objCmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            objConn.Open();
            intTmp = dt.Rows.Count;
            objConn.Close();
            return intTmp;
        }
        #endregion

        #region 检索记录集
        //*****************************************************************************************//
        /// <summary>
        /// DataSet获取数据
        /// </summary>
        /// <author name="sky"></author>
        /// <createtime value="2002/08/03"></createtime>
        /// <param name="strSQL"></param>
        /// <param name="strTblName"></param>
        /// <returns></returns>
        public static DataSet GetDS(string strSQL, string strTblName)
        {
            SqlConnection objConn = new SqlConnection(strConn);

            DataSet objTmp = new DataSet();
            SqlDataAdapter objAdapter = new SqlDataAdapter(strSQL, objConn);
            objConn.Open();
            objAdapter.Fill(objTmp, strTblName);
            objConn.Close();
            return objTmp;

        }

        /// <summary>
        /// DataSet获取数据
        /// </summary>
        /// <author name="sky"></author>
        /// <param name="strSQL"></param>
        /// <param name="StartIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="strTblName"></param>
        /// <returns></returns>
        public static DataSet GetDS(string strSQL, int StartIndex, int PageSize, string strTblName)
        {
            SqlConnection objConn = new SqlConnection(strConn);

            DataSet objTmp = new DataSet();
            SqlDataAdapter objAdapter = new SqlDataAdapter(strSQL, objConn);
            objConn.Open();
            objAdapter.Fill(objTmp, StartIndex, PageSize, strTblName);
            objConn.Close();
            return objTmp;
        }

        /// <summary>
        /// 获取DataSet数据
        /// </summary>
        /// <param name="ProcName"></param>
        /// <returns></returns>
        public static DataSet GetDS(string ProcName)
        {

            SqlConnection objConn = new SqlConnection(strConn);
            SqlCommand objCmd = new SqlCommand(ProcName, objConn);
            objCmd.CommandType = CommandType.StoredProcedure;

            DataSet objTmp = new DataSet();
            SqlDataAdapter objAdapter = new SqlDataAdapter(objCmd);
            objConn.Open();
            objAdapter.Fill(objTmp);
            objConn.Close();
            return objTmp;

        }

        /// <summary>
        /// 获取DataSet数据
        /// </summary>
        /// <param name="ProcName"></param>
        /// <param name="objArray"></param>
        /// <returns></returns>
        public static DataSet GetDS(string ProcName, ArrayList objArray)
        {

            SqlConnection objConn = new SqlConnection(strConn);
            SqlCommand objCmd = new SqlCommand(ProcName, objConn);
            objCmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < objArray.Count; i++)
            {
                objCmd.Parameters.Add(objArray[i]);
            }

            DataSet objTmp = new DataSet();
            SqlDataAdapter objAdapter = new SqlDataAdapter(objCmd);
            objConn.Open();
            objAdapter.Fill(objTmp);
            objConn.Close();
            return objTmp;

        }
        #endregion

        #region 检索单条数据

        /// <summary>
        /// DataRow获取单条数据
        /// </summary>
        /// <author name="chido"></author=chido>
        /// <createtime value="2002/08/03"></createtime>
        /// <param name="strSQL">SQL语句</param>
        public static DataRow GetRow(string strSQL)
        {
            DataRow objTmp;
            DataTable dt = new DataTable();
            SqlConnection objConn = new SqlConnection(strConn);

            SqlDataAdapter objAdapter = new SqlDataAdapter(strSQL, objConn);
            objConn.Open();
            objAdapter.Fill(dt);
            objTmp = dt.NewRow();
            if (dt.Rows.Count >= 1)
            {
                objTmp = dt.Rows[0];
            }
            else
            {
                objTmp = null;
            }
            objConn.Close();

            return objTmp;
        }
        #endregion

        #region 检索数据表
        //*****************************************************************************************//
        /// <summary>
        /// DataTable获取数据
        /// </summary>
        /// <author name="tangjia"></author>
        /// <createtime value="2003/03/28"></createtime>

        /// <returns>DataTable</returns>
        public static DataTable GetTable(string strSQL)
        {
            DataTable objTmp = new DataTable();
            SqlConnection objConn = new SqlConnection(strConn);
            SqlDataAdapter objAdapter = new SqlDataAdapter(strSQL, objConn);
            objConn.Open();
            objAdapter.Fill(objTmp);
            objConn.Close();
            return objTmp;

        }

        public static DataTable GetTable(string procName, ArrayList objArray)
        {

            DataTable objTmp = new DataTable();
            SqlConnection objConn = new SqlConnection(strConn);
            SqlDataAdapter objAdapter = new SqlDataAdapter(procName, objConn);

            SqlCommand objCmd = new SqlCommand(procName, objConn);
            objCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objCmd;
            for (int i = 0; i < objArray.Count; i++)
            {
                objCmd.Parameters.Add(objArray[i]);
            }

            objConn.Open();
            objAdapter.Fill(objTmp);
            objConn.Close();
            return objTmp;
        }

        /// <summary>
        /// 获取DataSet数据
        /// </summary>
        /// <param name="ProcName"></param>
        /// <returns></returns>
        public static DataTable GetTableProc(string ProcName)
        {

            SqlConnection objConn = new SqlConnection(strConn);
            SqlCommand objCmd = new SqlCommand(ProcName, objConn);
            objCmd.CommandType = CommandType.StoredProcedure;

            DataTable objTmp = new DataTable();
            SqlDataAdapter objAdapter = new SqlDataAdapter(objCmd);
            objConn.Open();
            objAdapter.Fill(objTmp);
            objConn.Close();
            return objTmp;

        }

        #endregion

        #region 检索指定集合一列值
        /// <summary>
        /// 获取一列值
        /// </summary>
        /// <param name="strSQL"></param>
        /// <param name="strFld"></param>
        /// <param name="aryVal"></param>
        public static string GetFldVal(string strSQL, string strFld, ref string[] aryVal)
        {
            string strTmp;
            string strTmp2;
            int i = 0;
            strTmp = "";
            SqlDataReader objReader;
            SqlConnection objConn = new SqlConnection(strConn);
            SqlCommand objCmd = new SqlCommand(strSQL, objConn);
            objConn.Open();
            objReader = objCmd.ExecuteReader();
            while (objReader.Read())
            {
                strTmp2 = objReader[strFld].ToString();
                strTmp2 = strTmp2.Replace("|", "");
                if (i == 0)
                {
                    strTmp = strTmp2;
                }
                else
                {
                    strTmp = strTmp + "|" + strTmp2;
                }
                i++;
            }
            aryVal = strTmp.Split(Convert.ToChar("|"));

            objConn.Close();
            return strTmp;
        }

        #endregion

        #region 获取一对值
        public static Hashtable GetHash(string strSQL, string strKey, string strVal)
        {
            Hashtable objHash = new Hashtable();

            SqlDataReader objReader;
            SqlConnection objConn = new SqlConnection(strConn);
            SqlCommand objCmd = new SqlCommand(strSQL, objConn);
            objConn.Open();
            objReader = objCmd.ExecuteReader();
            while (objReader.Read())
            {
                objHash.Add(objReader[strKey].ToString(), objReader[strVal].ToString());
            }

            objConn.Close();
            return objHash;
        }
        #endregion

        #region 执行存储过程
        //*****************************************************************************************//
        /// <summary>
        /// 执行存储过程,不带参数,无返回值
        /// </summary>
        /// <author name="sky"></author>
        /// <createtime value="2002/08/03"></createtime>
        /// <param name="ProcName">存储过程名称</param>
        public static void ExecProc(string ProcName)
        {
            SqlConnection objConn = new SqlConnection(strConn);
            SqlCommand objCmd = new SqlCommand(ProcName, objConn);
            objConn.Open();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.ExecuteNonQuery();
            objConn.Close();

        }
        //*****************************************************************************************//
        /// <summary>
        /// 执行存储过程,带参数,无返回值
        /// </summary>
        /// <author name="sky"></author>
        /// <createtime value="2003/05/01"></createtime>
        /// <param name="ProcName">存储过程名称</param>

        public static void ExecProc(string ProcName, ArrayList objArray)
        {
            SqlConnection objConn = new SqlConnection(strConn);

            SqlCommand objCmd = new SqlCommand(ProcName, objConn);
            objConn.Open();
            objCmd.CommandType = CommandType.StoredProcedure;

            for (int i = 0; i < objArray.Count; i++)
            {
                objCmd.Parameters.Add(objArray[i]);
            }
            objCmd.ExecuteNonQuery();
            objConn.Close();

        }

        /// <summary>
        /// 执行存储过程,带参数,带返回值
        /// </summary>
        /// <author name="sky"></author>
        /// <createtime value="2003/05/01"></createtime>
        /// <param name="ProcName">存储过程名称</param>

        public static string ExecProc(string ProcName, ArrayList objArray, string ReturnName)
        {
            string nRet;
            SqlConnection objConn = new SqlConnection(strConn);

            SqlCommand objCmd = new SqlCommand(ProcName, objConn);
            objConn.Open();
            objCmd.CommandType = CommandType.StoredProcedure;

            for (int i = 0; i < objArray.Count; i++)
            {
                objCmd.Parameters.Add(objArray[i]);
            }
            objCmd.Parameters[ReturnName].Direction = ParameterDirection.Output;
            objCmd.ExecuteNonQuery();

            nRet = Convert.ToString(objCmd.Parameters[ReturnName].Value);
            objConn.Close();

            return nRet;
        }
        /// <summary>
        /// 执行存储过程,带参数,带返回值,带返回状态
        /// </summary>
        /// <author name="sky"></author>
        /// <createtime value="2003/05/01"></createtime>
        /// <param name="ProcName">存储过程名称</param>

        public static void ExecProc(string ProcName, ArrayList objArray, ref string returnValue, ref string returnStatus)
        {
            SqlConnection objConn = new SqlConnection(strConn);

            SqlCommand objCmd = new SqlCommand(ProcName, objConn);
            objConn.Open();
            objCmd.CommandType = CommandType.StoredProcedure;

            for (int i = 0; i < objArray.Count; i++)
            {
                objCmd.Parameters.Add(objArray[i]);
            }
            
            objCmd.ExecuteNonQuery();

            returnStatus = Convert.ToString(objCmd.Parameters[returnStatus].Value);
            returnValue = Convert.ToString(objCmd.Parameters[returnValue].Value);

            objConn.Close();
        }
        /// <summary>
        /// 执行存储过程,无参数,带返回值,带返回状态
        /// 地图自用 误删
        /// </summary>
        /// <author name="yht"></author>
        /// <createtime value="2003/05/01"></createtime>
        /// <param name="ProcName">存储过程名称</param>
        public static DataTable ExecProcForMap(string ProcName)
        {
            SqlConnection objConn = new SqlConnection(strConn);
            SqlCommand objCmd = new SqlCommand(ProcName, objConn);
            objConn.Open();
            objCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Da = new SqlDataAdapter(objCmd);
            DataTable dt = new DataTable();
            Da.Fill(dt);
            objConn.Close();
            return dt;
        }
        /// <summary>
        /// 执行存储过程,有参数,带返回值,带返回状态
        /// 地图自用 误删
        /// </summary>
        /// <author name="yht"></author>
        /// <createtime value="2003/05/01"></createtime>
        /// <param name="ProcName">存储过程名称</param>
        public static DataTable ExecProcForMap(string ProcName, string Nid)
        {
            SqlConnection objConn = new SqlConnection(strConn);
            SqlCommand objCmd = new SqlCommand(ProcName, objConn);
            objConn.Open();
            objCmd.CommandType = CommandType.StoredProcedure;
            SqlParameter para= new SqlParameter("@Nid",Nid);
            objCmd.Parameters.Add(para);
            SqlDataAdapter Da = new SqlDataAdapter(objCmd);
            DataTable dt = new DataTable();
            Da.Fill(dt);
            objConn.Close();
            return dt;
        }
        #endregion

    }
}