using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ers_Pro.App_Code.Intd_Lts;

namespace Ers_Pro.Master
{
    public partial class MainMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Tb_User Tb_User1 = null;
            try
            {
                Tb_User1 = Session["Glb_Tb_User"] as Tb_User;
                Lbl_User.Text = Tb_User1.xUserFName +" "+ Tb_User1.xUserLName;
            }
            catch
            {
                Response.Redirect("~/Login.aspx?");
            }
            //Session.Timeout
        }
        protected void IBtn_Sabt_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void IBtn_Admin_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void Ibtn_Exit_Click(object sender, ImageClickEventArgs e)
        {
            Session["Glb_Tb_User"] = null;
            Session.RemoveAll();
            Response.Redirect("~/Login.aspx?");
        }
    }
}