using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HS.Server.Interfaces.DAO;
using HS.Server.Interfaces.Entities.Systems;
using Library.DataAccess;

using HS.UI.Common;
using System.Data;

namespace HS.Server.BR.Systems
{
    public class DanhMucEntities : IDanhMuc
    {

        #region Const Fields

        private const System.String SP_DANHMUC_INSERT = "[dbo].[DANHMUC_INSERT]";
        private const System.String SP_DANHMUC_UPDATE = "[dbo].[DANHMUC_UPDATE]";
        private const System.String SP_DANHMUC_DELETE = "[dbo].[DANHMUC_DELETE]";
        private const System.String SP_DANHMUC_SELECT_BY_ID = "[dbo].[DANHMUC_SELECT_BYID]";
        private const System.String SP_DANHMUC_SELECT_ALL = "[dbo].[DANHMUC_SELECT_ALL]";
        private const System.String SP_DANHMUC_SELECT_DYNAMIC = "[dbo].[DANHMUC_SELECT_DYNAMIC]";
        private const System.String SP_DANHMUC_SELECT_TOP_DYNAMIC = "[dbo].[DANHMUC_SELECT_TOP_DYNAMIC]";
        private const System.String SP_DANHMUC_SELECT_COUNT = "[dbo].[DANHMUC_SELECT_COUNT]";
        private const System.String SP_DANHMUC_SELECT_PAGING = "[dbo].[DANHMUC_SELECT_PAGING]";
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

        public DanhMucEntities()
        {
        }

        public DanhMucEntities(System.String connectionString)
        {
            this.ConnectionString = connectionString;
        }

        #endregion

        #region Protected Methods

        protected virtual DanhMucData Convert(DataRow row)
        {
            dynamic data = new DynamicDataRow(row);

            DanhMucData obj = new DanhMucData(); // Chú ý Int64 hoặc Int32 phụ thuộc vào kiểu - dễ lẫn chỗ này

            obj.MaLoaiDanhMuc = System.Convert.ToString(data.MaLoaiDanhMuc);
            obj.TenLoaiDanhMuc = System.Convert.ToString(data.TenLoaiDanhMuc);
            obj.ThuTu = System.Convert.ToInt32(data.ThuTu);
            obj.System = System.Convert.ToBoolean(data.System);

            return obj;
        }

        #endregion

        #region Pulbic Methods

        public virtual System.Int32 Add(DanhMucData obj)
        {
            JDataAccess dao = new JDataAccess(ConnectionString);
            dao.SetCommandText(SP_DANHMUC_INSERT, CommandType.StoredProcedure);
            dao.SetParameters(new IDataParameter[]{
                dao.CreateParameter("@MaLoaiDanhMuc", obj.MaLoaiDanhMuc),
                dao.CreateParameter("@TenLoaiDanhMuc", obj.TenLoaiDanhMuc),
                dao.CreateParameter("@ThuTu", obj.ThuTu),
                dao.CreateParameter("@System", obj.System)
            });
            return dao.SubmitChange();
        }

        public virtual System.Int32 Change(DanhMucData obj)
        {
            JDataAccess dao = new JDataAccess(ConnectionString);
            dao.SetCommandText(SP_DANHMUC_UPDATE, CommandType.StoredProcedure);
            dao.SetParameters(new IDataParameter[]{
                dao.CreateParameter("@MaLoaiDanhMuc", obj.MaLoaiDanhMuc),
                dao.CreateParameter("@TenLoaiDanhMuc", obj.TenLoaiDanhMuc),
                dao.CreateParameter("@ThuTu", obj.ThuTu),
                dao.CreateParameter("@System", obj.System)
            });
            return dao.SubmitChange();
        }

        public virtual System.Int32 Remove(DanhMucData obj)
        {
            JDataAccess dao = new JDataAccess(ConnectionString);
            dao.SetCommandText(SP_DANHMUC_DELETE, CommandType.StoredProcedure);
            dao.SetParameters(new IDataParameter[]{
                dao.CreateParameter("@MaLoaiDanhMuc", obj.MaLoaiDanhMuc),
                dao.CreateParameter("@TenLoaiDanhMuc", obj.TenLoaiDanhMuc),
                dao.CreateParameter("@ThuTu", obj.ThuTu),
                dao.CreateParameter("@System", obj.System)
            });
            return dao.SubmitChange();
        }

