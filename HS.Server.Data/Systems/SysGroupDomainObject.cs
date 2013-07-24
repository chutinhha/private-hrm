using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HS.Server.Data.Entities.Systems;
using Library.DataAccess;

using HS.UI.Common;
using System.Data;

namespace HS.Server.Data.Systems
{

    /// <summary>
    /// The 24/07/2013 02:38:26 PMDomainObject implemented for Data Access Layer mapped table SysGroup.
    /// CODE:
    ///     - Author:    BangDV
    ///     - Generated Date:  24/07/2013 02:38:26 PM
    /// </summary>
    public class SysGroupDomainObject
    {

        #region Const Fields

        private const System.String SP_SYSGROUP_INSERT = "[dbo].[SYSGROUP_INSERT]";
        private const System.String SP_SYSGROUP_UPDATE = "[dbo].[SYSGROUP_UPDATE]";
        private const System.String SP_SYSGROUP_DELETE = "[dbo].[SYSGROUP_DELETE]";
        private const System.String SP_SYSGROUP_SELECT_BY_ID = "[dbo].[SYSGROUP_SELECT_BYID]";
        private const System.String SP_SYSGROUP_SELECT_ALL = "[dbo].[SYSGROUP_SELECT_ALL]";
        private const System.String SP_SYSGROUP_SELECT_DYNAMIC = "[dbo].[SYSGROUP_SELECT_DYNAMIC]";
        private const System.String SP_SYSGROUP_SELECT_TOP_DYNAMIC = "[dbo].[SYSGROUP_SELECT_TOP_DYNAMIC]";
        private const System.String SP_SYSGROUP_SELECT_COUNT = "[dbo].[SYSGROUP_SELECT_COUNT]";
        private const System.String SP_SYSGROUP_SELECT_PAGING = "[dbo].[SYSGROUP_SELECT_PAGING]";
        #endregion

        #region Properties

        private System.String _ConnectionString = "";
        /// <summary>
        /// Connect to database
        /// </summary>
        public System.String ConnectionString
        {
            get { return _ConnectionString; }
            set { _ConnectionString = value; }
        }

        #endregion

        #region Constructors

        public SysGroupDomainObject()
        {
        }

        public SysGroupDomainObject(System.String connectionString)
        {
            this.ConnectionString = connectionString;
        }

        #endregion

        #region Protected Methods

        protected virtual SysGroupData Convert(DataRow row)
        {
            dynamic data = new DynamicDataRow(row);

            SysGroupData obj = new SysGroupData();

            obj.ID = System.Convert.ToInt32(data.ID);
            obj.ID_Creator = System.Convert.ToInt32(data.ID_Creator);
            obj.Name = System.Convert.ToString(data.Name);
            obj.Description = System.Convert.ToString(data.Description);
            obj.Active = System.Convert.ToBoolean(data.Active);


            return obj;
        }

        #endregion
        #region Pulbic Methods
        public virtual System.Int32 Add(SysGroupData obj)
        {
            JDataAccess dao = new JDataAccess(ConnectionString);
            dao.SetCommandText(SP_SYSGROUP_INSERT, CommandType.StoredProcedure);
            dao.SetParameters(new IDataParameter[]{
                dao.CreateParameter("@ID", obj.ID),
                dao.CreateParameter("@ID_Creator", obj.ID_Creator),
                dao.CreateParameter("@Name", obj.Name),
                dao.CreateParameter("@Description", obj.Description),
                dao.CreateParameter("@Active", obj.Active)

			});
            return dao.SubmitChange();
        }



        public virtual System.Int32 Change(SysGroupData obj)
        {
            JDataAccess dao = new JDataAccess(ConnectionString);
            dao.SetCommandText(SP_SYSGROUP_UPDATE, CommandType.StoredProcedure);
            dao.SetParameters(new IDataParameter[]{
                dao.CreateParameter("@ID", obj.ID),
                dao.CreateParameter("@ID_Creator", obj.ID_Creator),
                dao.CreateParameter("@Name", obj.Name),
                dao.CreateParameter("@Description", obj.Description),
                dao.CreateParameter("@Active", obj.Active)

			});
            return dao.SubmitChange();
        }


        public virtual System.Int32 Remove(SysGroupData obj)
        {
            JDataAccess dao = new JDataAccess(ConnectionString);
            dao.SetCommandText(SP_SYSGROUP_DELETE, CommandType.StoredProcedure);
            dao.SetParameters(new IDataParameter[]{
                dao.CreateParameter("@ID", obj.ID),
                dao.CreateParameter("@ID_Creator", obj.ID_Creator),
                dao.CreateParameter("@Name", obj.Name),
                dao.CreateParameter("@Description", obj.Description),
                dao.CreateParameter("@Active", obj.Active)

			});
            return dao.SubmitChange();
        }


