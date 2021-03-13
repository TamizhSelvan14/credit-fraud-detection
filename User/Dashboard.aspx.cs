using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class User_Dashboard : System.Web.UI.Page
{
    public string ConnString = WebConfigurationManager.ConnectionStrings["connect"].ConnectionString;
    public SqlCommand cmd = new SqlCommand();
    public SqlConnection Conn = new SqlConnection();
    SqlDataReader red;
    DataSet st;


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
        SqlDataAdapter adp = new SqlDataAdapter("select * from [dbo].[AccountDetails] where id=" + Session["UserID"].ToString() + "", Conn);
        st = new DataSet();
        adp.Fill(st);
        lblAccountNo.Text = st.Tables[0].Rows[0]["Accno"].ToString();
        lblStatus.Text = st.Tables[0].Rows[0]["Status"].ToString();

        Conn.Close();
    }

}