using EasyStrategy.Api.TransferObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyStrategy.Api.Contracts.Groupers
{
    public interface IGrouperApiService
    {
        Task<IEnumerable<TransferObjects.GrouperType>> ListGrouperType();
        Task<IEnumerable<TransferObjects.Grouper>> ListGrouper();
    }
}
