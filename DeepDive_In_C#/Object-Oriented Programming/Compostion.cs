using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepDive_In_C_.Object_Oriented_Programming
{
    internal class Compostion
    {
        public static void Run_Compsotion()
        {
            //=================================================================
            // 🧱 Composition Example: Building a Computer from its Components

            Computer computer = new(
                new Case(),
                new Motherboard(),
                new PowerSupply(),
                new HardDrive(sizeInTb: 16),
                new Ram(ramInGB: 64),
                new GraphicsCard());

            computer.Poweron();

        }
        // 🚫 `sealed` prevents inheritance: this class cannot be inherited
        public sealed class Case
        {
            public void PressPowerButton()
            {
                Console.WriteLine("Power button pressed");
            }
        }

        public sealed class Motherboard
        {
            public void Boot()
            {
                Console.WriteLine("Booting...");
            }
        }

        public sealed class PowerSupply
        {
            public void TurnOn()
            {
                Console.WriteLine("Power supply turned on");
            }
        }

        public sealed class HardDrive
        {
            private readonly int _sizeInTb;

            public HardDrive(int sizeInTb)
            {
                _sizeInTb = sizeInTb;
            }

            public void ReadData()
            {
                Console.WriteLine($"Reading data from the hard drive with size of {_sizeInTb} TB");
            }
        }

        public sealed class Ram
        {
            private readonly int _RamInGB;

            public Ram(int ramInGB)
            {
                _RamInGB = ramInGB;
            }

            public void Load()
            {
                Console.WriteLine($"Loading data into ram with capacity of {_RamInGB} GB");
            }
        }

        public sealed class GraphicsCard
        {
            public void Render()
            {
                Console.WriteLine("GPU Rendering");
            }
        }

        // 🧰 Original version using a class with traditional composition
        /*
        public sealed class Computer
        {
            private readonly Case _case;
            private readonly Motherboard _motherboard;
            private readonly PowerSupply _powerSupply;
            private readonly HardDrive _hardDrive;
            private readonly Ram _ram;
            private readonly GraphicsCard _graphicsCard;

            public Computer(Case thecase, Motherboard motherboard, PowerSupply powersupply,
                HardDrive harddrive, Ram ram, GraphicsCard graphicsCard)
            {
                _case = thecase;
                _motherboard = motherboard;
                _powerSupply = powersupply;
                _hardDrive = harddrive;
                _ram = ram;
                _graphicsCard = graphicsCard;
            }

            public void Poweron()
            {
                _case.PressPowerButton();
                _powerSupply.TurnOn();
                _motherboard.Boot();
                _ram.Load();
                _hardDrive.ReadData();
                _graphicsCard.Render();
            }
        }
        */

        // 🧾 If using a `record`, composition still works but is more concise
        public sealed record Computer
        (
            Case Thecase,
            Motherboard Motherboard,
            PowerSupply Powersupply,
            HardDrive Harddrive,
            Ram Ram,
            GraphicsCard GraphicsCard
        )
        {
            public void Poweron()
            {
                Thecase.PressPowerButton();
                Powersupply.TurnOn();
                Motherboard.Boot();
                Ram.Load();
                Harddrive.ReadData();
                GraphicsCard.Render();
            }
        };

    }
}
