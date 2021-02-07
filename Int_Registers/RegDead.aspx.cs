using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ers_Pro.App_Code.Intd_Lts;
using ShamsiDateTime;

namespace Ers_Pro.Int_Registers
{
    public partial class RegDead : System.Web.UI.Page
    {
        Alarm Alarm1 = new Alarm();

        #region Puplics

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
        public Tb_User Tb_User1
        {
            get { return Session[Str_PageId + "_Tb_User"] as Tb_User; }
            set { Session[Str_PageId + "_Tb_User"] = value; }
        }
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
        public Tb_Dead Tb_Dead1
        {
            get { return Session[Str_PageId + "_Tb_Dead"] as Tb_Dead; }
            set { Session[Str_PageId + "_Tb_Dead"] = value; }
        }
        public List<Tb_File> Lst_Tb_File
        {
            get { return Session[Str_PageId + "_List<Tb_File>"] as List<Tb_File>; }
            set { Session[Str_PageId + "_List<Tb_File>"] = value; }
        }
        public Tb_File Tb_File1
        {
            get { return Session[Str_PageId + "_Tb_File"] as Tb_File; }
            set { Session[Str_PageId + "_Tb_File"] = value; }
        }
        public Tb_Heir Tb_Heir1
        {
            get { return Session[Str_PageId + "_Tb_Heir"] as Tb_Heir; }
            set { Session[Str_PageId + "_Tb_Heir"] = value; }
        }


