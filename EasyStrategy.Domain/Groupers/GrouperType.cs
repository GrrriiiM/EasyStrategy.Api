using System;
using System.Collections.Generic;
using System.Text;

namespace EasyStrategy.Domain.Groupers
{
    public class GrouperType : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
        public GrouperType Parent { get; set; }
        public string ReferenceColorRGB { get; set; }
        public string ReferenceIcon { get; set; }
        public int Order { get; set; }
    }
}
