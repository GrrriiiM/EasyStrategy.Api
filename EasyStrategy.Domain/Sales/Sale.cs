using EasyStrategy.Domain.Groupers;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyStrategy.Domain.Sales
{
    public class Sale : BaseEntity
    {
        public virtual SaleIntervalType IntervalType { get; set; }
        public DateTime IntervalBegin { get; set; }
        public DateTime IntervalEnd { get; set; }
        public virtual GrouperAggregation GrouperAggregation { get; set; }
        public virtual GrouperType GrouperType { get; set; }
        public virtual Grouper Grouper { get; set; }
        public long ReferenceId { get; set; }
        public string ReferenceDescription { get; set; }
        public virtual ICollection<SaleNumberValue> Numbers { get; set; }
    }
}
