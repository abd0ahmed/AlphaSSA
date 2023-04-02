using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static AlphaSSA.Internal.Master;

namespace AlphaSSA.Models
{
    public class clsFullProduct : TblProduct
    {
       
        SSADBDataContext db;
       public List<ClsStoreProductsModel> StoreProducts;
        List<CLsProductInvoicesInfo> InvoiceHeaders;
      public List<TbLInvoiceDetaile> invoiceDetailes;
       
        public clsFullProduct()
        {

           
        }

        public clsFullProduct(int id)
        {
            this.ID = id;
            GetInvoices();

        }
        public clsFullProduct(SSADBDataContext db,int id)
        {
            this.ID = id;
            GetInvoices();
            this.db = db;
        }
        SSADBDataContext ChkDB()
        {
            if (db == null)
            {
                db = new SSADBDataContext();
                return db;
            }
            db.Connection.Close();
            return db;
        }
        void GetInvoices()
        {
           
                using (db = ChkDB())
                {
                    GetStoreProducts();
                    GetinvoiceDetailes();
                    GetInvoiceHeaders();
                }
            
        }
        void GetStoreProducts()
        {
          
                StoreProducts = (from p in db.TblProducts
                                 join sp in db.TblStoreProducts on p.ID equals sp.productID
                                 join s in db.tblStores on sp.StoreID equals s.ID
                                 where sp.productID == ID
                                 select new ClsStoreProductsModel { Name = s.Name, Qty = (int)sp.Qty }).ToList();
            
           


        }
        void GetinvoiceDetailes()
        {
            
                invoiceDetailes = db.TbLInvoiceDetailes.Where(x => x.itemID == ID).ToList();
            
           

        }
        void GetInvoiceHeaders()
        {
          
                InvoiceHeaders = (from h in db.TblInvoiceHeaders
                                  join d in db.TbLInvoiceDetailes on h.ID equals d.InvoiceID
                                  join s in db.TblSallers on h.Saller equals s.ID
                                  join c in db.TblClients on h.ClientID equals c.ID
                                  
                                  where d.itemID == ID
                                  select new CLsProductInvoicesInfo(d.itemID??0)
                                  {
                                      ClientID = h.ClientID,
                                      code = h.code
                                      ,
                                      Date = h.Date,
                                      Discount = h.Discount,
                                      ID = h.ID,
                                      invoiceType = h.invoiceType,
                                      net = h.net,
                                      Printed = h.Printed,
                                      SourceID = h.SourceID,
                                      Total = h.Total
                                      ,_saller=s.Name
                                      ,Client=c.Name
                                      ,shift=h.shift
                                      ,Time=h.Time
                                      
                                      
                                  }
                           ).ToList();
            }

        
        int GetSalesinvCount()
        {
            
            if (invoiceDetailes == null)
                return 0;

            return salesInvoices.Count;

        }
        
        int GetBurchaseinvCount()
        {
           
            if (invoiceDetailes == null)
                return 0;

            return BurchaseInvoices.Count;

        }
        
        List<CLsProductInvoicesInfo> GetSalesInvoices()
        {
            return InvoiceHeaders.Where(x => x.invoiceType == (int)AlphaSSA.Internal.Master.InvoiceType.Sales).ToList();
        }
       
        List<CLsProductInvoicesInfo> GetBurchaseInvoices()
        {
            return InvoiceHeaders.Where(x => x.invoiceType == (int)AlphaSSA.Internal.Master.InvoiceType.Purchase).ToList();
        }
       
        decimal GetProductValue()
        {
            decimal value = 0;
           

            value = decimal.Parse((Qty * price).ToString());
            return value;
        }
        
        decimal GetProductBuyValue()
        {
            decimal value = 0;


            value = decimal.Parse((Qty * BuyPrise).ToString());
            return value;
        }
        
        List<CLsProductInvoicesInfo> GetSalesretInvoices()
        {
            return InvoiceHeaders.Where(x => x.invoiceType == (byte)Internal.Master.InvoiceType.salesReturn).ToList();
        }
        
        List<CLsProductInvoicesInfo> GetBurchaseretInvoices()
        {
            return InvoiceHeaders.Where(x => x.invoiceType == (byte)Internal.Master.InvoiceType.PurchaseReturn).ToList();
        }
        
        int GetSalesCount()
        {
           
            var data= ( (from d in invoiceDetailes
                                     join h in InvoiceHeaders on d.InvoiceID equals h.ID
                                     where h.invoiceType ==( (byte)Internal.Master.InvoiceType.Sales)
                     select   d));
            return (int)data.Sum(x=>x.itemQty);
        }
        
        int GetPurchaseCount()
        {
            var data = ((from d in invoiceDetailes
                         join h in InvoiceHeaders on d.InvoiceID equals h.ID
                         where h.invoiceType == ((byte)Internal.Master.InvoiceType.Purchase)
                         select d));
            return (int)data.Sum(x => x.itemQty);
        }
       
        int _ProductCount = 0;
        
        int ProductCount()
        {
            if (_ProductCount != 0 && StoreProducts != null)
            {
                return _ProductCount;
            }
          
            if (StoreProducts != null)
            {
                _ProductCount = StoreProducts.Select(x => x.Qty).Sum() ;
            }
            


            return _ProductCount;
        }
        [Display(Name = "اجمالي قيمة بيع")]
        public decimal ProductValue { get { return GetProductValue(); } }
        [Display(Name = "اجمالي قيمة شراء")]
        public decimal ProductBuyValue { get { return GetProductBuyValue(); } }
        [Display(Name = "اجمالي كميات المخازن")]
        public int Qty { get { return ProductCount(); } }
       
        public List<CLsProductInvoicesInfo> salesInvoices { get { return GetSalesInvoices(); } }
        [Display(Name = "فواتير الشراء")]
        public List<CLsProductInvoicesInfo> BurchaseInvoices { get { return GetBurchaseInvoices(); } }
        [Display(Name = "فواتير مرتجع بيع")]
        public List<CLsProductInvoicesInfo> salesretInvoices { get { return GetSalesretInvoices(); } }
        [Display(Name = "فواتير مرتجع شراء")]
        public List<CLsProductInvoicesInfo> BurchaseretInvoices { get { return GetBurchaseretInvoices(); } }
        public new int ID { get; set; }
        [Display(Name = "عدد فواتير البيع")]
        public int SalesinvCount
        {
            get { return GetSalesinvCount(); }
        }
        [Display(Name = "عدد القطع المباعة")]
        public int SalesCount
        {
            get { return GetSalesCount(); }
        }
        [Display(Name = "عدد القطع المشتراة")]
        public int PurchaseCount
        {
            get { return GetPurchaseCount(); }
        }
        [Display(Name = "عدد فواتير الشراء")]
        public int PurchaseinvCount
        {
            get { return GetBurchaseinvCount(); }
        }
        
    }
}

