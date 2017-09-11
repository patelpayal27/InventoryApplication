using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace InventoryModel.Classes
{
    public class DealerT
    {
        ConnectDB DBObj;

        public List<Dealers> GetDealer(int DealerID, bool ShowDeletedAlso)
        {
            string Query = string.Empty;
            List<Dealers> lstDealers = null;
            Dealers DealerObj = null;
            DataSet ds = new DataSet();
            //int SrNo = 0;
            try
            {
                DBObj = new ConnectDB();
                lstDealers = new List<Dealers>();

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
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in ds.Tables[0].Rows)
                    {
                        //SrNo++;
                        DealerObj = new Dealers();
                        //DealerObj.SrNo = SrNo;
                        DealerObj.DealerID = Convert.ToInt32(drow["DealerID"]);
                        DealerObj.DealerName = Convert.ToString(drow["DealerName"]);
                        DealerObj.DealerAddress = Convert.ToString(drow["DealerAddress"]);
                        DealerObj.DealerPhoneNum = Convert.ToString(drow["DealerPhoneNum"]);
                        lstDealers.Add(DealerObj);
                    }
                }
                return lstDealers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddDealer(Dealers Dealerobj)
        {
            string Query = string.Empty;
            bool Result = false;
            try
            {
                DBObj = new ConnectDB();
                Query = "INSERT INTO Dealers (DealerName,DealerAddress,DealerPhoneNum,DelFlag)";
                Query = Query + " VALUES ('" + Dealerobj.DealerName + "','" + Dealerobj.DealerAddress + "','" + Dealerobj.DealerPhoneNum + "','N')";
                Result = DBObj.ExecuteNonQuerySQLite(Query);
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ModifyDealer(Dealers Dealerobj)
        {
            string Query = string.Empty;
            bool Result = false;
            try
            {
                DBObj = new ConnectDB();
                Query = "UPDATE Dealers Set";
                Query = Query + " DealerName = '" + Dealerobj.DealerName + "',";
                Query = Query + " DealerAddress = '" + Dealerobj.DealerAddress + "',";
                Query = Query + " DealerPhoneNum = '" + Dealerobj.DealerPhoneNum + "'";
                Query = Query + " WHERE DealerID = " + Dealerobj.DealerID;
                Result = DBObj.ExecuteNonQuerySQLite(Query);
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RemoveDealer(Dealers Dealerobj)
        {
            string Query = string.Empty;
            bool Result = false;
            try
            {
                DBObj = new ConnectDB();
                Query = "UPDATE Dealers Set DelFlag = 'Y' WHERE DealerID = " + Dealerobj.DealerID;
                //Query = "DELETE FROM Dealers WHERE DealerID = " + Dealerobj.DealerID;
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
