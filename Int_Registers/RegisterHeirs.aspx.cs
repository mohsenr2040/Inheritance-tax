using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ers_Pro.App_Code.Intd_Lts;

namespace Ers_Pro
{
    public partial class RegisterHeirs : System.Web.UI.Page
    {
        Alarm Alarm1 = new Alarm();
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
        public Tb_Heir Tb_Heir1
        {
            get { return Session[Str_PageId + "_Tb_Heir"] as Tb_Heir; }
            set { Session[Str_PageId + "_Tb_Heir"] = value; }
        }
        public Tb_Dead Tb_Dead1
        {
            get { return Session[Str_PageId + "_Tb_Dead"] as Tb_Dead; }
            set { Session[Str_PageId + "_Tb_Dead"] = value; }
        }
        public Tb_Person Tb_PersonExist
        {
            get { return Session[Str_PageId + "_Tb_PersonExist"] as Tb_Person; }
            set { Session[Str_PageId + "_Tb_PersonExist"] = value; }
        }

        public List<Tb_Person> Lst_Heris
        {
            get { return Session[Str_PageId + "Lst_Heris"] as List<Tb_Person>; }
            set { Session[Str_PageId + "Lst_Heris"] = value; }
        }
        public void NewReg()
        {
            Txt_PFirsName.Text =
                Txt_BirthDate.Text=
            Txt_PIdNo.Text =
            Txt_PNationalCode.Text = "";
            Btn_New.Visible = false;
            Btn_Cancel.Visible = false;
            Hfld_Command.Value = "Save";
            Txt_PNationalCode.Focus();

        }
        public void ResetControls()
        {
            Hfld_Command.Value = "Save";
            Txt_PFirsName.Text =
            Txt_PIdNo.Text =
            Txt_BirthDate.Text=
            Txt_PAddrress.Text =
            Txt_PBirthPlace.Text =
            Txt_PCodPosti.Text =
            Txt_PFirsName.Text =
            Txt_PIdNo.Text =
            Txt_PLastName.Text =
            Txt_PNationalCode.Text =
            Txt_PSoodorPlace.Text =
            Txt_PTel.Text =
            TxtPFatherName.Text =
            Txt_PNationalCode.Text = "";
            Ddl_Ratio.SelectedIndex = 0;
            Btn_New.Visible = false;
            Btn_Cancel.Visible = false;
            Rbtn_Sex.SelectedIndex = 0;
        }
        int DedId = 0;
        public void removesess()
        {
            Tb_Heir1 = null;
            Tb_Person1 = null;
            Tb_User1 = null;

        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Glb_Tb_User"] == null)
                Response.Redirect("~/Login.aspx");
            Tb_User1 = Session["Glb_Tb_User"] as Tb_User;
            (Master.FindControl("Lbl_Title") as Label).Text = "ثبت مشخصات وراث";
            Txt_Hozeh.Text = Tb_User1.xUser_Hozeh;
            if (!IsPostBack)
            {
                Ddl_Ratio.Items.Add("");
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

        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            if (Txt_BirthDate.Text == "__/__/____")
            {
                Alarm1.ShowMesseage("!تاریخ را صحیح وارد نمایید", this.Page);
                return;
            }
            int int_Year = int.Parse(Txt_BirthDate.Text.Substring(0, 4));
            int int_Mounth = int.Parse(Txt_BirthDate.Text.Substring(5, 2));
            int int_Day = int.Parse(Txt_BirthDate.Text.Substring(8, 2));
            if (int_Year < 1300 || int_Year > 1400 || int_Mounth == 00 || int_Mounth > 12 || int_Day == 00 || int_Day > 31)
            {
                Alarm1.ShowMesseage("!تاریخ را صحیح وارد نمایید", this.Page);
                return;
            }
            if(Txt_Klasse.Text.Trim()=="")
            {
                RequiredFieldValidator9.Validate();
                return;
            }
            if (Lts_Inherited.Tb_Files.SingleOrDefault(n => n.xClass == Txt_Klasse.Text & n.xHozeh == Txt_Hozeh.Text) != null)
            {
                DedId = Lts_Inherited.Tb_Files.SingleOrDefault(n => n.xHozeh == Txt_Hozeh.Text & n.xClass == Txt_Klasse.Text).xDedId_fk;
                Tb_Dead1 = Lts_Inherited.Tb_Deads.SingleOrDefault(n => n.xDedId_pk == DedId);

                Tb_PersonExist = Lts_Inherited.Tb_Persons.SingleOrDefault(n => n.xPrsNationalCode == Txt_PNationalCode.Text.Trim());
              
                if (Hfld_Command.Value == "Save")
                {
                    try
                    {
                        Tb_Person1 = new Tb_Person();
                        if (Tb_PersonExist != null)
                        {
                            ////کنترل شخص ثبت شده
                            Tb_Heir1 = Lts_Inherited.Tb_Heirs.SingleOrDefault(n => n.xDedId_fk == DedId && n.xPrsId_fk == Tb_PersonExist.xPrsId_pk);
                            if (Tb_Heir1 != null)
                            {
                                Alarm1.ShowMesseage("این شخص قبلا بعنوان وارث در این پرونده ثبت گردیده است!", this.Page);
                                return;
                            }
                            Tb_Person1 = Tb_PersonExist;
                            Tb_Person1.xPrsIsDeleted_ = false;
                        }
                        else
                        {
                            Tb_Person1.xPrsFName = Txt_PFirsName.Text;
                            Tb_Person1.xPrsLName = Txt_PLastName.Text;
                            Tb_Person1.xPrsFatherName = TxtPFatherName.Text;
                            Tb_Person1.xPrsBirthDate = Txt_BirthDate.Text;
                            Tb_Person1.xPrsBirthPlace = Txt_PBirthPlace.Text;
                            Tb_Person1.xPrsIdNo = Txt_PIdNo.Text;
                            Tb_Person1.xPrsIssuancePalce = Txt_PSoodorPlace.Text;
                            Tb_Person1.xPrsNationalCode = Txt_PNationalCode.Text;
                            Tb_Person1.xPrsPostalCode = Txt_PCodPosti.Text;
                            Tb_Person1.xPrsTel = Txt_PTel.Text;
                            if (Rbtn_Sex.SelectedValue == "male")
                                Tb_Person1.xPrsSex = "male";
                            else
                                Tb_Person1.xPrsSex = "fmale";
                            Tb_Person1.xPrsAddrress = Txt_PAddrress.Text;
                            Lts_Inherited.Tb_Persons.InsertOnSubmit(Tb_Person1);

                        }
                        Tb_Heir1 = new Tb_Heir();
                        Tb_Heir1.Tb_Dead = Tb_Dead1;
                        Tb_Heir1.Tb_Person = Tb_Person1;
                        Tb_Heir1.xRtoId_fk =int.Parse(Ddl_Ratio.SelectedValue);
                        Tb_Heir1.xIsApplicant_ = false;

                        Lts_Inherited.Tb_Heirs.InsertOnSubmit(Tb_Heir1);
                        Lts_Inherited.SubmitChanges();
                        Alarm1.ShowMesseage("!عملیات ذخیره با موفقیت انجام شد", this.Page);
                        //Btn_New.Visible = true;
                        NewReg();

                        Lst_Heris = Lts_Inherited.Tb_Heirs.Where(n => n.xDedId_fk == DedId).Select(n => n.Tb_Person).ToList();
                        Gvw_Heris.DataSource = Lst_Heris;
                        Gvw_Heris.DataBind();
                        Gvw_Heris.Visible = true;
                    }
                    catch
                    {
                        Alarm1.ShowMesseage("!خطا", this.Page);
                    }

                }
                else if (Hfld_Command.Value == "Edit")
                {
                    try
                    {
                        if (Tb_Person1.xPrsNationalCode != Txt_PNationalCode.Text && Tb_PersonExist != null)
                        {
                            Tb_Heir1 = Lts_Inherited.Tb_Heirs.SingleOrDefault(n => n.xDedId_fk == DedId && n.xPrsId_fk == Tb_PersonExist.xPrsId_pk);
                            if (Tb_Heir1 != null)
                            {
                                Alarm1.ShowMesseage("این شخص قبلا بعنوان وارث در این پرونده ثبت گردیده است!", this.Page);
                                return;
                            }
                        }
                        Tb_Person1.xPrsFName = Txt_PFirsName.Text;
                        Tb_Person1.xPrsLName = Txt_PLastName.Text;
                        Tb_Person1.xPrsFatherName = TxtPFatherName.Text;
                        Tb_Person1.xPrsBirthDate = Txt_BirthDate.Text;
                        Tb_Person1.xPrsBirthPlace = Txt_PBirthPlace.Text;
                        Tb_Person1.xPrsIdNo = Txt_PIdNo.Text;
                        Tb_Person1.xPrsIssuancePalce = Txt_PSoodorPlace.Text;
                        Tb_Person1.xPrsNationalCode = Txt_PNationalCode.Text;
                        Tb_Person1.xPrsPostalCode = Txt_PCodPosti.Text;
                        Tb_Person1.xPrsTel = Txt_PTel.Text;
                        if (Rbtn_Sex.SelectedValue == "male")
                            Tb_Person1.xPrsSex = "male";
                        else
                            Tb_Person1.xPrsSex = "fmale";
                        Tb_Person1.xPrsAddrress = Txt_PAddrress.Text;

                        Tb_Heir1.xRtoId_fk = int.Parse(Ddl_Ratio.SelectedValue);

                        Lts_Inherited.SubmitChanges();
                        Alarm1.ShowMesseage("!عملیات ویرایش با موفقیت انجام شد", this.Page);

                        Lst_Heris = Lts_Inherited.Tb_Heirs.Where(n => n.xDedId_fk == DedId).Select(n => n.Tb_Person).ToList();
                        Gvw_Heris.DataSource = Lst_Heris;
                        Gvw_Heris.DataBind();
                        Gvw_Heris.Visible = true;
                        NewReg();
                         
                        Gvw_Heris.Visible = true;
                    }
                    catch
                    {
                        Alarm1.ShowMesseage("!خطا", this.Page);
                    }
                }

                
            }
            else
            {
                Alarm1.ShowMesseage("پرونده ای  وجود ندارد!", this.Page);
            }
            
        }
        protected void Btn_New_Click(object sender, EventArgs e)
        {
            NewReg();
        }

        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            ResetControls();
            if (Txt_Klasse.Text.Trim() == "" && !IsPostBack)
            {
                return;
            }
            if(Txt_Klasse.Text.Trim()=="")
            {
                Alarm1.ShowMesseage("کلاسه را وارد کنید ", this.Page);
                Session["Classe"] = null;
               
                return;
            }
            Lts_Inherited = new Lts_InheritedDataContext();
            try
            {
                DedId = Lts_Inherited.Tb_Files.SingleOrDefault(n => n.xHozeh == Txt_Hozeh.Text & n.xClass == Txt_Klasse.Text).xDedId_fk;
                Tb_Dead1 = Lts_Inherited.Tb_Deads.Single(n => n.xDedId_pk == DedId);
                Lbl_DedName.Text = Tb_Dead1.xDedFName + " " + Tb_Dead1.xDedLName;
                Lbl_DedNationalcode.Text = Tb_Dead1.xDedNationalCode;

                 
                Btn_Save.Enabled = true;
                Imgbtn_Sssearch.Enabled = true;

                Lst_Heris = Lts_Inherited.Tb_Heirs.Where(n => n.xDedId_fk == DedId).Select(n=>n.Tb_Person).ToList();
                Gvw_Heris.DataSource = Lst_Heris;
                Gvw_Heris.DataBind();
                Gvw_Heris.Visible = true;
                Session["Classe"] = Txt_Klasse.Text.Trim();            

            }
            catch
            {
                Alarm1.ShowMesseage("پرونده ای  وجود ندارد!", this.Page);
                Session["Classe"] = null;
                Gvw_Heris.Visible = false;
                Lbl_DedName.Text =
                Lbl_DedNationalcode.Text = "";
            }
           
        }
        protected void Imgbtn_Sssearch_Click(object sender, ImageClickEventArgs e)
        {
            Tb_PersonExist = Lts_Inherited.Tb_Persons.SingleOrDefault(n => n.xPrsNationalCode == Txt_PNationalCode.Text.Trim());

            if (Tb_PersonExist != null)
            {
                Txt_PFirsName.Text = Tb_PersonExist.xPrsFName;
                Txt_PLastName.Text = Tb_PersonExist.xPrsLName;
                TxtPFatherName.Text = Tb_PersonExist.xPrsFatherName;
                Txt_BirthDate.Text = Tb_PersonExist.xPrsBirthDate;
                Txt_PAddrress.Text = Tb_PersonExist.xPrsAddrress;
                Txt_PCodPosti.Text = Tb_PersonExist.xPrsPostalCode;
                Txt_PIdNo.Text = Tb_PersonExist.xPrsIdNo;
                Txt_PSoodorPlace.Text = Tb_PersonExist.xPrsIssuancePalce;
                Txt_PTel.Text = Tb_PersonExist.xPrsTel;
                Txt_PBirthPlace.Text = Tb_PersonExist.xPrsBirthPlace;
                if (Tb_PersonExist.xPrsSex == "male")
                    Rbtn_Sex.SelectedIndex = 0;
                else
                    Rbtn_Sex.SelectedIndex = 1;

            }
        }

       