        public virtual DanhMucData GetDanhmucByID(System.String maLoaiDanhMuc)
        {
            JDataAccess dao = new JDataAccess(ConnectionString);
            dao.SetCommandText(SP_DANHMUC_SELECT_BY_ID, CommandType.StoredProcedure);
            dao.SetParameters(new IDataParameter[]{
                dao.CreateParameter("@MaLoaiDanhMuc", maLoaiDanhMuc)
            });

            DataTable table = dao.ExecuteQuery();
            if (table != null && table.Rows.Count > 0)
            {
                return Convert(table.Rows[0]);
            }

            return default(DanhMucData);
        }

        public virtual IList<DanhMucData> GetDanhMucs()
        {
            JDataAccess dao = new JDataAccess(ConnectionString);
            dao.SetCommandText("SELECT * FROM DanhMuc", CommandType.Text);

            DataTable table = dao.ExecuteQuery();
            if (table != null && table.Rows.Count > 0)
            {
                IList<DanhMucData> list = new List<DanhMucData>(table.Rows.Count);
                foreach (DataRow row in table.Rows)
                {
                    list.Add(Convert(row));
                }

                return list;
            }
            return new List<DanhMucData>();
        }

        public virtual IList<DanhMucData> GetDanhmucs(System.String whereCondition)
        {
            JDataAccess dao = new JDataAccess(ConnectionString);
            dao.SetCommandText(SP_DANHMUC_SELECT_DYNAMIC, CommandType.StoredProcedure);
            dao.SetParameters(new IDataParameter[]{
                dao.CreateParameter("@WhereCondition", whereCondition)
            });

            DataTable table = dao.ExecuteQuery();
            if (table != null && table.Rows.Count > 0)
            {
                IList<DanhMucData> list = new List<DanhMucData>(table.Rows.Count);
                foreach (DataRow row in table.Rows)
                {
                    list.Add(Convert(row));
                }

                return list;
            }
            return new List<DanhMucData>();
        }

        public virtual IList<DanhMucData> GetDanhmucs(System.Int32 size, System.String whereCondition)
        {
            JDataAccess dao = new JDataAccess(ConnectionString);
            dao.SetCommandText(SP_DANHMUC_SELECT_TOP_DYNAMIC, CommandType.StoredProcedure);
            dao.SetParameters(new IDataParameter[]{
                dao.CreateParameter("@Size", size),
                dao.CreateParameter("@WhereCondition", whereCondition)
            });

            DataTable table = dao.ExecuteQuery();
            if (table != null && table.Rows.Count > 0)
            {
                IList<DanhMucData> list = new List<DanhMucData>(table.Rows.Count);
                foreach (DataRow row in table.Rows)
                {
                    list.Add(Convert(row));
                }

                return list;
            }
            return new List<DanhMucData>();
        }

        public virtual System.Int32 GetDanhmucCount(System.String whereCondition)
        {
            JDataAccess dao = new JDataAccess(ConnectionString);
            dao.SetCommandText(SP_DANHMUC_SELECT_COUNT, CommandType.StoredProcedure);
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

        public virtual IList<DanhMucData> GetDanhmucPaging(System.String whereCondition, System.Int32 pageSize, System.Int32 currentPage, System.String sortByColumns)
        {
            JDataAccess dao = new JDataAccess(ConnectionString);
            dao.SetCommandText(SP_DANHMUC_SELECT_PAGING, CommandType.StoredProcedure);
            dao.SetParameters(new IDataParameter[]{
                dao.CreateParameter("@WhereCondition", whereCondition),
                dao.CreateParameter("@PageSize", pageSize),
                dao.CreateParameter("@CurrentPage", currentPage),
                dao.CreateParameter("@SortByColumns", sortByColumns)
            });

            DataTable table = dao.ExecuteQuery();
            if (table != null && table.Rows.Count > 0)
            {
                IList<DanhMucData> list = new List<DanhMucData>(table.Rows.Count);
                foreach (DataRow row in table.Rows)
                {
                    list.Add(Convert(row));
                }

                return list;
            }
            return new List<DanhMucData>();
        }
        
        #endregion
    }
}
