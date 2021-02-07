using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ers_Pro.App_Code.Intd_Lts;
using ShamsiDateTime;

namespace Ers_Pro.Int_Inquiries.Bank
{
    public partial class Inq_Bank : System.Web.UI.Page
    {
        Alarm Alarm = new Alarm();
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
        public Tb_Dead Tb_Dead1
        {
            get { return Session[Str_PageId + "_Tb_Dead"] as Tb_Dead; }
            set { Session[Str_PageId + "_Tb_Dead"] = value; }
        }
        public Tb_User Tb_User1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Glb_Tb_User"] == null)
                Response.Redirect("~/Login.aspx");
            Tb_User1 = Session["Glb_Tb_User"] as Tb_User;
            (Master.FindControl("Lbl_Title") as Label).Text = "استعلام از بانک / موسسه";
            Txt_Hozeh.Text = Tb_User1.xUser_Hozeh;

            if (!IsPostBack)
            {
                if (Session["Classe"] != null)
                {
                    Txt_Klasse.Text = Session["Classe"].ToString();
                    Session.RemoveAll();
                    Session["Glb_Tb_User"] = Tb_User1;
                    Session["Classe"] = Txt_Klasse.Text;
                    Btn_Search_Click(sender, e);
                }
            }
        }

        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            if (Txt_Klasse.Text.Trim() == "" && !IsPostBack)
            {
                return;
            }
            if (Txt_Klasse.Text.Trim() == "")
            {
                Alarm.ShowMesseage("!کلاسه را وارد کنید", this.Page);
                Session["Classe"] = null;
                return;
            }


            Lts_Inherited = new Lts_InheritedDataContext();

            Tb_File Tb_Files1 = Lts_Inherited.Tb_Files.SingleOrDefault(n => n.xHozeh == Txt_Hozeh.Text & n.xClass == Txt_Klasse.Text);
            if (Tb_Files1 == null)
            {
                Alarm.ShowMesseage("!پرونده ای  وجود ندارد", this.Page);
                Session["Classe"] = null;
                Lbl_DedName.Text =
                    Lbl_DedNationalcode.Text = "";
                return;
            }
            Session["Classe"] = Txt_Klasse.Text.Trim();

            Tb_Dead1 = Lts_Inherited.Tb_Deads.SingleOrDefault(n => n.xDedId_pk == Tb_Files1.xDedId_fk);
            Lbl_DedName.Text = Tb_Dead1.xDedFName + " " + Tb_Dead1.xDedLName;
            Lbl_DedNationalcode.Text = Tb_Dead1.xDedNationalCode;
           
            Btn_Sodor.Enabled = true;
        }

        protected void Btn_Sodor_Click(object sender, EventArgs e)
        {
            if (Lts_Inherited.Tb_Inquiries.SingleOrDefault(n => n.Tb_InquiryType.xInqType.Contains("بانک") && n.xDedId_fk == Tb_Dead1.xDedId_pk) != null)
            {
                Lbl_Msg.Text = "!استعلام صادر گردیده است";
                Lbl_Msg.Visible = true;
                Lbl_Msg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            Tb_InquiryType Tb_InquiryType1 = Lts_Inherited.Tb_InquiryTypes.SingleOrDefault(n => n.xInqType.Contains("بانک"));

            Tb_Inquiry Tb_Inquiry1 = new Tb_Inquiry();
            Tb_Inquiry1.Tb_Dead = Tb_Dead1;
            //Tb_Inquiry1.xInqDate = Class_ShamsiDateTime.MilladiToShamsi(DateTime.Now.Date).ToString();
            Tb_Inquiry1.xInqDate = Tdp_InqDate.Date;
            Tb_Inquiry1.xInqRegNo = Txt_InqNo.Text;
            Tb_Inquiry1.Tb_InquiryType = Tb_InquiryType1;
            Lts_Inherited.Tb_Inquiries.InsertOnSubmit(Tb_Inquiry1);
           
            try
            {
                Lts_Inherited.SubmitChanges();
                Session["Bank_DeadId"] = Tb_Dead1.xDedId_pk.ToString();
                Session["Bank_InqDate"] = Tb_Inquiry1.xInqDate;
                Session["Bank_InqNo"] = Tb_Inquiry1.xInqRegNo;
                Session["Bank_Name"] = Txt_BankName.Text;
                Response.Redirect("~/Int_Inquiries/Bank/Rpt_Bank.aspx", true);
            }
            catch
            {
                Alarm.ShowMesseage("!خطا", this.Page);
            }

        }
    }
}