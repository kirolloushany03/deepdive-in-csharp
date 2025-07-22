namespace DeepDive_In_C_.Object_Oriented_Programming
{
    internal class HeadToHeadInheritance
    {
    //Inheritance Approach

    // The Goal: To build different types of cars.
    // The Method: Using Inheritance, where each new car type IS A kind of a parent car.
    }
    public enum DoorPosition // Let's keep this name as it was in the video
    {
        FrontDriverSide,
        FrontPassengerSide,
        RearDriverSide,
        RearPassengerSide
    }

    // The great-great-grandfather of all our vehicles 👴
    // The very top of our family tree.
    public abstract class Vehicle
    { }

    // The grandfather class 👨‍🦳
    // It INHERITS from Vehicle. It adds the idea of an "engine".
    // Still abstract, so we can't create just an "Automobile".
    public abstract class Automobile : Vehicle
    {
        // The problem starts here... we are HARD-CODING the engine type. 🤔
        private readonly string _engineType;
        protected Automobile(string engineType)
        {
            _engineType = engineType;
        }
        public void StartEngine()
        {
            StartEngine(_engineType);
        }

        // Any child MUST figure out how to open its doors.
        public abstract void OpenDoor(DoorPosition doorPosition);

        protected static void StartEngine(string engineType)
        {
            Console.WriteLine($"starting {engineType} engine!");
        }
    }

    // The parent class for all cars 👨
    // It INHERITS from Automobile.
    // It decides that ALL cars will have a 1.8L engine. This is a rigid rule! ⛓️
    public abstract class Car : Automobile
    {
        // This constructor is needed to pass the engine type up to the parent (Automobile)
        public Car() : base("1.8L") // Hard-coded value!
        {
        }

        // We are overriding the parent's abstract method.
        // NOTE: The example code in the video had this part commented out and a different implementation in derived classes.
        // I'll leave the original provided code's logic here.
    }


    // The child class. A Sedan IS A Car. ✅
    public class Sedan : Car
    {
        public override void OpenDoor(DoorPosition doorPosition)
        {
            Console.WriteLine($"sedan opening {doorPosition} door!");
        }
    }

    // Another child. A Coupe IS A Car. ✅
    public class Coupe : Car
    {
        public override void OpenDoor(DoorPosition doorPosition)
        {
            // This logic is specific to the Coupe. It knows it only has two doors.
            if (doorPosition == DoorPosition.RearDriverSide ||
                doorPosition == DoorPosition.RearPassengerSide)
            {
                throw new InvalidOperationException("Coupe only have two doors");
            }
            Console.WriteLine($"Coupe opening {doorPosition} door!");
        }
    }

    // This class does NOT inherit from Car, it inherits directly from Automobile.
    // This is done because it has a different engine size.
    public class PickupTruck : Automobile
    {
        // This constructor passes the specific engine type to the Automobile parent.
        public PickupTruck() : base("3.6L")
        {
        }

        public override void OpenDoor(DoorPosition doorPosition)
        {
            // PROBLEM: This logic is almost IDENTICAL to the Coupe. 
            // We are duplicating code! 😫
            if (doorPosition == DoorPosition.RearPassengerSide ||
                doorPosition == DoorPosition.RearDriverSide)
            {
                throw new InvalidOperationException("Truck only have two doors");
            }
            Console.WriteLine($"Truck opening {doorPosition} door!");
        }
    }
    public class Van : Automobile
    {
        public Van() : base("3.6L")
        {
        }

        public override void OpenDoor(DoorPosition doorPosition)
        {
            // Vans have special behavior for their doors.
            if (doorPosition == DoorPosition.RearPassengerSide ||
                doorPosition == DoorPosition.RearDriverSide)
            {
                Console.WriteLine($"Van sliding open {doorPosition} door!");
            }
            else
            {
                Console.WriteLine($"van swinging {doorPosition} door!");
            }
        }
    }
    // 🤔 The Main Problem with Inheritance here (مشكلة الوراثة هنا):
    /*
     * 1. It's RIGID :
     *    - To get a Pickup Truck with a different engine, we would need to create a whole NEW class. 
     *      (e.g., `SmallPickupTruck` that inherits from `Automobile`).
     *    - To get a Pickup Truck with four doors, we would need to create ANOTHER new class.
     *      (e.g., `FourDoorPickupTruck`).
     * 2. It leads to a "class explosion" :
     *    - For every small variation, we need a new class. This gets very messy very fast! 💥
     * 3. We have code duplication :
     *    - The logic for "only has two doors" is repeated in `Coupe` and `PickupTruck`.
     */
}
