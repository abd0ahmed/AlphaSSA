using AlphaSSA.Models;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlphaSSA.VIEW
{
    public partial class FrmBarcode : DevExpress.XtraEditors.XtraForm
    {
        List<ClsBarCodeModel> Models;
        public FrmBarcode()
        {
            InitializeComponent();
        }
        public FrmBarcode(ClsBarCodeModel model)
        {
            InitializeComponent();
            getdata(model);
        }
        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            barCodeControl1.Text = txtBarcode.Text;
        }

        private void FrmBarcode_Load(object sender, EventArgs e)
        {
           
        }
        void generateData()
        {
            Models = new List<ClsBarCodeModel>();
            for (int i = 0; i <int.Parse( txtCopies.Text); i++)
            {
                Models.Add(new ClsBarCodeModel() { Name = txtName.Text, Barcode = txtBarcode.Text, Price = decimal.Parse(txtPrice.Text) });
            }

        }
        void getdata(ClsBarCodeModel model)
        {
            txtBarcode.Text = model.Barcode;
            txtName.Text = model.Name;
            txtPrice.Text = model.Price.ToString();


        }
        private void BtnPrint_Click(object sender, EventArgs e)
        {
            generateData();
            rptbarcode rpt = new rptbarcode();
            rpt.prepairData(Models);
        }
    }
}