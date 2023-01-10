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

namespace AlphaSSA.VIEW
{
    public partial class FrmProductsReport : DevExpress.XtraEditors.XtraForm
    {
        List<Models.clsProductsReportModel> datas;
        public FrmProductsReport() { InitializeComponent(); }

        void GetData()

        {
            if(datas == null)
            {
                using(var data = new SSADBDataContext())
                {
                    var d =
                            from pr in data.TblProducts
                        select new Models.clsProductsReportModel
                        {
                            ProductID = pr.ID,
                            Barcode = pr.barcode,
                            Name = pr.Name,
                            BuyPrice = pr.BuyPrise,
                            sellPrice = pr.price,
                        };
                    datas = d.ToList();
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            GetData();

            gridControl1.DataSource = datas.OrderByDescending(x => x.SellCount).ToList();
            gridView1.Columns[nameof(Models.clsProductsReportModel.ProductID)].Visible = false;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            GetData();
            gridControl1.DataSource = datas.OrderBy(x => x.SellCount).ToList();
            gridView1.Columns[nameof(Models.clsProductsReportModel.ProductID)].Visible = false;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            Models.clsProductDetails prd = new Models.clsProductDetails();
            var p = (Models.clsProductsReportModel)gridView1.GetFocusedRow();
            prd.ID = p.ProductID;
            prd.Name = p.Name;
            prd.barcode = p.Barcode;
            prd.BuyPrise = p.BuyPrice;
            prd.price = p.sellPrice;
            FrmProductDetails frm = new FrmProductDetails(prd);
            frm.ShowDialog();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            using(var file = new FolderBrowserDialog())
            {
                DialogResult dr = file.ShowDialog();
                if(dr == DialogResult.OK && !string.IsNullOrWhiteSpace(file.SelectedPath))
                {
                    string files = file.SelectedPath;

                    gridControl1.ExportToXls(files + @"\ProductReport.xls");

                    XtraMessageBox.Show("تم");
                }
            }
        }
    }
}