using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01.Factories
{
    class CalkaFactory
    {
        public static List<Calcs.Calka> dajListeCalek(List<Calcs.Range> ranges, Functions.IFunction fn, int steps)
        {
            return ranges.Select(range => new Calcs.Calka(range, fn, steps)).ToList();
        }
    }
}
