namespace DeepDive_In_C_.AsynchronousParallelAndMultiThreading;

internal class Tasks
{
    public static void RunExambles()
    {
        /// Tasks in c# allow us to perform asyncronos operations 
        /// using task objects , we can get more conrol over
        /// how we'd like our asynchornous opertions to be executed.

        Console.WriteLine($"Main Thread Id: {Thread.CurrentThread.ManagedThreadId}");

        Task task1 = Task.Run(() =>
        {
            Console.WriteLine($"Task 1 thred id :{Thread.CurrentThread.ManagedThreadId}");
        });

        Task task2 = Task.Run(() =>
        {
            Console.WriteLine($"Task 2 thred id :{Thread.CurrentThread.ManagedThreadId}");
        });

        Task task3 = Task.Run(() =>
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Task 3 thred id :{Thread.CurrentThread.ManagedThreadId} {i}");
                Thread.Sleep(1000);
            }
        });


        Task.WaitAll(task1, task2, task3);
        Console.WriteLine("Tasks 1 ,2,3 have completed ");



        Task task4 = Task.Run(() =>
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Task 4 Thread Id: {Thread.CurrentThread.ManagedThreadId} {i}");
                Thread.Sleep(500);
            }
        });

        task4.Wait();
        Console.WriteLine("Task 4 completed");

        /// we can also use the "builder patter"  to cahin thingns together
        /// on task objects:
        Task task5 = Task.Run(() =>
        {
            Console.WriteLine($"Task 5 Thread ID: {Thread.CurrentThread.ManagedThreadId}");
        }).ContinueWith((prevTask) =>
        {
            Console.WriteLine($"Task 5 continuation Thread Id: {Thread.CurrentThread.ManagedThreadId}");
            throw new Exception("we intended to do this!#");
        }).ContinueWith((prevTask) =>
        {
            Console.WriteLine($"Task 5 continuation 2 Thread Id: {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"{prevTask.Exception.GetType().Name}: {prevTask.Exception.Message}");
        }, TaskContinuationOptions.OnlyOnFaulted);
        task5.Wait();


        /// aggregate excption are a way to handle multiple exceptions
        /// that can occur when working with tasks
        AggregateException aggregateException = new(
            "This is the aggregate exception message",
            new InvalidOperationException("This the first inner exception"),
            new ArgumentException("This tthe secount inner exception."));

        try
        {
            throw aggregateException;
        }
        catch (AggregateException ex)
        {
            Console.WriteLine($"{ex.GetType().Name}: {ex.Message}");
            foreach (Exception innerEx in ex.InnerExceptions)
            {
                Console.WriteLine($"\t{innerEx.GetType().Name}: {innerEx.Message}");
            }
        }
    }
}