        public void ResetControls()
        {
            Txt_Klasse.Text=
                Txt_DeadPlace.Text =
                Txt_FatherName.Text =
                Txt_FirstName.Text =
                Txt_IDNo.Text =
                Txt_LastName.Text =
                Txt_SodoorPlace.Text =
                TxtNationalcode.Text =
                Txt_FotDate.Text = "";
                //Ddl_Fday.Text =
                //Txt_CodeHoviati.Text =
                //Ddl_FMounth.Text = "";
            Btn_Cancel.Visible = false;
            Hfld_Command.Value = "Save";
            Rbtn_DSex.SelectedIndex = 0;
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Glb_Tb_User"] == null)
                Response.Redirect("~/Login.aspx");
            Tb_User1 = Session["Glb_Tb_User"] as Tb_User;
            (Master.FindControl("Lbl_Title") as Label).Text = "ثبت مشخصات متوفی";
            Txt_Hozeh.Text = Tb_User1.xUser_Hozeh;
            #region ddl_Load
            //if (!IsPostBack)
            //{
            //    Ddl_Fday.Items.Add("");
            //    Ddl_FMounth.Items.Add("");
            //    Ddl_FYear.Items.Add("");

            //    string[] Lst_Day = new string[31];
            //    string j = "";
            //    int i;
            //    for (i = 0; i <= 30; i++)
            //    {
            //        j = (i + 1).ToString();
            //        if (i < 9)
            //            j = "0" + j;
            //        Lst_Day[i] = j;
            //    }
            //    foreach (string item in Lst_Day)
            //    {
            //        Ddl_Fday.Items.Add(item.ToString());
            //    }
            //    string[] Lst_Mounth = new string[12];
            //    for (i = 0; i <= 11; i++)
            //    {
            //        j = (i + 1).ToString();
            //        if (i < 9)
            //            j = "0" + j;
            //        Lst_Mounth[i] = j;
            //    }
            //    foreach (string item in Lst_Mounth)
            //    {
            //        Ddl_FMounth.Items.Add(item.ToString());
            //    }
            //    string[] Lst_Year = new string[2];
            //    for (i = 1395; i <= 1396; i++)
            //    {
            //        j = (i + 1).ToString();
            //        Lst_Year[i - 1395] = j;
            //    }
            //    foreach (string item in Lst_Year)
            //    {
            //        Ddl_FYear.Items.Add(item.ToString());
            //    }
            //    Ddl_FYear.SelectedItem.Text = "1395";

            //}
            #endregion
        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            if (Txt_FotDate.Text == "__/__/____")
            {
                Alarm1.ShowMesseage("!تاریخ را صحیح وارد نمایید", this.Page);
                return;
            }
            int int_Year=int.Parse(Txt_FotDate.Text.Substring(0,4));
            int int_Mounth=int.Parse(Txt_FotDate.Text.Substring(5,2));
            int int_Day=int.Parse(Txt_FotDate.Text.Substring(8,2));
            if (int_Year < 1300 || int_Year > 1400 || int_Mounth == 00 || int_Mounth > 12 || int_Day == 00 || int_Day>31)
            {
                Alarm1.ShowMesseage("!تاریخ را صحیح وارد نمایید", this.Page);
                return;
            }
            if (Lts_Inherited == null)
                Lts_Inherited = new Lts_InheritedDataContext();

            string Str_Msg = "";

            if (Hfld_Command.Value == "Save")
            {
                string class1 = "0";
                Tb_Dead1 = Lts_Inherited.Tb_Deads.SingleOrDefault(n => n.xDedNationalCode == TxtNationalcode.Text.Trim() && n.xDedIsDeleted_ == false);

                if (Tb_Dead1 != null)
                {
                    Alarm1.ShowMesseage("!مشخصات متوفی قبلا ثبت گردیده است", this.Page);
                    return;
                }

                Tb_Dead1 = new Tb_Dead();
                Tb_Dead1.xDedFName = Txt_FirstName.Text.Trim();
                Tb_Dead1.xDedLName = Txt_LastName.Text.Trim();
                Tb_Dead1.xDedFatherName = Txt_FatherName.Text.Trim();
                Tb_Dead1.xDedDeadDate = Txt_FotDate.Text.Trim();
                //Ddl_FYear.Text.Trim() + "/" + Ddl_FMounth.Text.Trim() + "/" + Ddl_Fday.Text.Trim();
                Tb_Dead1.xDedDeadPlace = Txt_DeadPlace.Text.Trim();
                Tb_Dead1.xDedIdNo = Txt_IDNo.Text.Trim();
                Tb_Dead1.xDedIssuancePlace = Txt_SodoorPlace.Text.Trim();
                Tb_Dead1.xDedNationalCode = TxtNationalcode.Text.Trim();
                Tb_Dead1.xUserId_fk = Tb_User1.xUserId_pk;
                Tb_Dead1.xDedRegDate = Class_ShamsiDateTime.MilladiToShamsi(DateTime.Now.Date).ToString();
                //Tb_Dead1.xDedCodeHoviat = Txt_CodeHoviati.Text.Trim().Trim();
                if (Txt_CodAtba.Text.Trim() != "")
                    Tb_Dead1.xDedCodeAtba = Txt_CodAtba.Text.Trim();

                if (Rbtn_DSex.SelectedValue == "male")
                    Tb_Dead1.xDedSex = "male";
                else
                    Tb_Dead1.xDedSex = "fmale";

                Lts_Inherited.Tb_Deads.InsertOnSubmit(Tb_Dead1);

                //List<int> Lst_Class = null;
                Lst_Tb_File = Lts_Inherited.Tb_Files.Where(n => n.xHozeh == Tb_User1.xUser_Hozeh &&
                                n.Tb_Dead.xDedIsDeleted_==false).OrderBy(n =>Convert.ToInt32(n.xClass)).ToList();

                if (Lst_Tb_File.Count != 0)
                {
                    class1 = Lst_Tb_File.LastOrDefault().xClass;
                }

                Tb_File1 = new Tb_File();
                Tb_File1.xClass = (int.Parse(class1) + 1).ToString();
                Tb_File1.Tb_Dead = Tb_Dead1;
                Tb_File1.xHozeh = Txt_Hozeh.Text;
                Lts_Inherited.Tb_Files.InsertOnSubmit(Tb_File1);
                Str_Msg = "!عملیات ذخیره با موفقیت انجام شد";
                Txt_Klasse.Text = (class1 + 1).ToString();
                Session["Classe"] = Txt_Klasse.Text.Trim();
            }
            else if(Hfld_Command.Value=="Edit")
            {
                if (Lts_Inherited.Tb_Deads.SingleOrDefault(n => n.xDedNationalCode == TxtNationalcode.Text.Trim()) != null &&
                    Tb_Dead1.xDedNationalCode!=TxtNationalcode.Text.Trim())
                {
                    Alarm1.ShowMesseage("!مشخصات متوفی قبلا ثبت گردیده است", this.Page);
                    return;
                }
                Tb_Dead1.xDedFName = Txt_FirstName.Text.Trim();
                Tb_Dead1.xDedLName = Txt_LastName.Text.Trim();
                Tb_Dead1.xDedFatherName = Txt_FatherName.Text.Trim();
                Tb_Dead1.xDedDeadDate = Txt_FotDate.Text.Trim(); 
                 //Ddl_FYear.Text.Trim() + "/" + Ddl_FMounth.Text.Trim() + "/" + Ddl_Fday.Text.Trim();
                Tb_Dead1.xDedDeadPlace = Txt_DeadPlace.Text.Trim();
                Tb_Dead1.xDedIdNo = Txt_IDNo.Text.Trim();
                Tb_Dead1.xDedIssuancePlace = Txt_SodoorPlace.Text.Trim();
                Tb_Dead1.xDedNationalCode = TxtNationalcode.Text.Trim();
                Tb_Dead1.xUserId_fk = Tb_User1.xUserId_pk;
                Tb_Dead1.xDedRegDate = Class_ShamsiDateTime.MilladiToShamsi(DateTime.Now.Date).ToString();
                if (Rbtn_DSex.SelectedIndex == 0)
                    Tb_Dead1.xDedSex = "male";
                else
                    Tb_Dead1.xDedSex = "fmale";
                Str_Msg = "!عملیات ویرایش با موفقیت انجام شد";

            }
            try
            {
                Lts_Inherited.SubmitChanges();
                Alarm1.ShowMesseage(Str_Msg, this.Page);
                GetDead(Tb_Dead1.xDedId_pk);
                ResetControls();
            }
            catch
            {
                Alarm1.ShowMesseage("!خطا", this.Page);
            }
        }

