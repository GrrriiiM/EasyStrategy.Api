using System;
using System.Collections.Generic;
using System.Text;

namespace EasyStrategy.Domain.Groupers
{
    public class Grouper : BaseEntity
    {
        protected Grouper()
        {

        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public virtual GrouperType Type { get; private set; }
        public virtual Grouper Parent { get; private set; }
        public string ReferenceColorRGB { get; private set; }
        public string ReferenceIcon { get; private set; }
        public int Order { get; private set; }
        public bool IsTotal { get; private set; }
        public virtual ICollection<Grouper> Childrens { get; private set; }
    }
}
