using System.Diagnostics;

namespace DeepDive_In_C_.AdvancingWithMethodsAndFunctions;

public class Lazy
{
    public static void RunExample()
    {
        ///making here an anounymous delegate
        ///and it take the time for the first time only
        Lazy<int> lazyValue = new Lazy<int>(() =>

        {
            Console.WriteLine("This will only run once");
            Console.WriteLine("Finding the max...");
            int[] numbers = [10, 20, 30, 40, 50];

            int max = int.MinValue;
            foreach (var number in numbers)
            {
                if (number > max)
                {
                    max = number;
                }

                Thread.Sleep(1000);
            }

            Console.WriteLine($"the max is: {max}");
            return max;
        }
        );

        Stopwatch stopwatch = Stopwatch.StartNew();

        Console.WriteLine($"the value of lazyvalue is: {lazyValue.Value}");

        stopwatch.Stop();

        Console.WriteLine($"time taken to print lazy value first time only {stopwatch.ElapsedMilliseconds * 0.001} s");


        Stopwatch stopwatch2 = Stopwatch.StartNew();
        Console.WriteLine($"the value of lazyvalue is: {lazyValue.Value}");
        Console.WriteLine($"the value of lazyvalue is: {lazyValue.Value}");
        Console.WriteLine($"the value of lazyvalue is: {lazyValue.Value}");
        Console.WriteLine($"the value of lazyvalue is: {lazyValue.Value}");
        Console.WriteLine($"the value of lazyvalue is: {lazyValue.Value}");

        stopwatch2.Stop();


        Console.WriteLine($"time taken for the next instances after  the first one loaded {stopwatch2.ElapsedMilliseconds * 0.001} s");
    }
}
