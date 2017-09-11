using InventoryModel.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InventoryView
{
    public partial class frmItemSearch : Form
    {
        #region Declaration
        SearchCriteria SearchCri = null;
        CategoriesT catTobj = null;
        BrandsT brandsTobj = null;
        DealerT dealTobj = null;
        List<Categories> lstCategories = null;
        List<Brands> lstBrands = null;
        List<Dealers> lstDealers = null;

        #endregion

        public frmItemSearch()
        {
            InitializeComponent();
        }

        public void frmItemSearch_Load(object sender, EventArgs e)
        {
            ckbAllItems.Focus();
            FillCategoriesCmb();
            FillBrandsCmb();
            FillDealersCmb();
            dtpBuyFromDate.Format = DateTimePickerFormat.Custom;
            dtpBuyFromDate.CustomFormat = "-- SELECT DATE --";
            dtpBuyToDate.Format = DateTimePickerFormat.Custom;
            dtpBuyToDate.CustomFormat = "-- SELECT DATE --";
            dtpSellFromDate.Format = DateTimePickerFormat.Custom;
            dtpSellFromDate.CustomFormat = "-- SELECT DATE --";
            dtpSellToDate.Format = DateTimePickerFormat.Custom;
            dtpSellToDate.CustomFormat = "-- SELECT DATE --";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FillSearchCriObj();
            if (Validation())
            {
                frmListData frm = new frmListData("ITEM", SearchCri);
                frm.CloseClicked += frm_CloseClicked;
                frm.MdiParent = this.MdiParent;
                frm.Dock = DockStyle.Fill;
                frm.Show();
            }
        }

        void frm_CloseClicked(object sender, EventArgs e)
        {
            ClearAllControls();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ckbAllItems_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbAllItems.Checked)
            {
                EnableDisableFormControls(false);
                ckbAllItems.Enabled = true;
                ckbAllItems.Focus();
            }
            else
                EnableDisableFormControls(true);
        }

        private void ckbAllItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ckbAllItems.Checked)
                    ckbAllItems.Checked = false;
                else
                    ckbAllItems.Checked = true;
            }
        }

        private void txtItemId_TextChanged(object sender, EventArgs e)
        {
            if (txtItemId.Text.Trim() != "")
            {
                EnableDisableFormControls(false);
                txtItemId.Enabled = true;
            }
            else
            {
                EnableDisableFormControls(true);
            }
            txtItemId.Focus();
        }

        private void cmbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbCategories.SelectedIndex) > 0)
            {
                EnableDisableFormControls(false);
                cmbCategories.Enabled = true;
            }
            else
            {
                EnableDisableFormControls(true);
            }
            cmbCategories.Focus();
        }

        private void cmbBrands_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbBrands.SelectedIndex) > 0)
            {
                EnableDisableFormControls(false);
                cmbBrands.Enabled = true;
            }
            else
            {
                EnableDisableFormControls(true);
            }
            cmbBrands.Focus();
        }

        private void cmbDealers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbDealers.SelectedIndex) > 0)
            {
                EnableDisableFormControls(false);
                cmbDealers.Enabled = true;
            }
            else
            {
                EnableDisableFormControls(true);
            }
            cmbDealers.Focus();
        }

        private void dtpBuyFromDate_ValueChanged(object sender, EventArgs e)
        {
            dtpBuyFromDate.Format = DateTimePickerFormat.Short;
            EnableDisableFormControls(false);
            dtpBuyFromDate.Enabled = true;
            dtpBuyToDate.Enabled = true;
        }

        private void dtpBuyToDate_ValueChanged(object sender, EventArgs e)
        {
            dtpBuyToDate.Format = DateTimePickerFormat.Short;
            EnableDisableFormControls(false);
            dtpBuyFromDate.Enabled = true;
            dtpBuyToDate.Enabled = true;
        }

        private void dtpSellFromDate_ValueChanged(object sender, EventArgs e)
        {
            dtpSellFromDate.Format = DateTimePickerFormat.Short;
            EnableDisableFormControls(false);
            dtpSellFromDate.Enabled = true;
            dtpSellToDate.Enabled = true;
        }

        private void dtpSellToDate_ValueChanged(object sender, EventArgs e)
        {
            dtpSellToDate.Format = DateTimePickerFormat.Short;
            EnableDisableFormControls(false);
            dtpSellFromDate.Enabled = true;
            dtpSellToDate.Enabled = true;
        }

        private void txtBuyFromPrice_TextChanged(object sender, EventArgs e)
        {
            if (txtBuyFromPrice.Text.Trim() == "" && txtBuyToPrice.Text.Trim() == "")
                EnableDisableFormControls(true);
            else if (txtBuyFromPrice.Text.Trim() == "" && txtBuyToPrice.Text.Trim() != "")
            {
                EnableDisableFormControls(false);
                txtBuyFromPrice.Enabled = true;
                txtBuyToPrice.Enabled = true;
            }
            else if (txtBuyFromPrice.Text.Trim() != "")
            {
                EnableDisableFormControls(false);
                txtBuyFromPrice.Enabled = true;
                txtBuyToPrice.Enabled = true;
            }
            else
            {
                EnableDisableFormControls(true);
            }
            txtBuyFromPrice.Focus();
        }

        private void txtBuyToPrice_TextChanged(object sender, EventArgs e)
        {
            if (txtBuyFromPrice.Text.Trim() == "" && txtBuyToPrice.Text.Trim() == "")
                EnableDisableFormControls(true);
            else if (txtBuyFromPrice.Text.Trim() != "" && txtBuyToPrice.Text.Trim() == "")
            {
                EnableDisableFormControls(false);
                txtBuyFromPrice.Enabled = true;
                txtBuyToPrice.Enabled = true;
            }
            else if (txtBuyToPrice.Text.Trim() != "")
            {
                EnableDisableFormControls(false);
                txtBuyFromPrice.Enabled = true;
                txtBuyToPrice.Enabled = true;
            }
            else
            {
                EnableDisableFormControls(true);
            }
            txtBuyToPrice.Focus();
        }

        private void txtSellFromPrice_TextChanged(object sender, EventArgs e)
        {
            if (txtSellFromPrice.Text.Trim() == "" && txtSellToPrice.Text.Trim() == "")
                EnableDisableFormControls(true);
            else if (txtSellFromPrice.Text.Trim() == "" && txtSellToPrice.Text.Trim() != "")
            {
                EnableDisableFormControls(false);
                txtSellFromPrice.Enabled = true;
                txtSellToPrice.Enabled = true;
            }
            else if (txtSellFromPrice.Text.Trim() != "")
            {
                EnableDisableFormControls(false);
                txtSellFromPrice.Enabled = true;
                txtSellToPrice.Enabled = true;
            }
            else
            {
                EnableDisableFormControls(true);
            }
            txtSellFromPrice.Focus();
        }

        private void txtSellToPrice_TextChanged(object sender, EventArgs e)
        {
            if (txtSellFromPrice.Text.Trim() == "" && txtSellToPrice.Text.Trim() == "")
                EnableDisableFormControls(true);
            else if (txtSellFromPrice.Text.Trim() != "" && txtSellToPrice.Text.Trim() == "")
            {
                EnableDisableFormControls(false);
                txtSellFromPrice.Enabled = true;
                txtSellToPrice.Enabled = true;
            }
            else if (txtSellToPrice.Text.Trim() != "")
            {
                EnableDisableFormControls(false);
                txtSellFromPrice.Enabled = true;
                txtSellToPrice.Enabled = true;
            }
            else
            {
                EnableDisableFormControls(true);
            }
            txtSellToPrice.Focus();
        }

        private void FillCategoriesCmb()
        {
            try
            {
                Categories obj = new Categories();
                obj.CatID = 0; obj.CatDesc = "-- Select Category --";
                catTobj = new CategoriesT();
                lstCategories = new List<Categories>();
                lstCategories = catTobj.GetCategories(0, false);
                cmbCategories.ValueMember = "CatID";
                cmbCategories.DisplayMember = "CatDesc";
                //cmbCategories.DataSource = lstCategories;
                cmbCategories.Items.Add(obj);
                foreach (Categories data in lstCategories)
                    cmbCategories.Items.Add(data);
                cmbCategories.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("FillControls, Ex - " + ex.Message.ToString());
            }
        }

        private void FillBrandsCmb()
        {
            try
            {
                Brands obj = new Brands();
                obj.BrandID = 0; obj.BrandName = "-- Select Brand --";
                brandsTobj = new BrandsT();
                lstBrands = new List<Brands>();
                lstBrands = brandsTobj.GetBrands(0, false);
                cmbBrands.ValueMember = "BrandID";
                cmbBrands.DisplayMember = "BrandName";
                //cmbBrands.DataSource = lstBrands;
                cmbBrands.Items.Add(obj);
                foreach (Brands data in lstBrands)
                    cmbBrands.Items.Add(data);
                cmbBrands.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("FillBrandsCmb, Ex - " + ex.Message.ToString());
            }
        }

        private void FillDealersCmb()
        {
            try
            {
                Dealers obj = new Dealers();
                obj.DealerID = 0; obj.DealerName = "-- Select Dealer --";
                dealTobj = new DealerT();
                lstDealers = new List<Dealers>();
                lstDealers = dealTobj.GetDealer(0, false);
                cmbDealers.ValueMember = "DealerID";
                cmbDealers.DisplayMember = "DealerName";
                //cmbDealers.DataSource = lstDealers;
                cmbDealers.Items.Add(obj);
                foreach (Dealers data in lstDealers)
                    cmbDealers.Items.Add(data);
                cmbDealers.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("FillBrandsCmb, Ex - " + ex.Message.ToString());
            }
        }

        private void FillSearchCriObj()
        {
            SearchCri = new SearchCriteria();
            if (ckbAllItems.Checked)
            {
                SearchCri.ShowAll = "YES";
                return;
            }
            else if (txtItemId.Enabled)
            {
                if (txtItemId.Text.Trim() != "")
                {
                    SearchCri.ItemID = Convert.ToInt32(txtItemId.Text);
                    return;
                }
            }
            else if (cmbCategories.Enabled)
            {
                if (cmbCategories.SelectedIndex > 0)
                {
                    Categories cat = new Categories();
                    cat = (Categories)cmbCategories.SelectedItem;
                    SearchCri.CatID = cat.CatID;
                }
                //SearchCri.CatID = Convert.ToInt32(cmbCategories.SelectedValue);
                return;
            }
            else if (cmbBrands.Enabled)
            {
                if (cmbBrands.SelectedIndex > 0)
                {
                    Brands brand = new Brands();
                    brand = (Brands)cmbBrands.SelectedItem;
                    SearchCri.BrandID = brand.BrandID;
                }
                //SearchCri.BrandID = Convert.ToInt32(cmbBrands.SelectedValue);
                return;
            }
            else if (cmbDealers.Enabled)
            {
                if (cmbDealers.SelectedIndex > 0)
                {
                    Dealers dealer = new Dealers();
                    dealer = (Dealers)cmbDealers.SelectedItem;
                    SearchCri.DealerID = dealer.DealerID;
                }
                //SearchCri.DealerID = Convert.ToInt32(cmbDealers.SelectedValue);
                return;
            }
            else if (txtBuyFromPrice.Enabled)
            {
                if (txtBuyFromPrice.Text.Trim() != "")
                    SearchCri.BuyFromPrice = txtBuyFromPrice.Text.Trim();
                if (txtBuyToPrice.Text.Trim() != "")
                    SearchCri.BuyToPrice = txtBuyToPrice.Text.Trim();
                return;
            }
            else if (txtSellFromPrice.Enabled)
            {
                if (txtSellFromPrice.Text.Trim() != "")
                    SearchCri.SellFromPrice = txtSellFromPrice.Text;
                if (txtSellToPrice.Text.Trim() != "")
                    SearchCri.SellToPrice = txtSellToPrice.Text;
                return;
            }
            else if (dtpBuyFromDate.Enabled)
            {
                if (dtpBuyFromDate.Format != DateTimePickerFormat.Custom)
                    SearchCri.BuyFromDate = Convert.ToDateTime(dtpBuyFromDate.Text);
                if (dtpBuyToDate.Format != DateTimePickerFormat.Custom)
                    SearchCri.BuyToDate = Convert.ToDateTime(dtpBuyToDate.Text);
                return;
            }
            else if (dtpSellFromDate.Enabled)
            {
                if (dtpSellFromDate.Format != DateTimePickerFormat.Custom)
                    SearchCri.SellFromDate = Convert.ToDateTime(dtpSellFromDate.Text);
                if (dtpSellToDate.Format != DateTimePickerFormat.Custom)
                    SearchCri.SellToDate = Convert.ToDateTime(dtpSellToDate.Text);
                return;
            }
        }

        private void EnableDisableFormControls(bool Flag)
        {
            foreach (Control c in this.Controls)
            {
                string ControlName = c.Name;
                if (!ControlName.StartsWith("lbl") && !ControlName.StartsWith("btn"))
                    c.Enabled = Flag;
            }
        }

        public void ClearAllControls()
        {
            ckbAllItems.Checked = false;
            txtItemId.Text = "";
            txtBuyFromPrice.Text = "";
            txtBuyToPrice.Text = "";
            txtSellFromPrice.Text = "";
            txtSellToPrice.Text = "";
            cmbCategories.SelectedIndex = 0;
            cmbBrands.SelectedIndex = 0;
            cmbDealers.SelectedIndex = 0;
        }

        private bool Validation()
        {
            if (SearchCri.ShowAll == null && SearchCri.ItemID == 0 && SearchCri.CatID == 0 && SearchCri.BrandID == 0 && SearchCri.DealerID == 0 && SearchCri.BuyFromDate.ToString("dd-MMM-yyyy") == "01-Jan-0001" && SearchCri.BuyToDate.ToString("dd-MMM-yyyy") == "01-Jan-0001" && SearchCri.BuyFromPrice == null && SearchCri.BuyToPrice == null && SearchCri.SellFromDate.ToString("dd-MMM-yyyy") == "01-Jan-0001" && SearchCri.SellToDate.ToString("dd-MMM-yyyy") == "01-Jan-0001" && SearchCri.SellFromPrice == null && SearchCri.SellToPrice == null)
            {
                //ShowMsg("Select At Least One Search Criteria.", "ItemID");
                //return false;
                SearchCri.ShowAll = "YES";
                return true;
            }
            else if (SearchCri.BuyFromPrice != "" && SearchCri.BuyToPrice == "")
            {
                ShowMsg("Enter Buy To Price.", "BuyToPrice");
                return false;
            }
            else if (SearchCri.BuyFromPrice == "" && SearchCri.BuyToPrice != "")
            {
                ShowMsg("Enter Buy From Price.", "BuyFromPrice");
                return false;
            }
            else if (SearchCri.SellFromPrice != "" && SearchCri.SellToPrice == "")
            {
                ShowMsg("Enter Sell To Price.", "SellToPrice");
                return false;
            }
            else if (SearchCri.SellFromPrice == "" && SearchCri.SellToPrice != "")
            {
                ShowMsg("Enter Sell From Price.", "SellFromPrice");
                return false;
            }
            else if (SearchCri.BuyFromDate.ToString("dd-MMM-yyyy") != "01-Jan-0001" && SearchCri.BuyToDate.ToString("dd-MMM-yyyy") == "01-Jan-0001")
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

        private void ShowMsg(string Msg, string FocusField)
        {
            MessageBox.Show(Msg);
            if (FocusField == "ItemID")
                txtItemId.Focus();
            else if (FocusField == "BuyFromDate")
                dtpBuyFromDate.Focus();
            else if (FocusField == "BuyToDate")
                dtpBuyToDate.Focus();
            else if (FocusField == "BuyFromPrice")
                txtBuyFromPrice.Focus();
            else if (FocusField == "BuyToPrice")
                txtBuyToPrice.Focus();
            else if (FocusField == "SellFromDate")
                dtpSellFromDate.Focus();
            else if (FocusField == "SellToDate")
                dtpSellToDate.Focus();
            else if (FocusField == "SellFromPrice")
                txtSellFromPrice.Focus();
            else if (FocusField == "SellToPrice")
                txtSellToPrice.Focus();
        }

        private void dtpBuyFromDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                dtpBuyFromDate.Format = DateTimePickerFormat.Custom;
                dtpBuyFromDate.CustomFormat = "-- SELECT DATE --";
            }
            if (dtpBuyFromDate.Format == DateTimePickerFormat.Custom && dtpBuyToDate.Format == DateTimePickerFormat.Custom)
                EnableDisableFormControls(true);
        }

        private void dtpBuyToDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                dtpBuyToDate.Format = DateTimePickerFormat.Custom;
                dtpBuyToDate.CustomFormat = "-- SELECT DATE --";
            }
            if (dtpBuyFromDate.Format == DateTimePickerFormat.Custom && dtpBuyToDate.Format == DateTimePickerFormat.Custom)
                EnableDisableFormControls(true);
        }

        private void dtpSellFromDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                dtpSellFromDate.Format = DateTimePickerFormat.Custom;
                dtpSellFromDate.CustomFormat = "-- SELECT DATE --";
            }
            if (dtpSellFromDate.Format == DateTimePickerFormat.Custom && dtpSellToDate.Format == DateTimePickerFormat.Custom)
                EnableDisableFormControls(true);
        }

        private void dtpSellToDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                dtpSellToDate.Format = DateTimePickerFormat.Custom;
                dtpSellToDate.CustomFormat = "-- SELECT DATE --";
            }
            if (dtpSellFromDate.Format == DateTimePickerFormat.Custom && dtpSellToDate.Format == DateTimePickerFormat.Custom)
                EnableDisableFormControls(true);
        }
    }
}
