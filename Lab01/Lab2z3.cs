using Lab01.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01
{
    class Lab2z3
    {
        private double totalProgress;

        private int pobierzDaneWejsciowe()
        {
            // Prechowuje numer funkcji pobranej od uzytkownika
            string input;
            // Przechowuje liczbe przedzialow pobrana od uzytkownika
            // Wykonuj dopoki uzytkownik nie poda odpowiedniej wartosci
            do
            {
                Console.WriteLine("1. y = 2x + 2x^2\n2. y = 2x^2\n3. y = 2x - 3\n4. y = 3x^3 - 2x^2 + 5x - 3\nWybierz opcję: ");
                input = Console.ReadLine();
            } while (input != "1" && input != "2" && input != "3" && input != "4");

            
            return int.Parse(input);
        }

        private void progressReporter(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            
            Console.WriteLine($"Progress: {e.ProgressPercentage}%");
        }

        private void doWorkMethod(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var worker = sender as System.ComponentModel.BackgroundWorker;
            WorkArguments arg = e.Argument as WorkArguments;
            double res = arg.CurrentMethod ? arg.Calka.trapezy() : arg.Calka.prostokaty();
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
            string calcMethod = arg.CurrentMethod ? "Metoda trapezów" : "Metoda prostokątów";
            e.Result = $"Ukończono obliczenia dla przedziału [{arg.Calka.X1},{arg.Calka.X2}] {calcMethod}, wynik: {res}";
        }

        private void workerCompletedMethod(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

            if (e.Cancelled)
            {
                Console.WriteLine("Zatrzymano obliczenia");
            }
            else
            {
                Console.WriteLine(e.Result);
            }
        }
        private void runBgWorkers(Calka[] calki)
        {
            // Inicjalizacja zadań w tle
            System.ComponentModel.BackgroundWorker[] backgroundWorkers = new System.ComponentModel.BackgroundWorker[calki.Length*2];
            int currentWorker = 0;
            for (int i = 0; i < calki.Length; i++)
            {
                // BG worker dla metody trapezow
                backgroundWorkers[currentWorker] = new System.ComponentModel.BackgroundWorker();
                backgroundWorkers[currentWorker].DoWork += doWorkMethod;
                backgroundWorkers[currentWorker].ProgressChanged+= progressReporter;
                backgroundWorkers[currentWorker].WorkerReportsProgress = true;
                backgroundWorkers[currentWorker].RunWorkerAsync(new WorkArguments(calki[i], true));
                backgroundWorkers[currentWorker].RunWorkerCompleted += workerCompletedMethod;

                // BG worker dla metody prostokatow
                backgroundWorkers[currentWorker+1] = new System.ComponentModel.BackgroundWorker();
                backgroundWorkers[currentWorker+1].DoWork += doWorkMethod;
                backgroundWorkers[currentWorker+1].ProgressChanged += progressReporter;
                backgroundWorkers[currentWorker+1].WorkerReportsProgress = true;
                backgroundWorkers[currentWorker+1].RunWorkerAsync(new WorkArguments(calki[i], false));
                backgroundWorkers[currentWorker+1].RunWorkerCompleted += workerCompletedMethod;
            }
        }

        // Wybierz odpowiednia funkcje
        public void wykonaj()
        {
            int index = pobierzDaneWejsciowe();
            // Przechowuje liczbe przedzialow pobrana od uzytkownika
            int n = UserInput.getNumber("Wprowadz liczbe odcinkow: ", true);
            CalkaFn fn = fn1;

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
                case 4:
                    fn = fn4;
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
