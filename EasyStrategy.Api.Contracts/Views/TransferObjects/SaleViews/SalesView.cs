using System;
using System.Collections.Generic;
using System.Text;

namespace EasyStrategy.Api.TransferObjects
{
    public class SalesView : Dictionary<string, object>
    {
        public DateTime LastUpdate { get; set; }
        public List<ISaleView> Views { get; set; }


    }
}
