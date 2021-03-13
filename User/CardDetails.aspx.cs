using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_CardDetails : System.Web.UI.Page
{

    public string ConnString = WebConfigurationManager.ConnectionStrings["connect"].ConnectionString;
    public SqlCommand cmd = new SqlCommand();
    public SqlConnection Conn = new SqlConnection();
    public SqlDataReader dr;
    DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            grid();
        }
    }
    protected void grid()
    {
        Conn = new SqlConnection(ConnString);
        Conn.Open();
        SqlDataAdapter adp = new SqlDataAdapter("select *  from[dbo].[Creditcard] C join AccountDetails A on c.Accno = A.Accno where A.id = " + Session["UserID"].ToString() + "", Conn);
        ds = new DataSet();
        adp.Fill(ds);
        lblAccno.Text = ds.Tables[0].Rows[0]["Accno"].ToString();
        lblCardNo.Text = ds.Tables[0].Rows[0]["Cardno"].ToString();
        lblCard_limit.Text = ds.Tables[0].Rows[0]["Card_limit"].ToString();
        lblCvvNo.Text = ds.Tables[0].Rows[0]["CVVno"].ToString();
        lblExp_date.Text = ds.Tables[0].Rows[0]["Exp_date"].ToString();
        lblGiven_date.Text = ds.Tables[0].Rows[0]["Given_date"].ToString();


        Conn.Close();
    }
}