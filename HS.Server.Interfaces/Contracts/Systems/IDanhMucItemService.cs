using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

using HS.Server.Interfaces.DAO;

namespace HS.Server.Interfaces.Contracts.Systems
{
    /// <summary>
    /// IDanhMucItemService interface for service layer mapped table DanhMuc_Item.
    /// CODE:
    ///     - Author:    BangDV
    ///     - Generated Date:  21/07/2013 02:35:46 PM
    /// </summary>
    [ServiceContract]
    public interface IDanhMucItemService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [OperationContract]
        System.Int32 AddDanhMucItem(DanhMucItemData data);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [OperationContract]
        System.Int32 ChangeDanhMucItem(DanhMucItemData data);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [OperationContract]
        System.Int32 RemoveDanhMucItem(DanhMucItemData data);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IList<DanhMucItemData> GetDanhMucItemsByDanhMuc(string maLoaiDanhMuc);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IList<DanhMucItemData> GetDanhMucItems();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objId"></param>
        /// <returns></returns>
        [OperationContract]
        DanhMucItemData GetDanhMucItemByID(System.Guid iD);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IList<DanhMucItemData> GetDanhMucItemByCriteria(System.String whereCondition);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IList<DanhMucItemData> GetDanhMucItemBySizeCriteria(System.Int32 size, System.String whereCondition);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        System.Int32 GetDanhMucItemCount(System.String whereCondition);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IList<DanhMucItemData> GetDanhMucItemPaging(System.String whereCondition, System.Int32 pageSize, System.Int32 currentPage, System.String sortByColumns);
    }
}
