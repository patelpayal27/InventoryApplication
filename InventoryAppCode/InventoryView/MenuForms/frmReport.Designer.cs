namespace InventoryView
{
    partial class frmReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReport));
            this.cmbReports = new System.Windows.Forms.ComboBox();
            this.lblReportFor = new System.Windows.Forms.Label();
            this.lblHeaderReport = new System.Windows.Forms.Label();
            this.grdReportData = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPdf = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.toolTipCat = new System.Windows.Forms.ToolTip(this.components);
            this.btnViewReport = new System.Windows.Forms.Button();
            this.btnShowData = new System.Windows.Forms.Button();
            this.dtpSellToDate = new System.Windows.Forms.DateTimePicker();
            this.lblSellToDate = new System.Windows.Forms.Label();
            this.dtpSellFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblSellFromDate = new System.Windows.Forms.Label();
            this.dtpBuyToDate = new System.Windows.Forms.DateTimePicker();
            this.lblBuyToDate = new System.Windows.Forms.Label();
            this.dtpBuyFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblBuyFromDate = new System.Windows.Forms.Label();
            this.UserDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.grdReportData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserDataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbReports
            // 
            this.cmbReports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReports.FormattingEnabled = true;
            this.cmbReports.Location = new System.Drawing.Point(163, 42);
            this.cmbReports.Name = "cmbReports";
            this.cmbReports.Size = new System.Drawing.Size(219, 26);
            this.cmbReports.TabIndex = 1;
            this.cmbReports.SelectedIndexChanged += new System.EventHandler(this.cmbReports_SelectedIndexChanged);
            // 
            // lblReportFor
            // 
            this.lblReportFor.AutoSize = true;
            this.lblReportFor.Location = new System.Drawing.Point(27, 44);
            this.lblReportFor.Name = "lblReportFor";
            this.lblReportFor.Size = new System.Drawing.Size(87, 18);
            this.lblReportFor.TabIndex = 51;
            this.lblReportFor.Text = "Report For : ";
            // 
            // lblHeaderReport
            // 
            this.lblHeaderReport.AutoSize = true;
            this.lblHeaderReport.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderReport.Location = new System.Drawing.Point(23, 7);
            this.lblHeaderReport.Name = "lblHeaderReport";
            this.lblHeaderReport.Size = new System.Drawing.Size(101, 27);
            this.lblHeaderReport.TabIndex = 50;
            this.lblHeaderReport.Text = "Reports :";
            // 
            // grdReportData
            // 
            this.grdReportData.AllowUserToAddRows = false;
            this.grdReportData.AllowUserToDeleteRows = false;
            this.grdReportData.AllowUserToResizeColumns = false;
            this.grdReportData.AllowUserToResizeRows = false;
            this.grdReportData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.grdReportData.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grdReportData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.grdReportData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdReportData.GridColor = System.Drawing.Color.White;
            this.grdReportData.Location = new System.Drawing.Point(28, 133);
            this.grdReportData.MultiSelect = false;
            this.grdReportData.Name = "grdReportData";
            this.grdReportData.ReadOnly = true;
            this.grdReportData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdReportData.Size = new System.Drawing.Size(727, 369);
            this.grdReportData.TabIndex = 55;
            this.grdReportData.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(720, 513);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 35);
            this.btnClose.TabIndex = 7;
            this.toolTipCat.SetToolTip(this.btnClose, "Close Reports");
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPdf
            // 
            this.btnPdf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPdf.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPdf.BackgroundImage")));
            this.btnPdf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPdf.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnPdf.FlatAppearance.BorderSize = 0;
            this.btnPdf.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPdf.Location = new System.Drawing.Point(129, 513);
            this.btnPdf.Name = "btnPdf";
            this.btnPdf.Size = new System.Drawing.Size(35, 35);
            this.btnPdf.TabIndex = 5;
            this.toolTipCat.SetToolTip(this.btnPdf, "Save Data In PDF");
            this.btnPdf.UseVisualStyleBackColor = true;
            this.btnPdf.Visible = false;
            this.btnPdf.Click += new System.EventHandler(this.btnPdf_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExcel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExcel.BackgroundImage")));
            this.btnExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExcel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnExcel.FlatAppearance.BorderSize = 0;
            this.btnExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Location = new System.Drawing.Point(177, 513);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(35, 35);
            this.btnExcel.TabIndex = 6;
            this.toolTipCat.SetToolTip(this.btnExcel, "Save Data In Excel");
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Visible = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(673, 513);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(9, 11, 9, 11);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(35, 35);
            this.btnSearch.TabIndex = 4;
            this.toolTipCat.SetToolTip(this.btnSearch, "Search");
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Visible = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnViewReport
            // 
            this.btnViewReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnViewReport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnViewReport.BackgroundImage")));
            this.btnViewReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnViewReport.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnViewReport.FlatAppearance.BorderSize = 0;
            this.btnViewReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnViewReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewReport.Location = new System.Drawing.Point(31, 513);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(35, 35);
            this.btnViewReport.TabIndex = 65;
            this.toolTipCat.SetToolTip(this.btnViewReport, "View Report");
            this.btnViewReport.UseVisualStyleBackColor = true;
            this.btnViewReport.LocationChanged += new System.EventHandler(this.btnViewReport_LocationChanged);
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // btnShowData
            // 
            this.btnShowData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnShowData.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnShowData.BackgroundImage")));
            this.btnShowData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnShowData.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnShowData.FlatAppearance.BorderSize = 0;
            this.btnShowData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnShowData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowData.Location = new System.Drawing.Point(79, 513);
            this.btnShowData.Name = "btnShowData";
            this.btnShowData.Size = new System.Drawing.Size(35, 35);
            this.btnShowData.TabIndex = 66;
            this.toolTipCat.SetToolTip(this.btnShowData, "View Data");
            this.btnShowData.UseVisualStyleBackColor = true;
            this.btnShowData.Click += new System.EventHandler(this.btnShowData_Click);
            // 
            // dtpSellToDate
            // 
            this.dtpSellToDate.Location = new System.Drawing.Point(536, 104);
            this.dtpSellToDate.Name = "dtpSellToDate";
            this.dtpSellToDate.Size = new System.Drawing.Size(219, 23);
            this.dtpSellToDate.TabIndex = 59;
            this.dtpSellToDate.ValueChanged += new System.EventHandler(this.dtpSellToDate_ValueChanged);
            this.dtpSellToDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpSellToDate_KeyDown);
            // 
            // lblSellToDate
            // 
            this.lblSellToDate.AutoSize = true;
            this.lblSellToDate.Location = new System.Drawing.Point(435, 105);
            this.lblSellToDate.Name = "lblSellToDate";
            this.lblSellToDate.Size = new System.Drawing.Size(80, 18);
            this.lblSellToDate.TabIndex = 63;
            this.lblSellToDate.Text = "Sell To Date";
            // 
            // dtpSellFromDate
            // 
            this.dtpSellFromDate.Location = new System.Drawing.Point(163, 104);
            this.dtpSellFromDate.Name = "dtpSellFromDate";
            this.dtpSellFromDate.Size = new System.Drawing.Size(219, 23);
            this.dtpSellFromDate.TabIndex = 58;
            this.dtpSellFromDate.ValueChanged += new System.EventHandler(this.dtpSellFromDate_ValueChanged);
            this.dtpSellFromDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpSellFromDate_KeyDown);
            // 
            // lblSellFromDate
            // 
            this.lblSellFromDate.AutoSize = true;
            this.lblSellFromDate.Location = new System.Drawing.Point(26, 104);
            this.lblSellFromDate.Name = "lblSellFromDate";
            this.lblSellFromDate.Size = new System.Drawing.Size(97, 18);
            this.lblSellFromDate.TabIndex = 62;
            this.lblSellFromDate.Text = "Sell From Date";
            // 
            // dtpBuyToDate
            // 
            this.dtpBuyToDate.Location = new System.Drawing.Point(536, 75);
            this.dtpBuyToDate.Name = "dtpBuyToDate";
            this.dtpBuyToDate.Size = new System.Drawing.Size(219, 23);
            this.dtpBuyToDate.TabIndex = 57;
            this.dtpBuyToDate.ValueChanged += new System.EventHandler(this.dtpBuyToDate_ValueChanged);
            this.dtpBuyToDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpBuyToDate_KeyDown);
            // 
            // lblBuyToDate
            // 
            this.lblBuyToDate.AutoSize = true;
            this.lblBuyToDate.Location = new System.Drawing.Point(434, 78);
            this.lblBuyToDate.Name = "lblBuyToDate";
            this.lblBuyToDate.Size = new System.Drawing.Size(81, 18);
            this.lblBuyToDate.TabIndex = 61;
            this.lblBuyToDate.Text = "Buy To Date";
            // 
            // dtpBuyFromDate
            // 
            this.dtpBuyFromDate.Location = new System.Drawing.Point(163, 75);
            this.dtpBuyFromDate.Name = "dtpBuyFromDate";
            this.dtpBuyFromDate.Size = new System.Drawing.Size(219, 23);
            this.dtpBuyFromDate.TabIndex = 56;
            this.dtpBuyFromDate.ValueChanged += new System.EventHandler(this.dtpBuyFromDate_ValueChanged);
            this.dtpBuyFromDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpBuyFromDate_KeyDown);
            // 
            // lblBuyFromDate
            // 
            this.lblBuyFromDate.AutoSize = true;
            this.lblBuyFromDate.Location = new System.Drawing.Point(26, 75);
            this.lblBuyFromDate.Name = "lblBuyFromDate";
            this.lblBuyFromDate.Size = new System.Drawing.Size(98, 18);
            this.lblBuyFromDate.TabIndex = 60;
            this.lblBuyFromDate.Text = "Buy From Date";
            // 
            // UserDataBindingSource
            // 
            this.UserDataBindingSource.DataMember = "UserData";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(28, 133);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(727, 332);
            this.reportViewer1.TabIndex = 64;
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(774, 560);
            this.ControlBox = false;
            this.Controls.Add(this.btnViewReport);
            this.Controls.Add(this.btnShowData);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.dtpSellToDate);
            this.Controls.Add(this.lblSellToDate);
            this.Controls.Add(this.dtpSellFromDate);
            this.Controls.Add(this.lblSellFromDate);
            this.Controls.Add(this.dtpBuyToDate);
            this.Controls.Add(this.lblBuyToDate);
            this.Controls.Add(this.dtpBuyFromDate);
            this.Controls.Add(this.lblBuyFromDate);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPdf);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.grdReportData);
            this.Controls.Add(this.cmbReports);
            this.Controls.Add(this.lblReportFor);
            this.Controls.Add(this.lblHeaderReport);
            this.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReport";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.frmReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdReportData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserDataBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbReports;
        private System.Windows.Forms.Label lblReportFor;
        private System.Windows.Forms.Label lblHeaderReport;
        private System.Windows.Forms.DataGridView grdReportData;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPdf;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ToolTip toolTipCat;
        private System.Windows.Forms.DateTimePicker dtpSellToDate;
        private System.Windows.Forms.Label lblSellToDate;
        private System.Windows.Forms.DateTimePicker dtpSellFromDate;
        private System.Windows.Forms.Label lblSellFromDate;
        private System.Windows.Forms.DateTimePicker dtpBuyToDate;
        private System.Windows.Forms.Label lblBuyToDate;
        private System.Windows.Forms.DateTimePicker dtpBuyFromDate;
        private System.Windows.Forms.Label lblBuyFromDate;
        private System.Windows.Forms.BindingSource UserDataBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button btnViewReport;
        private System.Windows.Forms.Button btnShowData;
    }
}