namespace DeepDive_In_C_.AsynchronousParallelAndMultiThreading;

internal class AsyncAwait
{
    public static async Task RunExamples()
    {
        /// like using task objects and we can use the aysnc/await keywords to 
        /// structure async code without having to think about it in
        /// terms of objects
        #region part one
        /*
            in order to make an async method , we use a new keyword
        and the task object as  the return type 
         */

        Console.WriteLine($"main thread {Thread.CurrentThread.ManagedThreadId}");

        async Task FirstAsyncMethod()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            Console.WriteLine($"done firstasyncMethod {Thread.CurrentThread.ManagedThreadId}");
        }
        ;

        /*
         * if we need to return anything , we use Task<T> the genric version
         * to be abel to pass back data:
         */
        async Task<int> SecoundAsyncMethod()
        {
            await Task.Delay(TimeSpan.FromSeconds(500));
            return 3;
        }

        /*
            much like the task objects , we can these async methods
            and they'll go off and run but we should track them 
            we can use the await keyword to wait for the async method.

            within our conetxt we will not run the code after the await
            until the async method has completed
         */
        #region excute FirstAsyncMethod()
        Console.WriteLine("awaiting FirstAsyncMethod...");
        await FirstAsyncMethod();

        //alternatively ...
        Console.WriteLine("awaiting firstasyncmethod again");
        Task firstAsyncMethodTask = FirstAsyncMethod();
        await firstAsyncMethodTask;

        #endregion

        #endregion

        #region part 2
        //like our task eexamples we cann run several async methods

        async Task<string> ThirdAsyncMethod(TimeSpan timeToWait, string messageToWrite)
        {
            await Task.Delay(timeToWait);
            Console.WriteLine(messageToWrite);
            return messageToWrite;
        }

        //Console.WriteLine("starting 3 async methods");

        Task<string> task1 = ThirdAsyncMethod(TimeSpan.FromSeconds(3), "Task 1 has completed");
        Task<string> task2 = ThirdAsyncMethod(TimeSpan.FromSeconds(1), "Task 2 has completed");
        Task<string> task3 = ThirdAsyncMethod(TimeSpan.FromSeconds(2), "Task 3 has completed");


        #region excuting ThirdAsyncMethod()
        //we can wait for all of them to complete

        Console.WriteLine("waiting for 3 async methods ...");
        await Task.WhenAll(task1, task2, task3);
        Console.WriteLine("all 3 async methods have completed");


        // alternatively we can also wait until any of them completes using 
        //  whenAny()
        // Returns the first Task that completes,
        // regardless of whether it succeeded, failed, or was canceled.


        Task<string> firsTaskToComplete = await Task.WhenAny(task1, task2, task3);

        #endregion

        #endregion

        #region part3
        /*
         * let's look at this interesting behavior to understand
         * that marking somethig async doesn't just make it 
         * automatically run assynchronously
         */

        async Task NotActuallyAsync()
        {
            Console.WriteLine("Entering NotActuallyAsync...");
            Thread.Sleep(1000);
            Console.WriteLine("Exiting NotActuallyAsync...");
        }

        //we can call this method and await it but it will not
        Console.WriteLine("calling NotActuallyAsync...");
        Task notActuallyAsyncTask = NotActuallyAsync();
        Console.WriteLine("awaiting NotActuallyAsync...");
        await notActuallyAsyncTask;
        Console.WriteLine("finsihed await NotActuallyAsync");

        Console.WriteLine(string.Empty);


        async Task LeverageTaskYield()
        {
            Console.WriteLine("entring LeverageTaskYield...");
            await Task.Yield();
            Console.WriteLine("continuing from LeverageTaskYield ...");
            Thread.Sleep(1000);
            Console.WriteLine("exiting LeverageTaskYield...");
        }

        /*
            we can call this method awit it and it will
        at least allow the scheduler to run other tasks 
        and this because of calling yeild
         */

        Console.WriteLine("calling LeverageTaskYield...");
        Task leverageTaskYieldTask = LeverageTaskYield();
        Console.WriteLine("awiting LeverageTaskYield...");
        await leverageTaskYieldTask;
        Console.WriteLine("finshed waitng LeverageTaskYield....");

        #endregion

        #region part 4
        /*
            it is important ot note that once you introduce async/await
        into the call tree you should use it all the way up/down
        lets lookk at twhat happens to our exception handling
        when you mix async and non-async code
         */

        async Task TestCatchingExceptions()
        {
            Console.WriteLine("TestCatchingExceptions ThisIsNotATask..");
            await Task.Delay(TimeSpan.FromSeconds(1));
            Console.WriteLine("Finished dealy inside TestCatchingExceptions...");

            Console.WriteLine("caling async method...");
            try
            {
                await ThisIsATask();
                // so we can not await this because this method is async but nnot return a Task
                //await ThisIsNotATask();
                //ThisIsNotATask();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"caought excption from async method :{ex.Message}");
            }
        }


        async Task ThisIsATask()
        {
            Console.WriteLine("entring ThisIsATask..");
            await Task.Delay(TimeSpan.FromSeconds(1));
            Console.WriteLine("Finished dealy inside ThisIsATask...");

            throw new Exception("ThisIsATask has throown an exception");
        }
        async void ThisIsNotATask()
        {
            Console.WriteLine("entring ThisIsNotATask..");
            await Task.Delay(TimeSpan.FromSeconds(1));
            Console.WriteLine("Finished dealy inside ThisIsNotATask...");

            throw new Exception("ThisIsNotATask has throown an exception");
        }



        await TestCatchingExceptions();
        Console.ReadLine();
        #endregion
    }
}
