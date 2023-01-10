using AlphaSSA.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AlphaSSA.VIEW
{
    public partial class FrmProductsList : FrmMAster
    {
        SSADBDataContext db;
        clsProductDetails Product;
        List<clsProductDetails> productDetails;
        bool ViewOnly=false;

        public FrmProductsList()
        {
            InitializeComponent();
            LoadData();
            show_New();
            show_Edit();
        }
        public FrmProductsList(bool view)
        {
            InitializeComponent();
            LoadData();
            ViewOnly = view;
        }
        void LoadData()
        {
            using (db = new SSADBDataContext())
            {

                productDetails = new List<clsProductDetails>(db.TblProducts.Select(x => new clsProductDetails { ID = x.ID, Name = x.Name, barcode = x.barcode, cat = x.cat, price = x.price ,BuyPrise=x.BuyPrise}));
            }
            gridControl1.DataSource = productDetails;
        }

        private void FrmProductsList_Load(object sender, EventArgs e)
        {
            gridView1.Columns[nameof(TblProduct.ID)].Caption = "م";
            gridView1.Columns[nameof(TblProduct.ID)].VisibleIndex = 0;
            gridView1.Columns[nameof(clsProductDetails.barcode)].VisibleIndex = 1;
            gridView1.Columns[nameof(TblProduct.Name)].VisibleIndex = 2;
            gridView1.Columns[nameof(TblProduct.Name)].Caption = "اسم المنتج";
            gridView1.Columns[nameof(TblProduct.cat)].Visible = false;
            gridView1.Columns[nameof(TblProduct.StartingBalance)].Visible = false;
            gridView1.Columns[nameof(clsProductDetails.catname)].Caption = "التصنيف";
            gridView1.Columns[nameof(clsProductDetails.price)].Caption = "السعر";
            gridView1.Columns[nameof(clsProductDetails.barcode)].Caption = "BarCode";
            gridView1.Columns[nameof(clsProductDetails.BuyPrise)].Caption = "سعر الشراء";
            

            if (!ViewOnly)
            {
                show_New();
                show_Edit();
                
            }
            Show_Barcode();
        }
        public override void printBarcode()
        {
            ClsBarCodeModel brm = new ClsBarCodeModel();
            brm.Name = Product.Name;
            brm.Price = (decimal)Product.price;
            brm.Barcode = Product.barcode;
            FrmBarcode frm = new FrmBarcode(brm);
            frm.ShowDialog();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            Product = (clsProductDetails)gridView1.GetFocusedRow();

        }
        
        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            FrmProductDetails frm = new FrmProductDetails(Product);
            frm.ShowDialog();

        }
        public override void New()
        {
            frmAddProduct frm = new frmAddProduct();
            frm.ShowDialog();
            LoadData();
        }
        public override void EDIT()
        {
            frmAddProduct frm = new frmAddProduct(Product);
            frm.ShowDialog();
            LoadData();
        }
        private void gridControl1_EditorKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            
        }

        private void FrmProductsList_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == System.Windows.Forms.Keys.F2)
            {
                EDIT();
            }
        }
    }
}