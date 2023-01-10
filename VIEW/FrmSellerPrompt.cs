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
    public partial class FrmSellerPrompt : DevExpress.XtraEditors.XtraForm
    {
        decimal dd=0;
        UCInvSeller uc;
        bool co;
        public FrmSellerPrompt(UCInvSeller uc )
        {
            InitializeComponent();
            this.uc = uc;
            

        }

        private void BtnFastSave_Click(object sender, EventArgs e)
        {
            uc.SetClientID((int.Parse(txtID.Text.Trim())),co);
            this.Dispose();
        }

        private void txtPaied_EditValueChanged(object sender, EventArgs e)
        {
           
            
        }

        private void txtPaied_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData==Keys.Enter||e.KeyData==Keys.Return)
            {
                btnClose.PerformClick();
            }
        }
    }
}