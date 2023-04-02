using AlphaSSA.Models;
using DevExpress.XtraPrinting.Drawing;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

namespace AlphaSSA.VIEW
{
    public partial class rptbarcode : DevExpress.XtraReports.UI.XtraReport
    {
        public rptbarcode()
        {
            InitializeComponent();
        }
       public void prepairData(List<ClsBarCodeModel> model)
        {
            this.PageWidth = AlphaSSA.Properties.Settings.Default.barcodeWidth;
            DataSource = model;
            xrLabel2.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "Name"));
            xrLabel1.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "Price"));
            xrBarCode1.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "Barcode"));
            getCompanyName();
            this.ShowPreview();
        }
        void getCompanyName()
        {
            using (var db=new SSADBDataContext())
            {
                lblCompanyName.Text = db.TblCompanyInfos.FirstOrDefault().Name;

            }


        }
    }
}
