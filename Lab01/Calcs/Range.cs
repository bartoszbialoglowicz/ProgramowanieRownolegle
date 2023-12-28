using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01.Calcs
{
    internal class Range
    {
        private double x1;
        private double x2;

        public double X1 { get => x1; set => x1 = value; }
        public double X2 { get => x2; set => x2 = value; }

        public Range(double x1, double x2)
        {
            this.x1 = x1;
            this.x2 = x2;
        }

        public string getText()
        {
            return $"<{x1},{x2}>";
        }

        public double getLength(int steps)
        {
            if (x1 >= 0 && x2 >= 0)
                return Math.Abs(x1 - x2);
            if (x1 >= 0 && x2 <= 0)
                return x1 + Math.Abs(x2);
            if (x1 <= 0 && x2 >= 0)
                return x2 + Math.Abs(x1);

            return Math.Abs(Math.Abs(x1) - Math.Abs(x2));
        }
    }
}
