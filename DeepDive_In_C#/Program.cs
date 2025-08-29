/*//classes types (refrence types) vs
//value types (prmitive data types) --> (integers, doubles and boleans)more

//what we will do just we will just call these things in functions and will see what will happen

//refernce types --> talking about shared refrence that's in memery and work with it 
//value types --> copied around
Console.WriteLine("==============add to list by passing the ref of it==============");


List<string> ourlist = new()
{ 
    "hello",
    "kiro"
};

void DoSthWithRefrence(List<string> list)
{
    list.Add("from");
    list.Add("kiro3");
}
Console.WriteLine("this before refrenceing:\n");
Console.WriteLine(string.Join("\n", ourlist));

Console.WriteLine("\nthis after refrenceing:\n");

DoSthWithRefrence(ourlist);

foreach (var list in ourlist)
{
    Console.WriteLine(list);
}


//above so what happned here
//1- we we wrote new() adn add "hello" and "kiro"
//now the object list created that has "hello and kiro" in the heap and
//sent to the variable that named ourlist the refrence of the place of that  object in the memorey
//so now ourlist is just pointing to the object in the heap memomry 
// when we just add ourlist to the function called "DosthwithRefernce"
// and in this function there is a prameter that now pointint to the same list(object) that variable  ourlist points 2 
//so now we have two varaibalbes points to the same object means have the reference or the place that the object in the heap memorey
//so when we just added some strings in the function and print the function again we found that the list has the new strings taht added from teh function
//and this because variable that in the parm of the function points to the same object

Console.WriteLine("==============try to change the value by passing the value==============");

//now with valuse

string ourstring = "hello, kiro";

void Dosthwithvalue(string value)
{
    value = "Kiro the best";
}

Console.WriteLine("\nvalue before:\n");
Console.WriteLine(ourstring);

Console.WriteLine("\nvalue after:\n");
Dosthwithvalue(ourstring);
Console.WriteLine(ourstring);


//so here the value did not changed and this because this becaseu teh function modified the value insside only the vfunction not outside 

//but we can modifi the value by passing the refrence of the value like we did in the object
//and this by using the word ref


Console.WriteLine("==============change the value by passing the ref==============");
void DoSthWithValueByRef(ref string value)
{
    value = "kiro the best";
}

Console.WriteLine("\nvalue before:\n");
Console.WriteLine(ourstring);

Console.WriteLine("\nvalue after:\n");
DoSthWithValueByRef(ref ourstring);
Console.WriteLine(ourstring);

//what the ref keyword do the ref keyword is just tellig eh compiler that this value is 
// passing by refrence not by value 
//✅ That means the method receives a reference to the original variable, not a copy.
//When you use ref, the function receives a reference to the memory address of the variable,
  //not just its value.
//This enables:

//✅ Modifying the original variable

//✅ Skipping unnecessary value copies (especially for structs!)

//✅ Returning references from methods*/

//uncomment to run the exmples 

/*using DeepDive_In_C_;

PrimerOnClasses_refence_AndValueTypes.RuncExamples();*/

//=============================================================
/*//enums
//Enums are value types
//the better to use enums in situation that you will not change the values of it
//can we change the enums --> no

*enums we can call are in fact a numeric type --> that we can cast it as an integer
 * but we can not cast enum as string
 

//so here we can cast the inum as integer
using System.Runtime.Serialization;

int monday = (int)DaysOfWeek.monday;

//but we can not cast it as string
//string monday = (string)DaysOfWeek.monday; //can not convert daysofweek to string

//and this the confucing part that when we wrte enums to the console
//they look like stings!
Console.WriteLine($"enum value directly: {DaysOfWeek.monday}");
Console.WriteLine($"enum value casted to int: {(int)DaysOfWeek.monday}");

//but we can go from an << enum to a string >>
//so we need to use the ToString() Method to do that
string mondaystring = DaysOfWeek.monday.ToString();
Console.WriteLine($"this the string representation of it -->  {mondaystring} --type--> {mondaystring.GetType()}");

//and to go from << string to enum >> we need parsing
//we need to use Enum.Parse and this need the enum type and sting value
//also we have another variabion in mondayenum2 with genierics with <>
Console.WriteLine(DaysOfWeek.Friday.GetType());

DaysOfWeek Fridayenum = (DaysOfWeek)Enum.Parse(typeof(DaysOfWeek), "Friday");
//another version of parsing
DaysOfWeek fridayenum2 = Enum.Parse<DaysOfWeek>("Friday");

Console.WriteLine($"fridayenum = {Fridayenum} type {Fridayenum.GetType()} and this fridayenum2 = {fridayenum2} type {fridayenum2.GetType()}");

//there is also TryParse validation as well:
DaysOfWeek mondayenum3;
bool parssuccesed = Enum.TryParse("monday", out mondayenum3);
Console.WriteLine($"Enum {(parssuccesed ? "was parsed" : "was not parsed")}: {mondayenum3}");

//so why here still see sunday printed even the  enum was not sucesseful
// and this becasue the default numeric value of the enum is 0
// and sunday is also assigned to the numeric value 0
bool parssuccesed2 = Enum.TryParse("kiro", out mondayenum3);
Console.WriteLine($"Enum {(parssuccesed2 ? "was parsed" : "was not parsed")}: {mondayenum3}");

//and if we changed to dayofweek2 and here we jsut set the numeric values form 1 -7
//still will get not parsed and numeric value 0
DaysofWeek2 mondayenum4;
bool parssuccesed4 = Enum.TryParse("kiro", out mondayenum4);
Console.WriteLine($"Enum for mondayenum4 {(parssuccesed4 ? "was parsed" : "was not parsed")}: {mondayenum4}");

//we can also use the enum.getvalues method to get all the values of an enum

Console.WriteLine("\nAll Enum Values:");
Console.WriteLine("print values with casting");

foreach (DaysOfWeek day in Enum.GetValues(typeof(DaysOfWeek)))
{
Console.WriteLine($"Enum value: {(int)day} and type: {day.GetType()}");
}

Console.WriteLine("\nprint values without casting");

foreach (DaysOfWeek day in Enum.GetValues(typeof(DaysOfWeek)))
{
Console.WriteLine($"Enum value: {day} and type: {day.GetType()}");
}

Console.WriteLine("\nprint all the names of the enum string");

Console.WriteLine("\nAll Enum Names");
foreach (string day in Enum.GetNames(typeof(DaysOfWeek)))
{
Console.WriteLine($"Enum Name: {day} and type: {day.GetType()}");
}
Console.WriteLine("\n");
//wierd behavior where we can techincally cast an int to an enum
//even if the int desn;t correspont to a valid enum value!
DaysOfWeek invalidday = (DaysOfWeek)8;
Console.WriteLine($"Invalid Enum Value: {invalidday} type of it {invalidday.GetType()}");

permissions readwrite = permissions.read | permissions.write;
Console.WriteLine($"RW: {readwrite}");

//we can check if a flas is set like this :
bool canRead = (readwrite & permissions.read) == permissions.read;
bool canWrite = (readwrite & permissions.write) == permissions.write;
bool canExcute = (readwrite & permissions.Excute) == permissions.Excute;

Console.WriteLine($"canRead : {canRead}");
Console.WriteLine($"canWrite : {canWrite}");
Console.WriteLine($"canExcute : {canExcute}");

enums also be used as "flags"
using bitwise opertors
why we assign the numbers like this  0 1 2 4 this numbering called the power of 2
and we do this to the number to dont get confused when we use opertors
like if assing 0 1 2 3 instead of  0 1 2  4
in the first one if we jsut made 1 + 2 (read + write) this will give us 3 but 3 assigend before to "excute"
so the computer will get confused which one to make the two choises read + write or do excute
thats why we do it power of 2
also we have all the freedom to do what we want and assign  what we want

[Flags]
enum permissions
{
    None = 0,
    read = 1,
    write = 2,
    Excute = 4
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

//we can also define the enums like this in another way
enum DaysofWeek2
{
    sunday = 1,
    monday = 2,
    tuesday = 3,
    wednesday = 4,
    thursday = 5,
    Friday = 6,
    saturday = 7
}*/

/*using DeepDive_In_C_;

Enums.run_enums();*/


//=============================================================

//begin in struct
//it is a value type
/*
 * look like calss, 
 * also have a construcotor
 * 🏗️ Constructor Difference:
 * When you define a constructor with parameters in a class, 
 *  the default parameterless constructor disappears ❌.

 * But in a struct, even if you define a constructor with parameters, 
 *  the default parameterless constructor still exists ✅.
 *  
 *  
 *  also the struct is stored in the stack and this also a big diffrence
 *  as the stack is faster than the heap as it dont need garbage collector 
 *  so this will beuseful if you have things small and need faster pefromance than clases
 */

//example of a struct
/*
 */




// so when you just pass the class so you give them the refrence which can be controlled by sth else
//but when you pass the struct it makes copy of the struct 

//here is an exmaple of astruct being copied when passed to a method
/*void DoSomethingWithPoint(Point p)
{
    p.X = 111;
    p.Y = 123;
}

var ourpoint = new Point()
{
    X = 124,
    Y = 145
};

Console.WriteLine(ourpoint.GetType()); // so the type of it is point

Console.WriteLine($"ourpoint before Dosomethingwithpoint: " + 
    $"{ourpoint.X}, {ourpoint.Y}");

DoSomethingWithPoint(ourpoint);

Console.WriteLine($"ourpoint after Dosomethingwithpoint: " +
    $"{ourpoint.X}, {ourpoint.Y}");*/

