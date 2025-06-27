using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepDive_In_C_
{
    internal class Records
    {
        public static void RunRecords()
        {

            // ✅ This example explores how records behave with value and reference types in C#

            // 1️⃣ Init-only properties using record with object initializer
            MyRecord myrecord1 = new(123, "ABC");

            MyRecord2 myrecord2 = new()
            {
                NumbericValue = 123,
                stringvalue = "ABC"
            };

            Console.WriteLine(myrecord2);

            // ❌ Attempting to modify init-only properties (won’t compile)
            // myrecord2.stringvalue = "kkk";
            // myrecord2.NumbericValue = 1456;

            // 2️⃣ Equality comparison between two records with the same data
            MyRecord recordA = new(123, "ABC");
            MyRecord recordB = new(123, "ABC");

            Console.WriteLine("➡️ Is recordA equal to recordB?");
            Console.WriteLine(recordA == recordB);                   // ✅ true
            Console.WriteLine(recordA.Equals(recordB));              // ✅ true
            Console.WriteLine(object.Equals(recordA, recordB));      // ✅ true

            // 3️⃣ Using "with" expression to clone and update record values
            // we can use the "with "keyword to create new record
            // with the same values as the original , but with some changes
            MyRecord recordC = recordA with { NumericValue = 1258 };

            Console.WriteLine(recordA);
            Console.WriteLine(recordB);
            Console.WriteLine(recordC);

            // 4️⃣ Deconstruction to extract values from records
            var (recValue, recString) = recordA;

            Console.WriteLine("\n📦 Deconstructed values from recordA:");
            Console.WriteLine(recValue);     // ➡️ 123
            Console.WriteLine(recString);    // ➡️ "ABC"

            /*
             * 🧠 Why Use Deconstruction in Records?
             * 
             * 1️⃣ Cleaner access to individual properties
             *     🔸 Example:
             *         var (recValue, recString) = recordA;
             *         Console.WriteLine(recValue);
             *         Console.WriteLine(recString);
             * 
             * 2️⃣ Better integration with LINQ
             *     🔸 Example:
             *         people.Select(p => { var (n, _) = p; return n; });
             * 
             * 3️⃣ Useful for switch pattern matching
             *     🔸 Example:
             *         person switch { ("Alice", 25) => "Matched!", _ => "Default" }
             * 
             * 4️⃣ Clean controller/API logic
             *     🔸 Example:
             *         var (username, password) = loginRequest;
             * 
             * 5️⃣ Improved readability & works with immutability
             */

            // 5️⃣ Adding extra properties outside the constructor
            MyRecordWithExtraProperties newone = new(123, "kkk");

            Console.WriteLine($"\n📝 Before setting extra prop:");
            Console.WriteLine($"stringvalue: {newone.StringValue} , intvalue: {newone.NumericValue}, property: {newone.Extraproperty}");

            newone.Extraproperty = "kk is the best";

            Console.WriteLine($"\n📝 After setting extra prop:");
            Console.WriteLine($"stringvalue: {newone.StringValue} , intvalue: {newone.NumericValue}, property: {newone.Extraproperty}");
        }
        /*
 * 🧩 Mixing positional and non-positional properties:
 * You can extend records with additional properties that are not part of the constructor.
 */
        public record MyRecordWithExtraProperties(
            int NumericValue,
            string StringValue)
        {
            public string Extraproperty { get; set; }
        }

        // ❌ Invalid deconstruction: wrong order of types
        // (string recstring, int recvalue) = recordA;

        /*
         * 6️⃣ Record Structs
         * Records can also be defined as structs:
         * - Live on the 🧠 stack instead of heap 🧵
         * - Performance optimized for value types
         */
        public record struct MyRecordStruct(
            int NumericValue,
            string StringValue);

        // 📄 Positional record example
        public record MyRecord(
            int NumericValue,
            string stringvalue
        );

        // 🛡️ Init-only record with object initializer syntax
        public record MyRecord2
        {
            public int NumbericValue { get; init; }
            public string stringvalue { get; init; }
        }
    }
}
