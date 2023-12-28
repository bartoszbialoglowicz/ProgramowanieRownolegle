using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01
{
    internal interface IFunction
    {
        string Name { get; set; }
        double GetY(double x);
    }

    class Quadratic: IFunction
    {
        private string name;

        public string Name { get => "x^2"; set => name = value; }
        public double GetY(double x)
        {
            return x * x;
        }
    }

    class Cubic: IFunction
    {
        private string name;

        public string Name { get => "x^3"; set => name = value; }

        public double GetY(double x)
        {
            return x * x * x;
        }
    }

    class Fn2x2xx: IFunction
    {
        private string name;
        public string Name { get => "y = 2x + 2x^2"; set => name = value; }

        public double GetY(double x)
        {
            return (2 * x) + (2 * Math.Pow(x, 2));
        }
    }

    // Funkcja y = 2x^2
    class Fn2xx: IFunction 
    {
        private string name;
        public string Name { get => "y = 2x^2"; set => name = value; }

        public double GetY(double x)
        {
            return 2 * Math.Pow(x, 2);
        }
    }

    // Funkcja y = 2x - 3
    class Fn2x3: IFunction
    {
        private string name;
        public string Name { get => "y = 2x - 3"; set => name = value; }

        public double GetY(double x)
        {
            return (2 * x) - 3;
        }
    }

    // Funkcja wielomianowa z lab2b
    // f(x) = 3x^3 - 2x^2 + 5x - 3
    class FN3x32xx5x3 : IFunction
    {
        private string name;
        public string Name { get => "y = 3x^3 - 2x^2 + 5x - 3"; set => name = value; }

        public double GetY(double x)
        {
            return (3 * Math.Pow(x, 3)) - (2 * (Math.Pow(x, 2))) + (5 * x) - 3;
        }
    }
}
