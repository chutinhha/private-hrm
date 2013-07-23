using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace HS.Server.Data
{
    public class DynamicDataRow : DynamicObject
    {
        System.Data.DataRow row;

        protected DynamicDataRow()
        {
        }

        public DynamicDataRow(System.Data.DataRow row)
        {
            this.row = row;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            try
            {
                result = row[binder.Name] == DBNull.Value ? null : row[binder.Name];
            }
            catch
            {
                result = null; //DBNull.Value;
            }
            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            try
            {
                row[binder.Name] = value;
            }
            catch
            {
                row.Table.Columns.Add(
                    new DataColumn(binder.Name, (value == null ? typeof(System.Object) : value.GetType()))
                );
                row[binder.Name] = value;
            }
            return true;
        }
    }
}