/*
 * 👆👆 and we got here the same values and this because the
 * struct value type bass copy of it not the original one 
*/

/*void DoSomethingWithPointWithProperties(PointWithProperties p)
{
    p.X = 111;
    p.Y = 123;
}

var ourpointWithProb = new PointWithProperties()
{
    X = 124,
    Y = 145
};

Console.WriteLine(ourpointWithProb.GetType()); // so the type of it is point

Console.WriteLine($"ourpointWithProb before DoSomethingWithPointWithProperties: " +
    $"{ourpointWithProb.X}, {ourpointWithProb.Y}");

DoSomethingWithPointWithProperties(ourpointWithProb);

Console.WriteLine($"ourpointWithProb after DoSomethingWithPointWithProperties: " +
    $"{ourpointWithProb.X} ,  {ourpointWithProb.Y}");

//-------------------tying that the two constructor will work // so here what 
var PointWithTwoConstructor = new PointWithConstructor(3,4);

Console.WriteLine($"this x from struct PointWithConstructor {PointWithTwoConstructor.X}" +
    $" and this the Y from struct PointWithConstructor {PointWithTwoConstructor.Y}");*/
/*
    because structs can look like classes, it can be
    confusing when to use a struct and when to use a class
    here are some guidelines:
    -use a struct when you have a small, simple object
    that you want to pass by value
    - use a struct when you want to avoid the overhead
    of heap allocation, garbage collecting, etc ...
    I try to think about very primative things like a
    Point, or a Color, or a Rectangle, or other geometric things
*/

/*public struct Point
{
    public int X;
    public int Y;
}
//same struct but with properties
public struct PointWithProperties
{
    public int X { get; set; }
    public int Y { get; set; }
}

//struct with constructor
public struct PointWithConstructor
{
    public PointWithConstructor()
    {
        Console.WriteLine("hellow from the default");
    }
    public PointWithConstructor(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; set; }
    public int Y { get; set; }
}

public struct PointWithMethod
{
    public int X;
    public int Y;

    public void Move(int x, int y)
    {
        X += x;
        Y += y;
    }
}*/


/*using DeepDive_In_C_;

Structs.RunStructs_Exersices();*/

//==============================================
//the problem with equality
/*
 * so we can say here 
 * what is the problem here ?
 *      so the probelm here when you work with both in same project staruct(value type) and classes(refrecne type)
 * the probelm that you can get confused by the two behaviours between the value and refrence type
 * so the solution here is to override the behaviour of the equality to make the refrence type (class)
 * to behave likethe value type and this by override three things
 *      1. the Equals method so we can check the content instead of the refrences(memory addresses)
 *                  But that’s only half the story
 *      2. also we will change the the GetHashCode() method for the 
 *              objects go into hash-based collections like Dictionary or HashSet
 *      3. last thing is the operaotr == != to make it to use our Equals method instead of the default one
        \

so this what the people try to do jsut for clarifiying to use we dont have to do that
next one will be the solution
 */

//lets look at class equality
/*var myclass1 = new Myclass { NumericValue = 123, StringValue = "ABC" };
var myclass2 = new Myclass { NumericValue = 123, StringValue = "ABC" };
Console.WriteLine("is myclasss1 is equal to myclass2");
Console.WriteLine(myclass1 == myclass2);
Console.WriteLine(myclass1.Equals(myclass2));
Console.WriteLine(object.Equals(myclass1, myclass2));


var mystruct1 = new Mystruct {NumericValue = 123, StringValue = "soso" };
var mystruct2 = new Mystruct {NumericValue = 123, StringValue = "soso" };
Console.WriteLine("is mystrcut1 is equal to mystruct2");
//Console.WriteLine( mystruct1 == mystruct2); //you need to sepcify the specific propbety
Console.WriteLine(mystruct1.Equals(mystruct2));
Console.WriteLine(object.Equals(mystruct1, mystruct2));


//after modifiying the behaviour of Equals to make the behaviour of the refrence type liekthe value type
var myClassWithEquality1 = new MyclassWithEquality { NumericValue = 123, StringValue = "koko" };
var myClassWithEquality2 = new MyclassWithEquality { NumericValue = 123, StringValue = "koko" };

Console.WriteLine("myClassWithEquality1 is equal to myClassWithEquality2");
Console.WriteLine(myClassWithEquality1 == myClassWithEquality2);
Console.WriteLine(myClassWithEquality1.Equals(myClassWithEquality2));
Console.WriteLine(object.Equals(myClassWithEquality1, myClassWithEquality2));

// so we can modify the behavior of the classes so it can compare the values insteead of the refence only
var myClassWithEqualityAntOperator1 = new MyclassWithEqualityAndOperator { NumericValue= 123 , StringValue = "fofo"};
var myClassWithEqualityAntOperator2 = new MyclassWithEqualityAndOperator { NumericValue= 123 , StringValue = "fofo"};
Console.WriteLine("is myClassWithEqualityAntOperator1 is queal to myClassWithEqualityAntOperator2");
Console.WriteLine(myClassWithEqualityAntOperator1 == myClassWithEqualityAntOperator2);
Console.WriteLine(myClassWithEqualityAntOperator1.Equals(myClassWithEqualityAntOperator2));
Console.WriteLine(object.Equals(myClassWithEqualityAntOperator1, myClassWithEqualityAntOperator2));


public class MyclassWithEqualityAndOperator
{ 
    public int NumericValue { get; set; }
    public string StringValue { get; set; }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        var other = (MyclassWithEqualityAndOperator)obj;
        return NumericValue == other.NumericValue && StringValue == other.StringValue;
    }

    public override int GetHashCode()
    {
        return NumericValue.GetHashCode() ^ StringValue.GetHashCode();
    }

    public static bool operator ==(MyclassWithEqualityAndOperator left, MyclassWithEqualityAndOperator right)
    { 
        return left.Equals(right);
    }
    public static bool operator !=(MyclassWithEqualityAndOperator left, MyclassWithEqualityAndOperator right)
    { 
        return !left.Equals(right);
    }
}


public class MyclassWithEquality
{
    public string StringValue { get; set; }
    public int NumericValue { get; set; }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType()) 
            return false;

        var other = (MyclassWithEquality)obj; //🎩 This turns the object into a real MycalssWithEquality type

        return NumericValue == other.NumericValue && StringValue == other.StringValue;
    }

    public override int GetHashCode()
    {
        return NumericValue.GetHashCode() ^ StringValue.GetHashCode();
    }
}

public class Myclass
{ 
    public int NumericValue { get; set; }
    public string StringValue { get; set; }
}

public struct Mystruct
{
    public int NumericValue { get; set; }
    public string StringValue { get; set; }
}
*/
/*using DeepDive_In_C_;

ProblemWithEquality.Run();*/


//====================================================================================
//records the solution of the previous problem
//  (problem between the refrence and value type equlaity)
//record is refrence type and dealing with the value type results

/*MyRecord myrecord1 = new(123, "ABC");

MyRecord2 myrecord2 = new()
{
    NumbericValue = 123,
    stringvalue = "ABC"
};

Console.WriteLine(myrecord2);


//not the both casese we cannot change the propetires
//becaue the they are both init only:
//myrecord2.stringvalue = "kkk"; // will not compile
//myrecord2.NumbericValue= 1456; //will not compile  and this becaue the init


//how the eqality will works with the record  ?
MyRecord recordA = new(123, "ABC");
MyRecord recordB = new(123, "ABC");
Console.WriteLine("is recordA is equal to recordB");
Console.WriteLine(recordA == recordB); //true
Console.WriteLine(recordA.Equals(recordB)); //true
Console.WriteLine(object.Equals(recordA, recordB)); //true


//we can use the "with "keyword to create new record
// with the same values as the original , but with some changes

MyRecord recordC = recordA with {NumericValue = 1258 };

Console.WriteLine(recordA);
Console.WriteLine(recordB);
Console.WriteLine(recordC);

//we can also decostruct the record in to its properties
//why we use the decostruct
*//*
 * ✅ Use Case: Deconstruction in Records
 *
 * 1. Simplified Property Access:
 *    - Easily extract values without dot notation clutter.
 *    - Example: var (name, age) = Person;
 *
 * 2. LINQ Integration:
 *    - Makes projection and filtering more elegant in Select/Where.
 *    - Example: people.Select(p => { var (n, _) = p; return n; });
 *
 * 3. Pattern Matching:
 *    - Deconstruct directly in switch expressions or match patterns.
 *    - Example: Person switch { ("Alice", 25) => "Matched!", _ => "Default" }
 *
 * 4. Clean API/Controller Logic:
 *    - Deconstruct DTOs in minimal APIs or MVC controllers.
 *    - Example: var (username, password) = loginRequest;
 *
 * 5. Readability & Immutability:
 *    - Enhances readability and works naturally with record immutability.
 *//*
var (recValue, recString) = recordA;
Console.WriteLine("\nthis from the deconstruct of the record A");
Console.WriteLine(recValue);
Console.WriteLine(recString);



MyRecordWithExtraProperties newone = new(123, "kkk");
Console.WriteLine($"stringvalue: {newone.StringValue} , intvalue: {newone.NumericValue}, property:{newone.Extraproperty}");

newone.Extraproperty = "kk is the best";

Console.WriteLine($"stringvalue: {newone.StringValue} , intvalue: {newone.NumericValue}, property:{newone.Extraproperty}");


*//*
 * if neded we can mix in th thinks liek additional properties 
 * that are not just form the posional ones on the constructor
 *//*
public record MyRecordWithExtraProperties(
    int NumericValue,
    string StringValue)
{
    public string Extraproperty { get; set; }
}




//in the deconstrct we have to postion the order
//  based on the order fo the probperties if not will not wrok

//(string recstring, int recvalue) = recordA; // will not compile

*//*
 * records can also be defined as a structs which means they'll 
 * will be on the stacck instead of the heap and this can be useful for 
 * things for performance 
 *//*

public record struct MyRecordStruct(
    int NumericValue,
    string StringValue);



public record MyRecord(
    int NumericValue,
    string stringvalue
    );

//so th init make the proeperties as immutable
public record MyRecord2
{ 
    public int NumbericValue { get; init; }
    public string stringvalue { get; init; }
}
*/


