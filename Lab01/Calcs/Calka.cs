using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01.Calcs
{

    class Calka
    {
        private Calcs.Range range;
        private Functions.IFunction fn;
        private double step;

        internal Range Range { get => range; set => range = value; }

        public Calka(Calcs.Range range, Functions.IFunction fn, int stepCount)
        {
            this.range = range;
            this.fn = fn;
            this.step = this.range.getLength(stepCount);
        }

        public double trapezy()
        {
            // Suma wartosci pol trapezow
            double sum = 0;
            for (double i = range.X1; i < range.X2; i += step)
            {
                // Wartosc funkcji w poczatkowym punkcie odcinka
                double fx = fn.Calc(i);
                // Wartosc funkcji w koncowym punkcie odcinka
                double fx2 = fn.Calc(i + step);

                // Obliczenie pola trapezu w danym odcinku i dodanie wartosci do sumy
                sum += (fx + fx2) * step / 2;
            }

            return sum;
        }

        public double prostokaty()
        {
            // Suma wartosci pol prostokatow
            double sum = 0;
            for (double i = range.X1 + step; i <= range.X2; i += step)
            {
                // Wartosc funkcji w danym punkcie
                double fx = fn.Calc(i);
                // Dodaj pole obecnego odcinka do sumy
                sum += fx * step;
            }

            return sum;
        }

        public string getInfo()
        {
            return $"Calka oznaczona w przedziale <{range.X1},{range.X2}>";
        }
    }
}
