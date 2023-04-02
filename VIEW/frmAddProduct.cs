using AlphaSSA.Models;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AlphaSSA.VIEW
{
    public partial class frmAddProduct : FrmMAster
    {
        SSADBDataContext db;
        List<TblCategory> Categories;
        List<tblStore> Stores;
        TblProduct product;
        TblStoreProduct storeProduct;
        bool edit ;
        //Internal.FrmProductsProcessor ProductsProcessor;
        public frmAddProduct()
        {
            InitializeComponent();
            edit = false;
            GetData();
            New();
            show_save();
            show_New();
           // ProductsProcessor = new Internal.FrmProductsProcessor();
        }
        public frmAddProduct(TblProduct _product)
        {
            InitializeComponent();
            edit = true;
            product = _product;
           // ProductsProcessor .Product= _product;
            txtQty.Properties.ReadOnly = true;
            GetData();
            show_save();
            
        }
        void RetreveData()
        {
            txtID.Text = product.ID.ToString();
            txtBarcode.Text = product.barcode;
            txtPrice.Text = product.price.ToString() ;
            txtProductName.Text = product.Name;
            txtBuyPrise.Text = product.BuyPrise.ToString();
            using (db = new SSADBDataContext())
            {
                lkpStore.Properties.DataSource = Stores;
                lkpStore.EditValue = db.TblStoreProducts.FirstOrDefault(x => x.productID == product.ID && x.Qty >= 0).StoreID;
                lkpStore.Properties.PopulateColumns();
                lkpStore.Properties.DisplayMember = nameof(tblStore.Name);
                lkpStore.Properties.ValueMember = nameof(tblStore.ID);
                lkpCat.Properties.PopulateColumns();
                lkpCat.Properties.DisplayMember = nameof(TblCategory.Name);
                lkpCat.Properties.ValueMember = nameof(TblCategory.ID);
                lkpCat.EditValue = product.cat;
                
            }

        }
        void GetData()
        {

            using (db = new SSADBDataContext())
            {
                Categories = new List<TblCategory>(db.TblCategories);
                Stores = new List<tblStore>(db.tblStores);
               
            }

            lkpCat.Properties.DataSource = Categories;
            lkpCat.Properties.PopulateColumns();
            lkpCat.Properties.DisplayMember = nameof(TblCategory.Name);
            lkpCat.Properties.ValueMember = nameof(TblCategory.ID);
            lkpStore.Properties.DataSource = Stores;
            lkpStore.Properties.PopulateColumns();
            lkpStore.Properties.DisplayMember = nameof(tblStore.Name);
            lkpStore.Properties.ValueMember = nameof(tblStore.ID);
            if (product != null)
            {

                RetreveData();
                

            }
        }
        public override void New()
        {
            product = new TblProduct();
            storeProduct = new TblStoreProduct();

            clear();
        }
        void clear()
        {
            txtProductName.Text = "";
            txtID.Text = "";
            txtPrice.Text = "";
            txtBuyPrise.Text = "";
            txtQty.Text = "0";
          if(lkpCat.EditValue==null)
                 lkpCat.EditValue = Properties.Settings.Default.DefaultCat;
                lkpStore.EditValue = Properties.Settings.Default.DefaultStore;
            txtBarcode.Text = GetNewCode();
            // lkpCat.EditValue = Properties.Settings.Default.DefaultCat;
        }
        void setData()
        {
            product.Name = txtProductName.Text.Trim();
            product.price = decimal.Parse(txtPrice.Text.ToString());
            product.BuyPrise = decimal.Parse(txtBuyPrise.Text);
            product.cat = (int)lkpCat.EditValue;
            product.barcode = txtBarcode.Text.Trim();
            if (product.ID == 0)
            {
                storeProduct.Qty = int.Parse(txtQty.Text.ToString());
                storeProduct.StoreID = (int)lkpStore.EditValue;
            }
            else
            {
                storeProduct = db.TblStoreProducts.FirstOrDefault(x => x.productID == product.ID && x.StoreID == (int)lkpStore.EditValue);
            }
        }
        bool vlidateData()
        {
            bool v = true;
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                txtProductName.ErrorText = "لا يمكن ترك الاسم فارعا";
                v = false;
            }
            if (lkpCat.EditValue == null)
            {
                lkpCat.ErrorText = "يرجي اختيار تصنيف";
                v = false;
            }
            if (lkpStore.EditValue == null)
            {
                lkpStore.ErrorText = "يرجي اختيار مخزن";
                v = false;
            }
            if (db.TblProducts.SingleOrDefault(x => x.Name == txtProductName.Text.Trim() && x.ID != product.ID) != null)
            {
                txtProductName.ErrorText = "هذا الاسم موجود من قبل";
                v = false;
            }
            if (db.TblProducts.SingleOrDefault(x => x.barcode == txtBarcode.Text.Trim() && x.ID != product.ID) != null)
            {
                txtBarcode.ErrorText = "هذا الكود موجود من قبل";
                v = false;
            }


            return v;
        }
        public override void Save()
        {
            bool addinv = false;
            using (db = new SSADBDataContext())
            {
                if (!vlidateData())
                {
                    return;
                }
                
                if (product.ID == 0)
                {
                    db.TblProducts.InsertOnSubmit(product);
                    if (int.Parse(txtQty.EditValue.ToString()) > 0)
                    {
                        addinv = true;
                    }
                  
                    
                }
                else
                {

                    product = db.TblProducts.SingleOrDefault(x => x.ID == product.ID);
                }
                setData();
                db.SubmitChanges();
                if (storeProduct.productID == 0)
                {
                    storeProduct.productID = product.ID;
                    db.TblStoreProducts.InsertOnSubmit(storeProduct);
                    db.SubmitChanges();
                }
                else
                {
                    var sP = db.TblStoreProducts.SingleOrDefault(x => x.ID == storeProduct.ID);
                    sP.Qty = int.Parse(txtQty.Text);
                    sP.StoreID = (int?)lkpStore.EditValue?? storeProduct.StoreID;
                    db.SubmitChanges();
                }
                if (addinv)
                {
                    AddInvoice(db);
                }
                XtraMessageBox.Show("تم الحفظ بنجاح");
            }
        }
        void AddInvoice(SSADBDataContext db)
        {
            TblInvoiceHeader header = new TblInvoiceHeader();
            TbLInvoiceDetaile detaile = new TbLInvoiceDetaile();
            header.invoiceType = (int)Internal.Master.InvoiceType.Purchase;
            header.code = GetNewCode(null);
            header.Saller = Properties.Settings.Default.DefaultCahser;
            header.ClientID = Properties.Settings.Default.DefaultClient;
            header.Date = DateTime.Now;
            header.Time = DateTime.Now.TimeOfDay;
            header.shift = (db.TblShifts.ToList()).LastOrDefault().ID;
            header.Total = int.Parse(txtQty.EditValue.ToString()) * decimal.Parse(txtBuyPrise.EditValue.ToString());
            header.net= int.Parse(txtQty.EditValue.ToString()) * decimal.Parse(txtBuyPrise.EditValue.ToString());
            db.TblInvoiceHeaders.InsertOnSubmit(header);
            
            detaile.itemID = product.ID;
            
            detaile.StoreID = storeProduct.StoreID;
            detaile.itemQty = (int.Parse(txtQty.EditValue.ToString()));
            storeProduct.Qty = detaile.itemQty;
            detaile.price = decimal.Parse( txtBuyPrise.EditValue.ToString());
            detaile.TotalPrice = detaile.price * detaile.itemQty;
            db.SubmitChanges();
            detaile.InvoiceID = header.ID;

            db.TbLInvoiceDetailes.InsertOnSubmit(detaile);
          //  db.TblStoreProducts.Attach(storeProduct);
            db.SubmitChanges();
        }


        string GetNewCode()
        {
            var maxcode = string.Empty;
            using (db = new SSADBDataContext())
            {

                maxcode = db.TblProducts.Where(x => x.cat == (int)lkpCat.EditValue).Select(x => x.barcode).Max();
                if (string.IsNullOrEmpty(maxcode))
                {
                    maxcode = db.TblCategories.SingleOrDefault(x => x.ID == (int)lkpCat.EditValue).barcode;
                }
            }
            return NextCode(maxcode);
        }

        private void lkpCat_EditValueChanged(object sender, EventArgs e)
        {
            if (!edit)
            {
                txtBarcode.Text = GetNewCode();
            }
            
        }
        
        private void txtBarcode_EditValueChanged(object sender, EventArgs e)
        {
            
            barcodeC.Text = txtBarcode.Text;
        }

        private void barcodeC_Click(object sender, EventArgs e)
        {
            ClsBarCodeModel model = new ClsBarCodeModel();
            model.Barcode = txtBarcode.Text;
            model.Name = txtProductName.Text;
            model.Price =Convert.ToDecimal( txtPrice.EditValue);
            FrmBarcode frm = new FrmBarcode(model);
            frm.ShowDialog();
        }

        private void barcodeC_DoubleClick(object sender, EventArgs e)
        {

        }

        private void lkpStore_EditValueChanged(object sender, EventArgs e)
        {
            if (product!=null&& product.ID>0)
            {
                using (db=new SSADBDataContext())
                {
                    txtQty.Text = db.TblStoreProducts.Where(x => x.StoreID ==( (int)lkpStore.EditValue) && x.productID==product.ID).FirstOrDefault().Qty.ToString();
                }
               
            }
        }

        private void frmAddProduct_Load(object sender, EventArgs e)
        {
            lkpStore.EditValue= Properties.Settings.Default.DefaultStore;
            lkpCat.EditValue = Properties.Settings.Default.DefaultCat;
        }
        string GetNewCode(string Codeform)
        {
            var maxcode = string.Empty;
            using (db = new SSADBDataContext())
            {
                List<TblInvoiceHeader> data = db.TblInvoiceHeaders
                    .Where(x => x.invoiceType ==(int) Internal.Master.InvoiceType.Purchase)
                    .ToList();
                if (data.Count() > 0)
                {
                    maxcode = data.Max(x => x.code);
                }

                if (string.IsNullOrEmpty(maxcode))
                {
                    maxcode = "PR-00000000";
                }
            }
            return NextCode(maxcode);
        }
        
    }
}