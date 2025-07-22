
namespace DeepDive_In_C_.Object_Oriented_Programming
{
    internal class HeadToHead_Composition
    {
        public static void RunExmples()
        {
            //Composition Approach
            // The Goal: Same as before, build different types of cars.
            // The Method: Using Composition. A vehicle IS NOT an engine, it HAS AN engine.
            // It's like building with Lego blocks! 🧩
            ComposedVehicle composedSedan = new(
            new ConfigurableEngine(1.8f), // We give it a 1.8L engine part
            new Dictionary<DoorPosition, IDoor> // And we give it four swinging door parts
            {
            { DoorPosition.FrontDriverSide, new StandardSwingingDoor()},
            { DoorPosition.FrontPassengerSide, new StandardSwingingDoor()},
            { DoorPosition.RearDriverSide, new StandardSwingingDoor()},
            { DoorPosition.RearPassengerSide, new StandardSwingingDoor()}
            });

            composedSedan.StartEngine();
            composedSedan.OpenDoor(DoorPosition.FrontDriverSide);
        }
        // This is just a helper to know which door we are talking about.
        //public enum DoorPosition
        //{
        //    FrontDriverSide,
        //    RearDriverSide,
        //    FrontPassengerSide,
        //    RearPassengerSide
        //};

        // ⚙️ The contractn for what an engine must be able to do.
        // Any class that wants to be an "Engine" must have a Start() method.
        public interface IEngine
        {
            void Start();
        }

        // 🚪 The contract for what a door must be able to do.
        // Any class that wants to be a "Door" must have an Open() method.
        public interface IDoor
        {
            void Open();
        }

        // A specific TYPE of engine that follows the IEngine contract.
        public class V8Engine : IEngine
        {
            public void Start()
            {
                Console.WriteLine("Big ol' V8 engine starting! Vroom vroom! 🏎️");
            }
        }

        // ANOTHER specific type of engine. It's configurable!
        // We can tell it its size when we create it.
        public class ConfigurableEngine : IEngine
        {
            private readonly float _displacementInLiters;
            public ConfigurableEngine(float displacementInLiters)
            {
                _displacementInLiters = displacementInLiters;
            }

            public void Start()
            {
                Console.WriteLine($"Starting {_displacementInLiters}L engine.");
            }
        }

        // A specific TYPE of door. This one swings.
        public class StandardSwingingDoor : IDoor
        {
            public void Open()
            {
                Console.WriteLine("Swinging open door! *creak*");
            }
        }

        // ANOTHER specific type of door. This one slides, like in a van.
        public class SlidingDoor : IDoor
        {
            public void Open()
            {
                Console.WriteLine("Sliding opening door! *swoosh*");
            }
        }

        // ✨ This is the MAGIC CLASS! ✨
        // This one class can be ANY vehicle we want, just by changing the parts we give it.
        public sealed class ComposedVehicle
        {
            // The "slots" for our parts. The vehicle HAS an engine and HAS a collection of doors.
            private readonly IEngine _engine;
            private readonly IReadOnlyDictionary<DoorPosition, IDoor> _doors;

            // The "assembly line"  When we create a vehicle, we MUST give it its parts.
            public ComposedVehicle(IEngine engine, Dictionary<DoorPosition, IDoor> doors)
            {
                _engine = engine;
                _doors = doors;
            }

            // The vehicle doesn't start itself, it tells its engine to start.
            public void StartEngine()
            {
                _engine.Start();
            }

            // The vehicle finds the correct door and tells THAT door to open.
            public void OpenDoor(DoorPosition doorPosition) // Keeping the name consistent with the other file
            {
                if (!_doors.TryGetValue(doorPosition, out IDoor? door))
                {
                    // This is smart! We check if the door exists before trying to use it.
                    // No need for specific logic like in the Coupe/PickupTruck classes.
                    throw new InvalidOperationException(
                        $"There is no door at position {doorPosition}!");
                }
                Console.WriteLine($"Opening {doorPosition} door...");
                door.Open();
            }
        }
    }
    

}
