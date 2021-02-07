using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ers_Pro
{
    public partial class AccPay : System.Web.UI.Page
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Glb_Tb_User"] == null)
                Response.Redirect("~/Login.aspx");
            
            (Master.FindControl("Lbl_Title") as Label).Text = "صدور کواهی پرداخت مالیات بر ارث";
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
                string[] Lst_Year = new string[97];
                for (i = 1300; i <= 1396; i++)
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
                Ddl_Mounth.Text =
                Txt_CrtNo.Text = "";
            Chk_Estates.Items.Clear();
            Chk_Heirs.Items.Clear();
        }

        Tb_Dead Tb_Dead2 = null;
        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            ResetControls();
            if (TxtNationalcode.Text.Trim() == "")
            {
                Lbl_Msg.Text = "کد ملی را وارد نمایید!";
                Lbl_Msg.ForeColor = System.Drawing.Color.Red;
                Lbl_Msg.Visible = Visible;
                return;
            }
            Lts_Inherited = new Lts_InheritedDataContext();

            Tb_Dead2 = Lts_Inherited.Tb_Deads.SingleOrDefault(d => d.xDedNationalCode == TxtNationalcode.Text);
            if (Tb_Dead2 == null)
            {
                Lbl_Msg.Text = "کد ملی وجود ندارد!";
                Lbl_Msg.ForeColor = System.Drawing.Color.Red;
                Lbl_Msg.Visible = Visible;
                return;
            }

            List<Tb_Heir> Lst_Tb_Heir = Lts_Inherited.Tb_Heirs.Where(n => n.xDedId_fk == Tb_Dead2.xDedId_pk).ToList();
            
            foreach (Tb_Heir item in Lst_Tb_Heir)
            {
                Tb_Person Tb_Person1 = Lts_Inherited.Tb_Persons.Single(n => n.xPrsId_pk == item.xPrsId_fk);
                Chk_Heirs.Items.Add(new ListItem(Tb_Person1.xPrsName + " " + Tb_Person1.xPrsFamily, Tb_Person1.xPrsId_pk.ToString()));
            }
            
            List<Tb_Estate> Lst_Estates = Lts_Inherited.Tb_Estates.Where(n => n.xDedId_fk == Tb_Dead2.xDedId_pk).ToList();
            foreach (Tb_Estate item in Lst_Estates)
            {
                Chk_Estates.Items.Add(new ListItem(item.xEstType, item.xEstId_pk.ToString()));
            }
        }

        protected void Btn_Sodor_Click(object sender, EventArgs e)
        {

            string Str_Nationacode = TxtNationalcode.Text;

            if (Lts_Inherited.Tb_CertPays.SingleOrDefault(n => n.xDedId_fk == Tb_Dead2.xDedId_pk) == null)
            {
                Tb_CertPay1 = new Tb_CertPay();
                Tb_CertPay1.xCrtRegNo = Txt_CrtNo.Text;
                Tb_CertPay1.xCrtRegDate = Ddl_Year.Text + "/" + Ddl_Mounth.Text + "/" + Ddl_day.Text;
                Tb_CertPay1.xDedId_fk = Tb_Dead2.xDedId_pk;
                Lts_Inherited.Tb_CertPays.InsertOnSubmit(Tb_CertPay1);

                try
                {
                    Lts_Inherited.SubmitChanges();
                    Session["Nationalcode"] = Str_Nationacode;
                    Response.Redirect("~/Rpt_Pay.aspx", false);
                }
                catch (Exception ex)
                {
                    Lbl_Msg.Text = "Error!" + ex.ToString();
                    Lbl_Msg.ForeColor = System.Drawing.Color.Red;
                    Lbl_Msg.Visible = true;
                }

            }
            else
            {
                Tb_File Tb_File1 = Lts_Inherited.Tb_Files.Where(n => n.xDedId_fk == Tb_Dead2.xDedId_pk).First();
                Lbl_Msg.Text = "برای این شخص قبلا گواهی صادر گردیده است!:" + "حوزه:" + Tb_File1.xHozeh + "---" + "کلاسه:" + Tb_File1.xClass;
                Lbl_Msg.ForeColor = System.Drawing.Color.Red;
                Lbl_Msg.Visible = true;
            }
        }
    }
}