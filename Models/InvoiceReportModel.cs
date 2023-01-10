using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaSSA.Models
{
   public class InvoiceReportModel
    {
        public DateTime Date { get; set; }
        public decimal Salesinv { get; set; }
        public decimal PurchaseInv { get; set; }
        public decimal salesRetInv { get; set; }
        public decimal PurchaseRetInv { get; set; }
    }
}
