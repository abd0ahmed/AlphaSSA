using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaSSA.Models
{
    public class CLsProductInvoicesInfo:TblInvoiceHeader
    {
        int itemid;
        public CLsProductInvoicesInfo()
        {
            
        }

        public CLsProductInvoicesInfo(int ID)
        {
            itemid = ID;
        }
        [Display(Name = "نوع الفاتورة")]
        public string invoiceTypeName { get { return Internal.Master.InvoiceTypes[(byte)invoiceType].value; } }
        [Display(Name = "كاشير")]
        public string _saller { get; set; }
        [Display(Name = "العميل")]
        public string Client { get; set; }
        int? _qty = null;
        [Display(Name = "كمية")]
        public int qty { get { return GetProductInvQty(); } }
        [Display(Name = "م")]
        public new int ID { get; set; }
        [Display(Name = "كود")]
        public new string code { get; set; }
        int GetProductInvQty()
        {
            if (itemid==0)
            {
                return 0;
            }
            if (_qty==null)
            {
                using (var db =new SSADBDataContext())
                {
                    List<TbLInvoiceDetaile> d = db.TbLInvoiceDetailes.Where(x => x.InvoiceID == ID).ToList();
                    return d.SingleOrDefault(x => x.itemID == itemid).itemQty??0;
                }
            }
            return _qty??0;
        }

    }
}
