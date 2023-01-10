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
    public partial class UCDiscount : UserControl
    {
        public decimal Discount { get; set; }
        SSADBDataContext db;
        LabelControl View;
        public UCDiscount(SSADBDataContext db,LabelControl View)
        {
            InitializeComponent();
            this.db = db;
            this.View = View;
            
        }
        public void SetError(string Error)
        {

            textEdit1.ErrorText = Error;

        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            Discount = decimal.Parse(textEdit1.Text);
            View.Text = textEdit1.Text;
        }
        public void clear()
        {

            textEdit1.EditValue = 0;
        }
    }
}
