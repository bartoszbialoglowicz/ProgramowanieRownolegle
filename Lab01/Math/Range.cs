using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01.Math
{
    internal class Range
    {
        private double x1;
        private double x2;
        private double step;

        public double X1 { get => x1; set => x1 = value; }
        public double X2 { get => x2; set => x2 = value; }
        public double Step { get => step; set => step = value; }
    }
}