//========================================================================
/*using DeepDive_In_C_;

//just this without static class
*//*Records tryit = new();
tryit.RunRecords();*//*

//and this with static class
Records.RunRecords();*/


//========================================================================
//welcome again to the oop
//c# don't allow mulitple inhertence only allowing one 


/*BMW car1 = new();
Console.WriteLine(car1.DoorCount);

Car BMWcar = new Car() {DoorCount = 4 };
Car coupe = new () { DoorCount  = 2};
Truck PickupTruck = new () { DoorCount  = 2};
Bike bike = new Bike();

BMWcar.OpenDoors();
coupe.OpenDoors();
PickupTruck.OpenDoors();
bike.OpenDoors();

public class Vehicle
{ 
    public int DoorCount { get; init; }

    //gettype get teh specific type of the instance so i can see where i come from specifcally
    public void OpenDoors()
    {
        Console.WriteLine(
            $"{GetType().Name} opening {DoorCount} doors!");
    }
}

public class Automobile : Vehicle
{ }

public class Car : Automobile
{ }

public class BMW : Car
{
    public BMW()
    {
        DoorCount = 4;
    }
}
public class Truck : Automobile
{ }
public class Van : Automobile
{ }

public class Bike : Vehicle
{
    public Bike() 
    {
        DoorCount = 0;
    }
}

public class Plane: Vehicle
{ }*/



//==================
/*using DeepDive_In_C_;

Inheritance.Run_inheritcance();*/

//=====================================================================
// oop - interfaces
//just a defeinition of how we would interact with something / not the implementation
// dont get to pick and choose i need to implment all of it

/* why to use intefaces ?
 * what is the problem it solving?
 * why we do it in our code instead of doing the methods dirctly
 */
//you can inhert from multiple interfaces

/*using System.Security.Cryptography.X509Certificates;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Motorcycle motorcycle = new();
motorcycle.StartEngine();
Console.WriteLine(motorcycle.IsEngineRunning);

//just small thing to try to hack 😂 the IsEngineRunning to set it outside the class
//motorcycle.IsEngineRunning = flase; // this will fail because will give error
                                      //"The property or indexer 'Motorcycle.IsEngineRunning'
                                      //cannot be used in this context
                                      //because the set accessor is inaccessible"
motorcycle.StopEngine();
Console.WriteLine(motorcycle.IsEngineRunning);

motorcycle.StopEngine();
Console.WriteLine(motorcycle.IsEngineRunning);

//just to have the idea casting it to the class to interface implcit
//and vice versa will be  so we need to explicit casting it
IMotorized motorized = motorcycle; //this part actually happen in the backend using the dependcy injection 
Motorcycle motocycle2 = (Motorcycle)motorized; // of course iwll not do that but we can do it in better way


*//*
 🤔 If multiple classes implement IHasDoosrs,
     how do we pick which one gets used?

 ✅ We choose at creation time using 'new Room(...)'
     or 'new Spaceship(...)'—that’s where control happens.

 🧠 The code only depends on the interface, but actual
     behavior comes from the class we create with 'new'.

 ⚙️ In real projects, this is often handled automatically
     using Dependency Injection (DI) containers.
*//*
IHasDoosrs doors = new Room(3);

doors.OpenDoors(1);
doors.CloseDoors(2);
doors.IsDoorOpen(0);


Console.WriteLine("======================car =====================");
Car coupe = new(2);
Car sedan  = new(4);




void TestIgnition(IMotorized motorized)
{
    motorized.StartEngine();
    Console.WriteLine($"Engine is running: {motorized.IsEngineRunning}");
    motorized.StopEngine();
    Console.WriteLine($"Engine is running: {motorized.IsEngineRunning}");
}
void TestDoors(IHasDoosrs hasDoosrs)
{
    for (int i = 0; i < hasDoosrs.NumberOfDoors; i++)
    {
        hasDoosrs.OpenDoors(i);
        Console.WriteLine($"Door {i} is open: {hasDoosrs.IsDoorOpen(i)}");
    }
}


TestIgnition(coupe);
TestIgnition(sedan);

TestDoors(coupe);
TestDoors(sedan);

//now public calss with both mulitple interfaces
public class Car : IHasDoosrs, IMotorized
{
    public readonly bool[] _doors;
    public Car(int numbersofdoors)
    {
        _doors = new bool[numbersofdoors];
    }

    public int NumberOfDoors => _doors.Length;

    public bool IsEngineRunning { get; private set; }

    public void OpenDoors(int doorIndex)
    {
        _doors[doorIndex] = true;
        Console.WriteLine($"Door {doorIndex} is {(_doors[doorIndex] is false ? "close" : "open")}");
        Console.WriteLine($"     {string.Join(",", _doors)}");
        Console.WriteLine(GetType());

    }

    public void CloseDoors(int doorIndex)
    {
        _doors[doorIndex] = false;
        Console.WriteLine($"Door {doorIndex} is {(_doors[doorIndex] is false ? "close" : "open")}");
        Console.WriteLine($"     {string.Join(",", _doors)}");

    }

    public bool IsDoorOpen(int doorIndex)
    {
        Console.WriteLine($"Door {doorIndex} is {(_doors[doorIndex] is false ? "close" : "open")}");
        Console.WriteLine($"     {string.Join(",", _doors)}");
        return _doors[doorIndex];

    }
    
    public void StartEngine()
    {
        if (IsEngineRunning)
        { return; }

        IsEngineRunning = true;
        Console.WriteLine("Engine started🏎️");
    }

    public void StopEngine()
    {
        if (!IsEngineRunning)
        { return; }

        IsEngineRunning = false;
        Console.WriteLine("Engine stopped🛑");
    }
}


public class Room : IHasDoosrs
{
    public readonly bool[] _doors;

    public Room(int numberofDoors)
    { 
        _doors = new bool[numberofDoors];
    }

    public int NumberOfDoors => _doors.Length;
    public void OpenDoors(int doorIndex)
    { 
        _doors[doorIndex] = true;
        Console.WriteLine($"Door {doorIndex} is {(_doors[doorIndex] is false ? "close" : "open")}");
        Console.WriteLine($"     {string.Join(",", _doors)}");
        Console.WriteLine(GetType());

    }

    public void CloseDoors(int doorIndex)
    {
        _doors[doorIndex] = false;
        Console.WriteLine($"Door {doorIndex} is {(_doors[doorIndex] is false ? "close" : "open")}");
        Console.WriteLine($"     {string.Join(",", _doors)}");

    }

    public bool IsDoorOpen(int doorIndex)
    {
        Console.WriteLine($"Door {doorIndex} is {(_doors[doorIndex] is false ? "close" : "open")}");
        Console.WriteLine($"     {string.Join(",", _doors)}");
        return _doors[doorIndex];

    }

}


public class Motorcycle : IMotorized
{ 
    public bool IsEngineRunning { get; private set; }

    public void StartEngine()
    {
        if (IsEngineRunning)
        { return; }

        IsEngineRunning = true;
        Console.WriteLine("Engine started🏎️");
    }

    public void StopEngine()
    {
        if (!IsEngineRunning)
        { return; }

        IsEngineRunning = false;
        Console.WriteLine("Engine stopped🛑");
    }
}


public interface IHasDoosrs
{ 
    int NumberOfDoors { get; }
    void OpenDoors(int doorIndex);

    void CloseDoors(int doorIndex);

    bool IsDoorOpen(int doorIndex);
}

public interface IMotorized
{ 
    bool IsEngineRunning { get; }

    void StartEngine();

    void StopEngine();
}*/

//===============================================
/*using DeepDive_In_C_;

Interfaces.Run_InterfacesEXamp();*/

//===============================================
//abstract classes
// classes cannot be instantiated directly 
//they provide some base fucnctionality and also have methods needs to be implement
//like the interface

// ❗ Some developers try to apply DRY (Don't Repeat Yourself) and see duplicate logic.
// 😬 To solve this, they use abstract classes to "share" code across multiple classes,
// hoping inheritance will clean things up. but we can use the compostions later
// and we will unsderstand why

//now test to break the rules we will try to instantiate an abstract class

/*MyBaseClass myBaseClass = new MyBaseClass();//will get also can not make instance from abstract

IMybasecalss myBaseClass2 = new IMybasecalss(); // or from interface this will not compile 

interface IMybasecalss
{
    public void print();
}*/


// ✅ If a class inherits from an abstract class,
// it must do the following to compile successfully:

// 1️⃣ Implement **all** abstract methods defined in the base abstract class.
// 2️⃣ Use the `override` keyword when implementing those methods.

