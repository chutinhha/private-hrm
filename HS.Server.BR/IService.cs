using HS.UI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HS.Server.BR
{
    public partial class IService
    {
        #region Properties

        private System.String _ConnectionString = "";
        /// <summary>
        /// Connect to database
        /// </summary>
        public System.String ConnectionString
        {
            get
            {
                if (_ConnectionString == "")
                {
                    _ConnectionString = Variables.ConnectionString;
                }
                return _ConnectionString;
            }
            set { _ConnectionString = value; }
        }

        #endregion

        #region Constructors

        public IService()
        {
        }

        public IService(System.String connectionString)
        {
            this.ConnectionString = connectionString;
        }

        #endregion
    }
}
