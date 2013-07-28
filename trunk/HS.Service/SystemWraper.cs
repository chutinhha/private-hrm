using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HS.Service.Connection.HSService;

namespace HS.Service.Wraper
{
    public class SystemWraper : ServiceBase
    {
        private SystemClient _instant;
        public SystemClient Instant
        {
            get
            {
                if (_instant == null)
                {
                    ServiceName = "Systems";
                    _instant = new SystemClient();
                }

                return _instant;
            }
        }

        public SystemWraper() { }

        #region DanhMuc

        public int AddDanhMuc(DanhMucData obj)
        {
            return Instant.AddDanhMuc(obj);
        }

        public int ChangeDanhMuc(DanhMucData obj)
        {
            return Instant.ChangeDanhMuc(obj);
        }

        public int RemoveDanhMuc(DanhMucData obj)
        {
            return Instant.RemoveDanhMuc(obj);
        }

        public List<DanhMucData> GetDanhMucs()
        {
            return Instant.GetDanhMucs();
        }

        public DanhMucData GetDanhMucByID(string maLoaiDanhMuc)
        {
            return Instant.GetDanhMucByID(maLoaiDanhMuc);
        }

        public List<DanhMucData> GetDanhMucByCriteria(string whereCondition)
        {
            return Instant.GetDanhMucByCriteria(whereCondition);
        }

        public List<DanhMucData> GetDanhMucBySizeCriteria(int size, string whereCondition)
        {
            return Instant.GetDanhMucBySizeCriteria(size, whereCondition);
        }

        public int GetDanhMucCount(string conditionWhere)
        {
            return Instant.GetDanhMucCount(conditionWhere);
        }

        public List<DanhMucData> GetDanhMucPaging(string whereCondition, int pageSize, int currentPage, string sortByColumns)
        {
            return Instant.GetDanhMucPaging(whereCondition, pageSize, currentPage, sortByColumns);
        }

        #endregion

        #region DanhMuc_Item

        public int AddDanhMucItem(DanhMucItemData obj)
        {
            return Instant.AddDanhMucItem(obj);
        }

        public int ChangeDanhMucItem(DanhMucItemData obj)
        {
            return Instant.ChangeDanhMucItem(obj);
        }

        public int RemoveDanhMucItem(DanhMucItemData obj)
        {
            return Instant.RemoveDanhMucItem(obj);
        }

        public List<DanhMucItemData> GetDanhMucItems()
        {
            return Instant.GetDanhMucItems();
        }

        public DanhMucItemData GetDanhMucItemByID(System.Int32 ID, System.String MaLoaiDanhMuc)
        {
            return Instant.GetDanhMucItemByID(ID, MaLoaiDanhMuc);
        }

        public List<DanhMucItemData> GetDanhMucItemsByDanhMuc(string maLoaiDanhMuc)
        {
            List<DanhMucItemData> tempList = new List<DanhMucItemData>();
            string whereCondition = string.Format(" AND MaLoaiDanhMuc = '{0}'", maLoaiDanhMuc);
            int itemCount = GetDanhMucItemCount(whereCondition);
            int pageSize = 50;
            decimal pageCount = Math.Ceiling((decimal)itemCount / pageSize);

            if (pageCount >= 1)
            {
                int page = 1;
                while (page <= pageCount)
                {
                    tempList.AddRange(GetDanhMucItemPaging(whereCondition, pageSize, page, "ThuTu, TenDanhMuc"));

                    page++;
                }
            }

            return tempList;
        }
        public List<DanhMucItemData> GetDanhMucItemByCriteria(string whereCondition)
        {
            return Instant.GetDanhMucItemByCriteria(whereCondition);
        }

        public List<DanhMucItemData> GetDanhMucItemBySizeCriteria(int size, string whereCondition)
        {
            return Instant.GetDanhMucItemBySizeCriteria(size, whereCondition);
        }

        public int GetDanhMucItemCount(string conditionWhere)
        {
            return Instant.GetDanhMucItemCount(conditionWhere);
        }

        public List<DanhMucItemData> GetDanhMucItemPaging(string whereCondition, int pageSize, int currentPage, string sortByColumns)
        {
            return Instant.GetDanhMucItemPaging(whereCondition, pageSize, currentPage, sortByColumns);
        }

        #endregion

        #region SysAccount

        public int AddSysAccount(SysAccountData obj)
        {
            return Instant.AddSysAccount(obj);
        }

        public int ChangeSysAccount(SysAccountData obj)
        {
            return Instant.ChangeSysAccount(obj);
        }

        public int RemoveSysAccount(SysAccountData obj)
        {
            return Instant.RemoveSysAccount(obj);
        }

        public List<SysAccountData> GetSysAccounts()
        {
            return Instant.GetSysAccounts();
        }

        public SysAccountData GetSysAccountByID(System.Int32 ID)
        {
            return Instant.GetSysAccountByID(ID);
        }

        public List<SysAccountData> GetSysAccountByCriteria(string whereCondition)
        {
            return Instant.GetSysAccountByCriteria(whereCondition);
        }

        public List<SysAccountData> GetSysAccountBySizeCriteria(int size, string whereCondition)
        {
            return Instant.GetSysAccountBySizeCriteria(size, whereCondition);
        }

        public int GetSysAccountCount(string conditionWhere)
        {
            return Instant.GetSysAccountCount(conditionWhere);
        }

        public List<SysAccountData> GetSysAccountPaging(string whereCondition, int pageSize, int currentPage, string sortByColumns)
        {
            return Instant.GetSysAccountPaging(whereCondition, pageSize, currentPage, sortByColumns);
        }

        #endregion

        #region SysGroup

        public int AddSysGroup(SysGroupData obj)
        {
            return Instant.AddSysGroup(obj);
        }

        public int ChangeSysGroup(SysGroupData obj)
        {
            return Instant.ChangeSysGroup(obj);
        }

        public int RemoveSysGroup(SysGroupData obj)
        {
            return Instant.RemoveSysGroup(obj);
        }

        public List<SysGroupData> GetSysGroups()
        {
            return Instant.GetSysGroups();
        }

        public SysGroupData GetSysGroupByID(System.Int32 ID)
        {
            return Instant.GetSysGroupByID(ID);
        }

        public List<SysGroupData> GetSysGroupByCriteria(string whereCondition)
        {
            return Instant.GetSysGroupByCriteria(whereCondition);
        }

        public List<SysGroupData> GetSysGroupBySizeCriteria(int size, string whereCondition)
        {
            return Instant.GetSysGroupBySizeCriteria(size, whereCondition);
        }

        public int GetSysGroupCount(string conditionWhere)
        {
            return Instant.GetSysGroupCount(conditionWhere);
        }

        public List<SysGroupData> GetSysGroupPaging(string whereCondition, int pageSize, int currentPage, string sortByColumns)
        {
            return Instant.GetSysGroupPaging(whereCondition, pageSize, currentPage, sortByColumns);
        }

        #endregion
    }
}
