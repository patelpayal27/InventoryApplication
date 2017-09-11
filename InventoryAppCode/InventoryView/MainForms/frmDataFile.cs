using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Net.NetworkInformation;
using InventoryModel.Classes;

namespace InventoryView
{
    public partial class frmDataFile : Form
    {
        public event EventHandler SubmitClicked;
        public frmDataFile()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (rdb_Old.Checked)
            {
                ImportOldDataFile();
                MessageBox.Show("Data File Imported Successfully");
                this.Visible = false;
                SubmitClicked(sender, e);
            }
            else if (rdb_New.Checked)
            {
                CreateNewDataFile();
                MessageBox.Show("New Data File Created Successfully");
                UpdateInitialPswd(GeneratePswd());
                this.Visible = false;
                SubmitClicked(sender, e);
            }
            else
            {
                MessageBox.Show("Select Input.");
            }
        }

        private void CreateNewDataFile()
        {
            try
            {
                if (!Directory.Exists(InventoryModel.Classes.Constants.SqliteFilePath))
                    Directory.CreateDirectory(InventoryModel.Classes.Constants.SqliteFilePath);

                Stream srcFileReader = Assembly.GetCallingAssembly().GetManifestResourceStream("InventoryView.EmbeddedResources.InventoryDB_Dummy.sqlite");
                Stream destFileWriter = File.Create(InventoryModel.Classes.Constants.SqliteFilePath + @"\InventoryDB.sqlite");
                byte[] buffer = new byte[8192];

                int bytesRead;
                while ((bytesRead = srcFileReader.Read(buffer, 0, buffer.Length)) > 0)
                {
                    destFileWriter.Write(buffer, 0, bytesRead);
                }
                destFileWriter.Close();
                srcFileReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception In CreateNewDataFile. Ex - " + ex.Message.ToString());
            }
        }

        private void ImportOldDataFile()
        {
            try
            {
                if (!Directory.Exists(InventoryModel.Classes.Constants.SqliteFilePath))
                    Directory.CreateDirectory(InventoryModel.Classes.Constants.SqliteFilePath);

                OpenFileDialog op = new OpenFileDialog();
                op.Multiselect = false;
                op.ShowDialog();
                string Filename = op.FileName;
                File.Copy(Filename, InventoryModel.Classes.Constants.SqliteFilePath + @"\InventoryDB.sqlite");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception In ImportOldDataFile. Ex - " + ex.Message.ToString());
            }
        }

        private string GeneratePswd()
        {
            //NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            string initialPswd = "";
            //foreach (NetworkInterface adapter in nics)
            //{
            //    if (initialPswd == "")
            //    {
            //        initialPswd = adapter.GetPhysicalAddress().ToString();
            //    }
            //}
            //initialPswd = initialPswd.Replace("-","");
            //if (initialPswd == "")
            //    return "sysadmin";
            //initialPswd = EncryptPassword(initialPswd);
            initialPswd = "jatin";
            return initialPswd;
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

        private void UpdateInitialPswd(string pswd)
        {
            UserDataT userTObj = new UserDataT();
            userTObj.UpdateSysPswd(pswd);
        }
    }
}
