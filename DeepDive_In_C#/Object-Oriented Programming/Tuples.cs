global using colors22 = (byte R, byte G, byte B);
namespace DeepDive_In_C_.Object_Oriented_Programming;


internal class Tuples
{
    public static void RunTuplesExamples()
    {
        //Tubles
        //Ah shit here we go again
        //what is tubles (a light weight data transfer object)
        //that can contain multple values of diffrenct types 

        // Tuples in C# come in two different flavors:
        // 1. System.Tuple:
        //  -reference type
        //  - immutable ( you can't change it after it's created.)
        //  - values are properties
        //2. System.ValueTuple: a value type
        //  - value type
        //  - mutable
        //  - values are fields

        
        

        //lets begin with the system.Tuple
        Tuple<int, string> tuple = new Tuple<int, string>(1, "one");
        Tuple<int, string> tuple2 = new(1, "one");

        //system.ValueTuple

        ValueTuple<int, string> ValueTuple = new ValueTuple<int, string>(1, "one");
        ValueTuple<int, string> ValueTuple2 = new(1, "one");
        ValueTuple<int, string> ValueTuple3 = (1, "one");

        var ValueTuple4 = (1, 2, 3, 4, 5, 8, 6, 4, "one", 0.25);

        /*let summaries what happend up
         * - we have gernics in both cases
         * - the type parameters are for each of the items the tuple will hold
         * - we know we have refrence vs value types here between both of them
         * - the sytax of the valueTuple is simpler
         * - valueTuples can take in an arbitrary number of elements
         * (You can put as many values as you want into a ValueTuple—it’s flexible, not limited to a specific number.)
         */



        /* wy we use tuples
         * - returning multiple values from a method
         * - passing multiple values to a method
         * - grouping multiple values together
         * - all without having to go make a dedicated class
         */

        //how would we return a min and max from a method before tupels
        // - use out parameters
        // - use a cusom return type
        int GetMinAndMaxOutParameter(int[] numbers, out int max)
        {
            if (numbers.Length == 0)
                throw new ArgumentException("cannot find min and max of an empty array");
            int min = numbers[0];
            max = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] < min)
                    min = numbers[i];
                if (numbers[i] > max)
                    max = numbers[i];
            }
            return min;
        }

        int[] numbers = { 1, 2, 3, 4, 5, 7, 8, 9 };

        int min = GetMinAndMaxOutParameter(numbers, out int max);
        Console.WriteLine($"{min} this the min value and this the max value {max}");

        //lets now make it with tuples

        (int, int) GetMinAndMaxWithTuple(int[] numbers)
        {
            if (numbers.Length == 0)
                throw new ArgumentException("cannot find min and max of an empty array");

            int min = numbers[0];
            int max = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] < min)
                    min = numbers[i];
                if (numbers[i] > max)
                    max = numbers[i];
            }
            return (min, max);
        }

        Console.WriteLine("min and max with tupele");
        var MinAndMax = GetMinAndMaxWithTuple(numbers);
        Console.WriteLine($"min is {MinAndMax.Item1} and the max {MinAndMax.Item2}");
        Console.WriteLine($"the whole tuple {MinAndMax}");


        (int Min, int Max) GetMinAndMaxWithNamedTuple(int[] numbers)
        {
            if (numbers.Length == 0)
                throw new ArgumentException("cannot find min and max of an empty array");

            int min = numbers[0];
            int max = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] < min)
                    min = numbers[i];
                if (numbers[i] > max)
                    max = numbers[i];
            }
            //return (Min: min, Max: max);
            return (min, max);
        }
        var MinAndMaxNamed = GetMinAndMaxWithNamedTuple(numbers);
        Console.WriteLine($"with nameing min and max --> min is {MinAndMaxNamed.Min} and the max {MinAndMaxNamed.Max}");
        Console.WriteLine($"the whole tuple {MinAndMaxNamed}");



        //deconstruct tubeles
        (int fristthing, string secundthing) = (1, "this the secound thing");
        (int minval, int maxval) nnn = GetMinAndMaxWithNamedTuple(numbers);
        (int minval2, _) = GetMinAndMaxWithNamedTuple(numbers); // you can also discard what you want


        //just we can understan or to know the types of it in the tuple we can do use the var one out of the front
        var (firstthing, secoundthing) = (1, "hellow");

        colors22 newcolors = (255, 0, 0);
        newcolors.R = 128;


        //equlity tubles
        (int, string, int) TupleA = (123, "hello", 456);
        (int, int) TupleB = (123, 456);
        (float, float) TupleC = (FirstNumber: 123, SecoundNumber: 456);
        (byte, string, float) TupleD = (FirstNumber: 123, Name: "hello", SecoundNumber: 456);
        (int, int) TupleE = (456, 789);
        (byte, string, float) TupleF = (123, "world", 456);
        (string, string) TupleG = ("hello", "world");

        Console.WriteLine($"tupelA == tupleB: {TupleA == TupleD}");
        Console.WriteLine($"tupelA == tupleF: {TupleA == TupleF}");
        Console.WriteLine($"tupelB == tupleC: {TupleB == TupleC}");
        Console.WriteLine($"tupelB == tupleE: {TupleB == TupleE}");


        //if we used the .equals is not suported for to comparson so all will be false
        Console.WriteLine($"\ntupelA == tupleB: {TupleA.Equals(TupleD)}");
        Console.WriteLine($"tupelA == tupleF: {TupleA.Equals(TupleF)}");
        Console.WriteLine($"tupelB == tupleC: {TupleB.Equals(TupleC)}");
        Console.WriteLine($"tupelB == tupleE: {TupleB.Equals(TupleE)}");


        //so at the end 
        // - 🔢 Cardinality matters: same number of elements & compatible types
        // - 🏷️ Element names are ignored in comparison
        // - 🔄 Order of elements IS considered
        // - 🔄 Types don't need to be identical, just compatible

    }
}
