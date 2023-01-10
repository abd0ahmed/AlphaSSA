using DevExpress.XtraEditors;
using System;
using System.Linq;

namespace AlphaSSA.VIEW
{
    public partial class FrmUsers : FrmMAster
    {
        TblUser user;
        public FrmUsers()
        {
            InitializeComponent();
            New();
        }
        public FrmUsers(TblUser user)
        {
            InitializeComponent();
            this.user = user;
            txtUserName.Text = user.UserName;
        }
        public override void New()
        {
            user = new TblUser();
            txtPassword.Text = "";
            txtUserName.Text = "";
            LkpType.EditValue = 1;
        }

        private void FrmUsers_Load(object sender, EventArgs e)
        {
            show_New();
            show_save();
            LkpType.Properties.DataSource = Internal.Master.UserTypes;
            LkpType.Properties.DisplayMember = "value";
            LkpType.Properties.ValueMember = "ID";

        }
        public override void Save()
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                txtUserName.ErrorText = "يجب كتابة اسم المستخدم";
                return;
            }
            using (var db = new SSADBDataContext())
            {
                if (db.TblUsers.FirstOrDefault(x => x.UserName == txtUserName.Text.Trim() && x.ID != user.ID) != null)
                {
                    txtUserName.ErrorText = "هذا الاسم مستخدم من قبل";
                }
                if (user != null && user.ID > 0)
                {
                    db.TblUsers.Attach(user);
                }
                else
                    db.TblUsers.InsertOnSubmit(user);
                user.UserName = txtUserName.Text.Trim();
                if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    user.Password = txtPassword.Text.Trim();
                }
                user.UserType = Convert.ToByte(LkpType.EditValue);
                db.SubmitChanges();
                XtraMessageBox.Show("تم الحفظ بنجاح");
            }
        }
    }
}