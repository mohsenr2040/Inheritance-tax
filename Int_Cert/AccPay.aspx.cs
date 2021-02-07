using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ers_Pro.App_Code.Intd_Lts;

namespace Ers_Pro
{
    public partial class AccPay : System.Web.UI.Page
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
        public Tb_CertPay Tb_CertPay1
        {
            get { return Session[Str_PageId + "_Tb_CertPay"] as Tb_CertPay; }
            set { Session[Str_PageId + "_Tb_CertPay"] = value; }
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
            (Master.FindControl("Lbl_Title") as Label).Text = "صدور گواهی پرداخت مالیات بر ارث";
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
                Ddl_day.Items.Add("");
                Ddl_Mounth.Items.Add("");
                Ddl_Year.Items.Add("");

                string[] Lst_Day = new string[31];
                string j = "";
                int i;
                for (i = 0; i <= 30; i++)
                {
                    j = (i + 1).ToString();
                    if (i < 9)
                        j = "0" + j;
                    Lst_Day[i] = j;
                }
                foreach (string item in Lst_Day)
                {
                    Ddl_day.Items.Add(item.ToString());
                }
                string[] Lst_Mounth = new string[12];
                for (i = 0; i <= 11; i++)
                {
                    j = (i + 1).ToString();
                    if (i < 9)
                        j = "0" + j;
                    Lst_Mounth[i] = j;
                }
                foreach (string item in Lst_Mounth)
                {
                    Ddl_Mounth.Items.Add(item.ToString());
                }
                string[] Lst_Year = new string[100];
                for (i = 1300; i <= 1399; i++)
                {
                    j = (i + 1).ToString();
                    Lst_Year[i - 1300] = j;
                }
                foreach (string item in Lst_Year)
                {
                    Ddl_Year.Items.Add(item.ToString());
                }
                //Lbl_Msg.Visible = false;
                Ddl_Year.SelectedItem.Text = "1395";
            }
            #endregion
        }
        public void ResetControls()
        {
            Ddl_day.Text =
                Lbl_DedName.Text =
                Lbl_DedNationalcode.Text =
                Ddl_Mounth.Text =
                Txt_Nahad.Text=
                Txt_CrtNo.Text = "";
            Lbl_Msg.Visible = false;
            Chk_Estates.Items.Clear();
            Chk_Heirs.Items.Clear();
            Chk_Estates.Items.Add(new ListItem("دارایی...", "0"));
            Chk_Heirs.Items.Add(new ListItem("وراث...", "0"));
            Chk_Estates.Enabled = false;
            Chk_Heirs.Enabled = false;
            MainTable.Rows[7].Cells[0].Visible = false;
            Gvw_CertPay.Visible = false;
            
        }

        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            if (Txt_Klasse.Text.Trim() == "" && !IsPostBack)
            {
                return;
            }
            ResetControls();
            if (Txt_Klasse.Text.Trim() == "")
            {
                Alarm.ShowMesseage("کلاسه را وارد کنید ", this.Page);
                Session["Classe"] = null;
                return;
            }

            Lts_Inherited = new Lts_InheritedDataContext();

            Tb_File Tb_Files1 = Lts_Inherited.Tb_Files.SingleOrDefault(n => n.xHozeh == Txt_Hozeh.Text & n.xClass == Txt_Klasse.Text);
            if (Tb_Files1 == null)
            {
                ResetControls();
                Lbl_Msg.Text = "پرونده ای  وجود ندارد!";
                Lbl_Msg.ForeColor = System.Drawing.Color.Red;
                Lbl_Msg.Visible = true;
                Session["Classe"] = null;
                return;
            }
            Session["Classe"] = Txt_Klasse.Text.Trim();
            Chk_Estates.Items.Clear();
            Chk_Heirs.Items.Clear();
            Chk_Estates.Enabled = true;
            Chk_Heirs.Enabled = true;

            Tb_Dead1 = Lts_Inherited.Tb_Deads.SingleOrDefault(n => n.xDedId_pk == Tb_Files1.xDedId_fk);
            Lbl_DedName.Text = Tb_Dead1.xDedFName + " " + Tb_Dead1.xDedLName;
            Lbl_DedNationalcode.Text = Tb_Dead1.xDedNationalCode;

            List<Tb_Heir> Lst_Tb_Heir = Lts_Inherited.Tb_Heirs.Where(n => n.xDedId_fk == Tb_Dead1.xDedId_pk).ToList();

            foreach (Tb_Heir item in Lst_Tb_Heir)
            {
                Chk_Heirs.Items.Add(new ListItem(item.Tb_Person.xPrsFName + " " + item.Tb_Person.xPrsLName, item.xPrsId_fk.ToString()));
            }

            List<Tb_Estate> Lst_Estates = Lts_Inherited.Tb_Estates.Where(n => n.xDedId_fk == Tb_Dead1.xDedId_pk && n.xEstIsDeleted_==false).ToList();
            foreach (Tb_Estate item in Lst_Estates)
            {
                Chk_Estates.Items.Add(new ListItem(item.Tb_EstateType.xEstType + "(" + item.xEstDescription.Substring(0, item.xEstDescription.Length < 10 ? item.xEstDescription.Length : 10) + "..." + ")", item.xEstId_pk.ToString()));
            }

            if (Lst_Tb_Heir.Count==0)
            {
                Chk_Heirs.Items.Add(new ListItem("وراث...", "0"));
                Chk_Heirs.Enabled = false;
            }
            if (Lst_Estates.Count==0)
            {
                Chk_Estates.Items.Add(new ListItem("دارایی...", "0"));
                Chk_Estates.Enabled = false;
            }
            List<Tb_CertPay> Lst_Cert = Lts_Inherited.Tb_CertPays.Where(n => n.xDedId_fk == Tb_Dead1.xDedId_pk).ToList();
            Gvw_CertPay.DataSource = Lst_Cert;
            Gvw_CertPay.DataBind();
            Gvw_CertPay.Visible = true;
            MainTable.Rows[7].Cells[0].Visible = true;
        }

        protected void Btn_Sodor_Click(object sender, EventArgs e)
        {
            if (Txt_Klasse.Text.Trim() == "")
            {
                Alarm.ShowMesseage("!کلاسه را وارد کنید", this.Page);
                return;
            }
            if (Chk_Heirs.Items.Count == 0)
            {
                Lbl_Msg.Text = "وراث را ثبت نمایید!";
                Lbl_Msg.ForeColor = System.Drawing.Color.Red;
                Lbl_Msg.Visible = true;
                return;
            }
            if (Chk_Estates.Items.Count == 0)
            {
                Lbl_Msg.Text = "دارایی ها را ثبت نمایید!";
                Lbl_Msg.ForeColor = System.Drawing.Color.Red;
                Lbl_Msg.Visible = true;
                return;
            }
            if (Lts_Inherited.Tb_Applies.SingleOrDefault(n => n.Tb_Dead == Tb_Dead1) == null)
            {
                Lbl_Msg.Text = "اطلاعات فرم درخواست ثبت نگردیده است!";
                Lbl_Msg.ForeColor = System.Drawing.Color.Red;
                Lbl_Msg.Visible = true;
                return;
            }

            bool bol_Flag = false;
            foreach (ListItem HrsItem in Chk_Heirs.Items)
                if (HrsItem.Selected)
                    foreach (ListItem EstItem in Chk_Estates.Items)
                        if (EstItem.Selected)
                            if (Lts_Inherited.Tb_CertPersonPays.SingleOrDefault(n => n.xPrsId_fk == int.Parse(HrsItem.Value) && n.xEstId_fk == int.Parse(EstItem.Value)) != null)
                            {
                                bol_Flag = true;
                                break;
                            }
            if (bol_Flag)
            {

                Tb_File Tb_File1 = Lts_Inherited.Tb_Files.Where(n => n.xDedId_fk == Tb_Dead1.xDedId_pk).First();
                Lbl_Msg.Text = "گواهی برای اشخاص انتخاب شده با دارایی های انتخابی صادر گردیده است"+"!";
                Lbl_Msg.ForeColor = System.Drawing.Color.Red;
                Lbl_Msg.Visible = true;
                return;
            }

            string Str_Nationacode = Tb_Dead1.xDedNationalCode;
            Tb_CertPay1 = new Tb_CertPay();
            Tb_CertPay1.xCrtRegNo = Txt_CrtNo.Text;
            Tb_CertPay1.xCrtRegDate = Ddl_Year.Text + "/" + Ddl_Mounth.Text + "/" + Ddl_day.Text;
            Tb_CertPay1.xDedId_fk = Tb_Dead1.xDedId_pk;
            Tb_CertPay1.xCrtTo = Txt_Nahad.Text.Trim();
            Lts_Inherited.Tb_CertPays.InsertOnSubmit(Tb_CertPay1);

            foreach (ListItem ItemHeir in Chk_Heirs.Items)
                if (ItemHeir.Selected)
                    foreach (ListItem ItemEstate in Chk_Estates.Items)
                    {
                        if (ItemEstate.Selected)
                        {
                            Tb_CertPersonPay Tb_CertPersonPay1 = new Tb_CertPersonPay();
                            Tb_CertPersonPay1.Tb_CertPay = Tb_CertPay1;
                            Tb_CertPersonPay1.xPrsId_fk = int.Parse(ItemHeir.Value);
                            Tb_CertPersonPay1.xEstId_fk = int.Parse(ItemEstate.Value);
                            Lts_Inherited.Tb_CertPersonPays.InsertOnSubmit(Tb_CertPersonPay1);
                        }
                    }
            try
            {
                Lts_Inherited.SubmitChanges();
            }
            catch (Exception ex)
            {
                Lbl_Msg.Text = "Error!" + ex.ToString();
                Lbl_Msg.ForeColor = System.Drawing.Color.Red;
                Lbl_Msg.Visible = true;
                return;
            }

            Ddl_day.Text =
               Ddl_Mounth.Text =
               Txt_CrtNo.Text = "";
            foreach(ListItem item in Chk_Estates.Items)
                item.Selected=false;
            foreach (ListItem item in Chk_Heirs.Items)
                item.Selected = false;

            Lbl_Msg.Text = "گواهی صادر گردید" +"!";
            Lbl_Msg.ForeColor = System.Drawing.Color.Green;
            Lbl_Msg.Visible = true;


            List<Tb_CertPay> Lst_Cert = Lts_Inherited.Tb_CertPays.Where(n => n.xDedId_fk == Tb_Dead1.xDedId_pk).ToList();
            Gvw_CertPay.DataSource = Lst_Cert;
            Gvw_CertPay.DataBind();
            Gvw_CertPay.Visible = true;
            MainTable.Rows[7].Cells[0].Visible = true;
        }

        protected void Gvw_CertPay_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["CrtId"] = Gvw_CertPay.SelectedDataKey.Value;
            Response.Redirect("~/Int_Cert/Rpt_Pay.aspx", false);
        }
    }
}