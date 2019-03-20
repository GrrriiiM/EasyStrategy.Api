using System;
using System.Collections.Generic;
using System.Text;

namespace EasyStrategy.Api.TransferObjects
{
    public class Sale : Dictionary<string, object>
    {
        public long IntervalTypeId { get; set; }
        public DateTime IntervalBegin { get; set; }
        public DateTime IntervalEnd { get; set; }
        public long GrouperAggregationId { get; set; }
        public long  GrouperTypeId { get; set; }
        public long GrouperId { get; set; }
        public long GrouperOrder { get; set; }
        public string GrouperColor { get; set; }
        public long ReferenceId { get; set; }
        public string ReferenceDescription { get; set; }
    }
}
