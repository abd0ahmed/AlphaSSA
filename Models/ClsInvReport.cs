using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaSSA.Models
{
   public class ClsInvReport
    {
        public DateTime dateFrom { get; set; }
        public DateTime dateTo { get; set; }
        public decimal TotalSales { get; set; }
        public decimal totalPurchase { get; set; }
        public decimal totalSalesRet { get; set; }
        public decimal TodalpurchaseRet { get; set; }
        List<InvoiceReportModel> ds;
        public ClsInvReport(DateTime dateFrom, DateTime dateTo)
        {
            this.dateFrom = dateFrom;this.dateTo = dateTo;
            PrepairData();
        }

        private void PrepairData()
        {
            using (var db=new SSADBDataContext())
            {
            }
        }
    }
}