        protected void Btn_New_Click(object sender, EventArgs e)
        {
            ResetControls();
        }

        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            
            Lts_Inherited = new Lts_InheritedDataContext();
            List<Sp_DeadSearchResult> Lst_Deads =
                Lts_Inherited.Sp_DeadSearch(Txt_searchFName.Text.Trim() != "" ? Txt_searchFName.Text.Trim() : "0",
                                            Txt_searchLname.Text.Trim() != "" ? Txt_searchLname.Text.Trim() : "0",
                                            Txt_searchNationalcode.Text.Trim() != "" ? Txt_searchNationalcode.Text.Trim() : "0",
                                            Txt_searchClasse.Text.Trim() != "" ? Txt_searchClasse.Text.Trim() : "0",
                                            Txt_Hozeh.Text.Trim() != "" ? Txt_Hozeh.Text.Trim() : "0").ToList();
            //List<Tb_File> Lst_Files=Lts_Inherited.Tb_Files.Where(n=>
            //    (n.xHozeh==Txt_Hozeh.Text.Trim() ||Txt_Hozeh.Text.Trim()=="")&&
            //    (n.xClass==Txt_searchClasse.Text.Trim() || Txt_searchClasse.Text.Trim() == "")).ToList();

            //List<Tb_Dead> Lst_Deads = Lst_Files.Where(n =>
            //    (n.Tb_Dead.xDedFName.Contains(Txt_searchFName.Text.Trim()) || Txt_searchFName.Text.Trim() == "") &&
            //    (n.Tb_Dead.xDedLName.Contains(Txt_searchLname.Text.Trim()) || Txt_searchLname.Text.Trim() == "") &&
            //    (n.Tb_Dead.xDedNationalCode == Txt_searchNationalcode.Text.Trim() || Txt_searchNationalcode.Text.Trim() == "") &&
            //    n.Tb_Dead.xDedIsDeleted_ == false).Select(n=>n.Tb_Dead).ToList();

            Gvw_Dead.DataSource = null;
            Gvw_Dead.DataSource = Lst_Deads;
            Gvw_Dead.DataBind();
            Gvw_Dead.Visible = true;
            Lbl_Records.Text = Lst_Deads.Count.ToString();
            Lbl_Records.Visible = true;
            Lbl_Rec.Visible = true;
               
        }

