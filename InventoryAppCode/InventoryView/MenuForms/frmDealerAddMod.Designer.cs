namespace InventoryView
{
    partial class frmDealerAddMod
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDealerAddMod));
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtDealerName = new System.Windows.Forms.TextBox();
            this.lblDealerName = new System.Windows.Forms.Label();
            this.lblDealerHeader = new System.Windows.Forms.Label();
            this.txtDealerAddress = new System.Windows.Forms.TextBox();
            this.lblDealerAddress = new System.Windows.Forms.Label();
            this.lblDealerNumber = new System.Windows.Forms.Label();
            this.txtDealerNumber = new InventoryView.Controls.NumericTextBox();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSubmit.BackgroundImage")));
            this.btnSubmit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSubmit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Location = new System.Drawing.Point(26, 200);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(35, 35);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
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
            this.btnClose.Location = new System.Drawing.Point(360, 200);
            this.btnClose.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 35);
            this.btnClose.TabIndex = 5;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtDealerName
            // 
            this.txtDealerName.Location = new System.Drawing.Point(146, 64);
            this.txtDealerName.MaxLength = 200;
            this.txtDealerName.Name = "txtDealerName";
            this.txtDealerName.Size = new System.Drawing.Size(249, 23);
            this.txtDealerName.TabIndex = 1;
            // 
            // lblDealerName
            // 
            this.lblDealerName.AutoSize = true;
            this.lblDealerName.Location = new System.Drawing.Point(23, 67);
            this.lblDealerName.Name = "lblDealerName";
            this.lblDealerName.Size = new System.Drawing.Size(85, 18);
            this.lblDealerName.TabIndex = 21;
            this.lblDealerName.Text = "Dealer Name";
            // 
            // lblDealerHeader
            // 
            this.lblDealerHeader.AutoSize = true;
            this.lblDealerHeader.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDealerHeader.Location = new System.Drawing.Point(22, 16);
            this.lblDealerHeader.Name = "lblDealerHeader";
            this.lblDealerHeader.Size = new System.Drawing.Size(103, 22);
            this.lblDealerHeader.TabIndex = 20;
            this.lblDealerHeader.Text = "Add Dealer :";
            // 
            // txtDealerAddress
            // 
            this.txtDealerAddress.Location = new System.Drawing.Point(146, 93);
            this.txtDealerAddress.MaxLength = 500;
            this.txtDealerAddress.Multiline = true;
            this.txtDealerAddress.Name = "txtDealerAddress";
            this.txtDealerAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDealerAddress.Size = new System.Drawing.Size(249, 61);
            this.txtDealerAddress.TabIndex = 2;
            // 
            // lblDealerAddress
            // 
            this.lblDealerAddress.AutoSize = true;
            this.lblDealerAddress.Location = new System.Drawing.Point(23, 96);
            this.lblDealerAddress.Name = "lblDealerAddress";
            this.lblDealerAddress.Size = new System.Drawing.Size(99, 18);
            this.lblDealerAddress.TabIndex = 23;
            this.lblDealerAddress.Text = "Dealer Address";
            // 
            // lblDealerNumber
            // 
            this.lblDealerNumber.AutoSize = true;
            this.lblDealerNumber.Location = new System.Drawing.Point(23, 163);
            this.lblDealerNumber.Name = "lblDealerNumber";
            this.lblDealerNumber.Size = new System.Drawing.Size(100, 18);
            this.lblDealerNumber.TabIndex = 25;
            this.lblDealerNumber.Text = "Dealer Number";
            // 
            // txtDealerNumber
            // 
            this.txtDealerNumber.Location = new System.Drawing.Point(146, 160);
            this.txtDealerNumber.MaxLength = 10;
            this.txtDealerNumber.Name = "txtDealerNumber";
            this.txtDealerNumber.Size = new System.Drawing.Size(249, 23);
            this.txtDealerNumber.TabIndex = 3;
            // 
            // frmDealerAddMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(421, 252);
            this.ControlBox = false;
            this.Controls.Add(this.txtDealerNumber);
            this.Controls.Add(this.lblDealerNumber);
            this.Controls.Add(this.txtDealerAddress);
            this.Controls.Add(this.lblDealerAddress);
            this.Controls.Add(this.txtDealerName);
            this.Controls.Add(this.lblDealerName);
            this.Controls.Add(this.lblDealerHeader);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDealerAddMod";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmDealerAddMod_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtDealerName;
        private System.Windows.Forms.Label lblDealerName;
        private System.Windows.Forms.Label lblDealerHeader;
        private System.Windows.Forms.TextBox txtDealerAddress;
        private System.Windows.Forms.Label lblDealerAddress;
        private System.Windows.Forms.Label lblDealerNumber;
        private Controls.NumericTextBox txtDealerNumber;
    }
}