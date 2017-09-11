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
    public partial class frmValidity : Form
    {
        public event EventHandler SubmitClicked;

        public frmValidity()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtNoOfDays.Text.Trim() != "")
            {
                if (Convert.ToInt32(txtNoOfDays.Text) > 0)
                {
                    string retVal = Security.addEvalDays(Convert.ToDouble(txtNoOfDays.Text.Trim()));
                    if (retVal != "")
                    {
                        MessageBox.Show(retVal, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (Convert.ToInt32(txtNoOfDays.Text) == 1)
                            MessageBox.Show("Application Validaty Increased By " + txtNoOfDays.Text.Trim() + " Day.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Application Validaty Increased By " + txtNoOfDays.Text.Trim() + " Days.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        SubmitClicked(sender, e);
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            SubmitClicked(sender, e);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Security.delAppKey();
            MessageBox.Show("Application Reset Successfully. Add Days To Increase Validity.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