        protected void Gvw_Dead_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gvw_Dead.PageIndex = e.NewPageIndex;
            Btn_Search_Click(sender, e);
        }

       

        protected void Btn_Cancel_Click(object sender, EventArgs e)
        {
            ResetControls();
        }

        protected void Gvw_Dead_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Tb_Dead1 = Lts_Inherited.Tb_Deads.SingleOrDefault(n => n.xDedId_pk == int.Parse(Gvw_Dead.DataKeys[e.RowIndex].Value.ToString()));
            Tb_Dead1.xDedIsDeleted_ = true;
            try
            {
                Lts_Inherited.SubmitChanges();
                Alarm1.ShowMesseage("!عملیات حدف با موفقیت انجام شد", this.Page);
                Btn_Search_Click(sender, e);
            }
            catch
            {
                Alarm1.ShowMesseage("!خطا", this.Page);
                return;
            }
        }

        protected void Gvw_Dead_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tb_Dead1 = Lts_Inherited.Tb_Deads.SingleOrDefault(n => n.xDedId_pk == int.Parse(Gvw_Dead.SelectedDataKey.Value.ToString()));
            //Txt_CodeHoviati.Text = Tb_Dead1.xDedCodeHoviat;
            Txt_DeadPlace.Text = Tb_Dead1.xDedDeadPlace;
            Txt_FatherName.Text = Tb_Dead1.xDedFatherName;
            Txt_FirstName.Text = Tb_Dead1.xDedFName;
            Txt_IDNo.Text = Tb_Dead1.xDedIdNo;
            Txt_LastName.Text = Tb_Dead1.xDedLName;
            TxtNationalcode.Text = Tb_Dead1.xDedNationalCode;
            Txt_SodoorPlace.Text = Tb_Dead1.xDedIssuancePlace;
            Txt_FotDate.Text = Tb_Dead1.xDedDeadDate;
            //Ddl_Fday.ClearSelection();
            //Ddl_FMounth.ClearSelection();
            //Ddl_FYear.ClearSelection();
            //Ddl_Fday.Items.FindByText(Tb_Dead1.xDedDeadDate.Substring(8, 2)).Selected = true;
            //Ddl_FMounth.Items.FindByText(Tb_Dead1.xDedDeadDate.Substring(5, 2)).Selected = true;
            //Ddl_FYear.Items.FindByText(Tb_Dead1.xDedDeadDate.Substring(0, 4)).Selected = true;
            if (Tb_Dead1.xDedSex == "male")
                Rbtn_DSex.SelectedIndex = 0;
            else
                Rbtn_DSex.SelectedIndex = 1;

            Btn_Cancel.Visible = true;
            Hfld_Command.Value = "Edit";
        }

        protected void Imgbtn_Sssearch_Click(object sender, ImageClickEventArgs e)
        {
            if (Lts_Inherited == null)
                Lts_Inherited = new Lts_InheritedDataContext();

            Tb_Dead1 = Lts_Inherited.Tb_Deads.SingleOrDefault(n => n.xDedNationalCode == TxtNationalcode.Text.Trim());

            if (Tb_Dead1 != null)
            {
                Txt_FirstName.Text = Tb_Dead1.xDedFName;
                Txt_LastName.Text = Tb_Dead1.xDedLName;
                Txt_FatherName.Text = Tb_Dead1.xDedFatherName;
                //Ddl_Fday.ClearSelection();
                //Ddl_FMounth.ClearSelection();
                //Ddl_FYear.ClearSelection();
                //Ddl_Fday.Items.FindByText(Tb_Dead1.xDedDeadDate.Substring(8, 2)).Selected = true;
                //Ddl_FMounth.Items.FindByText(Tb_Dead1.xDedDeadDate.Substring(5, 2)).Selected = true;
                //Ddl_FYear.Items.FindByText(Tb_Dead1.xDedDeadDate.Substring(0, 4)).Selected = true;
                Txt_FotDate.Text = Tb_Dead1.xDedDeadDate;
                Txt_IDNo.Text = Tb_Dead1.xDedIdNo;
                Txt_SodoorPlace.Text = Tb_Dead1.xDedIssuancePlace;
                Txt_DeadPlace.Text = Tb_Dead1.xDedDeadPlace;
                if (Tb_Dead1.xDedSex == "male")
                    Rbtn_DSex.SelectedIndex = 0;
                else
                    Rbtn_DSex.SelectedIndex = 1;
                //Txt_CodeHoviati.Text = Tb_Dead1.xDedCodeHoviat;

            }
        }


        public void GetDead(int DeadId)
        {
            List<Tb_Dead> Lst_Deads = Lts_Inherited.Tb_Deads.Where(n=>n.xDedId_pk==DeadId).ToList();
            Gvw_Dead.DataSource = null;
            Gvw_Dead.DataSource = Lst_Deads;
            Gvw_Dead.DataBind();
            Lbl_Records.Text = Lst_Deads.Count.ToString();
            Lbl_Records.Visible = true;
            Lbl_Rec.Visible = true;
            Gvw_Dead.Visible = true;
        }
    }
}