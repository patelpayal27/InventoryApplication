using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InventoryModel.Classes;
using Microsoft.Reporting.WinForms;

namespace InventoryView
{
    public partial class frmReportViewer : Form
    {
        public frmReportViewer()
        {
            InitializeComponent();
        }

        private void frmReportViewer_Load(object sender, EventArgs e)
        {
            Datasets objDatasets = new Datasets();
            ReportParameter[] allPar = new ReportParameter[1]; // create parameters array
            ReportParameter parSum = new ReportParameter("Date", System.DateTime.Now.ToString());
            allPar[0] = parSum;

            DataSet ds = new DataSet();
            ds = objDatasets.GetUserDataset(0, false);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);
            }
            reportViewer1.LocalReport.SetParameters(allPar); // set parameter array
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            this.reportViewer1.ZoomMode = ZoomMode.PageWidth;
            this.reportViewer1.RefreshReport();
        }
    }
}
