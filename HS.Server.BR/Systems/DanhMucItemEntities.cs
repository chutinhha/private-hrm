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
    public class DanhMucItemEntities : IDanhMucItem
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

        public DanhMucItemEntities()
        {
        }

        public DanhMucItemEntities(System.String connectionString)
        {
            this.ConnectionString = connectionString;
        }

        #endregion

        #region Protected Methods

        protected virtual DmDanhmucitemData Convert(DataRow row)
        {
            dynamic data = new DynamicDataRow(row);

            DmDanhmucitemData obj = new DmDanhmucitemData(); // Chú ý Int64 hoặc Int32 phụ thuộc vào kiểu - dễ lẫn chỗ này

            obj.MaLoaiDanhMuc = System.Convert.ToString(data.MaLoaiDanhMuc);
            obj.MaDanhMuc = System.Convert.ToString(data.MaDanhMuc);
            obj.TenDanhMuc = System.Convert.ToString(data.TenDanhMuc);
            obj.ThuTu = System.Convert.ToInt32(data.ThuTu);
            obj.IntVal1 = System.Convert.ToInt32(data.IntVal1);
            obj.IntVal2 = System.Convert.ToInt32(data.IntVal2);
            obj.IntVal3 = System.Convert.ToInt32(data.IntVal3);
            obj.DecVal1 = System.Convert.ToDecimal(data.DecVal1);
            obj.DecVal2 = System.Convert.ToDecimal(data.DecVal2);
            obj.DecVal3 = System.Convert.ToDecimal(data.DecVal3);
            obj.StrVal1 = System.Convert.ToString(data.StrVal1);
            obj.StrVal2 = System.Convert.ToString(data.StrVal2);
            obj.StrVal3 = System.Convert.ToString(data.StrVal3);


            return obj;
        }

        public virtual IList<DmDanhmucitemData> GetDmDanhmucitemsByLoaiDm(string loaiDm)
        {
            JDataAccess dao = new JDataAccess(ConnectionString);
            dao.SetCommandText(string.Format("SELECT * FROM DM_DanhMucItem WHERE MaLoaiDanhMuc=@MaLoaiDanhMuc"), CommandType.Text);
            dao.SetParameters(new IDataParameter[]{
                dao.CreateParameter("@MaLoaiDanhMuc", loaiDm)
            });

            DataTable table = dao.ExecuteQuery();
            if (table != null && table.Rows.Count > 0)
            {
                IList<DmDanhmucitemData> list = new List<DmDanhmucitemData>(table.Rows.Count);
                foreach (DataRow row in table.Rows)
                {
                    list.Add(Convert(row));
                }

                return list;
            }
            return new List<DmDanhmucitemData>();
        }

        #endregion
    }
}
