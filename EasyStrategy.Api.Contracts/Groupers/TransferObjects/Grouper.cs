using System;
using System.Collections.Generic;
using System.Text;

namespace EasyStrategy.Api.TransferObjects
{
    public class Grouper
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long GrouperTypeId { get; set; }
        public int GrouperTypeLevel { get; set; }
        public long? ParentId { get; set; }
        public string ReferenceColorRGB { get; set; }
        public string ReferenceIcon { get; set; }
        public int Order { get; set; }
        public bool IsTotal { get; set; }
    }
}
