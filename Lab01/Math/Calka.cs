using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01.Math
{

    public delegate double CalkaFn(double x);
    class Calka
    {
        private Range range;
        private CalkaFn fn;

        internal Range Range { get => range; set => range = value; }

        public Calka(Range range, CalkaFn fn)
        {
            this.range = range;
            this.fn = fn;
        }

        public double trapezy()
        {
            // Suma wartosci pol trapezow
            double sum = 0;
            for (double i = range.X1; i < range.X2; i += range.Step)
            {
                // Wartosc funkcji w poczatkowym punkcie odcinka
                double fx = fn(i);
                // Wartosc funkcji w koncowym punkcie odcinka
                double fx2 = fn(i + range.Step);

                // Obliczenie pola trapezu w danym odcinku i dodanie wartosci do sumy
                sum += (fx + fx2) * range.Step / 2;
            }

            return sum;
        }

        public double prostokaty()
        {
            // Suma wartosci pol prostokatow
            double sum = 0;
            for (double i = range.X1 + range.Step; i <= range.X2; i += range.Step)
            {
                // Wartosc funkcji w danym punkcie
                double fx = fn(i);
                // Dodaj pole obecnego odcinka do sumy
                sum += fx * range.Step;
            }

            return sum;
        }

        public string getInfo()
        {
            return $"Calka oznaczona w przedziale <{range.X1},{range.X2}>";
        }
    }
}
