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
    public partial class UCinvStore : UserControl
    {
        SSADBDataContext db;
        public tblStore Store { get; set; }
        public UCinvStore(SSADBDataContext db)
        {
            InitializeComponent();
            Store = new tblStore();
            this.db = db;
        }
        public void SetError(string Error)
        {

            textEdit1.ErrorText = Error;

        }
        public void GetData(List<tblStore> Stores)
        {
            textEdit1.Properties.DataSource = Stores;
            textEdit1.Properties.DisplayMember = nameof(tblStore.Name);
            textEdit1.Properties.ValueMember = nameof(tblStore.ID);

        }
        public void SetClientID(int? id)
        {
            using (db = new SSADBDataContext())
            {
                Store = db.tblStores.SingleOrDefault(x => x.ID == id);
                if (Store != null && Store.Name != string.Empty)
                {
                    textEdit1.EditValue = Store.ID;

                }

            }

        }
        public int? GetClientID()
        {
            return (int?)textEdit1.EditValue;


        }
    }
}
