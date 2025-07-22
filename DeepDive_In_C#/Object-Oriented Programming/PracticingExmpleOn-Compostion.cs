using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepDive_In_C_.Object_Oriented_Programming
{
    internal class PracticingExmpleOn_Compostion
    {
        public static void RunExmeples()
        {
            // Setting up the console to show emojis correctly. Nice touch! 👌
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Here, you are COMPOSING your first warrior.
            // You are passing in a Sword object and a LeatherArmor object.
            CompositeBattel knight = new(new Sword(), new LeatherArmor());
            knight.finishThem(); // Let's see him in action!

            Console.WriteLine("-------------------------");

            // Here, you are COMPOSING a DIFFERENT warrior using the SAME class!
            // You just swapped the parts: an Axe and SteelArmor. This is the power of composition.
            CompositeBattel bigerone = new(new Axe(), new SteelArmor());
            bigerone.finishThem();
        }

        // The "contract" for a weapon. Anything that is a weapon MUST have an attack method.
        public interface Iweapon
        {
            void attack();
        }

        // The "contract" for armor.
        public interface IArmor
        {
            void Defend();
        }

        // One type of weapon. 🗡️
        public class Sword : Iweapon
        {
            public void attack()
            {
                Console.WriteLine("tak you with the sword");
            }
        }


        // Another type of weapon. 🪓
        public class Axe : Iweapon
        {
            public void attack()
            {
                Console.WriteLine("axe send it to get your head");
            }
        }

        // One type of armor. 🛡️
        public class LeatherArmor : IArmor
        {
            public void Defend()
            {
                Console.WriteLine("defending with leather armor");
            }
        }

        // Another, stronger type of armor.
        public class SteelArmor : IArmor
        {
            public void Defend()
            {
                Console.WriteLine("defending with steel armor 🥷");
            }
        }


        // Your main "composite" class. The battle character. 
        // It is COMPOSED of a weapon and armor.
        public class CompositeBattel
        {
            // The "slots" to hold the parts.
            private readonly Iweapon _weapon;
            private readonly IArmor _armor;

            // The constructor that "assembles" the character.
            public CompositeBattel(Iweapon weapon, IArmor armor)
            {
                _weapon = weapon;
                _armor = armor;
            }

            // The action method. The character delegates the work to its parts.
            public void finishThem()
            {
                Console.WriteLine("will finish them");
                _weapon.attack(); // Asks the weapon to attack
                _armor.Defend();  // Asks the armor to defend
            }
        }
    }
}
