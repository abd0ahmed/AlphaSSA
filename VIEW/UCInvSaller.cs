using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
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
    public partial class UCInvSeller : UserControl
    {
        SSADBDataContext db;
        public TblSaller Seller { get; set; }
        public UCInvSeller(SSADBDataContext db)
        {
            InitializeComponent();
            Seller = new TblSaller();
            this.db = db;
        }
        
        public void SetError(string Error)
        {

            textEdit1.ErrorText = Error;

        }
        public void GetData(List<TblSaller> sellers)
        {
            textEdit1.Properties.DataSource = sellers;
            textEdit1.Properties.DisplayMember = nameof(TblSaller.Name);
            textEdit1.Properties.ValueMember = nameof(TblSaller.ID);

        }
        public void SetClientID(int? id)
        {
            using (db = new SSADBDataContext())
            {
                Seller = db.TblSallers.SingleOrDefault(x => x.ID == id);
                if (Seller != null && Seller.Name != string.Empty)
                {
                    textEdit1.EditValue = Seller.ID;

                }
                else SetError("كود غير موجود");

            }

        }
        public void SetClientID(int? id, bool co)
        {
            using (db = new SSADBDataContext())
            {
                Seller = db.TblSallers.SingleOrDefault(x => x.ID == id);
                if (Seller != null && Seller.Name != string.Empty)
                {
                    textEdit1.EditValue = Seller.ID;
                    co = true;

                }
                else { SetError("كود غير موجود"); co = false; }
               
                  

            }
        }
        public int? GetClientID()
        {
            return (int?)textEdit1.EditValue;


        }
        public void Setsaller(int ID)
        {
            SetClientID(ID);

        }
        private void textEdit1_ProcessNewValue(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            using (db = new SSADBDataContext())
            {
                TblSaller tbl = new TblSaller();
                tbl.Name = textEdit1.Text.Trim();

                db.TblSallers.InsertOnSubmit(tbl);
                db.SubmitChanges();
                if (tbl.ID > 0)
                {
                    ((List<TblSaller>)textEdit1.Properties.DataSource).Add(tbl);
                    textEdit1.EditValue = tbl.ID;
                    Seller = tbl;
                    XtraMessageBox.Show("تم اضافة العميل");
                }
                
                else
                {
                    XtraMessageBox.Show("حدث خطأ");
                }

            }
        }

        private void textEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if ((string)e.Button.Tag=="Edit" )
            {
                FrmSaller frm = new FrmSaller();
                frm.ShowDialog();
            }
        }
    }
}
