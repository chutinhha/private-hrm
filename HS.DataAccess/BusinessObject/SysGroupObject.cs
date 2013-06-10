using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HS.DataAccess.BusinessObject
{
    public class SysGroupObject
    {
        public int ID { get; set; }
        public string GroupName {get;set;}
        public byte State { get; set; }
    }

    public class SysGroupSearchObject
    {
        public string GroupName { get; set; }
        public byte? State { get; set; }
    }
}
