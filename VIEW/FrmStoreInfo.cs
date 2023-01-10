using AlphaSSA.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AlphaSSA.VIEW
{
    public partial class FrmStoreInfo : FrmMAster
    {
        List<ClsStoreInfo> storeInfos;
        ClsStoreInfo cli;

        public FrmStoreInfo()
        {
            InitializeComponent();
            getdata();
        }
        void getdata()
        {

            using (var db = new SSADBDataContext())
            {

                storeInfos = new List<ClsStoreInfo>(db.tblStores.Select(i => new ClsStoreInfo { ID = i.ID, Name = i.Name }));

            }
            gridControl1.DataSource = storeInfos;
            gridView1.PopulateColumns();


        }

        private void FrmStoreInfo_Shown(object sender, EventArgs e)
        {
            gridView1.Columns[nameof(ClsStoreInfo.ID)].Caption = "م";
            gridView1.Columns[nameof(ClsStoreInfo.ID)].VisibleIndex = 0;
            gridView1.Columns[nameof(ClsStoreInfo.Name)].Caption = "اسم المخزن";
            gridView1.Columns[nameof(ClsStoreInfo.Name)].VisibleIndex = 1;
          //  gridView1.Columns[nameof(ClsStoreInfo.Products)].Visible = false;

        }

        private void FrmStoreInfo_Load(object sender, EventArgs e)
        {
           
            show_New();
           
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            cli = (ClsStoreInfo)gridView1.GetFocusedRow();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            frmStoreDetails frm = new frmStoreDetails(cli.ID);
            frm.ShowDialog();
        }
    }
}
