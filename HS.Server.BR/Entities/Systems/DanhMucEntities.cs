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
    public class DanhMucEntities : IDanhMucService
    {
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
        }

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
                ErrorLog.Log("[AddDanhMuc]", ex.Message);
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
                ErrorLog.Log("[ChangeDanhMuc]", ex.Message);
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
                ErrorLog.Log("[RemoveDanhMuc]", ex.Message);
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
                ErrorLog.Log("[GetDanhMucs]", ex.Message);
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
                ErrorLog.Log("[GetDanhMucByID]", ex.Message);
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
                ErrorLog.Log("[GetDanhMucByCriteria]", ex.Message);
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
                ErrorLog.Log("[GetDanhMucBySizeCriteria]", ex.Message);
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
                ErrorLog.Log("[GetDanhMucCount]", ex.Message);
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
                ErrorLog.Log("[GetDanhMucPaging]", ex.Message);
                return new List<DanhMucData>();
            }
        }

        #endregion
    }
}
