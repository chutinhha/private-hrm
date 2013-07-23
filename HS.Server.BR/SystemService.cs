using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HS.UI.Common;
using HS.Server.Interfaces.DAO;
using HS.Server.Interfaces.Contracts;
using HS.Server.DA.Systems;

namespace HS.Server.BR
{
    public partial class IService : ISystem
    {
        #region Danhmuc

        public System.Int32 AddDanhMuc(DanhMucData data)
        {
            try
            {
                var domain = new DanhMucDomainObject(ConnectionString);
                return domain.Add(data);
            }
            catch (Exception ex)
            {
                ErrorLog.WebLog("[AddDanhMuc]", ex.Message);
            }
            return -1;
        }

        public System.Int32 ChangeDanhMuc(DanhMucData data)
        {
            try
            {
                var domain = new DanhMucDomainObject(ConnectionString);
                return domain.Change(data);
            }
            catch (Exception ex)
            {
                ErrorLog.WebLog("[ChangeDanhMuc]", ex.Message);
            }
            return -1;
        }

        public System.Int32 RemoveDanhMuc(DanhMucData data)
        {
            try
            {
                var domain = new DanhMucDomainObject(ConnectionString);
                return domain.Remove(data);
            }
            catch (Exception ex)
            {
                ErrorLog.WebLog("[RemoveDanhMuc]", ex.Message);
            }
            return -1;
        }

        public IList<DanhMucData> GetDanhMucs()
        {
            try
            {
                var domain = new DanhMucDomainObject(ConnectionString);
                return domain.GetDanhMucs();
            }
            catch (Exception ex)
            {
                ErrorLog.WebLog("[GetDanhMucs]", ex.Message);
                return null;
            }
        }

        public DanhMucData GetDanhMucByID(System.String maLoaiDanhMuc)
        {
            try
            {
                var domain = new DanhMucDomainObject(ConnectionString);
                return domain.GetDanhMucByID(maLoaiDanhMuc);
            }
            catch (Exception ex)
            {
                ErrorLog.WebLog("[GetDanhMucByID]", ex.Message);
                return null;
            }
        }

        public IList<DanhMucData> GetDanhMucByCriteria(System.String whereCondition)
        {
            try
            {
                var domain = new DanhMucDomainObject(ConnectionString);
                return domain.GetDanhMucs(whereCondition);
            }
            catch (Exception ex)
            {
                ErrorLog.WebLog("[GetDanhMucByCriteria]", ex.Message);
                return null;
            }
        }

        public IList<DanhMucData> GetDanhMucBySizeCriteria(System.Int32 size, System.String whereCondition)
        {
            try
            {
                var domain = new DanhMucDomainObject(ConnectionString);
                return domain.GetDanhMucs(size, whereCondition);
            }
            catch (Exception ex)
            {
                ErrorLog.WebLog("[GetDanhMucBySizeCriteria]", ex.Message);
                return null;
            }
        }

        public System.Int32 GetDanhMucCount(System.String whereCondition)
        {
            try
            {
                var domain = new DanhMucDomainObject(ConnectionString);
                return domain.GetDanhMucCount(whereCondition);
            }
            catch (Exception ex)
            {
                ErrorLog.WebLog("[GetDanhMucCount]", ex.Message);
            }
            return -1;
        }

        public IList<DanhMucData> GetDanhMucPaging(System.String whereCondition, System.Int32 pageSize, System.Int32 currentPage, System.String sortByColumns)
        {
            try
            {
                var domain = new DanhMucDomainObject(ConnectionString);
                return domain.GetDanhMucPaging(whereCondition, pageSize, currentPage, sortByColumns);
            }
            catch (Exception ex)
            {
                ErrorLog.WebLog("[GetDanhMucPaging]", ex.Message);
                return new List<DanhMucData>();
            }
        }

        #endregion

        #region DanhMuc_Item

        public System.Int32 AddDanhMucItem(DanhMucItemData data)
        {
            try
            {
                var domain = new DanhMucItemDomainObject(ConnectionString);
                return domain.Add(data);
            }
            catch (Exception ex)
            {
                ErrorLog.WebLog("[AddDanhMucItem]", ex.Message);
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
                ErrorLog.WebLog("[ChangeDanhMucItem]", ex.Message);
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
                ErrorLog.WebLog("[RemoveDanhMucItem]", ex.Message);
            }
            return -1;
        }

        public IList<DanhMucItemData> GetDanhMucItemsByDanhMuc(string maLoaiDanhMuc)
        {
            try
            {
                var domain = new DanhMucItemDomainObject(ConnectionString);
                return domain.GetDanhMucItems(string.Format(" AND di.MaLoaiDanhMuc = '{0}'", maLoaiDanhMuc));
            }
            catch (Exception ex)
            {
                ErrorLog.WebLog("[GetDanhMucItemsByDanhMuc]", ex.Message);
                return null;
            }
        }

        public IList<DanhMucItemData> GetDanhMucItems()
        {
            try
            {
                var domain = new DanhMucItemDomainObject(ConnectionString);
                return domain.GetDanhMucItems();
            }
            catch (Exception ex)
            {
                ErrorLog.WebLog("[GetDanhMucItems]", ex.Message);
                return null;
            }
        }

        public DanhMucItemData GetDanhMucItemByID(System.Guid iD)
        {
            try
            {
                var domain = new DanhMucItemDomainObject(ConnectionString);
                return domain.GetDanhMucItemByID(iD);
            }
            catch (Exception ex)
            {
                ErrorLog.WebLog("[GetDanhMucItemByID]", ex.Message);
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
                ErrorLog.WebLog("[GetDanhMucItemByCriteria]", ex.Message);
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
                ErrorLog.WebLog("[GetDanhMucItemBySizeCriteria]", ex.Message);
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
                ErrorLog.WebLog("[GetDanhMucItemCount]", ex.Message);
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
                ErrorLog.WebLog("[GetDanhMucItemPaging]", ex.Message);
                return new List<DanhMucItemData>();
            }
        }

        #endregion
    }
}
