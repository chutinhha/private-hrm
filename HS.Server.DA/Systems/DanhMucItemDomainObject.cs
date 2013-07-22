using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HS.Server.Interfaces.DAO;
using Library.DataAccess;

using HS.UI.Common;
using System.Data;

namespace HS.Server.DA.Systems
{
    public class DanhMucItemDomainObject
    {

        #region Const Fields

        private const System.String SP_DANHMUCITEM_INSERT = "[dbo].[DANHMUCITEM_INSERT]";
        private const System.String SP_DANHMUCITEM_UPDATE = "[dbo].[DANHMUCITEM_UPDATE]";
        private const System.String SP_DANHMUCITEM_DELETE = "[dbo].[DANHMUCITEM_DELETE]";
        private const System.String SP_DANHMUCITEM_SELECT_BY_ID = "[dbo].[DANHMUCITEM_SELECT_BYID]";
        private const System.String SP_DANHMUCITEM_SELECT_ALL = "[dbo].[DANHMUCITEM_SELECT_ALL]";
        private const System.String SP_DANHMUCITEM_SELECT_DYNAMIC = "[dbo].[DANHMUCITEM_SELECT_DYNAMIC]";
        private const System.String SP_DANHMUCITEM_SELECT_TOP_DYNAMIC = "[dbo].[DANHMUCITEM_SELECT_TOP_DYNAMIC]";
        private const System.String SP_DANHMUCITEM_SELECT_COUNT = "[dbo].[DANHMUCITEM_SELECT_COUNT]";
        private const System.String SP_DANHMUCITEM_SELECT_PAGING = "[dbo].[DANHMUCITEM_SELECT_PAGING]";
        #endregion
        
        #region Properties

        private System.String _ConnectionString = "";
        /// <summary>
        /// Connect to database
        /// </summary>
        public System.String ConnectionString
        {
            get
            {
                return _ConnectionString;
            }
            set
            {
                if (_ConnectionString != value)
                {
                    _ConnectionString = value;
                }
            }
        }

        #endregion

        #region Constructors

        public DanhMucItemDomainObject()
        {
        }

        public DanhMucItemDomainObject(System.String connectionString)
        {
            this.ConnectionString = connectionString;
        }

        #endregion

        #region Protected Methods

        protected virtual DanhMucItemData Convert(DataRow row)
        {
            dynamic data = new DynamicDataRow(row);

            DanhMucItemData obj = new DanhMucItemData();

            obj.ID = Guid.Parse(System.Convert.ToString(data.ID));
            obj.MaLoaiDanhMuc = System.Convert.ToString(data.MaLoaiDanhMuc);
            obj.MaDanhMuc = System.Convert.ToString(data.MaDanhMuc);
            obj.TenDanhMuc = System.Convert.ToString(data.TenDanhMuc);
            obj.ThuTu = System.Convert.ToInt32(data.ThuTu);
            obj.IntVal1 = data.IntVal1 != null ? System.Convert.ToInt32(data.IntVal1) : null;
            obj.IntVal2 = data.IntVal2 != null ? System.Convert.ToInt32(data.IntVal2) : null;
            obj.IntVal3 = data.IntVal3 != null ? System.Convert.ToInt32(data.IntVal3) : null;
            obj.DecVal1 = data.DecVal1 != null ? System.Convert.ToDecimal(data.DecVal1) : null;
            obj.DecVal2 = data.DecVal2 != null ? System.Convert.ToDecimal(data.DecVal2) : null;
            obj.DecVal3 = data.DecVal3 != null ? System.Convert.ToDecimal(data.DecVal3) : null;
            obj.StrVal1 = System.Convert.ToString(data.StrVal1);
            obj.StrVal2 = System.Convert.ToString(data.StrVal2);
            obj.StrVal3 = System.Convert.ToString(data.StrVal3);
            obj.Active = System.Convert.ToBoolean(data.Active);

            return obj;
        }

        #endregion

        #region Pulbic Methods

