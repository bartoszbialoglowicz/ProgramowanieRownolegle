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
            Console.WriteLine(text);
            // Docelowo przechowuje przekonwerowana wartosc wejsciowa
            int output;
            // Docelowo przechowuje nieprzekonwerowana wartosc wejsciowa
            string input;

            // Wykonuj dopoki podany teskt bedzie liczba
            do
            {
                input = Console.ReadLine();
            } while (!int.TryParse(input, out output));

            // Jezeli argument abs==true zwroc wartosc absolutna
            return abs ? Math.Abs(output) : output;
        }
    }
}
