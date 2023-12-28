using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01.Functions
{
    class Fn2 : IFunction
    {
        private string name;
        public string Name { get => "y = 2x - 3";}

        public double Calc(double x)
        {
            return (2 * x) - 3;
        }
    }
}
