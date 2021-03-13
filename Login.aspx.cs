using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Login : System.Web.UI.Page
{

    public string ConnString = WebConfigurationManager.ConnectionStrings["connect"].ConnectionString;
    public SqlCommand cmd = new SqlCommand();
    public SqlConnection Conn = new SqlConnection();
    public SqlDataReader dr;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (Request.QueryString["type"].ToString() == "user")
                {
                    hypRegister.Visible = true;
                }
            }
            catch (Exception)
            {

            }
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["type"].ToString().ToLower() == "admin")
        {
            if (txtUserName.Text.ToLower() == "admin" && txtPassword.Text.ToLower() == "admin")
            {
                Response.Redirect("Admin/Dashboard.aspx");
            }
        }
        else if (Request.QueryString["type"].ToString() == "bank")
        {
            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);

            cmd = new SqlCommand("select * from BankDetails where Username='" + txtUserName.Text + "' and Password='" + txtPassword.Text + "'", Conn);
            Conn.Open();
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {

                Session["UserID"] = dr["id"].ToString();
                Response.Redirect("Bank/Dashboard.aspx");

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "<script>alert('Access Denied.....You Are Entered Wrong UserId or Password');</script>", false);
            }

        }
        else if (Request.QueryString["type"].ToString() == "user")
        {
            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);

            cmd = new SqlCommand("select * from AccountDetails where Username='" + txtUserName.Text + "' and Password='" + txtPassword.Text + "'", Conn);
            Conn.Open();
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {

                Session["UserID"] = dr["id"].ToString();
                Session["Accno"] = dr["Accno"].ToString();
                dr.Close();
                Response.Redirect("User/Dashboard.aspx");
              

              
            }
            else
            {
                dr.Close();
                string qry = "insert into [HackerList] (UserName,DeviceId,Wrong_Password) values('" + txtUserName.Text + "','Browser','" + txtPassword.Text + "')";
                SqlCommand cmd2 = new SqlCommand(qry, Conn);
                cmd2.ExecuteNonQuery();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "<script>alert('Access Denied.....You Are Entered Wrong UserId or Password');</script>", false);
            }

        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {

    }
}