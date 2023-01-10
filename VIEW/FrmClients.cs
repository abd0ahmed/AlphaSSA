using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace AlphaSSA.VIEW
{
    public partial class FrmClients : FrmMAster
    {
        TblClient client;
        SSADBDataContext db;
        private BindingList<TblClient> clients;

        public FrmClients() 
        {
            InitializeComponent();
            New();
        }

        public FrmClients(BindingList<TblClient> clients)
        {
            InitializeComponent();
            New();
            this.clients = clients;
        }

        void clear()
        {
            txtID.Text = string.Empty;
            txtName.Text = string.Empty;
            txtPhone.Text = string.Empty;
        }

        private void FrmClients_Load(object sender, EventArgs e)
        {
            show_save();
            show_New();
        }

        bool ValidateData()
        {
            bool v = true;
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                txtName.ErrorText = "لايمكن ترك الحقل فارغا";
                v = false;
            }
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                txtPhone.ErrorText = "لايمكن ترك الحقل فارغا";
                v = false;
            }
            //if (db.TblClients.FirstOrDefault(x => x.Name == txtName.Text.Trim()) != null)
            //{
            //    txtName.ErrorText = "هذا الاسم مسجل من فبل";
            //    v = false;
            //}
            if (db.TblClients.FirstOrDefault(x => x.Phone == txtPhone.Text.Trim()) != null)
            {
                txtPhone.ErrorText = "هذا الرقم مسجل من قبل";
                v = false;
            }

            return v;
        }
        public override void Save()
        {
            using (db=new SSADBDataContext())
            {
                if (!ValidateData())
                {
                    return;
                }
                db.TblClients.InsertOnSubmit(client);
                client.Name = txtName.Text.Trim();
                client.Phone = txtPhone.Text.Trim();
                db.SubmitChanges();
                txtID.Text = client.ID.ToString();
                XtraMessageBox.Show("تم الحفظ بنجاح");
                
                if (clients!=null)
                {
                    clients.Add(client);
                    this.Close();
                }
                New();
            }
        }

        public override void New()
        {
            client = new TblClient();
            clear();
        }
    }
}