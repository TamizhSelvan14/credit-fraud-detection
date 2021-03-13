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
public partial class User_backupcode : System.Web.UI.Page
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


        Random ran = new Random();
        lblcode1.Text = ran.Next(1111, 999999).ToString();
        lblcode2.Text = ran.Next(1111, 999999).ToString();
        Conn = new SqlConnection(ConnString);
        Conn.Open();
        string qry = "insert into backupcode values('" + Session["Accno"].ToString() + "','" + lblcode1.Text + "', '" + lblcode2.Text + "' )";
        SqlCommand cmd2 = new SqlCommand(qry, Conn);
        cmd2.ExecuteNonQuery();
        lblMessage.Text = "backupcode Successfully Created.";
        lblMessage.ForeColor = System.Drawing.Color.Green;



        //string qry = "insert into Payment (Purchase_from,Cardno,DateTime,Amount) values('" + txtMachineId.Text + "','" + txtCardNo.Text + "','" + DateTime.Now.ToString() + "','" + txtPruchaseAmount.Text + "')";


        //Conn = new SqlConnection(ConnString);
        //Conn.Open();
        //SqlDataAdapter adp = new SqlDataAdapter("select *  from[dbo].[Creditcard] C join AccountDetails A on c.Accno = A.Accno where A.id = " + Session["UserID"].ToString() + "", Conn);
        //ds = new DataSet();
        //adp.Fill(ds);

        //lblcode1.Text = ds.Tables[0].Rows[0]["Accno"].ToString();
        //lblcode2.Text = ds.Tables[0].Rows[0]["Cardno"].ToString();
       


        Conn.Close();
    }

}