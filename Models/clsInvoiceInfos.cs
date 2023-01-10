using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.DataFormats;

namespace AlphaSSA.Models
{
   public class clsInvoiceInfos:TblInvoiceHeader
    {
        [Display(Name ="م")]
        public int invoiceID { get; set; }
        [Display(Name = "كود")]
        public string Code { get; set; }
        [Display(Name = "نوع الفاتورة")]
        public string InvType { get; set; }
        [Display(Name = "تاريخ الفاتورة")]
        [DataType(DataType.DateTime)]
        public DateTime InvoiceDate { get; set; }
        [Display(Name  = "وقت الفاتورة")]
        
        [DataType(DataType.Time)]
        public TimeSpan? InvoiceTime { get; set; }
        [Display(Name = "وقت الفاتورة")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString =" hh : mm tt")]
        public DateTime TimeConverted { get { return DateTime.Today.Add(InvoiceTime??TimeSpan.Parse("00:00:00:00")); } }
        [Display(Name = "اجمالى")]
        public decimal TotolPrice { get; set; }
        [Display(Name = "العميل")]
        public string ClinetName { get; set; }
        [Display(Name = "الخصم")]
        public decimal Discount1 { get; set; }
        [Display(Name = "كاشير")]
        public string Seller { get { return GetSeller(); } }
        string GetSeller()
        {
            string s="";
            using (var db = new SSADBDataContext())
            {
                
                if (Saller!=null&&Saller>0)
                {
                    return db.TblSallers.SingleOrDefault(x => x.ID == Saller).Name;
                }
            }
            return s;
        }

    }
}
