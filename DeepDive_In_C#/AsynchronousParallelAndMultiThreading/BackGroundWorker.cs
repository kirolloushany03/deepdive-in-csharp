using System.ComponentModel;

namespace DeepDive_In_C_.AsynchronousParallelAndMultiThreading;

internal class BackGroundWorker
{
    public static void Runexamples()
    {
        BackgroundWorker worker1 = new BackgroundWorker();


        //we can then subscript to the DoWork event
        worker1.DoWork += (object sender, DoWorkEventArgs e) =>
        {
            //so cancellationnpending will not work if we sleep so it willl
            //wait the sleep to fisnh and the stop
            while (!worker1.CancellationPending)
            {
                Console.WriteLine("worker 1 : working in the background");
                Thread.Sleep(1000);
            }
            Console.WriteLine("worker 1 : done the work and it't completed");
        };

        worker1.WorkerSupportsCancellation = true;
        worker1.RunWorkerAsync();

        //so lets go with another worker

        BackgroundWorker worker2 = new BackgroundWorker();

        worker2.DoWork += (sender, e) =>
        {
            int interations = (int)e.Argument;
            for (int i = 0; i < interations; i++)
            {
                Console.WriteLine($"woker 2 : working inteh backgound on iteration number {i}../../");
                Thread.Sleep(1000);
            }
            //instead of adding completed here we can subscript to another event
        };

        worker2.RunWorkerCompleted += (sender, e) =>
        {
            Console.WriteLine("woker 2 completed from the RunWorkerCompleted event");
            worker1.CancelAsync();
        };

        worker2.RunWorkerAsync(5);

        Console.WriteLine("press enter to exit");
        Console.ReadLine();
    }
}
