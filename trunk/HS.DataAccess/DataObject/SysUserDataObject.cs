using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HS.DataAccess.DataObject
{
    public class SysUserDataObject : ConnectionBase
    {
        public BusinessObject.SysUserObject Get(int id)
        {
            try
            {
                DataSet dts = new DataSet();
                BusinessObject.SysUserObject user = new BusinessObject.SysUserObject();

                dts = SelectData(string.Format("SELECT * FROM SYS_USER WHERE ID={0}", id));

                if (dts.Tables.Count == 0 || dts.Tables[0].Rows.Count == 0)
                {
                    //UI.Common.ErrorLog.Log("SysUserDataObject - Get(int)", "Select No Data");
                    return null;
                }

                using (DataTable dtb = dts.Tables[0])
                {
                    user.ID = int.Parse(dtb.Rows[0]["ID"].ToString());
                    user.ID_Group = int.Parse(dtb.Rows[0]["ID_GROUP"].ToString());
                    user.Username = dtb.Rows[0]["USERNAME"].ToString();
                    user.Password = dtb.Rows[0]["PASSWORD"].ToString();
                    user.SecurityQuestion = dtb.Rows[0]["SEC_Q"].ToString();
                    user.SecurityAnswer = dtb.Rows[0]["SEC_A"].ToString();
                    user.LastLogin = (DateTime)dtb.Rows[0]["LAST_LOGIN"];
                    user.State = byte.Parse(dtb.Rows[0]["STATE"].ToString());
                }

                return user;
            }
            catch (Exception ex)
            {
                UI.Common.ErrorLog.Log("SysUserDataObject - Get(int)", ex.Message);
                return null;
            }

        }

        public List<BusinessObject.SysUserObject> GetByGroup(int idGroup)
        {
            try
            {
                DataSet dts = new DataSet();
                List<BusinessObject.SysUserObject> users = new List<BusinessObject.SysUserObject>();

                dts = SelectData(string.Format("SELECT * FROM SYS_USER WHERE ID_GROUP={0}", idGroup));

                if (dts.Tables.Count == 0 || dts.Tables[0].Rows.Count == 0)
                {
                    //UI.Common.ErrorLog.Log("SysUserDataObject - GetByGroup(int)", "Select No Data");
                    return users;
                }

                DataTable dtb = dts.Tables[0];
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    BusinessObject.SysUserObject user = new BusinessObject.SysUserObject();

                    user.ID = int.Parse(dtb.Rows[i]["ID"].ToString());
                    user.ID_Group = int.Parse(dtb.Rows[i]["ID_GROUP"].ToString());
                    user.Username = dtb.Rows[i]["USERNAME"].ToString();
                    user.Password = dtb.Rows[i]["PASSWORD"].ToString();
                    user.SecurityQuestion = dtb.Rows[i]["SEC_Q"].ToString();
                    user.SecurityAnswer = dtb.Rows[i]["SEC_A"].ToString();
                    user.LastLogin = (DateTime)dtb.Rows[i]["LAST_LOGIN"];
                    user.State = byte.Parse(dtb.Rows[i]["STATE"].ToString());

                    users.Add(user);
                }

                return users;
            }
            catch (Exception ex)
            {
                UI.Common.ErrorLog.Log("SysUserDataObject - GetByGroup(int)", ex.Message);
                return null;
            }

        }

        public List<BusinessObject.SysUserObject> GetByCondition(BusinessObject.SysUserSearchObject searchCondition)
        {
            try
            {
                DataSet dts = new DataSet();
                List<BusinessObject.SysUserObject> users = new List<BusinessObject.SysUserObject>();

                string selectString = "SELECT * FROM SYS_USER WHERE (1=1) {0}";

                string whereCondition = "";
                List<System.Data.OleDb.OleDbParameter> param = new List<System.Data.OleDb.OleDbParameter>();

                if (searchCondition.ID_Group.HasValue)
                {
                    whereCondition += " AND SYS_USER.ID_GROUP = @ID_GROUP";
                    param.Add(new System.Data.OleDb.OleDbParameter()
                    {
                        ParameterName = "@ID_GROUP",
                        DbType = System.Data.DbType.Int32,
                        Value = searchCondition.ID_Group.Value
                    });
                }

                if (!string.IsNullOrWhiteSpace(searchCondition.Username))
                {
                    whereCondition += " AND SYS_USER.Username LIKE '%' + @Username + '%' ";
                    param.Add(new System.Data.OleDb.OleDbParameter()
                    {
                        ParameterName = "@Username",
                        DbType = System.Data.DbType.String,
                        Value = searchCondition.Username
                    });
                }

                if (!string.IsNullOrWhiteSpace(searchCondition.Fullname))
                {
                    whereCondition += " AND SYS_USER.Fullname LIKE '%' + @Fullname + '%' ";
                    param.Add(new System.Data.OleDb.OleDbParameter()
                    {
                        ParameterName = "@Fullname",
                        DbType = System.Data.DbType.String,
                        Value = searchCondition.Fullname
                    });
                }

                if (searchCondition.State.HasValue)
                {
                    whereCondition += " AND SYS_USER.STATE = @STATE";
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
                    return users;
                }

                DataTable dtb = dts.Tables[0];
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    BusinessObject.SysUserObject user = new BusinessObject.SysUserObject();

                    user.ID = int.Parse(dtb.Rows[i]["ID"].ToString());
                    user.ID_Group = int.Parse(dtb.Rows[i]["ID_GROUP"].ToString());
                    user.Username = dtb.Rows[i]["USERNAME"].ToString();
                    user.Password = dtb.Rows[i]["PASSWORD"].ToString();
                    user.SecurityQuestion = dtb.Rows[i]["SEC_Q"].ToString();
                    user.SecurityAnswer = dtb.Rows[i]["SEC_A"].ToString();
                    user.LastLogin = (DateTime)dtb.Rows[i]["LAST_LOGIN"];
                    user.State = byte.Parse(dtb.Rows[i]["STATE"].ToString());

                    users.Add(user);
                }

                return users;
            }
            catch (Exception ex)
            {
                UI.Common.ErrorLog.Log("SysUserDataObject - GetByCondition(SysUserSearchObject)", ex.Message);
                return null;
            }

        }
    }
}
