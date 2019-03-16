using System;
using System.Collections.Generic;
using System.Text;

namespace EasyStrategy.Api.Domain.Groupers
{
    public class Grouper : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public virtual GrouperType Type { get; private set; }
    }
}
