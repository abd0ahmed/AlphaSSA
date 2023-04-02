using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaSSA.DataProcessors
{
    public class ProductInfoProcessor
    {
         public SSADBDataContext db { get; set; }
        public ProductInfoProcessor(SSADBDataContext db)
        {
            this.db=db;
        }
        public TblProduct GetProduct(int id)
        {

            var propduct = db.TblProducts.Where(x => x.ID == id).FirstOrDefault() ;
                return propduct;
            
        }
        public TblProduct GetProductByName(string Name)
        {

            var propduct = db.TblProducts.Where(x => x.Name ==Name).FirstOrDefault();
            return propduct;

        }
        public TblProduct GetProduct(string Code)
        {
           
                var propduct = db.TblProducts.Where(x => x.barcode == Code).FirstOrDefault();
                return propduct;
            
        }
        public List<TblProduct> GetAllProducts()
        {
           
                var propducts = db.TblProducts;
                return propducts.ToList();
            


        }
        public int SaveProduct(TblProduct product)
        {
           
                db.TblProducts.InsertOnSubmit(product);
                db.SubmitChanges();
                return product.ID;
            

        }
        public void SaveProducts(List<TblProduct>products)
        {
          
                db.TblProducts.InsertAllOnSubmit(products);
                db.SubmitChanges();
                
            

        }


    }
}
