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
    public partial class frmListData : Form
    {
        public event EventHandler CloseClicked;
        string frmAction = string.Empty;
        string frmMenu = string.Empty;
        string userType = string.Empty;
        string loginName = string.Empty;
        SearchCriteria SearchCri = null;
        CategoriesT CatObj = null;
        BrandsT BrandObj = null;
        DealerT DealerObj = null;
        ItemDataT Itemobj = null;
        UserDataT Userobj = null;
        List<Categories> lstCategories = null;
        List<Brands> lstBrands = null;
        List<Dealers> lstDealers = null;
        List<ItemData> lstItems = null;
        List<UserData> lstUsers = null;

        public frmListData()
        {
            InitializeComponent();
        }
        
        public frmListData(string MenuName)
        {
            InitializeComponent();
            frmMenu = MenuName;
        }

        public frmListData(string MenuName, string _userType, string _loginName)
        {
            InitializeComponent();
            frmMenu = MenuName;
            userType = _userType;
            loginName = _loginName;
        }

        public frmListData(string MenuName, SearchCriteria SCri)
        {
            InitializeComponent();
            frmMenu = MenuName;
            if (SCri != null)
                SearchCri = SCri;
        }

        private void frmListData_Load(object sender, EventArgs e)
        {
            try
            {
                this.ControlBox = false;
                LoadDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmListData_Load, Ex - " + ex.Message.ToString());
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                frmAction = "ADD";
                if (frmMenu == "CAT")
                {
                    frmCategoryAddMod frm = new frmCategoryAddMod(frmAction, null);
                    frm.SubmitClicked += new EventHandler(frm_SubmitClicked);
                    frm.ShowDialog();
                }
                else if (frmMenu == "BRAND")
                {
                    frmBrandAddMod frm = new frmBrandAddMod(frmAction, null, null);
                    frm.SubmitClicked += new EventHandler(frm_SubmitClicked);
                    frm.ShowDialog();
                }
                else if (frmMenu == "DEALER")
                {
                    frmDealerAddMod frm = new frmDealerAddMod(frmAction, null);
                    frm.SubmitClicked += new EventHandler(frm_SubmitClicked);
                    frm.ShowDialog();
                }
                else if (frmMenu == "ITEM")
                {
                    frmItemAddMod frm = new frmItemAddMod(frmAction, null);
                    frm.SubmitClicked += new EventHandler(frm_SubmitClicked);
                    frm.ShowDialog();
                }
                else if (frmMenu == "USER")
                {
                    frmUserAddMod frm = new frmUserAddMod(frmAction, null, userType);
                    frm.SubmitClicked += new EventHandler(frm_SubmitClicked);
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnAdd_Click, Ex - " + ex.Message.ToString());
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                frmAction = "MODIFY";
                if (frmMenu == "CAT")
                {
                    if (grdData.SelectedRows.Count != 0)
                    {
                        Categories Catobj = new Categories();
                        DataGridViewRow row = this.grdData.SelectedRows[0];
                        Catobj.CatID = Convert.ToInt32(row.Cells["CatID"].Value);
                        Catobj.CatDesc = Convert.ToString(row.Cells["CatDesc"].Value);

                        frmCategoryAddMod frm = new frmCategoryAddMod(frmAction, Catobj);
                        frm.SubmitClicked += new EventHandler(frm_SubmitClicked);
                        frm.ShowDialog();
                    }
                    else
                        MessageBox.Show("Please Select A Record To Modify");
                }
                else if (frmMenu == "BRAND")
                {
                    if (grdData.SelectedRows.Count != 0)
                    {
                        BrandObj = new BrandsT();
                        Brands obj = new Brands();
                        List<int> lstCatId = new List<int>();
                        List<string> lstTemp = new List<string>();
                        DataGridViewRow row = this.grdData.SelectedRows[0];
                        obj.BrandID = Convert.ToInt32(row.Cells["Brand ID"].Value);
                        obj.BrandName = Convert.ToString(row.Cells["Brand Name"].Value);
                        lstTemp = Convert.ToString(row.Cells["Category Id"].Value).Split(',').ToList();
                        foreach (var item in lstTemp)
                            lstCatId.Add(Convert.ToInt32(item));

                        frmBrandAddMod frm = new frmBrandAddMod(frmAction, obj, lstCatId);
                        frm.SubmitClicked += new EventHandler(frm_SubmitClicked);
                        frm.ShowDialog();
                    }
                    else
                        MessageBox.Show("Please Select A Record To Modify");
                }
                else if (frmMenu == "DEALER")
                {
                    if (grdData.SelectedRows.Count != 0)
                    {
                        Dealers dealObj = new Dealers();
                        DataGridViewRow row = this.grdData.SelectedRows[0];
                        dealObj.DealerID = Convert.ToInt32(row.Cells["DealerID"].Value);
                        dealObj.DealerName = Convert.ToString(row.Cells["DealerName"].Value);
                        dealObj.DealerAddress = Convert.ToString(row.Cells["DealerAddress"].Value);
                        dealObj.DealerPhoneNum = Convert.ToString(row.Cells["DealerPhoneNum"].Value);

                        frmDealerAddMod frm = new frmDealerAddMod(frmAction, dealObj);
                        frm.SubmitClicked += new EventHandler(frm_SubmitClicked);
                        frm.ShowDialog();
                    }
                    else
                        MessageBox.Show("Please Select A Record To Modify");
                }
                else if (frmMenu == "ITEM")
                {
                    if (grdData.SelectedRows.Count != 0)
                    {
                        ItemData itemobj = new ItemData();
                        DataGridViewRow row = this.grdData.SelectedRows[0];
                        itemobj.ItemID = Convert.ToInt32(row.Cells["ItemID"].Value);
                        itemobj.ModelNumber = Convert.ToString(row.Cells["ModelNumber"].Value);
                        itemobj.CatID = Convert.ToInt32(row.Cells["CatID"].Value);
                        itemobj.BrandID = Convert.ToInt32(row.Cells["BrandID"].Value);
                        itemobj.DealerID = Convert.ToInt32(row.Cells["DealerID"].Value);
                        itemobj.IMEI = Convert.ToString(row.Cells["IMEI"].Value);
                        itemobj.BuyDate = Convert.ToDateTime(row.Cells["BuyDate"].Value);
                        itemobj.BuyPrice = Convert.ToDouble(row.Cells["BuyPrice"].Value);
                        itemobj.CustomerName = Convert.ToString(row.Cells["CustomerName"].Value);
                        itemobj.CustAddress = Convert.ToString(row.Cells["CustAddress"].Value);
                        itemobj.CustPhoneNum = Convert.ToString(row.Cells["CustPhoneNum"].Value);
                        itemobj.SellDate = Convert.ToDateTime(row.Cells["SellDate"].Value);
                        itemobj.SellPrice = Convert.ToDouble(row.Cells["SellPrice"].Value);

                        frmItemAddMod frm = new frmItemAddMod(frmAction, itemobj);
                        frm.SubmitClicked += new EventHandler(frm_SubmitClicked);
                        frm.ShowDialog();
                    }
                    else
                        MessageBox.Show("Please Select A Record To Modify");
                }
                else if (frmMenu == "USER")
                {
                    if (grdData.SelectedRows.Count != 0)
                    {
                        UserData UserDataObj = new UserData();
                        DataGridViewRow row = this.grdData.SelectedRows[0];
                        UserDataObj.ID = Convert.ToInt32(row.Cells["ID"].Value);
                        UserDataObj.UserName = Convert.ToString(row.Cells["UserName"].Value);
                        UserDataObj.Password = Convert.ToString(row.Cells["Password"].Value);
                        UserDataObj.UserType = Convert.ToString(row.Cells["UserType"].Value);

                        frmUserAddMod frm = new frmUserAddMod(frmAction, UserDataObj, userType);
                        frm.SubmitClicked += new EventHandler(frm_SubmitClicked);
                        frm.ShowDialog();
                    }
                    else
                        MessageBox.Show("Please Select A Record To Modify");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnEdit_Click, Ex - " + ex.Message.ToString());
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                var result = MessageBox.Show("Confirm Delete..?", "", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (frmMenu == "CAT")
                    {
                        if (grdData.SelectedRows.Count != 0)
                        {
                            CatObj = new CategoriesT();
                            Categories obj = new Categories();
                            DataGridViewRow row = this.grdData.SelectedRows[0];
                            obj.CatID = Convert.ToInt32(row.Cells["CatID"].Value);

                            if (CatObj.RemoveCategory(obj))
                            {
                                LoadDataGrid();
                            }
                        }
                        else
                            MessageBox.Show("Please Select A Record To Delete");
                    }
                    else if (frmMenu == "BRAND")
                    {
                        if (grdData.SelectedRows.Count != 0)
                        {
                            BrandObj = new BrandsT();
                            Brands obj = new Brands();
                            DataGridViewRow row = this.grdData.SelectedRows[0];
                            obj.BrandID = Convert.ToInt32(row.Cells["Brand ID"].Value);

                            if (BrandObj.RemoveBrand(obj))
                            {
                                LoadDataGrid();
                            }
                        }
                        else
                            MessageBox.Show("Please Select A Record To Delete");
                    }
                    else if (frmMenu == "DEALER")
                    {
                        if (grdData.SelectedRows.Count != 0)
                        {
                            DealerObj = new DealerT();
                            Dealers dealObj = new Dealers();
                            DataGridViewRow row = this.grdData.SelectedRows[0];
                            dealObj.DealerID = Convert.ToInt32(row.Cells["DealerID"].Value);

                            if (DealerObj.RemoveDealer(dealObj))
                            {
                                LoadDataGrid();
                            }
                        }
                        else
                            MessageBox.Show("Please Select A Record To Delete");
                    }
                    else if (frmMenu == "USER")
                    {
                        if (grdData.SelectedRows.Count != 0)
                        {
                            Userobj = new UserDataT();
                            UserData UserDataObj = new UserData();
                            DataGridViewRow row = this.grdData.SelectedRows[0];
                            UserDataObj.ID = Convert.ToInt32(row.Cells["ID"].Value);
                            UserDataObj.UserType = Convert.ToString(row.Cells["UserType"].Value);

                            if (UserDataObj.UserType == "SYSADMIN")
                            {
                                MessageBox.Show("Cannot Delete System Admin User.");
                            }
                            else
                            {
                                if (Userobj.RemoveUser(UserDataObj))
                                {
                                    LoadDataGrid();
                                }
                            }
                        }
                        else
                            MessageBox.Show("Please Select A Record To Delete");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnDel_Click, Ex - " + ex.Message.ToString());
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                frmAction = "VIEW";
                if (frmMenu == "CAT")
                {
                    if (grdData.SelectedRows.Count != 0)
                    {
                        Categories Catobj = new Categories();
                        DataGridViewRow row = this.grdData.SelectedRows[0];
                        Catobj.CatID = Convert.ToInt32(row.Cells["CatID"].Value);
                        Catobj.CatDesc = Convert.ToString(row.Cells["CatDesc"].Value);

                        frmCategoryAddMod frm = new frmCategoryAddMod(frmAction, Catobj);
                        frm.SubmitClicked += new EventHandler(frm_SubmitClicked);
                        frm.ShowDialog();
                    }
                    else
                        MessageBox.Show("Please Select A Record To View");
                }
                else if (frmMenu == "BRAND")
                {
                    if (grdData.SelectedRows.Count != 0)
                    {
                        BrandObj = new BrandsT();
                        Brands obj = new Brands();
                        List<int> lstCatId = new List<int>();
                        List<string> lstTemp = new List<string>();
                        DataGridViewRow row = this.grdData.SelectedRows[0];
                        obj.BrandID = Convert.ToInt32(row.Cells["Brand ID"].Value);
                        obj.BrandName = Convert.ToString(row.Cells["Brand Name"].Value);
                        lstTemp = Convert.ToString(row.Cells["Category Id"].Value).Split(',').ToList();
                        foreach (var item in lstTemp)
                            lstCatId.Add(Convert.ToInt32(item));

                        frmBrandAddMod frm = new frmBrandAddMod(frmAction, obj, lstCatId);
                        frm.SubmitClicked += new EventHandler(frm_SubmitClicked);
                        frm.ShowDialog();
                    }
                    else
                        MessageBox.Show("Please Select A Record To View");
                }
                else if (frmMenu == "DEALER")
                {
                    if (grdData.SelectedRows.Count != 0)
                    {
                        Dealers dealObj = new Dealers();
                        DataGridViewRow row = this.grdData.SelectedRows[0];
                        dealObj.DealerID = Convert.ToInt32(row.Cells["DealerID"].Value);
                        dealObj.DealerName = Convert.ToString(row.Cells["DealerName"].Value);
                        dealObj.DealerAddress = Convert.ToString(row.Cells["DealerAddress"].Value);
                        dealObj.DealerPhoneNum = Convert.ToString(row.Cells["DealerPhoneNum"].Value);

                        frmDealerAddMod frm = new frmDealerAddMod(frmAction, dealObj);
                        frm.SubmitClicked += new EventHandler(frm_SubmitClicked);
                        frm.ShowDialog();
                    }
                    else
                        MessageBox.Show("Please Select A Record To View");
                }
                else if (frmMenu == "ITEM")
                {
                    if (grdData.SelectedRows.Count != 0)
                    {
                        ItemData itemobj = new ItemData();
                        DataGridViewRow row = this.grdData.SelectedRows[0];
                        itemobj.ItemID = Convert.ToInt32(row.Cells["ItemID"].Value);
                        itemobj.CatID = Convert.ToInt32(row.Cells["CatID"].Value);
                        itemobj.BrandID = Convert.ToInt32(row.Cells["BrandID"].Value);
                        itemobj.DealerID = Convert.ToInt32(row.Cells["DealerID"].Value);
                        itemobj.IMEI = Convert.ToString(row.Cells["IMEI"].Value);
                        itemobj.BuyDate = Convert.ToDateTime(row.Cells["BuyDate"].Value);
                        itemobj.BuyPrice = Convert.ToDouble(row.Cells["BuyPrice"].Value);
                        itemobj.CustomerName = Convert.ToString(row.Cells["CustomerName"].Value);
                        itemobj.CustAddress = Convert.ToString(row.Cells["CustAddress"].Value);
                        itemobj.CustPhoneNum = Convert.ToString(row.Cells["CustPhoneNum"].Value);
                        itemobj.SellDate = Convert.ToDateTime(row.Cells["SellDate"].Value);
                        itemobj.SellPrice = Convert.ToDouble(row.Cells["SellPrice"].Value);

                        frmItemAddMod frm = new frmItemAddMod(frmAction, itemobj);
                        frm.SubmitClicked += new EventHandler(frm_SubmitClicked);
                        frm.ShowDialog();
                    }
                    else
                        MessageBox.Show("Please Select A Record To View");
                }
                else if (frmMenu == "USER")
                {
                    if (grdData.SelectedRows.Count != 0)
                    {
                        UserData UserDataObj = new UserData();
                        DataGridViewRow row = this.grdData.SelectedRows[0];
                        UserDataObj.ID = Convert.ToInt32(row.Cells["ID"].Value);
                        UserDataObj.UserName = Convert.ToString(row.Cells["UserName"].Value);
                        UserDataObj.Password = Convert.ToString(row.Cells["Password"].Value);

                        frmUserAddMod frm = new frmUserAddMod(frmAction, UserDataObj, userType);
                        frm.SubmitClicked += new EventHandler(frm_SubmitClicked);
                        frm.ShowDialog();
                    }
                    else
                        MessageBox.Show("Please Select A Record To View");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnView_Click, Ex - " + ex.Message.ToString());
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (frmMenu == "ITEM")
            {
                frmItemSearch frm = new frmItemSearch();
                frm.Close();
                this.CloseClicked(this, new EventArgs());
            }
            this.Close();
        }

        void frm_SubmitClicked(object sender, EventArgs e)
        {
            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            try
            {
                SetToolTip();
                if (frmMenu == "CAT")
                {
                    lblHeader.Text = "Categories";
                    CatObj = new CategoriesT();
                    lstCategories = new List<Categories>();
                    lstCategories = CatObj.GetCategories(0, false);
                    grdData.DataSource = null;
                    grdData.DataSource = lstCategories;
                }
                else if (frmMenu == "BRAND")
                {
                    lblHeader.Text = "Brands";
                    BrandObj = new BrandsT();
                    lstBrands = new List<Brands>();
                    lstBrands = BrandObj.GetBrands(0, false);
                    grdData.DataSource = null;

                    DataTable table = new DataTable();
                    table.Columns.Add("Brand ID", typeof(string));
                    table.Columns.Add("Brand Name", typeof(string));
                    table.Columns.Add("Category Name", typeof(string));
                    table.Columns.Add("Category Id", typeof(string));

                    foreach (Brands a in lstBrands)
                    {
                        table.Rows.Add(a.BrandID, a.BrandName, BrandObj.GetCategoryByBrand(a.BrandID, false), BrandObj.GetCategoryIdByBrand(a.BrandID, false));
                    }
                    grdData.DataSource = table;
                    grdData.Columns[3].Visible = false;
                }
                else if (frmMenu == "DEALER")
                {
                    grdData.Width = 710;
                    btnClose.Location = new Point(705, 436);
                    lblHeader.Text = "Dealers";
                    DealerObj = new DealerT();
                    lstDealers = new List<Dealers>();
                    lstDealers = DealerObj.GetDealer(0, false);
                    grdData.DataSource = null;
                    grdData.DataSource = lstDealers;
                }
                else if (frmMenu == "ITEM")
                {
                    grdData.Width = 710;
                    btnClose.Location = new Point(705, 436);
                    lblHeader.Text = "Items";
                    Itemobj = new ItemDataT();
                    lstItems = new List<ItemData>();
                    //lstItems = Itemobj.GetItem(0, false);
                    lstItems = Itemobj.GetItemData(0, false, SearchCri);
                    grdData.DataSource = null;
                    grdData.DataSource = lstItems;
                    grdData.Columns["CatID"].Visible = false;
                    grdData.Columns["BrandID"].Visible = false;
                    grdData.Columns["DealerID"].Visible = false;
                }
                else if (frmMenu == "USER")
                {
                    lblHeader.Text = "Application Users";
                    Userobj = new UserDataT();
                    lstUsers = new List<UserData>();

                    if (userType == "SYSADMIN")
                    {
                        lstUsers = Userobj.GetUser(0, false);
                        btnAdd.Enabled = true;
                        btnDel.Enabled = true;
                    }
                    else
                    {
                        lstUsers = Userobj.GetUserByName(loginName, false);
                        btnAdd.Enabled = false;
                        btnDel.Enabled = false;
                    }
                    grdData.DataSource = null;
                    grdData.DataSource = lstUsers;
                    grdData.Columns["ID"].Visible = false;
                }
                grdData_Resize();
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadDataGrid, Ex - " + ex.Message.ToString());
            }
        }

        private void SetToolTip()
        {
            try
            {
                ToolTip t = new ToolTip();
                if (frmMenu == "CAT")
                {
                    t.SetToolTip(btnAdd, "Add Category");
                    t.SetToolTip(btnEdit, "Modify Category");
                    t.SetToolTip(btnDel, "Delete Category");
                    t.SetToolTip(btnView, "View Category");
                    t.SetToolTip(btnClose, "Close Categories");
                }
                else if (frmMenu == "BRAND")
                {
                    t.SetToolTip(btnAdd, "Add Brand");
                    t.SetToolTip(btnEdit, "Modify Brand");
                    t.SetToolTip(btnDel, "Delete Brand");
                    t.SetToolTip(btnView, "View Brand");
                    t.SetToolTip(btnClose, "Close Brands");
                }
                else if (frmMenu == "DEALER")
                {
                    t.SetToolTip(btnAdd, "Add Dealer");
                    t.SetToolTip(btnEdit, "Modify Dealer");
                    t.SetToolTip(btnDel, "Delete Dealer");
                    t.SetToolTip(btnView, "View Dealer");
                    t.SetToolTip(btnClose, "Close Dealers");
                }
                else if (frmMenu == "ITEM")
                {
                    t.SetToolTip(btnAdd, "Add Item");
                    t.SetToolTip(btnEdit, "Modify Item");
                    t.SetToolTip(btnDel, "Delete Item");
                    t.SetToolTip(btnView, "View Item");
                    t.SetToolTip(btnClose, "Close Items");
                }
                else if (frmMenu == "USER")
                {
                    t.SetToolTip(btnAdd, "Add User");
                    t.SetToolTip(btnEdit, "Modify User");
                    t.SetToolTip(btnDel, "Delete User");
                    t.SetToolTip(btnView, "View User");
                    t.SetToolTip(btnClose, "Close User");
                }
                else
                {
                    t.SetToolTip(btnAdd, "Add");
                    t.SetToolTip(btnEdit, "Modify");
                    t.SetToolTip(btnDel, "Delete");
                    t.SetToolTip(btnView, "View");
                    t.SetToolTip(btnClose, "Close");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SetToolTip, Ex - " + ex.Message.ToString());
            }
        }

        private void grdData_Resize()
        {
            int width = this.grdData.RowHeadersWidth;
            foreach (DataGridViewColumn col in this.grdData.Columns)
            {
                //col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                width += col.Width;
            }
            if (width < this.grdData.Width)
            {
                this.grdData.Columns[this.grdData.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void grdData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                btnAdd.Focus();
            }
            else if (e.KeyCode == Keys.Shift && e.KeyCode == Keys.Tab)
            {
                btnClose.Focus();
            }
        }
    }
}
