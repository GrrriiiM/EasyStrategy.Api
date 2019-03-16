using EasyStrategy.Api.Domain.Groupers;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyStrategy.Api.Domain.Sales
{
    public class SaleTarget : BaseEntity
    {
        public virtual SaleIntervalType IntervalType { get; set; }
        public DateTime IntervalBegin { get; set; }
        public DateTime IntervalEnd { get; set; }
        public GrouperRelation AggregationGrouperRelation { get; set; }
        public GrouperType GrouperType { get; set; }
        public long ReferenceGrouperId { get; set; }
        public string ReferenceGrouperDescription { get; set; }
        public double Target { get; set; }
    }
}
