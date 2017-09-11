namespace InventoryView
{
    partial class frmItemAddMod
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmItemAddMod));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblItemHeader = new System.Windows.Forms.Label();
            this.cmbBrands = new System.Windows.Forms.ComboBox();
            this.cmbCategories = new System.Windows.Forms.ComboBox();
            this.cmbDealers = new System.Windows.Forms.ComboBox();
            this.lblDealer = new System.Windows.Forms.Label();
            this.lblBuyDate = new System.Windows.Forms.Label();
            this.lblBuyPrice = new System.Windows.Forms.Label();
            this.dtpBuyDate = new System.Windows.Forms.DateTimePicker();
            this.lblCustomerNumber = new System.Windows.Forms.Label();
            this.txtCustomerAddress = new System.Windows.Forms.TextBox();
            this.lblCustomerAddress = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblHoriLine = new System.Windows.Forms.Label();
            this.dtpSellDate = new System.Windows.Forms.DateTimePicker();
            this.lblSellPrice = new System.Windows.Forms.Label();
            this.lblSellDate = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.lblModelNum = new System.Windows.Forms.Label();
            this.txtIMEINumber = new System.Windows.Forms.TextBox();
            this.lblIMEI = new System.Windows.Forms.Label();
            this.txtCustomerNumber = new InventoryView.Controls.NumericTextBox();
            this.txtSellPrice = new InventoryView.Controls.DecimalTextBox();
            this.txtBuyPrice = new InventoryView.Controls.DecimalTextBox();
            this.SuspendLayout();
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
            this.btnClose.Location = new System.Drawing.Point(362, 492);
            this.btnClose.Margin = new System.Windows.Forms.Padding(9, 11, 9, 11);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 35);
            this.btnClose.TabIndex = 14;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSubmit.BackgroundImage")));
            this.btnSubmit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSubmit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Location = new System.Drawing.Point(25, 492);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(9, 11, 9, 11);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(35, 35);
            this.btnSubmit.TabIndex = 13;
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Location = new System.Drawing.Point(25, 82);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(86, 18);
            this.lblBrand.TabIndex = 30;
            this.lblBrand.Text = "Select Brand";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(25, 50);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(103, 18);
            this.lblCategory.TabIndex = 28;
            this.lblCategory.Text = "Select Category";
            // 
            // lblItemHeader
            // 
            this.lblItemHeader.AutoSize = true;
            this.lblItemHeader.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemHeader.Location = new System.Drawing.Point(24, 10);
            this.lblItemHeader.Name = "lblItemHeader";
            this.lblItemHeader.Size = new System.Drawing.Size(88, 22);
            this.lblItemHeader.TabIndex = 27;
            this.lblItemHeader.Text = "Add Item :";
            // 
            // cmbBrands
            // 
            this.cmbBrands.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBrands.FormattingEnabled = true;
            this.cmbBrands.Location = new System.Drawing.Point(148, 79);
            this.cmbBrands.Name = "cmbBrands";
            this.cmbBrands.Size = new System.Drawing.Size(249, 26);
            this.cmbBrands.TabIndex = 2;
            // 
            // cmbCategories
            // 
            this.cmbCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategories.FormattingEnabled = true;
            this.cmbCategories.Location = new System.Drawing.Point(148, 47);
            this.cmbCategories.Name = "cmbCategories";
            this.cmbCategories.Size = new System.Drawing.Size(249, 26);
            this.cmbCategories.TabIndex = 1;
            this.cmbCategories.SelectedIndexChanged += new System.EventHandler(this.cmbCategories_SelectedIndexChanged);
            // 
            // cmbDealers
            // 
            this.cmbDealers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDealers.FormattingEnabled = true;
            this.cmbDealers.Location = new System.Drawing.Point(148, 111);
            this.cmbDealers.Name = "cmbDealers";
            this.cmbDealers.Size = new System.Drawing.Size(249, 26);
            this.cmbDealers.TabIndex = 3;
            // 
            // lblDealer
            // 
            this.lblDealer.AutoSize = true;
            this.lblDealer.Location = new System.Drawing.Point(25, 114);
            this.lblDealer.Name = "lblDealer";
            this.lblDealer.Size = new System.Drawing.Size(88, 18);
            this.lblDealer.TabIndex = 36;
            this.lblDealer.Text = "Select Dealer";
            // 
            // lblBuyDate
            // 
            this.lblBuyDate.AutoSize = true;
            this.lblBuyDate.Location = new System.Drawing.Point(26, 214);
            this.lblBuyDate.Name = "lblBuyDate";
            this.lblBuyDate.Size = new System.Drawing.Size(62, 18);
            this.lblBuyDate.TabIndex = 38;
            this.lblBuyDate.Text = "Buy Date";
            // 
            // lblBuyPrice
            // 
            this.lblBuyPrice.AutoSize = true;
            this.lblBuyPrice.Location = new System.Drawing.Point(24, 243);
            this.lblBuyPrice.Name = "lblBuyPrice";
            this.lblBuyPrice.Size = new System.Drawing.Size(67, 18);
            this.lblBuyPrice.TabIndex = 40;
            this.lblBuyPrice.Text = "Buy Price";
            // 
            // dtpBuyDate
            // 
            this.dtpBuyDate.Location = new System.Drawing.Point(148, 211);
            this.dtpBuyDate.Name = "dtpBuyDate";
            this.dtpBuyDate.Size = new System.Drawing.Size(248, 23);
            this.dtpBuyDate.TabIndex = 6;
            // 
            // lblCustomerNumber
            // 
            this.lblCustomerNumber.AutoSize = true;
            this.lblCustomerNumber.Location = new System.Drawing.Point(24, 392);
            this.lblCustomerNumber.Name = "lblCustomerNumber";
            this.lblCustomerNumber.Size = new System.Drawing.Size(119, 18);
            this.lblCustomerNumber.TabIndex = 45;
            this.lblCustomerNumber.Text = "Customer Number";
            // 
            // txtCustomerAddress
            // 
            this.txtCustomerAddress.Location = new System.Drawing.Point(147, 322);
            this.txtCustomerAddress.MaxLength = 500;
            this.txtCustomerAddress.Multiline = true;
            this.txtCustomerAddress.Name = "txtCustomerAddress";
            this.txtCustomerAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCustomerAddress.Size = new System.Drawing.Size(249, 61);
            this.txtCustomerAddress.TabIndex = 9;
            // 
            // lblCustomerAddress
            // 
            this.lblCustomerAddress.AutoSize = true;
            this.lblCustomerAddress.Location = new System.Drawing.Point(24, 325);
            this.lblCustomerAddress.Name = "lblCustomerAddress";
            this.lblCustomerAddress.Size = new System.Drawing.Size(118, 18);
            this.lblCustomerAddress.TabIndex = 43;
            this.lblCustomerAddress.Text = "Customer Address";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(147, 293);
            this.txtCustomerName.MaxLength = 200;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(249, 23);
            this.txtCustomerName.TabIndex = 8;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(24, 296);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(104, 18);
            this.lblCustomerName.TabIndex = 41;
            this.lblCustomerName.Text = "Customer Name";
            // 
            // lblHoriLine
            // 
            this.lblHoriLine.BackColor = System.Drawing.Color.DimGray;
            this.lblHoriLine.Location = new System.Drawing.Point(25, 277);
            this.lblHoriLine.Name = "lblHoriLine";
            this.lblHoriLine.Size = new System.Drawing.Size(370, 2);
            this.lblHoriLine.TabIndex = 47;
            // 
            // dtpSellDate
            // 
            this.dtpSellDate.Location = new System.Drawing.Point(147, 418);
            this.dtpSellDate.Name = "dtpSellDate";
            this.dtpSellDate.Size = new System.Drawing.Size(248, 23);
            this.dtpSellDate.TabIndex = 11;
            // 
            // lblSellPrice
            // 
            this.lblSellPrice.AutoSize = true;
            this.lblSellPrice.Location = new System.Drawing.Point(22, 450);
            this.lblSellPrice.Name = "lblSellPrice";
            this.lblSellPrice.Size = new System.Drawing.Size(66, 18);
            this.lblSellPrice.TabIndex = 51;
            this.lblSellPrice.Text = "Sell Price";
            // 
            // lblSellDate
            // 
            this.lblSellDate.AutoSize = true;
            this.lblSellDate.Location = new System.Drawing.Point(24, 421);
            this.lblSellDate.Name = "lblSellDate";
            this.lblSellDate.Size = new System.Drawing.Size(61, 18);
            this.lblSellDate.TabIndex = 50;
            this.lblSellDate.Text = "Sell Date";
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(148, 142);
            this.txtModel.MaxLength = 50;
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(249, 23);
            this.txtModel.TabIndex = 4;
            // 
            // lblModelNum
            // 
            this.lblModelNum.AutoSize = true;
            this.lblModelNum.Location = new System.Drawing.Point(24, 146);
            this.lblModelNum.Name = "lblModelNum";
            this.lblModelNum.Size = new System.Drawing.Size(97, 18);
            this.lblModelNum.TabIndex = 53;
            this.lblModelNum.Text = "Model Number";
            // 
            // txtIMEINumber
            // 
            this.txtIMEINumber.Location = new System.Drawing.Point(148, 175);
            this.txtIMEINumber.MaxLength = 50;
            this.txtIMEINumber.Name = "txtIMEINumber";
            this.txtIMEINumber.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtIMEINumber.Size = new System.Drawing.Size(249, 23);
            this.txtIMEINumber.TabIndex = 5;
            // 
            // lblIMEI
            // 
            this.lblIMEI.AutoSize = true;
            this.lblIMEI.Location = new System.Drawing.Point(25, 171);
            this.lblIMEI.Name = "lblIMEI";
            this.lblIMEI.Size = new System.Drawing.Size(102, 36);
            this.lblIMEI.TabIndex = 32;
            this.lblIMEI.Text = "IMEI Number(s)\r\n(,) seperated";
            // 
            // txtCustomerNumber
            // 
            this.txtCustomerNumber.Location = new System.Drawing.Point(147, 389);
            this.txtCustomerNumber.MaxLength = 10;
            this.txtCustomerNumber.Name = "txtCustomerNumber";
            this.txtCustomerNumber.Size = new System.Drawing.Size(249, 23);
            this.txtCustomerNumber.TabIndex = 10;
            // 
            // txtSellPrice
            // 
            this.txtSellPrice.Location = new System.Drawing.Point(145, 447);
            this.txtSellPrice.MaxLength = 15;
            this.txtSellPrice.Name = "txtSellPrice";
            this.txtSellPrice.Size = new System.Drawing.Size(249, 23);
            this.txtSellPrice.TabIndex = 12;
            this.txtSellPrice.Text = "0.0";
            // 
            // txtBuyPrice
            // 
            this.txtBuyPrice.Location = new System.Drawing.Point(147, 240);
            this.txtBuyPrice.MaxLength = 15;
            this.txtBuyPrice.Name = "txtBuyPrice";
            this.txtBuyPrice.Size = new System.Drawing.Size(249, 23);
            this.txtBuyPrice.TabIndex = 7;
            this.txtBuyPrice.Text = "0.0";
            // 
            // frmItemAddMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(421, 537);
            this.ControlBox = false;
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.lblModelNum);
            this.Controls.Add(this.txtCustomerNumber);
            this.Controls.Add(this.txtSellPrice);
            this.Controls.Add(this.txtBuyPrice);
            this.Controls.Add(this.dtpSellDate);
            this.Controls.Add(this.lblSellPrice);
            this.Controls.Add(this.lblSellDate);
            this.Controls.Add(this.lblHoriLine);
            this.Controls.Add(this.lblCustomerNumber);
            this.Controls.Add(this.txtCustomerAddress);
            this.Controls.Add(this.lblCustomerAddress);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.dtpBuyDate);
            this.Controls.Add(this.lblBuyPrice);
            this.Controls.Add(this.lblBuyDate);
            this.Controls.Add(this.cmbDealers);
            this.Controls.Add(this.lblDealer);
            this.Controls.Add(this.cmbCategories);
            this.Controls.Add(this.cmbBrands);
            this.Controls.Add(this.txtIMEINumber);
            this.Controls.Add(this.lblIMEI);
            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblItemHeader);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmItemAddMod";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmItemAddMod_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblItemHeader;
        private System.Windows.Forms.ComboBox cmbBrands;
        private System.Windows.Forms.ComboBox cmbCategories;
        private System.Windows.Forms.ComboBox cmbDealers;
        private System.Windows.Forms.Label lblDealer;
        private System.Windows.Forms.Label lblBuyDate;
        private System.Windows.Forms.Label lblBuyPrice;
        private System.Windows.Forms.DateTimePicker dtpBuyDate;
        private System.Windows.Forms.Label lblCustomerNumber;
        private System.Windows.Forms.TextBox txtCustomerAddress;
        private System.Windows.Forms.Label lblCustomerAddress;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblHoriLine;
        private System.Windows.Forms.DateTimePicker dtpSellDate;
        private System.Windows.Forms.Label lblSellPrice;
        private System.Windows.Forms.Label lblSellDate;
        private Controls.DecimalTextBox txtBuyPrice;
        private Controls.DecimalTextBox txtSellPrice;
        private Controls.NumericTextBox txtCustomerNumber;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label lblModelNum;
        private System.Windows.Forms.TextBox txtIMEINumber;
        private System.Windows.Forms.Label lblIMEI;
    }
}