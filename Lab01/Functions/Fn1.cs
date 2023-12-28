using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01.Functions
{
    internal class Fn1 : IFunction
    {
        private string name;
        public string Name { get => "y = 2x^2";}

        public double Calc(double x)
        {
            
            return 2 * Math.Pow(x, 2);
        }
    }
}
