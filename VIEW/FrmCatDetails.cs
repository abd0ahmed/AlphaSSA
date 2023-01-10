using AlphaSSA.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace AlphaSSA.VIEW
{
    public partial class FrmCatDetails : FrmMAster
    {
        SSADBDataContext db;
        List<clsCatDetails> clsCats;
        public FrmCatDetails()
        {
            InitializeComponent();
            RefreshData();
        }
        void RefreshData()
        {

            using (db = new SSADBDataContext())
            {
                clsCats = new List<clsCatDetails>(db.TblCategories.Select(i => new clsCatDetails { ID = i.ID, Name = i.Name, barcode = i.barcode }));
            }
            gridControl1.DataSource = clsCats;
            gridView1.PopulateColumns();

        }
        public override void refresh()
        {
            RefreshData();
            gridInit();
        }
        private void FrmCatDetails_Shown(object sender, EventArgs e)
        {
            gridInit();
        }
        void gridInit()
        {
            gridView1.PopulateColumns();
            gridView1.Columns[nameof(clsCatDetails.ID)].Caption = "م";
            gridView1.Columns[nameof(clsCatDetails.ID)].VisibleIndex = 0;
            gridView1.Columns[nameof(clsCatDetails.Name)].Caption = "اسم الصنف";
            gridView1.Columns[nameof(clsCatDetails.Name)].VisibleIndex = 1;
            
           



        }

        private void FrmCatDetails_Load(object sender, EventArgs e)
        {
           
            show_New();
        }
    }
}