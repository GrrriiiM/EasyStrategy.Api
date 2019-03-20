using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyStrategy.Api.Helpers
{
    public static partial class Converters
    {
        public static TransferObjects.SalesView ToTransferObject(List<Domain.Sales.Sale> sales , Domain.Sales.SaleIntervalType saleIntervalType, DateTime LastUpdate)
        {
            var ret = new TransferObjects.SalesView();

            var distinctNumbers = sales.SelectMany(_ => _.Numbers).Select(_ => _.ValueType).Distinct();
            
            foreach(var number in distinctNumbers)
            {
                ret.Add(number.Name, sales.Sum(_ => _.Numbers.FirstOrDefault(_1 => _1.ValueType == number).Value));
            }

            ret.LastUpdate = LastUpdate;

            return ret;
        }
    }
}