        protected void Gvw_Heris_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetControls();
             
            Hfld_Command.Value = "Edit";
            Tb_Person1 = Lts_Inherited.Tb_Persons.SingleOrDefault(n => n.xPrsId_pk == int.Parse(Gvw_Heris.SelectedDataKey.Value.ToString()));
            Txt_PAddrress.Text = Tb_Person1.xPrsAddrress;
            Txt_PBirthPlace.Text = Tb_Person1.xPrsBirthPlace;
            Txt_PCodPosti.Text = Tb_Person1.xPrsPostalCode;
            Txt_PFirsName.Text = Tb_Person1.xPrsFName;
            Txt_PIdNo.Text = Tb_Person1.xPrsIdNo;
            Txt_PLastName.Text = Tb_Person1.xPrsLName;
            Txt_PNationalCode.Text = Tb_Person1.xPrsNationalCode;
            Txt_PSoodorPlace.Text = Tb_Person1.xPrsIssuancePalce;
            Txt_PTel.Text = Tb_Person1.xPrsTel;
            TxtPFatherName.Text = Tb_Person1.xPrsFatherName;
            Txt_BirthDate.Text = Tb_Person1.xPrsBirthDate;

            if (Tb_Person1.xPrsSex == "male")
                Rbtn_Sex.SelectedIndex = 0;
            else
                Rbtn_Sex.SelectedIndex = 1;
            Btn_Cancel.Visible = true;

