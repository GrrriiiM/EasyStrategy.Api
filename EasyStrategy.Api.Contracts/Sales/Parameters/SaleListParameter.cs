using System;
using System.Collections.Generic;
using System.Text;

namespace EasyStrategy.Api.Parameters
{
    public class SaleListParameter
    {

        public long[] AggregationGrouperIds { get; set; }
        public long? GrouperId { get; set; }
        public long? GrouperTypeId { get; set; }
        public long IntervalTypeId { get; set; }
        public DateTime? IntervalBegin { get; set; }
        public DateTime? IntervalEnd { get; set; }

    }
    
}
