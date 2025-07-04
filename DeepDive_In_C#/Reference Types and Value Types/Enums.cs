using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepDive_In_C_
{
    class Enums
    {
        public static void run_enums()
        {
            Console.OutputEncoding = Encoding.UTF8;
            /// 🧠 Enums are value types
            /// ✅ The better to use enums in situations where you will NOT change the values
            /// ❓ Can we change enums? --> ❌ No

            /*
            🧮 Enums are numeric types --> we can cast them as integers
            🛑 But we CANNOT cast enums as strings directly
            */

            // Casting an enum to int
            int monday = (int)DaysOfWeek.monday;

            /// ❌ We cannot cast it directly to a string
            // string monday = (string)DaysOfWeek.monday; // ❌ Cannot convert DaysOfWeek to string

            /// 🤯 Confusing Part: When we write enums to the console, they look like strings!
            Console.WriteLine($"enum value directly: {DaysOfWeek.monday}");
            Console.WriteLine($"enum value casted to int: {(int)DaysOfWeek.monday}");

            /// 🔁 From << enum to string >> ➡️ Use ToString()
            string mondaystring = DaysOfWeek.monday.ToString();
            Console.WriteLine($"this the string representation of it --> {mondaystring} --type--> {mondaystring.GetType()}");

            /// 🔄 From << string to enum >> ➡️ Use Enum.Parse
            Console.WriteLine(DaysOfWeek.Friday.GetType());

            DaysOfWeek Fridayenum = (DaysOfWeek)Enum.Parse(typeof(DaysOfWeek), "Friday");

            // Another version using generics
            DaysOfWeek fridayenum2 = Enum.Parse<DaysOfWeek>("Friday");

            Console.WriteLine($"fridayenum = {Fridayenum} type {Fridayenum.GetType()} and this fridayenum2 = {fridayenum2} type {fridayenum2.GetType()}");

            /// ✅ TryParse for validation
            DaysOfWeek mondayenum3;
            bool parssuccesed = Enum.TryParse("monday", out mondayenum3);
            Console.WriteLine($"Enum {(parssuccesed ? "was parsed" : "was not parsed")}: {mondayenum3}");

            /// ❗ Even if parsing fails, it still prints a value.
            /// Because the default numeric value of an enum is 0, which corresponds to Sunday!
            bool parssuccesed2 = Enum.TryParse("kiro", out mondayenum3);
            Console.WriteLine($"Enum {(parssuccesed2 ? "was parsed" : "was not parsed")}: {mondayenum3}");

            /// 🔁 If we change to DaysofWeek2 with values from 1-7,
            /// And we parse a wrong value, it still returns 0 (no match)
            DaysofWeek2 mondayenum4;
            bool parssuccesed4 = Enum.TryParse("kiro", out mondayenum4);
            Console.WriteLine($"Enum for mondayenum4 {(parssuccesed4 ? "was parsed" : "was not parsed")}: {mondayenum4}");

            /// 📜 Enum.GetValues ➕ Enum.GetNames
            Console.WriteLine("\n🔁 All Enum Values with casting:");
            foreach (DaysOfWeek day in Enum.GetValues(typeof(DaysOfWeek)))
            {
                Console.WriteLine($"Enum value: {(int)day} and type: {day.GetType()}");
            }

            Console.WriteLine("\n🔁 All Enum Values without casting:");
            foreach (DaysOfWeek day in Enum.GetValues(typeof(DaysOfWeek)))
            {
                Console.WriteLine($"Enum value: {day} and type: {day.GetType()}");
            }

            Console.WriteLine("\n📃 All Enum Names:");
            foreach (string day in Enum.GetNames(typeof(DaysOfWeek)))
            {
                Console.WriteLine($"Enum Name: {day} and type: {day.GetType()}");
            }

            /// 🤯 Weird behavior: we can technically cast an int to an enum,
            /// Even if the int doesn't correspond to a valid enum value!
            DaysOfWeek invalidday = (DaysOfWeek)8;
            Console.WriteLine($"Invalid Enum Value: {invalidday} type of it {invalidday.GetType()}");

            /// 🧩 Flags usage
            permissions readwrite = permissions.read | permissions.write;
            Console.WriteLine($"RW: {readwrite}");

            /// ✅ Check if a flag is set using bitwise operations
            bool canRead = (readwrite & permissions.read) == permissions.read;
            bool canWrite = (readwrite & permissions.write) == permissions.write;
            bool canExcute = (readwrite & permissions.Excute) == permissions.Excute;

            Console.WriteLine($"canRead : {canRead}");
            Console.WriteLine($"canWrite : {canWrite}");
            Console.WriteLine($"canExcute : {canExcute}");
        }
            
            enum DaysOfWeek
            {
                sunday,
                monday,
                tuesday,
                wednesday,
                thursday,
                Friday,
                saturday
            }

            /// 🧾 Alternative enum definition with numeric values
            enum DaysofWeek2
            {
                sunday = 1,
                monday = 2,
                tuesday = 3,
                wednesday = 4,
                thursday = 5,
                Friday = 6,
                saturday = 7
            }

            /*
            📌 Enums can also be used as "flags" using bitwise operators.
            📐 Why do we assign values like 0, 1, 2, 4 (powers of 2)?

            Because if we assign 0, 1, 2, 3:
            ➡️ read (1) + write (2) = 3
            ➡️ But 3 already exists as Excute → conflict!

            ✅ Using powers of 2 removes ambiguity and gives us freedom to combine values.
            */
            [Flags]
            enum permissions
            {
                None = 0,
                read = 1,
                write = 2,
                Excute = 4
            }
    }
}

