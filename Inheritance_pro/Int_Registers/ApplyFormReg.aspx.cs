using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ers_Pro.App_Code.Intd_Lts;

namespace Ers_Pro
{
    public partial class ApplyFormReg : System.Web.UI.Page
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
        public Tb_User Tb_User1;
        public Tb_File Tb_File1
        {
            get { return Session[Str_PageId + "_Tb_File"] as Tb_File; }
            set { Session[Str_PageId + "_Tb_File"] = value; }
        }
        public Tb_Apply Tb_Apply1
        {
            get { return Session[Str_PageId + "_Tb_Apply"] as Tb_Apply; }
            set { Session[Str_PageId + "_Tb_Apply"] = value; }
        }
        public Tb_Dead Tb_Dead1
        {
            get { return Session[Str_PageId + "_Tb_Dead"] as Tb_Dead; }
            set { Session[Str_PageId + "_Tb_Dead"] = value; }
        }

        public void ResetControl()
        {
            Txt_ShobeNo.Text =
            Txt_HasrNo.Text =
            Txt_Dadgah.Text =
            Txt_AppNo.Text =
            Txt_ApplyDate.Text=
            Txt_HasrDate.Text=
            Txt_CodeHoviati.Text = "";
            Btn_New.Visible = false;
            Hfld_Command.Value = "Save";
            Btn_Cancel.Visible = false;
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Glb_Tb_User"] == null)
                Response.Redirect("~/Login.aspx");
            Tb_User1 = Session["Glb_Tb_User"] as Tb_User;
            (Master.FindControl("Lbl_Title") as Label).Text = "ثبت اطلاعات فرم درخواست";
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

            #region ddl_Load
            if (!IsPostBack)
            {
                Txt_Hozeh.Text = Tb_User1.xUser_Hozeh;
            }
            #endregion
        }
        int DedId;
        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            if (Txt_ApplyDate.Text == "__/__/____" || Txt_HasrDate.Text == "__/__/____")
            {
                Alarm.ShowMesseage("!تاریخ را صحیح وارد نمایید", this.Page);
                return;
            }
            int int_Year = int.Parse(Txt_ApplyDate.Text.Substring(0, 4));
            int int_Mounth = int.Parse(Txt_ApplyDate.Text.Substring(5, 2));
            int int_Day = int.Parse(Txt_ApplyDate.Text.Substring(8, 2));
            if (int_Year < 1300 || int_Year > 1400 || int_Mounth == 00 || int_Mounth > 12 || int_Day == 00 || int_Day > 31)
            {
                Alarm.ShowMesseage("!تاریخ را صحیح وارد نمایید", this.Page);
                return;
            }
             int_Year = int.Parse(Txt_HasrDate.Text.Substring(0, 4));
             int_Mounth = int.Parse(Txt_HasrDate.Text.Substring(5, 2));
             int_Day = int.Parse(Txt_HasrDate.Text.Substring(8, 2));
            if (int_Year < 1300 || int_Year > 1400 || int_Mounth == 00 || int_Mounth > 12 || int_Day == 00 || int_Day > 31)
            {
                Alarm.ShowMesseage("!تاریخ را صحیح وارد نمایید", this.Page);
                return;
            }


            Tb_File1 = Lts_Inherited.Tb_Files.SingleOrDefault(n => n.xHozeh == Txt_Hozeh.Text & n.xClass == Txt_Klasse.Text);
            if(Tb_File1==null)
            {
                Alarm.ShowMesseage("کلاسه مورد نظر اشتباه است !",this.Page);
                return;
            }

            string Str_Msg = "";
            if(Hfld_Command.Value=="Save")
            {
                if (Lts_Inherited.Tb_Applies.SingleOrDefault(n => n.xDedId_fk == Tb_File1.xDedId_fk && n.xAppIsDeleted_==false) != null)
                {
                    Alarm.ShowMesseage("اطلاعات فرم درخواست قبلا ثبت گردیده است", this.Page);
                    return;
                }
                Tb_Apply1 = new Tb_Apply();
                Tb_Apply1.xAppRegNo = Txt_AppNo.Text;
                Tb_Apply1.xAppRegDate = Txt_ApplyDate.Text; 
                Tb_Apply1.xAppHasrNo = Txt_HasrNo.Text;
                Tb_Apply1.xAppHasrDate = Txt_HasrDate.Text;
                Tb_Apply1.xAppShobeDadgah = Txt_ShobeNo.Text;
                Tb_Apply1.xAppDadgah = Txt_Dadgah.Text;
                Tb_Apply1.xDedId_fk = Tb_File1.xDedId_fk;
                Tb_File1.Tb_Dead.xDedCodeHoviat = Txt_CodeHoviati.Text.Trim();

                Lts_Inherited.Tb_Applies.InsertOnSubmit(Tb_Apply1);
                Str_Msg = "!عملیات ذخیره با موفقیت انجام شد";
            }
            
            else if (Hfld_Command.Value=="Edit")
            {
                Tb_Apply1.xAppRegNo = Txt_AppNo.Text;
                Tb_Apply1.xAppRegDate = Txt_ApplyDate.Text;
                Tb_Apply1.xAppHasrNo = Txt_HasrNo.Text;
                Tb_Apply1.xAppHasrDate = Txt_HasrDate.Text;
                Tb_Apply1.xAppShobeDadgah = Txt_ShobeNo.Text;
                Tb_Apply1.xAppDadgah = Txt_Dadgah.Text;
                Tb_Apply1.xDedId_fk = Tb_File1.xDedId_fk;
                Tb_Apply1.Tb_Dead.xDedCodeHoviat = Txt_CodeHoviati.Text.Trim();

                Str_Msg = "!عملیات ویرایش با موفقیت انجام شد";
            }

