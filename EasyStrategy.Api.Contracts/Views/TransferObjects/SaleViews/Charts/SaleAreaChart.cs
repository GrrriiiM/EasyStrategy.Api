using System;
using System.Collections.Generic;
using System.Text;

namespace EasyStrategy.Api.TransferObjects
{
    public class SaleAreaChartView : ISaleView
    {
        public long IntervalTypeId { get; set; }
        public string IntervalTypeString { get; set; }

        public long MinX { get; set; }
        public long MaxX { get; set; }
        public long MinY { get; set; }
        public long MaxY { get; set; }

        public List<SaleAreaChartInterval> Values { get; set; }

        public class SaleAreaChartInterval
        {
            public long X { get; set; }
            public long Y { get; set; }
        }

    }
}
