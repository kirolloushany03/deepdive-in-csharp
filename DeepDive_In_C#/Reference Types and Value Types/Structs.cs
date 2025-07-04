using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepDive_In_C_
{
    internal class Structs
    {
        // 🌟 Begin: Working with Structs in C#
        // ✅ Structs are value types!

        /*
         * 🧱 Structs vs Classes in C# 🤔
         * 
         * 📦 Structs look like classes ➕ they can have constructors too!
         * 
         * 🛠️ Constructor Differences:
         * ----------------------------
         * 🏛️ Class:
         * - If you define a constructor with parameters ➡️
         *   the default parameterless constructor is removed ❌.
         * 
         * 🧱 Struct:
         * - Even if you define a constructor with parameters ➡️
         *   the default parameterless constructor **still exists** ✅.
         * 
         * ⚡ Performance Differences:
         * ---------------------------
         * 🧠 Structs are stored in the **stack** 📦
         * 🧠 Classes are stored in the **heap** 🗃️
         * 
         * 🏎️ Stack is faster because:
         * - No Garbage Collector needed ♻️❌
         * - Direct, fast memory access 🚀
         * 
         * 🪶 Use Structs when:
         * - The data is small 🧬
         * - You need fast access and don’t want GC overhead ⏱️
         */

        // 📌 Example: Struct Definition 🧱
        /*
         */

        // 🧠 Passing Data: Struct vs Class
        // --------------------------------
        /*
         * 📤 When passing a class ➡️ you pass the **reference** 🔗
         * - So changes affect the original object 🧨
         *
         * 📤 When passing a struct ➡️ you pass a **copy** 📄
         * - So changes don't affect the original 🧊
         */

        // 📍 Example: Struct copy behavior when passed to a method 👇
        public static void RunStructs_Exersices()
        {
            Console.OutputEncoding = Encoding.UTF8; //adding emojies
            void DoSomethingWithPoint(Point p)
            {
                p.X = 111;
                p.Y = 123;
            }

            var ourpoint = new Point()
            {
                X = 124,
                Y = 145
            };

            Console.WriteLine(ourpoint.GetType()); // 🧾 Prints the type: Point

            Console.WriteLine($"📍 ourpoint BEFORE DoSomethingWithPoint: " +
                $"{ourpoint.X}, {ourpoint.Y}");

            DoSomethingWithPoint(ourpoint);

            Console.WriteLine($"📍 ourpoint AFTER DoSomethingWithPoint: " +
                $"{ourpoint.X}, {ourpoint.Y}");

            /*
             * ✅ Output is unchanged after method call!
             * 🔁 This is because the struct is a **value type** ➡️ it passed a copy 🧊 not the original.
             */

            void DoSomethingWithPointWithProperties(PointWithProperties p)
            {
                p.X = 111;
                p.Y = 123;
            }

            var ourpointWithProb = new PointWithProperties()
            {
                X = 124,
                Y = 145
            };

            Console.WriteLine(ourpointWithProb.GetType()); // 🧾 Prints the type: PointWithProperties

            Console.WriteLine($"📍 ourpointWithProb BEFORE DoSomethingWithPointWithProperties: " +
                $"{ourpointWithProb.X}, {ourpointWithProb.Y}");

            DoSomethingWithPointWithProperties(ourpointWithProb);

            Console.WriteLine($"📍 ourpointWithProb AFTER DoSomethingWithPointWithProperties: " +
                $"{ourpointWithProb.X} ,  {ourpointWithProb.Y}");


            // 🧪 Testing constructor behavior 🏗️
            // ----------------------------------
            var PointWithTwoConstructor = new PointWithConstructor(3, 4);

            Console.WriteLine($"📌 X from PointWithConstructor: {PointWithTwoConstructor.X}" +
                $" | Y from PointWithConstructor: {PointWithTwoConstructor.Y}");

            /*
             * ⚖️ Class vs Struct – When to Use?
             * ---------------------------------
             * 🔹 Use a **struct** when:
             *   - You have a small, simple object 📏
             *   - You want to pass it by **value** 📤
             *   - You want to avoid heap allocation + GC ♻️
             *
             * 💭 Think of primitive or geometric things like:
             *   🟣 Point, 🟥 Color, 🟩 Rectangle...
             *   These are perfect use-cases for structs!
             */
        }

        // 🧱 Struct Definitions Below ⬇️

        public struct Point
        {
            public int X;
            public int Y;
        }

        // 🧱 Struct with Properties 🛠️
        public struct PointWithProperties
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        // 🧱 Struct with Constructors 🚧
        public struct PointWithConstructor
        {
            public PointWithConstructor()
            {
                Console.WriteLine("👋 Hello from the default constructor 🏗️");
            }
            public PointWithConstructor(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int X { get; set; }
            public int Y { get; set; }
        }

        // 🧱 Struct with Method 📍
        public struct PointWithMethod
        {
            public int X;
            public int Y;

            public void Move(int x, int y)
            {
                X += x;
                Y += y;
            }
        }
    }
}