// ❌ If you forget to implement even one abstract method,
// OR you forget the `override` keyword —
// 🚫 The code will NOT compile and you’ll get a compiler error.

//so the override if you remove it it will sth technicaly called hiding
//that we decalre sth with the same name and signnature it will technically hide the other method
//that in the abstract class but still will not compile
//and we dont need to override the print method that in the abstract class as wasn't marked as abstract

/*using DeepDive_In_C_;
using static System.Runtime.InteropServices.JavaScript.JSType;

MyderviedClass myDerivedclass = new MyderviedClass();
myDerivedclass.print();
myDerivedclass.PrintAbstract();

Console.WriteLine("==============this th final one =================");
MyDerivedClass2 myDerivedAbstractClass2 = new MyDerivedClass2();
myDerivedAbstractClass2.print();
myDerivedAbstractClass2.PrintAbstract();
myDerivedAbstractClass2.printInterface();

// abstract class also cna interhr from interfacess and other classes as we can see in this exmple


interface IMyInterface
{
     void printInterface();
}*/

//sth i notice here that if you jsut put in inhertance the 
// interface classs , then the abstract clas will give you an error an the iwll not comipile 
//so yo uhave to put abstract class first and then the intnerfacess  so why

/*📘 Why This Rule Exists
C# uses a single-inheritance model for classes and multi-inheritance for interfaces. So:
- The first type after the colon : must be the base class (if any).
-All following types are assumed to be interfaces.
⚠️ That’s why putting IMyInterface first confuses the compiler — it thinks MyBaseClass is another interface, and throws the error when it realizes it's not.
*/
/*abstract class MyDerivedAbstractClass : MyBaseClass, IMyInterface
{
    public abstract void printInterface();
}

class MyDerivedClass2 : MyDerivedAbstractClass
{
    //now we must impment both methods from the abstract calss and also the interface method
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
    //so you need that if you inhert from this you have to impment this mehtod
    public abstract void PrintAbstract();
}
*/
//using DeepDive_In_C_;

//AbstractClasse.Run_AbstractExamples();

//================================================================================
//begin a new one
//two keywords that we have access in c# that is virtual and protected 

//private keyword can not use it in the derived class that inhert from 
//protected keyword that can be used in the derived class that inhert from 

//virtual make you able have the option of override and implement 
//absract you must override and implemnt all of th emethods abstracted


//virtual
//mix so the abstract you must to implement the abstract methods 
//but here comee the virutal that you can use it that you can use it that
//you hve the option to impment it or not 


//DerivedClass2 derivedClass2 = new();
//derivedClass2.printInDerivedClass();
//derivedClass2.VirtualPrintInBaseClass();
//class BaseClass2
//{
//    protected void PrintInBaseClass()
//    {
//        Console.WriteLine("PrintInBaseClass");
//    }

//    public virtual void VirtualPrintInBaseClass() // so virual means
//                                                  // you have the option to override
//                                                  // and implement it or not 
//    {
//        Console.WriteLine("VirtualPrintInBaseClass");
//    }
//}


//class DerivedClass2 : BaseClass2
//{
//    public void printInDerivedClass()
//    {
//        Console.WriteLine("printInDerivedClass");
//        PrintInBaseClass();
//    }

//    public override void VirtualPrintInBaseClass()
//    {
//        Console.WriteLine("VirtualPrintInBaseClass in the derived class");
//        Console.WriteLine("... and now we'll call the base class method!");        
//        base.VirtualPrintInBaseClass();
//    }
//}





////protected

////DerivedClass derivedClass = new();
////derivedClass.PrintInDerivedClass();


//abstract class AbstractBaseClass
//{
//    protected void ProtectedPrintInBaseClass()
//    {
//        Console.WriteLine("ProtectedPrintInBaseClass");
//    }
//    protected abstract void ProtectedAbsractPrint();
//}

//class DerivedClass : AbstractBaseClass
//{
//    public void PrintInDerivedClass()
//    {
//        Console.WriteLine("we're in the derived class??");
//        base.ProtectedPrintInBaseClass();
//        Console.WriteLine("we are leaveing the method in the derived class!");
//    }

//    protected override void ProtectedAbsractPrint()
//    {
//        Console.WriteLine("ProtectedAbsractPrint()");
//    }
//}


//using DeepDive_In_C_;

//PrtotectedVsPrivate_AbstractVsVirtual.Run_Examples();

////=================================================================
////compostions


//Computer computer = new(

//    new Case(),
//    new Motherboard(),
//    new PowerSupply(),
//    new HardDrive(sizeInTb: 16),
//    new Ram(ramInGB: 64),
//    new GraphicsCard());

//computer.Poweron();

////searled can ot be inherted
//public sealed class Case
//{
//    public void PressPowerButton()
//    {
//        Console.WriteLine("Power button pressed");
//    }
//}


//public sealed class Motherboard
//{
//    public void Boot()
//    {
//        Console.WriteLine("Booting...");
//    }
//}


//public sealed class PowerSupply
//{
//    public void TurnOn()
//    {
//        Console.WriteLine("Power supply turned on");
//    }
//}

//public sealed class HardDrive
//{
//    private readonly int _sizeInTb;
//    public HardDrive(int sizeInTb)
//    { 
//        _sizeInTb = sizeInTb;
//    }

//    public void ReadData()
//    {
//        Console.WriteLine($"Reading data from the hard drive with size of {_sizeInTb} TB");
//    }
//}

//public sealed class Ram
//{
//    private readonly int _RamInGB;

//    public Ram(int ramInGB)
//    {
//        _RamInGB = ramInGB;
//    }

//    public void Load()
//    {
//        Console.WriteLine($"Loading data into ram with capacity of {_RamInGB} GB");
//    }

//}

//public sealed class GraphicsCard
//{ 
//    public void Render()
//    {
//        Console.WriteLine("GPU Rendering");
//    }
//}


////public sealed class Computer
////{ 
////    private readonly Case _case;
////    private readonly Motherboard _motherboard;
////    private readonly PowerSupply _powerSupply;
////    private readonly HardDrive _hardDrive;
////    private readonly Ram _ram;
////    private readonly GraphicsCard _graphicsCard;

////    public Computer( Case thecase , Motherboard motherboard, PowerSupply powersupply,
////        HardDrive harddrive, Ram ram , GraphicsCard graphicsCard)
////    { 
////        _case = thecase;
////        _motherboard = motherboard;
////        _powerSupply = powersupply;
////        _hardDrive = harddrive;
////        _ram = ram;
////        _graphicsCard = graphicsCard;
////    }

////   public void Poweron()
////    {
////        _case.PressPowerButton();
////        _powerSupply.TurnOn();
////        _motherboard.Boot();
////        _ram.Load();
////        _hardDrive.ReadData();
////        _graphicsCard.Render();
////    }

////}


////if it was a record will be like this 
//public sealed record Computer
//(Case Thecase, Motherboard Motherboard, PowerSupply Powersupply,
//        HardDrive Harddrive, Ram Ram, GraphicsCard GraphicsCard)
//{
//    public void Poweron()
//    {
//        Thecase.PressPowerButton();
//        Powersupply.TurnOn();
//        Motherboard.Boot();
//        Ram.Load();
//        Harddrive.ReadData();
//        GraphicsCard.Render();

//    }
//};


//===========================================================================
//head to head to see the adavanctage




//public abstract class Vehicle
//{ }

//public abstract class Automobile : Vehicle
//{
//    private readonly string _engineType;
//    protected Automobile(string engineType)
//    { 
//        _engineType = engineType;
//    }
//    public void StartEngine()
//    { 
//        StartEngine(_engineType);
//    }
//    public abstract void OpenDoor(DoorPostion doorPostion);

//    protected static void StartEngine(string engineType)
//    {
//        Console.WriteLine($"starting {engineType} engine!");
//    }
//}
////if we have abstract inhert from abstract we don't have to overriede the methods
//public abstract class Car : Automobile
//{
//    public override void StartEngine() 
//    {
//        Console.WriteLine("Car starting engine 1.8L engine!");
//    }
//}

//public class Sedan : Car
//{
//    public override void OpenDoor(DoorPostion doorPostion)
//    {
//        Console.WriteLine($"sendan opening {doorPostion} door!");
//    }
//}

//public class Coupe : Car
//{
//    public override void OpenDoor(DoorPostion doorPostion)
//    {
//        if (doorPostion == DoorPostion.RearDriverSide ||
//            doorPostion == DoorPostion.RearPassengerSide)
//        {
//            throw new InvalidOperationException("Coupe only have two doors");
//        }
//        Console.WriteLine($"Coupes only have two doors!");
//    }
//}

//public class PickupTruck : Automobile
//{
//    public override void StartEngine()
//    {
//        Console.WriteLine("Truck starting engine 3.6 L engine!");   
//    }

//    public override void OpenDoor(DoorPostion doorPostion)
//    {
//        if (doorPostion == DoorPostion.RearPassengerSide ||
//            doorPostion == DoorPostion.RearDriverSide)
//        {
//            throw new InvalidOperationException("Truck only have two doors");
//        }
//        Console.WriteLine($"Truck opening {doorPostion} door!");
//    }
//}
//public class Van : Automobile
//{
//    public override void StartEngine()
//    {
//        Console.WriteLine("Van starting engine 3.6 L engine!");   
//    }

