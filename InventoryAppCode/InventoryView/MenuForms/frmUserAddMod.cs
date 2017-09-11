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
    public partial class frmUserAddMod : Form
    {
        private string frmAction = string.Empty;
        string loginUserType = string.Empty;
        public event EventHandler SubmitClicked;
        UserData UserObj = null;
        UserDataT UserTobj = null;

        public frmUserAddMod()
        {
            InitializeComponent();
        }

        public frmUserAddMod(string Action, UserData Uobj, string _loginUserType)
        {
            try
            {
                InitializeComponent();
                this.UserObj = new UserData();
                frmAction = Action;
                loginUserType = _loginUserType;
                if (Uobj != null)
                    this.UserObj = Uobj;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUserAddMod, Ex- " + ex.Message.ToString());
            }
        }

        private void frmUserAddMod_Load(object sender, EventArgs e)
        {
            try
            {
                FillUserType();
                if (frmAction == "ADD")
                    this.lblUserHeader.Text = "Add Application User";
                else if (frmAction == "MODIFY")
                {
                    txtUserName.ReadOnly = true;
                    this.lblUserHeader.Text = "Change Application User Password";

                    if (UserObj.UserType == "SYSADMIN")
                    {
                        //cmbUserType.Text = UserObj.UserType;
                        cmbUserType.SelectedValue = UserObj.UserType;
                        cmbUserType.Enabled = false;
                    }
                    else
                        cmbUserType.SelectedValue = UserObj.UserType;

                    if(loginUserType != "SYSADMIN")
                        cmbUserType.Enabled = false;
                }
                else if (frmAction == "VIEW")
                {
                    this.lblUserHeader.Text = "View Application User";
                    EnableDisableControls(false);
                }
                else
                    this.lblUserHeader.Text = "";

                if (UserObj != null)
                {
                    txtUserName.Text = UserObj.UserName;
                    txtPassword.Text = UserObj.Password;
                    txtConfirmPassword.Text = UserObj.Password;
                }
                else
                {
                    txtUserName.Text = string.Empty;
                    txtPassword.Text = string.Empty;
                    txtConfirmPassword.Text = string.Empty;
                }
                txtUserName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUserAddMod_Load, Ex- " + ex.Message.ToString());
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
                    UserTobj = new UserDataT();
                    UserObj.UserName = txtUserName.Text.Trim();
                    UserObj.Password = txtPassword.Text.Trim();
                    UserObj.UserType = cmbUserType.SelectedValue.ToString();

                    if (frmAction == "ADD")
                    {
                        if (UserTobj.AddUser(UserObj))
                        {
                            this.SubmitClicked(this, new EventArgs());
                            this.Close();
                        }
                        else
                            MessageBox.Show("Cannot Add User.");
                    }
                    else if (frmAction == "MODIFY")
                    {
                        if (UserTobj.ModifyUser(UserObj))
                        {
                            this.SubmitClicked(this, new EventArgs());
                            this.Close();
                        }
                        else
                            MessageBox.Show("Cannot Modify User.");
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
            if (txtConfirmPassword.Text.Trim() == "")
            {
                ShowMsg("Enter Confirm Password.", "Password");
                return false;
            }
            if (txtPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
            {
                ShowMsg("Password Doesn't Matches With Confirm Password.", "Password");
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

        private void EnableDisableControls(bool Flag)
        {
            cmbUserType.Enabled = Flag;
            txtUserName.Enabled = Flag;
            txtPassword.Enabled = Flag;
            txtConfirmPassword.Enabled = Flag;
            btnSubmit.Visible = Flag;
        }

        private void FillUserType()
        {
            cmbUserType.DataSource = null;
            cmbUserType.DisplayMember = "Text";
            cmbUserType.ValueMember = "Value";

            if (UserObj.UserType == "SYSADMIN")
            {
                var items = new[] { 
                    new { Text = "SYSADMIN", Value = "SYSADMIN" },
                new { Text = "Normal User", Value = "NORMAL" },
                new { Text = "Admin User", Value = "ADMIN" },
                };
                cmbUserType.DataSource = items; 
            }
            else
            {
                var items = new[] { 
                new { Text = "Normal User", Value = "NORMAL" },
                new { Text = "Admin User", Value = "ADMIN" },
                };
                cmbUserType.DataSource = items;
            }
        }
    }
}