            try
            {
                Lts_Inherited.SubmitChanges();
                Alarm.ShowMesseage(Str_Msg, this.Page);
                ResetControl();

                List<Tb_Apply> Lst_Applys = Lts_Inherited.Tb_Applies.Where(n => n.xDedId_fk == Tb_File1.xDedId_fk && n.xAppIsDeleted_==false).ToList();
                Gvw_Applies.DataSource = Lst_Applys;
                Gvw_Applies.DataBind();
                Gvw_Applies.Visible = true;
            }
            catch 
            {
                Alarm.ShowMesseage("!خطا", this.Page);
            }
        }

        protected void Btn_New_Click(object sender, EventArgs e)
        {
            ResetControl();
        }

        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            ResetControl();
            if (Txt_Klasse.Text.Trim() == "" && !IsPostBack)
            {
                return;
            }
            if (Txt_Klasse.Text.Trim() == "")
            {
                Alarm.ShowMesseage("کلاسه را وارد کنید ", this.Page);
                Session["Classe"] = null;
                return;
            }

            Lts_Inherited = new Lts_InheritedDataContext();
            Tb_File1 = null;
            Tb_File1 = Lts_Inherited.Tb_Files.SingleOrDefault(n => n.xHozeh == Txt_Hozeh.Text & n.xClass == Txt_Klasse.Text);
            if (Tb_File1 == null)
            {
                Alarm.ShowMesseage("پرونده ای  وجود ندارد !", this.Page);
                Gvw_Applies.Visible = false;
                Session["Classe"] = null;
                Lbl_DedName.Text =
                Lbl_DedNationalcode.Text = "";
                return;
            }
            try
            {
                DedId = Lts_Inherited.Tb_Files.SingleOrDefault(n => n.xHozeh == Txt_Hozeh.Text & n.xClass == Txt_Klasse.Text & n.Tb_Dead.xDedIsDeleted_==false).xDedId_fk;
                Tb_Dead1 = Lts_Inherited.Tb_Deads.Single(n => n.xDedId_pk == DedId);
                Lbl_DedName.Text = Tb_Dead1.xDedFName + " " + Tb_Dead1.xDedLName;
                Lbl_DedNationalcode.Text = Tb_Dead1.xDedNationalCode;
                Btn_Save.Enabled = true;

                List<Tb_Apply> Lst_Applys = Lts_Inherited.Tb_Applies.Where(n => n.xDedId_fk == Tb_Dead1.xDedId_pk && n.xAppIsDeleted_ == false).ToList();
                Gvw_Applies.DataSource = Lst_Applys;
                Gvw_Applies.DataBind();
                Gvw_Applies.Visible = true;
                Session["Classe"] = Txt_Klasse.Text.Trim();

            }
            catch
            {
                Alarm.ShowMesseage("خطا!", this.Page);
                Gvw_Applies.Visible = false;
            }
           
        }

        protected void Gvw_Applies_SelectedIndexChanged(object sender, EventArgs e)
        {
            Hfld_Command.Value = "Edit";
            Tb_Apply1 = Lts_Inherited.Tb_Applies.SingleOrDefault(n => n.xAppId_pk == int.Parse(Gvw_Applies.SelectedDataKey.Value.ToString()));
            Txt_AppNo.Text = Tb_Apply1.xAppRegNo;
            Txt_Dadgah.Text = Tb_Apply1.xAppDadgah;
            Txt_HasrNo.Text = Tb_Apply1.xAppHasrNo;
            Txt_ShobeNo.Text = Tb_Apply1.xAppShobeDadgah;
            Txt_ApplyDate.Text = Tb_Apply1.xAppRegDate;
            Txt_HasrDate.Text = Tb_Apply1.xAppHasrDate;

            Txt_CodeHoviati.Text = Tb_Apply1.Tb_Dead.xDedCodeHoviat;
            Btn_Cancel.Visible = true;
        }

        protected void Gvw_Applies_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Tb_Apply1 = Lts_Inherited.Tb_Applies.SingleOrDefault(n => n.xAppId_pk == int.Parse(Gvw_Applies.DataKeys[e.RowIndex].Value.ToString()));
            Tb_Apply1.xAppIsDeleted_ = true;
            try
            {
                Lts_Inherited.SubmitChanges();
                Alarm.ShowMesseage("!عملیات حذف با موفقیت انجام شد", this.Page);

                List<Tb_Apply> Lst_Applys = Lts_Inherited.Tb_Applies.Where(n => n.xDedId_fk == Tb_Dead1.xDedId_pk && n.xAppIsDeleted_ == false).ToList();
                Gvw_Applies.DataSource = Lst_Applys;
                Gvw_Applies.DataBind();
                Gvw_Applies.Visible = true;
            }
            catch
            {
                Alarm.ShowMesseage("!خطا", this.Page);
            }
        }

        protected void Btn_Cancel_Click(object sender, EventArgs e)
        {
            ResetControl();
        }
    }
}