using System;
using System.Collections.Generic;
using System.Text;

namespace EasyStrategy.Domain.Sales
{
    public class SaleNumberValue : BaseEntity
    {
        public Sale Sale { get; set; }
        public SaleValueType ValueType { get; set; }
        public decimal Value { get; set; }

    }
}
