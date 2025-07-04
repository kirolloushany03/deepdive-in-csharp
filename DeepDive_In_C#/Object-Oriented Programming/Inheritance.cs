using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepDive_In_C_
{
    internal class Inheritance
    {
        public static void Run_inheritcance()
        {
            // 👋 Welcome again to OOP in C#
            // 🛑 C# does NOT allow multiple inheritance — each class can inherit from only ONE base class

            // Creating various vehicle objects
            BMW car1 = new();
            Console.WriteLine(car1.DoorCount);

            Car BMWcar = new Car() { DoorCount = 4 };
            Car coupe = new() { DoorCount = 2 };
            Truck PickupTruck = new() { DoorCount = 2 };
            Bike bike = new Bike();

            // Calling method from base class (Vehicle)
            BMWcar.OpenDoors();
            coupe.OpenDoors();
            PickupTruck.OpenDoors();
            bike.OpenDoors();
        }

        // 🧱 Base class for all vehicles
        public class Vehicle
        {
            public int DoorCount { get; init; }

            // 🔍 GetType() returns the exact runtime type of the object
            // ✅ Helpful in debugging to know the actual class being used
            public void OpenDoors()
            {
                Console.WriteLine(
                    $"{GetType().Name} opening {DoorCount} doors!");
            }
        }

        // 🧩 Automobile is a subclass of Vehicle
        public class Automobile : Vehicle
        {}

        // 🚗 Car inherits from Automobile
        public class Car : Automobile
        {}

        // 🚘 BMW is a specific kind of Car
        public class BMW : Car
        {
            public BMW()
            {
                DoorCount = 4;
            }
        }

        // 🚛 Truck and 🚐 Van also inherit from Automobile
        public class Truck : Automobile
        {}

        public class Van : Automobile
        {}

        // 🏍️ Bike is a Vehicle but not an Automobile
        public class Bike : Vehicle
        {
            public Bike()
            {
                DoorCount = 0;
            }
        }

        // ✈️ Plane is another type of Vehicle
        public class Plane : Vehicle
        {}
    }
}
