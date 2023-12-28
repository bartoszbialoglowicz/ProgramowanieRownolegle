using Lab01.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01
{
    internal class WorkArguments
    {
        private Calka calka;
        // True dla trapezow false dla prostokatow
        private bool currentMethod;

        public bool CurrentMethod { get => currentMethod; set => currentMethod = value; }
        internal Calka Calka { get => calka; set => calka = value; }

        public WorkArguments(Calka calka, bool currentMethod)
        {
            this.calka = calka;
            this.currentMethod = currentMethod;
        }
    }
}
