
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AlphaSSA.Models
{
    public class clsCatDetails : TblCategory
    {
        SSADBDataContext db;


        public List<clsFullProduct> tblProducts;
        [Display(Name = "عدد المنتجات")]
        public int ProductsCount { get { return GetProductsCount(); } }
        [Display(Name = "القيمة الاجمالية")]
        public string CatVaLue { get { return GetProductsBuyValue() + " جم"; } }
        [Display(Name = "عدد القطع")]
        public int FullCount { get { return GetFullCount(); } }
        public clsCatDetails(TblCategory category)
        {
            ID = category.ID;
            Name = category.Name;
            barcode = category.barcode;
            GetProducts();
        }

        private void GetProducts()
        {
            using (db = new SSADBDataContext())
            {
                var data = (from p in db.TblProducts
                            join cat in db.TblCategories on p.cat equals cat.ID
                            where cat.ID == ID
                            select new clsFullProduct(p.ID, db)
                 ).ToList();

                tblProducts = data;
            }
        }

        private int GetFullCount()
        {
            if (tblProducts != null)
            {
                return tblProducts.Select(x => x.Qty).Sum();
            }
            else
            {
                return 0;
            }
        }

        int GetProductsCount()
        {
            if (tblProducts != null)
            {
                return tblProducts.Count;
            }
            else
            {
                return 0;
            }
        }

        decimal? GetProductsValue()
        {
            if (tblProducts != null)
            {
                return tblProducts.Select(x => x.ProductValue).Sum();
            }
            else
            {
                return 0;
            }
        }
        decimal? GetProductsBuyValue()
        {
            if (tblProducts != null)
            {
                return tblProducts.Select(x => x.ProductBuyValue).Sum();
            }
            else
            {
                return 0;
            }
        }

    }
}
