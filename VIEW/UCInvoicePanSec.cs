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
    public partial class UCInvoicePanSec : UserControl
    {
        SSADBDataContext db;
       public TblClient Client { get; set; }
        public UCInvoicePanSec(SSADBDataContext db)
        {
            InitializeComponent();
            Client = new TblClient();
            this.db = db;
        }

        private void UCInvoicePanSec_Load(object sender, EventArgs e)
        {
            textEdit1.Properties.Buttons[1].Click += UCInvoicePanSec_Click;


        }
        public void SetError(string Error)
        {

            textEdit1.ErrorText = Error;

        }
        public void GetData(BindingList<TblClient> Clinets)
        {
            textEdit1.Properties.DataSource = Clinets;
            textEdit1.Properties.DisplayMember = nameof(TblClient.Name);
            textEdit1.Properties.ValueMember = nameof(TblClient.ID);
            textEdit1.Properties.PopulateViewColumns();

        }
        private void UCInvoicePanSec_Click(object sender, EventArgs e)
        {


            var Clients = (BindingList<TblClient>)textEdit1.Properties.DataSource;
            FrmClients frm = new FrmClients(Clients);
            frm.ShowDialog();
            textEdit1.EditValue = Clients.LastOrDefault().ID;
            XtraMessageBox.Show("تم اضافة العميل");
            


        }
        public void SetClientID(int? id)
        {
            using (db=new SSADBDataContext())
            {
                Client = db.TblClients.SingleOrDefault(x => x.ID == id);
                if (Client!=null&&Client.Name!=string.Empty)
                {

                    textEdit1.EditValue = Client.ID;
                    textEdit2.Text = Client.Phone;
                }

            }
        
        }
        public int? GetClientID()
        {
            return (int?)textEdit1.EditValue;


        }
        void saveNEwClient()
        {
            var Clients =(BindingList<TblClient>) textEdit1.Properties.DataSource;
            FrmClients frm = new FrmClients(Clients);
            frm.ShowDialog();
            textEdit1.EditValue = Clients.Max(x => x.ID);
            XtraMessageBox.Show("تم اضافة العميل");

            


        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (textEdit1.EditValue!=null&& (int)textEdit1.EditValue > 0)
            {
                Client = ((BindingList<TblClient>)textEdit1.Properties.DataSource).Single(x => x.ID == int.Parse(textEdit1.EditValue.ToString()));
                textEdit2.Text = Client.Phone;
            }
           
        }

        private void textEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            
        }
    }
}
