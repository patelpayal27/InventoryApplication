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
    public partial class frmMenu : Form
    {
        frmLogin frmlogin;
        Form currForm = null;
        string usertype = string.Empty;
        string username = string.Empty;
        string daysLeft = string.Empty;

        public frmMenu()
        {
            InitializeComponent();
        }

        public frmMenu(string userType, string userName, string days)
        {
            InitializeComponent();
            this.usertype = userType;
            this.username = userName;
            this.daysLeft = days;
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            DateTime Dt = System.DateTime.Now;
            Dt = Dt.AddDays(Convert.ToDouble(daysLeft));
            if (usertype.ToUpper() == "SYSADMIN")
                ShowSysAdminMenu(true);
            else
                ShowSysAdminMenu(false);

            if (Convert.ToInt32(daysLeft.Trim()) <= 0)
            {
                toolStripStatusLabel1.Alignment = ToolStripItemAlignment.Right;
                toolStripStatusLabel1.Text = "** Application Is Expired. **";
                EnableDisableMenus(false);
            }
            else
            {
                if (Convert.ToInt32(daysLeft.Trim()) == 1)
                    toolStripStatusLabel1.Text = "** Application Will Expire In " + daysLeft + " Day, On " + Dt.ToString("dd-MMM-yyyy") + " **";
                else
                    toolStripStatusLabel1.Text = "** Application Will Expire In " + daysLeft + " Days, On " + Dt.ToString("dd-MMM-yyyy") + " **";
                EnableDisableMenus(true);
            }
        }

        private void openForm(Form _frm)
        {
            if (currForm != null)
            {
                currForm.Close();
                currForm.Dispose();
            }
            currForm = _frm;
            currForm.MdiParent = this.MdiParent;
            currForm.Dock = DockStyle.Fill;
            currForm.Show();
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            if (usertype.ToUpper() == "ADMIN" || usertype.ToUpper() == "SYSADMIN")
            {
                openForm(new frmListData("CAT"));
            }
        }

        private void btnBrands_Click(object sender, EventArgs e)
        {
            if (usertype.ToUpper() == "ADMIN" || usertype.ToUpper() == "SYSADMIN")
            {
                openForm(new frmListData("BRAND"));
            }
        }

        private void btnDealers_Click(object sender, EventArgs e)
        {
            if (usertype.ToUpper() == "ADMIN" || usertype.ToUpper() == "SYSADMIN")
            {
                openForm(new frmListData("DEALER"));
            }
        }

        private void btnItems_Click(object sender, EventArgs e)
        {
            //openForm(new frmListData("ITEM"));
            openForm(new frmItemSearch());
        }

        private void btnImpExpData_Click(object sender, EventArgs e)
        {
            if (usertype.ToUpper() == "SYSADMIN")
            {
                openForm(new frmImpExp());
            }
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            openForm(new frmListData("USER", usertype, username));
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            if (usertype.ToUpper() == "ADMIN" || usertype.ToUpper() == "SYSADMIN")
            {
                openForm(new frmReport());
            }
        }

        private void btnGenBill_Click(object sender, EventArgs e)
        {
            if (usertype.ToUpper() == "ADMIN" || usertype.ToUpper() == "SYSADMIN")
            {
                openForm(new frmGenBill());
            }
        }

        private void btnValidity_Click(object sender, EventArgs e)
        {
            frmValidity frm = new frmValidity();
            frm.SubmitClicked += frm_SubmitClicked;
            frm.ShowDialog();
        }

        private void ShowSysAdminMenu(bool value)
        {
            btnValidity.Visible = value;
            lblValidity.Visible = value;
        }

        private void EnableDisableMenus(bool value)
        {
            btnBrands.Enabled = value;
            btnCategories.Enabled = value;
            btnDealers.Enabled = value;
            btnImpExpData.Enabled = value;
            btnItems.Enabled = value;
            btnReports.Enabled = value;
            btnUsers.Enabled = value;
        }

        void frm_SubmitClicked(object sender, EventArgs e)
        {
            daysLeft = Security.getEvalDays();
            frmMenu_Load(sender, e);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            frmlogin = new frmLogin();
            frmlogin.MdiParent = this.MdiParent;
            frmlogin.Dock = DockStyle.Fill;
            frmlogin.SubmitClicked += new EventHandler(frmlogin_SubmitClicked);
            frmlogin.Show();
        }

        void frmlogin_SubmitClicked(object sender, EventArgs e)
        {
            string userType = string.Empty;
            string userName = string.Empty;
            string EvalDays = string.Empty;

            userType = frmlogin.userType;
            userName = frmlogin.userName;
            EvalDays = Security.getEvalDays();
            frmMenu frmMnu = new frmMenu(userType, userName, EvalDays);
            frmMnu.MdiParent = this.MdiParent;
            frmMnu.Dock = DockStyle.Fill;
            frmMnu.Show();
        }
    }
}
