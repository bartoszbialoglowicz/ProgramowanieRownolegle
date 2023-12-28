using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01.Factories
{
    class FunctionFactory
    {
        public static List<Functions.IFunction> getFunctionList()
        {

            return new List<Functions.IFunction>
            {
                new Functions.Fn1(),
                new Functions.Fn2(),
                new Functions.Fn3(),
                new Functions.Fn4(),
            };
        }
    }
}
