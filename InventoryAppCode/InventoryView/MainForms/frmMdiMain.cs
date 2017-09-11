using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using InventoryModel.Classes;
using System.Drawing.Text;

namespace InventoryView
{
    public partial class frmMdiMain : Form
    {
        string userType = string.Empty;
        string userName = string.Empty;
        string EvalDays = string.Empty;
        frmMenu frmMnu = null;
        frmLogin frmlogin = null;
        frmDataFile frmdataFile = null;

        public frmMdiMain()
        {
            try
            {
                string[] tmp = Assembly.GetCallingAssembly().GetManifestResourceNames();
                Stream srcFileReader = Assembly.GetCallingAssembly().GetManifestResourceStream("InventoryView.EmbeddedResources.InventoryModel.dll");
                byte[] InventoryModelDll = new byte[srcFileReader.Length];
                srcFileReader.Read(InventoryModelDll, 0, InventoryModelDll.Length);
                Assembly.Load(InventoryModelDll);

                Stream srcFileReader1 = Assembly.GetCallingAssembly().GetManifestResourceStream("InventoryView.EmbeddedResources.DocumentFormat.OpenXml.dll");
                byte[] OpenXMLDll = new byte[srcFileReader1.Length];
                srcFileReader1.Read(OpenXMLDll, 0, OpenXMLDll.Length);
                Assembly.Load(OpenXMLDll);

                Stream srcFileReader2 = Assembly.GetCallingAssembly().GetManifestResourceStream("InventoryView.EmbeddedResources.itextsharp.dll");
                byte[] itextsharpDll = new byte[srcFileReader2.Length];
                srcFileReader2.Read(itextsharpDll, 0, itextsharpDll.Length);
                Assembly.Load(itextsharpDll);

                //Stream srcFileReader3 = Assembly.GetCallingAssembly().GetManifestResourceStream("InventoryView.EmbeddedResources.System.Data.SQLite.dll");
                //byte[] SQLiteDll = new byte[srcFileReader3.Length];
                //srcFileReader3.Read(SQLiteDll, 0, SQLiteDll.Length);
                //Assembly.Load(SQLiteDll);

                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception In frmMdiMain(). Ex - " + ex.Message.ToString());
            }
        }