            Tb_Heir1 = Lts_Inherited.Tb_Heirs.SingleOrDefault(n => n.xPrsId_fk == Tb_Person1.xPrsId_pk && n.xDedId_fk == Tb_Dead1.xDedId_pk);
            if (Tb_Heir1.xRtoId_fk != null)
            {
                Ddl_Ratio.ClearSelection();
                Ddl_Ratio.Items.FindByValue(Tb_Heir1.xRtoId_fk.ToString()).Selected = true;
            }
        }

        protected void Btn_Cancel_Click(object sender, EventArgs e)
        {
            ResetControls();
             
            
        }

        protected void Gvw_Heris_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Tb_Person1 = Lts_Inherited.Tb_Persons.SingleOrDefault(n => n.xPrsId_pk == int.Parse(Gvw_Heris.DataKeys[e.RowIndex].Value.ToString()));
            Tb_Heir1 = Lts_Inherited.Tb_Heirs.SingleOrDefault(n => n.xDedId_fk == Tb_Dead1.xDedId_pk && n.xPrsId_fk == Tb_Person1.xPrsId_pk);
            Lts_Inherited.Tb_Heirs.DeleteOnSubmit(Tb_Heir1);
            try
            {
                Lts_Inherited.SubmitChanges();
                Alarm1.ShowMesseage("!عملیات حذف با موفقیت انجام شد", this.Page);

                Lst_Heris = Lts_Inherited.Tb_Heirs.Where(n => n.xDedId_fk == Tb_Dead1.xDedId_pk).Select(n => n.Tb_Person).ToList();
                Gvw_Heris.DataSource = Lst_Heris;
                Gvw_Heris.DataBind();
                Gvw_Heris.Visible = true;
            }
            catch
            {
                Alarm1.ShowMesseage("!خطا", this.Page);
            }
        }

        protected void Gvw_Heris_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gvw_Heris.PageIndex = e.NewPageIndex;
            Btn_Search_Click(sender, e);
        }

    }
}