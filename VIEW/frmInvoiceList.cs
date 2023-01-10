using AlphaSSA.Internal;
using AlphaSSA.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AlphaSSA.VIEW
{
    public partial class frmInvoiceList : FrmMAster
    {
        List<clsInvoiceInfos> ds;
        TblInvoiceHeader Head;

        public frmInvoiceList() { InitializeComponent(); }

        void caculate()
        {
            List<clsInvoiceInfos> dd = new List<clsInvoiceInfos>();
            for (int i = 0; i < gridView1.DataRowCount; i++)
            {
                dd.Add(gridView1.GetRow(i) as clsInvoiceInfos);
            }
            txtCount.Text = gridView1.RowCount.ToString();
            txtTotal.Text = (dd.Where(x => x.invoiceType == (byte)Master.InvoiceType.Sales).Sum(x => x.net) -
                dd.Where(x => x.invoiceType == (byte)Master.InvoiceType.Purchase).Sum(x => x.net) +
                dd.Where(x => x.invoiceType == (byte)Master.InvoiceType.PurchaseReturn).Sum(x => x.net) -
                dd.Where(x => x.invoiceType == (byte)Master.InvoiceType.salesReturn).Sum(x => x.net))
                .ToString();
        }

        private void frmInvoiceList_Load(object sender, EventArgs e)
        {
            getdata();
            gridView1.Columns[nameof(clsInvoiceInfos.ClientID)].Visible = false;
            gridView1.Columns[nameof(clsInvoiceInfos.ID)].Visible = false;
            gridView1.Columns[nameof(clsInvoiceInfos.Discount)].Visible = false;
            gridView1.Columns[nameof(clsInvoiceInfos.Date)].Visible = false;
            gridView1.Columns[nameof(clsInvoiceInfos.Total)].Visible = false;
            gridView1.Columns[nameof(clsInvoiceInfos.net)].Visible = false;
            gridView1.Columns[nameof(clsInvoiceInfos.code)].Visible = false;
            gridView1.Columns[nameof(clsInvoiceInfos.invoiceType)].Visible = false;
            gridView1.Columns[nameof(clsInvoiceInfos.Printed)].Visible = false;
            gridView1.Columns[nameof(clsInvoiceInfos.SourceID)].Visible = false;
            gridView1.Columns[nameof(clsInvoiceInfos.Saller)].Visible = false;
            gridView1.Columns[nameof(clsInvoiceInfos.InvoiceTime)].Visible = false;
            gridView1.Columns[nameof(clsInvoiceInfos.Time)].Visible = false;
            gridView1.Columns[nameof(clsInvoiceInfos.shift)].Visible = false;
            gridView1.Columns[nameof(clsInvoiceInfos.casher)].Visible = false;

            caculate();
        }

        void getdata()
        {
            using (var db = new SSADBDataContext())
            {
                ds = (from i in db.TblInvoiceHeaders
                      join c in db.TblClients on i.ClientID equals c.ID

                      select new Models.clsInvoiceInfos
                      {
                          ID = i.ID,
                          invoiceID = i.ID,
                          ClientID = i.ClientID,
                          code = i.code,
                          Code = i.code,
                          InvoiceDate = (DateTime)i.Date,
                          Discount1 = (decimal?)i.Discount??0,
                          Discount = i.Discount,
                          invoiceType = i.invoiceType,
                          InvType = Internal.Master.InvoiceTypes[(byte)i.invoiceType].value,
                          Total = i.Total,
                          TotolPrice = (decimal?)i.Total??0,
                          ClinetName = c.Name,
                          net = i.net,
                          Saller = i.Saller,
                          Date = i.Date,
                          InvoiceTime = i.Time
                      }).ToList();
            }
            gridControl1.DataSource = ds;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            clsInvoiceInfos infos = (clsInvoiceInfos)gridView1.GetFocusedRow();
            frmInvNew frm = new frmInvNew(infos);
            frm.Print();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        { Head = (TblInvoiceHeader)gridView1.GetFocusedRow(); }

        private void gridView1_RowCountChanged(object sender, EventArgs e) { caculate(); }

        private void gridView1_SubstituteFilter(object sender, DevExpress.Data.SubstituteFilterEventArgs e)
        { caculate(); }
    }
}