using System;
using System.Linq;

namespace AlphaSSA.VIEW
{
    public partial class FrmMAster : DevExpress.XtraEditors.XtraForm
    {
        public void show_ret()
        {
            BtnRetreve.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;


        }
        public void show_Edit()
        {

            btnEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

        }
        public void show_Delete()
        {

            BtnDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

        }
        public void show_save()
        {

            BtnSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

        }
        public void show_New()
        {

            BtnNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

        }
        public void show_exPort()
        {

            BtnExport.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

        }
        public FrmMAster()
        {
            InitializeComponent();
        }

        public virtual void Export()
        {

        }
        public virtual void New()
        {

        }
        public virtual void Save()
        {

        }
        public virtual void Delete()
        {

        }
        public virtual void refresh()
        {

        }
        public virtual void EDIT()
        {

        }
        public virtual void Retreve()
        {

        }
        public void Show_Barcode()
        {
            BtnBarcode.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }
        public virtual void printBarcode()
        {

        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            New();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Save();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Delete();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            refresh();
        }
        public static string NextCode(string maxcode)
        {
            if (string.IsNullOrEmpty(maxcode))
            {
                return "1";
            }
            string str1 = "";
            foreach (char c in maxcode)
                str1 = char.IsDigit(c) ? str1 + c : str1;
            if (string.IsNullOrEmpty(str1))
                return maxcode + 1;
            string str2 = str1.Insert(0, "1");
            str2 = (Convert.ToInt32(str2) + 1).ToString();
            string str3 = str2[0] == '1' ? str2.Remove(0, 1) : str2.Remove(0, 1).Insert(0, "1");
            int index = maxcode.LastIndexOf(str1);
            maxcode = maxcode.Remove(index);
            maxcode = maxcode.Insert(index, str3);
            return maxcode;
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EDIT();
        }

        private void BtnRetreve_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Retreve();
        }

        private void FrmMAster_Load(object sender, EventArgs e)
        {

        }

        private void BtnBarcode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            printBarcode();
        }

        private void barButtonItem1_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Export();
        }
    }
}