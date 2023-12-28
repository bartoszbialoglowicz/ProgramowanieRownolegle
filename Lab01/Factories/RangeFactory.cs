using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01.Factories
{
    internal class RangeFactory
    {

        public static List<Calcs.Range> GetRanges()
        {
            return new List<Calcs.Range>
            {
                new Calcs.Range(-10, 10),
                new Calcs.Range(-5, 20),
                new Calcs.Range(-5, 0),
            };
        }
    }
}