//    public override void OpenDoor(DoorPostion doorPostion)
//    {
//        if (doorPostion == DoorPostion.RearPassengerSide ||
//            doorPostion == DoorPostion.RearDriverSide)
//        {
//            Console.WriteLine($"Van sliding open {doorPostion} door!");
//        }
//        else
//        {
//            Console.WriteLine($"van swinging {doorPostion} door!");
//        }
//    }
//}
//so what is the problem that we have with inhertance
/*
 * in the pickup truck engine if we will have like diff versionn we have to make nnew class to change the ening e
 * or to inhert from it and then overridee the startengine 
 * or picup truck with more doors so we will maek agian 
 * so the probelm what we will get in more level with inhertance 
 * 
 */


//using System.Threading.Channels;

//ComposedVehicle composedSedan = new(
//    new ConfigurableEngine(1.8f),
//    new Dictionary<DoorPostion, IDoor> 
//    {
//        { DoorPostion.FronteDriverSide, new standardswingingDoor()},
//        {DoorPostion.FrontPassengerSide, new standardswingingDoor()},
//        {DoorPostion.RearDriverSide, new standardswingingDoor()},
//        { DoorPostion.RearPassengerSide, new standardswingingDoor()}
//    });

//composedSedan.StartEngine();
//composedSedan.OpenDoore(DoorPostion.FronteDriverSide);


//public enum DoorPostion
//{
//    FronteDriverSide,
//    RearDriverSide,
//    FrontPassengerSide,
//    RearPassengerSide
//};
//public interface IEngine
//{
//    void Start();
//}

//public interface IDoor
//{
//    void Open();
//}

//public class V8Engine : IEngine
//{
//    public void Start()
//    {
//        Console.WriteLine("Big  v8 engine starting");
//    }
//}

//public class ConfigurableEngine : IEngine
//{
//    private readonly float _displacemtnInliters;
//    public ConfigurableEngine(float displacemtnInliters)
//    {
//        _displacemtnInliters = displacemtnInliters;
//    }

//    public void Start()
//    {
//        Console.WriteLine($"starting {_displacemtnInliters}L engine");
//    }
//}

//public class standardswingingDoor : IDoor
//{
//    public void Open()
//    {
//        Console.WriteLine("swinging open door");
//    }
//}
//public class SlidingDoor : IDoor
//{
//    public void Open()
//    {
//        Console.WriteLine("Sliding opening door");
//    }
//}

//public sealed class ComposedVehicle
//{
//    private readonly IEngine _engine;
//    private readonly IReadOnlyDictionary<DoorPostion, IDoor> _doors;
//    public ComposedVehicle(IEngine engine, Dictionary<DoorPostion, IDoor> doors)
//    { 
//        _engine = engine;
//        _doors = doors;
//    }
//    public void StartEngine()
//    { 
//        _engine.Start();
//    }

//    public void OpenDoore(DoorPostion doorpostion)
//    {
//        if (!_doors.TryGetValue(doorpostion, out IDoor? door))
//        {
//            throw new InvalidOperationException(
//                $"thre is no door at postion {doorpostion}");
//        }
//        Console.WriteLine($"opening {doorpostion} door...");
//        door.Open();
//    }

//}

//just simple exampole to apply on it from my side 

//Console.OutputEncoding = System.Text.Encoding.UTF8;
//CompositeBattel knight = new(new Sword(), new LeatherArmor());
//knight.finishThem();

//Console.WriteLine("-------------------------");

//CompositeBattel bigerone = new(new Axe(), new SteelArmor());
//bigerone.finishThem();

//public interface Iweapon
//{
//    void attack();
//}

//public interface IArmor
//{
//    void Defend();
//}

//public class Sword : Iweapon
//{
//    public void attack()
//    {
//        Console.WriteLine("tak you with the sword");
//    }
//}


//public class Axe : Iweapon
//{
//    public void attack()
//    {
//        Console.WriteLine("axe send it to get your head");
//    }
//}

//public class LeatherArmor : IArmor
//{
//    public void Defend()
//    {
//        Console.WriteLine("defending with leather armor");
//    }
//}

//public class SteelArmor : IArmor
//{
//    public void Defend()
//    {
//        Console.WriteLine("defending with steel amorm 🥷");
//    }
//}


//public class CompositeBattel
//{ 
//    private readonly Iweapon _weapon;
//    private readonly IArmor _armor;

//    public CompositeBattel(Iweapon weapon, IArmor armor)
//    { 
//        _weapon = weapon;
//        _armor = armor;
//    }

//    public void finishThem()
//    {
//        Console.WriteLine("will finsihe them");
//        _weapon.attack();
//        _armor.Defend();
//    }
//}


//--------------------------------------------------------------------
//////genrics
//////generic does not care about the type
////// or cares only about the type in a limited way
//////we can use genrics on classes , interfaces, methods, etc...

//GenricClass<int> myNumbericInstance = new GenricClass<int>();
//GenricClass<string> mystringInstance = new GenricClass<string>();
////GenricClass instancewithouType = new GenricClass(); //so this will not work

////so for this sone we dont need to specify the type of it when we make an instance
//ImplemntationWithIntgerType instanceofImplmentationWithIntegerType = new();
////-----------------------------------------------------------------------------------

////part 2
//ClassWithGenericMethod InstanceclassGenricMehtod = new();
//InstanceclassGenricMehtod.GenricMethod("this is a string");
//InstanceclassGenricMehtod.GenricMethod(42);
//InstanceclassGenricMehtod.GenricFunction(3.14);

////just here we wrote that to prove that the return will be the same type
//int genricfunctionresult1 = InstanceclassGenricMehtod.GenricFunction(42);
//string genricfunctionresult2 = InstanceclassGenricMehtod.GenricFunction("this a string");
//double genricfunctionresult3 = InstanceclassGenricMehtod.GenricFunction(3.14);

///// <summary> part 3
///// so we was dealing with generics before like in list or dictionries
///// </summary>

//List<int> numericList = new List<int>();
//List<string> stringList = new List<string>();


// * is like i don't really dont care about what type you are as long as
// * you have a parameter list constructor so i need this contructor on whaterver you givin to me
// * 
// * or care that you are a refrence type so you can specify that you need to be class
//*/
////we can use constraints to limit the types that can be used with a genric




//Dog frank = new(
//Weight: 50,
//height: 24);

//Dog spot = new(
//Weight: 35,
//height: 18);

//Cat whiskers = new(
//Weight: 10,
//height: 12,
//HasFur: true);

//Cat pharoah = new(
//Weight: 12,
//height: 14,
//HasFur: false);

//Fish goldie = new(
//Weight: 0.5,
//height: 2);
//var animals = new IAnimal[] { frank, spot, whiskers, pharoah, goldie };

//var totalweight = CalculateWeight(animals);
//var totalheight = CalculateHeight(animals);
//var onlyfur = OnlyWithFur(animals);

//Console.WriteLine($"this the total Weight {totalheight} " +
//    $"total height {totalheight} " +
//    $"and the only ones have furs is -->{onlyfur.ToString}");
//double CalculateWeight<T>(IEnumerable<T> animals)
//    where T : IAnimal //this the only constrain we want
//{
//    var total = animals.Sum(a => a.Weight);
//    return total;
//}

//double CalculateHeight<T>(IEnumerable<T> animals)
//    where T : IAnimal
//{
//    var total = animals.Sum(a => a.height);
//    return total;
//}

//IEnumerable<IAnimal> OnlyWithFur(IEnumerable<IAnimal> animals)
//{ 
//    return animals.Where(a => a.HasFur);
//}


////------------interface classes etc 👇👇 and instantiate them up 👆👆------------
//public interface IAnimal
//{
//    double Weight { get; }
//    double height { get; }
//    bool HasFur { get; }
//}

//public record Cat(
//    double Weight,
//    double height,
//    bool HasFur) : IAnimal;

//public record Dog(double Weight, double height) : IAnimal
//{
//    public bool HasFur => true;
//}

//public record Fish(
//    double Weight,
//    double height) :
//    IAnimal
//{
//    public bool HasFur => false;
//}


////part 2
////now lets see some genric methods👇👇
//public class ClassWithGenericMethod
//{
//    public void GenricMethod<T>(T value)
//    {
//        Console.WriteLine(
//            $"The type of the value is {value?.GetType().Name}" +
//            $" and the value is --> {value}");
//    }
//    public T GenricFunction<T>(T value)
//    {
//        Console.WriteLine(
//            $"the type of the value is --> {value?.GetType().Name}");
//        return value;
//    }
//}

////so we saw some genric classes and genric interfaces 👇👇
////we could also make an implemnetation that specffies the type
////so we can make the class not genric but specify the type in the interface
//public class ImplemntationWithIntgerType : IGenericIneterace<int>
//{

//}
//public interface IGenericIneterace<T>
//{
//    //no methods
//}

//public class GenricClass<T> : IGenericIneterace<T>
//{
//    // so the class itseelf also needs to have a type of prameter on it 
//    //to allow caller creating instances of this class to specify the type
//}

//static int[] TwoSum(int[] nums, int target)
//{
//    for (int i = 0; i < nums.Length; i++)
//    {
//        for (int j = i+1; j < nums.Length; j++)
//        {
//            if ( nums[i] + nums[j] == target)
//                return new int[] {i , j };
//        }
//    }
//    return new int[] { -1, -1 };
//}

//int[] test = new int[] { 3, 2, 4 };
//Console.WriteLine($"[{string.Join(",", TwoSum(test, 6))}]");



//exercise on genrics
//return and make the genrics again write it again 

//(2)
//Utilities.Inspect(22);
//Utilities.Inspect("hellow");
//Utilities.Inspect(2.22);


