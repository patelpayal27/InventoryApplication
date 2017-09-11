using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace InventoryModel.Classes
{
    public class CategoriesT
    {
        ConnectDB DBObj;

        public List<Categories> GetCategories(int CatID, bool ShowDeletedAlso)
        {
            string Query = string.Empty;
            List<Categories> lstCategories = null;
            Categories CatObj = null;
            DataSet ds = new DataSet();
            //int SrNo = 0;
            try
            {
                DBObj = new ConnectDB();
                lstCategories = new List<Categories>();

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
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in ds.Tables[0].Rows)
                    {
                        //SrNo++;
                        CatObj = new Categories();
                        //CatObj.SrNo = SrNo;
                        CatObj.CatID = Convert.ToInt32(drow["CatID"]);
                        CatObj.CatDesc = Convert.ToString(drow["CatDesc"]);
                        lstCategories.Add(CatObj);
                    }
                }
                return lstCategories;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddCategory(Categories Catobj)
        {
            string Query = string.Empty;
            bool Result = false;
            try
            {
                DBObj = new ConnectDB();
                Query = "INSERT INTO Categories (CatDesc,DelFlag) values ('" + Catobj.CatDesc + "','N')";
                Result = DBObj.ExecuteNonQuerySQLite(Query);
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ModifyCategory(Categories Catobj)
        {
            string Query = string.Empty;
            bool Result = false;
            try
            {
                DBObj = new ConnectDB();
                Query = "UPDATE Categories Set CatDesc = '" + Catobj.CatDesc + "' WHERE CatID = " + Catobj.CatID;
                Result = DBObj.ExecuteNonQuerySQLite(Query);
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RemoveCategory(Categories Catobj)
        {
            string Query = string.Empty;
            bool Result = false;
            try
            {
                DBObj = new ConnectDB();
                Query = "UPDATE Categories Set DelFlag = 'Y' WHERE CatID = " + Catobj.CatID;
                //Query = "DELETE FROM Categories WHERE CatID = " + Catobj.CatID;
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
