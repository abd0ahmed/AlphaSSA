using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace AlphaSSA
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Assembly asm = typeof(DevExpress.UserSkins.SkinProject1).Assembly;
            DevExpress.Skins.SkinManager.Default.RegisterAssembly(asm);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new VIEW.FrmLogin());
        }
    }
}
