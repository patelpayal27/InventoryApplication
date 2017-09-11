using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;

namespace InventoryModel.Classes
{
    class ConnectDB
    {
        SQLiteConnection m_dbConnection = null;
        public void Connect()
        {
            m_dbConnection = new SQLiteConnection("Data Source=" + InventoryModel.Classes.Constants.SqliteFilePath + @"\InventoryDB.sqlite;Version=3;foreign keys=true;");
            m_dbConnection.Open();
        }

        public void DisConnect()
        {
            m_dbConnection.Close();
        }

        public DataSet ExecuteReaderSQLite(string Query)
        {
            try
            {
                Connect();
                SQLiteCommand command = new SQLiteCommand(Query, m_dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                dt.Load(reader);
                ds.Tables.Add(dt);
                DisConnect();
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ExecuteNonQuerySQLite(string Query)
        {
            bool Result = false;
            int intResult = 0;
            try
            {
                Connect();
                SQLiteCommand command = new SQLiteCommand(Query, m_dbConnection);
                intResult = command.ExecuteNonQuery();
                DisConnect();
                if (intResult > 0)
                    Result = true;
                else
                    Result = false;
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
