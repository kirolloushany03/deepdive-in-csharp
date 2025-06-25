using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepDive_In_C_
{
    internal class ProblemWithEquality
    {
        public static void Run()
        {
            // ==========================
            // Equality Problem in C#
            // ==========================
            //
            // 🤔 Problem:
            // When using both structs (value types) and classes (ref types),
            // you might get confused by how equality works differently.
            //
            // ✅ Solution:
            // Make class equality behave like struct equality by:
            //
            // 1️⃣ Override `Equals()` → Compare values, not references.
            // 2️⃣ Override `GetHashCode()` → Needed for hash-based collections.
            // 3️⃣ Overload `==` and `!=` → So they use your `Equals()` logic.
            //
            // 🔸 You don’t always need to do this, but it helps avoid bugs.
            // ⚠️ Overriding Equals, GetHashCode, and operators manually is powerful but super error-prone.
            // A tiny mistake can lead to unexpected behavior in collections or comparisons.



            // 🔍 Default class equality
            var myclass1 = new Myclass { NumericValue = 123, StringValue = "ABC" };
            var myclass2 = new Myclass { NumericValue = 123, StringValue = "ABC" };

            Console.WriteLine("myclass1 == myclass2?");
            Console.WriteLine(myclass1 == myclass2);               // False (ref check)
            Console.WriteLine(myclass1.Equals(myclass2));           // False
            Console.WriteLine(object.Equals(myclass1, myclass2));   // False


            // 🔍 Default struct equality
            var mystruct1 = new Mystruct { NumericValue = 123, StringValue = "soso" };
            var mystruct2 = new Mystruct { NumericValue = 123, StringValue = "soso" };

            Console.WriteLine("mystruct1 == mystruct2?");
            // Console.WriteLine(mystruct1 == mystruct2); // ⚠️ Not allowed unless operator overloaded
            Console.WriteLine(mystruct1.Equals(mystruct2));         // True
            Console.WriteLine(object.Equals(mystruct1, mystruct2)); // True


            // ✅ After overriding Equals (classes behave like structs)
            var myClassWithEquality1 = new MyclassWithEquality { NumericValue = 123, StringValue = "koko" };
            var myClassWithEquality2 = new MyclassWithEquality { NumericValue = 123, StringValue = "koko" };

            Console.WriteLine("myClassWithEquality1 == myClassWithEquality2?");
            Console.WriteLine(myClassWithEquality1 == myClassWithEquality2);             // False (no operator overloaded)
            Console.WriteLine(myClassWithEquality1.Equals(myClassWithEquality2));        // True
            Console.WriteLine(object.Equals(myClassWithEquality1, myClassWithEquality2));// True


            // ✅ After overriding Equals + operator ==/!=
            var myClassWithEqualityAntOperator1 = new MyclassWithEqualityAndOperator { NumericValue = 123, StringValue = "fofo" };
            var myClassWithEqualityAntOperator2 = new MyclassWithEqualityAndOperator { NumericValue = 123, StringValue = "fofo" };

            Console.WriteLine("myClassWithEqualityAntOperator1 == myClassWithEqualityAntOperator2?");
            Console.WriteLine(myClassWithEqualityAntOperator1 == myClassWithEqualityAntOperator2);             // True
            Console.WriteLine(myClassWithEqualityAntOperator1.Equals(myClassWithEqualityAntOperator2));        // True
            Console.WriteLine(object.Equals(myClassWithEqualityAntOperator1, myClassWithEqualityAntOperator2));// True

        }

        // ==========================
        // Class With Equals + Operator
        // ==========================
        public class MyclassWithEqualityAndOperator
        {
            public int NumericValue { get; set; }
            public string StringValue { get; set; }

            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType()) return false;
                var other = (MyclassWithEqualityAndOperator)obj;
                return NumericValue == other.NumericValue && StringValue == other.StringValue;
            }

            public override int GetHashCode()
            {
                return NumericValue.GetHashCode() ^ StringValue.GetHashCode();
            }

            public static bool operator ==(MyclassWithEqualityAndOperator left, MyclassWithEqualityAndOperator right)
            {
                return left.Equals(right);
            }

            public static bool operator !=(MyclassWithEqualityAndOperator left, MyclassWithEqualityAndOperator right)
            {
                return !left.Equals(right);
            }
        }


        // ==========================
        // Class With Only Equals()
        // ==========================
        public class MyclassWithEquality
        {
            public string StringValue { get; set; }
            public int NumericValue { get; set; }

            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType()) return false;
                var other = (MyclassWithEquality)obj;
                return NumericValue == other.NumericValue && StringValue == other.StringValue;
            }

            public override int GetHashCode()
            {
                return NumericValue.GetHashCode() ^ StringValue.GetHashCode();
            }
        }


        // ==========================
        // Simple Class (No Overrides)
        // ==========================
        public class Myclass
        {
            public int NumericValue { get; set; }
            public string StringValue { get; set; }
        }


        // ==========================
        // Simple Struct
        // ==========================
        public struct Mystruct
        {
            public int NumericValue { get; set; }
            public string StringValue { get; set; }
        }
    }
}
