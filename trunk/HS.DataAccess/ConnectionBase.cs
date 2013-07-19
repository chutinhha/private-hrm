using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using HS.UI.Common;

namespace HS.DataAccess
{
    public class ConnectionBase
    {
        private const string CONNECTION_STRING = "Data Source={0};InitialCatalog={1};User Id={2};Password={3};";
        //private const string CONNECTION_STRING = "Provider=Microsoft.ACE.Sql.12.0;Data Source={0};Persist Security Info=False;";

        private static SqlConnection _connection;
        public static SqlConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    var appSettings = System.Configuration.ConfigurationManager.AppSettings;

                    _connection = new SqlConnection(string.Format(CONNECTION_STRING, appSettings[""]));
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

        public bool ExcuteSQL(string sqlString, SqlParameter[] parameters = null)
        {
            try
            {
                OpenConnection();

                using (
                SqlCommand cm = Connection.CreateCommand())
                {

                    cm.CommandType = System.Data.CommandType.Text;
                    cm.CommandText = sqlString;

                    foreach (SqlParameter param in parameters)
                    {
                        cm.Parameters.Add(param);
                    }

                    cm.ExecuteNonQuery();
                }


                CloseConnection();
                return true;
            }
            catch (SqlException exception)
            {
                ErrorLog.Log("ExcuteSQL", exception.Message);

                CloseConnection();
                return false;
            }
        }

        public bool ExcuteStore(string sqlString, SqlParameter[] parameters = null)
        {
            try
            {
                OpenConnection();

                using (
                SqlCommand cm = Connection.CreateCommand())
                {

                    cm.CommandType = System.Data.CommandType.StoredProcedure;
                    cm.CommandText = sqlString;

                    foreach (SqlParameter param in parameters)
                    {
                        cm.Parameters.Add(param);
                    }

                    cm.ExecuteNonQuery();
                }


                CloseConnection();
                return true;
            }
            catch (SqlException exception)
            {
                ErrorLog.Log("ExcuteSQL", exception.Message);

                CloseConnection();
                return false;
            }
        }

        public DataSet SelectData(string sqlString, SqlParameter[] parameters = null)
        {
            try
            {
                DataSet data = new DataSet();
                OpenConnection();

                using (SqlCommand cm = Connection.CreateCommand())
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cm))
                    {
                        cm.CommandType = System.Data.CommandType.Text;
                        cm.CommandText = sqlString;

                        foreach (SqlParameter param in parameters)
                        {
                            cm.Parameters.Add(param);
                        }

                        da.Fill(data);
                    }
                }

                CloseConnection();
                return data;
            }
            catch (SqlException exception)
            {
                ErrorLog.Log("ExcuteSQL", exception.Message);

                CloseConnection();
                return null;
            }
        }
    }
}
