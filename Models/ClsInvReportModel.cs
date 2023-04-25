using DevExpress.XtraEditors.Filtering.Templates;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaSSA.Models
{
    public class ClsInvReportModel
    {
        [Display(Name ="كود الفاتورة")]
        public string InvoiceCode { get; set; }
        [Display(Name = "تاريخ")]
        public DateTime? InvoiceDate { get; set; }
        [Display(Name = "وقت")]
        public TimeSpan? InvoiceTime { get; set; }
        [Display(Name = "خصم")]
        public decimal? Discount { get; set; }
        [Display(Name = "اسم المنتج")]
        public string ProductName { get; set; }
        [Display(Name = "باركود")]
        public string ProductBarcode { get; set; }
        [Display(Name = "سعر الشراء")]
        public decimal? BuyPrice { get; set; }
        [Display(Name = "سعر البيع")]
        public decimal? SellPrice { get; set; }
        [Display(Name = "كمية")]
        public int? ItemQty { get; set; }
        [Display(Name = "احمالي")]
        public decimal? TotalPrice { get; set; }
        [Display(Name = "البائع")]
        public string SallerName { get; set; }
        public int? invoiceType { get; set; }
    }
}
