using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for Alarm
/// </summary>
/// 

public class Alarm
{
   
    public void ShowMesseage(string Str_Msg, Page page)
    {
        page.ClientScript.RegisterClientScriptBlock(this.GetType(), "UC_Alarm", "alert('" + Str_Msg + "')", true);
        if (!page.ClientScript.IsClientScriptBlockRegistered("UC_Alarm"))
            ScriptManager.RegisterClientScriptBlock(page, this.GetType(), "UC_Alarm", "alert('" + Str_Msg + "')", true);
    }
}

