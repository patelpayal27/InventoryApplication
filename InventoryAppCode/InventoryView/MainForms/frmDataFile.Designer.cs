namespace InventoryView
{
    partial class frmDataFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDataFile));
            this.rdb_Old = new System.Windows.Forms.RadioButton();
            this.rdb_New = new System.Windows.Forms.RadioButton();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblDealerHeader = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rdb_Old
            // 
            this.rdb_Old.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rdb_Old.AutoSize = true;
            this.rdb_Old.Location = new System.Drawing.Point(51, 106);
            this.rdb_Old.Name = "rdb_Old";
            this.rdb_Old.Size = new System.Drawing.Size(125, 22);
            this.rdb_Old.TabIndex = 0;
            this.rdb_Old.TabStop = true;
            this.rdb_Old.Text = "Import Data File";
            this.rdb_Old.UseVisualStyleBackColor = true;
            // 
            // rdb_New
            // 
            this.rdb_New.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rdb_New.AutoSize = true;
            this.rdb_New.Location = new System.Drawing.Point(51, 134);
            this.rdb_New.Name = "rdb_New";
            this.rdb_New.Size = new System.Drawing.Size(154, 22);
            this.rdb_New.TabIndex = 1;
            this.rdb_New.TabStop = true;
            this.rdb_New.Text = "Create New Data File";
            this.rdb_New.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(175, 180);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 27;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSubmit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSubmit.BackgroundImage")));
            this.btnSubmit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSubmit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Location = new System.Drawing.Point(136, 180);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(30, 30);
            this.btnSubmit.TabIndex = 26;
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblDealerHeader
            // 
            this.lblDealerHeader.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDealerHeader.AutoSize = true;
            this.lblDealerHeader.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDealerHeader.Location = new System.Drawing.Point(12, 9);
            this.lblDealerHeader.Name = "lblDealerHeader";
            this.lblDealerHeader.Size = new System.Drawing.Size(206, 66);
            this.lblDealerHeader.TabIndex = 28;
            this.lblDealerHeader.Text = "Data File Not Present.\r\nImport Your Old Data File \r\nOr Create New Data File.";
            // 
            // frmDataFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(258, 229);
            this.ControlBox = false;
            this.Controls.Add(this.lblDealerHeader);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.rdb_New);
            this.Controls.Add(this.rdb_Old);
            this.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDataFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdb_Old;
        private System.Windows.Forms.RadioButton rdb_New;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblDealerHeader;
    }
}