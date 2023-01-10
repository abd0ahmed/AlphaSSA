using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaSSA.Internal
{
   public static class Master
    {
        public class ValueAndID
        {
            public int ID { get; set; }
            public string value { get; set; }

        }
        #region InvoiceTypes
        public static List<ValueAndID> InvoiceTypes = new List<ValueAndID>()
        { new ValueAndID{ID=0,value="فاتورة مبيعات"} ,
            new ValueAndID{ID=1,value="فاتورة مشتريات"},
            new ValueAndID{ID=2,value="مردود بيع"},
            new ValueAndID{ID=3,value="مردود شراء"}
        };
        public enum InvoiceType
        {
            Sales = SourceType.Sales,
            Purchase = SourceType.Purchase,
            salesReturn = SourceType.salesReturn,
            PurchaseReturn = SourceType.PurchaseReturn
        }
        public enum SourceType
        {
            Sales,
            Purchase,
            salesReturn,
            PurchaseReturn
        }
        #endregion
        
        public enum UserType
        {
            Admin,
            Casher
            
        }
        public static List<ValueAndID> UserTypes = new List<ValueAndID>()
        { new ValueAndID{ID=0,value="Admin"} ,
            new ValueAndID{ID=1,value="casher"},

        };
        public static List<ValueAndID> ShiftStatus = new List<ValueAndID>()
        { new ValueAndID{ID=1,value="مفتوح"} ,
            new ValueAndID{ID=2,value="مغلق"},
            
        };
        public enum ShiftState
        {
            open = 0,
            close 
            
        }


    }
}
