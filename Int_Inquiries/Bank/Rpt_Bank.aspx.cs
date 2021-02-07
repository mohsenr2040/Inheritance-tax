using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ers_Pro.App_Code.Intd_Lts;
using Microsoft.Reporting.WebForms;

namespace Ers_Pro.Int_Inquiries.Bank
{
    public partial class Rpt_Bank : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Glb_Tb_User"] == null)
                Response.Redirect("~/Login.aspx");

            (Master.FindControl("Lbl_Title") as Label).Text = "استعلام از بانک / موسسه";

            Lts_InheritedDataContext Lts_Inherited = new Lts_InheritedDataContext();

            Tb_User Tb_User1 = Session["Glb_Tb_User"] as Tb_User;

            int DedId = int.Parse(Session["Bank_DeadId"].ToString());
            Tb_Dead Tb_Dead1 = Lts_Inherited.Tb_Deads.SingleOrDefault(n => n.xDedId_pk == DedId);


            Rptv_InqBank.LocalReport.ReportPath = Server.MapPath("~/Int_Inquiries/Bank/Rpt_Bank.rdlc");
            Rptv_InqBank.LocalReport.Refresh();

            ReportParameter[] ReportParameter = new ReportParameter[8];
            ReportParameter[0] = new ReportParameter("DedName", Tb_Dead1.xDedFName + " " + Tb_Dead1.xDedLName);
            ReportParameter[1] = new ReportParameter("dedNationalcode", Tb_Dead1.xDedNationalCode);
            ReportParameter[2] = new ReportParameter("DedFotDate", Tb_Dead1.xDedDeadDate);
            ReportParameter[3] = new ReportParameter("UserName", Tb_User1.xUserFName + " " + Tb_User1.xUserLName);
            ReportParameter[4] = new ReportParameter("Inq_date",  Session["Bank_InqDate"].ToString());
            ReportParameter[5] = new ReportParameter("Inq_RegNo", Session["Bank_InqNo"].ToString());
            ReportParameter[6] = new ReportParameter("Hozeh", Tb_User1.xUser_Hozeh);
            ReportParameter[7] = new ReportParameter("Bank_Name", Session["Bank_Name"].ToString());

            Rptv_InqBank.LocalReport.SetParameters(ReportParameter);
            Rptv_InqBank.LocalReport.Refresh();
        }
    }
}