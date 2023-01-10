using System;
using System.Linq;

namespace AlphaSSA.VIEW
{
    public partial class FrmUsersList : FrmMAster
    {
        TblUser User;
        public FrmUsersList()
        {
            InitializeComponent();
        }

        private void FrmUsersList_Load(object sender, EventArgs e)
        {
            show_New();
            show_Edit();
            refreshdata();
            gridView1.Columns[nameof(TblUser.Password)].Visible = false;
        }
        void refreshdata()
        {
            using (var db = new SSADBDataContext())
            {
                gridControl1.DataSource = db.TblUsers.ToList();
            }
        }

        public override void New()
        {
            FrmUsers frm = new FrmUsers();
            frm.ShowDialog();
            refreshdata();

        }
        public override void EDIT()
        {
            FrmUsers frm = new FrmUsers(User);
            frm.ShowDialog();
            refreshdata();
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            User = gridView1.GetFocusedRow() as TblUser;
        }
    }
}