using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Collections;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace HAQS_Enter
{
	/// <summary>
	/// obBind ��ժҪ˵����
	/// </summary>
	public class obBind
	{

		#region �������������
		public obBind()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		#endregion

		#region ��DropDownList
		/// <summary>
		///��Sql,ָ���ֶ�,Ĭ��ֵ"0"
		/// </summary>
		/// <param name="objTmp"></param>
		/// <param name="strValueField"></param>
		/// <param name="strTextField"></param>
		/// <param name="strSQL"></param>
		public static void BindDropDownList(DropDownList objTmp,string strValueField,string strTextField,string strSql)
		{
			
			objTmp.Items.Clear();
			DataSet ds=new DataSet();
            ds = SqlHelper.GetDS(strSql, "tblName");
			objTmp.DataSource=ds.Tables["tblName"];
			objTmp.DataValueField = strValueField;
			objTmp.DataTextField = strTextField;
			objTmp.DataBind();

		}
        public static void BindDropDownLists(DropDownList objTmp, string strSql)
        {

            objTmp.Items.Clear();
            DataSet ds = new DataSet();
            ds = SqlHelper.GetDS(strSql, "T_Dic_OperationRoom_Class");
            objTmp.DataSource = ds.Tables["T_Dic_OperationRoom_Class"].DefaultView;//.Columns [3].ColumnName ;
            objTmp.DataValueField = ds.Tables["T_Dic_OperationRoom_Class"].Columns[1].ColumnName;//strValueField;
            objTmp.DataTextField = ds.Tables["T_Dic_OperationRoom_Class"].Columns[3].ColumnName;//strTextField;
            objTmp.DataBind();


        }
        public static void BindDropDownListss(DropDownList objTmp, string strSql)
        {

            objTmp.Items.Clear();
            DataSet ds = new DataSet();
            ds = SqlHelper.GetDS(strSql, "T_Dic_CheckType");
            objTmp.DataSource = ds.Tables["T_Dic_CheckType"].DefaultView;//.Columns [3].ColumnName ;
            objTmp.DataValueField = ds.Tables["T_Dic_CheckType"].Columns[1].ColumnName;//strValueField;
            objTmp.DataTextField = ds.Tables["T_Dic_CheckType"].Columns[2].ColumnName;//strTextField;
            objTmp.DataBind();


        }
        public static void BindDropDownListsss(DropDownList objTmp, string strSql)
        {

            objTmp.Items.Clear();
            DataSet ds = new DataSet();
            ds = SqlHelper.GetDS(strSql, "T_Dic_CheckType");
            objTmp.DataSource = ds.Tables["T_Dic_CheckType"].DefaultView;//.Columns [3].ColumnName ;
            objTmp.DataValueField = ds.Tables["T_Dic_CheckType"].Columns[1].ColumnName;//strValueField;
            objTmp.DataTextField = ds.Tables["T_Dic_CheckType"].Columns[2].ColumnName;//strTextField;
            objTmp.DataBind();


        }
        public static void BindDropDownListssss(DropDownList objTmp, string strSql)
        {

            objTmp.Items.Clear();
            DataSet ds = new DataSet();
            ds = SqlHelper.GetDS(strSql, "T_OperationRoom");
            objTmp.DataSource = ds.Tables["T_OperationRoom"].DefaultView;//.Columns [3].ColumnName ;
            objTmp.DataValueField = ds.Tables["T_OperationRoom"].Columns[2].ColumnName;//strValueField;
            objTmp.DataTextField = ds.Tables["T_OperationRoom"].Columns[1].ColumnName;//strTextField;
            objTmp.DataBind();


        }
        public static void OperaRoomNoBind(DropDownList objTmp)
        {

            objTmp.Items.Clear();
            DataSet ds = new DataSet();
            ds = SqlHelper.GetDS("select OperationRoomNo from T_OperationRoom", "T_OperationRoom");
            objTmp.DataSource = ds.Tables["T_OperationRoom"].DefaultView;//.Columns [3].ColumnName ;
            objTmp.DataValueField = ds.Tables["T_OperationRoom"].Columns[0].ColumnName;//strValueField;
            objTmp.DataTextField = ds.Tables["T_OperationRoom"].Columns[0].ColumnName;//strTextField;
            objTmp.DataBind();


        }
        /// <summary>
        ///��Sql,ָ���ֶ�,Ĭ��ֵ"0"
        /// </summary>
        /// <param name="objTmp"></param>
        /// <param name="strValueField"></param>
        /// <param name="strTextField"></param>
        /// <param name="strSQL"></param>
        public static void BindDropDownListByDataTable(DropDownList objTmp, string strValueField, string strTextField,DataTable dt)
        {
            objTmp.Items.Clear();
            objTmp.DataSource = dt;
            objTmp.DataValueField = strValueField;
            objTmp.DataTextField = strTextField;
            objTmp.DataBind();

        }
        /// <summary>
        /// ��Sql,ָ���ֶ�,ѡ��ָ��ֵ��
        /// </summary>
        /// <param name="objTmp"></param>
        /// <param name="strValueField"></param>
        /// <param name="strTextField"></param>
        /// <param name="strSql"></param>
        /// <param name="strAddtionValue"></param>
        public static void BindDropDownListAddtion(DropDownList objTmp, string strValueField, string strTextField, string strSql, string strAddtionValue)
        {

            objTmp.Items.Clear();
            DataSet ds = new DataSet();
            ds = SqlHelper.GetDS(strSql, "tblName");
            objTmp.DataSource = ds.Tables["tblName"];
            objTmp.DataValueField = strValueField;
            objTmp.DataTextField = strTextField;
            objTmp.DataBind();

            objTmp.Items.Insert(0, new ListItem("��ѡ��", strAddtionValue));
            int i;
            int intLen;
            intLen = objTmp.Items.Count;
            for (i = 0; i < intLen; i++)
            {
                objTmp.Items[i].Selected = false;
            }
            for (i = 0; i < intLen; i++)
            {
                if (objTmp.Items[i].Value == strAddtionValue)
                    objTmp.Items[i].Selected = true;
            }

        }
        /// <summary>
        /// ��Sql,ָ���ֶ�,ѡ��ָ��ֵ��
        /// </summary>
        /// <param name="objTmp"></param>
        /// <param name="strValueField"></param>
        /// <param name="strTextField"></param>
        /// <param name="strSql"></param>
        /// <param name="strAddtionValue"></param>
        public static void BindDropDownListAddtion(DropDownList objTmp, string strValueField, string strTextField, string strSql, string strAddText,string strAddtionValue)
        {

            objTmp.Items.Clear();
            DataSet ds = new DataSet();
            ds = SqlHelper.GetDS(strSql, "tblName");
            objTmp.DataSource = ds.Tables["tblName"];
            objTmp.DataValueField = strValueField;
            objTmp.DataTextField = strTextField;
            objTmp.DataBind();

            objTmp.Items.Insert(0, new ListItem(strAddText, strAddtionValue));
            int i;
            int intLen;
            intLen = objTmp.Items.Count;
            for (i = 0; i < intLen; i++)
            {
                objTmp.Items[i].Selected = false;
            }
            for (i = 0; i < intLen; i++)
            {
                if (objTmp.Items[i].Value == strAddtionValue)
                    objTmp.Items[i].Selected = true;
            }

        }
		/// <summary>
		/// ��Sql,ָ���ֶ�,Ĭ��ֵ"**"
		/// </summary>
		/// <param name="objTmp"></param>
		/// <param name="strValueField"></param>
		/// <param name="strTextField"></param>
		/// <param name="strSql"></param>
		public static void BindDropDownListExt(DropDownList objTmp,string strValueField,string strTextField,string strSql)
		{
			objTmp.Items.Clear();
            DataTable dt;
            dt = SqlHelper.GetTable(strSql);
            objTmp.DataSource = dt;
			objTmp.DataValueField = strValueField;
			objTmp.DataTextField = strTextField;
			objTmp.DataBind();

		}

		/// <summary>
		/// ��ʼ��DropDownList,ѡ��ָ���� 
		/// </summary>
		/// <param name="objTmp"></param>
		/// <param name="strValue"></param>
		public static void InitDropDownList(DropDownList objTmp,string strValue)
		{
            for (int i = 0; i < objTmp.Items.Count; i++)
			{
                if (strValue == objTmp.Items[i].Value.ToString())
                    objTmp.Items[i].Selected = true;
                else
                {
                    objTmp.Items[i].Selected = false;
                }
			}
		}

        /// <summary>
        /// ѡ��ָ����(��������)
        /// </summary>
        /// <param name="objTmp"></param>
        /// <param name="nIndex"></param>
        public static void InitDropDownListFromIndex(DropDownList objTmp, int nIndex)
        {
            int intLen;
            intLen = objTmp.Items.Count;
            
            if (nIndex < intLen)
            {
                for (int i = 0; i < intLen; i++)
                {
                    objTmp.Items[i].Selected = false;
                }

                objTmp.Items[nIndex].Selected = true;
            }
        }
		/// <summary>
		/// ��ʼ��DropDownList,ѡ�е�һ��
		/// </summary>
		/// <param name="objTmp"></param>
		public static void InitDropDownList(DropDownList objTmp)
		{

			if (objTmp.Items.Count >0)
				objTmp.Items[0].Selected=true;
		}

		#endregion

		#region ��HtmlSelect
		//���ݰ�HtmlSelect
		public static void BindHtmlSelect(HtmlSelect objTmp,string strValueField,string strTextField,string strSql)
		{
			objTmp.Items.Clear();
            DataTable dt;
            dt = SqlHelper.GetTable(strSql);
            objTmp.DataSource = dt;
			objTmp.DataValueField = strValueField;
			objTmp.DataTextField = strTextField;
			objTmp.DataBind();
		}
		#endregion

		#region ��DataGrid

		/// <summary>
		/// ���ݰ� DataGrid 
		/// </summary>
		/// <param name="objTmp"></param>
		/// <param name="strSql"></param>
		public static void BindDataGridSql(DataGrid objTmp,string strSql)
		{
            DataTable dt;

            dt = SqlHelper.GetTable(strSql);
			if(dt.Rows.Count==objTmp.PageSize*objTmp.CurrentPageIndex)
			{
				if(objTmp.CurrentPageIndex!=0)
				{
					objTmp.CurrentPageIndex-=1;
				}
			} 			
			objTmp.DataSource=dt;
			objTmp.DataBind();
			
		}

		/// <summary>
		/// ΪDataGrid �趨���
		/// </summary>
		/// <param name="objTmp"></param>
		public static void SetDataGrid(DataGrid objTmp)
		{
			objTmp.AllowPaging =true;
			objTmp.PagerStyle.Mode = PagerMode.NextPrev;
			objTmp.PagerStyle.NextPageText = "��һҳ";
			objTmp.PagerStyle.PrevPageText = "��һҳ";
			objTmp.PageSize =10;
		}

		#endregion

        #region ��GridView
 
        public static void BindDataGridView(GridView objTmp, DataTable dt)
        {
            objTmp.DataSource = dt;
            objTmp.DataBind();
        }
        /// <summary>
        /// ���ݰ� GridView
        /// </summary>
        /// <param name="objTmp"></param>
        /// <param name="strSql"></param>
        public static void BindDataGridViewSql(GridView objTmp, string strSql)
        {

            DataTable dt;
            dt = SqlHelper.GetTable(strSql);

            objTmp.DataSource = dt;
            objTmp.DataBind();

        }



        #endregion

        #region ��DataList
        public static void BindDataListSql(DataList objTmp,string strSql)
		{
            DataTable dt;

            dt = SqlHelper.GetTable(strSql);

            objTmp.DataSource = dt;
			objTmp.DataBind();
			
		}

        public static void BindDataListPs(DataList dtList, DataTable dt, int pageSize, int currentPageIndex)
        {
            PagedDataSource ps = new PagedDataSource();
            ps.DataSource = dt.DefaultView;
            ps.AllowPaging = true;
            ps.PageSize = pageSize;
            ps.CurrentPageIndex = currentPageIndex;

            dtList.DataSource = ps;
            dtList.DataBind();
        }

        public static void BindDataList(DataList objTmp, DataTable dt)
        {
            objTmp.DataSource = dt;
            objTmp.DataBind();
        }

        public static int GetPageCount(DataTable dt, int pageSize)
        {
            int pageCount;
            PagedDataSource ps = new PagedDataSource();
            ps.DataSource = dt.DefaultView;
            ps.AllowPaging = true;
            ps.PageSize = pageSize;
            pageCount = ps.PageCount;
            return pageCount;
        }


		#endregion

		#region ��ListBox
		public static void BindListBoxSql(ListBox objTmp,string strValueField,string strTextField,string strSql)
		{
			objTmp.Items.Clear();
            DataTable dt;

            dt = SqlHelper.GetTable(strSql);
            objTmp.DataSource = dt;
			objTmp.DataValueField = strValueField;
			objTmp.DataTextField = strTextField;
			objTmp.DataBind();
		}

		/// <summary>
		/// ����б���
		/// </summary>
		/// <param name="objList"></param>
		/// <param name="strVal"></param>
		/// <param name="strText"></param>
		public static void AddListItem(ListControl objList,string strVal,string strText)
		{
			int intLen = objList.Items.Count;
			int nSign = 0;

			for(int i=0;i<intLen;i++)
			{
				if(objList.Items[i].Value==strVal)
					nSign = 1;
			}
			if (nSign==0)
			{
				ListItem objListItem = new ListItem(strText,strVal);
				objList.Items.Add(objListItem);
			}
		}
		/// <summary>
		/// ɾ���б���
		/// </summary>
		/// <param name="objList"></param>
		/// <param name="strVal"></param>
		public static void DelListItem(ListControl objList,string strVal)
		{

			int intLen = objList.Items.Count;
			int nPosition = -1;

			for(int i=0;i<intLen;i++)
			{
				if(objList.Items[i].Value==strVal)
					nPosition = i;
			}
			if(nPosition!=-1)
			{
				objList.Items.RemoveAt(nPosition);
			}
		}
		/// <summary>
		/// ��Ӷ���б���
		/// </summary>
		/// <param name="objList"></param>
		/// <param name="strVal"></param>
		/// <param name="strText"></param>
		/// <param name="strSql"></param>
		public static void AddListItems(ListControl objList,string strVal,string strText,string strSql)
		{
            DataTable dt;
            dt = SqlHelper.GetTable(strSql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                AddListItem(objList, dt.Rows[i][strVal].ToString(), dt.Rows[i][strText].ToString());
            }
		}
		#endregion

		#region ��CheckBoxList
/// <summary>
/// ��CheckBoxList
/// </summary>
/// <param name="objList"></param>
/// <param name="strValField"></param>
/// <param name="strTextField"></param>
/// <param name="strSql"></param>
		public static void BindCheckBoxList(CheckBoxList objList,string strValField,string strTextField,string strSql)
		{
			objList.Items.Clear();
            DataTable dt;
            dt = SqlHelper.GetTable(strSql);
            objList.DataSource = dt;
			objList.DataValueField = strValField;
			objList.DataTextField = strTextField;
			objList.DataBind();
		}
/// <summary>
/// �趨��ֵ
/// </summary>
/// <param name="objList"></param>
/// <param name="strValues"></param>
		public static void InitCheckBoxList(CheckBoxList objList,string[] strValues)
		{
			ListItem objItem;
			for(int i=0;i<strValues.Length;i++)
			{
				objItem = objList.Items.FindByValue(strValues[i]);
				objItem.Selected =true;
			}
		}
/// <summary>
/// ѡ��
/// </summary>
/// <param name="objList"></param>
		public static void InitCheckBoxListChecked(CheckBoxList objList)
		{
			foreach(ListItem objItem in objList.Items)
			{
				objItem.Selected =true;
			}
		}

/// <summary>
/// ��ȡCheckBoxListֵ
/// </summary>
/// <param name="srcCheckBoxList"></param>
/// <returns></returns>
        public static string GetCheckBoxListString(CheckBoxList srcCheckBoxList)
        {
            string nRet = "";
            ListItem item = new ListItem();
            for (int i = 0; i < srcCheckBoxList.Items.Count; i++)
            {
                item = srcCheckBoxList.Items[i];
                if (item.Selected == true)
                    if (nRet == "")
                        nRet = item.Value;
                    else
                        nRet = nRet + "," + item.Value;
            }
            return nRet;
        }
		#endregion

	}
}
