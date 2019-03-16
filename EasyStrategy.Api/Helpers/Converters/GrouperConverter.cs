using EasyStrategy.Domain.Groupers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyStrategy.Api.Helpers
{
    public static partial class Converters
    {
        public static TransferObjects.GrouperType ToTransferObject(GrouperType obj)
        {
            return new TransferObjects.GrouperType
            {
                Id = obj.Id,
                Name = obj.Name,
                Level = obj.Level,
                Order = obj.Order,
                ParentId = obj.Parent?.Id
            };
        }

        public static TransferObjects.Grouper ToTransferObject(Grouper obj)
        {
            return new TransferObjects.Grouper
            {
                Id = obj.Id,
                Name = obj.Name,
                GrouperTypeId = obj.Type.Id,
                GrouperTypeLevel = obj.Type.Level,
                ParentId = obj.Parent?.Id,
                Order = obj.Order,
                ReferenceColorRGB = obj.ReferenceColorRGB,
                ReferenceIcon = obj.ReferenceIcon,
                IsTotal = obj.IsTotal
            };
        }
    }
}
