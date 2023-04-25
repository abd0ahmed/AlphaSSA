using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaSSA.Models
{
    public class ClsInvoiceReturnModel
    {
        public int ID { get; set; }
        public string ItemName { get; set; }
        public int qty { get; set; }
        public decimal Price { get; set; }
        public decimal totalPrice { get; set; }
        public string Code { get; set; }
        public decimal Discount { get; set; }
  
        public int GetStoreID(int invid)
        {
            int s = 0;
            using (var db = new SSADBDataContext())
            {
               s = (int)db.TbLInvoiceDetailes.SingleOrDefault(x => x.itemID == this.ID&&x.InvoiceID== invid).StoreID;
            }
            return s;
        }

    }
}
