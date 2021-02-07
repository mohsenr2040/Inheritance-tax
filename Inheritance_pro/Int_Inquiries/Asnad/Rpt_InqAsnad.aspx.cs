using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.Reporting.WebForms;
using System.Web.UI.WebControls;
using Ers_Pro.App_Code.Intd_Lts;

namespace Ers_Pro.Int_Inquiries.Asnad
{
    public partial class Rpt_InqAsnad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Glb_Tb_User"] == null)
                Response.Redirect("~/Login.aspx");

            (Master.FindControl("Lbl_Title") as Label).Text = "استعلام از اداره ثبت اسناد و املاک";

            Lts_InheritedDataContext Lts_Inherited = new Lts_InheritedDataContext();

            Tb_User Tb_User1 = Session["Glb_Tb_User"] as Tb_User;

            List<Inq_AsnadResult> Lst_Inq_Asnad = new List<Inq_AsnadResult>();
            Tb_Dead Tb_Dead1 = new Tb_Dead();
            int DedId = 0;
            string Str_Inq_date = "";
            string Str_Inq_RegNo = "";


            if (Session["InqId"] != null)
            {
                List<Tb_InqEstate> Lst_Inq = Lts_Inherited.Tb_InqEstates.Where(n => n.xInqId_fk == int.Parse(Session["InqId"].ToString())).ToList();
                Tb_Inquiry Tb_Inquiry1 = Lts_Inherited.Tb_Inquiries.SingleOrDefault(n => n.xInqId_pk == int.Parse(Session["InqId"].ToString()));

                foreach(Tb_InqEstate item in Lst_Inq)
                {
                    Lst_Inq_Asnad.AddRange(Lts_Inherited.Inq_Asnad(Tb_Inquiry1.xDedId_fk, item.xEstId_fk));
                }

                Str_Inq_date = Tb_Inquiry1.xInqDate;
                Str_Inq_RegNo = Tb_Inquiry1.xInqRegNo;
                Tb_Dead1 = Lts_Inherited.Tb_Deads.SingleOrDefault(n => n.xDedId_pk == Tb_Inquiry1.xDedId_fk);
            }
            else
            {
                DedId = int.Parse(Session["Asnad_DeadId"].ToString());
                Tb_Dead1 = Lts_Inherited.Tb_Deads.SingleOrDefault(n => n.xDedId_pk == DedId);

                List<string> Lst_Estates = new List<string>();
                Lst_Estates = Session["Asnad_EstateId"].ToString().Split('&').ToList();
                Lst_Estates.RemoveAt(Lst_Estates.Count - 1);

                Str_Inq_date =Session["Asnad_InqDate"].ToString();
                Str_Inq_RegNo=Session["Asnad_InqNo"].ToString();

                foreach (string item in Lst_Estates)
                    Lst_Inq_Asnad.AddRange(Lts_Inherited.Inq_Asnad(DedId, int.Parse(item)));
            }
            Rptv_InqAsnad.LocalReport.ReportPath = Server.MapPath("~/Int_Inquiries/Asnad/Rpt_InqAsnad.rdlc");
            Rptv_InqAsnad.LocalReport.Refresh();

            ReportDataSource Rds = new ReportDataSource();
            Rds.Name = "Inq_Asnad";
            Rds.Value = Lst_Inq_Asnad;

            Rptv_InqAsnad.LocalReport.DataSources.Clear();
            Rptv_InqAsnad.LocalReport.DataSources.Add(Rds);
            Rptv_InqAsnad.LocalReport.Refresh();

           

            ReportParameter[] ReportParameter=new ReportParameter[7];
            ReportParameter[0] = new ReportParameter("DedName", Tb_Dead1.xDedFName + " " + Tb_Dead1.xDedLName);
            ReportParameter[1] = new ReportParameter("dedNationalcode", Tb_Dead1.xDedNationalCode);
            ReportParameter[2] = new ReportParameter("DedFotDate", Tb_Dead1.xDedDeadDate);
            ReportParameter[3] = new ReportParameter("UserName", Tb_User1.xUserFName + " " + Tb_User1.xUserLName);
            ReportParameter[4] = new ReportParameter("Inq_date", Str_Inq_date );
            ReportParameter[5] = new ReportParameter("Inq_RegNo",  Str_Inq_RegNo );
            ReportParameter[6] = new ReportParameter("Hozeh", Tb_User1.xUser_Hozeh);

            Rptv_InqAsnad.LocalReport.SetParameters(ReportParameter);
            Rptv_InqAsnad.LocalReport.Refresh();
        }

    }
}