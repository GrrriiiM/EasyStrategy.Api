using System;
using System.Collections.Generic;
using System.Text;

namespace EasyStrategy.Api.TransferObjects
{
    public class GrouperType
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int Order { get; set; }
        public long? ParentId { get; set; }
    }
}
