namespace InventoryView
{
    partial class frmReportViewer
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.UserDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.UsersDataSet = new InventoryView.UsersDataSet();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.UserDataTableAdapter = new InventoryView.UsersDataSetTableAdapters.UserDataTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.UserDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsersDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // UserDataBindingSource
            // 
            this.UserDataBindingSource.DataMember = "UserData";
            this.UserDataBindingSource.DataSource = this.UsersDataSet;
            // 
            // UsersDataSet
            // 
            this.UsersDataSet.DataSetName = "UsersDataSet";
            this.UsersDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.UserDataBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "InventoryView.RDLC_Reports.rdlcUserData.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(2, 2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(726, 587);
            this.reportViewer1.TabIndex = 0;
            // 
            // UserDataTableAdapter
            // 
            this.UserDataTableAdapter.ClearBeforeFill = true;
            // 
            // frmReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 594);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReportViewer";
            this.Text = "frmReportViewer";
            this.Load += new System.EventHandler(this.frmReportViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UserDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsersDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource UserDataBindingSource;
        private UsersDataSet UsersDataSet;
        private UsersDataSetTableAdapters.UserDataTableAdapter UserDataTableAdapter;
    }
}