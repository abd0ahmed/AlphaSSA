using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AlphaSSA.VIEW
{
    public partial class FrmSaller : FrmMAster
    {
        TblSaller saller;
        public FrmSaller()
        {
            InitializeComponent();
            show_save();
            show_New();
            show_Edit();
            show_Delete();

        }
        void LoadData()
        {
            using (var db = new SSADBDataContext())
            {

                gridControl1.DataSource = db.TblSallers.ToList();


            }



        }
        public override void New()
        {
            textEdit1.Text = "";
            saller = new TblSaller();
            base.New();
        }

        private void FrmSaller_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void gridView1_Click(object sender, EventArgs e)
        {

        }
        public override void Save()
        {
            using (var db = new SSADBDataContext())
            {
                if (!string.IsNullOrWhiteSpace(textEdit1.Text))
                {
                    if (db.TblSallers.SingleOrDefault(x => x.Name == textEdit1.Text.Trim()) != null)
                    {
                        textEdit1.ErrorText = "هذا الاسم موجود من قبل";
                        return;
                    }
                    if (saller.ID > 0)
                    {
                        db.TblSallers.Attach(saller);

                    }
                    else
                    {
                        db.TblSallers.InsertOnSubmit(saller);
                    }

                    saller.Name = textEdit1.Text.Trim();

                    db.SubmitChanges();
                    LoadData();
                    XtraMessageBox.Show("تم حفظ بائع كود : " + saller.ID);
                }
                else
                {
                    textEdit1.ErrorText = "لا يمكن ترك الاسم فارغا";
                }

            }
            base.Save();
        }
        public override void EDIT()
        {
            saller = (TblSaller)gridView1.GetFocusedRow();
            textEdit1.Text = saller.Name;
        }
        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {

        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            textEdit1.ErrorText = "";
        }
        public override void Delete()
        {
            if (XtraMessageBox.Show("هل انت متأكد من حذف البائع", "تنبيه", buttons: MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                saller = (TblSaller)gridView1.GetFocusedRow();
                using (var db = new SSADBDataContext())
                {
                    if (db.TblInvoiceHeaders.Where(x => x.Saller == saller.ID).Count() > 0)
                    {
                        XtraMessageBox.Show(" لا يمكن حذف كود مسجل بالفواتير ");
                        return;
                    }
                    db.TblSallers.Attach(saller);
                    db.TblSallers.DeleteOnSubmit(saller);
                    db.SubmitChanges();
                }
                LoadData();
            }

        }
        public override void refresh()
        {
            LoadData();
            base.refresh();
        }
    }
}