using System;
using System.Linq;

namespace AlphaSSA.VIEW
{
    public partial class FrmMain : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        private void accordionControlElement2_Click(object sender, EventArgs e)
        {
            FrmStores frm = new FrmStores();
            frm.ShowDialog();
        }

        private void accordionControlElement3_Click(object sender, EventArgs e)
        {
            FrmStoreInfo frm = new FrmStoreInfo();
            frm.ShowDialog();
        }

        private void accordionControlElement6_Click(object sender, EventArgs e)
        {
            frmCat frm = new frmCat();
            frm.ShowDialog();
        }

        private void accordionControlElement7_Click(object sender, EventArgs e)
        {
            FrmCatDetails frm = new FrmCatDetails();
            frm.ShowDialog();
        }

        private void accordionControlElement9_Click(object sender, EventArgs e)
        {
            frmAddProduct frm = new frmAddProduct();
            frm.ShowDialog();
        }

        private void accordionControlElement10_Click(object sender, EventArgs e)
        {
            FrmProductsList frm = new FrmProductsList();
            frm.ShowDialog();
        }

        private void accordionControlElement11_Click(object sender, EventArgs e)
        {
            FrmClients frm = new FrmClients();
            frm.ShowDialog();

        }

        private void accordionControlElement12_Click(object sender, EventArgs e)
        {
            FrmClientsList frm = new FrmClientsList();
            frm.ShowDialog();
        }

        private void accordionControlElement13_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement14_Click(object sender, EventArgs e)
        {
            frmInvNew frm = new frmInvNew(Internal.Master.InvoiceType.Sales);
            frm.Show();
        }

        private void accordionControlElement15_Click(object sender, EventArgs e)
        {
            frmInvNew frm = new frmInvNew(Internal.Master.InvoiceType.Purchase);
            frm.Show();
        }

        private void accordionControlElement17_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement18_Click(object sender, EventArgs e)
        {
            FrmSettings frm = new FrmSettings();
            frm.ShowDialog();
        }

        private void accordionControlElement16_Click(object sender, EventArgs e)
        {
            frmInvoiceList frm = new frmInvoiceList();
            frm.ShowDialog();
        }

        private void accordionControlElement19_Click(object sender, EventArgs e)
        {
            FrmUsersList frm = new FrmUsersList();
            frm.ShowDialog();
        }

        private void accordionControlElement20_Click(object sender, EventArgs e)
        {
            FrmReturn frm = new FrmReturn(Internal.Master.InvoiceType.Sales);
            frm.ShowDialog();
        }

        private void accordionControlElement21_Click(object sender, EventArgs e)
        {
            FrmReturn frm = new FrmReturn(Internal.Master.InvoiceType.Purchase);
            frm.ShowDialog();
        }

        private void accordionControlElement22_Click(object sender, EventArgs e)
        {
            FrmBarcode frm = new FrmBarcode();
            frm.ShowDialog();
        }

        private void accordionControlElement23_Click_1(object sender, EventArgs e)
        {
            FrmSaller frm = new FrmSaller();
            frm.ShowDialog();
        }

        private void accordionControlElement24_Click(object sender, EventArgs e)
        {
            FrmInvReprot frm = new FrmInvReprot();
                frm.Show();
        }

        private void accordionControlElement25_Click(object sender, EventArgs e)
        {
            FrmProductsReport frm = new FrmProductsReport();
            frm.Show();
        }
    }
}
