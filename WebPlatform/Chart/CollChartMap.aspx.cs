using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

public partial class Chart_CollChartMap : System.Web.UI.Page
{
   public DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetData();
        }
    }


    private void GetData()
    {

        string strSql = "select sum(NetWeight+OverWeight) as totalWeight,convert(varchar,year(WeightTime))+'.'+convert(varchar,month(WeightTime)) as ymonth "
                        + " from TT_LoadWeight where WeightTime <=getdate() and WeightTime>=Convert(datetime,dateadd(month,-12,getdate()),23) "
                        + " group by convert(varchar,year(WeightTime))+'.'+convert(varchar,month(WeightTime)) "
                        + " order by convert(datetime,convert(varchar,year(WeightTime))+'.'+convert(varchar,month(WeightTime))+'.'+'01') asc";

         ds = TDTK.IndustryPlatform.CoalTraffic.DBUtility.DbHelperSQL.Query(strSql);
         hidCollChart.Value = "";
         for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
         {   hidCollChart.Value += float.Parse(ds.Tables[0].Rows[i]["totalWeight"].ToString()) + "," + ds.Tables[0].Rows[i]["ymonth"].ToString() + ",产量统计,a.html" + "|";
         }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "", "doChart();", true);
    }

  
}
