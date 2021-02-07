using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Drawing.Printing;
using Ers_Pro.App_Code.Intd_Lts;

namespace Ers_Pro
{
    public partial class Rpt_Pay : System.Web.UI.Page
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
            if (Session["Glb_Tb_User"] == null)
                Response.Redirect("~/Login.aspx");

            (Master.FindControl("Lbl_Title") as Label).Text = "گواهی پرداخت مالیات بر ارث";
            Rpt_Viw1.LocalReport.ReportPath = Server.MapPath("~/Int_Cert/Rpt_Pay.rdlc");
            Rpt_Viw1.LocalReport.Refresh();

            Tb_User1 = Session["Glb_Tb_User"] as Tb_User;
            string Str_Nationalcode;

            try
            {
                Lts_Inherited = new Lts_InheritedDataContext();
                List<CertPay_PersonResult> Lst_CertPay_Person = new List<CertPay_PersonResult>();
                List<CertPay_EstatesResult> Lst_CertPay_Estates = new List<CertPay_EstatesResult>();
                List<CertPay_DeadResult> Lst_CertPay_Dead = new List<CertPay_DeadResult>();

                if (Session["CrtId"] != null)
                {
                    //List<Tb_Person> Lst_Person = Lts_Inherited.Tb_CertPersonPays.Where(n => n.xCrtId_fk == int.Parse(Session["CrtId"].ToString())).Select(n => n.Tb_Person).Distinct().ToList();
                    //foreach (Tb_Person item in Lst_Person)
                    Lst_CertPay_Person = Lts_Inherited.CertPay_Person(int.Parse(Session["CrtId"].ToString())).Distinct().ToList();

                    //List<Tb_Estate> Lst_Estate = Lts_Inherited.Tb_CertPersonPays.Where(n => n.xCrtId_fk == int.Parse(Session["CrtId"].ToString())).Select(n => n.Tb_Estate).Distinct().ToList();
                    //foreach (Tb_Estate item in Lst_Estate)

                    Lst_CertPay_Estates = Lts_Inherited.CertPay_Estates(int.Parse(Session["CrtId"].ToString())).Distinct().ToList();


                    Lst_CertPay_Dead = Lts_Inherited.CertPay_Dead(int.Parse(Session["CrtId"].ToString())).ToList();

                    Tb_User Tb_User2 = Lts_Inherited.Tb_Users.SingleOrDefault(n => n.xUser_Hozeh == (Tb_User1.xUser_Hozeh.Substring(0, 5) + "0"));

                    ReportDataSource Rds = new ReportDataSource();
                    Rds.Name = "CertPay_Person";
                    Rds.Value = Lst_CertPay_Person;

                    ReportDataSource Rds1 = new ReportDataSource();
                    Rds1.Name = "CertPay_Estates";
                    Rds1.Value = Lst_CertPay_Estates;

                    ReportDataSource Rds2 = new ReportDataSource();
                    Rds2.Name = "CertPay_Dead";
                    Rds2.Value = Lst_CertPay_Dead;

                    Rpt_Viw1.LocalReport.DataSources.Clear();
                    Rpt_Viw1.LocalReport.DataSources.Add(Rds);
                    Rpt_Viw1.LocalReport.DataSources.Add(Rds1);
                    Rpt_Viw1.LocalReport.DataSources.Add(Rds2);
                    Rpt_Viw1.LocalReport.Refresh();


                    ReportParameter[] reportParameter = new ReportParameter[22];
                    reportParameter[0] = new ReportParameter("Rpm_Klasse", Lst_CertPay_Dead.Select(n => n.xClass).Single());
                    reportParameter[1] = new ReportParameter("Rpm_SabtDate", Lst_CertPay_Dead.Select(n => n.xCrtRegDate).Single());
                    reportParameter[2] = new ReportParameter("Rpm_RegNo", Lst_CertPay_Dead.Select(n => n.xCrtRegNo).Single());
                    reportParameter[3] = new ReportParameter("Rpm_Gov", Lst_CertPay_Dead.Select(n => n.xCrtTo).Single());
                    reportParameter[4] = new ReportParameter("Rpm_AppNo", Lst_CertPay_Dead.Select(n => n.xAppRegNo).Single());
                    reportParameter[5] = new ReportParameter("Rpm_App_Date", Lst_CertPay_Dead.Select(n => n.xAppRegDate).Single());
                    reportParameter[6] = new ReportParameter("Rpm_PostalCode", Lst_CertPay_Person.Select(n => n.xPrsPostalCode).First());
                    reportParameter[7] = new ReportParameter("Rpm_ShMaliati", "");
                    reportParameter[8] = new ReportParameter("Rpm_Addrress", Lst_CertPay_Person.Select(n => n.xPrsAddrress).First());
                    reportParameter[9] = new ReportParameter("Rpm_Tel", Lst_CertPay_Person.Select(n => n.xPrsTel).First());
                    reportParameter[10] = new ReportParameter("Rpm_HasrNo", Lst_CertPay_Dead.Select(n => n.xAppHasrNo).Single());
                    reportParameter[11] = new ReportParameter("Rpm_HasrDate", Lst_CertPay_Dead.Select(n => n.xAppHasrDate).Single());
                    reportParameter[12] = new ReportParameter("Rpm_ShobeDadgah", Lst_CertPay_Dead.Select(n => n.xAppShobeDadgah).Single());
                    reportParameter[13] = new ReportParameter("Rpm_Dadgah", Lst_CertPay_Dead.Select(n => n.xAppDadgah).Single());
                    reportParameter[14] = new ReportParameter("Rpm_UserFullName", Lst_CertPay_Dead.Select(n => n.xUserFName).Single() + " " + Lst_CertPay_Dead.Select(n => n.xUserLName).Single());
                    reportParameter[15] = new ReportParameter("Rpm_OfficeNo", Lst_CertPay_Dead.Select(n => n.xOfficeNo).Single());
                    reportParameter[16] = new ReportParameter("Rpm_GroupTaxNo", Tb_User1.xUser_Hozeh.Substring(0, 5) + "0");
                    reportParameter[17] = new ReportParameter("Rpm_Taxvahed", Tb_User1.xUser_Hozeh);
                    reportParameter[18] = new ReportParameter("Rpm_OfficeAddrress", Lst_CertPay_Dead.Select(n => n.xOfficeAddrress).Single());
                    reportParameter[19] = new ReportParameter("Rpm_OfficeTel", Lst_CertPay_Dead.Select(n => n.xOfficeTel).Single());
                    reportParameter[20] = new ReportParameter("Rpm_OfficePostal", Lst_CertPay_Dead.Select(n => n.xOfficePostalcode).Single());
                    reportParameter[21] = new ReportParameter("Rpm_AdminGroup", Tb_User2.xUserFName + " " + Tb_User2.xUserLName);


                    Rpt_Viw1.LocalReport.SetParameters(reportParameter);
                    Rpt_Viw1.LocalReport.Refresh();
                }
            }
            catch { }
        }
        protected void Btn_Print_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "window.open('/Int_Cert/Rpt_Print.aspx ','_blank')", true);
        }

      
    }
}