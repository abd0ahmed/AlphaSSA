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
using Guna.UI2.WinForms;

namespace AlphaSSA.VIEW
{
    public partial class FrmLogin : DevExpress.XtraEditors.XtraForm
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

       
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            try
            {
                
                Application.Exit();
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        void Login()
        {
            using (var db = new SSADBDataContext())
            {
                var user = db.TblUsers.SingleOrDefault(x => x.UserName == txtUsername.Text.Trim());
                if (user == null)
                {
                    XtraMessageBox.Show("اسم المستخدم غير صحيح");
                    return;
                }
                else if (user.Password != txtPassword.Text.Trim())
                {
                    XtraMessageBox.Show("كلمة المرور غير صحيحة");
                    return;
                }
                if (user.UserType==(byte)Internal.Master.UserType.Admin)
                {

                    FrmMain frm = new FrmMain();
                    Hide();
                    frm.ShowDialog();

                }
                else if (user.UserType == (byte)Internal.Master.UserType.Casher)
                {
                    frmInvNew frm = new frmInvNew();
                    Hide();
                    frm.ShowDialog();
                }
              
              
                Show();
            }
            txtPassword.Text = "";

        }

    
        private void BTnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void BtnCasher_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void guna2TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData==Keys.Enter||e.KeyData==Keys.Return)
            {
                var se = (Guna2TextBox)sender;
                if (  se.Name== "txtUsername")
                {
                    txtPassword.Focus();
                }
                else if (se.Name=="txtPassword")
                {
                    BTnLogin_Click(BTnLogin, new EventArgs() );
                }
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        private void BtnAbout_Click(object sender, EventArgs e)
        {

        }
    }
}