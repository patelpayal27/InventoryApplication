namespace InventoryView
{
    partial class frmBrandAddMod
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBrandAddMod));
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblBrandHeader = new System.Windows.Forms.Label();
            this.lblCatName = new System.Windows.Forms.Label();
            this.txtBrandName = new System.Windows.Forms.TextBox();
            this.lblBrandName = new System.Windows.Forms.Label();
            this.LstBxCategory = new System.Windows.Forms.CheckedListBox();
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
            this.btnSubmit.Location = new System.Drawing.Point(25, 199);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(35, 35);
            this.btnSubmit.TabIndex = 3;
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
            this.btnClose.Location = new System.Drawing.Point(327, 199);
            this.btnClose.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 35);
            this.btnClose.TabIndex = 4;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblBrandHeader
            // 
            this.lblBrandHeader.AutoSize = true;
            this.lblBrandHeader.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrandHeader.Location = new System.Drawing.Point(21, 14);
            this.lblBrandHeader.Name = "lblBrandHeader";
            this.lblBrandHeader.Size = new System.Drawing.Size(99, 22);
            this.lblBrandHeader.TabIndex = 15;
            this.lblBrandHeader.Text = "Add Brand :";
            // 
            // lblCatName
            // 
            this.lblCatName.AutoSize = true;
            this.lblCatName.Location = new System.Drawing.Point(22, 90);
            this.lblCatName.Name = "lblCatName";
            this.lblCatName.Size = new System.Drawing.Size(72, 18);
            this.lblCatName.TabIndex = 17;
            this.lblCatName.Text = "Categories";
            // 
            // txtBrandName
            // 
            this.txtBrandName.Location = new System.Drawing.Point(113, 53);
            this.txtBrandName.MaxLength = 200;
            this.txtBrandName.Name = "txtBrandName";
            this.txtBrandName.Size = new System.Drawing.Size(249, 23);
            this.txtBrandName.TabIndex = 1;
            // 
            // lblBrandName
            // 
            this.lblBrandName.AutoSize = true;
            this.lblBrandName.Location = new System.Drawing.Point(22, 56);
            this.lblBrandName.Name = "lblBrandName";
            this.lblBrandName.Size = new System.Drawing.Size(83, 18);
            this.lblBrandName.TabIndex = 18;
            this.lblBrandName.Text = "Brand Name";
            // 
            // LstBxCategory
            // 
            this.LstBxCategory.FormattingEnabled = true;
            this.LstBxCategory.Location = new System.Drawing.Point(113, 90);
            this.LstBxCategory.Name = "LstBxCategory";
            this.LstBxCategory.Size = new System.Drawing.Size(249, 94);
            this.LstBxCategory.TabIndex = 2;
            this.LstBxCategory.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.LstBxCategory_ItemCheck);
            // 
            // frmBrandAddMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(389, 249);
            this.ControlBox = false;
            this.Controls.Add(this.LstBxCategory);
            this.Controls.Add(this.txtBrandName);
            this.Controls.Add(this.lblBrandName);
            this.Controls.Add(this.lblCatName);
            this.Controls.Add(this.lblBrandHeader);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmBrandAddMod";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmBrandAddMod_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblBrandHeader;
        private System.Windows.Forms.Label lblCatName;
        private System.Windows.Forms.TextBox txtBrandName;
        private System.Windows.Forms.Label lblBrandName;
        private System.Windows.Forms.CheckedListBox LstBxCategory;
    }
}