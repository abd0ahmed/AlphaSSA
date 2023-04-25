using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaSSA.Models
{
    public class ProductFullIvoiceDataModel
    {
        [Display(Name ="نوع الفاتورة")]
        public Byte? InvoiceType { get; set; }
        [Display(Name = "كود")]
        public string Code { get; set; }
        [Display(Name = "كمية")]
        public int ItemQty { get; set; }
        [Display(Name = "سعر")]
        public decimal? Price { get; set; }
        [Display(Name = "خصم")]
        public decimal? Discount { get; set; }
        [Display(Name = "اجمالي")]
        public decimal? Total { get; set; }
        [Display(Name = "تاريخ")]
        public DateTime? Date { get; set; }
        [Display(Name = "وقت")]
        public TimeSpan? Time { get; set; }
        [Display(Name = "العميل")]
        public string ClientName { get; set; }
        [Display(Name = "البائع")]
        public string SallerName { get; set; }
        [Display(Name = "م")]
        public int InvoiceID { get; set; }

    }
}
