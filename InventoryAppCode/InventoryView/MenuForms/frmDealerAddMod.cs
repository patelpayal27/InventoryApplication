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
    public partial class frmDealerAddMod : Form
    {
        private string frmAction = string.Empty;
        public event EventHandler SubmitClicked;
        Dealers DealerObj = null;
        DealerT DealerTobj = null;

        public frmDealerAddMod()
        {
            InitializeComponent();
        }

        public frmDealerAddMod(string Action, Dealers Dobj)
        {
            try
            {
                InitializeComponent();
                this.DealerObj = new Dealers();
                frmAction = Action;
                if (Dobj != null)
                    this.DealerObj = Dobj;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmDealerAddMod, Ex- " + ex.Message.ToString());
            }
        }

        private void frmDealerAddMod_Load(object sender, EventArgs e)
        {
            try
            {
                if (frmAction == "ADD")
                    this.lblDealerHeader.Text = "Add Dealer";
                else if (frmAction == "MODIFY")
                    this.lblDealerHeader.Text = "Modify Dealer";
                else if (frmAction == "VIEW")
                {
                    this.lblDealerHeader.Text = "View Dealer";
                    EnableDisableControls(false);
                }
                else
                    this.lblDealerHeader.Text = "";

                if (DealerObj != null)
                {
                    txtDealerName.Text = DealerObj.DealerName;
                    txtDealerAddress.Text = DealerObj.DealerAddress;
                    txtDealerNumber.Text = DealerObj.DealerPhoneNum;
                }
                else
                {
                    txtDealerName.Text = string.Empty;
                    txtDealerAddress.Text = string.Empty;
                    txtDealerNumber.Text = string.Empty;
                }
                txtDealerName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmDealerAddMod_Load, Ex- " + ex.Message.ToString());
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validation())
                {
                    DealerTobj = new DealerT();
                    DealerObj.DealerName = txtDealerName.Text.Trim();
                    DealerObj.DealerAddress = txtDealerAddress.Text.Trim();
                    DealerObj.DealerPhoneNum = txtDealerNumber.Text.Trim();

                    if (frmAction == "ADD")
                    {
                        if (DealerTobj.AddDealer(DealerObj))
                        {
                            this.SubmitClicked(this, new EventArgs());
                            this.Close();
                        }
                        else
                            MessageBox.Show("Cannot Add Dealer.");
                    }
                    else if (frmAction == "MODIFY")
                    {
                        if (DealerTobj.ModifyDealer(DealerObj))
                        {
                            this.SubmitClicked(this, new EventArgs());
                            this.Close();
                        }
                        else
                            MessageBox.Show("Cannot Modify Dealer.");
                    }
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
            if (txtDealerName.Text.Trim() == "")
            {
                ShowMsg("Enter Dealer Name.", "name");
                return false;
            }
            //if (txtDealerAddress.Text.Trim() == "")
            //{
            //    ShowMsg("Enter Dealer Address.", "address");
            //    return false;
            //}
            //if (txtDealerNumber.Text.Trim() == "")
            //{
            //    ShowMsg("Enter Dealer Number.", "number");
            //    return false;
            //}
            return true;
        }

        private void ShowMsg(string Msg, string FocusField)
        {
            MessageBox.Show(Msg);
            if (FocusField == "name")
                txtDealerName.Focus();
            else if (FocusField == "address")
                txtDealerAddress.Focus();
            else if (FocusField == "number")
                txtDealerNumber.Focus();
        }

        private void EnableDisableControls(bool Flag)
        {
            txtDealerName.Enabled = Flag;
            txtDealerAddress.Enabled = Flag;
            txtDealerNumber.Enabled = Flag;
            btnSubmit.Visible = Flag;
        }
    }
}
