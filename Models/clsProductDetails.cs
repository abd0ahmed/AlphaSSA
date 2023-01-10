using System;
using System.Linq;

namespace AlphaSSA.Models
{
    public class clsProductDetails:TblProduct
    {
        SSADBDataContext db;
        string catName;
        public string catname { get { return GetCatName(); } }
        string GetCatName()
        {
            if (catName==string.Empty||catName==null)
            {
                using (db = new SSADBDataContext())
                {

                    catName = (from p in db.TblProducts
                               join cat in db.TblCategories on p.cat equals cat.ID
                               where p.ID == ID
                               select cat.Name).FirstOrDefault().ToString();


                }
            }
            return catName;
        }
    }
}
