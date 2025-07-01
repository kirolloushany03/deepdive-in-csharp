using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepDive_In_C_
{
    internal class AbstractClasse
    {
        public static void Run_AbstractExamples()
        {
            // 🔷 abstract classes
            // 🚫 Classes cannot be instantiated directly 
            // 🧱 They provide some base functionality and also have methods that need to be implemented
            // 📜 Like the interface

            // ❗ Some developers try to apply DRY (Don't Repeat Yourself) and see duplicate logic.
            // 😬 To solve this, they use abstract classes to "share" code across multiple classes,
            // hoping inheritance will clean things up. But we can use composition later
            // 🧠 And we will understand why

            // 🔨 Now test to break the rules: we will try to instantiate an abstract class

            /*
            MyBaseClass myBaseClass = new MyBaseClass(); 
            // ❌ Will get error: Cannot make instance from abstract

            IMybasecalss myBaseClass2 = new IMybasecalss(); 
            // ❌ Or from interface — this will not compile

            interface IMybasecalss
            {
                public void print();
            }
            */

            // ✅ If a class inherits from an abstract class,
            // it must do the following to compile successfully:

            // 1️⃣ Implement **all** abstract methods defined in the base abstract class.
            // 2️⃣ Use the `override` keyword when implementing those methods.

            // ❌ If you forget to implement even one abstract method,
            // OR you forget the `override` keyword —
            // 🚫 The code will NOT compile and you’ll get a compiler error.

            // ⚠️ If you remove `override`, it's technically called "hiding"
            // 🕵️ That means declaring something with the same name and signature
            // will technically hide the other method in the abstract class — but still won't compile
            // 🔁 And we don’t need to override the `print()` method from the abstract class
            // 🟢 Because it wasn’t marked as abstract


            // 🚀 Instantiating derived class that implements abstract base method
            MyderviedClass myDerivedclass = new MyderviedClass();
            myDerivedclass.print();
            myDerivedclass.PrintAbstract();

            Console.WriteLine("==============this the final one =================");

            // 🚀 Instantiating derived class that implements both abstract base and interface
            MyDerivedClass2 myDerivedAbstractClass2 = new MyDerivedClass2();
            myDerivedAbstractClass2.print();
            myDerivedAbstractClass2.PrintAbstract();
            myDerivedAbstractClass2.printInterface();
        }

        // 🔗 abstract class also can inherit from interfaces and other classes — as we can see in this example

        interface IMyInterface
        {
            void printInterface();
        }

        // 🧐 Something I noticed here:
        // 📌 If you list the interface first in the inheritance list and then the abstract class,
        // you'll get an error and the code will not compile
        // ⚠️ So you have to put the abstract class first and then the interfaces — but why?

        /*
        📘 Why This Rule Exists:
        C# uses a single-inheritance model for classes and multi-inheritance for interfaces. So:
        - ✅ The first type after the colon `:` must be the base class (if any)
        - ➕ All following types are assumed to be interfaces
        ⚠️ That’s why putting IMyInterface first confuses the compiler — it thinks MyBaseClass is another interface, 
             and throws the error when it realizes it’s not
        */

        abstract class MyDerivedAbstractClass : MyBaseClass, IMyInterface
        {
            public abstract void printInterface();
        }

        class MyDerivedClass2 : MyDerivedAbstractClass
        {
            // 🛠️ Now we must implement both methods: 
            // - From the abstract class
            // - And the interface method

            public override void PrintAbstract()
            {
                Console.WriteLine("PrintAbstract() in MyDerivedAbsractClass2");
            }

            public override void printInterface()
            {
                Console.WriteLine("printInterface() in MyDerivedAbsractClass2");
            }
        }

        class MyderviedClass : MyBaseClass
        {
            public override void PrintAbstract()
            {
                Console.WriteLine("PrintAbstract() in MyDerviedclass");
            }
        }

        abstract class MyBaseClass
        {
            public void print()
            {
                Console.WriteLine("Print() in MyBaseClass");
            }

            // 📢 So you need this: if you inherit from this class,
            // you have to implement this method
            public abstract void PrintAbstract();
        }
    }
}
