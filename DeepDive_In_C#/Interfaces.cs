using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepDive_In_C_
{
    internal class Interfaces
    {
        // ======================= 🔌 INTERFACES =======================

        // 🔐 Contract for any motorized object (e.g., Car, Motorcycle)
        public interface IMotorized
        {
            bool IsEngineRunning { get; }
            void StartEngine();
            void StopEngine();
        }

        // 🚪 Contract for any object that has doors (e.g., Car, Room)
        public interface IHasDoors
        {
            int NumberOfDoors { get; }
            void OpenDoors(int doorIndex);
            void CloseDoors(int doorIndex);
            bool IsDoorOpen(int doorIndex);
        }
        public static void Run_InterfacesEXamp()
        {
            // 🎯 OBJECTIVE: Understand C# Interfaces in OOP
            // An interface is a *contract* that defines what methods/properties a class should implement.
            // It **doesn't contain the implementation itself**, just the definition.
            // ✅ Interfaces allow multiple classes to share common behavior while keeping implementations separate.


            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // 🔧 Creating a motorcycle and testing its engine functionality
            Motorcycle motorcycle = new();
            motorcycle.StartEngine();
            Console.WriteLine(motorcycle.IsEngineRunning); // ✅ true

            // 🛡️ Trying to hack the engine status from outside will fail because the setter is private
            // motorcycle.IsEngineRunning = false; ❌ Compiler Error: 'set' accessor is inaccessible

            motorcycle.StopEngine();
            Console.WriteLine(motorcycle.IsEngineRunning); // ✅ false

            // 🔄 Casting between class ↔️ interface
            IMotorized motorized = motorcycle; // Implicit cast: This happens under the hood in Dependency Injection (DI)
            Motorcycle motocycle2 = (Motorcycle)motorized; // Explicit cast: Not typical in real-world DI

            // 🏠 Room that implements IHasDoors interface
            IHasDoors doors = new Room(3);
            doors.OpenDoors(1);
            doors.CloseDoors(2);
            doors.IsDoorOpen(0);

            // 🚘 Now testing Car which implements both IHasDoors and IMotorized
            Console.WriteLine("======================car =====================");
            Car coupe = new(2);
            Car sedan = new(4);

            void TestIgnition(IMotorized motorized)
            {
                motorized.StartEngine();
                Console.WriteLine($"Engine is running: {motorized.IsEngineRunning}");
                motorized.StopEngine();
                Console.WriteLine($"Engine is running: {motorized.IsEngineRunning}");
            }

            void TestDoors(IHasDoors hasDoors)
            {
                for (int i = 0; i < hasDoors.NumberOfDoors; i++)
                {
                    hasDoors.OpenDoors(i);
                    Console.WriteLine($"Door {i} is open: {hasDoors.IsDoorOpen(i)}");
                }
            }

            TestIgnition(coupe);
            TestIgnition(sedan);

            TestDoors(coupe);
            TestDoors(sedan);

            /* 🧠 Why Use Interfaces?
             * ----------------------
             * ✅ Interfaces allow multiple classes to share common behavior without inheritance.
             * ✅ You can inherit from **multiple interfaces**, unlike classes (single inheritance).
             * ✅ Interfaces help with abstraction, testability, and loose coupling (especially in DI).
             * ✅ The code depends on interfaces, not concrete classes — this allows flexibility.
             */

        }
        // ========================= 🚗 CAR CLASS =========================
        public class Car : IHasDoors, IMotorized
        {
            public readonly bool[] _doors;

            public Car(int numberOfDoors)
            {
                _doors = new bool[numberOfDoors];
            }

            public int NumberOfDoors => _doors.Length;
            public bool IsEngineRunning { get; private set; }

            public void OpenDoors(int doorIndex)
            {
                _doors[doorIndex] = true;
                Console.WriteLine($"Door {doorIndex} is open ✅");
                Console.WriteLine($"     Status: {string.Join(",", _doors)}");
                Console.WriteLine(GetType());
            }

            public void CloseDoors(int doorIndex)
            {
                _doors[doorIndex] = false;
                Console.WriteLine($"Door {doorIndex} is closed ❌");
                Console.WriteLine($"     Status: {string.Join(",", _doors)}");
            }

            public bool IsDoorOpen(int doorIndex)
            {
                string state = _doors[doorIndex] ? "open ✅" : "closed ❌";
                Console.WriteLine($"Door {doorIndex} is {state}");
                Console.WriteLine($"     Status: {string.Join(",", _doors)}");
                return _doors[doorIndex];
            }

            public void StartEngine()
            {
                if (IsEngineRunning) return;
                IsEngineRunning = true;
                Console.WriteLine("Engine started 🏎️");
            }

            public void StopEngine()
            {
                if (!IsEngineRunning) return;
                IsEngineRunning = false;
                Console.WriteLine("Engine stopped 🛑");
            }
        }

        // ========================= 🏠 ROOM CLASS =========================
        public class Room : IHasDoors
        {
            public readonly bool[] _doors;

            public Room(int numberOfDoors)
            {
                _doors = new bool[numberOfDoors];
            }

            public int NumberOfDoors => _doors.Length;

            public void OpenDoors(int doorIndex)
            {
                _doors[doorIndex] = true;
                Console.WriteLine($"Door {doorIndex} is open ✅");
                Console.WriteLine($"     Status: {string.Join(",", _doors)}");
                Console.WriteLine(GetType());
            }

            public void CloseDoors(int doorIndex)
            {
                _doors[doorIndex] = false;
                Console.WriteLine($"Door {doorIndex} is closed ❌");
                Console.WriteLine($"     Status: {string.Join(",", _doors)}");
            }

            public bool IsDoorOpen(int doorIndex)
            {
                string state = _doors[doorIndex] ? "open ✅" : "closed ❌";
                Console.WriteLine($"Door {doorIndex} is {state}");
                Console.WriteLine($"     Status: {string.Join(",", _doors)}");
                return _doors[doorIndex];
            }
        }

        // ======================= 🏍️ MOTORCYCLE CLASS =======================
        public class Motorcycle : IMotorized
        {
            public bool IsEngineRunning { get; private set; }

            public void StartEngine()
            {
                if (IsEngineRunning) return;
                IsEngineRunning = true;
                Console.WriteLine("Engine started 🏍️");
            }

            public void StopEngine()
            {
                if (!IsEngineRunning) return;
                IsEngineRunning = false;
                Console.WriteLine("Engine stopped 🛑");
            }
        }
    }
}
