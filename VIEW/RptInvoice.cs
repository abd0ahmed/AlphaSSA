using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using AlphaSSA.Internal;
using System.Linq;
using AlphaSSA.Models;

namespace AlphaSSA.VIEW
{
    public partial class RptInvoice : DevExpress.XtraReports.UI.XtraReport
    {
        TblInvoiceHeader Header;
        
        bool FastPrint;
        public RptInvoice()
        {
            InitializeComponent();
        }
        void getInfo()
        {
            using (var db=new SSADBDataContext())
            {
                lblCompanyName.Text = db.TblCompanyInfos.FirstOrDefault().Name;
                lbl1.Text = db.TblCompanyInfos.FirstOrDefault().Phone;
                lbl2.Text = db.TblCompanyInfos.FirstOrDefault().Whatsapp;
                lbl3.Text = db.TblCompanyInfos.FirstOrDefault().Address;
            }
            this.PageWidth = Convert.ToInt32( AlphaSSA.Properties.Settings.Default.Width);
           
        }
        public void PrePareData(object ds1,object ds2,object ds3,bool fastPrint=false)
        
        {
            //this.DataSource = ds1;
            Header = (TblInvoiceHeader)ds2;
            getInfo();
            lblDate.Text =((DateTime) Header.Date).ToString("dd:MM:yyyy");
            lblTime.Text = DateTime.Today.Add(Header.Time??TimeSpan.Parse("00:00:00:00")).ToString(" hh "+" :"+" mm"+" tt" );
            lblInvoiceType.Text = Master.InvoiceTypes.SingleOrDefault(x => x.ID == ((int)Header.invoiceType)).value;
            txtCode.Text = Header.code;
            txtDiscount.Text = Header.Discount.ToString();
            txtNet.Text = Header.net.ToString();
            txtSubTotal.Text = Header.Total.ToString();
            cellID.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "index"));
            CellName.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "ItemName"));
            CellQty.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "qty"));
            CellPrice.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "Price"));
            CellTotal.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "totalPrice"));

            Print(fastPrint);


        }
        public void Print(bool fast)
        {
            if (fast)
            {
                this.Print();
                return;
            }
            this.ShowPreviewDialog();


        }

    }
}
