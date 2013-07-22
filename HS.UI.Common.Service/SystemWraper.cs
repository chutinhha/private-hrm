using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HS.UI.Connection.HSService;

namespace HS.UI.Common.Service
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

        public DanhMucItemData GetDanhMucItemByID(Guid iD)
        {
            return Instant.GetDanhMucItemByID(iD);
        }

        public List<DanhMucItemData> GetDanhMucItemsByDanhMuc(string maLoaiDanhMuc)
        {


            return Instant.GetDanhMucItemsByDanhMuc(maLoaiDanhMuc);
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
    }
}
