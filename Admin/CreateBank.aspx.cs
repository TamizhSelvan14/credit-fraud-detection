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


public partial class Admin_CreateBank : System.Web.UI.Page
{
    public string ConnString = WebConfigurationManager.ConnectionStrings["connect"].ConnectionString;
    public SqlCommand cmd = new SqlCommand();
    public SqlConnection Conn = new SqlConnection();
    public SqlDataReader dr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindddl();
        }
    }

    private void bindddl()
    {

        Conn = new SqlConnection(ConnString);
        cmd = new SqlCommand("select * from BankList");
        cmd.CommandType = CommandType.Text;
        cmd.Connection = Conn;
        Conn.Open();
        ddlBankName.DataSource = cmd.ExecuteReader();
        ddlBankName.DataTextField = "Name";
        ddlBankName.DataValueField = "Id";
        ddlBankName.DataBind();
        ddlBankName.Items.Insert(0, new ListItem("- Select -", ""));
        ddlBankName.SelectedIndex = 0;
        Conn.Close();

    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtBranch.Text = "";
        txtIfsc.Text = "";
        bindddl();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            Conn = new SqlConnection(ConnString);
            cmd = new SqlCommand("select * from BankDetails where IfscCode='" + txtIfsc.Text.Trim() + "'", Conn);
            Conn.Open();
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                lblMessage.Text = "Ifsc Code already exist !!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                dr.Close();
            }
            else
            {
                dr.Close();
                Conn.Close();
                Conn.Open();
                string qry = "insert into BankDetails (BankName,IfscCode,Branch,UserName,Password) values('" + ddlBankName.SelectedValue + "','" + txtIfsc.Text + "','" + txtBranch.Text + "','" + txtUserName.Text.Trim() + "','" + txtpassword.Text.Trim() + "')";
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
}