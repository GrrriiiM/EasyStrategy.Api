using System;
using System.Collections.Generic;
using System.Text;

namespace EasyStrategy.Domain.Groupers
{
    public class GrouperAggregation : BaseEntity
    {
        public string Description { get; set; }

        public GrouperAggregation()
        {
            this.GrouperAggregationGroupers = new List<GrouperAggregationGrouper>();
        }

        public virtual ICollection<GrouperAggregationGrouper> GrouperAggregationGroupers { get; set; }
    }
}
