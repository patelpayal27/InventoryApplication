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
    public partial class frmCategoryAddMod : Form
    {
        private string frmAction = string.Empty;
        public event EventHandler SubmitClicked;
        CategoriesT catTObj = null;
        Categories catObj = null;

        public frmCategoryAddMod()
        {
            InitializeComponent();
        }

        public frmCategoryAddMod(string Action, Categories Catobj)
        {
            try
            {
                InitializeComponent();
                catObj = new Categories();
                frmAction = Action;
                if (Catobj != null)
                    catObj = Catobj;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmCategoryAddMod, Ex- " + ex.Message.ToString());
            }
        }

        private void frmCategoryAddMod_Load(object sender, EventArgs e)
        {
            try
            {
                if (frmAction == "ADD")
                    this.lblCategoryHeader.Text = "Add Category";
                else if (frmAction == "MODIFY")
                    this.lblCategoryHeader.Text = "Modify Category";
                else if (frmAction == "VIEW")
                {
                    this.lblCategoryHeader.Text = "View Category";
                    EnableDisableControls(false);
                }
                else
                    this.lblCategoryHeader.Text = "";

                if (catObj != null)
                    txtCategory.Text = catObj.CatDesc;
                else
                    txtCategory.Text = string.Empty;

                txtCategory.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmCategoryAddMod_Load, Ex- " + ex.Message.ToString());
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validation())
                {
                    catTObj = new CategoriesT();

                    if (frmAction == "ADD")
                    {
                        catObj.CatDesc = txtCategory.Text;
                        if (catTObj.AddCategory(catObj))
                        {
                            this.SubmitClicked(this, new EventArgs());
                            this.Close();
                        }
                        else
                            MessageBox.Show("Cannot Add Category.");
                    }
                    else if (frmAction == "MODIFY")
                    {
                        if (catObj.CatDesc.Trim() != txtCategory.Text.Trim())
                        {
                            catObj.CatDesc = txtCategory.Text;
                            if (catTObj.ModifyCategory(catObj))
                            {
                                this.SubmitClicked(this, new EventArgs());
                                this.Close();
                            }
                            else
                                MessageBox.Show("Cannot Modify Category.");
                        }
                        else
                            this.Close();
                    }
                    else
                        MessageBox.Show("Error...");
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

        private bool Validation()
        {
            if (txtCategory.Text.Trim() == "")
            {
                ShowMsg("Enter Category Name.", "category");
                return false;
            }
            return true;
        }

        private void ShowMsg(string Msg, string FocusField)
        {
            MessageBox.Show(Msg);
            if (FocusField == "category")
                txtCategory.Focus();
        }

        private void EnableDisableControls(bool Flag)
        {
            txtCategory.Enabled = Flag;
            btnSubmit.Visible = Flag;
        }
    }
}
