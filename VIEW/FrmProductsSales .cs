using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Popup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlphaSSA.VIEW
{
    public partial class FrmProductsSales: DevExpress.XtraEditors.XtraForm
    {
   
        SSADBDataContext db;
        public FrmProductsSales()
        {
            InitializeComponent();
            LoadData();
        }
        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        void LoadData()
        {
            using (db = new SSADBDataContext())
            {
                gridControl1.DataSource = db.TblProducts.OrderByDescending(x => x.price);
            }

        }
        void getdata()
        {
            using (db=new SSADBDataContext())
            {
                gridControl1.DataSource = db.TblProducts.OrderByDescending(x => x.price);
            }
            //List<TblInvoiceHeader> h = (List<TblInvoiceHeader>)gridControl1.DataSource;
            //lblTotalSalles.Text = h.Where(x=>x.invoiceType==(byte)Internal.Master.InvoiceType.Sales).Sum(x => x.Total).ToString();
            //lblTotalReturns.Text = h.Where(x => x.invoiceType == (byte)Internal.Master.InvoiceType.salesReturn).Sum(x => x.Total).ToString();
            //lblNet.Text = (decimal.Parse(lblTotalSalles.Text) - decimal.Parse(lblTotalReturns.Text)).ToString();
        }
        private void frmDailyReprort_Load(object sender, EventArgs e)
        {
            LoadData();
            
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            getdata();
        }

    }

    
    }