using InventoryModel.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DocumentFormat.OpenXml.Packaging;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.Reporting.WinForms;

namespace InventoryView
{
    public partial class frmReport : Form
    {
        string ReportType = string.Empty;
        string DateField = string.Empty;
        string Flag = string.Empty;
        SearchCriteria SearchCri = null;
        CategoriesT CatObj = null;
        BrandsT BrandObj = null;
        DealerT DealerObj = null;
        ItemDataT Itemobj = null;
        UserDataT Userobj = null;
        List<Categories> lstCategories = null;
        List<Brands> lstBrands = null;
        List<Dealers> lstDealers = null;
        List<ItemData> lstItems = null;
        List<UserData> lstUsers = null;

        public frmReport()
        {
            InitializeComponent();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            try
            {
                FillReportCmb();
                dtpBuyFromDate.Format = DateTimePickerFormat.Custom;
                dtpBuyFromDate.CustomFormat = "-- SELECT DATE --";
                dtpBuyToDate.Format = DateTimePickerFormat.Custom;
                dtpBuyToDate.CustomFormat = "-- SELECT DATE --";
                dtpSellFromDate.Format = DateTimePickerFormat.Custom;
                dtpSellFromDate.CustomFormat = "-- SELECT DATE --";
                dtpSellToDate.Format = DateTimePickerFormat.Custom;
                dtpSellToDate.CustomFormat = "-- SELECT DATE --";
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmReport_Load, Ex - " + ex.Message.ToString());
            }
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

        private void FillReportCmb()
        {
            try
            {
                cmbReports.Items.Add("Items");
                cmbReports.Items.Add("Categories");
                cmbReports.Items.Add("Brands");
                cmbReports.Items.Add("Dealers");
                //cmbReports.Items.Add("Users");
                cmbReports.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("FillReportCmb, Ex - " + ex.Message.ToString());
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShowData_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbReports.SelectedIndex >= 0)
                {
                    grdReportData.Visible = true;
                    reportViewer1.Visible = false;
                    ReportType = cmbReports.Text;
                    LoadDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnSearch_Click, Ex - " + ex.Message.ToString());
            }
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            try
            {
                //frmReportViewer frm = new frmReportViewer();
                //frm.ShowDialog();
                btnViewReport.Enabled = false;
                Cursor.Current = Cursors.WaitCursor;

                string Error = string.Empty;
                switch (cmbReports.Text)
                {
                    case "Items":
                        {
                            FillSearchCriObj();
                            if (Validation())
                            {
                                BindItemsReport(ref Error);
                            }
                            break;
                        }
                    case "Categories":
                        BindCatReport(ref Error);
                        break;
                    case "Brands":
                        BindBrandsReport(ref Error);
                        break;
                    case "Dealers":
                        BindDealersReport(ref Error);
                        break;
                    case "Users":
                        BindUserReport(ref Error);
                        break;
                    default:
                        return;
                }
                if (Error == "")
                {
                    grdReportData.Visible = false;
                    reportViewer1.Visible = true;
                }
                else
                {
                    grdReportData.Visible = true;
                    reportViewer1.Visible = false;
                    MessageBox.Show(Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnViewReport_Click, Ex - " + ex.Message.ToString());
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                btnViewReport.Enabled = true;
            }
        }

        private void btnViewReport_LocationChanged(object sender, EventArgs e)
        {
            int yloc = btnPdf.Location.Y;
            int w = reportViewer1.Size.Width;
            int h = yloc - 150;
            grdReportData.Size = new Size(w, h);
            reportViewer1.Size = new Size(w, h);
        }

        private void cmbReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                grdReportData.DataSource = null;
                if (cmbReports.SelectedIndex > 0)
                    EnableDisableDates(false);
                else
                    EnableDisableDates(true);

                grdReportData.Visible = true;
                reportViewer1.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("cmbReports_SelectedIndexChanged, Ex - " + ex.Message.ToString());
            }
        }

        private void LoadDataGrid()
        {
            try
            {
                if (ReportType == "Categories")
                {
                    CatObj = new CategoriesT();
                    lstCategories = new List<Categories>();
                    lstCategories = CatObj.GetCategories(0, false);
                    grdReportData.DataSource = null;
                    grdReportData.DataSource = lstCategories;
                }
                else if (ReportType == "Brands")
                {
                    BrandObj = new BrandsT();
                    lstBrands = new List<Brands>();
                    lstBrands = BrandObj.GetBrands(0, false);
                    grdReportData.DataSource = null;

                    DataTable table = new DataTable();
                    table.Columns.Add("Brand ID", typeof(string));
                    table.Columns.Add("Brand Name", typeof(string));
                    table.Columns.Add("Category Name", typeof(string));
                    table.Columns.Add("Category Id", typeof(string));

                    foreach (Brands a in lstBrands)
                    {
                        table.Rows.Add(a.BrandID, a.BrandName, BrandObj.GetCategoryByBrand(a.BrandID, false), BrandObj.GetCategoryIdByBrand(a.BrandID, false));
                    }
                    grdReportData.DataSource = table;
                    grdReportData.Columns[3].Visible = false;
                }
                else if (ReportType == "Dealers")
                {
                    DealerObj = new DealerT();
                    lstDealers = new List<Dealers>();
                    lstDealers = DealerObj.GetDealer(0, false);
                    grdReportData.DataSource = null;
                    grdReportData.DataSource = lstDealers;
                }
                else if (ReportType == "Items")
                {
                    FillSearchCriObj();
                    Itemobj = new ItemDataT();
                    lstItems = new List<ItemData>();
                    //lstItems = Itemobj.GetItem(0, false);
                    lstItems = Itemobj.GetItemData(0, false, SearchCri);
                    grdReportData.DataSource = null;
                    grdReportData.DataSource = lstItems;
                    grdReportData.Columns["CatID"].Visible = false;
                    grdReportData.Columns["BrandID"].Visible = false;
                    grdReportData.Columns["DealerID"].Visible = false;
                }
                else if (ReportType == "Users")
                {
                    Userobj = new UserDataT();
                    lstUsers = new List<UserData>();
                    lstUsers = Userobj.GetUser(0, false);
                    grdReportData.DataSource = null;
                    grdReportData.DataSource = lstUsers;
                    grdReportData.Columns["ID"].Visible = false;
                }
                grdReportData_Resize();
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadDataGrid, Ex - " + ex.Message.ToString());
            }
        }

        private void grdReportData_Resize()
        {
            int width = this.grdReportData.RowHeadersWidth;
            foreach (DataGridViewColumn col in this.grdReportData.Columns)
            {
                //col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                width += col.Width;
            }
            if (width < this.grdReportData.Width)
            {
                this.grdReportData.Columns[this.grdReportData.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void BindItemsReport(ref string Error)
        {
            try
            {
                string FromDate = string.Empty;
                string ToDate = string.Empty;

                if (DateField.ToUpper() == "ALL")
                {
                    FromDate = ToDate = System.DateTime.Now.ToString("dd-MMM-yyyy");
                }
                else if (DateField.ToUpper() == "BUY")
                {
                    FromDate = SearchCri.BuyFromDate.ToString("dd-MMM-yyyy");
                    ToDate = SearchCri.BuyToDate.ToString("dd-MMM-yyyy");
                }
                else if (DateField.ToUpper() == "SELL")
                {
                    FromDate = SearchCri.SellFromDate.ToString("dd-MMM-yyyy");
                    ToDate = SearchCri.SellToDate.ToString("dd-MMM-yyyy");
                }

                System.Drawing.Printing.PageSettings ps = new System.Drawing.Printing.PageSettings();
                ps.Landscape = true;
                ps.PaperSize.RawKind = (int)System.Drawing.Printing.PaperKind.A4;
                ps.Margins = new System.Drawing.Printing.Margins(0, 0, 25, 25);
                reportViewer1.SetPageSettings(ps);

                reportViewer1.LocalReport.ReportEmbeddedResource = "InventoryView.RDLC_Reports.rdlcItems.rdlc";
                reportViewer1.LocalReport.Refresh();
                reportViewer1.RefreshReport();

                Datasets objDatasets = new Datasets();
                ReportParameter[] allPar = new ReportParameter[5]; // create parameters array PrintDate
                ReportParameter parFromDate = new ReportParameter("FromDate", FromDate);
                ReportParameter parToDate = new ReportParameter("ToDate", ToDate);
                ReportParameter parPrintDate = new ReportParameter("PrintDate", System.DateTime.Now.ToString());
                ReportParameter parDateField = new ReportParameter("DateField", DateField);
                ReportParameter parFlag = new ReportParameter("Flag", Flag);
                allPar[0] = parFromDate;
                allPar[1] = parToDate;
                allPar[2] = parPrintDate;
                allPar[3] = parDateField;
                allPar[4] = parFlag;

                DataSet ds = new DataSet();
                ds = objDatasets.GetItemDataset(0, false, SearchCri);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(rds);
                }
                else
                {
                    Error = "No Record Present";
                    return;
                }

                reportViewer1.LocalReport.SetParameters(allPar); // set parameter array
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.PageWidth;
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("BindItemsReport, Ex - " + ex.Message.ToString());
            }
        }

        private void BindCatReport(ref string Error)
        {
            try
            {
                System.Drawing.Printing.PageSettings ps = new System.Drawing.Printing.PageSettings();
                ps.Landscape = false;
                ps.PaperSize.RawKind = (int)System.Drawing.Printing.PaperKind.A4;
                ps.Margins = new System.Drawing.Printing.Margins(50, 50, 50, 50);
                reportViewer1.SetPageSettings(ps);

                reportViewer1.LocalReport.ReportEmbeddedResource = "InventoryView.RDLC_Reports.rdlcCategories.rdlc";
                reportViewer1.LocalReport.Refresh();
                reportViewer1.RefreshReport();

                Datasets objDatasets = new Datasets();
                ReportParameter[] allPar = new ReportParameter[2]; // create parameters array PrintDate
                ReportParameter parDate = new ReportParameter("Date", System.DateTime.Now.ToString("dd-MMM-yyyy"));
                ReportParameter parPrintDate = new ReportParameter("PrintDate", System.DateTime.Now.ToString());
                allPar[0] = parDate;
                allPar[1] = parPrintDate;

                DataSet ds = new DataSet();
                ds = objDatasets.GetCategorieDataset(0, false);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(rds);
                }
                else
                {
                    Error = "No Record Present";
                    return;
                }

                reportViewer1.LocalReport.SetParameters(allPar); // set parameter array
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.PageWidth;
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("BindCatReport, Ex - " + ex.Message.ToString());
            }
        }

        private void BindBrandsReport(ref string Error)
        {
            try
            {
                System.Drawing.Printing.PageSettings ps = new System.Drawing.Printing.PageSettings();
                ps.Landscape = false;
                ps.PaperSize.RawKind = (int)System.Drawing.Printing.PaperKind.A4;
                ps.Margins = new System.Drawing.Printing.Margins(50, 50, 50, 50);
                reportViewer1.SetPageSettings(ps);

                reportViewer1.LocalReport.ReportEmbeddedResource = "InventoryView.RDLC_Reports.rdlcBrands.rdlc";
                reportViewer1.LocalReport.Refresh();
                reportViewer1.RefreshReport();

                Datasets objDatasets = new Datasets();
                ReportParameter[] allPar = new ReportParameter[2]; // create parameters array PrintDate
                ReportParameter parDate = new ReportParameter("Date", System.DateTime.Now.ToString("dd-MMM-yyyy"));
                ReportParameter parPrintDate = new ReportParameter("PrintDate", System.DateTime.Now.ToString());
                allPar[0] = parDate;
                allPar[1] = parPrintDate;

                DataSet ds = new DataSet();
                ds = objDatasets.GetBrandsDataset(0, false);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(rds);
                }
                else
                {
                    Error = "No Record Present";
                    return;
                }
                reportViewer1.LocalReport.SetParameters(allPar); // set parameter array
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.PageWidth;
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("BindBrandsReport, Ex - " + ex.Message.ToString());
            }
        }

        private void BindDealersReport(ref string Error)
        {
            try
            {
                System.Drawing.Printing.PageSettings ps = new System.Drawing.Printing.PageSettings();
                ps.Landscape = false;
                ps.PaperSize.RawKind = (int)System.Drawing.Printing.PaperKind.A4;
                ps.Margins = new System.Drawing.Printing.Margins(50, 50, 50, 50);
                reportViewer1.SetPageSettings(ps);

                reportViewer1.LocalReport.ReportEmbeddedResource = "InventoryView.RDLC_Reports.rdlcDealers.rdlc";
                reportViewer1.LocalReport.Refresh();
                reportViewer1.RefreshReport();

                Datasets objDatasets = new Datasets();
                ReportParameter[] allPar = new ReportParameter[2]; // create parameters array PrintDate
                ReportParameter parDate = new ReportParameter("Date", System.DateTime.Now.ToString("dd-MMM-yyyy"));
                ReportParameter parPrintDate = new ReportParameter("PrintDate", System.DateTime.Now.ToString());
                allPar[0] = parDate;
                allPar[1] = parPrintDate;

                DataSet ds = new DataSet();
                ds = objDatasets.GetDealerDataset(0, false);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(rds);
                }
                else
                {
                    Error = "No Record Present";
                    return;
                }
                reportViewer1.LocalReport.SetParameters(allPar); // set parameter array
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.PageWidth;
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("BindDealersReport, Ex - " + ex.Message.ToString());
            }
        }

