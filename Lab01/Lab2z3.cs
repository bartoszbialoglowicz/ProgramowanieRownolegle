using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01
{
    class Lab2z3
    {

        // Funkcja y = 2x + 2x^2
        private static double fn1(double x)
        {
            return (2 * x) + 2 * Math.Pow(x, 2);
        }

        // Funkcja y = 2x^2
        private static double fn2(double x)
        {
            return 2 * Math.Pow(x, 2);
        }

        // Funkcja y = 2x - 3
        private static double fn3(double x)
        {
            return 2 * x - 3;
        }

        // Funkcja wielomianowa z lab2b
        // f(x) = 3x^3 - 2x^2 + 5x - 3
        private static double fn4(double x)
        {
            return (3 * Math.Pow(x, 3)) - (2 * Math.Pow(x, 2)) + (5 * x) - 3;
        }

        private int pobierzDaneWejsciowe()
        {
            // Prechowuje numer funkcji pobranej od uzytkownika
            string input;
            // Przechowuje liczbe przedzialow pobrana od uzytkownika
            // Wykonuj dopoki uzytkownik nie poda odpowiedniej wartosci
            do
            {
                Console.WriteLine("1. y = 2x + 2x^2\n2. y = 2x^2\n3. y = 2x - 3\nWybierz opcję: ");
                input = Console.ReadLine();
            } while (input != "1" && input != "2" && input != "3");

            
            return int.Parse(input);
        }

        private void progressReporter(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            
            Console.WriteLine($"Progress: {e.ProgressPercentage}%");
        }

        private void doWorkMethod(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var worker = sender as System.ComponentModel.BackgroundWorker;
            Calka calka = e.Argument as Calka;
            for (int i = 0; i <= 100; i+= 10)
            {
                if (!worker.CancellationPending)
                {
                    worker.ReportProgress(i);
                    System.Threading.Thread.Sleep(100);
                }
                else
                {
                    e.Cancel = true;
                }
            }
            e.Result = calka.trapezy();
        }

        private void workerCompletedMethod(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                Console.WriteLine("Zatrzymano obliczenia");
            }
            else
            {
                Console.WriteLine($"Ukonczono obliczenia. Wynik: {e.Result}");
            }
        }
        private void runBgWorkers(Calka[] calki)
        {
            // Inicjalizacja zadań w tle
            System.ComponentModel.BackgroundWorker[] backgroundWorkers = new System.ComponentModel.BackgroundWorker[calki.Length];
            for (int i = 0; i < calki.Length; i++)
            {
                backgroundWorkers[i] = new System.ComponentModel.BackgroundWorker();
                backgroundWorkers[i].DoWork += doWorkMethod;
                backgroundWorkers[i].ProgressChanged+= progressReporter;
                backgroundWorkers[i].WorkerReportsProgress = true;
                backgroundWorkers[i].RunWorkerAsync(calki[i]);
                backgroundWorkers[i].RunWorkerCompleted += workerCompletedMethod;
            }
        }

        // Wybierz odpowiednia funkcje
        public void wykonaj()
        {
            int index = pobierzDaneWejsciowe();
            // Przechowuje liczbe przedzialow pobrana od uzytkownika
            int n = UserInput.getNumber("Wprowadz liczbe odcinkow: ", true);
            CalkaFn fn = fn1;


            // TODO: trapezy

            switch(index)
            {
                case 1:
                    fn = fn1;
                    break;
                case 2:
                    fn = fn2;
                    break;
                case 3:
                    fn = fn3;
                    break;
            }

            Calka[] calki = {
                new Calka(-10, 10, n, fn),
                new Calka(-5, 20, n, fn),
                new Calka(-5, 0, n, fn)
            };
            
            runBgWorkers(calki);
        }
    }
}
