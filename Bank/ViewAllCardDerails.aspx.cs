using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Bank_ViewAllCardDerails : System.Web.UI.Page
{
    public string ConnString = WebConfigurationManager.ConnectionStrings["connect"].ConnectionString;
    public SqlCommand cmd = new SqlCommand();
    public SqlConnection Conn = new SqlConnection();
    SqlDataReader red;
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
        SqlDataAdapter adp = new SqlDataAdapter("select Name,Accno,Address,Aadharno,Gender,MailID,Phoneno,Status,CreateDate from  [dbo].[AccountDetails] where CreateBy =" + Session["UserID"].ToString() + "", Conn);
        ds = new DataSet();
        adp.Fill(ds);
        grdView.DataSource = ds;
        grdView.DataBind();

        Conn.Close();
    }


    protected void grdView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.TableSection = TableRowSection.TableHeader;
    }

    private DataTable GetData(SqlCommand cmd)

    {
        DataTable dt = new DataTable();
        String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        SqlDataAdapter sda = new SqlDataAdapter();
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;
        try
        {
            con.Open();
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
            sda.Dispose();
            con.Dispose();
        }

    }

    protected void btnExcel_Click(object sender, EventArgs e)
    {
        string strQuery = "select Name,Accno,Address,Aadharno,Gender,MailID,Phoneno,Status,CreateDate from  [dbo].[AccountDetails] where CreateBy =" + Session["UserID"].ToString() + "";
        SqlCommand cmd = new SqlCommand(strQuery);
        DataTable dt = GetData(cmd);
        GridView GridView1 = new GridView();
        GridView1.AllowPaging = false;
        GridView1.DataSource = dt;
        GridView1.DataBind();

        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=DataTable.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);

        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            GridView1.Rows[i].Attributes.Add("class", "textmode");
        }

        GridView1.RenderControl(hw);
        string style = @"<style> .textmode { mso-number-format:\@; } </style>";
        Response.Write(style);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }

    protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "UnLock")
        {
            string getUserid_id = Convert.ToString(e.CommandArgument);

            try
            {
                Conn = new SqlConnection(ConnString);
                Conn.Open();
                Random rand = new Random();
                string UserName = rand.Next(9999, 99999).ToString();
                string Password = rand.Next(9999, 99999).ToString();

                string qry = "update AccountDetails set status='Activated' where Accno='" + getUserid_id + "'";
                cmd = new SqlCommand(qry, Conn);
                cmd.ExecuteNonQuery();

                Conn.Close();
                
                grid();
            }
            catch (Exception ex)
            {

            }

        }
        else if (e.CommandName == "Block")
        {
            string getUserid_id = Convert.ToString(e.CommandArgument);

            try
            {
                Conn = new SqlConnection(ConnString);
                Conn.Open();
                string qry = "update AccountDetails set status='Blocked' where Accno='" + getUserid_id + "'";
                cmd = new SqlCommand(qry, Conn);
                cmd.ExecuteNonQuery();

                Conn.Close(); grid();
            }
            catch (Exception ex)
            {

            }

        }
    }

    public void SendEmail(string recepientEmail, string subject, string body)
    {
        using (MailMessage mailMessage = new MailMessage())
        {
            mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["UserName"]);
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = true;
            mailMessage.To.Add(new MailAddress(recepientEmail));
            SmtpClient smtp = new SmtpClient();
            smtp.Host = ConfigurationManager.AppSettings["Host"];
            smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
            System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
            NetworkCred.UserName = ConfigurationManager.AppSettings["UserName"];
            NetworkCred.Password = ConfigurationManager.AppSettings["Password"];
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]);
            smtp.Send(mailMessage);
        }
    }
}