//(3)

/*void Swap<T>(ref T value1, ref T value2)
{
    Console.WriteLine($"this value1 = {value1} and this value2 = {value2}");
    var temp = value2;
    value2 = value1;
    value1 = temp;
    Console.WriteLine($"this value1 = {value1} and this value2 = {value2}");
}
int a = 22 , b = 23 ;

Swap(ref a, ref b);*/




//------------------------------------------------------
// (1) A generic container class that can hold one item of any type 'T'.
/*public class Box<T>
{
    public T ?Content { get; set; }

}
//(2) // A static class for general-purpose, reusable methods.
public static class Utilities
{
    public static void Inspect<T>(T value)
    {
        Console.WriteLine(value?.GetType());
    }
}*/

//(4)


/*void ProcessEntity<T>(T entity)
    where T : IEntity
{
    Console.WriteLine(entity.Id);
}

IEntity entity = new SomeEntity { Id = 42 };

ProcessEntity(entity);

public interface IEntity
{ 
    int Id { get; set; }
}

public class SomeEntity : IEntity
{ 
    public int Id { get; set; }
}*/

//Test testtry = new();
//testtry.ID = 22;

//Repository<Test> try22 = new (testtry);
//Console.WriteLine(try22.Printall);


//public interface IEntity
//{
//    int ID { get; set; }
//}

//public class Test : IEntity
//{
//    public int ID { get; set; }
//}



////(5)
//public class Repository<T>
//    where T : IEntity
//{ 
//    public Repository(T firstitem) => items.Add(firstitem);
//    private List<T> items  =new ();

//    public void AddItem(T item)
//    { 
//        items.Add(item);
//    }

//    public T FindById(int id)
//    {
//        return items.FirstOrDefault(x => x.ID == id);

//    }

//    public void Printall()
//    {
//        Console.WriteLine(items.ToString());
//    }
//}


//genirics again (Ah, shit here we go again)
//gernics are used to create things with a placeholder for the type
// - this means that genrics dont care about type
// - cares only about type in a limitied way
// we can use genrics on classes , methods, inteface, etc ...



// ─────────────────────────── 🧭 SECTION: <1>test genric class and give type───────────────────────────


//GenricClass<int> mynumbericInstance = new GenricClass<int>();
//GenricClass<string> MyStrigInstance = new GenricClass<string>();
////GenricClass instacewithoutType = new GenricClass(); //so this will not work as no type

//// ─────────────────────────── 🧭 SECTION: <3>test normal classe with gernic methods───────────────────────
//ClassWithGernicMethod instanceofclassWithGenricMethhod = new();
//instanceofclassWithGenricMethhod.GenricMehtod("This a string");
//instanceofclassWithGenricMethhod.GenricMehtod(42);
//instanceofclassWithGenricMethhod.GenricMehtod(152.1);

//Console.WriteLine("\nthis by GenricFunction\n");
////so here we check that the GenricFunction returns the actual type
////and if we changed the string to int for the first will give us error (connot implcity from string to int)
//string GernicFunctionReustl1 = instanceofclassWithGenricMethhod.GenricFunction("this a string");
//int GernicFunctionReustl2 = instanceofclassWithGenricMethhod.GenricFunction(42);
//double GernicFunctionReustl3 = instanceofclassWithGenricMethhod.GenricFunction(152.1);

//// --------------------------- 🧭 SECTION: <4> testing existing genric ---------------------------
//List<int> ints = new List<int>();
//List<string> stringList = new List<string>();
////this becaue algorithms and data structre formany collections don't care abpoutthe type fo the elements
////that i don't care what type you are as loing as you have a parameter list constructor, i
////just need that constructor on whatever type you're giving me, and we're good to go  or sometimes

//// ─────────────────────────── 🧭 SECTION: <5>test exampele that combine everything───────────────────────────

//Dog dog1 = new(Weight:20 , Height:30);
//Dog dog2 = new(Weight:30 , Height:40);

//Cat cat1 = new(Weight:10 , Height:20, HasFur:false);
//Cat cat2 = new(Weight:20 , Height:30, HasFur:true);

//Fish fish1 = new(Weight: 0.5, Height: 1);

//var animals = new IAnimal[] { dog1, dog2, cat1, cat2, fish1 };

//Console.WriteLine("\n------------------------------\n");
//Console.WriteLine($"this the sum weight of all the animals {CalculateWeight(animals)}");
//Console.WriteLine($"this the sum height of all the animals {CalculateHeigth(animals)}");
//Console.WriteLine($"this the the animals that has fur {onlyWithFur(animals)}");

////we can also make this as it is the same type
//var totalcatWeight = new Cat[] { cat1, cat2 };
//var totaldogWeigt = new Dog[] {dog1, dog2 };
//var totalFishweight = new Fish[] { fish1 };


//Console.WriteLine($"this the total weight for cats {CalculateWeight(totalcatWeight)}");
//Console.WriteLine($"this the total weight for dogs {CalculateWeight(totaldogWeigt)}");
//Console.WriteLine($"this the total weight for HasFur {CalculateWeight(totalFishweight)}");


//static double  CalculateWeight<T>(IEnumerable<T> animals)
//    where T : IAnimal
//{ 
//    var total = animals.Sum(a => a.Weight); 
//    return total;
//}
//static double  CalculateHeigth<T>(IEnumerable<T> animals)
//    where T : IAnimal
//{ 
//    var total = animals.Sum(a => a.Height); 
//    return total;
//}

//IEnumerable<IAnimal>  onlyWithFur(IEnumerable<IAnimal> animals)
//{ 
//    return animals.Where(a => a.HasFur);
//}


//// --------------------------- 🧭 SECTION: testing up 👆 ---------------------------

//// ─────────────────────────── 🧭 SECTION: <5> exampele that combine everything───────────────────────────
////so what if we care about they type but not the exact type?
//// we can use constraints to limit the types that can be used with a generic!

//public interface IAnimal
//{
//    double Weight { get; }
//    double Height { get; }
//    bool HasFur { get; }
//}
// * so this line 👇 (record) done automatically (declares dog, create immutable properties for weight, height, hasfur)
// * also genrates a constructor that sets those properties, also implements value based equality(Equalt, GetHashcode),
// * provides Tostring() override and supprots with experssion 
// */
//public record Cat(double Weight, double Height, bool HasFur) : IAnimal;
//public record Dog(double Weight, double Height) : IAnimal
//{
//    public bool HasFur => true;
//}

//public record Fish(double Weight, double Height) : IAnimal
//{
//    public bool HasFur => false;
//}

//// ─────────────────────────── 🧭 SECTION: <3> normal classe with gernic methods───────────────────────────
////and here if we made the class gernic so we dont need to make the methods
////ass genrics it will be gernics automatically
////-The class declares<T> at the top.
////- All methods inside the class can use T directly—no need to redeclare <T> in the method.

//public class ClassWithGernicMethod
//{
//    public void GenricMehtod<T>(T value)
//    {
//        Console.WriteLine(
//            $"the type of the value is {value.GetType().Name}" +
//            $" the value is {value}");
//    }

//    public T GenricFunction<T>(T value)
//    {
//        Console.WriteLine(
//            $"the type of the value is {value.GetType().Name}" +
//            $" and the value of it is {value}");
//        return value;
//    }
//}






//// ─────────────────────────── 🧭 SECTION: <2> genirc classes ───────────────────────────

////we could also make an implemnation that specfies the type so youcan specify only the interface
////so no need from adding type to the class
//public class ImplementationwihtoutIntegerType : IGericIneterface<int>
//{ 

//}


//// ─────────────────────────── 🧭 SECTION: <1> genric interfaces and classes───────────────────────────
////we can use genrics to define an interface with atype parameter<T>
//public interface IGericIneterface<T>
//{ 
//    //not methods just creating empy interface
//}

////we can make class that implemnt this interface
//public class GenricClass<T>: IGericIneterface<T>
//{ 
//    /*
//     * so the class itesef also needs to have atype parameter on it
//     * to all caller createing instances of this class to specfiy type
//     */
//}



//-----------------------------------------------------------------------------------------------
////Tubles
////Ah shit here we go again
////what is tubles (a light weight data transfer object)
////that can contain multple values of diffrenct types 

//// Tuples in C# come in two different flavors:
//// 1. System.Tuple:
////  -reference type
////  - immutable ( you can't change it after it's created.)
////  - values are properties
////2. System.ValueTuple: a value type
////  - value type
////  - mutable
////  - values are fields

////to make sth global 
//global using colors = (byte R , byte G, byte B);
//using System.Runtime.CompilerServices;

////lets begin with the system.Tuple
//Tuple<int, string> tuple = new Tuple<int, string>(1,"one");
//Tuple<int, string> tuple2 = new (1,"one");

////system.ValueTuple

//ValueTuple<int, string> ValueTuple = new ValueTuple<int, string>(1, "one");
//ValueTuple<int, string> ValueTuple2 = new (1, "one");
//ValueTuple<int, string> ValueTuple3 = (1, "one");

//var ValueTuple4 = (1,2,3,4,5,8,6,4, "one", 0.25);

// * - we have gernics in both cases
// * - the type parameters are for each of the items the tuple will hold
// * - we know we have refrence vs value types here between both of them
// * - the sytax of the valueTuple is simpler
// * - valueTuples can take in an arbitrary number of elements
// * (You can put as many values as you want into a ValueTuple—it’s flexible, not limited to a specific number.)
// */



