using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepDive_In_C_
{
    internal class PrtotectedVsPrivate_AbstractVsVirtual
    {
        public static void Run_Examples()
        {
            // 🌟 START: Understanding `virtual` and `protected` in C# 🌟

            // 🔒 `private`: ❌ Cannot be accessed in the derived class
            // 🛡️ `protected`: ✅ Can be accessed in the derived class

            // 🔁 `virtual`: Optional override and implementation in the derived class
            // 🧩 `abstract`: Mandatory to override and implement all abstract methods in the derived class

            // 🎯 `virtual` is a middle ground:
            // If the method is `abstract`, ➡️ it **must** be overridden.
            // If the method is `virtual`, ➡️ you **may choose** to override it (not required).

            // 🔒 `protected` example:
            DerivedClass derivedClass = new();
            derivedClass.PrintInDerivedClass();


            // ✅ Let's see how `virtual` works in action:
            DerivedClass2 derivedClass2 = new();
            derivedClass2.printInDerivedClass();
            derivedClass2.VirtualPrintInBaseClass();
        }

        //for 🔒 protected 
        abstract class AbstractBaseClass
        {
            // 🛡️ Protected method: used by derived class
            protected void ProtectedPrintInBaseClass()
            {
                Console.WriteLine("ProtectedPrintInBaseClass");
            }

            // 📌 Abstract method: must be overridden in derived class
            protected abstract void ProtectedAbsractPrint();
        }

        class DerivedClass : AbstractBaseClass
        {
            public void PrintInDerivedClass()
            {
                Console.WriteLine("we're in the derived class??");

                // ✅ Calling protected method from base class
                base.ProtectedPrintInBaseClass();

                Console.WriteLine("we are leaving the method in the derived class!");
            }

            // 🔁 Required implementation of abstract method from base
            protected override void ProtectedAbsractPrint()
            {
                Console.WriteLine("ProtectedAbsractPrint()");
            }
        }

        //for 🔁 virtual 
        class BaseClass2
        {
            // 🛡️ Protected method: accessible only within the class and its derived types
            protected void PrintInBaseClass()
            {
                Console.WriteLine("PrintInBaseClass");
            }

            // 🔁 Virtual method: can optionally be overridden by derived classes
            public virtual void VirtualPrintInBaseClass()
            {
                Console.WriteLine("VirtualPrintInBaseClass");
            }
        }

        class DerivedClass2 : BaseClass2
        {
            public void printInDerivedClass()
            {
                Console.WriteLine("printInDerivedClass");

                // ✅ Calling the protected method from base class
                PrintInBaseClass();
            }

            // ✅ Overriding the virtual method from base class
            public override void VirtualPrintInBaseClass()
            {
                Console.WriteLine("VirtualPrintInBaseClass in the derived class");

                Console.WriteLine("... and now we'll call the base class method!");
                base.VirtualPrintInBaseClass(); // 🔁 Calls the original base class version
            }
        }

    }
}
