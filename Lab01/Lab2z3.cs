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
            e.Result = $"Ukończono obliczenia dla przedziału {arg.Calka.Range.getText()} {calcMethod}, wynik: {res}";
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
        private void runBgWorkers(List<Calcs.Calka> calki)
        {
            // Inicjalizacja zadań w tle
            System.ComponentModel.BackgroundWorker[] backgroundWorkers = new System.ComponentModel.BackgroundWorker[calki.Count*2];
            int currentWorker = 0;
            calki.ForEach(calka =>
            {
                // BG worker dla metody trapezow
                backgroundWorkers[currentWorker] = new System.ComponentModel.BackgroundWorker();
                backgroundWorkers[currentWorker].DoWork += doWorkMethod;
                backgroundWorkers[currentWorker].ProgressChanged += progressReporter;
                backgroundWorkers[currentWorker].WorkerReportsProgress = true;
                backgroundWorkers[currentWorker].RunWorkerAsync(new WorkArguments(calka, true));
                backgroundWorkers[currentWorker].RunWorkerCompleted += workerCompletedMethod;

                // BG worker dla metody prostokatow
                backgroundWorkers[currentWorker + 1] = new System.ComponentModel.BackgroundWorker();
                backgroundWorkers[currentWorker + 1].DoWork += doWorkMethod;
                backgroundWorkers[currentWorker + 1].ProgressChanged += progressReporter;
                backgroundWorkers[currentWorker + 1].WorkerReportsProgress = true;
                backgroundWorkers[currentWorker + 1].RunWorkerAsync(new WorkArguments(calka, false));
                backgroundWorkers[currentWorker + 1].RunWorkerCompleted += workerCompletedMethod;
            });
            
                
            
        }

        // Wybierz odpowiednia funkcje
        public void wykonaj()
        {
            Functions.IFunction fn = UserInput.getFunction();
            List<Calcs.Range> ranges = Factories.RangeFactory.GetRanges();
            int steps = UserInput.getSteps();
            List<Calcs.Calka> calki = Factories.CalkaFactory.dajListeCalek(ranges, fn, steps);
            runBgWorkers(calki);
        }
    }
}