        public virtual System.Int32 Add(DanhMucItemData obj)
        {
            JDataAccess dao = new JDataAccess(ConnectionString);
            dao.SetCommandText(SP_DANHMUCITEM_INSERT, CommandType.StoredProcedure);
            dao.SetParameters(new IDataParameter[]{
                dao.CreateParameter("@ID", obj.ID),
                dao.CreateParameter("@MaLoaiDanhMuc", obj.MaLoaiDanhMuc),
                dao.CreateParameter("@MaDanhMuc", obj.MaDanhMuc),
                dao.CreateParameter("@TenDanhMuc", obj.TenDanhMuc),
                dao.CreateParameter("@ThuTu", obj.ThuTu),
                dao.CreateParameter("@IntVal1", obj.IntVal1),
                dao.CreateParameter("@IntVal2", obj.IntVal2),
                dao.CreateParameter("@IntVal3", obj.IntVal3),
                dao.CreateParameter("@DecVal1", obj.DecVal1),
                dao.CreateParameter("@DecVal2", obj.DecVal2),
                dao.CreateParameter("@DecVal3", obj.DecVal3),
                dao.CreateParameter("@StrVal1", obj.StrVal1),
                dao.CreateParameter("@StrVal2", obj.StrVal2),
                dao.CreateParameter("@StrVal3", obj.StrVal3),
                dao.CreateParameter("@Active", obj.Active)
            });
            return dao.SubmitChange();
        }

        public virtual System.Int32 Change(DanhMucItemData obj)
        {
            JDataAccess dao = new JDataAccess(ConnectionString);
            dao.SetCommandText(SP_DANHMUCITEM_UPDATE, CommandType.StoredProcedure);
            dao.SetParameters(new IDataParameter[]{
                dao.CreateParameter("@ID", obj.ID),
                dao.CreateParameter("@MaLoaiDanhMuc", obj.MaLoaiDanhMuc),
                dao.CreateParameter("@MaDanhMuc", obj.MaDanhMuc),
                dao.CreateParameter("@TenDanhMuc", obj.TenDanhMuc),
                dao.CreateParameter("@ThuTu", obj.ThuTu),
                dao.CreateParameter("@IntVal1", obj.IntVal1),
                dao.CreateParameter("@IntVal2", obj.IntVal2),
                dao.CreateParameter("@IntVal3", obj.IntVal3),
                dao.CreateParameter("@DecVal1", obj.DecVal1),
                dao.CreateParameter("@DecVal2", obj.DecVal2),
                dao.CreateParameter("@DecVal3", obj.DecVal3),
                dao.CreateParameter("@StrVal1", obj.StrVal1),
                dao.CreateParameter("@StrVal2", obj.StrVal2),
                dao.CreateParameter("@StrVal3", obj.StrVal3),
                dao.CreateParameter("@Active", obj.Active)

            });
            return dao.SubmitChange();
        }

        public virtual System.Int32 Remove(DanhMucItemData obj)
        {
            JDataAccess dao = new JDataAccess(ConnectionString);
            dao.SetCommandText(SP_DANHMUCITEM_DELETE, CommandType.StoredProcedure);
            dao.SetParameters(new IDataParameter[]{
                dao.CreateParameter("@ID", obj.ID),
                dao.CreateParameter("@MaLoaiDanhMuc", obj.MaLoaiDanhMuc),
                dao.CreateParameter("@MaDanhMuc", obj.MaDanhMuc),
                dao.CreateParameter("@TenDanhMuc", obj.TenDanhMuc),
                dao.CreateParameter("@ThuTu", obj.ThuTu),
                dao.CreateParameter("@IntVal1", obj.IntVal1),
                dao.CreateParameter("@IntVal2", obj.IntVal2),
                dao.CreateParameter("@IntVal3", obj.IntVal3),
                dao.CreateParameter("@DecVal1", obj.DecVal1),
                dao.CreateParameter("@DecVal2", obj.DecVal2),
                dao.CreateParameter("@DecVal3", obj.DecVal3),
                dao.CreateParameter("@StrVal1", obj.StrVal1),
                dao.CreateParameter("@StrVal2", obj.StrVal2),
                dao.CreateParameter("@StrVal3", obj.StrVal3),
                dao.CreateParameter("@Active", obj.Active)

            });
            return dao.SubmitChange();
        }

