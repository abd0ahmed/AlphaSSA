using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AlphaSSA.VIEW
{
    public partial class frmDailyReprort : DevExpress.XtraEditors.XtraForm
    {
        TblShift shift;
        SSADBDataContext db;
        TblInvoiceHeader currentRow;
        GridView gv;

        public frmDailyReprort()
        {
            InitializeComponent();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        void LoadData()
        {
            using (db = new SSADBDataContext())
            {

                txtshift.Properties.DataSource = db.TblShifts.ToList();
            }
            txtshift.Properties.DisplayMember = nameof(TblShift.shiftName);
            txtshift.Properties.ValueMember = nameof(TblShift.ID);
            txtshift.Properties.PopulateColumns();
            txtshift.Properties.Columns[nameof(TblShift.ID)].Visible = false;
            txtshift.Properties.Columns[nameof(TblShift.shiftNum)].Visible = false;
            txtshift.Properties.Columns[nameof(TblShift.shiftState)].Visible = false;
            txtshift.Properties.Columns[nameof(TblShift.shiftName)].Caption = "الشيفت";
            txtshift.Properties.Columns[nameof(TblShift.startDate)].Caption = "تاريخ البداية";
            txtshift.Properties.Columns[nameof(TblShift.startTime)].Caption = "وقت البداية";
            txtshift.Properties.Columns[nameof(TblShift.endDate)].Caption = "تاريخ انتهاء";
            txtshift.Properties.Columns[nameof(TblShift.endTime)].Caption = "وقت انتهاء";
            txtshift.Properties.PopupWidthMode = PopupWidthMode.ContentWidth;
            txtshift.Properties.PopupSizeable = true;
            txtshift.Properties.CustomDrawCell += Properties_CustomDrawCell;
            txtshift.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;

        }

        private void Properties_CustomDrawCell(object sender, LookUpCustomDrawCellArgs e)
        {
            if (e.DisplayText != string.Empty && e.Column.FieldName == nameof(TblShift.startDate))
            {
                e.DisplayText = DateTime.Parse(e.DisplayText).ToString("dd / MM / yyyy");
            }
            if (e.DisplayText != string.Empty && e.Column.FieldName == nameof(TblShift.endDate))
            {
                e.DisplayText = DateTime.Parse(e.DisplayText).ToString("dd / MM / yyyy");
            }
            if (e.DisplayText != string.Empty && e.Column.FieldName == nameof(TblShift.startTime))
            {
                e.DisplayText = DateTime.Today.Add(TimeSpan.Parse(e.DisplayText)).ToString("hh : mm tt");
            }
            if (e.DisplayText != string.Empty && e.Column.FieldName == nameof(TblShift.endTime))
            {
                e.DisplayText = DateTime.Today.Add(TimeSpan.Parse(e.DisplayText)).ToString("hh : mm tt");
            }

        }
        void getdata()
        {
            using (db = new SSADBDataContext())
            {
                // gridControl1.DataSource = db.TblInvoiceHeaders.Where(x => x.shift == (int)txtshift.EditValue).ToList();
                var data = from H in db.TblInvoiceHeaders
                           where H.shift == (int)txtshift.EditValue
                           select new Models.clsDilyreportModel(H)
                           {
                               TbLInvoiceDetailes = (from d in db.TbLInvoiceDetailes
                                                     where d.InvoiceID == H.ID
                                                     select d).ToList()
                           };
                gridControl1.DataSource = data.ToList();
            }
            gridView1.PopulateColumns();
            gridView1.Columns[nameof(TblInvoiceHeader.ID)].Visible = false;
            gridView1.Columns[nameof(TblInvoiceHeader.SourceID)].Visible = false;
            gridView1.Columns[nameof(TblInvoiceHeader.casher)].Visible = false;
            gridView1.Columns[nameof(TblInvoiceHeader.Printed)].Visible = false;
            gridView1.Columns[nameof(TblInvoiceHeader.ClientID)].Visible = false;
            gridView1.Columns[nameof(TblInvoiceHeader.Saller)].Visible = false;
            gridView1.Columns[nameof(TblInvoiceHeader.invoiceType)].Visible = true;
            gridView1.Columns[nameof(TblInvoiceHeader.invoiceType)].Caption = "نوع الفاتورة";
            gridView1.Columns[nameof(TblInvoiceHeader.shift)].Visible = false;
            gridView1.Columns[nameof(TblInvoiceHeader.Date)].Caption = "تاريخ";
            gridView1.Columns[nameof(TblInvoiceHeader.Date)].VisibleIndex = 0;
            gridView1.Columns[nameof(TblInvoiceHeader.Time)].VisibleIndex = 1;
            gridView1.Columns[nameof(TblInvoiceHeader.Time)].Caption = "وقت";
            gridView1.Columns[nameof(TblInvoiceHeader.code)].Caption = "كود";
            gridView1.Columns[nameof(TblInvoiceHeader.Total)].Caption = "اجمالي";
            gridView1.Columns[nameof(TblInvoiceHeader.Discount)].Caption = "خصم";
            gridView1.Columns[nameof(TblInvoiceHeader.net)].Caption = "صافي";
            List<Models.clsDilyreportModel> h = (List<Models.clsDilyreportModel>)gridControl1.DataSource;
            lblTotalSalles.Text = h.Where(x => x.invoiceType == (byte)Internal.Master.InvoiceType.Sales).Sum(x => x.net).ToString();
            lblTotalReturns.Text = h.Where(x => x.invoiceType == (byte)Internal.Master.InvoiceType.salesReturn).Sum(x => x.net).ToString();
            lblNet.Text = (decimal.Parse(lblTotalSalles.Text) - decimal.Parse(lblTotalReturns.Text)).ToString();

        }
        private void frmDailyReprort_Load(object sender, EventArgs e)
        {
            LoadData();
            gridView1.CustomColumnDisplayText += GridView1_CustomColumnDisplayText;
        }
        private void GridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == nameof(TblInvoiceHeader.Time))
            {
                DateTime dt;
                var s = DateTime.Today.Add((TimeSpan)e.Value);
                e.DisplayText = s.ToShortTimeString();
            }
            int R = 0;
            if (e.Value!=null)
            {
                int.TryParse(e.Value.ToString(), out R);
            }
           
            if (e.Column.FieldName == nameof(TblInvoiceHeader.invoiceType) && R != null)
            {
                e.DisplayText = Internal.Master.InvoiceTypes.SingleOrDefault(x => x.ID == int.Parse(e.Value.ToString())).value;
            }

        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            getdata();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {

            using (var file = new FolderBrowserDialog())
            {
                DialogResult dr = file.ShowDialog();
                if (dr == DialogResult.OK && !string.IsNullOrWhiteSpace(file.SelectedPath))
                {
                    string files = file.SelectedPath;

                    gridControl1.ExportToXls(files + @"\DailyReport.xls");
                    
                    XtraMessageBox.Show("تم");
                }
            }
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            frmInvNew frm = new frmInvNew(currentRow);
            frm.Print();
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            currentRow = (TblInvoiceHeader)gridView1.GetFocusedRow();
        }

        private void gridControl1_ViewRegistered(object sender, DevExpress.XtraGrid.ViewOperationEventArgs e)
        {
            gv = e.View as GridView;
            gv.PopulateColumns();
            gv.ViewCaption = "تفاصيل الفاتورة";
            gv.Columns[nameof(TbLInvoiceDetaile.ID)].Visible = false;
            gv.Columns[nameof(TbLInvoiceDetaile.InvoiceID)].Visible = false;
            gv.Columns[nameof(TbLInvoiceDetaile.StoreID)].Visible = false;
            gv.Columns[nameof(TbLInvoiceDetaile.itemID)].Caption = "الصنف";
            gv.Columns[nameof(TbLInvoiceDetaile.itemQty)].Caption = "كمية";
            gv.Columns[nameof(TbLInvoiceDetaile.price)].Caption = "سعر";
            gv.Columns[nameof(TbLInvoiceDetaile.TotalPrice)].Caption = "اجمالي";
            gv.Columns[nameof(TbLInvoiceDetaile.TotalPrice)].VisibleIndex = 4;


            gv.CustomDrawCell += Gv_CustomDrawCell;

        }

        private void Gv_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.Name== "colitemID")
            {
                using (var db = new SSADBDataContext())
                {
                    e.DisplayText = db.TblProducts.SingleOrDefault(x => x.ID == (int)e.CellValue).Name.ToString();
                }
            }
           
            
        }
    }
}