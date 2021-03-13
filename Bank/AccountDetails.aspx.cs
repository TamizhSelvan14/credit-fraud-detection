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

public partial class Bank_AccountDetails : System.Web.UI.Page
{

    public string ConnString = WebConfigurationManager.ConnectionStrings["connect"].ConnectionString;
    public SqlCommand cmd = new SqlCommand();
    public SqlConnection Conn = new SqlConnection();
    public SqlDataReader dr;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GenerateAccNo();
        }

    }

    void GenerateAccNo()
    {
        Random rnd = new Random();
        string fi1 = rnd.Next(11111, 99999).ToString();
        string fi2 = rnd.Next(11111, 99999).ToString();
        string fi3 = rnd.Next(11111, 99999).ToString();
        txtAccno.Text = fi1 + fi2 + fi3;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            Conn = new SqlConnection(ConnString);
            cmd = new SqlCommand("select * from [AccountDetails] where Phoneno='" + txtphone.Text + "' and Accno='" + txtAccno.Text + "'", Conn);
            Conn.Open();
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                lblMessage.Text = "Phone No already exist !!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                dr.Close();
            }
            else
            {
                dr.Close();
                Conn.Close();
                Conn.Open();
                string qry = "insert into [AccountDetails] (Name,Accno,Address,Aadharno,Gender,MailID,Phoneno,CreateBy) values('" + txtname.Text + "','" + txtAccno.Text + "','" + txtaddress.Text + "','" + txtadharno.Text + "','" + ddlGender.SelectedItem.Text + "','" + txtmailid.Text + "','" + txtphone.Text + "','" + Session["UserID"].ToString() + "')";
                SqlCommand cmd2 = new SqlCommand(qry, Conn);
                cmd2.ExecuteNonQuery();
                lblMessage.Text = "Details Added Successfully";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                Conn.Close();
                btnClear_Click(sender, e);

            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message.Replace("'", "");
            lblMessage.ForeColor = System.Drawing.Color.Red;

        }
        finally { Conn.Close(); }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtAccno.Text = "";
        txtaddress.Text = "";
        txtadharno.Text = "";
        txtmailid.Text = "";
        txtname.Text = "";
        txtphone.Text = "";
        GenerateAccNo();
    }
}