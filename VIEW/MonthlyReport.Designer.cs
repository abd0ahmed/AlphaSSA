
namespace AlphaSSA.VIEW
{
    partial class MonthlyReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.dtDate = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblFrom = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblto = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.txtPurchaseretInv = new DevExpress.XtraReports.UI.XRTableCell();
            this.txtsellretinv = new DevExpress.XtraReports.UI.XRTableCell();
            this.txtPurchaseinv = new DevExpress.XtraReports.UI.XRTableCell();
            this.txtSellinv = new DevExpress.XtraReports.UI.XRTableCell();
            this.txtDate = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.txtTotalBurchaseRet = new DevExpress.XtraReports.UI.XRTableCell();
            this.txtTotalSellsRet = new DevExpress.XtraReports.UI.XRTableCell();
            this.txtTotalPurchase = new DevExpress.XtraReports.UI.XRTableCell();
            this.txtTotalSells = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblto,
            this.xrLabel3,
            this.lblFrom,
            this.xrLabel2,
            this.xrLabel1,
            this.xrTable1});
            this.TopMargin.HeightF = 138.5417F;
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 53.125F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable3,
            this.xrTable2});
            this.Detail.HeightF = 70.83333F;
            this.Detail.Name = "Detail";
            // 
            // xrTable1
            // 
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 113.5417F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(650F, 25F);
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell3,
            this.xrTableCell4,
            this.dtDate});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell1.Multiline = true;
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.StylePriority.UseFont = false;
            this.xrTableCell1.StylePriority.UseTextAlignment = false;
            this.xrTableCell1.Text = "فواتير مرتجع شراء";
            this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell1.Weight = 1.6167199116894293D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell2.Multiline = true;
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.StylePriority.UseFont = false;
            this.xrTableCell2.StylePriority.UseTextAlignment = false;
            this.xrTableCell2.Text = "فواتير مرتجع بيع";
            this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell2.Weight = 1.5836007013891533D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell3.Multiline = true;
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.StylePriority.UseFont = false;
            this.xrTableCell3.StylePriority.UseTextAlignment = false;
            this.xrTableCell3.Text = "فواتير شراء";
            this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell3.Weight = 1.7601492438357074D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell4.Multiline = true;
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.StylePriority.UseFont = false;
            this.xrTableCell4.StylePriority.UseTextAlignment = false;
            this.xrTableCell4.Text = "فواتير بيع";
            this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell4.Weight = 1.739850658351541D;
            // 
            // dtDate
            // 
            this.dtDate.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDate.Multiline = true;
            this.dtDate.Name = "dtDate";
            this.dtDate.StylePriority.UseFont = false;
            this.dtDate.StylePriority.UseTextAlignment = false;
            this.dtDate.Text = "التاريخ";
            this.dtDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.dtDate.Weight = 1.6330129197927619D;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(286.9166F, 34.375F);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "تقرير فواتير ";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(554.1667F, 74.04167F);
            this.xrLabel2.Multiline = true;
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(95.83331F, 23F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = ":الفترة  من";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lblFrom
            // 
            this.lblFrom.LocationFloat = new DevExpress.Utils.PointFloat(426.0417F, 74.04167F);
            this.lblFrom.Multiline = true;
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.lblFrom.SizeF = new System.Drawing.SizeF(128.125F, 23F);
            this.lblFrom.Text = "lblFrom";
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(386.9166F, 74.04167F);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(39.12506F, 23F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = ":الى";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lblto
            // 
            this.lblto.LocationFloat = new DevExpress.Utils.PointFloat(258.7917F, 74.04169F);
            this.lblto.Multiline = true;
            this.lblto.Name = "lblto";
            this.lblto.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblto.SizeF = new System.Drawing.SizeF(128.125F, 23F);
            this.lblto.Text = "lblFrom";
            // 
            // xrTable2
            // 
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(650F, 25F);
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.txtPurchaseretInv,
            this.txtsellretinv,
            this.txtPurchaseinv,
            this.txtSellinv,
            this.txtDate});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // txtPurchaseretInv
            // 
            this.txtPurchaseretInv.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPurchaseretInv.Multiline = true;
            this.txtPurchaseretInv.Name = "txtPurchaseretInv";
            this.txtPurchaseretInv.StylePriority.UseFont = false;
            this.txtPurchaseretInv.StylePriority.UseTextAlignment = false;
            this.txtPurchaseretInv.Text = "فواتير مرتجع شراء";
            this.txtPurchaseretInv.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.txtPurchaseretInv.Weight = 1.6167199116894293D;
            // 
            // txtsellretinv
            // 
            this.txtsellretinv.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsellretinv.Multiline = true;
            this.txtsellretinv.Name = "txtsellretinv";
            this.txtsellretinv.StylePriority.UseFont = false;
            this.txtsellretinv.StylePriority.UseTextAlignment = false;
            this.txtsellretinv.Text = "فواتير مرتجع بيع";
            this.txtsellretinv.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.txtsellretinv.Weight = 1.5836007013891533D;
            // 
            // txtPurchaseinv
            // 
            this.txtPurchaseinv.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPurchaseinv.Multiline = true;
            this.txtPurchaseinv.Name = "txtPurchaseinv";
            this.txtPurchaseinv.StylePriority.UseFont = false;
            this.txtPurchaseinv.StylePriority.UseTextAlignment = false;
            this.txtPurchaseinv.Text = "فواتير شراء";
            this.txtPurchaseinv.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.txtPurchaseinv.Weight = 1.7601492438357074D;
            // 
            // txtSellinv
            // 
            this.txtSellinv.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSellinv.Multiline = true;
            this.txtSellinv.Name = "txtSellinv";
            this.txtSellinv.StylePriority.UseFont = false;
            this.txtSellinv.StylePriority.UseTextAlignment = false;
            this.txtSellinv.Text = "فواتير بيع";
            this.txtSellinv.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.txtSellinv.Weight = 1.739850658351541D;
            // 
            // txtDate
            // 
            this.txtDate.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDate.Multiline = true;
            this.txtDate.Name = "txtDate";
            this.txtDate.StylePriority.UseFont = false;
            this.txtDate.StylePriority.UseTextAlignment = false;
            this.txtDate.Text = "التاريخ";
            this.txtDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.txtDate.Weight = 1.6330129197927619D;
            // 
            // xrTable3
            // 
            this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 45.83333F);
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
            this.xrTable3.SizeF = new System.Drawing.SizeF(650F, 25F);
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.txtTotalBurchaseRet,
            this.txtTotalSellsRet,
            this.txtTotalPurchase,
            this.txtTotalSells,
            this.xrTableCell5});
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Weight = 1D;
            // 
            // txtTotalBurchaseRet
            // 
            this.txtTotalBurchaseRet.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalBurchaseRet.Multiline = true;
            this.txtTotalBurchaseRet.Name = "txtTotalBurchaseRet";
            this.txtTotalBurchaseRet.StylePriority.UseFont = false;
            this.txtTotalBurchaseRet.StylePriority.UseTextAlignment = false;
            this.txtTotalBurchaseRet.Text = "فواتير مرتجع شراء";
            this.txtTotalBurchaseRet.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.txtTotalBurchaseRet.Weight = 1.6167199116894293D;
            // 
            // txtTotalSellsRet
            // 
            this.txtTotalSellsRet.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalSellsRet.Multiline = true;
            this.txtTotalSellsRet.Name = "txtTotalSellsRet";
            this.txtTotalSellsRet.StylePriority.UseFont = false;
            this.txtTotalSellsRet.StylePriority.UseTextAlignment = false;
            this.txtTotalSellsRet.Text = "فواتير مرتجع بيع";
            this.txtTotalSellsRet.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.txtTotalSellsRet.Weight = 1.6246307862549276D;
            // 
            // txtTotalPurchase
            // 
            this.txtTotalPurchase.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPurchase.Multiline = true;
            this.txtTotalPurchase.Name = "txtTotalPurchase";
            this.txtTotalPurchase.StylePriority.UseFont = false;
            this.txtTotalPurchase.StylePriority.UseTextAlignment = false;
            this.txtTotalPurchase.Text = "فواتير شراء";
            this.txtTotalPurchase.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.txtTotalPurchase.Weight = 1.7827144729239388D;
            // 
            // txtTotalSells
            // 
            this.txtTotalSells.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalSells.Multiline = true;
            this.txtTotalSells.Name = "txtTotalSells";
            this.txtTotalSells.StylePriority.UseFont = false;
            this.txtTotalSells.StylePriority.UseTextAlignment = false;
            this.txtTotalSells.Text = "فواتير بيع";
            this.txtTotalSells.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.txtTotalSells.Weight = 1.7621565306548632D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell5.Multiline = true;
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.StylePriority.UseFont = false;
            this.xrTableCell5.StylePriority.UseTextAlignment = false;
            this.xrTableCell5.Text = "اجمالي";
            this.xrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell5.Weight = 1.653949472094213D;
            // 
            // MonthlyReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail});
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Margins = new System.Drawing.Printing.Margins(100, 100, 139, 53);
            this.Version = "20.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.XRLabel lblto;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel lblFrom;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell3;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell4;
        private DevExpress.XtraReports.UI.XRTableCell dtDate;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRTable xrTable3;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow3;
        private DevExpress.XtraReports.UI.XRTableCell txtTotalBurchaseRet;
        private DevExpress.XtraReports.UI.XRTableCell txtTotalSellsRet;
        private DevExpress.XtraReports.UI.XRTableCell txtTotalPurchase;
        private DevExpress.XtraReports.UI.XRTableCell txtTotalSells;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell5;
        private DevExpress.XtraReports.UI.XRTable xrTable2;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell txtPurchaseretInv;
        private DevExpress.XtraReports.UI.XRTableCell txtsellretinv;
        private DevExpress.XtraReports.UI.XRTableCell txtPurchaseinv;
        private DevExpress.XtraReports.UI.XRTableCell txtSellinv;
        private DevExpress.XtraReports.UI.XRTableCell txtDate;
    }
}
