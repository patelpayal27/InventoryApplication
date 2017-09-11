using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InventoryModel.Classes;

namespace InventoryView
{
    public partial class frmItemAddMod : Form
    {
        private string frmAction = string.Empty;
        public event EventHandler SubmitClicked;
        ItemData Itemobj = null;
        ItemDataT ItemTobj = null;
        CategoriesT catTobj = null;
        BrandsT brandsTobj = null;
        DealerT dealTobj = null;
        List<Categories> lstCategories = null;
        List<Brands> lstBrands = null;
        List<Dealers> lstDealers = null;

        public frmItemAddMod()
        {
            InitializeComponent();
        }

        public frmItemAddMod(string Action, ItemData Iobj)
        {
            try
            {
                InitializeComponent();
                this.Itemobj = new ItemData();
                frmAction = Action;
                if (Iobj != null)
                    this.Itemobj = Iobj;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmItemAddMod, Ex- " + ex.Message.ToString());
            }
        }

        private void frmItemAddMod_Load(object sender, EventArgs e)
        {
            try
            {
                FillCategoriesCmb();
                FillDealersCmb();
                if (frmAction == "ADD")
                    this.lblItemHeader.Text = "Add Item";
                else if (frmAction == "MODIFY")
                    this.lblItemHeader.Text = "Modify Item";
                else if (frmAction == "VIEW")
                {
                    this.lblItemHeader.Text = "View Item";
                    EnableDisableControls(false);
                }
                else
                    this.lblItemHeader.Text = "";

                if (frmAction == "MODIFY" && Itemobj != null)
                {
                    txtModel.Text = Itemobj.ModelNumber;
                    txtIMEINumber.Text = Itemobj.IMEI;
                    cmbCategories.SelectedValue = Itemobj.CatID;
                    cmbBrands.SelectedValue = Itemobj.BrandID;
                    cmbDealers.SelectedValue = Itemobj.DealerID;
                    dtpBuyDate.Text = Convert.ToString(Itemobj.BuyDate);
                    txtBuyPrice.Text = Convert.ToString(Itemobj.BuyPrice);
                    txtCustomerName.Text = Itemobj.CustomerName;
                    txtCustomerAddress.Text = Itemobj.CustAddress;
                    txtCustomerNumber.Text = Itemobj.CustPhoneNum;
                    dtpSellDate.Text = Convert.ToString(Itemobj.SellDate);
                    txtSellPrice.Text = Convert.ToString(Itemobj.SellPrice);
                }
                else
                {
                    dtpBuyDate.Text = string.Empty;
                    dtpSellDate.Text = string.Empty;
                }
                cmbCategories.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmItemAddMod_Load, Ex- " + ex.Message.ToString());
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                ItemTobj = new ItemDataT();
                Itemobj.CatID = Convert.ToInt32(cmbCategories.SelectedValue);
                Itemobj.BrandID = Convert.ToInt32(cmbBrands.SelectedValue);
                Itemobj.DealerID = Convert.ToInt32(cmbDealers.SelectedValue);
                Itemobj.ModelNumber = txtModel.Text.Trim();
                Itemobj.IMEI = txtIMEINumber.Text.Trim();
                Itemobj.BuyDate = dtpBuyDate.Text != "" ? Convert.ToDateTime(dtpBuyDate.Text) : DateTime.FromOADate(0);
                Itemobj.BuyPrice = txtBuyPrice.Text != "" ? Convert.ToDouble(txtBuyPrice.Text) : 0.0;
                Itemobj.CustomerName = txtCustomerName.Text;
                Itemobj.CustAddress = txtCustomerAddress.Text;
                Itemobj.CustPhoneNum = txtCustomerNumber.Text;
                Itemobj.SellDate = dtpSellDate.Text != "" ? Convert.ToDateTime(dtpSellDate.Text) : DateTime.FromOADate(0);
                Itemobj.SellPrice = txtSellPrice.Text != "" ? Convert.ToDouble(txtSellPrice.Text) : 0.0;

                if (frmAction == "ADD")
                {
                    if (ItemTobj.AddItem(Itemobj))
                    {
                        this.SubmitClicked(this, new EventArgs());
                        this.Close();
                    }
                    else
                        MessageBox.Show("Cannot Add Dealer.");
                }
                else if (frmAction == "MODIFY")
                {
                    if (ItemTobj.ModifyItem(Itemobj))
                    {
                        this.SubmitClicked(this, new EventArgs());
                        this.Close();
                    }
                    else
                        MessageBox.Show("Cannot Modify Dealer.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnSubmit_Click, Ex - " + ex.Message.ToString());
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FillCategoriesCmb()
        {
            try
            {
                catTobj = new CategoriesT();
                lstCategories = new List<Categories>();
                lstCategories = catTobj.GetCategories(0, false);
                cmbCategories.ValueMember = "CatID";
                cmbCategories.DisplayMember = "CatDesc";
                cmbCategories.DataSource = lstCategories;
            }
            catch (Exception ex)
            {
                MessageBox.Show("FillControls, Ex - " + ex.Message.ToString());
            }
        }

        private void FillBrandsCmb(int CatID)
        {
            try
            {
                brandsTobj = new BrandsT();
                lstBrands = new List<Brands>();
                lstBrands = brandsTobj.GetBrandsbyCatID(CatID, false);
                cmbBrands.ValueMember = "BrandID";
                cmbBrands.DisplayMember = "BrandName";
                cmbBrands.DataSource = lstBrands;
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
                dealTobj = new DealerT();
                lstDealers = new List<Dealers>();
                lstDealers = dealTobj.GetDealer(0, false);
                cmbDealers.ValueMember = "DealerID";
                cmbDealers.DisplayMember = "DealerName";
                cmbDealers.DataSource = lstDealers;
            }
            catch (Exception ex)
            {
                MessageBox.Show("FillBrandsCmb, Ex - " + ex.Message.ToString());
            }
        }

        private void cmbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillBrandsCmb(Convert.ToInt32(cmbCategories.SelectedValue));
        }

        private void EnableDisableControls(bool Flag)
        {
            cmbCategories.Enabled = Flag;
            cmbBrands.Enabled = Flag;
            cmbDealers.Enabled = Flag;
            txtIMEINumber.Enabled = Flag;
            dtpBuyDate.Enabled = Flag;
            txtBuyPrice.Enabled = Flag;
            txtCustomerName.Enabled = Flag;
            txtCustomerAddress.Enabled = Flag;
            txtCustomerNumber.Enabled = Flag;
            dtpSellDate.Enabled = Flag;
            txtSellPrice.Enabled = Flag;
            btnSubmit.Visible = Flag;
        }
    }
}
