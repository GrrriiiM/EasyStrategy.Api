using System;
using System.Collections.Generic;
using System.Text;

namespace EasyStrategy.Domain.Sales
{
    public class SaleIntervalType : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public enum SaleIntervalTypeEnum
    {
        Hour = 1,
        Day = 2
    }
}
