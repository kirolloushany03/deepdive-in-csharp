namespace DeepDive_In_C_.Object_Oriented_Programming;

internal class Genrics2
{
    public static void RunExamples()
    {
        //genirics again
        //gernics are used to create things with a placeholder for the type
        // - this means that genrics dont care about type
        // - cares only about type in a limitied way
        // we can use genrics on classes , methods, inteface, etc ...



        // ─────────────────────────── 🧭 SECTION: <1>test genric class and give type───────────────────────────


        GenricClass<int> mynumbericInstance = new GenricClass<int>();
        GenricClass<string> MyStrigInstance = new GenricClass<string>();
        //GenricClass instacewithoutType = new GenricClass(); //so this will not work as no type

        // ─────────────────────────── 🧭 SECTION: <3>test normal classe with gernic methods───────────────────────
        ClassWithGernicMethod instanceofclassWithGenricMethhod = new();
        instanceofclassWithGenricMethhod.GenricMehtod("This a string");
        instanceofclassWithGenricMethhod.GenricMehtod(42);
        instanceofclassWithGenricMethhod.GenricMehtod(152.1);

        Console.WriteLine("\nthis by GenricFunction\n");
        //so here we check that the GenricFunction returns the actual type
        //and if we changed the string to int for the first will give us error (connot implcity from string to int)
        string GernicFunctionReustl1 = instanceofclassWithGenricMethhod.GenricFunction("this a string");
        int GernicFunctionReustl2 = instanceofclassWithGenricMethhod.GenricFunction(42);
        double GernicFunctionReustl3 = instanceofclassWithGenricMethhod.GenricFunction(152.1);

        // --------------------------- 🧭 SECTION: <4> testing existing genric ---------------------------
        List<int> ints = new List<int>();
        List<string> stringList = new List<string>();
        //this becaue algorithms and data structre formany collections don't care abpoutthe type fo the elements
        //that i don't care what type you are as loing as you have a parameter list constructor, i
        //just need that constructor on whatever type you're giving me, and we're good to go  or sometimes

        // ─────────────────────────── 🧭 SECTION: <5>test exampele that combine everything───────────────────────────

        Dog dog1 = new(Weight: 20, Height: 30);
        Dog dog2 = new(Weight: 30, Height: 40);

        Cat cat1 = new(Weight: 10, Height: 20, HasFur: false);
        Cat cat2 = new(Weight: 20, Height: 30, HasFur: true);

        Fish fish1 = new(Weight: 0.5, Height: 1);

        var animals = new IAnimal[] { dog1, dog2, cat1, cat2, fish1 };

        Console.WriteLine("\n------------------------------\n");
        Console.WriteLine($"this the sum weight of all the animals {CalculateWeight(animals)}");
        Console.WriteLine($"this the sum height of all the animals {CalculateHeigth(animals)}");
        Console.WriteLine($"this the the animals that has fur {onlyWithFur(animals)}");

        //we can also make this as it is the same type
        var totalcatWeight = new Cat[] { cat1, cat2 };
        var totaldogWeigt = new Dog[] { dog1, dog2 };
        var totalFishweight = new Fish[] { fish1 };


        Console.WriteLine($"this the total weight for cats {CalculateWeight(totalcatWeight)}");
        Console.WriteLine($"this the total weight for dogs {CalculateWeight(totaldogWeigt)}");
        Console.WriteLine($"this the total weight for HasFur {CalculateWeight(totalFishweight)}");


        static double CalculateWeight<T>(IEnumerable<T> animals)
            where T : IAnimal
        {
            var total = animals.Sum(a => a.Weight);
            return total;
        }
        static double CalculateHeigth<T>(IEnumerable<T> animals)
            where T : IAnimal
        {
            var total = animals.Sum(a => a.Height);
            return total;
        }

        IEnumerable<IAnimal> onlyWithFur(IEnumerable<IAnimal> animals)
        {
            return animals.Where(a => a.HasFur);
        }

    }

    // --------------------------- 🧭 SECTION: testing up 👆 ---------------------------

    // ─────────────────────────── 🧭 SECTION: <5> exampele that combine everything───────────────────────────
    //so what if we care about they type but not the exact type?
    // we can use constraints to limit the types that can be used with a generic!

    public interface IAnimal
    {
        double Weight { get; }
        double Height { get; }
        bool HasFur { get; }
    }
    /*just small info for me
     * so this line 👇 (record) done automatically (declares dog, create immutable properties for weight, height, hasfur)
     * also genrates a constructor that sets those properties, also implements value based equality(Equalt, GetHashcode),
     * provides Tostring() override and supprots with experssion 
     */
    public record Cat(double Weight, double Height, bool HasFur) : IAnimal;
    public record Dog(double Weight, double Height) : IAnimal
    {
        public bool HasFur => true;
    }

    public record Fish(double Weight, double Height) : IAnimal
    {
        public bool HasFur => false;
    }

    // ─────────────────────────── 🧭 SECTION: <3> normal classe with gernic methods───────────────────────────
    //and here if we made the class gernic so we dont need to make the methods
    //ass genrics it will be gernics automatically
    //-The class declares<T> at the top.
    //- All methods inside the class can use T directly—no need to redeclare <T> in the method.

    public class ClassWithGernicMethod
    {
        public void GenricMehtod<T>(T value)
        {
            Console.WriteLine(
                $"the type of the value is {value?.GetType().Name}" +
                $" the value is {value}");
        }

        public T GenricFunction<T>(T value)
        {
            Console.WriteLine(
                $"the type of the value is {value?.GetType().Name}" +
                $" and the value of it is {value}");
            return value;
        }
    }






    // ─────────────────────────── 🧭 SECTION: <2> genirc classes ───────────────────────────

    //we could also make an implemnation that specfies the type so youcan specify only the interface
    //so no need from adding type to the class
    public class ImplementationwihtoutIntegerType : IGericIneterface<int>
    {

    }


    // ─────────────────────────── 🧭 SECTION: <1> genric interfaces and classes───────────────────────────
    //we can use genrics to define an interface with atype parameter<T>
    public interface IGericIneterface<T>
    {
        //not methods just creating empy interface
    }

    //we can make class that implemnt this interface
    public class GenricClass<T> : IGericIneterface<T>
    {
        /*
         * so the class itesef also needs to have atype parameter on it
         * to all caller createing instances of this class to specfiy type
         */
    }
}

