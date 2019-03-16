using EasyStrategy.Api.Domain.Groupers;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyStrategy.Api.Domain.Sales
{
    public class Sale : BaseEntity
    {
        public virtual SaleIntervalType IntervalType { get; private set; }
        public DateTime IntervalBegin { get; private set; }
        public DateTime IntervalEnd { get; private set; }
        public virtual GrouperRelation AggregationGrouperRelation { get; private set; }
        public virtual GrouperType GrouperType { get; private set; }
        public long ReferenceGrouperId { get; private set; }
        public string ReferenceGrouperDescription { get; private set; }
        public double Value { get; set; }
    }
}