        private void BindUserReport(ref string Error)
        {
            try
            {
                System.Drawing.Printing.PageSettings ps = new System.Drawing.Printing.PageSettings();
                ps.Landscape = false;
                ps.PaperSize.RawKind = (int)System.Drawing.Printing.PaperKind.A4;
                ps.Margins = new System.Drawing.Printing.Margins(50, 50, 50, 50);
                reportViewer1.SetPageSettings(ps);

                //reportViewer1.PrinterSettings.DefaultPageSettings.Landscape = false;

                reportViewer1.LocalReport.ReportEmbeddedResource = "InventoryView.RDLC_Reports.rdlcUserData.rdlc";
                reportViewer1.LocalReport.Refresh();
                reportViewer1.RefreshReport();

                Datasets objDatasets = new Datasets();
                ReportParameter[] allPar = new ReportParameter[2]; // create parameters array PrintDate
                ReportParameter parDate = new ReportParameter("Date", System.DateTime.Now.ToString("dd-MMM-yyyy"));
                ReportParameter parPrintDate = new ReportParameter("PrintDate", System.DateTime.Now.ToString());
                allPar[0] = parDate;
                allPar[1] = parPrintDate;

                DataSet ds = new DataSet();
                ds = objDatasets.GetUserDataset(0, false);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(rds);
                }
                else
                {
                    Error = "No Record Present";
                    return;
                }
                reportViewer1.LocalReport.SetParameters(allPar); // set parameter array
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.PageWidth;
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("BindUserReport, Ex - " + ex.Message.ToString());
            }
        }

