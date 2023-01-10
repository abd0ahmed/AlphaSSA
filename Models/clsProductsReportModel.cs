using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaSSA.Models
{
    public class clsProductsReportModel
    {
        public int ProductID { get; set; }
        [Display(Name ="باركود")]
        public string Barcode { get; set; }
        [Display(Name = "اسم المنتج")]
        public string Name { get; set; }
        [Display(Name = "سعر الشراء")]
        public decimal? BuyPrice { get; set; }
        [Display(Name = "سعر البيع")]
        public decimal? sellPrice { get; set; }
        [Display(Name = "عدد")]
        public int SellCount { get { return GetSellCount(); } }
        [Display(Name = "اجمالي")]
        public decimal? sellTotal { get { return sellcount * sellPrice; } }
        int sellcount = 0;
        decimal totalPrice = 0;
        int GetSellCount()
        {
            if (sellcount==0)
            {
                using (var db= new SSADBDataContext())
                {
                    sellcount = (from pr in db.TblProducts
                                 join dt in db.TbLInvoiceDetailes on pr.ID equals dt.itemID
                                join hr in db.TblInvoiceHeaders on dt.InvoiceID equals hr.ID
                                where hr.invoiceType == (int)Internal.Master.InvoiceType.Sales && dt.itemID==ProductID
                                select dt).Sum(x => x.itemQty)??0;
                        
                }
            }
            return sellcount;
        }
        decimal GetSellprice()
        {
            if (sellcount == 0)
            {
                using (var db = new SSADBDataContext())
                {
                    totalPrice = (from pr in db.TblProducts
                                 join dt in db.TbLInvoiceDetailes on pr.ID equals dt.itemID
                                 join hr in db.TblInvoiceHeaders on dt.InvoiceID equals hr.ID
                                 where hr.invoiceType == (int)Internal.Master.InvoiceType.Sales && dt.itemID == ProductID
                                 select dt).Sum(x => x.TotalPrice) ?? 0;

                }
            }
            return totalPrice;
        }
    }
     
}
