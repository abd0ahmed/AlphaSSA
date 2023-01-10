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
    public partial class FrmStores : FrmMAster
    {
        SSADBDataContext db;
        tblStore Store;
        BindingList<tblStore> Stores;
        public FrmStores()
        {
            InitializeComponent();
        }
        void getDAta()
        {
            using (db=new SSADBDataContext())
            {
                Stores = new BindingList<tblStore>(db.tblStores.ToList());
            }
            RefreshData();

        }
        void RefreshData()
        {

            gridControl1.DataSource = Stores;
            gridControl1.Refresh();

        }

        private void FrmStores_Load(object sender, EventArgs e)
        {
            New();
            getDAta();
            show_save();
            show_New();
        }
        void clear()
        {
            txtID.Text = "";
            txtNAme .Text= "";
            Store = null;
        }
        public override void New()
        {
            if (txtNAme.Text.Count()>0)
            {
                if (XtraMessageBox.Show("هل تريد تجاهل التغيرات الحالية؟؟؟","تحذير",buttons:MessageBoxButtons.YesNo,icon:MessageBoxIcon.Warning)==DialogResult.No)
                {
                    return;
                }
                else
                {
                    clear();
                    Store = new tblStore();
                }
            }
            else
            {
                clear();
                Store = new tblStore();
            }
           

        }
        public override void Save()
        {
            var getDub = Stores.FirstOrDefault(x => x.Name == txtNAme.Text.Trim());
            if (!(getDub==null))
            {
                txtNAme.ErrorText = "هذا الاسم موجود من قبل";
            }
            else
            {
                Store.Name = txtNAme.Text.Trim();
                using (db=new SSADBDataContext())
                {
                    db.tblStores.InsertOnSubmit(Store);
                    db.SubmitChanges();
                    txtID.Text = Store.ID.ToString();
                   
                    
                }
               
              
                XtraMessageBox.Show("تم الحفظ بنجاح");
                getDAta();
                clear();
                Store = new tblStore();
            }
            base.Save();
        }
        public override void refresh()
        {
            gridControl1.Refresh();
            gridView1.RefreshData();
        }
        private void txtNAme_EditValueChanged(object sender, EventArgs e)
        {
            txtNAme.ErrorText = "";
        }
    }
}