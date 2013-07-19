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

        protected virtual DmLoaidanhmucData Convert(DataRow row)
        {
            dynamic data = new DynamicDataRow(row);

            DmLoaidanhmucData obj = new DmLoaidanhmucData(System.Convert.ToInt32(data.ID)); // Chú ý Int64 hoặc Int32 phụ thuộc vào kiểu - dễ lẫn chỗ này

            obj.ID = System.Convert.ToInt32(data.ID);
            obj.MaLoaiDanhMuc = System.Convert.ToString(data.MaLoaiDanhMuc);
            obj.TenLoaiDanhMuc = System.Convert.ToString(data.TenLoaiDanhMuc);
            obj.ThuTu = System.Convert.ToInt32(data.ThuTu);
            obj.System = System.Convert.ToBoolean(data.System);

            return obj;
        }

        #endregion

        public virtual IList<DmLoaidanhmucData> GetDmLoaidanhmucs()
        {
            JDataAccess dao = new JDataAccess(ConnectionString);
            dao.SetCommandText("SELECT * FROM DM_LoaiDanhMuc", CommandType.Text);

            DataTable table = dao.ExecuteQuery();
            if (table != null && table.Rows.Count > 0)
            {
                IList<DmLoaidanhmucData> list = new List<DmLoaidanhmucData>(table.Rows.Count);
                foreach (DataRow row in table.Rows)
                {
                    list.Add(Convert(row));
                }

                return list;
            }
            return new List<DmLoaidanhmucData>();
        }

    }
}
