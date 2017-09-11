namespace InventoryView
{
    partial class frmItemSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmItemSearch));
            this.lblHeader = new System.Windows.Forms.Label();
            this.ckbAllItems = new System.Windows.Forms.CheckBox();
            this.lblItemId = new System.Windows.Forms.Label();
            this.cmbDealers = new System.Windows.Forms.ComboBox();
            this.lblDealer = new System.Windows.Forms.Label();
            this.cmbCategories = new System.Windows.Forms.ComboBox();
            this.cmbBrands = new System.Windows.Forms.ComboBox();
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.dtpBuyFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblBuyFromDate = new System.Windows.Forms.Label();
            this.dtpBuyToDate = new System.Windows.Forms.DateTimePicker();
            this.lblBuyToDate = new System.Windows.Forms.Label();
            this.dtpSellToDate = new System.Windows.Forms.DateTimePicker();
            this.lblSellToDate = new System.Windows.Forms.Label();
            this.dtpSellFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblSellFromDate = new System.Windows.Forms.Label();
            this.lblBuyFromPrice = new System.Windows.Forms.Label();
            this.lblBuyToPrice = new System.Windows.Forms.Label();
            this.lblSellToPrice = new System.Windows.Forms.Label();
            this.lblSellFromPrice = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtBuyFromPrice = new InventoryView.Controls.DecimalTextBox();
            this.txtItemId = new InventoryView.Controls.NumericTextBox();
            this.txtSellToPrice = new InventoryView.Controls.DecimalTextBox();
            this.txtSellFromPrice = new InventoryView.Controls.DecimalTextBox();
            this.txtBuyToPrice = new InventoryView.Controls.DecimalTextBox();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(30, 20);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(151, 27);
            this.lblHeader.TabIndex = 11;
            this.lblHeader.Text = "Search Items :";
            // 
            // ckbAllItems
            // 
            this.ckbAllItems.AutoSize = true;
            this.ckbAllItems.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbAllItems.Location = new System.Drawing.Point(30, 70);
            this.ckbAllItems.Name = "ckbAllItems";
            this.ckbAllItems.Size = new System.Drawing.Size(116, 22);
            this.ckbAllItems.TabIndex = 1;
            this.ckbAllItems.Text = "Show All Items";
            this.ckbAllItems.UseVisualStyleBackColor = true;
            this.ckbAllItems.CheckedChanged += new System.EventHandler(this.ckbAllItems_CheckedChanged);
            this.ckbAllItems.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ckbAllItems_KeyDown);
            // 
            // lblItemId
            // 
            this.lblItemId.AutoSize = true;
            this.lblItemId.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemId.Location = new System.Drawing.Point(30, 110);
            this.lblItemId.Name = "lblItemId";
            this.lblItemId.Size = new System.Drawing.Size(51, 18);
            this.lblItemId.TabIndex = 23;
            this.lblItemId.Text = "Item Id";
            // 
            // cmbDealers
            // 
            this.cmbDealers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDealers.FormattingEnabled = true;
            this.cmbDealers.Location = new System.Drawing.Point(170, 215);
            this.cmbDealers.Name = "cmbDealers";
            this.cmbDealers.Size = new System.Drawing.Size(219, 26);
            this.cmbDealers.TabIndex = 5;
            this.cmbDealers.SelectedIndexChanged += new System.EventHandler(this.cmbDealers_SelectedIndexChanged);
            // 
            // lblDealer
            // 
            this.lblDealer.AutoSize = true;
            this.lblDealer.Location = new System.Drawing.Point(30, 215);
            this.lblDealer.Name = "lblDealer";
            this.lblDealer.Size = new System.Drawing.Size(112, 18);
            this.lblDealer.TabIndex = 42;
            this.lblDealer.Text = "Search By Dealer";
            // 
            // cmbCategories
            // 
            this.cmbCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategories.FormattingEnabled = true;
            this.cmbCategories.Location = new System.Drawing.Point(170, 145);
            this.cmbCategories.Name = "cmbCategories";
            this.cmbCategories.Size = new System.Drawing.Size(219, 26);
            this.cmbCategories.TabIndex = 3;
            this.cmbCategories.SelectedIndexChanged += new System.EventHandler(this.cmbCategories_SelectedIndexChanged);
            // 
            // cmbBrands
            // 
            this.cmbBrands.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBrands.FormattingEnabled = true;
            this.cmbBrands.Location = new System.Drawing.Point(170, 180);
            this.cmbBrands.Name = "cmbBrands";
            this.cmbBrands.Size = new System.Drawing.Size(219, 26);
            this.cmbBrands.TabIndex = 4;
            this.cmbBrands.SelectedIndexChanged += new System.EventHandler(this.cmbBrands_SelectedIndexChanged);
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Location = new System.Drawing.Point(30, 180);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(110, 18);
            this.lblBrand.TabIndex = 41;
            this.lblBrand.Text = "Search By Brand";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(30, 145);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(127, 18);
            this.lblCategory.TabIndex = 40;
            this.lblCategory.Text = "Search By Category";
            // 
            // dtpBuyFromDate
            // 
            this.dtpBuyFromDate.Location = new System.Drawing.Point(170, 250);
            this.dtpBuyFromDate.Name = "dtpBuyFromDate";
            this.dtpBuyFromDate.Size = new System.Drawing.Size(219, 23);
            this.dtpBuyFromDate.TabIndex = 6;
            this.dtpBuyFromDate.ValueChanged += new System.EventHandler(this.dtpBuyFromDate_ValueChanged);
            this.dtpBuyFromDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpBuyFromDate_KeyDown);
            // 
            // lblBuyFromDate
            // 
            this.lblBuyFromDate.AutoSize = true;
            this.lblBuyFromDate.Location = new System.Drawing.Point(30, 250);
            this.lblBuyFromDate.Name = "lblBuyFromDate";
            this.lblBuyFromDate.Size = new System.Drawing.Size(98, 18);
            this.lblBuyFromDate.TabIndex = 44;
            this.lblBuyFromDate.Text = "Buy From Date";
            // 
            // dtpBuyToDate
            // 
            this.dtpBuyToDate.Location = new System.Drawing.Point(530, 250);
            this.dtpBuyToDate.Name = "dtpBuyToDate";
            this.dtpBuyToDate.Size = new System.Drawing.Size(219, 23);
            this.dtpBuyToDate.TabIndex = 7;
            this.dtpBuyToDate.ValueChanged += new System.EventHandler(this.dtpBuyToDate_ValueChanged);
            this.dtpBuyToDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpBuyToDate_KeyDown);
            // 
            // lblBuyToDate
            // 
            this.lblBuyToDate.AutoSize = true;
            this.lblBuyToDate.Location = new System.Drawing.Point(430, 250);
            this.lblBuyToDate.Name = "lblBuyToDate";
            this.lblBuyToDate.Size = new System.Drawing.Size(81, 18);
            this.lblBuyToDate.TabIndex = 46;
            this.lblBuyToDate.Text = "Buy To Date";
            // 
            // dtpSellToDate
            // 
            this.dtpSellToDate.Location = new System.Drawing.Point(530, 285);
            this.dtpSellToDate.Name = "dtpSellToDate";
            this.dtpSellToDate.Size = new System.Drawing.Size(219, 23);
            this.dtpSellToDate.TabIndex = 9;
            this.dtpSellToDate.ValueChanged += new System.EventHandler(this.dtpSellToDate_ValueChanged);
            this.dtpSellToDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpSellToDate_KeyDown);
            // 
            // lblSellToDate
            // 
            this.lblSellToDate.AutoSize = true;
            this.lblSellToDate.Location = new System.Drawing.Point(430, 285);
            this.lblSellToDate.Name = "lblSellToDate";
            this.lblSellToDate.Size = new System.Drawing.Size(80, 18);
            this.lblSellToDate.TabIndex = 50;
            this.lblSellToDate.Text = "Sell To Date";
            // 
            // dtpSellFromDate
            // 
            this.dtpSellFromDate.Location = new System.Drawing.Point(170, 285);
            this.dtpSellFromDate.Name = "dtpSellFromDate";
            this.dtpSellFromDate.Size = new System.Drawing.Size(219, 23);
            this.dtpSellFromDate.TabIndex = 8;
            this.dtpSellFromDate.ValueChanged += new System.EventHandler(this.dtpSellFromDate_ValueChanged);
            this.dtpSellFromDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpSellFromDate_KeyDown);
            // 
            // lblSellFromDate
            // 
            this.lblSellFromDate.AutoSize = true;
            this.lblSellFromDate.Location = new System.Drawing.Point(30, 285);
            this.lblSellFromDate.Name = "lblSellFromDate";
            this.lblSellFromDate.Size = new System.Drawing.Size(97, 18);
            this.lblSellFromDate.TabIndex = 48;
            this.lblSellFromDate.Text = "Sell From Date";
            // 
            // lblBuyFromPrice
            // 
            this.lblBuyFromPrice.AutoSize = true;
            this.lblBuyFromPrice.Location = new System.Drawing.Point(30, 320);
            this.lblBuyFromPrice.Name = "lblBuyFromPrice";
            this.lblBuyFromPrice.Size = new System.Drawing.Size(103, 18);
            this.lblBuyFromPrice.TabIndex = 52;
            this.lblBuyFromPrice.Text = "Buy From Price";
            // 
            // lblBuyToPrice
            // 
            this.lblBuyToPrice.AutoSize = true;
            this.lblBuyToPrice.Location = new System.Drawing.Point(425, 325);
            this.lblBuyToPrice.Name = "lblBuyToPrice";
            this.lblBuyToPrice.Size = new System.Drawing.Size(86, 18);
            this.lblBuyToPrice.TabIndex = 54;
            this.lblBuyToPrice.Text = "Buy To Price";
            // 
            // lblSellToPrice
            // 
            this.lblSellToPrice.AutoSize = true;
            this.lblSellToPrice.Location = new System.Drawing.Point(425, 360);
            this.lblSellToPrice.Name = "lblSellToPrice";
            this.lblSellToPrice.Size = new System.Drawing.Size(85, 18);
            this.lblSellToPrice.TabIndex = 58;
            this.lblSellToPrice.Text = "Sell To Price";
            // 
            // lblSellFromPrice
            // 
            this.lblSellFromPrice.AutoSize = true;
            this.lblSellFromPrice.Location = new System.Drawing.Point(30, 355);
            this.lblSellFromPrice.Name = "lblSellFromPrice";
            this.lblSellFromPrice.Size = new System.Drawing.Size(102, 18);
            this.lblSellFromPrice.TabIndex = 56;
            this.lblSellFromPrice.Text = "Sell From Price";
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(661, 407);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(9, 11, 9, 11);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(35, 35);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(714, 407);
            this.btnClose.Margin = new System.Windows.Forms.Padding(9, 11, 9, 11);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 35);
            this.btnClose.TabIndex = 15;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtBuyFromPrice
            // 
            this.txtBuyFromPrice.Location = new System.Drawing.Point(170, 320);
            this.txtBuyFromPrice.MaxLength = 15;
            this.txtBuyFromPrice.Name = "txtBuyFromPrice";
            this.txtBuyFromPrice.Size = new System.Drawing.Size(219, 23);
            this.txtBuyFromPrice.TabIndex = 10;
            this.txtBuyFromPrice.Text = "0.0";
            // 
            // txtItemId
            // 
            this.txtItemId.Location = new System.Drawing.Point(170, 110);
            this.txtItemId.MaxLength = 25;
            this.txtItemId.Name = "txtItemId";
            this.txtItemId.Size = new System.Drawing.Size(219, 23);
            this.txtItemId.TabIndex = 2;
            // 
            // txtSellToPrice
            // 
            this.txtSellToPrice.Location = new System.Drawing.Point(530, 350);
            this.txtSellToPrice.MaxLength = 15;
            this.txtSellToPrice.Name = "txtSellToPrice";
            this.txtSellToPrice.Size = new System.Drawing.Size(219, 23);
            this.txtSellToPrice.TabIndex = 13;
            this.txtSellToPrice.Text = "0.0";
            // 
            // txtSellFromPrice
            // 
            this.txtSellFromPrice.Location = new System.Drawing.Point(170, 355);
            this.txtSellFromPrice.MaxLength = 15;
            this.txtSellFromPrice.Name = "txtSellFromPrice";
            this.txtSellFromPrice.Size = new System.Drawing.Size(219, 23);
            this.txtSellFromPrice.TabIndex = 12;
            this.txtSellFromPrice.Text = "0.0";
            // 
            // txtBuyToPrice
            // 
            this.txtBuyToPrice.Location = new System.Drawing.Point(530, 320);
            this.txtBuyToPrice.MaxLength = 15;
            this.txtBuyToPrice.Name = "txtBuyToPrice";
            this.txtBuyToPrice.Size = new System.Drawing.Size(219, 23);
            this.txtBuyToPrice.TabIndex = 11;
            this.txtBuyToPrice.Text = "0.0";
            // 
            // frmItemSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(782, 481);
            this.ControlBox = false;
            this.Controls.Add(this.txtBuyToPrice);
            this.Controls.Add(this.txtSellFromPrice);
            this.Controls.Add(this.txtSellToPrice);
            this.Controls.Add(this.txtBuyFromPrice);
            this.Controls.Add(this.txtItemId);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblSellToPrice);
            this.Controls.Add(this.lblSellFromPrice);
            this.Controls.Add(this.lblBuyToPrice);
            this.Controls.Add(this.lblBuyFromPrice);
            this.Controls.Add(this.dtpSellToDate);
            this.Controls.Add(this.lblSellToDate);
            this.Controls.Add(this.dtpSellFromDate);
            this.Controls.Add(this.lblSellFromDate);
            this.Controls.Add(this.dtpBuyToDate);
            this.Controls.Add(this.lblBuyToDate);
            this.Controls.Add(this.dtpBuyFromDate);
            this.Controls.Add(this.lblBuyFromDate);
            this.Controls.Add(this.cmbDealers);
            this.Controls.Add(this.lblDealer);
            this.Controls.Add(this.cmbCategories);
            this.Controls.Add(this.cmbBrands);
            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblItemId);
            this.Controls.Add(this.ckbAllItems);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmItemSearch";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.frmItemSearch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.CheckBox ckbAllItems;
        private System.Windows.Forms.Label lblItemId;
        private System.Windows.Forms.ComboBox cmbDealers;
        private System.Windows.Forms.Label lblDealer;
        private System.Windows.Forms.ComboBox cmbCategories;
        private System.Windows.Forms.ComboBox cmbBrands;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.DateTimePicker dtpBuyFromDate;
        private System.Windows.Forms.Label lblBuyFromDate;
        private System.Windows.Forms.DateTimePicker dtpBuyToDate;
        private System.Windows.Forms.Label lblBuyToDate;
        private System.Windows.Forms.DateTimePicker dtpSellToDate;
        private System.Windows.Forms.Label lblSellToDate;
        private System.Windows.Forms.DateTimePicker dtpSellFromDate;
        private System.Windows.Forms.Label lblSellFromDate;
        private System.Windows.Forms.Label lblBuyFromPrice;
        private System.Windows.Forms.Label lblBuyToPrice;
        private System.Windows.Forms.Label lblSellToPrice;
        private System.Windows.Forms.Label lblSellFromPrice;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClose;
        private Controls.NumericTextBox txtItemId;
        private Controls.DecimalTextBox txtBuyFromPrice;
        private Controls.DecimalTextBox txtSellToPrice;
        private Controls.DecimalTextBox txtSellFromPrice;
        private Controls.DecimalTextBox txtBuyToPrice;
    }
}