        public virtual DanhMucItemData GetDanhMucItemByID(Guid iD)
        {
            JDataAccess dao = new JDataAccess(ConnectionString);
            dao.SetCommandText(SP_DANHMUCITEM_SELECT_BY_ID, CommandType.StoredProcedure);
            dao.SetParameters(new IDataParameter[]{
                dao.CreateParameter("@ID", iD)
            });

            DataTable table = dao.ExecuteQuery();
            if (table != null && table.Rows.Count > 0)
            {
                return Convert(table.Rows[0]);
            }

            return default(DanhMucItemData);
        }
        
        public virtual IList<DanhMucItemData> GetDanhMucItems(System.String whereCondition)
        {
            JDataAccess dao = new JDataAccess(ConnectionString);
            dao.SetCommandText(SP_DANHMUCITEM_SELECT_DYNAMIC, CommandType.StoredProcedure);
            dao.SetParameters(new IDataParameter[]{
                dao.CreateParameter("@WhereCondition", whereCondition)
            });

            DataTable table = dao.ExecuteQuery();
            if (table != null && table.Rows.Count > 0)
            {
                IList<DanhMucItemData> list = new List<DanhMucItemData>(table.Rows.Count);
                foreach (DataRow row in table.Rows)
                {
                    list.Add(Convert(row));
                }

                return list;
            }
            return new List<DanhMucItemData>();
        }

        public virtual IList<DanhMucItemData> GetDanhMucItems(System.Int32 size, System.String whereCondition)
        {
            JDataAccess dao = new JDataAccess(ConnectionString);
            dao.SetCommandText(SP_DANHMUCITEM_SELECT_TOP_DYNAMIC, CommandType.StoredProcedure);
            dao.SetParameters(new IDataParameter[]{
                dao.CreateParameter("@Size", size),
                dao.CreateParameter("@WhereCondition", whereCondition)
            });

            DataTable table = dao.ExecuteQuery();
            if (table != null && table.Rows.Count > 0)
            {
                IList<DanhMucItemData> list = new List<DanhMucItemData>(table.Rows.Count);
                foreach (DataRow row in table.Rows)
                {
                    list.Add(Convert(row));
                }

                return list;
            }
            return new List<DanhMucItemData>();
        }

        public virtual System.Int32 GetDanhMucItemCount(System.String whereCondition)
        {
            JDataAccess dao = new JDataAccess(ConnectionString);
            dao.SetCommandText(SP_DANHMUCITEM_SELECT_COUNT, CommandType.StoredProcedure);
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

        public virtual IList<DanhMucItemData> GetDanhMucItemPaging(System.String whereCondition, System.Int32 pageSize, System.Int32 currentPage, System.String sortByColumns)
        {
            JDataAccess dao = new JDataAccess(ConnectionString);
            dao.SetCommandText(SP_DANHMUCITEM_SELECT_PAGING, CommandType.StoredProcedure);
            dao.SetParameters(new IDataParameter[]{
                dao.CreateParameter("@WhereCondition", whereCondition),
                dao.CreateParameter("@PageSize", pageSize),
                dao.CreateParameter("@CurrentPage", currentPage),
                dao.CreateParameter("@SortByColumns", sortByColumns)
            });

            DataTable table = dao.ExecuteQuery();
            if (table != null && table.Rows.Count > 0)
            {
                IList<DanhMucItemData> list = new List<DanhMucItemData>(table.Rows.Count);
                foreach (DataRow row in table.Rows)
                {
                    list.Add(Convert(row));
                }

                return list;
            }
            return new List<DanhMucItemData>();
        }

        #endregion
    }
}
