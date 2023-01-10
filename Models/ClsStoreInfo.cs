using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AlphaSSA.Models
{
    public class ClsStoreInfo : tblStore
    {
        SSADBDataContext db;
        int _ProductsCount=0;
        int _ProductsQty = 0;
        decimal _StoreValue = 0;
        List<clsFullProduct> _Products;
        [Display(Name = "المنتجات")]
        [Browsable(false)]
        public List<clsFullProduct> Products { get { return Get_Products(); } }
        [Display(Name = "عدد المنتجات")]
        public int Products_count { get { return Get_ProductsCount(); } }
        [Display(Name = "عدد القطع")]
        public string Product_Qty { get { return Get_ProductsQty() + " قطعة"; } }
        [Display(Name = "القيمة الاجمالية")]
        public string storeValue { get { return Get_StoreValue() + " جم"; } }
        List<clsFullProduct> Get_Products()
        {
            if (_Products==null)
            {
                using (db = new SSADBDataContext())
                {

                    _Products = (from pr in db.TblProducts
                                join stpr in db.TblStoreProducts
                                on pr.ID equals stpr.productID
                                where stpr.StoreID == ID
                                select new clsFullProduct(db,pr.ID)
                                {
                                    
                                    Name = pr.Name,
                                    price = pr.price,
                                    BuyPrise=pr.BuyPrise

                                }).ToList();
                    return _Products;
                }
            }

            return _Products;
        }

        int  Get_ProductsCount()
        {
            if (_ProductsCount==0)
            {
                _ProductsCount= Products.Count;
                return _ProductsCount;
            }
            return _ProductsCount;



        }
        int Get_ProductsQty()
        {

            if (_ProductsQty == 0)
            {
                _ProductsQty=Products.Select(x=>x.Qty).Sum();
                return _ProductsQty;
            }
            return _ProductsQty;



        }
        decimal Get_StoreValue()
        {

            if (_StoreValue == 0)
            {
                _StoreValue= Products.Select(x=>x.ProductBuyValue).Sum();
                return _StoreValue;
            }
            return _StoreValue;



        }
    }

}
