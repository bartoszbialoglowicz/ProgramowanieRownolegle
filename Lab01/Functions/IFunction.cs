using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01.Functions
{
    interface IFunction
    {
        string Name { get; }
        double Calc(double x);
    }
}
