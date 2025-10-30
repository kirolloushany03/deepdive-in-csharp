namespace DeepDive_In_C_.AsynchronousParallelAndMultiThreading;

internal class Threads
{
    public static void RunThreadExmaples()
    {
        //thread object in c# allow us to create and manage threads
        //template
        Thread thread = new Thread(() =>
        {
            //do anything
        });


        ThreadContext thread1Context = new(
                Name: "Thread 1",
                Message: "hello from thread 1!"
            );

        //passing parameters to the threads
        Thread thread1 = new Thread(new ParameterizedThreadStart(o =>
        {
            ThreadContext context = (ThreadContext)o;

            Thread.CurrentThread.Name = context.Name;
            Console.WriteLine($"{Thread.CurrentThread.Name}: {context.Message}");
        }));

        thread1.Start(thread1Context);


        //ThreadContext thread2Context = new(
        //        Name:"Thread 2",
        //        Message: "hello from thread 2!"
        //    );

        //Thread thread2 = new Thread(new ParameterizedThreadStart(o => 
        //{
        //    ThreadContext context = (ThreadContext)o;
        //    Thread.CurrentThread.Name = context.Name;

        //    while (true)
        //    {
        //        Console.WriteLine($"{Thread.CurrentThread.Name}: {context.Message}");
        //        Thread.Sleep(1000);
        //    }
        //}));

        //thread2.Start(thread2Context);

        //we can also set a thread to be a backtgoud  thread
        //which will autmatically stop wiht en the main thread stops

        ThreadContext thread3Context = new(
                Name: "Thread 3",
                Message: "hello from thread 3!"
            );

        Thread thread3 = new Thread(new ParameterizedThreadStart(o =>
        {
            ThreadContext context = (ThreadContext)o;
            Thread.CurrentThread.Name = context.Name;

            while (true)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}: {context.Message}");
                Thread.Sleep(1000);
            }
        }));
        thread3.IsBackground = true;
        thread3.Start(thread3Context);

        Console.WriteLine("press enter to stop thread 3");
        Console.ReadLine();
    }
    record ThreadContext(string Name, string Message);
}
