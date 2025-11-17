using System.Threading.Tasks;

namespace DeepDive_In_C_.AsynchronousParallelAndMultiThreading;

internal class CancellationTokens
{
    public static async Task RunExamples()
    {
        //cancelation  tokens

        /// we can use cancellation tokens with our async/await code
        /// to cancel tasks that are running:
        /// we can get a token from a cancellationTokenSource 

        CancellationTokenSource cts = new CancellationTokenSource();
        var cancellationToken = cts.Token;


        async Task LoopUntilCancelldAsync(CancellationToken cancellationToken)
        {
            await Task.Yield();
            Console.WriteLine("looping unitl Cancelled...");

            ///we can throw exctpion but not recommnded
            ///cancellationToken.ThrowIfCancellationRequested
            while (!cancellationToken.IsCancellationRequested)
            {
                Console.WriteLine("waiting ...");
                //await Task.Delay(3000, cancellationToken);\
                try
                {
                    await Task.Delay(3000, cancellationToken);
                }
                catch (OperationCanceledException)
                {
                    break;
                }
            }
            Console.WriteLine("cancelled");
        }

        /*Console.WriteLine("press enter to cancel the loop");
        Task loopTask = LoopUntilCancelldAsync(cancellationToken);

        Console.ReadLine();
        cts.Cancel();

        await loopTask;*/

        //we can chain cancellation tokens together:
        CancellationTokenSource cts2 = new CancellationTokenSource();
        var cancellationToken2 = cts2.Token;
        var linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken2);
        var linkedToken = linkedTokenSource.Token;

        Console.WriteLine("using a linked token souce!");
        Console.WriteLine("press enter to cancel the loop");
        Task loopTask = LoopUntilCancelldAsync(linkedToken);

        Console.ReadLine();
        cts2.Cancel();

        await loopTask;

        /// recommneded every time to writing an async awaitabel method that you pass in 
        /// cancellation token
    }
}
