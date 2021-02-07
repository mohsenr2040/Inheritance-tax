using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ers_Pro.App_Code.Intd_Lts;
using Ers_Pro.App_Code;
namespace Ers_Pro
{
    public partial class RegEstates : System.Web.UI.Page
    {
        Alarm Alarm = new Alarm();
        
        #region Publics
        
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
        public Tb_User Tb_User1;
        public Lts_InheritedDataContext Lts_Inherited
        {
            get { return Session[Str_PageId + "_Lts_Inherited"] as Lts_InheritedDataContext; }
            set { Session[Str_PageId + "_Lts_Inherited"] = value; }
        }
        public Tb_Person Tb_Person1
        {
            get { return Session[Str_PageId + "_Tb_Person"] as Tb_Person; }
            set { Session[Str_PageId + "_Tb_Person"] = value; }
        }
        public List<Tb_Estate> Lst_Estates
        {
            get { return Session[Str_PageId + "_Lst_Estates"] as List<Tb_Estate>; }
            set { Session[Str_PageId + "_Lst_Estates"] = value; }
        }
        public Tb_Estate Tb_Estate1
        {
            get { return Session[Str_PageId + "_Tb_Estate"] as Tb_Estate; }
            set { Session[Str_PageId + "_Tb_Estate"] = value; }
        }
        public Tb_Dead Tb_Dead1
        {
            get { return Session[Str_PageId + "_Tb_Dead"] as Tb_Dead; }
            set { Session[Str_PageId + "_Tb_Dead"] = value; }
        }
        public void ResetControls()
        {
            Txt_EstateDesc.Text = "";
            Ddl_Estatetype.SelectedIndex = 0;
            Lbl_Msg.Visible = false;
            Btn_New.Visible = false;
            Btn_Cancel.Visible = false;
            Hfld_Command.Value = "Save";
        }

        public void removesess()
        {
            Tb_Person1 = null;
            Tb_User1 = null;

        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Glb_Tb_User"] == null)
                Response.Redirect("~/Login.aspx");
            Tb_User1 = Session["Glb_Tb_User"] as Tb_User;
            (Master.FindControl("Lbl_Title") as Label).Text = "ثبت دارایی های متوفی";
            Txt_Hozeh.Text = Tb_User1.xUser_Hozeh;
            if(!IsPostBack)
            {
                Hfld_Command.Value = "Save";
            }
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
            ResetControls();
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
            try
            {
                Tb_File Tb_Files1 = Lts_Inherited.Tb_Files.SingleOrDefault(n => n.xHozeh == Txt_Hozeh.Text & n.xClass == Txt_Klasse.Text);
                if (Tb_Files1 == null)
                {
                    ResetControls();
                    Alarm.ShowMesseage("پرونده ای  وجود ندارد!", this.Page);
                    Gvw_Estate.Visible = false;
                    Lbl_DedName.Text =
                    Lbl_DedNationalcode.Text = "";
                    Session["Classe"] = null;
                    return;
                }
                Session["Classe"] = Txt_Klasse.Text.Trim();

                Tb_Dead1 = Lts_Inherited.Tb_Deads.SingleOrDefault(n => n.xDedId_pk == Tb_Files1.xDedId_fk);
                Lbl_DedName.Text = Tb_Dead1.xDedFName + " " + Tb_Dead1.xDedLName;
                Lbl_DedNationalcode.Text = Tb_Dead1.xDedNationalCode;
                 
                Btn_Save.Enabled = true;


                Lst_Estates = Lts_Inherited.Tb_Estates.Where(n => n.xDedId_fk == Tb_Dead1.xDedId_pk && n.xEstIsDeleted_ == false).ToList();
                Gvw_Estate.DataSource = Lst_Estates;
                Gvw_Estate.DataBind();
                Gvw_Estate.Visible = true;
            }
            catch
            {
                ResetControls();
                Alarm.ShowMesseage("Error", this.Page);
            }
           
        }