        private void frmMdiMain_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsAppRunning())
                {
                    //string temp = Security.EncryptPswd("sysadmin");
                    CheckNInstallFont();
                    EvalDays = Security.getEvalDays();

                    if (dataFileExist())
                    {
                        OpenForms("login");
                    }
                    else
                    {
                        //MessageBox.Show("Data File Not Present. Import Your Old Data File Or Create New Data File.");
                        OpenForms("datafile");
                    }
                }
                else
                {
                    MessageBox.Show("Inventory Application Is Already Running.");
                    CloseApplication();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception In frmMdiMain_Load(). Ex - " + ex.Message.ToString());
            }
        }


        private void CloseApplication()
        {
            Environment.Exit(0);
        }

        void frmdataFile_SubmitClicked(object sender, EventArgs e)
        {
            OpenForms("login");
        }

        void frmlogin_SubmitClicked(object sender, EventArgs e)
        {
            userType = frmlogin.userType;
            userName = frmlogin.userName;
            OpenForms("menu");
        }

        private bool dataFileExist()
        {
            if (!Directory.Exists(InventoryModel.Classes.Constants.SqliteFilePath))
                Directory.CreateDirectory(InventoryModel.Classes.Constants.SqliteFilePath);

            //MessageBox.Show("In dataFileExist, " + InventoryModel.Classes.Data.SqliteFilePath + @"\InventoryDB.sqlite");
            string file = InventoryModel.Classes.Constants.SqliteFilePath + @"\InventoryDB.sqlite";
            if (File.Exists(file))
                return true;
            else
                return false;
        }

        private void OpenForms(string formName)
        {
            try
            {
                if (formName == "login")
                {
                    frmlogin = new frmLogin();
                    frmlogin.MdiParent = this;
                    frmlogin.Dock = DockStyle.Fill;
                    frmlogin.SubmitClicked += new EventHandler(frmlogin_SubmitClicked);
                    frmlogin.Show();
                }
                else if (formName == "menu")
                {
                    frmMnu = new frmMenu(userType, userName, EvalDays);
                    frmMnu.MdiParent = this;
                    frmMnu.Dock = DockStyle.Fill;
                    frmMnu.Show();
                }
                else if (formName == "datafile")
                {
                    frmdataFile = new frmDataFile();
                    frmdataFile.MdiParent = this;
                    frmdataFile.Dock = DockStyle.Fill;
                    frmdataFile.SubmitClicked += new EventHandler(frmdataFile_SubmitClicked);
                    frmdataFile.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception In OpenForms. Ex - " + ex.Message.ToString());
            }
        }

        private void CheckNInstallFont()
        {
            try
            {
                if (!FontExist())
                {
                    InstallFont();
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private bool FontExist()
        {
            try
            {
                string filename = "MATURASC.TTF";
                string fontsfolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Fonts);
                if (File.Exists(fontsfolder + @"\" + filename))
                {
                    //MessageBox.Show("FontExist true." + fontsfolder + @"\" + filename);
                    return true;
                }
                else
                {
                    //MessageBox.Show("FontExist false." + fontsfolder + @"\" + filename);
                    return false;
                }
                //var fontCollection = new InstalledFontCollection();
                //foreach (var fontFamily in fontCollection.Families)
                //{
                //    if (fontFamily.Name == "Matura MT Script Capitals")
                //    {
                //        MessageBox.Show("In FontExist true");
                //        return true;
                //    }
                //}
                //return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void InstallFont()
        {
            try
            {
                if (!Directory.Exists(InventoryModel.Classes.Constants.SqliteFilePath))
                    Directory.CreateDirectory(InventoryModel.Classes.Constants.SqliteFilePath);

                //Copy fonts to local folder from application
                string filename = "MATURASC.TTF";
                if (!File.Exists(InventoryModel.Classes.Constants.SqliteFilePath + @"\" + filename))
                {
                    Stream srcFileReader = Assembly.GetCallingAssembly().GetManifestResourceStream("InventoryView.EmbeddedResources." + filename);
                    Stream destFileWriter = File.Create(InventoryModel.Classes.Constants.SqliteFilePath + @"\" + filename);
                    byte[] buffer = new byte[8192];

                    int bytesRead;
                    while ((bytesRead = srcFileReader.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        destFileWriter.Write(buffer, 0, bytesRead);
                    }
                    destFileWriter.Close();
                    srcFileReader.Close();
                }

                //copy fonts to windows fonts folder
                string fontsfolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Fonts);
                File.Copy(InventoryModel.Classes.Constants.SqliteFilePath + @"\" + filename, fontsfolder + @"\" + filename);

                //if (File.Exists(fontsfolder + @"\" + filename))
                //{
                //    MessageBox.Show("InstallFont FontExist true.");
                //}
                //else
                //{
                //    MessageBox.Show("InstallFont FontExist false.");
                //}

                //register fonts
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Fonts");
                key.SetValue("Matura MT Script Capitals (TrueType)", filename);
                key.Close();
                //MessageBox.Show("InstallFont registry false.");
                //File.Delete(InventoryModel.Classes.Data.SqliteFilePath + @"\" + filename);
            }
            catch (Exception)
            {
                //MessageBox.Show("Exception In InstallFont. Ex - "+ ex.Message.ToString());
                return;
            }
        }

        private bool IsAppRunning()
        {
            try
            {
                string currentProcessName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
                System.Diagnostics.Process[] allProcessWithThisName = System.Diagnostics.Process.GetProcessesByName(currentProcessName);

                //if (allProcessWithThisName.Count() > 1)
                //    return true;
                //else
                //    return false;
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception In IsAppRunning - " + ex.Message.ToString());
                return true;
            }
        }

        public void CloseForms()
        {
            Form[] childforms = this.MdiChildren;
            foreach (Form cform in childforms)
            {
                cform.Close();
            }
            //OpenForms("login");
            frmMdiMain_Load(this, new EventArgs());
        }
    }
}
