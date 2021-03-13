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


public partial class Register : System.Web.UI.Page
{

    public string ConnString = WebConfigurationManager.ConnectionStrings["connect"].ConnectionString;
    public SqlCommand cmd = new SqlCommand();
    public SqlConnection Conn = new SqlConnection();
    SqlDataReader red;

    DataSet st;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Conn = new SqlConnection(ConnString);
        Conn.Open();
        SqlDataAdapter adp = new SqlDataAdapter("select * from AccountDetails where Accno='" + txtAccountNo.Text.Trim() + "' and Phoneno='" + txtMobileNo.Text.Trim() + "' and Status is null", Conn);
        st = new DataSet();
        adp.Fill(st);

        if (st.Tables[0].Rows.Count == 0)
        {
            lblMessage.Text = "Account No Or Phone No Or request already raised";
            lblMessage.ForeColor = System.Drawing.Color.Red;
           

        }
        else
        {

            string qry = "update AccountDetails set status='Request Raised' where Accno='" + txtAccountNo.Text + "'";
            SqlCommand cmd2 = new SqlCommand(qry, Conn);
            cmd2.ExecuteNonQuery();
            lblMessage.Text = "Request raised successfully";
            lblMessage.ForeColor = System.Drawing.Color.Green;
            Conn.Close();
            txtAccountNo.Text = "";
            txtMobileNo.Text = "";
        }

    }
}