// * - returning multiple values from a method
// * - passing multiple values to a method
// * - grouping multiple values together
// * - all without having to go make a dedicated class
// */

////how would we return a min and max from a method before tupels
//// - use out parameters
//// - use a cusom return type
//int GetMinAndMaxOutParameter(int[] numbers, out int max)
//{
//    if (numbers.Length == 0)
//        throw new ArgumentException("cannot find min and max of an empty array");
//    int min = numbers[0];
//    max = numbers[0];

//    for (int i = 1; i < numbers.Length; i++)
//    {
//        if (numbers[i] < min)
//            min = numbers[i];
//        if (numbers[i] > max)
//            max = numbers[i];
//    }
//    return min;
//}

//int[] numbers = { 1, 2, 3, 4, 5, 7, 8, 9 };
////int min = GetMinAndMaxOutParameter(numbers, out int max);
////Console.WriteLine($"{min} this the min value and this the max value {max}");

////lets now make it with tuples

//(int, int) GetMinAndMaxWithTuple(int[] numbers)
//{
//    if (numbers.Length == 0)
//        throw new ArgumentException("cannot find min and max of an empty array");

//    int min = numbers[0];
//    int max = numbers[0];

//    for (int i = 1; i < numbers.Length; i++)
//    {
//        if (numbers[i] < min)
//            min = numbers[i];
//        if (numbers[i] > max)
//            max = numbers[i];
//    }
//    return (min, max);
//}

////Console.WriteLine("min and max with tupele");
////var MinAndMax = GetMinAndMaxWithTuple(numbers);
////Console.WriteLine($"min is {MinAndMax.Item1} and the max {MinAndMax.Item2}");
////Console.WriteLine($"the whole tuple {MinAndMax}");


//(int Min, int Max) GetMinAndMaxWithNamedTuple(int[] numbers)
//{
//    if (numbers.Length == 0)
//        throw new ArgumentException("cannot find min and max of an empty array");

//    int min = numbers[0];
//    int max = numbers[0];

//    for (int i = 1; i < numbers.Length; i++)
//    {
//        if (numbers[i] < min)
//            min = numbers[i];
//        if (numbers[i] > max)
//            max = numbers[i];
//    }
//    //return (Min: min, Max: max);
//    return (min, max);
//}
////var MinAndMaxNamed = GetMinAndMaxWithNamedTuple(numbers);
////Console.WriteLine($"with nameing min and max --> min is {MinAndMaxNamed.Min} and the max {MinAndMaxNamed.Max}");
////Console.WriteLine($"the whole tuple {MinAndMaxNamed}");



////deconstruct tubeles
//(int fristthing, string secundthing) = (1, "this the secound thing");
//(int minval, int maxval) nnn = GetMinAndMaxWithNamedTuple(numbers);
//(int minval2, _) = GetMinAndMaxWithNamedTuple(numbers); // you can also discard what you want


////just we can understan or to know the types of it in the tuple we can do use the var one out of the front
//var (firstthing, secoundthing) = (1, "hellow");

//colors newcolors= (255,0,0);
//newcolors.R = 128;


////equlity tubles
//(int, string, int) TupleA = (123, "hello", 456);
//(int, int) TupleB = (123, 456);
//(float, float) TupleC = (FirstNumber: 123, SecoundNumber: 456);
//(byte, string, float) TupleD = (FirstNumber: 123, Name: "hello", SecoundNumber: 456);
//(int, int) TupleE = (456, 789);
//(byte, string, float) TupleF = (123, "world", 456);
//(string, string) TupleG = ("hello", "world");

//Console.WriteLine($"tupelA == tupleB: {TupleA == TupleD}");
//Console.WriteLine($"tupelA == tupleF: {TupleA == TupleF}");
//Console.WriteLine($"tupelB == tupleC: {TupleB == TupleC}");
//Console.WriteLine($"tupelB == tupleE: {TupleB == TupleE}");


////if we used the .equals is not suported for to comparson so all will be false
//Console.WriteLine($"\ntupelA == tupleB: {TupleA.Equals( TupleD)}");
//Console.WriteLine($"tupelA == tupleF: {TupleA.Equals( TupleF)}");
//Console.WriteLine($"tupelB == tupleC: {TupleB.Equals (TupleC)}");
//Console.WriteLine($"tupelB == tupleE: {TupleB.Equals(TupleE)}");


////so at the end 
//// - 🔢 Cardinality matters: same number of elements & compatible types
//// - 🏷️ Element names are ignored in comparison
//// - 🔄 Order of elements IS considered
//// - 🔄 Types don't need to be identical, just compatible


//---------------------------------------------------------------------------
//here we go agin 
//lets begin with (encoding strings and bytes)


/*using System.Text;

string HelloWorld = "hello world ";
byte[] bytesForHelloWoldAscii = Encoding.ASCII.GetBytes(HelloWorld);

string hellowWorldConvertedback  = Encoding.ASCII.GetString(bytesForHelloWoldAscii);

Console.WriteLine($"converting {HelloWorld} to bytes and back with ascii");
Console.WriteLine($"original : {HelloWorld}");
Console.WriteLine($"converted {hellowWorldConvertedback}");

Console.WriteLine($"{hellowWorldConvertedback == HelloWorld}");

string unsupportedAsciiString = "😂 i'm in danger";
byte[] unsuppoortedAsciiBytes = Encoding.ASCII.GetBytes(unsupportedAsciiString);
string convertedbackfromunsupportedAscii = Encoding.ASCII.GetString(unsuppoortedAsciiBytes);

Console.WriteLine($"converting to ascii and back with unsupported cahracter");
Console.WriteLine($"orginal {unsupportedAsciiString}");
Console.WriteLine($"coverted {convertedbackfromunsupportedAscii}");
Console.WriteLine($"orignnial string length {unsupportedAsciiString.Length}");
Console.WriteLine($"coverted string length {convertedbackfromunsupportedAscii.Length}");
Console.WriteLine($"    ascii bytes length {unsuppoortedAsciiBytes.Length}");

Console.WriteLine($"string equal: {unsupportedAsciiString == convertedbackfromunsupportedAscii}");
Console.WriteLine($"firstchar equal: {unsupportedAsciiString[0] == convertedbackfromunsupportedAscii[0]}");

//so to solve that both is length is false euqal so we can solve it with converting to utf8 lets see
byte[] unsupporedstringasUtf8bytes = Encoding.UTF8.GetBytes(unsupportedAsciiString);
string UnsupportedStringAsUtf8 = Encoding.UTF8.GetString(unsupporedstringasUtf8bytes);

Console.WriteLine($"converting to utf-8 and back with original cahracter\n");
Console.WriteLine($"orginal {unsupportedAsciiString}");
Console.WriteLine($"coverted {unsupporedstringasUtf8bytes}");
Console.WriteLine($"original length {unsupportedAsciiString.Length}");
Console.WriteLine($"coverted length {UnsupportedStringAsUtf8.Length}");
Console.WriteLine($"ascii bytes length {unsuppoortedAsciiBytes.Length}");
Console.WriteLine($"Utf-8 bytes length {unsupporedstringasUtf8bytes.Length}");

Console.WriteLine($"string equal: {unsupportedAsciiString == UnsupportedStringAsUtf8}");    
Console.WriteLine($"firstchar equal: {unsupportedAsciiString[0] == UnsupportedStringAsUtf8[0]}");*/


//------------------------------------------------------------------------------------------------------
////here we go again 
////streams
//// allow us to navicate through a set of bytes
////streams privide us a common api for working with binary data
////without have to know exactly how that data is represented

////so for streams all the streams have base calss called streams
////Stream stream = new Stream();// so it will not compile as it is abstract one but the rest types
////is inherting from this base class () so sth like that come from the base class things like
//// * length
//// * current postions
//// * whether we can read from or write to 
//// * note that all the streams get theses properties / methods because they inhert from the base class
//// *  but not all fo them support all the the functionality

//using System.Text;
//--------------
// MemoryStream |
//--------------
//MemoryStream mymemorystream = new MemoryStream();

//Console.WriteLine("writting to stream");
//Console.WriteLine($"stream postion before  {mymemorystream.Position}");
//Console.WriteLine($"stream length before   {mymemorystream.Length}");
//Console.WriteLine($"stream capacity before {mymemorystream.Capacity}");

//byte[] data = Encoding.UTF8.GetBytes("hello world from kiro");
//mymemorystream.Write(data, offset: 0, count: data.Length);

//Console.WriteLine("\nwritting to stream\n");
//Console.WriteLine($"stream postion after  {mymemorystream.Position}");
//Console.WriteLine($"stream length after   {mymemorystream.Length}");
//Console.WriteLine($"stream capacity after {mymemorystream.Capacity}");

//Console.WriteLine("\nrepostioning memory strem....");
//mymemorystream.Seek(0, SeekOrigin.Begin);
////or
//mymemorystream.Position = 0; //or manually
//Console.WriteLine($"strem postion after: {mymemorystream.Position}");

////now we can read our data but 
//// how much data do we need to read?
//// where are we putting it?
//byte[] readbuffer = new byte[mymemorystream.Length];

//Console.WriteLine("\nReading from Memory Stream...");
//int NumberOfBytesRead = mymemorystream.Read(readbuffer, 0, readbuffer.Length);
//Console.WriteLine($"Number of bytes read: {NumberOfBytesRead}");

//string ReadString = Encoding.UTF8.GetString(readbuffer);
//Console.WriteLine($"Read string: {ReadString}");


