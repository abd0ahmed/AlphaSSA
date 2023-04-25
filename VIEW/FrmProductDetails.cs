using AlphaSSA.Internal;
using AlphaSSA.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlphaSSA.VIEW
{
    public partial class FrmProductDetails : FrmMAster
    {
        TblProduct product;
        clsFullProduct clsFullProduct;
        public FrmProductDetails()
        {
            InitializeComponent();
        }
        public FrmProductDetails(clsProductDetails clsProductDetails)
        {
            InitializeComponent();
            product = new TblProduct();
            product.ID =  clsProductDetails.ID;
            initializeData();
            setData();
        }

        void initializeData()
        {
             clsFullProduct = new clsFullProduct(product);

            GridBurchase.DataSource = clsFullProduct.BurchaseInvoices;
            GridSales.DataSource = clsFullProduct.salesInvoices;
            GridQty.DataSource = clsFullProduct.StoreProductsDs;
            GridSalesRet.DataSource = clsFullProduct.salesretInvoices;
            GridPurchaseRet.DataSource = clsFullProduct.BurchaseretInvoices;

            txtInvoiceCount.Text = clsFullProduct.SalesinvCount.ToString();
            txtSellsCount.Text = clsFullProduct.SalesCount.ToString();
            txtSellReturnCount.Text = clsFullProduct.salesretInvoices.Count().ToString();
            txtBuyPrise.Text = clsFullProduct.TblProduct.BuyPrise.ToString();
            var LastsellInv = clsFullProduct.salesInvoices.LastOrDefault();
            if (LastsellInv != null)
            {
                txtLastInvoice.EditValue = ((DateTime)LastsellInv.Date).ToString("dd/MM/yyyy");
            }

            txtPurchasesCount.Text = clsFullProduct.BurchaseInvoices.Count().ToString();
            var LastPurlInv = clsFullProduct.BurchaseInvoices.LastOrDefault();
            if (LastPurlInv != null)
            {
                txtLastPurchase.Text = ((DateTime)LastPurlInv.Date).ToString("dd/MM/yyyy") ?? "";
            }

            txtPInvoiceCount.Text= clsFullProduct.PurchaseCount.ToString();
            txtBurchaseReturnCount.Text= clsFullProduct.PurchaseinvCount.ToString();


            ViewQty.Columns[nameof(ClsStoreProductsModel.Name)].Caption = "اسم المخزن";
            ViewQty.Columns[nameof(ClsStoreProductsModel.Qty)].Caption = "الكمية";

            //ViewSales.Columns[nameof(CLsProductInvoicesInfo.ID)].Caption = "م";
            //ViewSales.Columns[nameof(CLsProductInvoicesInfo.code)].Caption = "كود الفاتورة";
            //ViewSales.Columns[nameof(CLsProductInvoicesInfo.invoiceTypeName)].Caption = "نوع الفاتورة";
            //ViewSales.Columns[nameof(CLsProductInvoicesInfo.Date)].Caption = "تاريخ";
            //ViewSales.Columns[nameof(CLsProductInvoicesInfo.Total)].Caption = "اجمالي";
            //ViewSales.Columns[nameof(CLsProductInvoicesInfo.net)].Caption = "الصافي";
            //ViewSales.Columns[nameof(CLsProductInvoicesInfo.Discount)].Caption = "خصم";
            //ViewSales.Columns[nameof(CLsProductInvoicesInfo.invoiceTypeName)].VisibleIndex = 2;
            //ViewSales.Columns[nameof(CLsProductInvoicesInfo.invoiceType)].Visible = false;
            //ViewSales.Columns[nameof(CLsProductInvoicesInfo.Printed)].Visible = false;
            //ViewSales.Columns[nameof(CLsProductInvoicesInfo.SourceID)].Visible = false;
            //ViewSales.Columns[nameof(CLsProductInvoicesInfo.Saller)].Visible = false;
            //ViewSales.Columns[nameof(CLsProductInvoicesInfo.ClientID)].Visible = false;
            //ViewSales.Columns[nameof(CLsProductInvoicesInfo._saller)].VisibleIndex = 10;
            //ViewSales.Columns[nameof(CLsProductInvoicesInfo.Client)].VisibleIndex = 9;



            //ViewBurchase.Columns[nameof(CLsProductInvoicesInfo.ID)].Caption = "م";
            //ViewBurchase.Columns[nameof(CLsProductInvoicesInfo.code)].Caption = "كود الفاتورة";
            //ViewBurchase.Columns[nameof(CLsProductInvoicesInfo.invoiceTypeName)].Caption = "نوع الفاتورة";
            //ViewBurchase.Columns[nameof(CLsProductInvoicesInfo.Date)].Caption = "تاريخ";
            //ViewBurchase.Columns[nameof(CLsProductInvoicesInfo.Total)].Caption = "اجمالي";
            //ViewBurchase.Columns[nameof(CLsProductInvoicesInfo.net)].Caption = "الصافي";
            //ViewBurchase.Columns[nameof(CLsProductInvoicesInfo.Discount)].Caption = "خصم";
            //ViewBurchase.Columns[nameof(CLsProductInvoicesInfo.invoiceTypeName)].VisibleIndex = 2;
            //ViewBurchase.Columns[nameof(CLsProductInvoicesInfo.invoiceType)].Visible = false;
            //ViewBurchase.Columns[nameof(CLsProductInvoicesInfo.Printed)].Visible = false;
            //ViewBurchase.Columns[nameof(CLsProductInvoicesInfo.SourceID)].Visible = false;
            //ViewBurchase.Columns[nameof(CLsProductInvoicesInfo.Saller)].Visible = false;
            //ViewBurchase.Columns[nameof(CLsProductInvoicesInfo.ClientID)].Visible = false;
            //ViewBurchase.Columns[nameof(CLsProductInvoicesInfo._saller)].VisibleIndex = 10;
            //ViewBurchase.Columns[nameof(CLsProductInvoicesInfo.Client)].VisibleIndex = 9;

        }
        void setData()
        {

            txtProductName.Text = clsFullProduct.TblProduct.Name;
            txtPrise.Text = clsFullProduct.TblProduct.price.ToString();
            txtBuyPrise.Text = clsFullProduct.TblProduct.BuyPrise.ToString();
           txtCat.Text =clsFullProduct.CatName;

        }
        private void FrmProductDetails_Load(object sender, EventArgs e)
        {

        }

        private void ViewSales_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

        }

        private void GridSales_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void اضافةمرتجعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int invoiceID = ((ProductFullIvoiceDataModel)ViewSales.GetFocusedRow()).InvoiceID;
            Internal.Master.InvoiceType invoiceType =
                (Master.InvoiceType)((ProductFullIvoiceDataModel)ViewSales.GetFocusedRow()).InvoiceType;
            FrmReturn frm = new FrmReturn(invoiceType, invoiceID);
            frm.ShowDialog();
        }

        private void طباعةالفاتورةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInvNew frm = new frmInvNew();
        }

        private void ViewSales_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Value == null)
                return;
            
            if (e.Column.FieldName == nameof(ProductFullIvoiceDataModel.Time))
            {
                    var s = DateTime.Today.Add((TimeSpan)e.Value);
                    e.DisplayText = s.ToShortTimeString();
            }
            else if (e.Column.FieldName == nameof(ProductFullIvoiceDataModel.InvoiceType))
            {
                int va = int.Parse(e.Value.ToString());
                    e.DisplayText = Internal.Master.InvoiceTypes.First(x=>x.ID==va).value;
            }
        }
    }
}