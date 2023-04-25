using AlphaSSA.Models;
using DevExpress.Charts.Native;
using DevExpress.DataProcessing.InMemoryDataProcessor;
using DevExpress.Office.Utils;
using DevExpress.PivotGrid.OLAP.Mdx;
using DevExpress.Xpo.DB.Helpers;
using DevExpress.XtraExport.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlphaSSA.DataProcessors
{
    public class FullProductProcessor
    {
        string _catName = "";
        List<ProductFullIvoiceDataModel> _productFullIvoiceDataModels;
        public SSADBDataContext context { get; set; }
        public TblProduct Product { get; set; }
        public List<TblInvoiceHeader> ProductInvoices { get; set; }
        public List<TbLInvoiceDetaile> ProductIVDetails { get; set; }
        public List<TblStoreProduct> StoreProducts { get; set; }
        public List<ClsStoreProductsModel> StoreProductsDs { get { return GetSPDS(); }  }
        public string CatName { get { return getCatName(); }  }

        private List<ClsStoreProductsModel> GetSPDS()
        {
            using (context = new SSADBDataContext())
            {
                var data = (from p in StoreProducts
                            join s in context.tblStores on p.StoreID equals s.ID
                            where p.productID == Product.ID
                            select new ClsStoreProductsModel() { Name = s.Name ?? "", Qty = p.Qty ?? 0 });
                return data.ToList();
            }
           
        }

        public List<ProductFullIvoiceDataModel> ProductFullIvoiceData {
            get 
            {
                if (_productFullIvoiceDataModels==null)
                {
                    _productFullIvoiceDataModels = GetProductFullIvoiceData();
                }
                return _productFullIvoiceDataModels;
            }
        }
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
            getCatName();
        }
        List<ProductFullIvoiceDataModel> GetProductFullIvoiceData()
        {
            List<ProductFullIvoiceDataModel> data;
            using (var context = new SSADBDataContext())
            {
                 //data = (from d in ProductIVDetails
                 //           join h in ProductInvoices on d.InvoiceID equals h.ID
                 //           join c in context.TblClients on h.ClientID equals c.ID
                 //           where d.itemID == Product.ID
                 //           select new ProductFullIvoiceDataModel()
                 //           {
                 //               InvoiceType = h.invoiceType,
                 //               Code = h.code,
                 //               ItemQty = d.itemQty ?? 0,
                 //               Total = d.price * d.itemQty,
                 //               Price = d.price,
                 //               Discount = h.Discount,
                 //               Date = h.Date,
                 //               Time = h.Time,
                 //               SallerName = h.Saller.ToString(),
                 //               ClientName = c.Name ?? "",
                 //               InvoiceID = h.ID
                 //           }).ToList() ;
                //ToDo : rebuild This Methode Better
                // problem : cannot bind sallers in Linq.Quairy 
                // reason: Saller id can be null 
                // effict: causes hiding entire row

             


data = (from d in ProductIVDetails
                join h in ProductInvoices on d.InvoiceID equals h.ID
                join c in context.TblClients on h.ClientID equals c.ID
                join s in context.TblSallers on h.Saller equals s.ID into sellerGroup
                from s in sellerGroup.DefaultIfEmpty()
                where d.itemID == Product.ID
                select new ProductFullIvoiceDataModel()
                {
                    InvoiceType = h.invoiceType,
                    Code = h.code,
                    ItemQty = d.itemQty ?? 0,
                    Total = d.price * d.itemQty,
                    Price = d.price,
                    Discount = h.Discount,
                    Date = h.Date,
                    Time = h.Time,
                    SallerName = s != null ? s.Name : "",
                    ClientName = c.Name ?? "",
                    InvoiceID = h.ID
                }).ToList();
                //var d2 = context.TblSallers;
                //foreach (var item in data)
                //{
                //    if (item.SallerName != "")
                //        item.SallerName = d2.FirstOrDefault(x => x.ID == int.Parse(item.SallerName ?? "0")).Name;
                //}
            }
            return data.ToList();
        }
        public string getCatName()
        {
            if (_catName=="")
            {
                _catName = context.TblCategories.FirstOrDefault(x => x.ID == Product.cat).Name.ToString();
            }
            return _catName;
        }

        public List<ProductFullIvoiceDataModel> SalesInvoices
        {
            get
            {
                var data = ProductFullIvoiceData.Where(x => x.InvoiceType ==(byte) Internal.Master.InvoiceType.Sales);
                return data.ToList();
            }
        }
        public List<ProductFullIvoiceDataModel> PurchaseInvoices
        {
            get
            {
                var data = ProductFullIvoiceData.Where(x => x.InvoiceType == (byte)Internal.Master.InvoiceType.Purchase);
                return data.ToList();
            }
        }
        public List<ProductFullIvoiceDataModel> SalesRetInvoices
        {
            get
            {
                var data = ProductFullIvoiceData.Where(x => x.InvoiceType == (byte)Internal.Master.InvoiceType.salesReturn);
                return data.ToList();
            }
        }
        public List<ProductFullIvoiceDataModel> PurchaseRetInvoices
        {
            get
            {
                var data = ProductFullIvoiceData.Where(x => x.InvoiceType == (byte)Internal.Master.InvoiceType.PurchaseReturn);
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
                var data = (from h in ProductFullIvoiceData
                            where h.InvoiceType == (int)Internal.Master.InvoiceType.Purchase
                            select h).ToList();
                return data.Sum(x=>x.ItemQty);
            }
        }
        public int SalesCount
        {
            get
            {
                var data = (from h in ProductFullIvoiceData
                            where h.InvoiceType == (int)Internal.Master.InvoiceType.Sales
                            select h).ToList();
                return data.Sum(x => x.ItemQty);
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
