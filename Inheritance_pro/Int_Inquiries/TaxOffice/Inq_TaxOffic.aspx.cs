using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ers_Pro.App_Code.Intd_Lts;
using ShamsiDateTime;

namespace Ers_Pro.Int_Inquiries.TaxOffice
{
    public partial class Inq_TaxOffic : System.Web.UI.Page
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
            (Master.FindControl("Lbl_Title") as Label).Text = "استعلام از اداره امور مالیاتی";
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
                Chk_Estates.Items.Clear();
                return;
            }
            Session["Classe"] = Txt_Klasse.Text.Trim();

            Tb_Dead1 = Lts_Inherited.Tb_Deads.SingleOrDefault(n => n.xDedId_pk == Tb_Files1.xDedId_fk);
            Lbl_DedName.Text = Tb_Dead1.xDedFName + " " + Tb_Dead1.xDedLName;
            Lbl_DedNationalcode.Text = Tb_Dead1.xDedNationalCode;

            List<Tb_Estate> Lst_Estates = Lts_Inherited.Tb_Estates.Where(n => n.xDedId_fk == Tb_Dead1.xDedId_pk
                && (n.Tb_EstateType.xEstType.Contains("مغازه") || n.Tb_EstateType.xEstType.Contains("خانه") || n.Tb_EstateType.xEstType.Contains("زمین"))).ToList();
            Chk_Estates.Items.Clear();

            foreach (Tb_Estate item in Lst_Estates)
            {
                Chk_Estates.Items.Add(new ListItem(item.Tb_EstateType.xEstType + "(" + item.xEstDescription.Substring(0, item.xEstDescription.Length < 10 ? item.xEstDescription.Length : 10) + "..." + ")", item.xEstId_pk.ToString()));
            }
            Btn_Sodor.Enabled = true;
        }

        protected void Btn_Sodor_Click(object sender, EventArgs e)
        {
            if (Lts_Inherited.Tb_Inquiries.SingleOrDefault(n => n.Tb_InquiryType.xInqType.Contains("مالیات") && n.xDedId_fk == Tb_Dead1.xDedId_pk) != null)
            {
                Lbl_Msg.Text = "!استعلام صادر گردیده است";
                Lbl_Msg.Visible = true;
                Lbl_Msg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            Tb_InquiryType Tb_InquiryType1 = Lts_Inherited.Tb_InquiryTypes.SingleOrDefault(n => n.xInqType.Contains("مالیات"));

            Tb_Inquiry Tb_Inquiry1 = new Tb_Inquiry();
            Tb_Inquiry1.Tb_Dead = Tb_Dead1;
            //Tb_Inquiry1.xInqDate = Class_ShamsiDateTime.MilladiToShamsi(DateTime.Now.Date).ToString();
            Tb_Inquiry1.xInqDate = Tdp_InqDate.Date;
            Tb_Inquiry1.xInqRegNo = Txt_InqNo.Text;
            Tb_Inquiry1.Tb_InquiryType = Tb_InquiryType1;
            Lts_Inherited.Tb_Inquiries.InsertOnSubmit(Tb_Inquiry1);

            foreach (ListItem EstItem in Chk_Estates.Items)
                if (EstItem.Selected)
                {
                    Tb_InqEstate Tb_InqEstate1 = new Tb_InqEstate();
                    Tb_InqEstate1.Tb_Inquiry = Tb_Inquiry1;
                    Tb_InqEstate1.xEstId_fk = int.Parse(EstItem.Value);
                    Lts_Inherited.Tb_InqEstates.InsertOnSubmit(Tb_InqEstate1);
                }
            try
            {
                Lts_Inherited.SubmitChanges();
                Session["Office_DeadId"] = Tb_Dead1.xDedId_pk.ToString();
                Session["Office_InqDate"] = Tb_Inquiry1.xInqDate;
                Session["Office_InqNo"] = Tb_Inquiry1.xInqRegNo;
                Session["Office_Name"] = Txt_Office.Text;
                Session["Office_EstateId"] = null;
                foreach (ListItem EstItem in Chk_Estates.Items)
                    if (EstItem.Selected)
                        Session["Office_EstateId"] += EstItem.Value + "&";
                Response.Redirect("~/Int_Inquiries/TaxOffice/Rpt_TaxOffice.aspx", true);
            }
            catch
            {
                Alarm.ShowMesseage("!خطا", this.Page);
            }

        }
    }
}