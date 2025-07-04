using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepDive_In_C_
{
    internal class PrimerOnClasses_refence_AndValueTypes
    {
        public static void RuncExamples()
        {
            // 📌 Reference Types (like classes) vs Value Types (like primitives)
            // ✅ Value types include: int, double, bool, etc.
            // ✅ We'll see what happens when we pass each to a function.

            // 🎯 Reference Types → Share memory reference (point to the same object in memory)
            // 🎯 Value Types → Get copied when passed

            Console.WriteLine("============== Add to List by Passing the Reference ==============");

            List<string> ourList = new()
            {
                "hello",
                "kiro"
            };

            void DoSthWithReference(List<string> list)
            {
                list.Add("from");
                list.Add("kiro3");
            }

            Console.WriteLine("Before referencing:\n");
            Console.WriteLine(string.Join("\n", ourList));

            Console.WriteLine("\nAfter referencing:\n");

            DoSthWithReference(ourList);

            foreach (var item in ourList)
            {
                Console.WriteLine(item);
            }

            // 🧠 What happened here?
            // 1️⃣ We created a new List<string> with "hello" and "kiro"
            // 2️⃣ This list object is stored in the heap
            // 3️⃣ The variable `ourList` holds a reference (pointer) to the object in memory
            // 4️⃣ When we passed `ourList` to the method, the parameter `list` received the same reference
            // 5️⃣ So both `ourList` and `list` point to the exact same object in memory
            // 6️⃣ When we added items inside the method, we were modifying the same list
            // ✅ That's why the changes were visible outside the method

            Console.WriteLine("============== Try to Change a Value Type ==============");

            string ourString = "hello, kiro";

            void DoSthWithValue(string value)
            {
                value = "Kiro the best";
            }

            Console.WriteLine("\nValue before:\n");
            Console.WriteLine(ourString);

            Console.WriteLine("\nValue after:\n");
            DoSthWithValue(ourString);
            Console.WriteLine(ourString);

            // 🧠 What happened here?
            // ❌ The string did not change!
            // ✅ That's because `string` is a value type (immutable in .NET), and the method got only a copy
            // So any change to `value` inside the method did NOT affect the original `ourString`

            Console.WriteLine("============== Change Value by Passing with ref ==============");

            void DoSthWithValueByRef(ref string value)
            {
                value = "Kiro the best";
            }

            Console.WriteLine("\nValue before:\n");
            Console.WriteLine(ourString);

            Console.WriteLine("\nValue after:\n");
            DoSthWithValueByRef(ref ourString);
            Console.WriteLine(ourString);

            // 🔥 Now the value changed because we used `ref`

            // 💡 What does `ref` do?
            // ✅ It tells the compiler: "Pass this variable by reference, not by value"
            // ✅ The method receives a reference to the memory address, not just the value

            // 🚀 Benefits of `ref`:
            // - Can modify the original variable
            // - Avoids copying large structs
            // - Supports returning references from methods

        }
    }
}
