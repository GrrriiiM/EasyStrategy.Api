using EasyStrategy.Api.Contracts.Groupers;
using EasyStrategy.Api.Data;
using EasyStrategy.Api.TransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EasyStrategy.Api.Services
{
    public class GrouperApiService : IGrouperApiService
    {
        readonly EasyContext _context;

        public GrouperApiService(EasyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TransferObjects.GrouperType>> ListGrouperType()
        {
            return await _context.GrouperTypes
                .Include(_ => _.Parent)
                .ToAsyncEnumerable()
                .OrderBy(_ => _.Level)
                .ThenBy(_ => _.Order)
                .Select(_ => Helpers.Converters.ToTransferObject(_)).ToList();
        }

        
        public async Task<IEnumerable<TransferObjects.Grouper>> ListGrouper()
        {
            return await _context.Groupers
                .Include(_ => _.Parent)
                .Include(_ => _.Type)
                .ToAsyncEnumerable()
                .OrderBy(_ => _.Type.Level)
                .ThenBy(_ => !_.IsTotal)
                .ThenBy(_ => _.Order)
                .Select(_ => Helpers.Converters.ToTransferObject(_))
                .ToList();
        }
    }
}
