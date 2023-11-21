using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01
{

    public delegate double CalkaFn(double x);
    class Calka
    {
        // Poczatek przedzialu calkowania
        private float x1;
        // Koniec przedzialu calkowania
        private float x2;
        // Liczba odcinkow
        private int liczbaOdcinkow;
        // Dlugosc pojedynczego odcinka
        private float dlugoscOdcinka;
        // Funkcja
        private CalkaFn fn;

        public Calka(float x1, float x2, int liczbaOdcinkow, CalkaFn fn)
        {
            this.x1 = x1;
            this.x2 = x2;

            // x1 bedzie zawsze poczatkiem przedzialu
            if (x2 < x1)
            {
                this.x1 = x2;
                this.x2 = x1;
            }

            this.liczbaOdcinkow = liczbaOdcinkow;
            this.dlugoscOdcinka = (this.x2 - this.x1) / liczbaOdcinkow;
            this.fn = fn;
        }

        public double trapezy()
        {
            // Suma wartosci pol trapezow
            double sum = 0;
            for (double i = this.x1; i < this.x2; i += this.dlugoscOdcinka)
            {
                // Wartosc funkcji w poczatkowym punkcie odcinka
                double fx = this.fn(i);
                // Wartosc funkcji w koncowym punkcie odcinka
                double fx2 = this.fn(i + this.dlugoscOdcinka);

                // Obliczenie pola trapezu w danym odcinku i dodanie wartosci do sumy
                sum += ((fx + fx2) * dlugoscOdcinka) / 2;
            }

            return sum;
        }

        public double prostokaty()
        {
            // Suma wartosci pol prostokatow
            double sum = 0;
            for (double i = this.x1 + this.dlugoscOdcinka; i <= this.x2; i += this.dlugoscOdcinka)
            {
                // Wartosc funkcji w danym punkcie
                double fx = this.fn(i);
                // Dodaj pole obecnego odcinka do sumy
                sum += fx * dlugoscOdcinka;
            }

            return sum;
        }

        public string getInfo()
        {
            return $"Calka oznaczona w przedziale <{this.x1},{this.x2}>";
        }
    }
}
