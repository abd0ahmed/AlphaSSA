using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaSSA.Models
{
    public class ClsInvoiceProducts
    {
        public int ID { get ; set; }
        public string  ItemName { get; set; }
        public int qty { get; set; }
        public decimal Price { get; set; }
        public decimal totalPrice { get; set; }
        public int index { get; set; }

    }
}
