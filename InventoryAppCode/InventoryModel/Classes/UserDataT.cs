using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace InventoryModel.Classes
{
    public class UserDataT
    {
        ConnectDB DBObj;

        public List<UserData> GetUser(int UserID, bool ShowDeletedAlso)
        {
            string Query = string.Empty;
            List<UserData> lstUsers = null;
            UserData UserObj = null;
            DataSet ds = new DataSet();
            //int SrNo = 0;
            try
            {
                DBObj = new ConnectDB();
                lstUsers = new List<UserData>();

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
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in ds.Tables[0].Rows)
                    {
                        //SrNo++;
                        UserObj = new UserData();
                        //DealerObj.SrNo = SrNo;
                        UserObj.ID = Convert.ToInt32(drow["ID"]);
                        UserObj.UserName = Convert.ToString(drow["UserName"]);
                        UserObj.Password = Security.DecryptPswd(Convert.ToString(drow["Password"]));
                        UserObj.UserType = Convert.ToString(drow["UserType"]);
                        lstUsers.Add(UserObj);
                    }
                }
                return lstUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<UserData> GetUserByName(string UserName, bool ShowDeletedAlso)
        {
            string Query = string.Empty;
            List<UserData> lstUsers = null;
            UserData UserObj = null;
            DataSet ds = new DataSet();
            //int SrNo = 0;
            try
            {
                DBObj = new ConnectDB();
                lstUsers = new List<UserData>();

                Query = "SELECT * FROM UserData WHERE UserName = '" + UserName + "' ";
                if (!ShowDeletedAlso)
                    Query = Query + " AND DelFlag = 'N'";
                Query = Query + " ORDER BY ID";

                ds = DBObj.ExecuteReaderSQLite(Query);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in ds.Tables[0].Rows)
                    {
                        //SrNo++;
                        UserObj = new UserData();
                        //DealerObj.SrNo = SrNo;
                        UserObj.ID = Convert.ToInt32(drow["ID"]);
                        UserObj.UserName = Convert.ToString(drow["UserName"]);
                        UserObj.Password = Security.DecryptPswd(Convert.ToString(drow["Password"]));
                        UserObj.UserType = Convert.ToString(drow["UserType"]);
                        lstUsers.Add(UserObj);
                    }
                }
                return lstUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddUser(UserData Userobj)
        {
            string Query = string.Empty;
            DataSet ds = new DataSet();
            bool Result = false;
            try
            {
                DBObj = new ConnectDB();
                Userobj.Password = Security.EncryptPswd(Userobj.Password);

                Query = "SELECT COUNT(1) AS DATACOUNT FROM UserData WHERE UserName = '" + Userobj.UserName.ToUpper() + "'";
                ds = DBObj.ExecuteReaderSQLite(Query);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[0][0]) > 0)
                    {
                        Query = "UPDATE UserData Set DelFlag = 'N', Password = '" + Userobj.Password + "', UserType = '" + Userobj.UserType + "'";
                        Query = Query + " WHERE UserName = '" + Userobj.UserName.ToUpper() + "'";
                        Result = DBObj.ExecuteNonQuerySQLite(Query);
                        return Result;
                    }
                }

                Query = "INSERT INTO UserData (UserName,Password,DelFlag,UserType)";
                Query = Query + " VALUES ('" + Userobj.UserName.ToUpper() + "','" + Userobj.Password + "','N','" + Userobj.UserType + "')";
                Result = DBObj.ExecuteNonQuerySQLite(Query);
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ModifyUser(UserData Userobj)
        {
            string Query = string.Empty;
            bool Result = false;
            try
            {
                Userobj.Password = Security.EncryptPswd(Userobj.Password);

                DBObj = new ConnectDB();
                Query = "UPDATE UserData Set";
                Query = Query + " UserName = '" + Userobj.UserName.ToUpper() + "',";
                Query = Query + " UserType = '" + Userobj.UserType.ToUpper() + "',";
                Query = Query + " Password = '" + Userobj.Password + "'";
                Query = Query + " WHERE ID = " + Userobj.ID;
                Result = DBObj.ExecuteNonQuerySQLite(Query);
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RemoveUser(UserData Userobj)
        {
            string Query = string.Empty;
            bool Result = false;
            try
            {
                DBObj = new ConnectDB();
                Query = "UPDATE UserData Set DelFlag = 'Y' WHERE ID = " + Userobj.ID;
                //Query = "DELETE FROM UserData WHERE ID = " + Dealerobj.ID;
                Result = DBObj.ExecuteNonQuerySQLite(Query);
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckUserPassword(UserData Userobj, ref string Error, ref string UserType)
        {
            string Query = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                Userobj.Password = Security.EncryptPswd(Userobj.Password);

                DBObj = new ConnectDB();
                Query = "SELECT COUNT(1) AS DATACOUNT FROM UserData WHERE UserName = '" + Userobj.UserName.ToUpper() + "'";
                ds = DBObj.ExecuteReaderSQLite(Query);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[0][0]) == 0)
                    {
                        Error = "UserName Does Not Exist.";
                        return false;
                    }
                }

                Query = "SELECT COUNT(1) AS DATACOUNT FROM UserData WHERE UserName = '" + Userobj.UserName.ToUpper() + "' AND Password = '" + Userobj.Password + "'";
                ds = DBObj.ExecuteReaderSQLite(Query);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[0][0]) == 0)
                    {
                        Error = "Incorrect Password.";
                        return false;
                    }
                }

                Query = "SELECT UserType FROM UserData WHERE UserName = '" + Userobj.UserName.ToUpper() + "' AND Password = '" + Userobj.Password + "'";
                ds = DBObj.ExecuteReaderSQLite(Query);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    UserType = Convert.ToString(ds.Tables[0].Rows[0][0]);
                }
                return true;
            }
            catch (Exception ex)
            {
                Error = "Exception in CheckUserPassword - " + ex.Message.ToString();
                throw ex;
            }
        }

        public bool UpdateSysPswd(string password)
        {
            string Query = string.Empty;
            bool Result = false;
            try
            {
                password = Security.EncryptPswd(password);

                DBObj = new ConnectDB();
                Query = "UPDATE UserData Set Password = '" + password + "' WHERE UserName = 'SYSADMIN'";
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
