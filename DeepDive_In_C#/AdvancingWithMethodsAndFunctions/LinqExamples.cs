namespace DeepDive_In_C_.AdvancingWithMethodsAndFunctions;

public class LinqExamples
{
    public static void RunExmaples()
    {
        ///LINQ stand for language integrated query
        /// we get acccess to bunch of linq methods in the System.Linq  namesapce
        /// that operate on IEnumberable<T> 
        /// they are all  extention methods

        /// LINQ can help us
        /// - map: transform each item
        /// -filter: only taek some items
        /// -reduce: combine items

        //map: transofrm each element in a collection
        List<string> rawNumbers = ["1", "2", "3", "4", "5",];

        List<int> numbers = new();

        foreach (string rawnumber in rawNumbers)
        {
            numbers.Add(int.Parse(rawnumber));
            Console.WriteLine(string.Join(",", numbers));
        }

        //using linq

        var numbers2 = rawNumbers
            .Select(number => int.Parse(number))
            .ToList();

        Console.WriteLine($"so this numbers2 {string.Join(",", numbers2)}");


        //filter
        //normal one
        List<int> evennumbers = new();
        foreach (int number in numbers)
        {
            if (number % 2 == 0)
                evennumbers.Add(number);
        }

        Console.WriteLine($"even numbers " +
            $"{string.Join(",", evennumbers)}");

        //linq way
        var evenNumbers2 = numbers2
            .Where(number => number % 2 == 0);

        PrintAll("evenNumbers2 ", evenNumbers2);


        //average without using linq
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        double average = sum / (double)numbers.Count();

        Console.WriteLine($"average wihtou linq {average}");

        //average with linq

        var avarage2 = numbers2
            .Average();

        Console.WriteLine($"average using linq {avarage2}");


        //making our linq
        var myLinqReuslt = numbers
            .KiroLinqMethod(number => number * 2)
            .ToArray();

        Console.WriteLine(string.Join(",", myLinqReuslt));

        void PrintAll<T>(string title, IEnumerable<T> list)
        {
            Console.WriteLine($"{title}" +
                $"{string.Join(",", list)}");
        }
    }
}

public static class MyLinq
{
    public static IEnumerable<T> KiroLinqMethod<T>(this IEnumerable<T> source, Func<T, T> selector)
    {
        foreach (T item in source)
        {
            Console.WriteLine($"Applying selector to {item}");
            yield return item;
        }
    }
}
