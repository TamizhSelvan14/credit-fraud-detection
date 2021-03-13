using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Purchase : System.Web.UI.Page
{
    public string ConnString = WebConfigurationManager.ConnectionStrings["connect"].ConnectionString;
    public SqlCommand cmd = new SqlCommand();
    public SqlConnection Conn = new SqlConnection();
    SqlDataReader red;
    ConfigSettings _settings = new ConfigSettings();
    DataSet st;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string hostName = Dns.GetHostName(); // Retrive the Name of HOST  
            Console.WriteLine(hostName);
            // Get the IP  
            txtIpAddress.Text = Dns.GetHostByName(hostName).AddressList[0].ToString();

            Random rand = new Random();
            txtMachineId.Text = rand.Next(9999, 999999).ToString();

            grid();

        }
    }


    protected void grid()
    {
        Conn = new SqlConnection(ConnString);
        Conn.Open();
        SqlDataAdapter adp = new SqlDataAdapter("select *  from backupcode ", Conn);
        st = new DataSet();
        adp.Fill(st);
        lblbackcode1.Text = st.Tables[0].Rows[0]["FirstPassword"].ToString();
        lblbackcode2.Text = st.Tables[0].Rows[0]["SecondPassword"].ToString();
    
        Conn.Close();
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        txt1stPassword.Text = "";
        txt2stPassword.Text = "";
        txtCardNo.Text = "";
        txtPassword.Text = "";
        txtPruchaseAmount.Text = "";
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if ((txt2stPassword.Text == lbl2stPassword.Text) || (txt2stPassword.Text == lblbackcode2.Text))
        {
            try
            {
                Conn = new SqlConnection(ConnString);

                Conn.Close();
                Conn.Open();
                string qry = "insert into Payment (Purchase_from,Cardno,DateTime,Amount) values('" + txtMachineId.Text + "','" + txtCardNo.Text + "','" + DateTime.Now.ToString() +"','" + txtPruchaseAmount.Text + "')";
                SqlCommand cmd2 = new SqlCommand(qry, Conn);
                cmd2.ExecuteNonQuery();
                lblMessage.Text = "Purchased Successfully";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                Conn.Close();
                sendSMS(lblMobile.Text, "Purchase Successful for RS : " + txtPruchaseAmount.Text);

                btnClear_Click(sender, e);
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message.Replace("'", "");
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
            finally { Conn.Close(); }
        }
        else
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = "2 St Password incorrect";
            UpdatehackerListOTP2_Tried(txt2stPassword.Text);
        }
    }

    void Generate1StPssword()
    {
        
        
        //Conn.Open();
        Random ran = new Random();
        lbl1stPassword.Text = ran.Next(1111, 999999).ToString();
        string qry = "Update AccountDetails set FirstPassword='" + lbl1stPassword.Text + "' where accno='" + lblAccountNo.Text + "'";
        SqlCommand cmd2 = new SqlCommand(qry, Conn);
        cmd2.ExecuteNonQuery();
        lblMessage.Text = "First Password Successfully Created.";
        lblMessage.ForeColor = System.Drawing.Color.Green;
        sendSMS(lblMobile.Text, "Card 1 st Password : " + lbl1stPassword.Text);

    }

    void Generate2StPssword()
    {
        Conn = new SqlConnection(ConnString);
        Conn.Open();
        Random ran = new Random();

        lbl2stPassword.Text = ran.Next(1111, 999999).ToString();
        string qry = "Update AccountDetails set SecondPassword='" + lbl2stPassword.Text + "' where accno='" + lblAccountNo.Text + "'";
        SqlCommand cmd2 = new SqlCommand(qry, Conn);
        cmd2.ExecuteNonQuery();
        lblMessage.Text = "Second Password Successfully Created.";
        lblMessage.ForeColor = System.Drawing.Color.Green;
        sendSMS(lblmobilealt.Text, "Card 2 st Password : " + lbl2stPassword.Text);
    }


    protected void btnCheckPassword_Click(object sender, EventArgs e)
    {
        Conn = new SqlConnection(ConnString);
        Conn.Open();
        SqlDataAdapter adp = new SqlDataAdapter("Select A.Accno,A.status,A.Phoneno,A.altphoneno from AccountDetails A join Creditcard C on a.Accno = c.Accno where a.Password='" + txtPassword.Text + "'", Conn);
        st = new DataSet();
        adp.Fill(st);

        if (st.Tables[0].Rows.Count == 0)
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = "Password or Card Details incorrect";
            UpdatehackerListPin_Tried(txtPassword.Text);
        }
        else
        {
            if (st.Tables[0].Rows[0]["status"].ToString() != "Blocked")
            {
                lblAccountNo.Text = st.Tables[0].Rows[0]["Accno"].ToString();
                lblMobile.Text = st.Tables[0].Rows[0]["Phoneno"].ToString();

                lblmobilealt.Text = st.Tables[0].Rows[0]["altphoneno"].ToString();

                Generate1StPssword();
                txt1stPassword.Visible = true;
                btn1stPassword.Visible = true;
            }
            else
            {

                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Account is Block.Please contact Bank.";

            }
        }

        Conn.Close();
    }

    protected void btn1stPassword_Click(object sender, EventArgs e)
    {
        if ((txt1stPassword.Text == lbl1stPassword.Text) || (txt1stPassword.Text == lblbackcode1.Text))
        {
            Generate2StPssword();
            txt2stPassword.Visible = true;
            btnSubmit.Visible = true;
        }
        else
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = "1 St Password incorrect";
            UpdatehackerListOTP_Tried(txt1stPassword.Text);
        }
    }


    void UpdatehackerListPin_Tried(string pwd)
    {
        try
        {
            Conn = new SqlConnection(ConnString);

            Conn.Open();
            string qry = "insert into [HackerList] (Cardno,DateTime,Amount,DeviceId,Pin_Tried,IP_Address) values('" + txtCardNo.Text + "','" + DateTime.Now + "','" + txtPruchaseAmount.Text + "','" + txtMachineId.Text + "','" + pwd + "','" + txtIpAddress.Text + "')";
            SqlCommand cmd2 = new SqlCommand(qry, Conn);
            cmd2.ExecuteNonQuery();
            //lblMessage.Text = "Details Added Successfully";
            //lblMessage.ForeColor = System.Drawing.Color.Green;
            Conn.Close();

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message.Replace("'", "");
            lblMessage.ForeColor = System.Drawing.Color.Red;

        }
        finally { Conn.Close(); }
    }
    void UpdatehackerListOTP_Tried(string pwd)
    {
        try
        {
            Conn = new SqlConnection(ConnString);

            Conn.Open();
            string qry = "insert into [HackerList] (Cardno,DateTime,Amount,DeviceId,OTP_Tried,IP_Address) values('" + txtCardNo.Text + "','" + DateTime.Now + "','" + txtPruchaseAmount.Text + "','" + txtMachineId.Text + "','" + pwd + "','" + txtIpAddress.Text + "')";
            SqlCommand cmd2 = new SqlCommand(qry, Conn);
            cmd2.ExecuteNonQuery();
            //lblMessage.Text = "Details Added Successfully";
            //lblMessage.ForeColor = System.Drawing.Color.Green;
            Conn.Close();

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message.Replace("'", "");
            lblMessage.ForeColor = System.Drawing.Color.Red;

        }
        finally { Conn.Close(); }
    }
    void UpdatehackerListOTP2_Tried(string pwd)
    {
        try
        {
            Conn = new SqlConnection(ConnString);

            Conn.Open();
            string qry = "insert into [HackerList] (Cardno,DateTime,Amount,DeviceId,OTP2_Tried,IP_Address) values('" + txtCardNo.Text + "','" + DateTime.Now + "','" + txtPruchaseAmount.Text + "','" + txtMachineId.Text + "','" + pwd + "','" + txtIpAddress.Text + "')";
            SqlCommand cmd2 = new SqlCommand(qry, Conn);
            cmd2.ExecuteNonQuery();
            //lblMessage.Text = "Details Added Successfully";
            //lblMessage.ForeColor = System.Drawing.Color.Green;
            Conn.Close();

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message.Replace("'", "");
            lblMessage.ForeColor = System.Drawing.Color.Red;

        }
        finally { Conn.Close(); }
    }


    public string sendSMS(string MobileNo, string smsText)
    {
        string SmsStatusMsg = string.Empty;
        try
        {
            WebClient client = new WebClient();
            StringBuilder sb = new StringBuilder();

            sb.Append(_settings.SmsBegin);

            sb.Append(_settings.SmsUserName);
            sb.Append(_settings.SmsSecond);
            sb.Append(_settings.SmsPassword);
            sb.Append(_settings.SmsThird);
            sb.Append(_settings.SmsSenderIDPromotional);
            sb.Append(_settings.SmsFouth);
            sb.Append(_settings.SmsRoutePro);
            sb.Append(_settings.SmsFifth);
            sb.Append(MobileNo);

            sb.Append(_settings.SmsLast);
            sb.Append(smsText);

            string URL = sb.ToString();
            SmsStatusMsg = new TimedWebClient { Timeout = 600000 }.DownloadString(URL);

            string datetime = DateTime.Now.ToString("yyyyMMdd");

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[5] { new DataColumn("sms_Broadcast_id"), new DataColumn("sms_Status"), new DataColumn("sms_mobileNo"), new DataColumn("sms_text"), new DataColumn("sms_dateFormat") });
            string sentsmsList = MobileNo;
            string[] words = sentsmsList.Split(',');
            foreach (string MObileNo in words)
            {
                dt.Rows.Add("sss", null, MObileNo, smsText, datetime);
            }

            return "Message Sent Successful.";
        }
        catch (WebException e1)
        {
            return e1.Message + " " + "WebException" + " " + e1.InnerException;

        }
        catch (Exception e2)
        {
            return e2.Message + " " + "WebException" + " " + e2.InnerException;

        }
    }
}