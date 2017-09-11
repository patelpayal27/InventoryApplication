namespace InventoryView
{
    partial class frmGenBill
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGenBill));
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblConsigneeName = new System.Windows.Forms.Label();
            this.lblConsignorName = new System.Windows.Forms.Label();
            this.txtConsigneeName = new System.Windows.Forms.TextBox();
            this.txtConsignorName = new System.Windows.Forms.TextBox();
            this.txtConsigneeAddress = new System.Windows.Forms.TextBox();
            this.lblConsigneeAddress = new System.Windows.Forms.Label();
            this.txtConsignorAddress = new System.Windows.Forms.TextBox();
            this.lblConsignorAddress = new System.Windows.Forms.Label();
            this.lblConsigneeNumber = new System.Windows.Forms.Label();
            this.lblConsignorNumber = new System.Windows.Forms.Label();
            this.txtRefId = new System.Windows.Forms.TextBox();
            this.lblRefId = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.txtVatTin = new System.Windows.Forms.TextBox();
            this.lblVatTin = new System.Windows.Forms.Label();
            this.txtCstNo = new System.Windows.Forms.TextBox();
            this.lblCstNo = new System.Windows.Forms.Label();
            this.txtIMEI = new System.Windows.Forms.TextBox();
            this.lblIMEI = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtShipCharge = new System.Windows.Forms.TextBox();
            this.lblShipCharge = new System.Windows.Forms.Label();
            this.txtTax = new System.Windows.Forms.TextBox();
            this.lblTax = new System.Windows.Forms.Label();
            this.txtCouponsDiscounts = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenBill = new System.Windows.Forms.Button();
            this.txtTotalAmt = new System.Windows.Forms.TextBox();
            this.lblTotalAmt = new System.Windows.Forms.Label();
            this.txtNetAmount = new System.Windows.Forms.TextBox();
            this.lblNetAmount = new System.Windows.Forms.Label();
            this.txtTaxAmt = new System.Windows.Forms.TextBox();
            this.lblTaxAmt = new System.Windows.Forms.Label();
            this.btnCalculateAmt = new System.Windows.Forms.Button();
            this.toolStripLabel = new System.Windows.Forms.ToolStrip();
            this.txtConsignorNumber = new InventoryView.Controls.NumericTextBox();
            this.txtConsigneeNumber = new InventoryView.Controls.NumericTextBox();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(30, 20);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(153, 27);
            this.lblHeader.TabIndex = 12;
            this.lblHeader.Text = "Generate Bill :";
            // 
            // lblConsigneeName
            // 
            this.lblConsigneeName.AutoSize = true;
            this.lblConsigneeName.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsigneeName.Location = new System.Drawing.Point(30, 70);
            this.lblConsigneeName.Name = "lblConsigneeName";
            this.lblConsigneeName.Size = new System.Drawing.Size(108, 18);
            this.lblConsigneeName.TabIndex = 25;
            this.lblConsigneeName.Text = "Consignee Name";
            // 
            // lblConsignorName
            // 
            this.lblConsignorName.AutoSize = true;
            this.lblConsignorName.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsignorName.Location = new System.Drawing.Point(403, 71);
            this.lblConsignorName.Name = "lblConsignorName";
            this.lblConsignorName.Size = new System.Drawing.Size(107, 18);
            this.lblConsignorName.TabIndex = 27;
            this.lblConsignorName.Text = "Consignor Name";
            // 
            // txtConsigneeName
            // 
            this.txtConsigneeName.Location = new System.Drawing.Point(155, 70);
            this.txtConsigneeName.Name = "txtConsigneeName";
            this.txtConsigneeName.Size = new System.Drawing.Size(230, 23);
            this.txtConsigneeName.TabIndex = 1;
            // 
            // txtConsignorName
            // 
            this.txtConsignorName.Location = new System.Drawing.Point(523, 71);
            this.txtConsignorName.Name = "txtConsignorName";
            this.txtConsignorName.Size = new System.Drawing.Size(230, 23);
            this.txtConsignorName.TabIndex = 13;
            this.txtConsignorName.Text = "ND Mobile";
            // 
            // txtConsigneeAddress
            // 
            this.txtConsigneeAddress.Location = new System.Drawing.Point(155, 100);
            this.txtConsigneeAddress.MaxLength = 500;
            this.txtConsigneeAddress.Multiline = true;
            this.txtConsigneeAddress.Name = "txtConsigneeAddress";
            this.txtConsigneeAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConsigneeAddress.Size = new System.Drawing.Size(230, 75);
            this.txtConsigneeAddress.TabIndex = 2;
            // 
            // lblConsigneeAddress
            // 
            this.lblConsigneeAddress.AutoSize = true;
            this.lblConsigneeAddress.Location = new System.Drawing.Point(30, 100);
            this.lblConsigneeAddress.Name = "lblConsigneeAddress";
            this.lblConsigneeAddress.Size = new System.Drawing.Size(123, 18);
            this.lblConsigneeAddress.TabIndex = 31;
            this.lblConsigneeAddress.Text = "Consignee Address";
            // 
            // txtConsignorAddress
            // 
            this.txtConsignorAddress.Location = new System.Drawing.Point(523, 100);
            this.txtConsignorAddress.MaxLength = 500;
            this.txtConsignorAddress.Multiline = true;
            this.txtConsignorAddress.Name = "txtConsignorAddress";
            this.txtConsignorAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConsignorAddress.Size = new System.Drawing.Size(230, 75);
            this.txtConsignorAddress.TabIndex = 14;
            this.txtConsignorAddress.Text = "35, Sharaddha Deep Complex Plaza-2, Nr. Jodhpur Sweets Shashtrinagar Road, NARANP" +
    "URA, AHMEDABAD- 380013";
            // 
            // lblConsignorAddress
            // 
            this.lblConsignorAddress.AutoSize = true;
            this.lblConsignorAddress.Location = new System.Drawing.Point(402, 103);
            this.lblConsignorAddress.Name = "lblConsignorAddress";
            this.lblConsignorAddress.Size = new System.Drawing.Size(122, 18);
            this.lblConsignorAddress.TabIndex = 33;
            this.lblConsignorAddress.Text = "Consignor Address";
            // 
            // lblConsigneeNumber
            // 
            this.lblConsigneeNumber.AutoSize = true;
            this.lblConsigneeNumber.Location = new System.Drawing.Point(30, 180);
            this.lblConsigneeNumber.Name = "lblConsigneeNumber";
            this.lblConsigneeNumber.Size = new System.Drawing.Size(123, 18);
            this.lblConsigneeNumber.TabIndex = 35;
            this.lblConsigneeNumber.Text = "Consignee Number";
            // 
            // lblConsignorNumber
            // 
            this.lblConsignorNumber.AutoSize = true;
            this.lblConsignorNumber.Location = new System.Drawing.Point(403, 181);
            this.lblConsignorNumber.Name = "lblConsignorNumber";
            this.lblConsignorNumber.Size = new System.Drawing.Size(122, 18);
            this.lblConsignorNumber.TabIndex = 37;
            this.lblConsignorNumber.Text = "Consignor Number";
            // 
            // txtRefId
            // 
            this.txtRefId.Location = new System.Drawing.Point(155, 210);
            this.txtRefId.Name = "txtRefId";
            this.txtRefId.Size = new System.Drawing.Size(230, 23);
            this.txtRefId.TabIndex = 4;
            // 
            // lblRefId
            // 
            this.lblRefId.AutoSize = true;
            this.lblRefId.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefId.Location = new System.Drawing.Point(30, 210);
            this.lblRefId.Name = "lblRefId";
            this.lblRefId.Size = new System.Drawing.Size(44, 18);
            this.lblRefId.TabIndex = 38;
            this.lblRefId.Text = "Ref Id";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(155, 240);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(230, 23);
            this.dtpDate.TabIndex = 5;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(30, 240);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(35, 18);
            this.lblDate.TabIndex = 46;
            this.lblDate.Text = "Date";
            // 
            // txtVatTin
            // 
            this.txtVatTin.Location = new System.Drawing.Point(523, 210);
            this.txtVatTin.Name = "txtVatTin";
            this.txtVatTin.Size = new System.Drawing.Size(230, 23);
            this.txtVatTin.TabIndex = 16;
            this.txtVatTin.Text = "24072905327";
            // 
            // lblVatTin
            // 
            this.lblVatTin.AutoSize = true;
            this.lblVatTin.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVatTin.Location = new System.Drawing.Point(403, 210);
            this.lblVatTin.Name = "lblVatTin";
            this.lblVatTin.Size = new System.Drawing.Size(58, 18);
            this.lblVatTin.TabIndex = 47;
            this.lblVatTin.Text = "VAT/TIN";
            // 
            // txtCstNo
            // 
            this.txtCstNo.Location = new System.Drawing.Point(523, 240);
            this.txtCstNo.Name = "txtCstNo";
            this.txtCstNo.Size = new System.Drawing.Size(230, 23);
            this.txtCstNo.TabIndex = 17;
            this.txtCstNo.Text = "24572905327";
            // 
            // lblCstNo
            // 
            this.lblCstNo.AutoSize = true;
            this.lblCstNo.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCstNo.Location = new System.Drawing.Point(403, 240);
            this.lblCstNo.Name = "lblCstNo";
            this.lblCstNo.Size = new System.Drawing.Size(53, 18);
            this.lblCstNo.TabIndex = 49;
            this.lblCstNo.Text = "CST NO";
            // 
            // txtIMEI
            // 
            this.txtIMEI.Location = new System.Drawing.Point(155, 270);
            this.txtIMEI.Name = "txtIMEI";
            this.txtIMEI.Size = new System.Drawing.Size(230, 23);
            this.txtIMEI.TabIndex = 6;
            // 
            // lblIMEI
            // 
            this.lblIMEI.AutoSize = true;
            this.lblIMEI.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIMEI.Location = new System.Drawing.Point(30, 270);
            this.lblIMEI.Name = "lblIMEI";
            this.lblIMEI.Size = new System.Drawing.Size(33, 18);
            this.lblIMEI.TabIndex = 51;
            this.lblIMEI.Text = "IMEI";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(155, 300);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(599, 23);
            this.txtDesc.TabIndex = 7;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.Location = new System.Drawing.Point(30, 300);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(88, 18);
            this.lblDesc.TabIndex = 53;
            this.lblDesc.Text = "DESCRIPTION";
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(460, 330);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(48, 23);
            this.txtQty.TabIndex = 10;
            this.txtQty.Text = "1";
            this.txtQty.TextChanged += new System.EventHandler(this.txtQty_TextChanged);
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty.Location = new System.Drawing.Point(400, 330);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(38, 18);
            this.lblQty.TabIndex = 55;
            this.lblQty.Text = "QTY ";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(205, 330);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(180, 23);
            this.txtPrice.TabIndex = 9;
            this.txtPrice.TextChanged += new System.EventHandler(this.txtPrice_TextChanged);
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Location = new System.Drawing.Point(155, 330);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(40, 18);
            this.lblPrice.TabIndex = 57;
            this.lblPrice.Text = "Price";
            // 
            // txtShipCharge
            // 
            this.txtShipCharge.Location = new System.Drawing.Point(155, 360);
            this.txtShipCharge.Name = "txtShipCharge";
            this.txtShipCharge.Size = new System.Drawing.Size(110, 23);
            this.txtShipCharge.TabIndex = 11;
            this.txtShipCharge.Text = "0";
            this.txtShipCharge.TextChanged += new System.EventHandler(this.txtShipCharge_TextChanged);
            // 
            // lblShipCharge
            // 
            this.lblShipCharge.AutoSize = true;
            this.lblShipCharge.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShipCharge.Location = new System.Drawing.Point(30, 360);
            this.lblShipCharge.Name = "lblShipCharge";
            this.lblShipCharge.Size = new System.Drawing.Size(117, 18);
            this.lblShipCharge.TabIndex = 61;
            this.lblShipCharge.Text = "Shipping Changes";
            // 
            // txtTax
            // 
            this.txtTax.Location = new System.Drawing.Point(85, 330);
            this.txtTax.Name = "txtTax";
            this.txtTax.Size = new System.Drawing.Size(53, 23);
            this.txtTax.TabIndex = 8;
            this.txtTax.TextChanged += new System.EventHandler(this.txtTax_TextChanged);
            // 
            // lblTax
            // 
            this.lblTax.AutoSize = true;
            this.lblTax.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTax.Location = new System.Drawing.Point(30, 330);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(54, 18);
            this.lblTax.TabIndex = 59;
            this.lblTax.Text = "Tax (%)";
            // 
            // txtCouponsDiscounts
            // 
            this.txtCouponsDiscounts.Location = new System.Drawing.Point(155, 390);
            this.txtCouponsDiscounts.Name = "txtCouponsDiscounts";
            this.txtCouponsDiscounts.Size = new System.Drawing.Size(110, 23);
            this.txtCouponsDiscounts.TabIndex = 12;
            this.txtCouponsDiscounts.Text = "0";
            this.txtCouponsDiscounts.TextChanged += new System.EventHandler(this.txtCouponsDiscounts_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 390);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 18);
            this.label1.TabIndex = 63;
            this.label1.Text = "Coupons / Discount";
            // 
            // btnGenBill
            // 
            this.btnGenBill.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGenBill.BackgroundImage")));
            this.btnGenBill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGenBill.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnGenBill.FlatAppearance.BorderSize = 0;
            this.btnGenBill.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnGenBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenBill.Location = new System.Drawing.Point(718, 429);
            this.btnGenBill.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.btnGenBill.Name = "btnGenBill";
            this.btnGenBill.Size = new System.Drawing.Size(35, 35);
            this.btnGenBill.TabIndex = 18;
            this.btnGenBill.UseVisualStyleBackColor = true;
            this.btnGenBill.Click += new System.EventHandler(this.btnGenBill_Click);
            // 
            // txtTotalAmt
            // 
            this.txtTotalAmt.Location = new System.Drawing.Point(620, 390);
            this.txtTotalAmt.Name = "txtTotalAmt";
            this.txtTotalAmt.ReadOnly = true;
            this.txtTotalAmt.Size = new System.Drawing.Size(134, 23);
            this.txtTotalAmt.TabIndex = 21;
            // 
            // lblTotalAmt
            // 
            this.lblTotalAmt.AutoSize = true;
            this.lblTotalAmt.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmt.Location = new System.Drawing.Point(365, 390);
            this.lblTotalAmt.Name = "lblTotalAmt";
            this.lblTotalAmt.Size = new System.Drawing.Size(243, 36);
            this.lblTotalAmt.TabIndex = 68;
            this.lblTotalAmt.Text = "Total Amount = Net Amount - Coupons\r\n+ Shipping Charges";
            // 
            // txtNetAmount
            // 
            this.txtNetAmount.Location = new System.Drawing.Point(620, 360);
            this.txtNetAmount.Name = "txtNetAmount";
            this.txtNetAmount.ReadOnly = true;
            this.txtNetAmount.Size = new System.Drawing.Size(134, 23);
            this.txtNetAmount.TabIndex = 20;
            // 
            // lblNetAmount
            // 
            this.lblNetAmount.AutoSize = true;
            this.lblNetAmount.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetAmount.Location = new System.Drawing.Point(365, 360);
            this.lblNetAmount.Name = "lblNetAmount";
            this.lblNetAmount.Size = new System.Drawing.Size(252, 18);
            this.lblNetAmount.TabIndex = 66;
            this.lblNetAmount.Text = "Net Amount = Price x qty + Tax Amount";
            // 
            // txtTaxAmt
            // 
            this.txtTaxAmt.Location = new System.Drawing.Point(620, 330);
            this.txtTaxAmt.Name = "txtTaxAmt";
            this.txtTaxAmt.ReadOnly = true;
            this.txtTaxAmt.Size = new System.Drawing.Size(134, 23);
            this.txtTaxAmt.TabIndex = 19;
            // 
            // lblTaxAmt
            // 
            this.lblTaxAmt.AutoSize = true;
            this.lblTaxAmt.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaxAmt.Location = new System.Drawing.Point(530, 330);
            this.lblTaxAmt.Name = "lblTaxAmt";
            this.lblTaxAmt.Size = new System.Drawing.Size(81, 18);
            this.lblTaxAmt.TabIndex = 70;
            this.lblTaxAmt.Text = "Tax Amount";
            // 
            // btnCalculateAmt
            // 
            this.btnCalculateAmt.BackColor = System.Drawing.Color.White;
            this.btnCalculateAmt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCalculateAmt.BackgroundImage")));
            this.btnCalculateAmt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCalculateAmt.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCalculateAmt.FlatAppearance.BorderSize = 0;
            this.btnCalculateAmt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnCalculateAmt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalculateAmt.ForeColor = System.Drawing.Color.Black;
            this.btnCalculateAmt.Location = new System.Drawing.Point(669, 429);
            this.btnCalculateAmt.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.btnCalculateAmt.Name = "btnCalculateAmt";
            this.btnCalculateAmt.Size = new System.Drawing.Size(35, 35);
            this.btnCalculateAmt.TabIndex = 72;
            this.btnCalculateAmt.UseVisualStyleBackColor = false;
            this.btnCalculateAmt.Click += new System.EventHandler(this.btnCalculateAmt_Click);
            // 
            // toolStripLabel
            // 
            this.toolStripLabel.Location = new System.Drawing.Point(0, 0);
            this.toolStripLabel.Name = "toolStripLabel";
            this.toolStripLabel.Size = new System.Drawing.Size(782, 25);
            this.toolStripLabel.TabIndex = 73;
            this.toolStripLabel.Text = "toolStripLabel";
            // 
            // txtConsignorNumber
            // 
            this.txtConsignorNumber.Location = new System.Drawing.Point(523, 181);
            this.txtConsignorNumber.MaxLength = 10;
            this.txtConsignorNumber.Name = "txtConsignorNumber";
            this.txtConsignorNumber.Size = new System.Drawing.Size(230, 23);
            this.txtConsignorNumber.TabIndex = 15;
            this.txtConsignorNumber.Text = "9687643804";
            // 
            // txtConsigneeNumber
            // 
            this.txtConsigneeNumber.Location = new System.Drawing.Point(155, 180);
            this.txtConsigneeNumber.MaxLength = 10;
            this.txtConsigneeNumber.Name = "txtConsigneeNumber";
            this.txtConsigneeNumber.Size = new System.Drawing.Size(230, 23);
            this.txtConsigneeNumber.TabIndex = 3;
            // 
            // frmGenBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(782, 481);
            this.ControlBox = false;
            this.Controls.Add(this.toolStripLabel);
            this.Controls.Add(this.btnCalculateAmt);
            this.Controls.Add(this.txtTaxAmt);
            this.Controls.Add(this.lblTaxAmt);
            this.Controls.Add(this.txtTotalAmt);
            this.Controls.Add(this.lblTotalAmt);
            this.Controls.Add(this.txtNetAmount);
            this.Controls.Add(this.lblNetAmount);
            this.Controls.Add(this.btnGenBill);
            this.Controls.Add(this.txtCouponsDiscounts);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtShipCharge);
            this.Controls.Add(this.lblShipCharge);
            this.Controls.Add(this.txtTax);
            this.Controls.Add(this.lblTax);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.lblQty);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.txtIMEI);
            this.Controls.Add(this.lblIMEI);
            this.Controls.Add(this.txtCstNo);
            this.Controls.Add(this.lblCstNo);
            this.Controls.Add(this.txtVatTin);
            this.Controls.Add(this.lblVatTin);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.txtRefId);
            this.Controls.Add(this.lblRefId);
            this.Controls.Add(this.txtConsignorNumber);
            this.Controls.Add(this.lblConsignorNumber);
            this.Controls.Add(this.txtConsigneeNumber);
            this.Controls.Add(this.lblConsigneeNumber);
            this.Controls.Add(this.txtConsignorAddress);
            this.Controls.Add(this.lblConsignorAddress);
            this.Controls.Add(this.txtConsigneeAddress);
            this.Controls.Add(this.lblConsigneeAddress);
            this.Controls.Add(this.txtConsignorName);
            this.Controls.Add(this.txtConsigneeName);
            this.Controls.Add(this.lblConsignorName);
            this.Controls.Add(this.lblConsigneeName);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGenBill";
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblConsigneeName;
        private System.Windows.Forms.Label lblConsignorName;
        private System.Windows.Forms.TextBox txtConsigneeName;
        private System.Windows.Forms.TextBox txtConsignorName;
        private System.Windows.Forms.TextBox txtConsigneeAddress;
        private System.Windows.Forms.TextBox txtConsignorAddress;
        private System.Windows.Forms.Label lblConsignorAddress;
        private System.Windows.Forms.Label lblConsigneeAddress;
        private Controls.NumericTextBox txtConsigneeNumber;
        private System.Windows.Forms.Label lblConsigneeNumber;
        private Controls.NumericTextBox txtConsignorNumber;
        private System.Windows.Forms.Label lblConsignorNumber;
        private System.Windows.Forms.TextBox txtRefId;
        private System.Windows.Forms.Label lblRefId;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.TextBox txtVatTin;
        private System.Windows.Forms.Label lblVatTin;
        private System.Windows.Forms.TextBox txtCstNo;
        private System.Windows.Forms.Label lblCstNo;
        private System.Windows.Forms.TextBox txtIMEI;
        private System.Windows.Forms.Label lblIMEI;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtShipCharge;
        private System.Windows.Forms.Label lblShipCharge;
        private System.Windows.Forms.TextBox txtTax;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.TextBox txtCouponsDiscounts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGenBill;
        private System.Windows.Forms.TextBox txtTotalAmt;
        private System.Windows.Forms.Label lblTotalAmt;
        private System.Windows.Forms.TextBox txtNetAmount;
        private System.Windows.Forms.Label lblNetAmount;
        private System.Windows.Forms.TextBox txtTaxAmt;
        private System.Windows.Forms.Label lblTaxAmt;
        private System.Windows.Forms.Button btnCalculateAmt;
        private System.Windows.Forms.ToolStrip toolStripLabel;
    }
}