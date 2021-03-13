using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// Summary description for ConfigSettings
/// </summary>
public class ConfigSettings
{
 // public static string ConnString = WebConfigurationManager.ConnectionStrings["PuzzleSpace"].ConnectionString;

    public ConfigSettings()
    {
        //
        // TODO: Add constructor logic here
        //
    }
 
    public string SmsUserName { get { return WebConfigurationManager.AppSettings["SmsUserName"].ToString(); } }
    public string SmsPassword { get { return WebConfigurationManager.AppSettings["SmsPassword"].ToString(); } }
    public string SmsSenderIDPromotional { get { return WebConfigurationManager.AppSettings["SmsSenderIDPromotional"].ToString(); } }
    public string SmsSenderID { get { return WebConfigurationManager.AppSettings["SmsSenderID"].ToString(); } }
    public string SmsRoutePro { get { return WebConfigurationManager.AppSettings["SmsRoutePro"].ToString(); } }
    public string SmsRouteTran { get { return WebConfigurationManager.AppSettings["SmsRouteTran"].ToString(); } }
    public string SmsBegin { get { return WebConfigurationManager.AppSettings["SmsBegin"].ToString(); } }
    public string SmsSecond { get { return WebConfigurationManager.AppSettings["SmsSecond"].ToString(); } }
    public string SmsThird { get { return WebConfigurationManager.AppSettings["SmsThird"].ToString(); } }
    public string SmsFouth { get { return WebConfigurationManager.AppSettings["SmsFouth"].ToString(); } }
    public string SmsFifth { get { return WebConfigurationManager.AppSettings["SmsFifth"].ToString(); } }
    public string SmsLast { get { return WebConfigurationManager.AppSettings["SmsLast"].ToString(); } }
    public string SmsGetCredits { get { return WebConfigurationManager.AppSettings["SmsGetCredits"].ToString(); } }


  
}

