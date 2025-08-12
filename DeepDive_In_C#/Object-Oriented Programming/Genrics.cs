namespace DeepDive_In_C_.Object_Oriented_Programming;

internal class Genrics
{
    public static void RunExamples()
    {
        //// 📌 GENERICS
        //// 🔹 Generics don't care about the type (or care only in a limited way)
        //// 🔹 We can use Generics in classes, interfaces, methods, etc...

        /* 📝 PART 1: Generic Classes */
        GenricClass<int> myNumericInstance = new GenricClass<int>();
        GenricClass<string> myStringInstance = new GenricClass<string>();

        // ❌ This won't work without specifying a type
        // GenricClass instanceWithoutType = new GenricClass(); 

        // ✅ No need to specify type here (type is fixed in implementation)
        ImplemntationWithIntgerType instanceOfImplementationWithIntegerType = new();

        // ----------------------------------------------------------

        /* 📝 PART 2: Generic Methods */
        ClassWithGenericMethod instanceClassGenericMethod = new();
        instanceClassGenericMethod.GenricMethod("this is a string");
        instanceClassGenericMethod.GenricMethod(42);
        instanceClassGenericMethod.GenricFunction(3.14);

        // 🧪 Testing return type matches input type
        int genericFunctionResult1 = instanceClassGenericMethod.GenricFunction(42);
        string genericFunctionResult2 = instanceClassGenericMethod.GenricFunction("this is a string");
        double genericFunctionResult3 = instanceClassGenericMethod.GenricFunction(3.14);

        // ----------------------------------------------------------

        /// <summary>
        /// 📝 PART 3: We've been using Generics already in built-in types (like List, Dictionary)
        /// </summary>
        List<int> numericList = new List<int>();
        List<string> stringList = new List<string>();

        /*
        📌 Common usage in C#:
        - I don’t care what type you are, as long as you meet certain conditions  
          (e.g., have a parameterless constructor, or be a reference type).
        - We can use constraints to limit which types can be used with a generic.
        */

        // ----------------------------------------------------------
        // 🐾 Example: Working with animals
        Dog frank = new(Weight: 50, height: 24);
        Dog spot = new(Weight: 35, height: 18);

        Cat whiskers = new(Weight: 10, height: 12, HasFur: true);
        Cat pharoah = new(Weight: 12, height: 14, HasFur: false);

        Fish goldie = new(Weight: 0.5, height: 2);

        var animals = new IAnimal[] { frank, spot, whiskers, pharoah, goldie };

        // 🧮 Calculations
        var totalWeight = CalculateWeight(animals);
        var totalHeight = CalculateHeight(animals);
        var onlyFur = OnlyWithFur(animals);

        Console.WriteLine($"Total Weight: {totalWeight} | " +
                          $"Total height: {totalHeight} | " +
                          $"Only with fur: {onlyFur}");

        // ----------------------------------------------------------
        // 📌 Generic method with constraint
        double CalculateWeight<T>(IEnumerable<T> animals)
            where T : IAnimal // Only types that implement IAnimal are allowed
        {
            return animals.Sum(a => a.Weight);
        }

        double CalculateHeight<T>(IEnumerable<T> animals)
            where T : IAnimal
        {
            return animals.Sum(a => a.height);
        }

        IEnumerable<IAnimal> OnlyWithFur(IEnumerable<IAnimal> animals)
        {
            return animals.Where(a => a.HasFur);
        }

    }

    // ------------ 🐾 Interface & Classes (used above) 👆👆 ------------
    public interface IAnimal
    {
        double Weight { get; }
        double height { get; }
        bool HasFur { get; }
    }

    // 🐱 Cat record
    public record Cat(
        double Weight,
        double height,
        bool HasFur) : IAnimal;

    // 🐶 Dog record (always has fur)
    public record Dog(double Weight, double height) : IAnimal
    {
        public bool HasFur => true;
    }

    // 🐟 Fish record (never has fur)
    public record Fish(
        double Weight,
        double height) : IAnimal
    {
        public bool HasFur => false;
    }

    // ----------------------------------------------------------

    /* 📝 PART 2: Generic Methods */
    public class ClassWithGenericMethod
    {
        // 📌 Generic Method - accepts any type
        public void GenricMethod<T>(T value)
        {
            Console.WriteLine(
                $"The type of the value is {value?.GetType().Name}" +
                $" and the value is --> {value}");
        }

        // 📌 Generic Function - returns the same type as input
        public T GenricFunction<T>(T value)
        {
            Console.WriteLine(
                $"The type of the value is --> {value?.GetType().Name}");
            return value;
        }
    }

    // ----------------------------------------------------------

    /* 📝 PART 1: Generic Classes & Interfaces */
    // 📌 We can specify the type directly in implementation (no longer generic here)
    public class ImplemntationWithIntgerType : IGenericIneterace<int>
    {
    }

    // 📌 Generic Interface
    public interface IGenericIneterace<T>
    {
        // No members
    }

    // 📌 Generic Class (type specified when creating an instance)
    public class GenricClass<T> : IGenericIneterace<T>
    {
        // Class itself also needs the type parameter
    }
}
