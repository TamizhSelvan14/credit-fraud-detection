using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class User_HackerList : System.Web.UI.Page
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
        //SqlDataAdapter adp = new SqlDataAdapter("select H.Cardno,H.UserName,H.DateTime,H.Amount,H.DeviceId,H.Wrong_Password,H.Pin_Tried,H.OTP_Tried,H.OTP2_Tried,H.IP_Address from HackerList H join Creditcard C on H.Cardno = C.Cardno  join AccountDetails A on c.Accno = A.Accno union select H.Cardno,H.UserName,H.DateTime,H.Amount,H.DeviceId,H.Wrong_Password,H.Pin_Tried,H.OTP_Tried,H.OTP2_Tried,H.IP_Address  from HackerList H join AccountDetails A on H.UserName = A.UserName where A.id = '" + Session["UserID"].ToString() + "'", Conn);
       
        SqlDataAdapter adp = new SqlDataAdapter("select H.Cardno,H.DateTime,H.Amount,H.DeviceId,H.OTP_Tried,H.IP_Address from HackerList H join Creditcard C on H.Cardno = C.Cardno  join AccountDetails A on c.Accno = A.Accno union select H.Cardno,H.DateTime,H.Amount,H.DeviceId,H.OTP_Tried,H.IP_Address from HackerList H join AccountDetails A on H.UserName = A.UserName where A.id = '" + Session["UserID"].ToString() + "'", Conn);
        
        st = new DataSet();
        adp.Fill(st);
        grdView.DataSource = st;
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
        string strQuery = "select H.Cardno,H.DateTime,H.Amount,H.DeviceId,H.OTP_Tried,H.IP_Address from HackerList H join Creditcard C on H.Cardno = C.Cardno  join AccountDetails A on c.Accno = A.Accno union select H.Cardno,H.DateTime,H.Amount,H.DeviceId,H.OTP_Tried,H.IP_Address from HackerList H join AccountDetails A on H.UserName = A.UserName where A.id = '" + Session["UserID"].ToString() + "'";
        SqlCommand cmd = new SqlCommand(strQuery,Conn);
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
}