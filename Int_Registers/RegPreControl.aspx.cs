using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ers_Pro.App_Code.Intd_Lts;

namespace Ers_Pro
{
    public partial class RegPreControl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Glb_Tb_User"] == null)
                Response.Redirect("~/Login.aspx");
            (Master.FindControl("Lbl_Title") as Label).Text = "بررسی قبل از ثبت";
        }

        protected void Btn_Search_Click(object sender, EventArgs e)
        {

            if(TxtNationalcode.Text.Trim()=="")
            {
                Lbl_Msg.Text = "کد ملی را وارد کنید!";
                Lbl_Msg.ForeColor = System.Drawing.Color.Red;
                Lbl_Msg.Visible = true;
                return;
            }

            Lts_InheritedDataContext Lts_Inherited=new Lts_InheritedDataContext();
            Tb_Dead Tb_Dead1 = Lts_Inherited.Tb_Deads.SingleOrDefault(n => n.xDedNationalCode == TxtNationalcode.Text.Trim());

            if (Tb_Dead1 != null)
            {
                Tb_File Tb_Files1 = Lts_Inherited.Tb_Files.SingleOrDefault(n => n.xDedId_fk == Tb_Dead1.xDedId_pk);
                Lbl_Msg.Text = "متوفی در حوزه مالیاتی " + Tb_Files1.xHozeh + "  وکلاسه " +
                    Tb_Files1.xClass + "دارای سابقه می باشد" +"!";
                Lbl_Msg.ForeColor = System.Drawing.Color.Red;
                Lbl_Msg.Visible = true;
            }
            else
            {
                Lbl_Msg.Text = "متوفی دارای سابقه نمی باشد" + "!";
                Lbl_Msg.ForeColor = System.Drawing.Color.Green;
                Lbl_Msg.Visible = true;
            }
        }
    }
}