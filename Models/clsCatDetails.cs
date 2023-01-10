
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
        List<clsFullProduct> tblProducts;
        [Display(Name = "المنتجات")]
        [Browsable(true)]
        [HiddenInput(DisplayValue = false)]
        public List<clsFullProduct> Products { get { return _Products(); } }
        [Display(Name = "عدد المنتجات")]
        public int ProductsCount { get { return GetProductsCount(); } }
        [Display(Name = "القيمة الاجمالية")]
        public string CatVaLue { get { return GetProductsValue() + " جم"; } }
        [Display(Name = "عدد القطع")]
        public int FullCount { get { return GetFullCount(); } }

        private int GetFullCount()
        {
            if (tblProducts != null)
            {
                return Products.Select(x=>x.Qty).Sum();
            }
            else
            {
                return 0;
            }
        }

        int GetProductsCount()
        {
            if (tblProducts!=null)
            {
                return Products.Count;
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
                return Products.Select (x => x.BuyPrise *x.Qty).Sum();
            }
            else
            {
                return 0;
            }
        }
        List<Models.clsFullProduct> _Products()
        {
            if (tblProducts==null)
            {
                using (db = new SSADBDataContext())
                {
                    var data = (from p in db.TblProducts
                                join cat in db.TblCategories on p.cat equals cat.ID
                                where cat.ID == ID
                                select new clsFullProduct(p.ID)
                                {
                                    Name = p.Name,
                                    price = p.price
                                   , barcode = p.barcode
                                   ,cat=p.cat
                                   ,BuyPrise=p.BuyPrise
                                }
                     ).ToList();

                    tblProducts = data;
                }
            }
          
                return tblProducts??new List<clsFullProduct>();
            

        }
    }
}