        private void FillSearchCriObj()
        {
            try
            {
                SearchCri = new SearchCriteria();
                if (dtpBuyFromDate.Enabled)
                {
                    if (dtpBuyFromDate.Format != DateTimePickerFormat.Custom)
                        SearchCri.BuyFromDate = Convert.ToDateTime(dtpBuyFromDate.Text);
                    if (dtpBuyToDate.Format != DateTimePickerFormat.Custom)
                        SearchCri.BuyToDate = Convert.ToDateTime(dtpBuyToDate.Text);
                    DateField = "Buy";
                }
                else if (dtpSellFromDate.Enabled)
                {
                    if (dtpSellFromDate.Format != DateTimePickerFormat.Custom)
                        SearchCri.SellFromDate = Convert.ToDateTime(dtpSellFromDate.Text);
                    if (dtpSellToDate.Format != DateTimePickerFormat.Custom)
                        SearchCri.SellToDate = Convert.ToDateTime(dtpSellToDate.Text);
                    DateField = "Sell";

                }
                if (dtpBuyFromDate.Format == DateTimePickerFormat.Custom && dtpBuyToDate.Format == DateTimePickerFormat.Custom && dtpSellFromDate.Format == DateTimePickerFormat.Custom && dtpSellToDate.Format == DateTimePickerFormat.Custom)
                {
                    SearchCri.ShowAll = "YES";
                    Flag = "2";
                    DateField = "All";
                }
                else
                {
                    Flag = "1";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("FillSearchCriObj, Ex - " + ex.Message.ToString());
            }
        }

        private bool Validation()
        {
            try
            {
                if (SearchCri.BuyFromDate.ToString("dd-MMM-yyyy") != "01-Jan-0001" && SearchCri.BuyToDate.ToString("dd-MMM-yyyy") == "01-Jan-0001")
                {
                    ShowMsg("Enter Buy To Date.", "BuyToDate");
                    return false;
                }
                else if (SearchCri.BuyFromDate.ToString("dd-MMM-yyyy") == "01-Jan-0001" && SearchCri.BuyToDate.ToString("dd-MMM-yyyy") != "01-Jan-0001")
                {
                    ShowMsg("Enter Buy From Date.", "BuyFromDate");
                    return false;
                }
                else if (SearchCri.BuyFromDate.ToString("dd-MMM-yyyy") != "01-Jan-0001" && SearchCri.BuyToDate.ToString("dd-MMM-yyyy") != "01-Jan-0001")
                {
                    if (SearchCri.BuyFromDate > SearchCri.BuyToDate)
                    {
                        ShowMsg("Buy From Date Cannot Be Greater Than Buy To Date.", "BuyFromDate");
                        return false;
                    }
                }
                else if (SearchCri.SellFromDate.ToString("dd-MMM-yyyy") == "01-Jan-0001" && SearchCri.SellToDate.ToString("dd-MMM-yyyy") != "01-Jan-0001")
                {
                    ShowMsg("Enter Sell To Date.", "SellToDate");
                    return false;
                }
                else if (SearchCri.SellFromDate.ToString("dd-MMM-yyyy") != "01-Jan-0001" && SearchCri.SellToDate.ToString("dd-MMM-yyyy") == "01-Jan-0001")
                {
                    ShowMsg("Enter Sell From Date.", "SellFromDate");
                    return false;
                }
                else if (SearchCri.SellFromDate.ToString("dd-MMM-yyyy") != "01-Jan-0001" && SearchCri.SellToDate.ToString("dd-MMM-yyyy") != "01-Jan-0001")
                {
                    if (SearchCri.SellFromDate > SearchCri.SellToDate)
                    {
                        ShowMsg("Sell From Date Cannot Be Greater Than Sell To Date.", "SellFromDate");
                        return false;
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void ShowMsg(string Msg, string FocusField)
        {
            MessageBox.Show(Msg);
            if (FocusField == "BuyFromDate")
                dtpBuyFromDate.Focus();
            else if (FocusField == "BuyToDate")
                dtpBuyToDate.Focus();
            else if (FocusField == "SellFromDate")
                dtpSellFromDate.Focus();
            else if (FocusField == "SellToDate")
                dtpSellToDate.Focus();
        }

        private void EnableDisableDates(bool Value)
        {
            dtpBuyFromDate.Enabled = Value;
            dtpBuyToDate.Enabled = Value;
            dtpSellFromDate.Enabled = Value;
            dtpSellToDate.Enabled = Value;
        }

        #region UnUsed Code - EXCEL and PDF Printing
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbReports.SelectedIndex >= 0)
                {
                    ReportType = cmbReports.Text;
                    LoadDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnSearch_Click, Ex - " + ex.Message.ToString());
            }
        }

        private void btnPdf_Click(object sender, EventArgs e)
        {
            try
            {
                //frmReportViewer frm = new frmReportViewer();
                //frm.ShowDialog();

                string Error = string.Empty;
                switch (cmbReports.Text)
                {
                    case "Items":
                        BindItemsReport(ref Error);
                        break;
                    case "Categories":
                        BindCatReport(ref Error);
                        break;
                    case "Brands":
                        BindBrandsReport(ref Error);
                        break;
                    case "Dealers":
                        BindDealersReport(ref Error);
                        break;
                    case "Users":
                        BindUserReport(ref Error);
                        break;
                    default:
                        return;
                }
                if (Error == "")
                {
                    grdReportData.Visible = false;
                    reportViewer1.Visible = true;
                }
                else
                {
                    grdReportData.Visible = true;
                    reportViewer1.Visible = false;
                    MessageBox.Show(Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnPdf_Click, Ex - " + ex.Message.ToString());
            }
        }

        private void btnPdf1_Click(object sender, EventArgs e)
        {
            try
            {
                string ExportToPath = string.Empty;
                string FileName = string.Empty;
                FolderBrowserDialog diaFolder = new FolderBrowserDialog();
                diaFolder.Description = "Select Folder To Save PDF File";
                if (diaFolder.ShowDialog() == DialogResult.OK)
                {
                    ExportToPath = diaFolder.SelectedPath;
                    FileName = cmbReports.Text + "_Report_" + System.DateTime.Now.ToString("ddMMyyyy") + ".pdf";

                    switch (cmbReports.Text)
                    {
                        case "Users":
                            {
                                CreateUserPdfDoc(lstUsers, ExportToPath + @"\" + FileName);
                                break;
                            }
                        default:
                            break;
                    }
                    MessageBox.Show("File Saved To : " + ExportToPath + "\nFile Name : " + FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnPdf_Click, Ex - " + ex.Message.ToString());
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string ExportToPath = string.Empty;
                string FileName = string.Empty;
                FolderBrowserDialog diaFolder = new FolderBrowserDialog();
                diaFolder.Description = "Select Folder To Save Excel File";
                if (diaFolder.ShowDialog() == DialogResult.OK)
                {
                    ExportToPath = diaFolder.SelectedPath;
                    FileName = cmbReports.Text + "_Report_" + System.DateTime.Now.ToString("ddMMyyyy") + ".xls";
                    DataSet ds = DataGridView2DataSet(grdReportData);
                    ExportDataSetToExcel(ds, ExportToPath + "\\" + FileName);
                    MessageBox.Show("File Saved To : " + ExportToPath + "\nFile Name : " + FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnExcel_Click, Ex - " + ex.Message.ToString());
            }
        }

        public DataSet DataGridView2DataSet(DataGridView dgv)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                // Header columns
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    DataColumn dc = new DataColumn(column.Name.ToString());
                    dt.Columns.Add(dc);
                }

                // Data cells
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    DataGridViewRow row = dgv.Rows[i];
                    DataRow dr = dt.NewRow();
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        dr[j] = (row.Cells[j].Value == null) ? "" : row.Cells[j].Value.ToString();
                    }
                    dt.Rows.Add(dr);
                }

                //// Related to the bug arround min size when using ExcelLibrary for export
                //for (int i = dgv.Rows.Count; i < minRow; i++)
                //{
                //    DataRow dr = dt.NewRow();
                //    for (int j = 0; j < dt.Columns.Count; j++)
                //    {
                //        dr[j] = "  ";
                //    }
                //    dt.Rows.Add(dr);
                //}
                ds.Tables.Add(dt);
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show("DataGridView2DataTable, Ex - " + ex.Message.ToString());
                return ds;
            }
        }

        private void ExportDataSetToExcel(DataSet ds, string destination)
        {
            try
            {
                using (var workbook = SpreadsheetDocument.Create(destination, DocumentFormat.OpenXml.SpreadsheetDocumentType.Workbook))
                {
                    var workbookPart = workbook.AddWorkbookPart();

                    workbook.WorkbookPart.Workbook = new DocumentFormat.OpenXml.Spreadsheet.Workbook();

                    workbook.WorkbookPart.Workbook.Sheets = new DocumentFormat.OpenXml.Spreadsheet.Sheets();

                    foreach (System.Data.DataTable table in ds.Tables)
                    {

                        var sheetPart = workbook.WorkbookPart.AddNewPart<WorksheetPart>();
                        var sheetData = new DocumentFormat.OpenXml.Spreadsheet.SheetData();
                        sheetPart.Worksheet = new DocumentFormat.OpenXml.Spreadsheet.Worksheet(sheetData);

                        DocumentFormat.OpenXml.Spreadsheet.Sheets sheets = workbook.WorkbookPart.Workbook.GetFirstChild<DocumentFormat.OpenXml.Spreadsheet.Sheets>();
                        string relationshipId = workbook.WorkbookPart.GetIdOfPart(sheetPart);

                        uint sheetId = 1;
                        if (sheets.Elements<DocumentFormat.OpenXml.Spreadsheet.Sheet>().Count() > 0)
                        {
                            sheetId =
                                sheets.Elements<DocumentFormat.OpenXml.Spreadsheet.Sheet>().Select(s => s.SheetId.Value).Max() + 1;
                        }

                        DocumentFormat.OpenXml.Spreadsheet.Sheet sheet = new DocumentFormat.OpenXml.Spreadsheet.Sheet() { Id = relationshipId, SheetId = sheetId, Name = table.TableName };
                        sheets.Append(sheet);

                        DocumentFormat.OpenXml.Spreadsheet.Row headerRow = new DocumentFormat.OpenXml.Spreadsheet.Row();

                        List<String> columns = new List<string>();
                        foreach (System.Data.DataColumn column in table.Columns)
                        {
                            columns.Add(column.ColumnName);

                            DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                            cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                            cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(column.ColumnName);
                            headerRow.AppendChild(cell);
                        }

                        sheetData.AppendChild(headerRow);

                        foreach (System.Data.DataRow dsrow in table.Rows)
                        {
                            DocumentFormat.OpenXml.Spreadsheet.Row newRow = new DocumentFormat.OpenXml.Spreadsheet.Row();
                            foreach (String col in columns)
                            {
                                DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                                cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                                cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(dsrow[col].ToString()); //
                                newRow.AppendChild(cell);
                            }

                            sheetData.AppendChild(newRow);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ExportDataSet, Ex - " + ex.Message.ToString());
            }
        }

        private void CreateUserPdfDoc(List<UserData> lstUsers, string destination)
        {
            using (FileStream stream = new FileStream(destination, FileMode.Create))
            {
                Document document = new Document(PageSize.A4, 25, 25, 25, 25);
                PdfWriter.GetInstance(document, stream);

                document.Open();
                Paragraph title = new Paragraph();
                Chunk H1 = new Chunk("Report For Application Users As On : " + "Date");
                H1.Font.SetStyle(iTextSharp.text.Font.BOLD);
                H1.Font.Size = 8;
                H1.SetUnderline(1f, -2f);
                title.Add(H1);
                title.Alignment = Element.ALIGN_CENTER;
                document.Add(title);

                PdfPTable DataTable = new PdfPTable(new float[] { 2, 2, 2, 2 });
                DataTable.WidthPercentage = 100;
                DataTable.SplitLate = false;

                PdfPCell isincol0 = new PdfPCell(new Phrase("User ID"));
                isincol0.HorizontalAlignment = Element.ALIGN_LEFT;
                isincol0.VerticalAlignment = Element.ALIGN_TOP;
                //isincol0.Phrase.Font.SetStyle(Font.Bold);
                isincol0.Phrase.Font.Size = 8;
                DataTable.AddCell(isincol0);

                PdfPCell isincol1 = new PdfPCell(new Phrase("User Name"));
                isincol1.HorizontalAlignment = Element.ALIGN_LEFT;
                isincol1.VerticalAlignment = Element.ALIGN_TOP;
                //isincol1.Phrase.Font.SetStyle(Font.BOLD);
                isincol1.Phrase.Font.Size = 8;
                DataTable.AddCell(isincol1);

                PdfPCell isincol2 = new PdfPCell(new Phrase("Password"));
                isincol2.HorizontalAlignment = Element.ALIGN_LEFT;
                isincol2.VerticalAlignment = Element.ALIGN_TOP;
                //isincol2.Phrase.Font.SetStyle(Font.BOLD);
                isincol2.Phrase.Font.Size = 8;
                DataTable.AddCell(isincol2);

                PdfPCell isincol3 = new PdfPCell(new Phrase("User Type"));
                isincol3.HorizontalAlignment = Element.ALIGN_RIGHT;
                isincol3.VerticalAlignment = Element.ALIGN_TOP;
                //isincol3.Phrase.Font.SetStyle(Font.BOLD);
                isincol3.Phrase.Font.Size = 8;
                DataTable.AddCell(isincol3);

                PdfPCell ID = null;
                PdfPCell UserName = null;
                PdfPCell Password = null;
                PdfPCell UserType = null;

                foreach (UserData user in lstUsers)
                {
                    ID = new PdfPCell(new Phrase(user.ID));
                    ID.HorizontalAlignment = Element.ALIGN_LEFT;
                    ID.VerticalAlignment = Element.ALIGN_TOP;
                    ID.Phrase.Font.Size = 8;
                    ID.MinimumHeight = 15f;
                    DataTable.AddCell(ID);

                    UserName = new PdfPCell(new Phrase(user.UserName));
                    UserName.HorizontalAlignment = Element.ALIGN_LEFT;
                    UserName.VerticalAlignment = Element.ALIGN_TOP;
                    UserName.Phrase.Font.Size = 8;
                    UserName.MinimumHeight = 15f;
                    DataTable.AddCell(UserName);

                    Password = new PdfPCell(new Phrase(user.Password));
                    Password.HorizontalAlignment = Element.ALIGN_LEFT;
                    Password.VerticalAlignment = Element.ALIGN_TOP;
                    Password.Phrase.Font.Size = 8;
                    Password.MinimumHeight = 15f;
                    DataTable.AddCell(Password);

                    UserType = new PdfPCell(new Phrase(user.UserType));
                    UserType.HorizontalAlignment = Element.ALIGN_LEFT;
                    UserType.VerticalAlignment = Element.ALIGN_TOP;
                    UserType.Phrase.Font.Size = 8;
                    UserType.MinimumHeight = 15f;
                    DataTable.AddCell(UserType);
                }

                document.Add(DataTable);
                document.Close();
                stream.Close();
            }
        }
        #endregion

        private void dtpBuyFromDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                dtpBuyFromDate.Format = DateTimePickerFormat.Custom;
                dtpBuyFromDate.CustomFormat = "-- SELECT DATE --";
            }
            if (dtpBuyFromDate.Format == DateTimePickerFormat.Custom && dtpBuyToDate.Format == DateTimePickerFormat.Custom)
            {
                dtpSellFromDate.Enabled = true;
                dtpSellToDate.Enabled = true;
            }
        }

        private void dtpBuyToDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                dtpBuyToDate.Format = DateTimePickerFormat.Custom;
                dtpBuyToDate.CustomFormat = "-- SELECT DATE --";
            }
            if (dtpBuyFromDate.Format == DateTimePickerFormat.Custom && dtpBuyToDate.Format == DateTimePickerFormat.Custom)
            {
                dtpSellFromDate.Enabled = true;
                dtpSellToDate.Enabled = true;
            }
        }

        private void dtpSellFromDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                dtpSellFromDate.Format = DateTimePickerFormat.Custom;
                dtpSellFromDate.CustomFormat = "-- SELECT DATE --";
            }
            if (dtpSellFromDate.Format == DateTimePickerFormat.Custom && dtpSellToDate.Format == DateTimePickerFormat.Custom)
            {
                dtpBuyFromDate.Enabled = true;
                dtpBuyToDate.Enabled = true;
            }
        }

        private void dtpSellToDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                dtpSellToDate.Format = DateTimePickerFormat.Custom;
                dtpSellToDate.CustomFormat = "-- SELECT DATE --";
            }
            if (dtpSellFromDate.Format == DateTimePickerFormat.Custom && dtpSellToDate.Format == DateTimePickerFormat.Custom)
            {
                dtpBuyFromDate.Enabled = true;
                dtpBuyToDate.Enabled = true;
            }
        }

        private void dtpBuyFromDate_ValueChanged(object sender, EventArgs e)
        {
            dtpBuyFromDate.Format = DateTimePickerFormat.Short;
            EnableBuyDates(true);
        }

        private void dtpBuyToDate_ValueChanged(object sender, EventArgs e)
        {
            dtpBuyToDate.Format = DateTimePickerFormat.Short;
            EnableBuyDates(true);
        }

        private void dtpSellFromDate_ValueChanged(object sender, EventArgs e)
        {
            dtpSellFromDate.Format = DateTimePickerFormat.Short;
            EnableBuyDates(false);
        }

        private void dtpSellToDate_ValueChanged(object sender, EventArgs e)
        {
            dtpSellToDate.Format = DateTimePickerFormat.Short;
            EnableBuyDates(false);
        }

        private void EnableBuyDates(bool Value)
        {
            dtpBuyFromDate.Enabled = Value;
            dtpBuyToDate.Enabled = Value;
            dtpSellFromDate.Enabled = !Value;
            dtpSellToDate.Enabled = !Value;

            grdReportData.DataSource = null;
            grdReportData.Visible = true;
            reportViewer1.Visible = false;
        }
    }
}
