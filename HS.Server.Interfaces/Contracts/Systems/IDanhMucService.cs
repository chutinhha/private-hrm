using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

using HS.Server.Interfaces.DAO;

namespace HS.Server.Interfaces.Contracts.Systems
{
    /// <summary>
    /// IDanhMucService interface for service layer mapped table DanhMuc.
    /// CODE:
    ///     - Author:    BangDV
    ///     - Generated Date:  20/07/2013 04:03:53 PM
    /// </summary>
    [ServiceContract]
    public interface IDanhMucService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [OperationContract]
        System.Int32 AddDanhMuc(DanhMucData data);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [OperationContract]
        System.Int32 ChangeDanhMuc(DanhMucData data);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [OperationContract]
        System.Int32 RemoveDanhMuc(DanhMucData data);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IList<DanhMucData> GetDanhMucs();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objId"></param>
        /// <returns></returns>
        [OperationContract]
        DanhMucData GetDanhMucByID(System.String maLoaiDanhMuc);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IList<DanhMucData> GetDanhMucByCriteria(System.String whereCondition);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IList<DanhMucData> GetDanhMucBySizeCriteria(System.Int32 size, System.String whereCondition);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        System.Int32 GetDanhMucCount(System.String whereCondition);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IList<DanhMucData> GetDanhMucPaging(System.String whereCondition, System.Int32 pageSize, System.Int32 currentPage, System.String sortByColumns);
    }
}
