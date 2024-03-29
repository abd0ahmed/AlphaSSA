﻿using AlphaSSA.Models;
using DevExpress.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

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
                clsCats = (from cd in db.TblCategories
                           select new clsCatDetails(cd)).ToList();
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
            
            gridView1.RowCellClick += GridView1_RowCellClick;
        }
        void gridInit()
        {
            gridView1.PopulateColumns();
            gridView1.Columns[nameof(clsCatDetails.ID)].Caption = "م";
            gridView1.Columns[nameof(clsCatDetails.ID)].VisibleIndex = 0;
            gridView1.Columns[nameof(clsCatDetails.Name)].Caption = "اسم الصنف";
            gridView1.Columns[nameof(clsCatDetails.Name)].VisibleIndex = 1;
            gridView1.Columns[nameof(clsCatDetails.ID)].Visible = false;
           
            
            



        }

   
        private void GridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            
        }

        private void FrmCatDetails_Load(object sender, EventArgs e)
        {
           
            show_New();
            
        }
    }
}