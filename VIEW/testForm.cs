using AlphaSSA.DataProcessors;
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
    public partial class testForm : DevExpress.XtraEditors.XtraForm
    {
        FullProductProcessor fpp;
        public testForm()
        {
            InitializeComponent();
        }

        private void testForm_Load(object sender, EventArgs e)
        {
            using (var db=new SSADBDataContext())
            {
                fpp = new FullProductProcessor(11,db);
                gridControl1.DataSource = fpp.ProductInvoices;
            }
           
        }
    }
}