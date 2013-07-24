using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

using HS.Server.Data.Entities.Systems;

namespace HS.Server.Contracts.Systems
{
    /// <summary>
    /// ISysGroupService interface for service layer mapped table SysGroup.
    /// CODE:
    ///     - Author:    BangDV
    ///     - Generated Date:  24/07/2013 02:38:26 PM
    /// </summary>
    [ServiceContract]
    public interface ISysGroupService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [OperationContract]
        System.Int32 AddSysGroup(SysGroupData data);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [OperationContract]
        System.Int32 ChangeSysGroup(SysGroupData data);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [OperationContract]
        System.Int32 RemoveSysGroup(SysGroupData data);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IList<SysGroupData> GetSysGroups();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objId"></param>
        /// <returns></returns>
        [OperationContract]
        SysGroupData GetSysGroupByID(System.Int32 ID);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IList<SysGroupData> GetSysGroupByCriteria(System.String whereCondition);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IList<SysGroupData> GetSysGroupBySizeCriteria(System.Int32 size, System.String whereCondition);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        System.Int32 GetSysGroupCount(System.String whereCondition);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IList<SysGroupData> GetSysGroupPaging(System.String whereCondition, System.Int32 pageSize, System.Int32 currentPage, System.String sortByColumns);
    }
}
