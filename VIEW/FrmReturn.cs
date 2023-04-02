using AlphaSSA.Internal;
using AlphaSSA.Models;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Popup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AlphaSSA.VIEW
{
    public partial class FrmReturn : FrmMAster
    {
        BindingList<ClsInvoiceReturnModel> invoiceProducts;
        Master.InvoiceType invType;
        ClsInvoiceReturnModel product;
        BindingList<ClsInvoiceReturnModel> returnProducts;
        List<TbLInvoiceDetaile> tbLInvoiceDetailes;
        TblInvoiceHeader Header;
        SSADBDataContext db;
        List<TbLInvoiceDetaile> other;
        int invoiceID = 0;
        public FrmReturn(Master.InvoiceType InvType)
        {
            InitializeComponent();
            invType = InvType;
            New();
        }
        public FrmReturn(Master.InvoiceType InvType,int InvoiceID)
        {
            InitializeComponent();
            this.invoiceID = InvoiceID;
            invType = InvType;
            New();
            
        }
        public override void Save()
        {
            Header = new TblInvoiceHeader();
            tbLInvoiceDetailes = new List<TbLInvoiceDetaile>();

            using ( db=new SSADBDataContext())
            {

                SetData();
                Header.shift = db.TblShifts.Select(x=>x.ID).MaxOrDefault();
                Header.Time = DateTime.Now.TimeOfDay;
                Header.Date = DateTime.Now;
                var sourceHeader = db.TblInvoiceHeaders.SingleOrDefault(x => x.ID == (int)lkpInvoiceCode.EditValue);
                db.TblInvoiceHeaders.InsertOnSubmit(Header);
                db.SubmitChanges();
                foreach (var item in returnProducts)
                {
                    tbLInvoiceDetailes.Add(new TbLInvoiceDetaile() { itemID = item.ID, InvoiceID = Header.ID, itemQty = item.qty, price = item.Price, TotalPrice = item.Price * item.qty, StoreID = item.GetStoreID(sourceHeader.ID) });
                }

                db.TbLInvoiceDetailes.InsertAllOnSubmit(tbLInvoiceDetailes);
                if (invType==Master.InvoiceType.Sales)
                {
                    foreach (var item in tbLInvoiceDetailes)
                    {
                        var s = db.TblStoreProducts.SingleOrDefault(x => x.productID == item.itemID && x.StoreID == item.StoreID);
                        
                        s.Qty += item.itemQty;
                    }
                }
                if (invType==Master.InvoiceType.Purchase)
                {

                    foreach (var item in tbLInvoiceDetailes)
                    {
                        var s = db.TblStoreProducts.SingleOrDefault(x => x.productID == item.itemID && x.StoreID == item.StoreID);
                        s.Qty -= item.itemQty;
                    }

                }
                
                db.SubmitChanges();

            }
            



        }
       byte GetInvoiceType()
        {
            switch (invType)
            {
                case Master.InvoiceType.Sales:
                    return (byte)Master.InvoiceType.salesReturn;
                    break;
                case Master.InvoiceType.Purchase:
                    return  (byte)Master.InvoiceType.PurchaseReturn;
                    break;

                default:
                    return 0;
                    break;
            }



        }
        void SetData()
        {
            var sourceHeader = db.TblInvoiceHeaders.SingleOrDefault(x => x.ID == (int)lkpInvoiceCode.EditValue);
            Header.ClientID = sourceHeader.ClientID;
            InitializeCode();
            Header.invoiceType = GetInvoiceType();
            Header.Date = DateTime.Now;
            Header.Total = returnProducts.Sum(x => x.totalPrice);
            Header.Discount = 0;
            Header.net = Header.Total;
            Header.SourceID = sourceHeader.ID;
            Header.Time = DateTime.Today.TimeOfDay;
        }
        string GetNewCode(string codeform)
        {
            var maxcode = string.Empty;
            
            
                List<TblInvoiceHeader> data = db.TblInvoiceHeaders.Where(x => x.invoiceType == GetInvoiceType()).ToList();
                if (data.Count() > 0)
                {
                    maxcode = data.Max(x=>x.code);
                }

                if (string.IsNullOrEmpty(maxcode))
                {
                    maxcode = codeform;
                }
            
            return NextCode(maxcode);
        }
        void InitializeCode()
        {
            switch (invType)
            {
               
                case Master.InvoiceType.Sales:
                    Header.code = GetNewCode("SRI-00000000");
                    break;
                case Master.InvoiceType.Purchase:
                    Header.code = GetNewCode("PRR-00000000");
                    break;
                default:
                    break;
            }

        }
        void changePrice(ClsInvoiceReturnModel Item1, ClsInvoiceReturnModel Item2)
        {
            Item1.totalPrice = (Item1.Price-Item1.Discount) * Item1.qty;
            if (Item2!=null)
            {
                Item2.totalPrice =( Item2.Price-Item2.Discount) * Item2.qty;
            }
            txtPicCount.Text = returnProducts.Sum(x => x.qty).ToString();
            txtProCount.Text = returnProducts.Count().ToString();
            txtTotal.Text = returnProducts.Sum(x => x.totalPrice).ToString();
        }
        void AddProductToReturn()
        {
            decimal disc = 0;
            if (GetInvoiceType()==(byte)Master.InvoiceType.salesReturn)
            {
                disc = decimal.Parse(txtDiscount.Text);
            }
            else if (GetInvoiceType() == (byte)Master.InvoiceType.PurchaseReturn)
            {
                disc = decimal.Parse(txtDiscount.Text)*-1;
            }
            if (string.IsNullOrWhiteSpace(txtQty.Text))
            {
                return;
            }

            if (product != null && product.ID != 0)
            {
                var pr = invoiceProducts.SingleOrDefault(x => x.ID == product.ID);
                int qty = product.qty + pr.qty;
                if (int.Parse(txtQty.Text) > qty)
                {
                    XtraMessageBox.Show("لا يمكن ارجاع كمية اكبر من الكمية المباعة");
                    product = new ClsInvoiceReturnModel();
                    return;
                }

                pr.qty = qty - int.Parse(txtQty.Text);
                product.qty = int.Parse(txtQty.Text);
                product.Discount = disc;
                
                changePrice(product, pr);
                product = new ClsInvoiceReturnModel();

                
                return;
            }

            product = invoiceProducts.Single(x => x.ID == (int)LkpProductCode.EditValue);
            if (int.Parse(txtQty.Text) > product.qty)
            {
                XtraMessageBox.Show("لا يمكن ارجاع كمية اكبر من الكمية المباعة");
                product = new ClsInvoiceReturnModel();
                return;
            }

            var rt = returnProducts.Where(x => x.ID == product.ID).FirstOrDefault();
            if (rt != null)
            {
                rt.qty = rt.qty + int.Parse(txtQty.Text);
                product.qty = product.qty - int.Parse(txtQty.Text);
                ReturnProducts_ListChanged(null, null);
            }
            else
            {
                product.qty = product.qty - int.Parse(txtQty.Text);
                returnProducts.Add(
                    new ClsInvoiceReturnModel()
                    {
                        ID = product.ID,
                        Code = product.Code,
                        qty = int.Parse(txtQty.Text),
                        ItemName = product.ItemName,
                        Discount=disc,
                        Price = product.Price,
                        totalPrice = (product.Price-disc ) * int.Parse(txtQty.Text)
                    }) ;
                changePrice(product, rt);
            }

            product = new ClsInvoiceReturnModel();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            product = (ClsInvoiceReturnModel)gridView1.GetFocusedRow();
            if (product == null)
            {
                return;
            }
            var rp = invoiceProducts.Single(x => x.ID == product.ID);
            if (rp.qty >= 1)
            {
                product.qty++;
                rp.qty--;
            }
            changePrice(product, rp);
            gridView1.RefreshData();
            product = new ClsInvoiceReturnModel();
        }

        private void BtnMinus_Click(object sender, EventArgs e)
        {
            product = (ClsInvoiceReturnModel)gridView1.GetFocusedRow();
            if (product == null)
            {
                return;
            }
            var rp = invoiceProducts.Single(x => x.ID == product.ID);
            if (product.qty > 1)
            {
                product.qty--;
                rp.qty++;
                changePrice(product, rp);
                gridView1.RefreshData();
            }
            product = new ClsInvoiceReturnModel();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            product = (ClsInvoiceReturnModel)gridView1.GetFocusedRow();
            if (product == null)
            {
                return;
            }
            var rp = invoiceProducts.Single(x => x.ID == product.ID);
            rp.qty = rp.qty + product.qty;
            product.qty = 0;
            product.totalPrice = 0;
            changePrice(product, rp);
            returnProducts.Remove(product);
            gridView1.RefreshData();
            product = new ClsInvoiceReturnModel();
        }

        private void FrmReturn_Load(object sender, EventArgs e)
        {
            show_save();
            show_New();
            GetData();
            lkpInvoiceCode.Properties.DisplayMember = "code";
            lkpInvoiceCode.Properties.ValueMember = "ID";
            gridControl1.DataSource = returnProducts;
            gridView1.PopulateColumns();
            gridView1.Columns[nameof(ClsInvoiceReturnModel.ID)].Visible = false;
            gridView1.Columns[nameof(ClsInvoiceReturnModel.ItemName)].Caption = "اسم الصنف";
            gridView1.Columns[nameof(ClsInvoiceReturnModel.Price)].Caption = "سعر";
            gridView1.Columns[nameof(ClsInvoiceReturnModel.totalPrice)].Caption = "احمالي";
            gridView1.Columns[nameof(ClsInvoiceReturnModel.qty)].Caption = "كمية";
            gridView1.Columns[nameof(ClsInvoiceReturnModel.Code)].Caption = "كود";
            gridView1.Columns[nameof(ClsInvoiceReturnModel.Discount)].Caption = "خصم";
            returnProducts.ListChanged += ReturnProducts_ListChanged;


        }

        void GetData()
        {
            using (var db = new SSADBDataContext())
            {
                lkpInvoiceCode.Properties.DataSource = db.TblInvoiceHeaders
                    .Where(x => x.invoiceType == (byte)invType)
                    .ToList();

            }
            lkpInvoiceCode.Properties.PopulateColumns();
            lkpInvoiceCode.Properties.Columns[nameof(TblInvoiceHeader.ID)].Visible = false;
            lkpInvoiceCode.Properties.Columns[nameof(TblInvoiceHeader.ClientID)].Visible = false;
            lkpInvoiceCode.Properties.Columns[nameof(TblInvoiceHeader.invoiceType)].Visible = false;
            lkpInvoiceCode.Properties.Columns[nameof(TblInvoiceHeader.Printed)].Visible = false;
            lkpInvoiceCode.Properties.Columns[nameof(TblInvoiceHeader.Saller)].Visible = false;
            lkpInvoiceCode.Properties.Columns[nameof(TblInvoiceHeader.SourceID)].Visible = false;
            lkpInvoiceCode.Properties.Columns[nameof(TblInvoiceHeader.shift)].Visible = false;
            lkpInvoiceCode.Properties.Columns[nameof(TblInvoiceHeader.casher)].Visible = false;
            lkpInvoiceCode.Properties.Columns[nameof(TblInvoiceHeader.Date)].Caption = "تاريخ";
            lkpInvoiceCode.Properties.Columns[nameof(TblInvoiceHeader.code)].Caption = "كود";
            lkpInvoiceCode.Properties.Columns[nameof(TblInvoiceHeader.Discount)].Caption = "خصم";
            lkpInvoiceCode.Properties.Columns[nameof(TblInvoiceHeader.net)].Caption = "صافي";
            lkpInvoiceCode.Properties.Columns[nameof(TblInvoiceHeader.Total)].Caption = "اجمال";
            lkpInvoiceCode.Properties.Columns[nameof(TblInvoiceHeader.Time)].Caption = "وقت";
            if (invoiceID>0)
            {
                GetInvoiceData(invoiceID);
            }
        }

        void GetInvoiceData(int invoiceID=0)
        {
            using (var db = new SSADBDataContext())
            {
                
                invoiceProducts = new BindingList<ClsInvoiceReturnModel>(
                    (from p in db.TblProducts
                     join ip in db.TbLInvoiceDetailes on p.ID equals ip.itemID
                     where ip.InvoiceID ==(invoiceID==0? (int)lkpInvoiceCode.EditValue:invoiceID)
                     select new ClsInvoiceReturnModel()
                     {
                         ID = p.ID,
                         ItemName = p.Name,
                         Code = p.barcode,
                         qty = (int)ip.itemQty,
                         Price = (decimal)ip.price,
                         totalPrice = (decimal)ip.TotalPrice
                     }).ToList());
                other = (from ih in db.TblInvoiceHeaders
                                                 join id in db.TbLInvoiceDetailes on ih.ID equals id.InvoiceID
                                                 where ih.SourceID == (invoiceID == 0 ? (int)lkpInvoiceCode.EditValue : invoiceID)
                         select id).ToList();
            }
            if (other!=null)
            {
                foreach (var item in other)
                {
                    var i = invoiceProducts.SingleOrDefault(x => x.ID == item.itemID);
                    i.qty -= (int)item.itemQty;
                }
            }

            lkpInvoiceCode.Enabled = false;
            LkpProductCode.Properties.DataSource = invoiceProducts;
            LkpProductCode.Properties.DisplayMember = "ItemName";
            LkpProductCode.Properties.ValueMember = "ID";

            LkpProductCode.Properties.PopulateColumns();
            LkpProductCode.Properties.Columns[nameof(ClsInvoiceReturnModel.ID)].Visible = false;
            LkpProductCode.Properties.Columns[nameof(ClsInvoiceReturnModel.Code)].Caption = "كود";
            LkpProductCode.Properties.Columns[nameof(ClsInvoiceReturnModel.ItemName)].Caption = "اسم الصنف";
            LkpProductCode.Properties.Columns[nameof(ClsInvoiceReturnModel.Discount)].Visible = false;
            LkpProductCode.Properties.Columns[nameof(ClsInvoiceReturnModel.qty)].Caption = "كمية";
            LkpProductCode.Properties.Columns[nameof(ClsInvoiceReturnModel.Price)].Caption = "سعر";
            LkpProductCode.Properties.Columns[nameof(ClsInvoiceReturnModel.totalPrice)].Caption = "اجمالي";
            LkpProductCode.Properties.Columns[nameof(ClsInvoiceReturnModel.totalPrice)].Visible = false;

        }
        

        private void gridView1_Click(object sender, EventArgs e)
        {
            product = (ClsInvoiceReturnModel)gridView1.GetFocusedRow();
            if (product != null)
            {
                LkpProductCode.EditValue = product.ID;
                txtQty.Text = product.qty.ToString();
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            product = (ClsInvoiceReturnModel)gridView1.GetFocusedRow();
            LkpProductCode.EditValue = product.ID;
            txtQty.Text = product.qty.ToString();
        }

        private void lkpInvoiceCode_EnabledChanged(object sender, EventArgs e)
        {
           
        }

        private void ReturnProducts_ListChanged(object sender, ListChangedEventArgs e)
        {
            
          

        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Return)
            {
                txtDiscount.Focus();
            }
        }

        public override void New()
        {
            lkpInvoiceCode.Enabled = true;
            product = new ClsInvoiceReturnModel();
            returnProducts = new BindingList<ClsInvoiceReturnModel>();
        }

        private void btnSave_Print_Click(object sender, EventArgs e)
        {
            Save();
            RptInvoice rpt = new RptInvoice();
            rpt.DataSource = returnProducts;
            rpt.PrePareData(returnProducts, Header, null);
            Close();

        }

        private void lkpInvoiceCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData==Keys.Enter||e.KeyData==Keys.Return)
            {
                GetInvoiceData();
                
            }
        }

        private void txtQty_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Return)
            {
                if (!string.IsNullOrWhiteSpace(txtQty.Text) && int.Parse(txtQty.Text) > 0)
                {
                    AddProductToReturn();
                    gridView1.RefreshData();
                    txtDiscount.Text = "";
                    txtQty.Text = "";
                    LkpProductCode.EditValue = null;
                    LkpProductCode.Focus();
                }
            }

        }

        private void LkpProductCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData==Keys.Enter||e.KeyData==Keys.Return)
            {
                txtQty.Focus();
            }
        }

        private void lkpInvoiceCode_Popup(object sender, EventArgs e)
        {

            lkpInvoiceCode.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            lkpInvoiceCode.Properties.BestFit();
        }

        private void lkpInvoiceCode_CustomDrawCell(object sender, LookUpCustomDrawCellArgs e)
        {
            if (e.Column.FieldName==nameof(TblInvoiceHeader.Date))
            {
                if (((TblInvoiceHeader)e.Row).Date != null)
                {
                    var s = ((TblInvoiceHeader)e.Row).Date;
                    var d = ((DateTime)s).ToString("dd : MM : yyyy");
                    e.DisplayText = d;

            }
            }
          else  if (e.Column.FieldName == nameof(TblInvoiceHeader.Time))
            {
                if (((TblInvoiceHeader)e.Row).Time != null)
                {
                    var s = ((TblInvoiceHeader)e.Row).Time;
                    var d = DateTime.Today.Add((TimeSpan)s).ToString(" hh : mm tt");
                    e.DisplayText = d;

                }
            }

        }

        private void lkpInvoiceCode_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
          
        }
    }
}