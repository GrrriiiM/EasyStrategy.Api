using System;
using System.Collections.Generic;
using System.Text;

namespace EasyStrategy.Api.Domain.Groupers
{
    public class GrouperRelation
    {
        public GrouperRelation Parent { get; set; }
        public Grouper Grouper { get; set; }
    }
}
