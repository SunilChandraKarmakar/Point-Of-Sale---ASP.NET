using Microsoft.Reporting.WebForms;
using Point_Of_Sale.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Point_Of_Sale
{
    public partial class Report : System.Web.UI.Page
    {
        private POS_WebEntities db = new POS_WebEntities();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var rs = db.Customers.OrderByDescending(a => a.ID).Select(a => a.ID).First();
                GetReport(Convert.ToInt32(rs));
            }
        }

        public void GetReport(int Invo)
        {
            var r = (from a in db.ReportDetails()
                     select a);

            ReportDataSource rd = new ReportDataSource("DataSet1", r.OrderByDescending(g => g.InvoiceNo).Where(g => g.InvoiceNo == Invo).ToList());
            ReportViewer1.LocalReport.DataSources.Add(rd);
            ReportViewer1.LocalReport.Refresh();
        }
    }
}