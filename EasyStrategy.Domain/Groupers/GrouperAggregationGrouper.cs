using System;
using System.Collections.Generic;
using System.Text;

namespace EasyStrategy.Domain.Groupers
{
    public class GrouperAggregationGrouper : BaseEntity
    {
        public virtual GrouperAggregation GrouperAggregation { get; set; }
        public virtual Grouper Grouper { get; set; }
    }
}
