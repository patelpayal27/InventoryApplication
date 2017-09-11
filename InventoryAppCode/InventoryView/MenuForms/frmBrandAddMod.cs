using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InventoryModel.Classes;
using System.Collections;

namespace InventoryView
{
    public partial class frmBrandAddMod : Form
    {
        private string frmAction = string.Empty;
        public event EventHandler SubmitClicked;
        BrandsT BrandTObj = null;
        Brands Brandobj = null;
        CategoriesT CatTObj = null;
        List<Categories> lstCat = null;
        List<int> lstCatId = null;

        public frmBrandAddMod()
        {
            InitializeComponent();
        }

        public frmBrandAddMod(string Action, Brands Bobj, List<int> lstCatID)
        {
            try
            {
                InitializeComponent();
                this.Brandobj = new Brands();
                frmAction = Action;
                if (Bobj != null)
                    this.Brandobj = Bobj;
                if (lstCatID != null)
                    this.lstCatId = lstCatID;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmBrandAddMod, Ex- " + ex.Message.ToString());
            }
        }

        private void frmBrandAddMod_Load(object sender, EventArgs e)
        {
            try
            {
                if (frmAction == "ADD")
                    this.lblBrandHeader.Text = "Add Brand";
                else if (frmAction == "MODIFY")
                    this.lblBrandHeader.Text = "Modify Brand";
                else if (frmAction == "VIEW")
                {
                    this.lblBrandHeader.Text = "View Brand";
                    EnableDisableControls(false);
                }
                else
                    this.lblBrandHeader.Text = "";

                if (Brandobj != null)
                    txtBrandName.Text = Brandobj.BrandName;
                else
                    txtBrandName.Text = string.Empty;

                //Catobj = new Categories();
                CatTObj = new CategoriesT();
                lstCat = new List<Categories>();
                lstCat = CatTObj.GetCategories(0, false);

                foreach (var item in lstCat)
                {
                    if (lstCatId != null)
                    {
                        if (lstCatId.Contains(item.CatID))
                            LstBxCategory.Items.Add(item, true);
                        else
                            LstBxCategory.Items.Add(item);
                    }
                    else
                        LstBxCategory.Items.Add(item);
                }
                LstBxCategory.DisplayMember = "CatDesc";
                LstBxCategory.ValueMember = "CatID";
                txtBrandName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmBrandAddMod_Load, Ex- " + ex.Message.ToString());
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validation())
                {
                    BrandTObj = new BrandsT();
                    Brandobj.BrandName = txtBrandName.Text;
                    List<Int32> lstCatId = new List<int>();
                    foreach (Categories item in LstBxCategory.CheckedItems)
                    {
                        lstCatId.Add(item.CatID);
                    }

                    if (frmAction == "ADD")
                    {
                        if (BrandTObj.AddBrand(Brandobj, lstCatId))
                        {
                            this.SubmitClicked(this, new EventArgs());
                            this.Close();
                        }
                        else
                            MessageBox.Show("Cannot Add Brand.");
                    }
                    else if (frmAction == "MODIFY")
                    {
                        if (BrandTObj.ModifyBrand(Brandobj, lstCatId))
                        {
                            this.SubmitClicked(this, new EventArgs());
                            this.Close();
                        }
                        else
                            MessageBox.Show("Cannot Modify Brand.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnSubmit_Click, Ex - " + ex.Message.ToString());
            }
        }

        private bool Validation()
        {
            if (txtBrandName.Text.Trim() == "")
            {
                ShowMsg("Enter Brand Name.", "brand");
                return false;
            }
            int count = 0;
            foreach (Categories item in LstBxCategory.CheckedItems)
            {
                count++;
            }
            if (count == 0)
            {
                ShowMsg("Select At Least One Category.", "category");
                return false;
            }
            return true;
        }

        private void ShowMsg(string Msg, string FocusField)
        {
            MessageBox.Show(Msg);
            if (FocusField == "brand")
                txtBrandName.Focus();
            else if (FocusField == "category")
                LstBxCategory.Focus();
        }

        private void EnableDisableControls(bool Flag)
        {
            txtBrandName.Enabled = Flag;
            LstBxCategory.Enabled = Flag;
            btnSubmit.Visible = Flag;
            //ListEnabled = false;
        }

        private void LstBxCategory_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //if (!ListEnabled)
            //{
            //    e.NewValue = e.CurrentValue;
            //}
        }

    }
}
