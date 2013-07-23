using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HS.UI.Common;

namespace HS.Service
{
    public class ServiceBase
    {
        public string ServiceName = "";

        public string ServiceAddress
        {
            get
            {
                return Variables.ServiceURL + (Variables.ServiceURL.EndsWith("/") ? "" : "/") + ServiceName;
            }
        }
    }
}
