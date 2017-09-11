using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace InventoryModel.Classes
{
    public class Datasets
    {
        ConnectDB DBObj;

        public DataSet GetItemDataset(int ItemID, bool ShowDeletedAlso, SearchCriteria SCri)
        {
            string Query = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                DBObj = new ConnectDB();
                if (ItemID != 0)
                {
                    Query = "SELECT I.ItemID,I.ModelNumber,I.IMEI,I.CatID,I.BrandID,I.DealerID,I.BuyDate,I.BuyPrice,I.CustomerName,I.CustAddress,I.CustPhoneNum, ";
                    Query = Query + " I.SellDate,I.SellPrice,C.CatDesc,B.BrandName,D.DealerName ";
                    Query = Query + " FROM ItemData I INNER JOIN Categories C ON I.CatID = C.CatID";
                    Query = Query + " INNER JOIN Brands B ON I.BrandID = B.BrandID ";
                    Query = Query + " INNER JOIN Dealers D ON I.DealerID = D.DealerID WHERE I.ItemID = " + ItemID;
                    if (!ShowDeletedAlso)
                        Query = Query + " AND I.DelFlag = 'N'";
                    Query = Query + " ORDER BY I.ItemID";
                }
                else if (SCri != null)
                {
                    Query = "SELECT I.ItemID,I.ModelNumber,I.IMEI,I.CatID,I.BrandID,I.DealerID,I.BuyDate,I.BuyPrice,I.CustomerName,I.CustAddress,I.CustPhoneNum, ";
                    Query = Query + " I.SellDate,I.SellPrice,C.CatDesc,B.BrandName,D.DealerName ";
                    Query = Query + " FROM ItemData I INNER JOIN Categories C ON I.CatID = C.CatID";
                    Query = Query + " INNER JOIN Brands B ON I.BrandID = B.BrandID ";
                    Query = Query + " INNER JOIN Dealers D ON I.DealerID = D.DealerID ";
                    if (SCri.ShowAll == null)
                    {
                        Query = Query + " WHERE ";
                        if (SCri.ItemID != 0)
                            Query = Query + "I.ItemID = " + SCri.ItemID;
                        else if (SCri.CatID != 0)
                            Query = Query + "I.CatID = " + SCri.CatID;
                        else if (SCri.BrandID != 0)
                            Query = Query + "I.BrandID = " + SCri.BrandID;
                        else if (SCri.DealerID != 0)
                            Query = Query + "I.DealerID = " + SCri.DealerID;
                        else if (SCri.BuyFromPrice != null)
                            Query = Query + "I.BuyPrice BETWEEN " + SCri.BuyFromPrice + " AND " + SCri.BuyToPrice;
                        else if (SCri.SellFromPrice != null)
                            Query = Query + "I.BuyPrice BETWEEN " + SCri.SellFromPrice + " AND " + SCri.SellToPrice;
                        else if (SCri.BuyFromDate != null && SCri.BuyFromDate.ToString("yyyy-MM-dd") != "0001-01-01")
                            Query = Query + "Date(I.BuyDate) BETWEEN Date('" + SCri.BuyFromDate.ToString("yyyy-MM-dd") + "') AND Date('" + SCri.BuyToDate.ToString("yyyy-MM-dd") + "')";
                        else if (SCri.SellFromDate != null && SCri.SellFromDate.ToString("yyyy-MM-dd") != "0001-01-01")
                            Query = Query + "Date(I.SellDate) BETWEEN Date('" + SCri.SellFromDate.ToString("yyyy-MM-dd") + "') AND Date('" + SCri.SellToDate.ToString("yyyy-MM-dd") + "')";

                        string v = Convert.ToDateTime(SCri.BuyFromDate).ToString("yyyy-MM-dd");

                        if (!ShowDeletedAlso)
                            Query = Query + " AND I.DelFlag = 'N'";
                    }
                    else
                    {
                        if (!ShowDeletedAlso)
                            Query = Query + " WHERE I.DelFlag = 'N'";
                    }
                    Query = Query + " ORDER BY I.ItemID";
                }
                else
                {
                    Query = "SELECT I.ItemID,I.ModelNumber,I.IMEI,I.CatID,I.BrandID,I.DealerID,I.BuyDate,I.BuyPrice,I.CustomerName,I.CustAddress,I.CustPhoneNum, ";
                    Query = Query + " I.SellDate,I.SellPrice,C.CatDesc,B.BrandName,D.DealerName ";
                    Query = Query + " FROM ItemData I INNER JOIN Categories C ON I.CatID = C.CatID";
                    Query = Query + " INNER JOIN Brands B ON I.BrandID = B.BrandID ";
                    Query = Query + " INNER JOIN Dealers D ON I.DealerID = D.DealerID ";
                    if (!ShowDeletedAlso)
                        Query = Query + " WHERE I.DelFlag = 'N'";
                    Query = Query + " ORDER BY I.ItemID";
                }

                ds = DBObj.ExecuteReaderSQLite(Query);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetCategorieDataset(int CatID, bool ShowDeletedAlso)
        {
            string Query = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                DBObj = new ConnectDB();
                if (CatID != 0)
                {
                    Query = "SELECT * FROM Categories WHERE CatID = " + CatID;
                    if (!ShowDeletedAlso)
                        Query = Query + " AND DelFlag = 'N'";
                    Query = Query + " ORDER BY CatID";
                }
                else
                {
                    Query = "SELECT * FROM Categories";
                    if (!ShowDeletedAlso)
                        Query = Query + " WHERE DelFlag = 'N'";
                    Query = Query + " ORDER BY CatID";
                }

                ds = DBObj.ExecuteReaderSQLite(Query);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetBrandsDataset(int BrandID, bool ShowDeletedAlso)
        {
            string Query = string.Empty;
            string CatgeoryName = string.Empty;
            DataSet ds = new DataSet();
            DataSet dsResult = new DataSet();
            try
            {
                DBObj = new ConnectDB();
                if (BrandID != 0)
                {
                    Query = "SELECT * FROM Brands WHERE BrandID = " + BrandID;
                    if (!ShowDeletedAlso)
                        Query = Query + " WHERE DelFlag = 'N'";
                    Query = Query + " ORDER BY BrandID";
                }
                else
                {
                    Query = "SELECT * FROM Brands ";
                    if (!ShowDeletedAlso)
                        Query = Query + " WHERE DelFlag = 'N'";
                    Query = Query + " ORDER BY BrandID";

                    Query = "SELECT *,(SELECT CatDesc FROM Categories a INNER JOIN CatBrandMapping b ON a.CatID = b.CatID WHERE b.BrandID =  Br.BrandID) AS Category FROM Brands Br";
                    if (!ShowDeletedAlso)
                        Query = Query + " WHERE DelFlag = 'N'";
                    Query = Query + " ORDER BY BrandID";
                }
                ds = DBObj.ExecuteReaderSQLite(Query);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataSet ds1 = new DataSet();
                    DataTable dt = new DataTable();
                    DataRow dr;
                    DataColumn ColBrandID;
                    DataColumn ColBrandName;
                    DataColumn ColDelFlag;
                    DataColumn ColCategory;

                    ColBrandID = new DataColumn("BrandID", Type.GetType("System.Int32"));
                    ColBrandName = new DataColumn("BrandName", Type.GetType("System.String"));
                    ColDelFlag = new DataColumn("DelFlag", Type.GetType("System.String"));
                    ColCategory = new DataColumn("Category", Type.GetType("System.String"));

                    dt.Columns.Add(ColBrandID);
                    dt.Columns.Add(ColBrandName);
                    dt.Columns.Add(ColDelFlag);
                    dt.Columns.Add(ColCategory);

                    foreach (DataRow drow in ds.Tables[0].Rows)
                    {
                        CatgeoryName = string.Empty;
                        Query = "SELECT * FROM Categories a INNER JOIN CatBrandMapping b ON a.CatID = b.CatID WHERE b.BrandID = " + drow["BrandID"];
                        if (!ShowDeletedAlso)
                            Query = Query + " AND DelFlag = 'N'";
                        Query = Query + " ORDER BY b.BrandID";

                        ds1 = DBObj.ExecuteReaderSQLite(Query);
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow drow1 in ds1.Tables[0].Rows)
                            {
                                CatgeoryName = CatgeoryName + ", " + Convert.ToString(drow1["CatDesc"]);
                            }
                        }
                        CatgeoryName = CatgeoryName.Trim(',');

                        dr = dt.NewRow();
                        dr["BrandID"] = drow["BrandID"];
                        dr["BrandName"] = drow["BrandName"];
                        dr["DelFlag"] = drow["DelFlag"];
                        dr["Category"] = CatgeoryName;
                        dt.Rows.Add(dr);
                    }
                    dsResult.Tables.Add(dt);
                }
                return dsResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetDealerDataset(int DealerID, bool ShowDeletedAlso)
        {
            string Query = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                DBObj = new ConnectDB();

                if (DealerID != 0)
                {
                    Query = "SELECT * FROM Dealers WHERE DealerID = " + DealerID;
                    if (!ShowDeletedAlso)
                        Query = Query + " AND DelFlag = 'N'";
                    Query = Query + " ORDER BY DealerID";
                }
                else
                {
                    Query = "SELECT * FROM Dealers";
                    if (!ShowDeletedAlso)
                        Query = Query + " WHERE DelFlag = 'N'";
                    Query = Query + " ORDER BY DealerID";
                }

                ds = DBObj.ExecuteReaderSQLite(Query);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetUserDataset(int UserID, bool ShowDeletedAlso)
        {
            string Query = string.Empty;
            List<Classes.UserData> lstUsers = null;
            DataSet ds = new DataSet();
            try
            {
                DBObj = new ConnectDB();
                lstUsers = new List<Classes.UserData>();

                if (UserID != 0)
                {
                    Query = "SELECT * FROM UserData WHERE ID = " + UserID;
                    if (!ShowDeletedAlso)
                        Query = Query + " AND DelFlag = 'N'";
                    Query = Query + " ORDER BY ID";
                }
                else
                {
                    Query = "SELECT * FROM UserData";
                    if (!ShowDeletedAlso)
                        Query = Query + " WHERE DelFlag = 'N'";
                    Query = Query + " ORDER BY ID";
                }

                ds = DBObj.ExecuteReaderSQLite(Query);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
