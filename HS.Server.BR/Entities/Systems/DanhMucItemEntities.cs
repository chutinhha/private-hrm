using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Library.DataAccess;

using HS.UI.Common;
using HS.Server.Interfaces.DAO;
using HS.Server.DA.Systems;
using HS.Server.BR.Contracts.Systems;

namespace HS.Server.BR.Entities.Systems
{
    public class DanhMucItemEntities
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

        protected virtual DanhMucItemData Convert(DataRow row)
        {
            dynamic data = new DynamicDataRow(row);

            DanhMucItemData obj = new DanhMucItemData(); // Chú ý Int64 hoặc Int32 phụ thuộc vào kiểu - dễ lẫn chỗ này

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

        #endregion

        #region Pulbic Methods


        public System.Int32 AddDanhMucItem(DanhMucItemData data)
        {
            try
            {
                var domain = new DanhMucItemDomainObject(ConnectionString);
                return domain.Add(data);
            }
            catch (Exception ex)
            {
                ErrorLog.Log("[AddDanhMucItem]", ex.Message);
            }
            return -1;
        }
        public System.Int32 ChangeDanhMucItem(DanhMucItemData data)
        {
            try
            {
                var domain = new DanhMucItemDomainObject(ConnectionString);
                return domain.Change(data);
            }
            catch (Exception ex)
            {
                ErrorLog.Log("[ChangeDanhMucItem]", ex.Message);
            }
            return -1;
        }

        public System.Int32 RemoveDanhMucItem(DanhMucItemData data)
        {
            try
            {
                var domain = new DanhMucItemDomainObject(ConnectionString);
                return domain.Remove(data);
            }
            catch (Exception ex)
            {
                ErrorLog.Log("[RemoveDanhMucItem]", ex.Message);
            }
            return -1;
        }

        public virtual IList<DanhMucItemData> GetDanhMucItemsByDanhMuc(string maLoaiDanhMuc)
        {
            try
            {
                var domain = new DanhMucItemDomainObject(ConnectionString);
                return domain.GetDanhMucItemsByDanhMuc(maLoaiDanhMuc);
            }
            catch (Exception ex)
            {
                ErrorLog.Log("[GetDanhMucItems]", ex.Message);
                return null;
            }
        }

        public DanhMucItemData GetDanhMucItemByID(System.String maLoaiDanhMuc, System.String maDanhMuc)
        {
            try
            {
                var domain = new DanhMucItemDomainObject(ConnectionString);
                return domain.GetDanhMucItemByID(maLoaiDanhMuc, maDanhMuc);
            }
            catch (Exception ex)
            {
                ErrorLog.Log("[GetDanhMucItemByID]", ex.Message);
                return null;
            }
        }

        public IList<DanhMucItemData> GetDanhMucItemByCriteria(System.String whereCondition)
        {
            try
            {
                var domain = new DanhMucItemDomainObject(ConnectionString);
                return domain.GetDanhMucItems(whereCondition);
            }
            catch (Exception ex)
            {
                ErrorLog.Log("[GetDanhMucItemByCriteria]", ex.Message);
                return null;
            }
        }

        public IList<DanhMucItemData> GetDanhMucItemBySizeCriteria(System.Int32 size, System.String whereCondition)
        {
            try
            {
                var domain = new DanhMucItemDomainObject(ConnectionString);
                return domain.GetDanhMucItems(size, whereCondition);
            }
            catch (Exception ex)
            {
                ErrorLog.Log("[GetDanhMucItemBySizeCriteria]", ex.Message);
                return null;
            }
        }

        public System.Int32 GetDanhMucItemCount(System.String whereCondition)
        {
            try
            {
                var domain = new DanhMucItemDomainObject(ConnectionString);
                return domain.GetDanhMucItemCount(whereCondition);
            }
            catch (Exception ex)
            {
                ErrorLog.Log("[GetDanhMucItemCount]", ex.Message);
            }
            return -1;
        }

        public IList<DanhMucItemData> GetDanhMucItemPaging(System.String whereCondition, System.Int32 pageSize, System.Int32 currentPage, System.String sortByColumns)
        {
            try
            {
                var domain = new DanhMucItemDomainObject(ConnectionString);
                return domain.GetDanhMucItemPaging(whereCondition, pageSize, currentPage, sortByColumns);
            }
            catch (Exception ex)
            {
                ErrorLog.Log("[GetDanhMucItemPaging]", ex.Message);
                return new List<DanhMucItemData>();
            }
        }

        #endregion
    }
}
