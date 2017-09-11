using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace InventoryModel.Classes
{
    public class ItemDataT
    {
        ConnectDB DBObj;

        public List<ItemData> GetItem(int ItemID, bool ShowDeletedAlso)
        {
            string Query = string.Empty;
            List<ItemData> lstItemData = null;
            ItemData ItemDataObj = null;
            DataSet ds = new DataSet();
            //int SrNo = 0;
            try
            {
                DBObj = new ConnectDB();
                lstItemData = new List<ItemData>();

                if (ItemID != 0)
                {
                    Query = "SELECT * FROM ItemData WHERE ItemID = " + ItemID;
                    if (!ShowDeletedAlso)
                        Query = Query + " AND DelFlag = 'N'";
                    Query = Query + " ORDER BY ItemID";
                }
                else
                {
                    Query = "SELECT * FROM ItemData";
                    if (!ShowDeletedAlso)
                        Query = Query + " WHERE DelFlag = 'N'";
                    Query = Query + " ORDER BY ItemID";
                }

                ds = DBObj.ExecuteReaderSQLite(Query);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in ds.Tables[0].Rows)
                    {
                        //SrNo++;
                        ItemDataObj = new ItemData();
                        //ItemDataObj.SrNo = SrNo;
                        ItemDataObj.ItemID = Convert.ToInt32(drow["ItemID"]);
                        ItemDataObj.ModelNumber = Convert.ToString(drow["ModelNumber"]);
                        ItemDataObj.IMEI = Convert.ToString(drow["IMEI"]);
                        ItemDataObj.CatID = Convert.ToInt32(drow["CatID"]);
                        ItemDataObj.BrandID = Convert.ToInt32(drow["BrandID"]);
                        ItemDataObj.DealerID = Convert.ToInt32(drow["DealerID"]);
                        ItemDataObj.BuyDate = Convert.ToDateTime(Convert.ToString(drow["BuyDate"]));
                        ItemDataObj.BuyPrice = Convert.ToDouble(drow["BuyPrice"]);
                        ItemDataObj.CustomerName = Convert.ToString(drow["CustomerName"]);
                        ItemDataObj.CustAddress = Convert.ToString(drow["CustAddress"]);
                        ItemDataObj.CustPhoneNum = Convert.ToString(drow["CustPhoneNum"]);
                        ItemDataObj.SellDate = Convert.ToDateTime(Convert.ToString(drow["SellDate"]));
                        ItemDataObj.SellPrice = Convert.ToDouble(drow["SellPrice"]);
                        lstItemData.Add(ItemDataObj);
                    }
                }
                return lstItemData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ItemData> GetItemData(int ItemID, bool ShowDeletedAlso, SearchCriteria SCri)
        {
            string Query = string.Empty;
            List<ItemData> lstItemData = null;
            ItemData ItemDataObj = null;
            DataSet ds = new DataSet();
            //int SrNo = 0;
            try
            {
                DBObj = new ConnectDB();
                lstItemData = new List<ItemData>();

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

                    //Query = "SELECT * FROM ItemData WHERE ItemID = " + ItemID;
                    //if (!ShowDeletedAlso)
                    //    Query = Query + " AND DelFlag = 'N'";
                    //Query = Query + " ORDER BY ItemID";
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

                        //string v = Convert.ToDateTime(SCri.BuyFromDate).ToString("yyyy-MM-dd");

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
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in ds.Tables[0].Rows)
                    {
                        //SrNo++;
                        ItemDataObj = new ItemData();
                        //ItemDataObj.SrNo = SrNo;
                        ItemDataObj.ItemID = Convert.ToInt32(drow["ItemID"]);
                        ItemDataObj.ModelNumber = Convert.ToString(drow["ModelNumber"]);
                        ItemDataObj.IMEI = Convert.ToString(drow["IMEI"]);
                        ItemDataObj.CatID = Convert.ToInt32(drow["CatID"]);
                        ItemDataObj.BrandID = Convert.ToInt32(drow["BrandID"]);
                        ItemDataObj.DealerID = Convert.ToInt32(drow["DealerID"]);
                        ItemDataObj.BuyDate = Convert.ToDateTime(Convert.ToString(drow["BuyDate"])).Date;
                        ItemDataObj.BuyPrice = Convert.ToDouble(drow["BuyPrice"]);
                        ItemDataObj.CustomerName = Convert.ToString(drow["CustomerName"]);
                        ItemDataObj.CustAddress = Convert.ToString(drow["CustAddress"]);
                        ItemDataObj.CustPhoneNum = Convert.ToString(drow["CustPhoneNum"]);
                        ItemDataObj.SellDate = Convert.ToDateTime(Convert.ToString(drow["SellDate"])).Date;
                        ItemDataObj.SellPrice = Convert.ToDouble(drow["SellPrice"]);
                        ItemDataObj.CatDesc = Convert.ToString(drow["CatDesc"]);
                        ItemDataObj.BrandName = Convert.ToString(drow["BrandName"]);
                        ItemDataObj.DealerName = Convert.ToString(drow["DealerName"]);
                        lstItemData.Add(ItemDataObj);
                    }
                }

                //if (SCri.BuyFromDate != null || SCri.SellFromDate != null)
                //{
                //    List<ItemData> lstFilterItemData = new List<ItemData>();
                //    if (SCri.BuyFromDate != null)
                //    {
                //        lstFilterItemData = lstItemData.Where(x => x.BuyDate >= Convert.ToDateTime(SCri.BuyFromDate))
                //                                       .Where(x => x.BuyDate <= Convert.ToDateTime(SCri.BuyToDate)).ToList();
                //    }
                //    else
                //    {
                //        lstFilterItemData = lstItemData.Where(x => x.BuyDate <= Convert.ToDateTime(SCri.SellFromDate))
                //                                       .Where(x => x.BuyDate >= Convert.ToDateTime(SCri.SellToDate)).ToList();
                //    }
                //    return lstFilterItemData;
                //}
                return lstItemData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddItem(ItemData ItemDataobj)
        {
            string Query = string.Empty;
            bool Result = false;
            try
            {
                DBObj = new ConnectDB();
                Query = "INSERT INTO ItemData";
                Query = Query + " (ModelNumber,IMEI,CatID,BrandID,DealerID,BuyDate,BuyPrice,CustomerName,CustAddress,CustPhoneNum,SellDate,SellPrice,DelFlag)";
                Query = Query + " VALUES('" + ItemDataobj.ModelNumber + "','" + ItemDataobj.IMEI + "','" + ItemDataobj.CatID + "','" + ItemDataobj.BrandID + "'";
                Query = Query + " ,'" + ItemDataobj.DealerID + "','" + ItemDataobj.BuyDate.ToString("yyyy-MM-dd") + "','" + ItemDataobj.BuyPrice + "'";
                Query = Query + " ,'" + ItemDataobj.CustomerName + "','" + ItemDataobj.CustAddress + "','" + ItemDataobj.CustPhoneNum + "'";
                Query = Query + " ,'" + ItemDataobj.SellDate.ToString("yyyy-MM-dd") + "','" + ItemDataobj.SellPrice + "','N')";
                Result = DBObj.ExecuteNonQuerySQLite(Query);
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ModifyItem(ItemData ItemDataobj)
        {
            string Query = string.Empty;
            bool Result = false;
            try
            {
                DBObj = new ConnectDB();
                Query = "UPDATE ItemData Set";
                Query = Query + " ModelNumber = '" + ItemDataobj.ModelNumber + "',";
                Query = Query + " IMEI = '" + ItemDataobj.IMEI + "',";
                Query = Query + " CatID = '" + ItemDataobj.CatID + "',";
                Query = Query + " BrandID = '" + ItemDataobj.BrandID + "',";
                Query = Query + " DealerID = '" + ItemDataobj.DealerID + "',";
                Query = Query + " BuyDate = '" + ItemDataobj.BuyDate.ToString("yyyy-MM-dd") + "',";
                Query = Query + " BuyPrice = '" + ItemDataobj.BuyPrice + "',";
                Query = Query + " CustomerName = '" + ItemDataobj.CustomerName + "',";
                Query = Query + " CustAddress = '" + ItemDataobj.CustAddress + "',";
                Query = Query + " CustPhoneNum = '" + ItemDataobj.CustPhoneNum + "',";
                Query = Query + " SellDate = '" + ItemDataobj.SellDate.ToString("yyyy-MM-dd") + "',";
                Query = Query + " SellPrice = '" + ItemDataobj.SellPrice + "'";
                Query = Query + " WHERE ItemID = " + ItemDataobj.ItemID;
                Result = DBObj.ExecuteNonQuerySQLite(Query);
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RemoveItem(ItemData ItemDataobj)
        {
            string Query = string.Empty;
            bool Result = false;
            try
            {
                DBObj = new ConnectDB();
                Query = "UPDATE ItemData Set DelFlag = 'Y' WHERE ItemID = " + ItemDataobj.ItemID;
                //Query = "DELETE FROM ItemData WHERE ItemID = " + ItemDataobj.ItemID;
                Result = DBObj.ExecuteNonQuerySQLite(Query);
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
