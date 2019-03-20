using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyStrategy.Api.Helpers
{
    public static partial class Converters
    {
        public static TransferObjects.SaleAreaChartView ToTransferObject(List<Domain.Sales.Sale> sales, Domain.Sales.SaleIntervalType saleIntervalType)
        {
            var ret = new TransferObjects.SaleAreaChartView();

            var values = sales.SelectMany(_ => _.Numbers.Where(_1 => _1.ValueType.Id == 1));
            var targets = sales.SelectMany(_ => _.Numbers.Where(_1 => _1.ValueType.Id == 2));

            var sumValue = values.Sum(_ => _.Value);
            var sumTarget = targets.Sum(_ => _.Value);


            ret.IntervalTypeId = saleIntervalType.Id;
            ret.IntervalTypeString = saleIntervalType.Name;

            ret.MinY = 0;
            ret.MaxY = (long)(sumValue > sumTarget ? sumValue : sumTarget);

            if (ret.IntervalTypeId == 1)
            {
                ret.MinX = sales.Min(_ => _.IntervalBegin.Hour);
                ret.MaxX = sales.Max(_ => _.IntervalBegin.Hour);
                ret.Values = sales.OrderBy(_ => _.IntervalBegin).Select(_ => new TransferObjects.SaleAreaChartView.SaleAreaChartInterval
                {
                    X = _.IntervalBegin.Day + 1,
                    Y = (long)_.Numbers.First(_1 => _1.ValueType.Id == 1).Value
                }).ToList();
            }

            

            

            return ret;
        }
    }
}
