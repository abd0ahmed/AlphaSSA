
namespace AlphaSSA.VIEW
{
    partial class frmAddProduct
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator1 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddProduct));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtBuyPrise = new DevExpress.XtraEditors.TextEdit();
            this.barcodeC = new DevExpress.XtraEditors.BarCodeControl();
            this.txtQty = new DevExpress.XtraEditors.TextEdit();
            this.lkpStore = new DevExpress.XtraEditors.LookUpEdit();
            this.lkpCat = new DevExpress.XtraEditors.LookUpEdit();
            this.txtBarcode = new DevExpress.XtraEditors.TextEdit();
            this.txtPrice = new DevExpress.XtraEditors.TextEdit();
            this.txtProductName = new DevExpress.XtraEditors.TextEdit();
            this.txtID = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBuyPrise.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpStore.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarcode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtBuyPrise);
            this.layoutControl1.Controls.Add(this.barcodeC);
            this.layoutControl1.Controls.Add(this.txtQty);
            this.layoutControl1.Controls.Add(this.lkpStore);
            this.layoutControl1.Controls.Add(this.lkpCat);
            this.layoutControl1.Controls.Add(this.txtBarcode);
            this.layoutControl1.Controls.Add(this.txtPrice);
            this.layoutControl1.Controls.Add(this.txtProductName);
            this.layoutControl1.Controls.Add(this.txtID);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 24);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1060, 109, 650, 400);
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(618, 259);
            this.layoutControl1.TabIndex = 4;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtBuyPrise
            // 
            this.txtBuyPrise.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtBuyPrise.Location = new System.Drawing.Point(12, 60);
            this.txtBuyPrise.Name = "txtBuyPrise";
            this.txtBuyPrise.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtBuyPrise.Properties.MaskSettings.Set("MaskManagerSignature", "allowNull=False");
            this.txtBuyPrise.Properties.MaskSettings.Set("mask", "n2");
            this.txtBuyPrise.Properties.MaskSettings.Set("autoHideDecimalSeparator", true);
            this.txtBuyPrise.Properties.MaskSettings.Set("hideInsignificantZeros", true);
            this.txtBuyPrise.Properties.MaskSettings.Set("valueAfterDelete", DevExpress.Data.Mask.NumericMaskManager.ValueAfterDelete.ZeroThenNull);
            this.txtBuyPrise.Properties.UseMaskAsDisplayFormat = true;
            this.txtBuyPrise.Size = new System.Drawing.Size(227, 20);
            this.txtBuyPrise.StyleController = this.layoutControl1;
            this.txtBuyPrise.TabIndex = 12;
            // 
            // barcodeC
            // 
            this.barcodeC.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barcodeC.Appearance.Options.UseFont = true;
            this.barcodeC.AutoModule = true;
            this.barcodeC.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.barcodeC.HorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.barcodeC.HorizontalTextAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.barcodeC.Location = new System.Drawing.Point(12, 132);
            this.barcodeC.Module = 3D;
            this.barcodeC.Name = "barcodeC";
            this.barcodeC.Padding = new System.Windows.Forms.Padding(10, 2, 10, 0);
            this.barcodeC.Size = new System.Drawing.Size(594, 115);
            this.barcodeC.StyleController = this.layoutControl1;
            this.barcodeC.Symbology = code128Generator1;
            this.barcodeC.TabIndex = 11;
            this.barcodeC.Text = "BTK-0001";
            this.barcodeC.VerticalAlignment = DevExpress.Utils.VertAlignment.Center;
            this.barcodeC.VerticalTextAlignment = DevExpress.Utils.VertAlignment.Center;
            this.barcodeC.Click += new System.EventHandler(this.barcodeC_Click);
            this.barcodeC.DoubleClick += new System.EventHandler(this.barcodeC_DoubleClick);
            // 
            // txtQty
            // 
            this.txtQty.EditValue = "0";
            this.txtQty.Location = new System.Drawing.Point(211, 108);
            this.txtQty.Name = "txtQty";
            this.txtQty.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtQty.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.txtQty.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.txtQty.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtQty.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.txtQty.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtQty.Properties.MaskSettings.Set("mask", "000");
            this.txtQty.Properties.MaskSettings.Set("valueAfterDelete", DevExpress.Data.Mask.NumericMaskManager.ValueAfterDelete.ZeroThenNull);
            this.txtQty.Properties.MaskSettings.Set("hideInsignificantZeros", true);
            this.txtQty.Properties.MaskSettings.Set("autoHideDecimalSeparator", true);
            this.txtQty.Properties.NullText = "0";
            this.txtQty.Properties.UseMaskAsDisplayFormat = true;
            this.txtQty.Size = new System.Drawing.Size(127, 20);
            this.txtQty.StyleController = this.layoutControl1;
            this.txtQty.TabIndex = 10;
            // 
            // lkpStore
            // 
            this.lkpStore.Location = new System.Drawing.Point(12, 108);
            this.lkpStore.Name = "lkpStore";
            this.lkpStore.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpStore.Properties.NullText = "";
            this.lkpStore.Size = new System.Drawing.Size(127, 20);
            this.lkpStore.StyleController = this.layoutControl1;
            this.lkpStore.TabIndex = 9;
            this.lkpStore.EditValueChanged += new System.EventHandler(this.lkpStore_EditValueChanged);
            // 
            // lkpCat
            // 
            this.lkpCat.Location = new System.Drawing.Point(410, 108);
            this.lkpCat.Name = "lkpCat";
            this.lkpCat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpCat.Properties.NullText = "";
            this.lkpCat.Size = new System.Drawing.Size(128, 20);
            this.lkpCat.StyleController = this.layoutControl1;
            this.lkpCat.TabIndex = 8;
            this.lkpCat.EditValueChanged += new System.EventHandler(this.lkpCat_EditValueChanged);
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(12, 84);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(526, 20);
            this.txtBarcode.StyleController = this.layoutControl1;
            this.txtBarcode.TabIndex = 7;
            this.txtBarcode.EditValueChanged += new System.EventHandler(this.txtBarcode_EditValueChanged);
            // 
            // txtPrice
            // 
            this.txtPrice.EditValue = "0";
            this.txtPrice.Location = new System.Drawing.Point(311, 60);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtPrice.Properties.MaskSettings.Set("mask", "n2");
            this.txtPrice.Properties.MaskSettings.Set("autoHideDecimalSeparator", true);
            this.txtPrice.Properties.MaskSettings.Set("hideInsignificantZeros", true);
            this.txtPrice.Properties.MaskSettings.Set("valueAfterDelete", DevExpress.Data.Mask.NumericMaskManager.ValueAfterDelete.ZeroThenNull);
            this.txtPrice.Properties.UseMaskAsDisplayFormat = true;
            this.txtPrice.Size = new System.Drawing.Size(227, 20);
            this.txtPrice.StyleController = this.layoutControl1;
            this.txtPrice.TabIndex = 6;
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(12, 36);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(526, 20);
            this.txtProductName.StyleController = this.layoutControl1;
            this.txtProductName.TabIndex = 5;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(12, 12);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(526, 20);
            this.txtID.StyleController = this.layoutControl1;
            this.txtID.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem9});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(618, 259);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtID;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(598, 24);
            this.layoutControlItem1.Text = "ID";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(56, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtProductName;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(598, 24);
            this.layoutControlItem2.Text = "اسم المنتج";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(56, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtPrice;
            this.layoutControlItem3.Location = new System.Drawing.Point(299, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(299, 24);
            this.layoutControlItem3.Text = "سعر المنتج";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(56, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtBarcode;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(598, 24);
            this.layoutControlItem4.Text = "باركود";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(56, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.lkpCat;
            this.layoutControlItem5.Location = new System.Drawing.Point(398, 96);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(200, 24);
            this.layoutControlItem5.Text = "التصنيف";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(56, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.lkpStore;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(199, 24);
            this.layoutControlItem6.Text = "المخزن";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(56, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtQty;
            this.layoutControlItem7.Location = new System.Drawing.Point(199, 96);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(199, 24);
            this.layoutControlItem7.Text = "رصيد مبدئي";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(56, 13);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.barcodeC;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 120);
            this.layoutControlItem8.MinSize = new System.Drawing.Size(54, 20);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(598, 119);
            this.layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.txtBuyPrise;
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(299, 24);
            this.layoutControlItem9.Text = "سعر شراء";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(56, 13);
            // 
            // frmAddProduct
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 305);
            this.Controls.Add(this.layoutControl1);
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("frmAddProduct.IconOptions.SvgImage")));
            this.Name = "frmAddProduct";
            this.Text = "اضافة منتج";
            this.Load += new System.EventHandler(this.frmAddProduct_Load);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtBuyPrise.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpStore.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarcode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit txtID;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.TextEdit txtQty;
        private DevExpress.XtraEditors.LookUpEdit lkpStore;
        private DevExpress.XtraEditors.LookUpEdit lkpCat;
        private DevExpress.XtraEditors.TextEdit txtBarcode;
        private DevExpress.XtraEditors.TextEdit txtPrice;
        private DevExpress.XtraEditors.TextEdit txtProductName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.BarCodeControl barcodeC;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraEditors.TextEdit txtBuyPrise;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
    }
}