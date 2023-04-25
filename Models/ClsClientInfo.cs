using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphaSSA.Internal;

namespace AlphaSSA.Models
{
    public class ClsClientInfo: TblClient
    {
       
        SSADBDataContext db;
       public ClsClientInfo()
        {
            GetClientInvoices();
            GetClientBalance();
            GetLAstInv();
            invoiceHeaders = null;

        }
        public List<CLsProductInvoicesInfo> ClientInvoices { get { return GetClientInvoices(); } }
        public decimal? ClientBalance { get { return GetClientBalance(); } }
        public DateTime? LastInvo { get { return GetLAstInv(); } }
        public int InvCount { get { return ClientInvoices.Where(x => x.invoiceType == (int)Master.InvoiceType.Sales).Count(); } }

        decimal? _ClintBalance = 0;
        DateTime? _LastInvo = null;

        private List<CLsProductInvoicesInfo> invoiceHeaders;
        List<CLsProductInvoicesInfo> GetClientInvoices()
        {
            if (invoiceHeaders == null||invoiceHeaders==new List<CLsProductInvoicesInfo>())
            {
                using (db = new SSADBDataContext())
                {
                    var data  = (from h in db.TblInvoiceHeaders
                                 join s in db.TblSallers on h.Saller equals s.ID
                                 where h.ClientID == ID
                                                 select new CLsProductInvoicesInfo()
                                                 {
                                                     code = h.code,
                                                     Date = h.Date,
                                                     Discount = h.Discount,
                                                     ID = h.ID,
                                                     invoiceType = h.invoiceType,
                                                     net = h.net,
                                                     Printed = h.Printed,
                                                     SourceID = h.SourceID,
                                                     Total = h.Total,
                                                     _saller=s.Name
                                                     
                                                 }
                                  ).ToList();
                    invoiceHeaders = data.ToList();
                   
                }
            }
                return invoiceHeaders;
            

        }
        DateTime? GetLAstInv()
        {
            if (_LastInvo!=null)
            {
                return _LastInvo;
            }
            if (ClientInvoices.Count>0)
            {
                return _LastInvo= ClientInvoices.LastOrDefault().Date;
            }
            return null;
        }
        decimal? GetClientBalance()
        {
            if (_ClintBalance != 0)
            {
                return _ClintBalance;
            }
            if (ClientInvoices.Count > 0)
            {
                return _ClintBalance = ClientInvoices.Where(x => x.invoiceType == (byte)Internal.Master.InvoiceType.Sales).Sum(x=>x.net)
                    - ClientInvoices.Where(x => x.invoiceType == (byte)Internal.Master.InvoiceType.salesReturn).Sum(x => x.net);

            }
            return 0;
        }
    }
}
