using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01.Factories
{
    internal class RangeFactory
    {
        private List<Range> ranges;

        public List<Range> Ranges { get => ranges; set => ranges = value; }

        public RangeFactory(List<Range> rangeList)
        {
            this.ranges = rangeList;
        }
    }
}
