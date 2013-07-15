using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;
using HS.UI.Common;

namespace HS.DataAccess
{
    public class ConnectionBase
    {
        //private const string CONNECTION_STRING = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};User Id=admin;Password=;";
        private const string CONNECTION_STRING = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Persist Security Info=False;";

        private static OleDbConnection _connection;
        public static OleDbConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    if (System.IO.File.Exists(System.IO.Path.Combine(Application.StartupPath, "Database\\DB.accdb")))
                        _connection = new OleDbConnection(string.Format(CONNECTION_STRING, System.IO.Path.Combine(Application.StartupPath, "Database\\DB.accdb")));
                }

                return _connection;
            }
        }

        private void OpenConnection()
        {
            if (Connection != null)
            {
                Connection.Open();
            }
        }

        private void CloseConnection()
        {
            if (Connection.State != System.Data.ConnectionState.Closed)
            {
                Connection.Close();
            }
        }

        public bool ExcuteSQL(string sqlString, OleDbParameter[] parameters = null)
        {
            try
            {
                OpenConnection();

                using (
                OleDbCommand cm = Connection.CreateCommand())
                {

                    cm.CommandType = System.Data.CommandType.Text;
                    cm.CommandText = sqlString;

                    foreach (OleDbParameter param in parameters)
                    {
                        cm.Parameters.Add(param);
                    }

                    cm.ExecuteNonQuery();
                }


                CloseConnection();
                return true;
            }
            catch (OleDbException exception)
            {
                ErrorLog.Log("ExcuteSQL", exception.Message);

                CloseConnection();
                return false;
            }
        }

        public bool ExcuteStore(string sqlString, OleDbParameter[] parameters = null)
        {
            try
            {
                OpenConnection();

                using (
                OleDbCommand cm = Connection.CreateCommand())
                {

                    cm.CommandType = System.Data.CommandType.StoredProcedure;
                    cm.CommandText = sqlString;

                    foreach (OleDbParameter param in parameters)
                    {
                        cm.Parameters.Add(param);
                    }

                    cm.ExecuteNonQuery();
                }


                CloseConnection();
                return true;
            }
            catch (OleDbException exception)
            {
                ErrorLog.Log("ExcuteSQL", exception.Message);

                CloseConnection();
                return false;
            }
        }

        public DataSet SelectData(string sqlString, OleDbParameter[] parameters = null)
        {
            try
            {
                DataSet data = new DataSet();
                OpenConnection();

                using (OleDbCommand cm = Connection.CreateCommand())
                {
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cm))
                    {
                        cm.CommandType = System.Data.CommandType.Text;
                        cm.CommandText = sqlString;

                        foreach (OleDbParameter param in parameters)
                        {
                            cm.Parameters.Add(param);
                        }

                        da.Fill(data);
                    }
                }

                CloseConnection();
                return data;
            }
            catch (OleDbException exception)
            {
                ErrorLog.Log("ExcuteSQL", exception.Message);

                CloseConnection();
                return null;
            }
        }
    }
}
