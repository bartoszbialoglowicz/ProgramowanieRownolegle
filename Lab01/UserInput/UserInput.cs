using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01
{
    class UserInput
    {
        public static int getNumber(string text, bool abs=false)
        {
            // Wyswietl tekst dla uzytkownika
            // Docelowo przechowuje przekonwerowana wartosc wejsciowa
            int output;
            // Docelowo przechowuje nieprzekonwerowana wartosc wejsciowa
            string input;

            // Wykonuj dopoki podany teskt bedzie liczba
            do
            {

                Console.WriteLine(text);
                input = Console.ReadLine();
            } while (!int.TryParse(input, out output));

            // Jezeli argument abs==true zwroc wartosc absolutna
            return abs ? Math.Abs(output) : output;
        }

        public static Functions.IFunction getFunction()
        {
            List < Functions.IFunction > fnList = Factories.FunctionFactory.getFunctionList();
            int index = 0;
            fnList.ForEach(el => Console.WriteLine($"{++index}. {el.Name}"));
            int input = 0;
            do
            {
                input = getNumber("Wybierz funkcję:");
            } while (input <= 0 || input > fnList.Count);

            return fnList[input - 1];
        }

        public static int getSteps()
        {
            int steps = getNumber("Podaj liczbę kroków");
            return steps;
        }
    }
}
