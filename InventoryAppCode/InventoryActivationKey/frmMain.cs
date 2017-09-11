using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InventoryActivationKey
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnGenerateKey_Click(object sender, EventArgs e)
        {
            if (txtMAC.Text == "")
                MessageBox.Show("Enter MAC Address.");
            string activeKey = EncryptPassword(txtMAC.Text.Trim());
            txtActiveKey.Text = activeKey;

        }

        public string EncryptPassword(string _password)
        {
            string encpassFinal = string.Empty;

            char[] temp = _password.ToCharArray();
            char[] temp1 = new char[_password.Count()];
            for (int i = 0; i < temp.Count(); i++)
            {
                int ascii = (int)temp[i];
                switch (ascii)
                {
                    case 57:
                        ascii = 48;
                        break;
                    case 90:
                        ascii = 65;
                        break;
                    case 122:
                        ascii = 97;
                        break;
                    default:
                        ascii = ascii + 2;
                        break;
                }
                temp1[i] = (char)ascii;
            }
            encpassFinal = new string(temp1);
            return encpassFinal;
        }
    }
}
