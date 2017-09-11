using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace InventoryView
{
    public partial class frmImpExp : Form
    {
        string ExportFromPath = string.Empty;
        string ExportToPath = string.Empty;
        string ImportFromPath = string.Empty;
        string ImportToPath = string.Empty;
        string Filename = string.Empty;

        public frmImpExp()
        {
            InitializeComponent();
        }

        private void frmImpExp_Load(object sender, EventArgs e)
        {
            btnImport.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(InventoryModel.Classes.Constants.SqliteFilePath))
                    Directory.CreateDirectory(InventoryModel.Classes.Constants.SqliteFilePath);

                string SelectedFilename = string.Empty;
                ImportToPath = InventoryModel.Classes.Constants.SqliteFilePath;
                Filename = "InventoryDB.sqlite";
                OpenFileDialog OFD = new OpenFileDialog();
                OFD.Title = "CHOOSE DATA FILE";
                OFD.InitialDirectory = @"c:\";
                OFD.RestoreDirectory = true;
                OFD.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
                OFD.FilterIndex = 2;
                OFD.Multiselect = false;
                if (OFD.ShowDialog() == DialogResult.OK)
                {
                    ImportFromPath = Path.GetDirectoryName(OFD.FileName);
                    SelectedFilename = Path.GetFileName(OFD.FileName);
                    if (SelectedFilename != Filename)
                    {
                        MessageBox.Show("Select File Cannot Be Imported. Incorrect File.");
                        return;
                    }
                    if (File.Exists(ImportFromPath + @"\" + Filename))
                        File.Copy(ImportFromPath + @"\" + Filename, ImportToPath + @"\" + Filename, true);
                    if (File.Exists(ImportToPath + @"\" + Filename))
                        MessageBox.Show("File Imported Successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnImport_Click, Ex - " + ex.Message.ToString());
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(InventoryModel.Classes.Constants.SqliteFilePath))
                    Directory.CreateDirectory(InventoryModel.Classes.Constants.SqliteFilePath);

                ExportFromPath = InventoryModel.Classes.Constants.SqliteFilePath;//Application.StartupPath;
                Filename = "InventoryDB.sqlite";
                FolderBrowserDialog diaFolder = new FolderBrowserDialog();
                diaFolder.Description = "Select Folder To Save Data File";
                if (diaFolder.ShowDialog() == DialogResult.OK)
                {
                    ExportToPath = diaFolder.SelectedPath;
                    if (File.Exists(ExportFromPath + @"\" + Filename))
                        File.Copy(ExportFromPath + @"\" + Filename, ExportToPath + @"\" + Filename, true);
                    if (File.Exists(ExportToPath + @"\" + Filename))
                        MessageBox.Show("File Exported Successfully - " + ExportToPath + @"\" + Filename);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnExport_Click, Ex - " + ex.Message.ToString());
            }
        }
    }
}
