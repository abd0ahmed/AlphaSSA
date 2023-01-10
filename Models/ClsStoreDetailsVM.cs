using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaSSA.Models
{
    public class ClsStoreDetailsVM
    {
        public int id { get; set; }
        [Display(Name = "سعر الشراء")]
        public decimal? BuyPrice { get; set; }
        [Display(Name = "سعر البيع")]
        public decimal? SellPrice { get; set; }
        [Display(Name = "الكمية")]
        public int Qty { get; set; }
        [Display(Name ="اسم الصنف")]
        public string Name { get; set; }
        public decimal TotalSell { get { return SellPrice * Qty ?? 0; } }
        public decimal TotalBuy { get { return BuyPrice * Qty ?? 0; } }
    }
}
