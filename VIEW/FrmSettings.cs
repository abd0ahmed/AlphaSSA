using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AlphaSSA.VIEW
{
    public partial class FrmSettings : FrmMAster
    { 
        public FrmSettings()
        {
            InitializeComponent();
        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            System.Configuration.Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            show_save();
            using (var db = new SSADBDataContext())
            {
                txtCompanyName.Text = db.TblCompanyInfos.FirstOrDefault().Name;
                lbl1.Text= db.TblCompanyInfos.FirstOrDefault().Phone;
                lbl2.Text = db.TblCompanyInfos.FirstOrDefault().Whatsapp;
                lbl3.Text = db.TblCompanyInfos.FirstOrDefault().Address;
                txtDefaultCat.Properties.DataSource = db.TblCategories;
                txtDefaultClient.Properties.DataSource = db.TblClients;
                txtDefaultStore.Properties.DataSource = db.tblStores;
                lkpDefaultCasher.Properties.DataSource = db.TblSallers;
            }
            txtDefaultCat.Properties.DisplayMember = nameof(TblCategory.Name);
            txtDefaultCat.Properties.ValueMember = nameof(TblCategory.ID);
            txtDefaultClient.Properties.DisplayMember = nameof(TblClient.Name);
            txtDefaultClient.Properties.ValueMember = nameof(TblClient.ID);
            txtDefaultStore.Properties.DisplayMember = nameof(tblStore.Name);
            txtDefaultStore.Properties.ValueMember = nameof(tblStore.ID);
            lkpDefaultCasher.Properties.DisplayMember = nameof(TblSaller.Name);
            lkpDefaultCasher.Properties.ValueMember = nameof(TblSaller.ID);

            txtDefaultCat.EditValue = AlphaSSA.Properties.Settings.Default.DefaultCat;
            txtDefaultClient.EditValue = AlphaSSA.Properties.Settings.Default.DefaultClient;
            txtDefaultStore.EditValue = AlphaSSA.Properties.Settings.Default.DefaultStore;
            lkpDefaultCasher.EditValue = AlphaSSA.Properties.Settings.Default.DefaultCahser;
            txtWidth.Text = AlphaSSA.Properties.Settings.Default.Width.ToString();
            txtBarcodWidth.Text= AlphaSSA.Properties.Settings.Default.barcodeWidth.ToString();
            txtBarcodHight.Text = AlphaSSA.Properties.Settings.Default.barcodeHight.ToString();
        }
        public override void Save()
        {
            System.Configuration.Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            using (var db = new SSADBDataContext())
            {
                TblCompanyInfo info = db.TblCompanyInfos.FirstOrDefault();
                info.Name = txtCompanyName.Text;
                info.Phone = lbl1.Text;
                info.Whatsapp = lbl2.Text;
                info.Address = lbl3.Text;
                db.SubmitChanges();
            }
            AlphaSSA.Properties.Settings.Default.DefaultCat = (int)txtDefaultCat.EditValue;
            AlphaSSA.Properties.Settings.Default.DefaultClient = (int)txtDefaultClient.EditValue;
            AlphaSSA.Properties.Settings.Default.DefaultStore = (int)txtDefaultStore.EditValue;
            AlphaSSA.Properties.Settings.Default.DefaultCahser = (int)lkpDefaultCasher.EditValue;
            AlphaSSA.Properties.Settings.Default.Width = double.Parse(txtWidth.Text);
            AlphaSSA.Properties.Settings.Default.barcodeHight = int.Parse(txtBarcodHight.Text);
            AlphaSSA.Properties.Settings.Default.barcodeWidth = int.Parse(txtBarcodWidth.Text);
        }
    }
}