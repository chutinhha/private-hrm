using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HS.DataAccess.DataObject
{
    public class SysGroupDataObject : ConnectionBase
    {
        /// <summary>
        /// Get by ID
        /// </summary>
        /// <param name="id">ID to get; o = get all</param>
        /// <returns></returns>
        public BusinessObject.SysGroupObject Get(int id)
        {
            try
            {
                DataSet dts = new DataSet();
                BusinessObject.SysGroupObject group = new BusinessObject.SysGroupObject();

                dts = SelectData(string.Format("SELECT * FROM SYS_GROUP WHERE (ID={0} OR {0} = 0)", id));

                if (dts.Tables.Count == 0 || dts.Tables[0].Rows.Count == 0)
                {
                    //UI.Common.ErrorLog.Log("SysUserDataObject - Get(int)", "Select No Data");
                    return null;
                }

                using (DataTable dtb = dts.Tables[0])
                {
                    group.ID = int.Parse(dtb.Rows[0]["ID"].ToString());
                    group.GroupName = dtb.Rows[0]["GROUP_NAME"].ToString();
                    group.State = byte.Parse(dtb.Rows[0]["STATE"].ToString());
                }

                return group;
            }
            catch (Exception ex)
            {
                UI.Common.ErrorLog.Log("SysGroupDataObject - Get(int)", ex.Message);
                return null;
            }
        }
        
        public List<BusinessObject.SysGroupObject> GetByCondition(BusinessObject.SysGroupSearchObject searchCondition)
        {
            try
            {
                DataSet dts = new DataSet();
                List<BusinessObject.SysGroupObject> groups = new List<BusinessObject.SysGroupObject>();

                string selectString = "SELECT * FROM SYS_GROUP WHERE (1=1) {0}";

                string whereCondition = "";
                List<System.Data.OleDb.OleDbParameter> param = new List<System.Data.OleDb.OleDbParameter>();
                
                if (!string.IsNullOrWhiteSpace(searchCondition.GroupName))
                {
                    whereCondition += " AND SYS_GROUP.GROUP_NAME LIKE '%' + @GROUP_NAME + '%' ";
                    param.Add(new System.Data.OleDb.OleDbParameter()
                    {
                        ParameterName = "@GROUP_NAME",
                        DbType = System.Data.DbType.String,
                        Value = searchCondition.GroupName
                    });
                }
                
                if (searchCondition.State.HasValue)
                {
                    whereCondition += " AND SYS_GROUP.STATE = @STATE";
                    param.Add(new System.Data.OleDb.OleDbParameter()
                    {
                        ParameterName = "@STATE",
                        DbType = System.Data.DbType.Int16,
                        Value = searchCondition.State.Value
                    });
                }

                dts = SelectData(string.Format(selectString, whereCondition), param.ToArray());

                if (dts.Tables.Count == 0 || dts.Tables[0].Rows.Count == 0)
                {
                    //UI.Common.ErrorLog.Log("SysUserDataObject - GetByCondition(SysUserSearchObject)", "Select No Data");
                    return groups;
                }

                DataTable dtb = dts.Tables[0];
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    BusinessObject.SysGroupObject group = new BusinessObject.SysGroupObject();

                    group.ID = int.Parse(dtb.Rows[0]["ID"].ToString());
                    group.GroupName = dtb.Rows[0]["GROUP_NAME"].ToString();
                    group.State = byte.Parse(dtb.Rows[0]["STATE"].ToString());

                    groups.Add(group);
                }

                return groups;
            }
            catch (Exception ex)
            {
                UI.Common.ErrorLog.Log("SysGroupDataObject - GetByCondition(SysGroupSearchObject)", ex.Message);
                return null;
            }

        }
    }
}
