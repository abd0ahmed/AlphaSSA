using AlphaSSA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaSSA.DataProcessors
{
    public class FullProductProcessor
    {
        public SSADBDataContext context { get; set; }
        public TblProduct Product { get; set; }
        public List<TblInvoiceHeader> ProductInvoices { get; set; }
        public List<TbLInvoiceDetaile> ProductIVDetails { get; set; }
        public List<TblStoreProduct> StoreProducts { get; set; }
        public FullProductProcessor(int ID,SSADBDataContext context)
        {
            this.context = context;
            GetProductData(ID);
        }
        private void GetProductData(int iD)
        {
            Product = context.TblProducts.FirstOrDefault(x => x.ID == iD);
            var data = (from h in context.TblInvoiceHeaders
                        join d in context.TbLInvoiceDetailes on h.ID equals d.InvoiceID
                        where d.itemID == iD
                        select h
                       ) .ToList();
            ProductInvoices = data;
            ProductIVDetails=context.TbLInvoiceDetailes.Where(x=>x.itemID==iD).ToList();
            StoreProducts = context.TblStoreProducts.Where(x => x.productID == iD).ToList();
        }

        public List<TblInvoiceHeader> SalesInvoices
        {
            get
            {
                var data = ProductInvoices.Where(x => x.invoiceType == (int)Internal.Master.InvoiceType.Sales);
                return data.ToList();
            }
        }
        public List<TblInvoiceHeader> PurchaseInvoices
        {
            get
            {
                var data = ProductInvoices.Where(x => x.invoiceType == (int)Internal.Master.InvoiceType.Purchase);
                return data.ToList();
            }
        }
        public List<TblInvoiceHeader> SalesRetInvoices
        {
            get
            {
                var data = ProductInvoices.Where(x => x.invoiceType == (int)Internal.Master.InvoiceType.salesReturn);
                return data.ToList();
            }
        }
        public List<TblInvoiceHeader> PurchaseRetInvoices
        {
            get
            {
                var data = ProductInvoices.Where(x => x.invoiceType == (int)Internal.Master.InvoiceType.PurchaseReturn);
                return data.ToList();
            }
        }
        public int PurchaseinvCount
        {
            get
            {
                return PurchaseInvoices.Count() ;
            }
        }
        public int SalesinvCount
        {
            get
            {
                return SalesInvoices.Count();
            }
        }
        public int PurchaseCount
        {
            get
            {
                var data=(from h in ProductInvoices 
                          join d in ProductIVDetails on h.ID equals d.InvoiceID
                          where h.invoiceType ==(int) Internal.Master.InvoiceType.Purchase
                          select d).Sum(x=>x.itemQty);
                return data??0;
            }
        }
        public int SalesCount
        {
            get
            {
                var data = (from h in ProductInvoices
                            join d in ProductIVDetails on h.ID equals d.InvoiceID
                            where h.invoiceType == (int)Internal.Master.InvoiceType.Sales
                            select d).Sum(x => x.itemQty);
                return data ?? 0;
            }
        }
        public int Qty
        {
            get
            {
                var data = StoreProducts.Sum(x => x.Qty);
                return data ?? 0;
            }
        }
        public decimal ProductValue
        {
            get
            {
                var data = Qty *Product.price;
                return data ??0;
            }
        }
        public decimal ProductBuyValue
        {
            get
            {
                var data = Qty * Product.BuyPrise;
                return data ?? 0;
            }
        }
    }
}
