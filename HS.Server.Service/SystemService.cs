using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HS.Common;
using HS.Server.Contracts;
using HS.Server.Data.Systems;
using HS.Server.Data.Entities.Systems;

namespace HS.Server.Service
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


        public DanhMucItemData GetDanhMucItemByID(System.Int32 ID, System.String MaLoaiDanhMuc)
        {
            try
            {
                var domain = new DanhMucItemDomainObject(ConnectionString);
                return domain.GetDanhMucItemByID(ID, MaLoaiDanhMuc);
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

        #region SysAccount

        public System.Int32 AddSysAccount(SysAccountData data)
        {
            try
            {
                var domain = new SysAccountDomainObject(ConnectionString);
                return domain.Add(data);
            }
            catch (Exception ex)
            {
                ErrorLog.Log("[AddSysAccount]", ex.Message);
            }
            return -1;
        }

        public System.Int32 ChangeSysAccount(SysAccountData data)
        {
            try
            {
                var domain = new SysAccountDomainObject(ConnectionString);
                return domain.Change(data);
            }
            catch (Exception ex)
            {
                ErrorLog.Log("[ChangeSysAccount]", ex.Message);
            }
            return -1;
        }

        public System.Int32 RemoveSysAccount(SysAccountData data)
        {
            try
            {
                var domain = new SysAccountDomainObject(ConnectionString);
                return domain.Remove(data);
            }
            catch (Exception ex)
            {
                ErrorLog.Log("[RemoveSysAccount]", ex.Message);
            }
            return -1;
        }

        public IList<SysAccountData> GetSysAccounts()
        {
            try
            {
                var domain = new SysAccountDomainObject(ConnectionString);
                return domain.GetSysAccounts();
            }
            catch (Exception ex)
            {
                ErrorLog.Log("[GetSysAccounts]", ex.Message);
                return null;
            }
        }

        public SysAccountData GetSysAccountByID(System.Int32 ID)
        {
            try
            {
                var domain = new SysAccountDomainObject(ConnectionString);
                return domain.GetSysAccountByID(ID);
            }
            catch (Exception ex)
            {
                ErrorLog.Log("[GetSysAccountByID]", ex.Message);
                return null;
            }
        }

        public IList<SysAccountData> GetSysAccountByCriteria(System.String whereCondition)
        {
            try
            {
                var domain = new SysAccountDomainObject(ConnectionString);
                return domain.GetSysAccounts(whereCondition);
            }
            catch (Exception ex)
            {
                ErrorLog.Log("[GetSysAccountByCriteria]", ex.Message);
                return null;
            }
        }

        public IList<SysAccountData> GetSysAccountBySizeCriteria(System.Int32 size, System.String whereCondition)
        {
            try
            {
                var domain = new SysAccountDomainObject(ConnectionString);
                return domain.GetSysAccounts(size, whereCondition);
            }
            catch (Exception ex)
            {
                ErrorLog.Log("[GetSysAccountBySizeCriteria]", ex.Message);
                return null;
            }
        }

        public System.Int32 GetSysAccountCount(System.String whereCondition)
        {
            try
            {
                var domain = new SysAccountDomainObject(ConnectionString);
                return domain.GetSysAccountCount(whereCondition);
            }
            catch (Exception ex)
            {
                ErrorLog.Log("[GetSysAccountCount]", ex.Message);
            }
            return -1;
        }

        public IList<SysAccountData> GetSysAccountPaging(System.String whereCondition, System.Int32 pageSize, System.Int32 currentPage, System.String sortByColumns)
        {
            try
            {
                var domain = new SysAccountDomainObject(ConnectionString);
                return domain.GetSysAccountPaging(whereCondition, pageSize, currentPage, sortByColumns);
            }
            catch (Exception ex)
            {
                ErrorLog.Log("[GetSysAccountPaging]", ex.Message);
                return new List<SysAccountData>();
            }
        }

        #endregion

        #region SysGroup

        public System.Int32 AddSysGroup(SysGroupData data)
        {
            try
            {
                var domain = new SysGroupDomainObject(ConnectionString);
                return domain.Add(data);
            }
            catch (Exception ex)
            {
                ErrorLog.Log("[AddSysGroup]", ex.Message);
            }
            return -1;
        }

        public System.Int32 ChangeSysGroup(SysGroupData data)
        {
            try
            {
                var domain = new SysGroupDomainObject(ConnectionString);
                return domain.Change(data);
            }
            catch (Exception ex)
            {
                ErrorLog.Log("[ChangeSysGroup]", ex.Message);
            }
            return -1;
        }

        public System.Int32 RemoveSysGroup(SysGroupData data)
        {
            try
            {
                var domain = new SysGroupDomainObject(ConnectionString);
                return domain.Remove(data);
            }
            catch (Exception ex)
            {
                ErrorLog.Log("[RemoveSysGroup]", ex.Message);
            }
            return -1;
        }

        public IList<SysGroupData> GetSysGroups()
        {
            try
            {
                var domain = new SysGroupDomainObject(ConnectionString);
                return domain.GetSysGroups();
            }
            catch (Exception ex)
            {
                ErrorLog.Log("[GetSysGroups]", ex.Message);
                return null;
            }
        }

        public SysGroupData GetSysGroupByID(System.Int32 ID)
        {
            try
            {
                var domain = new SysGroupDomainObject(ConnectionString);
                return domain.GetSysGroupByID(ID);
            }
            catch (Exception ex)
            {
                ErrorLog.Log("[GetSysGroupByID]", ex.Message);
                return null;
            }
        }

        public IList<SysGroupData> GetSysGroupByCriteria(System.String whereCondition)
        {
            try
            {
                var domain = new SysGroupDomainObject(ConnectionString);
                return domain.GetSysGroups(whereCondition);
            }
            catch (Exception ex)
            {
                ErrorLog.Log("[GetSysGroupByCriteria]", ex.Message);
                return null;
            }
        }

        public IList<SysGroupData> GetSysGroupBySizeCriteria(System.Int32 size, System.String whereCondition)
        {
            try
            {
                var domain = new SysGroupDomainObject(ConnectionString);
                return domain.GetSysGroups(size, whereCondition);
            }
            catch (Exception ex)
            {
                ErrorLog.Log("[GetSysGroupBySizeCriteria]", ex.Message);
                return null;
            }
        }

        public System.Int32 GetSysGroupCount(System.String whereCondition)
        {
            try
            {
                var domain = new SysGroupDomainObject(ConnectionString);
                return domain.GetSysGroupCount(whereCondition);
            }
            catch (Exception ex)
            {
                ErrorLog.Log("[GetSysGroupCount]", ex.Message);
            }
            return -1;
        }

        public IList<SysGroupData> GetSysGroupPaging(System.String whereCondition, System.Int32 pageSize, System.Int32 currentPage, System.String sortByColumns)
        {
            try
            {
                var domain = new SysGroupDomainObject(ConnectionString);
                return domain.GetSysGroupPaging(whereCondition, pageSize, currentPage, sortByColumns);
            }
            catch (Exception ex)
            {
                ErrorLog.Log("[GetSysGroupPaging]", ex.Message);
                return new List<SysGroupData>();
            }
        }

        #endregion
    }
}
