using AlphaSSA.Internal;
using AlphaSSA.Models;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AlphaSSA.VIEW
{
    public partial class frmInvNew : DevExpress.XtraEditors.XtraForm
    {
        BindingList<TblClient> Clients;
        SSADBDataContext db;
        TblInvoiceHeader Header;
        SSADBDataContext invDb;
        ClsInvoiceProducts InvoiceProduct;
        BindingList<ClsInvoiceProducts> InvoiceProducts;
        Master.InvoiceType InvoiceType;
        TblProduct product;
        List<TblProduct> Products;
        UCDiscount UCDiscount;
        UCInvSeller uCInvSeller;
        UCinvStore UCinvStore;
        UCShift UCShift;
        UCInvoicePanSec UCUser;


        public frmInvNew()
        {
            InitializeComponent();
            ininializeData();
            New();
        }


        public frmInvNew(Master.InvoiceType type)
        {
            this.InvoiceType = type;
            InitializeComponent();
            ininializeData();
            New();
            if (type == Internal.Master.InvoiceType.Purchase)
            {
                Ulock_P_Q_Edits();
            }
        }

        public frmInvNew(clsInvoiceInfos header)
        {
            InitializeComponent();
            ininializeData();
            this.Header = header;
            RetriveData();
        }

        public frmInvNew(TblInvoiceHeader header)
        {
            InitializeComponent();
            ininializeData();
            this.Header = header;
            RetriveData();
        }

        void BindDataSource()
        {
            switch (InvoiceType)
            {
                case Master.InvoiceType.Sales:
                    ColPrice.FieldName = nameof(TblProduct.price);
                    break;
                case Master.InvoiceType.Purchase:
                    ColPrice.FieldName = nameof(TblProduct.BuyPrise);
                    break;
                case Master.InvoiceType.salesReturn:
                    break;
                case Master.InvoiceType.PurchaseReturn:
                    break;
                default:
                    break;
            }

            InvoiceProducts = new BindingList<ClsInvoiceProducts>();
            gridControl2.DataSource = InvoiceProducts;
            InvoiceProducts.RaiseListChangedEvents = true;
            InvoiceProducts.ListChanged += InvoiceProducts_ListChanged;
        }

        private void BtnAddCount_Click(object sender, EventArgs e)
        {
            InvoiceProduct = gridView1.GetFocusedRow() as ClsInvoiceProducts;
            if (InvoiceProduct == null)
            {
                return;
            }
            InvoiceProduct.qty += 1;
            InvoiceProduct.totalPrice = InvoiceProduct.Price * InvoiceProduct.qty;
            ClsInvoiceProducts be = InvoiceProducts.First(x => x.ID == InvoiceProduct.ID);
            be = InvoiceProduct;
            InvoiceProducts.RaiseListChangedEvents = true;
            InvoiceProducts_ListChanged(
                InvoiceProducts,
                new ListChangedEventArgs(
                    ListChangedType.ItemChanged,
                    InvoiceProducts.SingleOrDefault(x => x.ID == InvoiceProduct.ID).index));
            gridControl1.Refresh();
            gridView1.Focus();
        }

        private void BtnBarcodeSearch_Click(object sender, EventArgs e)
        {
            getProductData();
            txtBarcode.Text = string.Empty;
        }

        private void BtnClientsList_Click(object sender, EventArgs e)
        {
            FrmClientsList frm = new FrmClientsList();
            frm.ShowDialog();
        }

        private void BtnExit_Click(object sender, EventArgs e) { this.Dispose(); }

        private void BtnFastSave_Click(object sender, EventArgs e)
        {
            FrmSellerPrompt frm = new FrmSellerPrompt(uCInvSeller);
            frm.ShowDialog();
            bool co = true;
            if (!co)
            {
                return;
            }
            Save_Print();

            ininializeData();
            New();
        }

        private void BtnInvoiceList_Click(object sender, EventArgs e)
        {
            frmInvoiceList frm = new frmInvoiceList();
            frm.ShowDialog();
        }

        private void BtnMinusCount_Click(object sender, EventArgs e)
        {
            InvoiceProduct = gridView1.GetFocusedRow() as ClsInvoiceProducts;
            if (InvoiceProduct == null)
            {
                return;
            }
            if (InvoiceProduct.qty == 1)
            {
                InvoiceProducts.Remove(InvoiceProduct);
                InvoiceProducts_ListChanged(
                    InvoiceProducts,
                    new ListChangedEventArgs(ListChangedType.ItemDeleted, InvoiceProduct.index - 1));
                return;
            }
            InvoiceProduct.qty -= 1;
            InvoiceProduct.totalPrice = InvoiceProduct.Price * InvoiceProduct.qty;
            ClsInvoiceProducts be = InvoiceProducts.First(x => x.ID == InvoiceProduct.ID);
            be = InvoiceProduct;
            InvoiceProducts_ListChanged(
                InvoiceProducts,
                new ListChangedEventArgs(
                    ListChangedType.ItemChanged,
                    InvoiceProducts.SingleOrDefault(x => x.ID == InvoiceProduct.ID).index));
            gridControl1.Refresh();
            gridView1.Focus();
        }

        private void BtnNew_Click(object sender, EventArgs e) { New(); }

        private void BtnPrint_Click(object sender, EventArgs e) { Print(); }

        private void BtnProductsList_Click(object sender, EventArgs e)
        {
            FrmProductsList frm = new FrmProductsList(true);
            frm.ShowDialog();
        }

        private void BtnRemoveProduct_Click(object sender, EventArgs e)
        {
            if (InvoiceProduct == null)
            {
                return;
            }
            InvoiceProduct = gridView1.GetFocusedRow() as ClsInvoiceProducts;
            InvoiceProducts.Remove(InvoiceProduct);
            InvoiceProducts_ListChanged(InvoiceProducts, new ListChangedEventArgs(ListChangedType.ItemDeleted, null));

            gridView1.Focus();
        }

        private void BtnRetrev_Click(object sender, EventArgs e)
        {
            FrmReturn frm = new FrmReturn(InvoiceType);
            frm.ShowDialog();
        }

        private void BtnSave_Click(object sender, EventArgs e) { Save(); }

        private void BtnShiftList_Click(object sender, EventArgs e)
        {
            frmDailyReprort frm = new frmDailyReprort();
            frm.ShowDialog();
        }

        void Clear()
        {
            // txtCode.Text = string.Empty;
            lblDiscount.Text = "0";
            lblNet.Text = "0";
            lblPeaceCount.Text = "0";
            lblProductCount.Text = "0";
            lblTotal.Text = "0";
            gridControl2.DataSource = null;
            uCInvSeller.SetClientID(Properties.Settings.Default.DefaultCahser);
            UCUser.SetClientID(Properties.Settings.Default.DefaultClient);
            UCinvStore.SetClientID(Properties.Settings.Default.DefaultStore);
            UCDiscount.clear();
        }


        private void frmInvNew_Load(object sender, EventArgs e)
        {
            BindDataSource();

            this.gridControl2.LookAndFeel.SetSkinStyle("My Basic");
            using (db = new SSADBDataContext())
            {
                gridControl1.DataSource = db.TblProducts;
            }

            gridView1.CellValueChanged += GridView1_CellValueChanged;
        }

        DateTime? GetinvoiceDT()
        {
            DateTime dt = DateTime.Now;
            DateTime def = new DateTime();
            if (Header.Date != null && Header.Date != def)
            {
                return Header.Date;
            }
            return dt;
        }

        TimeSpan? Getinvoicetime()
        {
            TimeSpan dt = DateTime.Now.TimeOfDay;
            TimeSpan def = new TimeSpan();
            if (Header.Time != null && Header.Time != def)
            {
                return Header.Time;
            }
            return dt;
        }

        void getProductData()
        {
            using (invDb = new SSADBDataContext())

            {
                product = Products.Single(x => x.barcode == txtBarcode.EditValue.ToString().ToUpper());
                // product = invDb.TblProducts.SingleOrDefault(x => x.barcode ==  txtSearch.EditValue.ToString().Trim());
                InvoiceProduct = new ClsInvoiceProducts();
                if (product == null)
                {
                    XtraMessageBox.Show("هذا الكود غير موجود");
                    return;
                }
                InvoiceProduct.ItemName = product.Name;
                InvoiceProduct.ID = product.ID;
                if (InvoiceType == Master.InvoiceType.PurchaseReturn || InvoiceType == Master.InvoiceType.Purchase)
                {
                    InvoiceProduct.Price = (decimal)product.BuyPrise;
                }
                else if (InvoiceType == Master.InvoiceType.salesReturn || InvoiceType == Master.InvoiceType.Sales)
                {
                    InvoiceProduct.Price = (decimal)product.price;
                }


                var exist = InvoiceProducts.FirstOrDefault(x => x.ID == InvoiceProduct.ID);
                if (exist != null)
                {
                    exist.qty += 1;
                    exist.totalPrice = exist.Price * exist.qty;
                    InvoiceProducts.Remove(exist);
                    InvoiceProducts.Add(exist);
                    return;
                }
                InvoiceProduct.qty += 1;
                InvoiceProduct.totalPrice = InvoiceProduct.Price * InvoiceProduct.qty;
                InvoiceProducts.Add(InvoiceProduct);
            }
        }

        void getProductData(TblProduct product)
        {
            using (invDb = new SSADBDataContext())

            {
                InvoiceProduct = new ClsInvoiceProducts();
                if (product == null)
                {
                    XtraMessageBox.Show("هذا الكود غير موجود");
                    return;
                }
                InvoiceProduct.ItemName = product.Name;
                InvoiceProduct.ID = product.ID;
                if (InvoiceType == Master.InvoiceType.PurchaseReturn || InvoiceType == Master.InvoiceType.Purchase)
                {
                    InvoiceProduct.Price = (decimal)product.BuyPrise;
                }
                else if (InvoiceType == Master.InvoiceType.salesReturn || InvoiceType == Master.InvoiceType.Sales)
                {
                    InvoiceProduct.Price = (decimal)product.price;
                }
                InvoiceProduct.totalPrice = InvoiceProduct.Price * InvoiceProduct.qty;
                var exist = InvoiceProducts.FirstOrDefault(x => x.ID == InvoiceProduct.ID);
                if (exist != null)
                {
                    exist.qty += 1;
                    exist.totalPrice = exist.Price * exist.qty;
                    InvoiceProducts.Remove(exist);
                    InvoiceProducts.Add(exist);
                    // InvoiceProducts_ListChanged(InvoiceProducts, new ListChangedEventArgs(ListChangedType.ItemChanged, InvoiceProducts.SingleOrDefault(x => x.ID == InvoiceProduct.ID).index));
                    return;
                }
                InvoiceProduct.qty += 1;
                InvoiceProduct.totalPrice = InvoiceProduct.Price * InvoiceProduct.qty;
                InvoiceProducts.Add(InvoiceProduct);
            }
            gridView1.RefreshData();
        }

        private void GridView1_CellValueChanged(
            object sender,
            DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            InvoiceProducts_ListChanged(
                gridView1,
                new ListChangedEventArgs(ListChangedType.ItemChanged, gridView1.GetDataSourceRowIndex(e.RowHandle)));
        }

        void InializeClients()
        {
            try
            {
                Clients = new BindingList<TblClient>(db.TblClients.ToList());
                UCUser.GetData(Clients);
                UCUser.SetClientID(Properties.Settings.Default.DefaultClient);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
          
        }

        void inializeControls()
        {
            var c = panelControl12.Controls.Count;
            if (c <= 0)
            {
                panelControl12.Controls.Add(UCShift = new UCShift(inializeShift()) { Dock = DockStyle.Top });
                panelControl12.Controls.Add(UCDiscount = new UCDiscount(db, lblDiscount) { Dock = DockStyle.Top });
                panelControl12.Controls.Add(uCInvSeller = new UCInvSeller(db) { Dock = DockStyle.Top });
                panelControl12.Controls.Add(UCinvStore = new UCinvStore(db) { Dock = DockStyle.Top });
                panelControl12.Controls.Add(UCUser = new UCInvoicePanSec(db) { Dock = DockStyle.Top });
            }
        }

        private void InializeProducts()
        {
            Products = db.TblProducts.ToList();
        }

        void InializeSallers()
        {
            uCInvSeller.GetData(db.TblSallers.ToList());
            uCInvSeller.SetClientID(Properties.Settings.Default.DefaultCahser);
        }

        TblShift inializeShift()
        {
            using (db = new SSADBDataContext())
            {
                return db.TblShifts.SingleOrDefault(x => x.shiftState == (int)Internal.Master.ShiftState.open);
            }
        }

        private void InializeStores()
        {
            UCinvStore.GetData(db.tblStores.ToList());
            UCinvStore.SetClientID(Properties.Settings.Default.DefaultStore);
        }

        void InializeType()
        {
            switch (InvoiceType)
            {
                case Master.InvoiceType.Sales:
                    if (Header == null || Header.ID == 0)
                    {
                        // LockControls();
                    }
                    else
                    {
                        // Unlockcontrols();
                    }
                    lblFormHead.Text = "فاتورة مبيعات";
                    break;
                case Master.InvoiceType.Purchase:
                    if (Header == null || Header.ID == 0)
                    {
                        //LockControls();
                    }
                    else
                    {
                        // Unlockcontrols();
                    }
                    lblFormHead.Text = "فاتورة مشتريات";
                    break;
                case Master.InvoiceType.salesReturn:

                    break;
                case Master.InvoiceType.PurchaseReturn:

                    break;
                default:
                    break;
            }
        }
        void ininializeData()
        {
            inializeControls();
            using (db = new SSADBDataContext())
            {
                InializeClients();
                InializeStores();
                InializeType();
                InializeProducts();
                InializeSallers();
                InitializeCode();
            }
        }

        void InitializeCode()
        {
            switch (InvoiceType)
            {
                case Master.InvoiceType.Sales:
                    lblInvoiceCode.Text = GetNewCode("SI-00000000");
                    lblheader.Text = "فاتورة مبيعات";
                    break;
                case Master.InvoiceType.Purchase:
                    lblInvoiceCode.Text = GetNewCode("PR-00000000");
                    lblheader.Text = "فاتورة مشتريات";

                    break;
                case Master.InvoiceType.salesReturn:
                    lblInvoiceCode.Text = GetNewCode("SRI-00000000");
                    lblheader.Text = "فاتورة مردود مبيعات";
                    break;
                case Master.InvoiceType.PurchaseReturn:
                    lblInvoiceCode.Text = GetNewCode("PRR-00000000");
                    lblheader.Text = "فاتورة مردود مشتريات";
                    break;
                default:
                    break;
            }
            lblInvoiceCode.Refresh();
        }

        private void InvoiceProducts_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded)
            {
                InvoiceProducts.LastOrDefault().index = e.NewIndex;
            }
            if (e.ListChangedType == ListChangedType.ItemChanged)
            {
                // XtraMessageBox.Show("ok");
            }
            switch (e.ListChangedType)
            {
                case ListChangedType.Reset:
                    break;
                case ListChangedType.ItemAdded:
                    var row = InvoiceProducts[e.NewIndex];
                    using (var db = new SSADBDataContext())
                    {
                        var o = db.TblStoreProducts
                            .SingleOrDefault(x => x.productID == row.ID && x.StoreID == UCinvStore.GetClientID());
                        int fullQty = 0;
                        if (o != null)
                        {
                            fullQty = ((o.Qty) ?? 0);
                        }


                        if (row.qty > fullQty)
                        {
                            if (InvoiceType == Master.InvoiceType.Sales)
                            {
                                XtraMessageBox.Show("لا يوجد كمية كافية بالمخزن");
                                if (row.qty == 1)
                                {
                                    InvoiceProducts.Remove(row);
                                }
                                else
                                {
                                    row.qty -= 1;
                                }
                            }
                        }
                    }
                    break;
                case ListChangedType.ItemDeleted:
                    break;
                case ListChangedType.ItemMoved:
                    break;
                case ListChangedType.ItemChanged:
                    row = InvoiceProducts[e.NewIndex];
                    using (var db = new SSADBDataContext())
                    {
                        var o = db.TblStoreProducts
                            .SingleOrDefault(x => x.productID == row.ID && x.StoreID == UCinvStore.GetClientID());
                        int fullQty = 0;
                        if (o != null)
                        {
                            fullQty = ((o.Qty) ?? 0);
                        }

                        if (row.qty > fullQty)
                        {
                            if (InvoiceType == Master.InvoiceType.Sales)
                            {
                                XtraMessageBox.Show("لا يوجد كمية كافية بالمخزن");
                                row.qty -= 1;
                            }
                        }
                        row.totalPrice = row.Price * row.qty;
                    }
                    break;
                case ListChangedType.PropertyDescriptorAdded:
                    break;
                case ListChangedType.PropertyDescriptorDeleted:
                    break;
                case ListChangedType.PropertyDescriptorChanged:
                    break;
                default:
                    break;
            }

            lblTotal.Text = InvoiceProducts.Sum(x => x.totalPrice).ToString();
            lblProductCount.Text = InvoiceProducts.Count().ToString();
            lblPeaceCount.Text = InvoiceProducts.Sum(x => x.qty).ToString();
            lblNet.Text = (decimal.Parse(lblTotal.Text) - decimal.Parse(lblDiscount.Text)).ToString();
        }

        private void lblDate_Paint(object sender, PaintEventArgs e)
        { lblDate.Text = DateTime.Now.ToString("dd / MM / yyyy"); }

        private void lblDiscount_TextChanged(object sender, EventArgs e)
        { lblNet.Text = (decimal.Parse(lblTotal.Text) - decimal.Parse(lblDiscount.Text)).ToString(); }

        private void lblFormHead_DoubleClick(object sender, EventArgs e) { WindowState = FormWindowState.Minimized; }

        private void lblFormHead_Paint(object sender, PaintEventArgs e)
        {
        }

        void LockColumnEdits()
        {
            gridView1.OptionsBehavior.Editable = false;
            Colqty.OptionsColumn.AllowEdit = false;
            ColPrice.OptionsColumn.AllowEdit = false;
            ColtotalPrice.OptionsColumn.AllowEdit = false;
            ColID.OptionsColumn.AllowEdit = false;
            ColItemName.OptionsColumn.AllowEdit = false;
            if (lblheader.Text == "فاتورة مشتريات")
            {
                Ulock_P_Q_Edits();
            }
        }

        void LockSave()
        {
            BtnSave.Enabled = false;
            BtnFastSave.Enabled = false;
        }

        void NewShift()
        {
            using (db = new SSADBDataContext())
            {
                var sh = db.TblShifts.SingleOrDefault(x => x.shiftState == (int)Internal.Master.ShiftState.open);
                if (sh != null)
                {
                    sh.endDate = DateTime.Now;
                    sh.endTime = DateTime.Now.TimeOfDay;
                    sh.shiftState = (int)Internal.Master.ShiftState.close;
                    db.SubmitChanges();
                }
                //========================================================
                var sh1 = new TblShift();
                sh1.startDate = DateTime.Now;
                sh1.startTime = DateTime.Now.TimeOfDay;
                sh1.shiftState = (int)Internal.Master.ShiftState.open;
                sh1.shiftName = NewShiftName(sh);
                db.TblShifts.InsertOnSubmit(sh1);
                db.SubmitChanges();
                UCShift.refreshData(sh1);
            }
        }
        string NewShiftName(TblShift sh)
        {
            if (sh != null)
            {
                char s1 = sh.shiftName.LastOrDefault();
                int i1 = int.Parse(s1.ToString());
                int index = sh.shiftName.LastIndexOf(s1);
                return (DateTime.Now.ToString("dd_MM_yyyy_") + (i1 + 1).ToString());
            }
            else
            {
                return (DateTime.Now.ToString("dd_MM_yyyy") + "_" + "1");
            }
        }
        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            labelControl3.SetBounds(
                (panel1.Width / 2 - labelControl3.Width / 2),
                (panel1.Height / 2 - labelControl3.Height / 2),
                labelControl3.Width,
                labelControl3.Height);
        }
        private void panel2_SizeChanged(object sender, EventArgs e)
        {
            labelControl2.SetBounds(
                (panel2.Width / 2 - labelControl2.Width / 2),
                (panel2.Height / 2 - labelControl2.Height / 2),
                labelControl2.Width,
                labelControl2.Height);
        }

        private void panel3_SizeChanged(object sender, EventArgs e)
        {
            labelControl1.SetBounds(
                (panel3.Width / 2 - labelControl1.Width / 2),
                (panel3.Height / 2 - labelControl1.Height / 2),
                labelControl1.Width,
                labelControl1.Height);
        }

        void PrepareDate()
        {
            Header = new TblInvoiceHeader();
            Header.ClientID = UCUser.GetClientID();
            Header.code = lblInvoiceCode.Text;
            Header.Date = GetinvoiceDT();
            Header.Time = Getinvoicetime();
            Header.net = decimal.Parse(lblNet.Text);
            Header.Total = decimal.Parse(lblTotal.Text);
            Header.Discount = (decimal?)decimal.Parse(lblDiscount.Text) ?? 0; // ToDo:Get Value From UserControl
            Header.invoiceType = (byte)InvoiceType;
            Header.Saller = uCInvSeller.GetClientID();
            Header.shift = UCShift.getCurrentShift().ID;
        }

        void RetriveData()
        {
            using (db = new SSADBDataContext())
            {
                InvoiceProducts = new BindingList<ClsInvoiceProducts>(
                    (from p in db.TblProducts
                     join ip in db.TbLInvoiceDetailes on p.ID equals ip.itemID
                     where ip.InvoiceID == Header.ID
                     select new ClsInvoiceProducts
                     {
                         ID = ip.ID,
                         ItemName = p.Name,
                         Price = (decimal)ip.price,
                         totalPrice = (decimal)ip.TotalPrice,
                         qty = (int)ip.itemQty
                     }).ToList());
                txtBarcode.Text = Header.code;
                lblDate.Text = Header.Date?.ToString("dd / MM / yyyy ") ?? "na";
                UCinvStore.SetClientID(db.TbLInvoiceDetailes.FirstOrDefault(x => x.InvoiceID == Header.ID).StoreID);
                UCUser.SetClientID(Header.ClientID);
            }
            // gridControl1.DataSource = null;
            int index = 0;
            foreach (var item in InvoiceProducts)
            {
                index += 1;
                item.index = index;
            }
            gridControl1.DataSource = InvoiceProducts;
            gridControl1.Refresh();
            //gridView1.RefreshData();
            //gridControl1.RefreshDataSource();
        }

        void Save_Print()
        {
            Save();
            if (Header == null || Header.ID == 0)
            {
                return;
            }
            RptInvoice rpt = new RptInvoice();
            rpt.DataSource = InvoiceProducts;
            rpt.PrePareData(InvoiceProducts, Header, null, true);
            New();
            InitializeCode();
            Clear();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("تأكيد اغلاق الشيفت وفتح شيفت جديد", "تنبيه", MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {
                NewShift();
            }
        }

        private void tileView1_ItemClick(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventArgs e)
        {
            getProductData((TblProduct)tileView1.GetFocusedRow());
        }

        private void txtBarcode_EditValueChanged(object sender, EventArgs e)
        {
            if (UCinvStore.GetClientID() == null)
            {
                UCinvStore.SetError("برجاء اختيار المخزن");
                return;
            }
            else
            {
                UCinvStore.SetError(string.Empty);
            }
            if (UCUser.GetClientID() == null)
            {
                UCUser.SetError("برجاء اختيار العميل");
                return;
            }
            else
            {
                UCUser.SetError(string.Empty);
            }
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Return)
            {
                getProductData();
                txtBarcode.Text = string.Empty;
            }
        }

        private void txtsearch_EditValueChanged(object sender, EventArgs e)
        {
            tileView1.ApplyFindFilter(txtsearch.Text);
        }

        void Ulock_P_Q_Edits()
        {
            gridView1.OptionsBehavior.Editable = true;
            Colqty.OptionsColumn.AllowEdit = true;
            Colqty.OptionsColumn.ReadOnly = false;
            ColPrice.OptionsColumn.AllowEdit = true;
            ColPrice.OptionsColumn.ReadOnly = false;
        }

        void UnLockSave()
        {
            BtnSave.Enabled = true;
            BtnFastSave.Enabled = true;
        }

        bool VAlidateData()
        {
            bool v = true;
            if (UCinvStore.GetClientID() == null)
            {
                UCinvStore.SetError("برجاء اختيار المخزن");
                v = false;
            }
            if (UCUser.GetClientID() == null)
            {
                UCUser.SetError("برجاء اختيار العميل");
                v = false;
            }
            if (gridView1.RowCount <= 0)
            {
                XtraMessageBox.Show("لا يمكن حفظ الفاتورة فارغة");
                v = false;
            }
            return v;
        }

        public void New()
        {
            Header = new TblInvoiceHeader();
            InvoiceProduct = new ClsInvoiceProducts();
            lblDate.Text = DateTime.Now.Date.ToString("dd / MM / yyyy");
            Clear();
            BindDataSource();
            UnLockSave();
            LockColumnEdits();
            // Unlockcontrols();
        }

        public void Print()
        {
            RptInvoice rpt = new RptInvoice();
            rpt.DataSource = InvoiceProducts;
            rpt.PrePareData(InvoiceProducts, Header, null, false);
        }

        public void Save()
        {
            if (!VAlidateData())
            {
                return;
            }
            PrepareDate();
            using (db = new SSADBDataContext())
            {
                db.TblInvoiceHeaders.InsertOnSubmit(Header);
                db.SubmitChanges();
            }
            if (Header.invoiceType == (int)Master.InvoiceType.Sales)
            {
                List<TblStoreProduct> storeProducts = new List<TblStoreProduct>();
                using (db = new SSADBDataContext())
                {
                    var ItemsForSave = new List<TbLInvoiceDetaile>();
                    foreach (var item in InvoiceProducts)
                    {
                        var ifs = new TbLInvoiceDetaile()
                        {
                            itemID = item.ID,
                            InvoiceID = Header.ID,
                            itemQty = item.qty,
                            price = item.Price,
                            TotalPrice = item.totalPrice,
                            StoreID = UCinvStore.GetClientID()
                            
                        };
                        ItemsForSave.Add(ifs);
                        //--------------SubFromStoreQty
                        var storeproduct = db.TblStoreProducts
                            .SingleOrDefault(x => x.productID == ifs.itemID && x.StoreID == ifs.StoreID);
                        storeproduct.Qty -= ifs.itemQty;
                        storeProducts.Add(storeproduct);
                    }
                    db.TbLInvoiceDetailes.InsertAllOnSubmit(ItemsForSave);
                    // db.TblStoreProducts.AttachAll(storeProducts);
                    db.SubmitChanges();
                }
            }
            else if (Header.invoiceType == (int)Master.InvoiceType.Purchase)
            {
                List<TblStoreProduct> storeProducts = new List<TblStoreProduct>();
                using (db = new SSADBDataContext())
                {
                    var ItemsForSave = new List<TbLInvoiceDetaile>();
                    foreach (var item in InvoiceProducts)
                    {
                        var ifs = new TbLInvoiceDetaile()
                        {
                            itemID = item.ID,
                            InvoiceID = Header.ID,
                            itemQty = item.qty,
                            price = item.Price,
                            TotalPrice = item.totalPrice,
                            StoreID = UCinvStore.GetClientID()
                        };
                        ItemsForSave.Add(ifs);
                        //------------------AddToStoreQty
                        var storeproduct = db.TblStoreProducts
                            .SingleOrDefault(x => x.productID == ifs.itemID && x.StoreID == ifs.StoreID);
                        if (storeproduct == null)
                        {
                            storeproduct = new TblStoreProduct();
                            storeproduct.productID = (int)ifs.itemID;
                            storeproduct.StoreID = (int)ifs.StoreID;
                            storeproduct.Qty = 0;
                            db.TblStoreProducts.InsertOnSubmit(storeproduct);
                            db.SubmitChanges();
                            storeProducts.Add(storeproduct);
                        }
                        storeproduct.Qty += ifs.itemQty;
                    }
                    db.TbLInvoiceDetailes.InsertAllOnSubmit(ItemsForSave);
                    //db.TblStoreProducts.AttachAll(storeProducts);
                    db.SubmitChanges();
                }
            }
            XtraMessageBox.Show("تم الحفظ");
            LockSave();
        }

        #region InvoiceCode
        string GetNewCode(string codeform)
        {
            var maxcode = string.Empty;
            using (db = new SSADBDataContext())
            {
                List<TblInvoiceHeader> data = db.TblInvoiceHeaders
                    .Where(x => x.invoiceType == (byte)InvoiceType)
                    .ToList();
                if (data.Count() > 0)
                {
                    maxcode = data.Max(x => x.code);
                }

                if (string.IsNullOrEmpty(maxcode))
                {
                    maxcode = codeform;
                }
            }
            return NextCode(maxcode);
        }

        public static string NextCode(string maxcode)
        {
            if (string.IsNullOrEmpty(maxcode))
            {
                return "1";
            }
            string str1 = string.Empty;
            foreach (char c in maxcode)
                str1 = char.IsDigit(c) ? str1 + c : str1;
            if (string.IsNullOrEmpty(str1))
                return maxcode + 1;
            string str2 = str1.Insert(0, "1");
            str2 = (Convert.ToInt64(str2) + 1).ToString();
            string str3 = str2[0] == '1' ? str2.Remove(0, 1) : str2.Remove(0, 1).Insert(0, "1");
            int index = maxcode.LastIndexOf(str1);
            maxcode = maxcode.Remove(index);
            maxcode = maxcode.Insert(index, str3);
            return maxcode;
        }
        #endregion
    }
}