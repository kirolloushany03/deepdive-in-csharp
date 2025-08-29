namespace DeepDive_In_C_.AdvancingWithMethodsAndFunctions;

internal class Callbacks_Delegates
{
    public static void RunExamples()
    {
        //callbacks and delegates
        //so the callback is the design patter
        //and you apply it with the delegates

        //lets stor a mthod into an action variable
        //action has no return type always void

        Action action = Kiro;

        action();
        action.Invoke();

        void Kiro()
        {
            Console.WriteLine("helow kiro from delegates from kiro");
        }


        //we willuse funk another type of delgates
        //and it return the last type you put in it
        //and it take the type of the two paramters and the reutrn of it also
        //so the last parmeter here on the list is the return type of the func

        Func<int, int, int> addfunction = AddFunction;
        Func<int, int, int> subtractionfunction = SubtractionFunction;


        Console.WriteLine(addfunction(2, 3));


        int AddFunction(int a, int b)
        {
            return a + b;
        }

        int SubtractionFunction(int a, int b)
        {
            return a - b;
        }


        //so in this method this method take method as paramter and it will run anything in the method that we took after 
        //take enter from the user
        void DoSomethingAfterPressingEnter(Action callbackmethod)
        {
            Console.WriteLine("pressing enter to get your subrise");
            Console.ReadLine();
            callbackmethod();
        }

        DoSomethingAfterPressingEnter(Kiro);


        /*
            so when to use it
        when you need to contorl what is excuted after a certain even occurs or condition is met
        -after  a file is downladed
        - when a user click s a button 
        - when a monitor detects an issue
         */

        //we can also pass function as paramter
        void Calculate(Func<int, int, int> calculateMehtodCallback)
        {
            Console.WriteLine("Enter the First Number:");
            int a = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Secound Number:");
            int b = int.Parse(Console.ReadLine());

            int reuslt = calculateMehtodCallback.Invoke(a, b);

            Console.WriteLine($"the reuslt is {reuslt}");
        }

        Console.WriteLine("Addtion exmple");
        Calculate(AddFunction);
        Console.WriteLine("Subtraction exmpale");
        Calculate(SubtractionFunction);

        //making our delgate why to be have more readablity like if go to line like this
        //    int reuslt = calculateMehtodCallback.inovke(); and hover on inovke will said to us arg1 and arg2 
        //but if we didi our onw which will not be too far from this will be more readable as we will but the names
        //like this 


        Calculatedelegate addDelegate = AddFunction;
        Calculatedelegate SubtractionDelegate = SubtractionFunction;
        //SubtractionDelegate.Invoke(); // so here when you hover on invoke will see instead of giving me arg1 and arg2 will giving you
        // firstnumber and secoundnumber which is more readable

        void Calculate2(Calculatedelegate calculatedelegate)
        {
            Console.WriteLine("Enter the First Number:");
            int a = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Secound Number:");
            int b = int.Parse(Console.ReadLine());

            int reuslt = calculatedelegate(a, b);
            Console.WriteLine($"the reuslt is {reuslt}");
        }


        Console.WriteLine("Addtion exmple");
        Calculate2(AddFunction);
        Console.WriteLine("Subtraction exmpale");
        Calculate2(SubtractionFunction);

        //so also there is on more type is Predicate which is Func<T, bool> so it sth betere for comaprison
        //so it si one Normal Func but return a bool

        Predicate<int> isEven = x => x % 1 == 0;

        Console.WriteLine(isEven.Invoke(4));

        isEven.Invoke(7);


        //bool iseven (int a)
        //{
        //    return a % 2 == 0;
        //}


    }
    delegate int Calculatedelegate(int firstnumber, int secoundnumber);

}
