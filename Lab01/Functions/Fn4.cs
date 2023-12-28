using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01.Functions
{
    class Fn4 : IFunction
    {
        private string name;
        public string Name { get => "y = 3x^3 - 2x^2 + 5x - 3";}

        public double Calc(double x)
        {
            return (3 * Math.Pow(x, 3)) - (2 * (Math.Pow(x, 2))) + (5 * x) - 3;
        }
    }
}
