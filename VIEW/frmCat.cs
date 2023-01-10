using DevExpress.XtraEditors;
using System;
using System.Linq;

namespace AlphaSSA.VIEW
{
    public partial class frmCat : FrmMAster
    {
        TblCategory cat;
        SSADBDataContext db;
        public frmCat()
        {
            InitializeComponent();
            refreshData();
            New();
        }
        public override void New()
        {
            NewINS();
            clear();
        }
        void NewINS()
        {

            cat = new TblCategory();
        }
        void clear()
        {
            txtID.Text = "";
            txtBarcode.Text = "";
            txtName.Text = "";
        }
        bool validateData()
        {
            bool v = true;
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                txtName.ErrorText = "لا يمكن ترك الاسم فارغ";
                v = false;
            }
            if (db.TblCategories.FirstOrDefault(x => x.Name == txtName.Text.Trim()) != null)
            {
                txtName.ErrorText = "هذا الاسم موجود من قبل";
                v = false;
            }
            if (string.IsNullOrWhiteSpace(txtBarcode.Text))
            {
                txtBarcode.ErrorText = "لا يمكن ترك الكود فارغ";
                v = false;
            }
            if (db.TblCategories.FirstOrDefault(x => x.barcode == txtBarcode.Text.Trim()) != null)
            {
                txtBarcode.ErrorText = "هذا الكود موجود من قبل";
                v = false;
            }

            return v;
        }
        void refreshData()
        {
            using (db = new SSADBDataContext())
            {
                gridControl1.DataSource = db.TblCategories.ToList();
            }
        }
        public override void Save()
        {
            using (db = new SSADBDataContext())
            {
                if (!validateData())
                {
                    return;
                }
                cat.Name = txtName.Text.Trim();
                cat.barcode = txtBarcode.Text.Trim();
                db.TblCategories.InsertOnSubmit(cat);
                db.SubmitChanges();
                XtraMessageBox.Show("تم الحفظ بنجاح");
                New();
                refreshData();

            }
        }

        private void frmCat_Load(object sender, EventArgs e)
        {
            show_save();
            show_New();
        }
    }
}