        public virtual SysGroupData GetSysGroupByID(System.Int32 ID)
        {
            JDataAccess dao = new JDataAccess(ConnectionString);
            dao.SetCommandText(SP_SYSGROUP_SELECT_BY_ID, CommandType.StoredProcedure);
            dao.SetParameters(new IDataParameter[]{
dao.CreateParameter("@ID", ID)          });

            DataTable table = dao.ExecuteQuery();
            if (table != null && table.Rows.Count > 0)
            {
                return Convert(table.Rows[0]);
            }

            return default(SysGroupData);
        }


        public virtual IList<SysGroupData> GetSysGroups()
        {
            JDataAccess dao = new JDataAccess(ConnectionString);
            dao.SetCommandText(SP_SYSGROUP_SELECT_ALL, CommandType.StoredProcedure);

            DataTable table = dao.ExecuteQuery();
            if (table != null && table.Rows.Count > 0)
            {
                IList<SysGroupData> list = new List<SysGroupData>(table.Rows.Count);
                foreach (DataRow row in table.Rows)
                {
                    list.Add(Convert(row));
                }

                return list;
            }
            return new List<SysGroupData>();
        }

        public virtual IList<SysGroupData> GetSysGroups(System.String whereCondition)
        {
            JDataAccess dao = new JDataAccess(ConnectionString);
            dao.SetCommandText(SP_SYSGROUP_SELECT_DYNAMIC, CommandType.StoredProcedure);
            dao.SetParameters(new IDataParameter[]{
				dao.CreateParameter("@WhereCondition", whereCondition)
			});

            DataTable table = dao.ExecuteQuery();
            if (table != null && table.Rows.Count > 0)
            {
                IList<SysGroupData> list = new List<SysGroupData>(table.Rows.Count);
                foreach (DataRow row in table.Rows)
                {
                    list.Add(Convert(row));
                }

                return list;
            }
            return new List<SysGroupData>();
        }

        public virtual IList<SysGroupData> GetSysGroups(System.Int32 size, System.String whereCondition)
        {
            JDataAccess dao = new JDataAccess(ConnectionString);
            dao.SetCommandText(SP_SYSGROUP_SELECT_TOP_DYNAMIC, CommandType.StoredProcedure);
            dao.SetParameters(new IDataParameter[]{
				dao.CreateParameter("@Size", size),
				dao.CreateParameter("@WhereCondition", whereCondition)
			});

            DataTable table = dao.ExecuteQuery();
            if (table != null && table.Rows.Count > 0)
            {
                IList<SysGroupData> list = new List<SysGroupData>(table.Rows.Count);
                foreach (DataRow row in table.Rows)
                {
                    list.Add(Convert(row));
                }

                return list;
            }
            return new List<SysGroupData>();
        }

        public virtual System.Int32 GetSysGroupCount(System.String whereCondition)
        {
            JDataAccess dao = new JDataAccess(ConnectionString);
            dao.SetCommandText(SP_SYSGROUP_SELECT_COUNT, CommandType.StoredProcedure);
            dao.SetParameters(new IDataParameter[]{
				dao.CreateParameter("@WhereCondition", whereCondition)
			});

            DataTable table = dao.ExecuteQuery();
            if (table != null && table.Rows.Count > 0)
            {
                return System.Int32.Parse(table.Rows[0][0].ToString());
            }
            return 0;
        }

        public virtual IList<SysGroupData> GetSysGroupPaging(System.String whereCondition, System.Int32 pageSize, System.Int32 currentPage, System.String sortByColumns)
        {
            JDataAccess dao = new JDataAccess(ConnectionString);
            dao.SetCommandText(SP_SYSGROUP_SELECT_PAGING, CommandType.StoredProcedure);
            dao.SetParameters(new IDataParameter[]{
				dao.CreateParameter("@WhereCondition", whereCondition),
				dao.CreateParameter("@PageSize", pageSize),
				dao.CreateParameter("@CurrentPage", currentPage),
				dao.CreateParameter("@SortByColumns", sortByColumns)
			});

            DataTable table = dao.ExecuteQuery();
            if (table != null && table.Rows.Count > 0)
            {
                IList<SysGroupData> list = new List<SysGroupData>(table.Rows.Count);
                foreach (DataRow row in table.Rows)
                {
                    list.Add(Convert(row));
                }

                return list;
            }
            return new List<SysGroupData>();
        }


        #endregion
    }

}
