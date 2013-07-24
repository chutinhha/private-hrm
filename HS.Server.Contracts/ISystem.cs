using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HS.Server.Contracts.Systems;
using System.ServiceModel;

namespace HS.Server.Contracts
{
    [ServiceContract]
    public interface ISystem : 
        IDanhMuc,
        IDanhMucItem,
        ISysAccountService,
        ISysGroupService
    {

    }
}
