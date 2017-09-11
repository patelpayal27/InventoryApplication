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
    public partial class frmLogin : Form
    {
        public event EventHandler SubmitClicked;
        public string userType = string.Empty;
        public string userName = string.Empty;
        UserDataT userTObj = null;
        UserData userObj = null;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            //txtUserName.Text = "SYSADMIN";
            //txtPassword.Text = "sysadmin";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                string error = string.Empty;
                userTObj = new UserDataT();
                userObj = new UserData();
                userObj.UserName = userName = txtUserName.Text.Trim().ToUpper();
                userObj.Password = txtPassword.Text.Trim();

                if (userTObj.CheckUserPassword(userObj, ref error, ref userType))
                {
                    this.SubmitClicked(sender, e);
                    this.Close();
                }
                else
                    MessageBox.Show(error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool Validation()
        {
            if (txtUserName.Text.Trim() == "")
            {
                ShowMsg("Enter User Name.", "User");
                return false;
            }
            if (txtPassword.Text.Trim() == "")
            {
                ShowMsg("Enter Password.", "Password");
                return false;
            }
            return true;
        }

        private void ShowMsg(string Msg, string FocusField)
        {
            MessageBox.Show(Msg);
            if (FocusField == "User")
                txtUserName.Focus();
            else if (FocusField == "Password")
                txtPassword.Focus();
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            txtUserName.Text = txtUserName.Text.ToUpper();
            txtUserName.SelectionStart = txtUserName.Text.Length;
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin_Click(sender, e);
        }
    }
}
