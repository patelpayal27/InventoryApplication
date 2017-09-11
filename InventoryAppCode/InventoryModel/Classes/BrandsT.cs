using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace InventoryModel.Classes
{
    public class BrandsT
    {
        ConnectDB DBObj;

        public List<Brands> GetBrands(int BrandID, bool ShowDeletedAlso)
        {
            string Query = string.Empty;
            List<Brands> lstBrands = null;
            Brands BrandObj = null;
            DataSet ds = new DataSet();
            //int SrNo = 0;
            try
            {
                DBObj = new ConnectDB();
                lstBrands = new List<Brands>();

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
                }

                ds = DBObj.ExecuteReaderSQLite(Query);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in ds.Tables[0].Rows)
                    {
                        //SrNo++;
                        BrandObj = new Brands();
                        //BrandObj.SrNo = SrNo;
                        BrandObj.BrandID = Convert.ToInt32(drow["BrandID"]);
                        BrandObj.BrandName = Convert.ToString(drow["BrandName"]);
                        lstBrands.Add(BrandObj);
                    }
                }
                return lstBrands;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Brands> GetBrandsbyCatID(int CatID, bool ShowDeletedAlso)
        {
            string Query = string.Empty;
            List<Brands> lstBrands = null;
            Brands BrandObj = null;
            DataSet ds = new DataSet();
            //int SrNo = 0;
            try
            {
                DBObj = new ConnectDB();
                lstBrands = new List<Brands>();

                if (CatID != 0)
                {
                    Query = "SELECT * FROM Brands a INNER JOIN CatBrandMapping b ON a.BrandID = b.BrandID WHERE b.CatID = " + CatID;
                    if (!ShowDeletedAlso)
                        Query = Query + " AND DelFlag = 'N'";
                    Query = Query + " ORDER BY a.BrandID";
                }
                else
                {
                    Query = "SELECT * FROM Brands a INNER JOIN CatBrandMapping b ON a.BrandID = b.BrandID ";
                    if (!ShowDeletedAlso)
                        Query = Query + " AND DelFlag = 'N'";
                    Query = Query + " ORDER BY a.BrandID";
                }

                ds = DBObj.ExecuteReaderSQLite(Query);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in ds.Tables[0].Rows)
                    {
                        //SrNo++;
                        BrandObj = new Brands();
                        //BrandObj.SrNo = SrNo;
                        BrandObj.BrandID = Convert.ToInt32(drow["BrandID"]);
                        BrandObj.BrandName = Convert.ToString(drow["BrandName"]);
                        lstBrands.Add(BrandObj);
                    }
                }
                return lstBrands;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetCategoryByBrand(int BrandID, bool ShowDeletedAlso)
        {
            string Query = string.Empty;
            DataSet ds = new DataSet();
            string CatgeoryName = string.Empty;
            try
            {
                DBObj = new ConnectDB();

                Query = "SELECT * FROM Categories a INNER JOIN CatBrandMapping b ON a.CatID = b.CatID WHERE b.BrandID = " + BrandID;
                if (!ShowDeletedAlso)
                    Query = Query + " AND DelFlag = 'N'";
                Query = Query + " ORDER BY b.BrandID";

                ds = DBObj.ExecuteReaderSQLite(Query);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in ds.Tables[0].Rows)
                    {
                        CatgeoryName = CatgeoryName + ", " + Convert.ToString(drow["CatDesc"]);
                    }
                }
                CatgeoryName = CatgeoryName.Trim(',');
                //CatgeoryName = CatgeoryName.TrimStart(',');
                //CatgeoryName = CatgeoryName.TrimEnd(',');
                return CatgeoryName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetCategoryIdByBrand(int BrandID, bool ShowDeletedAlso)
        {
            string Query = string.Empty;
            DataSet ds = new DataSet();
            string CatgeoryId = string.Empty;
            try
            {
                DBObj = new ConnectDB();

                Query = "SELECT * FROM Categories a INNER JOIN CatBrandMapping b ON a.CatID = b.CatID WHERE b.BrandID = " + BrandID;
                if (!ShowDeletedAlso)
                    Query = Query + " AND DelFlag = 'N'";
                Query = Query + " ORDER BY b.BrandID";

                ds = DBObj.ExecuteReaderSQLite(Query);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in ds.Tables[0].Rows)
                    {
                        CatgeoryId = CatgeoryId + ", " + Convert.ToString(drow["CatID"]);
                    }
                }
                CatgeoryId = CatgeoryId.Trim(',');
                return CatgeoryId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddBrand(Brands Brandobj, List<int> lstCatID)
        {
            string Query = string.Empty;
            bool Result1 = false;
            bool Result2 = false;
            DataSet ds = new DataSet();
            try
            {
                DBObj = new ConnectDB();

                Query = "INSERT INTO Brands (BrandName,DelFlag) values ('" + Brandobj.BrandName + "','N')";
                Result1 = DBObj.ExecuteNonQuerySQLite(Query);

                Query = "SELECT seq FROM sqlite_sequence WHERE NAME = 'Brands'";

                ds = DBObj.ExecuteReaderSQLite(Query);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in ds.Tables[0].Rows)
                    {
                        Brandobj.BrandID = Convert.ToInt32(drow["seq"]);
                    }
                }

                foreach (int CatID in lstCatID)
                {
                    Query = "INSERT INTO CatBrandMapping values (" + CatID + "," + Brandobj.BrandID + ")";
                    Result2 = DBObj.ExecuteNonQuerySQLite(Query);
                }
                return (Result1 && Result2);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ModifyBrand(Brands Brandobj, List<int> lstCatID)
        {
            string Query = string.Empty;
            bool Result1 = false;
            bool Result2 = false;
            try
            {
                DBObj = new ConnectDB();
                Query = "UPDATE Brands Set BrandName = '" + Brandobj.BrandName + "' WHERE BrandID = " + Brandobj.BrandID;
                Result1 = DBObj.ExecuteNonQuerySQLite(Query);

                Query = "DELETE FROM CatBrandMapping WHERE BrandID = " + Brandobj.BrandID;
                Result1 = DBObj.ExecuteNonQuerySQLite(Query);

                foreach (int CatID in lstCatID)
                {
                    Query = "INSERT INTO CatBrandMapping values (" + CatID + "," + Brandobj.BrandID + ")";
                    Result2 = DBObj.ExecuteNonQuerySQLite(Query);
                }
                return (Result1 && Result2);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RemoveBrand(Brands Brandobj)
        {
            string Query = string.Empty;
            bool Result1 = false;
            bool Result2 = false;
            try
            {
                DBObj = new ConnectDB();
                Query = "UPDATE Brands Set DelFlag = 'Y' WHERE BrandID = " + Brandobj.BrandID;
                //Query = "DELETE FROM Brands WHERE BrandID = " + Brandobj.BrandID;
                Result1 = DBObj.ExecuteNonQuerySQLite(Query);

                Query = "DELETE FROM CatBrandMapping WHERE BrandID = " + Brandobj.BrandID;
                Result2 = DBObj.ExecuteNonQuerySQLite(Query);

                return (Result1 && Result2);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
