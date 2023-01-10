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
using AlphaSSA.Models;


namespace AlphaSSA.VIEW
{
    public partial class FrmClientsList : FrmMAster
    {
        SSADBDataContext db;
        ClsClientInfo clientInfo;
        List<ClsClientInfo> ClientInfos;
        public FrmClientsList()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            using (db=new SSADBDataContext())
            {
                ClientInfos = (from c in db.TblClients
                               select new ClsClientInfo
                               {
                                   ID = c.ID,
                                   Name = c.Name,
                                   Phone = c.Phone
                               }).ToList();

            }
            
            
        }
        private void FrmClientsList_Load(object sender, EventArgs e)
        {
            LoadData();
            gridControl1.DataSource = ClientInfos;
            gridView1.Columns[nameof(ClsClientInfo.ID)].Visible = false;
            gridView1.Columns[nameof(ClsClientInfo.Name)].Caption = "اسم العميل";
            gridView1.Columns[nameof(ClsClientInfo.Phone )].Caption = "رقم التبليفون";
            gridView1.Columns[nameof(ClsClientInfo.ClientBalance)].Caption = "رصيد";
            gridView1.Columns[nameof(ClsClientInfo.InvCount)].Caption = "عدد مرات الشراء";
            gridView1.Columns[nameof(ClsClientInfo.LastInvo)].Caption = "اخر فاتورة";
            gridControl1.ShowOnlyPredefinedDetails = true;
           
            show_New();
            show_exPort();

        }
        public override void Export()
        {
            using (var file = new FolderBrowserDialog())
            {
                DialogResult dr = file.ShowDialog();
                if (dr == DialogResult.OK && !string.IsNullOrWhiteSpace(file.SelectedPath))
                {
                    string files = file.SelectedPath;

                    gridControl1.ExportToXls(files + @"\ClientsList.xls");

                    XtraMessageBox.Show("تم");
                }
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            clientInfo =(ClsClientInfo) gridView1.GetFocusedRow();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            frmClientInfo frm = new frmClientInfo(clientInfo);
            frm.ShowDialog();
        }
    }
}