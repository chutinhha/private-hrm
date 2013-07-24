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
    /// The 24/07/2013 02:11:42 PMDomainObject implemented for Data Access Layer mapped table SysAccount.
    /// CODE:
    ///     - Author:    BangDV
    ///     - Generated Date:  24/07/2013 02:11:42 PM
    /// </summary>
    public class SysAccountDomainObject
    {

        #region Const Fields

        private const System.String SP_SYSACCOUNT_INSERT = "[dbo].[SYSACCOUNT_INSERT]";
        private const System.String SP_SYSACCOUNT_UPDATE = "[dbo].[SYSACCOUNT_UPDATE]";
        private const System.String SP_SYSACCOUNT_DELETE = "[dbo].[SYSACCOUNT_DELETE]";
        private const System.String SP_SYSACCOUNT_SELECT_BY_ID = "[dbo].[SYSACCOUNT_SELECT_BYID]";
        private const System.String SP_SYSACCOUNT_SELECT_ALL = "[dbo].[SYSACCOUNT_SELECT_ALL]";
        private const System.String SP_SYSACCOUNT_SELECT_DYNAMIC = "[dbo].[SYSACCOUNT_SELECT_DYNAMIC]";
        private const System.String SP_SYSACCOUNT_SELECT_TOP_DYNAMIC = "[dbo].[SYSACCOUNT_SELECT_TOP_DYNAMIC]";
        private const System.String SP_SYSACCOUNT_SELECT_COUNT = "[dbo].[SYSACCOUNT_SELECT_COUNT]";
        private const System.String SP_SYSACCOUNT_SELECT_PAGING = "[dbo].[SYSACCOUNT_SELECT_PAGING]";
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

        public SysAccountDomainObject()
        {
        }

        public SysAccountDomainObject(System.String connectionString)
        {
            this.ConnectionString = connectionString;
        }

        #endregion

        #region Protected Methods

        protected virtual SysAccountData Convert(DataRow row)
        {
            dynamic data = new DynamicDataRow(row);

            SysAccountData obj = new SysAccountData();

            obj.ID = System.Convert.ToInt32(data.ID);
            obj.Username = System.Convert.ToString(data.Username);
            obj.Password = System.Convert.ToString(data.Password);
            obj.RealName = System.Convert.ToString(data.RealName);
            obj.Email = System.Convert.ToString(data.Email);
            obj.ID_DonVis = System.Convert.ToString(data.ID_DonVis);
            obj.LastAccess = data.LastAccess != null ? System.Convert.ToDateTime(data.LastAccess) : (DateTime?)null;
            obj.Active = System.Convert.ToBoolean(data.Active);
            obj.AccountType = System.Convert.ToByte(data.AccountType);
            obj.Creator_ID = System.Convert.ToInt32(data.Creator_ID);
            obj.ID_DonViGoc = System.Convert.ToInt32(data.ID_DonViGoc);
            obj.IsUpdate = System.Convert.ToBoolean(data.IsUpdate);


            return obj;
        }

        #endregion

        #region Pulbic Methods
        public virtual System.Int32 Add(SysAccountData obj)
        {
            JDataAccess dao = new JDataAccess(ConnectionString);
            dao.SetCommandText(SP_SYSACCOUNT_INSERT, CommandType.StoredProcedure);
            dao.SetParameters(new IDataParameter[]{
                dao.CreateParameter("@ID", obj.ID),
                dao.CreateParameter("@Username", obj.Username),
                dao.CreateParameter("@Password", obj.Password),
                dao.CreateParameter("@RealName", obj.RealName),
                dao.CreateParameter("@Email", obj.Email),
                dao.CreateParameter("@ID_DonVis", obj.ID_DonVis),
                dao.CreateParameter("@LastAccess", obj.LastAccess),
                dao.CreateParameter("@Active", obj.Active),
                dao.CreateParameter("@AccountType", obj.AccountType),
                dao.CreateParameter("@Creator_ID", obj.Creator_ID),
                dao.CreateParameter("@ID_DonViGoc", obj.ID_DonViGoc),
                dao.CreateParameter("@IsUpdate", obj.IsUpdate)

			});
            return dao.SubmitChange();
        }



        public virtual System.Int32 Change(SysAccountData obj)
        {
            JDataAccess dao = new JDataAccess(ConnectionString);
            dao.SetCommandText(SP_SYSACCOUNT_UPDATE, CommandType.StoredProcedure);
            dao.SetParameters(new IDataParameter[]{
                dao.CreateParameter("@ID", obj.ID),
                dao.CreateParameter("@Username", obj.Username),
                dao.CreateParameter("@Password", obj.Password),
                dao.CreateParameter("@RealName", obj.RealName),
                dao.CreateParameter("@Email", obj.Email),
                dao.CreateParameter("@ID_DonVis", obj.ID_DonVis),
                dao.CreateParameter("@LastAccess", obj.LastAccess),
                dao.CreateParameter("@Active", obj.Active),
                dao.CreateParameter("@AccountType", obj.AccountType),
                dao.CreateParameter("@Creator_ID", obj.Creator_ID),
                dao.CreateParameter("@ID_DonViGoc", obj.ID_DonViGoc),
                dao.CreateParameter("@IsUpdate", obj.IsUpdate)

			});
            return dao.SubmitChange();
        }


        public virtual System.Int32 Remove(SysAccountData obj)
        {
            JDataAccess dao = new JDataAccess(ConnectionString);
            dao.SetCommandText(SP_SYSACCOUNT_DELETE, CommandType.StoredProcedure);
            dao.SetParameters(new IDataParameter[]{
                dao.CreateParameter("@ID", obj.ID),
                dao.CreateParameter("@Username", obj.Username),
                dao.CreateParameter("@Password", obj.Password),
                dao.CreateParameter("@RealName", obj.RealName),
                dao.CreateParameter("@Email", obj.Email),
                dao.CreateParameter("@ID_DonVis", obj.ID_DonVis),
                dao.CreateParameter("@LastAccess", obj.LastAccess),
                dao.CreateParameter("@Active", obj.Active),
                dao.CreateParameter("@AccountType", obj.AccountType),
                dao.CreateParameter("@Creator_ID", obj.Creator_ID),
                dao.CreateParameter("@ID_DonViGoc", obj.ID_DonViGoc),
                dao.CreateParameter("@IsUpdate", obj.IsUpdate)

			});
            return dao.SubmitChange();
        }


        public virtual SysAccountData GetSysAccountByID(System.Int32 ID)
        {
            JDataAccess dao = new JDataAccess(ConnectionString);
            dao.SetCommandText(SP_SYSACCOUNT_SELECT_BY_ID, CommandType.StoredProcedure);
            dao.SetParameters(new IDataParameter[]{
dao.CreateParameter("@ID", ID)          });

            DataTable table = dao.ExecuteQuery();
            if (table != null && table.Rows.Count > 0)
            {
                return Convert(table.Rows[0]);
            }

            return default(SysAccountData);
        }


        public virtual IList<SysAccountData> GetSysAccounts()
        {
            JDataAccess dao = new JDataAccess(ConnectionString);
            dao.SetCommandText(SP_SYSACCOUNT_SELECT_ALL, CommandType.StoredProcedure);

            DataTable table = dao.ExecuteQuery();
            if (table != null && table.Rows.Count > 0)
            {
                IList<SysAccountData> list = new List<SysAccountData>(table.Rows.Count);
                foreach (DataRow row in table.Rows)
                {
                    list.Add(Convert(row));
                }

                return list;
            }
            return new List<SysAccountData>();
        }

        public virtual IList<SysAccountData> GetSysAccounts(System.String whereCondition)
        {
            JDataAccess dao = new JDataAccess(ConnectionString);
            dao.SetCommandText(SP_SYSACCOUNT_SELECT_DYNAMIC, CommandType.StoredProcedure);
            dao.SetParameters(new IDataParameter[]{
				dao.CreateParameter("@WhereCondition", whereCondition)
			});

            DataTable table = dao.ExecuteQuery();
            if (table != null && table.Rows.Count > 0)
            {
                IList<SysAccountData> list = new List<SysAccountData>(table.Rows.Count);
                foreach (DataRow row in table.Rows)
                {
                    list.Add(Convert(row));
                }

                return list;
            }
            return new List<SysAccountData>();
        }

        public virtual IList<SysAccountData> GetSysAccounts(System.Int32 size, System.String whereCondition)
        {
            JDataAccess dao = new JDataAccess(ConnectionString);
            dao.SetCommandText(SP_SYSACCOUNT_SELECT_TOP_DYNAMIC, CommandType.StoredProcedure);
            dao.SetParameters(new IDataParameter[]{
				dao.CreateParameter("@Size", size),
				dao.CreateParameter("@WhereCondition", whereCondition)
			});

            DataTable table = dao.ExecuteQuery();
            if (table != null && table.Rows.Count > 0)
            {
                IList<SysAccountData> list = new List<SysAccountData>(table.Rows.Count);
                foreach (DataRow row in table.Rows)
                {
                    list.Add(Convert(row));
                }

                return list;
            }
            return new List<SysAccountData>();
        }

        public virtual System.Int32 GetSysAccountCount(System.String whereCondition)
        {
            JDataAccess dao = new JDataAccess(ConnectionString);
            dao.SetCommandText(SP_SYSACCOUNT_SELECT_COUNT, CommandType.StoredProcedure);
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

        public virtual IList<SysAccountData> GetSysAccountPaging(System.String whereCondition, System.Int32 pageSize, System.Int32 currentPage, System.String sortByColumns)
        {
            JDataAccess dao = new JDataAccess(ConnectionString);
            dao.SetCommandText(SP_SYSACCOUNT_SELECT_PAGING, CommandType.StoredProcedure);
            dao.SetParameters(new IDataParameter[]{
				dao.CreateParameter("@WhereCondition", whereCondition),
				dao.CreateParameter("@PageSize", pageSize),
				dao.CreateParameter("@CurrentPage", currentPage),
				dao.CreateParameter("@SortByColumns", sortByColumns)
			});

            DataTable table = dao.ExecuteQuery();
            if (table != null && table.Rows.Count > 0)
            {
                IList<SysAccountData> list = new List<SysAccountData>(table.Rows.Count);
                foreach (DataRow row in table.Rows)
                {
                    list.Add(Convert(row));
                }

                return list;
            }
            return new List<SysAccountData>();
        }


        #endregion
    }

}
