using EasyStrategy.Domain.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyStrategy.Api.Helpers
{
    public static partial class Converters
    {
        public static TransferObjects.Sale ToTransferObject(Sale obj)
        {
            var ret =  new TransferObjects.Sale
            {
                IntervalTypeId = obj.IntervalType.Id,
                IntervalBegin = obj.IntervalBegin,
                IntervalEnd = obj.IntervalEnd,
                GrouperAggregationId = obj.GrouperAggregation.Id,
                GrouperTypeId = obj.GrouperType.Id,
                GrouperId = obj.Grouper != null ? obj.Grouper.Id : 0,
                GrouperOrder = obj.Grouper != null ? obj.Grouper.Order : 0,
                GrouperColor = obj.Grouper != null ? obj.Grouper.ReferenceColorRGB : "",
                ReferenceId = obj.ReferenceId,
                ReferenceDescription = obj.ReferenceDescription,
            };

            obj.Numbers.ToList().ForEach(_ => ret.Add(_.ValueType.Name, _.Value));

            return ret;
        }
    }
}
