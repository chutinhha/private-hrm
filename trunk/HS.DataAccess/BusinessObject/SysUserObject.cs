using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HS.DataAccess.BusinessObject
{
    public class SysUserObject
    {
        public int ID { get; set; }
        public int ID_Group { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }
        public DateTime LastLogin { get; set; }
        public byte State { get; set; }
    }

    public class SysUserSearchObject
    {
        public int? ID_Group { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public byte? State { get; set; }
    }
}
