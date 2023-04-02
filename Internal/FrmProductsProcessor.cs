using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaSSA.Internal
{
    public class FrmProductsProcessor
    {
         SSADBDataContext db ;
        DataProcessors.ProductInfoProcessor processor;
        public TblProduct Product { get; set; }
        public FrmProductsProcessor()
        {
            ProcessorDb();
        }
        void ProcessorDb()
        {
            processor = new DataProcessors.ProductInfoProcessor(db);

        }
        public bool checkproductNameExist(string Name)
        {
            using ( db=new SSADBDataContext())
            {
                var product = processor.GetProductByName(Name);
                if (product!=null && Product.ID != product.ID)
                    return true;
                return false;
            }
        }
        public bool checkproductCodeExist(string Code)
        {
            using ( db = new SSADBDataContext())
            {
                var product = processor.GetProduct(Code);
                if (product != null && Product.ID !=product.ID)
                    return true;
                return false;
            }
        }
    }
}
