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
    public partial class frmStoreDetails : DevExpress.XtraEditors.XtraForm
    {
        int StoreId;
        public frmStoreDetails()
        {
            InitializeComponent();
        }
        public frmStoreDetails(int id)
        {
            StoreId = id;
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            using (var db=new SSADBDataContext())
            {

                List< Models.ClsStoreDetailsVM > da = (from sp in db.TblStoreProducts
                                           join p in db.TblProducts on sp.productID equals p.ID
                                           where sp.StoreID == StoreId
                                           select new Models.ClsStoreDetailsVM()
                                           {
                                               id = p.ID
                                           ,
                                               Name = p.Name
                                           ,
                                               BuyPrice = p.BuyPrise ?? 0
                                           ,
                                               SellPrice = p.price ?? 0
                                           ,
                                               Qty = sp.Qty ?? 0

                                           }).ToList();

                gridControl1.DataSource = da;
                txtID.Text = StoreId.ToString();
                txtName.Text = db.tblStores.SingleOrDefault(x => x.ID == StoreId).Name;
                txtProBuySum . Text = da.Sum(x => x.TotalBuy).ToString();
                txtProSellSum.Text = da.Sum(x => x.TotalSell).ToString();
                txtProQySum.Text = da.Sum(x => x.Qty).ToString();
                txtProCount.Text = da.Count.ToString();
                


            }

        }

        private void frmStoreDetails_Load(object sender, EventArgs e)
        {
            gridView1.Columns[nameof(Models.ClsStoreDetailsVM.TotalBuy)].Visible = false;
            gridView1.Columns[nameof(Models.ClsStoreDetailsVM.TotalSell)].Visible = false;
            gridView1.Columns[nameof(Models.ClsStoreDetailsVM.id)].Visible = false;
            gridView1.Columns[nameof(Models.ClsStoreDetailsVM.Name)].VisibleIndex = 0;


        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            using (var file = new FolderBrowserDialog())
            {
                DialogResult dr = file.ShowDialog();
                if (dr == DialogResult.OK && !string.IsNullOrWhiteSpace(file.SelectedPath))
                {
                    string files = file.SelectedPath;

                    gridControl1.ExportToXls(files + @"\StoreReport.xls");

                    XtraMessageBox.Show("تم");
                }
            }
        }
    }
}