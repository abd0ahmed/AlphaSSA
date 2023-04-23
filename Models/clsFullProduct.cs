using AlphaSSA.DataProcessors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using static AlphaSSA.Internal.Master;

namespace AlphaSSA.Models
{
    public class clsFullProduct 
    {

        [Display(Name = "اجمالي قيمة بيع")]
        public decimal ProductValue { get { return ProductProcessor.ProductValue; } }

        [Display(Name = "اجمالي قيمة شراء")]
        public decimal ProductBuyValue { get { return ProductProcessor.ProductBuyValue; } }

        [Display(Name = "اجمالي كميات المخازن")]
        public int Qty { get { return ProductProcessor.Qty; } }

       // [Display(Name = "فواتير البيع")]
        //public List<CLsProductInvoicesInfo> salesInvoices { get { return ProductProcessor.SalesInvoices; } }

       // [Display(Name = "فواتير الشراء")]
        //public List<CLsProductInvoicesInfo> BurchaseInvoices { get { return GetBurchaseInvoices(); } }

        //[Display(Name = "فواتير مرتجع بيع")]
        //public List<CLsProductInvoicesInfo> salesretInvoices { get { return GetSalesretInvoices(); } }

        //[Display(Name = "فواتير مرتجع شراء")]
        //public List<CLsProductInvoicesInfo> BurchaseretInvoices { get { return GetBurchaseretInvoices(); } }

        
        [Display(Name = "عدد فواتير البيع")]
        public int SalesinvCount
        {
            get { return ProductProcessor.SalesinvCount; }
        }

        [Display(Name = "عدد القطع المباعة")]
        public int SalesCount
        {
            get { return ProductProcessor.SalesCount; }
        }
        [Display(Name = "عدد القطع المشتراة")]
        public int PurchaseCount
        {
            get { return ProductProcessor.PurchaseCount; }
        }
        [Display(Name = "عدد فواتير الشراء")]
        public int PurchaseinvCount
        {
            get { return ProductProcessor.PurchaseinvCount; }
        }
        public clsFullProduct()
        {
           
            
        }
        public clsFullProduct(TblProduct tblProduct)
        {
            using (var db = new SSADBDataContext())
            {
                ProductProcessor = new FullProductProcessor(tblProduct.ID, db);
            }
            
        }
        public clsFullProduct(int ID)
        {
            using (var db = new SSADBDataContext())
            {
                ProductProcessor = new FullProductProcessor(ID, db);
            }
        }
        public clsFullProduct(int ID,SSADBDataContext context)
        {
            ProductProcessor=new FullProductProcessor(ID,context);
        }
        FullProductProcessor ProductProcessor;
    }
}

