using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AlphaSSA.VIEW
{
    public partial class FrmInvReprot : DevExpress.XtraEditors.XtraForm
    {
        List<Models.ClsInvReportModel> Ds;
        public FrmInvReprot() { InitializeComponent(); }

        void LoadData()
        {
            if(Ds == null)
            {
                using(var db = new SSADBDataContext())
                {
                    var data = (from dt in db.TbLInvoiceDetailes
                                join th in db.TblInvoiceHeaders on dt.InvoiceID equals th.ID
                                join pr in db.TblProducts on dt.itemID equals pr.ID
                                join sa in db.TblSallers on th.Saller equals sa.ID
                                select new Models.ClsInvReportModel
                                {
                                    InvoiceCode = th.code,
                                    InvoiceDate = th.Date,
                                    InvoiceTime = th.Time,
                                    ProductName = pr.Name,
                                    ProductBarcode = pr.barcode,
                                    BuyPrice = pr.BuyPrise,
                                    SellPrice = pr.price,
                                    ItemQty = dt.itemQty,
                                    TotalPrice = dt.TotalPrice,
                                    SallerName = sa.Name,
                                    invoiceType = th.invoiceType
                                    , Discount = th.Discount
                                }).ToList();

                    Ds = data;
                }
            }
        }

        void Caculate()
        {
            var tds = ((List<Models.ClsInvReportModel>)gridControl1.DataSource);
            txtTotal.Text = tds.Sum(x=>x.TotalPrice).ToString();
            txtProductCount.Text = tds.Count().ToString();
            var ddd = tds.Select(x => x.InvoiceCode).Distinct();
            txtInvCount.Text = ddd.Count().ToString();
            
        }

        void applyFilter()
        {
            LoadData();
            //var d1 = Ds.Where(
            //       x => x.invoiceType == (int)lkpInvoiceType.EditValue &&
            //           x.InvoiceDate >= DateTime.Parse(((DateTime)PicDateFrom.EditValue).ToShortDateString()) &&
            //           x.InvoiceDate <= DateTime.Parse(((DateTime)PicDateTo.EditValue).ToShortDateString()))
            //       .ToList();
            //var d2 = Ds.Except(d1);
            //gridControl1.DataSource = d2.ToList();
            if (checkEdit1.Checked && !checkEdit2.Checked)
            {
                gridControl1.DataSource = Ds.Where(
                    x => x.invoiceType == (int)lkpInvoiceType.EditValue &&
                        x.InvoiceDate >= DateTime.Parse(((DateTime)PicDateFrom.EditValue).ToShortDateString()) &&
                        x.InvoiceDate <= DateTime.Parse(((DateTime)PicDateTo.EditValue).ToShortDateString()))
                    .ToList();
            }
            else if (checkEdit1.Checked && checkEdit2.Checked)
            {
                gridControl1.DataSource = Ds.Where(
                    x => x.invoiceType == (int)lkpInvoiceType.EditValue &&
                        x.InvoiceDate >= DateTime.Parse(((DateTime)PicDateFrom.EditValue).ToShortDateString()) &&
                        x.InvoiceDate <= DateTime.Parse(((DateTime)PicDateTo.EditValue).ToShortDateString()) &&
                        x.SallerName == lkpSaller.Text)
                    .ToList();
            }

            else if (checkEdit2.Checked && !checkEdit1.Checked)
            {
                gridControl1.DataSource = Ds.Where(
                    x => x.InvoiceDate >= DateTime.Parse(((DateTime)PicDateFrom.EditValue).ToShortDateString()) &&
                        x.InvoiceDate <= DateTime.Parse(((DateTime)PicDateTo.EditValue).ToShortDateString()) &&
                        x.ProductBarcode == lkpSaller.Text)
                    .ToList();
            }
            else
            {
                gridControl1.DataSource = Ds.Where(
                    x => x.InvoiceDate >= DateTime.Parse(((DateTime)PicDateFrom.EditValue).ToShortDateString()) &&
                        x.InvoiceDate <= DateTime.Parse(((DateTime)PicDateTo.EditValue).ToShortDateString()))
                    .ToList();
            }
            gridView1.Columns[nameof(Models.ClsInvReportModel.invoiceType)].Visible = false;
            Caculate();
        }

        private void BtnSearch_Click(object sender, EventArgs e) { applyFilter(); }

        private void BtnExit_Click(object sender, EventArgs e) { Dispose(); }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            using(var file = new FolderBrowserDialog())
            {
                DialogResult dr = file.ShowDialog();
                if(dr == DialogResult.OK && !string.IsNullOrWhiteSpace(file.SelectedPath))
                {
                    string files = file.SelectedPath;

                    gridControl1.ExportToXls(files + @"\InvoiceReport.xls");

                    XtraMessageBox.Show("تم");
                }
            }
        }

        private void gridView1_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if(e.Column.FieldName == nameof(Models.ClsInvReportModel.InvoiceTime))
            {
                if(e.Value != null)
                {
                    var s = DateTime.Today.Add((TimeSpan)e.Value);
                    e.DisplayText = s.ToShortTimeString();
                }
            } else if(e.Column.FieldName == nameof(Models.ClsInvReportModel.TotalPrice))
            {
                var s = (decimal)e.Value;
                e.DisplayText = s.ToString("C");
            } else if(e.Column.FieldName == nameof(Models.ClsInvReportModel.BuyPrice))
            {
                var s = (decimal)e.Value;
                e.DisplayText = s.ToString("C");
            } else if(e.Column.FieldName == nameof(Models.ClsInvReportModel.SellPrice))
            {
                var s = (decimal)e.Value;
                e.DisplayText = s.ToString("C");
            }
        }

        private void FrmInvReprot_Load(object sender, EventArgs e)
        {
            using(var data = new SSADBDataContext())
            {
                 lkpSaller.Properties.DataSource = data.TblSallers.ToList();
               
                lkpSaller.Properties.DisplayMember = "Name";
                lkpSaller.Properties.ValueMember = "ID";
                
                lkpInvoiceType.Properties.DataSource = Internal.Master.InvoiceTypes;
                lkpInvoiceType.Properties.DisplayMember = "value";
                lkpInvoiceType.Properties.ValueMember = "ID";
                lkpInvoiceType.EditValue = ((List<Internal.Master.ValueAndID>)lkpInvoiceType.Properties.DataSource).First().ID;
               lkpSaller.EditValue = ((List<TblSaller>)lkpSaller.Properties.DataSource).First().ID;
                checkEdit1.Checked = true;
                PicDateTo.EditValue = DateTime.Now;

            }
        }
    }
}