////shorcut way to getting the bytes in memory stream
//Console.WriteLine("\nReading data from memory sttream using ToArry()...");
//byte[] memorybytesnew = mymemorystream.ToArray();

//ReadString = Encoding.UTF8.GetString(memorybytesnew);
//Console.WriteLine($"read string: {ReadString}");

//-------------------part 1------------------------------------------------------


//using System.Text;

//File.WriteAllText("readwritec#.txt", "hello from c#");
//File.WriteAllBytes("readwritec#.txt", Encoding.UTF8.GetBytes("hello from c#"));

//byte[] someFileBytes = File.ReadAllBytes("readwritec#.txt");
//string someFilestring = File.ReadAllText("readwritec#.txt", Encoding.UTF8);

//Console.WriteLine($"this the info read from bytes {Encoding.UTF8.GetString(someFileBytes)}" +
//    $"\nand this from string {someFilestring}");
////--------------- part 2------------------

////we can use similar methods to gain access to a stream!
//FileStream filestream = File.Open
//    (
//        "D:\\.net vs\\first try\\DeepDive_In_C#\\DeepDive_In_C#\\readwritec#.txt",
//        FileMode.OpenOrCreate,
//        FileAccess.Write,
//        FileShare.Read
//    );

//byte[] buffer = Encoding.UTF8.GetBytes("here we go agin");
//filestream.Write(buffer, 0, buffer.Length);

////we can also use the apais directly on the stream class
//Stream filestreamAsStream = filestream;
//filestream.Seek(0, SeekOrigin.Begin);
//filestreamAsStream.Write(buffer, 0, buffer.Length);

//filestream.Close();
////---------------part 3-------------------

////then we can use the very similar api for reading from a file
//FileStream readingStream = File.Open
//    (
//    "readwritec#.txt",
//    FileMode.Open,
//    FileAccess.Read,
//    FileShare.None
//    );

//byte[] bufferForereading = new byte[readingStream.Length];
//var bytesReadFromStream = readingStream.Read(bufferForereading, 0, bufferForereading.Length);
//Console.WriteLine(bytesReadFromStream);

////----------------part 4-----------------------
////but if the file is too large what we do and don't know what is the file size is 
//readingStream.Seek(0, SeekOrigin.Begin );
//StreamReader reader = new StreamReader(readingStream, encoding: Encoding.UTF8);

//while (!reader.EndOfStream)
//{ 
//    string line  = reader.ReadLine(); //this one variation nof the reader
//    Console.WriteLine(line);
//}
////------------------part 5-------------------------------
////also we can make it to read it in chunks
//int chunkSize = 5; //1024
//Console.WriteLine($"\nReading chunks of size {chunkSize} of file...");
//readingStream.Seek(0, SeekOrigin.Begin);
//byte[] bufferforchunking = new byte[chunkSize];
//while (
//    (
//    bytesReadFromStream = readingStream.Read(bufferforchunking, 0, bufferforchunking.Length)
//    )
//    > 0)
//{
//    Console.WriteLine($"Read {bytesReadFromStream} bytes for this chunk");
//}

//--------------------------------------------------------------------------------------
////using & Disposal
//// What is IDisposable ??
////      is interface we're provided with that allow us to indicate that we have
////      recources that need to be released
////when we have to use Disposal ? because c# should be handdel all of this with the gc(garabage collector)
////      - streams , files , network, memory
////      -if we are dealing with some recources don't work with the garbage collector of the c# or not in the c# lang
////          thing like a third party like sql connection

////part 1
//Stream readmeStream = File.Open("readme.txt", FileMode.Open, FileAccess.Read);
////we need to do work
////the problem here that we don't gurntee that dispose method is going to get called while our applications's running
////because also could and exception get thrown 
//readmeStream.Dispose();

////part 2
////another wayt o fixit 
//// to use try and catch 
////      so it works but...
////prblems with that 
////      that ugly look 
////      we need to implment try and catch 

//readmeStream = File.Open("readme.txt", FileMode.Open, FileAccess.Read);
//try 
//{ 
//    //to sth
//}
//catch 
//{ 
//    //to sth
//}
//finally 
//{
//    readmeStream.Dispose();
//}

////part 3
////the best practice for this situation is by using Using
////if we put anthing inside the using that is not dispoable will not combile

//using (Stream myUsingStream = File.Open("readme.txt", FileMode.Open, FileAccess.Read))
//{
//    myUsingStream.Dispose();
//}

////the best and last form part 4
////so it works we have variable defined just for the scobe and if it get out of the scope will get disposed
////so need for sth simple this one need more implemnation the previous one
////so this one when the variable is getting out the scope 
//using Stream myUsingStream2 = File.Open
//    (
//    "readme.txt",
//    FileMode.Open,
//    FileAccess.Read
//    );
//public class MyDisoposable : IDisposable
//{
//    public void Dispose()
//    { 
//            //you will do here all what you want to dispose
//    }
//}

/*using System.Diagnostics;

using (Process process = new())
{ 
    process.StartInfo.FileName = "cmd.exe";
    process.StartInfo.Arguments = "/c echo Hellow form cmd using c#";
    process.StartInfo.UseShellExecute = false;
    process.StartInfo.CreateNoWindow = true;
    process.StartInfo.RedirectStandardOutput = true;

    process.Start();
    string output  = process.StandardOutput.ReadToEnd();
    process.WaitForExit();

    Console.WriteLine($"this what we got ffrom the cmd -->>>> {output}");
}

//or we can also use it like this 
using Process process2 = new Process();
process2.StartInfo.FileName = "cmd.exe";
process2.StartInfo.Arguments = "/c echo Hellow form cmd using c# using the .net8 syntax";
//process2.StartInfo.Arguments = "/c dir";
process2.StartInfo.UseShellExecute = false;
process2.StartInfo.CreateNoWindow = true;
process2.StartInfo.RedirectStandardOutput = true;

process2.Start();
string output2 = process2.StandardOutput.ReadToEnd();
process2.WaitForExit();

Console.WriteLine($"this what we got ffrom the cmd2 -->>>> {output2}");*/

//--------------------------------------------------------------------------------
//xml and json
/*using System.Text.Json;
using System.Xml;

string rawxml =
    """
    <people>
        <person>
            <name>kiro here</name>
            <age>211</age>
        </person>
    </people>
    """;

File.WriteAllText("people.xml", rawxml);


XmlDocument xmlDocument = new();
xmlDocument.Load("people.xml");

XmlNodeList? people = xmlDocument.SelectNodes("/people/person");
if (people != null)
{
    foreach (XmlNode person in people)
    {
        Console.WriteLine(person["name"].InnerText);
        Console.WriteLine(person["age"].InnerText);
        //so to change both of them in the right format you have to split them and spcifiy them
        person["name"].InnerText = person["name"].InnerText.ToUpper();
        person["age"].InnerText = person["age"].InnerText.ToUpper();
    }
}
else
{
    Console.WriteLine("no poeple found");
}

xmlDocument.Save("people2.xml");
Console.WriteLine("\ncontent of people2\n");
Console.WriteLine(File.ReadAllText("people2.xml"));
//-------------------------------------------------------
//-----------------------------json-----------------------
//json => it's lighter weigh but accomplishes a similar goal 
//so this willnot make json and write like the xml will make objects to json (serilisation) and viceversa(deserliztion

*//* flow
 * serilizing -> deserlizing
 * string representation -> bytes representation and vicerversa
 *//*

PeopleCollection peopleCollection = new(new[]
{
    new Person("soso", 23),
    new Person("koko", 21)
});

Console.WriteLine("serlizing people to json");
string rawjson = JsonSerializer.Serialize(peopleCollection);
Console.WriteLine(rawjson);

File.WriteAllText("people.json", rawjson);

//Console.WriteLine(File.ReadAllText("people.json"));
//File.ReadAllText("people.json");

//now deserlising from json to object
//we have two way using stream and using string

Console.WriteLine("\nDesrilizing people from json using stream .....");
using var peopleJsonStream = File.OpenRead("people.json");

PeopleCollection deserilizedPeopleFromStream = JsonSerializer.Deserialize<PeopleCollection>(peopleJsonStream);

foreach (var person in deserilizedPeopleFromStream.People)
{
    Console.WriteLine($"{person.Name} : {person.Age}");
}

Console.WriteLine("Desrilizing people from json using String .....");
var deserilizedPeopleFromString = JsonSerializer.Deserialize<PeopleCollection>(File.ReadAllText("people.json"));


foreach (var person in deserilizedPeopleFromString.People)
{
    Console.WriteLine($"{person.Name} : {person.Age}");
}

*//*
For large files / performance-critical apps → use Stream 🏎️
For small/medium JSON or when you already have a string → use Text 📝
 *//*


public record Person(string Name, int Age);
public record PeopleCollection(Person[] People);*/


//----------------------------------------------------------------------
//callbacks and delegates
//so the callback is the design patter
//and you apply it with the delegates

//lets stor a mthod into an action variable
//action has no return type always void
using System.Data;
using System.Runtime.CompilerServices;

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
    

int AddFunction(int a , int b)
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
void Calculate(Func<int,int,int> calculateMehtodCallback)
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

Predicate<int> isEven = x => x%1 ==0;

Console.WriteLine(isEven.Invoke(4));

isEven.Invoke(7);


//bool iseven (int a)
//{
//    return a % 2 == 0;
//}


delegate int Calculatedelegate(int firstnumber, int secoundnumber);



