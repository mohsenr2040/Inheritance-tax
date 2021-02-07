using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using Ers_Pro.App_Code.Intd_Lts;

namespace Ers_Pro.Int_Inquiries.TaxOffice
{
    public partial class Rpt_TaxOffice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Glb_Tb_User"] == null)
                Response.Redirect("~/Login.aspx");

            (Master.FindControl("Lbl_Title") as Label).Text = "استعلام از اداره امور مالیاتی";

            Lts_InheritedDataContext Lts_Inherited = new Lts_InheritedDataContext();

            Tb_User Tb_User1 = Session["Glb_Tb_User"] as Tb_User;

            int DedId = int.Parse(Session["Office_DeadId"].ToString());
            Tb_Dead Tb_Dead1 = Lts_Inherited.Tb_Deads.SingleOrDefault(n => n.xDedId_pk == DedId);

            List<string> Lst_Estates = new List<string>();
            Lst_Estates = Session["Office_EstateId"].ToString().Split('&').ToList();
            Lst_Estates.RemoveAt(Lst_Estates.Count - 1);

            List<Inq_AsnadResult> Lst_Inq_Asnad = new List<Inq_AsnadResult>();

            foreach (string item in Lst_Estates)
                Lst_Inq_Asnad.AddRange(Lts_Inherited.Inq_Asnad(DedId, int.Parse(item)));

            Rptv_InqOffice.LocalReport.ReportPath = Server.MapPath("~/Int_Inquiries/TaxOffice/Rpt_TaxOffice.rdlc");
            Rptv_InqOffice.LocalReport.Refresh();

            ReportDataSource Rds = new ReportDataSource();
            Rds.Name = "Inq_Office";
            Rds.Value = Lst_Inq_Asnad;

            Rptv_InqOffice.LocalReport.DataSources.Clear();
            Rptv_InqOffice.LocalReport.DataSources.Add(Rds);
            Rptv_InqOffice.LocalReport.Refresh();

            Tb_User Tb_User2 = Lts_Inherited.Tb_Users.SingleOrDefault(n => n.xUser_Hozeh == (Tb_User1.xUser_Hozeh.Substring(0, 5) + "0"));


            ReportParameter[] ReportParameter = new ReportParameter[7];
            ReportParameter[0] = new ReportParameter("DedName", Tb_Dead1.xDedFName + " " + Tb_Dead1.xDedLName);
            ReportParameter[1] = new ReportParameter("dedNationalcode", Tb_Dead1.xDedNationalCode);
            ReportParameter[2] = new ReportParameter("DedFotDate", Tb_Dead1.xDedDeadDate);
            ReportParameter[3] = new ReportParameter("GroupName", Tb_User2.xUserFName + " " + Tb_User2.xUserLName);
            ReportParameter[4] = new ReportParameter("Inq_date", Session["Office_InqDate"].ToString());
            ReportParameter[5] = new ReportParameter("Inq_RegNo", Session["Office_InqNo"].ToString());
            ReportParameter[6] = new ReportParameter("Office_Name", Session["Office_Name"].ToString());

            Rptv_InqOffice.LocalReport.SetParameters(ReportParameter);
            Rptv_InqOffice.LocalReport.Refresh();
        }
    }
}