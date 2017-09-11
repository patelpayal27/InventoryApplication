namespace InventoryActivationKey
{
    partial class frmMain
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
            this.lblActiveKey = new System.Windows.Forms.Label();
            this.txtActiveKey = new System.Windows.Forms.TextBox();
            this.lblMAC = new System.Windows.Forms.Label();
            this.txtMAC = new System.Windows.Forms.TextBox();
            this.btnGenerateKey = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblActiveKey
            // 
            this.lblActiveKey.AutoSize = true;
            this.lblActiveKey.Location = new System.Drawing.Point(19, 100);
            this.lblActiveKey.Name = "lblActiveKey";
            this.lblActiveKey.Size = new System.Drawing.Size(75, 13);
            this.lblActiveKey.TabIndex = 9;
            this.lblActiveKey.Text = "Activation Key";
            // 
            // txtActiveKey
            // 
            this.txtActiveKey.Location = new System.Drawing.Point(132, 97);
            this.txtActiveKey.Name = "txtActiveKey";
            this.txtActiveKey.Size = new System.Drawing.Size(196, 20);
            this.txtActiveKey.TabIndex = 8;
            // 
            // lblMAC
            // 
            this.lblMAC.AutoSize = true;
            this.lblMAC.Location = new System.Drawing.Point(19, 27);
            this.lblMAC.Name = "lblMAC";
            this.lblMAC.Size = new System.Drawing.Size(99, 13);
            this.lblMAC.TabIndex = 7;
            this.lblMAC.Text = "Enter MAC Address";
            // 
            // txtMAC
            // 
            this.txtMAC.Location = new System.Drawing.Point(132, 24);
            this.txtMAC.Name = "txtMAC";
            this.txtMAC.Size = new System.Drawing.Size(196, 20);
            this.txtMAC.TabIndex = 5;
            // 
            // btnGenerateKey
            // 
            this.btnGenerateKey.Location = new System.Drawing.Point(132, 57);
            this.btnGenerateKey.Name = "btnGenerateKey";
            this.btnGenerateKey.Size = new System.Drawing.Size(196, 23);
            this.btnGenerateKey.TabIndex = 6;
            this.btnGenerateKey.Text = "Generate Activation Key";
            this.btnGenerateKey.UseVisualStyleBackColor = true;
            this.btnGenerateKey.Click += new System.EventHandler(this.btnGenerateKey_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 147);
            this.Controls.Add(this.lblActiveKey);
            this.Controls.Add(this.txtActiveKey);
            this.Controls.Add(this.lblMAC);
            this.Controls.Add(this.txtMAC);
            this.Controls.Add(this.btnGenerateKey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory Activation Key";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblActiveKey;
        private System.Windows.Forms.TextBox txtActiveKey;
        private System.Windows.Forms.Label lblMAC;
        private System.Windows.Forms.TextBox txtMAC;
        private System.Windows.Forms.Button btnGenerateKey;
    }
}