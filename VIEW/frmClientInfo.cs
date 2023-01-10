using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlphaSSA.Models;

namespace AlphaSSA.VIEW
{
    
    public partial class frmClientInfo : FrmMAster
    {
        ClsClientInfo clientInfo=new ClsClientInfo();
        SSADBDataContext db;
        

        public frmClientInfo(ClsClientInfo info)
        {
            InitializeComponent();
            clientInfo.ID = info.ID;
            clientInfo.Name = info.Name;
            clientInfo.Phone = info.Phone;
            txtClintID.Text = clientInfo.Name;
            txtPhone.Text = clientInfo.Phone;
            txtBalnace.Text = clientInfo.ClientBalance.ToString();
            txtLastInv.Text = clientInfo.LastInvo.ToString();
        }

        private void frmClientInfo_Load(object sender, EventArgs e)
        {
            Getdata();
        }
        void Getdata()
        {
            gridControl1.DataSource = clientInfo.ClientInvoices;
            gridView1.PopulateColumns();
            gridView1.Columns[nameof(TblInvoiceHeader.ID)].Visible = false;
            gridView1.Columns[nameof(TblInvoiceHeader.invoiceType)].Visible = false;
            gridView1.Columns[nameof(TblInvoiceHeader.code)].Caption = "كود الفاتورة";
            gridView1.Columns[nameof(TblInvoiceHeader.Total)].Caption = "الاجمالي";
            gridView1.Columns[nameof(TblInvoiceHeader.Discount)].Caption = "الخصم";
            gridView1.Columns[nameof(TblInvoiceHeader.net)].Caption = "الصافي";
            gridView1.Columns[nameof(TblInvoiceHeader.Date)].Caption = "التاريخ";
            gridView1.Columns[nameof(CLsProductInvoicesInfo.invoiceTypeName)].Caption = "نوع الفاتورة";
            gridView1.Columns[nameof(CLsProductInvoicesInfo.invoiceTypeName)].VisibleIndex = 3;
            gridView1.Columns[nameof(CLsProductInvoicesInfo.SourceID)].Visible = false;
            gridView1.Columns[nameof(CLsProductInvoicesInfo.Printed)].Visible = false;
            gridView1.Columns[nameof(TblInvoiceHeader.ClientID)].Visible = false;
            gridView1.Columns[nameof(CLsProductInvoicesInfo.ClientID)].Visible = false;
            gridView1.Columns[nameof(CLsProductInvoicesInfo.Saller)].Visible = false;
            gridView1.Columns[nameof(CLsProductInvoicesInfo.Client)].Visible = false;
            gridView1.Columns[nameof(TblInvoiceHeader.Saller)].Visible = false;
            gridView1.Columns[nameof(CLsProductInvoicesInfo._saller)].VisibleIndex = 9;

        }
    }
}