        protected void Btn_New_Click(object sender, EventArgs e)
        {
            ResetControls();
        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            string Str_Msg = "";
            if (Lts_Inherited.Tb_Files.SingleOrDefault(n => n.xClass == Txt_Klasse.Text & n.xHozeh == Txt_Hozeh.Text) != null)
            {
                if (Hfld_Command.Value == "Save")
                {
                    Tb_Estate1 = new Tb_Estate();
                    Tb_Estate1.xDedId_fk = Tb_Dead1.xDedId_pk;
                    Tb_Estate1.xEstDescription = Txt_EstateDesc.Text;
                    Tb_Estate1.xEstTypeId_fk = int.Parse(Ddl_Estatetype.SelectedItem.Value);
                    Lts_Inherited.Tb_Estates.InsertOnSubmit(Tb_Estate1);
                    Str_Msg = "!عملیات ذخیره با موفقیت انجام شد";
                }
                else if (Hfld_Command.Value == "Edit")
                {
                    Tb_Estate1.xEstDescription = Txt_EstateDesc.Text;
                    Tb_EstateType Tb_EstateType1 = Lts_Inherited.Tb_EstateTypes.SingleOrDefault(n => n.xEstTypeId_pk == int.Parse(Ddl_Estatetype.SelectedItem.Value.ToString()));
                    Tb_Estate1.Tb_EstateType = Tb_EstateType1;
                    Str_Msg = "!عملیات ویرایش با موفقیت انجام شد";
                }
                
                try
                {
                    Lts_Inherited.SubmitChanges();
                    Alarm.ShowMesseage(Str_Msg, this.Page);
                    ResetControls();

                    List<Tb_Estate> Lst_Estates = Lts_Inherited.Tb_Estates.Where(n => n.xDedId_fk == Tb_Dead1.xDedId_pk && n.xEstIsDeleted_ == false).ToList();
                    Gvw_Estate.DataSource = Lst_Estates;
                    Gvw_Estate.DataBind();
                }
                catch
                {
                    Alarm.ShowMesseage("Error", this.Page);
                }
            }
            else
            {
                Alarm.ShowMesseage("پرونده ای  وجود ندارد!", this.Page);
            }
        }

        protected void Gvw_Estate_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tb_Estate1 = new Tb_Estate();
            Tb_Estate1 = Lts_Inherited.Tb_Estates.SingleOrDefault(n => n.xEstId_pk == int.Parse(Gvw_Estate.SelectedDataKey.Value.ToString()));

            Txt_EstateDesc.Text = Tb_Estate1.xEstDescription;
            Ddl_Estatetype.ClearSelection();
            Ddl_Estatetype.Items.FindByValue(Tb_Estate1.xEstTypeId_fk.ToString()).Selected = true;
            Hfld_Command.Value = "Edit";
            Btn_Cancel.Visible = true;
        }

        protected void Btn_Cancel_Click(object sender, EventArgs e)
        {
            ResetControls();
        }

        protected void Gvw_Estate_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Tb_Estate1 = Lts_Inherited.Tb_Estates.SingleOrDefault(n => n.xEstId_pk == int.Parse(Gvw_Estate.DataKeys[e.RowIndex].Value.ToString()));
            try
            {
                Tb_Estate1.xEstIsDeleted_ = true;
                Lts_Inherited.SubmitChanges();
                Alarm.ShowMesseage("!عملیات حذف با موفقیت انجام شد", this.Page);
                List<Tb_Estate> Lst_Estates = Lts_Inherited.Tb_Estates.Where(n => n.xDedId_fk == Tb_Dead1.xDedId_pk && n.xEstIsDeleted_ == false).ToList();
                Gvw_Estate.DataSource = Lst_Estates;
                Gvw_Estate.DataBind();
            }
            catch
            {
                Alarm.ShowMesseage("Error", this.Page);
            }
        }

        protected void Gvw_Estate_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gvw_Estate.PageIndex = e.NewPageIndex;
            Btn_Search_Click(sender, e);
        }
    }
}