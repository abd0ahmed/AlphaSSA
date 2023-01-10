using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaSSA.Models
{
   public class clsDilyreportModel:TblInvoiceHeader 
    {
        public clsDilyreportModel(TblInvoiceHeader header)
        {
            base.ID = header.ID;
            base.ClientID = header.ClientID;
            base.code = header.code;
            base.Date = header.Date;
            base.Time = header.Time;
            base.casher = header.casher;
            base.Discount = header.Discount;
            base.invoiceType = header.invoiceType;
            base.Total = header.Total;
            base.net = header.net;
            base.SourceID = header.SourceID;
            base.Printed = header.Printed;
            base.Saller = header.Saller;
           

        }
       
        public List<TbLInvoiceDetaile> TbLInvoiceDetailes { get; set; }

    }
}
