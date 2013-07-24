using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

using HS.Server.Data.Entities.Systems;

namespace HS.Server.Contracts.Systems
{
    /// <summary>
    /// ISysAccountService interface for service layer mapped table SysAccount.
    /// CODE:
    ///     - Author:    BangDV
    ///     - Generated Date:  24/07/2013 02:11:42 PM
    /// </summary>
    [ServiceContract]
    public interface ISysAccountService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [OperationContract]
        System.Int32 AddSysAccount(SysAccountData data);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [OperationContract]
        System.Int32 ChangeSysAccount(SysAccountData data);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [OperationContract]
        System.Int32 RemoveSysAccount(SysAccountData data);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IList<SysAccountData> GetSysAccounts();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objId"></param>
        /// <returns></returns>
        [OperationContract]
        SysAccountData GetSysAccountByID(System.Int32 ID);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IList<SysAccountData> GetSysAccountByCriteria(System.String whereCondition);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IList<SysAccountData> GetSysAccountBySizeCriteria(System.Int32 size, System.String whereCondition);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        System.Int32 GetSysAccountCount(System.String whereCondition);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IList<SysAccountData> GetSysAccountPaging(System.String whereCondition, System.Int32 pageSize, System.Int32 currentPage, System.String sortByColumns);
    }
}
