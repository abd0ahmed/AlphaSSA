using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AlphaSSA.VIEW
{
    public partial class SplashScreen1 : SplashScreen
    {
        
        public SplashScreen1()
        {
            InitializeComponent();
            this.labelCopyright.Text = "Copyright © 2020-" + DateTime.Now.Year.ToString();
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
            
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
           
        }

        #endregion

        public enum SplashScreenCommand
        {
            

        }
    }
}