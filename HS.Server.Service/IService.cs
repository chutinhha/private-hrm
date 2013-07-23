using HS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HS.Server.Service
{
    public partial class IService
    {
        #region Properties

        private string _connectionString = "";
        public string ConnectionString
        {
            get
            {
                if (_connectionString == "")
                {
                    _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[0].ConnectionString;
                }

                return _connectionString;
            }
        }

        #endregion

        #region Constructors

        public IService()
        {
        }

        #endregion
    }
}
